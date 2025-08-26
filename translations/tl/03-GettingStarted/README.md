<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1197b6dbde36773e04a5ae826557fdb9",
  "translation_date": "2025-08-26T18:07:17+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "tl"
}
-->
## Pagsisimula  

[![Gumawa ng Iyong Unang MCP Server](../../../translated_images/04.0ea920069efd979a0b2dad51e72c1df7ead9c57b3305796068a6cee1f0dd6674.tl.png)](https://youtu.be/sNDZO9N4m9Y)

_(I-click ang larawan sa itaas upang panoorin ang video ng araling ito)_

Ang seksyong ito ay binubuo ng ilang mga aralin:

- **1 Ang iyong unang server**, sa unang araling ito, matututuhan mo kung paano gumawa ng iyong unang server at suriin ito gamit ang inspector tool, isang mahalagang paraan upang subukan at i-debug ang iyong server, [sa aralin](01-first-server/README.md)

- **2 Kliyente**, sa araling ito, matututuhan mo kung paano magsulat ng isang kliyente na maaaring kumonekta sa iyong server, [sa aralin](02-client/README.md)

- **3 Kliyente na may LLM**, isang mas mahusay na paraan ng pagsulat ng kliyente ay sa pamamagitan ng pagdaragdag ng LLM upang ito ay makipag-"negotiate" sa iyong server kung ano ang gagawin, [sa aralin](03-llm-client/README.md)

- **4 Paggamit ng server sa GitHub Copilot Agent mode sa Visual Studio Code**. Dito, tatalakayin natin ang pagpapatakbo ng ating MCP Server mula sa loob ng Visual Studio Code, [sa aralin](04-vscode/README.md)

- **5 stdio Transport Server** Ang stdio transport ay ang inirerekomendang pamantayan para sa komunikasyon ng MCP server-to-client sa kasalukuyang espesipikasyon, na nagbibigay ng ligtas na komunikasyon batay sa subprocess, [sa aralin](05-stdio-server/README.md)

- **6 HTTP Streaming gamit ang MCP (Streamable HTTP)**. Alamin ang tungkol sa modernong HTTP streaming, mga progress notification, at kung paano ipatupad ang scalable, real-time na MCP servers at clients gamit ang Streamable HTTP. [sa aralin](06-http-streaming/README.md)

- **7 Paggamit ng AI Toolkit para sa VSCode** upang magamit at subukan ang iyong MCP Clients at Servers [sa aralin](07-aitk/README.md)

- **8 Pagsusuri**. Dito tayo magtutuon ng pansin kung paano natin masusubukan ang ating server at kliyente sa iba't ibang paraan, [sa aralin](08-testing/README.md)

- **9 Deployment**. Ang kabanatang ito ay tatalakay sa iba't ibang paraan ng pag-deploy ng iyong mga MCP solution, [sa aralin](09-deployment/README.md)

Ang Model Context Protocol (MCP) ay isang bukas na protocol na nag-iistandardisa kung paano nagbibigay ng konteksto ang mga aplikasyon sa LLMs. Isipin ang MCP na parang USB-C port para sa mga AI application - nagbibigay ito ng istandardisadong paraan upang ikonekta ang mga AI model sa iba't ibang data sources at tools.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mo ang sumusunod:

- I-set up ang mga development environment para sa MCP sa C#, Java, Python, TypeScript, at JavaScript
- Gumawa at mag-deploy ng mga pangunahing MCP server na may custom na features (resources, prompts, at tools)
- Gumawa ng host applications na kumokonekta sa MCP servers
- Subukan at i-debug ang mga MCP implementation
- Maunawaan ang mga karaniwang hamon sa setup at ang kanilang mga solusyon
- Ikonekta ang iyong mga MCP implementation sa mga sikat na LLM services

## Pagsisimula sa Iyong MCP Environment

Bago ka magsimula sa MCP, mahalagang ihanda ang iyong development environment at maunawaan ang pangunahing workflow. Ang seksyong ito ay gagabay sa iyo sa mga unang hakbang ng setup upang masigurado ang maayos na pagsisimula sa MCP.

### Mga Kinakailangan

Bago sumabak sa MCP development, tiyakin na mayroon ka ng mga sumusunod:

- **Development Environment**: Para sa napili mong wika (C#, Java, Python, TypeScript, o JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, o anumang modernong code editor
- **Package Managers**: NuGet, Maven/Gradle, pip, o npm/yarn
- **API Keys**: Para sa anumang AI services na balak mong gamitin sa iyong host applications

### Opisyal na SDKs

Sa mga susunod na kabanata, makikita mo ang mga solusyon na ginawa gamit ang Python, TypeScript, Java, at .NET. Narito ang lahat ng opisyal na suportadong SDKs.

Nagbibigay ang MCP ng opisyal na SDKs para sa iba't ibang wika:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Pinapanatili sa pakikipagtulungan sa Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Pinapanatili sa pakikipagtulungan sa Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Ang opisyal na TypeScript implementation
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Ang opisyal na Python implementation
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Ang opisyal na Kotlin implementation
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Pinapanatili sa pakikipagtulungan sa Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Ang opisyal na Rust implementation

## Mahahalagang Puntos

- Ang pag-set up ng MCP development environment ay simple gamit ang mga language-specific SDKs
- Ang paggawa ng MCP servers ay nangangailangan ng paglikha at pagrehistro ng mga tools na may malinaw na schemas
- Ang MCP clients ay kumokonekta sa mga server at modelo upang magamit ang mga pinalawak na kakayahan
- Ang pagsusuri at pag-debug ay mahalaga para sa maaasahang MCP implementations
- Ang mga opsyon sa deployment ay mula sa lokal na development hanggang sa cloud-based na mga solusyon

## Pagsasanay

Mayroon kaming hanay ng mga halimbawa na sumusuporta sa mga ehersisyo na makikita mo sa lahat ng kabanata sa seksyong ito. Bukod dito, ang bawat kabanata ay mayroon ding sariling mga ehersisyo at takdang-aralin.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Karagdagang Mga Mapagkukunan

- [Gumawa ng Agents gamit ang Model Context Protocol sa Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP gamit ang Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Ano ang Susunod

Susunod: [Paglikha ng iyong unang MCP Server](01-first-server/README.md)

---

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagama't sinisikap naming maging tumpak, tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa kanyang katutubong wika ang dapat ituring na opisyal na sanggunian. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.