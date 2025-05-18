<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:55:13+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "pt"
}
-->
# Executando este exemplo

## -1- Instale as dependências

```bash
dotnet run
```

## -2- Execute o exemplo

```bash
dotnet run
```

## -3- Teste o exemplo

Inicie um terminal separado antes de executar o comando abaixo (certifique-se de que o servidor ainda está em execução).

Com o servidor rodando em um terminal, abra outro terminal e execute o seguinte comando:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Isso deve iniciar um servidor web com uma interface visual que permite testar o exemplo.

Uma vez conectado ao servidor:

- tente listar as ferramentas e execute `add`, com os argumentos 2 e 4, você deverá ver 6 no resultado.
- vá para recursos e modelo de recurso e chame "greeting", digite um nome e você deverá ver uma saudação com o nome que você forneceu.

### Testando no modo CLI

Você pode iniciá-lo diretamente no modo CLI executando o seguinte comando:

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
> Geralmente é muito mais rápido executar o inspetor no modo CLI do que no navegador.
> Leia mais sobre o inspetor [aqui](https://github.com/modelcontextprotocol/inspector).

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automatizadas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritária. Para informações críticas, recomenda-se a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.