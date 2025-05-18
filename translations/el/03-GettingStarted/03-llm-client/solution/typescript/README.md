<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:55:41+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "el"
}
-->
# Εκτέλεση αυτού του δείγματος

Αυτό το δείγμα περιλαμβάνει την ύπαρξη ενός LLM στον πελάτη. Το LLM απαιτεί είτε να το εκτελέσετε σε ένα Codespaces είτε να ρυθμίσετε ένα προσωπικό διακριτικό πρόσβασης στο GitHub για να λειτουργήσει.

## -1- Εγκαταστήστε τις εξαρτήσεις

```bash
npm install
```

## -3- Εκτελέστε τον διακομιστή

```bash
npm run build
```

## -4- Εκτελέστε τον πελάτη

```sh
npm run client
```

Θα πρέπει να δείτε ένα αποτέλεσμα παρόμοιο με:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ενώ επιδιώκουμε την ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτοματοποιημένες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα θα πρέπει να θεωρείται η έγκυρη πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν είμαστε υπεύθυνοι για τυχόν παρεξηγήσεις ή παρανοήσεις που προκύπτουν από τη χρήση αυτής της μετάφρασης.