using Application.Dto;
using Application.UseCases;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace WpfConsole
{
    public partial class ViewCats : Window
    {
        private readonly MainWindow _main;
        private readonly CatService _catServices;
        private readonly AdoptionService _adoptionServices;

        public ViewCats(MainWindow main, CatService catServices, AdoptionService adoptionServices)
        {
            InitializeComponent();
            _main = main;
            _catServices = catServices;
            _adoptionServices = adoptionServices;
            LoadCats();
        }

        private void LoadCats()
        {
            var cats = _catServices.GetAllCats();
            icCats.ItemsSource = cats;
        }

        // ===== MENU =====
        private void btn_ViewAdoptions(object sender, RoutedEventArgs e)
        {
            var v = new ViewAdoptions(_main, _catServices, _adoptionServices);
            this.Hide();
            v.Show();
        }

        private void btn_AddCat(object sender, RoutedEventArgs e)
        {
            var addCat = new AddCat(_main, _catServices);
            this.Hide();
            addCat.Show();
        }

        private void btn_back(object sender, RoutedEventArgs e)
        {
            this.Hide();
            _main.Show();
        }

        private void Href_Click(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
            e.Handled = true;
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var img = (System.Windows.Controls.Image)sender;
                string catImagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "CatImages");
                string imageFile = Path.Combine(catImagesPath, "noPhoto.jpg");

                if ((sender as FrameworkElement)?.DataContext is CatDto cat)
                {
                    if (!string.IsNullOrWhiteSpace(cat.CatImage))
                    {
                        var candidate = Path.Combine(catImagesPath, cat.CatImage);
                        if (File.Exists(candidate))
                            imageFile = candidate;
                    }
                }

                if (File.Exists(imageFile))
                {
                    var bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.CacheOption = BitmapCacheOption.OnLoad;
                    bmp.UriSource = new Uri(imageFile, UriKind.Absolute);
                    bmp.EndInit();
                    bmp.Freeze();
                    img.Source = bmp;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore caricamento immagine: " + ex.Message,
                                "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OpenCatDetails_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.DataContext is CatDto cat)
            {
                var catOverView = new CatOverView(cat, this, _adoptionServices);
                this.Hide();
                catOverView.Show();
            }
        }
    }
}
