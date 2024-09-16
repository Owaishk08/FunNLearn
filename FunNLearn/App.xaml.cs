using FunNLearn.Pages;

namespace FunNLearn
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
        }
    }
}
