<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T05:59:34+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "el"
}
-->
# Εκτέλεση αυτού του παραδείγματος

## -1- Εγκατάσταση των εξαρτήσεων

```bash
dotnet restore
```

## -3- Εκτέλεση του παραδείγματος

```bash
dotnet run
```

## -4- Δοκιμή του παραδείγματος

Με τον διακομιστή να τρέχει σε ένα τερματικό, ανοίξτε ένα άλλο τερματικό και εκτελέστε την ακόλουθη εντολή:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Αυτό θα ξεκινήσει έναν web server με οπτικό περιβάλλον που σας επιτρέπει να δοκιμάσετε το παράδειγμα.

Μόλις ο διακομιστής συνδεθεί:

- δοκιμάστε να εμφανίσετε τα εργαλεία και τρέξτε το `add`, με ορίσματα 2 και 4, θα πρέπει να δείτε 6 στο αποτέλεσμα.
- πηγαίνετε στα resources και resource template και καλέστε το "greeting", πληκτρολογήστε ένα όνομα και θα δείτε έναν χαιρετισμό με το όνομα που δώσατε.

### Δοκιμή σε λειτουργία CLI

Μπορείτε να το ξεκινήσετε απευθείας σε λειτουργία CLI εκτελώντας την ακόλουθη εντολή:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Αυτή θα εμφανίσει όλα τα διαθέσιμα εργαλεία στον διακομιστή. Θα πρέπει να δείτε την εξής έξοδο:

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

**Αποποίηση Ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να λάβετε υπόψη ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν σφάλματα ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες συνιστάται η επαγγελματική μετάφραση από ανθρώπους. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.