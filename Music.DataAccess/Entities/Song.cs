﻿using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Music.DataAccess.Entities.Interfaces;

namespace Music.DataAccess.Entities
{
    public class Song : IEntity
    {

        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("BookName")]
        public Artist Artist { get; set; }

        [BsonElement("BookName")]
        public Group Group { get; set; }

        [BsonElement("BookName")]
        public Album Album { get; set; }
    }
}
