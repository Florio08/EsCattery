using Application.UseCases;
using Domain.Model.Entities;
using Infrastructure.Persistence.Dto;
using Infrastructure.Persistence.Repositories;
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
using Application.Dto;
namespace WpfConsole
{
    /// <summary>
    /// Logica di interazione per ViewAdoptions.xaml
    /// </summary>
    public partial class ViewAdoptions : Window
    {
        public ViewAdoptions(MainWindow main, CatService catServices,AdoptionService adoptionService )
        {
            InitializeComponent();
            _catServices = catServices;
            _adoptionService = adoptionService;
            lvAdoptions.ItemsSource =_adoptionService.GetAllAdoptions();
        }
        CatService _catServices;
        AdoptionService _adoptionService;

        private void Refund_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)?.DataContext is AdoptionDto adoption)
            {

                var result = MessageBox.Show(
                    $"Vuoi revocare l'adozione di {adoption.Cat.Name}?",
                    "Conferma revoca",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    DateOnly refundDate = DateOnly.FromDateTime(DateTime.Now);
                    _adoptionService.RefundCat(adoption.Cat,refundDate);
                    MessageBox.Show("Adozione revocata!", "Revoca", MessageBoxButton.OK, MessageBoxImage.Information);
                    lvAdoptions.ItemsSource= _adoptionService.GetAllAdoptions();
                }
            }
        }
    }
}
