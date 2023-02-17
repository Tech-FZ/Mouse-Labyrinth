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

namespace Mouse_Labyrinth
{
    public partial class HighscoreWindow : Window
    {
        public static string[][] scores = { };
        public static string scoreTxt = "";

        public HighscoreWindow()
        {
            InitializeComponent();
            string highscoreFile = System.IO.File.ReadAllText($"{Environment.GetEnvironmentVariable("appdata")}\\Mouse Labyrinth\\highscore.txt");
            highscoreBox.Text = "Name Time Tries\n" + highscoreFile;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void highscoreBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
