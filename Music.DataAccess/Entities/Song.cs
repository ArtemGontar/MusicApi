using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Music.DataAccess.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music.DataAccess.Entities
{
    public class Song : Resource, IEntity
    {
        /// <summary>
        /// The name of the album the song appears on.
        /// </summary>
        [Required]
        [BsonElement("albumName")]
        public string AlbumName { get; set; }

        /// <summary>
        /// The artist’s name.
        /// </summary>
        [Required]
        [BsonElement("artistName")]
        public string ArtistName { get; set; }

        /// <summary>
        /// The album artwork.
        /// </summary>
        [BsonElement("artwork")]
        public Artwork Artwork { get; set; }

        /// <summary>
        /// The duration of the song in milliseconds.
        /// </summary>
        [Required]
        [BsonElement("durationInMillis")]
        public long DurationInMillis { get; set; }

        /// <summary>
        /// The genre names the song is associated with.
        /// </summary>
        [BsonElement("genreNames")]
        public List<string> GenreNames { get; set; }

        /// <summary>
        /// The localized name of the song.
        /// </summary>
        [BsonElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// The number of the song in the album’s track list.
        /// </summary>
        [BsonElement("trackNumber")]
        public int TrackNumber { get; set; }

        /// <summary>
        /// The URL for sharing a song
        /// </summary>
        [BsonElement("url")]
        public string Url { get; set; }

        /// <summary>
        /// The release date of the song in YYYY-MM-DD format.
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// This value will always be songs.
        /// </summary>
        [BsonElement("type")]
        public string Type { get; set; }

        #region Relationships

        /// <summary>
        /// The albums associated with the song. By default, albums includes identifiers only.
        /// </summary>
        [BsonElement("albums")]
        public AlbumRelationship Albums { get; set; }

        /// <summary>
        /// The artists associated with the song. By default, artists includes identifiers only.
        /// </summary>
        [BsonElement("artists")]
        public ArtistRelationship Artists { get; set; }

        /// <summary>
        /// The genres associated with the song. By default, genres is not included.
        /// </summary>
        [BsonElement("genres")]
        public GenreRelationship Genres { get; set; }
        
        #endregion
    }
}
