using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using Music.DataAccess.Entities.Interfaces;

namespace Music.DataAccess.Entities
{
    public class Album : IEntity
    {
        public Album()
        {
            Songs = new List<Song>();
        }

        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public Artist Artist { get; set; }

        public Group Group { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
