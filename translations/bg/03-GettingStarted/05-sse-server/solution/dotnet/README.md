<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:59:07+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "bg"
}
-->
# Стартиране на този пример

## -1- Инсталирайте зависимостите

```bash
dotnet run
```

## -2- Стартирайте примера

```bash
dotnet run
```

## -3- Тествайте примера

Стартирайте отделен терминал преди да изпълните следното (уверете се, че сървърът все още работи).

Със стартиран сървър в един терминал, отворете друг терминал и изпълнете следната команда:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Това трябва да стартира уеб сървър с визуален интерфейс, който ви позволява да тествате примера.

След като сървърът е свързан:

- опитайте да изброите инструментите и изпълнете `add`, с аргументи 2 и 4, трябва да видите 6 в резултата.
- отидете на ресурси и шаблон на ресурс и извикайте "greeting", въведете име и трябва да видите поздрав с името, което сте предоставили.

### Тестване в CLI режим

Можете да го стартирате директно в CLI режим, като изпълните следната команда:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Това ще изброи всички налични инструменти в сървъра. Трябва да видите следния изход:

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

За да извикате инструмент, напишете:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Трябва да видите следния изход:

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
> Обикновено е много по-бързо да стартирате инспектора в CLI режим, отколкото в браузъра.
> Прочетете повече за инспектора [тук](https://github.com/modelcontextprotocol/inspector).

**Отказ от отговорност**:
Този документ е преведен с помощта на AI услуга за превод [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи може да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за недоразумения или неправилни тълкувания, произтичащи от използването на този превод.