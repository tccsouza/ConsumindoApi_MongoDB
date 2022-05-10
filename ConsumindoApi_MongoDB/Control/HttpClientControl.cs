using ConsumindoApi_MongoDB.Model;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.WebUtilities;

namespace ConsumindoApi_MongoDB.Control
{
    /// <summary>
    /// Classe responsável pela interface com API, realizando os métodos de busca.
    /// </summary>
    public class HttpClientControl
    {
        private const int SunglassesId = 4;
        private const int HatId = 1;

        private HttpClient _httpClient;

        private IEnumerable<Cat> _cats;

        private IEnumerable<CatsImage> _catsImages;
        public IEnumerable<Cat> Cats { get => _cats; private set => _cats = value; }
        public IEnumerable<CatsImage> CatsImages { get => _catsImages; set => _catsImages = value; }

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="baseAddress">Endereço onde a Api está expondo o serviço.</param>
        /// <param name="mediaType">Formato em que os dados serão enviado.</param>
        /// <param name="scheme">Chave para autenticação</param>
        /// <param name="parameter">Valor da chave para autenticação na Api.</param>
        public HttpClientControl(string baseAddress, string mediaType, string scheme, string parameter)
        {
            _cats = new List<Cat>();
            _catsImages = new List<CatsImage>();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, parameter);


        }

        /// <summary>
        /// Método para retornar todos os gatos
        /// </summary>
        /// <param name="resquestURI">Endereço onde a informçao será consumida</param>
        /// <returns></returns>
        public async Task GetAllCats(string resquestURI)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(resquestURI);

                if (response.IsSuccessStatusCode)
                {  //GET
                    Cats = await response.Content.ReadAsAsync<IEnumerable<Cat>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Método responsável por retornar as 3 imagens de acordo com o Gato.
        /// </summary>
        /// <param name="requestURI">Endereço onde a informação será consumida.</param>
        /// <param name="cat">Gato referencia para busca das imagens</param>
        /// <returns></returns>
        public async Task GetImageCats(string requestURI, Cat cat)
        {

            var query = new Dictionary<string, string>()
            {
                ["breed_id"] = cat.id,
                ["limit"] = "3"
            };

            requestURI = QueryHelpers.AddQueryString(requestURI, query);

            HttpResponseMessage response = await _httpClient.GetAsync(requestURI);

            if (response.IsSuccessStatusCode)
            {
                CatsImages = await response.Content.ReadAsAsync<IEnumerable<CatsImage>>();
            }
        }

        /// <summary>
        /// Método responsável por retornar 3 imagens de gatos com Óculos de sol.
        /// </summary>
        /// <param name="requestURI">Endereço onde a informação será consumida.</param>
        /// <returns></returns>
        public async Task GetImageSunglasses(string requestURI)
        {
            var query = new Dictionary<string, string>()
            {
                ["category_ids"] = SunglassesId.ToString(),
                ["limit"] = "3"
            };

            requestURI = QueryHelpers.AddQueryString(requestURI, query);

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(requestURI);

                if (response.IsSuccessStatusCode)
                {
                    CatsImages = await response.Content.ReadAsAsync<IEnumerable<CatsImage>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Método responsável por retornar 3 imagens de gatos com chapéus.
        /// </summary>
        /// <param name="requestURI"></param>
        /// <returns></returns>
        public async Task GetImageHats(string requestURI)
        {
            var query = new Dictionary<string, string>()
            {
                ["category_ids"] = HatId.ToString(),
                ["limit"] = "3"
            };

            requestURI = QueryHelpers.AddQueryString(requestURI, query);

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(requestURI);

                if (response.IsSuccessStatusCode)
                {
                    CatsImages = await response.Content.ReadAsAsync<IEnumerable<CatsImage>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }
    }
}
