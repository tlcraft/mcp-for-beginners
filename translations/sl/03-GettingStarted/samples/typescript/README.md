<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1fd6d5079bee9fe4f6ed9cfd8031d98",
  "translation_date": "2025-05-17T13:40:32+00:00",
  "source_file": "03-GettingStarted/samples/typescript/README.md",
  "language_code": "sl"
}
-->
# Vzorec

To je vzorec Typescript za MCP strežnik

Tukaj je prikazan del kalkulatorja:

```typescript
// Define calculator tools for each operation
server.tool(
  "add",
  {
    a: z.number(),
    b: z.number()
  },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

server.tool(
  "subtract",
  {
    a: z.number(),
    b: z.number()
  },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a - b) }]
  })
);

server.tool(
  "multiply",
  {
    a: z.number(),
    b: z.number()
  },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a * b) }]
  })
);

server.tool(
  "divide",
  {
    a: z.number(),
    b: z.number()
  },
  async ({ a, b }) => {
    if (b === 0) {
      return {
        content: [{ type: "text", text: "Error: Cannot divide by zero" }],
        isError: true
      };
    }
    return {
      content: [{ type: "text", text: String(a / b) }]
    };
  }
);
```

## Namestitev

Zaženite naslednji ukaz:

```bash
npm install
```

## Zagon

```bash
npm start
```

**Omejitev odgovornosti**: 
Ta dokument je bil preveden s pomočjo storitve AI za prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Medtem ko si prizadevamo za natančnost, vas prosimo, da se zavedate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za kritične informacije se priporoča profesionalni prevod s strani človeka. Ne odgovarjamo za kakršna koli nesporazumevanja ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.