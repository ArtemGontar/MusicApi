using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Music.DataAccess.Entities
{
    public class TrackRelationship
    {
        /// <summary>
        /// The data for the track included in the relationship.
        /// </summary>
        [BsonElement("data")]
        [Required]
        public List<Song> Data { get; set; }
    }
}