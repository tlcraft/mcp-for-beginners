<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-07-14T02:28:11+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "tw"
}
-->
## 分散式架構

分散式架構包含多個 MCP 節點協同工作，處理請求、共享資源並提供冗餘備援。這種方式透過節點間的通訊與協調，提升系統的可擴展性與容錯能力。

以下是一個使用 Redis 進行協調，實作分散式 MCP 伺服器架構的範例。

## 接下來的內容

- [5.8 安全性](../mcp-security/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。