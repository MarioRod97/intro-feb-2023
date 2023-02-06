using Finger;

var Builder = WebApplication.CreateBuilder(args);

var app = Builder.Build();

app.MapGet("/status", () =>{
    var status = new StatusMessage("All is good!", DateTimeOffset.Now);
    return status;
});

app.MapPost("/status", (StatusRequest req) =>{
    return req;
});

app.Run();

public record StatusRequest(string Message);