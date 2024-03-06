using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<YourSPODDataModel>>> GetSPODDataAvailableDates(int deviceId, string requestedTimezone)
        {
            try
            {
                var pipeline = new BsonDocument[]
                {
                    BsonDocument.Parse("{ $match: { id: " + deviceId + " } }"),
                    BsonDocument.Parse("{ $group: { _id: { month: { $month: { date: '$date', timezone: '" + requestedTimezone + "' } }, day: { $dayOfMonth: { date: '$date', timezone: '" + requestedTimezone + "' } }, year: { $year: { date: '$date', timezone: '" + requestedTimezone + "' } } }, count: { $sum: 1 }, date: { $max: '$date' } } }"),
                    BsonDocument.Parse("{ $sort: { date: 1 } }")
                };

                var logs = await _spodDataCollection.AggregateAsync<YourSPODDataModel>(pipeline);
                return Ok(logs.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
