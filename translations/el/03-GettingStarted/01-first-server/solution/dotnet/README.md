<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:09:33+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "el"
}
-->
# Εκτέλεση αυτού του δείγματος

## -1- Εγκαταστήστε τις εξαρτήσεις

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Εκτελέστε το δείγμα

```bash
dotnet run
```

## -4- Δοκιμάστε το δείγμα

Με τον διακομιστή να τρέχει σε ένα τερματικό, ανοίξτε ένα άλλο τερματικό και εκτελέστε την ακόλουθη εντολή:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Αυτό θα ξεκινήσει έναν web server με μια οπτική διεπαφή που σας επιτρέπει να δοκιμάσετε το δείγμα.

Μόλις συνδεθεί ο διακομιστής:

- δοκιμάστε να καταγράψετε τα εργαλεία και να εκτελέσετε την `add`, με ορίσματα 2 και 4, θα πρέπει να δείτε 6 στο αποτέλεσμα.
- πηγαίνετε στους πόρους και το πρότυπο πόρων και καλέστε "greeting", πληκτρολογήστε ένα όνομα και θα πρέπει να δείτε έναν χαιρετισμό με το όνομα που δώσατε.

### Δοκιμή σε λειτουργία CLI

Μπορείτε να το εκκινήσετε απευθείας σε λειτουργία CLI εκτελώντας την ακόλουθη εντολή:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Αυτό θα καταγράψει όλα τα εργαλεία που είναι διαθέσιμα στον διακομιστή. Θα πρέπει να δείτε την ακόλουθη έξοδο:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Για να καλέσετε ένα εργαλείο πληκτρολογήστε:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Θα πρέπει να δείτε την ακόλουθη έξοδο:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> [!TIP]
> Συνήθως είναι πολύ πιο γρήγορο να εκτελέσετε τον επιθεωρητή σε λειτουργία CLI παρά στο πρόγραμμα περιήγησης.
> Διαβάστε περισσότερα για τον επιθεωρητή [εδώ](https://github.com/modelcontextprotocol/inspector).

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτοματοποιημένες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή παρερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.