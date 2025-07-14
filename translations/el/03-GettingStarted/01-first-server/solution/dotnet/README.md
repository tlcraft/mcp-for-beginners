<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "07863f50601f395c3bdfce30f555f11a",
  "translation_date": "2025-07-13T17:49:04+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "el"
}
-->
# Εκτέλεση αυτού του δείγματος

## -1- Εγκατάσταση των εξαρτήσεων

```bash
dotnet restore
```

## -3- Εκτέλεση του δείγματος

```bash
dotnet run
```

## -4- Δοκιμή του δείγματος

Με τον server να τρέχει σε ένα τερματικό, ανοίξτε ένα άλλο τερματικό και εκτελέστε την παρακάτω εντολή:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Αυτό θα ξεκινήσει έναν web server με οπτικό περιβάλλον που σας επιτρέπει να δοκιμάσετε το δείγμα.

Μόλις ο server συνδεθεί:

- δοκιμάστε να εμφανίσετε τα εργαλεία και εκτελέστε το `add`, με ορίσματα 2 και 4, θα πρέπει να δείτε 6 στο αποτέλεσμα.
- πηγαίνετε στα resources και στο resource template και καλέστε το "greeting", πληκτρολογήστε ένα όνομα και θα δείτε έναν χαιρετισμό με το όνομα που δώσατε.

### Δοκιμή σε λειτουργία CLI

Μπορείτε να το ξεκινήσετε απευθείας σε λειτουργία CLI εκτελώντας την παρακάτω εντολή:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Αυτή η εντολή θα εμφανίσει όλα τα διαθέσιμα εργαλεία στον server. Θα πρέπει να δείτε την εξής έξοδο:

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

Θα πρέπει να δείτε την εξής έξοδο:

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

> ![!TIP]
> Συνήθως είναι πολύ πιο γρήγορο να τρέξετε τον inspector σε λειτουργία CLI παρά στον browser.
> Διαβάστε περισσότερα για τον inspector [εδώ](https://github.com/modelcontextprotocol/inspector).

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.