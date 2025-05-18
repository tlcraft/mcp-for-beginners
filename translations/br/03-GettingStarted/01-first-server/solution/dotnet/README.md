<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:08:57+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "br"
}
-->
# Executando este exemplo

## -1- Instale as dependências

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Execute o exemplo

```bash
dotnet run
```

## -4- Teste o exemplo

Com o servidor rodando em um terminal, abra outro terminal e execute o seguinte comando:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Isso deve iniciar um servidor web com uma interface visual permitindo que você teste o exemplo.

Uma vez que o servidor estiver conectado:

- tente listar as ferramentas e execute `add`, com os argumentos 2 e 4, você deve ver 6 no resultado.
- vá para recursos e modelo de recurso e chame "greeting", digite um nome e você deve ver uma saudação com o nome que você forneceu.

### Testando no modo CLI

Você pode iniciá-lo diretamente no modo CLI executando o seguinte comando:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Isso listará todas as ferramentas disponíveis no servidor. Você deve ver a seguinte saída:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Para invocar uma ferramenta, digite:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Você deve ver a seguinte saída:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Geralmente é muito mais rápido rodar o inspetor no modo CLI do que no navegador.
> Leia mais sobre o inspetor [aqui](https://github.com/modelcontextprotocol/inspector).

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora busquemos precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.