using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace TUTT_API.Models
{
    [DataContract]
    [BsonNoId]
    public class Country
    {
        public string name { get; set; }
        public string code { get; set; }
        public string flag { get; set; }
    }

    [DataContract]
    [BsonNoId]
    public class Coverage
    {
        public Fixtures fixtures { get; set; }
        public bool standings { get; set; }
        public bool players { get; set; }
        public bool top_scorers { get; set; }
        public bool top_assists { get; set; }
        public bool top_cards { get; set; }
        public bool injuries { get; set; }
        public bool predictions { get; set; }
        public bool odds { get; set; }
    }

    [DataContract]
    [BsonNoId]
    public class Fixtures
    {
        public bool events { get; set; }
        public bool lineups { get; set; }
        public bool statistics_fixtures { get; set; }
        public bool statistics_players { get; set; }
    }


    [DataContract]
    [BsonNoId]
    public class League
    {
        [DataMember]
        [BsonElement("id")]
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string logo { get; set; }
    }

    public class LeaguesModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public ObjectId _etag { get; set; }
        public Country country { get; set; }
        public League league { get; set; }
        public List<Season> seasons { get; set; }
        public bool isshow { get; set; }
    }

    [DataContract]
    [BsonNoId]
    public class Season
    {
        public int year { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public bool current { get; set; }
        public Coverage coverage { get; set; }
    }
}
