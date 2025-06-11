<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:09:23+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "el"
}
-->
## Ξεκινώντας  

Αυτή η ενότητα αποτελείται από αρκετά μαθήματα:

- **1 Ο πρώτος σας server**, σε αυτό το πρώτο μάθημα, θα μάθετε πώς να δημιουργήσετε τον πρώτο σας server και να τον ελέγξετε με το εργαλείο επιθεώρησης, ένας πολύτιμος τρόπος για να δοκιμάσετε και να εντοπίσετε σφάλματα στον server σας, [στο μάθημα](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, σε αυτό το μάθημα, θα μάθετε πώς να γράψετε έναν client που μπορεί να συνδεθεί με τον server σας, [στο μάθημα](/03-GettingStarted/02-client/README.md)

- **3 Client με LLM**, ένας ακόμη καλύτερος τρόπος να γράψετε έναν client είναι προσθέτοντας ένα LLM ώστε να μπορεί να "διαπραγματεύεται" με τον server σας για το τι πρέπει να κάνει, [στο μάθημα](/03-GettingStarted/03-llm-client/README.md)

- **4 Χρήση λειτουργίας GitHub Copilot Agent server μέσα στο Visual Studio Code**. Εδώ, εξετάζουμε το πώς να τρέξουμε τον MCP Server μας από το Visual Studio Code, [στο μάθημα](/03-GettingStarted/04-vscode/README.md)

- **5 Κατανάλωση από SSE (Server Sent Events)** SSE είναι ένα πρότυπο για streaming από server προς client, που επιτρέπει στους servers να στέλνουν ενημερώσεις σε πραγματικό χρόνο στους clients μέσω HTTP [στο μάθημα](/03-GettingStarted/05-sse-server/README.md)

- **6 Χρήση του AI Toolkit για VSCode** για να καταναλώσετε και να δοκιμάσετε τους MCP Clients και Servers σας [στο μάθημα](/03-GettingStarted/06-aitk/README.md)

- **7 Δοκιμές**. Εδώ θα εστιάσουμε ιδιαίτερα στο πώς μπορούμε να δοκιμάσουμε τον server και τον client με διάφορους τρόπους, [στο μάθημα](/03-GettingStarted/07-testing/README.md)

- **8 Ανάπτυξη**. Αυτό το κεφάλαιο θα εξετάσει διάφορους τρόπους ανάπτυξης των MCP λύσεών σας, [στο μάθημα](/03-GettingStarted/08-deployment/README.md)


Το Model Context Protocol (MCP) είναι ένα ανοιχτό πρωτόκολλο που τυποποιεί τον τρόπο με τον οποίο οι εφαρμογές παρέχουν context στα LLMs. Σκεφτείτε το MCP σαν μια θύρα USB-C για εφαρμογές τεχνητής νοημοσύνης - παρέχει έναν τυποποιημένο τρόπο σύνδεσης μοντέλων AI με διάφορες πηγές δεδομένων και εργαλεία.

## Μαθησιακοί Στόχοι

Στο τέλος αυτού του μαθήματος, θα είστε σε θέση να:

- Ρυθμίσετε περιβάλλοντα ανάπτυξης για MCP σε C#, Java, Python, TypeScript και JavaScript
- Δημιουργήσετε και αναπτύξετε βασικούς MCP servers με προσαρμοσμένες λειτουργίες (resources, prompts, και εργαλεία)
- Δημιουργήσετε εφαρμογές host που συνδέονται με MCP servers
- Δοκιμάσετε και εντοπίσετε σφάλματα σε υλοποιήσεις MCP
- Κατανοήσετε κοινές προκλήσεις ρύθμισης και τις λύσεις τους
- Συνδέσετε τις υλοποιήσεις MCP με δημοφιλείς υπηρεσίες LLM

## Ρύθμιση του Περιβάλλοντος MCP

Πριν ξεκινήσετε να εργάζεστε με το MCP, είναι σημαντικό να προετοιμάσετε το περιβάλλον ανάπτυξής σας και να κατανοήσετε τη βασική ροή εργασίας. Αυτή η ενότητα θα σας καθοδηγήσει στα αρχικά βήματα ρύθμισης για να εξασφαλίσετε μια ομαλή αρχή με το MCP.

### Προαπαιτούμενα

Πριν βουτήξετε στην ανάπτυξη MCP, βεβαιωθείτε ότι έχετε:

- **Περιβάλλον Ανάπτυξης**: Για τη γλώσσα που έχετε επιλέξει (C#, Java, Python, TypeScript ή JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ή οποιονδήποτε σύγχρονο επεξεργαστή κώδικα
- **Διαχειριστές Πακέτων**: NuGet, Maven/Gradle, pip ή npm/yarn
- **API Keys**: Για οποιεσδήποτε υπηρεσίες AI σκοπεύετε να χρησιμοποιήσετε στις εφαρμογές host σας


### Επίσημα SDKs

Στα επόμενα κεφάλαια θα δείτε λύσεις που έχουν δημιουργηθεί με Python, TypeScript, Java και .NET. Εδώ είναι όλα τα επίσημα υποστηριζόμενα SDKs.

Το MCP παρέχει επίσημα SDKs για πολλές γλώσσες:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Συντηρείται σε συνεργασία με τη Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Συντηρείται σε συνεργασία με την Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Η επίσημη υλοποίηση για TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Η επίσημη υλοποίηση για Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Η επίσημη υλοποίηση για Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Συντηρείται σε συνεργασία με την Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Η επίσημη υλοποίηση για Rust

## Βασικά Συμπεράσματα

- Η ρύθμιση ενός περιβάλλοντος ανάπτυξης MCP είναι απλή με τα SDKs ειδικά για κάθε γλώσσα
- Η δημιουργία MCP servers περιλαμβάνει τη δημιουργία και καταχώρηση εργαλείων με σαφή σχήματα
- Οι MCP clients συνδέονται με servers και μοντέλα για να αξιοποιήσουν τις επεκταμένες δυνατότητες
- Οι δοκιμές και ο εντοπισμός σφαλμάτων είναι απαραίτητα για αξιόπιστες υλοποιήσεις MCP
- Οι επιλογές ανάπτυξης ποικίλλουν από τοπική ανάπτυξη μέχρι λύσεις βασισμένες στο cloud

## Εξάσκηση

Διαθέτουμε ένα σύνολο δειγμάτων που συμπληρώνουν τις ασκήσεις που θα δείτε σε όλα τα κεφάλαια αυτής της ενότητας. Επιπλέον, κάθε κεφάλαιο έχει τις δικές του ασκήσεις και εργασίες.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Επιπλέον Πόροι

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Τι ακολουθεί

Επόμενο: [Δημιουργία του πρώτου σας MCP Server](/03-GettingStarted/01-first-server/README.md)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν σφάλματα ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική μετάφραση από ανθρώπους. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.