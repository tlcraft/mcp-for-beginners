<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-06-17T16:46:51+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "uk"
}
-->
# Запуск цього прикладу

Рекомендується встановити `uv`, але це не обов’язково, дивіться [інструкції](https://docs.astral.sh/uv/#highlights)

## -0- Створіть віртуальне середовище

```bash
python -m venv venv
```

## -1- Активуйте віртуальне середовище

```bash
venv\Scrips\activate
```

## -2- Встановіть залежності

```bash
pip install "mcp[cli]"
```

## -3- Запустіть приклад


```bash
mcp run server.py
```

## -4- Протестуйте приклад

Коли сервер працює в одному терміналі, відкрийте інший термінал і виконайте наступну команду:

```bash
mcp dev server.py
```

Це має запустити веб-сервер з візуальним інтерфейсом, що дозволяє протестувати приклад.

Після підключення до сервера:

- спробуйте вивести список інструментів і запустіть `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` — це обгортка навколо нього.

Ви можете запустити його безпосередньо в CLI-режимі, виконавши таку команду:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Це виведе всі інструменти, доступні на сервері. Ви маєте побачити такий результат:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

Щоб викликати інструмент, введіть:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Ви маєте побачити такий результат:

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
> Зазвичай запуск інспектора в CLI-режимі значно швидший, ніж у браузері.
> Детальніше про інспектор читайте [тут](https://github.com/modelcontextprotocol/inspector).

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння чи неправильні тлумачення, що виникли внаслідок використання цього перекладу.