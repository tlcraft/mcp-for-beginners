<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:02:55+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "el"
}
-->
# Εκτέλεση αυτού του παραδείγματος

Συνιστάται να εγκαταστήσετε το `uv` αλλά δεν είναι απαραίτητο, δείτε [οδηγίες](https://docs.astral.sh/uv/#highlights)

## -0- Δημιουργία εικονικού περιβάλλοντος

```bash
python -m venv venv
```

## -1- Ενεργοποίηση του εικονικού περιβάλλοντος

```bash
venv\Scrips\activate
```

## -2- Εγκατάσταση των εξαρτήσεων

```bash
pip install "mcp[cli]"
```

## -3- Εκτέλεση του παραδείγματος

```bash
mcp run server.py
```

## -4- Δοκιμή του παραδείγματος

Με τον server να τρέχει σε ένα τερματικό, ανοίξτε ένα άλλο τερματικό και εκτελέστε την ακόλουθη εντολή:

```bash
mcp dev server.py
```

Αυτό θα πρέπει να ξεκινήσει έναν web server με μια οπτική διεπαφή που σας επιτρέπει να δοκιμάσετε το παράδειγμα.

Μόλις ο server συνδεθεί:

- δοκιμάστε να καταγράψετε εργαλεία και εκτελέστε `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` είναι ένας περιτυλιγμένος γύρω από αυτό.

Μπορείτε να το εκτελέσετε απευθείας σε λειτουργία CLI εκτελώντας την ακόλουθη εντολή:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Αυτό θα καταγράψει όλα τα εργαλεία διαθέσιμα στον server. Θα πρέπει να δείτε την ακόλουθη έξοδο:

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
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Θα πρέπει να δείτε την ακόλουθη έξοδο:

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
> Συνήθως είναι πολύ πιο γρήγορο να εκτελέσετε τον επιθεωρητή σε λειτουργία CLI παρά στον περιηγητή.
> Διαβάστε περισσότερα για τον επιθεωρητή [εδώ](https://github.com/modelcontextprotocol/inspector).

Αποποίηση ευθυνών:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ενώ προσπαθούμε για ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτοματοποιημένες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το αρχικό έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν είμαστε υπεύθυνοι για τυχόν παρεξηγήσεις ή ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.