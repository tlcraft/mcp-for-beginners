<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T06:12:15+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
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

## -3- Протестуйте приклад

Перед тим, як виконувати наведене нижче, відкрийте окремий термінал (переконайтеся, що сервер досі працює).

Коли сервер запущено в одному терміналі, відкрийте інший і виконайте таку команду:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Це має запустити веб-сервер з візуальним інтерфейсом, який дозволить вам протестувати приклад.

> Переконайтеся, що як тип транспорту вибрано **SSE**, а URL має вигляд `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`, з аргументами 2 і 4 — у результаті ви повинні побачити 6.
- перейдіть до resources і resource template, викличте "greeting", введіть ім’я, і ви побачите вітання з вашим ім’ям.

### Тестування в режимі CLI

Ви можете запустити його безпосередньо в режимі CLI, виконавши таку команду:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Це покаже всі інструменти, доступні на сервері. Ви повинні побачити такий вивід:

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
> Зазвичай працювати з inspector у режимі CLI значно швидше, ніж у браузері.
> Докладніше про inspector читайте [тут](https://github.com/modelcontextprotocol/inspector).

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.