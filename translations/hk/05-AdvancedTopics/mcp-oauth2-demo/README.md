<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2d6413f234258f6bbc8189c463e510ee",
  "translation_date": "2025-06-02T18:31:27+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "hk"
}
-->
# MCP OAuth2 Demo

呢個項目係一個**簡約嘅 Spring Boot 應用程式**，同時擔任：

* **Spring 授權伺服器**（透過 `client_credentials` 流程發行 JWT 存取權杖），同時  
* **資源伺服器**（保護自己嘅 `/hello` 端點）。

佢模仿咗喺 [Spring blog post (2 Apr 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) 入面示範嘅設定。

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

你可以用以下步驟測試 OAuth2 嘅安全配置：

### 1. 確認伺服器運行同埋有保護

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. 用 client credentials 取得存取權杖

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

Note: Basic Authentication header (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`。

### 3. 用存取權杖存取受保護嘅端點

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

如果收到 "Hello from MCP OAuth2 Demo!" 嘅成功回應，就代表 OAuth2 配置運作正常。

---

## 容器構建

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## 部署到 **Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

Ingress FQDN 就係你嘅 **issuer** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`。

---

## 連接到 **Azure API Management**

將呢個 inbound policy 加入你嘅 API：

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

APIM 會自動攞 JWKS 同驗證每個請求。

---

## 下一步

- [Root contexts](../mcp-root-contexts/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯而成。雖然我哋致力確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件嘅母語版本應視為權威來源。對於重要資料，建議採用專業人工翻譯。我哋對因使用此翻譯而引起嘅任何誤解或錯誤詮釋概不負責。