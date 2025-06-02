<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2d6413f234258f6bbc8189c463e510ee",
  "translation_date": "2025-06-02T19:00:01+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "pl"
}
-->
# MCP OAuth2 Demo

Ten projekt to **minimalna aplikacja Spring Boot**, która pełni jednocześnie rolę:

* **Spring Authorization Server** (wydającego tokeny dostępu JWT za pomocą flow `client_credentials`), oraz  
* **Resource Server** (chroniącego własny endpoint `/hello`).

Odwzorowuje konfigurację pokazaną w [wpisie na blogu Spring (2 kwi 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

---

## Szybki start (lokalnie)

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

## Testowanie konfiguracji OAuth2

Możesz przetestować konfigurację zabezpieczeń OAuth2 wykonując następujące kroki:

### 1. Sprawdź, czy serwer działa i jest zabezpieczony

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. Pobierz token dostępu używając client credentials

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

Uwaga: Nagłówek Basic Authentication (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. Uzyskaj dostęp do chronionego endpointu używając tokenu

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

Pomyślna odpowiedź z "Hello from MCP OAuth2 Demo!" potwierdza, że konfiguracja OAuth2 działa poprawnie.

---

## Budowanie kontenera

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## Wdrażanie do **Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

FQDN ingressu staje się Twoim **issuerem** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## Integracja z **Azure API Management**

Dodaj tę politykę inbound do swojego API:

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

APIM pobierze JWKS i zweryfikuje każde żądanie.

---

## Co dalej

- [Root contexts](../mcp-root-contexts/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do jak największej dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uważany za wiarygodne źródło. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.