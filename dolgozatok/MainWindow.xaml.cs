using System.Collections.ObjectModel;
using System.Windows;

namespace dolgozatok
{
    class Diak
    {
        public string Nev { get; set; }
        public int Eletkor { get; set; }
        public int Pontszam { get; set; }

        public Diak(string nev, int eletkor, int pontszam)
        {
            Nev = nev;
            Eletkor = eletkor;
            Pontszam = pontszam;
        }
    }

    public partial class MainWindow : Window
    {
        List<Diak> diakok = new List<Diak>();

        public MainWindow()
        {
            InitializeComponent();
            diakok.Add(new Diak("Kiss Péter", 16, 87));
            diakok.Add(new Diak("Nagy Anna", 17, 92));
            diakok.Add(new Diak("Szabó Tamás", 16, 78));
            diakok.Add(new Diak("Tóth Éva", 18, 95));
            diakok.Add(new Diak("Varga Bence", 17, 81));
            diakok.Add(new Diak("Horváth Zsolt", 16, 65));
            diakok.Add(new Diak("Molnár Réka", 18, 89));
            diakok.Add(new Diak("Lakatos Dániel", 17, 72));
            dataGrid.ItemsSource = diakok;
        }

        private void hozzaadas(object sender, RoutedEventArgs e)
        {
            int kor = Convert.ToInt32(Eletkor.Text);
            int pont = Convert.ToInt32(Pontszam.Text);
            diakok.Add(new Diak(Nev.Text, kor, pont));
            dataGrid.Items.Refresh();
            Nev.Clear();
            Eletkor.Clear();
            Pontszam.Clear();
        }

        private void mentes(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mentve!");
        }
    }
}
