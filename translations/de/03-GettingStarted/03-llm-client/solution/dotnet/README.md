<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-16T14:58:48+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "de"
}
-->
# Dieses Beispiel ausführen

> [!NOTE]
> Dieses Beispiel geht davon aus, dass Sie eine GitHub Codespaces-Instanz verwenden. Wenn Sie es lokal ausführen möchten, müssen Sie einen persönlichen Zugriffstoken auf GitHub einrichten.

## Bibliotheken installieren

```sh
dotnet restore
```

Es sollten die folgenden Bibliotheken installiert werden: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol

## Ausführen

```sh 
dotnet run
```

Sie sollten eine Ausgabe ähnlich der folgenden sehen:

```text
Setting up stdio transport
Listing tools
Connected to server with tools: Add
Tool description: Adds two numbers
Tool parameters: {"title":"Add","description":"Adds two numbers","type":"object","properties":{"a":{"type":"integer"},"b":{"type":"integer"}},"required":["a","b"]}
Tool definition: Azure.AI.Inference.ChatCompletionsToolDefinition
Properties: {"a":{"type":"integer"},"b":{"type":"integer"}}
MCP Tools def: 0: Azure.AI.Inference.ChatCompletionsToolDefinition
Tool call 0: Add with arguments {"a":2,"b":4}
Sum 6
```

Ein Großteil der Ausgabe dient nur der Fehlersuche, aber wichtig ist, dass Sie Werkzeuge vom MCP-Server auflisten, diese in LLM-Werkzeuge umwandeln und am Ende eine MCP-Client-Antwort "Sum 6" erhalten.

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir auf Genauigkeit achten, bitten wir zu beachten, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.