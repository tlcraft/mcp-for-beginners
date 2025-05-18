<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:58:20+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "sk"
}
-->
# Spustenie tejto ukážky

Táto ukážka zahŕňa použitie LLM na klientovi. LLM vyžaduje, aby ste ju buď spustili v Codespaces, alebo nastavili osobný prístupový token v GitHub, aby fungovala.

## -1- Nainštalujte závislosti

```bash
npm install
```

## -3- Spustite server

```bash
npm run build
```

## -4- Spustite klienta

```sh
npm run client
```

Mali by ste vidieť výsledok podobný:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**Upozornenie**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, uvedomte si, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny preklad ľudským prekladateľom. Nie sme zodpovední za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.