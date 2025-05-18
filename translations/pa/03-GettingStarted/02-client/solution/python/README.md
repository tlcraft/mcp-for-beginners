<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:01:07+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "pa"
}
-->
# ਇਸ ਨਮੂਨੇ ਨੂੰ ਚਲਾਉਣਾ

ਤੁਹਾਨੂੰ `uv` ਇੰਸਟਾਲ ਕਰਨ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ ਪਰ ਇਹ ਲਾਜ਼ਮੀ ਨਹੀਂ ਹੈ, ਵੇਖੋ [ਹਦਾਇਤਾਂ](https://docs.astral.sh/uv/#highlights)

## -0- ਇੱਕ ਵਰਚੁਅਲ ਮਾਹੌਲ ਬਣਾਓ

```bash
python -m venv venv
```

## -1- ਵਰਚੁਅਲ ਮਾਹੌਲ ਨੂੰ ਸਰਗਰਮ ਕਰੋ

```bash
venv\Scrips\activate
```

## -2- ਲੋੜੀਂਦੀਆਂ ਚੀਜ਼ਾਂ ਇੰਸਟਾਲ ਕਰੋ

```bash
pip install "mcp[cli]"
```

## -3- ਨਮੂਨਾ ਚਲਾਓ

```bash
python client.py
```

ਤੁਹਾਨੂੰ ਇਸ ਤਰ੍ਹਾਂ ਦੇ ਨਤੀਜੇ ਦੇਖਣੇ ਚਾਹੀਦੇ ਹਨ:

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

**ਅਸਵੀਕਰਤੀਕਰਨ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਹਾਲਾਂਕਿ ਅਸੀਂ ਸਹੀ ਹੋਣ ਦਾ ਯਤਨ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਦਿਓ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸੁਵਿਧਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਇਸਦੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਮੂਲ ਦਸਤਾਵੇਜ਼ ਨੂੰ ਅਧਿਕਾਰਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੇ ਇਸਤੇਮਾਲ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।