<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:20:41+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "ru"
}
-->
# Запуск этого примера

Рекомендуется установить `uv`, но это не обязательно, смотрите [инструкции](https://docs.astral.sh/uv/#highlights)

## -1- Установите зависимости

```bash
npm install
```

## -3- Запустите пример

```bash
npm run build
```

## -4- Протестируйте пример

С сервером, работающим в одном терминале, откройте другой терминал и выполните следующую команду:

```bash
npm run inspector
```

Это должно запустить веб-сервер с визуальным интерфейсом, позволяющим протестировать пример.

После подключения к серверу:

- попробуйте перечислить инструменты и запустите `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev`, который является оберткой вокруг него.

Вы можете запустить его напрямую в режиме CLI, выполнив следующую команду:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Это перечислит все инструменты, доступные на сервере. Вы должны увидеть следующий вывод:

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
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Обычно запуск инспектора в режиме CLI происходит намного быстрее, чем в браузере.
> Подробнее об инспекторе читайте [здесь](https://github.com/modelcontextprotocol/inspector).

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Мы стремимся к точности, однако, пожалуйста, имейте в виду, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на его родном языке следует считать авторитетным источником. Для критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования этого перевода.