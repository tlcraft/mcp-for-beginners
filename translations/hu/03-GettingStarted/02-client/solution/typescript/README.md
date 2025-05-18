<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fae57a69c2b62cb7d92ff12da65f36c3",
  "translation_date": "2025-05-17T10:11:26+00:00",
  "source_file": "03-GettingStarted/02-client/solution/typescript/README.md",
  "language_code": "hu"
}
-->
# A minta futtatása

Ajánlott telepíteni a(z) `uv` csomagot, de nem kötelező, lásd [útmutató](https://docs.astral.sh/uv/#highlights)

## -1- A függőségek telepítése

```bash
npm install
```

## -3- A szerver futtatása

```bash
npm run build
```

## -4- Az ügyfél futtatása

```sh
npm run client
```

Egy hasonló eredményt kell látnod:

```text
Prompt:  {
  type: 'text',
  text: 'Please review this code:\n\nconsole.log("hello");'
}
Resource template:  file
Tool result:  { content: [ { type: 'text', text: '9' } ] }
```

**Felelősségkizárás**:  
Ez a dokumentum az [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítási szolgáltatás használatával készült. Miközben igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum anyanyelvén tekintendő a hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítás ajánlott. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félremagyarázásokért.