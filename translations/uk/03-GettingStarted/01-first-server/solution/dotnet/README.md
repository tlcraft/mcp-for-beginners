<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T06:12:09+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "uk"
}
-->
# Запуск цього прикладу

## -1- Встановіть залежності

```bash
dotnet restore
```

## -3- Запустіть приклад


```bash
dotnet run
```

## -4- Протестуйте приклад

Коли сервер запущений в одному терміналі, відкрийте інший термінал і виконайте таку команду:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Це має запустити веб-сервер з візуальним інтерфейсом, що дозволяє тестувати приклад.

Після підключення сервера: 

- спробуйте вивести список інструментів і запустити `add` з аргументами 2 та 4, у результаті має з’явитися 6.
- перейдіть до resources і resource template, викличте "greeting", введіть ім’я, і ви побачите привітання з введеним ім’ям.

### Тестування в CLI режимі

Ви можете запустити його безпосередньо в CLI режимі, виконавши таку команду:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Це виведе всі доступні інструменти на сервері. Ви маєте побачити такий результат:

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

Ви маєте побачити такий результат:

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
> Зазвичай запуск інспектора в CLI режимі значно швидший, ніж у браузері.
> Детальніше про інспектор читайте [тут](https://github.com/modelcontextprotocol/inspector).

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.