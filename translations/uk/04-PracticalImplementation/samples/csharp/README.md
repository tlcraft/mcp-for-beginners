<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0bc7bd48f55f1565f1d95ccb2c16f728",
  "translation_date": "2025-06-18T07:54:35+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/README.md",
  "language_code": "uk"
}
-->
# Приклад

Попередній приклад показує, як використовувати локальний проект .NET з типом `stdio`. А також як запустити сервер локально в контейнері. Це хороше рішення в багатьох випадках. Однак іноді корисно, щоб сервер працював віддалено, наприклад у хмарному середовищі. Саме тут на допомогу приходить тип `http`.

Дивлячись на рішення у папці `04-PracticalImplementation`, воно може здатися значно складнішим за попереднє. Але насправді це не так. Якщо придивитися до проекту `src/Calculator`, ви побачите, що це майже той самий код, що й у попередньому прикладі. Єдина відмінність у тому, що ми використовуємо іншу бібліотеку `ModelContextProtocol.AspNetCore` для обробки HTTP-запитів. І змінюємо метод `IsPrime` на приватний, щоб показати, що в коді можна мати приватні методи. Решта коду залишилася без змін.

Інші проєкти походять із [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/get-started/aspire-overview). Наявність .NET Aspire у рішенні покращує досвід розробника під час розробки та тестування, а також допомагає з моніторингом. Для запуску сервера це не обов’язково, але хороша практика мати його у вашому рішенні.

## Запуск сервера локально

1. У VS Code (з розширенням C# DevKit) перейдіть у каталог `04-PracticalImplementation/samples/csharp`.
1. Виконайте команду нижче, щоб запустити сервер:

   ```bash
    dotnet watch run --project ./src/AppHost
   ```

1. Коли у веб-браузері відкриється панель керування .NET Aspire, зверніть увагу на URL `http`. Він має виглядати приблизно так: `http://localhost:5058/`.

   ![.NET Aspire Dashboard](../../../../../translated_images/dotnet-aspire-dashboard.0a7095710e9301e90df2efd867e1b675b3b9bc2ccd7feb1ebddc0751522bc37c.uk.png)

## Тестування Streamable HTTP за допомогою MCP Inspector

Якщо у вас встановлений Node.js версії 22.7.5 і вище, ви можете використовувати MCP Inspector для тестування сервера.

Запустіть сервер і виконайте команду у терміналі:

```bash
npx @modelcontextprotocol/inspector http://localhost:5058
```

![MCP Inspector](../../../../../translated_images/mcp-inspector.c223422b9b494fb4a518a3b3911b3e708e6a5715069470f9163ee2ee8d5f1ba9.uk.png)

- Оберіть `Streamable HTTP` as the Transport type.
- In the Url field, enter the URL of the server noted earlier, and append `/mcp`. Він має бути `http` (не `https`) something like `http://localhost:5058/mcp`.
- select the Connect button.

A nice thing about the Inspector is that it provide a nice visibility on what is happening.

- Try listing the available tools
- Try some of them, it should works just like before.

## Test MCP Server with GitHub Copilot Chat in VS Code

To use the Streamable HTTP transport with GitHub Copilot Chat, change the configuration of the `calc-mcp` сервер, створений раніше, щоб виглядати так:

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "http://localhost:5058/mcp"
    }
  }
}
```

Проведіть кілька тестів:

- Запитайте "3 прості числа після 6780". Зверніть увагу, як Copilot використовує нові інструменти `NextFivePrimeNumbers` і повертає лише перші 3 прості числа.
- Запитайте "7 простих чисел після 111", щоб побачити результат.
- Запитайте "У Джона 24 льодяники, і він хоче роздати їх порівну трьом дітям. Скільки льодяників отримає кожна дитина?", щоб подивитися, що станеться.

## Розгортання сервера в Azure

Давайте розгорнемо сервер в Azure, щоб ним могли користуватися більше людей.

У терміналі перейдіть у папку `04-PracticalImplementation/samples/csharp` і виконайте команду:

```bash
azd up
```

Після завершення розгортання ви побачите повідомлення, подібне до цього:

![Azd deployment success](../../../../../translated_images/azd-deployment-success.bd42940493f1b834a5ce6251a6f88966546009b350df59d0cc4a8caabe94a4f1.uk.png)

Скопіюйте URL і використовуйте його в MCP Inspector та в GitHub Copilot Chat.

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "https://calc-mcp.gentleriver-3977fbcf.australiaeast.azurecontainerapps.io/mcp"
    }
  }
}
```

## Що далі?

Ми спробували різні типи транспорту та інструменти для тестування. Також розгорнули MCP сервер в Azure. Але що, якщо нашому серверу потрібен доступ до приватних ресурсів? Наприклад, до бази даних або приватного API? У наступній главі ми розглянемо, як покращити безпеку нашого сервера.

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.