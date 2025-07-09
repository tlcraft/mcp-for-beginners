<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "860935ff95d05b006d1d3323e8e3f9e8",
  "translation_date": "2025-07-09T22:34:00+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "tl"
}
-->
## Getting Started  

Ang seksyong ito ay binubuo ng ilang mga aralin:

- **1 Your first server**, sa unang araling ito, matututuhan mo kung paano gumawa ng iyong unang server at suriin ito gamit ang inspector tool, isang mahalagang paraan para subukan at i-debug ang iyong server, [to the lesson](01-first-server/README.md)

- **2 Client**, sa araling ito, matututuhan mo kung paano sumulat ng client na maaaring kumonekta sa iyong server, [to the lesson](02-client/README.md)

- **3 Client with LLM**, isang mas mahusay na paraan ng pagsulat ng client ay sa pamamagitan ng pagdagdag ng LLM dito upang "makipagnegosasyon" ito sa iyong server kung ano ang gagawin, [to the lesson](03-llm-client/README.md)

- **4 Consuming a server GitHub Copilot Agent mode in Visual Studio Code**. Dito, tinitingnan natin ang pagpapatakbo ng ating MCP Server mula sa loob ng Visual Studio Code, [to the lesson](04-vscode/README.md)

- **5 Consuming from a SSE (Server Sent Events)** Ang SSE ay isang standard para sa server-to-client streaming, na nagpapahintulot sa mga server na magpadala ng real-time na mga update sa mga client sa pamamagitan ng HTTP [to the lesson](05-sse-server/README.md)

- **6 HTTP Streaming with MCP (Streamable HTTP)**. Alamin ang tungkol sa modernong HTTP streaming, mga notification ng progreso, at kung paano magpatupad ng scalable, real-time MCP servers at clients gamit ang Streamable HTTP. [to the lesson](06-http-streaming/README.md)

- **7 Utilising AI Toolkit for VSCode** para gamitin at subukan ang iyong MCP Clients at Servers [to the lesson](07-aitk/README.md)

- **8 Testing**. Dito ay tututok tayo kung paano natin masusubukan ang ating server at client sa iba't ibang paraan, [to the lesson](08-testing/README.md)

- **9 Deployment**. Tatalakayin sa kabanatang ito ang iba't ibang paraan ng pag-deploy ng iyong MCP solutions, [to the lesson](09-deployment/README.md)


Ang Model Context Protocol (MCP) ay isang bukas na protocol na nagtatakda kung paano nagbibigay ng konteksto ang mga aplikasyon sa LLMs. Isipin ang MCP bilang isang USB-C port para sa mga AI application - nagbibigay ito ng isang standardized na paraan para ikonekta ang mga AI model sa iba't ibang mga pinagkukunan ng data at mga tool.

## Learning Objectives

Sa pagtatapos ng araling ito, magagawa mong:

- Mag-set up ng development environments para sa MCP gamit ang C#, Java, Python, TypeScript, at JavaScript
- Gumawa at mag-deploy ng mga basic MCP servers na may custom na mga tampok (resources, prompts, at tools)
- Lumikha ng mga host application na kumokonekta sa MCP servers
- Subukan at i-debug ang mga implementasyon ng MCP
- Maunawaan ang mga karaniwang hamon sa setup at ang mga solusyon nito
- Ikonekta ang iyong mga implementasyon ng MCP sa mga kilalang LLM services

## Setting Up Your MCP Environment

Bago ka magsimulang magtrabaho gamit ang MCP, mahalagang ihanda ang iyong development environment at maunawaan ang pangunahing workflow. Gagabayan ka ng seksyong ito sa mga unang hakbang ng setup upang masigurong magiging maayos ang iyong pagsisimula sa MCP.

### Prerequisites

Bago sumabak sa MCP development, siguraduhing mayroon kang:

- **Development Environment**: Para sa napili mong wika (C#, Java, Python, TypeScript, o JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, o anumang modernong code editor
- **Package Managers**: NuGet, Maven/Gradle, pip, o npm/yarn
- **API Keys**: Para sa anumang AI services na balak mong gamitin sa iyong mga host application


### Official SDKs

Sa mga susunod na kabanata makikita mo ang mga solusyong ginawa gamit ang Python, TypeScript, Java, at .NET. Narito ang lahat ng opisyal na suportadong SDKs.

Nagbibigay ang MCP ng opisyal na SDKs para sa iba't ibang wika:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Pinapanatili sa pakikipagtulungan sa Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Pinapanatili sa pakikipagtulungan sa Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Ang opisyal na implementasyon ng TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Ang opisyal na implementasyon ng Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Ang opisyal na implementasyon ng Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Pinapanatili sa pakikipagtulungan sa Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Ang opisyal na implementasyon ng Rust

## Key Takeaways

- Madaling mag-set up ng MCP development environment gamit ang mga language-specific SDKs
- Ang paggawa ng MCP servers ay nangangailangan ng paglikha at pagrerehistro ng mga tool na may malinaw na mga schema
- Ang MCP clients ay kumokonekta sa mga server at modelo upang magamit ang pinalawak na mga kakayahan
- Mahalaga ang testing at debugging para sa maaasahang implementasyon ng MCP
- Ang mga opsyon sa deployment ay mula sa lokal na development hanggang sa cloud-based na mga solusyon

## Practicing

Mayroon kaming mga sample na sumusuporta sa mga ehersisyo na makikita mo sa lahat ng kabanata sa seksyong ito. Bukod dito, bawat kabanata ay may kanya-kanyang mga ehersisyo at takdang-aralin

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

Next: [Creating your first MCP Server](01-first-server/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.