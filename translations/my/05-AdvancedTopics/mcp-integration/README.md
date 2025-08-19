<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f84eaea79c8fa9ab318a494f40891814",
<<<<<<< HEAD
  "translation_date": "2025-08-18T23:23:16+00:00",
=======
  "translation_date": "2025-08-18T18:45:04+00:00",
>>>>>>> origin/main
  "source_file": "05-AdvancedTopics/mcp-integration/README.md",
  "language_code": "my"
}
-->
<<<<<<< HEAD
# စီးပွားရေးလုပ်ငန်းအတွင်း ပေါင်းစည်းမှု
=======
# စီးပွားရေးလုပ်ငန်းများအတွက် ပေါင်းစည်းမှု
>>>>>>> origin/main

စီးပွားရေးလုပ်ငန်းအခြေအနေတွင် MCP Servers တည်ဆောက်ရာတွင် ရှိပြီးသား AI ပလက်ဖောင်းများနှင့် ဝန်ဆောင်မှုများနှင့် ပေါင်းစည်းရန် လိုအပ်တတ်ပါသည်။ ဒီအပိုင်းမှာ MCP ကို Azure OpenAI နှင့် Microsoft AI Foundry ကဲ့သို့သော စီးပွားရေးစနစ်များနှင့် ပေါင်းစည်းပုံကို ဖော်ပြထားပြီး အဆင့်မြင့် AI စွမ်းရည်များနှင့် ကိရိယာများကို စီမံခန့်ခွဲနိုင်စေရန် လမ်းညွှန်ထားပါသည်။

## အကျဉ်းချုပ်

<<<<<<< HEAD
ဒီသင်ခန်းစာမှာ Model Context Protocol (MCP) ကို စီးပွားရေး AI စနစ်များနှင့် ပေါင်းစည်းပုံကို သင်ယူပါမည်။ အဓိကအားဖြင့် Azure OpenAI နှင့် Microsoft AI Foundry ကို အခြေခံထားပြီး MCP ၏ လွယ်လွယ်ကူကူ ပြောင်းလွယ်ပြင်လွယ်မှုနှင့် တိုးချဲ့နိုင်စွမ်းကို ထိန်းသိမ်းထားရင်း အင်မတန် အားကောင်းသော AI မော်ဒယ်များနှင့် ကိရိယာများကို အသုံးချနိုင်စေပါသည်။
=======
ဒီသင်ခန်းစာမှာ Model Context Protocol (MCP) ကို စီးပွားရေး AI စနစ်များနှင့် ပေါင်းစည်းပုံကို သင်လေ့လာမည်ဖြစ်ပြီး Azure OpenAI နှင့် Microsoft AI Foundry ကို အဓိကထားပါမည်။ ဒီပေါင်းစည်းမှုများက အင်မတန်အစွမ်းထက်သော AI မော်ဒယ်များနှင့် ကိရိယာများကို အသုံးချနိုင်စေပြီး MCP ၏ လွတ်လပ်မှုနှင့် တိုးချဲ့နိုင်စွမ်းကို ထိန်းသိမ်းထားနိုင်စေပါသည်။
>>>>>>> origin/main

## သင်ခန်းစာရည်မှန်းချက်များ

ဒီသင်ခန်းစာအဆုံးတွင် သင်သည် အောက်ပါအရာများကို ပြုလုပ်နိုင်မည်ဖြစ်သည်-

- Azure OpenAI နှင့် MCP ကို ပေါင်းစည်းပြီး AI စွမ်းရည်များကို အသုံးချနိုင်ရန်။
- Azure OpenAI ဖြင့် MCP ကိရိယာ စီမံခန့်ခွဲမှုကို အကောင်အထည်ဖော်ရန်။
<<<<<<< HEAD
- Microsoft AI Foundry နှင့် MCP ကို ပေါင်းစည်းပြီး အဆင့်မြင့် AI Agent စွမ်းရည်များကို ပေါင်းစည်းရန်။
=======
- Microsoft AI Foundry နှင့် MCP ကို ပေါင်းစည်းပြီး အဆင့်မြင့် AI Agent စွမ်းရည်များကို အသုံးချရန်။
>>>>>>> origin/main
- Azure Machine Learning (ML) ကို အသုံးပြု၍ ML ပိုက်လိုင်းများကို အကောင်အထည်ဖော်ခြင်းနှင့် မော်ဒယ်များကို MCP ကိရိယာအဖြစ် မှတ်ပုံတင်ရန်။

## Azure OpenAI နှင့် ပေါင်းစည်းမှု

<<<<<<< HEAD
Azure OpenAI သည် GPT-4 ကဲ့သို့သော အင်မတန် အားကောင်းသော AI မော်ဒယ်များကို အသုံးပြုခွင့်ပေးသည်။ MCP နှင့် Azure OpenAI ကို ပေါင်းစည်းခြင်းဖြင့် ဒီမော်ဒယ်များကို အသုံးပြုနိုင်ရင်း MCP ၏ ကိရိယာ စီမံခန့်ခွဲမှု၏ လွယ်လွယ်ကူကူ ပြောင်းလွယ်ပြင်လွယ်မှုကို ထိန်းသိမ်းထားနိုင်သည်။

### C# အကောင်အထည်ဖော်မှု

ဒီကုဒ်နမူနာတွင် Azure OpenAI SDK ကို အသုံးပြု၍ MCP နှင့် Azure OpenAI ကို ပေါင်းစည်းပုံကို ဖော်ပြထားသည်။
=======
Azure OpenAI သည် GPT-4 ကဲ့သို့သော အင်မတန်အစွမ်းထက်သော AI မော်ဒယ်များကို အသုံးပြုခွင့်ပေးပါသည်။ MCP နှင့် Azure OpenAI ကို ပေါင်းစည်းခြင်းဖြင့် ဒီမော်ဒယ်များကို အသုံးချနိုင်စေပြီး MCP ၏ ကိရိယာ စီမံခန့်ခွဲမှု၏ လွတ်လပ်မှုကို ထိန်းသိမ်းထားနိုင်ပါသည်။

### C# အကောင်အထည်ဖော်မှု

ဒီကုဒ်နမူနာမှာ Azure OpenAI SDK ကို အသုံးပြု၍ MCP နှင့် Azure OpenAI ကို ပေါင်းစည်းပုံကို ဖော်ပြထားပါသည်။
>>>>>>> origin/main

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

အထက်ပါကုဒ်တွင်-

- Azure OpenAI client ကို endpoint, deployment name နှင့် API key ဖြင့် ပြင်ဆင်ထားသည်။
<<<<<<< HEAD
- `GetCompletionWithToolsAsync` ဟုခေါ်သော နည်းလမ်းတစ်ခုကို ဖန်တီးပြီး tool support ဖြင့် completions ရယူရန်။
- တုံ့ပြန်မှုအတွင်း tool calls ကို ကိုင်တွယ်ထားသည်။

သင့်ရဲ့ အထူး MCP server setup အပေါ် မူတည်ပြီး အမှန်တကယ် tool ကိုင်တွယ်မှု လုပ်ငန်းစဉ်ကို အကောင်အထည်ဖော်ရန် အားပေးပါသည်။
=======
- `GetCompletionWithToolsAsync` ဆိုသော method တစ်ခုကို ဖန်တီးပြီး tool support ဖြင့် completions ရယူရန်။
- တုံ့ပြန်မှုအတွင်း tool calls ကို ကိုင်တွယ်ထားသည်။

သင့်ရဲ့ MCP server setup အပေါ်မူတည်ပြီး အမှန်တကယ် tool ကိုင်တွယ်မှု logic ကို အကောင်အထည်ဖော်ရန် အကြံပြုပါသည်။
>>>>>>> origin/main

## Microsoft AI Foundry နှင့် ပေါင်းစည်းမှု

<<<<<<< HEAD
Azure AI Foundry သည် AI agents များကို တည်ဆောက်ခြင်းနှင့် တင်သွင်းခြင်းအတွက် ပလက်ဖောင်းတစ်ခုဖြစ်သည်။ MCP နှင့် AI Foundry ကို ပေါင်းစည်းခြင်းဖြင့် AI Foundry ၏ စွမ်းရည်များကို အသုံးချနိုင်ရင်း MCP ၏ လွယ်လွယ်ကူကူ ပြောင်းလွယ်ပြင်လွယ်မှုကို ထိန်းသိမ်းထားနိုင်သည်။

အောက်ပါကုဒ်တွင် MCP ကို အသုံးပြု၍ Agent integration တစ်ခုကို ဖန်တီးထားပြီး တောင်းဆိုမှုများကို ကိုင်တွယ်ခြင်းနှင့် tool calls ကို MCP ဖြင့် စီမံခန့်ခွဲပုံကို ဖော်ပြထားသည်။
=======
Azure AI Foundry သည် AI agents များကို တည်ဆောက်ခြင်းနှင့် တင်သွင်းခြင်းအတွက် ပလက်ဖောင်းတစ်ခုဖြစ်သည်။ MCP နှင့် AI Foundry ကို ပေါင်းစည်းခြင်းဖြင့် AI Foundry ၏ စွမ်းရည်များကို အသုံးချနိုင်စေပြီး MCP ၏ လွတ်လပ်မှုကို ထိန်းသိမ်းထားနိုင်ပါသည်။

အောက်ပါကုဒ်တွင် MCP ကို အသုံးပြု၍ Agent ပေါင်းစည်းမှုကို ဖော်ပြထားပါသည်။
>>>>>>> origin/main

### Java အကောင်အထည်ဖော်မှု

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

အထက်ပါကုဒ်တွင်-

<<<<<<< HEAD
- AI Foundry နှင့် MCP နှစ်ခုလုံးနှင့် ပေါင်းစည်းထားသော `AIFoundryMcpBridge` ဟုခေါ်သော class တစ်ခုကို ဖန်တီးထားသည်။
- AI Foundry agent တောင်းဆိုမှုကို ကိုင်တွယ်ရန် `processAgentRequest` ဟုခေါ်သော နည်းလမ်းတစ်ခုကို အကောင်အထည်ဖော်ထားသည်။
- MCP client ဖြင့် tool calls များကို အကောင်အထည်ဖော်ပြီး AI Foundry agent သို့ ပြန်လည်တင်သွင်းထားသည်။

## MCP နှင့် Azure ML ကို ပေါင်းစည်းခြင်း

MCP နှင့် Azure Machine Learning (ML) ကို ပေါင်းစည်းခြင်းဖြင့် Azure ၏ ML စွမ်းရည်များကို အသုံးချနိုင်ရင်း MCP ၏ လွယ်လွယ်ကူကူ ပြောင်းလွယ်ပြင်လွယ်မှုကို ထိန်းသိမ်းထားနိုင်သည်။ ဒီပေါင်းစည်းမှုသည် ML ပိုက်လိုင်းများကို အကောင်အထည်ဖော်ရန်၊ မော်ဒယ်များကို MCP ကိရိယာအဖြစ် မှတ်ပုံတင်ရန်နှင့် ကွန်ပျူတာ အရင်းအမြစ်များကို စီမံခန့်ခွဲရန် အသုံးဝင်သည်။
=======
- AI Foundry နှင့် MCP နှစ်ခုလုံးနှင့် ပေါင်းစည်းထားသော `AIFoundryMcpBridge` class တစ်ခုကို ဖန်တီးထားသည်။
- AI Foundry agent request ကို ကိုင်တွယ်ရန် `processAgentRequest` method ကို အကောင်အထည်ဖော်ထားသည်။
- MCP client ကို အသုံးပြု၍ tool calls များကို အကောင်အထည်ဖော်ပြီး AI Foundry agent သို့ ပြန်လည်တင်သွင်းထားသည်။

## MCP နှင့် Azure ML ပေါင်းစည်းမှု

MCP နှင့် Azure Machine Learning (ML) ကို ပေါင်းစည်းခြင်းဖြင့် Azure ၏ ML စွမ်းရည်များကို အသုံးချနိုင်စေပြီး MCP ၏ လွတ်လပ်မှုကို ထိန်းသိမ်းထားနိုင်ပါသည်။ ဒီပေါင်းစည်းမှုကို ML ပိုက်လိုင်းများကို အကောင်အထည်ဖော်ရန်၊ မော်ဒယ်များကို MCP ကိရိယာအဖြစ် မှတ်ပုံတင်ရန်နှင့် ကွန်ပျူတာအရင်းအမြစ်များကို စီမံခန့်ခွဲရန် အသုံးပြုနိုင်ပါသည်။
>>>>>>> origin/main

### Python အကောင်အထည်ဖော်မှု

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

အထက်ပါကုဒ်တွင်-

<<<<<<< HEAD
- MCP နှင့် Azure ML ကို ပေါင်းစည်းထားသော `EnterpriseAiIntegration` ဟုခေါ်သော class တစ်ခုကို ဖန်တီးထားသည်။
- MCP tools ကို အသုံးပြု၍ input data ကို စီမံခန့်ခွဲပြီး Azure ML သို့ ML pipeline တင်သွင်းရန် `execute_ml_pipeline` ဟုခေါ်သော နည်းလမ်းတစ်ခုကို အကောင်အထည်ဖော်ထားသည်။
- Azure ML မော်ဒယ်ကို MCP ကိရိယာအဖြစ် မှတ်ပုံတင်ရန် `register_ml_model_as_tool` ဟုခေါ်သော နည်းလမ်းတစ်ခုကို ဖန်တီးထားသည်။ 
- Tool မှတ်ပုံတင်ရန်အတွက် Azure ML data type များကို JSON schema type များနှင့် တွဲဖက်ထားသည်။
- ML pipeline အကောင်အထည်ဖော်မှုနှင့် မော်ဒယ်မှတ်ပုံတင်မှုကဲ့သို့သော ကြာရှည်တတ်သော လုပ်ငန်းစဉ်များကို ကိုင်တွယ်ရန် asynchronous programming ကို အသုံးပြုထားသည်။
=======
- MCP နှင့် Azure ML ကို ပေါင်းစည်းထားသော `EnterpriseAiIntegration` class တစ်ခုကို ဖန်တီးထားသည်။
- MCP ကိရိယာများကို အသုံးပြု၍ input data ကို ကိုင်တွယ်ပြီး Azure ML သို့ ML ပိုက်လိုင်းတင်သွင်းရန် `execute_ml_pipeline` method ကို အကောင်အထည်ဖော်ထားသည်။
- Azure ML မော်ဒယ်ကို MCP ကိရိယာအဖြစ် မှတ်ပုံတင်ရန် `register_ml_model_as_tool` method ကို အကောင်အထည်ဖော်ထားသည်။ 
- Tool မှတ်ပုံတင်မှုအတွက် Azure ML data type များကို JSON schema type များနှင့် တွဲဖက်ထားသည်။
- ML ပိုက်လိုင်းအကောင်အထည်ဖော်မှုနှင့် မော်ဒယ်မှတ်ပုံတင်မှုကဲ့သို့သော ကြာရှည်တတ်သော လုပ်ငန်းစဉ်များကို ကိုင်တွယ်ရန် asynchronous programming ကို အသုံးပြုထားသည်။
>>>>>>> origin/main

## နောက်တစ်ဆင့်

- [5.2 Multi modality](../mcp-multi-modality/README.md)

**အကြောင်းကြားချက်**:  
<<<<<<< HEAD
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူရင်းဘာသာစကားဖြင့် အာဏာတရားရှိသော အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော နားလည်မှုမှားများ သို့မဟုတ် အဓိပ္ပာယ်မှားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။
=======
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူရင်းဘာသာစကားဖြင့် အာဏာတရားရှိသော အရင်းအမြစ်အဖြစ် ရှုလေ့လာသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွတ်များ သို့မဟုတ် အနားယူမှုမှားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။
>>>>>>> origin/main
