using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppContatos.View
{	
	public partial class Inicio : ContentPage
	{
        public string textoIp;

		public Inicio ()
		{
			InitializeComponent ();
		}

        private async void ListaPessoasOnClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(edtIpServico.Text))
            {                
                await Navigation.PushModalAsync(new ListaPessoas());                
                Global.webServiceUrl = "http://" + (edtIpServico.Text).Trim() + ":3000/";
            }
            else
            {
                await DisplayAlert("Atenção", "Preencher o Ip do Serviço", "OK");
                edtIpServico.Focus();
            }
        }
    }

    
}