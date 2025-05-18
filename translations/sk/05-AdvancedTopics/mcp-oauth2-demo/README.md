<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:44:31+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "sk"
}
-->
# MCP OAuth2 Demo

Tento projekt je **minimálna aplikácia Spring Boot**, ktorá slúži ako:

* **Spring Authorization Server** (vydáva JWT prístupové tokeny prostredníctvom `client_credentials` flow), a  
* **Resource Server** (chráni vlastný `/hello` endpoint).

Odráža nastavenie zobrazené v [blogovom príspevku Spring (2. apríl 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

---

## Rýchly štart (lokálne)

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

## Testovanie OAuth2 konfigurácie

Môžete otestovať konfiguráciu zabezpečenia OAuth2 pomocou nasledujúcich krokov:

### 1. Overte, že server beží a je zabezpečený

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. Získajte prístupový token pomocou klientských poverení

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

Poznámka: Záhlavie základnej autentifikácie (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. Prístup k chránenému endpointu pomocou tokenu

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

Úspešná odpoveď s textom "Hello from MCP OAuth2 Demo!" potvrdzuje, že konfigurácia OAuth2 funguje správne.

---

## Vytvorenie kontajnera

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## Nasadenie do **Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

FQDN pre vstup sa stáva vaším **vydavateľom** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## Napojenie do **Azure API Management**

Pridajte túto politiku na vstup do svojej API:

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

APIM načíta JWKS a overí každú požiadavku.

**Upozornenie**:  
Tento dokument bol preložený pomocou služby pre automatizovaný preklad [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, berte na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.