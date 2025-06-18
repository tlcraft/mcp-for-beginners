<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:17:19+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "br"
}
-->
# Executando este exemplo

## -1- Instale as dependências

```bash
dotnet restore
```

## -2- Execute o exemplo

```bash
dotnet run
```

## -3- Teste o exemplo

Abra um terminal separado antes de executar o comando abaixo (certifique-se de que o servidor ainda está rodando).

Com o servidor rodando em um terminal, abra outro terminal e execute o seguinte comando:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Isso deve iniciar um servidor web com uma interface visual que permite testar o exemplo.

> Certifique-se de que o **Streamable HTTP** está selecionado como tipo de transporte, e que a URL seja `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`, com os argumentos 2 e 4, você deverá ver 6 no resultado.
- vá para resources e resource template e chame "greeting", digite um nome e você verá uma saudação com o nome que forneceu.

### Testando no modo CLI

Você pode iniciar diretamente no modo CLI executando o seguinte comando:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Isso listará todas as ferramentas disponíveis no servidor. Você deverá ver a seguinte saída:

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

Para invocar uma ferramenta, digite:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Você deverá ver a seguinte saída:

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
> Geralmente é muito mais rápido executar o inspector no modo CLI do que no navegador.
> Leia mais sobre o inspector [aqui](https://github.com/modelcontextprotocol/inspector).

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.