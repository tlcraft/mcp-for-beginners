<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T15:01:06+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "sr"
}
-->
# Primer

Ovo je Python primer za MCP server.

Ovaj modul demonstrira kako da implementirate osnovni MCP server koji može da obrađuje zahteve za kompletiranje. Pruža lažnu implementaciju koja simulira interakciju sa različitim AI modelima.

Ovako izgleda proces registracije alata:

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

Pokrenite sledeću komandu:

```bash
pip install mcp
```

## Pokretanje

```bash
python mcp_sample.py
```

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да обезбедимо тачност, молимо вас да будете свесни да аутоматизовани преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитативним извором. За критичне информације, препоручује се професионални превод од стране људи. Нисмо одговорни за било каква погрешна схватања или погрешна тумачења која произилазе из употребе овог превода.