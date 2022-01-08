using Cotacao.Domain.Cotacao;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cotacao.Domain.Shared
{
    public class FuncoesWeb
    {
        public static async Task<EnderecoModel> GetEnderecoWeb(string cep)
        {
            try
            {
                string url = string.Format("https://viacep.com.br/ws/{0}/json/", cep);

                var client = new HttpClient();
                var response = await client.GetAsync(url).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    {
                        string dados = await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false);
                        var result = JsonConvert.DeserializeObject<EnderecoModel>(dados);
                        return result;
                    }
                }
            }
            catch (Exception)
            {
            }

            return new EnderecoModel();
        }
    }
}
