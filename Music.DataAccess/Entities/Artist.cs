﻿using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using Music.DataAccess.Entities.Interfaces;

namespace Music.DataAccess.Entities
{
    public class Artist : IEntity
    {
        public Artist()
        {
            Songs = new List<Song>();

            Albums = new List<Album>();
            
        }

        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Fullname { get => Name + Surname; }

        public ICollection<Song> Songs { get; set; }

        public ICollection<Album> Albums { get; set; }

        public Group Group { get; set; }
    }
}
