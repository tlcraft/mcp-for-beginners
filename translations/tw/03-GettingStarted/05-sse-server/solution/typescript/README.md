<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:08:10+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "tw"
}
-->
# 執行這個範例

## -1- 安裝依賴項目

```bash
npm install
```

## -3- 執行範例

```bash
npm run build
```

## -4- 測試範例

在一個終端運行伺服器後，打開另一個終端並運行以下命令：

```bash
npm run inspector
```

這應該會啟動一個帶有視覺介面的網絡伺服器，讓你測試這個範例。

伺服器連接後：

- 嘗試列出工具並運行 `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build`。

- 在另一個終端運行以下命令：

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    這將列出伺服器中所有可用的工具。你應該會看到以下輸出：

    ```text
    {
    "tools": [
        {
        "name": "add",
        "description": "Add two numbers",
        "inputSchema": {
            "type": "object",
            "properties": {
            "a": {
                "title": "A",
                "type": "integer"
            },
            "b": {
                "title": "B",
                "type": "integer"
            }
            },
            "required": [
            "a",
            "b"
            ],
            "title": "addArguments"
        }
        }
    ]
    }
    ```

- 輸入以下命令來調用工具類型：

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

你應該會看到以下輸出：

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> 通常在命令行模式下運行檢查器比在瀏覽器中要快得多。
> 在[這裡](https://github.com/modelcontextprotocol/inspector)閱讀更多關於檢查器的信息。

**免責聲明**：
本文件已使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。儘管我們努力確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。應將原始文件的母語版本視為權威來源。對於關鍵信息，建議使用專業人工翻譯。對於因使用本翻譯而產生的任何誤解或誤讀，我們不承擔責任。