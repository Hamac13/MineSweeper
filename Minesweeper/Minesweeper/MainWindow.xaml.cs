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
using System.Diagnostics;
using System.Threading;


namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //main function to initialise component
        public MainWindow()
        {
            InitializeComponent();
        }

        //logic for when start button is clicked
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int gridSize;
            int mines;
            if (sldr_GridSize.Minimum != 0){gridSize = (int)sldr_GridSize.Value;}
            else { gridSize = 9; }
            if ( sldr_Mines.Minimum != 0) { mines = (int)sldr_Mines.Value; }
            else { mines = 1; }
            Window game = new Game(gridSize, mines);
            game.Show();
            this.Close();
        }

        //logic to adjust slider parameters when value is changed
        private void sldr_GridSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sldr_GridSize.Minimum = 9;
            txb_GridSize.Text = sldr_GridSize.Value.ToString();
            sldr_Mines.Maximum = sldr_GridSize.Value * sldr_GridSize.Value - 1;
        }

        //logic to adjust slider parameters when value is changed
        private void sldr_Mines_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sldr_Mines.Minimum = 1;
            txb_Mines.Text = sldr_Mines.Value.ToString(); 
        }
      
    }
}
