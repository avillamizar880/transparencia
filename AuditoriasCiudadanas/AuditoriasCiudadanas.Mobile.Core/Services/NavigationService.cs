using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AuditoriasCiudadanas.Mobile.Core.Infraestructure;
using Xamarin.Forms;

namespace AuditoriasCiudadanas.Mobile.Core.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<AppPages, Type> _pagesByKey = new Dictionary<AppPages, Type>();

        private NavigationPage _navigation;

        public string CurrentPageKey
        {
            get
            {
                lock (_pagesByKey)
                {
                    if (_navigation.CurrentPage == null)
                    {
                        return null;
                    }

                    var pageType = _navigation.CurrentPage.GetType();

                    return _pagesByKey.ContainsValue(pageType) ? _pagesByKey.First(p => p.Value == pageType).Key.ToString() : null;
                }
            }
        }

        public void GoBack()
        {
            lock (_pagesByKey)
            {
                _navigation.PopAsync();
            }
        }

        public void NavigateTo(AppPages pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(AppPages pageKey, object parameter)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    var type = _pagesByKey[pageKey];
                    ConstructorInfo constructor;
                    object[] parameters;

                    if (parameter == null)
                    {
                        constructor = type.GetTypeInfo().DeclaredConstructors.FirstOrDefault(c => !c.GetParameters().Any());

                        parameters = new object[] { };
                    }
                    else
                    {
                        constructor = type.GetTypeInfo().DeclaredConstructors.FirstOrDefault(c =>
                                {
                                    var p = c.GetParameters();
                                    return p.Count() == 1
                                           && p[0].ParameterType == parameter.GetType();
                                });

                        parameters = new[] { parameter };
                    }

                    if (constructor == null)
                    {
                        throw new InvalidOperationException($"No suitable constructor found for page {pageKey}");
                    }

                    var page = constructor.Invoke(parameters) as Page;

                     _navigation.PushAsync(page);
                }
                else
                {
                    throw new ArgumentException($"No such page: {pageKey}. Did you forget to call NavigationService.Configure?", nameof(pageKey));
                }
            }
        }

        public void Configure(AppPages pageKey, Type pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    _pagesByKey[pageKey] = pageType;
                }
                else
                {
                    _pagesByKey.Add(pageKey, pageType);
                }
            }
        }
        
        public void Initialize(NavigationPage navigation)
        {
            _navigation = navigation;
        }
    }
}