using Microsoft.WindowsAzure.MobileServices;
using SocialLogin.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateUWP))]
namespace SocialLogin.UWP
{
    public class AuthenticateUWP :IAuthenticate
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
                var user = await client.LoginAsync(provider);
                return user;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
