<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:39:46+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "hk"
}
-->
# MCP OAuth2 演示

這個項目是一個 **簡單的 Spring Boot 應用程序**，同時擔任：

* **Spring 授權服務器**（通過 `client_credentials` 流程發行 JWT 訪問令牌），以及  
* **資源服務器**（保護自己的 `/hello` 端點）。

它反映了 [Spring 博客文章（2025 年 4 月 2 日）](https://spring.io/blog/2025/04/02/mcp-server-oauth2) 中展示的設置。

---

## 快速開始（本地）

```bash
# build & run
./mvnw spring-boot:run

# obtain a token
curl -u mcp-client:secret -d grant_type=client_credentials \
     http://localhost:8081/oauth2/token | jq -r .access_token > token.txt

# call the protected endpoint
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello
```

---

## 測試 OAuth2 配置

您可以通過以下步驟測試 OAuth2 安全配置：

### 1. 確認服務器正在運行並已加密

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. 使用客戶端憑證獲取訪問令牌

```bash
# Get and extract the full token response
curl -v -X POST http://localhost:8081/oauth2/token \
  -H "Content-Type: application/x-www-form-urlencoded" \
  -H "Authorization: Basic bWNwLWNsaWVudDpzZWNyZXQ=" \
  -d "grant_type=client_credentials&scope=mcp.access"

# Or to extract just the token (requires jq)
curl -s -X POST http://localhost:8081/oauth2/token \
  -H "Content-Type: application/x-www-form-urlencoded" \
  -H "Authorization: Basic bWNwLWNsaWVudDpzZWNyZXQ=" \
  -d "grant_type=client_credentials&scope=mcp.access" | jq -r .access_token > token.txt
```

注意：基本身份驗證標頭 (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`。

### 3. 使用令牌訪問受保護的端點

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

成功回應 "Hello from MCP OAuth2 Demo!" 確認 OAuth2 配置工作正常。

---

## 容器構建

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## 部署到 **Azure 容器應用**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

入口 FQDN 成為您的 **發行者** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`。

---

## 集成到 **Azure API 管理**

在您的 API 添加此入站策略：

```xml
<inbound>
  <validate-jwt header-name="Authorization">
    <openid-config url="https://<fqdn>/.well-known/openid-configuration"/>
    <audiences>
      <audience>mcp-client</audience>
    </audiences>
  </validate-jwt>
  <base/>
</inbound>
```

APIM 將獲取 JWKS 並驗證每個請求。

**免責聲明**：  
本文檔使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始語言的文件應被視為權威來源。對於關鍵信息，建議使用專業人工翻譯。我們對於使用此翻譯而引起的任何誤解或誤釋不承擔責任。