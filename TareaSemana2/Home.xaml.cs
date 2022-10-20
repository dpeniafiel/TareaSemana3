using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaSemana2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        String Usuario { get; set; }
        public Home(String usuario)
        {
            InitializeComponent();
            this.Usuario = usuario;
            usuarioLogeado.Text = usuario;
        }

        private void btnIngresarCalificaciones_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Nota(this.Usuario));
        }
    }
}