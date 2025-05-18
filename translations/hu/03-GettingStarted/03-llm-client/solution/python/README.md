<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24531f2b6b0f7fa3839accf4dc10088a",
  "translation_date": "2025-05-17T10:51:01+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/python/README.md",
  "language_code": "hu"
}
-->
# A minta futtatása

Ajánlott telepíteni a(z) `uv` csomagot, de nem kötelező, lásd az [útmutatót](https://docs.astral.sh/uv/#highlights)

## -0- Hozz létre egy virtuális környezetet

```bash
python -m venv venv
```

## -1- Aktiváld a virtuális környezetet

```bash
venv\Scrips\activate
```

## -2- Telepítsd a függőségeket

```bash
pip install "mcp[cli]"
pip install openai
pip install azure-ai-inference
```

## -3- Futtasd a mintát

```bash
python client.py
```

Hasonló kimenetet kell látnod:

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

**Jogi nyilatkozat**:  
Ezt a dokumentumot a [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítószolgáltatás segítségével fordítottuk le. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum anyanyelvén tekintendő a hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást ajánlunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félremagyarázásokért.