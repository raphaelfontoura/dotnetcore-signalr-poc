using Microsoft.AspNetCore.SignalR.Client;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var uri = "http://localhost:5229/chat";

await using var connection = new HubConnectionBuilder()
    .WithUrl(uri)
    .Build();

await connection.StartAsync();

await foreach (var date in connection.StreamAsync<DateTime>("Streaming"))
{
    Console.WriteLine(date);
}