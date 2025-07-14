<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-07-13T20:15:17+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "el"
}
-->
# Εκτέλεση αυτού του παραδείγματος

Συνιστάται να εγκαταστήσετε το `uv`, αλλά δεν είναι υποχρεωτικό, δείτε τις [οδηγίες](https://docs.astral.sh/uv/#highlights)

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

Με τον server να τρέχει σε ένα τερματικό, ανοίξτε ένα άλλο τερματικό και εκτελέστε την παρακάτω εντολή:

```bash
mcp dev server.py
```

Αυτό θα ξεκινήσει έναν web server με οπτική διεπαφή που σας επιτρέπει να δοκιμάσετε το παράδειγμα.

Μόλις ο server συνδεθεί:

- δοκιμάστε να εμφανίσετε τα εργαλεία και εκτελέστε το `add` με ορίσματα 2 και 4, θα πρέπει να δείτε 6 στο αποτέλεσμα.
- μεταβείτε στους πόρους και στο πρότυπο πόρων και καλέστε το get_greeting, πληκτρολογήστε ένα όνομα και θα δείτε έναν χαιρετισμό με το όνομα που δώσατε.

### Δοκιμή σε λειτουργία CLI

Ο inspector που εκτελέσατε είναι στην πραγματικότητα μια εφαρμογή Node.js και το `mcp dev` είναι ένα wrapper γύρω από αυτήν.

Μπορείτε να το ξεκινήσετε απευθείας σε λειτουργία CLI εκτελώντας την παρακάτω εντολή:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Αυτή η εντολή θα εμφανίσει όλα τα διαθέσιμα εργαλεία στον server. Θα πρέπει να δείτε την παρακάτω έξοδο:

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

Θα πρέπει να δείτε την παρακάτω έξοδο:

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
> Συνήθως είναι πολύ πιο γρήγορο να τρέξετε τον inspector σε λειτουργία CLI παρά στον browser.
> Διαβάστε περισσότερα για τον inspector [εδώ](https://github.com/modelcontextprotocol/inspector).

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.