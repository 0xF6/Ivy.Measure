#r "nuget: Microsoft.Extensions.Logging.Console, 3.0.0"

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
var provider = new ServiceCollection() // todo: not working :(
        .AddLogging(x => x.AddConsole().SetMinimumLevel(LogLevel.Trace))
        .BuildServiceProvider();

void Info(object o)
    => Console.WriteLine($"[dotnet][info]: {o}");
void Error(object o)
    => Console.WriteLine($"[dotnet][error]: {o}");
void Warn(object o)
    => Console.WriteLine($"[dotnet][warn]: {o}");