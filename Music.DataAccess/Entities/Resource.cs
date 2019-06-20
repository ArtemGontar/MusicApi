using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Music.DataAccess.Entities
{
    public class Resource
    {
        /// <summary>
        /// Persistent identifier of the resource.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// A URL subpath that fetches the resource as the primary object. This member is only present in responses.
        /// </summary>
        [BsonElement("href")]
        public string Href { get; set; }
    }
}
