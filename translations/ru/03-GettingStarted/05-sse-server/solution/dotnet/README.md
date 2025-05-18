<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:52:58+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "ru"
}
-->
# Запуск этого примера

## -1- Установите зависимости

```bash
dotnet run
```

## -2- Запустите пример

```bash
dotnet run
```

## -3- Протестируйте пример

Запустите отдельный терминал перед выполнением ниже (убедитесь, что сервер все еще работает).

Когда сервер работает в одном терминале, откройте другой терминал и выполните следующую команду:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Это должно запустить веб-сервер с визуальным интерфейсом, позволяющим протестировать пример.

После подключения к серверу:

- попробуйте перечислить инструменты и запустить `add`, с аргументами 2 и 4, вы должны увидеть 6 в результате.
- перейдите к ресурсам и шаблону ресурсов и вызовите "greeting", введите имя, и вы должны увидеть приветствие с указанным вами именем.

### Тестирование в режиме CLI

Вы можете запустить его напрямую в режиме CLI, выполнив следующую команду:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Это перечислит все доступные на сервере инструменты. Вы должны увидеть следующий вывод:

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
> Обычно намного быстрее запускать инспектор в режиме CLI, чем в браузере.
> Подробнее об инспекторе читайте [здесь](https://github.com/modelcontextprotocol/inspector).

**Отказ от ответственности**:  
Этот документ был переведен с помощью AI-сервиса перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Хотя мы стремимся к точности, пожалуйста, учитывайте, что автоматические переводы могут содержать ошибки или неточности. Оригинальный документ на его родном языке должен считаться авторитетным источником. Для критически важной информации рекомендуется профессиональный перевод человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникающие в результате использования этого перевода.