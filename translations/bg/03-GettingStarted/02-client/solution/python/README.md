<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:05:11+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "bg"
}
-->
# Изпълнение на този пример

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
python client.py
```

Трябва да видите изход, подобен на:

```text
LISTING RESOURCES
Resource:  ('meta', None)
Resource:  ('nextCursor', None)
Resource:  ('resources', [])
                    INFO     Processing request of type ListToolsRequest                                                                               server.py:534
LISTING TOOLS
Tool:  add
READING RESOURCE
                    INFO     Processing request of type ReadResourceRequest                                                                            server.py:534
CALL TOOL
                    INFO     Processing request of type CallToolRequest                                                                                server.py:534
[TextContent(type='text', text='8', annotations=None)]
```

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI услуга за превод [Co-op Translator](https://github.com/Azure/co-op-translator). Докато се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Не носим отговорност за каквито и да било недоразумения или неправилни интерпретации, произтичащи от използването на този превод.