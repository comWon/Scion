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
        public ScionWindow()
        {
            InitializeComponent();
            sets = new CharacterSet();

            // TEST CODE 
            sets = Structural.TestCharSet();

            Combat r = new Combat(sets);
           // Rectangle r = new Rectangle();

            r.Height = 300;
            r.Width = 300;
            //r.Fill = new SolidColorBrush() { Color = Colors.Red };

            Object.Children.Add(r);
            Grid.SetColumn(r, 1);

            //CombatWindow = new Combat(sets);
            //CombatWindow.Height = 300;
            //CombatWindow.Width = 300;

            //Object.Children.Add(CombatWindow);
            //Grid.SetColumn(CombatWindow, 1);
            //CombatWindow.Visibility = Visibility.Visible;

            int x = 1;

        }

        Combat CombatWindow { get; set; }

        SolidColorBrush Monster = new SolidColorBrush
        {
            Color = Color.FromRgb(150, 0, 0)
        };
        SolidColorBrush Scion = new SolidColorBrush
        {
            Color = Color.FromRgb(0, 150, 0)
        };

        CharacterSet sets { get; set; }

        private void MonsterButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ScionButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Game_Click(object sender, RoutedEventArgs e)
        {
            CombatWindow = new Combat(sets);
            
            Object.Children.Add(CombatWindow);
            Grid.SetColumn(CombatWindow, 1);

        }

        private void masterFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
