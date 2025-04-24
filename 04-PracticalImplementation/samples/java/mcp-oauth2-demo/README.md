# MCP OAuth2 Demo

This project is a **minimal Spring Boot application** that acts as both:

* a **Spring Authorization Server** (issuing JWT access tokens via the `client_credentials` flow), and  
* a **Resource Server** (protecting its own `/hello` endpoint).

It mirrors the setup shown in the [Spring blog post (2 Apr 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

---

## Quick start (local)

```bash
# build & run
./mvnw spring-boot:run

# obtain a token
curl -u mcp-client:secret -d grant_type=client_credentials \
     http://localhost:8080/oauth2/token | jq -r .access_token > token.txt

# call the protected endpoint
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8080/hello
```

---

## Container build

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8080:8080 mcp-oauth2-demo
```

---

## Deploy to **Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8080
```

The ingress FQDN becomes your **issuer** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## Wire into **Azure API Management**

Add this inbound policy to your API:

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

APIM will fetch the JWKS and validate every request.

---

Happy hacking!  
