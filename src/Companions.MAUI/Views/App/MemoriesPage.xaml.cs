using Companions.MAUI.ViewModels.App;

namespace Companions.MAUI.Views.App;

public partial class MemoriesPage : ContentPage
{
    public MemoriesPage(MemoriesPageViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }

}