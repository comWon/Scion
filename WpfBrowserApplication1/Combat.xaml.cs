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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Scion.MainHard;

namespace Scion.Wpf
{
    class Combat
    {
        private Combat()
        {

        }

        public Combat(CharacterSet CS)
        {
            Chars = CS;

            foreach ( CharData c in CS.ActiveCharacters())
            {
                WpfToken token = new WpfToken(c);
                Canvas.SetTop(token.Token, token.CurrentX);
                Canvas.SetLeft(token.Token, token.CurrentY);
                tokens.Add(token);


            }
        }

        CharacterSet Chars { get; set; }

        List<WpfToken> tokens { get; set; }
    }
}
