var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.FunctionApp101>("functionapp101");

builder.Build().Run();
