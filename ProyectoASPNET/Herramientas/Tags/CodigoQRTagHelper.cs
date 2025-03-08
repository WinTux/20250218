using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ProyectoASPNET.Herramientas.Tags
{
    [HtmlTargetElement("codigoqr")]
    public class CodigoQRTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var contenido = context.AllAttributes["contenido"].Value.ToString();
            var ancho = int.Parse(context.AllAttributes["ancho"].Value.ToString());
            var alto = int.Parse(context.AllAttributes["alto"].Value.ToString());
            var barcodeWriter = new ZXing.BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.QrCode.QrCodeEncodingOptions
                {
                    Width = ancho,
                    Height = alto,
                    Margin = 0
                }
            };
            var pixelData = barcodeWriter.Write(contenido);
            using (var bitmap = new System.Drawing.Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb)) {
                using (var memoryStream = new MemoryStream()) { 
                    var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                    try
                    {
                        System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                    }
                    finally
                    {
                        bitmap.UnlockBits(bitmapData);
                    }
                    bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    output.TagName = "img"; // <img>
                    output.Attributes.Clear();
                    output.Attributes.SetAttribute("src", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(memoryStream.ToArray())));
                    output.Attributes.SetAttribute("width", ancho);
                    output.Attributes.SetAttribute("height", alto);
                }
            }
        }
    }
}
