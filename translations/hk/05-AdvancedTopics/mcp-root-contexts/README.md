<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8311f46a35cf608c9780f39b62c9dc3f",
  "translation_date": "2025-07-14T01:59:27+00:00",
  "source_file": "05-AdvancedTopics/mcp-root-contexts/README.md",
  "language_code": "hk"
}
-->
## 範例：財務分析的 Root Context 實作

在此範例中，我們將建立一個用於財務分析會話的 root context，示範如何在多次互動中維持狀態。

## 範例：Root Context 管理

有效管理 root context 對於維持對話歷史和狀態至關重要。以下是一個實作 root context 管理的範例。

## 多回合協助的 Root Context

在此範例中，我們將建立一個用於多回合協助會話的 root context，示範如何在多次互動中維持狀態。

## Root Context 最佳實務

以下是一些有效管理 root context 的最佳實務：

- **建立專注的 Context**：針對不同的對話目的或領域建立獨立的 root context，以保持清晰。

- **設定過期政策**：實施政策來封存或刪除舊的 context，以管理儲存空間並符合資料保留規範。

- **儲存相關的元資料**：利用 context 的元資料來保存對話中可能日後有用的重要資訊。

- **一致使用 Context ID**：一旦建立 context，所有相關請求都應一致使用其 ID，以維持連續性。

- **產生摘要**：當 context 變得龐大時，考慮產生摘要以擷取重要資訊，同時管理 context 大小。

- **實施存取控制**：對於多用戶系統，實施適當的存取控制以確保對話 context 的隱私與安全。

- **處理 Context 限制**：了解 context 大小的限制，並實施策略來應對非常長的對話。

- **完成後封存**：當對話結束時，封存 context 以釋放資源，同時保留對話歷史。

## 接下來的內容

- [5.5 路由](../mcp-routing/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或誤釋承擔責任。