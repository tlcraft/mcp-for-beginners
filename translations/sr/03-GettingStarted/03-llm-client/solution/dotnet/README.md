<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:44:37+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "sr"
}
-->
# Pokreni ovaj primer

> [!NOTE]
> Ovaj primer pretpostavlja da koristite GitHub Codespaces instancu. Ako želite da ga pokrenete lokalno, potrebno je da postavite lični pristupni token na GitHub-u.

## Instaliraj biblioteke

```sh
dotnet restore
```

Treba da instalirate sledeće biblioteke: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol 

## Pokreni

```sh 
dotnet run
```

Trebalo bi da vidite izlaz sličan ovom:

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

Mnogo izlaza je samo debagovanje, ali ono što je važno je da navodite alate sa MCP servera, pretvorite ih u LLM alate i završite sa MCP klijentskim odgovorom "Sum 6".

**Одричање од одговорности**:  
Овај документ је преведен помоћу услуге за превођење путем вештачке интелигенције [Co-op Translator](https://github.com/Azure/co-op-translator). Иако настојимо да постигнемо тачност, молимо вас да будете свесни да аутоматизовани преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати меродавним извором. За критичне информације, препоручује се професионални превод од стране људи. Не преузимамо одговорност за било каква погрешна разумевања или погрешна тумачења настала коришћењем овог превода.