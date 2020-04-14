using SeeUMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeeUMusic.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayLibraryVideoPage : ContentPage
    {
        public PlayLibraryVideoPage()
        {
            InitializeComponent();
        }

        async void OnShowVideoLibraryButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.IsEnabled = false;

            string filename = await DependencyService.Get<IVideoPicker>().GetVideoFileAsync();
            if (!string.IsNullOrWhiteSpace(filename))
            {
                mediaElement.Source = new FileMediaSource
                {
                    File = filename
                };
            }

            button.IsEnabled = true;
        }
    }
}