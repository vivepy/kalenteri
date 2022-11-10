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

namespace Kooste
{
    /// <summary>
    /// Interaction logic for lukuWindow.xaml
    /// </summary>
    public partial class lukuWindow : Window
    {
        public lukuWindow()
        {
            InitializeComponent();
        }

        private void Fontti_Click(object sender, RoutedEventArgs e)
        {
            FonttiWindow ikkuna = new FonttiWindow();
            if ((bool)ikkuna.ShowDialog()) teksti.FontFamily = new FontFamily(ikkuna.Valinnat.Text);
        }

        private void tKoko_Click(object sender, RoutedEventArgs e)
        {
            TKoko_window ikkuna = new TKoko_window();
            if ((bool)ikkuna.ShowDialog()) teksti.FontSize = ikkuna.koko_liuku.Value;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            var dialogi = new PrintDialog();
            if (dialogi.ShowDialog() == true)
            {
                dialogi.PrintVisual(grid, teksti.Text);
            }
        }
    }
}
