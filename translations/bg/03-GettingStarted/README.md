<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:16:46+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "bg"
}
-->
## Започване  

Този раздел съдържа няколко урока:

- **1 Вашият първи сървър**, в този първи урок ще научите как да създадете първия си сървър и да го инспектирате с инструмента inspector, ценен начин за тестване и отстраняване на грешки на сървъра ви, [към урока](/03-GettingStarted/01-first-server/README.md)

- **2 Клиент**, в този урок ще научите как да напишете клиент, който може да се свърже със сървъра ви, [към урока](/03-GettingStarted/02-client/README.md)

- **3 Клиент с LLM**, още по-добър начин за писане на клиент е като добавите LLM, така че той да може да „преговаря“ със сървъра какво да прави, [към урока](/03-GettingStarted/03-llm-client/README.md)

- **4 Използване на режим GitHub Copilot Agent за сървър в Visual Studio Code**. Тук разглеждаме как да стартираме нашия MCP сървър от Visual Studio Code, [към урока](/03-GettingStarted/04-vscode/README.md)

- **5 Консумиране от SSE (Server Sent Events)** SSE е стандарт за стрийминг от сървър към клиент, позволяващ на сървърите да изпращат актуализации в реално време към клиентите през HTTP [към урока](/03-GettingStarted/05-sse-server/README.md)

- **6 Използване на AI Toolkit за VSCode** за консумиране и тестване на вашите MCP клиенти и сървъри [към урока](/03-GettingStarted/06-aitk/README.md)

- **7 Тестване**. Тук ще се фокусираме особено върху различните начини за тестване на нашия сървър и клиент, [към урока](/03-GettingStarted/07-testing/README.md)

- **8 Деплоймънт**. Тази глава разглежда различни начини за разгръщане на вашите MCP решения, [към урока](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) е отворен протокол, който стандартизира начина, по който приложенията предоставят контекст на LLM. Мислете за MCP като за USB-C порт за AI приложения – той осигурява стандартизиран начин за свързване на AI модели с различни източници на данни и инструменти.

## Цели на обучението

В края на този урок ще можете да:

- Настроите развойни среди за MCP на C#, Java, Python, TypeScript и JavaScript
- Създавате и разгръщате базови MCP сървъри с персонализирани функции (ресурси, подсказки и инструменти)
- Създавате хост приложения, които се свързват с MCP сървъри
- Тествате и отстранявате грешки в MCP имплементации
- Разбирате често срещани предизвикателства при настройка и техните решения
- Свързвате вашите MCP имплементации с популярни LLM услуги

## Настройка на MCP средата ви

Преди да започнете работа с MCP, важно е да подготвите развойната си среда и да разберете основния работен процес. Този раздел ще ви преведе през началните стъпки за настройка, за да осигури гладък старт с MCP.

### Предварителни изисквания

Преди да се потопите в разработката с MCP, уверете се, че разполагате с:

- **Развойна среда**: За избрания от вас език (C#, Java, Python, TypeScript или JavaScript)
- **IDE/Редактор**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm или друг модерен редактор за код
- **Пакетни мениджъри**: NuGet, Maven/Gradle, pip или npm/yarn
- **API ключове**: За всички AI услуги, които планирате да използвате в хост приложенията си

### Официални SDK-та

В следващите глави ще видите решения, изградени с Python, TypeScript, Java и .NET. Ето всички официално поддържани SDK-та.

MCP предоставя официални SDK-та за няколко езика:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Поддържан съвместно с Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Поддържан съвместно със Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Официалната TypeScript имплементация
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Официалната Python имплементация
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Официалната Kotlin имплементация
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Поддържан съвместно с Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Официалната Rust имплементация

## Основни изводи

- Настройването на развойна среда за MCP е лесно с езиково-специфични SDK-та
- Създаването на MCP сървъри включва създаване и регистриране на инструменти с ясни схеми
- MCP клиентите се свързват със сървъри и модели, за да използват разширени възможности
- Тестването и отстраняването на грешки са от съществено значение за надеждни MCP имплементации
- Възможностите за деплоймънт варират от локална разработка до решения в облака

## Практика

Имаме набор от примери, които допълват упражненията, които ще видите във всички глави в този раздел. Освен това всяка глава има свои собствени упражнения и задачи

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../../../03-GettingStarted/samples/javascript)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Допълнителни ресурси

- [Създаване на агенти с Model Context Protocol в Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Отдалечен MCP с Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Какво следва

Следва: [Създаване на първия ви MCP сървър](/03-GettingStarted/01-first-server/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.