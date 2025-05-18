<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T15:01:12+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "hr"
}
-->
# Primjer

Ovo je Python primjer za MCP poslužitelj.

Ovaj modul pokazuje kako implementirati osnovni MCP poslužitelj koji može obrađivati zahtjeve za dovršavanje. Pruža lažnu implementaciju koja simulira interakciju s različitim AI modelima.

Evo kako izgleda proces registracije alata:

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

## Instalacija

Pokrenite sljedeću naredbu:

```bash
pip install mcp
```

## Pokretanje

```bash
python mcp_sample.py
```

**Odricanje odgovornosti**:  
Ovaj dokument je preveden koristeći AI uslugu prevođenja [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni prijevod od strane ljudskog prevoditelja. Ne odgovaramo za nesporazume ili pogrešne interpretacije koji proizlaze iz korištenja ovog prijevoda.