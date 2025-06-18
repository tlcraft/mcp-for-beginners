<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T05:47:37+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "ru"
}
-->
# Запуск этого примера

## -1- Установите зависимости

```bash
dotnet restore
```

## -2- Запустите пример

```bash
dotnet run
```

## -3- Проверьте пример

Перед выполнением ниже запустите отдельный терминал (убедитесь, что сервер всё ещё работает).

Когда сервер запущен в одном терминале, откройте другой и выполните следующую команду:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Это должно запустить веб-сервер с визуальным интерфейсом, позволяющим протестировать пример.

> Убедитесь, что в качестве типа транспорта выбран **SSE**, а URL — `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`, с аргументами 2 и 4, в результате вы должны увидеть 6.
- перейдите в раздел resources и resource template, вызовите "greeting", введите имя, и вы увидите приветствие с указанным именем.

### Тестирование в режиме CLI

Вы можете запустить его напрямую в режиме CLI, выполнив следующую команду:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Это выведет список всех инструментов, доступных на сервере. Вы должны увидеть следующий вывод:

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

Чтобы вызвать инструмент, введите:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, пожалуйста, имейте в виду, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на исходном языке следует считать авторитетным источником. Для получения критически важной информации рекомендуется обращаться к профессиональному переводу, выполненному человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.