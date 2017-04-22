using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace XF.CaliburnMicro1.Controls
{
    using Xamarin.Forms;
    using Xamarin.Forms.Maps;

    public class CustomMap : Map
    {
        #region PinsItemSource
        public static BindableProperty PinsItemsSourceProperty =
            BindableProperty.Create(
                "PinsItemsSource",
                typeof(IEnumerable<Pin>),
                typeof(CustomMap),
                default(IEnumerable<Pin>),
                propertyChanged: OnPinsItemsSourcePropertyChanged);

        public IEnumerable<Pin> PinsItemsSource
        {
            get { return (IEnumerable<Pin>)GetValue(PinsItemsSourceProperty); }
            set { SetValue(PinsItemsSourceProperty, value); }
        }

        private static void OnPinsItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomMap)bindable;

            control.PinsCollection = newValue as IObservableCollection<Pin>;
        }
        #endregion

        #region SelectedItem
        public static BindableProperty SelectedItemProperty =
            BindableProperty.Create(
                "SelectedItem",
                typeof(Pin),
                typeof(CustomMap),
                null,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: OnSelectedItemChanged
                );

        public Pin SelectedItem
        {
            get { return (Pin)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var map = (CustomMap)bindable;
            var pin = newValue as Pin;
            if (pin != null)
            {
                Distance distance = map.VisibleRegion.Radius;
                MapSpan region = MapSpan.FromCenterAndRadius(pin.Position, distance);
                map.MoveToRegion(region);
            }
        }
        #endregion

        #region MapCenter
        public static BindableProperty MapCenterProperty =
            BindableProperty.Create(
                "MapCenter",
                typeof(MapSpan),
                typeof(CustomMap),
                null);

        public MapSpan MapCenter
        {
            get { return (MapSpan)GetValue(MapCenterProperty); }
            set { SetValue(MapCenterProperty, value); }
        }

        #endregion


        public CustomMap()
        {
        }

        private IObservableCollection<Pin> _collection;

        protected IObservableCollection<Pin> PinsCollection
        {
            get { return _collection; }
            set
            {
                if (_collection != null)
                {
                    _collection.CollectionChanged -= OnObservableCollectionChanged;
                }

                _collection = value;

                if (_collection != null)
                {
                    _collection.CollectionChanged += OnObservableCollectionChanged;
                }
            }
        }

        private void OnObservableCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Pin pin in e.NewItems)
                {
                    pin.Clicked += OnPinClicked;
                    Pins.Add(pin);
                }
            }

            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Pin pin in e.NewItems)
                {
                    pin.Clicked -= OnPinClicked;
                    Pins.Remove(pin);
                }
            }
        }

        private void OnPinClicked(object sender, EventArgs e)
        {
            SelectedItem = (Pin)sender;
        }
        
        
    }
}
