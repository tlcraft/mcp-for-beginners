<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d5b044c0924d393af3066e03d7d89c5",
  "translation_date": "2025-07-16T09:52:41+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "sr"
}
-->
### -2- Креирање пројекта

Сада када сте инсталирали свој SDK, хајде да направимо пројекат:

### -3- Креирање фајлова пројекта

### -4- Писање кода сервера

### -5- Додавање алата и ресурса

Додајте алат и ресурс тако што ћете унети следећи код:

### -6- Коначни код

Додајмо последњи део кода који је потребан да сервер може да се покрене:

### -7- Тестирање сервера

Покрените сервер помоћу следеће команде:

### -8- Покретање помоћу инспектора

Инспектор је одличан алат који може да покрене ваш сервер и омогућава вам интеракцију са њим како бисте тестирали да ли ради. Хајде да га покренемо:
> [!NOTE]
> може изгледати другачије у пољу „command“ јер садржи команду за покретање сервера са вашим специфичним runtime-ом
Требало би да видите следећи кориснички интерфејс:

![Connect](/03-GettingStarted/01-first-server/assets/connect.png)

1. Повежите се на сервер тако што ћете изабрати дугме Connect
  Када се повежете на сервер, требало би да видите следеће:

  ![Connected](/03-GettingStarted/01-first-server/assets/connected.png)

1. Изаберите "Tools" и "listTools", требало би да се појави "Add", изаберите "Add" и унесите вредности параметара.

  Требало би да видите следећи одговор, односно резултат из алата "add":

  ![Result of running add](/03-GettingStarted/01-first-server/assets/ran-tool.png)

Честитамо, успели сте да креирате и покренете свој први сервер!

### Званични SDK-ови

MCP пружа званичне SDK-ове за више језика:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Одржава се у сарадњи са Microsoft-ом
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Одржава се у сарадњи са Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Званична TypeScript имплементација
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Званична Python имплементација
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Званична Kotlin имплементација
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Одржава се у сарадњи са Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Званична Rust имплементација

## Кључне поуке

- Постављање MCP развојног окружења је једноставно уз SDK-ове специфичне за језик
- Креирање MCP сервера подразумева креирање и регистрацију алата са јасним шемама
- Тестирање и отклањање грешака су неопходни за поуздане MCP имплементације

## Примери

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Задатак

Креирајте једноставан MCP сервер са алатом по вашем избору:

1. Имплементирајте алат у жељеном језику (.NET, Java, Python или JavaScript).
2. Дефинишите улазне параметре и повратне вредности.
3. Покрените инспектор алат да бисте проверили да ли сервер ради како треба.
4. Тестирајте имплементацију са различитим улазима.

## Решење

[Solution](./solution/README.md)

## Додатни ресурси

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Шта следи

Следеће: [Getting Started with MCP Clients](../02-client/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која произилазе из коришћења овог превода.