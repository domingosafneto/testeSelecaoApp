using AppContatos.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppContatos.RestServices
{
    public class PessoaRest
    {
        private HttpClient client;
        private List<Pessoa> pessoas;

        public PessoaRest()
        {
            client = new HttpClient();
        }

        public async Task<List<Pessoa>> GetPessoas()
        {
            var uri = new Uri(string.Format(Global.webServiceUrl + "api/Pessoas"));

            try
            {
                var response = await client.GetAsync(uri);

                string resposta = response.StatusCode.ToString();

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    // Desserializa a resposta do serviço
                    pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(content);

                    return pessoas.OrderBy(p => p.Nome).ToList();
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Erro", e.Message, "OK");
            }

            return null;
        }
    }
}
