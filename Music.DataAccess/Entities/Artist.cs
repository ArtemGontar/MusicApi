using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Music.DataAccess.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace Music.DataAccess.Entities
{
    public class Artist : IEntity
    {
        public Artist()
        {
            SongIds = new List<string>();

            AlbumIds = new List<string>();
            
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        [BsonElement("nickname")]
        public string Nickname { get; set; }
        
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("surname")]
        public string Surname { get; set; }

        public string Fullname { get => Name + Surname; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ICollection<string> SongIds { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ICollection<string> AlbumIds { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string GroupId { get; set; }

        [BsonElement("mainGenre")]
        public string MainGenre { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime BirthDay { get; set; }
    }
}
