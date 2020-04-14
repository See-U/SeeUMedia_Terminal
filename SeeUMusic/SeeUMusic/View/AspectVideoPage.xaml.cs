using SeeUMusic.Controls;
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
    public partial class AspectVideoPage : ContentPage
    {
        public AspectVideoPage()
        {
            InitializeComponent();
        }

        void OnAspectSelectedIndexChanged(object sender, EventArgs e)
        {
            mediaElement.Aspect = (Aspect)(sender as EnumPicker).SelectedItem;
        }
    }
}