<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "73240f845b99df9401fffd21c09a5f7b",
  "translation_date": "2025-07-16T23:46:48+00:00",
  "source_file": "05-AdvancedTopics/mcp-integration/README.md",
  "language_code": "ur"
}
-->
# انٹرپرائز انٹیگریشن

جب آپ انٹرپرائز کے سیاق و سباق میں MCP سرورز بنا رہے ہوتے ہیں، تو اکثر آپ کو موجودہ AI پلیٹ فارمز اور خدمات کے ساتھ انٹیگریٹ کرنے کی ضرورت ہوتی ہے۔ یہ سیکشن MCP کو انٹرپرائز سسٹمز جیسے Azure OpenAI اور Microsoft AI Foundry کے ساتھ انٹیگریٹ کرنے کا طریقہ بتاتا ہے، جو جدید AI صلاحیتوں اور ٹول آرکیسٹریشن کو ممکن بناتا ہے۔

## تعارف

اس سبق میں، آپ سیکھیں گے کہ Model Context Protocol (MCP) کو انٹرپرائز AI سسٹمز کے ساتھ کیسے انٹیگریٹ کیا جائے، خاص طور پر Azure OpenAI اور Microsoft AI Foundry پر توجہ دیتے ہوئے۔ یہ انٹیگریشن آپ کو طاقتور AI ماڈلز اور ٹولز سے فائدہ اٹھانے کی اجازت دیتی ہے جبکہ MCP کی لچک اور توسیع پذیری کو برقرار رکھتی ہے۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ قابل ہوں گے کہ:

- MCP کو Azure OpenAI کے ساتھ انٹیگریٹ کریں تاکہ اس کی AI صلاحیتوں کا استعمال کیا جا سکے۔
- Azure OpenAI کے ساتھ MCP ٹول آرکیسٹریشن کو نافذ کریں۔
- MCP کو Microsoft AI Foundry کے ساتھ ملائیں تاکہ جدید AI ایجنٹ کی صلاحیتیں حاصل کی جا سکیں۔
- Azure Machine Learning (ML) کا فائدہ اٹھائیں تاکہ ML پائپ لائنز کو چلایا جا سکے اور ماڈلز کو MCP ٹولز کے طور پر رجسٹر کیا جا سکے۔

## Azure OpenAI انٹیگریشن

Azure OpenAI طاقتور AI ماڈلز جیسے GPT-4 اور دیگر تک رسائی فراہم کرتا ہے۔ MCP کو Azure OpenAI کے ساتھ انٹیگریٹ کرنے سے آپ ان ماڈلز کا استعمال کر سکتے ہیں جبکہ MCP کی ٹول آرکیسٹریشن کی لچک کو برقرار رکھا جا سکتا ہے۔

### C# نفاذ

اس کوڈ کے ٹکڑے میں، ہم دکھاتے ہیں کہ MCP کو Azure OpenAI SDK کے ذریعے کیسے انٹیگریٹ کیا جائے۔

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

پچھلے کوڈ میں ہم نے:

- Azure OpenAI کلائنٹ کو اینڈ پوائنٹ، ڈپلائمنٹ نام اور API کلید کے ساتھ ترتیب دیا۔
- `GetCompletionWithToolsAsync` نامی طریقہ بنایا تاکہ ٹول سپورٹ کے ساتھ کمپلیشن حاصل کی جا سکے۔
- جواب میں ٹول کالز کو ہینڈل کیا۔

آپ کو ترغیب دی جاتی ہے کہ اپنے مخصوص MCP سرور سیٹ اپ کی بنیاد پر اصل ٹول ہینڈلنگ لاجک نافذ کریں۔

## Microsoft AI Foundry انٹیگریشن

Azure AI Foundry AI ایجنٹس بنانے اور تعینات کرنے کے لیے ایک پلیٹ فارم فراہم کرتا ہے۔ MCP کو AI Foundry کے ساتھ انٹیگریٹ کرنے سے آپ اس کی صلاحیتوں سے فائدہ اٹھا سکتے ہیں جبکہ MCP کی لچک کو برقرار رکھا جا سکتا ہے۔

نیچے دیے گئے کوڈ میں، ہم ایک ایجنٹ انٹیگریشن تیار کرتے ہیں جو درخواستوں کو پروسیس کرتا ہے اور MCP کے ذریعے ٹول کالز کو ہینڈل کرتا ہے۔

### Java نفاذ

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

پچھلے کوڈ میں ہم نے:

- `AIFoundryMcpBridge` کلاس بنائی جو AI Foundry اور MCP دونوں کے ساتھ انٹیگریٹ کرتی ہے۔
- `processAgentRequest` نامی طریقہ نافذ کیا جو AI Foundry ایجنٹ کی درخواست کو پروسیس کرتا ہے۔
- ٹول کالز کو MCP کلائنٹ کے ذریعے چلایا اور نتائج AI Foundry ایجنٹ کو واپس بھیجے۔

## MCP کو Azure ML کے ساتھ انٹیگریٹ کرنا

MCP کو Azure Machine Learning (ML) کے ساتھ انٹیگریٹ کرنے سے آپ Azure کی طاقتور ML صلاحیتوں سے فائدہ اٹھا سکتے ہیں جبکہ MCP کی لچک کو برقرار رکھ سکتے ہیں۔ یہ انٹیگریشن ML پائپ لائنز کو چلانے، ماڈلز کو ٹولز کے طور پر رجسٹر کرنے، اور کمپیوٹ وسائل کو منظم کرنے کے لیے استعمال کی جا سکتی ہے۔

### Python نفاذ

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

پچھلے کوڈ میں ہم نے:

- `EnterpriseAiIntegration` کلاس بنائی جو MCP کو Azure ML کے ساتھ انٹیگریٹ کرتی ہے۔
- `execute_ml_pipeline` طریقہ نافذ کیا جو ان پٹ ڈیٹا کو MCP ٹولز کے ذریعے پروسیس کرتا ہے اور Azure ML کو ML پائپ لائن جمع کرواتا ہے۔
- `register_ml_model_as_tool` طریقہ نافذ کیا جو Azure ML ماڈل کو MCP ٹول کے طور پر رجسٹر کرتا ہے، جس میں ضروری ڈپلائمنٹ ماحول اور کمپیوٹ وسائل کی تخلیق شامل ہے۔
- Azure ML ڈیٹا ٹائپس کو JSON اسکیمہ ٹائپس کے ساتھ میپ کیا تاکہ ٹول رجسٹریشن ہو سکے۔
- طویل چلنے والے آپریشنز جیسے ML پائپ لائن کی عمل آوری اور ماڈل رجسٹریشن کے لیے asynchronous پروگرامنگ کا استعمال کیا۔

## آگے کیا ہے

- [5.2 ملٹی موڈیلٹی](../mcp-multi-modality/README.md)

**دستخطی نوٹ**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔