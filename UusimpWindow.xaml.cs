using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kooste
{
    /// <summary>
    /// Interaction logic for UusimpWindow.xaml
    /// </summary>
    public partial class UusimpWindow : Window
    {
        public UusimpWindow()
        {            
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
        
    }
}