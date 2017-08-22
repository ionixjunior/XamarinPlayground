using Foundation;
using System;
using UIKit;
using Core;

namespace iOS
{
    public partial class ViewController : UIViewController
    {
        private Evento _evento;

        public ViewController (IntPtr handle) : base (handle)
        {
            _evento = new Evento();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        partial void btCarregar(UIButton sender)
        {
            lbDescricao.Text = _evento.GetInfo();
        }
    }
}