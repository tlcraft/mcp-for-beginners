<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-07-13T18:05:02+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "pt"
}
-->
# Executar este exemplo

Recomenda-se instalar o `uv`, mas não é obrigatório, veja as [instruções](https://docs.astral.sh/uv/#highlights)

## -1- Instalar as dependências

```bash
npm install
```

## -3- Executar o exemplo

```bash
npm run build
```

## -4- Testar o exemplo

Com o servidor a correr num terminal, abra outro terminal e execute o seguinte comando:

```bash
npm run inspector
```

Isto deverá iniciar um servidor web com uma interface visual que lhe permite testar o exemplo.

Assim que o servidor estiver ligado:

- experimente listar as ferramentas e executar `add`, com os argumentos 2 e 4, deverá ver 6 no resultado.
- vá a resources e resource template e chame "greeting", escreva um nome e deverá ver uma saudação com o nome que forneceu.

### Testar em modo CLI

O inspector que executou é na verdade uma aplicação Node.js e o `mcp dev` é um wrapper à sua volta.

Pode lançá-lo diretamente em modo CLI executando o seguinte comando:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Isto irá listar todas as ferramentas disponíveis no servidor. Deverá ver a seguinte saída:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

Para invocar uma ferramenta, escreva:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em atenção que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.