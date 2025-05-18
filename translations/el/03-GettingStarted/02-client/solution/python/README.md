<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:02:04+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "el"
}
-->
# Εκτέλεση αυτού του δείγματος

Συνιστάται να εγκαταστήσετε το `uv`, αλλά δεν είναι απαραίτητο, δείτε [οδηγίες](https://docs.astral.sh/uv/#highlights)

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
python client.py
```

Θα πρέπει να δείτε μια έξοδο παρόμοια με:

```text
LISTING RESOURCES
Resource:  ('meta', None)
Resource:  ('nextCursor', None)
Resource:  ('resources', [])
                    INFO     Processing request of type ListToolsRequest                                                                               server.py:534
LISTING TOOLS
Tool:  add
READING RESOURCE
                    INFO     Processing request of type ReadResourceRequest                                                                            server.py:534
CALL TOOL
                    INFO     Processing request of type CallToolRequest                                                                                server.py:534
[TextContent(type='text', text='8', annotations=None)]
```

**Αποποίηση ευθύνης**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης [Co-op Translator](https://github.com/Azure/co-op-translator). Ενώ προσπαθούμε για ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτοματοποιημένες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το αρχικό έγγραφο στη μητρική του γλώσσα θα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για οποιεσδήποτε παρανοήσεις ή παρερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.