using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Music.DataAccess.Entities.Interfaces;

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

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Surname")]
        public string Surname { get; set; }

        public string Fullname { get => Name + Surname; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ICollection<string> SongIds { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ICollection<string> AlbumIds { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string GroupId { get; set; }
    }
}
