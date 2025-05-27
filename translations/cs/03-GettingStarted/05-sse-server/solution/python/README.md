<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-27T16:23:21+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "cs"
}
-->
# Running this sample

Рекомендуется установить `uv`, но это не обязательно, смотрите [инструкции](https://docs.astral.sh/uv/#highlights)

## -0- Создайте виртуальное окружение

```bash
python -m venv venv
```

## -1- Активируйте виртуальное окружение

```bash
venv\Scrips\activate
```

## -2- Установите зависимости

```bash
pip install "mcp[cli]"
```

## -3- Запустите пример


```bash
mcp run server.py
```

## -4- Проверьте пример

С сервером, запущенным в одном терминале, откройте другой терминал и выполните следующую команду:

```bash
mcp dev server.py
```

Это должно запустить веб-сервер с визуальным интерфейсом, позволяющим тестировать пример.

После подключения к серверу:

- попробуйте вывести список инструментов и запустите `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` — это оболочка для этого.

Вы можете запустить его напрямую в режиме CLI, выполнив следующую команду:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Это выведет все доступные на сервере инструменты. Вы должны увидеть следующий вывод:

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

Чтобы вызвать инструмент, введите:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Вы должны увидеть следующий вывод:

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
> Обычно запуск инспектора в режиме CLI значительно быстрее, чем в браузере.
> Подробнее об инспекторе читайте [здесь](https://github.com/modelcontextprotocol/inspector).

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.