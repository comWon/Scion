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
    /// Interaction logic for ScionWindow.xaml
    /// </summary>
    public partial class ScionWindow : Window
    {
        public ScionWindow()
        {
            InitializeComponent();
        }

        private void MonsterButton_Click(object sender, RoutedEventArgs e)
        {
            masterFrame.Source = new System.Uri("MonsterLoad.xaml");
        }

        private void ScionButton_Click(object sender, RoutedEventArgs e)
        {
            masterFrame.Source = new System.Uri("ScionLoader.xaml");
        }

        private void frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
