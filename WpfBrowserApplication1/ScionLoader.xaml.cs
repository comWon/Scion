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
    /// <summary>
    /// Interaction logic for ScionLoader.xaml
    /// </summary>
    public partial class ScionLoader : Page
    {
        public CharacterSet CS = new CharacterSet();

        public ScionLoader()
        {
            InitializeComponent();
            CharData C = new CharData("test", "test", 7, 0);
            CS.AddCharacter(C);
        }

        private void SaveScion_Click(object sender, RoutedEventArgs e)
        {
            FileManagment.CharacterSaver(FileLocationBox.Text, CS);
        }

        private void LoadScions_Click(object sender, RoutedEventArgs e)
        {
            CS = FileManagment.LoadCharacters(FileLocationBox.Text);
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = CS.Listing();
        }

        private void dataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FileLocationBox_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
