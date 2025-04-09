// Updated sample based on https://github.com/modelcontextprotocol/csharp-sdk/tree/main/samples
// This sample combines patterns from QuickstartWeatherServer and other examples in the repository
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mcp;
using Mcp.Server;
using Mcp.Server.Transport;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace MCP.Samples.CSharp
{
    /// <summary>
    /// Sample implementation of a Model Context Protocol (MCP) server in C#
    /// Demonstrates basic setup and tool registration following the official SDK patterns from the
    /// official ModelContextProtocol C# SDK: https://github.com/modelcontextprotocol/csharp-sdk
    /// </summary>
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Create the host application builder - standard pattern for .NET apps
            var builder = Host.CreateApplicationBuilder(args);

            // Configure the MCP server with tools from the official SDK
            builder.Services.AddMcpServer(options =>
            {
                // Optional: Configure server options
                options.DefaultFunctionOptionsBuilder = builder => builder.WithTimeout(TimeSpan.FromSeconds(30));
            })
            .WithStdioServerTransport()
            .WithHttpServerTransport(options => 
            {
                // Example: Configure HTTP transport options
                options.Port = 5000;
                options.Path = "/mcp";
            })
            .WithTools<WeatherTools>() // Register weather tools
            .WithTools<AdditionalTools>(); // Example of registering another tool class

            // Add logging to standard error for debugging
            builder.Logging.AddConsole(options =>
            {
                options.LogToStandardErrorThreshold = LogLevel.Trace;
            });

            Console.WriteLine("Starting MCP server...");
            Console.WriteLine("HTTP server available at http://localhost:5000/mcp");
            Console.WriteLine("Press Ctrl+C to exit");

            // Run the application
            await builder.Build().RunAsync();
        }
    }

    /// <summary>
    /// Sample weather tools implementation following the official C# SDK patterns
    /// Reference: https://github.com/modelcontextprotocol/csharp-sdk/tree/main/samples/QuickstartWeatherServer
    /// </summary>
    public class WeatherTools
    {
        private readonly ILogger<WeatherTools> _logger;

        public WeatherTools(ILogger<WeatherTools> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the current weather for a given location
        /// </summary>
        /// <param name="location">The location to get weather for</param>
        /// <returns>The weather information</returns>
        [McpTool("getCurrentWeather", "Gets the current weather for a location")]
        public async Task<WeatherResult> GetCurrentWeatherAsync(
            [McpParameter(Description = "The location to get weather for")] string location)
        {
            _logger.LogInformation($"Getting weather for {location}");

            // Simulate API call delay
            await Task.Delay(500);
            
            // Return mock weather data
            return new WeatherResult
            {
                Location = location,
                Temperature = new Random().Next(0, 35),
                Condition = GetRandomWeatherCondition(),
                Timestamp = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Gets the weather forecast for a given location
        /// </summary>
        /// <param name="location">The location to get forecast for</param>
        /// <param name="days">Number of days to forecast (1-7)</param>
        /// <returns>The weather forecast information</returns>
        [McpTool("getWeatherForecast", "Gets a weather forecast for a location")]
        public async Task<WeatherForecast> GetWeatherForecastAsync(
            [McpParameter(Description = "The location to get forecast for")] string location,
            [McpParameter(Description = "Number of days to forecast (1-7)")] int days)
        {
            _logger.LogInformation($"Getting {days}-day forecast for {location}");

            if (days < 1 || days > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(days), "Days must be between 1 and 7");
            }

            // Simulate API call delay
            await Task.Delay(500);
            
            // Generate mock forecast data
            var forecast = new WeatherForecast
            {
                Location = location,
                Days = new WeatherDay[days]
            };

            var random = new Random();

            for (int i = 0; i < days; i++)
            {
                forecast.Days[i] = new WeatherDay
                {
                    Date = DateTime.UtcNow.AddDays(i + 1),
                    HighTemperature = random.Next(10, 38),
                    LowTemperature = random.Next(-5, 15),
                    Condition = GetRandomWeatherCondition()
                };
            }

            return forecast;
        }

        private static string GetRandomWeatherCondition()
        {
            string[] conditions = { "Sunny", "Partly Cloudy", "Cloudy", "Rainy", "Thunderstorms", "Snowy", "Foggy" };
            return conditions[new Random().Next(conditions.Length)];
        }
    }

    /// <summary>
    /// Additional tools example showing how to implement more complex MCP tools
    /// Based on patterns from various samples in the C# SDK repository
    /// </summary>
    public class AdditionalTools
    {
        private readonly ILogger<AdditionalTools> _logger;

        public AdditionalTools(ILogger<AdditionalTools> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Example of a tool that accepts a complex object as input
        /// </summary>
        [McpTool("searchDatabase", "Search a database with filters")]
        public async Task<SearchResult> SearchDatabaseAsync(
            [McpParameter(Description = "Search query")] string query,
            [McpParameter(Description = "Database to search", Schema = @"{""type"":""string"",""enum"":[""products"",""customers"",""orders""]}")] 
            string database,
            [McpParameter(Description = "Maximum results to return", IsOptional = true)] 
            int? maxResults = 10)
        {
            _logger.LogInformation($"Searching {database} database for: {query}");

            // Simulate API call delay
            await Task.Delay(500);
            
            // Return mock search results
            var result = new SearchResult
            {
                Query = query,
                Database = database,
                ResultCount = new Random().Next(0, maxResults ?? 10),
                SearchTime = new Random().NextDouble()
            };

            // Add some mock results
            result.Results = new object[result.ResultCount];
            for (int i = 0; i < result.ResultCount; i++)
            {
                result.Results[i] = database switch
                {
                    "products" => new { Id = i, Name = $"Product {i}", Price = new Random().Next(10, 1000) },
                    "customers" => new { Id = i, Name = $"Customer {i}", Email = $"customer{i}@example.com" },
                    "orders" => new { Id = i, CustomerId = new Random().Next(1, 100), Amount = new Random().Next(100, 10000) },
                    _ => new { Id = i, Name = $"Unknown {i}" }
                };
            }

            return result;
        }

        /// <summary>
        /// Example of a streaming tool that returns a stream of results
        /// </summary>
        [McpTool("generateReport", "Generate a report with streaming updates")]
        public async IAsyncEnumerable<ReportUpdate> GenerateReportAsync(
            [McpParameter(Description = "Report type")] string reportType,
            [McpParameter(Description = "Number of sections to generate")] int sections)
        {
            _logger.LogInformation($"Starting generation of {reportType} report with {sections} sections");

            for (int i = 0; i < sections; i++)
            {
                // Simulate processing time
                await Task.Delay(300);
                
                yield return new ReportUpdate
                {
                    SectionNumber = i + 1,
                    SectionName = $"Section {i + 1}",
                    PercentComplete = (i + 1) * 100 / sections,
                    Message = $"Completed processing section {i + 1} of {sections}"
                };
            }

            _logger.LogInformation("Report generation complete");
        }
    }

    #region Model Classes

    /// <summary>
    /// Represents a current weather reading result
    /// </summary>
    public class WeatherResult
    {
        public string Location { get; set; }
        public double Temperature { get; set; }
        public string Condition { get; set; }
        public DateTime Timestamp { get; set; }
    }

    /// <summary>
    /// Represents a weather forecast for multiple days
    /// </summary>
    public class WeatherForecast
    {
        public string Location { get; set; }
        public WeatherDay[] Days { get; set; }
    }

    /// <summary>
    /// Represents weather conditions for a single day
    /// </summary>
    public class WeatherDay
    {
        public DateTime Date { get; set; }
        public double HighTemperature { get; set; }
        public double LowTemperature { get; set; }
        public string Condition { get; set; }
    }

    /// <summary>
    /// Represents a database search result
    /// </summary>
    public class SearchResult
    {
        public string Query { get; set; }
        public string Database { get; set; }
        public int ResultCount { get; set; }
        public double SearchTime { get; set; }
        public object[] Results { get; set; }
    }

    /// <summary>
    /// Represents a streaming update during report generation
    /// </summary>
    public class ReportUpdate
    {
        public int SectionNumber { get; set; }
        public string SectionName { get; set; }
        public int PercentComplete { get; set; }
        public string Message { get; set; }
    }

    #endregion

    #region Attribute Definitions (For educational purposes only)
    // Note: The following attribute definitions are for demonstration only
    // In a real project, you would use the actual attributes from the MCP SDK

    [AttributeUsage(AttributeTargets.Method)]
    public class McpToolAttribute : Attribute
    {
        public McpToolAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    public class McpParameterAttribute : Attribute
    {
        public string Description { get; set; }
        public string Schema { get; set; }
        public bool IsOptional { get; set; }
    }

    #endregion
}
