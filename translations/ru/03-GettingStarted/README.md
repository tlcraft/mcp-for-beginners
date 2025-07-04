<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "97f1c99b5b12cf03d4b1be68b3636a4a",
  "translation_date": "2025-07-04T15:33:29+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ru"
}
-->
## Начало работы  

Этот раздел состоит из нескольких уроков:

- **1 Ваш первый сервер**, в этом первом уроке вы научитесь создавать свой первый сервер и исследовать его с помощью инструмента инспектора — полезного способа тестирования и отладки сервера, [к уроку](/03-GettingStarted/01-first-server/README.md)

- **2 Клиент**, в этом уроке вы узнаете, как написать клиента, который может подключаться к вашему серверу, [к уроку](/03-GettingStarted/02-client/README.md)

- **3 Клиент с LLM**, ещё более продвинутый способ написания клиента — добавить в него LLM, чтобы он мог "договариваться" с сервером о дальнейших действиях, [к уроку](/03-GettingStarted/03-llm-client/README.md)

- **4 Использование режима агента GitHub Copilot сервера в Visual Studio Code**. Здесь мы рассмотрим запуск MCP Server прямо из Visual Studio Code, [к уроку](/03-GettingStarted/04-vscode/README.md)

- **5 Использование SSE (Server Sent Events)**. SSE — это стандарт для потоковой передачи от сервера к клиенту, позволяющий серверам отправлять обновления в реальном времени по HTTP, [к уроку](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP-стриминг с MCP (Streamable HTTP)**. Узнайте о современном HTTP-стриминге, уведомлениях о прогрессе и о том, как реализовать масштабируемые MCP-серверы и клиенты в реальном времени с помощью Streamable HTTP, [к уроку](/03-GettingStarted/06-http-streaming/README.md)

- **7 Использование AI Toolkit для VSCode** для работы с MCP-клиентами и серверами и их тестирования, [к уроку](/03-GettingStarted/07-aitk/README.md)

- **8 Тестирование**. Здесь мы сосредоточимся на различных способах тестирования сервера и клиента, [к уроку](/03-GettingStarted/08-testing/README.md)

- **9 Развёртывание**. В этой главе рассмотрим разные способы развёртывания ваших MCP-решений, [к уроку](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) — это открытый протокол, стандартизирующий способ предоставления контекста LLM приложениями. Представьте MCP как USB-C порт для AI-приложений — он обеспечивает единый способ подключения AI-моделей к различным источникам данных и инструментам.

## Цели обучения

К концу этого урока вы сможете:

- Настроить среды разработки для MCP на C#, Java, Python, TypeScript и JavaScript
- Создавать и развёртывать базовые MCP-серверы с пользовательскими функциями (ресурсы, подсказки и инструменты)
- Создавать хост-приложения, подключающиеся к MCP-серверам
- Тестировать и отлаживать реализации MCP
- Понимать распространённые проблемы настройки и способы их решения
- Подключать свои реализации MCP к популярным LLM-сервисам

## Настройка вашей среды MCP

Прежде чем начать работу с MCP, важно подготовить среду разработки и понять базовый рабочий процесс. В этом разделе вы пройдёте начальные шаги настройки для комфортного старта с MCP.

### Требования

Перед тем как приступить к разработке MCP, убедитесь, что у вас есть:

- **Среда разработки**: для выбранного языка (C#, Java, Python, TypeScript или JavaScript)
- **IDE/редактор**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm или любой современный редактор кода
- **Менеджеры пакетов**: NuGet, Maven/Gradle, pip или npm/yarn
- **API-ключи**: для любых AI-сервисов, которые вы планируете использовать в своих хост-приложениях


### Официальные SDK

В следующих главах вы увидите решения, построенные с использованием Python, TypeScript, Java и .NET. Вот все официально поддерживаемые SDK.

MCP предоставляет официальные SDK для нескольких языков:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) — поддерживается в сотрудничестве с Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) — поддерживается в сотрудничестве с Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) — официальная реализация на TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) — официальная реализация на Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) — официальная реализация на Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) — поддерживается в сотрудничестве с Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) — официальная реализация на Rust

## Основные выводы

- Настройка среды разработки MCP проста благодаря языковым SDK
- Создание MCP-серверов включает создание и регистрацию инструментов с чёткими схемами
- MCP-клиенты подключаются к серверам и моделям для расширения возможностей
- Тестирование и отладка необходимы для надёжных реализаций MCP
- Варианты развёртывания варьируются от локальной разработки до облачных решений

## Практика

У нас есть набор примеров, дополняющих упражнения, которые вы встретите во всех главах этого раздела. Кроме того, каждая глава содержит свои собственные упражнения и задания.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../../../03-GettingStarted/samples/javascript)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Дополнительные ресурсы

- [Создание агентов с использованием Model Context Protocol на Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Удалённый MCP с Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Что дальше

Далее: [Создание вашего первого MCP сервера](./01-first-server/README.md)

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, просим учитывать, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для получения критически важной информации рекомендуется обращаться к профессиональному переводу, выполненному человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.