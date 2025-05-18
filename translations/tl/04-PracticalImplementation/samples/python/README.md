<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T14:59:46+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "tl"
}
-->
# Halimbawa

Ito ay isang halimbawa ng Python para sa isang MCP Server.

Ipinapakita ng module na ito kung paano ipatupad ang isang pangunahing MCP server na kayang humawak ng mga kahilingan para sa pagkumpleto. Nagbibigay ito ng mock na implementasyon na nagsisimula ng interaksyon sa iba't ibang AI models.

Ganito ang hitsura ng proseso ng pagpaparehistro ng tool:

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

## I-install

Patakbuhin ang sumusunod na utos:

```bash
pip install mcp
```

## Patakbuhin

```bash
python mcp_sample.py
```

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Habang sinisikap naming maging tumpak, mangyaring tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkaka-ayon. Ang orihinal na dokumento sa kanyang katutubong wika ang dapat ituring na mapagkakatiwalaang pinagmulan. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasaling-wika ng tao. Hindi kami mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na dulot ng paggamit ng pagsasaling ito.