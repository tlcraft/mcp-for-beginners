<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:17:41+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "el"
}
-->
# Εκτέλεση αυτού του παραδείγματος

## -1- Εγκατάσταση των εξαρτήσεων

```bash
dotnet restore
```

## -2- Εκτέλεση του παραδείγματος

```bash
dotnet run
```

## -3- Δοκιμή του παραδείγματος

Ξεκινήστε ένα ξεχωριστό τερματικό πριν εκτελέσετε την παρακάτω εντολή (βεβαιωθείτε ότι ο διακομιστής τρέχει ακόμα).

Με τον διακομιστή να τρέχει σε ένα τερματικό, ανοίξτε ένα άλλο τερματικό και εκτελέστε την ακόλουθη εντολή:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Αυτό θα ξεκινήσει έναν web διακομιστή με οπτική διεπαφή που σας επιτρέπει να δοκιμάσετε το παράδειγμα.

> Βεβαιωθείτε ότι το **Streamable HTTP** έχει επιλεγεί ως τύπος μεταφοράς, και το URL είναι `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`, με ορίσματα 2 και 4, θα πρέπει να δείτε 6 στο αποτέλεσμα.
- μεταβείτε στους πόρους και το πρότυπο πόρων και καλέστε το "greeting", πληκτρολογήστε ένα όνομα και θα δείτε έναν χαιρετισμό με το όνομα που δώσατε.

### Δοκιμή σε λειτουργία CLI

Μπορείτε να το εκκινήσετε απευθείας σε λειτουργία CLI εκτελώντας την ακόλουθη εντολή:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Αυτό θα εμφανίσει όλα τα διαθέσιμα εργαλεία στον διακομιστή. Θα πρέπει να δείτε την εξής έξοδο:

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
> Συνήθως είναι πολύ πιο γρήγορο να τρέξετε τον inspector σε λειτουργία CLI παρά στον περιηγητή.
> Διαβάστε περισσότερα για τον inspector [εδώ](https://github.com/modelcontextprotocol/inspector).

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτόματες μεταφράσεις μπορεί να περιέχουν σφάλματα ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για οποιεσδήποτε παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.