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

namespace Prb.Hotel.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> chambers = new List<string>();
        List<int> nights = new List<int>();
        List<int> persons = new List<int>();
        int NumberOfperson;
        double totaal;
        string fName;
        string lName;
        string fullName;


        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillChambers();
            NightsIn();
            NumberOfPersonsIn();
            txtFirstName.Focus();
            ckbOntbijt.IsChecked = true;
            cmbNumberOfPersons.SelectedIndex = 0;
            cmbRoomChoice.SelectedIndex = 0;
            lblBreakfast.Visibility = Visibility.Collapsed;
        }

        private void FillChambers()
        {
            chambers.Add("Standard Room");
            chambers.Add("Executive Room");
            chambers.Add("Deluxe Penthouse");

            cmbRoomChoice.ItemsSource = chambers;
        }         

        private void GetRoom()
        {
            cmbRoomChoice.ItemsSource = chambers;

            if (cmbRoomChoice.SelectedIndex == 0)
            {
                lblRoom.Content = "Kamer: Standard Room €50 / nacht";
            }
            else if (cmbRoomChoice.SelectedIndex == 1)
            {
                lblRoom.Content = "Kamer: Executive Room €100 / nacht";
            }
            else if (cmbRoomChoice.SelectedIndex == 2)
            {
                lblRoom.Content = "Kamer: Deluxe Penthouse €200 / nacht";
            }
        }

        private void NightsIn()
        {
            nights.Add(1);
            nights.Add(2);
            nights.Add(3);
            nights.Add(4);
            nights.Add(5);
            nights.Add(6);
            nights.Add(7);
            nights.Add(8);
            nights.Add(9);
            nights.Add(10);

            cmbNumberOfNights.ItemsSource = nights;
            cmbNumberOfNights.SelectedIndex = 0;
        }

        private void NumberOfPersonsIn()
        {
            persons.Add(1);
            persons.Add(2);
            persons.Add(3);
            persons.Add(4);
            persons.Add(5);

            cmbNumberOfPersons.ItemsSource = persons;

            if (cmbNumberOfPersons.SelectedIndex == 0)
            {
                lblPersons.Content = $"Aantal personen: 1";
            }
            else if(cmbNumberOfPersons.SelectedIndex == 1)
            {
                lblPersons.Content = $"Aantal personen: 2";
            }
            else if(cmbNumberOfPersons.SelectedIndex == 2)
            {
                lblPersons.Content = $"Aantal personen: 3";
            }
            else if (cmbNumberOfPersons.SelectedIndex == 3)
            {
                lblPersons.Content = $"Aantal personen: 4";
            }
            else if(cmbNumberOfPersons.SelectedIndex == 4)
            {
                lblPersons.Content = $"Aantal personen: 5";
            }
        }

        private void CkbOntbijt_Checked(object sender, RoutedEventArgs e)
        {
            if (ckbOntbijt.IsChecked == true)
            {
                ckbGeenOntbijt.IsChecked = false;
                lblBreakfast.Content = "Met ontbijt (reeds inbegrepen in de prijs)";
            }
            else if (ckbOntbijt.IsChecked == false)
            {
                lblOverview.Content = "";
            }
        }

        private void GetNumberOfNights()
        {
            if (cmbNumberOfNights.SelectedIndex == 0)
            {
                lblOverview.Content = $"Klantnaam : {fullName}\nAantal nachten: 1";
            }
            if (cmbNumberOfNights.SelectedIndex == 1)
            {
                lblOverview.Content = $"Klantnaam : {fullName}\nAantal nachten: 2";
            }
            if (cmbNumberOfNights.SelectedIndex == 2)
            {
                lblOverview.Content = $"Klantnaam : {fullName}\nAantal nachten: 3";
            }
            if (cmbNumberOfNights.SelectedIndex == 3)
            {
                lblOverview.Content = $"Klantnaam : {fullName}\nAantal nachten: 4";
            }
            if (cmbNumberOfNights.SelectedIndex == 4)
            {
                lblOverview.Content = $"Klantnaam : {fullName}\nAantal nachten: 5";
            }
            if (cmbNumberOfNights.SelectedIndex == 5)
            {
                lblOverview.Content = $"Klantnaam : {fullName}\nAantal nachten: 6";
            }
            if (cmbNumberOfNights.SelectedIndex == 6)
            {
                lblOverview.Content = $"Klantnaam : {fullName}\nAantal nachten: 7";
            }
            if (cmbNumberOfNights.SelectedIndex == 7)
            {
                lblOverview.Content = $"Klantnaam : {fullName}\nAantal nachten: 8";
            }
            if (cmbNumberOfNights.SelectedIndex == 8)
            {
                lblOverview.Content = $"Klantnaam : {fullName}\nAantal nachten: 9";
            }
            else if (cmbNumberOfNights.SelectedIndex == 9)
            {
                lblOverview.Content = $"Klantnaam : {fullName}\nAantal nachten: 10";
            }
        }

        private void CkbGeenOntbijt_Checked(object sender, RoutedEventArgs e)
        {
            ckbOntbijt.IsChecked = false;
            if (ckbGeenOntbijt.IsChecked == true)
            {
                lblBreakfast.Content = "Geen ontbijt";
            }
            else if (ckbGeenOntbijt.IsChecked == false)
            {
                lblOverview.Content = "";
            }
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            fName = txtFirstName.Text;
            lName = txtLastName.Text;


            if (txtFirstName.Text == "" || txtLastName.Text == "")
            {
                MessageBox.Show("Gelieve uw naam in te vullen !", "FOUT", MessageBoxButton.OK, MessageBoxImage.Error);
                txtFirstName.Focus();
            }
            else
            {
                fullName = $"{fName} {lName}";
                lblOverview.Content = fullName;

                GetNumberOfNights();
                NumberOfPersonsIn();
                GetRoom();
                lblBreakfast.Visibility = Visibility.Visible;
                Calculation();
            }

            
        }

        private void Calculation()
        {
            totaal = 0;
            int totalRoom = 0;
            int numberOfNights = 1;

            if(cmbRoomChoice.SelectedIndex == 0)
            {
                totalRoom = 50;
            }
            if(cmbRoomChoice.SelectedIndex == 1)
            {
                totalRoom += 100;
            }
            else if(cmbRoomChoice.SelectedIndex == 2)
            {
                totalRoom += 200;
            }

           

            if (cmbNumberOfPersons.SelectedIndex == 0)
            {
                NumberOfperson = 1;
            }
            if (cmbNumberOfPersons.SelectedIndex == 1)
            {
                NumberOfperson = 2;
            }
            if (cmbNumberOfPersons.SelectedIndex == 2)
            {
                NumberOfperson = 3;
            }
            if (cmbNumberOfPersons.SelectedIndex == 3)
            {
                NumberOfperson = 4;
            }
            else if (cmbNumberOfPersons.SelectedIndex == 4)
            {
                NumberOfperson = 5;
            }



            if(cmbNumberOfNights.SelectedIndex == 0)
            {
                totalRoom = totalRoom * 1;
            }
            if (cmbNumberOfNights.SelectedIndex == 1)
            {
                totalRoom = totalRoom * 2;
            }
            if (cmbNumberOfNights.SelectedIndex == 2)
            {
                totalRoom = totalRoom * 3;
            }
            if (cmbNumberOfNights.SelectedIndex == 3)
            {
                totalRoom = totalRoom * 4;
            }
            if (cmbNumberOfNights.SelectedIndex == 4)
            {
                totalRoom = totalRoom * 5;
            }
            if (cmbNumberOfNights.SelectedIndex == 5)
            {
                totalRoom = totalRoom * 6;
            }
            if (cmbNumberOfNights.SelectedIndex == 6)
            {
                totalRoom = totalRoom * 7;
            }
            if (cmbNumberOfNights.SelectedIndex == 7)
            {
                totalRoom = totalRoom * 8;
            }
            if (cmbNumberOfNights.SelectedIndex == 8)
            {
                totalRoom = totalRoom * 9;
            }
            if (cmbNumberOfNights.SelectedIndex == 9)
            {
                totalRoom = totalRoom * 10;
            }

            totaal = numberOfNights * totalRoom;
            tbkTotal.Text = $"€ {totaal.ToString()}";
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";

            cmbNumberOfPersons.SelectedIndex = 0;
            cmbNumberOfNights.SelectedIndex = 0;
            cmbRoomChoice.SelectedIndex = 0;

            lblBreakfast.Content = "";
            lblOverview.Content = "";
            lblPersons.Content = "";
            lblRoom.Content = "";
            txtFirstName.Focus();
        }
    }
}
