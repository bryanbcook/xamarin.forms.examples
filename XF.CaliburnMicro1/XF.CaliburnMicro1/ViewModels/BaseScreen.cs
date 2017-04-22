using Caliburn.Micro;
using System;
using System.Runtime.CompilerServices;

namespace XF.CaliburnMicro1.ViewModels
{
    public abstract class BaseScreen : Screen
    {
        protected void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Object.Equals(field, value))
            {
                field = value;
                NotifyOfPropertyChange(propertyName);
            }
        }
    }
}
