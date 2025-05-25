<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:42:25+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "no"
}
-->
# MCP OAuth2 Demo

Prosjektet er en **minimal Spring Boot-applikasjon** som fungerer både som:

* en **Spring Authorization Server** (utsteder JWT-tilgangstokener via `client_credentials`-flyten), og  
* en **Resource Server** (beskytter sin egen `/hello`-endepunkt).

Den gjenspeiler oppsettet som vises i [Spring blogginnlegget (2. apr 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

---

## Rask start (lokalt)

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

## Testing av OAuth2-konfigurasjonen

Du kan teste OAuth2-sikkerhetskonfigurasjonen med følgende trinn:

### 1. Bekreft at serveren kjører og er sikret

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. Få et tilgangstoken ved hjelp av klientlegitimasjon

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

Merk: Basic Authentication-headeren (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. Tilgang til det beskyttede endepunktet med tokenet

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

En vellykket respons med "Hello from MCP OAuth2 Demo!" bekrefter at OAuth2-konfigurasjonen fungerer korrekt.

---

## Containerbygging

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## Distribuer til **Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

Ingress FQDN blir din **issuer** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## Koble til **Azure API Management**

Legg til denne innkommende policyen til API-et ditt:

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

APIM vil hente JWKS og validere hver forespørsel.

I'm sorry, but it looks like you want the text translated to "no," which doesn't seem to refer to a specific language. Could you please clarify the language you want the text translated into?