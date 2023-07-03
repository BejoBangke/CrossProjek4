namespace CrossProjek4.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            // Perform login validation
            if (ValidateLogin())
            {
                // Navigate to MainPage through AppShell
                App.Current.MainPage = new AppShell();
            }
            else
            {
                DisplayAlert("Login Failed", "Invalid username or password", "OK");
            }
        }

        private bool ValidateLogin()
        {
            // Perform login validation logic here
            // Return true if login is successful, false otherwise
            // You can check the entered username and password against your authentication system or hard-coded values for testing
            return (UsernameEntry.Text == "Admin" && PasswordEntry.Text == "password");
        }
        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            // Perform any necessary cleanup or reset app state

            // Navigate back to the LoginPage
            await Shell.Current.GoToAsync("//LoginPage");
        }

    }
}
