using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace Music.DataAccess.Entities.Interfaces
{
    public interface IEntity
    {
        ObjectId Id { get; set; }
    }
}
