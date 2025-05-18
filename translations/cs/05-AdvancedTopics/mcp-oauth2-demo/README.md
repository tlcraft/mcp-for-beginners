<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:44:20+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "cs"
}
-->
# MCP OAuth2 Demo

Tento projekt je **minimální aplikace Spring Boot**, která funguje jako:

* **Spring Authorization Server** (vydávající JWT přístupové tokeny pomocí `client_credentials` flow), a  
* **Resource Server** (chránící svůj vlastní `/hello` endpoint).

Odráží nastavení ukázané v [příspěvku na blogu Spring (2. dubna 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

---

## Rychlý start (lokálně)

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

## Testování konfigurace OAuth2

Konfiguraci zabezpečení OAuth2 můžete otestovat pomocí následujících kroků:

### 1. Ověřte, že server běží a je zabezpečený

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. Získejte přístupový token pomocí klientských přihlašovacích údajů

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

Poznámka: Záhlaví Basic Authentication (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. Přistupte k chráněnému endpointu pomocí tokenu

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

Úspěšná odpověď s textem "Hello from MCP OAuth2 Demo!" potvrzuje, že konfigurace OAuth2 funguje správně.

---

## Sestavení kontejneru

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## Nasazení do **Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

Ingress FQDN se stává vaším **vydavatelem** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## Integrace s **Azure API Management**

Přidejte tuto politiku pro vstup do vašeho API:

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

APIM načte JWKS a ověří každý požadavek.

**Prohlášení**:  
Tento dokument byl přeložen pomocí AI překladové služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, mějte na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro důležité informace je doporučen profesionální lidský překlad. Nejsme zodpovědní za žádná nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.