package org.example.mcp;

import io.modelcontextprotocol.sdk.core.McpServer;
import io.modelcontextprotocol.sdk.core.client.McpClient;
import io.modelcontextprotocol.sdk.core.client.sampling.DefaultCompletionRequest;
import io.modelcontextprotocol.sdk.core.client.sampling.DefaultSamplingConfiguration;
import io.modelcontextprotocol.sdk.core.client.sampling.DefaultSamplingOptions;
import io.modelcontextprotocol.sdk.core.client.sampling.SamplingPrompt;
import io.modelcontextprotocol.sdk.core.client.sampling.SamplingResult;
import io.modelcontextprotocol.sdk.core.transport.DefaultMcpSession;
import io.modelcontextprotocol.sdk.core.transport.McpTransport;
import io.modelcontextprotocol.sdk.core.transport.stdio.StdioTransport;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.concurrent.CompletableFuture;
import java.util.logging.Logger;

/**
 * MCP Sample implementation in Java using the latest Java SDK
 */
public class MCPSample {
    private static final Logger logger = Logger.getLogger(MCPSample.class.getName());
    private final McpServer server;
    private final McpClient client;
    private final List<String> supportedModels = List.of("gpt-4", "llama-3-70b", "claude-3-sonnet");

    public MCPSample() {
        // Create a transport for the server
        McpTransport serverTransport = new StdioTransport();
        var serverSession = new DefaultMcpSession(serverTransport);
        
        // Initialize the server
        server = McpServer.builder()
                .name("MCP Sample Server")
                .version("1.0.0")
                .build(serverSession);
                
        // Create a transport for the client
        McpTransport clientTransport = new StdioTransport();
        var clientSession = new DefaultMcpSession(clientTransport);
        
        // Initialize the client
        client = McpClient.builder()
                .name("MCP Sample Client")
                .build(clientSession);
    }
    
    /**
     * Start the server and client
     */
    public void start() {
        server.start().join();
        client.start().join();
        logger.info("MCP Sample Server and Client started");
    }

    /**
     * Handle an MCP completion request using the MCP client
     * 
     * @param model The model to use
     * @param prompt The prompt to send
     * @return CompletableFuture containing the response
     */
    public CompletableFuture<SamplingResult> handleCompletionRequest(String model, String prompt) {
        logger.info("Processing completion request for model: " + model);

        // Validate model
        if (!supportedModels.contains(model)) {
            return CompletableFuture.failedFuture(
                new IllegalArgumentException("Model " + model + " not supported"));
        }

        // Create sampling configuration
        var config = DefaultSamplingConfiguration.builder()
                .model(model)
                .build();
        
        // Create sampling options
        var options = DefaultSamplingOptions.builder()
                .temperature(0.7)
                .maxTokens(100)
                .build();
        
        // Create prompt
        var samplingPrompt = SamplingPrompt.fromText(prompt);
        
        // Create completion request
        var request = DefaultCompletionRequest.builder()
                .configuration(config)
                .options(options)
                .prompt(samplingPrompt)
                .build();
        
        // Execute the completion request
        return client.sampling().complete(request);
    }

    /**
     * Stream a completion response using the MCP client
     * 
     * @param model The model to use
     * @param prompt The prompt to send
     * @return CompletableFuture containing the streamed result
     */    public CompletableFuture<SamplingResult> streamCompletion(String model, String prompt) {
        logger.info("Streaming completion request for model: " + model);
        
        // Validate model
        if (!supportedModels.contains(model)) {
            return CompletableFuture.failedFuture(
                new IllegalArgumentException("Model " + model + " not supported"));
        }

        // Create sampling configuration
        var config = DefaultSamplingConfiguration.builder()
                .model(model)
                .build();
        
        // Create sampling options
        var options = DefaultSamplingOptions.builder()
                .temperature(0.7)
                .maxTokens(100)
                .build();
        
        // Create prompt
        var samplingPrompt = SamplingPrompt.fromText(prompt);
        
        // Create completion request
        var request = DefaultCompletionRequest.builder()
                .configuration(config)
                .options(options)
                .prompt(samplingPrompt)
                .build();
        
        // Execute the streaming request
        return client.sampling().completeStreaming(request);
    }
    
    /**
     * Main method for demonstration
     */
    public static void main(String[] args) {
        var mcpSample = new MCPSample();
        mcpSample.start();
        
        // Example of using the sample
        String model = "gpt-4";
        String prompt = "Explain the Model Context Protocol in a sentence.";
        
        mcpSample.handleCompletionRequest(model, prompt)
            .thenAccept(result -> {
                logger.info("Completion result: " + result.content());
            })
            .exceptionally(ex -> {
                logger.severe("Error during completion: " + ex.getMessage());
                return null;
            });
    }
}
                return;
            }

            String model = (String) request.get("model");
            String prompt = (String) request.get("prompt");
            String requestId = (String) request.getOrDefault("id", UUID.randomUUID().toString());

            // Mock streaming response generation
            String responseText = "This is a streaming response to your prompt. " +
                "The Model Context Protocol allows standardized communication with AI models. " +
                "This message is being streamed word by word as a demonstration.";

            String[] words = responseText.split("\\s+");

            for (String word : words) {
                try {
                    // Simulate token-by-token generation
                    Thread.sleep(100);
                    
                    Map<String, Object> chunk = new HashMap<>();
                    chunk.put("id", "mcp-stream-" + requestId);
                    chunk.put("model", model);
                    chunk.put("delta", word + " ");
                    chunk.put("finished", false);
                    
                    publisher.submit(chunk);
                } catch (InterruptedException e) {
                    Thread.currentThread().interrupt();
                    break;
                }
            }

            // Final message
            Map<String, Object> usage = new HashMap<>();
            usage.put("promptTokens", prompt.split("\\s+").length);
            usage.put("completionTokens", words.length);
            usage.put("totalTokens", prompt.split("\\s+").length + words.length);

            Map<String, Object> finalChunk = new HashMap<>();
            finalChunk.put("id", "mcp-stream-" + requestId);
            finalChunk.put("model", model);
            finalChunk.put("delta", "");
            finalChunk.put("finished", true);
            finalChunk.put("usage", usage);
            
            publisher.submit(finalChunk);
            publisher.close();
        });

        return publisher;
    }

    public String getServerName() {
        return serverName;
    }

    public String getVersion() {
        return version;
    }
}

/**
 * MCP Client implementation in Java
 */
public class MCPClient {
    private final String serverUrl;
    private static final Logger logger = Logger.getLogger(MCPClient.class.getName());

    public MCPClient(String serverUrl) {
        this.serverUrl = serverUrl;
    }

    /**
     * Send a completion request to an MCP server
     * 
     * @param model The model to use
     * @param prompt The prompt to send
     * @param temperature The temperature parameter (0.0-1.0)
     * @param maxTokens The maximum tokens to generate
     * @return CompletableFuture containing the response
     */
    public CompletableFuture<Map<String, Object>> createCompletion(String model, String prompt, 
                                                                  double temperature, int maxTokens) {
        logger.info("Sending completion request to " + serverUrl);

        if (model == null || model.isEmpty()) {
            throw new IllegalArgumentException("Model is required");
        }
        if (prompt == null || prompt.isEmpty()) {
            throw new IllegalArgumentException("Prompt is required");
        }

        Map<String, Object> request = new HashMap<>();
        request.put("id", "req-" + UUID.randomUUID().toString());
        request.put("model", model);
        request.put("prompt", prompt);
        request.put("temperature", temperature);
        request.put("maxTokens", maxTokens);

        // In a real implementation, this would use HTTP to send the request
        // For this sample, we'll create a server and call it directly
        MCPServer server = new MCPServer("Sample MCP Server", "1.0");
        return server.handleCompletionRequest(request);
    }

    /**
     * Example main method demonstrating the usage of MCP client and server
     */
    public static void main(String[] args) {
        MCPClient client = new MCPClient("https://mcp.example.org");
        
        CompletableFuture<Map<String, Object>> future = client.createCompletion(
            "gpt-4",
            "Explain the Model Context Protocol in simple terms",
            0.7,
            100
        );
        
        future.thenAccept(response -> {
            System.out.println("\n--- MCP Response ---");
            response.forEach((key, value) -> System.out.println(key + ": " + value));
        }).join();
    }
}
