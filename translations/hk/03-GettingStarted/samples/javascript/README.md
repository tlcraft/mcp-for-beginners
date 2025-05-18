<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f27f8c14853621d982185e6bbdd1dc6",
  "translation_date": "2025-05-17T13:20:52+00:00",
  "source_file": "03-GettingStarted/samples/javascript/README.md",
  "language_code": "hk"
}
-->
# 示例

這是一個用於 MCP 伺服器的 JavaScript 示例

以下是計算器部分的樣子：

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

## 安裝

運行以下命令：

```bash
npm install
```

## 運行

```bash
npm start
```

**免責聲明**：
本文檔已使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始語言的文件應被視為權威來源。對於重要信息，建議使用專業人工翻譯。因使用此翻譯而產生的任何誤解或誤讀，我們概不負責。