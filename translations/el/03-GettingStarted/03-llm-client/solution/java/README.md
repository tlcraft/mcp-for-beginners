<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:27:26+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "el"
}
-->
# Calculator LLM Client

Μια εφαρμογή Java που δείχνει πώς να χρησιμοποιήσετε το LangChain4j για να συνδεθείτε με μια υπηρεσία MCP (Model Context Protocol) calculator με ενσωμάτωση GitHub Models.

## Προαπαιτούμενα

- Java 21 ή νεότερη έκδοση
- Maven 3.6+ (ή χρησιμοποιήστε το ενσωματωμένο Maven wrapper)
- Ένας λογαριασμός GitHub με πρόσβαση στα GitHub Models
- Μια υπηρεσία MCP calculator σε λειτουργία στο `http://localhost:8080`

## Λήψη του GitHub Token

Αυτή η εφαρμογή χρησιμοποιεί τα GitHub Models που απαιτούν ένα προσωπικό access token GitHub. Ακολουθήστε τα βήματα για να αποκτήσετε το token σας:

### 1. Πρόσβαση στα GitHub Models
1. Μεταβείτε στο [GitHub Models](https://github.com/marketplace/models)
2. Συνδεθείτε με τον λογαριασμό σας στο GitHub
3. Ζητήστε πρόσβαση στα GitHub Models αν δεν το έχετε ήδη κάνει

### 2. Δημιουργία Προσωπικού Access Token
1. Μεταβείτε στα [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. Πατήστε "Generate new token" → "Generate new token (classic)"
3. Δώστε ένα περιγραφικό όνομα στο token σας (π.χ. "MCP Calculator Client")
4. Ορίστε την ημερομηνία λήξης αν χρειάζεται
5. Επιλέξτε τα παρακάτω scopes:
   - `repo` (αν χρειάζεστε πρόσβαση σε ιδιωτικά repositories)
   - `user:email`
6. Πατήστε "Generate token"
7. **Σημαντικό**: Αντιγράψτε το token αμέσως - δεν θα μπορείτε να το δείτε ξανά!

### 3. Ορισμός Μεταβλητής Περιβάλλοντος

#### Σε Windows (Command Prompt):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Σε Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### Σε macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Ρύθμιση και Εγκατάσταση

1. **Κλωνοποιήστε ή μεταβείτε στον φάκελο του έργου**

2. **Εγκαταστήστε τις εξαρτήσεις**:
   ```cmd
   mvnw clean install
   ```
   Ή αν έχετε εγκατεστημένο το Maven παγκοσμίως:
   ```cmd
   mvn clean install
   ```

3. **Ορίστε τη μεταβλητή περιβάλλοντος** (βλέπε "Λήψη του GitHub Token" παραπάνω)

4. **Εκκινήστε την υπηρεσία MCP Calculator**:
   Βεβαιωθείτε ότι η υπηρεσία MCP calculator από το κεφάλαιο 1 τρέχει στο `http://localhost:8080/sse`. Πρέπει να είναι ενεργή πριν ξεκινήσετε τον client.

## Εκτέλεση της Εφαρμογής

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Τι Κάνει η Εφαρμογή

Η εφαρμογή δείχνει τρεις βασικές αλληλεπιδράσεις με την υπηρεσία calculator:

1. **Πρόσθεση**: Υπολογίζει το άθροισμα του 24.5 και του 17.3
2. **Τετραγωνική Ρίζα**: Υπολογίζει την τετραγωνική ρίζα του 144
3. **Βοήθεια**: Εμφανίζει τις διαθέσιμες λειτουργίες του calculator

## Αναμενόμενη Έξοδος

Όταν εκτελεστεί επιτυχώς, θα δείτε έξοδο παρόμοια με:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Επίλυση Προβλημάτων

### Συνηθισμένα Προβλήματα

1. **"GITHUB_TOKEN environment variable not set"**
   - Βεβαιωθείτε ότι έχετε ορίσει τη μεταβλητή `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean`

### Αποσφαλμάτωση

Για να ενεργοποιήσετε το debug logging, προσθέστε το ακόλουθο JVM όρισμα κατά την εκτέλεση:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Ρυθμίσεις

Η εφαρμογή είναι ρυθμισμένη να:
- Χρησιμοποιεί τα GitHub Models με το `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Έχει timeout 60 δευτερολέπτων για τα αιτήματα
- Ενεργοποιεί logging αιτημάτων/απαντήσεων για αποσφαλμάτωση

## Εξαρτήσεις

Βασικές εξαρτήσεις που χρησιμοποιούνται σε αυτό το έργο:
- **LangChain4j**: Για ενσωμάτωση AI και διαχείριση εργαλείων
- **LangChain4j MCP**: Για υποστήριξη Model Context Protocol
- **LangChain4j GitHub Models**: Για ενσωμάτωση GitHub Models
- **Spring Boot**: Για το πλαίσιο εφαρμογής και την εξάρτηση injection

## Άδεια Χρήσης

Αυτό το έργο διατίθεται υπό την άδεια Apache License 2.0 - δείτε το αρχείο [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) για λεπτομέρειες.

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν σφάλματα ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του πρέπει να θεωρείται η επίσημη πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική μετάφραση από ανθρώπους. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.