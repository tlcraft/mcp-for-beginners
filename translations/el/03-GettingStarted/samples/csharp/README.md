<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:59:15+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "el"
}
-->
# Υπηρεσία Βασικού Υπολογιστή MCP

Αυτή η υπηρεσία παρέχει βασικές λειτουργίες αριθμομηχανής μέσω του Model Context Protocol (MCP). Έχει σχεδιαστεί ως απλό παράδειγμα για αρχάριους που μαθαίνουν για υλοποιήσεις MCP.

Για περισσότερες πληροφορίες, δείτε το [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Χαρακτηριστικά

Αυτή η υπηρεσία αριθμομηχανής προσφέρει τις εξής δυνατότητες:

1. **Βασικές Αριθμητικές Λειτουργίες**:
   - Πρόσθεση δύο αριθμών
   - Αφαίρεση ενός αριθμού από έναν άλλο
   - Πολλαπλασιασμός δύο αριθμών
   - Διαίρεση ενός αριθμού με έναν άλλο (με έλεγχο διαίρεσης με το μηδέν)

## Χρήση του `stdio` Τύπου

## Διαμόρφωση

1. **Διαμόρφωση MCP Servers**:
   - Ανοίξτε τον χώρο εργασίας σας στο VS Code.
   - Δημιουργήστε ένα αρχείο `.vscode/mcp.json` στον φάκελο του χώρου εργασίας σας για να διαμορφώσετε τους MCP servers. Παράδειγμα διαμόρφωσης:

     ```jsonc
     {
       "inputs": [
         {
           "type": "promptString",
           "id": "repository-root",
           "description": "The absolute path to the repository root"
         }
       ],
       "servers": {
         "calculator-mcp-dotnet": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
             "run",
             "--project",
             "${input:repository-root}/03-GettingStarted/samples/csharp/src/calculator.csproj"
           ]
         }
       }
     }
     ```

   - Θα σας ζητηθεί να εισάγετε το ριζικό αποθετήριο GitHub, το οποίο μπορείτε να βρείτε με την εντολή `git rev-parse --show-toplevel`.

## Using the Service

The service exposes the following API endpoints through the MCP protocol:

- `add(a, b)`: Add two numbers together
- `subtract(a, b)`: Subtract the second number from the first
- `multiply(a, b)`: Multiply two numbers
- `divide(a, b)`: Divide the first number by the second (with zero check)
- isPrime(n): Check if a number is prime

## Test with Github Copilot Chat in VS Code

1. Try making a request to the service using the MCP protocol. For example, you can ask:
   - "Add 5 and 3"
   - "Subtract 10 from 4"
   - "Multiply 6 and 7"
   - "Divide 8 by 2"
   - "Does 37854 prime?"
   - "What are the 3 prime numbers before after 4242?"
2. To make sure it's using the tools add #MyCalculator to the prompt. For example:
   - "Add 5 and 3 #MyCalculator"
   - "Subtract 10 from 4 #MyCalculator


## Containerized Version

The previous soultion is great when you have the .NET SDK installed, and all the dependencies are in place. However, if you would like to share the solution or run it in a different environment, you can use the containerized version.

1. Start Docker and make sure it's running.
1. From a terminal, navigate in the folder `03-GettingStarted\samples\csharp\src` 
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` με το όνομα χρήστη σας στο Docker Hub):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ```  
1. Αφού δημιουργηθεί το image, ας το ανεβάσουμε στο Docker Hub. Εκτελέστε την παρακάτω εντολή:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Χρήση της Dockerized Έκδοσης

1. Στο αρχείο `.vscode/mcp.json`, αντικαταστήστε τη διαμόρφωση του server με την εξής:
   ```json
    "mcp-calc": {
      "command": "docker",
      "args": [
        "run",
        "--rm",
        "-i",
        "<YOUR-DOCKER-USERNAME>/mcp-calc"
      ],
      "envFile": "",
      "env": {}
    }
   ```
   Κοιτώντας τη διαμόρφωση, μπορείτε να δείτε ότι η εντολή είναι `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, και όπως πριν, μπορείτε να ζητήσετε από την υπηρεσία αριθμομηχανής να κάνει κάποιους υπολογισμούς για εσάς.

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρότι επιδιώκουμε ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν σφάλματα ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η επίσημη πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.