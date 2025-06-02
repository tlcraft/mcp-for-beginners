<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2d6413f234258f6bbc8189c463e510ee",
  "translation_date": "2025-06-02T19:27:20+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "hu"
}
-->
# MCP OAuth2 Demo

Ez a projekt egy **minimális Spring Boot alkalmazás**, amely egyszerre működik:

* mint **Spring Authorization Server** (JWT hozzáférési tokeneket bocsát ki a `client_credentials` folyamat segítségével), és  
* mint **Resource Server** (védi a saját `/hello` végpontját).

Ez a beállítás megegyezik a [Spring blogbejegyzésben (2025. április 2.)](https://spring.io/blog/2025/04/02/mcp-server-oauth2) bemutatottal.

---

## Gyors indítás (helyi)

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

### 1. Ellenőrizd, hogy a szerver fut és védett

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. Szerezz hozzáférési tokent kliens hitelesítő adatokkal

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

### 3. Érd el a védett végpontot a tokennel

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

Ha sikeres választ kapsz "Hello from MCP OAuth2 Demo!" üzenettel, az azt jelenti, hogy az OAuth2 konfiguráció helyesen működik.

---

## Konténer építése

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## Telepítés **Azure Container Apps**-be

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

Az ingress FQDN lesz az **issuer** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## Integráció **Azure API Management**-be

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

Az APIM lekéri a JWKS-t és érvényesíti az összes kérést.

---

## Mi következik ezután

- [Root contexts](../mcp-root-contexts/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy téves értelmezésekért.