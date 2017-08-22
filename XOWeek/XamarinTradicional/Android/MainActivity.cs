using Android.App;
using Android.Widget;
using Android.OS;
using Core;

namespace Android
{
    [Activity(Label = "Android", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
		private Button _btCarregar;
		private TextView _lbDescricao;
        private Evento _evento;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

			_btCarregar = (Button)this.FindViewById(Resource.Id.btCarregar);
			_lbDescricao = (TextView)this.FindViewById(Resource.Id.lbDescricao);
            _evento = new Evento();

            _btCarregar.Click += delegate {
                _lbDescricao.Text = _evento.GetInfo();
            };
        }
    }
}

