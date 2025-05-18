<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:13:30+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "tl"
}
-->
## Pagsisimula  

Ang seksyong ito ay binubuo ng ilang mga aralin:

- **-1- Ang iyong unang server**, sa unang araling ito, matututuhan mo kung paano gumawa ng iyong unang server at suriin ito gamit ang inspector tool, isang mahalagang paraan upang subukan at i-debug ang iyong server, [sa aralin](/03-GettingStarted/01-first-server/README.md)

- **-2- Kliyente**, sa araling ito, matututuhan mo kung paano sumulat ng kliyente na maaaring kumonekta sa iyong server, [sa aralin](/03-GettingStarted/02-client/README.md)

- **-3- Kliyente na may LLM**, isang mas mahusay na paraan ng pagsulat ng kliyente ay sa pamamagitan ng pagdaragdag ng LLM upang makapag "negotiate" ito sa iyong server kung ano ang gagawin, [sa aralin](/03-GettingStarted/03-llm-client/README.md)

- **-4- Paggamit ng server sa GitHub Copilot Agent mode sa Visual Studio Code**. Dito, tinitingnan natin ang pagpapatakbo ng ating MCP Server mula sa loob ng Visual Studio Code, [sa aralin](/03-GettingStarted/04-vscode/README.md)

- **-5- Paggamit mula sa SSE (Server Sent Events)** Ang SSE ay isang pamantayan para sa streaming mula sa server papunta sa kliyente, na nagpapahintulot sa mga server na magpadala ng mga real-time na update sa mga kliyente sa pamamagitan ng HTTP [sa aralin](/03-GettingStarted/05-sse-server/README.md)

- **-6- Paggamit ng AI Toolkit para sa VSCode** upang gamitin at subukan ang iyong MCP Clients at Servers [sa aralin](/03-GettingStarted/06-aitk/README.md)

- **-7 Pagsusuri**. Dito tayo magtutuon lalo na kung paano natin masusubukan ang ating server at kliyente sa iba't ibang paraan, [sa aralin](/03-GettingStarted/07-testing/README.md)

- **-8- Deployment**. Ang kabanatang ito ay tatalakay sa iba't ibang paraan ng pag-deploy ng iyong MCP solutions, [sa aralin](/03-GettingStarted/08-deployment/README.md)


Ang Model Context Protocol (MCP) ay isang bukas na protocol na nag-i-standardize kung paano nagbibigay ng konteksto ang mga aplikasyon sa LLMs. Isipin ang MCP na parang USB-C port para sa AI applications - nagbibigay ito ng isang standardized na paraan upang ikonekta ang mga AI models sa iba't ibang data sources at tools.

## Mga Layunin sa Pag-aaral

Sa pagtatapos ng araling ito, magagawa mong:

- Mag-set up ng development environments para sa MCP sa C#, Java, Python, TypeScript, at JavaScript
- Gumawa at mag-deploy ng mga pangunahing MCP server na may custom na mga tampok (mga resources, prompts, at tools)
- Lumikha ng mga host applications na kumokonekta sa MCP servers
- Subukan at i-debug ang mga implementasyon ng MCP
- Maunawaan ang mga karaniwang hamon sa setup at ang kanilang mga solusyon
- Ikonekta ang iyong mga implementasyon ng MCP sa mga sikat na serbisyo ng LLM

## Pagse-set Up ng Iyong MCP Environment

Bago ka magsimula sa MCP, mahalagang ihanda ang iyong development environment at maunawaan ang pangunahing workflow. Ang seksyong ito ay gagabay sa iyo sa mga paunang hakbang sa setup upang matiyak ang isang maayos na simula sa MCP.

### Mga Paunang Kailangan

Bago sumabak sa pag-develop ng MCP, tiyakin na mayroon ka ng:

- **Development Environment**: Para sa napili mong wika (C#, Java, Python, TypeScript, o JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, o anumang modernong code editor
- **Package Managers**: NuGet, Maven/Gradle, pip, o npm/yarn
- **API Keys**: Para sa anumang AI services na plano mong gamitin sa iyong host applications


### Opisyal na SDKs

Sa mga susunod na kabanata makikita mo ang mga solusyong ginawa gamit ang Python, TypeScript, Java at .NET. Narito ang lahat ng opisyal na suportadong SDKs.

Nagbibigay ang MCP ng mga opisyal na SDKs para sa maraming wika:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Pinapanatili sa pakikipagtulungan sa Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Pinapanatili sa pakikipagtulungan sa Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Ang opisyal na TypeScript na implementasyon
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Ang opisyal na Python na implementasyon
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Ang opisyal na Kotlin na implementasyon
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Pinapanatili sa pakikipagtulungan sa Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Ang opisyal na Rust na implementasyon

## Mga Pangunahing Punto

- Ang pag-set up ng isang MCP development environment ay diretso gamit ang mga language-specific na SDKs
- Ang paggawa ng MCP servers ay kinabibilangan ng paglikha at pagrerehistro ng mga tools na may malinaw na schemas
- Ang mga MCP clients ay kumokonekta sa mga server at modelo upang gamitin ang mga pinalawak na kakayahan
- Ang pagsusuri at pag-debug ay mahalaga para sa maaasahang implementasyon ng MCP
- Ang mga pagpipilian sa deployment ay mula sa lokal na pag-unlad hanggang sa cloud-based na mga solusyon

## Pagsasanay

Mayroon kaming hanay ng mga halimbawa na umaakma sa mga ehersisyo na makikita mo sa lahat ng kabanata sa seksyong ito. Bukod pa rito, ang bawat kabanata ay mayroon ding kanilang sariling mga ehersisyo at gawain

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Karagdagang Mga Mapagkukunan

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Ano ang susunod

Susunod: [Paglikha ng iyong unang MCP Server](/03-GettingStarted/01-first-server/README.md)

**Pagtatatuwa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Habang pinagsusumikapan naming maging tumpak, mangyaring tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga error o hindi pagkakatumpak. Ang orihinal na dokumento sa kanyang katutubong wika ang dapat ituring na mapagkakatiwalaang pinagmulan. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasaling-wika ng tao. Hindi kami mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na nagmumula sa paggamit ng pagsasaling ito.