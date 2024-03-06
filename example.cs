using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SPODDataController : ControllerBase
    {
        private readonly IMongoCollection<YourSPODDataModel> _spodDataCollection;

        public SPODDataController(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("YourDatabaseName");
            _spodDataCollection = database.GetCollection<YourSPODDataModel>("YourCollectionName");
        }

        [HttpGet("available-dates")]
        public async Task<ActionResult<IEnumerable<object>>> GetSPODDataAvailableDates(int deviceId, string requestedTimezone)
        {
            try
            {
                var pipeline = new[]
                {
                    PipelineStageDefinitionBuilder.Match<YourSPODDataModel>(Builders<YourSPODDataModel>.Filter.Eq("id", deviceId)),
                    PipelineStageDefinitionBuilder.Group(
                        new BsonDocument
                        {
                            { "_id", new BsonDocument
                                {
                                    { "month", new BsonDocument("$month", new BsonDocument("date", "$date").Add("timezone", requestedTimezone)) },
                                    { "day", new BsonDocument("$dayOfMonth", new BsonDocument("date", "$date").Add("timezone", requestedTimezone))) },
                                    { "year", new BsonDocument("$year", new BsonDocument("date", "$date").Add("timezone", requestedTimezone))) }
                                }
                            },
                            { "count", new BsonDocument("$sum", 1) },
                            { "date", new BsonDocument("$max", "$date") }
                        }
                    ),
                    PipelineStageDefinitionBuilder.Sort(new BsonDocument("date", 1))
                };

                var logs = await _spodDataCollection.AggregateAsync<object>(pipeline);
                return Ok(logs.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
