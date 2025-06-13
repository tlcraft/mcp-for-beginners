<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bf05718d019040cf0c7d4ccc6d6a1a88",
  "translation_date": "2025-06-13T05:50:48+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ru"
}
-->
### -2- Создание проекта

Теперь, когда SDK установлен, давайте создадим проект:

### -3- Создание файлов проекта

### -4- Создание кода сервера

### -5- Добавление инструмента и ресурса

Добавьте инструмент и ресурс, добавив следующий код:

### -6 Финальный код

Добавим последний необходимый код, чтобы сервер мог запуститься:

### -7- Тестирование сервера

Запустите сервер с помощью следующей команды:

### -8- Запуск с помощью инспектора

Инспектор — отличный инструмент, который может запустить ваш сервер и позволит вам взаимодействовать с ним для проверки его работы. Запустим его:

> [!NOTE]
> В поле "command" команда может выглядеть иначе, так как содержит команду запуска сервера для вашего конкретного окружения/runtime.

Вы увидите следующий пользовательский интерфейс:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ru.png)

1. Подключитесь к серверу, нажав кнопку Connect  
   После подключения вы увидите следующее:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ru.png)

2. Выберите "Tools" и "listTools", вы увидите появление "Add", нажмите на "Add" и заполните значения параметров.

   Вы увидите следующий ответ — результат работы инструмента "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ru.png)

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

- Настройка среды разработки MCP проста благодаря специализированным SDK для разных языков
- Создание MCP серверов включает разработку и регистрацию инструментов с чёткими схемами
- Тестирование и отладка необходимы для надёжной реализации MCP

## Примеры

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Задание

Создайте простой MCP сервер с инструментом по вашему выбору:
1. Реализуйте инструмент на предпочитаемом языке (.NET, Java, Python или JavaScript).
2. Определите входные параметры и возвращаемые значения.
3. Запустите инспектор, чтобы убедиться, что сервер работает корректно.
4. Проверьте реализацию с различными входными данными.

## Решение

[Решение](./solution/README.md)

## Дополнительные ресурсы

- [Создание агентов с использованием Model Context Protocol на Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Удалённый MCP с Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Что дальше

Далее: [Начало работы с MCP Clients](/03-GettingStarted/02-client/README.md)

**Отказ от ответственности**:  
Этот документ был переведен с помощью AI-сервиса перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия обеспечить точность, просим учитывать, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на исходном языке следует считать авторитетным источником. Для критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.