<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e1cbc99fa7185139ad6d539eca09a2b3",
  "translation_date": "2025-06-02T20:23:10+00:00",
  "source_file": "05-AdvancedTopics/mcp-root-contexts/README.md",
  "language_code": "tw"
}
-->
## Root Context 最佳實務

以下是有效管理 root context 的一些最佳實務：

- **建立專注的 Context**：為不同的對話目的或領域建立獨立的 root context，以維持清晰度。

- **設定過期政策**：實施政策來封存或刪除舊的 context，以管理儲存空間並符合資料保留規範。

- **儲存相關的 Metadata**：利用 context 的 metadata 儲存對話中可能日後有用的重要資訊。

- **一致使用 Context ID**：一旦建立 context，就持續使用其 ID 來處理所有相關請求，以維持連貫性。

- **生成摘要**：當 context 變得龐大時，考慮生成摘要來擷取重要資訊，同時控制 context 大小。

- **實施存取控制**：對於多用戶系統，實施適當的存取控制，確保對話 context 的隱私與安全。

- **處理 Context 限制**：注意 context 大小的限制，並實施策略來應對非常長的對話。

- **完成時封存**：對話結束時封存 context，釋放資源同時保留對話歷史。

## 接下來

- [Routing](../mcp-routing/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。