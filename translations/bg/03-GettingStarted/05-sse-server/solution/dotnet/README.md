<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T06:08:58+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "bg"
}
-->
# Стартиране на този пример

## -1- Инсталиране на зависимостите

```bash
dotnet restore
```

## -2- Стартиране на примера

```bash
dotnet run
```

## -3- Тестване на примера

Отворете отделен терминал преди да изпълните следното (уверете се, че сървърът все още работи).

Със сървъра стартиран в един терминал, отворете друг терминал и изпълнете следната команда:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Това трябва да стартира уеб сървър с визуален интерфейс, който ви позволява да тествате примера.

> Уверете се, че **SSE** е избран като тип транспорт, а URL адресът е `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`, с аргументи 2 и 4, трябва да видите резултат 6.
- отидете в resources и resource template и извикайте "greeting", въведете име и трябва да видите поздрав с въведеното име.

### Тестване в CLI режим

Можете да го стартирате директно в CLI режим, като изпълните следната команда:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Това ще покаже всички налични инструменти на сървъра. Трябва да видите следния изход:

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
> Научете повече за инспектора [тук](https://github.com/modelcontextprotocol/inspector).

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, възникнали от използването на този превод.