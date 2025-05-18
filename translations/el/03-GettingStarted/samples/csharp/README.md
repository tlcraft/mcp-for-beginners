<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T13:00:28+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "el"
}
-->
# Βασική Υπηρεσία Υπολογιστή MCP

Αυτή η υπηρεσία παρέχει βασικές λειτουργίες υπολογιστή μέσω του Πρωτοκόλλου Πλαισίου Μοντέλου (MCP). Έχει σχεδιαστεί ως ένα απλό παράδειγμα για αρχάριους που μαθαίνουν για τις υλοποιήσεις MCP.

Για περισσότερες πληροφορίες, δείτε το [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Χαρακτηριστικά

Αυτή η υπηρεσία υπολογιστή προσφέρει τις ακόλουθες δυνατότητες:

1. **Βασικές Αριθμητικές Λειτουργίες**:
   - Πρόσθεση δύο αριθμών
   - Αφαίρεση ενός αριθμού από έναν άλλο
   - Πολλαπλασιασμός δύο αριθμών
   - Διαίρεση ενός αριθμού με έναν άλλο (με έλεγχο διαίρεσης με το μηδέν)

## Χρήση `stdio` Τύπου

## Ρύθμιση

1. **Ρυθμίστε τους Διακομιστές MCP**:
   - Ανοίξτε το χώρο εργασίας σας στο VS Code.
   - Δημιουργήστε ένα αρχείο `.vscode/mcp.json` στο φάκελο του χώρου εργασίας σας για να ρυθμίσετε τους διακομιστές MCP. Παράδειγμα ρύθμισης:
     ```json
     {
       "servers": {
         "MyCalculator": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
                "run",
                "--project",
                "D:\\source\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj"
            ],
           "env": {}
         }
       }
     }
     ```
	- Αντικαταστήστε το μονοπάτι με το μονοπάτι του έργου σας. Το μονοπάτι πρέπει να είναι απόλυτο και όχι σχετικό με το φάκελο του χώρου εργασίας. (Παράδειγμα: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## Χρήση της Υπηρεσίας

Η υπηρεσία εκθέτει τα ακόλουθα σημεία API μέσω του πρωτοκόλλου MCP:

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
1. Αφού δημιουργηθεί η εικόνα, ας την ανεβάσουμε στο Docker Hub. Εκτελέστε την ακόλουθη εντολή:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Χρήση της Έκδοσης σε Docker

1. Στο αρχείο `.vscode/mcp.json`, αντικαταστήστε τη ρύθμιση του διακομιστή με την ακόλουθη:
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
   Βλέποντας τη ρύθμιση, μπορείτε να δείτε ότι η εντολή είναι `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, και όπως και πριν μπορείτε να ζητήσετε από την υπηρεσία υπολογιστή να κάνει μερικά μαθηματικά για εσάς.

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτοματοποιημένες μεταφράσεις μπορεί να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν είμαστε υπεύθυνοι για τυχόν παρανοήσεις ή παρερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.