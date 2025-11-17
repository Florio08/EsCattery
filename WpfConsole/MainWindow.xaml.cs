using Application.Dto;
using Application.UseCases;
using Infrastructure.Persistence.Repositories;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfConsole
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _catServices = new CatService(_catRepo,_adoptionRepo);
            _adoptionServices = new AdoptionService(_catRepo,_adoptionRepo,_adopterRepo);
            refreshStats();
        }
        AdopterJsonRepo _adopterRepo = new AdopterJsonRepo();
        AdoptionJsonRepo _adoptionRepo =new AdoptionJsonRepo();
        CatJsonRepo _catRepo = new CatJsonRepo();
        CatService _catServices;
        AdoptionService _adoptionServices;

        private void btn_ViewAdoptions(object sender, RoutedEventArgs e)
        {
            ViewAdoptions viewAdoptionsWindow = new ViewAdoptions(this,_catServices,_adoptionServices);
            viewAdoptionsWindow.Show();
            this.Hide();
        }

        private void btn_AddCat(object sender, RoutedEventArgs e)
        {
            AddCat addCat= new AddCat(this,_catServices);
            addCat.Show();
            this.Hide();

        }

        private void btn_ViewCats(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ViewCats viewCatsWindow = new ViewCats(this,_catServices,_adoptionServices);
            viewCatsWindow.Show();
        }
        private void Href_Click(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)//per aprire il link del mio github PER QUESTO HO CHIESTO AIUTO AL MIO CARO AMICO CHAT
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true // apre nel browser di default
            });
            e.Handled = true;
        }
        private void refreshStats()
        {
            lblTotalCats.Text = _catServices.GetAllCats().Count().ToString();
            lblAdoptions.Text = _adoptionServices.GetAllAdoptions().Count().ToString();
            lblFemales.Text = _catServices.GetAllCats().Where(c => c.Sex.Sex==1).Count().ToString();
            lblMales.Text= _catServices.GetAllCats().Where(c => c.Sex.Sex == 0).Count().ToString();
        }
        private void btn_RefreshStats(object sender, RoutedEventArgs e)
        {
            refreshStats();
        }
    }
}