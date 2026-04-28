using WorkoutPlaner.Core.ViewModels;

namespace WorkoutPlaner.Gui
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }

    }
}
