<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "73240f845b99df9401fffd21c09a5f7b",
  "translation_date": "2025-07-17T00:22:34+00:00",
  "source_file": "05-AdvancedTopics/mcp-integration/README.md",
  "language_code": "mr"
}
-->
# एंटरप्राइझ इंटिग्रेशन

एंटरप्राइझ संदर्भात MCP सर्व्हर्स तयार करताना, तुम्हाला अनेकदा विद्यमान AI प्लॅटफॉर्म्स आणि सेवा एकत्रित कराव्या लागतात. हा विभाग MCP ला Azure OpenAI आणि Microsoft AI Foundry सारख्या एंटरप्राइझ सिस्टम्सशी कसे इंटिग्रेट करायचे हे सांगतो, ज्यामुळे प्रगत AI क्षमता आणि टूल ऑर्केस्ट्रेशन शक्य होते.

## परिचय

या धड्यात, तुम्ही Model Context Protocol (MCP) ला एंटरप्राइझ AI सिस्टम्सशी कसे इंटिग्रेट करायचे हे शिकाल, विशेषतः Azure OpenAI आणि Microsoft AI Foundry वर लक्ष केंद्रित करून. या इंटिग्रेशन्समुळे तुम्हाला शक्तिशाली AI मॉडेल्स आणि टूल्सचा वापर करता येतो, तसेच MCP ची लवचिकता आणि विस्तार क्षमता टिकवून ठेवता येते.

## शिकण्याचे उद्दिष्ट

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:

- Azure OpenAI सोबत MCP इंटिग्रेट करून त्याच्या AI क्षमतांचा वापर करणे.
- Azure OpenAI सह MCP टूल ऑर्केस्ट्रेशन अंमलात आणणे.
- Microsoft AI Foundry सोबत MCP एकत्र करून प्रगत AI एजंट क्षमता मिळवणे.
- Azure Machine Learning (ML) चा वापर करून ML पाइपलाइन्स चालवणे आणि मॉडेल्सना MCP टूल्स म्हणून नोंदणी करणे.

## Azure OpenAI इंटिग्रेशन

Azure OpenAI GPT-4 आणि इतर शक्तिशाली AI मॉडेल्सचा प्रवेश प्रदान करते. MCP ला Azure OpenAI सोबत इंटिग्रेट केल्याने तुम्ही या मॉडेल्सचा वापर करू शकता आणि त्याचवेळी MCP च्या टूल ऑर्केस्ट्रेशनची लवचिकता टिकवू शकता.

### C# अंमलबजावणी

या कोड स्निपेटमध्ये, आम्ही Azure OpenAI SDK वापरून MCP कसे इंटिग्रेट करायचे हे दाखवले आहे.

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

वरील कोडमध्ये आम्ही:

- Azure OpenAI क्लायंटला endpoint, deployment name आणि API key सह कॉन्फिगर केले आहे.
- `GetCompletionWithToolsAsync` नावाची पद्धत तयार केली आहे जी टूल सपोर्टसह पूर्णता मिळवते.
- प्रतिसादात टूल कॉल्स हाताळले आहेत.

तुमच्या विशिष्ट MCP सर्व्हर सेटअपनुसार प्रत्यक्ष टूल हँडलिंग लॉजिक अंमलात आणण्याचा सल्ला दिला जातो.

## Microsoft AI Foundry इंटिग्रेशन

Azure AI Foundry AI एजंट तयार करण्यासाठी आणि तैनात करण्यासाठी एक प्लॅटफॉर्म प्रदान करते. MCP ला AI Foundry सोबत इंटिग्रेट केल्याने तुम्ही त्याच्या क्षमतांचा लाभ घेऊ शकता आणि MCP ची लवचिकता टिकवू शकता.

खालील कोडमध्ये, आम्ही एक एजंट इंटिग्रेशन विकसित केले आहे जे विनंत्या प्रक्रिया करते आणि MCP वापरून टूल कॉल्स हाताळते.

### Java अंमलबजावणी

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

वरील कोडमध्ये आम्ही:

- `AIFoundryMcpBridge` नावाचा एक क्लास तयार केला आहे जो AI Foundry आणि MCP दोन्हीशी इंटिग्रेट होतो.
- `processAgentRequest` नावाची पद्धत अंमलात आणली आहे जी AI Foundry एजंटची विनंती प्रक्रिया करते.
- टूल कॉल्स MCP क्लायंटद्वारे चालवून त्याचे परिणाम AI Foundry एजंटकडे परत पाठवले आहेत.

## MCP चे Azure ML सोबत इंटिग्रेशन

MCP ला Azure Machine Learning (ML) सोबत इंटिग्रेट केल्याने तुम्ही Azure च्या शक्तिशाली ML क्षमतांचा वापर करू शकता आणि MCP ची लवचिकता टिकवू शकता. या इंटिग्रेशनचा वापर ML पाइपलाइन्स चालवण्यासाठी, मॉडेल्सना टूल्स म्हणून नोंदणी करण्यासाठी आणि कम्प्युट रिसोर्सेस व्यवस्थापित करण्यासाठी केला जाऊ शकतो.

### Python अंमलबजावणी

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

वरील कोडमध्ये आम्ही:

- `EnterpriseAiIntegration` नावाचा एक क्लास तयार केला आहे जो MCP ला Azure ML सोबत इंटिग्रेट करतो.
- `execute_ml_pipeline` नावाची पद्धत अंमलात आणली आहे जी इनपुट डेटा MCP टूल्स वापरून प्रक्रिया करते आणि Azure ML कडे ML पाइपलाइन सबमिट करते.
- `register_ml_model_as_tool` नावाची पद्धत तयार केली आहे जी Azure ML मॉडेलला MCP टूल म्हणून नोंदणी करते, ज्यात आवश्यक तैनातीचे वातावरण आणि कम्प्युट रिसोर्सेस तयार करणे समाविष्ट आहे.
- Azure ML डेटा प्रकारांना JSON स्कीमा प्रकारांशी मॅप केले आहे टूल नोंदणीसाठी.
- ML पाइपलाइन अंमलबजावणी आणि मॉडेल नोंदणीसारख्या दीर्घकालीन ऑपरेशन्ससाठी असिंक्रोनस प्रोग्रामिंग वापरले आहे.

## पुढे काय

- [5.2 मल्टी मोडॅलिटी](../mcp-multi-modality/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.