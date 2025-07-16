<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "73240f845b99df9401fffd21c09a5f7b",
  "translation_date": "2025-07-16T22:25:37+00:00",
  "source_file": "05-AdvancedTopics/mcp-integration/README.md",
  "language_code": "fa"
}
-->
# یکپارچه‌سازی سازمانی

هنگام ساخت سرورهای MCP در محیط سازمانی، اغلب نیاز است که با پلتفرم‌ها و سرویس‌های هوش مصنوعی موجود ادغام شوید. این بخش نحوه یکپارچه‌سازی MCP با سیستم‌های سازمانی مانند Azure OpenAI و Microsoft AI Foundry را پوشش می‌دهد که امکان استفاده از قابلیت‌های پیشرفته هوش مصنوعی و هماهنگی ابزارها را فراهم می‌کند.

## مقدمه

در این درس، یاد می‌گیرید چگونه پروتکل مدل کانتکست (MCP) را با سیستم‌های هوش مصنوعی سازمانی، به ویژه Azure OpenAI و Microsoft AI Foundry، یکپارچه کنید. این ادغام‌ها به شما اجازه می‌دهند از مدل‌ها و ابزارهای قدرتمند هوش مصنوعی بهره‌مند شوید و در عین حال انعطاف‌پذیری و توسعه‌پذیری MCP را حفظ کنید.

## اهداف یادگیری

تا پایان این درس، قادر خواهید بود:

- MCP را با Azure OpenAI برای استفاده از قابلیت‌های هوش مصنوعی آن یکپارچه کنید.
- هماهنگی ابزارهای MCP را با Azure OpenAI پیاده‌سازی کنید.
- MCP را با Microsoft AI Foundry برای قابلیت‌های پیشرفته عامل‌های هوش مصنوعی ترکیب کنید.
- از Azure Machine Learning (ML) برای اجرای خطوط لوله یادگیری ماشین و ثبت مدل‌ها به عنوان ابزارهای MCP استفاده کنید.

## یکپارچه‌سازی Azure OpenAI

Azure OpenAI دسترسی به مدل‌های قدرتمند هوش مصنوعی مانند GPT-4 و دیگر مدل‌ها را فراهم می‌کند. ادغام MCP با Azure OpenAI به شما امکان می‌دهد از این مدل‌ها استفاده کنید و در عین حال انعطاف‌پذیری هماهنگی ابزارهای MCP را حفظ کنید.

### پیاده‌سازی C#

در این قطعه کد، نحوه یکپارچه‌سازی MCP با Azure OpenAI با استفاده از SDK مربوطه نشان داده شده است.

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

در کد بالا:

- کلاینت Azure OpenAI با نقطه انتهایی، نام استقرار و کلید API پیکربندی شده است.
- متدی به نام `GetCompletionWithToolsAsync` برای دریافت پاسخ‌ها با پشتیبانی از ابزارها ایجاد شده است.
- فراخوانی ابزارها در پاسخ مدیریت شده است.

شما تشویق می‌شوید که منطق واقعی مدیریت ابزارها را بر اساس تنظیمات خاص سرور MCP خود پیاده‌سازی کنید.

## یکپارچه‌سازی Microsoft AI Foundry

Azure AI Foundry بستری برای ساخت و استقرار عامل‌های هوش مصنوعی فراهم می‌کند. ادغام MCP با AI Foundry به شما امکان می‌دهد از قابلیت‌های آن بهره‌مند شوید و در عین حال انعطاف‌پذیری MCP را حفظ کنید.

در کد زیر، یکپارچه‌سازی عاملی توسعه داده شده است که درخواست‌ها را پردازش کرده و فراخوانی ابزارها را با استفاده از MCP مدیریت می‌کند.

### پیاده‌سازی Java

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

در کد بالا:

- کلاسی به نام `AIFoundryMcpBridge` ایجاد شده که با هر دو AI Foundry و MCP یکپارچه می‌شود.
- متدی به نام `processAgentRequest` پیاده‌سازی شده که درخواست عامل AI Foundry را پردازش می‌کند.
- فراخوانی ابزارها با اجرای آن‌ها از طریق کلاینت MCP و ارسال نتایج به عامل AI Foundry مدیریت شده است.

## یکپارچه‌سازی MCP با Azure ML

ادغام MCP با Azure Machine Learning (ML) به شما امکان می‌دهد از قابلیت‌های قدرتمند یادگیری ماشین Azure بهره‌مند شوید و در عین حال انعطاف‌پذیری MCP را حفظ کنید. این ادغام می‌تواند برای اجرای خطوط لوله یادگیری ماشین، ثبت مدل‌ها به عنوان ابزار و مدیریت منابع محاسباتی استفاده شود.

### پیاده‌سازی Python

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

در کد بالا:

- کلاسی به نام `EnterpriseAiIntegration` ایجاد شده که MCP را با Azure ML یکپارچه می‌کند.
- متدی به نام `execute_ml_pipeline` پیاده‌سازی شده که داده‌های ورودی را با استفاده از ابزارهای MCP پردازش کرده و یک خط لوله یادگیری ماشین را به Azure ML ارسال می‌کند.
- متدی به نام `register_ml_model_as_tool` پیاده‌سازی شده که یک مدل Azure ML را به عنوان ابزار MCP ثبت می‌کند، شامل ایجاد محیط استقرار و منابع محاسباتی لازم.
- نوع داده‌های Azure ML به انواع JSON schema برای ثبت ابزار نگاشت شده‌اند.
- از برنامه‌نویسی ناهمزمان برای مدیریت عملیات طولانی مانند اجرای خط لوله یادگیری ماشین و ثبت مدل استفاده شده است.

## مرحله بعد

- [5.2 چندرسانه‌ای](../mcp-multi-modality/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.