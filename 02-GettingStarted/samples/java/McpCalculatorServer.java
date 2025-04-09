// McpCalculatorServer.java - Sample MCP Calculator Server implementation in Java
package com.example.mcp;

import io.modelcontextprotocol.MCPServer;
import io.modelcontextprotocol.ServerBuilder;
import io.modelcontextprotocol.ServerConfig;
import io.modelcontextprotocol.content.ContentItem;
import io.modelcontextprotocol.content.TextContent;
import io.modelcontextprotocol.tool.ToolDefinition;
import io.modelcontextprotocol.tool.ToolExecutor;
import io.modelcontextprotocol.tool.ToolResponse;
import io.modelcontextprotocol.transport.stdio.StdioTransport;

import java.util.Arrays;
import java.util.List;
import java.util.Map;
import java.util.concurrent.CompletableFuture;

public class McpCalculatorServer {    public static void main(String[] args) throws Exception {
        // Configure the server
        ServerConfig config = new ServerConfig.Builder()
            .name("Calculator MCP Server")
            .version("1.0.0")
            .build();
        
        // Create MCP server
        MCPServer server = new ServerBuilder()
            .config(config)
            .build();
        
        // Define calculator tool
        ToolDefinition calculatorTool = new ToolDefinition.Builder()
            .name("calculator")
            .description("Performs basic arithmetic operations")
            .addParameter("operation", "string", "The arithmetic operation to perform")
                .withEnum("add", "subtract", "multiply", "divide")
            .addParameter("a", "number", "First operand")
            .addParameter("b", "number", "Second operand")
            .addRequiredParameters("operation", "a", "b")
            .build();
            
        // Register calculator tool
        server.registerTool(calculatorTool, new ToolExecutor() {
            @Override
            public CompletableFuture<ToolResponse> execute(Map<String, Object> params) {
                // Extract parameters
                String operation = (String) params.get("operation");
                double a = ((Number) params.get("a")).doubleValue();
                double b = ((Number) params.get("b")).doubleValue();
                
                double result = 0;
                  // Perform calculation
                switch (operation) {
                    case "add":
                        result = a + b;
                        break;
                    case "subtract":
                        result = a - b;
                        break;
                    case "multiply":
                        result = a * b;
                        break;
                    case "divide":
                        if (b == 0) {
                            throw new IllegalArgumentException("Cannot divide by zero");
                        }
                        result = a / b;
                        break;
                    default:
                        throw new IllegalArgumentException("Unknown operation: " + operation);
                }
                
                // Return result in standard MCP content format
                ContentItem textContent = new TextContent(String.format("{\"result\": %f}", result));
                ToolResponse response = new ToolResponse.Builder()
                    .addContent(textContent)
                    .build();
                
                return CompletableFuture.completedFuture(response);
            }
        });
        
        System.out.println("Starting Calculator MCP Server");
        
        // Start server with stdio transport
        StdioTransport transport = new StdioTransport();
        server.start(transport).join();
    }
}
