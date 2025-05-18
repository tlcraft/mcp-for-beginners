<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:13:06+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "bg"
}
-->
# Изпълнение на този пример

## -1- Инсталирайте зависимостите

```bash
npm install
```

## -3- Стартирайте примера

```bash
npm run build
```

## -4- Тествайте примера

Със сървъра, работещ в един терминал, отворете друг терминал и изпълнете следната команда:

```bash
npm run inspector
```

Това трябва да стартира уеб сървър с визуален интерфейс, който ви позволява да тествате примера.

След като сървърът се свърже:

- опитайте да изброите инструментите и изпълнете `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build`.

- В отделен терминал изпълнете следната команда:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    Това ще изброи всички инструменти, налични в сървъра. Трябва да видите следния изход:

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

- Извикайте тип инструмент, като въведете следната команда:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Трябва да видите следния изход:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> Обикновено е много по-бързо да стартирате инспектора в CLI режим, отколкото в браузъра.
> Прочетете повече за инспектора [тук](https://github.com/modelcontextprotocol/inspector).

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI услуга за превод [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи може да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да било недоразумения или погрешни интерпретации, произтичащи от използването на този превод.