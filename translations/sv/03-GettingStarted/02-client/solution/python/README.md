<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:02:18+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "sv"
}
-->
# Köra detta exempel

Det rekommenderas att installera `uv` men det är inte ett måste, se [instruktioner](https://docs.astral.sh/uv/#highlights)

## -0- Skapa en virtuell miljö

```bash
python -m venv venv
```

## -1- Aktivera den virtuella miljön

```bash
venv\Scrips\activate
```

## -2- Installera beroenden

```bash
pip install "mcp[cli]"
```

## -3- Kör exemplet

```bash
python client.py
```

Du bör se ett resultat som liknar:

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

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Vi strävar efter noggrannhet, men var medveten om att automatiska översättningar kan innehålla fel eller felaktigheter. Det ursprungliga dokumentet på dess ursprungliga språk bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår vid användning av denna översättning.