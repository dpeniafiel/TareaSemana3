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
    public partial class Nota : ContentPage
    {
        String Usuario { get; set; }
        public Nota(String usuario)
        {
            InitializeComponent();
            this.Usuario= usuario;
            usuarioLogeado.Text = usuario;
        }

        private void btnCalcularPrimerParcial_Clicked(object sender, EventArgs e)
        {
            if (notaTareas1.Text==null || notaTareas1.Text.Equals("") || notaExamen1.Text == null || notaExamen1.Text.Equals(""))
            {
                DisplayAlert("Error", "Ingrese las notas de tareas y examen del parcial 1", "OK");
                return;
            }

            var nota1 = Double.Parse(notaTareas1.Text);
            var examen1 = Double.Parse(notaExamen1.Text);
            var parcial1 = (nota1 * 0.3) + (examen1 * 0.2);
            DisplayAlert("Correcto", "Nota de primer parcial procesada con éxito.", "OK");
            notaParcial1.Text = parcial1.ToString();
        }

        private void btnCalcularSegundoParcial_Clicked(object sender, EventArgs e)
        {
            if (notaParcial1.Text.Equals(""))
            {
                DisplayAlert("Error", "Primero calcule el parcial 1.", "OK");
                return;
            }
            var nota2 = Double.Parse(notaTareas2.Text);
            var examen2 = Double.Parse(notaExamen2.Text);
            var parcial2 = (nota2 * 0.3) + (examen2 * 0.2);
            DisplayAlert("Correcto", "Nota de segundo parcial procesada con éxito.", "OK");
            notaParcial2.Text = parcial2.ToString();
        }

        private void btnCalcularNotaFinal_Clicked(object sender, EventArgs e)
        {
            if (notaParcial1.Text.Equals(""))
            {
                DisplayAlert("Error", "Primero calcule el parcial 1.", "OK");
                return;
            }
            if (notaParcial2.Text.Equals(""))
            {
                DisplayAlert("Error", "Primero calcule el parcial 2.", "OK");
                return;
            }
            var parcial1 = Double.Parse(notaParcial1.Text);
            var parcial2 = Double.Parse(notaParcial2.Text);
            var notaFinalCalculada = parcial1 + parcial2;
            var notaFinalCualitativo = ObtenerCalificacionCualitativa(notaFinalCalculada);
            DisplayAlert("Correcto", "Nota final procesada con éxito.", "OK");
            notaFinal.Text = notaFinalCalculada.ToString() + " (" + notaFinalCualitativo + ")";
        }

        private static string ObtenerCalificacionCualitativa(double notaFinalCalculada)
        {
            string notaFinalCualitativo;
            if (notaFinalCalculada < 5)
            {
                notaFinalCualitativo = "REPROBADO";
            }
            else if (notaFinalCalculada >=5 && notaFinalCalculada < 7)
            {
                notaFinalCualitativo = "EXAMEN COMPLEMENTARIO";
            }
            else
            {
                notaFinalCualitativo = "APROBADO";
            }

            return notaFinalCualitativo;
        }

        private void ValidarNota(TextChangedEventArgs e, Entry entry)
        {
            if (e.NewTextValue != null && !e.NewTextValue.Equals(""))
            {
                try
                {
                    var valor = Double.Parse(e.NewTextValue);
                    if (valor < 0 || valor > 10)
                    {
                        DisplayAlert("Advertencia", "La nota debe ser establecida entre 0 y 10", "OK");
                        entry.Text = e.OldTextValue;
                    }
                }
                catch
                {
                    DisplayAlert("Advertencia", "La nota debe ser establecida entre 0 y 10", "OK");
                }
            }
        }

        private void notaTareas1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarNota(e,notaTareas1);
            notaParcial1.Text = "";
            notaFinal.Text = "";
        }

       

        private void notaExamen1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarNota(e, notaExamen1);
            notaParcial1.Text = "";
            notaFinal.Text = "";
        }

        private void notaTareas2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarNota(e, notaTareas2);
            notaParcial2.Text = "";
            notaFinal.Text = "";
        }

        private void notaExamen2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarNota(e, notaExamen2);
            notaParcial2.Text = "";
            notaFinal.Text = "";
        }
    }
}