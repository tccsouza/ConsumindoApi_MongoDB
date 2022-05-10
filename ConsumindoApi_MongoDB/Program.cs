using ConsumindoApi_MongoDB.Control;
using ConsumindoApi_MongoDB.Model;
using System.Net.Http.Headers;

namespace ConsumindoApi_MongoDB
{
    /// <summary>
    /// Classe responsável pela execução da aplicação.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Método Main para realizar a execução da aplicação.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MongoDBControl mongoDBControlCats = new MongoDBControl();
            HttpClientControl HttpClientControlCats = new HttpClientControl("https://api.thecatapi.com/v1", "application/json", "x-api-key", "bea0f365 - 2a82 - 4c9a - ad8d - bf44168543f0");
            HttpClientControlCats.GetAllCats("https://api.thecatapi.com/v1/breeds").Wait();

            foreach (var cat in HttpClientControlCats.Cats)
            {
                HttpClientControlCats.GetImageCats("https://api.thecatapi.com/v1/images/search", cat).Wait();

                mongoDBControlCats.InsertCollection(cat, HttpClientControlCats.CatsImages);
            }

            HttpClientControlCats.GetImageSunglasses("https://api.thecatapi.com/v1/images/search").Wait();
            mongoDBControlCats.InsertCollection(HttpClientControlCats.CatsImages, "Sunglasses");
            HttpClientControlCats.GetImageHats("https://api.thecatapi.com/v1/images/search").Wait();
            mongoDBControlCats.InsertCollection(HttpClientControlCats.CatsImages, "Hats");
        }
    }
}