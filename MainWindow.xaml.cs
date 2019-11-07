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

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int round = 3;
        List<string> pattern = new List<string>();
        private bool inGame = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ButtonPress(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            NewPattern newPattern = new NewPattern();
            
            if (!inGame)
            {
                if (btn.Content.ToString() == "START")
                {
                    pattern.AddRange(newPattern.GetPattern(round));
                    ShowPattern(pattern);
                    inGame = true;
                }
            }
            else 
            {
                if (btn.Content.ToString() == "GREEN" && pattern[0] == "Green")
                {
                    pattern.RemoveAt(0);
                    btn.Background = Brushes.Green;
                    await Task.Delay(100);
                    btn.Background = Brushes.LightGray;
                }
                else if (btn.Content.ToString() == "RED" && pattern[0] == "RED")
                {
                    pattern.RemoveAt(0);
                    btn.Background = Brushes.Red;
                    await Task.Delay(100);
                    btn.Background = Brushes.LightGray;
                }
                else if (btn.Content.ToString() == "BLUE" && pattern[0] == "BLUE")
                {
                    pattern.RemoveAt(0);
                    btn.Background = Brushes.Blue;
                    await Task.Delay(100);
                    btn.Background = Brushes.LightGray;
                }
                else if (btn.Content.ToString() == "YELLOW" && pattern[0] == "YELLOW")
                {
                    pattern.RemoveAt(0);
                    btn.Background = Brushes.Yellow;
                    await Task.Delay(100);
                    btn.Background = Brushes.LightGray;
                }
                else
                {
                    Button dis = this.FindName("START") as Button;
                    dis.Content = "LOSER";
                    await Task.Delay(1000);
                    inGame = false;
                    dis.Content = "START";
                }
            }
        }
        public async void ShowPattern(List<string> arr)
        {
            foreach (string s in arr)
            {
                Button dis = new Button();
                SolidColorBrush c = new SolidColorBrush();
                switch (s)
                {
                    case "RED":
                        dis = this.FindName("RED") as Button;
                        c = Brushes.Red;
                        break;
                    case "GREEN":
                        dis = this.FindName("GREEN") as Button;
                        c = Brushes.Green;
                        break;
                    case "BLUE":
                        dis = this.FindName("BLUE") as Button;
                        c = Brushes.Blue;
                        break;
                    case "YELLOW":
                        dis = this.FindName("YELLOW") as Button;
                        c = Brushes.Yellow;
                        break;
                }
                dis.Background = c;
                await Task.Delay(1000);
                dis.Background = Brushes.LightGray;

            }
        }
    }
    public class NewPattern
    {
        
        public string[] GetPattern(int num)
        {
            string[] o = new string[num];
                Random r = new Random();
            for(int i = 0; i < num; i++)
            {
                int newRan = r.Next(1, 4);
                switch (newRan)
                {
                    case 1:
                        o[i] = "RED";
                        break;
                    case 2:
                        o[i] = "GREEN";
                        break;
                    case 3:
                        o[i] = "BLUE";
                        break;
                    case 4:
                        o[i] = "YELLOW";
                        break;
                }
            }
            return o;
        }
    }
}
