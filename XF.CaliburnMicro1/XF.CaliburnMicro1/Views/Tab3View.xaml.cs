namespace XF.CaliburnMicro1.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Maps;

    public interface IMapAware
    {
        Map GetMap();
    }
}

namespace XF.CaliburnMicro1.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Maps;

    public partial class Tab3View : ContentView, IMapAware
    {
        public Tab3View()
        {
            InitializeComponent();
        }

        public Map GetMap()
        {
            return map;
        }
    }
}
