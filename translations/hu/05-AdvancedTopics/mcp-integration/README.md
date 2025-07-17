<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "73240f845b99df9401fffd21c09a5f7b",
  "translation_date": "2025-07-17T10:24:54+00:00",
  "source_file": "05-AdvancedTopics/mcp-integration/README.md",
  "language_code": "hu"
}
-->
# Vállalati integráció

MCP szerverek építésekor vállalati környezetben gyakran szükség van meglévő AI platformokkal és szolgáltatásokkal való integrációra. Ez a rész bemutatja, hogyan lehet az MCP-t vállalati rendszerekkel, például az Azure OpenAI-val és a Microsoft AI Foundry-val összekapcsolni, lehetővé téve fejlett AI képességek és eszközök összehangolását.

## Bevezetés

Ebben a leckében megtanulod, hogyan integráld a Model Context Protocol-t (MCP) vállalati AI rendszerekkel, különös tekintettel az Azure OpenAI-ra és a Microsoft AI Foundry-ra. Ezek az integrációk lehetővé teszik, hogy kihasználd az erőteljes AI modellek és eszközök előnyeit, miközben megőrzöd az MCP rugalmasságát és bővíthetőségét.

## Tanulási célok

A lecke végére képes leszel:

- Integrálni az MCP-t az Azure OpenAI-val az AI képességek kihasználásához.
- Megvalósítani az MCP eszközök összehangolását az Azure OpenAI-val.
- Összekapcsolni az MCP-t a Microsoft AI Foundry-val fejlett AI ügynök funkciókért.
- Használni az Azure Machine Learning-et (ML) ML pipeline-ok futtatására és modellek MCP eszközként való regisztrálására.

## Azure OpenAI integráció

Az Azure OpenAI hozzáférést biztosít erőteljes AI modellekhez, mint például a GPT-4 és mások. Az MCP integrálása az Azure OpenAI-val lehetővé teszi ezen modellek használatát, miközben megőrzi az MCP eszköz összehangolásának rugalmasságát.

### C# megvalósítás

Ebben a kódrészletben bemutatjuk, hogyan integrálhatod az MCP-t az Azure OpenAI-val az Azure OpenAI SDK használatával.

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

A fenti kódban:

- Beállítottuk az Azure OpenAI klienst az endpoint, a telepítés neve és az API kulcs megadásával.
- Létrehoztunk egy `GetCompletionWithToolsAsync` metódust, amely eszköztámogatással kér be válaszokat.
- Kezeltük az eszközhívásokat a válaszban.

Javasoljuk, hogy a tényleges eszközkezelési logikát a saját MCP szervered beállításai alapján valósítsd meg.

## Microsoft AI Foundry integráció

Az Azure AI Foundry egy platform AI ügynökök építésére és telepítésére. Az MCP integrálása az AI Foundry-val lehetővé teszi képességeinek kihasználását, miközben megőrzi az MCP rugalmasságát.

Az alábbi kódban egy olyan ügynök integrációt fejlesztünk, amely feldolgozza a kéréseket és kezeli az eszközhívásokat az MCP segítségével.

### Java megvalósítás

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

A fenti kódban:

- Létrehoztunk egy `AIFoundryMcpBridge` osztályt, amely integrálja az AI Foundry-t és az MCP-t.
- Megvalósítottunk egy `processAgentRequest` metódust, amely feldolgozza az AI Foundry ügynök kéréseit.
- Kezeltük az eszközhívásokat az MCP kliensen keresztül, majd visszaküldtük az eredményeket az AI Foundry ügynöknek.

## MCP integrálása az Azure ML-lel

Az MCP integrálása az Azure Machine Learning-gel lehetővé teszi, hogy kihasználd az Azure erőteljes ML képességeit, miközben megőrzöd az MCP rugalmasságát. Ez az integráció használható ML pipeline-ok futtatására, modellek eszközként való regisztrálására és számítási erőforrások kezelésére.

### Python megvalósítás

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

A fenti kódban:

- Létrehoztunk egy `EnterpriseAiIntegration` osztályt, amely integrálja az MCP-t az Azure ML-lel.
- Megvalósítottunk egy `execute_ml_pipeline` metódust, amely bemeneti adatokat dolgoz fel MCP eszközök segítségével, majd ML pipeline-t indít az Azure ML-ben.
- Megvalósítottunk egy `register_ml_model_as_tool` metódust, amely egy Azure ML modellt regisztrál MCP eszközként, beleértve a szükséges telepítési környezet és számítási erőforrások létrehozását.
- Leképeztük az Azure ML adattípusokat JSON séma típusokra az eszközregisztrációhoz.
- Aszinkron programozást alkalmaztunk a potenciálisan hosszú ideig tartó műveletek, mint az ML pipeline futtatás és modellregisztráció kezelésére.

## Mi következik

- [5.2 Többmodalitás](../mcp-multi-modality/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.