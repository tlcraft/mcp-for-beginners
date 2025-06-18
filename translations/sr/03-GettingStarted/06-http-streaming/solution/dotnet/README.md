<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:19:30+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "sr"
}
-->
# Покретање овог примера

## -1- Инсталирајте зависности

```bash
dotnet restore
```

## -2- Покрените пример

```bash
dotnet run
```

## -3- Тестирајте пример

Пре него што покренете следеће, отворите посебан терминал (уверите се да сервер и даље ради).

Док сервер ради у једном терминалу, отворите други терминал и покрените следећу команду:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Ово би требало да покрене веб сервер са визуелним интерфејсом који вам омогућава да тестирате пример.

> Уверите се да је као тип транспорта изабран **Streamable HTTP**, а URL је `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`, са аргументима 2 и 4, требало би да видите резултат 6.
- идите на resources и resource template и позовите "greeting", унесите име и требало би да видите поздрав са именом које сте унели.

### Тестирање у CLI режиму

Можете га покренути директно у CLI режиму покретањем следеће команде:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Ово ће приказати све алате доступне на серверу. Требало би да видите следећи излаз:

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

Да бисте позвали алат укуцајте:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Требало би да видите следећи излаз:

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
> Обично је много брже покренути inspector у CLI режиму него у прегледачу.
> Више о inspector-у прочитајте [овде](https://github.com/modelcontextprotocol/inspector).

**Одрицање одговорности**:  
Овај документ је преведен коришћењем AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде прецизан, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом матерњем језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Не сносимо одговорност за било какве неспоразуме или погрешне тумачења настала коришћењем овог превода.