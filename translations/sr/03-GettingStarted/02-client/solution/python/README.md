<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:05:17+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "sr"
}
-->
# Pokretanje ovog primera

Preporučuje se instalacija `uv`, ali nije obavezno, pogledajte [uputstva](https://docs.astral.sh/uv/#highlights)

## -0- Kreirajte virtuelno okruženje

```bash
python -m venv venv
```

## -1- Aktivirajte virtuelno okruženje

```bash
venv\Scrips\activate
```

## -2- Instalirajte zavisnosti

```bash
pip install "mcp[cli]"
```

## -3- Pokrenite primer

```bash
python client.py
```

Trebalo bi da vidite izlaz sličan:

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

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо тачности, молимо вас да будете свесни да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати меродавним извором. За критичне информације, препоручује се професионални људски превод. Не сносимо одговорност за било каква неспоразума или погрешна тумачења настала коришћењем овог превода.