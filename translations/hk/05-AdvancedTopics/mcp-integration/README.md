<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "73240f845b99df9401fffd21c09a5f7b",
  "translation_date": "2025-07-16T21:14:38+00:00",
  "source_file": "05-AdvancedTopics/mcp-integration/README.md",
  "language_code": "hk"
}
-->
# 企業整合

在企業環境中構建 MCP 伺服器時，經常需要與現有的 AI 平台和服務整合。本節介紹如何將 MCP 與企業系統如 Azure OpenAI 和 Microsoft AI Foundry 整合，從而實現先進的 AI 功能和工具協調。

## 介紹

在本課程中，你將學習如何將 Model Context Protocol (MCP) 與企業 AI 系統整合，重點是 Azure OpenAI 和 Microsoft AI Foundry。這些整合讓你能夠利用強大的 AI 模型和工具，同時保持 MCP 的靈活性和可擴展性。

## 學習目標

完成本課程後，你將能夠：

- 將 MCP 與 Azure OpenAI 整合，利用其 AI 功能。
- 實現 MCP 與 Azure OpenAI 的工具協調。
- 將 MCP 與 Microsoft AI Foundry 結合，實現先進的 AI 代理功能。
- 利用 Azure Machine Learning (ML) 執行 ML 管線並將模型註冊為 MCP 工具。

## Azure OpenAI 整合

Azure OpenAI 提供了如 GPT-4 等強大 AI 模型的存取。將 MCP 與 Azure OpenAI 整合，讓你在保持 MCP 工具協調靈活性的同時，使用這些模型。

### C# 實作

在此程式碼片段中，我們示範如何使用 Azure OpenAI SDK 將 MCP 與 Azure OpenAI 整合。

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

在上述程式碼中，我們：

- 使用端點、部署名稱和 API 金鑰配置 Azure OpenAI 用戶端。
- 建立 `GetCompletionWithToolsAsync` 方法以支援工具的完成請求。
- 處理回應中的工具呼叫。

建議你根據具體的 MCP 伺服器設定，實作實際的工具處理邏輯。

## Microsoft AI Foundry 整合

Azure AI Foundry 提供一個構建和部署 AI 代理的平台。將 MCP 與 AI Foundry 整合，讓你能夠利用其功能，同時保持 MCP 的靈活性。

以下程式碼展示如何開發一個代理整合，使用 MCP 處理請求並處理工具呼叫。

### Java 實作

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

在上述程式碼中，我們：

- 建立了 `AIFoundryMcpBridge` 類別，整合 AI Foundry 與 MCP。
- 實作 `processAgentRequest` 方法，處理 AI Foundry 代理的請求。
- 透過 MCP 用戶端執行工具呼叫，並將結果提交回 AI Foundry 代理。

## 將 MCP 與 Azure ML 整合

將 MCP 與 Azure Machine Learning (ML) 整合，讓你能夠利用 Azure 強大的 ML 功能，同時保持 MCP 的靈活性。此整合可用於執行 ML 管線、將模型註冊為工具，以及管理運算資源。

### Python 實作

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

在上述程式碼中，我們：

- 建立了 `EnterpriseAiIntegration` 類別，整合 MCP 與 Azure ML。
- 實作 `execute_ml_pipeline` 方法，使用 MCP 工具處理輸入資料並提交 ML 管線至 Azure ML。
- 實作 `register_ml_model_as_tool` 方法，將 Azure ML 模型註冊為 MCP 工具，包括建立必要的部署環境和運算資源。
- 將 Azure ML 的資料類型映射到 JSON schema 類型以便工具註冊。
- 使用非同步程式設計來處理可能耗時的操作，如 ML 管線執行和模型註冊。

## 接下來的內容

- [5.2 多模態](../mcp-multi-modality/README.md)

**免責聲明**：  
本文件乃使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或誤釋承擔責任。