namespace CrossProjek4.Views
{
    public partial class Kontrol : ContentPage
    {
        public Kontrol()
        {
            InitializeComponent();
        }

        private async void OnButton_Clicked(object sender, EventArgs e)
        {
            bool confirmation = await DisplayAlert("Konfirmasi", "Tekan 'Ya' Untuk Lanjut Atau 'Tidak' Untuk Batal.", "Ya", "Tidak");

            if (confirmation)
            {
                // Send a message indicating that the switch is turned on
                MessagingCenter.Send(this, "SwitchStatusChanged", true);

                // Show a warning message as a pop-up alert
                await DisplayAlert("Warning", "Mengaktifkan", "OK");

                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                // Show a cancellation message as a pop-up alert
                await DisplayAlert("Cancellation", "Dibatalkan", "OK");
            }
        }

        private async void OffButton_Clicked(object sender, EventArgs e)
        {
            bool confirmation = await DisplayAlert("Konfirmasi", "Tekan 'Ya' Untuk Lanjut Atau 'Tidak' Untuk Batal.", "Ya", "Tidak");

            if (confirmation)
            {
                // Send a message indicating that the switch is turned off
                MessagingCenter.Send(this, "SwitchStatusChanged", false);

                // Show a warning message as a pop-up alert
                await DisplayAlert("Warning", "Mengaktifkan", "OK");

                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                // Show a cancellation message as a pop-up alert
                await DisplayAlert("Cancellation", "Dibatalkan", "OK");
            }
        }

    }
}
