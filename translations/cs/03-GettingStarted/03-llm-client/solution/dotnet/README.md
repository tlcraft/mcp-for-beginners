<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:43:53+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "cs"
}
-->
# Spusťte tento příklad

> [!NOTE]
> Tento příklad předpokládá, že používáte instance GitHub Codespaces. Pokud chcete spustit tento příklad lokálně, musíte si na GitHubu nastavit osobní přístupový token.

## Instalace knihoven

```sh
dotnet restore
```

Měly by se nainstalovat následující knihovny: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol 

## Spuštění

```sh 
dotnet run
```

Měli byste vidět výstup podobný:

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

Velká část výstupu je jen ladění, ale důležité je, že uvádíte nástroje ze serveru MCP, tyto nástroje přeměníte na nástroje LLM a skončíte s odpovědí klienta MCP "Sum 6".

**Upozornění**:  
Tento dokument byl přeložen pomocí služby pro automatický překlad [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, mějte na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.