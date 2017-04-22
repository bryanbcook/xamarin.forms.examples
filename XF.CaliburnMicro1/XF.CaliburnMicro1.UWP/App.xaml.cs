using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Reflection;
using Windows.ApplicationModel.Activation;
using XF.CaliburnMicro1.ViewModels;

namespace XF.CaliburnMicro1.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    //    sealed partial class App : Application
    //    {
    //        /// <summary>
    //        /// Initializes the singleton application object.  This is the first line of authored code
    //        /// executed, and as such is the logical equivalent of main() or WinMain().
    //        /// </summary>
    //        public App()
    //        {
    //            this.InitializeComponent();
    //            this.Suspending += OnSuspending;
    //        }

    //        /// <summary>
    //        /// Invoked when the application is launched normally by the end user.  Other entry points
    //        /// will be used such as when the application is launched to open a specific file.
    //        /// </summary>
    //        /// <param name="e">Details about the launch request and process.</param>
    //        protected override void OnLaunched(LaunchActivatedEventArgs e)
    //        {

    //#if DEBUG
    //            if (System.Diagnostics.Debugger.IsAttached)
    //            {
    //                this.DebugSettings.EnableFrameRateCounter = true;
    //            }
    //#endif

    //            Frame rootFrame = Window.Current.Content as Frame;

    //            // Do not repeat app initialization when the Window already has content,
    //            // just ensure that the window is active
    //            if (rootFrame == null)
    //            {
    //                // Create a Frame to act as the navigation context and navigate to the first page
    //                rootFrame = new Frame();

    //                rootFrame.NavigationFailed += OnNavigationFailed;

    //                Xamarin.Forms.Forms.Init(e);

    //                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
    //                {
    //                    //TODO: Load state from previously suspended application
    //                }

    //                // Place the frame in the current Window
    //                Window.Current.Content = rootFrame;
    //            }

    //            if (rootFrame.Content == null)
    //            {
    //                // When the navigation stack isn't restored navigate to the first page,
    //                // configuring the new page by passing required information as a navigation
    //                // parameter
    //                rootFrame.Navigate(typeof(MainPage), e.Arguments);
    //            }
    //            // Ensure the current window is active
    //            Window.Current.Activate();
    //        }

    //        /// <summary>
    //        /// Invoked when Navigation to a certain page fails
    //        /// </summary>
    //        /// <param name="sender">The Frame which failed navigation</param>
    //        /// <param name="e">Details about the navigation failure</param>
    //        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
    //        {
    //            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
    //        }

    //        /// <summary>
    //        /// Invoked when application execution is being suspended.  Application state is saved
    //        /// without knowing whether the application will be terminated or resumed with the contents
    //        /// of memory still intact.
    //        /// </summary>
    //        /// <param name="sender">The source of the suspend request.</param>
    //        /// <param name="e">Details about the suspend request.</param>
    //        private void OnSuspending(object sender, SuspendingEventArgs e)
    //        {
    //            var deferral = e.SuspendingOperation.GetDeferral();
    //            //TODO: Save application state and stop any background activity
    //            deferral.Complete();
    //        }
    //    }

    sealed partial class App
    {
        private WinRTContainer _container;

        public App()
        {
            InitializeComponent();
            this.UnhandledException += (o, e) =>
            {
                System.Diagnostics.Debugger.Break();
            };
        }

        protected override void Configure()
        {
            _container = new WinRTContainer();
            _container.RegisterWinRTServices();

            _container.Singleton<XF.CaliburnMicro1.App>();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
                return;

            Xamarin.Forms.Forms.Init(args);
            Xamarin.FormsMaps.Init("f6ZrO7ow0zlKXBd4Deoc~fhcElURWlNJgdoAwdr4OPQ~AoRpcSZYX6h0LfgJaqLM36LiM02-x3TizVw6ygEuu4l4NiP9Js85b6TCh0vSszaO"); // UWP 10 Key for City.Scramble.Dev obtained from Bing Maps web site https://www.bingmapsportal.com/Application

            // loads our MainPage as the root frame
            DisplayRootView<MainPage>();
        }

        #region IoC Overrides
        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[]
            {
                GetType().GetTypeInfo().Assembly,
                typeof(MainViewModel).GetTypeInfo().Assembly
            };
        } 
        #endregion
    }
}
