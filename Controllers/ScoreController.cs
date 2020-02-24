using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using quiz_api_mvc.Models;


namespace quiz_api_mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ScoreController : ControllerBase
    {
        // GET: api/Score
        [HttpGet]
        public IEnumerable<AScore> Get()
        {
            //Connect to DB
            var db = new MongoClient("mongodb+srv://posts_user:adminp@learningcluster-5qutw.azure.mongodb.net/test?retryWrites=true&w=majority");

            //Connect to a Database and a specific table
            var collection = db.GetDatabase("keyword-quiz").GetCollection<AScore>("quiz-scores");

            //Create a filter to create filters from
            var builder = Builders<AScore>.Filter;

            //Create an empty filter (for finding ALL elements)
            var empty = builder.Empty;

            //Get all elements matching the filter (all in this case)
            var all = collection.Find(empty);

            List<AScore> scores = all.ToList();

            return scores;
        }

        // GET: api/Score/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Score
        [HttpPost]
        public IEnumerable<AScore> Post([FromBody] Filter value)
        {
            //Connect to DB
            var db = new MongoClient("mongodb+srv://posts_user:adminp@learningcluster-5qutw.azure.mongodb.net/test?retryWrites=true&w=majority");

            //Connect to a Database and a specific table
            var collection = db.GetDatabase("keyword-quiz").GetCollection<AScore>("quiz-scores");

            var topicFilter = Builders<AScore>.Filter.Eq("topic", value.topic);
            var nameFilter = Builders<AScore>.Filter.Eq("name", value.name);

            //Create filter to delete by index
            if (value.topic != "All" && value.name != "All")
            {
                var findFilter = Builders<AScore>.Filter.And(topicFilter, nameFilter);
                var result = collection.Find(findFilter);

                List<AScore> scores = result.ToList();

                return scores;

            }
            else if (value.topic != "All")
            {
                var result = collection.Find(topicFilter);

                List<AScore> scores = result.ToList();

                return scores;
            }
            else
            {
                var result = collection.Find(nameFilter);

                List<AScore> scores = result.ToList();

                return scores;
            }
        }

        // PUT: api/Score/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            //Connect to DB
            var db = new MongoClient("mongodb+srv://posts_user:adminp@learningcluster-5qutw.azure.mongodb.net/test?retryWrites=true&w=majority");

            //Connect to a Database and a specific table
            var collection = db.GetDatabase("keyword-quiz").GetCollection<AScore>("quiz-scores");

            //Create filter to delete by index
            var deleteFilter = Builders<AScore>.Filter.Eq("index", id);

            collection.DeleteOne(deleteFilter);

            return "Success";
        }
    }
}
