<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:04:13+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "sw"
}
-->
# Kuendesha sampuli hii

Inashauriwa usakinishe `uv` lakini si lazima, angalia [maelekezo](https://docs.astral.sh/uv/#highlights)

## -0- Tengeneza mazingira pepe

```bash
python -m venv venv
```

## -1- Washa mazingira pepe

```bash
venv\Scrips\activate
```

## -2- Sakinisha mahitaji

```bash
pip install "mcp[cli]"
```

## -3- Endesha sampuli

```bash
python client.py
```

Unapaswa kuona matokeo yanayofanana na:

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

**Kanusho**: 
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwepo kwa usahihi. Hati ya awali katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo chenye mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatuwajibiki kwa kutoelewana au kutafsiri vibaya kunakotokana na matumizi ya tafsiri hii.