<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90651bcd1df019768921d531653638a",
  "translation_date": "2025-06-12T23:11:43+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "mo"
}
-->
### -2- Ստեղծել նախագիծ

Այժմ, երբ դուք տեղադրել եք SDK-ն, եկեք հաջորդ քայլը կատարենք՝ ստեղծենք նախագիծ։

### -3- Ստեղծել նախագծի ֆայլերը

### -4- Ստեղծել սերվերի կոդը

### -5- Ավելացնել գործիք և ռեսուրս

Ավելացրեք գործիք և ռեսուրս՝ հետևյալ կոդը ավելացնելով.

### -6- Վերջնական կոդ

Ավելացնենք վերջին կոդը, որը անհրաժեշտ է սերվերը սկսելու համար.

### -7- Թեստավորել սերվերը

Սերվերը սկսեք հետևյալ հրամանով.

### -8- Օգտագործել inspector-ը

Inspector-ը հիանալի գործիք է, որը կարող է սկսել ձեր սերվերը և թույլ է տալիս փոխազդել դրա հետ՝ ստուգելու համար, որ այն աշխատում է։ Եկեք սկսենք.

> [!NOTE]
> Հնարավոր է, որ "command" դաշտում տեսքը տարբերվի, քանի որ այնտեղ նշված է ձեր ընտրած runtime-ի սերվեր սկսելու հրամանը։

Դուք պետք է տեսնեք հետևյալ օգտվողային միջերեսը.

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.mo.png)

1. Կապվեք սերվերի հետ՝ ընտրելով Connect կոճակը։ Կապվելուց հետո դուք պետք է տեսնեք հետևյալը.

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.mo.png)

2. Ընտրեք "Tools" և "listTools", ապա պետք է տեսնեք "Add" գործիքը, ընտրեք "Add" և լրացրեք պարամետրերի արժեքները։

  Դուք պետք է տեսնեք հետևյալ պատասխանը, այսինքն՝ "add" գործիքի արդյունքը.

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.mo.png)

Շնորհավորում ենք, դուք հաջողությամբ ստեղծել և գործարկել եք ձեր առաջին սերվերը։

### Պաշտոնական SDK-ներ

MCP-ն տրամադրում է պաշտոնական SDK-ներ մի քանի լեզուների համար՝
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Maintained in collaboration with Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Maintained in collaboration with Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - The official TypeScript implementation
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - The official Python implementation
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - The official Kotlin implementation
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Maintained in collaboration with Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - The official Rust implementation

## Հիմնական եզրակացություններ

- MCP զարգացման միջավայրի կարգավորումը պարզ է՝ օգտագործելով լեզվային SDK-ներ
- MCP սերվերների կառուցումը ներառում է գործիքների ստեղծում և գրանցում հստակ սխեմաներով
- Թեստավորումն ու սխալների շտկումը կարևոր են MCP-ի վստահելի իրագործումների համար

## Նմուշներ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Առաջադրանք

Ստեղծեք պարզ MCP սերվեր՝ ձեր ընտրած գործիքով.
1. Իրականացրեք գործիքը ձեր նախընտրած լեզվով (.NET, Java, Python կամ JavaScript)։
2. Նշեք մուտքային պարամետրերը և վերադարձվող արժեքները։
3. Օգտագործեք inspector գործիքը՝ համոզվելու համար, որ սերվերը աշխատում է։
4. Թեստավորեք իրագործումը տարբեր մուտքային տվյալներով։

## Լուծում

[Solution](./solution/README.md)

## Լրացուցիչ ռեսուրսներ

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Ինչ է հաջորդը

Հաջորդը՝ [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Disclaimer**:  
This document has been translated using AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.

---

Could you please clarify what language or dialect "mo" refers to? There are several possibilities (e.g., Moldovan, a shorthand for a language, or a constructed language). Providing more context will help me give you an accurate translation.