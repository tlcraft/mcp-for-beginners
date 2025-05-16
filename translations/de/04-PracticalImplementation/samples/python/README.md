<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-16T15:43:36+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "de"
}
-->
# Beispiel

Dies ist ein Python-Beispiel für einen MCP-Server.

Dieses Modul zeigt, wie man einen einfachen MCP-Server implementiert, der
Abschlussanfragen verarbeiten kann. Es bietet eine Mock-Implementierung, die
die Interaktion mit verschiedenen KI-Modellen simuliert.

So sieht der Prozess zur Registrierung eines Tools aus:

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

## Installation

Führen Sie den folgenden Befehl aus:

```bash
pip install mcp
```

## Ausführen

```bash
python mcp_sample.py
```

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in der Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.