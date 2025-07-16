<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d5b044c0924d393af3066e03d7d89c5",
  "translation_date": "2025-07-16T09:35:05+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ru"
}
-->
### -2- Создание проекта

Теперь, когда у вас установлен SDK, давайте создадим проект:

### -3- Создание файлов проекта

### -4- Написание кода сервера

### -5- Добавление инструмента и ресурса

Добавьте инструмент и ресурс, добавив следующий код:

### -6 Финальный код

Добавим последний необходимый код, чтобы сервер мог запуститься:

### -7- Тестирование сервера

Запустите сервер с помощью следующей команды:

### -8- Запуск с использованием инспектора

Инспектор — отличный инструмент, который может запустить ваш сервер и позволит вам взаимодействовать с ним для проверки его работы. Давайте запустим его:
> [!NOTE]  
> в поле "command" это может выглядеть иначе, так как там указана команда для запуска сервера с вашим конкретным runtime/
Вы должны увидеть следующий пользовательский интерфейс:

![Connect](/03-GettingStarted/01-first-server/assets/connect.png)

1. Подключитесь к серверу, нажав кнопку Connect  
   После подключения к серверу вы увидите следующее:

   ![Connected](/03-GettingStarted/01-first-server/assets/connected.png)

1. Выберите "Tools" и "listTools", вы увидите появившуюся опцию "Add", выберите "Add" и заполните значения параметров.

   Вы должны увидеть следующий ответ, то есть результат работы инструмента "add":

   ![Result of running add](/03-GettingStarted/01-first-server/assets/ran-tool.png)

Поздравляем, вы успешно создали и запустили свой первый сервер!

### Официальные SDK

MCP предоставляет официальные SDK для нескольких языков:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) — поддерживается в сотрудничестве с Microsoft  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) — поддерживается в сотрудничестве с Spring AI  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) — официальная реализация на TypeScript  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) — официальная реализация на Python  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) — официальная реализация на Kotlin  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) — поддерживается в сотрудничестве с Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) — официальная реализация на Rust  

## Основные выводы

- Настройка среды разработки MCP проста благодаря SDK для конкретных языков  
- Создание MCP серверов включает создание и регистрацию инструментов с чёткими схемами  
- Тестирование и отладка необходимы для надёжной реализации MCP  

## Примеры

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Задание

Создайте простой MCP сервер с инструментом на ваш выбор:

1. Реализуйте инструмент на предпочитаемом языке (.NET, Java, Python или JavaScript).  
2. Определите входные параметры и возвращаемые значения.  
3. Запустите инспектор, чтобы убедиться, что сервер работает корректно.  
4. Проверьте реализацию с разными входными данными.  

## Решение

[Решение](./solution/README.md)

## Дополнительные ресурсы

- [Создание агентов с использованием Model Context Protocol на Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Удалённый MCP с Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## Что дальше

Далее: [Начало работы с MCP клиентами](../02-client/README.md)

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, просим учитывать, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для получения критически важной информации рекомендуется обращаться к профессиональному переводу, выполненному человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.