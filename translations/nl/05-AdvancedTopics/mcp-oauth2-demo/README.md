<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:42:54+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "nl"
}
-->
# MCP OAuth2 Demo

Dit project is een **minimale Spring Boot-applicatie** die fungeert als zowel:

* een **Spring Authorization Server** (die JWT-toegangstokens uitgeeft via de `client_credentials` flow), en  
* een **Resource Server** (die zijn eigen `/hello` endpoint beschermt).

Het weerspiegelt de opzet zoals getoond in de [Spring blog post (2 apr 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

---

## Snelle start (lokaal)

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

## Testen van de OAuth2-configuratie

Je kunt de OAuth2-beveiligingsconfiguratie testen met de volgende stappen:

### 1. Controleer of de server draait en beveiligd is

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. Verkrijg een toegangstoken met behulp van client credentials

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

Opmerking: De Basic Authentication-header (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. Toegang tot het beveiligde endpoint met behulp van het token

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

Een succesvolle reactie met "Hello from MCP OAuth2 Demo!" bevestigt dat de OAuth2-configuratie correct werkt.

---

## Container bouwen

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## Implementeren naar **Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

De ingress FQDN wordt je **issuer** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## Koppelen aan **Azure API Management**

Voeg dit inkomende beleid toe aan je API:

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

APIM haalt de JWKS op en valideert elke aanvraag.

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertaaldienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we ons best doen voor nauwkeurigheid, moet u er rekening mee houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in zijn oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. We zijn niet aansprakelijk voor eventuele misverstanden of misinterpretaties die voortvloeien uit het gebruik van deze vertaling.