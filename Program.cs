using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;


namespace ConsoleApp1
{
    class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement ("body")]
        public string Body { get; set; }
        [BsonElement("user")]
        public List<User> Users { get; set; }
        [BsonElement("tags")]
        public List<string> Tags { get; set; }
        [BsonElement("likes")]
        public int Like { get; set; }
        [BsonElement("comments")]
        public List<Comment> Comments { get; set; }
        [BsonElement("date")]
        public object PostCreateDate { get; set; }

    }
    class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("surname")]
        public string Surname { get; set; }
        [BsonElement("interests")]
        public List<string> Interest { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }

    }
    class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("body")]
        public string CommentBody { get; set; }
        [BsonElement("surname")]
        public string Surname { get; set; }
        [BsonElement("date")]
        public object PostCreateDate { get; set; }
    }
    class Program
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase database = client.GetDatabase("SocialNetwork");
        static IMongoCollection<Post> collection1 = database.GetCollection<Post>("posts");
        static IMongoCollection<User> collection2 = database.GetCollection<User>("users");

       

        static void Main(string[] args)
        {
            var documents = collection2.Find(new BsonDocument()).ToListAsync().Result;
            //var client = new MongoClient("mongodb://localhost:27017");
            //var database = client.GetDatabase("SocialNetwork");
            //IMongoCollection<BsonDocument> postsBsonCollection = database.GetCollection<BsonDocument>("posts");
            //var post = new Post();
            ReadAll();
            
        }
        public static void ReadAll()
        {
            List<Post> list = collection1.AsQueryable().ToList<Post>();
            var posts = from p in list select p;
            foreach (Post p in posts)
            {
                Console.WriteLine(p.Body);
            }
        }
    }
}
