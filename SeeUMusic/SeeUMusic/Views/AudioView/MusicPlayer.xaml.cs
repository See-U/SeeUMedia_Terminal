using SeeUMusic.ViewModels.SongVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeeUMusic.Views.AudioView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MusicPlayer : ContentPage
    {
        public MusicPlayer()
        {
            InitializeComponent();
            SongViewModel songViewModel = new SongViewModel(mediaElement);
            BindingContext = songViewModel;
        }
    }
}