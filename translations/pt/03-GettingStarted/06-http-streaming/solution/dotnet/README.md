<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-07-13T21:04:00+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "pt"
}
-->
# Executar este exemplo

## -1- Instalar as dependências

```bash
dotnet restore
```

## -2- Executar o exemplo

```bash
dotnet run
```

## -3- Testar o exemplo

Abra um terminal separado antes de executar o comando abaixo (certifique-se de que o servidor continua a funcionar).

Com o servidor a correr num terminal, abra outro terminal e execute o seguinte comando:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Isto deverá iniciar um servidor web com uma interface visual que permite testar o exemplo.

> Certifique-se de que o **Streamable HTTP** está selecionado como tipo de transporte, e que a URL é `http://localhost:3001/mcp`.

Assim que o servidor estiver ligado:

- experimente listar as ferramentas e executar `add`, com os argumentos 2 e 4, deverá ver 6 no resultado.
- vá a resources e resource template e chame "greeting", escreva um nome e deverá ver uma saudação com o nome que forneceu.

### Testar em modo CLI

Pode iniciar diretamente em modo CLI executando o seguinte comando:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Isto irá listar todas as ferramentas disponíveis no servidor. Deverá ver a seguinte saída:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Para invocar uma ferramenta, escreva:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Deverá ver a seguinte saída:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Normalmente é muito mais rápido executar o inspector em modo CLI do que no navegador.
> Leia mais sobre o inspector [aqui](https://github.com/modelcontextprotocol/inspector).

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.