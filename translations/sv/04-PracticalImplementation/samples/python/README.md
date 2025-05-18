<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T14:58:06+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "sv"
}
-->
# Exempel

Detta är ett Python-exempel för en MCP-server.

Detta modul visar hur man implementerar en grundläggande MCP-server som kan hantera
kompletteringsförfrågningar. Den ger en mock-implementation som simulerar
interaktion med olika AI-modeller.

Så här ser verktygsregistreringsprocessen ut:

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

## Installera

Kör följande kommando:

```bash
pip install mcp
```

## Kör

```bash
python mcp_sample.py
```

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, var medveten om att automatiserade översättningar kan innehålla fel eller felaktigheter. Det ursprungliga dokumentet på dess ursprungliga språk bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi är inte ansvariga för eventuella missförstånd eller misstolkningar som uppstår vid användning av denna översättning.