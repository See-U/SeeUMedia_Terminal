//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("SeeUMusic.View.VideoView.VideoPage.xaml", "View/VideoView/VideoPage.xaml", typeof(global::SeeUMusic.View.VideoView.VideoPage))]

namespace SeeUMusic.View.VideoView {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("View\\VideoView\\VideoPage.xaml")]
    public partial class VideoPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.MediaElement mediaElement;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::SeeUMusic.Controls.EnumPicker aspectEnumPicker;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(VideoPage));
            mediaElement = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.MediaElement>(this, "mediaElement");
            aspectEnumPicker = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::SeeUMusic.Controls.EnumPicker>(this, "aspectEnumPicker");
        }
    }
}
