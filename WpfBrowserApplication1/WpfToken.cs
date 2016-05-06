using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Data.Common;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using Scion.MainHard;

namespace Scion.Wpf
{
    class WpfToken
    {
        public Canvas Token { get; set; }

        SolidColorBrush TokenColour { get; set; }
        ImageBrush TokenBaseBrush { get; set; }
        ImageSource TokenBack { get; set; }
        bool TokenImageSet { get; set; }
        public string tokenText { get; private set; }
        public string TokenImage { get; private set; }
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }

        //CAnnot exit construcotr without calling TokenConstructor; Therfore private
        private WpfToken()
        {
            var outPutDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

            TokenImage = System.IO.Path.Combine(outPutDirectory, "Images\\Blank.png");

            TokenBack = new BitmapImage(new Uri(TokenImage));

            TokenBaseBrush = new ImageBrush()
            {
                ImageSource = TokenBack
            };

            TokenColour = new SolidColorBrush { Color = Color.FromRgb(125, 125, 0) };
            TokenImageSet = false;
            tokenText = "XXX";

            // Token Construction Not Performed,  

        }

        public WpfToken(CharData Settings) : this()
        {


            tokenText = Settings.ToonName;

            if (Settings.Image != null)
            {
                TokenImage = Settings.Image;
                TokenImageSet = true;
            }
            else
            {
                if (Settings.Monster)
                {
                    TokenColour.Color = Color.FromRgb(255, 0, 0);
                }
                else
                {
                    TokenColour.Color = Color.FromRgb(0, 255, 0);
                }
            }
            TokenConstructor();
            TokenPosition(Settings.ReturnPosition());
        }

        private void TokenPosition(int Step)
        {
            // if Invalid Step, Shunt to end
            if (Step < 0 || Step > 7) Step = 7;

            // Co-Ords holders

            double a = (Math.PI / 8) + ((Math.PI / 4) * Step);
            CurrentX = 150 + Convert.ToInt16(75 * Math.Cos(a));
            CurrentY = 150 + Convert.ToInt16(75 * Math.Sin(a));

        }

        private void TokenConstructor()
        {
            Ellipse cir = new Ellipse()
            {
                Height = 20,
                Width = 20,

                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            };
            TextBlock textBlk =
                new TextBlock
                {
                    Text = tokenText,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center
                };

            if (TokenImageSet) { cir.Fill = TokenBaseBrush; } else { cir.Fill = TokenColour; }

            Token = new Canvas() { Height = 20, Width = 20 };
            Token.Children.Add(cir);
            Token.Children.Add(textBlk);
        }
    }
}
