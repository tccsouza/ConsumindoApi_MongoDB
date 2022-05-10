using ConsumindoApi_MongoDB.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumindoApi_MongoDB.Control
{
    /// <summary>
    /// Classe responsável pela interface com o banco de dados, realizando a persistencia dos dados.
    /// </summary>
    public class MongoDBControl
    {

        string DataBaseName = "CatsDB";
        string conexaoMongoDB = "mongodb://localhost:27017";
        IMongoDatabase database;
        IEnumerable<CatsDB> catsDBs;

        /// <summary>
        /// Construtor da Classe.
        /// </summary>
        public MongoDBControl()
        {
            var client = new MongoClient(conexaoMongoDB);
            database = client.GetDatabase(DataBaseName);
            catsDBs = new List<CatsDB>();
        }

        /// <summary>
        /// Metódo responsavel pela inserção dos dados dos gatos e suas respectivas imagens.
        /// </summary>
        /// <param name="cat">Gato a ser inserido no banco.</param>
        /// <param name="catsImages">Imagens relativa ao gato.</param>
        public void InsertCollection(Cat cat, IEnumerable<CatsImage> catsImages)
        {
            CatsDB catdb = new CatsDB()
            {
                Name = cat.name,
                Origin = cat.origin,
                Temperament = cat.temperament,
                Description = "Teste",
            };

            foreach (var c in catsImages)
            {
                catdb.Image += c.Url + " ";
            }
            try
            {
                var collection = database.GetCollection<CatsDB>("Cats");
                collection.InsertOne(catdb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Método responsavel por inserir as imagens dos gatos de acordo com a categoria.
        /// </summary>
        /// <param name="catsImages">Imagens dos gatos</param>
        /// <param name="type">Categoria das imagens ex. gato com chapéu.</param>
        public void InsertCollection(IEnumerable<CatsImage> catsImages,string type)
        {
            var collection = database.GetCollection<CatsImageDB>("CatsImages" + type);
            try
            {
                foreach (var c in catsImages)
                {
                    CatsImageDB catimagesdb = new CatsImageDB();
                    catimagesdb.Name = c.Id;
                    catimagesdb.Url += c.Url;
                    collection.InsertOne(catimagesdb);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
