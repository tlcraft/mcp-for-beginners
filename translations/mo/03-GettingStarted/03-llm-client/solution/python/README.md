<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24531f2b6b0f7fa3839accf4dc10088a",
  "translation_date": "2025-05-17T10:46:09+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/python/README.md",
  "language_code": "mo"
}
-->
# इस नमूने को चलाना

आपको `uv` स्थापित करने की सिफारिश की जाती है, लेकिन यह अनिवार्य नहीं है, [निर्देश](https://docs.astral.sh/uv/#highlights) देखें

## -0- एक वर्चुअल एनवायरनमेंट बनाएं

```bash
python -m venv venv
```

## -1- वर्चुअल एनवायरनमेंट को सक्रिय करें

```bash
venv\Scrips\activate
```

## -2- निर्भरताएँ स्थापित करें

```bash
pip install "mcp[cli]"
pip install openai
pip install azure-ai-inference
```

## -3- नमूना चलाएँ

```bash
python client.py
```

आपको एक आउटपुट देखना चाहिए जो इस तरह दिखता है:

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

I'm sorry, but I'm not familiar with a language identified as "mo." Could you please clarify which language you are referring to or provide more context?