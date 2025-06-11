<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ed9cab32cc67c12d8969b407aa47100a",
  "translation_date": "2025-06-11T09:29:42+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/java/README.md",
  "language_code": "hk"
}
-->
# Basic Calculator MCP Service

呢個服務透過 Model Context Protocol (MCP) 用 Spring Boot 同 WebFlux 傳輸，提供基本嘅計算機操作。佢設計得簡單，適合初學者了解 MCP 實現嘅例子。

想知多啲，可以參考 [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html) 嘅官方文件。


## 使用服務

服務透過 MCP 協議公開以下 API 端點：

- `add(a, b)`：將兩個數字相加
- `subtract(a, b)`：用第一個數減第二個數
- `multiply(a, b)`：將兩個數字相乘
- `divide(a, b)`：用第一個數除以第二個數（會檢查除數是否為零）
- `power(base, exponent)`：計算數字嘅次方
- `squareRoot(number)`：計算平方根（會檢查負數）
- `modulus(a, b)`：計算除法餘數
- `absolute(number)`：計算絕對值

## 依賴項

呢個項目需要以下主要依賴：

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

## 編譯項目

用 Maven 編譯項目：
```bash
./mvnw clean install -DskipTests
```

## 運行服務器

### 使用 Java

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### 使用 MCP Inspector

MCP Inspector 係一個方便用嚟同 MCP 服務互動嘅工具。想用佢配合呢個計算機服務：

1. **喺新嘅終端視窗安裝同執行 MCP Inspector**：
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **打開網頁介面**，點擊應用程式顯示嘅 URL（通常係 http://localhost:6274）

3. **設定連接**：
   - 將傳輸類型設為 "SSE"
   - URL 設定為你嘅服務器 SSE 端點：`http://localhost:8080/sse`
   - 點擊「Connect」

4. **使用工具**：
   - 點擊「List Tools」睇可用嘅計算機操作
   - 選擇一個工具，點擊「Run Tool」執行操作

![MCP Inspector Screenshot](../../../../../../translated_images/tool.40e180a7b0d0fe2067cf96435532b01f63f7f8619d6b0132355a04b426b669ac.hk.png)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋致力確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件嘅母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我哋對因使用此翻譯而引致嘅任何誤解或誤釋概不負責。