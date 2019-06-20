using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Music.DataAccess.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music.DataAccess.Entities
{
    public class Album : Resource, IEntity
    {
        public Album()
        {
        }
        
        /// <summary>
        /// The name of the album the music video appears on.
        /// </summary>
        [BsonElement("albumName")]
        [Required]
        public string AlbumName { get; set; }


        /// <summary>
        /// The artist’s name.
        /// </summary>
        [BsonElement("artistName")]
        [Required]
        public string ArtistName { get; set; }


        /// <summary>
        /// The album artwork.
        /// </summary>
        [BsonElement("artwork")]
        [Required]
        public Artwork Artwork { get; set; }

        /// <summary>
        /// The names of the genres associated with this album.
        /// </summary>
        [BsonElement("genreNames")]
        [Required]
        public List<string> GenreNames { get; set; }

        /// <summary>
        /// Indicates whether the album contains a single song.
        /// </summary>
        [BsonElement("isSingle")]
        [Required]
        public bool IsSingle { get; set; }

        /// <summary>
        /// The localized name of the album.
        /// </summary>
        [BsonElement("name")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The name of the record label for the album.
        /// </summary>
        [BsonElement("recordLabel")]
        [Required]
        public string RecordLabel { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// The number of tracks.
        /// </summary>
        [BsonElement("trackCount")]
        [Required]
        public string TrackCount { get; set; }

        /// <summary>
        /// The URL for sharing the album.
        /// </summary>
        [BsonElement("url")]
        [Required]
        public string Url { get; set; }

        /// <summary>
        /// This value will always be albums.
        /// </summary>
        [BsonElement("type")]
        [Required]
        public string Type { get; set; }

        #region Relationship

        /// <summary>
        /// The artists associated with the album. By default, artists includes identifiers only.
        /// </summary>
        [BsonElement("artists")]
        [Required]
        public ArtistRelationship Artists { get; set; }

        /// <summary>
        /// The genres for the album. By default, genres is not included.
        /// </summary>
        [BsonElement("genres")]
        [Required]
        public GenreRelationship Genres { get; set; }

        /// <summary>
        /// The songs and music videos on the album. By default, tracks includes objects.
        /// </summary>
        [BsonElement("tracks")]
        [Required]
        public TrackRelationship Tracks { get; set; }

        #endregion
    }
}
