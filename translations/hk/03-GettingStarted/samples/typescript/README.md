<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1fd6d5079bee9fe4f6ed9cfd8031d98",
  "translation_date": "2025-05-17T13:34:46+00:00",
  "source_file": "03-GettingStarted/samples/typescript/README.md",
  "language_code": "hk"
}
-->
# 範例

這是一個用於 MCP 伺服器的 Typescript 範例

這是計算器部分的樣子：

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

## 安裝

執行以下命令：

```bash
npm install
```

## 執行

```bash
npm start
```

**免責聲明**：
本文檔已使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。我們努力追求準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。應以原始語言的文檔作為權威來源。對於重要信息，建議尋求專業人工翻譯。對於使用此翻譯所產生的任何誤解或誤讀，我們不承擔責任。