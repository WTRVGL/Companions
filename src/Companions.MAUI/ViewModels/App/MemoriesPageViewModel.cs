using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Companions.MAUI.Models.App;
using Companions.MAUI.Services.Interface;
using Syncfusion.Maui.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Image = Companions.MAUI.Models.App.Image;

namespace Companions.MAUI.ViewModels.App
{
    public partial class MemoriesPageViewModel : BaseViewModel
    {
        private readonly IBuddyService _buddyService;
        private readonly IGoogleService _googleService;
        public MemoriesPageViewModel(IBuddyService buddyService, IGoogleService googleService)
        {
            _buddyService = buddyService;
            _googleService = googleService;
        }

        [ObservableProperty]
        ObservableCollection<BuddyImages> _buddyImages;


        [RelayCommand]
        async void PageAppearing()
        {
            BuddyImages = new ObservableCollection<BuddyImages>();
            var buddies = await _buddyService.GetBuddies();
            foreach (var buddy in buddies)
            {
                BuddyImages.Add(new BuddyImages { BuddyName = buddy.Name, Images = buddy.Images, BuddyId = buddy.Id });
            }
        }

        [RelayCommand]
        async void AddBuddyImage(string buddyId)
        {
            //Select files
            var result = await FilePicker.Default.PickMultipleAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    if (item.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    item.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        IsBusy = true;
                        var file = await item.OpenReadAsync();
                        var url = await _googleService.UploadImage(file);

                        var image = new Image
                        {
                            BuddyId = buddyId,
                            ImageURL = url
                        };

                        //Sync UI
                        var buddy = BuddyImages.FirstOrDefault(b => b.BuddyId == buddyId);
                        var index = BuddyImages.IndexOf(buddy);
                        BuddyImages[index].Images.Add(image);

                        //Update DB
                        await _buddyService.AddImage(image);
                        IsBusy = false;
                    }
                }
            }
        }
    }
}