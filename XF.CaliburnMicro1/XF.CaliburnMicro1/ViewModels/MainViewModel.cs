using Caliburn.Micro;
using System.Runtime.CompilerServices;

namespace XF.CaliburnMicro1.ViewModels
{
    public class MainViewModel : Screen
    {
        private string _mainText;

        public MainViewModel()
        {
            MainText = "Hello from Caliburn.Micro!";
        }

        public string MainText
        {
            get { return _mainText; }
            set
            {
                SetField(ref _mainText, value);
            }
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(field, value))
            {
                field = value;
                NotifyOfPropertyChange(propertyName);
                return true;
            }
            return false;
        }
    }
}
