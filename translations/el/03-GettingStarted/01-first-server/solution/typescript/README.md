<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:23:39+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "el"
}
-->
# Εκτέλεση αυτού του δείγματος

Συνιστάται να εγκαταστήσετε το `uv` αλλά δεν είναι απαραίτητο, δείτε [οδηγίες](https://docs.astral.sh/uv/#highlights)

## -1- Εγκατάσταση των εξαρτήσεων

```bash
npm install
```

## -3- Εκτέλεση του δείγματος

```bash
npm run build
```

## -4- Δοκιμή του δείγματος

Με τον διακομιστή να τρέχει σε ένα τερματικό, ανοίξτε ένα άλλο τερματικό και εκτελέστε την παρακάτω εντολή:

```bash
npm run inspector
```

Αυτό θα πρέπει να ξεκινήσει έναν διακομιστή ιστού με μια οπτική διεπαφή που σας επιτρέπει να δοκιμάσετε το δείγμα.

Μόλις ο διακομιστής συνδεθεί:

- δοκιμάστε να απαριθμήσετε εργαλεία και να εκτελέσετε `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` είναι ένα περιτύλιγμα γύρω από αυτό.

Μπορείτε να το εκκινήσετε απευθείας σε λειτουργία CLI εκτελώντας την παρακάτω εντολή:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Αυτό θα απαριθμήσει όλα τα διαθέσιμα εργαλεία στον διακομιστή. Θα πρέπει να δείτε την ακόλουθη έξοδο:

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
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Συνήθως είναι πολύ πιο γρήγορο να εκτελέσετε το ispector σε λειτουργία CLI παρά στον περιηγητή.
> Διαβάστε περισσότερα για το inspector [εδώ](https://github.com/modelcontextprotocol/inspector).

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ενώ προσπαθούμε για ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτοματοποιημένες μεταφράσεις μπορεί να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν είμαστε υπεύθυνοι για τυχόν παρανοήσεις ή παρερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.