<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "73240f845b99df9401fffd21c09a5f7b",
  "translation_date": "2025-07-17T11:14:08+00:00",
  "source_file": "05-AdvancedTopics/mcp-integration/README.md",
  "language_code": "ro"
}
-->
# Integrare Enterprise

Când construiești servere MCP în context enterprise, adesea este necesar să integrezi cu platforme și servicii AI existente. Această secțiune explică cum să integrezi MCP cu sisteme enterprise precum Azure OpenAI și Microsoft AI Foundry, oferind capabilități avansate de AI și orchestrare a uneltelor.

## Introducere

În această lecție vei învăța cum să integrezi Model Context Protocol (MCP) cu sisteme AI enterprise, concentrându-te pe Azure OpenAI și Microsoft AI Foundry. Aceste integrări îți permit să folosești modele și unelte AI puternice, păstrând în același timp flexibilitatea și extensibilitatea MCP.

## Obiective de învățare

La finalul acestei lecții vei putea:

- Integra MCP cu Azure OpenAI pentru a folosi capabilitățile sale AI.
- Implementa orchestrarea uneltelor MCP cu Azure OpenAI.
- Combina MCP cu Microsoft AI Foundry pentru capabilități avansate de agenți AI.
- Folosi Azure Machine Learning (ML) pentru a executa pipeline-uri ML și a înregistra modele ca unelte MCP.

## Integrarea Azure OpenAI

Azure OpenAI oferă acces la modele AI puternice precum GPT-4 și altele. Integrarea MCP cu Azure OpenAI îți permite să folosești aceste modele, păstrând flexibilitatea orchestrării uneltelor MCP.

### Implementare C#

În acest fragment de cod demonstrăm cum să integrezi MCP cu Azure OpenAI folosind SDK-ul Azure OpenAI.

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

În codul de mai sus am:

- Configurat clientul Azure OpenAI cu endpoint-ul, numele implementării și cheia API.
- Creat o metodă `GetCompletionWithToolsAsync` pentru a obține completări cu suport pentru unelte.
- Gestionat apelurile către unelte în răspuns.

Ești încurajat să implementezi logica efectivă de gestionare a uneltelor în funcție de configurația specifică a serverului tău MCP.

## Integrarea Microsoft AI Foundry

Azure AI Foundry oferă o platformă pentru construirea și implementarea agenților AI. Integrarea MCP cu AI Foundry îți permite să valorifici capabilitățile sale, păstrând flexibilitatea MCP.

În codul de mai jos dezvoltăm o integrare Agent care procesează cereri și gestionează apeluri către unelte folosind MCP.

### Implementare Java

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

În codul de mai sus am:

- Creat o clasă `AIFoundryMcpBridge` care integrează atât AI Foundry, cât și MCP.
- Implementat o metodă `processAgentRequest` care procesează o cerere a unui agent AI Foundry.
- Gestionat apelurile către unelte executându-le prin clientul MCP și trimițând rezultatele înapoi agentului AI Foundry.

## Integrarea MCP cu Azure ML

Integrarea MCP cu Azure Machine Learning (ML) îți permite să folosești capabilitățile puternice ML ale Azure, păstrând flexibilitatea MCP. Această integrare poate fi folosită pentru a executa pipeline-uri ML, a înregistra modele ca unelte și a gestiona resursele de calcul.

### Implementare Python

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

În codul de mai sus am:

- Creat o clasă `EnterpriseAiIntegration` care integrează MCP cu Azure ML.
- Implementat o metodă `execute_ml_pipeline` care procesează datele de intrare folosind uneltele MCP și trimite un pipeline ML către Azure ML.
- Implementat o metodă `register_ml_model_as_tool` care înregistrează un model Azure ML ca unealtă MCP, inclusiv crearea mediului de implementare și a resurselor de calcul necesare.
- Mapat tipurile de date Azure ML la tipuri JSON schema pentru înregistrarea uneltelor.
- Folosit programare asincronă pentru a gestiona operațiuni care pot dura mult, precum execuția pipeline-urilor ML și înregistrarea modelelor.

## Ce urmează

- [5.2 Multi modality](../mcp-multi-modality/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.