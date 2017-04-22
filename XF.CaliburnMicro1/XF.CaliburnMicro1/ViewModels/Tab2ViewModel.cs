using XF.CaliburnMicro1.Controls;

namespace XF.CaliburnMicro1.ViewModels
{
    public class Tab2ViewModel : BaseScreen, ITabViewModel
    {
        private bool _showDialog;
        private string _result;
        private ActionSheetParameters _parameters;

        public Tab2ViewModel()
        {
            Tab2Content = "Tab 2 Content";
            DisplayName = "Tab2";
            ShowDialogCommand = new DelegateCommand((o) =>
            {
                DialogParameters = new ActionSheetParameters
                {
                    Title = "Choose Wisely",
                    Buttons = new string[] { "One", "Two", "Blue" }
                };

                ShowDialog = false;
                ShowDialog = true;
            });
        }

        public string Tab2Content { get; set; }

        public string Icon => "Tab2.png";

        public int SortOrder => 0;

        public string Title => "Tab 2";

        public bool ShowDialog
        {
            get { return _showDialog; }
            set { SetField(ref _showDialog, value); }
        }

        public string Result
        {
            get { return _result; }
            set { SetField(ref _result, value); }
        }

        public ActionSheetParameters DialogParameters
        {
            get { return _parameters; }
            set { SetField(ref _parameters, value); }
        }

        public DelegateCommand ShowDialogCommand
        {
            get;
            protected set;
        }

        public DelegateCommand ResultSelectedCommand
        {
            get;
            protected set;
        }
    }
}
