<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8311f46a35cf608c9780f39b62c9dc3f",
  "translation_date": "2025-06-12T21:30:10+00:00",
  "source_file": "05-AdvancedTopics/mcp-root-contexts/README.md",
  "language_code": "hk"
}
-->
## 範例：用於財務分析的 Root Context 實作

在這個範例中，我們會建立一個用於財務分析會話的 root context，示範如何在多次互動中保持狀態。

## 範例：Root Context 管理

有效管理 root context 對於維持對話歷史和狀態至關重要。以下是實作 root context 管理的範例。

## 用於多輪協助的 Root Context

在這個範例中，我們會建立一個用於多輪協助會話的 root context，示範如何在多次互動中保持狀態。

## Root Context 最佳實踐

以下是有效管理 root context 的一些最佳實踐：

- **建立專注的 Context**：為不同的對話目的或領域建立獨立的 root context，以保持清晰度。

- **設定過期政策**：實施政策來封存或刪除舊的 context，以管理儲存空間並符合資料保留規範。

- **儲存相關的元資料**：利用 context 元資料來保存對話中可能日後有用的重要資訊。

- **持續使用 Context ID**：建立 context 後，持續使用其 ID 來處理所有相關請求，以維持連貫性。

- **產生摘要**：當 context 變得龐大時，考慮產生摘要以捕捉關鍵資訊，同時管理 context 大小。

- **實施存取控制**：對於多用戶系統，實施適當的存取控制，確保對話 context 的隱私與安全。

- **處理 Context 限制**：了解 context 大小限制，並實施策略以處理非常長的對話。

- **完成後封存**：對話結束時封存 context，以釋放資源並保留對話歷史。

## 下一步

- [5.5 Routing](../mcp-routing/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯而成。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原文文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們對因使用此翻譯而引起的任何誤解或誤釋概不負責。