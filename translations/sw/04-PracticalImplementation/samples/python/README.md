<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T15:00:03+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "sw"
}
-->
# Sampuli

Hii ni sampuli ya Python kwa ajili ya Server ya MCP.

Moduli hii inaonyesha jinsi ya kutekeleza server ya msingi ya MCP inayoweza kushughulikia maombi ya kukamilisha. Inatoa utekelezaji wa mfano unaosimulia maingiliano na mifano mbalimbali ya AI.

Hivi ndivyo mchakato wa usajili wa zana unavyoonekana:

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

## Sakinisha

Endesha amri ifuatayo:

```bash
pip install mcp
```

## Endesha

```bash
python mcp_sample.py
```

**Kanusho**: 
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya awali katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo chenye mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatuwajibiki kwa kutoelewana au tafsiri zisizo sahihi zinazosababishwa na matumizi ya tafsiri hii.