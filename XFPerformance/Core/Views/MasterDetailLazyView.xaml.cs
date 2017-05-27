using System;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class MasterDetailLazyView : MasterDetailPage
    {
        public MasterDetailLazyView()
        {
            InitializeComponent();
        }

		void OpenDetail(object sender, EventArgs e)
		{
			Detail = new NavigationPage(new DetailLazyView());
			IsPresented = false;
		}
    }
}
