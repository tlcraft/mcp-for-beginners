<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:44:07+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "sk"
}
-->
# Spustite tento príklad

> [!NOTE]
> Tento príklad predpokladá, že používate inštanciu GitHub Codespaces. Ak ho chcete spustiť lokálne, musíte si nastaviť osobný prístupový token na GitHube.

## Inštalácia knižníc

```sh
dotnet restore
```

Mali by ste nainštalovať nasledujúce knižnice: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtocol

## Spustenie

```sh 
dotnet run
```

Mali by ste vidieť výstup podobný:

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

Veľa z výstupu je len ladenie, ale dôležité je, že vypisujete nástroje zo servera MCP, premeníte ich na nástroje LLM a skončíte s odpoveďou klienta MCP "Sum 6".

**Upozornenie**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, vezmite prosím na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nezodpovedáme za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.