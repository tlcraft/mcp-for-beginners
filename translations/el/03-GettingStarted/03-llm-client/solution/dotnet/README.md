<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:41:22+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "el"
}
-->
# Εκτελέστε αυτό το δείγμα

> [!NOTE]
> Αυτό το δείγμα υποθέτει ότι χρησιμοποιείτε μια GitHub Codespaces instance. Αν θέλετε να το εκτελέσετε τοπικά, πρέπει να δημιουργήσετε ένα προσωπικό access token στο GitHub.

## Εγκατάσταση βιβλιοθηκών

```sh
dotnet restore
```

Θα πρέπει να εγκαταστήσετε τις εξής βιβλιοθήκες: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol

## Εκτέλεση

```sh 
dotnet run
```

Θα πρέπει να δείτε ένα αποτέλεσμα παρόμοιο με:

```text
Setting up stdio transport
Listing tools
Connected to server with tools: Add
Tool description: Adds two numbers
Tool parameters: {"title":"Add","description":"Adds two numbers","type":"object","properties":{"a":{"type":"integer"},"b":{"type":"integer"}},"required":["a","b"]}
Tool definition: Azure.AI.Inference.ChatCompletionsToolDefinition
Properties: {"a":{"type":"integer"},"b":{"type":"integer"}}
MCP Tools def: 0: Azure.AI.Inference.ChatCompletionsToolDefinition
Tool call 0: Add with arguments {"a":2,"b":4}
Sum 6
```

Πολλές από τις εξόδους είναι απλά debugging, αλλά το σημαντικό είναι ότι καταγράφετε εργαλεία από τον MCP Server, τα μετατρέπετε σε LLM εργαλεία και καταλήγετε με μια MCP client απόκριση "Sum 6".

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης [Co-op Translator](https://github.com/Azure/co-op-translator). Ενώ καταβάλλουμε προσπάθειες για ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα θα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρανοήσεις ή παρερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.