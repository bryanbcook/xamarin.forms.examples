namespace XF.CaliburnMicro1
{
    using Caliburn.Micro;
    using Caliburn.Micro.Xamarin.Forms;
    using Xamarin.Forms;
    using XF.CaliburnMicro1.ViewModels;

    public class App : FormsApplication
    {
        private readonly SimpleContainer container;

        public App(SimpleContainer container)
        {
            this.container = container;

            // TODO: Register additional viewmodels and services
            container
                .PerRequest<Main2ViewModel>()
                .PerRequest<ITabViewModel,Tab1ViewModel>()
                .PerRequest<ITabViewModel,Tab2ViewModel>()
                .PerRequest<ITabViewModel,Tab3ViewModel>()
                ;

            Initialize();

            DisplayRootViewFor<Main2ViewModel>();
        }

        protected override void PrepareViewFirst(NavigationPage navigationPage)
        {
            container.Instance<INavigationService>(new NavigationPageAdapter(navigationPage));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
