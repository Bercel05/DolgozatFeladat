using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DolgozatFeladat
{
  
    public class Dolgozat
    {
        public string Nev { get; set; }
        public int Eletkor { get; set; }
        public int Pontszam { get; set; }
    }

    public partial class MainWindow : Window
    {
        
        public ObservableCollection<Dolgozat> DolgozatLista { get; set; } = new ObservableCollection<Dolgozat>();

        public MainWindow()
        {
            InitializeComponent();

            DolgozatLista.Add(new Dolgozat { Nev = "Kiss Péter", Eletkor = 16, Pontszam = 87 });
            DolgozatLista.Add(new Dolgozat { Nev = "Nagy Anna", Eletkor = 17, Pontszam = 92 });
            DolgozatLista.Add(new Dolgozat { Nev = "Szabó Tamás", Eletkor = 16, Pontszam = 78 });
            DolgozatLista.Add(new Dolgozat { Nev = "Tóth Éva", Eletkor = 18, Pontszam = 95 });
            DolgozatLista.Add(new Dolgozat { Nev = "Varga Bence", Eletkor = 17, Pontszam = 81 });
            DolgozatLista.Add(new Dolgozat { Nev = "Horváth Zsolt", Eletkor = 16, Pontszam = 65 });
            DolgozatLista.Add(new Dolgozat { Nev = "Molnár Réka", Eletkor = 18, Pontszam = 89 });
            DolgozatLista.Add(new Dolgozat { Nev = "Lakatos Dániel", Eletkor = 17, Pontszam = 72 });

            
            dgDolgozatok.ItemsSource = DolgozatLista;
        }

        private void BtnHozzaadas_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNev.Text))
            {
                MessageBox.Show("Kérlek, add meg a nevet!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (int.TryParse(txtEletkor.Text, out int eletkor) && int.TryParse(txtPontszam.Text, out int pontszam))
            {
                Dolgozat ujDolgozat = new Dolgozat
                {
                    Nev = txtNev.Text,
                    Eletkor = eletkor,
                    Pontszam = pontszam
                };

                DolgozatLista.Add(ujDolgozat);
                txtNev.Clear();
                txtEletkor.Clear();
                txtPontszam.Clear();
            }
            else
            {
                MessageBox.Show("Az életkor és a pontszám csak szám lehet!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       
        private void BtnMentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("dolgozatok_mentes.txt"))
                {
                    foreach (var d in DolgozatLista)
                    {
                        sw.WriteLine($"{d.Nev};{d.Eletkor};{d.Pontszam}");
                    }
                }
                MessageBox.Show("Sikeres mentés a 'dolgozatok_mentes.txt' fájlba!", "Mentés", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Hiba történt a mentés során: " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}