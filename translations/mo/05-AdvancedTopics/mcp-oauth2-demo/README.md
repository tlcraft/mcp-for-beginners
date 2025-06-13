<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a7083e660ca0d85fd6a947514c61993",
  "translation_date": "2025-06-12T23:12:54+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "mo"
}
-->
# MCP OAuth2 Demo

Este proyecto es una **aplicación mínima de Spring Boot** que funciona como:

* un **Servidor de Autorización Spring** (emitiendo tokens de acceso JWT mediante el flujo `client_credentials`), y  
* un **Servidor de Recursos** (protegiendo su propio endpoint `/hello`).

Refleja la configuración mostrada en el [post del blog de Spring (2 Abr 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

---

## Inicio rápido (local)

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

## Probando la configuración de OAuth2

Puedes probar la configuración de seguridad OAuth2 con los siguientes pasos:

### 1. Verifica que el servidor esté en ejecución y seguro

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. Obtén un token de acceso usando credenciales de cliente

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

Nota: El encabezado de Autenticación Básica (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. Accede al endpoint protegido usando el token

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

Una respuesta exitosa con "Hello from MCP OAuth2 Demo!" confirma que la configuración OAuth2 está funcionando correctamente.

---

## Construcción del contenedor

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## Desplegar en **Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

El FQDN de ingreso se convierte en tu **issuer** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## Integrar con **Azure API Management**

Agrega esta política de entrada a tu API:

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

APIM obtendrá el JWKS y validará cada solicitud.

---

## Qué sigue

- [5.4 Root contexts](../mcp-root-contexts/README.md)

**Disclaimer**:  
Thiz dokyument haz bin translaited yusing AI translaition serviz [Co-op Translator](https://github.com/Azure/co-op-translator). Whil wi striv for akyurasi, pleez bi aware that otomaytid translaitions may contain erors or inakyeraseez. Thuh orijinal dokyument in its naytiv langwaj shud bi konsidird thuh authorityv sors. For kritikall informayshun, profeshunal hyuman translaition iz rekomended. Wi ar not layabul for enny misundurstandings or misinterpretayshuns arising from thuh yus of this translaition.