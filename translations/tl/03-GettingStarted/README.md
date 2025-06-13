<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-13T00:39:24+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "tl"
}
-->
## Getting Started  

Ini nga seksyon may ara sang pila ka mga leksyon:

- **1 Your first server**, sa sini nga una nga leksyon, matun-an mo kon paano maghimo sang imo una nga server kag inspeksyonan ini gamit ang inspector tool, isa ka importante nga paagi para magtest kag mag-debug sang imo server, [to the lesson](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, sa sini nga leksyon, matun-an mo kon paano magsulat sang client nga makakonekta sa imo server, [to the lesson](/03-GettingStarted/02-client/README.md)

- **3 Client with LLM**, mas maayo nga paagi sang pagsulat sang client amo ang pagdugang sang LLM para makapang-"negotiate" ini sa imo server kon ano ang himuon, [to the lesson](/03-GettingStarted/03-llm-client/README.md)

- **4 Consuming a server GitHub Copilot Agent mode in Visual Studio Code**. Diri, ginatan-aw naton kon paano patakbon ang aton MCP Server halin sa sulod sang Visual Studio Code, [to the lesson](/03-GettingStarted/04-vscode/README.md)

- **5 Consuming from a SSE (Server Sent Events)** SSE isa ka standard para sa server-to-client streaming, nga nagahatag kahigayunan sa mga server nga magpadala sang real-time updates sa mga client paagi sa HTTP [to the lesson](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP Streaming with MCP (Streamable HTTP)**. Tun-i ang modern nga HTTP streaming, progress notifications, kag kon paano mag-implementar sang scalable, real-time MCP servers kag clients gamit ang Streamable HTTP. [to the lesson](/03-GettingStarted/06-http-streaming/README.md)

- **7 Utilising AI Toolkit for VSCode** para magamit kag matest ang imo MCP Clients kag Servers [to the lesson](/03-GettingStarted/07-aitk/README.md)

- **8 Testing**. Diri magatutok kita kon paano naton matest ang aton server kag client sa lain-lain nga mga paagi, [to the lesson](/03-GettingStarted/08-testing/README.md)

- **9 Deployment**. Ini nga kapitulo magatan-aw sang lain-lain nga mga paagi sa pagdeploy sang imo MCP solutions, [to the lesson](/03-GettingStarted/09-deployment/README.md)


Ang Model Context Protocol (MCP) isa ka bukas nga protocol nga naga-standardize kon paano ang mga aplikasyon naga-provide sang context sa LLMs. Pwede mo isipon ang MCP pareho sang USB-C port para sa AI applications - nagahatag ini sang standard nga paagi para makakonek ang AI models sa lain-lain nga data sources kag tools.

## Learning Objectives

Pagkatapos sini nga leksyon, mahimo mo na:

- I-setup ang development environments para sa MCP gamit ang C#, Java, Python, TypeScript, kag JavaScript
- Maghimo kag magdeploy sang basic nga MCP servers nga may custom features (resources, prompts, kag tools)
- Maghimo sang host applications nga makakonek sa MCP servers
- Magtest kag mag-debug sang MCP implementations
- Masabtan ang mga komon nga problema sa setup kag ang ila mga solusyon
- Makakonek ang imo MCP implementations sa mga popular nga LLM services

## Setting Up Your MCP Environment

Antes ka magsugod gamit ang MCP, importante nga i-prepare ang imo development environment kag masabtan ang basic nga workflow. Ini nga seksyon magagiyahan ka sa mga unang nga mga steps para masiguro nga hapsay ang imo pagsugod gamit ang MCP.

### Prerequisites

Antes ka mag-umpisa sa MCP development, siguruha nga may ara ka sang:

- **Development Environment**: Para sa imo napili nga language (C#, Java, Python, TypeScript, o JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, o bisan ano nga moderno nga code editor
- **Package Managers**: NuGet, Maven/Gradle, pip, o npm/yarn
- **API Keys**: Para sa bisan ano nga AI services nga plano mo gamiton sa imo host applications


### Official SDKs

Sa masunod nga mga kapitulo makit-an mo ang mga solusyon nga ginbuhat gamit ang Python, TypeScript, Java kag .NET. Ari diri ang tanan nga opisyal nga ginasuportahan nga SDKs.

Nagahatag ang MCP sang opisyal nga SDKs para sa madamo nga mga language:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Ginamanage upod ang Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Ginamanage upod ang Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Opisyal nga TypeScript implementation
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Opisyal nga Python implementation
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Opisyal nga Kotlin implementation
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Ginamanage upod ang Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Opisyal nga Rust implementation

## Key Takeaways

- Hapos lang mag-setup sang MCP development environment gamit ang language-specific SDKs
- Ang paghimo sang MCP servers nagalakip sang pag-create kag pag-register sang tools nga may klaro nga schemas
- Ang MCP clients nagakonek sa servers kag models para magamit ang mas lapad nga capabilities
- Importante ang testing kag debugging para sa kasaligan nga MCP implementations
- May ara sang lain-lain nga deployment options halin sa local development tubtob sa cloud-based nga solusyon

## Practicing

May ara kita sang mga samples nga nagakumpleto sa mga exercises nga imo makita sa tanan nga kapitulo sa sini nga seksyon. Dugang pa, ang kada kapitulo may ara man kaugalingon nga exercises kag assignments

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## What's next

Sunod: [Creating your first MCP Server](/03-GettingStarted/01-first-server/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagaman nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.