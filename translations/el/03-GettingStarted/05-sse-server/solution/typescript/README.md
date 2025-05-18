<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:09:59+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "el"
}
-->
# Εκτέλεση αυτού του δείγματος

## -1- Εγκατάσταση των εξαρτήσεων

```bash
npm install
```

## -3- Εκτέλεση του δείγματος

```bash
npm run build
```

## -4- Δοκιμή του δείγματος

Με τον server να τρέχει σε ένα τερματικό, ανοίξτε ένα άλλο τερματικό και εκτελέστε την ακόλουθη εντολή:

```bash
npm run inspector
```

Αυτό θα ξεκινήσει έναν web server με μια οπτική διεπαφή που σας επιτρέπει να δοκιμάσετε το δείγμα.

Μόλις ο server συνδεθεί:

- δοκιμάστε να καταγράψετε εργαλεία και εκτελέστε `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build`.

- Σε ένα ξεχωριστό τερματικό εκτελέστε την ακόλουθη εντολή:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    Αυτό θα καταγράψει όλα τα διαθέσιμα εργαλεία στον server. Θα πρέπει να δείτε το ακόλουθο αποτέλεσμα:

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

- Ενεργοποιήστε έναν τύπο εργαλείου πληκτρολογώντας την ακόλουθη εντολή:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Θα πρέπει να δείτε το ακόλουθο αποτέλεσμα:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> Συνήθως είναι πολύ πιο γρήγορο να εκτελέσετε τον inspector σε λειτουργία CLI παρά στο πρόγραμμα περιήγησης.
> Διαβάστε περισσότερα για τον inspector [εδώ](https://github.com/modelcontextprotocol/inspector).

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία AI μετάφρασης [Co-op Translator](https://github.com/Azure/co-op-translator). Ενώ προσπαθούμε για την ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτοματοποιημένες μεταφράσεις μπορεί να περιέχουν λάθη ή ανακρίβειες. Το αρχικό έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρανοήσεις ή παρερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.