<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-07-13T21:07:01+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "uk"
}
-->
# Запуск цього прикладу

## -1- Встановіть залежності

```bash
dotnet restore
```

## -2- Запустіть приклад

```bash
dotnet run
```

## -3- Перевірте приклад

Перед тим, як виконати наведене нижче, відкрийте окремий термінал (переконайтеся, що сервер все ще працює).

Коли сервер запущений в одному терміналі, відкрийте інший і виконайте таку команду:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Це має запустити веб-сервер з візуальним інтерфейсом, який дозволить вам протестувати приклад.

> Переконайтеся, що як тип транспорту вибрано **Streamable HTTP**, а URL — `http://localhost:3001/mcp`.

Після підключення до сервера:

- спробуйте вивести список інструментів і запустити `add` з аргументами 2 і 4 — у результаті має з’явитися 6.
- перейдіть до ресурсів і шаблону ресурсу, викличте "greeting", введіть ім’я, і ви побачите привітання з вашим ім’ям.

### Тестування в режимі CLI

Ви можете запустити його безпосередньо в режимі CLI, виконавши таку команду:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Це виведе всі інструменти, доступні на сервері. Ви повинні побачити такий результат:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
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
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Ви побачите такий результат:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Зазвичай запуск інспектора в режимі CLI значно швидший, ніж у браузері.
> Детальніше про інспектор читайте [тут](https://github.com/modelcontextprotocol/inspector).

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.