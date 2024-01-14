using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SALONXAMARIN
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Profil : ContentPage
	{
		public Profil ()
		{
			InitializeComponent ();
		}

        private async void OnMoreButtonClicked(object sender, EventArgs e)
        {
            // Create and show the popup
            await PopupNavigation.Instance.PushAsync(new MoreOptionsPopup());
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
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error picking file: {ex.Message}");
            }
        }
        private async void Postes_enregistres_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Postes_enregistres()); // Redirige vers la page du profil
        }
        private async void Profil_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profil()); // Redirige vers la page du profil
        }
        private void OnClearCVButtonClicked(object sender, EventArgs e)
        {
            CVLabel.Text = string.Empty; // Clear CV label text           
        }        
    }

    public class MoreOptionsPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public MoreOptionsPopup()
        {
            CloseWhenBackgroundIsClicked = true;
            HasSystemPadding = false;

            StackLayout layout = new StackLayout
            {
                BackgroundColor = Color.White,
                Padding = new Thickness(20),
                Spacing = 10,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 250, // Adjust the width as needed
                HeightRequest = 200, // Adjust the height as needed
            };

            // Create the layout and buttons inside the popup
            //StackLayout layout = new StackLayout();

            // Buttons with a consistent style
            Xamarin.Forms.Button afficherButton = new Xamarin.Forms.Button
            {
                Text = "Afficher",
                FontSize = 16,
                TextColor = Color.FromHex("#007AFF"), // Adjust the color to your preference
            };

            Xamarin.Forms.Button telechargerButton = new Xamarin.Forms.Button
            {
                Text = "Télécharger",
                FontSize = 16,
                TextColor = Color.FromHex("#007AFF"), // Adjust the color to your preference
            };

            Xamarin.Forms.Button remplacerButton = new Xamarin.Forms.Button
            {
                Text = "Remplacer",
                FontSize = 16,
                TextColor = Color.FromHex("#007AFF"), // Adjust the color to your preference
            };

            Xamarin.Forms.Button supprimerButton = new Xamarin.Forms.Button
            {
                Text = "Supprimer",
                FontSize = 16,
                TextColor = Color.FromHex("#FF3B30"), // Adjust the color to your preference
            };

            layout.Children.Add(afficherButton);
            layout.Children.Add(remplacerButton);
            layout.Children.Add(telechargerButton);
            layout.Children.Add(supprimerButton);

            // Set the content of the popup
            Content = layout;
        }
    }
}