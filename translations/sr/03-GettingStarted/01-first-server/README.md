<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f01d4263fc6eec331615fef42429b720",
  "translation_date": "2025-06-18T18:27:35+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "sr"
}
-->
### -2- Креирање пројекта

Сада када сте инсталирали SDK, хајде да креирамо пројекат:

### -3- Креирање фајлова пројекта

### -4- Писање кода сервера

### -5- Додавање алата и ресурса

Додајте алат и ресурс тако што ћете унети следећи код:

### -6- Коначни код

Хајде да додамо последњи део кода који је потребан да сервер може да се покрене:

### -7- Тестирање сервера

Покрените сервер са следећом командом:

### -8- Покретање помоћу инспектора

Инспектор је одличан алат који може да покрене ваш сервер и омогући вам интеракцију са њим како бисте тестирали да ли ради. Хајде да га покренемо:

> [!NOTE]
> у пољу „команда“ може изгледати другачије јер садржи команду за покретање сервера са вашим специфичним окружењем

Требало би да видите следећи кориснички интерфејс:

![Повежи](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sr.png)

1. Повежите се са сервером кликом на дугме Connect  
   Када се повежете са сервером, требало би да видите следеће:

   ![Повезано](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.sr.png)

2. Изаберите „Tools“ и „listTools“, требало би да се појави опција „Add“, изаберите „Add“ и унесите вредности параметара.

   Требало би да добијете следећи одговор, односно резултат из алата „add“:

   ![Резултат извршавања add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.sr.png)

Честитамо, успели сте да креирате и покренете свој први сервер!

### Званични SDK-ови

MCP нуди званичне SDK-ове за више програмских језика:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Одржава се у сарадњи са Microsoft-ом
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Одржава се у сарадњи са Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Званична TypeScript имплементација
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Званична Python имплементација
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Званична Kotlin имплементација
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Одржава се у сарадњи са Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Званична Rust имплементација

## Кључне појединости

- Постављање MCP развојног окружења је једноставно уз језички специфичне SDK-ове
- Изградња MCP сервера укључује креирање и регистрацију алата са јасним шемама
- Тестирање и отклањање грешака су кључни за поуздану MCP имплементацију

## Примери

- [Java Калкулатор](../samples/java/calculator/README.md)
- [.Net Калкулатор](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Калкулатор](../samples/javascript/README.md)
- [TypeScript Калкулатор](../samples/typescript/README.md)
- [Python Калкулатор](../../../../03-GettingStarted/samples/python)

## Задатак

Креирајте једноставан MCP сервер са алатом по вашем избору:

1. Имплементирајте алат у жељеном језику (.NET, Java, Python или JavaScript).
2. Дефинишите улазне параметре и повратне вредности.
3. Покрените инспектор алат да бисте проверили да ли сервер ради како треба.
4. Тестирајте имплементацију са различитим улазима.

## Решење

[Решење](./solution/README.md)

## Додатни ресурси

- [Креирање агената помоћу Model Context Protocol на Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Ремот MCP са Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP агент](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Шта следи

Следеће: [Почетак рада са MCP клијентима](/03-GettingStarted/02-client/README.md)

**Одрицање одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо прецизности, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Изворни документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења настала коришћењем овог превода.