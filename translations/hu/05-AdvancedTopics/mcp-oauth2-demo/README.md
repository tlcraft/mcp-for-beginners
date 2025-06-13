<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a7083e660ca0d85fd6a947514c61993",
  "translation_date": "2025-06-13T00:51:24+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "hu"
}
-->
# MCP OAuth2 Demo

Ez a projekt egy **minimális Spring Boot alkalmazás**, amely egyszerre működik:

* **Spring Authorization Server-ként** (JWT hozzáférési tokeneket bocsát ki a `client_credentials` folyamat segítségével), és  
* **Resource Server-ként** (védi a saját `/hello` végpontját).

Ez a beállítás megfelel a [Spring blogbejegyzésben (2025. április 2.)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) bemutatottnak.

---

## Gyors kezdés (helyi)

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

## Az OAuth2 konfiguráció tesztelése

Az OAuth2 biztonsági beállításokat a következő lépésekkel tesztelheted:

### 1. Ellenőrizd, hogy a szerver fut és biztonságos

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. Szerezz hozzáférési tokent kliens-hitelesítéssel

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

Megjegyzés: A Basic Authentication fejléc (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. Használd a tokent a védett végpont eléréséhez

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

Ha a válaszban megjelenik a "Hello from MCP OAuth2 Demo!", az azt jelenti, hogy az OAuth2 konfiguráció helyesen működik.

---

## Konténer építése

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## Telepítés **Azure Container Apps** szolgáltatásba

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

Az ingress FQDN lesz az **issuer** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## Integráció az **Azure API Management**-be

Add hozzá ezt a bejövő szabályt az API-dhoz:

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

Az APIM lekéri a JWKS-t és minden kérést érvényesít.

---

## Mi a következő lépés

- [5.4 Root contexts](../mcp-root-contexts/README.md)

**Nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár igyekszünk pontos fordítást biztosítani, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy téves értelmezésekért.