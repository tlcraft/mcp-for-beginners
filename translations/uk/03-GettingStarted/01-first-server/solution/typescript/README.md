<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-06-17T16:45:13+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "uk"
}
-->
# Запуск цього прикладу

Рекомендується встановити `uv`, але це не обов’язково, дивіться [інструкції](https://docs.astral.sh/uv/#highlights)

## -1- Встановіть залежності

```bash
npm install
```

## -3- Запустіть приклад


```bash
npm run build
```

## -4- Перевірте приклад

Коли сервер працює в одному терміналі, відкрийте інший термінал і виконайте наступну команду:

```bash
npm run inspector
```

Це має запустити веб-сервер з візуальним інтерфейсом, що дозволяє тестувати приклад.

Після підключення сервера: 

- спробуйте вивести список інструментів і запустіть `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev`, який є оболонкою для цього.

Ви можете запустити його безпосередньо в режимі CLI, виконавши таку команду:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Це покаже всі інструменти, доступні на сервері. Ви повинні побачити такий вивід:

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
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Ви повинні побачити такий вивід:

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
Цей документ був перекладений за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, враховуйте, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.