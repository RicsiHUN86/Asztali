using System.Windows;

namespace Filmek
{
    class Film
    {
        public string Cim { get; set; }
        public string Mufaj { get; set; }
        public int Hossz { get; set; }
        public double Ertekeles { get; set; }

        public Film(string cim, string mufaj, int hossz, double ertekeles)
        {
            Cim = cim;
            Mufaj = mufaj;
            Hossz = hossz;
            Ertekeles = ertekeles;
        }
    }

    public partial class MainWindow : Window
    {
        List<Film> filmek = new List<Film>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void betoltes(object sender, RoutedEventArgs e)
        {
            filmek.Clear();
            filmek.Add(new Film("Csillagok háborúja", "sci-fi", 121, 8.6));
            filmek.Add(new Film("Titanic", "dráma", 195, 7.8));
            filmek.Add(new Film("A Gyűrűk Ura", "fantasy", 201, 8.8));
            filmek.Add(new Film("Mátrix", "sci-fi", 136, 8.7));
            filmek.Add(new Film("Shrek", "animáció", 90, 7.9));
            dataGrid.ItemsSource = filmek;
            folyamat.Value = 100;
        }

        private void darab(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Filmek száma: {filmek.Count}");
        }

        private void leghosszabb(object sender, RoutedEventArgs e)
        {
            Film leghosszabb = filmek.MaxBy(film => film.Hossz);
            MessageBox.Show($"Leghosszabb film: {leghosszabb.Cim} ({leghosszabb.Hossz} perc)");
        }

        private void atlag(object sender, RoutedEventArgs e)
        {
            double atlag = filmek.Average(film => film.Ertekeles);
            MessageBox.Show($"Átlag értékelés: {atlag:F1}");
        }

        private void csakSciFi(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = filmek.Where(film => film.Mufaj == "sci-fi").ToList();
        }

        private void csakCimek(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = filmek.Select(film => new { film.Cim }).ToList();
        }

        private void rendezes(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = filmek.OrderBy(film => film.Cim).ToList();
        }

        private void kivalasztas(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is Film kijelolt)
            {
                MessageBox.Show($"Kiválasztott film: {kijelolt.Cim}\nÉrtékelés: {kijelolt.Ertekeles}");
            }
        }
    }
}
