using PdfSharp.Fonts;
using System.Reflection;
namespace App
{
    public class FontResolver : IFontResolver
    {
        public byte[] GetFont(string faceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourcePrefix = $"{assembly.GetName().Name}.Resources.Fonts.";

            switch (faceName)
            {
                case "OpenSansRegular":
                    return LoadFontData(resourcePrefix + "OpenSans-Regular.ttf");
                case "OpenSansBold":
                    return LoadFontData(resourcePrefix + "OpenSans-Bold.ttf");
                default:
                    throw new InvalidOperationException($"Font face '{faceName}' not found.");
            }
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            if (familyName.Equals("OpenSans", StringComparison.OrdinalIgnoreCase))
            {
                if (isBold)
                    return new FontResolverInfo("OpenSansBold");
                else
                    return new FontResolverInfo("OpenSansRegular");
            }

            return null;
        }

        private byte[] LoadFontData(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    throw new InvalidOperationException($"Resource '{resourceName}' not found.");

                var fontData = new byte[stream.Length];
                stream.Read(fontData, 0, fontData.Length);
                return fontData;
            }
        }
    }
}
