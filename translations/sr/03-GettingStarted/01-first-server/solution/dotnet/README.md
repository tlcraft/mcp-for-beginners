<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T06:09:25+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "sr"
}
-->
# Покретање овог примера

## -1- Инсталирајте зависности

```bash
dotnet restore
```

## -3- Покрените пример

```bash
dotnet run
```

## -4- Тестирајте пример

Док сервер ради у једном терминалу, отворите други терминал и покрените следећу команду:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Ово би требало да покрене веб сервер са визуелним интерфејсом који вам омогућава да тестирате пример.

Када се сервер повеже:

- покушајте да набројите алате и покренете `add` са аргументима 2 и 4, требало би да видите резултат 6.
- идите на resources и resource template и позовите "greeting", унесите име и требало би да видите поздрав са именом које сте унели.

### Тестирање у CLI режиму

Можете га покренути директно у CLI режиму покретањем следеће команде:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Ово ће набројати све алате доступне на серверу. Требало би да видите следећи излаз:

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

Да бисте позвали алат укуцајте:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Требало би да видите следећи излаз:

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
> Обично је много брже покренути inspector у CLI режиму него у прегледачу.
> Више о inspector-у прочитајте [овде](https://github.com/modelcontextprotocol/inspector).

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI преводилачке услуге [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде прецизан, имајте у виду да аутоматизовани преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која могу настати употребом овог превода.