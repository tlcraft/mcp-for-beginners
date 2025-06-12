<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a7083e660ca0d85fd6a947514c61993",
  "translation_date": "2025-06-12T21:32:44+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "fr"
}
-->
# MCP OAuth2 Demo

Ce projet est une **application Spring Boot minimale** qui fait à la fois office de :

* **Serveur d’autorisation Spring** (émettant des jetons d’accès JWT via le flux `client_credentials`), et  
* **Serveur de ressources** (protégeant son propre endpoint `/hello`).

Il reflète la configuration présentée dans le [article de blog Spring (2 avril 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

---

## Démarrage rapide (local)

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

## Tester la configuration OAuth2

Vous pouvez tester la configuration de sécurité OAuth2 avec les étapes suivantes :

### 1. Vérifier que le serveur est en fonctionnement et sécurisé

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. Obtenir un jeton d’accès avec les identifiants client

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

Note : L’en-tête d’authentification Basic (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. Accéder au endpoint protégé avec le jeton

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

Une réponse réussie avec « Hello from MCP OAuth2 Demo! » confirme que la configuration OAuth2 fonctionne correctement.

---

## Construction du conteneur

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## Déployer sur **Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

Le FQDN d’ingress devient votre **issuer** (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## Intégration avec **Azure API Management**

Ajoutez cette politique entrante à votre API :

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

APIM récupérera le JWKS et validera chaque requête.

---

## Et ensuite

- [5.4 Root contexts](../mcp-root-contexts/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforçons d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, il est recommandé de recourir à une traduction professionnelle réalisée par un humain. Nous déclinons toute responsabilité en cas de malentendus ou d’interprétations erronées résultant de l’utilisation de cette traduction.