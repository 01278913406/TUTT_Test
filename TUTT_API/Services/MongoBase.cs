using MongoDB.Driver;

namespace TUTT_API.Services
{
    public class MongoBase
    {
        private readonly IConfiguration Configuration;

        public MongoClient client;
        public MongoServer server;
        private MongoDatabase db;

        public MongoDatabase Db
        {
            get { return db; }
            set { db = value; }
        }
        public MongoBase(IConfiguration configuration)
        {
            Configuration = configuration;
            client = new MongoClient(Configuration["MongoConnectString"].ToString());
            server = client.GetServer();
            if (server.State == MongoServerState.Disconnected)
            {
                server.Connect();
            }
            db = server.GetDatabase("Cms_Live_Score");
        }
    }
}
