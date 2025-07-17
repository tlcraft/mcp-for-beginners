<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "73240f845b99df9401fffd21c09a5f7b",
  "translation_date": "2025-07-17T12:38:21+00:00",
  "source_file": "05-AdvancedTopics/mcp-integration/README.md",
  "language_code": "my"
}
-->
# စီးပွားရေးလုပ်ငန်း ပေါင်းစည်းမှု

စီးပွားရေးလုပ်ငန်းအတွင်း MCP Server များကို တည်ဆောက်ရာတွင် ရှိပြီးသား AI ပလက်ဖောင်းများနှင့် ဝန်ဆောင်မှုများနှင့် ပေါင်းစည်းရန် လိုအပ်တတ်သည်။ ဤအပိုင်းတွင် MCP ကို Azure OpenAI နှင့် Microsoft AI Foundry ကဲ့သို့သော စီးပွားရေးစနစ်များနှင့် ပေါင်းစည်းခြင်းနည်းလမ်းများကို ဖော်ပြထားပြီး အဆင့်မြင့် AI စွမ်းရည်များနှင့် ကိရိယာများ စီမံခန့်ခွဲမှုကို ချိတ်ဆက်နိုင်စေသည်။

## နိဒါန်း

ဤသင်ခန်းစာတွင် Model Context Protocol (MCP) ကို စီးပွားရေး AI စနစ်များဖြစ်သည့် Azure OpenAI နှင့် Microsoft AI Foundry နှင့် ပေါင်းစည်းနည်းကို သင်ယူမည်ဖြစ်သည်။ ဤပေါင်းစည်းမှုများက သင်အား အင်အားကြီး AI မော်ဒယ်များနှင့် ကိရိယာများကို အသုံးပြုခွင့်ရရှိစေပြီး MCP ၏ လွတ်လပ်မှုနှင့် တိုးချဲ့နိုင်မှုကို ထိန်းသိမ်းပေးသည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာအပြီးတွင် သင်သည် -

- MCP ကို Azure OpenAI နှင့် ပေါင်းစည်းကာ ၎င်း၏ AI စွမ်းရည်များကို အသုံးပြုနိုင်မည်။
- Azure OpenAI နှင့် MCP ကိရိယာ စီမံခန့်ခွဲမှုကို အကောင်အထည်ဖော်နိုင်မည်။
- Microsoft AI Foundry နှင့် MCP ကို ပေါင်းစည်းကာ အဆင့်မြင့် AI အေးဂျင့် စွမ်းရည်များကို ရရှိနိုင်မည်။
- Azure Machine Learning (ML) ကို အသုံးပြုကာ ML ပိုင်းလိုင်းများကို အကောင်အထည်ဖော်ခြင်းနှင့် မော်ဒယ်များကို MCP ကိရိယာအဖြစ် မှတ်ပုံတင်နိုင်မည်။

## Azure OpenAI ပေါင်းစည်းမှု

Azure OpenAI သည် GPT-4 အပါအဝင် အင်အားကြီး AI မော်ဒယ်များကို အသုံးပြုခွင့်ပေးသည်။ MCP ကို Azure OpenAI နှင့် ပေါင်းစည်းခြင်းဖြင့် ၎င်းမော်ဒယ်များကို အသုံးပြုနိုင်ပြီး MCP ၏ ကိရိယာ စီမံခန့်ခွဲမှု လွတ်လပ်မှုကို ထိန်းသိမ်းနိုင်သည်။

### C# အကောင်အထည်ဖော်ခြင်း

ဤကုဒ်အပိုင်းတွင် Azure OpenAI SDK ကို အသုံးပြုကာ MCP ကို Azure OpenAI နှင့် ပေါင်းစည်းနည်းကို ပြသထားသည်။

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

အထက်ပါကုဒ်တွင် -

- Azure OpenAI client ကို endpoint, deployment name နှင့် API key ဖြင့် ပြင်ဆင်ထားသည်။
- ကိရိယာထောက်ပံ့မှုဖြင့် ပြည့်စုံမှုရယူရန် `GetCompletionWithToolsAsync` မက်သဒ်ကို ဖန်တီးထားသည်။
- တုံ့ပြန်ချက်တွင် ကိရိယာခေါ်ဆိုမှုများကို ကိုင်တွယ်ထားသည်။

သင့် MCP server အခြေအနေအရ ကိရိယာကိုင်တွယ်မှု လုပ်ဆောင်ချက်ကို ကိုယ်တိုင် အကောင်အထည်ဖော်ရန် အကြံပြုပါသည်။

## Microsoft AI Foundry ပေါင်းစည်းမှု

Azure AI Foundry သည် AI အေးဂျင့်များကို တည်ဆောက်ခြင်းနှင့် ဖြန့်ချိခြင်းအတွက် ပလက်ဖောင်းဖြစ်သည်။ MCP ကို AI Foundry နှင့် ပေါင်းစည်းခြင်းဖြင့် ၎င်း၏ စွမ်းရည်များကို အသုံးပြုနိုင်ပြီး MCP ၏ လွတ်လပ်မှုကို ထိန်းသိမ်းနိုင်သည်။

အောက်ပါကုဒ်တွင် MCP ကို အသုံးပြုကာ တောင်းဆိုမှုများကို ဆောင်ရွက်ပြီး ကိရိယာခေါ်ဆိုမှုများကို ကိုင်တွယ်သည့် Agent ပေါင်းစည်းမှုကို ဖန်တီးထားသည်။

### Java အကောင်အထည်ဖော်ခြင်း

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

အထက်ပါကုဒ်တွင် -

- AI Foundry နှင့် MCP နှစ်ခုလုံးနှင့် ပေါင်းစည်းထားသည့် `AIFoundryMcpBridge` class ကို ဖန်တီးထားသည်။
- AI Foundry agent တောင်းဆိုမှုကို ဆောင်ရွက်သည့် `processAgentRequest` မက်သဒ်ကို အကောင်အထည်ဖော်ထားသည်။
- MCP client မှတဆင့် ကိရိယာခေါ်ဆိုမှုများကို ဆောင်ရွက်ပြီး ရလဒ်များကို AI Foundry agent သို့ ပြန်လည်တင်ပြထားသည်။

## MCP ကို Azure ML နှင့် ပေါင်းစည်းခြင်း

MCP ကို Azure Machine Learning (ML) နှင့် ပေါင်းစည်းခြင်းဖြင့် Azure ၏ အင်အားကြီး ML စွမ်းရည်များကို အသုံးပြုနိုင်ပြီး MCP ၏ လွတ်လပ်မှုကို ထိန်းသိမ်းနိုင်သည်။ ဤပေါင်းစည်းမှုကို ML ပိုင်းလိုင်းများကို အကောင်အထည်ဖော်ခြင်း၊ မော်ဒယ်များကို ကိရိယာအဖြစ် မှတ်ပုံတင်ခြင်းနှင့် ကွန်ပျူတာ အရင်းအမြစ်များကို စီမံခန့်ခွဲရန် အသုံးပြုနိုင်သည်။

### Python အကောင်အထည်ဖော်ခြင်း

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

အထက်ပါကုဒ်တွင် -

- MCP နှင့် Azure ML ကို ပေါင်းစည်းထားသည့် `EnterpriseAiIntegration` class ကို ဖန်တီးထားသည်။
- MCP ကိရိယာများကို အသုံးပြုကာ အချက်အလက်များကို ဆောင်ရွက်ပြီး Azure ML သို့ ML ပိုင်းလိုင်းတစ်ခုကို တင်သွင်းသည့် `execute_ml_pipeline` မက်သဒ်ကို အကောင်အထည်ဖော်ထားသည်။
- Azure ML မော်ဒယ်ကို MCP ကိရိယာအဖြစ် မှတ်ပုံတင်ရန် လိုအပ်သည့် deployment ပတ်ဝန်းကျင်နှင့် ကွန်ပျူတာ အရင်းအမြစ်များ ဖန်တီးခြင်းအပါအဝင် `register_ml_model_as_tool` မက်သဒ်ကို ဖန်တီးထားသည်။
- Azure ML ဒေတာအမျိုးအစားများကို ကိရိယာမှတ်ပုံတင်မှုအတွက် JSON schema အမျိုးအစားများသို့ ပြောင်းလဲထားသည်။
- ML ပိုင်းလိုင်း အကောင်အထည်ဖော်ခြင်းနှင့် မော်ဒယ်မှတ်ပုံတင်ခြင်းကဲ့သို့ ကြာရှည်တည်ဆဲ လုပ်ငန်းစဉ်များကို ကိုင်တွယ်ရန် အချိန်မီ အလုပ်လုပ်စနစ် (asynchronous programming) ကို အသုံးပြုထားသည်။

## နောက်တစ်ဆင့်

- [5.2 Multi modality](../mcp-multi-modality/README.md)

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။