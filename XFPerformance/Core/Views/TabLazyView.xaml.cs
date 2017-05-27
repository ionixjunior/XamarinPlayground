using System;
using System.Collections.Generic;
using Core.Contents;
using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class TabLazyView : TabbedPage
    {
        private long _timestamp;
        private List<Page> _loadedPages = new List<Page>();

        public TabLazyView()
        {
            InitializeComponent();
            BindingContext = new SampleViewModel();
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
			_timestamp = DateTime.Now.AddSeconds(1).Ticks;

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                if (DateTime.Now.Ticks < _timestamp)
                    return false;

                if (_loadedPages.Contains(CurrentPage))
                    return false;
                
                _loadedPages.Add(CurrentPage);

                // lógica para carregar conteúdo correto
                (CurrentPage as ContentPage).Content = new SampleContent();

                return false;
            });
        }
    }
}
