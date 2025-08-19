<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-07-13T20:17:12+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "bg"
}
-->
# Стартиране на този пример

Препоръчително е да инсталирате `uv`, но не е задължително, вижте [инструкции](https://docs.astral.sh/uv/#highlights)

## -0- Създайте виртуална среда

```bash
python -m venv venv
```

## -1- Активирайте виртуалната среда

```bash
venv\Scrips\activate
```

## -2- Инсталирайте зависимостите

```bash
pip install "mcp[cli]"
```

## -3- Стартирайте примера

```bash
uvicorn server:app
```

## -4- Тествайте примера

Със стартиран сървър в един терминал, отворете друг терминал и изпълнете следната команда:

```bash
mcp dev server.py
```

Това трябва да стартира уеб сървър с визуален интерфейс, който ви позволява да тествате примера.

След като сървърът се свърже:

- опитайте да изброите инструментите и изпълнете `add` с аргументи 2 и 4, трябва да видите резултат 6.
- отидете на resources и resource template и извикайте get_greeting, въведете име и трябва да видите поздрав с въведеното име.

### Тестване в режим CLI

Инспекторът, който стартирахте, всъщност е Node.js приложение, а `mcp dev` е обвивка около него.

Можете да го стартирате директно в режим CLI, като изпълните следната команда:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Това ще изброи всички налични инструменти на сървъра. Трябва да видите следния изход:

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

За да извикате инструмент, въведете:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.