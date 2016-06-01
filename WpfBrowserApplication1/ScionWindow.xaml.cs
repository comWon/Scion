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
using Scion.MainHard;

namespace Scion.Wpf
{
    /// <summary>
    /// Interaction logic for ScionWindow.xaml
    /// </summary>
    public partial class ScionWindow : Window
    {
        public ScionLoader sL { get; set; }
        public MonsterIn ML { get; set; }
        public CharacterSet characterSet { get; set; }

        public ScionWindow()
        {
            InitializeComponent();
        }

        SolidColorBrush Monster = new SolidColorBrush
        {
            Color = Color.FromRgb(150, 0, 0)
        };
        SolidColorBrush Scion = new SolidColorBrush
        {
            Color = Color.FromRgb(0, 150, 0)
        };

        private void MonsterButton_Click(object sender, RoutedEventArgs e)
        {
            ML = new MonsterIn();
            masterFrame.Content = ML;
        }

        private void ScionButton_Click(object sender, RoutedEventArgs e)
        {
             sL = new ScionLoader();
            masterFrame.Content = sL;
        }

        private void Game_Click(object sender, RoutedEventArgs e)
        {

            CombatWindow combatWindow = new CombatWindow(characterSet);
        }
    }
}
