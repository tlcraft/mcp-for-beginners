<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:14:26+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "tl"
}
-->
## Getting Started  

Itong bahagi ay binubuo ng ilang mga aralin:

- **1 Your first server**, sa unang araling ito, matututuhan mo kung paano gumawa ng iyong unang server at suriin ito gamit ang inspector tool, isang mahalagang paraan para subukan at i-debug ang iyong server, [to the lesson](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, sa araling ito, matututuhan mo kung paano sumulat ng client na kayang kumonekta sa iyong server, [to the lesson](/03-GettingStarted/02-client/README.md)

- **3 Client with LLM**, mas magandang paraan ng pagsulat ng client ay sa pamamagitan ng pagdagdag ng LLM dito para ito ay "makipagnegosasyon" sa iyong server kung ano ang gagawin, [to the lesson](/03-GettingStarted/03-llm-client/README.md)

- **4 Consuming a server GitHub Copilot Agent mode in Visual Studio Code**. Dito, tinitingnan natin kung paano patakbuhin ang ating MCP Server mula mismo sa Visual Studio Code, [to the lesson](/03-GettingStarted/04-vscode/README.md)

- **5 Consuming from a SSE (Server Sent Events)** SSE ay isang standard para sa server-to-client streaming, na nagpapahintulot sa mga server na mag-push ng real-time updates sa mga client gamit ang HTTP [to the lesson](/03-GettingStarted/05-sse-server/README.md)

- **6 Utilising AI Toolkit for VSCode** para gamitin at subukan ang iyong MCP Clients at Servers [to the lesson](/03-GettingStarted/06-aitk/README.md)

- **7 Testing**. Dito ay tututok tayo kung paano natin masusubukan ang ating server at client sa iba't ibang paraan, [to the lesson](/03-GettingStarted/07-testing/README.md)

- **8 Deployment**. Tatalakayin sa kabanatang ito ang iba't ibang paraan ng pag-deploy ng iyong MCP solutions, [to the lesson](/03-GettingStarted/08-deployment/README.md)


Ang Model Context Protocol (MCP) ay isang open protocol na nag-standardize kung paano nagbibigay ng context ang mga aplikasyon sa LLMs. Isipin ang MCP bilang isang USB-C port para sa mga AI application - nagbibigay ito ng standardized na paraan para ikonekta ang AI models sa iba't ibang data sources at tools.

## Learning Objectives

Sa pagtatapos ng araling ito, magagawa mo nang:

- Mag-setup ng development environments para sa MCP gamit ang C#, Java, Python, TypeScript, at JavaScript
- Gumawa at mag-deploy ng basic MCP servers na may custom na features (resources, prompts, at tools)
- Lumikha ng host applications na nakakonekta sa MCP servers
- Mag-test at mag-debug ng mga implementasyon ng MCP
- Maunawaan ang mga karaniwang hamon sa setup at ang mga solusyon dito
- Ikonekta ang iyong MCP implementasyon sa mga kilalang LLM services

## Setting Up Your MCP Environment

Bago ka magsimulang magtrabaho gamit ang MCP, mahalagang ihanda ang iyong development environment at maintindihan ang basic na workflow. Gabay ka ng bahaging ito sa mga unang hakbang para masiguro ang maayos na pagsisimula sa MCP.

### Prerequisites

Bago sumabak sa MCP development, siguraduhing mayroon kang:

- **Development Environment**: Para sa napiling wika (C#, Java, Python, TypeScript, o JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, o anumang modernong code editor
- **Package Managers**: NuGet, Maven/Gradle, pip, o npm/yarn
- **API Keys**: Para sa anumang AI services na balak mong gamitin sa iyong host applications


### Official SDKs

Sa mga susunod na kabanata makikita mo ang mga solusyong ginawa gamit ang Python, TypeScript, Java at .NET. Narito ang lahat ng opisyal na suportadong SDKs.

Nagbibigay ang MCP ng opisyal na SDKs para sa iba't ibang wika:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Pinapanatili sa pakikipagtulungan sa Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Pinapanatili sa pakikipagtulungan sa Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Ang opisyal na TypeScript na implementasyon
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Ang opisyal na Python na implementasyon
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Ang opisyal na Kotlin na implementasyon
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Pinapanatili sa pakikipagtulungan sa Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Ang opisyal na Rust na implementasyon

## Key Takeaways

- Madaling mag-setup ng MCP development environment gamit ang mga language-specific SDKs
- Ang paggawa ng MCP servers ay nangangailangan ng paglikha at pagrerehistro ng mga tools na may malinaw na schemas
- Ang MCP clients ay kumokonekta sa mga servers at models para magamit ang mga pinalawak na kakayahan
- Mahalaga ang testing at debugging para sa maaasahang implementasyon ng MCP
- May iba't ibang deployment options mula sa lokal na development hanggang sa cloud-based solutions

## Practicing

Mayroon kaming mga sample na nagsisilbing karagdagan sa mga exercises na makikita mo sa lahat ng kabanata sa bahaging ito. Bukod dito, bawat kabanata ay may sariling exercises at assignments

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

Next: [Creating your first MCP Server](/03-GettingStarted/01-first-server/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.