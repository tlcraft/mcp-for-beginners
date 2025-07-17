<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "73240f845b99df9401fffd21c09a5f7b",
  "translation_date": "2025-07-17T01:28:10+00:00",
  "source_file": "05-AdvancedTopics/mcp-integration/README.md",
  "language_code": "tr"
}
-->
# Kurumsal Entegrasyon

Kurumsal bağlamda MCP Sunucuları oluştururken, genellikle mevcut AI platformları ve hizmetleriyle entegrasyon yapmanız gerekir. Bu bölüm, MCP'yi Azure OpenAI ve Microsoft AI Foundry gibi kurumsal sistemlerle nasıl entegre edeceğinizi, gelişmiş AI yetenekleri ve araç orkestrasyonu sağlamayı ele alır.

## Giriş

Bu derste, Model Context Protocol (MCP)'yi kurumsal AI sistemleriyle, özellikle Azure OpenAI ve Microsoft AI Foundry ile nasıl entegre edeceğinizi öğreneceksiniz. Bu entegrasyonlar, güçlü AI modelleri ve araçlarından faydalanmanızı sağlarken MCP'nin esnekliği ve genişletilebilirliğini korumanıza olanak tanır.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- MCP'yi Azure OpenAI ile entegre ederek AI yeteneklerinden faydalanmak.
- Azure OpenAI ile MCP araç orkestrasyonunu uygulamak.
- MCP'yi Microsoft AI Foundry ile birleştirerek gelişmiş AI ajan yetenekleri sağlamak.
- Azure Machine Learning (ML)'i kullanarak ML boru hatlarını çalıştırmak ve modelleri MCP araçları olarak kaydetmek.

## Azure OpenAI Entegrasyonu

Azure OpenAI, GPT-4 ve diğer güçlü AI modellerine erişim sağlar. MCP'yi Azure OpenAI ile entegre etmek, bu modelleri kullanmanızı sağlarken MCP'nin araç orkestrasyonu esnekliğini korur.

### C# Uygulaması

Bu kod örneğinde, Azure OpenAI SDK'sını kullanarak MCP'yi Azure OpenAI ile nasıl entegre edeceğimizi gösteriyoruz.

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

Yukarıdaki kodda:

- Azure OpenAI istemcisini uç nokta, dağıtım adı ve API anahtarı ile yapılandırdık.
- Araç desteği ile tamamlamalar almak için `GetCompletionWithToolsAsync` metodunu oluşturduk.
- Yanıttaki araç çağrılarını işledik.

Kendi MCP sunucu yapınıza göre gerçek araç işleme mantığını uygulamanız önerilir.

## Microsoft AI Foundry Entegrasyonu

Azure AI Foundry, AI ajanları oluşturmak ve dağıtmak için bir platform sağlar. MCP'yi AI Foundry ile entegre etmek, onun yeteneklerinden faydalanmanızı sağlarken MCP'nin esnekliğini korur.

Aşağıdaki kodda, MCP kullanarak istekleri işleyen ve araç çağrılarını yöneten bir Ajan entegrasyonu geliştiriyoruz.

### Java Uygulaması

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

Yukarıdaki kodda:

- AI Foundry ve MCP ile entegre olan `AIFoundryMcpBridge` sınıfını oluşturduk.
- AI Foundry ajan isteğini işleyen `processAgentRequest` metodunu uyguladık.
- Araç çağrılarını MCP istemcisi üzerinden çalıştırıp sonuçları AI Foundry ajanına geri gönderdik.

## MCP'yi Azure ML ile Entegre Etmek

MCP'yi Azure Machine Learning (ML) ile entegre etmek, Azure'un güçlü ML yeteneklerinden faydalanmanızı sağlarken MCP'nin esnekliğini korur. Bu entegrasyon, ML boru hatlarını çalıştırmak, modelleri araç olarak kaydetmek ve hesaplama kaynaklarını yönetmek için kullanılabilir.

### Python Uygulaması

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

Yukarıdaki kodda:

- MCP'yi Azure ML ile entegre eden `EnterpriseAiIntegration` sınıfını oluşturduk.
- Girdi verilerini MCP araçlarıyla işleyip Azure ML'ye bir ML boru hattı gönderen `execute_ml_pipeline` metodunu uyguladık.
- Azure ML modelini MCP aracı olarak kaydeden, gerekli dağıtım ortamı ve hesaplama kaynaklarını oluşturan `register_ml_model_as_tool` metodunu uyguladık.
- Araç kaydı için Azure ML veri tiplerini JSON şema tiplerine eşledik.
- ML boru hattı çalıştırma ve model kaydı gibi uzun sürebilecek işlemleri yönetmek için asenkron programlama kullandık.

## Sonraki Adımlar

- [5.2 Çoklu Mod](../mcp-multi-modality/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.