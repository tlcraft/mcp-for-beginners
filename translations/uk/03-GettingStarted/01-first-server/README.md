<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f01d4263fc6eec331615fef42429b720",
  "translation_date": "2025-06-18T18:29:08+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "uk"
}
-->
### -2- Створення проекту

Тепер, коли у вас встановлено SDK, давайте створимо проект:  

### -3- Створення файлів проекту

### -4- Написання коду сервера

### -5- Додавання інструменту та ресурсу

Додайте інструмент і ресурс, додавши наступний код:  

### -6- Остаточний код

Додамо останній необхідний код, щоб сервер міг запуститися:  

### -7- Тестування сервера

Запустіть сервер за допомогою наступної команди:  

### -8- Запуск за допомогою інспектора

Інспектор — це чудовий інструмент, який може запустити ваш сервер і дозволяє взаємодіяти з ним, щоб перевірити, чи він працює. Запустимо його:  

> [!NOTE]
> в полі "command" команда може виглядати інакше, оскільки там міститься команда запуску сервера для вашого конкретного середовища виконання  

Ви побачите такий інтерфейс користувача:  

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.uk.png)

1. Підключіться до сервера, натиснувши кнопку Connect.  
   Після підключення до сервера ви побачите наступне:  

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.uk.png)

2. Виберіть "Tools" та "listTools", ви побачите "Add". Виберіть "Add" і заповніть значення параметрів.  

   Ви побачите наступну відповідь, тобто результат роботи інструменту "add":  

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.uk.png)

Вітаємо, ви успішно створили і запустили свій перший сервер!  

### Офіційні SDK

MCP надає офіційні SDK для кількох мов програмування:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - підтримується у співпраці з Microsoft  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - підтримується у співпраці зі Spring AI  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - офіційна реалізація на TypeScript  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - офіційна реалізація на Python  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - офіційна реалізація на Kotlin  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - підтримується у співпраці з Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - офіційна реалізація на Rust  

## Основні висновки

- Налаштування середовища розробки MCP просте завдяки SDK для конкретних мов  
- Створення MCP серверів передбачає створення та реєстрацію інструментів із чіткими схемами  
- Тестування та налагодження є необхідними для надійної реалізації MCP  

## Приклади

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Завдання

Створіть простий MCP сервер з інструментом на ваш вибір:

1. Реалізуйте інструмент у вашій улюбленій мові (.NET, Java, Python або JavaScript).  
2. Визначте вхідні параметри та значення, що повертаються.  
3. Запустіть інструмент inspector, щоб переконатися, що сервер працює належним чином.  
4. Перевірте реалізацію з різними вхідними даними.  

## Розв’язок

[Розв’язок](./solution/README.md)  

## Додаткові ресурси

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## Що далі

Далі: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, просимо враховувати, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.