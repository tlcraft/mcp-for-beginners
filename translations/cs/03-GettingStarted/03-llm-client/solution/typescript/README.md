<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-27T16:20:04+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "cs"
}
-->
# Ejecutar este ejemplo

Este ejemplo implica tener un LLM en el cliente. El LLM necesita que ejecutes esto en Codespaces o que configures un token de acceso personal en GitHub para que funcione.

## -1- Instalar las dependencias

```bash
npm install
```

## -3- Ejecutar el servidor

```bash
npm run build
```

## -4- Ejecutar el cliente

```sh
npm run client
```

Deberías ver un resultado similar a:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za závazný zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné interpretace vzniklé použitím tohoto překladu.