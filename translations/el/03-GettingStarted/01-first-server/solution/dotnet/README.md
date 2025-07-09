<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "07863f50601f395c3bdfce30f555f11a",
  "translation_date": "2025-07-09T21:58:42+00:00",
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

Με τον server να τρέχει σε ένα τερματικό, άνοιξε ένα άλλο τερματικό και εκτέλεσε την παρακάτω εντολή:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Αυτό θα ξεκινήσει έναν web server με οπτική διεπαφή που σου επιτρέπει να δοκιμάσεις το δείγμα.

Μόλις ο server συνδεθεί:

- δοκίμασε να εμφανίσεις τα εργαλεία και εκτέλεσε το `add` με ορίσματα 2 και 4, θα πρέπει να δεις 6 στο αποτέλεσμα.
- πήγαινε στα resources και στο resource template και κάλεσε το "greeting", γράψε ένα όνομα και θα δεις έναν χαιρετισμό με το όνομα που έδωσες.

### Δοκιμή σε λειτουργία CLI

Μπορείς να το ξεκινήσεις απευθείας σε λειτουργία CLI εκτελώντας την παρακάτω εντολή:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Αυτή η εντολή θα εμφανίσει όλα τα διαθέσιμα εργαλεία στον server. Θα πρέπει να δεις την εξής έξοδο:

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

Για να καλέσεις ένα εργαλείο πληκτρολόγησε:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Θα πρέπει να δεις την εξής έξοδο:

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
> Συνήθως είναι πολύ πιο γρήγορο να τρέχεις τον inspector σε λειτουργία CLI παρά στον browser.
> Διάβασε περισσότερα για τον inspector [εδώ](https://github.com/modelcontextprotocol/inspector).

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.