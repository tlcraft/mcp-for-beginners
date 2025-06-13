<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:39:30+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "tw"
}
-->
在前面的程式碼中，我們：

- 匯入了相關函式庫
- 建立了一個 client 實例，並使用 stdio 作為傳輸方式連線
- 列出 prompts、resources 和 tools，並且全部呼叫執行

這樣就完成了一個可以與 MCP Server 通訊的 client。

接下來的練習部分，我們會花時間逐段解析程式碼，說明每個部分的作用。

## 練習：撰寫 client

如上所述，我們會慢慢解釋程式碼，如果想要的話，也可以跟著一起寫。

### -1- 匯入函式庫

先匯入所需的函式庫，我們需要用到 client 和我們選擇的傳輸協定 stdio。stdio 是用來在本機執行的協定。SSE 是另一種傳輸協定，未來章節會介紹，但目前先用 stdio。

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。