<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T14:57:43+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "el"
}
-->
# Δείγμα

Αυτό είναι ένα δείγμα Python για έναν MCP Server.

Αυτό το module δείχνει πώς να υλοποιήσετε έναν βασικό MCP server που μπορεί να διαχειριστεί αιτήματα ολοκλήρωσης. Παρέχει μια ψευδοεφαρμογή που προσομοιώνει την αλληλεπίδραση με διάφορα μοντέλα AI.

Έτσι φαίνεται η διαδικασία εγγραφής του εργαλείου:

```python
completion_tool = ToolDefinition(
    name="completion",
    description="Generate completions using AI models",
    parameters={
        "model": {
            "type": "string",
            "enum": self.models,
            "description": "The AI model to use for completion"
        },
        "prompt": {
            "type": "string",
            "description": "The prompt text to complete"
        },
        "temperature": {
            "type": "number",
            "description": "Sampling temperature (0.0 to 1.0)"
        },
        "max_tokens": {
            "type": "number",
            "description": "Maximum number of tokens to generate"
        }
    },
    required=["model", "prompt"]
)

# Register the tool with its handler
self.server.tools.register(completion_tool, self._handle_completion)
```

## Εγκατάσταση

Εκτελέστε την παρακάτω εντολή:

```bash
pip install mcp
```

## Εκτέλεση

```bash
python mcp_sample.py
```

Αποποίηση ευθυνών:
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτοματοποιημένες μεταφράσεις μπορεί να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα θα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρανοήσεις ή εσφαλμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.