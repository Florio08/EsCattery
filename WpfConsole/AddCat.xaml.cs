using Application.Dto;
using Application.UseCases;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfConsole
{
    /// <summary>
    /// Logica di interazione per AddCat.xaml
    /// </summary>
    public partial class AddCat : Window
    {
        public AddCat(MainWindow main,CatService catServices )
        {
            InitializeComponent();
            _main = main;
            _catServices = catServices;
        }
        private MainWindow _main;
        private CatService _catServices;
        // ========== MENU / LINK ==========
        private void btn_ViewAdoptions(object s, RoutedEventArgs e) { /* apri ViewAdoptions */ }
        private void btn_AddCat(object s, RoutedEventArgs e) { /* già qui */ }
        private void btn_ViewCats(object s, RoutedEventArgs e) { /* apri lista gatti */ }

        private void Href_Click(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
            e.Handled = true;
        }

        private void SexCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (cbMale.IsChecked == true) cbFemale.IsChecked = false;
            if (cbFemale.IsChecked == true) cbMale.IsChecked = false;
        }

        /// <summary>
        /// dove salvo le immagini dei gatti
        /// </summary>
        /// <returns></returns>
        private static string GetCatImagesDir()
        {
            // Cartella dell'app (bin/Debug/net8.0-windows/…)
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var targetDir = System.IO.Path.Combine(baseDir, "Resources", "CatImages");
            Directory.CreateDirectory(targetDir);
            return targetDir;
        }

        /// <summary>
        /// vedo le estensioni supportate
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool IsSupportedImage(string path)
        {
            string ext = System.IO.Path.GetExtension(path).ToLowerInvariant();
            return ext is ".jpg" or ".jpeg" or ".png" or ".gif" or ".bmp" or ".webp";
        }

        /// <summary>
        /// carico e copio l'immagine selezionata
        /// </summary>
        /// <param name="sourcePath"></param>
        private void LoadAndCopyImage(string sourcePath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath) || !File.Exists(sourcePath))
            {
                MessageBox.Show("File non valido.", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!IsSupportedImage(sourcePath))
            {
                MessageBox.Show("Formato non supportato. Usa JPG, PNG, GIF, BMP o WEBP.", "Formato non valido",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string targetDir = GetCatImagesDir();
            string fileName = System.IO.Path.GetFileName(sourcePath);

            // Evita collisioni: se già esiste, appendo timestamp
            string destPath = System.IO.Path.Combine(targetDir, fileName);
            if (File.Exists(destPath))
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(fileName);
                string ext = System.IO.Path.GetExtension(fileName);
                fileName = $"{name}_{DateTime.Now:yyyyMMdd_HHmmss}{ext}";
                destPath = System.IO.Path.Combine(targetDir, fileName);
            }

            File.Copy(sourcePath, destPath);

            // Preview
            var bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.CacheOption = BitmapCacheOption.OnLoad; // rilascia il file
            bmp.UriSource = new Uri(destPath);
            bmp.EndInit();
            imgPreview.Source = bmp;

            // Scrivi solo il NOME file
            txtPhotoFileName.Text = fileName;
        }

        // drag and drop MODESTAMENTE FATTO DA CHAT (IO NON MENTO, COME AVREI FATTO SENNÓ?)
        private void DropArea_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effects = DragDropEffects.Copy;
            else e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        private void DropArea_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files?.Length > 0)
                {
                    LoadAndCopyImage(files[0]);
                }
            }
        }
        //vb qui ricontrollo l'estensione due volte pk é preso tramite codice e non drag and drop
        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog//grazie mille a stackoverflow ;3
            {
                Filter = "Immagini|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.webp|Tutti i file|*.*"
            };
            if (dlg.ShowDialog() == true)
            {
                LoadAndCopyImage(dlg.FileName);
            }
        }

        // ========== SALVA ==========
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Qui costruisci il tuo DTO/Entity e invoca il service (es. _catService.Add(...))
            // Esempio (pseudo):
            // var sex = cbMale.IsChecked == true ? "M" : cbFemale.IsChecked == true ? "F" : null;
            // var dto = new CatDto { Name = txtName.Text, Breed = txtBreed.Text, Sex = sex, Description = txtDescription.Text,
            //                        BirthDay = dpBirthDay.SelectedDate, Arrival = dpArrival.SelectedDate,
            //                        PhotoFileName = txtPhotoFileName.Text };
            // _catService.Add(dto);
            SexDto sex;
            if (cbMale.IsChecked == true)
            {
                 sex= new SexDto(0);
            }
            else
            {
                sex = new SexDto(1);
            }
            try
            {
                DateOnly? birth = dpBirthDay.SelectedDate.HasValue ? DateOnly.FromDateTime(dpBirthDay.SelectedDate.Value) : null;
                DateOnly arrived = DateOnly.FromDateTime(dpArrival.SelectedDate ?? DateTime.Today);
                _catServices.AddCat(new Application.Dto.CatDto(txtName.Text, txtBreed.Text, sex, txtDescription.Text, birth, arrived, null, txtPhotoFileName.Text, null));

            }catch(Exception ex)
            {
                MessageBox.Show($"Errore durante il salvataggio del gatto, ricontrollare i dati inseriti: {ex.Message}", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Gatto salvato!", "Successo", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
            _main.Show();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) 
        {
            _main.Show();
            this.Close();
        }
    }
}
