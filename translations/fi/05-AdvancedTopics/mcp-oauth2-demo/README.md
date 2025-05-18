<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:42:43+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "fi"
}
-->
# MCP OAuth2 Demo

Tämä projekti on **minimaalinen Spring Boot -sovellus**, joka toimii sekä:

* **Spring Authorization Serverinä** (joka myöntää JWT-käyttöoikeustokeneita `client_credentials`-prosessin kautta), ja  
* **Resource Serverinä** (suojaten oman `/hello`-päätepisteensä).

Se jäljittelee asetusta, joka on esitetty [Spring-blogipostauksessa (2. huhtikuuta 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

---

## Nopea aloitus (paikallinen)

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

## OAuth2-konfiguraation testaaminen

Voit testata OAuth2-turvakonfiguraation seuraavilla vaiheilla:

### 1. Varmista, että palvelin toimii ja on suojattu

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. Hanki käyttöoikeustoken asiakastunnuksilla

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

Huomio: Basic Authentication -otsikko (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. Pääsy suojattuun päätepisteeseen tokenilla

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

Onnistunut vastaus "Hello from MCP OAuth2 Demo!" vahvistaa, että OAuth2-konfiguraatio toimii oikein.

---

## Säiliön rakentaminen

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## Julkaisu **Azure Container Apps** -palveluun

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

Ingress FQDN:stä tulee **myöntäjäsi** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## Liittäminen **Azure API Management** -palveluun

Lisää tämä saapuva politiikka API:si:

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

APIM hakee JWKS:n ja validoi jokaisen pyynnön.

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää auktoritatiivisena lähteenä. Kriittisen tiedon osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.