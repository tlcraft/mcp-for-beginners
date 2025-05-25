<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T14:57:17+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "tr"
}
-->
# Örnek

Bu, bir MCP Sunucusu için Python örneğidir.

Bu modül, tamamlanma isteklerini işleyebilen temel bir MCP sunucusunun nasıl uygulanacağını gösterir. Çeşitli AI modelleriyle etkileşimi simüle eden sahte bir uygulama sağlar.

İşte araç kayıt süreci böyle görünüyor:

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

## Kurulum

Aşağıdaki komutu çalıştırın:

```bash
pip install mcp
```

## Çalıştır

```bash
python mcp_sample.py
```

**Feragatname**:  
Bu belge, [Co-op Translator](https://github.com/Azure/co-op-translator) AI çeviri hizmeti kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayın. Belgenin orijinal dili, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlama veya yanlış yorumlamalardan sorumlu değiliz.