using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ThirdParty.Json.LitJson;

namespace MongoDBConnect.Models
{
    public class Username
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string user { get; set; } =  null!;
        public string address { get; set; }  =  null!;
        public string company { get; set; }  =  null!;
        public string userid { get; set; }  =  null!;

    }
}