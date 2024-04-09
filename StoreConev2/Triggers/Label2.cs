using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StoreConev2.Triggers
{
    public class Label2 : TriggerAction<Button>
    {
        protected override void Invoke(Button sender)
        {
            var labelStack = sender.Parent.FindByName<StackLayout>("labelStack");
            if (labelStack != null)
            {
                var label = new Label
                {
                    Text = "Producto agregado",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Start,
                    FontSize = 26,
                    TextColor = Color.Red,
                    BackgroundColor = Color.White,
                };
                labelStack.Children.Add(label);

                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    // Oculta el label después de 3 segundos
                    label.IsVisible = false;
                    return false; // return false to stop repeating
                });
            }
        }
    }


}