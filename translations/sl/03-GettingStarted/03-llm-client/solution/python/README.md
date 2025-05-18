<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24531f2b6b0f7fa3839accf4dc10088a",
  "translation_date": "2025-05-17T10:52:15+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/python/README.md",
  "language_code": "sl"
}
-->
# مثال چلانے

آپ کو `uv` انسٹال کرنے کی تجویز دی جاتی ہے لیکن یہ ضروری نہیں ہے، [ہدایات](https://docs.astral.sh/uv/#highlights) دیکھیں

## -0- ایک ورچوئل ماحول بنائیں

```bash
python -m venv venv
```

## -1- ورچوئل ماحول کو فعال کریں

```bash
venv\Scrips\activate
```

## -2- انحصارات کو انسٹال کریں

```bash
pip install "mcp[cli]"
pip install openai
pip install azure-ai-inference
```

## -3- مثال چلائیں

```bash
python client.py
```

آپ کو اس طرح کا آؤٹ پٹ دیکھنا چاہئے:

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

**Omejitev odgovornosti**: 
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za kritične informacije je priporočljivo profesionalno človeško prevajanje. Ne prevzemamo odgovornosti za morebitne nesporazume ali napačne razlage, ki izhajajo iz uporabe tega prevoda.