﻿using System;
using System.Collections.Generic;
using System.Text;
using Music.DataAccess.Entities.Interfaces;

namespace Music.DataAccess.Entities
{
    public class Track : IEntity
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
