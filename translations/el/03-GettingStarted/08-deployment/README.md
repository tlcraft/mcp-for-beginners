<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:52:37+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "el"
}
-->
# Ανάπτυξη MCP Servers

Η ανάπτυξη του MCP server σας επιτρέπει σε άλλους να έχουν πρόσβαση στα εργαλεία και τις πηγές του πέρα από το τοπικό σας περιβάλλον. Υπάρχουν διάφορες στρατηγικές ανάπτυξης που πρέπει να εξετάσετε, ανάλογα με τις απαιτήσεις σας για επεκτασιμότητα, αξιοπιστία και ευκολία διαχείρισης. Παρακάτω θα βρείτε οδηγίες για την ανάπτυξη MCP servers τοπικά, σε containers και στο cloud.

## Επισκόπηση

Αυτό το μάθημα καλύπτει πώς να αναπτύξετε την εφαρμογή MCP Server σας.

## Στόχοι μάθησης

Μέχρι το τέλος αυτού του μαθήματος, θα μπορείτε να:

- Αξιολογήσετε διαφορετικές προσεγγίσεις ανάπτυξης.
- Αναπτύξετε την εφαρμογή σας.

## Τοπική ανάπτυξη και ανάπτυξη

Αν ο server σας προορίζεται να εκτελείται στο μηχάνημα των χρηστών, μπορείτε να ακολουθήσετε τα παρακάτω βήματα:

1. **Κατεβάστε τον server**. Αν δεν έχετε γράψει τον server, τότε κατεβάστε τον πρώτα στο μηχάνημά σας. 
1. **Ξεκινήστε τη διαδικασία του server**: Εκτελέστε την εφαρμογή MCP server σας 

Για SSE (δεν χρειάζεται για server τύπου stdio)

1. **Διαμορφώστε τη δικτύωση**: Βεβαιωθείτε ότι ο server είναι προσβάσιμος στη αναμενόμενη θύρα 
1. **Συνδέστε πελάτες**: Χρησιμοποιήστε τοπικά URLs σύνδεσης όπως `http://localhost:3000`

## Ανάπτυξη στο Cloud

Οι MCP servers μπορούν να αναπτυχθούν σε διάφορες πλατφόρμες cloud:

- **Serverless Functions**: Αναπτύξτε ελαφρούς MCP servers ως serverless functions
- **Υπηρεσίες Containers**: Χρησιμοποιήστε υπηρεσίες όπως Azure Container Apps, AWS ECS, ή Google Cloud Run
- **Kubernetes**: Αναπτύξτε και διαχειριστείτε MCP servers σε clusters Kubernetes για υψηλή διαθεσιμότητα

### Παράδειγμα: Azure Container Apps

Τα Azure Container Apps υποστηρίζουν την ανάπτυξη MCP Servers. Είναι ακόμα σε εξέλιξη και υποστηρίζει αυτή τη στιγμή SSE servers.

Ορίστε πώς μπορείτε να το κάνετε:

1. Κλωνοποιήστε ένα repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Εκτελέστε το τοπικά για να δοκιμάσετε τα πράγματα:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Για να το δοκιμάσετε τοπικά, δημιουργήστε ένα αρχείο *mcp.json* σε έναν κατάλογο *.vscode* και προσθέστε το ακόλουθο περιεχόμενο:

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

  Μόλις ξεκινήσει ο SSE server, μπορείτε να κάνετε κλικ στο εικονίδιο αναπαραγωγής στο αρχείο JSON, τώρα θα πρέπει να δείτε τα εργαλεία στον server να αναγνωρίζονται από το GitHub Copilot, δείτε το εικονίδιο Εργαλείου. 

1. Για να το αναπτύξετε, εκτελέστε την ακόλουθη εντολή:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Ορίστε, αναπτύξτε το τοπικά, αναπτύξτε το στο Azure μέσω αυτών των βημάτων.

## Πρόσθετοι πόροι

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Άρθρο για Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Τι ακολουθεί

- Επόμενο: [Πρακτική Εφαρμογή](/04-PracticalImplementation/README.md)

**Αποποίηση ευθύνης**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το αρχικό έγγραφο στη μητρική του γλώσσα θα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για οποιαδήποτε παρεξηγήσεις ή παρερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.