using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RotmgDiscordBot.ConsoleWorker;
using RotmgDiscordBot.ConsoleWorker.IoC;
using RotmgDiscordBot.Infra.IoC.Domain;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .ConfigureConsoleDependencies()
    .ConfigureDomainDependencies();

using var host = builder.Build();

var main = host.Services.GetRequiredService<Main>();

await main.RunAsync();

Console.WriteLine("Finished processing.");
