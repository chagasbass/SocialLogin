using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using SocialLogin.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateDroid))]

namespace SocialLogin.Droid
{
    public class AuthenticateDroid : IAuthenticate
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
                return await client.LoginAsync(Xamarin.Forms.Forms.Context, provider);  
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}