using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF.CaliburnMicro1.ViewModels
{
    public class Tab1ViewModel : Screen, ITabViewModel
    {
        public Tab1ViewModel()
        {
            Tab1Content = "Tab 1 Content";
            DisplayName = "Tab1";
        }

        public string Tab1Content { get; set; }

        public string Icon => "Tab1.png";

        public int SortOrder => 0;

        public string Title => "Tab1";

        protected override void OnActivate()
        {
            base.OnActivate();
        }
    }
}
