<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3cb0da3badd51d73ab78ebade2827d98",
  "translation_date": "2025-06-12T21:29:46+00:00",
  "source_file": "05-AdvancedTopics/mcp-sampling/README.md",
  "language_code": "hk"
}
-->
## 確定性抽樣

對於需要穩定輸出的應用，確定性抽樣可以確保結果可重現。它的做法是使用固定的隨機種子，並將溫度設為零。

以下示例展示了如何在不同編程語言中實現確定性抽樣。

## 動態抽樣配置

智能抽樣會根據每個請求的上下文和需求調整參數。這表示會根據任務類型、用戶偏好或歷史表現，動態調整溫度、top_p 和懲罰等參數。

以下展示了如何在不同編程語言中實現動態抽樣。

## 下一步

- [5.7 Scaling](../mcp-scaling/README.md)

**免責聲明**：  
本文件乃使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件之母語版本應被視為權威來源。對於重要資訊，建議使用專業人工翻譯。我們對因使用本翻譯而引起之任何誤解或誤釋概不負責。