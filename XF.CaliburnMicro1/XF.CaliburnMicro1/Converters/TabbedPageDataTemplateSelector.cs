namespace XF.CaliburnMicro1.Converters
{
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;
    using Caliburn.Micro.Xamarin.Forms;
    using Xamarin.Forms;    

    public class TabbedPageDataTemplateSelector : DataTemplateSelector
    {
        private readonly Dictionary<Type, DataTemplate> _selectors;

        public TabbedPageDataTemplateSelector()
        {
            _selectors = new Dictionary<Type, DataTemplate>();
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Type viewModelType = item.GetType();

            DataTemplate template = null;

            // check if we've already found the datatemplate for this view
            if (!_selectors.TryGetValue(viewModelType, out template))
            {
                // use caliburn to find the View for this viewmodel
                Type viewType = ViewLocator.LocateTypeForModelType(viewModelType, null, null);

                template = new DataTemplate(() =>
                {
                    var view = Activator.CreateInstance(viewType);

                    var bindableObject = view as BindableObject;

                    if (bindableObject != null)
                    {
                        // when the view's content changes...
                        bindableObject.BindingContextChanged += (sender, args) =>
                        {
                            var page = sender as Page;

                            // leverage a caliburn view lifecyle event
                            // if the viewmodel supports it
                            var viewAware = page?.BindingContext as IViewAware;
                            viewAware?.AttachView(page);
                        };
                    }

                    return view;
                });

                // cache the datatemplate
                _selectors.Add(viewModelType, template);
            }

            // return the correct view for the viewmodel
            return template;
        }
    }
}
