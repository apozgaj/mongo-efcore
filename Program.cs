// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using mongo;
using MongoDB.Driver;

var connectionString = "";

var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));

settings.ServerApi = new ServerApi(ServerApiVersion.V1);

var client = new MongoClient(settings);

var db = new MovieDbContext(new DbContextOptionsBuilder<MovieDbContext>().UseMongoDB(client, "sample_mflix").Options);

var movie = await db.Movies.FirstOrDefaultAsync(m => m.title == "In the Land of the Head Hunters");

if(movie is null) {
    Console.WriteLine("No movie found");
    return;
}

Console.WriteLine(movie.title);