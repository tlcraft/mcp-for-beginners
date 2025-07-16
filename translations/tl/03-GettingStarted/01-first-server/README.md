<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d5b044c0924d393af3066e03d7d89c5",
  "translation_date": "2025-07-16T09:49:20+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "tl"
}
-->
### -2- Gumawa ng proyekto

Ngayon na na-install mo na ang iyong SDK, gumawa tayo ng proyekto: 

### -3- Gumawa ng mga file ng proyekto

### -4- Gumawa ng code ng server

### -5- Magdagdag ng tool at resource

Magdagdag ng tool at resource sa pamamagitan ng paglalagay ng sumusunod na code:

### -6 Panghuling code

Idagdag natin ang huling code na kailangan para makapagsimula ang server:

### -7- Subukan ang server

Simulan ang server gamit ang sumusunod na utos:

### -8- Patakbuhin gamit ang inspector

Ang inspector ay isang mahusay na tool na maaaring magpatakbo ng iyong server at payagan kang makipag-ugnayan dito upang masubukan kung gumagana ito. Simulan natin ito:
> [!NOTE]
> maaaring magmukhang iba ito sa "command" field dahil naglalaman ito ng utos para patakbuhin ang server gamit ang iyong partikular na runtime/
Dapat mong makita ang sumusunod na user interface:

![Connect](/03-GettingStarted/01-first-server/assets/connect.png)

1. Kumonekta sa server sa pamamagitan ng pagpili sa Connect button  
  Kapag nakakonekta ka na sa server, dapat mong makita ang sumusunod:

  ![Connected](/03-GettingStarted/01-first-server/assets/connected.png)

1. Piliin ang "Tools" at "listTools", dapat lumabas ang "Add", piliin ang "Add" at punan ang mga halaga ng parameter.

  Makikita mo ang sumusunod na tugon, ibig sabihin ay resulta mula sa "add" tool:

  ![Result of running add](/03-GettingStarted/01-first-server/assets/ran-tool.png)

Congrats, nagawa mo nang gumawa at patakbuhin ang iyong unang server!

### Official SDKs

Nagbibigay ang MCP ng opisyal na SDK para sa iba't ibang wika:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Pinapanatili kasama ang Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Pinapanatili kasama ang Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Ang opisyal na implementasyon ng TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Ang opisyal na implementasyon ng Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Ang opisyal na implementasyon ng Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Pinapanatili kasama ang Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Ang opisyal na implementasyon ng Rust

## Mga Pangunahing Punto

- Madaling mag-setup ng MCP development environment gamit ang mga SDK na nakatuon sa wika
- Ang paggawa ng MCP servers ay nangangailangan ng paglikha at pagrerehistro ng mga tool na may malinaw na mga schema
- Mahalaga ang pagsubok at pag-debug para sa maaasahang implementasyon ng MCP

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Takdang-Aralin

Gumawa ng simpleng MCP server gamit ang tool na iyong pipiliin:

1. I-implementa ang tool sa iyong gustong wika (.NET, Java, Python, o JavaScript).
2. Tukuyin ang mga input parameter at mga return value.
3. Patakbuhin ang inspector tool upang matiyak na gumagana ang server ayon sa inaasahan.
4. Subukan ang implementasyon gamit ang iba't ibang input.

## Solusyon

[Solution](./solution/README.md)

## Karagdagang Mga Mapagkukunan

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Ano ang susunod

Susunod: [Getting Started with MCP Clients](../02-client/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.