namespace XF.CaliburnMicro1.ViewModels
{
    using System;
    using Caliburn.Micro;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Controls;

    public interface ITabViewModel
    {
        string Title { get; }
        string Icon { get; }
        int SortOrder { get; }
    }

    public class Main2ViewModel : Conductor<Screen>.Collection.OneActive
    {
        public Main2ViewModel(IEnumerable<ITabViewModel> tabs)
        {
            if (tabs.Any())
            {
                foreach (var tab in tabs.OrderBy(i => i.SortOrder))
                {
                    Items.Add((Screen)tab);
                }

                ActivateItem(Items[0]);
            }
        }
    }
}

