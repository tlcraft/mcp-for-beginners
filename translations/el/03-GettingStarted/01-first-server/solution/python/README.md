<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:16:29+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "el"
}
-->
# Εκτέλεση αυτού του δείγματος

Συνιστάται να εγκαταστήσετε το `uv` αλλά δεν είναι απαραίτητο, δείτε [οδηγίες](https://docs.astral.sh/uv/#highlights)

## -0- Δημιουργήστε ένα εικονικό περιβάλλον

```bash
python -m venv venv
```

## -1- Ενεργοποιήστε το εικονικό περιβάλλον

```bash
venv\Scrips\activate
```

## -2- Εγκαταστήστε τις εξαρτήσεις

```bash
pip install "mcp[cli]"
```

## -3- Εκτελέστε το δείγμα

```bash
mcp run server.py
```

## -4- Δοκιμάστε το δείγμα

Με τον διακομιστή να τρέχει σε ένα τερματικό, ανοίξτε ένα άλλο τερματικό και εκτελέστε την ακόλουθη εντολή:

```bash
mcp dev server.py
```

Αυτό θα πρέπει να ξεκινήσει έναν web server με οπτική διεπαφή που σας επιτρέπει να δοκιμάσετε το δείγμα.

Μόλις συνδεθεί ο διακομιστής: 

- δοκιμάστε να καταγράψετε εργαλεία και εκτελέστε το `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` είναι ένα περιτύλιγμα γύρω από αυτό.

Μπορείτε να το εκκινήσετε απευθείας σε λειτουργία CLI εκτελώντας την ακόλουθη εντολή:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Αυτό θα καταγράψει όλα τα εργαλεία διαθέσιμα στον διακομιστή. Θα πρέπει να δείτε το ακόλουθο αποτέλεσμα:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

Για να καλέσετε ένα εργαλείο πληκτρολογήστε:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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

> ![!TIP]
> Συνήθως είναι πολύ πιο γρήγορο να εκτελέσετε τον inspector σε λειτουργία CLI παρά στον περιηγητή.
> Διαβάστε περισσότερα για τον inspector [εδώ](https://github.com/modelcontextprotocol/inspector).

**Αποποίηση Ευθύνης**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης [Co-op Translator](https://github.com/Azure/co-op-translator). Ενώ προσπαθούμε για ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτοματοποιημένες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για οποιεσδήποτε παρεξηγήσεις ή παρερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.