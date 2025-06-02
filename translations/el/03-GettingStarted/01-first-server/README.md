<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:09:47+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "el"
}
-->
### -2- Δημιουργία έργου

Τώρα που έχετε εγκαταστήσει το SDK, ας δημιουργήσουμε το έργο σας στη συνέχεια:

### -3- Δημιουργία αρχείων έργου

### -4- Δημιουργία κώδικα διακομιστή

### -5- Προσθήκη εργαλείου και πόρου

Προσθέστε ένα εργαλείο και έναν πόρο προσθέτοντας τον παρακάτω κώδικα:

### -6 Τελικός κώδικας

Ας προσθέσουμε τον τελευταίο κώδικα που χρειαζόμαστε ώστε ο διακομιστής να μπορεί να ξεκινήσει:

### -7- Δοκιμή του διακομιστή

Ξεκινήστε τον διακομιστή με την παρακάτω εντολή:

### -8- Εκτέλεση με το inspector

Το inspector είναι ένα εξαιρετικό εργαλείο που μπορεί να εκκινήσει τον διακομιστή σας και να σας επιτρέψει να αλληλεπιδράσετε μαζί του ώστε να ελέγξετε ότι λειτουργεί. Ας το ξεκινήσουμε:

> [!NOTE]
> μπορεί να φαίνεται διαφορετικό στο πεδίο "command" καθώς περιέχει την εντολή για την εκτέλεση ενός διακομιστή με το συγκεκριμένο runtime που χρησιμοποιείτε/

Θα δείτε την παρακάτω διεπαφή χρήστη:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.el.png)

1. Συνδεθείτε στον διακομιστή επιλέγοντας το κουμπί Connect  
   Μόλις συνδεθείτε, θα δείτε τα εξής:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.el.png)

2. Επιλέξτε "Tools" και "listTools", θα δείτε να εμφανίζεται το "Add", επιλέξτε "Add" και συμπληρώστε τις τιμές των παραμέτρων.

   Θα δείτε την παρακάτω απάντηση, δηλαδή ένα αποτέλεσμα από το εργαλείο "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.el.png)

Συγχαρητήρια, καταφέρατε να δημιουργήσετε και να τρέξετε τον πρώτο σας διακομιστή!

### Επίσημα SDKs

Το MCP παρέχει επίσημα SDKs για πολλές γλώσσες:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Συντηρείται σε συνεργασία με τη Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Συντηρείται σε συνεργασία με τη Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Η επίσημη υλοποίηση σε TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Η επίσημη υλοποίηση σε Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Η επίσημη υλοποίηση σε Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Συντηρείται σε συνεργασία με τη Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Η επίσημη υλοποίηση σε Rust

## Κύρια σημεία

- Η ρύθμιση περιβάλλοντος ανάπτυξης MCP είναι απλή με τα SDKs για κάθε γλώσσα
- Η κατασκευή MCP διακομιστών περιλαμβάνει τη δημιουργία και καταχώρηση εργαλείων με σαφή σχήματα
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
3. Τρέξτε το εργαλείο inspector για να βεβαιωθείτε ότι ο διακομιστής λειτουργεί σωστά.
4. Δοκιμάστε την υλοποίηση με διάφορες εισόδους.

## Λύση

[Solution](./solution/README.md)

## Πρόσθετοι Πόροι

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Τι ακολουθεί

Επόμενο: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Αποποίηση Ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να λάβετε υπόψη ότι οι αυτόματες μεταφράσεις μπορεί να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θεωρείται η επίσημη πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.