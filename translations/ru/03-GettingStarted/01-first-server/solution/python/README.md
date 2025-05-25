<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:13:37+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
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

Запустите сервер в одном терминале, откройте другой терминал и выполните следующую команду:

```bash
mcp dev server.py
```

Это должно запустить веб-сервер с визуальным интерфейсом, позволяющим протестировать пример.

После подключения к серверу:

- попробуйте перечислить инструменты и запустить `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` — это оболочка вокруг него.

Вы можете запустить его напрямую в режиме CLI, выполнив следующую команду:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Это отобразит все доступные на сервере инструменты. Вы должны увидеть следующий вывод:

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
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
Этот документ был переведен с помощью службы автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Мы стремимся к точности, однако, пожалуйста, учитывайте, что автоматизированные переводы могут содержать ошибки или неточности. Оригинальный документ на родном языке следует считать авторитетным источником. Для критической информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недопонимания или неверные интерпретации, возникающие в результате использования этого перевода.