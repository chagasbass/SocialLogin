using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialLogin
{
    public class AzureService
    {
        static readonly string AppURL = "https://catsapppedro.azurewebsites.net";

        public MobileServiceClient Client { get; set; } = null;
        
        public void Initialize()
        {
            Client = new MobileServiceClient(AppURL);
        }

        public async Task<MobileServiceUser> LoginAsync()
        {
            Initialize();
            var auth = DependencyService.Get<IAuthenticate>();
            var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);

            if(user == null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Erro!", "Não foi possível efetuar login", "Ok");
                });
                return null;
            }
            return user;
        }
    }
}
