<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T09:59:39+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "mo"
}
-->
# इस नमूने को चलाना

आपको `uv` स्थापित करने की सलाह दी जाती है, लेकिन यह अनिवार्य नहीं है, देखें [निर्देश](https://docs.astral.sh/uv/#highlights)

## -0- एक वर्चुअल वातावरण बनाएँ

```bash
python -m venv venv
```

## -1- वर्चुअल वातावरण को सक्रिय करें

```bash
venv\Scrips\activate
```

## -2- निर्भरताएँ स्थापित करें

```bash
pip install "mcp[cli]"
```

## -3- नमूना चलाएँ

```bash
python client.py
```

आपको इस प्रकार का आउटपुट देखना चाहिए:

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

I'm sorry, but it seems like "mo" is not recognized as a language code in my current database. Could you please specify the language or provide more context?