<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "69ba3bd502bd743233137bac5539c08b",
<<<<<<< HEAD
  "translation_date": "2025-08-18T19:06:49+00:00",
=======
  "translation_date": "2025-08-18T14:10:50+00:00",
>>>>>>> origin/main
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "sw"
}
-->
# Kuendesha sampuli hii

Inapendekezwa usakinishe `uv` lakini si lazima, angalia [maelekezo](https://docs.astral.sh/uv/#highlights)

<<<<<<< HEAD
## -0- Unda mazingira ya mtandaoni
=======
## -0- Unda mazingira ya kawaida (virtual environment)
>>>>>>> origin/main

```bash
python -m venv venv
```

<<<<<<< HEAD
## -1- Washa mazingira ya mtandaoni
=======
## -1- Washa mazingira ya kawaida
>>>>>>> origin/main

```bash
venv\Scrips\activate
```

## -2- Sakinisha mahitaji

```bash
pip install "mcp[cli]"
```

## -3- Endesha sampuli

```bash
uvicorn server:app
```

## -4- Jaribu sampuli

<<<<<<< HEAD
Ukiwa na seva inayoendelea kwenye terminal moja, fungua terminal nyingine na endesha amri ifuatayo:
=======
Ukiwa na seva inayoendesha kwenye terminal moja, fungua terminal nyingine na endesha amri ifuatayo:
>>>>>>> origin/main

```bash
mcp dev server.py
```

<<<<<<< HEAD
Hii inapaswa kuanzisha seva ya wavuti yenye kiolesura cha kuona kinachokuwezesha kujaribu sampuli.
=======
Hii inapaswa kuanzisha seva ya wavuti yenye kiolesura cha kuona kinachokuruhusu kujaribu sampuli.
>>>>>>> origin/main

Mara seva inapounganishwa:

- jaribu kuorodhesha zana na endesha `add`, ukiwa na hoja 2 na 4, unapaswa kuona 6 kama matokeo.
<<<<<<< HEAD
- nenda kwenye rasilimali na kiolezo cha rasilimali na uite get_greeting, andika jina na unapaswa kuona salamu na jina ulilotoa.

### Kujaribu katika hali ya CLI

Kikagua ulichokimbia ni programu ya Node.js na `mcp dev` ni kifuniko kinachozunguka programu hiyo.

Unaweza kuizindua moja kwa moja katika hali ya CLI kwa kuendesha amri ifuatayo:
=======
- nenda kwenye rasilimali na templeti ya rasilimali na uite get_greeting, andika jina na unapaswa kuona salamu na jina ulilotoa.

### Kujaribu katika hali ya CLI

Kikaguzi ulichokimbia ni programu ya Node.js na `mcp dev` ni kifuniko (wrapper) kinachokizunguka.

Unaweza kukizindua moja kwa moja katika hali ya CLI kwa kuendesha amri ifuatayo:
>>>>>>> origin/main

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

<<<<<<< HEAD
Hii itatoa orodha ya zana zote zinazopatikana kwenye seva. Unapaswa kuona matokeo yafuatayo:
=======
Hii itaorodhesha zana zote zinazopatikana kwenye seva. Unapaswa kuona matokeo yafuatayo:
>>>>>>> origin/main

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

<<<<<<< HEAD
Ili kuita chombo, andika:
=======
Ili kuita zana andika:
>>>>>>> origin/main

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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

<<<<<<< HEAD
> ![!TIP]
> Kwa kawaida ni haraka zaidi kuendesha kikagua katika hali ya CLI kuliko kwenye kivinjari.
> Soma zaidi kuhusu kikagua [hapa](https://github.com/modelcontextprotocol/inspector).

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya asili katika lugha yake ya awali inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, inashauriwa kutumia huduma ya tafsiri ya kitaalamu ya binadamu. Hatutawajibika kwa maelewano mabaya au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.
=======
> [!TIP]  
> Kwa kawaida ni haraka zaidi kuendesha kikaguzi katika hali ya CLI kuliko kwenye kivinjari.  
> Soma zaidi kuhusu kikaguzi [hapa](https://github.com/modelcontextprotocol/inspector).

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya asili katika lugha yake ya awali inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatutawajibika kwa kutoelewana au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.
>>>>>>> origin/main
