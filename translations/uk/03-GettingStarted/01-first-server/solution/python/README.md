<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-06-17T16:44:46+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
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

Поки сервер працює в одному терміналі, відкрийте інший термінал і виконайте наступну команду:

```bash
mcp dev server.py
```

Це має запустити веб-сервер з візуальним інтерфейсом, який дозволить вам протестувати приклад.

Після підключення сервера: 

- спробуйте перелічити інструменти та запустити `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev`, який є обгорткою для цього.

Ви можете запустити його безпосередньо в CLI-режимі, виконавши наступну команду:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Це покаже всі інструменти, доступні на сервері. Ви повинні побачити такий результат:

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
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Ви побачите наступний результат:

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
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, просимо враховувати, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.