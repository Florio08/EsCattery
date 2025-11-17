using Application.Dto;
using Application.UseCases;
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
using System.Windows.Shapes;

namespace WpfConsole
{
    /// <summary>
    /// Logica di interazione per MakeAdoption.xaml
    /// </summary>
    public partial class MakeAdoption : Window
    {
        public MakeAdoption(ViewCats viewCats, AdoptionService adoptionServices,CatDto cat)
        {
            InitializeComponent();
            _viewCats = viewCats;
            _adoptionServices = adoptionServices;
            _cat = cat;
        }
        private ViewCats _viewCats;
        private AdoptionService _adoptionServices;
        private CatDto _cat;
        private void BtnAdopt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _adoptionServices.AdoptCat(_cat, new AdopterDto(txtName.Text, txtSurname.Text, new AddressDto(txtStreet.Text, txtCity.Text, txtPostalCode.Text, txtCountry.Text), new PhoneNumberDto(txtCelNumber.Text), new FiscalCodeDto(txtFiscalCode.Text), new EmailDto(txtEmail.Text)), DateOnly.FromDateTime(DateTime.Now));
            }catch(Exception ex)
            {
                MessageBox.Show("One of the field is wrong, check if everything is correct, MAYBE you did not put VIA on the street or the cell number does not have thhe prefix like +39","Riprova",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            MessageBox.Show("Adoption Complete","Success",MessageBoxButton.OK,MessageBoxImage.Information);
            _viewCats.Show();
            this.Close();
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            _viewCats.Show();
            this.Close();
        }
    }
}
