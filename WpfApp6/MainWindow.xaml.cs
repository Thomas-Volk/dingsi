
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

namespace Abschlussprojekt_Passwortmanager
{
    /// <summary>
    /// Interaktionslogik für AccountAdd.xaml
    /// </summary>
    public partial class AccountAdd : Window
    {
        //public List<string> accounts = new List<string>();
       List<Account> accounts = new List<Account>();

        public AccountAdd(string benutzerName)
        {
            InitializeComponent();

            //test

            //string benutzerName = "Basti";
            var hour = DateTime.Now.Hour;

            if (hour < 12)
            {
                lblBegruessung.Content = "Guten Morgen"; //{0}", benutzerName;
            }
            else if (hour < 18)
            {
                lblBegruessung.Content = "Guten Nachmittag"; //{0}", benutzerName);
            }
            else
            {
                lblBegruessung.Content = "Guten Abend"; //{0}", benutzerName);
            }


        }



        // Button zum Passwort generieren
        public void btnPasswort_Click(object sender, RoutedEventArgs e)
        {
            double sliderValue = woSlider.Value;
            int length = Convert.ToInt32(sliderValue);
        }


        // Button zum Passowort generieren
        private string generietesPasswort(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!§$%&/?";
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                sb.Append(validChars[rnd.Next(validChars.Length)]);
            }
            return sb.ToString();

        }

        //Button zum Account erstellen
        public void btnAccountAdd_Click(object sender, RoutedEventArgs e)
        {
            string plattform = txtPlattform.Text;
            string benutzer = txtBenutzer.Text;
            string genPasswort = txtGenPW.Text;

            if (!string.IsNullOrEmpty(plattform) && !string.IsNullOrEmpty(benutzer) && !string.IsNullOrEmpty(genPasswort))
            {
                accounts.Add(new Account { plattform = plattform, benutzer = benutzer, genPasswort = genPasswort });
                MessageBox.Show("Account wurde hinzugefügt");
            }
            else
            {
                MessageBox.Show("Bitte alle Felder ausfüllen");
            }
        }

        public void btnAccountShow_Click(object sender, RoutedEventArgs e)
        {
            var accountSeite = new AccountSeite(accounts);
            AccountSeite.Show();

        }


    }
    public class Account
    {
        public string plattform { get; set; }
        public string benutzer { get; set; }
        public string genPasswort { get; set; }

        public override string ToString()
        {
            return $"{plattform} - {benutzer}: {genPasswort}";
        }
    }
}
