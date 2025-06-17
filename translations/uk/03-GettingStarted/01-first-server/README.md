<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bf05718d019040cf0c7d4ccc6d6a1a88",
  "translation_date": "2025-06-17T16:44:19+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "uk"
}
-->
### -2- Створення проекту

Тепер, коли у вас встановлений SDK, давайте створимо проект: 

### -3- Створення файлів проекту

### -4- Написання коду сервера

### -5- Додавання інструменту та ресурсу

Додайте інструмент і ресурс, додавши наступний код:

### -6- Остаточний код

Додамо останній необхідний код, щоб сервер міг запуститися:

### -7- Тестування сервера

Запустіть сервер за допомогою наступної команди:

### -8- Запуск за допомогою інспектора

Інспектор — це чудовий інструмент, який може запустити ваш сервер і дозволити вам взаємодіяти з ним, щоб перевірити, чи все працює. Запустимо його:

> [!NOTE]
> у полі "command" може бути вказана команда запуску сервера саме для вашого середовища виконання

Ви побачите наступний інтерфейс користувача:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.uk.png)

1. Підключіться до сервера, натиснувши кнопку Connect  
   Після підключення до сервера ви побачите таке:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.uk.png)

2. Виберіть "Tools" і "listTools", ви побачите "Add", натисніть "Add" і заповніть параметри.

   Ви побачите наступну відповідь, тобто результат роботи інструменту "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.uk.png)

Вітаємо, ви успішно створили і запустили свій перший сервер!

### Офіційні SDK

MCP надає офіційні SDK для кількох мов:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) — підтримується у співпраці з Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) — підтримується у співпраці з Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) — офіційна реалізація на TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) — офіційна реалізація на Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) — офіційна реалізація на Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) — підтримується у співпраці з Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) — офіційна реалізація на Rust

## Основні висновки

- Налаштування середовища розробки MCP є простим завдяки мовоспецифічним SDK
- Створення MCP серверів включає розробку і реєстрацію інструментів із чіткими схемами
- Тестування і відлагодження є необхідними для надійної реалізації MCP

## Приклади

- [Java калькулятор](../samples/java/calculator/README.md)
- [.Net калькулятор](../../../../03-GettingStarted/samples/csharp)
- [JavaScript калькулятор](../samples/javascript/README.md)
- [TypeScript калькулятор](../samples/typescript/README.md)
- [Python калькулятор](../../../../03-GettingStarted/samples/python)

## Завдання

Створіть простий MCP сервер з інструментом на ваш вибір:
1. Реалізуйте інструмент на вашій улюбленій мові (.NET, Java, Python або JavaScript).
2. Визначте вхідні параметри та значення, що повертаються.
3. Запустіть інструмент інспектора, щоб переконатися, що сервер працює правильно.
4. Протестуйте реалізацію з різними вхідними даними.

## Розв’язок

[Розв’язок](./solution/README.md)

## Додаткові ресурси

- [Створення агентів за допомогою Model Context Protocol на Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Віддалений MCP з Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Що далі

Далі: [Початок роботи з MCP клієнтами](/03-GettingStarted/02-client/README.md)

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоч ми й прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння чи неправильні тлумачення, що виникли внаслідок використання цього перекладу.