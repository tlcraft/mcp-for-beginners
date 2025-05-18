<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:06:33+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "ru"
}
-->
# Запуск этого примера

## -1- Установите зависимости

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Запустите пример

```bash
dotnet run
```

## -4- Протестируйте пример

С запущенным сервером в одном терминале откройте другой терминал и выполните следующую команду:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Это должно запустить веб-сервер с визуальным интерфейсом, который позволит вам протестировать пример.

После подключения к серверу:

- попробуйте перечислить инструменты и выполните `add` с аргументами 2 и 4, вы должны увидеть результат 6.
- перейдите к ресурсам и шаблону ресурсов и вызовите "greeting", введите имя, и вы должны увидеть приветствие с указанным вами именем.

### Тестирование в режиме CLI

Вы можете запустить его непосредственно в режиме CLI, выполнив следующую команду:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Это перечислит все доступные инструменты на сервере. Вы должны увидеть следующий вывод:

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
> Обычно запуск инспектора в режиме CLI происходит гораздо быстрее, чем в браузере.
> Узнайте больше об инспекторе [здесь](https://github.com/modelcontextprotocol/inspector).

**Отказ от ответственности**:  
Этот документ был переведен с использованием службы автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Хотя мы стремимся к точности, пожалуйста, имейте в виду, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на его родном языке следует считать авторитетным источником. Для критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникающие в результате использования этого перевода.