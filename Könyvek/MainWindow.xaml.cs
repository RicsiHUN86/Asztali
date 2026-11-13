using System.Windows;

namespace Konyvek
{
    class Konyv
    {
        public string Cim { get; set; }
        public string Szerzo { get; set; }
        public int Oldalszam { get; set; }
        public string Mufaj { get; set; }
        public bool Elerheto { get; set; }

        public Konyv(string cim, string szerzo, int oldalszam, string mufaj, bool elerheto)
        {
            Cim = cim;
            Szerzo = szerzo;
            Oldalszam = oldalszam;
            Mufaj = mufaj;
            Elerheto = elerheto;
        }
    }

    public partial class MainWindow : Window
    {
        List<Konyv> konyvek = new List<Konyv>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void betoltes(object sender, RoutedEventArgs e)
        {
            konyvek.Clear();
            konyvek.Add(new Konyv("1984", "George Orwell", 328, "Sci-fi", true));
            konyvek.Add(new Konyv("A szolgálólány meséje", "Margaret Atwood", 311, "Disztópia", false));
            konyvek.Add(new Konyv("Az ember tragédiája", "Madách Imre", 250, "Dráma", true));
            konyvek.Add(new Konyv("Dűne", "Frank Herbert", 604, "Sci-fi", true));
            konyvek.Add(new Konyv("Egri csillagok", "Gárdonyi Géza", 552, "Történelmi", false));
            dataGrid.ItemsSource = konyvek;
            folyamat.Value = 100;
        }

        private void darab(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Összesen {konyvek.Count} könyv van.");
        }

        private void leghosszabb(object sender, RoutedEventArgs e)
        {
            Konyv leghosszabb = konyvek.MaxBy(static konyv => konyv.Oldalszam);
            MessageBox.Show($"Leghosszabb könyv: {leghosszabb.Cim} ({leghosszabb.Oldalszam} oldal)");
        }

        private void atlag(object sender, RoutedEventArgs e)
        {
            double atlag = konyvek.Average(static konyv => konyv.Oldalszam);
            MessageBox.Show($"Átlagos oldalszám: {atlag:F0}");
        }

        private void csakElerheto(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = konyvek.Where(static konyv => konyv.Elerheto).ToList();
        }

        private void csakCimek(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = konyvek.Select(static konyv => new { konyv.Cim }).ToList();
        }

        private void rendezes(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = konyvek.OrderBy(static konyv => konyv.Szerzo).ToList();
        }
    }
}
