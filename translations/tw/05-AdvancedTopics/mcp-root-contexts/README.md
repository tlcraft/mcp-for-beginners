<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8311f46a35cf608c9780f39b62c9dc3f",
  "translation_date": "2025-06-12T21:25:49+00:00",
  "source_file": "05-AdvancedTopics/mcp-root-contexts/README.md",
  "language_code": "tw"
}
-->
## 範例：金融分析的 Root Context 實作

在此範例中，我們將建立一個用於金融分析會話的 root context，展示如何在多次互動中維持狀態。

## 範例：Root Context 管理

有效管理 root context 對於維持對話歷史和狀態非常重要。以下是如何實作 root context 管理的範例。

## 多輪協助的 Root Context

在此範例中，我們將建立一個用於多輪協助會話的 root context，展示如何在多次互動中維持狀態。

## Root Context 最佳實踐

以下是一些有效管理 root context 的最佳實踐：

- **建立專注的 Context**：針對不同的對話目的或領域建立獨立的 root context，以維持清晰度。

- **設定過期政策**：實作政策來封存或刪除舊的 context，以管理儲存空間並符合資料保存規範。

- **儲存相關的 Metadata**：利用 context metadata 儲存對話中可能日後有用的重要資訊。

- **一致使用 Context ID**：一旦建立 context，就持續使用其 ID 來處理所有相關請求，以維持連續性。

- **產生摘要**：當 context 變得龐大時，考慮產生摘要以擷取重要資訊，同時控制 context 大小。

- **實作存取控制**：對於多使用者系統，實作適當的存取控制，確保對話 context 的隱私與安全。

- **處理 Context 限制**：了解 context 大小限制，並實作策略來應對非常長的對話。

- **完成後封存**：對話結束後封存 context，以釋放資源同時保留對話歷史。

## 下一步

- [5.5 Routing](../mcp-routing/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們力求準確，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議使用專業人工翻譯。我們不對因使用此翻譯所產生之任何誤解或誤釋負責。