namespace CrossProjek4.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Subscribe to the message for switch status change
            MessagingCenter.Subscribe<Kontrol, bool>(this, "SwitchStatusChanged", (sender, isOn) =>
            {
                StatusLabel.Text = isOn ? "Status: On" : "Status: Off";
            });


        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Connection());
        }
        private async void ConnectButton_Clicked(object sender, EventArgs e)
        {
            string ipAddress = IpEntry.Text;

            if (!string.IsNullOrWhiteSpace(ipAddress))
            {
                // Perform the connection logic with the provided IP address
                // You can add your code here to handle the connection

                // Update the connection status label
                ConnectionStatusLabel.Text = "Connecting to " + ipAddress;

                // Start the scan timer
                await ScanForIPAddressWithTimer(ipAddress);
            }
            else
            {
                // Display an alert if the IP address is empty
                await DisplayAlert("Error", "Please enter a valid IP address", "OK");
            }
        }

        private async Task ScanForIPAddressWithTimer(string ipAddress)
        {
            // Perform the scan logic with the provided IP address
            // You can replace the following code with your actual scanning implementation

            // Simulating a delay of 3 seconds for the scan
            await Task.Delay(TimeSpan.FromSeconds(3));

            // Simulating a scan result
            bool isIPAddressFound = (ipAddress == "192.168.1.1");

            // Display the scan result
            await DisplayScanResult(isIPAddressFound);
        }

        private async Task DisplayScanResult(bool isIPAddressFound)
        {
            if (isIPAddressFound)
            {
                // Display a pop-up if the IP address is found
                await DisplayAlert("Scan Result", "IP address found!", "OK");
            }
            else
            {
                // Display a pop-up if the IP address is not found
                await DisplayAlert("Scan Result", "IP address not found!", "OK");
            }
        }


    }
}
