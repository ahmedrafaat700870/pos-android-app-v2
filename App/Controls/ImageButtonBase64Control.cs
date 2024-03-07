

namespace App.Controls
{
    public class ImageButtonBase64Control : Microsoft.Maui.Controls.ImageButton
    {

        public static readonly BindableProperty Base64SourceProperty =
            BindableProperty.Create(
                nameof(Base64Source),
                typeof(string),
                typeof(ImageBase64Control),
                string.Empty,
                propertyChanged: OnBase64SourceChanged);

        public string Base64Source
        {
            set
            {
                SetValue(Base64SourceProperty, value);
            }
            get
            {
                return (string)GetValue(Base64SourceProperty);
            }
        }

        private static void OnBase64SourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            MemoryStream stream = new MemoryStream(Convert.FromBase64String((string)newValue));
            ((ImageButton)bindable).Source = ImageSource.FromStream(() => stream);
        }
    }
}
