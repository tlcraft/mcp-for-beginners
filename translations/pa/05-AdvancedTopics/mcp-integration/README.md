<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "73240f845b99df9401fffd21c09a5f7b",
  "translation_date": "2025-07-17T00:48:51+00:00",
  "source_file": "05-AdvancedTopics/mcp-integration/README.md",
  "language_code": "pa"
}
-->
# ਐਂਟਰਪ੍ਰਾਈਜ਼ ਇੰਟੀਗ੍ਰੇਸ਼ਨ

ਜਦੋਂ ਤੁਸੀਂ ਐਂਟਰਪ੍ਰਾਈਜ਼ ਸੰਦਰਭ ਵਿੱਚ MCP ਸਰਵਰ ਬਣਾਉਂਦੇ ਹੋ, ਤਾਂ ਅਕਸਰ ਤੁਹਾਨੂੰ ਮੌਜੂਦਾ AI ਪਲੇਟਫਾਰਮਾਂ ਅਤੇ ਸੇਵਾਵਾਂ ਨਾਲ ਇੰਟੀਗ੍ਰੇਟ ਕਰਨ ਦੀ ਲੋੜ ਹੁੰਦੀ ਹੈ। ਇਹ ਭਾਗ ਦੱਸਦਾ ਹੈ ਕਿ MCP ਨੂੰ ਐਂਟਰਪ੍ਰਾਈਜ਼ ਸਿਸਟਮਾਂ ਜਿਵੇਂ ਕਿ Azure OpenAI ਅਤੇ Microsoft AI Foundry ਨਾਲ ਕਿਵੇਂ ਜੋੜਿਆ ਜਾ ਸਕਦਾ ਹੈ, ਜਿਸ ਨਾਲ ਅਡਵਾਂਸਡ AI ਸਮਰੱਥਾਵਾਂ ਅਤੇ ਟੂਲ ਆਰਕੀਸਟ੍ਰੇਸ਼ਨ ਸੰਭਵ ਹੁੰਦੀ ਹੈ।

## ਪਰਿਚਯ

ਇਸ ਪਾਠ ਵਿੱਚ, ਤੁਸੀਂ ਸਿੱਖੋਗੇ ਕਿ Model Context Protocol (MCP) ਨੂੰ ਐਂਟਰਪ੍ਰਾਈਜ਼ AI ਸਿਸਟਮਾਂ ਨਾਲ ਕਿਵੇਂ ਇੰਟੀਗ੍ਰੇਟ ਕਰਨਾ ਹੈ, ਖਾਸ ਕਰਕੇ Azure OpenAI ਅਤੇ Microsoft AI Foundry ਨਾਲ। ਇਹ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਤੁਹਾਨੂੰ ਸ਼ਕਤੀਸ਼ਾਲੀ AI ਮਾਡਲਾਂ ਅਤੇ ਟੂਲਾਂ ਦਾ ਲਾਭ ਉਠਾਉਣ ਦਿੰਦੇ ਹਨ, ਜਦਕਿ MCP ਦੀ ਲਚਕੀਲਾਪਣ ਅਤੇ ਵਿਸਥਾਰਯੋਗਤਾ ਬਰਕਰਾਰ ਰਹਿੰਦੀ ਹੈ।

## ਸਿੱਖਣ ਦੇ ਉਦੇਸ਼

ਇਸ ਪਾਠ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- MCP ਨੂੰ Azure OpenAI ਨਾਲ ਇੰਟੀਗ੍ਰੇਟ ਕਰਕੇ ਇਸ ਦੀ AI ਸਮਰੱਥਾਵਾਂ ਦਾ ਉਪਯੋਗ ਕਰਨਾ।
- Azure OpenAI ਨਾਲ MCP ਟੂਲ ਆਰਕੀਸਟ੍ਰੇਸ਼ਨ ਨੂੰ ਲਾਗੂ ਕਰਨਾ।
- MCP ਨੂੰ Microsoft AI Foundry ਨਾਲ ਜੋੜ ਕੇ ਅਡਵਾਂਸਡ AI ਏਜੰਟ ਸਮਰੱਥਾਵਾਂ ਪ੍ਰਾਪਤ ਕਰਨਾ।
- Azure Machine Learning (ML) ਦਾ ਲਾਭ ਉਠਾ ਕੇ ML ਪਾਈਪਲਾਈਨਾਂ ਚਲਾਉਣਾ ਅਤੇ ਮਾਡਲਾਂ ਨੂੰ MCP ਟੂਲਾਂ ਵਜੋਂ ਰਜਿਸਟਰ ਕਰਨਾ।

## Azure OpenAI ਇੰਟੀਗ੍ਰੇਸ਼ਨ

Azure OpenAI ਸ਼ਕਤੀਸ਼ਾਲੀ AI ਮਾਡਲਾਂ ਜਿਵੇਂ GPT-4 ਆਦਿ ਤੱਕ ਪਹੁੰਚ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ। MCP ਨੂੰ Azure OpenAI ਨਾਲ ਜੋੜਨ ਨਾਲ ਤੁਸੀਂ ਇਹ ਮਾਡਲ ਵਰਤ ਸਕਦੇ ਹੋ, ਜਦਕਿ MCP ਦੀ ਟੂਲ ਆਰਕੀਸਟ੍ਰੇਸ਼ਨ ਦੀ ਲਚਕੀਲਾਪਣ ਬਰਕਰਾਰ ਰਹਿੰਦੀ ਹੈ।

### C# ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ

ਇਸ ਕੋਡ ਸਨਿੱਪੇਟ ਵਿੱਚ, ਅਸੀਂ ਦਿਖਾਉਂਦੇ ਹਾਂ ਕਿ MCP ਨੂੰ Azure OpenAI SDK ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਕਿਵੇਂ ਇੰਟੀਗ੍ਰੇਟ ਕਰਨਾ ਹੈ।

```csharp
// .NET Azure OpenAI Integration
using Microsoft.Mcp.Client;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace EnterpriseIntegration
{
    public class AzureOpenAiMcpClient
    {
        private readonly string _endpoint;
        private readonly string _apiKey;
        private readonly string _deploymentName;
        
        public AzureOpenAiMcpClient(IConfiguration config)
        {
            _endpoint = config["AzureOpenAI:Endpoint"];
            _apiKey = config["AzureOpenAI:ApiKey"];
            _deploymentName = config["AzureOpenAI:DeploymentName"];
        }
        
        public async Task<string> GetCompletionWithToolsAsync(string prompt, params string[] allowedTools)
        {
            // Create OpenAI client
            var client = new OpenAIClient(new Uri(_endpoint), new AzureKeyCredential(_apiKey));
            
            // Create completion options with tools
            var completionOptions = new ChatCompletionsOptions
            {
                DeploymentName = _deploymentName,
                Messages = { new ChatMessage(ChatRole.User, prompt) },
                Temperature = 0.7f,
                MaxTokens = 800
            };
            
            // Add tool definitions
            foreach (var tool in allowedTools)
            {
                completionOptions.Tools.Add(new ChatCompletionsFunctionToolDefinition
                {
                    Name = tool,
                    // In a real implementation, you'd add the tool schema here
                });
            }
            
            // Get completion response
            var response = await client.GetChatCompletionsAsync(completionOptions);
            
            // Handle tool calls in the response
            foreach (var toolCall in response.Value.Choices[0].Message.ToolCalls)
            {
                // Implementation to handle Azure OpenAI tool calls with MCP
                // ...
            }
            
            return response.Value.Choices[0].Message.Content;
        }
    }
}
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- Azure OpenAI ਕਲਾਇੰਟ ਨੂੰ ਐਂਡਪੌਇੰਟ, ਡਿਪਲੋਇਮੈਂਟ ਨਾਮ ਅਤੇ API ਕੀ ਨਾਲ ਕਨਫਿਗਰ ਕੀਤਾ।
- `GetCompletionWithToolsAsync` ਮੈਥਡ ਬਣਾਈ ਜੋ ਟੂਲ ਸਹਾਇਤਾ ਨਾਲ ਕਮਪਲੀਸ਼ਨ ਪ੍ਰਾਪਤ ਕਰਦਾ ਹੈ।
- ਜਵਾਬ ਵਿੱਚ ਟੂਲ ਕਾਲਾਂ ਨੂੰ ਹੈਂਡਲ ਕੀਤਾ।

ਤੁਹਾਨੂੰ ਆਪਣੇ ਵਿਸ਼ੇਸ਼ MCP ਸਰਵਰ ਸੈਟਅਪ ਦੇ ਅਨੁਸਾਰ ਅਸਲ ਟੂਲ ਹੈਂਡਲਿੰਗ ਲਾਜਿਕ ਲਾਗੂ ਕਰਨ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ।

## Microsoft AI Foundry ਇੰਟੀਗ੍ਰੇਸ਼ਨ

Azure AI Foundry AI ਏਜੰਟ ਬਣਾਉਣ ਅਤੇ ਡਿਪਲੋਇ ਕਰਨ ਲਈ ਇੱਕ ਪਲੇਟਫਾਰਮ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ। MCP ਨੂੰ AI Foundry ਨਾਲ ਜੋੜਨ ਨਾਲ ਤੁਸੀਂ ਇਸ ਦੀਆਂ ਸਮਰੱਥਾਵਾਂ ਦਾ ਲਾਭ ਉਠਾ ਸਕਦੇ ਹੋ, ਜਦਕਿ MCP ਦੀ ਲਚਕੀਲਾਪਣ ਬਰਕਰਾਰ ਰਹਿੰਦੀ ਹੈ।

ਹੇਠਾਂ ਦਿੱਤੇ ਕੋਡ ਵਿੱਚ, ਅਸੀਂ ਇੱਕ ਏਜੰਟ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਵਿਕਸਿਤ ਕਰਦੇ ਹਾਂ ਜੋ MCP ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਬੇਨਤੀ ਪ੍ਰਕਿਰਿਆ ਕਰਦਾ ਹੈ ਅਤੇ ਟੂਲ ਕਾਲਾਂ ਨੂੰ ਹੈਂਡਲ ਕਰਦਾ ਹੈ।

### ਜਾਵਾ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ

```java
// Java AI Foundry Agent Integration
package com.example.mcp.enterprise;

import com.microsoft.aifoundry.AgentClient;
import com.microsoft.aifoundry.AgentToolResponse;
import com.microsoft.aifoundry.models.AgentRequest;
import com.microsoft.aifoundry.models.AgentResponse;
import com.mcp.client.McpClient;
import com.mcp.tools.ToolRequest;
import com.mcp.tools.ToolResponse;

public class AIFoundryMcpBridge {
    private final AgentClient agentClient;
    private final McpClient mcpClient;
    
    public AIFoundryMcpBridge(String aiFoundryEndpoint, String mcpServerUrl) {
        this.agentClient = new AgentClient(aiFoundryEndpoint);
        this.mcpClient = new McpClient.Builder()
            .setServerUrl(mcpServerUrl)
            .build();
    }
    
    public AgentResponse processAgentRequest(AgentRequest request) {
        // Process the AI Foundry Agent request
        AgentResponse initialResponse = agentClient.processRequest(request);
        
        // Check if the agent requested to use tools
        if (initialResponse.getToolCalls() != null && !initialResponse.getToolCalls().isEmpty()) {
            // For each tool call, route it to the appropriate MCP tool
            for (AgentToolCall toolCall : initialResponse.getToolCalls()) {
                String toolName = toolCall.getName();
                Map<String, Object> parameters = toolCall.getArguments();
                
                // Execute the tool using MCP
                ToolResponse mcpResponse = mcpClient.executeTool(toolName, parameters);
                
                // Create tool response for AI Foundry
                AgentToolResponse toolResponse = new AgentToolResponse(
                    toolCall.getId(),
                    mcpResponse.getResult()
                );
                
                // Submit tool response back to the agent
                initialResponse = agentClient.submitToolResponse(
                    request.getConversationId(), 
                    toolResponse
                );
            }
        }
        
        return initialResponse;
    }
}
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਇੱਕ `AIFoundryMcpBridge` ਕਲਾਸ ਬਣਾਈ ਜੋ AI Foundry ਅਤੇ MCP ਦੋਹਾਂ ਨਾਲ ਇੰਟੀਗ੍ਰੇਟ ਹੁੰਦੀ ਹੈ।
- `processAgentRequest` ਮੈਥਡ ਲਾਗੂ ਕੀਤਾ ਜੋ AI Foundry ਏਜੰਟ ਦੀ ਬੇਨਤੀ ਨੂੰ ਪ੍ਰਕਿਰਿਆ ਕਰਦਾ ਹੈ।
- ਟੂਲ ਕਾਲਾਂ ਨੂੰ MCP ਕਲਾਇੰਟ ਰਾਹੀਂ ਚਲਾਇਆ ਅਤੇ ਨਤੀਜੇ AI Foundry ਏਜੰਟ ਨੂੰ ਵਾਪਸ ਭੇਜੇ।

## MCP ਨੂੰ Azure ML ਨਾਲ ਇੰਟੀਗ੍ਰੇਟ ਕਰਨਾ

MCP ਨੂੰ Azure Machine Learning (ML) ਨਾਲ ਜੋੜਨ ਨਾਲ ਤੁਸੀਂ Azure ਦੀ ਸ਼ਕਤੀਸ਼ਾਲੀ ML ਸਮਰੱਥਾਵਾਂ ਦਾ ਲਾਭ ਉਠਾ ਸਕਦੇ ਹੋ, ਜਦਕਿ MCP ਦੀ ਲਚਕੀਲਾਪਣ ਬਰਕਰਾਰ ਰਹਿੰਦੀ ਹੈ। ਇਹ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ML ਪਾਈਪਲਾਈਨਾਂ ਚਲਾਉਣ, ਮਾਡਲਾਂ ਨੂੰ ਟੂਲ ਵਜੋਂ ਰਜਿਸਟਰ ਕਰਨ ਅਤੇ ਕੰਪਿਊਟ ਸਰੋਤਾਂ ਦਾ ਪ੍ਰਬੰਧਨ ਕਰਨ ਲਈ ਵਰਤੀ ਜਾ ਸਕਦੀ ਹੈ।

### ਪਾਇਥਨ ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ

```python
# Python Azure AI Integration
from mcp_client import McpClient
from azure.ai.ml import MLClient
from azure.identity import DefaultAzureCredential
from azure.ai.ml.entities import Environment, AmlCompute
import os
import asyncio

class EnterpriseAiIntegration:
    def __init__(self, mcp_server_url, subscription_id, resource_group, workspace_name):
        # Set up MCP client
        self.mcp_client = McpClient(server_url=mcp_server_url)
        
        # Set up Azure ML client
        self.credential = DefaultAzureCredential()
        self.ml_client = MLClient(
            self.credential,
            subscription_id,
            resource_group,
            workspace_name
        )
    
    async def execute_ml_pipeline(self, pipeline_name, input_data):
        """Executes an ML pipeline in Azure ML"""
        # First process the input data using MCP tools
        processed_data = await self.mcp_client.execute_tool(
            "dataPreprocessor",
            {
                "data": input_data,
                "operations": ["normalize", "clean", "transform"]
            }
        )
        
        # Submit the pipeline to Azure ML
        pipeline_job = self.ml_client.jobs.create_or_update(
            entity={
                "name": pipeline_name,
                "display_name": f"MCP-triggered {pipeline_name}",
                "experiment_name": "mcp-integration",
                "inputs": {
                    "processed_data": processed_data.result
                }
            }
        )
        
        # Return job information
        return {
            "job_id": pipeline_job.id,
            "status": pipeline_job.status,
            "creation_time": pipeline_job.creation_context.created_at
        }
    
    async def register_ml_model_as_tool(self, model_name, model_version="latest"):
        """Registers an Azure ML model as an MCP tool"""
        # Get model details
        if model_version == "latest":
            model = self.ml_client.models.get(name=model_name, label="latest")
        else:
            model = self.ml_client.models.get(name=model_name, version=model_version)
        
        # Create deployment environment
        env = Environment(
            name="mcp-model-env",
            conda_file="./environments/inference-env.yml"
        )
        
        # Set up compute
        compute = self.ml_client.compute.get("mcp-inference")
        
        # Deploy model as online endpoint
        deployment = self.ml_client.online_deployments.create_or_update(
            endpoint_name=f"mcp-{model_name}",
            deployment={
                "name": f"mcp-{model_name}-deployment",
                "model": model.id,
                "environment": env,
                "compute": compute,
                "scale_settings": {
                    "scale_type": "auto",
                    "min_instances": 1,
                    "max_instances": 3
                }
            }
        )
        
        # Create MCP tool schema based on model schema
        tool_schema = {
            "type": "object",
            "properties": {},
            "required": []
        }
        
        # Add input properties based on model schema
        for input_name, input_spec in model.signature.inputs.items():
            tool_schema["properties"][input_name] = {
                "type": self._map_ml_type_to_json_type(input_spec.type)
            }
            tool_schema["required"].append(input_name)
        
        # Register as MCP tool
        # In a real implementation, you would create a tool that calls the endpoint
        return {
            "model_name": model_name,
            "model_version": model.version,
            "endpoint": deployment.endpoint_uri,
            "tool_schema": tool_schema
        }
    
    def _map_ml_type_to_json_type(self, ml_type):
        """Maps ML data types to JSON schema types"""
        mapping = {
            "float": "number",
            "int": "integer",
            "bool": "boolean",
            "str": "string",
            "object": "object",
            "array": "array"
        }
        return mapping.get(ml_type, "string")
```

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ ਅਸੀਂ:

- ਇੱਕ `EnterpriseAiIntegration` ਕਲਾਸ ਬਣਾਈ ਜੋ MCP ਨੂੰ Azure ML ਨਾਲ ਜੋੜਦੀ ਹੈ।
- `execute_ml_pipeline` ਮੈਥਡ ਲਾਗੂ ਕੀਤਾ ਜੋ MCP ਟੂਲਾਂ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਇਨਪੁੱਟ ਡੇਟਾ ਨੂੰ ਪ੍ਰਕਿਰਿਆ ਕਰਦਾ ਹੈ ਅਤੇ Azure ML ਨੂੰ ML ਪਾਈਪਲਾਈਨ ਸੌਂਪਦਾ ਹੈ।
- `register_ml_model_as_tool` ਮੈਥਡ ਲਾਗੂ ਕੀਤਾ ਜੋ Azure ML ਮਾਡਲ ਨੂੰ MCP ਟੂਲ ਵਜੋਂ ਰਜਿਸਟਰ ਕਰਦਾ ਹੈ, ਜਿਸ ਵਿੱਚ ਜ਼ਰੂਰੀ ਡਿਪਲੋਇਮੈਂਟ ਵਾਤਾਵਰਣ ਅਤੇ ਕੰਪਿਊਟ ਸਰੋਤ ਬਣਾਉਣਾ ਸ਼ਾਮਲ ਹੈ।
- ਟੂਲ ਰਜਿਸਟ੍ਰੇਸ਼ਨ ਲਈ Azure ML ਡੇਟਾ ਕਿਸਮਾਂ ਨੂੰ JSON ਸਕੀਮਾ ਕਿਸਮਾਂ ਨਾਲ ਮੈਪ ਕੀਤਾ।
- ਲੰਬੇ ਸਮੇਂ ਚੱਲਣ ਵਾਲੀਆਂ ਕਾਰਵਾਈਆਂ ਜਿਵੇਂ ML ਪਾਈਪਲਾਈਨ ਚਲਾਉਣਾ ਅਤੇ ਮਾਡਲ ਰਜਿਸਟ੍ਰੇਸ਼ਨ ਲਈ ਅਸਿੰਕ੍ਰੋਨਸ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਦੀ ਵਰਤੋਂ ਕੀਤੀ।

## ਅਗਲਾ ਕੀ ਹੈ

- [5.2 ਮਲਟੀ ਮੋਡੈਲਿਟੀ](../mcp-multi-modality/README.md)

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।