<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bf05718d019040cf0c7d4ccc6d6a1a88",
  "translation_date": "2025-06-13T06:05:19+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "tl"
}
-->
### -2- Gumawa ng proyekto

Ngayon na na-install mo na ang SDK mo, gumawa tayo ng proyekto: 

### -3- Gumawa ng mga file ng proyekto

### -4- Gumawa ng code ng server

### -5- Magdagdag ng tool at resource

Magdagdag ng tool at resource sa pamamagitan ng paglalagay ng sumusunod na code:

### -6 Panghuling code

Idagdag natin ang huling code na kailangan para makapagsimula ang server:

### -7- Subukan ang server

Simulan ang server gamit ang sumusunod na utos:

### -8- Patakbuhin gamit ang inspector

Ang inspector ay isang mahusay na tool na makakapagsimula ng iyong server at magpapahintulot sa iyo na makipag-ugnayan dito para masubukan kung gumagana ito. Simulan natin ito:

> [!NOTE]
> maaaring mag-iba ang hitsura nito sa "command" field dahil naglalaman ito ng utos para patakbuhin ang server gamit ang iyong partikular na runtime/

Makikita mo ang sumusunod na user interface:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.tl.png)

1. Kumonekta sa server sa pamamagitan ng pagpili sa Connect button  
  Kapag nakakonekta ka na sa server, makikita mo na ang sumusunod:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.tl.png)

2. Piliin ang "Tools" at "listTools", makikita mo ang "Add" na lalabas, piliin ang "Add" at punan ang mga halaga ng parameter.

  Makikita mo ang sumusunod na tugon, ibig sabihin ay resulta mula sa "add" tool:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.tl.png)

Congrats, nagawa mo nang likhain at patakbuhin ang iyong unang server!

### Opisyal na SDKs

Nagbibigay ang MCP ng opisyal na SDKs para sa iba't ibang wika:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Pinapanatili kasama ang Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Pinapanatili kasama ang Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Opisyal na implementasyon ng TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Opisyal na implementasyon ng Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Opisyal na implementasyon ng Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Pinapanatili kasama ang Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Opisyal na implementasyon ng Rust

## Mahahalagang Punto

- Madaling mag-setup ng MCP development environment gamit ang mga SDK na nakatuon sa partikular na wika
- Ang paggawa ng MCP servers ay nangangailangan ng paglikha at pagrerehistro ng mga tools na may malinaw na mga schema
- Mahalaga ang pagsubok at pag-debug para sa maaasahang implementasyon ng MCP

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Takdang-Aralin

Gumawa ng simpleng MCP server na may tool na iyong pipiliin:
1. I-implementa ang tool sa iyong paboritong wika (.NET, Java, Python, o JavaScript).
2. Tukuyin ang mga input parameter at mga return value.
3. Patakbuhin ang inspector tool upang matiyak na gumagana ang server ayon sa inaasahan.
4. Subukan ang implementasyon gamit ang iba't ibang inputs.

## Solusyon

[Solusyon](./solution/README.md)

## Karagdagang mga Mapagkukunan

- [Build Agents gamit ang Model Context Protocol sa Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP gamit ang Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Ano ang susunod

Susunod: [Panimula sa MCP Clients](/03-GettingStarted/02-client/README.md)

**Pagtatapat**:  
Ang dokumentong ito ay isinalin gamit ang serbisyong AI na pagsasalin [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na opisyal na sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na nagmumula sa paggamit ng pagsasaling ito.