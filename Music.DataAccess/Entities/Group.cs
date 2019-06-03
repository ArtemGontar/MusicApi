using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Music.DataAccess.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music.DataAccess.Entities
{
    public class Group : IEntity
    {
        public Group()
        {
            MemberIds = new List<string>();
            AlbumIds = new List<string>();
            SongIds = new List<string>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonElement("groupName")]
        public string GroupName { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ICollection<string> MemberIds { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ICollection<string> AlbumIds { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ICollection<string> SongIds { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreationDate { get; set; }

        [BsonElement("mainGenre")]
        public string MainGenre { get; set; }
    }
}
