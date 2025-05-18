<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:18:51+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "sw"
}
-->
# Kuendesha sampuli hii

Inashauriwa kusakinisha `uv` lakini si lazima, angalia [maelekezo](https://docs.astral.sh/uv/#highlights)

## -0- Tengeneza mazingira halisi

```bash
python -m venv venv
```

## -1- Washa mazingira halisi

```bash
venv\Scrips\activate
```

## -2- Sakinisha utegemezi

```bash
pip install "mcp[cli]"
```

## -3- Endesha sampuli

```bash
mcp run server.py
```

## -4- Jaribu sampuli

Kwa server inayofanya kazi kwenye terminal moja, fungua terminal nyingine na endesha amri ifuatayo:

```bash
mcp dev server.py
```

Hii inapaswa kuanzisha server ya wavuti na kiolesura cha kuona kinachokuruhusu kujaribu sampuli.

Mara server inapounganishwa:

- jaribu kuorodhesha zana na endesha `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` ni kifuniko juu yake.

Unaweza kuianzisha moja kwa moja katika hali ya CLI kwa kuendesha amri ifuatayo:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Hii itaorodhesha zana zote zinazopatikana katika server. Unapaswa kuona matokeo yafuatayo:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

Kuomba zana andika:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Unapaswa kuona matokeo yafuatayo:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Kwa kawaida ni haraka sana kuendesha ispector katika hali ya CLI kuliko kwenye kivinjari.
> Soma zaidi kuhusu ispector [hapa](https://github.com/modelcontextprotocol/inspector).

**Kanusho**: 
Hati hii imetafsiriwa kwa kutumia huduma ya kutafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya asili katika lugha yake ya kiasili inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, inashauriwa kutumia huduma za kitaalamu za tafsiri ya binadamu. Hatutawajibika kwa kutoelewana au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.