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
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.StartAndExpand, FontSize = 24, TextColor = Color.OrangeRed, BackgroundColor = Color.Black,
                };
                labelStack.Children.Add(label);

                Device.StartTimer(TimeSpan.FromSeconds(3), () =>
                {
                    // Remove the label after 2 seconds
                    labelStack.Children.Remove(label);
                    return false; // return false to stop repeating
                });
            }
        }
    }
}