using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;

namespace CrossProjek4.Services
{
    public class BleScanner
    {
        private readonly IBluetoothLE bluetoothLE;
        private readonly IAdapter adapter;

        public BleScanner()
        {
            bluetoothLE = CrossBluetoothLE.Current;
            adapter = bluetoothLE.Adapter;
        }

        public async Task<IEnumerable<string>> ScanForDevices()
        {
            try
            {
                var results = new List<string>();

                adapter.DeviceDiscovered += (s, args) =>
                {
                    // Add the device name to the results list
                    results.Add(args.Device.Name);
                };

                // Start scanning for BLE devices
                await adapter.StartScanningForDevicesAsync();
                await Task.Delay(TimeSpan.FromSeconds(10)); // Scan for 10 seconds

                // Stop scanning for BLE devices
                await adapter.StopScanningForDevicesAsync();

                return results;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during scanning
                Console.WriteLine($"Error scanning for BLE devices: {ex.Message}");
                return null;
            }
        }
    }
}
