<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-06-17T16:47:06+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "uk"
}
-->
# Запуск цього прикладу

## -1- Встановіть залежності

```bash
dotnet run
```

## -2- Запустіть приклад

```bash
dotnet run
```

## -3- Перевірте приклад

Перед тим, як виконати наведене нижче, відкрийте окремий термінал (переконайтеся, що сервер все ще працює).

Коли сервер запущено в одному терміналі, відкрийте інший і виконайте таку команду:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Це має запустити веб-сервер з візуальним інтерфейсом, що дозволяє тестувати приклад.

Після підключення сервера:

- спробуйте вивести список інструментів і запустити `add` з аргументами 2 та 4, у результаті має бути 6.
- перейдіть до ресурсів і шаблону ресурсу, викличте "greeting", введіть ім’я, і ви побачите привітання з введеним ім’ям.

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
> Зазвичай запуск інспектора в режимі CLI набагато швидший, ніж у браузері.
> Докладніше про інспектор читайте [тут](https://github.com/modelcontextprotocol/inspector).

**Відмова від відповідальності**:  
Цей документ був перекладений за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння чи неправильні тлумачення, що виникли внаслідок використання цього перекладу.