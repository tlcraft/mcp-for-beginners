<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "73240f845b99df9401fffd21c09a5f7b",
  "translation_date": "2025-07-16T23:36:08+00:00",
  "source_file": "05-AdvancedTopics/mcp-integration/README.md",
  "language_code": "ar"
}
-->
# التكامل المؤسسي

عند بناء خوادم MCP في بيئة مؤسسية، غالبًا ما تحتاج إلى التكامل مع منصات وخدمات الذكاء الاصطناعي الموجودة. يغطي هذا القسم كيفية دمج MCP مع أنظمة المؤسسات مثل Azure OpenAI وMicrosoft AI Foundry، مما يتيح قدرات ذكاء اصطناعي متقدمة وتنظيم الأدوات.

## المقدمة

في هذا الدرس، ستتعلم كيفية دمج بروتوكول سياق النموذج (MCP) مع أنظمة الذكاء الاصطناعي المؤسسية، مع التركيز على Azure OpenAI وMicrosoft AI Foundry. تتيح هذه التكاملات الاستفادة من نماذج وأدوات ذكاء اصطناعي قوية مع الحفاظ على مرونة وقابلية توسعة MCP.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:

- دمج MCP مع Azure OpenAI للاستفادة من قدرات الذكاء الاصطناعي الخاصة به.
- تنفيذ تنظيم أدوات MCP مع Azure OpenAI.
- دمج MCP مع Microsoft AI Foundry لتمكين قدرات وكيل ذكاء اصطناعي متقدمة.
- الاستفادة من Azure Machine Learning (ML) لتنفيذ خطوط أنابيب التعلم الآلي وتسجيل النماذج كأدوات MCP.

## تكامل Azure OpenAI

يوفر Azure OpenAI الوصول إلى نماذج ذكاء اصطناعي قوية مثل GPT-4 وغيرها. يتيح دمج MCP مع Azure OpenAI استخدام هذه النماذج مع الحفاظ على مرونة تنظيم أدوات MCP.

### تنفيذ C#

في هذا المقتطف البرمجي، نوضح كيفية دمج MCP مع Azure OpenAI باستخدام SDK الخاص بـ Azure OpenAI.

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

في الكود السابق قمنا بـ:

- تكوين عميل Azure OpenAI باستخدام نقطة النهاية، واسم النشر، ومفتاح API.
- إنشاء طريقة `GetCompletionWithToolsAsync` للحصول على الإكمالات مع دعم الأدوات.
- معالجة استدعاءات الأدوات في الاستجابة.

ننصحك بتنفيذ منطق التعامل مع الأدوات الفعلي بناءً على إعداد خادم MCP الخاص بك.

## تكامل Microsoft AI Foundry

يوفر Azure AI Foundry منصة لبناء ونشر وكلاء الذكاء الاصطناعي. يتيح دمج MCP مع AI Foundry الاستفادة من قدراته مع الحفاظ على مرونة MCP.

في الكود أدناه، نطور تكامل وكيل يعالج الطلبات ويتعامل مع استدعاءات الأدوات باستخدام MCP.

### تنفيذ Java

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

في الكود السابق قمنا بـ:

- إنشاء فئة `AIFoundryMcpBridge` التي تدمج بين AI Foundry وMCP.
- تنفيذ طريقة `processAgentRequest` التي تعالج طلب وكيل AI Foundry.
- معالجة استدعاءات الأدوات عن طريق تنفيذها عبر عميل MCP وإرسال النتائج مرة أخرى إلى وكيل AI Foundry.

## دمج MCP مع Azure ML

يتيح دمج MCP مع Azure Machine Learning (ML) الاستفادة من قدرات التعلم الآلي القوية في Azure مع الحفاظ على مرونة MCP. يمكن استخدام هذا التكامل لتنفيذ خطوط أنابيب التعلم الآلي، تسجيل النماذج كأدوات، وإدارة موارد الحوسبة.

### تنفيذ Python

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

في الكود السابق قمنا بـ:

- إنشاء فئة `EnterpriseAiIntegration` التي تدمج MCP مع Azure ML.
- تنفيذ طريقة `execute_ml_pipeline` التي تعالج بيانات الإدخال باستخدام أدوات MCP وترسل خط أنابيب ML إلى Azure ML.
- تنفيذ طريقة `register_ml_model_as_tool` التي تسجل نموذج Azure ML كأداة MCP، بما في ذلك إنشاء بيئة النشر وموارد الحوسبة اللازمة.
- مطابقة أنواع بيانات Azure ML مع أنواع مخطط JSON لتسجيل الأدوات.
- استخدام البرمجة غير المتزامنة للتعامل مع العمليات التي قد تستغرق وقتًا طويلاً مثل تنفيذ خط أنابيب ML وتسجيل النماذج.

## ما التالي

- [5.2 تعدد الوسائط](../mcp-multi-modality/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.