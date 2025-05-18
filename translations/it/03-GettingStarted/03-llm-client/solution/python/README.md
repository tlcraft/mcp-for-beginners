<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24531f2b6b0f7fa3839accf4dc10088a",
  "translation_date": "2025-05-17T10:47:59+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/python/README.md",
  "language_code": "it"
}
-->
# Esecuzione di questo esempio

Si consiglia di installare `uv` ma non è obbligatorio, vedere [istruzioni](https://docs.astral.sh/uv/#highlights)

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
pip install openai
pip install azure-ai-inference
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
Tool {'a': {'title': 'A', 'type': 'integer'}, 'b': {'title': 'B', 'type': 'integer'}}
CALLING LLM
TOOL:  {'function': {'arguments': '{"a":2,"b":20}', 'name': 'add'}, 'id': 'call_BCbyoCcMgq0jDwR8AuAF9QY3', 'type': 'function'}
[05/08/25 21:04:55] INFO     Processing request of type CallToolRequest                                                                                server.py:534
TOOLS result:  [TextContent(type='text', text='22', annotations=None)]
```

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per l'accuratezza, si prega di essere consapevoli che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali incomprensioni o interpretazioni errate derivanti dall'uso di questa traduzione.