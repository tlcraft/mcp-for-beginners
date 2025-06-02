<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0de03f7a3ff0204d8356bc61325c459",
  "translation_date": "2025-06-02T20:01:04+00:00",
  "source_file": "05-AdvancedTopics/mcp-sampling/README.md",
  "language_code": "hk"
}
-->
## 確定性取樣

對於需要穩定輸出的應用，確定性取樣確保結果可重現。方法是使用固定的隨機種子，並將溫度設為零。

以下示範如何在不同程式語言中實現確定性取樣。

## 動態取樣配置

智能取樣會根據每次請求的上下文和需求調整參數。即根據任務類型、用戶偏好或過往表現，動態調整溫度、top_p 和懲罰參數。

以下示範如何在不同程式語言中實現動態取樣。

## 下一步

- [Scaling](../mcp-scaling/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋致力於準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件嘅母語版本應被視為權威來源。對於重要資訊，建議使用專業人工翻譯。因使用此翻譯而引致嘅任何誤解或誤釋，我哋概不負責。