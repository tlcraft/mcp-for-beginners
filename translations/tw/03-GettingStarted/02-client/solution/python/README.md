<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:00:06+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "tw"
}
-->
# 執行此範例

建議安裝 `uv`，但不是必須，請參閱[指示](https://docs.astral.sh/uv/#highlights)

## -0- 建立虛擬環境

```bash
python -m venv venv
```

## -1- 啟動虛擬環境

```bash
venv\Scrips\activate
```

## -2- 安裝相依套件

```bash
pip install "mcp[cli]"
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
READING RESOURCE
                    INFO     Processing request of type ReadResourceRequest                                                                            server.py:534
CALL TOOL
                    INFO     Processing request of type CallToolRequest                                                                                server.py:534
[TextContent(type='text', text='8', annotations=None)]
```

**免責聲明**：
本文檔已使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。儘管我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不精確之處。應以原始語言的文件為權威來源。對於關鍵信息，建議尋求專業人工翻譯。我們對於使用此翻譯所產生的任何誤解或誤讀不承擔責任。