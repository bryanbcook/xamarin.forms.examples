using Foundation;
using UIKit;

using Caliburn.Micro;
using Xamarin.Forms.Platform.iOS;

namespace XF.CaliburnMicro1.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        private readonly CaliburnAppDelegate appDelegate = new CaliburnAppDelegate();

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            global::Xamarin.FormsMaps.Init();

            LoadApplication(IoC.Get<App>());

            return base.FinishedLaunching(app, options);
        }
    }
}
