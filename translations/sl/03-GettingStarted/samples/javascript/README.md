<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f27f8c14853621d982185e6bbdd1dc6",
  "translation_date": "2025-05-17T13:26:17+00:00",
  "source_file": "03-GettingStarted/samples/javascript/README.md",
  "language_code": "sl"
}
-->
# සාම්පලය

මෙය MCP සේවාදායකය සඳහා ජාවාස්ක්‍රිප්ට් සාම්පලයකි

මෙහි ගණකය කොටස මෙසේ පෙනේ:

```javascript
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

## ස්ථාපනය

පහත විධානය ක්‍රියාත්මක කරන්න:

```bash
npm install
```

## ක්‍රියාත්මක කරන්න

```bash
npm start
```

**Zavrnitev odgovornosti**: 
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da se zavedate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za kritične informacije se priporoča profesionalni človeški prevod. Ne odgovarjamo za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.