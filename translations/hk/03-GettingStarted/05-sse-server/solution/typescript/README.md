<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:07:57+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "hk"
}
-->
# 運行這個範例

## -1- 安裝依賴項

```bash
npm install
```

## -3- 運行範例

```bash
npm run build
```

## -4- 測試範例

在一個終端運行服務器後，打開另一個終端並運行以下命令：

```bash
npm run inspector
```

這應該會啟動一個帶有視覺介面的網絡服務器，讓你可以測試這個範例。

服務器連接後：

- 嘗試列出工具並運行 `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build`。

- 在另一個終端運行以下命令：

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    這將列出服務器中所有可用的工具。你應該能看到以下輸出：

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

- 通過輸入以下命令調用工具類型：

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

你應該能看到以下輸出：

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
> 通常在CLI模式下運行檢查器比在瀏覽器中要快得多。
> 在[這裡](https://github.com/modelcontextprotocol/inspector)了解更多關於檢查器的信息。

**免責聲明**：
此文件已使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。儘管我們努力追求準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於關鍵信息，建議使用專業人工翻譯。我們不對使用此翻譯所引起的任何誤解或誤讀承擔責任。