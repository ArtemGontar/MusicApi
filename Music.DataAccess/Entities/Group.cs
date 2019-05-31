using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using Music.DataAccess.Entities.Interfaces;

namespace Music.DataAccess.Entities
{
    public class Group : IEntity
    {
        public Group()
        {
            Members = new List<Artist>();
            Albums = new List<Album>();
            Songs = new List<Song>();
        }

        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public ICollection<Artist> Members { get; set; }

        public ICollection<Album> Albums { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
