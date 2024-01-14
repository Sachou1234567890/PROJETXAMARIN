using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace SALONXAMARIN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Offres : ContentPage
    {
        public Offres()
        {
            InitializeComponent();

            // Créer une liste dynamique des postes disponibles
            List<string> availablePositions = GetAvailablePositions(); // Méthode pour obtenir les postes disponibles

            // Définir la source de données pour le Picker
            AvailablePositionsPicker.ItemsSource = availablePositions;
        }

        // Méthode pour obtenir les postes disponibles (exemple)
        private List<string> GetAvailablePositions()
        {
            // Ici, vous pouvez obtenir la liste depuis une source de données externe (base de données, service web, etc.)
            // Pour l'exemple, je crée une liste statique :
            return new List<string>
            {
                "Assistant visiteur",
                "Responsable de stand",
                // Ajoutez d'autres postes disponibles ici...
            };
        }

        // Méthode appelée lorsqu'un poste est sélectionné dans le Picker
        private void OnPositionSelected(object sender, EventArgs e)
        {
            var selectedPosition = AvailablePositionsPicker.SelectedItem as string;

            // Mettre à jour la description du poste en fonction de la sélection
            if (selectedPosition == "Assistant visiteur")
            {
                DescriptionLabel.Text = "Description détaillée du Poste 1.";
            }
            else if (selectedPosition == "Responsable de stand")
            {
                DescriptionLabel.Text = "Description détaillée du Poste 2.";
            }
            // Ajoutez d'autres conditions pour chaque poste disponible
            // Assurez-vous de correspondre exactement aux valeurs du Picker
        }


        private async void OnFilePickerButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var button = (Xamarin.Forms.Button)sender; // Get the button that triggered the event

                if (button.Text == "Télécharger un CV") // Assuming the button text is used for identification
                {
                    var pickedFile = await FilePicker.PickAsync(new PickOptions
                    {
                        PickerTitle = "Sélectionner un fichier",
                        FileTypes = FilePickerFileType.Pdf, // Adjust file types as needed
                    });

                    if (pickedFile != null)
                    {
                        CVLabel.Text = $"CV : {pickedFile.FileName}";
                        ClearCVButton.IsVisible = true; // Show trash can icon for clearing CV
                    }
                }
                else if (button.Text == "Télécharger une lettre de motivation") // Assuming the button text is used for identification
                {
                    var pickedFile = await FilePicker.PickAsync(new PickOptions
                    {
                        PickerTitle = "Sélectionner un fichier",
                        FileTypes = FilePickerFileType.Pdf, // Adjust file types as needed
                    });

                    if (pickedFile != null)
                    {
                        LettreLabel.Text = $"Lettre de motivation : {pickedFile.FileName}";
                        ClearLettreButton.IsVisible = true; // Show trash can icon for clearing lettre
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error picking file: {ex.Message}");
            }
        }

        private void OnClearCVButtonClicked(object sender, EventArgs e)
        {
            CVLabel.Text = string.Empty; // Clear CV label text
            ClearCVButton.IsVisible = false; // Hide trash can icon for CV
                                             // Delete the associated file - Implement file deletion logic here if needed
        }

        private void OnClearLettreButtonClicked(object sender, EventArgs e)
        {
            LettreLabel.Text = string.Empty; // Clear Lettre label text
            ClearLettreButton.IsVisible = false; // Hide trash can icon for Lettre
                                                 // Delete the associated file - Implement file deletion logic here if needed
        }

        private async void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            // Vérifier si au moins un champ est vide ou si aucun poste n'est sélectionné
            bool isAnyFieldEmpty = string.IsNullOrWhiteSpace(FirstNameEntry.Text)
                || string.IsNullOrWhiteSpace(LastNameEntry.Text)
                || string.IsNullOrWhiteSpace(EmailEntry.Text)
                || string.IsNullOrWhiteSpace(PhoneNumberEntry.Text)
                || AvailablePositionsPicker.SelectedIndex == -1; // Vérifier si aucun poste n'est sélectionné

            if (isAnyFieldEmpty)
            {
                await DisplayAlert("Erreur", "Veuillez remplir tous les champs du formulaire et sélectionner un poste.", "OK");
                return; // Arrêter le traitement si un champ est vide ou aucun poste sélectionné
            }

            // Si tous les champs sont remplis et un poste est sélectionné, continuer avec l'envoi de la candidature
            // (Ajoutez ici la logique pour envoyer la candidature)
        }



        //private void OnDocumentSwitchToggled(object sender, ToggledEventArgs e)
        //{
        //    if (e.Value)
        //    {
        //        SwitchLabel.Text = "J'ai bien vérifié les informations fournies";
        //        //SwitchLabel.Text = "J'ai bien examiné les données du formulaire";
        //        //SwitchLabel.Text = "J'ai bien visualisé les documents";
        //    }
        //    else
        //    {
        //        SwitchLabel.Text = "Vous devez visualiser les documents pour continuer";
        //    }
        //}




    }
}