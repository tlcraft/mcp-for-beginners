<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:44:27+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "hk"
}
-->
# Calculator HTTP Streaming Demo

此專案示範了使用 Spring Boot WebFlux 的 Server-Sent Events (SSE) 進行 HTTP 串流。專案包含兩個應用程式：

- **Calculator Server**：一個反應式網路服務，執行計算並透過 SSE 串流結果
- **Calculator Client**：一個消費串流端點的客戶端應用程式

## 先決條件

- Java 17 或以上版本
- Maven 3.6 或以上版本

## 專案結構

```
java/
├── calculator-server/     # Spring Boot server with SSE endpoint
│   ├── src/main/java/com/example/calculatorserver/
│   │   ├── CalculatorServerApplication.java
│   │   └── CalculatorController.java
│   └── pom.xml
├── calculator-client/     # Spring Boot client application
│   ├── src/main/java/com/example/calculatorclient/
│   │   └── CalculatorClientApplication.java
│   └── pom.xml
└── README.md
```

## 運作原理

1. **Calculator Server** 提供 `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - 消費串流回應
   - 將每個事件輸出到主控台

## 執行應用程式

### 選項 1：使用 Maven（推薦）

#### 1. 啟動 Calculator Server

開啟終端機並切換到 server 目錄：

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

伺服器將在 `http://localhost:8080` 啟動

你會看到類似以下的輸出：
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. 執行 Calculator Client

開啟 **新的終端機** 並切換到 client 目錄：

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

客戶端會連接伺服器，執行計算並顯示串流結果。

### 選項 2：直接使用 Java

#### 1. 編譯並執行伺服器：

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. 編譯並執行客戶端：

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## 手動測試伺服器

你也可以用瀏覽器或 curl 來測試伺服器：

### 使用瀏覽器：
造訪：`http://localhost:8080/calculate?a=10&b=5&op=add`

### 使用 curl：
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## 預期輸出

執行客戶端時，你應該會看到類似以下的串流輸出：

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## 支援的運算

- `add` - Addition (a + b)
- `sub` - Subtraction (a - b)
- `mul` - Multiplication (a * b)
- `div` - Division (a / b, returns NaN if b = 0)

## API Reference

### GET /calculate

**Parameters:**
- `a` (required): First number (double)
- `b` (required): Second number (double)
- `op` (required): Operation (`add`, `sub`, `mul`, `div`)

**Response:**
- Content-Type: `text/event-stream`
- 回傳包含計算進度與結果的 Server-Sent Events

**範例請求：**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**範例回應：**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## 疑難排解

### 常見問題

1. **Port 8080 已被佔用**
   - 停止其他使用 8080 埠的應用程式
   - 或在 `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` 中更改伺服器埠號（如果是背景執行的話）

## 技術棧

- **Spring Boot 3.3.1** - 應用程式框架
- **Spring WebFlux** - 反應式網頁框架
- **Project Reactor** - 反應式串流函式庫
- **Netty** - 非阻塞 I/O 伺服器
- **Maven** - 建置工具
- **Java 17+** - 程式語言

## 下一步

試著修改程式碼來：
- 新增更多數學運算
- 加入錯誤處理，處理無效的運算
- 新增請求/回應日誌
- 實作身份驗證
- 新增單元測試

**免責聲明**：  
本文件經由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯而成。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或錯誤詮釋承擔責任。