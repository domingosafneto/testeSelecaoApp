using AppContatos.Model;
using AppContatos.RestServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppContatos.View
{	
	public partial class ListaPessoas : ContentPage
	{        
        public ListaPessoas ()
		{
			InitializeComponent ();            
		}

        private void OnClickedListar(object sender, EventArgs e)
        {
            ListarPessoasAsync();
        }

        private async void ListarPessoasAsync()
        {
            
            try
            { 
                var services = new PessoaRest();
                List<Pessoa> pessoaList;

                pessoaList = await services.GetPessoas();

                if (pessoaList.Count() < 1)
                {
                    await DisplayAlert("Aviso", "Nenhuma pessoa encontrada", "OK");
                }
                else
                {
                   // pessoaList.OrderBy(p => p.Nome).ToList();
                    listView.ItemsSource = pessoaList; 
                }
            }
            catch(Exception e)
            {
                await DisplayAlert("Erro", e.Message, "OK");
            }
        }       
    }
}