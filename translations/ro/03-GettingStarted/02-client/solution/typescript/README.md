<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fae57a69c2b62cb7d92ff12da65f36c3",
  "translation_date": "2025-05-17T10:11:55+00:00",
  "source_file": "03-GettingStarted/02-client/solution/typescript/README.md",
  "language_code": "ro"
}
-->
# Rularea acestui exemplu

Se recomandă instalarea `uv`, dar nu este obligatoriu, vezi [instrucțiuni](https://docs.astral.sh/uv/#highlights)

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

Ar trebui să vezi un rezultat similar cu:

```text
Prompt:  {
  type: 'text',
  text: 'Please review this code:\n\nconsole.log("hello");'
}
Resource template:  file
Tool result:  { content: [ { type: 'text', text: '9' } ] }
```

**Declinarea responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa maternă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de oameni. Nu suntem responsabili pentru neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.