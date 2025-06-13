<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:39:18+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "hk"
}
-->
在之前的程式碼中，我們：

- 匯入了所需的函式庫
- 建立了一個客戶端實例，並使用 stdio 作為傳輸方式連接
- 列出提示、資源和工具，並全部調用

這樣就完成了一個能與 MCP Server 溝通的客戶端。

接下來，我們會在練習部分慢慢拆解每段程式碼並解釋其運作。

## 練習：撰寫客戶端

如前所述，讓我們慢慢說明程式碼，如果你願意，也可以跟著一起寫。

### -1- 匯入函式庫

先匯入我們需要的函式庫，我們需要用到 client 和選擇的傳輸協定 stdio。stdio 是設計給本地機器運行的協定。SSE 是另一種傳輸協定，我們會在未來章節介紹，但現在先用 stdio 繼續。

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋努力確保準確性，但請注意自動翻譯可能會有錯誤或不準確之處。原文文件以其母語版本為權威來源。如涉及重要資訊，建議採用專業人工翻譯。我哋對因使用本翻譯而引致嘅任何誤解或誤釋概不負責。