<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T15:01:17+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "sl"
}
-->
# Vzorec

To je Pythonov vzorec za MCP strežnik.

Ta modul prikazuje, kako implementirati osnovni MCP strežnik, ki lahko obravnava zahteve za dokončanje. Ponuja simulacijo, ki posnema interakcijo z različnimi modeli umetne inteligence.

Tako izgleda postopek registracije orodja:

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

## Namestitev

Zaženite naslednji ukaz:

```bash
pip install mcp
```

## Zagon

```bash
python mcp_sample.py
```

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za prevajanje z umetno inteligenco [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da se zavedate, da lahko samodejni prevodi vsebujejo napake ali netočnosti. Izvirni dokument v svojem maternem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije je priporočljivo profesionalno človeško prevajanje. Ne odgovarjamo za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.