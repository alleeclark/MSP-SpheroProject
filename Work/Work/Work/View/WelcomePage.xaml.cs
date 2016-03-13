using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Work.View
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

       public void GoToConnectPage(object sender, EventArgs args)
        {
            Navigation.PushAsync(new SpheroConnect());
        }

    }
}
