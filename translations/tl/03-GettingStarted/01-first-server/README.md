<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f01d4263fc6eec331615fef42429b720",
  "translation_date": "2025-06-18T18:25:04+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "tl"
}
-->
### -2- Gumawa ng proyekto

Ngayon na na-install mo na ang iyong SDK, gumawa tayo ng proyekto sa susunod:

### -3- Gumawa ng mga file ng proyekto

### -4- Gumawa ng code ng server

### -5- Magdagdag ng tool at resource

Magdagdag ng tool at resource sa pamamagitan ng paglalagay ng sumusunod na code:

### -6 Huling code

Idagdag natin ang huling code na kailangan para makapagsimula ang server:

### -7- Subukan ang server

Simulan ang server gamit ang sumusunod na utos:

### -8- Patakbuhin gamit ang inspector

Ang inspector ay isang mahusay na tool na maaaring magpatakbo ng iyong server at payagan kang makipag-ugnayan dito para masubukan kung gumagana ito. Simulan natin ito:

> [!NOTE]
> maaaring mag-iba ang itsura nito sa "command" field dahil naglalaman ito ng utos para patakbuhin ang server gamit ang iyong partikular na runtime/

Makikita mo ang sumusunod na user interface:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.tl.png)

1. Kumonekta sa server sa pamamagitan ng pagpili sa Connect button  
   Kapag nakakonekta ka na sa server, makikita mo na ang sumusunod:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.tl.png)

2. Piliin ang "Tools" at "listTools", makikita mo ang "Add" na lalabas, piliin ang "Add" at punan ang mga halaga ng parameter.

   Makikita mo ang sumusunod na tugon, ibig sabihin ay resulta mula sa "add" tool:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.tl.png)

Congrats, nagawa mo nang gumawa at patakbuhin ang iyong unang server!

### Opisyal na mga SDK

Nagbibigay ang MCP ng opisyal na mga SDK para sa iba't ibang wika:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Pinapanatili sa pakikipagtulungan sa Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Pinapanatili sa pakikipagtulungan sa Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Ang opisyal na implementasyon ng TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Ang opisyal na implementasyon ng Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Ang opisyal na implementasyon ng Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Pinapanatili sa pakikipagtulungan sa Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Ang opisyal na implementasyon ng Rust

## Mahahalagang Punto

- Madaling mag-setup ng MCP development environment gamit ang mga SDK na partikular sa wika
- Ang paggawa ng MCP servers ay kinabibilangan ng paglikha at pagrerehistro ng mga tool na may malinaw na mga schema
- Mahalaga ang pagsubok at pag-debug para sa maaasahang implementasyon ng MCP

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Takdang-Aralin

Gumawa ng simpleng MCP server na may tool na iyong pipiliin:

1. I-implementa ang tool sa iyong gustong wika (.NET, Java, Python, o JavaScript).
2. Tukuyin ang mga input parameter at mga return value.
3. Patakbuhin ang inspector tool upang matiyak na gumagana ang server ayon sa inaasahan.
4. Subukan ang implementasyon gamit ang iba't ibang input.

## Solusyon

[Solusyon](./solution/README.md)

## Karagdagang mga Mapagkukunan

- [Gumawa ng Agents gamit ang Model Context Protocol sa Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP gamit ang Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Ano ang susunod

Susunod: [Panimula sa MCP Clients](/03-GettingStarted/02-client/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong salin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.