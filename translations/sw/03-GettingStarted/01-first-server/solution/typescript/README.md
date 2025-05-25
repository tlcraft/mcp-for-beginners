<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:25:53+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "sw"
}
-->
# Kuendesha sampuli hii

Inapendekezwa usakinishe `uv` lakini si lazima, angalia [maelekezo](https://docs.astral.sh/uv/#highlights)

## -1- Sakinisha utegemezi

```bash
npm install
```

## -3- Endesha sampuli

```bash
npm run build
```

## -4- Jaribu sampuli

Ukiwa na seva inayoendesha katika terminal moja, fungua terminal nyingine na endesha amri ifuatayo:

```bash
npm run inspector
```

Hii inapaswa kuanzisha seva ya wavuti yenye kiolesura cha kuona inayokuruhusu kujaribu sampuli.

Seva ikishakuwa imeunganishwa:

- jaribu kuorodhesha zana na endesha `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` ni kifungashio chake.

Unaweza kuizindua moja kwa moja katika hali ya CLI kwa kuendesha amri ifuatayo:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Hii itaorodhesha zana zote zinazopatikana kwenye seva. Unapaswa kuona matokeo yafuatayo:

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

Ili kuitisha chombo andika:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Kwa kawaida ni haraka zaidi kuendesha ispector katika hali ya CLI kuliko kwenye kivinjari.
> Soma zaidi kuhusu ispector [hapa](https://github.com/modelcontextprotocol/inspector).

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya awali katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, inashauriwa kutumia tafsiri ya kitaalamu ya kibinadamu. Hatutawajibika kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.