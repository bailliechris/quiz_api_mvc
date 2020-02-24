using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace quiz_api_mvc.Models
{
    public class AScore
    {
        //  [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        //  [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public ObjectId Id { get; set; }
        public string topic { get; set; }
        public string index { get; set; }
        public string name { get; set; }
        public int score { get; set; }
        public int max { get; set; }
        public string time { get; set; }
    }
}
