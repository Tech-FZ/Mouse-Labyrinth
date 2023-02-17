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
using System.Runtime.InteropServices;
using System.Windows.Threading;
using System.IO;

namespace Mouse_Labyrinth
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool gameStarted = false;
        public static int timePassed = 0;
        public static int lives = 3;
        DispatcherTimer dispatcher = new DispatcherTimer();
        DispatcherTimer dispatcherTimerDoor = new DispatcherTimer();

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (gameStarted)
            {
                Point position = e.GetPosition(this);
                Point currentMousePos = NativeMethods.GetCursorPos();

                int[][] rectanglePositions = {
                    new int[] { (int)wall0.Margin.Left, (int)(wall0.Margin.Left + wall0.Width), (int)wall0.Margin.Top, (int)(wall0.Margin.Top + wall0.Height) },
                    new int[] { (int)wall1.Margin.Left, (int)(wall1.Margin.Left + wall1.Width), (int)wall1.Margin.Top, (int)(wall1.Margin.Top + wall1.Height) },
                    new int[] { (int)wall2.Margin.Left, (int)(wall2.Margin.Left + wall2.Width), (int)wall2.Margin.Top, (int)(wall2.Margin.Top + wall2.Height) },
                    new int[] { (int)wall3.Margin.Left, (int)(wall3.Margin.Left + wall3.Width), (int)wall3.Margin.Top, (int)(wall3.Margin.Top + wall3.Height) },
                    new int[] { (int)wall4.Margin.Left, (int)(wall4.Margin.Left + wall4.Width), (int)wall4.Margin.Top, (int)(wall4.Margin.Top + wall4.Height) },
                    new int[] { (int)wall5.Margin.Left, (int)(wall5.Margin.Left + wall5.Width), (int)wall5.Margin.Top, (int)(wall5.Margin.Top + wall5.Height) },
                    new int[] { (int)wall6.Margin.Left, (int)(wall6.Margin.Left + wall6.Width), (int)wall6.Margin.Top, (int)(wall6.Margin.Top + wall6.Height) },
                    new int[] { (int)wall7.Margin.Left, (int)(wall7.Margin.Left + wall7.Width), (int)wall7.Margin.Top, (int)(wall7.Margin.Top + wall7.Height) },
                    new int[] { (int)wall8.Margin.Left, (int)(wall8.Margin.Left + wall8.Width), (int)wall8.Margin.Top, (int)(wall8.Margin.Top + wall8.Height) },
                    new int[] { (int)wall9.Margin.Left, (int)(wall9.Margin.Left + wall9.Width), (int)wall9.Margin.Top, (int)(wall9.Margin.Top + wall9.Height) },
                    new int[] { (int)wall10.Margin.Left, (int)(wall10.Margin.Left + wall10.Width), (int)wall10.Margin.Top, (int)(wall10.Margin.Top + wall10.Height) },
                    new int[] { (int)wall12.Margin.Left, (int)(wall12.Margin.Left + wall12.Width), (int)wall12.Margin.Top, (int)(wall12.Margin.Top + wall12.Height) },
                    new int[] { (int)wall13.Margin.Left, (int)(wall13.Margin.Left + wall13.Width), (int)wall13.Margin.Top, (int)(wall13.Margin.Top + wall13.Height) },
                    new int[] { (int)wall14.Margin.Left, (int)(wall14.Margin.Left + wall14.Width), (int)wall14.Margin.Top, (int)(wall14.Margin.Top + wall14.Height) },
                    new int[] { (int)wall15.Margin.Left, (int)(wall15.Margin.Left + wall15.Width), (int)wall15.Margin.Top, (int)(wall15.Margin.Top + wall15.Height) },
                    new int[] { (int)wall16.Margin.Left, (int)(wall16.Margin.Left + wall16.Width), (int)wall16.Margin.Top, (int)(wall16.Margin.Top + wall16.Height) },
                    new int[] { (int)wall17.Margin.Left, (int)(wall17.Margin.Left + wall17.Width), (int)wall17.Margin.Top, (int)(wall17.Margin.Top + wall17.Height) },
                    new int[] { (int)wall18.Margin.Left, (int)(wall18.Margin.Left + wall18.Width), (int)wall18.Margin.Top, (int)(wall18.Margin.Top + wall18.Height) },
                    new int[] { (int)wall19.Margin.Left, (int)(wall19.Margin.Left + wall19.Width), (int)wall19.Margin.Top, (int)(wall19.Margin.Top + wall19.Height) },
                    new int[] { (int)wall20.Margin.Left, (int)(wall20.Margin.Left + wall20.Width), (int)wall20.Margin.Top, (int)(wall20.Margin.Top + wall20.Height) },
                    new int[] { (int)wall21.Margin.Left, (int)(wall21.Margin.Left + wall21.Width), (int)wall21.Margin.Top, (int)(wall21.Margin.Top + wall21.Height) },
                    new int[] { (int)wall22.Margin.Left, (int)(wall22.Margin.Left + wall22.Width), (int)wall22.Margin.Top, (int)(wall22.Margin.Top + wall22.Height) },
                    new int[] { (int)wall23.Margin.Left, (int)(wall23.Margin.Left + wall23.Width), (int)wall23.Margin.Top, (int)(wall23.Margin.Top + wall23.Height) },
                    new int[] { (int)wall24.Margin.Left, (int)(wall24.Margin.Left + wall24.Width), (int)wall24.Margin.Top, (int)(wall24.Margin.Top + wall24.Height) },
                    new int[] { (int)wall25.Margin.Left, (int)(wall25.Margin.Left + wall25.Width), (int)wall25.Margin.Top, (int)(wall25.Margin.Top + wall25.Height) },
                    new int[] { (int)wall26.Margin.Left, (int)(wall26.Margin.Left + wall26.Width), (int)wall26.Margin.Top, (int)(wall26.Margin.Top + wall26.Height) },
                    new int[] { (int)wall27.Margin.Left, (int)(wall27.Margin.Left + wall27.Width), (int)wall27.Margin.Top, (int)(wall27.Margin.Top + wall27.Height) },
                    new int[] { (int)wall28.Margin.Left, (int)(wall28.Margin.Left + wall28.Width), (int)wall28.Margin.Top, (int)(wall28.Margin.Top + wall28.Height) },
                    new int[] { (int)wall29.Margin.Left, (int)(wall29.Margin.Left + wall29.Width), (int)wall29.Margin.Top, (int)(wall29.Margin.Top + wall29.Height) },
                    new int[] { (int)wall30.Margin.Left, (int)(wall30.Margin.Left + wall30.Width), (int)wall30.Margin.Top, (int)(wall30.Margin.Top + wall30.Height) },
                };

                var playerMargin = Player.Margin;
                playerMargin.Left = position.X;
                playerMargin.Top = position.Y;

                Player.Margin = playerMargin;

                foreach (int[] rectXY in rectanglePositions)
                {
                    if (
                        Player.Margin.Left >= rectXY[0] - Player.Width && Player.Margin.Left <= rectXY[1] && Player.Margin.Top >= rectXY[2] - Player.Height
                        && Player.Margin.Top <= rectXY[3])
                    {
                        lifeIsLost();
                    }
                }

                if (Player.Margin.Left >= door.Margin.Left - Player.Width && Player.Margin.Left <= door.Margin.Left + door.Width
                    && Player.Margin.Top >= door.Margin.Top - Player.Height && Player.Margin.Top <= door.Margin.Top + door.Height)
                {
                    if (door.IsVisible)
                    {
                        lifeIsLost();
                    }
                }

                if (Player.Margin.Left >= 569 && Player.Margin.Left <= 596 && Player.Margin.Top >= 55 && Player.Margin.Top <= 100)
                {
                    gameStarted = false;
                    dispatcher.Stop();
                    dispatcherTimerDoor.Stop();

                    string highscoreSoFar = "";

                    try
                    {
                        highscoreSoFar = File.ReadAllText($"{Environment.GetEnvironmentVariable("appdata")}\\Mouse Labyrinth\\highscore.txt");
                    }
                    catch
                    {

                    }

                    try
                    {
                        FileInfo fileInfo = new FileInfo($"{Environment.GetEnvironmentVariable("appdata")}\\Mouse Labyrinth\\highscore.txt");
                        fileInfo.Directory.Create();
                        FileStream fileStream = File.Create($"{Environment.GetEnvironmentVariable("appdata")}\\Mouse Labyrinth\\highscore.txt");
                        AddText(fileStream, highscoreSoFar + $"{nameBox.Text} {timePassed}s {lives}\n");
                        fileStream.Close();
                    }
                    catch
                    {
                        
                    }

                    door.Visibility = Visibility.Visible;
                    timePassed = 0;
                    timeLbl.Content = "Time: 0:00";
                    livesLbl.Content = "You won!";
                    lives = 3;
                    playerMargin = Player.Margin;
                    playerMargin.Left = 27;
                    playerMargin.Top = 421;

                    Player.Margin = playerMargin;

                    HighscoreWindow highscoreWindow = new HighscoreWindow();
                    highscoreWindow.Show();
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            double xPos = Application.Current.MainWindow.Left;
            double yPos = Application.Current.MainWindow.Top;
            NativeMethods.SetCursorPos((int)(xPos + 43), (int)(yPos + 444 + 26));
            dispatcher.Interval = new TimeSpan(0, 0, 1);
            dispatcher.Tick += dispatcher_Tick;
            dispatcherTimerDoor.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimerDoor.Tick += door_Dispatcher_Tick;
        }

        public void lifeIsLost()
        {
            double xPos = Application.Current.MainWindow.Left;
            double yPos = Application.Current.MainWindow.Top;
            var playerMargin = Player.Margin;
            playerMargin.Left = 27;
            playerMargin.Top = 421;

            Player.Margin = playerMargin;

            lives--;

            if (lives > 0)
            {
                livesLbl.Content = $"Lives: {lives}";
            }
            
            else if (lives <= 0)
            {
                livesLbl.Content = "Game over.";
                gameStarted = false;
                dispatcher.Stop();
                timePassed = 0;
                timeLbl.Content = "Time: 0:00";
                lives = 3;
                dispatcherTimerDoor.Stop();
                door.Visibility = Visibility.Visible;
            }

            NativeMethods.SetCursorPos((int)(xPos + 43), (int)(yPos + 444 + 26));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (gameStarted)
            {
                gameStarted = false;
                dispatcher.Stop();
                dispatcherTimerDoor.Stop();
                door.Visibility = Visibility.Visible;
                timePassed = 0;
                timeLbl.Content = "Time: 0:00";
                var playerMargin = Player.Margin;
                playerMargin.Left = 27;
                playerMargin.Top = 421;

                Player.Margin = playerMargin;
            }
            
            double xPos = Application.Current.MainWindow.Left;
            double yPos = Application.Current.MainWindow.Top;
            NativeMethods.SetCursorPos((int)(xPos + 43), (int)(yPos + 444 + 26));
            gameStarted = true;
            livesLbl.Content = "Lives: 3";
            dispatcher.Start();
            dispatcherTimerDoor.Start();
        }

        public partial class NativeMethods
        {
            /// Return Type: BOOL->int  
            ///X: int  
            ///Y: int  
            [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "SetCursorPos")]
            [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public static extern bool SetCursorPos(int X, int Y);

            [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "GetCursorPos")]
            [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Struct)]
            public static extern Point GetCursorPos();
        }

        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point (POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        private void dispatcher_Tick(object sender, EventArgs e)
        {
            timePassed++;
            double minutesInDbl = timePassed / 60;
            int minutesToAdd = (int)Math.Round(minutesInDbl, 0, mode: MidpointRounding.AwayFromZero);

            while (timePassed < minutesToAdd * 60)
            {
                minutesToAdd--;
            }

            if (timePassed - minutesToAdd * 60 < 10)
            {
                timeLbl.Content = $"Time: {minutesToAdd}:0{timePassed - minutesToAdd * 60}";
            }
            else
            {
                timeLbl.Content = $"Time: {minutesToAdd}:{timePassed - minutesToAdd * 60}";
            }
        }

        private void door_Dispatcher_Tick(object sender, EventArgs e)
        {
            if (door.IsVisible)
            {
                door.Visibility = Visibility.Hidden;
            }
            else
            {
                door.Visibility = Visibility.Visible;
            }
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
