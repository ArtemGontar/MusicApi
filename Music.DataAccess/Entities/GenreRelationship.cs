using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Music.DataAccess.Entities
{
    public class GenreRelationship
    {
        /// <summary>
        /// The data for the genre included in the relationship.
        /// </summary>
        [BsonElement("data")]
        [Required]
        public List<Genre> Data { get; set; }
    }
}