<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2342baa570312086fc19edcf41320250",
  "translation_date": "2025-06-17T15:23:27+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "tw"
}
-->
在前面的程式碼中，我們：

- 匯入了所需的函式庫
- 建立了一個 client 實例，並使用 stdio 作為傳輸方式進行連接
- 列出了 prompts、資源和工具，並且都執行了它們

這樣你就擁有了一個可以與 MCP Server 溝通的 client。

接下來的練習部分，我們會花時間逐段解析程式碼，說明每個部分的運作原理。

## 練習：撰寫一個 client

如前所述，我們將花時間詳細解說程式碼，當然你也可以跟著一起編寫。

### -1- 匯入函式庫

讓我們先匯入所需的函式庫，我們需要引用 client 和選擇的傳輸協定 stdio。stdio 是一種適用於在本機執行的協定。SSE 是另一種傳輸協定，我們會在後續章節介紹，但目前先用 stdio。

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們力求準確，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤譯負責。