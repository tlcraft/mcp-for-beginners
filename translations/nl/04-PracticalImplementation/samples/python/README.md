<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T14:58:46+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "nl"
}
-->
# Voorbeeld

Dit is een Python-voorbeeld voor een MCP-server.

Deze module demonstreert hoe je een basis MCP-server kunt implementeren die verzoeken om voltooiing kan afhandelen. Het biedt een mock-implementatie die interactie met verschillende AI-modellen simuleert.

Hier zie je hoe het registratieproces van de tool eruitziet:

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

## Installeren

Voer de volgende opdracht uit:

```bash
pip install mcp
```

## Uitvoeren

```bash
python mcp_sample.py
```

**Disclaimer**:
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, moet u zich ervan bewust zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in zijn oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.