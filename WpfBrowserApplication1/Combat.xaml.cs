using Scion.MainHard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Scion.Wpf
{
    /// <summary>
    /// Interaction logic for CombatWindow.xaml
    /// </summary>
    public partial class Combat: Canvas
    {
        List<WpfToken> tokens { get; set; }
        CharacterSet charSet { get; set; }

        private Combat()
        {
            InitializeComponent();
        }

        public Combat(CharacterSet cs) :this() 
        {
            charSet = cs;

            foreach (CharData c in cs.Listing())
            {
                WpfToken token = new WpfToken(c);
                tokens.Add(token);
                int a = tokens.Count(s => s.charData.ReturnPosition() == token.charData.ReturnPosition());
                token.Sector( a,true);
                TokenCanvas.Children.Add(token.Token);
                Canvas.SetLeft(token.Token, token.CurrentY);
                Canvas.SetTop(token.Token, token.CurrentX);
            }
        }


    }
}
