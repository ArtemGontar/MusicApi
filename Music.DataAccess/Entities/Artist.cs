using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Music.DataAccess.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music.DataAccess.Entities
{
    public class Artist : IEntity
    {
        public Artist()
        {
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// The names of the genres associated with this artist.
        /// </summary>
        [BsonElement("genreNames")]
        [Required]
        public string GenreNames { get; set; }

        /// <summary>
        /// The localized name of the artist.
        /// </summary>
        [BsonElement("name")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The URL for sharing an artist
        /// </summary>
        [BsonElement("url")]
        [Required]
        public string Url { get; set; }

        /// <summary>
        /// This value will always be artists.
        /// </summary>
        [BsonElement("type")]
        [Required]
        public string Type { get; set; }

        #region Relationship

        /// <summary>
        /// The albums associated with the artist. By default, albums includes identifiers only.
        /// </summary>
        [BsonElement("albums")]
        [Required]
        public string Albums { get; set; }

        /// <summary>
        /// The genres associated with the artist. By default, genres is not included.
        /// </summary>
        [BsonElement("genres")]
        [Required]
        public string Genres { get; set; }

        #endregion

    }
}
