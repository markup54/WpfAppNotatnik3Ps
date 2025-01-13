using Microsoft.Win32;
using System.IO;
using System.Windows;

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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
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
    }
}
