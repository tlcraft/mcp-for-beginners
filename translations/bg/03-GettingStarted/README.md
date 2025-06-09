<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:46:41+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "bg"
}
-->
## Започване  

Този раздел съдържа няколко урока:

- **-1- Вашият първи сървър**, в този първи урок ще научите как да създадете първия си сървър и да го инспектирате с инструмента inspector, ценен начин за тестване и отстраняване на грешки в сървъра ви, [към урока](/03-GettingStarted/01-first-server/README.md)

- **-2- Клиент**, в този урок ще научите как да напишете клиент, който може да се свърже с вашия сървър, [към урока](/03-GettingStarted/02-client/README.md)

- **-3- Клиент с LLM**, още по-добър начин за писане на клиент е като добавите LLM, така че той да може да "преговаря" със сървъра какво да прави, [към урока](/03-GettingStarted/03-llm-client/README.md)

- **-4- Използване на режим GitHub Copilot Agent на сървър в Visual Studio Code**. Тук разглеждаме как да стартираме нашия MCP сървър директно от Visual Studio Code, [към урока](/03-GettingStarted/04-vscode/README.md)

- **-5- Използване на SSE (Server Sent Events)** SSE е стандарт за стрийминг от сървър към клиент, позволяващ на сървърите да изпращат актуализации в реално време към клиентите през HTTP [към урока](/03-GettingStarted/05-sse-server/README.md)

- **-6- Използване на AI Toolkit за VSCode** за консумиране и тестване на вашите MCP клиенти и сървъри [към урока](/03-GettingStarted/06-aitk/README.md)

- **-7 Тестване**. Тук ще се фокусираме специално върху различни начини за тестване на нашия сървър и клиент, [към урока](/03-GettingStarted/07-testing/README.md)

- **-8- Разгръщане**. Тази глава разглежда различни начини за разгръщане на вашите MCP решения, [към урока](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) е отворен протокол, който стандартизира начина, по който приложенията предоставят контекст на LLM. Мислете за MCP като за USB-C порт за AI приложения – той осигурява стандартизиран начин за свързване на AI модели с различни източници на данни и инструменти.

## Учебни цели

Към края на този урок ще можете да:

- Настроите развойна среда за MCP на C#, Java, Python, TypeScript и JavaScript
- Създавате и разгръщате базови MCP сървъри с персонализирани функции (ресурси, подканващи съобщения и инструменти)
- Създавате хост приложения, които се свързват с MCP сървъри
- Тествате и отстранявате грешки в MCP реализации
- Разбирате често срещани предизвикателства при настройка и техните решения
- Свързвате вашите MCP реализации с популярни LLM услуги

## Настройване на MCP средата

Преди да започнете работа с MCP, е важно да подготвите развойната си среда и да разберете основния работен процес. Този раздел ще ви преведе през първоначалните стъпки за настройка, за да осигури гладък старт с MCP.

### Предварителни изисквания

Преди да започнете разработка с MCP, уверете се, че разполагате с:

- **Развойна среда**: за избрания от вас език (C#, Java, Python, TypeScript или JavaScript)
- **IDE/редактор**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm или друг модерен редактор за код
- **Пакетни мениджъри**: NuGet, Maven/Gradle, pip или npm/yarn
- **API ключове**: за всички AI услуги, които планирате да използвате във вашите хост приложения


### Официални SDK

В следващите глави ще видите решения, изградени с Python, TypeScript, Java и .NET. Ето всички официално поддържани SDK-та.

MCP предоставя официални SDK-та за няколко езика:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Поддържан в сътрудничество с Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Поддържан в сътрудничество с Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Официалната TypeScript реализация
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Официалната Python реализация
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Официалната Kotlin реализация
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Поддържан в сътрудничество с Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Официалната Rust реализация

## Основни изводи

- Настройването на развойна среда за MCP е лесно с езиково-специфични SDK-та
- Създаването на MCP сървъри включва създаване и регистриране на инструменти с ясни схеми
- MCP клиентите се свързват със сървъри и модели, за да използват разширени възможности
- Тестването и отстраняването на грешки са от съществено значение за надеждни MCP реализации
- Възможностите за разгръщане варират от локална разработка до облачни решения

## Практика

Имаме набор от примери, които допълват упражненията, които ще видите във всички глави от този раздел. Освен това всяка глава има свои собствени упражнения и задачи

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Допълнителни ресурси

- [Създаване на агенти с Model Context Protocol в Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Отдалечен MCP с Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Какво следва

Следва: [Създаване на вашия първи MCP сървър](/03-GettingStarted/01-first-server/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи може да съдържат грешки или неточности. Оригиналният документ на неговия език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или погрешни тълкувания, произтичащи от използването на този превод.