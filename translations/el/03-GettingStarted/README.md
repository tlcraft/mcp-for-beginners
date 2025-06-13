<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-12T23:50:00+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "el"
}
-->
## Ξεκινώντας  

Αυτή η ενότητα αποτελείται από αρκετά μαθήματα:

- **1 Ο πρώτος σας server**, σε αυτό το πρώτο μάθημα, θα μάθετε πώς να δημιουργήσετε τον πρώτο σας server και να τον ελέγξετε με το εργαλείο επιθεώρησης, έναν πολύτιμο τρόπο για να δοκιμάσετε και να εντοπίσετε σφάλματα στον server σας, [στο μάθημα](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, σε αυτό το μάθημα, θα μάθετε πώς να γράψετε έναν client που μπορεί να συνδεθεί με τον server σας, [στο μάθημα](/03-GettingStarted/02-client/README.md)

- **3 Client με LLM**, ένας ακόμη καλύτερος τρόπος να γράψετε έναν client είναι προσθέτοντας ένα LLM, ώστε να μπορεί να "διαπραγματευτεί" με τον server σας τι πρέπει να κάνει, [στο μάθημα](/03-GettingStarted/03-llm-client/README.md)

- **4 Χρήση του server σε λειτουργία GitHub Copilot Agent στο Visual Studio Code**. Εδώ, εξετάζουμε πώς να τρέξουμε τον MCP Server μέσα από το Visual Studio Code, [στο μάθημα](/03-GettingStarted/04-vscode/README.md)

- **5 Κατανάλωση από SSE (Server Sent Events)** SSE είναι ένα πρότυπο για streaming από server σε client, που επιτρέπει στους servers να στέλνουν ενημερώσεις σε πραγματικό χρόνο στους clients μέσω HTTP [στο μάθημα](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP Streaming με MCP (Streamable HTTP)**. Μάθετε για το σύγχρονο HTTP streaming, τις ειδοποιήσεις προόδου και πώς να υλοποιήσετε κλιμακούμενους, σε πραγματικό χρόνο MCP servers και clients χρησιμοποιώντας το Streamable HTTP. [στο μάθημα](/03-GettingStarted/06-http-streaming/README.md)

- **7 Χρήση του AI Toolkit για VSCode** για να καταναλώσετε και να δοκιμάσετε τους MCP Clients και Servers σας [στο μάθημα](/03-GettingStarted/07-aitk/README.md)

- **8 Testing**. Εδώ θα εστιάσουμε κυρίως στο πώς μπορούμε να δοκιμάσουμε τον server και τον client με διάφορους τρόπους, [στο μάθημα](/03-GettingStarted/08-testing/README.md)

- **9 Deployment**. Αυτό το κεφάλαιο θα εξετάσει διάφορους τρόπους ανάπτυξης των MCP λύσεών σας, [στο μάθημα](/03-GettingStarted/09-deployment/README.md)


Το Model Context Protocol (MCP) είναι ένα ανοιχτό πρωτόκολλο που τυποποιεί τον τρόπο με τον οποίο οι εφαρμογές παρέχουν context σε LLMs. Σκεφτείτε το MCP σαν μια θύρα USB-C για εφαρμογές AI - προσφέρει έναν τυποποιημένο τρόπο σύνδεσης μοντέλων AI με διάφορες πηγές δεδομένων και εργαλεία.

## Στόχοι Μάθησης

Στο τέλος αυτού του μαθήματος, θα μπορείτε να:

- Ρυθμίσετε περιβάλλοντα ανάπτυξης για MCP σε C#, Java, Python, TypeScript και JavaScript
- Δημιουργήσετε και αναπτύξετε βασικούς MCP servers με προσαρμοσμένα χαρακτηριστικά (resources, prompts και εργαλεία)
- Δημιουργήσετε εφαρμογές host που συνδέονται με MCP servers
- Δοκιμάσετε και εντοπίσετε σφάλματα σε υλοποιήσεις MCP
- Κατανοήσετε κοινές προκλήσεις ρύθμισης και τις λύσεις τους
- Συνδέσετε τις υλοποιήσεις MCP με δημοφιλείς υπηρεσίες LLM

## Ρύθμιση του Περιβάλλοντος MCP

Πριν ξεκινήσετε να εργάζεστε με MCP, είναι σημαντικό να προετοιμάσετε το περιβάλλον ανάπτυξής σας και να κατανοήσετε τη βασική ροή εργασίας. Αυτή η ενότητα θα σας καθοδηγήσει στα αρχικά βήματα ρύθμισης για να εξασφαλίσετε μια ομαλή αρχή με το MCP.

### Προαπαιτούμενα

Πριν ξεκινήσετε την ανάπτυξη MCP, βεβαιωθείτε ότι έχετε:

- **Περιβάλλον Ανάπτυξης**: Για τη γλώσσα της επιλογής σας (C#, Java, Python, TypeScript ή JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ή οποιονδήποτε σύγχρονο κειμενογράφο
- **Διαχειριστές Πακέτων**: NuGet, Maven/Gradle, pip ή npm/yarn
- **Κλειδιά API**: Για οποιεσδήποτε υπηρεσίες AI σκοπεύετε να χρησιμοποιήσετε στις εφαρμογές host σας


### Επίσημα SDKs

Στα επόμενα κεφάλαια θα δείτε λύσεις που έχουν κατασκευαστεί με Python, TypeScript, Java και .NET. Εδώ είναι όλα τα επίσημα υποστηριζόμενα SDKs.

Το MCP παρέχει επίσημα SDKs για πολλές γλώσσες:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Συντηρείται σε συνεργασία με τη Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Συντηρείται σε συνεργασία με την Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Η επίσημη υλοποίηση για TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Η επίσημη υλοποίηση για Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Η επίσημη υλοποίηση για Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Συντηρείται σε συνεργασία με την Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Η επίσημη υλοποίηση για Rust

## Βασικά Σημεία

- Η ρύθμιση ενός περιβάλλοντος ανάπτυξης MCP είναι απλή με τα SDKs ανά γλώσσα
- Η δημιουργία MCP servers περιλαμβάνει τη δημιουργία και καταχώρηση εργαλείων με σαφή σχήματα
- Οι MCP clients συνδέονται με servers και μοντέλα για να αξιοποιήσουν τις επεκτάσεις
- Οι δοκιμές και ο εντοπισμός σφαλμάτων είναι απαραίτητα για αξιόπιστες υλοποιήσεις MCP
- Οι επιλογές ανάπτυξης κυμαίνονται από τοπική ανάπτυξη έως λύσεις βασισμένες στο cloud

## Πρακτική

Διαθέτουμε ένα σύνολο δειγμάτων που συμπληρώνουν τις ασκήσεις που θα δείτε σε όλα τα κεφάλαια αυτής της ενότητας. Επιπλέον, κάθε κεφάλαιο έχει τις δικές του ασκήσεις και εργασίες

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Πρόσθετοι Πόροι

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Τι ακολουθεί

Επόμενο: [Δημιουργώντας τον πρώτο σας MCP Server](/03-GettingStarted/01-first-server/README.md)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία μετάφρασης με τεχνητή νοημοσύνη [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να λάβετε υπόψη ότι οι αυτοματοποιημένες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η επίσημη πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.