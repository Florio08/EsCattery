using Domain.Model.Entities;
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
using Application.UseCases;
namespace WpfConsole
{
    /// <summary>
    /// Logica di interazione per CatOverView.xaml
    /// </summary>
    public partial class CatOverView : Window
    {
        public CatOverView(CatDto cat, ViewCats back,AdoptionService adoptionServices)
        {
            InitializeComponent();
            AdoptionServices = adoptionServices;
            _viewCats = back;
            _cat = cat;
            DisplayCatInfo(_cat);
        }
        private ViewCats _viewCats;
        private CatDto _cat;
        private AdoptionService AdoptionServices;
        private void DisplayCatInfo(CatDto cat)
        {
            // Set the title of the window to the cat's name  
            this.Title = $"Dettagli di {cat.Name}";
    
            lblName.Content = $"Nome: {cat.Name}";
            lblAge.Content = $"Sesso: {cat.Sex}";
            lblBreed.Content = $"Razza: {cat.Race}";
            lblDescription.Text = cat.Description;
            lblBirth.Content = cat.Birth.HasValue ? $"Data di nascita: {cat.Birth.Value:dd/MM/yyyy}" : "Data di nascita: N/A";
            lblArrived.Content = $"Data di arrivo al gattile: {cat.ArrivedToCattery:dd/MM/yyyy}";
            lblLeft.Content = cat.LeftCattery.HasValue ? $"Data di uscita dal gattile: {cat.LeftCattery.Value:dd/MM/yyyy}" : "Data di uscita dal gattile: Ancora presente";

            // Display cat photo  
            string catImagesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "CatImages");
            string imageFile;
            if (!string.IsNullOrEmpty(cat.CatImage))
            {

                imageFile = System.IO.Path.Combine(catImagesPath, cat.CatImage);
                imgCatPhoto.Source = new BitmapImage(new Uri(imageFile, UriKind.Absolute));
            }
            else
            {
                imageFile = System.IO.Path.Combine(catImagesPath, "noPhoto.jpg");
                imgCatPhoto.Source = new BitmapImage(new Uri(imageFile, UriKind.Absolute));
            }
                
        }
        private void btnAdoptNow_Click(object sender, RoutedEventArgs e)
        {
            MakeAdoption makeAdoption= new MakeAdoption(_viewCats,AdoptionServices,_cat);
            makeAdoption.Show();
            this.Close();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            _viewCats.Show(); 
            this.Close(); 
        }
    }
}
