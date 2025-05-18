<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:55:58+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "el"
}
-->
# Εκτέλεση αυτού του δείγματος

## -1- Εγκαταστήστε τις εξαρτήσεις

```bash
dotnet run
```

## -2- Εκτελέστε το δείγμα

```bash
dotnet run
```

## -3- Δοκιμάστε το δείγμα

Ξεκινήστε ένα ξεχωριστό τερματικό πριν εκτελέσετε τα παρακάτω (βεβαιωθείτε ότι ο διακομιστής εξακολουθεί να λειτουργεί).

Με τον διακομιστή να λειτουργεί σε ένα τερματικό, ανοίξτε ένα άλλο τερματικό και εκτελέστε την ακόλουθη εντολή:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Αυτό θα ξεκινήσει έναν διακομιστή ιστού με οπτική διεπαφή που σας επιτρέπει να δοκιμάσετε το δείγμα.

Μόλις συνδεθεί ο διακομιστής:

- δοκιμάστε να απαριθμήσετε εργαλεία και εκτελέστε το `add`, με επιχειρήματα 2 και 4, θα πρέπει να δείτε 6 στο αποτέλεσμα.
- πηγαίνετε στους πόρους και στο πρότυπο πόρου και καλέστε το "greeting", πληκτρολογήστε ένα όνομα και θα πρέπει να δείτε έναν χαιρετισμό με το όνομα που δώσατε.

### Δοκιμή σε λειτουργία CLI

Μπορείτε να το εκκινήσετε απευθείας σε λειτουργία CLI εκτελώντας την ακόλουθη εντολή:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Αυτό θα απαριθμήσει όλα τα διαθέσιμα εργαλεία στον διακομιστή. Θα πρέπει να δείτε το ακόλουθο αποτέλεσμα:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
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
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Θα πρέπει να δείτε το ακόλουθο αποτέλεσμα:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> [!TIP]
> Συνήθως είναι πολύ πιο γρήγορο να εκτελείτε το inspector σε λειτουργία CLI παρά στον περιηγητή.
> Διαβάστε περισσότερα για το inspector [εδώ](https://github.com/modelcontextprotocol/inspector).

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία AI μετάφρασης [Co-op Translator](https://github.com/Azure/co-op-translator). Ενώ προσπαθούμε για ακρίβεια, παρακαλώ σημειώστε ότι οι αυτοματοποιημένες μεταφράσεις μπορεί να περιέχουν σφάλματα ή ανακρίβειες. Το αρχικό έγγραφο στη μητρική του γλώσσα θα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για οποιεσδήποτε παρεξηγήσεις ή εσφαλμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.