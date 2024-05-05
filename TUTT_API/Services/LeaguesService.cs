using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using TUTT_API.Models;

namespace TUTT_API.Services
{
    public interface ILeaguesService
    {
        IList<LeaguesModel> GetAll(string? key, int start, int limit, string? sortField, out int total);
    }
    public class LeaguesService : ILeaguesService
    {
        MongoCollection<LeaguesModel> collection;
        MongoBase mongoBase;
        private readonly IConfiguration Configuration;

        public LeaguesService(IConfiguration _configuration)
        {
            Configuration = _configuration;
            mongoBase = new MongoBase(Configuration);
            MongoDatabase db = mongoBase.Db;

            if (!db.CollectionExists(Configuration["MongoCollection:leaguesclt"]))
            {
                db.CreateCollection(Configuration["MongoCollection:leaguesclt"]);
            }
            collection = db.GetCollection<LeaguesModel>(Configuration["MongoCollection:leaguesclt"]);

        }

        public IList<LeaguesModel> GetAll(string? key, int start, int limit, string? sortField, out int total)
        {
            var queries = new List<IMongoQuery>();
            if (!string.IsNullOrEmpty(key))
            {
                var query = Query.Or(

                                      Query.Or(
                                          Query<LeaguesModel>.Matches(e => e.league.name , new MongoDB.Bson.BsonRegularExpression("/.*" + key + ".*/i")),
                                          Query<LeaguesModel>.Matches(e => e.country.name, new MongoDB.Bson.BsonRegularExpression("/.*" + key + ".*/i"))
                                              )

                                       );
                queries.Add(query);
            }
           
            var finalQuery = queries.Count > 0 ? Query.And(queries) : Query.Null;
            total = (int)(collection.Count(finalQuery));
            if(!string.IsNullOrEmpty(sortField))
                return collection.Find(finalQuery).SetSortOrder(SortBy.Descending(sortField)).Skip(start).Take(limit).ToList();
            return collection.Find(finalQuery).OrderBy(o=>o.league.id).Skip(start).Take(limit).ToList();
        }
    }
}
