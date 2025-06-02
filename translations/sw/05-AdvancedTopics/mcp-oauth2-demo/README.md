<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9dc0d1fc8ddcd9426558f0d200894951",
  "translation_date": "2025-06-02T12:46:06+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "sw"
}
-->
# MCP OAuth2 Demo

Mradi huu ni **programu ndogo ya Spring Boot** inayofanya kazi kama:

* **Spring Authorization Server** (inayotolewa tokeni za JWT kupitia mtiririko wa `client_credentials`), na  
* **Resource Server** (inayolinda endpoint yake ya `/hello`).

Inalinganisha usanidi unaoonyeshwa katika [Spring blog post (2 Apr 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

---

## Anza haraka (ndani ya kompyuta)

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

## Kupima Usanidi wa OAuth2

Unaweza kupima usanidi wa usalama wa OAuth2 kwa hatua zifuatazo:

### 1. Thibitisha server iko hai na imehifadhiwa

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. Pata tokeni ya kufikia kwa kutumia sifa za mteja

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

Note: Kichwa cha Basic Authentication (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. Fikia endpoint iliyolindwa kwa kutumia tokeni

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

Jibu la mafanikio lenye "Hello from MCP OAuth2 Demo!" linaonyesha kuwa usanidi wa OAuth2 unafanya kazi ipasavyo.

---

## Kujenga container

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## Weka kwenye **Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

Anwani ya ingress FQDN inakuwa **issuer** yako (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## Unganisha na **Azure API Management**

Ongeza sera hii ya inbound kwa API yako:

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

APIM itachukua JWKS na kuthibitisha kila ombi.

---

## Nini kinachofuata

- [5.2 Web Search MCP Sample](../web-search-mcp/README.md)

**Kiarushi**:  
Hati hii imefasiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhima kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.