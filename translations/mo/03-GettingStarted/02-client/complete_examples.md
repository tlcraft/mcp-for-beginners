<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:31:07+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "mo"
}
-->
# 完整的 MCP 客戶端範例

此目錄包含不同程式語言的完整且可運作的 MCP 客戶端範例。每個客戶端都展示了主 README.md 教學中描述的完整功能。

## 可用的客戶端

### 1. Java 客戶端 (`client_example_java.java`)
- **傳輸方式**：HTTP 上的 SSE（伺服器推送事件）
- **目標伺服器**：`http://localhost:8080`
- **功能**：
  - 連線建立與心跳檢測
  - 工具列表
  - 計算器操作（加、減、乘、除、說明）
  - 錯誤處理與結果擷取

**執行方式：**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# 客戶端 (`client_example_csharp.cs`)
- **傳輸方式**：標準輸入/輸出（Stdio）
- **目標伺服器**：透過 dotnet run 啟動的本地 .NET MCP 伺服器
- **功能**：
  - 透過 stdio 傳輸自動啟動伺服器
  - 工具與資源列表
  - 計算器操作
  - JSON 結果解析
  - 全面錯誤處理

**執行方式：**
```bash
dotnet run
```

### 3. TypeScript 客戶端 (`client_example_typescript.ts`)
- **傳輸方式**：標準輸入/輸出（Stdio）
- **目標伺服器**：本地 Node.js MCP 伺服器
- **功能**：
  - 完整 MCP 協議支援
  - 工具、資源與提示操作
  - 計算器操作
  - 資源讀取與提示執行
  - 強健的錯誤處理

**執行方式：**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python 客戶端 (`client_example_python.py`)
- **傳輸方式**：標準輸入/輸出（Stdio）  
- **目標伺服器**：本地 Python MCP 伺服器
- **功能**：
  - 使用 async/await 模式進行操作
  - 工具與資源探索
  - 計算器操作測試
  - 資源內容讀取
  - 以類別組織程式碼

**執行方式：**
```bash
python client_example_python.py
```

## 所有客戶端共通功能

每個客戶端實作都展示了：

1. **連線管理**
   - 與 MCP 伺服器建立連線
   - 處理連線錯誤
   - 適當的清理與資源管理

2. **伺服器探索**
   - 列出可用工具
   - 列出可用資源（若支援）
   - 列出可用提示（若支援）

3. **工具呼叫**
   - 基本計算器操作（加、減、乘、除）
   - 伺服器資訊說明指令
   - 正確的參數傳遞與結果處理

4. **錯誤處理**
   - 連線錯誤
   - 工具執行錯誤
   - 優雅失敗與使用者回饋

5. **結果處理**
   - 從回應中擷取文字內容
   - 格式化輸出以提升可讀性
   - 處理不同的回應格式

## 執行前置條件

在執行這些客戶端之前，請確保：

1. **對應的 MCP 伺服器已啟動**（來自 `../01-first-server/`）
2. **已安裝所選語言所需的相依套件**
3. **網路連線正常**（針對 HTTP 傳輸）

## 各實作間的主要差異

| 語言       | 傳輸方式 | 伺服器啟動方式 | 非同步模型 | 主要函式庫         |
|------------|----------|----------------|------------|--------------------|
| Java       | SSE/HTTP | 外部啟動       | 同步       | WebFlux, MCP SDK   |
| C#         | Stdio    | 自動啟動       | Async/Await| .NET MCP SDK       |
| TypeScript | Stdio    | 自動啟動       | Async/Await| Node MCP SDK       |
| Python     | Stdio    | 自動啟動       | AsyncIO    | Python MCP SDK     |

## 下一步

瀏覽完這些客戶端範例後：

1. **修改客戶端**，新增功能或操作
2. **自行建立伺服器**，並用這些客戶端測試
3. **嘗試不同傳輸方式**（SSE 與 Stdio）
4. **打造更複雜的應用程式**，整合 MCP 功能

## 疑難排解

### 常見問題

1. **連線被拒絕**：確認 MCP 伺服器是否在預期的埠號/路徑上運行
2. **找不到模組**：安裝對應語言的 MCP SDK
3. **權限被拒**：檢查 stdio 傳輸的檔案權限
4. **找不到工具**：確認伺服器是否實作預期的工具

### 除錯建議

1. **啟用 MCP SDK 的詳細日誌**
2. **檢查伺服器日誌中的錯誤訊息**
3. **確認客戶端與伺服器的工具名稱與簽章一致**
4. **先用 MCP Inspector 測試伺服器功能**

## 相關文件

- [主客戶端教學](./README.md)
- [MCP 伺服器範例](../../../../03-GettingStarted/01-first-server)
- [MCP 與 LLM 整合](../../../../03-GettingStarted/03-llm-client)
- [官方 MCP 文件](https://modelcontextprotocol.io/)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。