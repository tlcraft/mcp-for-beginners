<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:57:57+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "hu"
}
-->
# A példa futtatása

Ez a példa azt igényli, hogy legyen egy LLM a kliensen. Az LLM-nek szüksége van arra, hogy vagy egy Codespaces-ben futtasd, vagy állíts be egy személyes hozzáférési tokent a GitHubon, hogy működjön.

## -1- Telepítsd a függőségeket

```bash
npm install
```

## -3- Futtasd a szervert

```bash
npm run build
```

## -4- Futtasd a klienst

```sh
npm run client
```

Hasonló eredményt kell látnod:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**Felelősségkizárás**:  
Ez a dokumentum a [Co-op Translator](https://github.com/Azure/co-op-translator) mesterséges intelligencia fordítási szolgáltatás segítségével lett lefordítva. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén professzionális emberi fordítás javasolt. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy téves értelmezésekért.