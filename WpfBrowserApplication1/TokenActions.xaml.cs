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
    /// Interaction logic for TokenActions.xaml
    /// </summary>
    public partial class TokenActions : Window , IDisposable
    {
        CharData ActOn { get; set; }

        private TokenActions()
        {
            InitializeComponent();
        }

        public TokenActions(CharData Token)
        {
            NameLabel.Content = Token.PlayerName + ": " + Token.ToonName;
            ActOn = Token;
        }

        public CharData getResult ()
        {
            return ActOn;
        }

        private void Ticks1_Click(object sender, RoutedEventArgs e)
        {
           
            ActOn.Action(1);

            this.Close();
        }

        private void Ticks2_Click(object sender, RoutedEventArgs e)
        {
            ActOn.Action(2);

            this.Close();
        }

        private void Ticks3_Click(object sender, RoutedEventArgs e)
        {
            ActOn.Action(3);

            this.Close();
        }

        private void Ticks4_Click(object sender, RoutedEventArgs e)
        {
            ActOn.Action(4);

            this.Close();
        }

        private void Ticks5_Click(object sender, RoutedEventArgs e)
        {
            ActOn.Action(5);

            this.Close();
        }

        private void Ticks6_Click(object sender, RoutedEventArgs e)
        {
            ActOn.Action(6);

            this.Close();
        }

        private void KillMe_Click(object sender, RoutedEventArgs e)
        {
            ActOn.Dead = true;

            this.Close();
        }

        void IDisposable.Dispose()
        {
           
        }


    }
}
