using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ConsumindoApi_MongoDB.Model
{
    /// <summary>
    /// Modelo responsável por fazer a interface direta com o Banco de Dados, representado uma Collection noSQL ou tabela SQL
    /// </summary>
    public class CatsImageDB
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Url { get; set; }
    }
}
