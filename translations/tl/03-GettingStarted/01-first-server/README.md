<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "37563349cd6894fe00489bf3b4d488ae",
  "translation_date": "2025-06-02T10:39:51+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "tl"
}
-->
### -2- Lumikha ng proyekto

Ngayon na na-install mo na ang iyong SDK, lumikha tayo ng proyekto sa susunod:

### -3- Lumikha ng mga file ng proyekto

### -4- Lumikha ng code ng server

### -5- Magdagdag ng tool at resource

Magdagdag ng tool at resource sa pamamagitan ng paglalagay ng sumusunod na code:

### -6- Panghuling code

Idagdag natin ang huling code na kailangan para makapagsimula ang server:

### -7- Subukan ang server

Simulan ang server gamit ang sumusunod na utos:

### -8- Patakbuhin gamit ang inspector

Ang inspector ay isang mahusay na tool na maaaring magsimula ng iyong server at pahintulutan kang makipag-ugnayan dito para masubukan kung gumagana ito. Simulan natin ito:

> [!NOTE]
> maaaring magkaiba ang itsura nito sa "command" field dahil naglalaman ito ng utos para patakbuhin ang server gamit ang iyong partikular na runtime/

Makikita mo ang sumusunod na user interface:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.tl.png)

1. Kumonekta sa server sa pamamagitan ng pagpili sa Connect button  
  Kapag nakakonekta ka na sa server, makikita mo na ang sumusunod:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.tl.png)

1. Piliin ang "Tools" at "listTools", makikita mo ang "Add" na lalabas, piliin ang "Add" at punan ang mga halaga ng parameter.

  Makikita mo ang sumusunod na tugon, ibig sabihin ay resulta mula sa "add" tool:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.tl.png)

Congrats, nagawa mo nang likhain at patakbuhin ang iyong unang server!

### Opisyal na mga SDK

Nagbibigay ang MCP ng opisyal na mga SDK para sa iba't ibang wika:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Pinananatili kasama ang Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Pinananatili kasama ang Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Ang opisyal na implementasyon sa TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Ang opisyal na implementasyon sa Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Ang opisyal na implementasyon sa Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Pinananatili kasama ang Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Ang opisyal na implementasyon sa Rust

## Mahahalagang Punto

- Madaling mag-setup ng MCP development environment gamit ang mga SDK na nakatutok sa bawat wika
- Ang paggawa ng MCP servers ay nangangailangan ng paglikha at pagrerehistro ng mga tools na may malinaw na mga schema
- Mahalaga ang pagsusuri at pag-debug para sa maaasahang MCP implementations

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Takdang Aralin

Gumawa ng isang simpleng MCP server na may tool na iyong pipiliin:
1. I-implement ang tool gamit ang iyong paboritong wika (.NET, Java, Python, o JavaScript).
2. Tukuyin ang mga input parameter at mga return value.
3. Patakbuhin ang inspector tool para matiyak na gumagana ang server ayon sa inaasahan.
4. Subukan ang implementasyon gamit ang iba't ibang inputs.

## Solusyon

[Solution](./solution/README.md)

## Karagdagang Mga Mapagkukunan

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Ano ang susunod

Susunod: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o kamalian. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na pinagmulan ng katotohanan. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.