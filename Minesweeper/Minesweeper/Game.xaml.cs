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
using System.Diagnostics;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        //Initialization of variables used throughout code
        //size of grid
        public static int gridsize { get; set; }
        //number of mines in grid and number of guessed mines by user
        public static int mine_num { get; set; }
        public static int mine_guesses;

        public static bool flagging = false;

        //2D array to contain buttons in grid
        public static Button[,] buttonGrid;
        public static RowDefinition[] gridRows = new RowDefinition[Game.gridsize];
        public static ColumnDefinition[] gridCols = new ColumnDefinition[Game.gridsize];
        //stopwatch to record time of user
        public static Stopwatch timer;
        //array to hold information of each cell
        public static string[,] gameArray;

        //main function where grid is initialized
        public Game(int gridSize, int mines)
        {
            InitializeComponent();
            timer = new Stopwatch();
            timer.Start();
            gridsize = gridSize;
            mine_num = mines;
            mine_guesses = mine_num;
            lbl_Mine_Guesses.Content = $"Mines: {mine_guesses}";
            buttonGrid = new Button[gridsize, gridsize];
            GameLogic.GenerateArray();

            for (int rowi = 0; rowi < gridsize; rowi++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                RowDefinition rowDef = new RowDefinition();
                colDef.Width = new GridLength(2, GridUnitType.Star);
                rowDef.Height = new GridLength(2, GridUnitType.Star);
                for (int columni = 0; columni < gridsize; columni++)
                {
                    //Console.WriteLine($"{rowi}, {columni}");
                    buttonGrid[rowi, columni] = new Button();
                    buttonGrid[rowi, columni].Content = "";
                    buttonGrid[rowi, columni].Background = Brushes.LightGray;
                    Grid.SetColumn(buttonGrid[rowi, columni], columni + 1);
                    Grid.SetRow(buttonGrid[rowi, columni], rowi + 2);
                    mainGrid.Children.Add(buttonGrid[rowi, columni]);

                    buttonGrid[rowi, columni].Click += GridClick;
                }
                mainGrid.ColumnDefinitions.Add(colDef);
                mainGrid.RowDefinitions.Add(rowDef);
            }
            RowDefinition padRow = new RowDefinition();
            padRow.Height = new GridLength(20);
            mainGrid.RowDefinitions.Add(padRow);
            ColumnDefinition padCol = new ColumnDefinition();
            padCol.Width = new GridLength(20);
            mainGrid.ColumnDefinitions.Add(padCol);
        }

        //logic for click event of menu button
        private void btn_Menu_Click(object sender, RoutedEventArgs e)
        {
            flagging = false;
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        //logic for when user clicks on cell in grid
        private void GridClick(object sender, RoutedEventArgs e)
        {
            
            int win = 0;
            Button btn = sender as Button;
            //Console.WriteLine(gameArray[(int)btn.GetValue(Grid.ColumnProperty), (int)btn.GetValue(Grid.RowProperty)]);
            if (flagging)
            {
                if (btn.Background == Brushes.Red) {
                    btn.Background = Brushes.LightGray;
                }
                else
                {
                    btn.Background = Brushes.Red;
                    mine_guesses--;
                    lbl_Mine_Guesses.Content = $"Mines: {mine_guesses}";
                }

                for (int rowi = 0; rowi < gridsize; rowi++)
                {
                    for (int columni = 0; columni < gridsize; columni++)
                    {
                        if (buttonGrid[rowi, columni].Content == gameArray[rowi, columni])
                        {
                            win++;
                        }
                        else if (buttonGrid[rowi, columni].Background == Brushes.Red && gameArray[rowi, columni] == "*")
                        {
                            win++;
                        }

                    }
                }
                
                if (win == gridsize * gridsize)
                {
                    timer.Stop();
                    
                    MessageBox.Show($"Time: {timer.Elapsed}", "win");

                }
            }

            else
            {
                int y = (int)btn.GetValue(Grid.RowProperty) - 2;
                int x = (int)btn.GetValue(Grid.ColumnProperty) - 1;
                
                if (gameArray[y, x] == "*")
                {
                    
                    for (int rowi = 0; rowi < gridsize; rowi++)
                    {
                        for (int columni = 0; columni < gridsize; columni++)
                        {
                            if (gameArray[rowi, columni] == "*")
                            {
                                buttonGrid[rowi, columni].Background = Brushes.Blue;
                            }
                            buttonGrid[rowi, columni].Content = gameArray[rowi, columni];
                        }
                    }
                    timer.Stop();
                    MessageBox.Show($"Time: {timer.Elapsed}", "Loss");
                    
                    Console.WriteLine($"{timer.Elapsed}");
                }
                else
                {
                    btn.Background = Brushes.Transparent;
                    btn.Content = gameArray[y, x];
                    if (gameArray[y, x] == "0")
                    {
                        GameLogic.CheckZero(x, y);
                    }
                    for (int rowi = 0; rowi < gridsize; rowi++)
                    {
                        for (int columni = 0; columni < gridsize; columni++)
                        {
                            if (buttonGrid[rowi, columni].Content == gameArray[rowi, columni])
                            {
                                win++;  
                            }
                            else if (buttonGrid[rowi, columni].Background == Brushes.Red && gameArray[rowi, columni] == "*")
                            {
                                win++;
                            }
                            
                        }
                    }
                }
                
                if (win == gridsize * gridsize)
                {
                    timer.Stop();
                    MessageBox.Show($"Time: {timer.Elapsed}", "win");
                    
                    Console.WriteLine($"{timer.Elapsed}");
                }
            }
        }

        //logic for flag button clicked event
        private void btn_flag_Click(object sender, RoutedEventArgs e)
        {
            flagging = !flagging;
            
            if (btn_flag.Background == Brushes.LightGray){btn_flag.Background = Brushes.DarkGray;}
            else { btn_flag.Background = Brushes.LightGray; }
        }

        //logic for new game button clicked event
        private void btn_NewGame_Click(object sender, RoutedEventArgs e)
        {
            GameLogic.GenerateArray();
            for (int rowi = 0; rowi < gridsize; rowi++)
            {
                for (int columni = 0; columni < gridsize; columni++)
                {
                    buttonGrid[columni, rowi].Content = "";
                    buttonGrid[columni, rowi].Background = Brushes.LightGray;
                }
            }
        }
    }
    //class to hold logic for game
    public class GameLogic
    {
        //start of function to generate array of strings with adjacency values and mine locations
        public static void GenerateArray()
        {
            Random rnd = new Random();
            Game.gameArray = new string[Game.gridsize, Game.gridsize];

            for (int rowi = 0; rowi < Game.gridsize; rowi++)
            {
                for (int columni = 0; columni < Game.gridsize; columni++)
                {
                    Game.gameArray[rowi, columni] = "0";
                }
            }
            for (int i = 0; i < Game.mine_num; i++)
            {
                int x = rnd.Next(Game.gridsize);
                int y = rnd.Next(Game.gridsize);

                if (Game.gameArray[x, y] == "*")
                {
                    i--;
                }
                Game.gameArray[x, y] = "*";
            }


            for (int ri = 0; ri < Game.gridsize; ri++)
            {
                for (int ci = 0; ci < Game.gridsize; ci++)
                {
                    if (Game.gameArray[ri, ci] != "*")
                    {
                        int num = 0;
                        int i1 = -1;
                        int c1 = -1;
                        int i2 = 1;
                        int c2 = 1;
                        if (ri == 0)
                        {
                            i1 = 0;
                        }
                        if (ci == 0)
                        {
                            c1 = 0;
                        }
                        if (ri == Game.gridsize - 1)
                        {
                            i2 = 0;
                        }
                        if (ci == Game.gridsize - 1)
                        {
                            c2 = 0;
                        }
                        for (int i = i1; i <= i2; i++)
                        {
                            for (int c = c1; c <= c2; c++)
                            {
                                if (c == 0 && i == 0)
                                {
                                    continue;
                                }

                                if (Game.gameArray[ri + i, ci + c] == "*")
                                {
                                    num++;
                                }
                            }
                        }
                        Game.gameArray[ri, ci] = num.ToString();
                    }
                }
            }
        }
        // end of GenerateArray function

        //function to clear neighbouring 0 cells when 0 is clicked
        public static void CheckZero(int x, int y)
        {

            int num = 0;
            int i1 = -1;
            int c1 = -1;
            int i2 = 1;
            int c2 = 1;
            if (x == 0)
            {
                i1 = 0;
            }
            if (y == 0)
            {
                c1 = 0;
            }
            if (x == Game.gridsize - 1)
            {
                i2 = 0;
            }
            if (y == Game.gridsize - 1)
            {
                c2 = 0;
            }
            for (int i = i1; i <= i2; i++)
            {
                for (int c = c1; c <= c2; c++)
                {
                    Game.buttonGrid[y + c, x + i].Content = Game.gameArray[y + c, x + i];
                    Game.buttonGrid[y + c, x + i].Background = Brushes.Transparent;
                    if (Game.gameArray[y + c, x + i] == "0" && Game.buttonGrid[y + c, x + i].Tag != "1")
                    {
                        Game.buttonGrid[y + c, x + i].Tag = "1";
                        CheckZero(x + i, y + c);
                    }
                }
            }
        }

    }
}
