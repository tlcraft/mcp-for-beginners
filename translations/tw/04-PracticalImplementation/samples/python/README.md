<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T14:55:57+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "tw"
}
-->
# 範例

這是一個用於 MCP 伺服器的 Python 範例。

此模組展示如何實作一個可以處理完成請求的基本 MCP 伺服器。它提供了一個模擬實作，用來模擬與各種 AI 模型的互動。

以下是工具註冊過程的樣子：

```python
completion_tool = ToolDefinition(
    name="completion",
    description="Generate completions using AI models",
    parameters={
        "model": {
            "type": "string",
            "enum": self.models,
            "description": "The AI model to use for completion"
        },
        "prompt": {
            "type": "string",
            "description": "The prompt text to complete"
        },
        "temperature": {
            "type": "number",
            "description": "Sampling temperature (0.0 to 1.0)"
        },
        "max_tokens": {
            "type": "number",
            "description": "Maximum number of tokens to generate"
        }
    },
    required=["model", "prompt"]
)

# Register the tool with its handler
self.server.tools.register(completion_tool, self._handle_completion)
```

## 安裝

執行以下命令：

```bash
pip install mcp
```

## 執行

```bash
python mcp_sample.py
```

**免責聲明**：

本文件使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始語言的文件應被視為權威來源。對於關鍵信息，建議進行專業人工翻譯。我們對於使用本翻譯所產生的任何誤解或誤讀不承擔責任。