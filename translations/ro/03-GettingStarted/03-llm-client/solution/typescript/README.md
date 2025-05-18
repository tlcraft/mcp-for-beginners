<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:58:43+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "ro"
}
-->
# Rularea acestui exemplu

Acest exemplu implică să aveți un LLM pe client. LLM-ul necesită fie să rulați acest lucru într-un Codespaces, fie să configurați un token de acces personal în GitHub pentru a funcționa.

## -1- Instalează dependențele

```bash
npm install
```

## -3- Rulează serverul

```bash
npm run build
```

## -4- Rulează clientul

```sh
npm run client
```

Ar trebui să vedeți un rezultat similar cu:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**Declinarea responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți de faptul că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa maternă ar trebui să fie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea umană profesională. Nu ne asumăm responsabilitatea pentru neînțelegerile sau interpretările greșite care pot apărea din utilizarea acestei traduceri.