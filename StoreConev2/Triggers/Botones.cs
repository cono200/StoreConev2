using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoreConev2.Triggers
{
    internal class Botones : TriggerAction<Button>
    {
        protected override async void Invoke(Button btn)
        {
            //HAce que cambie de color al dar clic y despues de un tiempo regresar a su color original
            //btn.BackgroundColor = Color.DarkOrange;
            //btn.Text = "Here we go!!!";
            //    await Task.Delay(500);
            //    btn.BackgroundColor = Color.Tomato;


            // Cambiar el color y el texto del botón cuando se hace clic
            btn.BackgroundColor = Color.Transparent;

            // Manejar el evento Pressed para cambiar el color del botón cuando se hace clic
            btn.Pressed += Btn_Pressed;

            // Manejar el evento Released para cambiar el color del botón cuando se deja de hacer clic
            btn.Released += Btn_Released;
        }

        private void Btn_Pressed(object sender, EventArgs e)
        {
            // Cambiar el color del botón cuando se hace clic
            ((Button)sender).BackgroundColor = Color.Brown;
        }

        private void Btn_Released(object sender, EventArgs e)
        {
            // Restaurar el color original del botón cuando se deja de hacer clic
            ((Button)sender).BackgroundColor = Color.Default;
        }
    }
}