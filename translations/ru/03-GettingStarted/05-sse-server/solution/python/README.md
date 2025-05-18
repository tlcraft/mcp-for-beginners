<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:00:01+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "ru"
}
-->
# Запуск этого примера

Рекомендуется установить `uv`, но это не обязательно, см. [инструкции](https://docs.astral.sh/uv/#highlights)

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

## -4- Протестируйте пример

С сервером, запущенным в одном терминале, откройте другой терминал и выполните следующую команду:

```bash
mcp dev server.py
```

Это должно запустить веб-сервер с визуальным интерфейсом, позволяющим протестировать пример.

После подключения к серверу:

- попробуйте перечислить инструменты и запустить `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev`, который является оболочкой вокруг него.

Вы можете запустить его напрямую в режиме CLI, выполнив следующую команду:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Это перечислит все доступные на сервере инструменты. Вы должны увидеть следующий вывод:

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
> Обычно запуск инспектора в режиме CLI происходит гораздо быстрее, чем в браузере.
> Подробнее об инспекторе читайте [здесь](https://github.com/modelcontextprotocol/inspector).

**Отказ от ответственности**:  
Этот документ был переведен с помощью службы автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Хотя мы стремимся к точности, пожалуйста, учитывайте, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на его родном языке должен рассматриваться как авторитетный источник. Для получения критической информации рекомендуется профессиональный перевод человеком. Мы не несём ответственности за любые недоразумения или неправильные интерпретации, возникающие в результате использования этого перевода.