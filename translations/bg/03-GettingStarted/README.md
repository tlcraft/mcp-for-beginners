<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "97f1c99b5b12cf03d4b1be68b3636a4a",
  "translation_date": "2025-07-04T18:54:10+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "bg"
}
-->
## Започване  

Този раздел се състои от няколко урока:

- **1 Вашият първи сървър**, в този първи урок ще научите как да създадете първия си сървър и да го инспектирате с инструмента inspector, полезен начин за тестване и отстраняване на грешки на сървъра, [към урока](/03-GettingStarted/01-first-server/README.md)

- **2 Клиент**, в този урок ще научите как да напишете клиент, който може да се свърже с вашия сървър, [към урока](/03-GettingStarted/02-client/README.md)

- **3 Клиент с LLM**, още по-добър начин за писане на клиент е като добавите LLM, така че той да може да "преговаря" със сървъра какво да прави, [към урока](/03-GettingStarted/03-llm-client/README.md)

- **4 Използване на режим GitHub Copilot Agent в Visual Studio Code**. Тук разглеждаме как да стартираме нашия MCP сървър директно от Visual Studio Code, [към урока](/03-GettingStarted/04-vscode/README.md)

- **5 Консумиране от SSE (Server Sent Events)** SSE е стандарт за стрийминг от сървър към клиент, позволяващ на сървърите да изпращат актуализации в реално време към клиентите през HTTP [към урока](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP стрийминг с MCP (Streamable HTTP)**. Научете за съвременния HTTP стрийминг, известия за напредък и как да реализирате мащабируеми, реално-времеви MCP сървъри и клиенти с помощта на Streamable HTTP. [към урока](/03-GettingStarted/06-http-streaming/README.md)

- **7 Използване на AI Toolkit за VSCode** за консумиране и тестване на вашите MCP клиенти и сървъри [към урока](/03-GettingStarted/07-aitk/README.md)

- **8 Тестване**. Тук ще се фокусираме специално върху различни начини за тестване на нашия сървър и клиент, [към урока](/03-GettingStarted/08-testing/README.md)

- **9 Деплоймънт**. Тази глава разглежда различни начини за разгръщане на вашите MCP решения, [към урока](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) е отворен протокол, който стандартизира начина, по който приложенията предоставят контекст на LLM. Мислете за MCP като за USB-C порт за AI приложения - той осигурява стандартизиран начин за свързване на AI модели с различни източници на данни и инструменти.

## Учебни цели

Към края на този урок ще можете да:

- Настроите среди за разработка за MCP на C#, Java, Python, TypeScript и JavaScript
- Създавате и разгръщате базови MCP сървъри с персонализирани функции (ресурси, подсказки и инструменти)
- Създавате хост приложения, които се свързват с MCP сървъри
- Тествате и отстранявате грешки в MCP реализации
- Разбирате често срещани предизвикателства при настройка и техните решения
- Свързвате вашите MCP реализации с популярни LLM услуги

## Настройване на вашата MCP среда

Преди да започнете работа с MCP, е важно да подготвите средата си за разработка и да разберете основния работен процес. Този раздел ще ви преведе през началните стъпки за гладък старт с MCP.

### Предварителни изисквания

Преди да се потопите в разработката с MCP, уверете се, че разполагате с:

- **Среда за разработка**: за избрания от вас език (C#, Java, Python, TypeScript или JavaScript)
- **IDE/редактор**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm или друг модерен редактор за код
- **Мениджъри на пакети**: NuGet, Maven/Gradle, pip или npm/yarn
- **API ключове**: за всички AI услуги, които планирате да използвате във вашите хост приложения


### Официални SDK

В следващите глави ще видите решения, изградени с Python, TypeScript, Java и .NET. Ето всички официално поддържани SDK.

MCP предоставя официални SDK за няколко езика:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Поддържан в сътрудничество с Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Поддържан в сътрудничество със Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Официалната TypeScript имплементация
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Официалната Python имплементация
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Официалната Kotlin имплементация
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Поддържан в сътрудничество с Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Официалната Rust имплементация

## Основни изводи

- Настройването на MCP среда за разработка е лесно с езиково-специфични SDK
- Създаването на MCP сървъри включва създаване и регистриране на инструменти с ясни схеми
- MCP клиентите се свързват със сървъри и модели, за да използват разширени възможности
- Тестването и отстраняването на грешки са ключови за надеждни MCP реализации
- Възможностите за разгръщане варират от локална разработка до облачни решения

## Практика

Имаме набор от примери, които допълват упражненията във всички глави от този раздел. Освен това всяка глава има свои собствени упражнения и задачи

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Допълнителни ресурси

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Какво следва

Следва: [Създаване на вашия първи MCP сървър](./01-first-server/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.