using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Music.DataAccess.Entities
{
    public class AlbumRelationship
    {
        /// <summary>
        /// The data for the album included in the relationship.
        /// </summary>
        [BsonElement("data")]
        [Required]
        public List<Album> Data { get; set; }
    }
}