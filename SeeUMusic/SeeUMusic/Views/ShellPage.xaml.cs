using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SeeUMusic.Models.SongModel;
using SeeUMusic.ViewModels.SongVM;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeeUMusic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShellPage : TabbedPage
    {
        // ICommand implementations
        public ICommand NavigateCommand { get; private set; }

		public ShellPage()
        {
            InitializeComponent();
			NavigateCommand = new Command<Type>(async (Type pageType) =>
			{
				PopupPage page = (PopupPage)Activator.CreateInstance(pageType);
				await PopupNavigation.Instance.PushAsync(page);
			});
			//Main();
			//http://music.163.com/api/playlist/detail?id=387699500
			//http://music.163.com/song/media/outer/url?id=281951.mp3
			//https://music.163.com/outchain/player?type=2&id=34899758&auto=1&height=66&bg=e8e8e8

		}
	}
}