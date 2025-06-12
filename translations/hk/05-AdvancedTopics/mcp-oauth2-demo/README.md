<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a7083e660ca0d85fd6a947514c61993",
  "translation_date": "2025-06-12T21:28:37+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "hk"
}
-->
# MCP OAuth2 Demo

呢個項目係一個**最簡Spring Boot應用程式**，同時擔當：

* **Spring授權伺服器**（透過`client_credentials`流程發行JWT存取令牌），同時  
* **資源伺服器**（保護佢自己嘅`/hello`端點）。

佢反映咗喺[Spring blog post (2025年4月2日)](https://spring.io/blog/2025/04/02/mcp-server-oauth2)入面示範嘅設定。

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

## 測試OAuth2設定

你可以用以下步驟測試OAuth2安全設定：

### 1. 確認伺服器運行同受保護

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. 用client credentials攞存取令牌

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

注意：Basic Authentication標頭係 (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`。

### 3. 用令牌存取受保護端點

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

收到「Hello from MCP OAuth2 Demo!」嘅成功回應就代表OAuth2設定運作正常。

---

## 容器構建

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## 部署到**Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

ingress嘅FQDN會變成你嘅**issuer** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`。

---

## 連接到**Azure API Management**

將呢個入站策略加入你嘅API：

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

APIM會攞JWKS同驗證每個請求。

---

## 下一步

- [5.4 Root contexts](../mcp-root-contexts/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能存在錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議使用專業人工翻譯。我們不對因使用此翻譯而引致的任何誤解或誤釋承擔責任。