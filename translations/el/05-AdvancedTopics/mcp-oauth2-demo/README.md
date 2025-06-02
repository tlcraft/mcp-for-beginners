<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9dc0d1fc8ddcd9426558f0d200894951",
  "translation_date": "2025-06-02T12:27:30+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "el"
}
-->
# MCP OAuth2 Demo

Αυτό το έργο είναι μια **ελάχιστη εφαρμογή Spring Boot** που λειτουργεί ως:

* **Διακομιστής Εξουσιοδότησης Spring** (εκδίδοντας JWT access tokens μέσω της ροής `client_credentials`), και  
* **Διακομιστής Πόρων** (προστατεύοντας το δικό του endpoint `/hello`).

Αντιγράφει τη ρύθμιση που παρουσιάζεται στο [Spring blog post (2 Apr 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

---

## Γρήγορη εκκίνηση (τοπικά)

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

## Δοκιμή της διαμόρφωσης OAuth2

Μπορείτε να δοκιμάσετε τη ρύθμιση ασφαλείας OAuth2 με τα παρακάτω βήματα:

### 1. Επιβεβαιώστε ότι ο διακομιστής τρέχει και είναι ασφαλής

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. Πάρτε ένα access token χρησιμοποιώντας τα client credentials

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

Σημείωση: Η κεφαλίδα Basic Authentication (`bWNwLWNsaWVudDpzZWNyZXQ=`) is the Base64 encoding of `mcp-client:secret`.

### 3. Πρόσβαση στο προστατευμένο endpoint χρησιμοποιώντας το token

```bash
# Using the saved token
curl -H "Authorization: Bearer $(cat token.txt)" http://localhost:8081/hello

# Or directly with the token value
curl -H "Authorization: Bearer eyJra...token_value...xyz" http://localhost:8081/hello
```

Μια επιτυχημένη απάντηση με "Hello from MCP OAuth2 Demo!" επιβεβαιώνει ότι η διαμόρφωση OAuth2 λειτουργεί σωστά.

---

## Δημιουργία container

```bash
docker build -t mcp-oauth2-demo .
docker run -p 8081:8081 mcp-oauth2-demo
```

---

## Ανάπτυξη σε **Azure Container Apps**

```bash
az containerapp up -n mcp-oauth2 \
  -g demo-rg -l westeurope \
  --image <your-registry>/mcp-oauth2-demo:latest \
  --ingress external --target-port 8081
```

Το ingress FQDN γίνεται ο **issuer** σας (`https://<fqdn>`).  
Azure provides a trusted TLS certificate automatically for `*.azurecontainerapps.io`.

---

## Ενσωμάτωση με **Azure API Management**

Προσθέστε αυτήν την inbound πολιτική στο API σας:

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

Το APIM θα ανακτήσει το JWKS και θα επικυρώνει κάθε αίτημα.

---

## Τι ακολουθεί

- [5.2 Web Search MCP Sample](../web-search-mcp/README.md)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε ακρίβεια, παρακαλούμε να λάβετε υπόψη ότι οι αυτοματοποιημένες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.