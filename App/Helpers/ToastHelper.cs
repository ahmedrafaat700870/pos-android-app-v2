using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
namespace App.Helpers
{
    public class ToastHelper
    {

        public async static void Show(string message)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            string text = message;
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(text, duration, fontSize);
            
            await toast.Show(cancellationTokenSource.Token);
        }
    }
}
