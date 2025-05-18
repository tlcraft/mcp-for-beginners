<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bcd07a55d0e5baece8d0a1a0310fdfe6",
  "translation_date": "2025-05-17T15:41:48+00:00",
  "source_file": "05-AdvancedTopics/mcp-oauth2-demo/README.md",
  "language_code": "el"
}
-->
# Επίδειξη MCP OAuth2

Αυτό το έργο είναι μια **ελάχιστη εφαρμογή Spring Boot** που λειτουργεί ως:

* **Διακομιστής Εξουσιοδότησης Spring** (εκδίδει JWT access tokens μέσω της ροής `client_credentials`), και  
* **Διακομιστής Πόρων** (προστατεύει το δικό του `/hello` endpoint).

Αντικατοπτρίζει τη ρύθμιση που παρουσιάζεται στο [Spring blog post (2 Απρ 2025)](https://spring.io/blog/2025/04/02/mcp-server-oauth2).

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

## Δοκιμή της Ρύθμισης OAuth2

Μπορείτε να δοκιμάσετε τη ρύθμιση ασφαλείας OAuth2 με τα παρακάτω βήματα:

### 1. Βεβαιωθείτε ότι ο διακομιστής λειτουργεί και είναι ασφαλής

```bash
# This should return 401 Unauthorized, confirming OAuth2 security is active
curl -v http://localhost:8081/
```

### 2. Αποκτήστε ένα access token χρησιμοποιώντας client credentials

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

Μια επιτυχής απάντηση με "Γειά από το MCP OAuth2 Demo!" επιβεβαιώνει ότι η ρύθμιση OAuth2 λειτουργεί σωστά.

---

## Δημιουργία Container

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

## Ενσωμάτωση στο **Azure API Management**

Προσθέστε αυτήν την εισερχόμενη πολιτική στο API σας:

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

Το APIM θα ανακτήσει το JWKS και θα επαληθεύσει κάθε αίτημα.

**Αποποίηση ευθύνης**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ενώ προσπαθούμε για ακρίβεια, παρακαλώ να γνωρίζετε ότι οι αυτοματοποιημένες μεταφράσεις μπορεί να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα θα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρανοήσεις ή εσφαλμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.