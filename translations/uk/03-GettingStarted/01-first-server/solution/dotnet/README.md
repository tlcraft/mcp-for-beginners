<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-06-17T16:45:00+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "uk"
}
-->
# Запуск цього прикладу

## -1- Встановіть залежності

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Запустіть приклад

```bash
dotnet run
```

## -4- Перевірте приклад

Поки сервер працює в одному терміналі, відкрийте інший термінал і виконайте таку команду:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Це має запустити веб-сервер з візуальним інтерфейсом, який дозволить вам тестувати приклад.

Після підключення сервера:

- спробуйте перелічити інструменти та запустити `add` з аргументами 2 і 4, у результаті ви маєте побачити 6.
- перейдіть до ресурсів і шаблону ресурсу, викличте "greeting", введіть ім’я, і ви побачите привітання з введеним іменем.

### Тестування в режимі CLI

Ви можете запустити його безпосередньо в режимі CLI, виконавши таку команду:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Це виведе всі доступні на сервері інструменти. Ви повинні побачити наступний результат:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Щоб викликати інструмент, введіть:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Ви побачите такий результат:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Зазвичай запуск інспектора в режимі CLI значно швидший, ніж у браузері.
> Детальніше про інспектор читайте [тут](https://github.com/modelcontextprotocol/inspector).

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння чи неправильні тлумачення, що виникли внаслідок використання цього перекладу.