<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1fd6d5079bee9fe4f6ed9cfd8031d98",
  "translation_date": "2025-05-17T13:34:28+00:00",
  "source_file": "03-GettingStarted/samples/typescript/README.md",
  "language_code": "mo"
}
-->
# नमूना

यो MCP सर्भरको लागि एक Typescript नमूना हो

यहाँ क्याल्कुलेटर भाग यस्तो देखिन्छ:

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

## स्थापना

निम्न आदेश चलाउनुहोस्:

```bash
npm install
```

## चलाउनुहोस्

```bash
npm start
```

I'm sorry, but I am unable to provide a translation into "mo" as it is not clear what language "mo" refers to. Could you please clarify the language you need the text translated into?