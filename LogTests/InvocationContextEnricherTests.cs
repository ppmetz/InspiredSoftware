using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using Serilog.Events;
using System.Diagnostics;
using static InspiredSoftware.SomeLog.InvocationContextExtensions;

namespace InspiredSoftware.Serilog2.Tests
{
    [TestClass()]
    public class InvocationContextEnricherTests
    {

        private static string logPath = nameof(InvocationContextEnricherTests) + ".log";
        private static string LogFullName => Path.GetFullPath(logPath);


        [TestMethod()]
        public void InvocationContextEnricherTest()
        {

            //MemberName, FilePath, FileName, LineNumber
            string outputTemplate = "{Timestamp:HH:mm:ss,fff} {Level:u3} {CallerFilePath} {NewLine}Type: {SourceContext}, Line: {CallerLineNumber} Method: {CallerMemberName}{NewLine}{Message:lj}{NewLine}{Exception}";

            Log.Logger = new LoggerConfiguration()
                                    .Enrich.FromLogContext()
                                    .WriteTo.File
                                        (
                                            path: LogFullName,
                                            restrictedToMinimumLevel: LogEventLevel.Verbose,
                                            outputTemplate: outputTemplate
                                        )
                                    .CreateLogger();

            ILogger logger = Serilog.Log.ForContext<InvocationContextEnricherTests>();

            logger.EnrichWithContext().Verbose("that's a message");
            logger.EnrichWithContext().Information("that's a message");
            logger.EnrichWithContext().Warning("that's a message");
            logger.EnrichWithContext().Error("that's a message");
            //logger.Verbose2("that's a message");

            Serilog.Log.CloseAndFlush();

            string? logRecords = File.ReadAllText(LogFullName);
            //Assert.IsFalse(string.IsNullOrWhiteSpace(logRecords));
            string Viewer = @"C:\Users\Peter\AppData\Local\Programs\Microsoft VS Code\Code.exe";
            Process.Start(Viewer, LogFullName);
        }

    }
}