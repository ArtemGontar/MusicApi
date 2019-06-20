using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Music.DataAccess.Entities
{
    public class Genre
    {

        /// <summary>
        /// The localized name of the genre.
        /// </summary>
        [BsonElement("name")]
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// This value will always be genres.
        /// </summary>
        [BsonElement("type")]
        [Required]
        public string Type { get; set; }
    }
}