<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:41:03+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "pt"
}
-->
# Demonstração de OAuth2 do MCP

Este projeto é uma **aplicação Spring Boot mínima** que atua como:

* um **Servidor de Autorização Spring** (emitindo tokens de acesso JWT via o fluxo `client_credentials`), e  
* um **Servidor de Recursos** (protegendo seu próprio endpoint `/hello`).

Ele reflete a configuração mostrada no [post do blog Spring (2 Abr 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

---

## Início rápido (local)

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

## Testando a Configuração OAuth2

Você pode testar a configuração de segurança OAuth2 com os seguintes passos:

### 1. Verifique se o servidor está em execução e protegido

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. Obtenha um token de acesso usando credenciais de cliente

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

Nota: O cabeçalho de Autenticação Básica (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. Acesse o endpoint protegido usando o token

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

Uma resposta bem-sucedida com "Olá do Demonstração de OAuth2 do MCP!" confirma que a configuração OAuth2 está funcionando corretamente.

---

## Construção de contêiner

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## Implantar em **Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

O FQDN de entrada torna-se seu **emissor** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## Integrar ao **Azure API Management**

Adicione esta política de entrada à sua API:

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

APIM buscará o JWKS e validará cada solicitação.

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritativa. Para informações críticas, recomenda-se a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações errôneas decorrentes do uso desta tradução.