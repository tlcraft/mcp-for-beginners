<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24531f2b6b0f7fa3839accf4dc10088a",
  "translation_date": "2025-05-17T10:46:32+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/python/README.md",
  "language_code": "tw"
}
-->
# 執行此範例

建議安裝 `uv`，但不是必須的，請參閱[說明](https://docs.astral.sh/uv/#highlights)

## -0- 建立虛擬環境

```bash
python -m venv venv
```

## -1- 啟用虛擬環境

```bash
venv\Scrips\activate
```

## -2- 安裝相依套件

```bash
pip install "mcp[cli]"
pip install openai
pip install azure-ai-inference
```

## -3- 執行範例

```bash
python client.py
```

你應該會看到類似以下的輸出：

```text
LISTING RESOURCES
Resource:  ('meta', None)
Resource:  ('nextCursor', None)
Resource:  ('resources', [])
                    INFO     Processing request of type ListToolsRequest                                                                               server.py:534
LISTING TOOLS
Tool:  add
Tool {'a': {'title': 'A', 'type': 'integer'}, 'b': {'title': 'B', 'type': 'integer'}}
CALLING LLM
TOOL:  {'function': {'arguments': '{"a":2,"b":20}', 'name': 'add'}, 'id': 'call_BCbyoCcMgq0jDwR8AuAF9QY3', 'type': 'function'}
[05/08/25 21:04:55] INFO     Processing request of type CallToolRequest                                                                                server.py:534
TOOLS result:  [TextContent(type='text', text='22', annotations=None)]
```

**免責聲明**：

本文件是使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯的。我們努力確保翻譯的準確性，但請注意，自動翻譯可能會包含錯誤或不精確之處。應以原語言的文件為權威來源。對於關鍵資訊，建議尋求專業人工翻譯。我們對於使用此翻譯所產生的任何誤解或誤釋不承擔責任。