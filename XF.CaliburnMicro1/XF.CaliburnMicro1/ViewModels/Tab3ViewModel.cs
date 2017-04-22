

namespace XF.CaliburnMicro1.ViewModels
{
    using Caliburn.Micro;
    using Xamarin.Forms.Maps;
    using XF.CaliburnMicro1.Views;

    public class Tab3ViewModel : BaseScreen, ITabViewModel
    {
        private Map _map;
        private Pin _selectedPin;
        private MapSpan _visibleRegion;
        private string _selectedPinIndex;

        public Tab3ViewModel()
        {
            Pins = new BindableCollection<Pin>();

            SelectPinCommand = new DelegateCommand(o =>
            {
                var index = int.Parse(o.ToString());

                SelectedPin = Pins[index - 1];
                SelectedPinIndex = index.ToString();
            });

            NewPinCommand = new DelegateCommand((o) =>
            {
                var position = MapControl.VisibleRegion.Center;
                var pin = Create("New!", position.Latitude, position.Longitude);
                Pins.Add(pin);
                
            });

        }

        public string Icon => "Tab3.png";

        public int SortOrder => 2;

        public string Title => "Tab 3";

        public BindableCollection<Pin> Pins { get; protected set; }

        public Pin SelectedPin
        {
            get { return _selectedPin; }
            set { SetField(ref _selectedPin, value); }
        }

        public string SelectedPinIndex
        {
            get { return _selectedPinIndex; }
            set { SetField(ref _selectedPinIndex, value); }
        }

        public MapSpan VisibleRegion
        {
            get { return _visibleRegion; }
            set { SetField(ref _visibleRegion, value); }
        }

        public DelegateCommand NewPinCommand { get; set; }

        public DelegateCommand SelectPinCommand { get; set; }

        internal Map MapControl
        {
            get { return _map; }
            set
            {
                if (_map != null)
                {
                    // unregister events
                }

                _map = value;

                if (_map != null)
                {
                    // wire-up events
                }
            }
        }

        protected override void OnViewAttached(object view, object context)
        {
            var mapView = view as IMapAware;
            if (mapView != null)
            {
                MapControl = mapView.GetMap();
            }
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            Pins.Clear();

            // top 4 largest cities in north america
            Pins.Add(Create("Mexico City", 19.4326, -99.1332));
            Pins.Add(Create("New York", 40.7128, -74.0059));
            Pins.Add(Create("Los Angeles", 34.0522, -118.2437));
            Pins.Add(Create("Toronto", 43.6532, -79.3832));
        }

        private Pin Create(string label, double lat, double longitude)
        {
            return
                  new Pin
                  {
                      Label = label,
                      Position = new Position(lat, longitude),
                      Type = PinType.Generic
                  };
        }
    }
}
