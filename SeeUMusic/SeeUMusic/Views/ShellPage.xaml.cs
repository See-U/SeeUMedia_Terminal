using NeteaseCloudMusicApi;
using Newtonsoft.Json.Linq;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SeeUMusic.ViewModels.SongVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeeUMusic.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShellPage : TabbedPage
    {
		public ICommand NavigateCommand { get; private set; }
		private SongViewModel songViewModel = new SongViewModel();

		public ShellPage()
        {
            InitializeComponent();
			NavigateCommand = new Command<Type>(async (Type pageType) =>
			{
				PopupPage page = (PopupPage)Activator.CreateInstance(pageType);
				await PopupNavigation.Instance.PushAsync(page);
			});

			BindingContext = songViewModel;
			//Main();
			//http://music.163.com/api/playlist/detail?id=387699500
			//http://music.163.com/song/media/outer/url?id=281951.mp3
		}
	}
}