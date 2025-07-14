<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:20:29+00:00",
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

Με τον server να τρέχει σε ένα τερματικό, άνοιξε ένα άλλο τερματικό και εκτέλεσε την παρακάτω εντολή:

```bash
npm run inspector
```

Αυτό θα ξεκινήσει έναν web server με οπτικό περιβάλλον που σου επιτρέπει να δοκιμάσεις το δείγμα.

Μόλις ο server συνδεθεί:

- δοκίμασε να εμφανίσεις τα εργαλεία και εκτέλεσε το `add` με ορίσματα 2 και 4, θα πρέπει να δεις 6 στο αποτέλεσμα.
- πήγαινε στα resources και στο resource template και κάλεσε το "greeting", γράψε ένα όνομα και θα δεις έναν χαιρετισμό με το όνομα που έδωσες.

### Δοκιμή σε λειτουργία CLI

Ο inspector που εκτέλεσες είναι στην πραγματικότητα μια εφαρμογή Node.js και το `mcp dev` είναι ένα wrapper γύρω από αυτήν.

- Ξεκίνα τον server με την εντολή `npm run build`.

- Σε ένα ξεχωριστό τερματικό εκτέλεσε την παρακάτω εντολή:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    Αυτή η εντολή θα εμφανίσει όλα τα διαθέσιμα εργαλεία στον server. Θα πρέπει να δεις την εξής έξοδο:

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

- Εκτέλεσε ένα εργαλείο πληκτρολογώντας την παρακάτω εντολή:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Θα πρέπει να δεις την εξής έξοδο:

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
> Συνήθως είναι πολύ πιο γρήγορο να τρέχεις τον inspector σε λειτουργία CLI παρά στον browser.
> Διάβασε περισσότερα για τον inspector [εδώ](https://github.com/modelcontextprotocol/inspector).

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.