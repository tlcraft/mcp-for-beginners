<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:39:25+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "mo"
}
-->
# MCP OAuth2 Demo

Este proyecto es una **aplicación mínima de Spring Boot** que actúa como:

* un **Servidor de Autorización de Spring** (emitiendo tokens de acceso JWT a través del flujo `client_credentials`), y
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

## Probando la Configuración de OAuth2

Puedes probar la configuración de seguridad de OAuth2 con los siguientes pasos:

### 1. Verifica que el servidor esté en funcionamiento y seguro

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

Una respuesta exitosa con "¡Hola desde MCP OAuth2 Demo!" confirma que la configuración de OAuth2 está funcionando correctamente.

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

El FQDN de ingreso se convierte en tu **emisor** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## Conectar con **Azure API Management**

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

APIM buscará el JWKS y validará cada solicitud.

I'm sorry, but I'm not familiar with a language named "mo." Could you please provide more context or specify the language you are referring to?