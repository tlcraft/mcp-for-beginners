<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:40:32+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "pt"
}
-->
# Execute este exemplo

> [!NOTE]
> Este exemplo assume que você está usando uma instância do GitHub Codespaces. Se você quiser executá-lo localmente, precisa configurar um token de acesso pessoal no GitHub.

## Instalar bibliotecas

```sh
dotnet restore
```

Deve instalar as seguintes bibliotecas: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol 

## Executar

```sh 
dotnet run
```

Você deverá ver uma saída similar a:

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

Grande parte da saída é apenas depuração, mas o importante é que você está listando ferramentas do MCP Server, transformando-as em ferramentas LLM e acaba com uma resposta do cliente MCP "Sum 6".

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, é recomendada a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações errôneas decorrentes do uso desta tradução.