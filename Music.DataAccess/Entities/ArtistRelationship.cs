using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Music.DataAccess.Entities
{
    public class ArtistRelationship
    {
        /// <summary>
        /// The data for the artist included in the relationship.
        /// </summary>
        [BsonElement("data")]
        [Required]
        public List<Artist> Data { get; set; }
    }
}