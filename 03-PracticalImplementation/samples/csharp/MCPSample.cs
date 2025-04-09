using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MCP.Samples.CSharp
{
    /// <summary>
    /// Sample implementation of a Model Context Protocol (MCP) server in C# .NET
    /// </summary>
    public class MCPServer
    {
        private readonly string _serverName;
        private readonly string _serverVersion;
        private readonly List<string> _supportedModels;
        private readonly ILogger<MCPServer> _logger;

        public MCPServer(string serverName, string serverVersion, ILogger<MCPServer> logger = null)
        {
            _serverName = serverName;
            _serverVersion = serverVersion;
            _supportedModels = new List<string> { "gpt-4", "llama-3-70b", "claude-3-sonnet" };
            _logger = logger ?? LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<MCPServer>();
        }

        /// <summary>
        /// Handle an MCP completion request
        /// </summary>
        /// <param name="request">The completion request</param>
        /// <returns>The completion response</returns>
        public async Task<MCPCompletionResponse> HandleCompletionRequestAsync(MCPCompletionRequest request)
        {
            _logger.LogInformation($"Processing completion request for model: {request.Model ?? "unknown"}");
            
            // Validate request
            if (string.IsNullOrEmpty(request.Model))
            {
                throw new ArgumentException("Model is required");
            }
            
            if (!_supportedModels.Contains(request.Model))
            {
                throw new ArgumentException($"Model {request.Model} not supported");
            }
            
            if (string.IsNullOrEmpty(request.Prompt))
            {
                throw new ArgumentException("Prompt is required");
            }
            
            // In a real implementation, this would call an AI model
            // Here we just echo back parts of the request with a mock response
            var response = new MCPCompletionResponse
            {
                Id = $"mcp-resp-{request.Id ?? Guid.NewGuid().ToString()}",
                Model = request.Model,
                Response = $"This is a response to: {request.Prompt.Substring(0, Math.Min(30, request.Prompt.Length))}...",
                Usage = new MCPUsage
                {
                    PromptTokens = request.Prompt.Split(' ').Length,
                    CompletionTokens = 20,
                    TotalTokens = request.Prompt.Split(' ').Length + 20
                }
            };
            
            // Simulate network delay
            await Task.Delay(500);
            return response;
        }

        /// <summary>
        /// Stream a completion response
        /// </summary>
        /// <param name="request">The completion request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>An asynchronous stream of completion chunks</returns>
        public async IAsyncEnumerable<MCPStreamingResponse> StreamCompletionAsync(
            MCPCompletionRequest request,
            [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            // Validate request
            if (string.IsNullOrEmpty(request.Model) || string.IsNullOrEmpty(request.Prompt))
            {
                yield return new MCPStreamingResponse 
                { 
                    Error = "Invalid request parameters" 
                };
                yield break;
            }

            // Mock streaming response generation
            string responseText = "This is a streaming response to your prompt about Model Context Protocol. " +
                "MCP standardizes how applications communicate with AI models, making it easier to build AI-powered applications " +
                "that work consistently across different model providers.";
            
            string[] words = responseText.Split(' ');

            for (int i = 0; i < words.Length && !cancellationToken.IsCancellationRequested; i++)
            {
                // Simulate token-by-token generation
                await Task.Delay(100, cancellationToken);
                
                yield return new MCPStreamingResponse
                {
                    Id = $"mcp-stream-{request.Id ?? Guid.NewGuid().ToString()}",
                    Model = request.Model,
                    Delta = words[i] + " ",
                    Finished = false
                };
            }

            // Final message
            if (!cancellationToken.IsCancellationRequested)
            {
                yield return new MCPStreamingResponse
                {
                    Id = $"mcp-stream-{request.Id ?? Guid.NewGuid().ToString()}",
                    Model = request.Model,
                    Delta = "",
                    Finished = true,
                    Usage = new MCPUsage
                    {
                        PromptTokens = request.Prompt.Split(' ').Length,
                        CompletionTokens = words.Length,
                        TotalTokens = request.Prompt.Split(' ').Length + words.Length
                    }
                };
            }
        }
    }

    /// <summary>
    /// Sample implementation of a Model Context Protocol (MCP) client in C# .NET
    /// </summary>
    public class MCPClient
    {
        private readonly string _serverUrl;
        private readonly ILogger<MCPClient> _logger;

        public MCPClient(string serverUrl, ILogger<MCPClient> logger = null)
        {
            _serverUrl = serverUrl;
            _logger = logger ?? LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<MCPClient>();
        }

        /// <summary>
        /// Send a completion request to an MCP server
        /// </summary>
        /// <param name="request">The completion request</param>
        /// <returns>The completion response</returns>
        public async Task<MCPCompletionResponse> CreateCompletionAsync(MCPCompletionRequest request)
        {
            _logger.LogInformation($"Sending completion request to {_serverUrl}");
            
            // Validate request
            if (string.IsNullOrEmpty(request.Model))
            {
                throw new ArgumentException("Model is required");
            }
            
            if (string.IsNullOrEmpty(request.Prompt))
            {
                throw new ArgumentException("Prompt is required");
            }
            
            // Ensure request has an ID
            if (string.IsNullOrEmpty(request.Id))
            {
                request.Id = Guid.NewGuid().ToString();
            }
            
            // In a real implementation, this would use HttpClient to send the request
            // For this sample, we'll create a server and call it directly
            var server = new MCPServer("Sample MCP Server", "1.0");
            return await server.HandleCompletionRequestAsync(request);
        }

        /// <summary>
        /// Stream a completion from an MCP server
        /// </summary>
        /// <param name="request">The completion request</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>An asynchronous stream of completion chunks</returns>
        public IAsyncEnumerable<MCPStreamingResponse> CreateCompletionStreamAsync(
            MCPCompletionRequest request, 
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Starting streaming completion with {_serverUrl}");
            
            // Validate request
            if (string.IsNullOrEmpty(request.Model))
            {
                throw new ArgumentException("Model is required");
            }
            
            if (string.IsNullOrEmpty(request.Prompt))
            {
                throw new ArgumentException("Prompt is required");
            }
            
            // Ensure request has an ID
            if (string.IsNullOrEmpty(request.Id))
            {
                request.Id = Guid.NewGuid().ToString();
            }
            
            // Set streaming flag
            request.Stream = true;
            
            // In a real implementation, this would use HttpClient with streaming
            // For this sample, we'll create a server and return its streaming response
            var server = new MCPServer("Sample MCP Server", "1.0");
            return server.StreamCompletionAsync(request, cancellationToken);
        }
    }

    #region Model Classes

    /// <summary>
    /// Represents an MCP completion request
    /// </summary>
    public class MCPCompletionRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("model")]
        public string Model { get; set; }
        
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }
        
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; } = 0.7;
        
        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; set; } = 100;
        
        [JsonPropertyName("stream")]
        public bool Stream { get; set; }
    }

    /// <summary>
    /// Represents an MCP completion response
    /// </summary>
    public class MCPCompletionResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("model")]
        public string Model { get; set; }
        
        [JsonPropertyName("response")]
        public string Response { get; set; }
        
        [JsonPropertyName("usage")]
        public MCPUsage Usage { get; set; }
        
        [JsonPropertyName("error")]
        public string Error { get; set; }
    }

    /// <summary>
    /// Represents an MCP streaming response chunk
    /// </summary>
    public class MCPStreamingResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("model")]
        public string Model { get; set; }
        
        [JsonPropertyName("delta")]
        public string Delta { get; set; }
        
        [JsonPropertyName("finished")]
        public bool Finished { get; set; }
        
        [JsonPropertyName("usage")]
        public MCPUsage Usage { get; set; }
        
        [JsonPropertyName("error")]
        public string Error { get; set; }
    }

    /// <summary>
    /// Represents token usage information in an MCP response
    /// </summary>
    public class MCPUsage
    {
        [JsonPropertyName("prompt_tokens")]
        public int PromptTokens { get; set; }
        
        [JsonPropertyName("completion_tokens")]
        public int CompletionTokens { get; set; }
        
        [JsonPropertyName("total_tokens")]
        public int TotalTokens { get; set; }
    }

    #endregion

    /// <summary>
    /// Example program demonstrating MCP client and server usage
    /// </summary>
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Configure logging
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<Program>();
            
            logger.LogInformation("Starting MCP sample application");
            
            // Create client
            var client = new MCPClient("https://mcp.example.org");
            
            // Standard completion example
            logger.LogInformation("Running standard completion example");
            
            try
            {
                var response = await client.CreateCompletionAsync(new MCPCompletionRequest
                {
                    Model = "gpt-4",
                    Prompt = "Explain the Model Context Protocol in simple terms",
                    Temperature = 0.7,
                    MaxTokens = 100
                });
                
                Console.WriteLine("\n--- MCP Response ---");
                Console.WriteLine(JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception ex)
            {
                logger.LogError($"Error in completion example: {ex.Message}");
            }
            
            // Streaming example
            logger.LogInformation("Running streaming completion example");
            
            try
            {
                var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                Console.WriteLine("\n--- Streaming Example ---");
                
                await foreach (var chunk in client.CreateCompletionStreamAsync(
                    new MCPCompletionRequest
                    {
                        Model = "gpt-4",
                        Prompt = "Explain streaming in MCP",
                        Temperature = 0.7
                    }, cts.Token))
                {
                    if (!string.IsNullOrEmpty(chunk.Delta))
                    {
                        Console.Write(chunk.Delta);
                    }
                    
                    if (chunk.Finished)
                    {
                        Console.WriteLine("\n\nStream finished");
                        Console.WriteLine($"Usage: {JsonSerializer.Serialize(chunk.Usage)}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                logger.LogWarning("Streaming example was cancelled or timed out");
            }
            catch (Exception ex)
            {
                logger.LogError($"Error in streaming example: {ex.Message}");
            }
        }
    }
}
