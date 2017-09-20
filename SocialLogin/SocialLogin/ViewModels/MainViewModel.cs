using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialLogin.ViewModels
{
   public class MainViewModel : BaseViewModel
    {

        readonly AzureService azureService = new AzureService();

        public Command LoginCommand { get; }
        private string _label;

        public string Label
        {
            get { return _label; }
            set { _label = value; OnPropertyChanged(); }
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value;OnPropertyChanged(); LoginCommand.ChangeCanExecute(); }
        }


        public MainViewModel()
        {
            LoginCommand = new Command(async ()=> await ExecuteLoginCommand(), ()=>!IsBusy);
        }

       async Task ExecuteLoginCommand()
       {

            if(!IsBusy)
            {
                Exception Error = null;
                try
                {
                    IsBusy = true;
                    var user = await azureService.LoginAsync();
                    Label = (user != null) ? $"Bem Vindo:{user.UserId}" : "Falha no longin";
                }
                catch (Exception ex)
                {

                    Error = ex;
                }

                finally
                {
                    IsBusy = false;
                }

                if (Error != null)
                    await App.Current.MainPage.DisplayAlert("Erro!", Error.Message, "Ok");
            }
            return;
          
       }
   }
}
