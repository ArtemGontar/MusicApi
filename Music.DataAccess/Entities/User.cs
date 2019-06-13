using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Music.DataAccess.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Music.DataAccess.Entities
{
    public class User : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public string CreditCard { get; set; }

        public DateTime RegisterDate { get; set; }

        [Required]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime BirthDay { get; set; }
        
    }
}
