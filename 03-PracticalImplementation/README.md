# Practical Implementation

## Overview

This lesson focuses on practical aspects of MCP implementation across multiple programming languages. We'll explore how to use MCP SDKs in .NET, Java, and Python to build robust applications, debug and test MCP servers, and create reusable prompt templates and workflows.

## Learning Objectives

By the end of this lesson, you will be able to:
- Implement MCP solutions using SDKs in .NET, Java, and Python
- Debug and test MCP servers systematically
- Create reusable prompt templates for consistent AI interactions
- Design effective MCP workflows for complex tasks
- Optimize MCP implementations for performance and reliability

## Working with MCP SDKs

This section provides practical examples of implementing MCP across multiple programming languages. You can find sample code in the `samples` directory organized by language.

### Available Samples

The repository includes sample implementations in the following languages:

- C# (.NET)
- Java
- JavaScript
- Python

Each sample demonstrates key MCP concepts and implementation patterns for that specific language and ecosystem.

### C# (.NET) Implementation

The .NET SDK for MCP provides comprehensive tooling for building both clients and servers.

#### Key Features

- Strong typing and async/await support
- Integration with ASP.NET Core middleware
- Built-in DI container integration
- Streaming response support

#### Sample Implementations

The official C# SDK repository contains several sample implementations demonstrating different aspects of MCP:

- **Basic MCP Client**: Simple example showing how to create an MCP client and call tools
- **Basic MCP Server**: Minimal server implementation with basic tool registration
- **Advanced MCP Server**: Full-featured server with tool registration, authentication, and error handling
- **ASP.NET Integration**: Examples demonstrating integration with ASP.NET Core
- **Tool Implementation Patterns**: Various patterns for implementing tools with different complexity levels

For complete C# implementation samples, visit the [official C# SDK samples repository](https://github.com/modelcontextprotocol/csharp-sdk/tree/main/samples).

### Java Implementation

The Java SDK offers robust MCP implementation options with enterprise-grade features.

#### Key Features

- Spring Framework integration
- Strong type safety
- Reactive programming support
- Comprehensive error handling

For a complete Java implementation sample, see [MCPSample.java](samples/java/MCPSample.java) in the samples directory.

### JavaScript Implementation

The JavaScript SDK provides a lightweight and flexible approach to MCP implementation.

#### Key Features

- Node.js and browser support
- Promise-based API
- Easy integration with Express and other frameworks
- WebSocket support for streaming

For a complete JavaScript implementation sample, see [mcp_sample.js](samples/javascript/mcp_sample.js) in the samples directory.

### Python Implementation

The Python SDK offers a Pythonic approach to MCP implementation with excellent ML framework integrations.

#### Key Features

- Async/await support with asyncio
- Flask and FastAPI integration
- Simple tool registration
- Native integration with popular ML libraries

For a complete Python implementation sample, see [mcp_sample.py](samples/python/mcp_sample.py) in the samples directory.
        
        public object GetSchema()
        {
            return new {
                type = "object",
                properties = new {
                    query = new { type = "string" },
                    database = new { type = "string", enum = new[] { "products", "customers", "orders" } }
                },
                required = new[] { "query", "database" }
            };
        }
        
        public async Task<ToolResponse> ExecuteAsync(ToolRequest request)
        {
            try
            {
                _logger.LogInformation("Executing database query tool");
                
                var query = request.Parameters.GetProperty("query").GetString();
                var database = request.Parameters.GetProperty("database").GetString();
                
                _logger.LogInformation("Query: {Query}, Database: {Database}", query, database);
                
                var results = await _databaseService.QueryAsync(database, query);
                
                return new ToolResponse {
                    Result = JsonSerializer.SerializeToElement(results)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing database query tool");
                throw new ToolExecutionException("Database query failed: " + ex.Message);
            }
        }
    }
}
```

### Java SDK

The Java SDK for MCP provides a flexible framework for building enterprise-grade MCP applications.

#### Key Features

- Builder pattern for configuration
- Reactive programming support
- Integration with Spring Boot
- Connection pooling and backoff strategies

#### Advanced Implementation

```java
package com.example.mcp.advanced;

import com.mcp.server.McpServer;
import com.mcp.tools.Tool;
import com.mcp.tools.ToolRequest;
import com.mcp.tools.ToolResponse;
import com.mcp.config.SecurityConfig;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;

import java.util.concurrent.Executors;
import java.util.concurrent.ExecutorService;
import java.util.logging.Logger;

@SpringBootApplication
public class AdvancedMcpApplication {
    private static final Logger logger = Logger.getLogger(AdvancedMcpApplication.class.getName());
    
    public static void main(String[] args) {
        SpringApplication.run(AdvancedMcpApplication.class, args);
    }
    
    @Bean
    public McpServer mcpServer(DocumentSearchTool searchTool, 
                              TranslationTool translationTool,
                              SecurityConfig securityConfig) {
        // Create thread pool for handling requests
        ExecutorService executorService = Executors.newFixedThreadPool(10);
        
        // Configure and build MCP server
        McpServer server = new McpServer.Builder()
            .setName("Advanced Java MCP Server")
            .setVersion("1.0.0")
            .setPort(5000)
            .setExecutor(executorService)
            .setSecurityConfig(securityConfig)
            .setMaxRequestSize(5 * 1024 * 1024) // 5MB
            .setResponseTimeout(30000) // 30 seconds
            .build();
            
        // Register tools
        server.registerTool(searchTool);
        server.registerTool(translationTool);
        
        // Start server
        server.start();
        logger.info("Advanced Java MCP Server started on port 5000");
        
        return server;
    }
    
    // Spring-managed tool bean
    @Bean
    public DocumentSearchTool documentSearchTool(DocumentRepository repository) {
        return new DocumentSearchTool(repository);
    }
    
    // Spring-managed tool bean
    @Bean
    public TranslationTool translationTool(TranslationService translationService) {
        return new TranslationTool(translationService);
    }
}

// Advanced tool implementation with dependency injection
class DocumentSearchTool implements Tool {
    private final DocumentRepository repository;
    private static final Logger logger = Logger.getLogger(DocumentSearchTool.class.getName());
    
    public DocumentSearchTool(DocumentRepository repository) {
        this.repository = repository;
    }
    
    @Override
    public String getName() {
        return "documentSearch";
    }
    
    @Override
    public String getDescription() {
        return "Searches documents in the knowledge base by keyword or topic";
    }
    
    @Override
    public Object getSchema() {
        // Create schema definition
        Map<String, Object> schema = new HashMap<>();
        // ... schema definition
        return schema;
    }
    
    @Override
    public ToolResponse execute(ToolRequest request) {
        try {
            String query = request.getParameters().get("query").asText();
            int limit = request.getParameters().get("limit").asInt(10);
            
            logger.info("Executing document search: " + query + ", limit: " + limit);
            
            List<Document> documents = repository.search(query, limit);
            
            // Transform documents to response format
            List<Map<String, Object>> results = documents.stream()
                .map(doc -> {
                    Map<String, Object> result = new HashMap<>();
                    result.put("id", doc.getId());
                    result.put("title", doc.getTitle());
                    result.put("summary", doc.getSummary());
                    result.put("relevance", doc.getRelevanceScore());
                    return result;
                })
                .collect(Collectors.toList());
            
            // Build response
            Map<String, Object> response = new HashMap<>();
            response.put("results", results);
            response.put("totalFound", documents.size());
            
            return new ToolResponse.Builder()
                .setResult(response)
                .build();
        } catch (Exception ex) {
            logger.severe("Error in document search: " + ex.getMessage());
            throw new ToolExecutionException("Document search failed", ex);
        }
    }
}
```

### Python SDK

The Python SDK provides a lightweight, flexible approach to implementing MCP solutions.

#### Key Features

- Easy integration with popular Python frameworks
- Async support with asyncio
- Support for various communication protocols
- Plugin architecture for tool extensions

#### Advanced Implementation

```python
from mcp_server import McpServer, AsyncMcpServer
from mcp_tools import Tool, ToolRequest, ToolResponse, ToolExecutionException
import asyncio
import logging
import aiohttp
import json
from typing import Dict, List, Any, Optional
from dataclasses import dataclass

# Configure logging
logging.basicConfig(
    level=logging.INFO,
    format='%(asctime)s - %(name)s - %(levelname)s - %(message)s'
)
logger = logging.getLogger(__name__)

# Data access service
class KnowledgeBaseService:
    """Service for accessing the knowledge base"""
    
    async def search_documents(self, query: str, max_results: int = 5) -> List[Dict[str, Any]]:
        """Search documents in the knowledge base"""
        # Implementation would connect to actual database
        logger.info(f"Searching for: {query}, max results: {max_results}")
        # Simulated response
        return [
            {"id": "1", "title": "MCP Overview", "content": "MCP is a protocol for..."},
            {"id": "2", "title": "MCP Tools", "content": "Tools are functions that..."}
        ]

# Advanced MCP tool with async support
class KnowledgeBaseTool(Tool):
    def __init__(self, kb_service: KnowledgeBaseService):
        self.kb_service = kb_service
        
    def get_name(self):
        return "knowledgeBase"
        
    def get_description(self):
        return "Searches the knowledge base for relevant information"
    
    def get_schema(self):
        return {
            "type": "object",
            "properties": {
                "query": {
                    "type": "string", 
                    "description": "The search query"
                },
                "max_results": {
                    "type": "integer",
                    "description": "Maximum number of results to return",
                    "default": 5
                }
            },
            "required": ["query"]
        }
    
    async def execute_async(self, request: ToolRequest) -> ToolResponse:
        try:
            # Extract parameters
            query = request.parameters.get("query")
            max_results = request.parameters.get("max_results", 5)
            
            logger.info(f"Executing knowledge base search for: {query}")
            
            # Call the knowledge base service
            results = await self.kb_service.search_documents(query, max_results)
            
            # Return results
            return ToolResponse(
                result={
                    "documents": results,
                    "count": len(results)
                }
            )
        except Exception as e:
            logger.error(f"Error in knowledge base search: {str(e)}")
            raise ToolExecutionException(f"Knowledge base search failed: {str(e)}")

# Webhook notification tool
class NotificationTool(Tool):
    def get_name(self):
        return "sendNotification"
        
    def get_description(self):
        return "Sends a notification to specified channels"
    
    def get_schema(self):
        return {
            "type": "object",
            "properties": {
                "message": {"type": "string"},
                "importance": {
                    "type": "string",
                    "enum": ["low", "medium", "high"],
                    "default": "medium"
                },
                "channels": {
                    "type": "array",
                    "items": {"type": "string"},
                    "default": ["email"]
                }
            },
            "required": ["message"]
        }
    
    async def execute_async(self, request: ToolRequest) -> ToolResponse:
        # Implementation details
        return ToolResponse(result={"success": True, "sent_to": 1})

# Main application
async def main():
    # Create services
    kb_service = KnowledgeBaseService()
    
    # Create async MCP server
    server = AsyncMcpServer(
        name="Advanced Python MCP Server",
        version="1.0.0",
        port=5000,
        max_concurrent_requests=20
    )
    
    # Register tools
    server.register_tool(KnowledgeBaseTool(kb_service))
    server.register_tool(NotificationTool())
    
    # Start server
    await server.start()
    logger.info("Advanced Python MCP Server running on port 5000")
    
    # Keep server running
    try:
        while True:
            await asyncio.sleep(3600)
    except KeyboardInterrupt:
        logger.info("Shutting down server")
        await server.stop()

if __name__ == "__main__":
    asyncio.run(main())
```

## Debugging and Testing MCP Servers

Effective debugging and testing is crucial for reliable MCP implementations.

### MCP Inspector

MCP Inspector is a powerful tool for interactively testing and debugging MCP servers:

```python
# Install MCP Inspector
pip install mcp-inspector

# Launch Inspector UI
mcp-inspector --server-url http://localhost:5000 --output-format detailed
```

The Inspector provides:
- Tool discovery and schema validation
- Request/response logging
- Performance metrics
- Interactive tool testing

### Automated Testing Frameworks

#### .NET Testing

```csharp
using Microsoft.Mcp.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace McpServerTests
{
    public class CalculatorToolTests
    {
        private readonly IMcpToolTester _toolTester;
        
        public CalculatorToolTests()
        {
            // Set up DI container for testing
            var services = new ServiceCollection();
            services.AddMcpTool<CalculatorTool>();
            services.AddMcpToolTesting();
            
            var serviceProvider = services.BuildServiceProvider();
            _toolTester = serviceProvider.GetRequiredService<IMcpToolTester>();
        }
        
        [Fact]
        public async Task Add_ValidNumbers_ReturnsCorrectSum()
        {
            // Arrange
            var request = new ToolRequest(
                toolName: "calculator",
                parameters: new {
                    operation = "add",
                    a = 5,
                    b = 7
                }
            );
            
            // Act
            var response = await _toolTester.ExecuteToolAsync(request);
            
            // Assert
            Assert.NotNull(response);
            Assert.Equal(12.0, response.Result.GetProperty("result").GetDouble());
        }
        
        [Fact]
        public async Task Divide_ByZero_ThrowsException()
        {
            // Arrange
            var request = new ToolRequest(
                toolName: "calculator",
                parameters: new {
                    operation = "divide",
                    a = 10,
                    b = 0
                }
            );
            
            // Act & Assert
            await Assert.ThrowsAsync<ToolExecutionException>(
                () => _toolTester.ExecuteToolAsync(request)
            );
        }
    }
}
```

#### Java Testing

```java
package com.example.mcp.tests;

import com.mcp.testing.McpToolTester;
import com.mcp.tools.ToolRequest;
import com.mcp.tools.ToolResponse;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.HashMap;
import java.util.Map;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
public class DocumentSearchToolTests {
    
    @Autowired
    private McpToolTester toolTester;
    
    @Test
    public void testDocumentSearch_ValidQuery_ReturnsResults() {
        // Arrange
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("query", "protocol");
        parameters.put("limit", 5);
        
        ToolRequest request = new ToolRequest.Builder()
            .setToolName("documentSearch")
            .setParameters(parameters)
            .build();
            
        // Act
        ToolResponse response = toolTester.executeTool(request);
        
        // Assert
        assertNotNull(response);
        assertNotNull(response.getResult().get("results"));
        assertTrue(response.getResult().get("results").isArray());
        assertTrue(response.getResult().get("totalFound").asInt() > 0);
    }
    
    @Test
    public void testDocumentSearch_EmptyQuery_ThrowsException() {
        // Arrange
        Map<String, Object> parameters = new HashMap<>();
        parameters.put("query", "");
        
        ToolRequest request = new ToolRequest.Builder()
            .setToolName("documentSearch")
            .setParameters(parameters)
            .build();
            
        // Act & Assert
        assertThrows(ToolExecutionException.class, () -> {
            toolTester.executeTool(request);
        });
    }
}
```

#### Python Testing

```python
import pytest
import json
from mcp_testing import McpToolTester
from mcp_tools import ToolRequest, ToolExecutionException

from knowledge_base_tool import KnowledgeBaseTool
from knowledge_base_service import KnowledgeBaseService

class TestKnowledgeBaseTool:
    @pytest.fixture
    def tool_tester(self):
        # Mock knowledge base service
        mock_kb_service = KnowledgeBaseService()
        
        # Create tool instance
        kb_tool = KnowledgeBaseTool(mock_kb_service)
        
        # Create tool tester
        return McpToolTester(kb_tool)
    
    @pytest.mark.asyncio
    async def test_knowledge_search_valid_query(self, tool_tester):
        # Arrange
        request = ToolRequest(
            tool_name="knowledgeBase",
            parameters={
                "query": "protocol",
                "max_results": 3
            }
        )
        
        # Act
        response = await tool_tester.execute_async(request)
        
        # Assert
        assert response is not None
        assert "documents" in response.result
        assert isinstance(response.result["documents"], list)
        assert len(response.result["documents"]) <= 3
        
    @pytest.mark.asyncio
    async def test_knowledge_search_empty_query(self, tool_tester):
        # Arrange
        request = ToolRequest(
            tool_name="knowledgeBase",
            parameters={
                "query": ""
            }
        )
        
        # Act & Assert
        with pytest.raises(ToolExecutionException):
            await tool_tester.execute_async(request)
```

## Creating Reusable Prompt Templates

Prompt templates help create consistent interactions with AI models across applications.

### Template Architecture

```
[System Message]
You are an AI assistant with access to the following tools:
{{tools}}

[User Message]
{{user_query}}

[Response Format]
{{response_format}}
```

### .NET Prompt Template Implementation

```csharp
using Microsoft.Mcp.Client;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McpTemplates
{
    public class PromptTemplate
    {
        private string _systemMessage;
        private string _responseFormat;
        private List<string> _allowedTools;
        
        public PromptTemplate(string systemMessage, string responseFormat, List<string> allowedTools)
        {
            _systemMessage = systemMessage;
            _responseFormat = responseFormat;
            _allowedTools = allowedTools;
        }
        
        public async Task<McpResponse> ExecuteAsync(IMcpClient mcpClient, string userQuery)
        {
            // Build the complete prompt
            var promptBuilder = new StringBuilder();
            
            // Add system message
            promptBuilder.AppendLine(_systemMessage);
            
            // Add tools information
            if (_allowedTools.Count > 0)
            {
                promptBuilder.AppendLine("\nYou have access to these tools:");
                foreach (var tool in _allowedTools)
                {
                    promptBuilder.AppendLine($"- {tool}");
                }
            }
            
            // Add user query
            promptBuilder.AppendLine($"\nUser Query: {userQuery}");
            
            // Add response format
            if (!string.IsNullOrEmpty(_responseFormat))
            {
                promptBuilder.AppendLine($"\nResponse Format: {_responseFormat}");
            }
            
            // Create options
            var options = new McpToolOptions
            {
                AllowedTools = _allowedTools.ToArray()
            };
            
            // Send prompt to MCP client
            return await mcpClient.SendPromptAsync(promptBuilder.ToString(), options);
        }
    }
    
    // Example usage:
    public class DocumentSearchExample
    {
        public async Task RunExample()
        {
            var mcpClient = new McpClient("https://mcp-server.example.com");
            
            var searchTemplate = new PromptTemplate(
                systemMessage: "You are a research assistant that helps find relevant documents.",
                responseFormat: "Provide a summary of each relevant document and explain why it's useful.",
                allowedTools: new List<string> { "documentSearch", "contentExtractor" }
            );
            
            var response = await searchTemplate.ExecuteAsync(
                mcpClient, 
                "Find documents about implementing MCP in enterprise settings"
            );
            
            Console.WriteLine(response.GeneratedText);
        }
    }
}
```

### Java Prompt Template Implementation

```java
package com.example.mcp.templates;

import com.mcp.client.McpClient;
import com.mcp.models.McpRequest;
import com.mcp.models.McpResponse;
import com.mcp.models.ToolOptions;

import java.util.List;
import java.util.HashMap;
import java.util.Map;

public class PromptTemplate {
    private final String systemMessage;
    private final String responseFormat;
    private final List<String> allowedTools;
    
    public PromptTemplate(String systemMessage, String responseFormat, List<String> allowedTools) {
        this.systemMessage = systemMessage;
        this.responseFormat = responseFormat;
        this.allowedTools = allowedTools;
    }
    
    public McpResponse execute(McpClient client, String userQuery) {
        // Build the complete prompt
        StringBuilder promptBuilder = new StringBuilder();
        
        // Add system message
        promptBuilder.append(systemMessage).append("\n\n");
        
        // Add tools information
        if (!allowedTools.isEmpty()) {
            promptBuilder.append("You have access to these tools:\n");
            for (String tool : allowedTools) {
                promptBuilder.append("- ").append(tool).append("\n");
            }
            promptBuilder.append("\n");
        }
        
        // Add user query
        promptBuilder.append("User Query: ").append(userQuery).append("\n\n");
        
        // Add response format
        if (responseFormat != null && !responseFormat.isEmpty()) {
            promptBuilder.append("Response Format: ").append(responseFormat).append("\n");
        }
        
        // Create request
        McpRequest request = new McpRequest.Builder()
            .setPrompt(promptBuilder.toString())
            .setAllowedTools(allowedTools)
            .build();
            
        // Send request and return response
        return client.sendRequest(request);
    }
}

// Example implementation
class CustomerSupportTemplate extends PromptTemplate {
    public CustomerSupportTemplate() {
        super(
            "You are a customer support assistant. Help users with their questions about products.",
            "Provide clear step-by-step instructions when applicable.",
            List.of("productSearch", "troubleshooter", "ticketCreator")
        );
    }
    
    // Additional support-specific methods
    public McpResponse handleSupportQuery(McpClient client, String query, String productId) {
        return execute(client, "Product ID: " + productId + "\nQuery: " + query);
    }
}
```

### Python Prompt Template Implementation

```python
from mcp_client import McpClient
from typing import List, Dict, Any, Optional

class PromptTemplate:
    def __init__(
        self, 
        system_message: str, 
        response_format: Optional[str] = None,
        allowed_tools: Optional[List[str]] = None
    ):
        self.system_message = system_message
        self.response_format = response_format
        self.allowed_tools = allowed_tools or []
        
    async def execute(self, client: McpClient, user_query: str) -> Dict[str, Any]:
        # Build the complete prompt
        prompt_parts = [self.system_message]
        
        # Add tools information
        if self.allowed_tools:
            tool_text = "You have access to these tools:\n"
            for tool in self.allowed_tools:
                tool_text += f"- {tool}\n"
            prompt_parts.append(tool_text)
        
        # Add user query
        prompt_parts.append(f"User Query: {user_query}")
        
        # Add response format
        if self.response_format:
            prompt_parts.append(f"Response Format: {self.response_format}")
        
        # Join all parts
        final_prompt = "\n\n".join(prompt_parts)
        
        # Send request to MCP client
        response = await client.send_prompt(
            prompt=final_prompt,
            allowed_tools=self.allowed_tools
        )
        
        return response

# Example specialized template
class DataAnalysisTemplate(PromptTemplate):
    def __init__(self):
        super().__init__(
            system_message=(
                "You are a data analysis assistant. Help users analyze and "
                "visualize their data to extract meaningful insights."
            ),
            response_format=(
                "1. Summarize key insights\n"
                "2. Provide specific data points\n"
                "3. Suggest visualizations if appropriate"
            ),
            allowed_tools=["dataQuery", "dataStats", "chartGenerator"]
        )
    
    async def analyze_dataset(self, client: McpClient, dataset_name: str, analysis_goal: str):
        query = f"Dataset: {dataset_name}\nAnalysis goal: {analysis_goal}"
        return await self.execute(client, query)
```

## Designing MCP Workflows

MCP workflows combine multiple tools to accomplish complex tasks.

### Workflow Architecture

Effective MCP workflows include:
1. **Initial Request**: The user's query or task description
2. **Tool Planning**: Determining which tools are needed
3. **Sequential Execution**: Running tools in a logical order
4. **Result Integration**: Combining tool outputs into a coherent response

### .NET Workflow Example

```csharp
using Microsoft.Mcp.Client;
using Microsoft.Mcp.Workflows;
using System.Threading.Tasks;

namespace McpWorkflows
{
    public class DocumentAnalysisWorkflow : IMcpWorkflow
    {
        private readonly IMcpClient _mcpClient;
        
        public DocumentAnalysisWorkflow(IMcpClient mcpClient)
        {
            _mcpClient = mcpClient;
        }
        
        public async Task<WorkflowResult> ExecuteAsync(string documentUrl)
        {
            // Step 1: Extract text from document
            var extractResult = await _mcpClient.ExecuteToolAsync("documentExtractor", new {
                url = documentUrl
            });
            
            string documentText = extractResult.GetProperty("text").GetString();
            string documentTitle = extractResult.GetProperty("title").GetString();
            
            // Step 2: Analyze entities in the text
            var entityResult = await _mcpClient.ExecuteToolAsync("entityAnalyzer", new {
                text = documentText
            });
            
            // Step 3: Generate summary
            var summaryResult = await _mcpClient.ExecuteToolAsync("textSummarizer", new {
                text = documentText,
                maxLength = 200
            });
            
            string summary = summaryResult.GetProperty("summary").GetString();
            
            // Step 4: Ask model to create final analysis using all data
            var prompt = $@"
Document Title: {documentTitle}

Document Summary: {summary}

Key Entities: {entityResult.ToString()}

Based on the above information, provide a comprehensive analysis of this document.
Include the main themes, key entities, and any important relationships between concepts.
";
            
            var modelResponse = await _mcpClient.SendPromptAsync(prompt);
            
            // Return composite result
            return new WorkflowResult {
                Title = documentTitle,
                Summary = summary,
                Analysis = modelResponse.GeneratedText,
                Entities = entityResult,
                FullText = documentText
            };
        }
    }
}
```

### Java Workflow Example

```java
package com.example.mcp.workflows;

import com.mcp.client.McpClient;
import com.mcp.models.McpResponse;
import com.mcp.workflows.Workflow;
import com.mcp.workflows.WorkflowResult;

import java.util.HashMap;
import java.util.Map;

public class CustomerSupportWorkflow implements Workflow {
    private final McpClient mcpClient;
    
    public CustomerSupportWorkflow(McpClient mcpClient) {
        this.mcpClient = mcpClient;
    }
    
    public WorkflowResult execute(String customerQuery, String customerId) {
        WorkflowResult result = new WorkflowResult();
        
        try {
            // Step 1: Retrieve customer information
            Map<String, Object> customerParams = new HashMap<>();
            customerParams.put("customerId", customerId);
            
            Map<String, Object> customerData = mcpClient.executeTool(
                "customerLookup", 
                customerParams
            ).getResult();
            
            result.put("customerData", customerData);
            
            // Step 2: Search for relevant knowledge base articles
            Map<String, Object> kbParams = new HashMap<>();
            kbParams.put("query", customerQuery);
            kbParams.put("limit", 3);
            
            Map<String, Object> kbResults = mcpClient.executeTool(
                "knowledgeSearch", 
                kbParams
            ).getResult();
            
            result.put("knowledgeArticles", kbResults.get("articles"));
            
            // Step 3: Generate response for customer
            StringBuilder promptBuilder = new StringBuilder();
            promptBuilder.append("Customer query: ").append(customerQuery).append("\n\n");
            promptBuilder.append("Customer information:\n");
            promptBuilder.append("- Name: ").append(customerData.get("name")).append("\n");
            promptBuilder.append("- Account type: ").append(customerData.get("accountType")).append("\n");
            promptBuilder.append("- Subscription status: ").append(customerData.get("subscriptionStatus")).append("\n\n");
            
            promptBuilder.append("Relevant knowledge articles:\n");
            for (Map<String, Object> article : (List<Map<String, Object>>) kbResults.get("articles")) {
                promptBuilder.append("- Title: ").append(article.get("title")).append("\n");
                promptBuilder.append("  Summary: ").append(article.get("summary")).append("\n\n");
            }
            
            promptBuilder.append("Based on the above information, provide a helpful response to the customer's query.");
            
            McpResponse response = mcpClient.sendPrompt(promptBuilder.toString());
            
            result.put("response", response.getGeneratedText());
            
            return result;
        } catch (Exception e) {
            result.put("error", e.getMessage());
            return result;
        }
    }
}
```

### Python Workflow Example

```python
from mcp_client import McpClient
from mcp_workflows import Workflow, WorkflowResult
import asyncio
from typing import Dict, Any

class DataProcessingWorkflow(Workflow):
    def __init__(self, mcp_client: McpClient):
        self.client = mcp_client
    
    async def execute(self, dataset_url: str, analysis_type: str) -> WorkflowResult:
        result = WorkflowResult()
        
        try:
            # Step 1: Download and validate dataset
            data_params = {
                "url": dataset_url,
                "validate": True
            }
            
            data_result = await self.client.execute_tool(
                "datasetLoader", 
                data_params
            )
            
            dataset_id = data_result.result.get("datasetId")
            result.add_result("dataset", data_result.result)
            
            # Step 2: Run data preprocessing
            preprocess_params = {
                "datasetId": dataset_id,
                "operations": ["removeNulls", "normalization"]
            }
            
            preprocess_result = await self.client.execute_tool(
                "dataPreprocessor", 
                preprocess_params
            )
            
            processed_dataset_id = preprocess_result.result.get("processedDatasetId")
            result.add_result("preprocessing", preprocess_result.result)
            
            # Step 3: Run selected analysis
            analysis_params = {
                "datasetId": processed_dataset_id,
                "analysisType": analysis_type,
                "includeVisualization": True
            }
            
            analysis_result = await self.client.execute_tool(
                "dataAnalyzer", 
                analysis_params
            )
            
            result.add_result("analysis", analysis_result.result)
            
            # Step 4: Generate insights summary
            prompt = f"""
            Dataset: {dataset_url}
            Analysis type: {analysis_type}
            
            Preprocessing results:
            - Rows processed: {preprocess_result.result.get('rowsProcessed')}
            - Null values removed: {preprocess_result.result.get('nullsRemoved')}
            - Columns normalized: {preprocess_result.result.get('normalizedColumns')}
            
            Analysis results:
            {analysis_result.result}
            
            Based on the preprocessing and analysis results, provide a comprehensive summary
            of the key insights from this dataset. Explain the significance of the main findings
            and suggest follow-up analyses that might be valuable.
            """
            
            summary_response = await self.client.send_prompt(prompt)
            result.add_result("insights", {"summary": summary_response.generated_text})
            
            return result
        
        except Exception as e:
            result.add_error(str(e))
            return result
```

## Optimizing MCP Implementations for Performance and Reliability

### Key Features

- Strong typing and async/await support
- Integration with ASP.NET Core middleware
- Built-in DI container integration
- Streaming response support

## Integrating MCP with Azure API Management

Azure API Management (APIM) provides a robust platform for publishing, securing, and managing MCP servers. This integration offers benefits such as authentication, rate limiting, analytics, and more.

### Setting Up MCP Endpoints in Azure API Management

To integrate your MCP server with Azure API Management:

1. **Create an API Management Instance**:
   ```bash
   az apim create --name "mcp-api-management" --resource-group "mcp-resources" --publisher-name "Your Organization" --publisher-email "admin@example.com" --sku-name "Developer"
   ```

2. **Import MCP APIs with OpenAPI Specification**:
   Create an OpenAPI specification for your MCP server endpoints and import it into API Management.

   ```json
   {
     "openapi": "3.0.0",
     "info": {
       "title": "MCP Server API",
       "version": "1.0.0"
     },
     "paths": {
       "/mcp/v1/tool-list": {
         "get": {
           "summary": "Get available tools",
           "responses": {
             "200": {
               "description": "List of available tools"
             }
           }
         }
       },
       "/mcp/v1/generate": {
         "post": {
           "summary": "Generate content with tool access",
           "requestBody": {
             "content": {
               "application/json": {
                 "schema": {
                   "type": "object",
                   "properties": {
                     "prompt": {
                       "type": "string"
                     },
                     "allowedTools": {
                       "type": "array",
                       "items": {
                         "type": "string"
                       }
                     }
                   }
                 }
               }
             }
           },
           "responses": {
             "200": {
               "description": "Generated content"
             }
           }
         }
       }
     }
   }
   ```

3. **Configure Policies for Authentication and Rate Limiting**:

   ```xml
   <policies>
     <inbound>
       <base />
       <authentication-managed-identity resource="https://your-mcp-server.example.com" />
       <rate-limit calls="5" renewal-period="60" />
       <cors>
         <allowed-origins>
           <origin>https://your-client-app.example.com</origin>
         </allowed-origins>
         <allowed-methods>
           <method>GET</method>
           <method>POST</method>
         </allowed-methods>
       </cors>
     </inbound>
   </policies>
   ```

### Implementing MCP with Azure Functions

Azure Functions can serve as lightweight MCP tools or even host an entire MCP server:

```csharp
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Mcp.Server;
using Microsoft.Mcp.Tools;
using System.Threading.Tasks;

namespace MCP.AzureFunctions
{
    public class McpServerFunctions
    {
        private readonly IMcpServer _mcpServer;
        
        public McpServerFunctions(IMcpServer mcpServer)
        {
            _mcpServer = mcpServer;
        }
        
        [FunctionName("GenerateContent")]
        public async Task<IActionResult> GenerateContent(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "mcp/v1/generate")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Processing MCP generate content request");
            
            try
            {
                // Deserialize the request
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var mcpRequest = JsonSerializer.Deserialize<McpRequest>(requestBody);
                
                // Process the request through the MCP server
                var response = await _mcpServer.ProcessRequestAsync(mcpRequest);
                
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error processing MCP request");
                return new StatusCodeResult(500);
            }
        }
        
        [FunctionName("GetToolList")]
        public IActionResult GetToolList(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "mcp/v1/tool-list")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Processing MCP tool list request");
            
            try
            {
                var tools = _mcpServer.GetAvailableTools();
                return new OkObjectResult(tools);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error getting MCP tool list");
                return new StatusCodeResult(500);
            }
        }
    }
}
```

### Scaling MCP with Azure Kubernetes Service

For high-performance MCP implementations, Azure Kubernetes Service (AKS) provides container orchestration:

```yaml
# mcp-deployment.yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: mcp-server
spec:
  replicas: 3
  selector:
    matchLabels:
      app: mcp-server
  template:
    metadata:
      labels:
        app: mcp-server
    spec:
      containers:
      - name: mcp-server
        image: mcpregistry.azurecr.io/mcp-server:v1.0
        ports:
        - containerPort: 80
        resources:
          requests:
            memory: "512Mi"
            cpu: "500m"
          limits:
            memory: "1Gi"
            cpu: "1000m"
        env:
        - name: ASPNETCORE_ENVIRONMENT
          value: "Production"
        - name: ConnectionStrings__Storage
          valueFrom:
            secretKeyRef:
              name: mcp-secrets
              key: storage-connection
---
apiVersion: v1
kind: Service
metadata:
  name: mcp-server-service
spec:
  selector:
    app: mcp-server
  ports:
  - port: 80
    targetPort: 80
  type: LoadBalancer
```

Deploy with:
```bash
kubectl apply -f mcp-deployment.yaml
```

### Monitoring MCP Performance with Azure Monitor

Configure Application Insights to monitor MCP performance metrics:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Add Application Insights
    services.AddApplicationInsightsTelemetry();
    
    // Add MCP server with configuration
    services.AddMcpServer(options => {
        options.ServerName = "Azure MCP Server";
        options.ServerVersion = "1.0.0";
        options.MaxConcurrentRequests = 10;
        options.EnableStreamingResponses = true;
    });
    
    // Add custom telemetry for MCP
    services.AddSingleton<ITelemetryInitializer, McpTelemetryInitializer>();
}
```

Custom telemetry for tracking MCP-specific metrics:

```csharp
public class McpTelemetryInitializer : ITelemetryInitializer
{
    public void Initialize(ITelemetry telemetry)
    {
        if (telemetry is RequestTelemetry requestTelemetry)
        {
            // Extract MCP-specific data from the current request
            var httpContext = HttpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                // Add MCP-specific properties
                if (httpContext.Request.Path.StartsWithSegments("/mcp/v1"))
                {
                    requestTelemetry.Properties["IsMcpRequest"] = "true";
                    
                    // Identify tool calls
                    if (httpContext.Request.Path.Value.Contains("/tool/"))
                    {
                        var toolName = httpContext.Request.Path.Value.Split("/").LastOrDefault();
                        requestTelemetry.Properties["McpToolName"] = toolName;
                    }
                }
            }
        }
    }
}
```

## Key Takeaways

- MCP SDKs provide language-specific tools for implementing robust MCP solutions
- The debugging and testing process is critical for reliable MCP applications
- Reusable prompt templates enable consistent AI interactions
- Well-designed workflows can orchestrate complex tasks using multiple tools
- Implementing MCP solutions requires consideration of security, performance, and error handling

## Exercise

Design a practical MCP workflow that addresses a real-world problem in your domain:

1. Identify 3-4 tools that would be useful for solving this problem
2. Create a workflow diagram showing how these tools interact
3. Implement a basic version of one of the tools using your preferred language
4. Create a prompt template that would help the model effectively use your tool

## Additional Resources


---

Next: [Advanced Topics](../04-AdvancedTopics/README.md)