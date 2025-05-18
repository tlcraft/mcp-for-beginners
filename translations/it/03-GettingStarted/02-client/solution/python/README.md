<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:01:25+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "it"
}
-->
# Esecuzione di questo esempio

Si consiglia di installare `uv`, ma non è obbligatorio, vedere [istruzioni](https://docs.astral.sh/uv/#highlights)

## -0- Creare un ambiente virtuale

```bash
python -m venv venv
```

## -1- Attivare l'ambiente virtuale

```bash
venv\Scrips\activate
```

## -2- Installare le dipendenze

```bash
pip install "mcp[cli]"
```

## -3- Eseguire l'esempio

```bash
python client.py
```

Dovresti vedere un output simile a:

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

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per l'accuratezza, si prega di essere consapevoli che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali fraintendimenti o interpretazioni errate derivanti dall'uso di questa traduzione.