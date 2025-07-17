<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "73240f845b99df9401fffd21c09a5f7b",
  "translation_date": "2025-07-16T22:48:29+00:00",
  "source_file": "05-AdvancedTopics/mcp-integration/README.md",
  "language_code": "hi"
}
-->
# एंटरप्राइज इंटीग्रेशन

जब आप एंटरप्राइज संदर्भ में MCP सर्वर बनाते हैं, तो अक्सर आपको मौजूदा AI प्लेटफॉर्म और सेवाओं के साथ इंटीग्रेट करना पड़ता है। यह अनुभाग MCP को Azure OpenAI और Microsoft AI Foundry जैसे एंटरप्राइज सिस्टम के साथ इंटीग्रेट करने के तरीकों को कवर करता है, जिससे उन्नत AI क्षमताएं और टूल ऑर्केस्ट्रेशन संभव होता है।

## परिचय

इस पाठ में, आप सीखेंगे कि Model Context Protocol (MCP) को एंटरप्राइज AI सिस्टम के साथ कैसे इंटीग्रेट किया जाए, खासकर Azure OpenAI और Microsoft AI Foundry पर ध्यान केंद्रित करते हुए। ये इंटीग्रेशन आपको शक्तिशाली AI मॉडल और टूल्स का उपयोग करने की अनुमति देते हैं, साथ ही MCP की लचीलापन और विस्तारशीलता बनाए रखते हैं।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:

- MCP को Azure OpenAI के साथ इंटीग्रेट करना ताकि उसकी AI क्षमताओं का उपयोग किया जा सके।
- Azure OpenAI के साथ MCP टूल ऑर्केस्ट्रेशन को लागू करना।
- उन्नत AI एजेंट क्षमताओं के लिए MCP को Microsoft AI Foundry के साथ संयोजित करना।
- Azure Machine Learning (ML) का उपयोग करके ML पाइपलाइनों को निष्पादित करना और मॉडल्स को MCP टूल्स के रूप में रजिस्टर करना।

## Azure OpenAI इंटीग्रेशन

Azure OpenAI GPT-4 और अन्य जैसे शक्तिशाली AI मॉडल्स तक पहुंच प्रदान करता है। MCP को Azure OpenAI के साथ इंटीग्रेट करने से आप इन मॉडलों का उपयोग कर सकते हैं, साथ ही MCP के टूल ऑर्केस्ट्रेशन की लचीलापन बनाए रख सकते हैं।

### C# इम्प्लीमेंटेशन

इस कोड स्निपेट में, हम दिखाते हैं कि Azure OpenAI SDK का उपयोग करके MCP को Azure OpenAI के साथ कैसे इंटीग्रेट किया जाए।

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

पिछले कोड में हमने:

- Azure OpenAI क्लाइंट को endpoint, deployment name और API key के साथ कॉन्फ़िगर किया है।
- `GetCompletionWithToolsAsync` नामक एक मेथड बनाया है जो टूल सपोर्ट के साथ completion प्राप्त करता है।
- प्रतिक्रिया में टूल कॉल्स को हैंडल किया है।

आपको प्रोत्साहित किया जाता है कि आप अपने विशिष्ट MCP सर्वर सेटअप के आधार पर वास्तविक टूल हैंडलिंग लॉजिक को लागू करें।

## Microsoft AI Foundry इंटीग्रेशन

Azure AI Foundry AI एजेंट बनाने और डिप्लॉय करने के लिए एक प्लेटफॉर्म प्रदान करता है। MCP को AI Foundry के साथ इंटीग्रेट करने से आप इसकी क्षमताओं का लाभ उठा सकते हैं, साथ ही MCP की लचीलापन बनाए रख सकते हैं।

नीचे दिए गए कोड में, हम एक एजेंट इंटीग्रेशन विकसित करते हैं जो अनुरोधों को प्रोसेस करता है और MCP का उपयोग करके टूल कॉल्स को हैंडल करता है।

### Java इम्प्लीमेंटेशन

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

पिछले कोड में हमने:

- `AIFoundryMcpBridge` क्लास बनाया है जो AI Foundry और MCP दोनों के साथ इंटीग्रेट करता है।
- `processAgentRequest` नामक एक मेथड लागू किया है जो AI Foundry एजेंट अनुरोध को प्रोसेस करता है।
- टूल कॉल्स को MCP क्लाइंट के माध्यम से निष्पादित करके हैंडल किया है और परिणामों को AI Foundry एजेंट को वापस सबमिट किया है।

## MCP को Azure ML के साथ इंटीग्रेट करना

MCP को Azure Machine Learning (ML) के साथ इंटीग्रेट करने से आप Azure की शक्तिशाली ML क्षमताओं का लाभ उठा सकते हैं, साथ ही MCP की लचीलापन बनाए रख सकते हैं। इस इंटीग्रेशन का उपयोग ML पाइपलाइनों को निष्पादित करने, मॉडल्स को टूल्स के रूप में रजिस्टर करने, और कंप्यूट संसाधनों का प्रबंधन करने के लिए किया जा सकता है।

### Python इम्प्लीमेंटेशन

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

पिछले कोड में हमने:

- `EnterpriseAiIntegration` क्लास बनाया है जो MCP को Azure ML के साथ इंटीग्रेट करता है।
- `execute_ml_pipeline` मेथड लागू किया है जो इनपुट डेटा को MCP टूल्स के माध्यम से प्रोसेस करता है और Azure ML को ML पाइपलाइन सबमिट करता है।
- `register_ml_model_as_tool` मेथड लागू किया है जो Azure ML मॉडल को MCP टूल के रूप में रजिस्टर करता है, जिसमें आवश्यक डिप्लॉयमेंट एनवायरनमेंट और कंप्यूट संसाधनों का निर्माण शामिल है।
- टूल रजिस्ट्रेशन के लिए Azure ML डेटा टाइप्स को JSON स्कीमा टाइप्स से मैप किया है।
- संभावित लंबी अवधि वाली प्रक्रियाओं जैसे ML पाइपलाइन निष्पादन और मॉडल रजिस्ट्रेशन को संभालने के लिए असिंक्रोनस प्रोग्रामिंग का उपयोग किया है।

## आगे क्या है

- [5.2 मल्टी मोडैलिटी](../mcp-multi-modality/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।