using Finger;

System.Console.Write("What is your status: ");

string? status = Console.ReadLine();

// Type identifier = new Constructor
if (status != null) {
    StatusMessage myStatus = new StatusMessage(status, DateTimeOffset.Now);
    Console.WriteLine($"You said your status was {myStatus.Status} at {myStatus.When:T}");
}
else {
    Console.WriteLine("Sorry, cannot have a null status");
}