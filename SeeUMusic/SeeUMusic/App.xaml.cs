using SeeUMusic.Helpers;
using SeeUMusic.View;
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
            await FileAccess.CopyVideoIfNotExists("XamarinForms101UsingEmbeddedImages.mp4");
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
