<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:29:35+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "el"
}
-->
# Ανάπτυξη MCP Διακομιστών

Η ανάπτυξη του MCP διακομιστή σας επιτρέπει σε άλλους να έχουν πρόσβαση στα εργαλεία και τους πόρους του πέρα από το τοπικό σας περιβάλλον. Υπάρχουν διάφορες στρατηγικές ανάπτυξης που μπορείτε να εξετάσετε, ανάλογα με τις απαιτήσεις σας για κλιμάκωση, αξιοπιστία και ευκολία διαχείρισης. Παρακάτω θα βρείτε οδηγίες για την ανάπτυξη MCP διακομιστών τοπικά, σε κοντέινερ και στο cloud.

## Επισκόπηση

Αυτό το μάθημα καλύπτει πώς να αναπτύξετε την εφαρμογή MCP Server σας.

## Στόχοι Μάθησης

Στο τέλος αυτού του μαθήματος, θα μπορείτε να:

- Αξιολογείτε διαφορετικές προσεγγίσεις ανάπτυξης.
- Αναπτύσσετε την εφαρμογή σας.

## Τοπική ανάπτυξη και ανάπτυξη

Αν ο διακομιστής σας προορίζεται να χρησιμοποιείται από χρήστες που τον τρέχουν τοπικά, μπορείτε να ακολουθήσετε τα εξής βήματα:

1. **Κατεβάστε τον διακομιστή**. Αν δεν έχετε γράψει εσείς τον διακομιστή, κατεβάστε τον πρώτα στη μηχανή σας.  
1. **Ξεκινήστε τη διαδικασία του διακομιστή**: Τρέξτε την εφαρμογή MCP server σας.

Για SSE (δεν απαιτείται για διακομιστές τύπου stdio)

1. **Ρυθμίστε το δίκτυο**: Βεβαιωθείτε ότι ο διακομιστής είναι προσβάσιμος στην αναμενόμενη θύρα.  
1. **Συνδέστε τους πελάτες**: Χρησιμοποιήστε τοπικά URLs σύνδεσης όπως `http://localhost:3000`.

## Ανάπτυξη στο Cloud

Οι MCP διακομιστές μπορούν να αναπτυχθούν σε διάφορες πλατφόρμες cloud:

- **Serverless Functions**: Αναπτύξτε ελαφριούς MCP διακομιστές ως serverless functions.  
- **Container Services**: Χρησιμοποιήστε υπηρεσίες όπως Azure Container Apps, AWS ECS ή Google Cloud Run.  
- **Kubernetes**: Αναπτύξτε και διαχειριστείτε MCP διακομιστές σε clusters Kubernetes για υψηλή διαθεσιμότητα.

### Παράδειγμα: Azure Container Apps

Τα Azure Container Apps υποστηρίζουν την ανάπτυξη MCP Servers. Είναι ακόμα σε εξέλιξη και προς το παρόν υποστηρίζουν SSE διακομιστές.

Ακολουθεί πώς μπορείτε να το κάνετε:

1. Κλωνοποιήστε ένα repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Τρέξτε το τοπικά για να δοκιμάσετε:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Για να το δοκιμάσετε τοπικά, δημιουργήστε ένα αρχείο *mcp.json* σε έναν φάκελο *.vscode* και προσθέστε το παρακάτω περιεχόμενο:

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  Μόλις ξεκινήσει ο SSE διακομιστής, μπορείτε να κάνετε κλικ στο εικονίδιο αναπαραγωγής στο αρχείο JSON, και τώρα θα πρέπει να δείτε τα εργαλεία στον διακομιστή να αναγνωρίζονται από το GitHub Copilot, δείτε το εικονίδιο εργαλείου.

1. Για να αναπτύξετε, τρέξτε την ακόλουθη εντολή:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Αυτά είναι, αναπτύξτε το τοπικά ή στο Azure ακολουθώντας αυτά τα βήματα.

## Πρόσθετοι Πόροι

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Άρθρο για Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Τι Ακολουθεί

- Επόμενο: [Πρακτική Εφαρμογή](/04-PracticalImplementation/README.md)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτοματοποιημένες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται η επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.