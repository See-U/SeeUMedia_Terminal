using SeeUMusic.Helpers;
using SeeUMusic.Views;
using Xamarin.Forms;

namespace SeeUMusic
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] { "MediaElement_Experimental" });
            InitializeComponent();
        }

        protected override async void OnStart()
        {
            //await FileAccess.CopyVideoIfNotExists("XamarinForms101UsingEmbeddedImages.mp4");
            //MainPage = new NavigationPage(new MainPage());
            MainPage = new ShellPage();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
