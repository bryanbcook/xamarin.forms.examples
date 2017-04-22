using Caliburn.Micro;

namespace XF.CaliburnMicro1.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(IoC.Get<XF.CaliburnMicro1.App>());
        }
    }
}
