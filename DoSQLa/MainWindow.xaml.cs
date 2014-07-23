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

namespace DoSQLa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }



        //private void DataGrid_Initialized(object sender, EventArgs e)
        //{
        //    DataClasses1DataContext dba = new DataClasses1DataContext();
        //    var query = (from s in dba.StudentTabelas select new { s.Imię, s.Nazwisko, s.Wiek });
        //    Stjudenci.ItemsSource = query.ToList();
        //}



        private void ComboBox_Initialized(object sender, EventArgs e)
        {
            DataClasses1DataContext dba = new DataClasses1DataContext();
            var zapytanie = (from s in dba.StudentTabelas select new { s.ID, s.Imię, s.Nazwisko });
           
            //string[] doWywalenia = { "{", ",", "ID =", "Imię =", "Nazwisko =", "}" };
            //string[] splity = Convert.ToString(zapytanie).Split(doWywalenia, StringSplitOptions.RemoveEmptyEntries);
            //ComboStjudent.ItemsSource = zapytanie.ToList();
            ////foreach (var item in splity)
            ////{
            ////    ComboStjudent.Items.Add(item);
            ////}

            ComboStjudent.ItemsSource = zapytanie.ToList();

        }

        private void ComboStjudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            string uczen = ComboStjudent.SelectedItem.ToString();
            //string uczenPierwszyEtap = uczen.Substring(6, 2);
            //UczenPierwszyEtap.Content = uczenPierwszyEtap;
            string obciecie = uczen.Remove(0, 6);
            //testLabel.Content = obciecie;
            string searchWithinThis = obciecie;
            string searchForThis = ",";
            int firstCharacter = searchWithinThis.IndexOf(searchForThis);
            //testLabel.Content = firstCharacter;
            string obciecie2 = obciecie.Remove(firstCharacter);
            int id = Convert.ToInt32(obciecie2);

            string[] doWywalenia = { "{", ",", "ID =", "Imię =", "Nazwisko =", "}" };
            string[] splity = uczen.Split(doWywalenia, StringSplitOptions.RemoveEmptyEntries) ;
            foreach (var item in splity)
            {
                ListBoxTest.Items.Add(item);
            }
            //testLabel.Content.ToString(splity);
            
            
            var zapytanie = (from p in db.Przedmioties
                             join o in db.Stu_Przeds on p.ID_przedmiotu equals o.ID_Przedmiotu
                             join u in db.StudentTabelas on o.ID_Studenta equals u.ID
                             where u.ID == id
                             select new { p.Nazwa_przedmiotu, o.Ocena });
            Stjudenci.ItemsSource = zapytanie.ToList();
        }


    }
}
