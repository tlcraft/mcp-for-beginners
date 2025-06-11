<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:22:12+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "tw"
}
-->
# Calculator LLM Client

一個 Java 應用程式，示範如何使用 LangChain4j 連接帶有 GitHub Models 整合的 MCP（Model Context Protocol）計算機服務。

## 先決條件

- Java 21 或以上版本
- Maven 3.6+（或使用附帶的 Maven wrapper）
- 擁有可使用 GitHub Models 的 GitHub 帳號
- 在 `http://localhost:8080` 運行中的 MCP 計算機服務

## 取得 GitHub Token

此應用程式使用 GitHub Models，需要 GitHub 個人存取權杖。請依照以下步驟取得你的權杖：

### 1. 進入 GitHub Models
1. 前往 [GitHub Models](https://github.com/marketplace/models)
2. 使用你的 GitHub 帳號登入
3. 若尚未申請，請申請使用 GitHub Models

### 2. 建立個人存取權杖
1. 前往 [GitHub 設定 → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. 點選「Generate new token」→「Generate new token (classic)」
3. 為你的權杖命名（例如：「MCP Calculator Client」）
4. 設定過期時間（依需求）
5. 選取以下權限範圍：
   - `repo`（若需存取私人倉庫）
   - `user:email`
6. 點選「Generate token」
7. **重要**：請立即複製權杖，之後將無法再次查看！

### 3. 設定環境變數

#### Windows（命令提示字元）：
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Windows（PowerShell）：
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### macOS/Linux：
```bash
export GITHUB_TOKEN=your_github_token_here
```

## 設定與安裝

1. **複製或切換到專案目錄**

2. **安裝相依套件**：
   ```cmd
   mvnw clean install
   ```
   或如果你已全域安裝 Maven：
   ```cmd
   mvn clean install
   ```

3. **設定環境變數**（參考上方「取得 GitHub Token」章節）

4. **啟動 MCP 計算機服務**：
   確認你已在 `http://localhost:8080/sse` 運行第一章的 MCP 計算機服務，需先啟動此服務才能啟動客戶端。

## 執行應用程式

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## 應用程式功能說明

此應用程式示範與計算機服務的三種主要互動：

1. **加法**：計算 24.5 與 17.3 的和
2. **平方根**：計算 144 的平方根
3. **幫助**：顯示可用的計算機功能

## 預期輸出

成功執行時，應看到類似以下的輸出：

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## 疑難排解

### 常見問題

1. **「GITHUB_TOKEN 環境變數未設定」**
   - 確認你已設定 `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean`

### 除錯

若要啟用除錯日誌，執行時加入以下 JVM 參數：
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## 設定說明

此應用程式設定為：
- 使用 GitHub Models，並設定為 `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- 請求超時時間為 60 秒
- 啟用請求/回應日誌以利除錯

## 相依套件

本專案主要使用的相依套件：
- **LangChain4j**：用於 AI 整合及工具管理
- **LangChain4j MCP**：支援 Model Context Protocol
- **LangChain4j GitHub Models**：整合 GitHub Models
- **Spring Boot**：應用程式框架與依賴注入

## 授權條款

本專案採用 Apache License 2.0 授權 - 詳情請參閱 [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) 檔案。

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們致力於翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。