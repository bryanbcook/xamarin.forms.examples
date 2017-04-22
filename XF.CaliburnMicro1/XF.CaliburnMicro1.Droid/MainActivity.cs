using Android.App;
using Android.Content.PM;
using Android.OS;

using Xamarin.Forms.Platform.Android;

using Caliburn.Micro;

namespace XF.CaliburnMicro1.Droid
{
    [Activity(
        Label = "XF.CaliburnMicro1", 
        Icon = "@drawable/icon", 
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            global::Xamarin.FormsMaps.Init(this, bundle);

            // Resolve the App class to use the singleton we created
            LoadApplication(IoC.Get<App>());
        }
    }
}

