﻿using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using Music.DataAccess.Entities;

namespace Music.BussinessLogic.Services.Interfaces
{
    public interface IArtistService : IService
    {
        IEnumerable<Artist> GetAll();

        Artist Get(ObjectId id);

        void Create(Artist artist);

        bool Update(ObjectId id, Artist artist);

        bool Delete(ObjectId id);
    }
}
