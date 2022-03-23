using AndroitiTask;
using AndroitiTask.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.ConfigureServices();

var serviceProvider = services.BuildServiceProvider();

var executor = serviceProvider.GetRequiredService<OutputService>();

executor.PrintCharCount();