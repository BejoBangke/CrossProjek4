using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System.Collections.ObjectModel;

namespace CrossProjek4.Views
{
    public partial class Connection : ContentPage
    {
        private readonly ObservableCollection<string> devicesList;
        private IBluetoothLE bluetoothLE;
        private IAdapter adapter;

        public Connection()
        {
            InitializeComponent();
            devicesList = new ObservableCollection<string>();
            DevicesListView.ItemsSource = devicesList;

            bluetoothLE = CrossBluetoothLE.Current;
            adapter = bluetoothLE.Adapter;
        }

        private async void OnSearchBLEClicked(object sender, EventArgs e)
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
            {
                var requestStatus = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                if (requestStatus != PermissionStatus.Granted)
                {
                    await DisplayAlert("Error", "Permission denied for Bluetooth", "OK");
                    return;
                }
            }

            devicesList.Clear();

            // Start scanning for BLE devices
            await ScanForDevices();

            if (devicesList.Count == 0)
            {
                await DisplayAlert("No Devices", "No BLE devices found nearby.", "OK");
            }
        }

        private async Task ScanForDevices()
        {
            adapter.DeviceDiscovered += (s, args) =>
            {
                // Add the device name to the results list
                devicesList.Add(args.Device.Name);
            };

            // Start scanning for BLE devices
            await adapter.StartScanningForDevicesAsync();
            await Task.Delay(TimeSpan.FromSeconds(3)); // Scan for 3 seconds

            // Stop scanning for BLE devices
            await adapter.StopScanningForDevicesAsync();
        }

    }
}
