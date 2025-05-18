<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T15:00:13+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "cs"
}
-->
# Ukázka

Toto je ukázka Pythonu pro MCP server.

Tento modul ukazuje, jak implementovat základní MCP server, který dokáže zpracovávat požadavky na dokončení. Poskytuje falešnou implementaci, která simuluje interakci s různými AI modely.

Takto vypadá proces registrace nástroje:

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

## Instalace

Spusťte následující příkaz:

```bash
pip install mcp
```

## Spuštění

```bash
python mcp_sample.py
```

**Upozornění**:  
Tento dokument byl přeložen pomocí služby pro překlad AI [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo mylné výklady vyplývající z použití tohoto překladu.