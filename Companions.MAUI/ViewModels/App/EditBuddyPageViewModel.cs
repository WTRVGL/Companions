using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Image = Companions.MAUI.Models.App.Image;

namespace Companions.MAUI.ViewModels.App
{
    [QueryProperty("Buddy", "Buddy")]
    public partial class EditBuddyPageViewModel : BaseViewModel
    {
        private readonly IBuddyService _buddyService;
        private readonly IGoogleService _googleService;
        public EditBuddyPageViewModel(IBuddyService buddyService, IGoogleService googleService)
        {
            _buddyService = buddyService;
            _googleService = googleService;
        }

        [ObservableProperty]
        private Buddy _buddy;
        [ObservableProperty]
        private Image _selectedImage;
        [ObservableProperty]
        private string _selectedGender;
        [ObservableProperty]
        private ObservableCollection<Image> _buddyImages;

        [RelayCommand]
        async void GoBack()
        {
            var newBuddy = Buddy;

            if (SelectedGender != null)
            {
                newBuddy.Gender = SelectedGender;
            }

            _buddyService.UpdateBuddy(newBuddy);

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        async void ImageSelected()
        {

        }

        [RelayCommand]
        async void AddImageTapped()
        {
            var result = await FilePicker.Default.PickAsync();
            if (result != null)
            {
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {

                    var file = await result.OpenReadAsync();
                    var url = await _googleService.UploadImage(file);

                    var image = new Image
                    {
                        BuddyId = Buddy.Id,
                        ImageURL = url
                    };

                    BuddyImages.Add(image);

                    //db update

                }
            }

        }

        partial void OnBuddyChanged(Buddy buddy)
        {
            BuddyImages = buddy.Images.ToObservableCollection();
        }
    }
}
