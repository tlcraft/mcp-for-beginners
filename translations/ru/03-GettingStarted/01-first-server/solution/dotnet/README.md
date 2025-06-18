<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T05:47:31+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "ru"
}
-->
# Запуск этого примера

## -1- Установка зависимостей

```bash
dotnet restore
```

## -3- Запуск примера

```bash
dotnet run
```

## -4- Тестирование примера

Когда сервер запущен в одном терминале, откройте другой терминал и выполните следующую команду:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Это должно запустить веб-сервер с визуальным интерфейсом, позволяющим протестировать пример.

После подключения сервера:

- попробуйте вывести список инструментов и запустите `add` с аргументами 2 и 4, в результате вы должны увидеть 6.
- перейдите к разделам resources и resource template, вызовите "greeting", введите имя, и вы увидите приветствие с указанным именем.

### Тестирование в режиме CLI

Вы можете запустить его напрямую в режиме CLI, выполнив следующую команду:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Это выведет все доступные инструменты на сервере. Вы должны увидеть следующий вывод:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Чтобы вызвать инструмент, введите:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Вы должны увидеть следующий вывод:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Обычно работать с инспектором в режиме CLI гораздо быстрее, чем через браузер.
> Подробнее об инспекторе можно прочитать [здесь](https://github.com/modelcontextprotocol/inspector).

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, просим учитывать, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.