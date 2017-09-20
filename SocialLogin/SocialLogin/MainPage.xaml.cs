using Xamarin.Forms;

namespace SocialLogin
{
    public partial class MainPage : ContentPage
    {
        readonly AzureService azureService = new AzureService();

        public MainPage()
        {
            InitializeComponent();

            LoginButton.Clicked += async (sender, args) =>
            {
                var user = await azureService.LoginAsync();
                InfoLabel.Text = (user != null) ? $"Bem Vindo:{user.UserId}" : "Falha no longin";
            };
        }
    }
}
