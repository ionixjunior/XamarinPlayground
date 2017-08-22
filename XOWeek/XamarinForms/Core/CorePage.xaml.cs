using Xamarin.Forms;

namespace Core
{
    public partial class CorePage : ContentPage
    {
        private Evento _evento;

        public CorePage()
        {
            InitializeComponent();
            _evento = new Evento();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            lbDescricao.Text = _evento.GetInfo();
        }
    }
}
