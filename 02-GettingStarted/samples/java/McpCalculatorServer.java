// McpCalculatorServer.java - Sample MCP Calculator Server implementation in Java
package com.example.mcp;

import com.mcp.server.McpServer;
import com.mcp.tools.Tool;
import com.mcp.tools.ToolRequest;
import com.mcp.tools.ToolResponse;
import com.mcp.tools.ToolExecutionException;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

public class McpCalculatorServer {
    public static void main(String[] args) {
        // Create and configure MCP server
        McpServer server = new McpServer.Builder()
            .setName("Calculator MCP Server")
            .setVersion("1.0.0")
            .setPort(5000)
            .build();
        
        // Register calculator tool
        server.registerTool(new CalculatorTool());
        
        // Start server
        server.start();
        System.out.println("Calculator MCP Server started on port 5000");
    }
}

class CalculatorTool implements Tool {
    @Override
    public String getName() {
        return "calculator";
    }
    
    @Override
    public String getDescription() {
        return "Performs basic arithmetic operations";
    }
    
    @Override
    public Object getSchema() {
        // Define parameter schema
        Map<String, Object> schema = new HashMap<>();
        schema.put("type", "object");
        
        Map<String, Object> properties = new HashMap<>();
        
        Map<String, Object> operation = new HashMap<>();
        operation.put("type", "string");
        operation.put("enum", Arrays.asList("add", "subtract", "multiply", "divide"));
        properties.put("operation", operation);
        
        Map<String, Object> a = new HashMap<>();
        a.put("type", "number");
        properties.put("a", a);
        
        Map<String, Object> b = new HashMap<>();
        b.put("type", "number");
        properties.put("b", b);
        
        schema.put("properties", properties);
        schema.put("required", Arrays.asList("operation", "a", "b"));
        
        return schema;
    }
    
    @Override
    public ToolResponse execute(ToolRequest request) {
        // Extract parameters
        String operation = request.getParameters().get("operation").asText();
        double a = request.getParameters().get("a").asDouble();
        double b = request.getParameters().get("b").asDouble();
        
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
                    throw new ToolExecutionException("Cannot divide by zero");
                }
                result = a / b;
                break;
            default:
                throw new ToolExecutionException("Unknown operation: " + operation);
        }
        
        // Create response
        Map<String, Object> response = new HashMap<>();
        response.put("result", result);
        
        return new ToolResponse.Builder()
            .setResult(response)
            .build();
    }
}
