<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bf05718d019040cf0c7d4ccc6d6a1a88",
  "translation_date": "2025-06-13T06:00:16+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "el"
}
-->
### -2- Δημιουργία έργου

Τώρα που έχετε εγκαταστήσει το SDK, ας δημιουργήσουμε το επόμενο έργο:

### -3- Δημιουργία αρχείων έργου

### -4- Δημιουργία κώδικα διακομιστή

### -5- Προσθήκη εργαλείου και πόρου

Προσθέστε ένα εργαλείο και έναν πόρο προσθέτοντας τον ακόλουθο κώδικα:

### -6 Τελικός κώδικας

Ας προσθέσουμε τον τελευταίο κώδικα που χρειάζεται ώστε ο διακομιστής να ξεκινήσει:

### -7- Δοκιμή διακομιστή

Ξεκινήστε τον διακομιστή με την παρακάτω εντολή:

### -8- Εκτέλεση με το inspector

Το inspector είναι ένα εξαιρετικό εργαλείο που μπορεί να εκκινήσει τον διακομιστή σας και σας επιτρέπει να αλληλεπιδράσετε μαζί του ώστε να δοκιμάσετε ότι λειτουργεί. Ας το ξεκινήσουμε:

> [!NOTE]
> μπορεί να φαίνεται διαφορετικό στο πεδίο "command" καθώς περιέχει την εντολή για την εκτέλεση ενός διακομιστή με το συγκεκριμένο runtime που χρησιμοποιείτε/

Θα δείτε την ακόλουθη διεπαφή χρήστη:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.el.png)

1. Συνδεθείτε με τον διακομιστή επιλέγοντας το κουμπί Connect  
   Μόλις συνδεθείτε με τον διακομιστή, θα δείτε το εξής:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.el.png)

2. Επιλέξτε "Tools" και "listTools", θα δείτε να εμφανίζεται το "Add", επιλέξτε "Add" και συμπληρώστε τις τιμές των παραμέτρων.

   Θα δείτε την ακόλουθη απάντηση, δηλαδή ένα αποτέλεσμα από το εργαλείο "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.el.png)

Συγχαρητήρια, καταφέρατε να δημιουργήσετε και να τρέξετε τον πρώτο σας διακομιστή!

### Επίσημα SDKs

Το MCP παρέχει επίσημα SDKs για πολλές γλώσσες:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Συντηρείται σε συνεργασία με τη Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Συντηρείται σε συνεργασία με το Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Η επίσημη υλοποίηση TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Η επίσημη υλοποίηση Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Η επίσημη υλοποίηση Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Συντηρείται σε συνεργασία με το Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Η επίσημη υλοποίηση Rust

## Βασικά σημεία

- Η ρύθμιση περιβάλλοντος ανάπτυξης MCP είναι απλή με τα SDKs για κάθε γλώσσα
- Η κατασκευή MCP διακομιστών περιλαμβάνει τη δημιουργία και εγγραφή εργαλείων με σαφή σχήματα
- Οι δοκιμές και ο εντοπισμός σφαλμάτων είναι απαραίτητα για αξιόπιστες υλοποιήσεις MCP

## Παραδείγματα

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Άσκηση

Δημιουργήστε έναν απλό MCP διακομιστή με ένα εργαλείο της επιλογής σας:
1. Υλοποιήστε το εργαλείο στη γλώσσα που προτιμάτε (.NET, Java, Python ή JavaScript).
2. Ορίστε τις παραμέτρους εισόδου και τις τιμές επιστροφής.
3. Εκτελέστε το εργαλείο inspector για να βεβαιωθείτε ότι ο διακομιστής λειτουργεί σωστά.
4. Δοκιμάστε την υλοποίηση με διάφορες εισόδους.

## Λύση

[Λύση](./solution/README.md)

## Πρόσθετοι πόροι

- [Δημιουργία Agents με το Model Context Protocol στο Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Απομακρυσμένο MCP με Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Τι ακολουθεί

Επόμενο: [Ξεκινώντας με MCP Clients](/03-GettingStarted/02-client/README.md)

**Αποποίηση Ευθύνης**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να λάβετε υπόψη ότι οι αυτοματοποιημένες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του πρέπει να θεωρείται η επίσημη πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική μετάφραση από ανθρώπινο μεταφραστή. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.