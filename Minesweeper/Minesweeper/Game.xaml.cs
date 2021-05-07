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

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public static int gridsize { get; set; }
        public Game(int gridSize, int mines)
        {
            InitializeComponent();
            gridsize = gridSize;
        }
    }
    public class GameLogic
    {
        public static Button[,] buttonGrid =  new Button[Game.gridsize, Game.gridsize];
        public static RowDefinition[] gridRows = new RowDefinition[Game.gridsize];
        public static ColumnDefinition[] gridCols = new ColumnDefinition[Game.gridsize];
        public static void setupGrid(int height, int width)
        {
            for (int rowi = 0; rowi < width; rowi++)
            {
                gridRows[rowi] = new RowDefinition();
                gridRows[rowi].Height = new GridLength(2, GridUnitType.Star);
                Game.mainGrid.RowDefinitions.Add(gridRows[rowi]);

                gridCols[rowi] = new ColumnDefinition();
                gridCols[rowi].Width = new GridLength(2, GridUnitType.Star);
            }

            for (int rowi = 0; rowi < width; rowi++)
            {
                for (int columni = 0; columni < height; columni++)
                {
                    
                }
            }
        }
    }
}
