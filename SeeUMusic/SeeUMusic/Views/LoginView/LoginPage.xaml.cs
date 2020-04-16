using Rg.Plugins.Popup.Pages;
using SeeUMusic.ViewModels.LoginVM;
using System;
using System.Globalization;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeeUMusic.Views.LoginView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : PopupPage
	{
        public LoginPage()
        {
            InitializeComponent();
			BindingContext = new LoginViewModel();
		}
	}

	/// <summary>
	/// Converts an Entry's Text.Length into a 'flag'
	///  * Entry is empty, returns 1
	/// 
	/// </summary>
	public class MultiTriggerConverter : IValueConverter
	{
		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{
			var cnt = (int)value;
			if (cnt > 0)
				return true;    // data has been entered
			else
				return false;   // input is empty
		}

		public object ConvertBack(object value, Type targetType,
			object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}