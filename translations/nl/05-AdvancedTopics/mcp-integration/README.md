<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "73240f845b99df9401fffd21c09a5f7b",
  "translation_date": "2025-07-17T07:10:26+00:00",
  "source_file": "05-AdvancedTopics/mcp-integration/README.md",
  "language_code": "nl"
}
-->
# Enterprise Integratie

Bij het bouwen van MCP-servers in een zakelijke omgeving moet je vaak integreren met bestaande AI-platforms en -diensten. In deze sectie wordt uitgelegd hoe je MCP kunt integreren met enterprise-systemen zoals Azure OpenAI en Microsoft AI Foundry, zodat je geavanceerde AI-mogelijkheden en toolorkestratie kunt benutten.

## Introductie

In deze les leer je hoe je het Model Context Protocol (MCP) integreert met enterprise AI-systemen, met de focus op Azure OpenAI en Microsoft AI Foundry. Deze integraties stellen je in staat krachtige AI-modellen en tools te gebruiken, terwijl je de flexibiliteit en uitbreidbaarheid van MCP behoudt.

## Leerdoelen

Aan het einde van deze les kun je:

- MCP integreren met Azure OpenAI om gebruik te maken van de AI-mogelijkheden.
- MCP toolorkestratie implementeren met Azure OpenAI.
- MCP combineren met Microsoft AI Foundry voor geavanceerde AI-agent functionaliteiten.
- Azure Machine Learning (ML) inzetten voor het uitvoeren van ML-pijplijnen en het registreren van modellen als MCP-tools.

## Azure OpenAI Integratie

Azure OpenAI biedt toegang tot krachtige AI-modellen zoals GPT-4 en anderen. Door MCP te integreren met Azure OpenAI kun je deze modellen gebruiken en tegelijkertijd de flexibiliteit van MCP’s toolorkestratie behouden.

### C# Implementatie

In deze codevoorbeeld laten we zien hoe je MCP integreert met Azure OpenAI met behulp van de Azure OpenAI SDK.

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

In bovenstaande code hebben we:

- De Azure OpenAI-client geconfigureerd met de endpoint, deploymentnaam en API-sleutel.
- Een methode `GetCompletionWithToolsAsync` gemaakt om completions met toolondersteuning op te halen.
- Toolaanroepen in de respons afgehandeld.

Je wordt aangemoedigd om de daadwerkelijke toolafhandelingslogica te implementeren op basis van jouw specifieke MCP-serverconfiguratie.

## Microsoft AI Foundry Integratie

Azure AI Foundry biedt een platform voor het bouwen en inzetten van AI-agents. Door MCP te integreren met AI Foundry kun je de mogelijkheden ervan benutten en tegelijkertijd de flexibiliteit van MCP behouden.

In onderstaande code ontwikkelen we een Agent-integratie die verzoeken verwerkt en toolaanroepen afhandelt met MCP.

### Java Implementatie

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

In bovenstaande code hebben we:

- Een `AIFoundryMcpBridge`-klasse gemaakt die integreert met zowel AI Foundry als MCP.
- Een methode `processAgentRequest` geïmplementeerd die een AI Foundry-agentverzoek verwerkt.
- Toolaanroepen afgehandeld door deze uit te voeren via de MCP-client en de resultaten terug te sturen naar de AI Foundry-agent.

## MCP integreren met Azure ML

Door MCP te integreren met Azure Machine Learning (ML) kun je gebruikmaken van de krachtige ML-mogelijkheden van Azure, terwijl je de flexibiliteit van MCP behoudt. Deze integratie kan worden gebruikt om ML-pijplijnen uit te voeren, modellen als tools te registreren en compute-resources te beheren.

### Python Implementatie

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

In bovenstaande code hebben we:

- Een `EnterpriseAiIntegration`-klasse gemaakt die MCP integreert met Azure ML.
- Een `execute_ml_pipeline`-methode geïmplementeerd die inputdata verwerkt met MCP-tools en een ML-pijplijn indient bij Azure ML.
- Een `register_ml_model_as_tool`-methode geïmplementeerd die een Azure ML-model registreert als MCP-tool, inclusief het aanmaken van de benodigde deploymentomgeving en compute-resources.
- Azure ML-datatypes gemapt naar JSON-schema types voor toolregistratie.
- Asynchrone programmering gebruikt om mogelijk langdurige operaties zoals ML-pijplijnuitvoering en modelregistratie af te handelen.

## Wat nu?

- [5.2 Multi modality](../mcp-multi-modality/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.