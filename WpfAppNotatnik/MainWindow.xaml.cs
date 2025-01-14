using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfAppNotatnik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string SciezkaDoPliku { get; set; } = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_info_autor(object sender, RoutedEventArgs e)
        {
            WindowAutor noweOknoOAutorze = new WindowAutor();
            noweOknoOAutorze.ShowDialog();//okno modalne
        }

        private void MenuItem_Click_Info_Aplikacja(object sender, RoutedEventArgs e)
        {
            WindowOAplikacji windowOAplikacji = new WindowOAplikacji();
            windowOAplikacji.Show(); //okno niemodalne
        }

        private void MenuItem_Click_Zapisz_Jako(object sender, RoutedEventArgs e)
        {
            string tekst = tekstNotatnikaTextBox.Text;
            //okno dialogowe do zapisu

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PlainText | *.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
               SciezkaDoPliku = saveFileDialog.FileName;
                File.WriteAllText(saveFileDialog.FileName, tekst);
                Title = SciezkaDoPliku;
            }

        }

        private void MenuItem_Click_Zapisz(object sender, RoutedEventArgs e)
        {
            if(SciezkaDoPliku == "")
            {
                MenuItem_Click_Zapisz_Jako(sender, e);
            }
            else
            {
                File.WriteAllText(SciezkaDoPliku, tekstNotatnikaTextBox.Text);
            }
        }

        private void MenuItem_Click_Nowy(object sender, RoutedEventArgs e)
        {
            if(SciezkaDoPliku != "")
            {
                if(tekstNotatnikaTextBox.Text != File.ReadAllText(SciezkaDoPliku))
                {
                    MessageBoxResult messageBoxResult =  MessageBox.Show("Czy chcesz zapisać zmiany w pliku?",
                        "Pytanie",
                        MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    if(messageBoxResult == MessageBoxResult.Yes)
                    {
                        File.WriteAllText(SciezkaDoPliku, tekstNotatnikaTextBox.Text);
                        tekstNotatnikaTextBox.Text = "";
                        SciezkaDoPliku = "";
                        Title = "Notatnik";
                    }
                    else if(messageBoxResult == MessageBoxResult.No)
                    {
                        tekstNotatnikaTextBox.Text = "";
                        SciezkaDoPliku = "";
                        Title = "Notatnik";
                    }

                }
                else
                {
                    
                        tekstNotatnikaTextBox.Text = "";
                        SciezkaDoPliku = "";
                        Title = "Notatnik";
                   
                }
            }
            else if(tekstNotatnikaTextBox.Text != "")
            {

                MessageBoxResult messageBoxResult = MessageBox.Show("Czy chcesz zapisać zmiany w pliku?",
                    "Pytanie",
                    MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if( messageBoxResult == MessageBoxResult.Yes)
                {
                    MenuItem_Click_Zapisz_Jako(sender, e);
                    tekstNotatnikaTextBox.Clear();
                    Title = "notatnik";
                    SciezkaDoPliku = "";
                }
                else if (messageBoxResult == MessageBoxResult.No)
                {
                    tekstNotatnikaTextBox.Text = "";
                    SciezkaDoPliku = "";
                    Title = "Notatnik";
                }
            }

        }

        private void MenuItem_Click_Otworz(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pliki tekstowe | *.txt";
            if(ofd.ShowDialog() == true)
            {
               tekstNotatnikaTextBox.Text = File.ReadAllText(ofd.FileName);
                SciezkaDoPliku = ofd.FileName;
                Title = ofd.FileName;
            }
        }

        private void MenuItem_Click_Zwieksz_czcionke(object sender, RoutedEventArgs e)
        {
            int rozmiarCzcionki = int.Parse(tekstNotatnikaTextBox.FontSize.ToString());
            rozmiarCzcionki++;
            tekstNotatnikaTextBox.FontSize = rozmiarCzcionki;
        }

        private void MenuItem_Click_Zmiejsz_Czcionke(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_KolorCZcionki(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            string kolor = menuItem.Header.ToString();
            switch (kolor)
            {
                case "niebieska":
                    tekstNotatnikaTextBox.Foreground = Brushes.Blue; 
                    break;
                case "czerwona":
                    tekstNotatnikaTextBox.Foreground = Brushes.Red;
                    break;
                case "zielona":
                    tekstNotatnikaTextBox.Foreground = Brushes.Green;
                    break;
                default:
            
                    tekstNotatnikaTextBox.Foreground = Brushes.Gray;
                    break;
            }
        }
    }
}
