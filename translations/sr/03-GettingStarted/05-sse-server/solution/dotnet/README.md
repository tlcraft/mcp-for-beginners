<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T06:09:31+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
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

Пре него што покренете следеће, отворите посебан терминал (проверите да ли сервер и даље ради).

Док сервер ради у једном терминалу, отворите други терминал и покрените следећу команду:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Ово би требало да покрене веб сервер са визуелним интерфејсом који вам омогућава да тестирате пример.

> Проверите да ли је **SSE** изабран као тип транспорта, а URL је `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`, са аргументима 2 и 4, требало би да видите резултат 6.
- идите на resources и resource template и позовите "greeting", укуцајте име и требало би да добијете поздрав са унетим именом.

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
> Обично је много брже покренути инспектор у CLI режиму него у прегледачу.
> Више о инспектору прочитајте [овде](https://github.com/modelcontextprotocol/inspector).

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо тачности, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења настала употребом овог превода.