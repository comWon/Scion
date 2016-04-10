﻿using System;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public List<Monster> MonsterList { get; set; }

        public Page1()
        {
            InitializeComponent();
        }

        private void FileLocationBox_Loaded(object sender, RoutedEventArgs e)
        {
             FileLocationBox.Text ="C:\\Monsters.Txt";
        }

        private void SaveMonsters_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
