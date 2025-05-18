<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:43:37+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "hu"
}
-->
# Futtasd ezt a mintát

> [!NOTE]
> Ez a minta feltételezi, hogy GitHub Codespaces példányt használ. Ha helyileg szeretnéd futtatni, be kell állítanod egy személyes hozzáférési tokent a GitHubon.

## Könyvtárak telepítése

```sh
dotnet restore
```

A következő könyvtárakat kell telepíteni: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol

## Futás

```sh 
dotnet run
```

Hasonló kimenetet kell látnod:

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

A kimenet nagy része csak hibakeresés, de ami fontos, hogy az MCP Server eszközeit listázod, ezeket LLM eszközökké alakítod, és az eredmény egy MCP kliens válasz "Sum 6".

**Felelősségkizárás**:  
Ezt a dokumentumot a [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítási szolgáltatással fordították. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentumot annak eredeti nyelvén kell tekinteni a hiteles forrásnak. Kritikus információk esetén javasolt a professzionális emberi fordítás. Nem vállalunk felelősséget az ezen fordítás használatából eredő félreértésekért vagy téves értelmezésekért.