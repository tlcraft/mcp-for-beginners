<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "73240f845b99df9401fffd21c09a5f7b",
  "translation_date": "2025-07-17T05:59:19+00:00",
  "source_file": "05-AdvancedTopics/mcp-integration/README.md",
  "language_code": "th"
}
-->
# การผสานรวมในองค์กร

เมื่อสร้าง MCP Servers ในบริบทขององค์กร คุณมักจะต้องผสานรวมกับแพลตฟอร์มและบริการ AI ที่มีอยู่แล้ว ส่วนนี้จะอธิบายวิธีการผสานรวม MCP กับระบบองค์กร เช่น Azure OpenAI และ Microsoft AI Foundry เพื่อเปิดใช้งานความสามารถ AI ขั้นสูงและการจัดการเครื่องมือ

## บทนำ

ในบทเรียนนี้ คุณจะได้เรียนรู้วิธีผสานรวม Model Context Protocol (MCP) กับระบบ AI ในองค์กร โดยเน้นที่ Azure OpenAI และ Microsoft AI Foundry การผสานรวมเหล่านี้ช่วยให้คุณใช้ประโยชน์จากโมเดล AI ที่ทรงพลังและเครื่องมือต่างๆ พร้อมกับรักษาความยืดหยุ่นและความสามารถในการขยายของ MCP

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- ผสานรวม MCP กับ Azure OpenAI เพื่อใช้ความสามารถ AI ของมัน
- นำ MCP มาจัดการเครื่องมือร่วมกับ Azure OpenAI
- รวม MCP กับ Microsoft AI Foundry เพื่อเพิ่มความสามารถของเอเจนต์ AI ขั้นสูง
- ใช้ Azure Machine Learning (ML) ในการรัน ML pipeline และลงทะเบียนโมเดลเป็นเครื่องมือของ MCP

## การผสานรวม Azure OpenAI

Azure OpenAI ให้การเข้าถึงโมเดล AI ที่ทรงพลัง เช่น GPT-4 และอื่นๆ การผสานรวม MCP กับ Azure OpenAI ช่วยให้คุณใช้โมเดลเหล่านี้ได้ในขณะที่ยังคงความยืดหยุ่นของการจัดการเครื่องมือใน MCP

### ตัวอย่างการใช้งาน C#

ในโค้ดตัวอย่างนี้ เราจะแสดงวิธีผสานรวม MCP กับ Azure OpenAI โดยใช้ Azure OpenAI SDK

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

ในโค้ดข้างต้น เราได้:

- กำหนดค่า Azure OpenAI client ด้วย endpoint, ชื่อ deployment และ API key
- สร้างเมธอด `GetCompletionWithToolsAsync` เพื่อรับผลลัพธ์พร้อมการสนับสนุนเครื่องมือ
- จัดการการเรียกใช้เครื่องมือในคำตอบ

คุณควรนำไปพัฒนาตรรกะการจัดการเครื่องมือจริงตามการตั้งค่า MCP server ของคุณ

## การผสานรวม Microsoft AI Foundry

Azure AI Foundry เป็นแพลตฟอร์มสำหรับสร้างและปรับใช้เอเจนต์ AI การผสานรวม MCP กับ AI Foundry ช่วยให้คุณใช้ประโยชน์จากความสามารถของมันในขณะที่ยังคงความยืดหยุ่นของ MCP

ในโค้ดด้านล่าง เราพัฒนา Agent integration ที่ประมวลผลคำขอและจัดการการเรียกใช้เครื่องมือโดยใช้ MCP

### ตัวอย่างการใช้งาน Java

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

ในโค้ดข้างต้น เราได้:

- สร้างคลาส `AIFoundryMcpBridge` ที่ผสานรวมทั้ง AI Foundry และ MCP
- นำเมธอด `processAgentRequest` มาใช้เพื่อประมวลผลคำขอจากเอเจนต์ AI Foundry
- จัดการการเรียกใช้เครื่องมือโดยรันผ่าน MCP client และส่งผลลัพธ์กลับไปยังเอเจนต์ AI Foundry

## การผสานรวม MCP กับ Azure ML

การผสานรวม MCP กับ Azure Machine Learning (ML) ช่วยให้คุณใช้ความสามารถ ML อันทรงพลังของ Azure พร้อมกับรักษาความยืดหยุ่นของ MCP การผสานรวมนี้สามารถใช้รัน ML pipeline ลงทะเบียนโมเดลเป็นเครื่องมือ และจัดการทรัพยากรคอมพิวต์

### ตัวอย่างการใช้งาน Python

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

ในโค้ดข้างต้น เราได้:

- สร้างคลาส `EnterpriseAiIntegration` ที่ผสานรวม MCP กับ Azure ML
- นำเมธอด `execute_ml_pipeline` มาใช้เพื่อประมวลผลข้อมูลนำเข้าโดยใช้เครื่องมือ MCP และส่ง ML pipeline ไปยัง Azure ML
- นำเมธอด `register_ml_model_as_tool` มาใช้เพื่อลงทะเบียนโมเดล Azure ML เป็นเครื่องมือ MCP รวมถึงการสร้างสภาพแวดล้อม deployment และทรัพยากรคอมพิวต์ที่จำเป็น
- แมปประเภทข้อมูลของ Azure ML เป็น JSON schema สำหรับการลงทะเบียนเครื่องมือ
- ใช้การเขียนโปรแกรมแบบอะซิงโครนัสเพื่อจัดการกับงานที่อาจใช้เวลานาน เช่น การรัน ML pipeline และการลงทะเบียนโมเดล

## ต่อไปคืออะไร

- [5.2 Multi modality](../mcp-multi-modality/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้