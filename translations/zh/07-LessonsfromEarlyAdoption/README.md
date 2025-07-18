<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6755bc4f6d0293ce6c49cfc5efba0d8e",
  "translation_date": "2025-07-18T09:19:39+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "zh"
}
-->
# 🌟 早期采用者的经验教训

## 🎯 本模块涵盖内容

本模块探讨了真实组织和开发者如何利用 Model Context Protocol (MCP) 解决实际问题并推动创新。通过详细的案例研究和实践项目，您将了解 MCP 如何实现安全、可扩展的 AI 集成，连接语言模型、工具和企业数据。

### 案例研究 5：Azure MCP —— 企业级模型上下文协议即服务

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) 是微软托管的企业级 Model Context Protocol 实现，旨在作为云服务提供可扩展、安全且合规的 MCP 服务器功能。该套件包含多个针对不同 Azure 服务和场景的专用 MCP 服务器。

> **🎯 生产就绪工具**  
> 本案例展示了多个生产就绪的 MCP 服务器！了解 Azure MCP 服务器及其他 Azure 集成服务器，请参阅我们的[**Microsoft MCP 服务器指南**](microsoft-mcp-servers.md#2--azure-mcp-server)。

**主要特性：**  
- 完全托管的 MCP 服务器托管，内置自动扩展、监控和安全功能  
- 与 Azure OpenAI、Azure AI Search 及其他 Azure 服务的原生集成  
- 通过 Microsoft Entra ID 实现企业级身份验证和授权  
- 支持自定义工具、提示模板和资源连接器  
- 符合企业安全和合规要求  
- 提供 15+ 专用 Azure 服务连接器，包括数据库、监控和存储

**Azure MCP 服务器功能：**  
- **资源管理**：完整的 Azure 资源生命周期管理  
- **数据库连接器**：直接访问 Azure Database for PostgreSQL 和 SQL Server  
- **Azure Monitor**：基于 KQL 的日志分析和运营洞察  
- **身份验证**：支持 DefaultAzureCredential 和托管身份模式  
- **存储服务**：Blob 存储、队列存储和表存储操作  
- **容器服务**：Azure Container Apps、Container Instances 和 AKS 管理

### 📚 观看 MCP 实际应用

想了解这些原则如何应用于生产就绪工具？请查看我们的[**10 个正在改变开发者生产力的 Microsoft MCP 服务器**](microsoft-mcp-servers.md)，展示了您今天就能使用的真实 Microsoft MCP 服务器。

## 概述

本课探讨早期采用者如何利用 Model Context Protocol (MCP) 解决现实挑战并推动各行业创新。通过详细案例研究和实践项目，您将看到 MCP 如何实现标准化、安全且可扩展的 AI 集成——将大型语言模型、工具和企业数据统一连接。您将获得设计和构建基于 MCP 解决方案的实战经验，学习经过验证的实现模式，并发现 MCP 在生产环境中部署的最佳实践。课程还将介绍新兴趋势、未来方向及开源资源，助您保持 MCP 技术及其生态系统的前沿地位。

## 学习目标

- 分析不同行业的真实 MCP 实现案例  
- 设计并构建完整的基于 MCP 的应用  
- 探索 MCP 技术的新兴趋势和未来方向  
- 在实际开发场景中应用最佳实践

## 真实 MCP 实现案例

### 案例研究 1：企业客户支持自动化

一家跨国公司实施了基于 MCP 的解决方案，标准化其客户支持系统中的 AI 交互，实现了：

- 为多个 LLM 提供商创建统一接口  
- 跨部门保持一致的提示管理  
- 实施强大的安全和合规控制  
- 根据具体需求轻松切换不同 AI 模型

**技术实现：**  
```python
# Python MCP server implementation for customer support
import logging
import asyncio
from modelcontextprotocol import create_server, ServerConfig
from modelcontextprotocol.server import MCPServer
from modelcontextprotocol.transports import create_http_transport
from modelcontextprotocol.resources import ResourceDefinition
from modelcontextprotocol.prompts import PromptDefinition
from modelcontextprotocol.tool import ToolDefinition

# Configure logging
logging.basicConfig(level=logging.INFO)

async def main():
    # Create server configuration
    config = ServerConfig(
        name="Enterprise Customer Support Server",
        version="1.0.0",
        description="MCP server for handling customer support inquiries"
    )
    
    # Initialize MCP server
    server = create_server(config)
    
    # Register knowledge base resources
    server.resources.register(
        ResourceDefinition(
            name="customer_kb",
            description="Customer knowledge base documentation"
        ),
        lambda params: get_customer_documentation(params)
    )
    
    # Register prompt templates
    server.prompts.register(
        PromptDefinition(
            name="support_template",
            description="Templates for customer support responses"
        ),
        lambda params: get_support_templates(params)
    )
    
    # Register support tools
    server.tools.register(
        ToolDefinition(
            name="ticketing",
            description="Create and update support tickets"
        ),
        handle_ticketing_operations
    )
    
    # Start server with HTTP transport
    transport = create_http_transport(port=8080)
    await server.run(transport)

if __name__ == "__main__":
    asyncio.run(main())
```

**结果：** 模型成本降低 30%，响应一致性提升 45%，全球运营合规性增强。

### 案例研究 2：医疗诊断助手

一家医疗机构构建了 MCP 基础设施，集成多个专业医疗 AI 模型，同时确保敏感患者数据安全：

- 在通用和专业医疗模型间无缝切换  
- 严格的隐私控制和审计追踪  
- 与现有电子健康记录 (EHR) 系统集成  
- 医疗术语的统一提示工程

**技术实现：**  
```csharp
// C# MCP host application implementation in healthcare application
using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.SDK.Client;
using ModelContextProtocol.SDK.Security;
using ModelContextProtocol.SDK.Resources;

public class DiagnosticAssistant
{
    private readonly MCPHostClient _mcpClient;
    private readonly PatientContext _patientContext;
    
    public DiagnosticAssistant(PatientContext patientContext)
    {
        _patientContext = patientContext;
        
        // Configure MCP client with healthcare-specific settings
        var clientOptions = new ClientOptions
        {
            Name = "Healthcare Diagnostic Assistant",
            Version = "1.0.0",
            Security = new SecurityOptions
            {
                Encryption = EncryptionLevel.Medical,
                AuditEnabled = true
            }
        };
        
        _mcpClient = new MCPHostClientBuilder()
            .WithOptions(clientOptions)
            .WithTransport(new HttpTransport("https://healthcare-mcp.example.org"))
            .WithAuthentication(new HIPAACompliantAuthProvider())
            .Build();
    }
    
    public async Task<DiagnosticSuggestion> GetDiagnosticAssistance(
        string symptoms, string patientHistory)
    {
        // Create request with appropriate resources and tool access
        var resourceRequest = new ResourceRequest
        {
            Name = "patient_records",
            Parameters = new Dictionary<string, object>
            {
                ["patientId"] = _patientContext.PatientId,
                ["requestingProvider"] = _patientContext.ProviderId
            }
        };
        
        // Request diagnostic assistance using appropriate prompt
        var response = await _mcpClient.SendPromptRequestAsync(
            promptName: "diagnostic_assistance",
            parameters: new Dictionary<string, object>
            {
                ["symptoms"] = symptoms,
                patientHistory = patientHistory,
                relevantGuidelines = _patientContext.GetRelevantGuidelines()
            });
            
        return DiagnosticSuggestion.FromMCPResponse(response);
    }
}
```

**结果：** 改善了医生的诊断建议，完全符合 HIPAA 规定，显著减少系统间的上下文切换。

### 案例研究 3：金融服务风险分析

一家金融机构采用 MCP 标准化不同部门的风险分析流程：

- 为信用风险、欺诈检测和投资风险模型创建统一接口  
- 实施严格的访问控制和模型版本管理  
- 确保所有 AI 建议的可审计性  
- 维护多系统间一致的数据格式

**技术实现：**  
```java
// Java MCP server for financial risk assessment
import org.mcp.server.*;
import org.mcp.security.*;

public class FinancialRiskMCPServer {
    public static void main(String[] args) {
        // Create MCP server with financial compliance features
        MCPServer server = new MCPServerBuilder()
            .withModelProviders(
                new ModelProvider("risk-assessment-primary", new AzureOpenAIProvider()),
                new ModelProvider("risk-assessment-audit", new LocalLlamaProvider())
            )
            .withPromptTemplateDirectory("./compliance/templates")
            .withAccessControls(new SOCCompliantAccessControl())
            .withDataEncryption(EncryptionStandard.FINANCIAL_GRADE)
            .withVersionControl(true)
            .withAuditLogging(new DatabaseAuditLogger())
            .build();
            
        server.addRequestValidator(new FinancialDataValidator());
        server.addResponseFilter(new PII_RedactionFilter());
        
        server.start(9000);
        
        System.out.println("Financial Risk MCP Server running on port 9000");
    }
}
```

**结果：** 提升了合规性，模型部署周期缩短 40%，部门间风险评估一致性提高。

### 案例研究 4：Microsoft Playwright MCP 服务器用于浏览器自动化

微软开发了[Playwright MCP 服务器](https://github.com/microsoft/playwright-mcp)，通过 Model Context Protocol 实现安全、标准化的浏览器自动化。该生产就绪服务器允许 AI 代理和 LLM 以受控、可审计且可扩展的方式与浏览器交互，支持自动化网页测试、数据提取和端到端工作流等用例。

> **🎯 生产就绪工具**  
> 本案例展示了您今天就能使用的真实 MCP 服务器！了解 Playwright MCP 服务器及其他 9 个生产就绪的 Microsoft MCP 服务器，请参阅我们的[**Microsoft MCP 服务器指南**](microsoft-mcp-servers.md#8--playwright-mcp-server)。

**主要特性：**  
- 将浏览器自动化功能（导航、表单填写、截图等）作为 MCP 工具暴露  
- 实施严格访问控制和沙箱机制，防止未授权操作  
- 提供详细的浏览器交互审计日志  
- 支持与 Azure OpenAI 及其他 LLM 提供商集成，实现代理驱动自动化  
- 为 GitHub Copilot 的编码代理提供网页浏览能力

**技术实现：**  
```typescript
// TypeScript: Registering Playwright browser automation tools in an MCP server
import { createServer, ToolDefinition } from 'modelcontextprotocol';
import { launch } from 'playwright';

const server = createServer({
  name: 'Playwright MCP Server',
  version: '1.0.0',
  description: 'MCP server for browser automation using Playwright'
});

// Register a tool for navigating to a URL and capturing a screenshot
server.tools.register(
  new ToolDefinition({
    name: 'navigate_and_screenshot',
    description: 'Navigate to a URL and capture a screenshot',
    parameters: {
      url: { type: 'string', description: 'The URL to visit' }
    }
  }),
  async ({ url }) => {
    const browser = await launch();
    const page = await browser.newPage();
    await page.goto(url);
    const screenshot = await page.screenshot();
    await browser.close();
    return { screenshot };
  }
);

// Start the MCP server
server.listen(8080);
```

**结果：**  
- 实现了 AI 代理和 LLM 的安全程序化浏览器自动化  
- 降低了手动测试工作量，提升了网页应用测试覆盖率  
- 提供了可复用、可扩展的企业级浏览器工具集成框架  
- 支持 GitHub Copilot 的网页浏览功能

**参考资料：**  
- [Playwright MCP 服务器 GitHub 仓库](https://github.com/microsoft/playwright-mcp)  
- [微软 AI 与自动化解决方案](https://azure.microsoft.com/en-us/products/ai-services/)

### 案例研究 5：Azure MCP —— 企业级模型上下文协议即服务

Azure MCP 服务器 ([https://aka.ms/azmcp](https://aka.ms/azmcp)) 是微软托管的企业级 Model Context Protocol 实现，作为云服务提供可扩展、安全且合规的 MCP 服务器功能。Azure MCP 使组织能够快速部署、管理并与 Azure AI、数据和安全服务集成 MCP 服务器，降低运营负担，加速 AI 采用。

> **🎯 生产就绪工具**  
> 这是您今天就能使用的真实 MCP 服务器！了解更多 Azure AI Foundry MCP 服务器信息，请参阅我们的[**Microsoft MCP 服务器指南**](microsoft-mcp-servers.md)。

- 完全托管的 MCP 服务器托管，内置自动扩展、监控和安全功能  
- 与 Azure OpenAI、Azure AI Search 及其他 Azure 服务的原生集成  
- 通过 Microsoft Entra ID 实现企业级身份验证和授权  
- 支持自定义工具、提示模板和资源连接器  
- 符合企业安全和合规要求

**技术实现：**  
```yaml
# Example: Azure MCP server deployment configuration (YAML)
apiVersion: mcp.microsoft.com/v1
kind: McpServer
metadata:
  name: enterprise-mcp-server
spec:
  modelProviders:
    - name: azure-openai
      type: AzureOpenAI
      endpoint: https://<your-openai-resource>.openai.azure.com/
      apiKeySecret: <your-azure-keyvault-secret>
  tools:
    - name: document_search
      type: AzureAISearch
      endpoint: https://<your-search-resource>.search.windows.net/
      apiKeySecret: <your-azure-keyvault-secret>
  authentication:
    type: EntraID
    tenantId: <your-tenant-id>
  monitoring:
    enabled: true
    logAnalyticsWorkspace: <your-log-analytics-id>
```

**结果：**  
- 通过提供即用型、合规的 MCP 服务器平台，缩短企业 AI 项目价值实现时间  
- 简化 LLM、工具和企业数据源的集成  
- 提升 MCP 工作负载的安全性、可观测性和运营效率  
- 采用 Azure SDK 最佳实践和最新身份验证模式，提升代码质量

**参考资料：**  
- [Azure MCP 文档](https://aka.ms/azmcp)  
- [Azure MCP 服务器 GitHub 仓库](https://github.com/Azure/azure-mcp)  
- [Azure AI 服务](https://azure.microsoft.com/en-us/products/ai-services/)

### 案例研究 6：NLWeb —— 自然语言网页接口协议

NLWeb 代表了微软构建 AI 网页基础层的愿景。每个 NLWeb 实例也是一个 MCP 服务器，支持一个核心方法 `ask`，用于以自然语言向网站提问。返回的响应采用 schema.org 这一广泛使用的网页数据描述词汇。简单来说，MCP 对 NLWeb 的作用，就像 HTTP 对 HTML 一样。

**主要特性：**  
- **协议层**：用于自然语言访问网站的简单协议  
- **Schema.org 格式**：利用 JSON 和 schema.org 提供结构化、机器可读的响应  
- **社区实现**：适合将网站抽象为项目列表（产品、食谱、景点、评论等）的简单实现  
- **UI 组件**：预构建的对话界面用户组件

**架构组成：**  
1. **协议**：用于自然语言查询网站的简单 REST API  
2. **实现**：利用现有标记和网站结构自动生成响应  
3. **UI 组件**：用于集成对话界面的现成组件

**优势：**  
- 支持人与网站及代理间的交互  
- 提供 AI 系统易于处理的结构化数据响应  
- 快速部署适用于列表型内容的网站  
- 标准化方法使网站更易被 AI 访问

**成果：**  
- 建立了 AI 网页交互标准基础  
- 简化了内容网站对话界面的创建  
- 提升了 AI 系统对网页内容的发现和访问能力  
- 促进了不同 AI 代理和网页服务间的互操作性

**参考资料：**  
- [NLWeb GitHub 仓库](https://github.com/microsoft/NlWeb)  
- [NLWeb 文档](https://github.com/microsoft/NlWeb)

### 案例研究 7：Azure AI Foundry MCP 服务器 —— 企业 AI 代理集成

Azure AI Foundry MCP 服务器展示了 MCP 如何在企业环境中协调和管理 AI 代理及工作流。通过将 MCP 与 Azure AI Foundry 集成，组织能够标准化代理交互，利用 Foundry 的工作流管理，并确保安全、可扩展的部署。

> **🎯 生产就绪工具**  
> 这是您今天就能使用的真实 MCP 服务器！了解更多 Azure AI Foundry MCP 服务器信息，请参阅我们的[**Microsoft MCP 服务器指南**](microsoft-mcp-servers.md#9--azure-ai-foundry-mcp-server)。

**主要特性：**  
- 全面访问 Azure AI 生态系统，包括模型目录和部署管理  
- 利用 Azure AI Search 进行知识索引，支持 RAG 应用  
- AI 模型性能和质量评估工具  
- 与 Azure AI Foundry Catalog 和 Labs 集成，支持前沿研究模型  
- 生产环境下的代理管理和评估能力

**成果：**  
- 快速原型设计和强大的 AI 代理工作流监控  
- 与 Azure AI 服务的无缝集成，支持高级场景  
- 统一界面构建、部署和监控代理管道  
- 提升企业安全、合规和运营效率  
- 加速 AI 采用，同时保持对复杂代理流程的控制

**参考资料：**  
- [Azure AI Foundry MCP 服务器 GitHub 仓库](https://github.com/azure-ai-foundry/mcp-foundry)  
- [将 Azure AI 代理与 MCP 集成（Microsoft Foundry 博客）](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### 案例研究 8：Foundry MCP Playground —— 实验与原型开发

Foundry MCP Playground 提供了一个即用型环境，用于实验 MCP 服务器和 Azure AI Foundry 集成。开发者可以快速原型设计、测试和评估 AI 模型及代理工作流，利用 Azure AI Foundry Catalog 和 Labs 的资源。该 Playground 简化了环境搭建，提供示例项目，支持协作开发，方便探索最佳实践和新场景，降低了基础设施复杂度。它特别适合团队验证想法、共享实验成果并加速学习，促进 MCP 和 Azure AI Foundry 生态的创新与社区贡献。

**参考资料：**  
- [Foundry MCP Playground GitHub 仓库](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### 案例研究 9：Microsoft Learn Docs MCP 服务器 —— AI 驱动的文档访问

Microsoft Learn Docs MCP 服务器是一项云托管服务，通过 Model Context Protocol 为 AI 助手提供对微软官方文档的实时访问。该生产就绪服务器连接到全面的 Microsoft Learn 生态系统，实现对所有官方微软资源的语义搜索。
> **🎯 生产环境级工具**
> 
> 这是一个你今天就能使用的真实 MCP 服务器！想了解更多关于 Microsoft Learn Docs MCP 服务器的信息，请参阅我们的[**Microsoft MCP 服务器指南**](microsoft-mcp-servers.md#1--microsoft-learn-docs-mcp-server)。
**主要特点：**
- 实时访问官方 Microsoft 文档、Azure 文档和 Microsoft 365 文档
- 先进的语义搜索功能，能够理解上下文和意图
- 随着 Microsoft Learn 内容的发布，信息始终保持最新
- 全面覆盖 Microsoft Learn、Azure 文档和 Microsoft 365 资源
- 返回最多 10 个高质量内容块，附带文章标题和 URL

**重要性：**
- 解决了微软技术“AI 知识过时”的问题
- 确保 AI 助手能够访问最新的 .NET、C#、Azure 和 Microsoft 365 功能
- 提供权威的第一方信息，确保代码生成准确
- 对于使用快速发展的微软技术的开发者至关重要

**成果：**
- 大幅提升微软技术相关 AI 生成代码的准确性
- 减少查找最新文档和最佳实践的时间
- 通过上下文感知的文档检索提升开发者生产力
- 无缝集成开发流程，无需离开 IDE

**参考资料：**
- [Microsoft Learn Docs MCP Server GitHub 仓库](https://github.com/MicrosoftDocs/mcp)
- [Microsoft Learn 文档](https://learn.microsoft.com/)

## 实践项目

### 项目 1：构建多提供商 MCP 服务器

**目标：** 创建一个 MCP 服务器，能够根据特定条件将请求路由到多个 AI 模型提供商。

**需求：**
- 支持至少三种不同的模型提供商（例如 OpenAI、Anthropic、本地模型）
- 实现基于请求元数据的路由机制
- 创建管理提供商凭据的配置系统
- 添加缓存以优化性能和成本
- 构建一个简单的仪表盘用于监控使用情况

**实施步骤：**
1. 搭建基础 MCP 服务器架构
2. 为每个 AI 模型服务实现提供商适配器
3. 根据请求属性创建路由逻辑
4. 为频繁请求添加缓存机制
5. 开发监控仪表盘
6. 使用各种请求模式进行测试

**技术选型：** 可选择 Python（或基于 .NET/Java/Python 的任意语言）、Redis 用于缓存，以及简单的 Web 框架构建仪表盘。

### 项目 2：企业级提示管理系统

**目标：** 开发基于 MCP 的系统，用于管理、版本控制和部署组织内的提示模板。

**需求：**
- 创建集中式提示模板仓库
- 实现版本控制和审批工作流
- 构建带有示例输入的模板测试功能
- 开发基于角色的访问控制
- 创建用于模板检索和部署的 API

**实施步骤：**
1. 设计模板存储的数据库模式
2. 创建模板的核心 CRUD API
3. 实现版本控制系统
4. 构建审批工作流
5. 开发测试框架
6. 创建简单的管理 Web 界面
7. 与 MCP 服务器集成

**技术选型：** 自选后端框架、SQL 或 NoSQL 数据库，以及管理界面的前端框架。

### 项目 3：基于 MCP 的内容生成平台

**目标：** 构建一个内容生成平台，利用 MCP 实现不同内容类型的一致输出。

**需求：**
- 支持多种内容格式（博客文章、社交媒体、营销文案）
- 实现基于模板的生成并支持自定义选项
- 创建内容审核和反馈系统
- 跟踪内容表现指标
- 支持内容版本控制和迭代

**实施步骤：**
1. 搭建 MCP 客户端架构
2. 创建不同内容类型的模板
3. 构建内容生成流水线
4. 实现审核系统
5. 开发指标跟踪系统
6. 创建模板管理和内容生成的用户界面

**技术选型：** 选择你偏好的编程语言、Web 框架和数据库系统。

## MCP 技术的未来方向

### 新兴趋势

1. **多模态 MCP**
   - 扩展 MCP 以标准化与图像、音频和视频模型的交互
   - 开发跨模态推理能力
   - 不同模态的标准化提示格式

2. **联邦 MCP 基础设施**
   - 分布式 MCP 网络，实现跨组织资源共享
   - 安全模型共享的标准协议
   - 隐私保护计算技术

3. **MCP 市场**
   - 用于共享和变现 MCP 模板及插件的生态系统
   - 质量保证和认证流程
   - 与模型市场的集成

4. **面向边缘计算的 MCP**
   - 适配资源受限的边缘设备的 MCP 标准
   - 针对低带宽环境的优化协议
   - 针对物联网生态的专用 MCP 实现

5. **监管框架**
   - 开发符合监管要求的 MCP 扩展
   - 标准化审计轨迹和可解释性接口
   - 与新兴 AI 治理框架的集成

### 来自微软的 MCP 解决方案

微软和 Azure 开发了多个开源仓库，帮助开发者在不同场景下实现 MCP：

#### Microsoft Organization
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - 用于浏览器自动化和测试的 Playwright MCP 服务器
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - OneDrive MCP 服务器实现，用于本地测试和社区贡献
3. [NLWeb](https://github.com/microsoft/NlWeb) - NLWeb 是一套开放协议及相关开源工具，主要致力于建立 AI Web 的基础层

#### Azure-Samples Organization
1. [mcp](https://github.com/Azure-Samples/mcp) - 提供多语言构建和集成 Azure 上 MCP 服务器的示例、工具和资源链接
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - 演示基于当前 Model Context Protocol 规范的认证 MCP 服务器参考实现
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions 中远程 MCP 服务器实现的入口页面，附带语言特定仓库链接
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - 使用 Azure Functions 和 Python 构建及部署自定义远程 MCP 服务器的快速入门模板
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - 使用 Azure Functions 和 .NET/C# 构建及部署自定义远程 MCP 服务器的快速入门模板
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - 使用 Azure Functions 和 TypeScript 构建及部署自定义远程 MCP 服务器的快速入门模板
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - 使用 Python 的 Azure API 管理作为远程 MCP 服务器的 AI 网关
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - 包含 MCP 功能的 APIM ❤️ AI 实验，集成 Azure OpenAI 和 AI Foundry

这些仓库提供了多种实现、模板和资源，支持跨不同编程语言和 Azure 服务的 Model Context Protocol 应用，涵盖从基础服务器实现到认证、云部署和企业集成的多种用例。

#### MCP 资源目录

官方 Microsoft MCP 仓库中的 [MCP Resources 目录](https://github.com/microsoft/mcp/tree/main/Resources) 提供了精选的示例资源、提示模板和工具定义，供 Model Context Protocol 服务器使用。该目录旨在帮助开发者快速入门 MCP，提供可复用的构建模块和最佳实践示例，包括：

- **提示模板：** 适用于常见 AI 任务和场景的现成提示模板，可根据需要调整用于 MCP 服务器实现。
- **工具定义：** 示例工具模式和元数据，标准化不同 MCP 服务器间的工具集成和调用。
- **资源示例：** 用于连接数据源、API 和外部服务的示例资源定义，适用于 MCP 框架。
- **参考实现：** 展示如何在实际 MCP 项目中组织资源、提示和工具的实用示例。

这些资源加速开发，促进标准化，帮助确保构建和部署基于 MCP 的解决方案时遵循最佳实践。

#### MCP 资源目录
- [MCP 资源（示例提示、工具和资源定义）](https://github.com/microsoft/mcp/tree/main/Resources)

### 研究机会

- MCP 框架内高效的提示优化技术
- 多租户 MCP 部署的安全模型
- 不同 MCP 实现的性能基准测试
- MCP 服务器的形式化验证方法

## 结论

Model Context Protocol (MCP) 正在快速塑造标准化、安全且可互操作的 AI 集成未来。通过本课的案例研究和实践项目，你已经了解了包括微软和 Azure 在内的早期采用者如何利用 MCP 解决实际问题，加速 AI 采用，并确保合规、安全与可扩展性。MCP 的模块化方法使组织能够在统一且可审计的框架中连接大型语言模型、工具和企业数据。随着 MCP 持续发展，积极参与社区、探索开源资源并应用最佳实践，将是构建稳健且面向未来的 AI 解决方案的关键。

## 附加资源

- [MCP Foundry GitHub 仓库](https://github.com/azure-ai-foundry/mcp-foundry)
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)
- [将 Azure AI 代理与 MCP 集成（Microsoft Foundry 博客）](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)
- [MCP GitHub 仓库（Microsoft）](https://github.com/microsoft/mcp)
- [MCP 资源目录（示例提示、工具和资源定义）](https://github.com/microsoft/mcp/tree/main/Resources)
- [MCP 社区与文档](https://modelcontextprotocol.io/introduction)
- [Azure MCP 文档](https://aka.ms/azmcp)
- [Playwright MCP 服务器 GitHub 仓库](https://github.com/microsoft/playwright-mcp)
- [Files MCP 服务器（OneDrive）](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP Auth Servers（Azure-Samples）](https://github.com/Azure-Samples/mcp-auth-servers)
- [Remote MCP Functions（Azure-Samples）](https://github.com/Azure-Samples/remote-mcp-functions)
- [Remote MCP Functions Python（Azure-Samples）](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET（Azure-Samples）](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript（Azure-Samples）](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python（Azure-Samples）](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway（Azure-Samples）](https://github.com/Azure-Samples/AI-Gateway)
- [微软 AI 与自动化解决方案](https://azure.microsoft.com/en-us/products/ai-services/)

## 练习

1. 分析一个案例研究，提出一种替代的实现方案。
2. 选择一个项目想法，制定详细的技术规格。
3. 研究一个案例研究未涉及的行业，概述 MCP 如何解决其特定挑战。
4. 探索一个未来方向，设计一个支持该方向的新 MCP 扩展概念。

下一节：[Microsoft MCP Server](../07-LessonsfromEarlyAdoption/microsoft-mcp-servers.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始语言的原文应被视为权威来源。对于重要信息，建议采用专业人工翻译。我们不对因使用本翻译而产生的任何误解或误释承担责任。