<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:21:49+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "hk"
}
-->
# Calculator LLM Client

一個示範點樣用 LangChain4j 連接 MCP（Model Context Protocol）計算機服務，並整合 GitHub Models 嘅 Java 應用程式。

## 先決條件

- Java 21 或以上版本
- Maven 3.6+（或者用內置嘅 Maven wrapper）
- 有 GitHub 帳戶並有權限使用 GitHub Models
- MCP 計算機服務運行喺 `http://localhost:8080`

## 點樣攞 GitHub Token

呢個應用程式用咗 GitHub Models，需要 GitHub 個人存取權杖。跟住以下步驟攞 token：

### 1. 進入 GitHub Models
1. 去 [GitHub Models](https://github.com/marketplace/models)
2. 用你嘅 GitHub 帳戶登入
3. 如果未有權限，申請使用 GitHub Models

### 2. 建立個人存取權杖
1. 去 [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. 撳「Generate new token」→「Generate new token (classic)」
3. 為 token 命名（例如「MCP Calculator Client」）
4. 設定過期時間（視乎需要）
5. 選擇以下範圍：
   - `repo`（如果要存取私有倉庫）
   - `user:email`
6. 撳「Generate token」
7. **重要**：即刻複製 token，之後就睇唔到啦！

### 3. 設定環境變數

#### Windows（Command Prompt）：
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

## 安裝同設定

1. **Clone 或者去到項目資料夾**

2. **安裝依賴**：
   ```cmd
   mvnw clean install
   ```
   如果你有全局裝 Maven：
   ```cmd
   mvn clean install
   ```

3. **設定環境變數**（見上面「點樣攞 GitHub Token」部分）

4. **啟動 MCP Calculator Service**：
   確保你有運行第一章嘅 MCP 計算機服務，地址係 `http://localhost:8080/sse`，啟動客戶端之前要先開咗服務。

## 運行應用程式

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## 應用程式做啲咩

呢個應用示範咗三個主要同計算機服務嘅互動：

1. **加法**：計算 24.5 同 17.3 嘅和
2. **平方根**：計算 144 嘅平方根
3. **幫助**：顯示可用嘅計算機功能

## 預期輸出

成功運行時，你應該會見到類似嘅輸出：

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## 排錯指南

### 常見問題

1. **「GITHUB_TOKEN 環境變數未設定」**
   - 確定你已經設定咗 `GITHUB_TOKEN` environment variable
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

### 調試

如果想開啟 debug 日誌，運行時加以下 JVM 參數：
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## 配置

應用程式配置：
- 用 GitHub Models 同 `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- 請求超時設為 60 秒
- 開啟請求/回應日誌方便調試

## 依賴

項目主要依賴：
- **LangChain4j**：用於 AI 整合同工具管理
- **LangChain4j MCP**：支持 Model Context Protocol
- **LangChain4j GitHub Models**：GitHub Models 整合
- **Spring Boot**：應用框架同依賴注入

## 授權

呢個項目係用 Apache License 2.0 授權 - 詳情見 [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) 文件。

**免責聲明**：  
本文件係用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋致力保持準確，但請注意自動翻譯可能包含錯誤或不準確嘅地方。原始文件嘅母語版本應被視為權威來源。對於重要資料，建議採用專業人工翻譯。我哋對因使用本翻譯而引起嘅任何誤會或誤解概不負責。