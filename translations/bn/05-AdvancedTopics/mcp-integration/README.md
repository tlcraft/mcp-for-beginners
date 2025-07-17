<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "73240f845b99df9401fffd21c09a5f7b",
  "translation_date": "2025-07-17T00:09:33+00:00",
  "source_file": "05-AdvancedTopics/mcp-integration/README.md",
  "language_code": "bn"
}
-->
# এন্টারপ্রাইজ ইন্টিগ্রেশন

এন্টারপ্রাইজ পরিবেশে MCP সার্ভার তৈরি করার সময়, প্রায়ই বিদ্যমান AI প্ল্যাটফর্ম এবং সার্ভিসের সাথে ইন্টিগ্রেট করতে হয়। এই অংশে MCP কে Azure OpenAI এবং Microsoft AI Foundry-এর মতো এন্টারপ্রাইজ সিস্টেমের সাথে কীভাবে সংযুক্ত করা যায় তা আলোচনা করা হয়েছে, যা উন্নত AI ক্ষমতা এবং টুল অর্কেস্ট্রেশন সক্ষম করে।

## পরিচিতি

এই পাঠে, আপনি শিখবেন কীভাবে Model Context Protocol (MCP) কে এন্টারপ্রাইজ AI সিস্টেমের সাথে ইন্টিগ্রেট করতে হয়, বিশেষ করে Azure OpenAI এবং Microsoft AI Foundry-এর সাথে। এই ইন্টিগ্রেশনগুলো আপনাকে শক্তিশালী AI মডেল এবং টুল ব্যবহার করার সুযোগ দেয়, সাথে MCP এর নমনীয়তা এবং সম্প্রসারণযোগ্যতা বজায় রাখে।

## শেখার উদ্দেশ্য

এই পাঠ শেষ করার পর, আপনি সক্ষম হবেন:

- MCP কে Azure OpenAI এর সাথে ইন্টিগ্রেট করে এর AI ক্ষমতাগুলো ব্যবহার করতে।
- Azure OpenAI এর সাথে MCP টুল অর্কেস্ট্রেশন বাস্তবায়ন করতে।
- Microsoft AI Foundry এর সাথে MCP মিলিয়ে উন্নত AI এজেন্ট ক্ষমতা অর্জন করতে।
- Azure Machine Learning (ML) ব্যবহার করে ML পাইপলাইন চালানো এবং মডেলগুলো MCP টুল হিসেবে নিবন্ধন করা।

## Azure OpenAI ইন্টিগ্রেশন

Azure OpenAI শক্তিশালী AI মডেল যেমন GPT-4 এবং অন্যান্য মডেলে অ্যাক্সেস প্রদান করে। MCP কে Azure OpenAI এর সাথে ইন্টিগ্রেট করলে আপনি এই মডেলগুলো ব্যবহার করতে পারবেন, সাথে MCP এর টুল অর্কেস্ট্রেশনের নমনীয়তাও বজায় থাকবে।

### C# বাস্তবায়ন

এই কোড স্নিপেটে আমরা দেখিয়েছি কীভাবে Azure OpenAI SDK ব্যবহার করে MCP কে Azure OpenAI এর সাথে ইন্টিগ্রেট করা যায়।

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

উপরের কোডে আমরা:

- Azure OpenAI ক্লায়েন্টকে endpoint, deployment name এবং API key দিয়ে কনফিগার করেছি।
- `GetCompletionWithToolsAsync` নামক একটি মেথড তৈরি করেছি যা টুল সাপোর্ট সহ কমপ্লিশন পায়।
- রেসপন্সে টুল কলগুলো হ্যান্ডেল করেছি।

আপনার MCP সার্ভারের নির্দিষ্ট সেটআপ অনুযায়ী প্রকৃত টুল হ্যান্ডলিং লজিক বাস্তবায়ন করার জন্য উৎসাহিত করা হচ্ছে।

## Microsoft AI Foundry ইন্টিগ্রেশন

Azure AI Foundry AI এজেন্ট তৈরি ও ডিপ্লয় করার জন্য একটি প্ল্যাটফর্ম প্রদান করে। MCP কে AI Foundry এর সাথে ইন্টিগ্রেট করলে আপনি এর ক্ষমতাগুলো ব্যবহার করতে পারবেন, সাথে MCP এর নমনীয়তাও বজায় থাকবে।

নিচের কোডে, আমরা একটি এজেন্ট ইন্টিগ্রেশন তৈরি করেছি যা MCP ব্যবহার করে রিকোয়েস্ট প্রক্রিয়াকরণ এবং টুল কল হ্যান্ডেল করে।

### Java বাস্তবায়ন

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

উপরের কোডে আমরা:

- একটি `AIFoundryMcpBridge` ক্লাস তৈরি করেছি যা AI Foundry এবং MCP উভয়ের সাথে ইন্টিগ্রেট করে।
- `processAgentRequest` নামক একটি মেথড বাস্তবায়ন করেছি যা AI Foundry এজেন্টের রিকোয়েস্ট প্রক্রিয়াকরণ করে।
- টুল কলগুলো MCP ক্লায়েন্টের মাধ্যমে এক্সিকিউট করে এবং ফলাফল AI Foundry এজেন্টে ফেরত পাঠায়।

## MCP কে Azure ML এর সাথে ইন্টিগ্রেট করা

MCP কে Azure Machine Learning (ML) এর সাথে ইন্টিগ্রেট করলে আপনি Azure এর শক্তিশালী ML ক্ষমতাগুলো ব্যবহার করতে পারবেন, সাথে MCP এর নমনীয়তাও বজায় থাকবে। এই ইন্টিগ্রেশন ML পাইপলাইন চালানো, মডেলগুলো টুল হিসেবে নিবন্ধন করা এবং কম্পিউট রিসোর্স ম্যানেজ করার জন্য ব্যবহার করা যেতে পারে।

### Python বাস্তবায়ন

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

উপরের কোডে আমরা:

- একটি `EnterpriseAiIntegration` ক্লাস তৈরি করেছি যা MCP কে Azure ML এর সাথে ইন্টিগ্রেট করে।
- `execute_ml_pipeline` মেথড বাস্তবায়ন করেছি যা ইনপুট ডেটা MCP টুল ব্যবহার করে প্রক্রিয়াকরণ করে এবং Azure ML এ ML পাইপলাইন সাবমিট করে।
- `register_ml_model_as_tool` মেথড তৈরি করেছি যা Azure ML মডেলকে MCP টুল হিসেবে নিবন্ধন করে, প্রয়োজনীয় ডিপ্লয়মেন্ট পরিবেশ এবং কম্পিউট রিসোর্স তৈরি সহ।
- Azure ML ডেটা টাইপগুলোকে JSON স্কিমা টাইপে ম্যাপ করেছি টুল নিবন্ধনের জন্য।
- অ্যাসিঙ্ক্রোনাস প্রোগ্রামিং ব্যবহার করেছি দীর্ঘমেয়াদী অপারেশন যেমন ML পাইপলাইন এক্সিকিউশন এবং মডেল নিবন্ধন হ্যান্ডেল করার জন্য।

## পরবর্তী ধাপ

- [5.2 Multi modality](../mcp-multi-modality/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।