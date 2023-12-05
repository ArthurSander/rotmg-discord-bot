using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RotmgDiscordBot.ConsoleWorker;
using RotmgDiscordBot.ConsoleWorker.IoC;
using RotmgDiscordBot.Infra.IoC.Domain;

var builder = Host.CreateApplicationBuilder(args);

var cts = new CancellationTokenSource();
Console.CancelKeyPress += (s, e) =>
{
    Console.WriteLine("Process exit requested: Safely exiting all processes...");
    cts.Cancel();
    e.Cancel = true;
};

builder.Services
    .ConfigureConsoleDependencies(cts.Token)
    .ConfigureDomainDependencies();

using var host = builder.Build();

var main = host.Services.GetRequiredService<Main>();



await main.RunAsync(cts.Token);

Console.WriteLine("Finished processing.");
