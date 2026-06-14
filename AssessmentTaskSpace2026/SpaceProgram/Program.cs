namespace SpaceProgram;

using Utilities;
using Utilities.Interfaces;
using Factories;
using Factories.Interfaces;
using Algorithms.Helpers;
using Algorithms.Helpers.Interfaces;
using Algorithms;
using Algorithms.Interfaces;
using Services.Interfaces;
using Services;
using Rendering.Interfaces;
using Rendering;
using IO.Interfaces;
using IO;
using Core.Interfaces;
using Core;

public class Program
{
    public static async Task Main()
    {
        IRandomGenerator randomGenerator = new RandomGenerator();
        ISpaceObjectFactory factory = new SpaceObjectFactory();
        IMapGenerator mapGenerator = new RandomMapGenerator(randomGenerator, factory);

        IStringAppender appender = new StringAppender();
        IMapRenderer renderer = new TextMapRenderer(appender);

        IPathResultBuilder builder = new PathResultBuilder();
        IPathFinder dijkstra = new DijkstraPathFinder(builder);
        IPathFinder bfs = new BfsPathFinder(builder);
        
        IMissionService service = new MissionService(dijkstra);
        
        IWriter writer = new ConsoleWriter();
        IReader reader = new ConsoleReader();
        
        IConsoleKey consoleKey = new ConsoleKey();
        IAmbience ambience = new Ambience();

        IEmailSender emailSender = new EmailSender();
        
        IEngine engine = new Engine(writer, reader, mapGenerator, service, renderer, consoleKey, ambience, emailSender);
        await engine.RunAsync();
    }
}
