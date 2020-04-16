using SeeUMusic.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeeUMusic.View.Video
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPage : ContentPage
    {
        public VideoPage()
        {
            InitializeComponent();
        }

        void OnAspectSelectedIndexChanged(object sender, EventArgs e)
        {
            mediaElement.Aspect = (Aspect)(sender as EnumPicker).SelectedItem;
        }
    }
}