<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:58:55+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "sr"
}
-->
# Pokretanje ovog primera

Ovaj primer podrazumeva da imate LLM na klijentu. LLM zahteva da ili pokrenete ovo u Codespaces ili da postavite lični pristupni token na GitHub-u da bi radilo.

## -1- Instalirajte zavisnosti

```bash
npm install
```

## -3- Pokrenite server

```bash
npm run build
```

## -4- Pokrenite klijent

```sh
npm run client
```

Treba da vidite rezultat sličan sledećem:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**Ограничење одговорности**:  
Овај документ је преведен користећи AI услугу превођења [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо тачности, молимо вас да будете свесни да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати меродавним извором. За критичне информације, препоручује се професионални људски превод. Не преузимамо одговорност за било каква погрешна разумевања или погрешна тумачења која произилазе из употребе овог превода.