<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:19:57+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "pt"
}
-->
# Executar este exemplo

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

- Inicie o servidor com o comando `npm run build`.

- Num terminal separado, execute o seguinte comando:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
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

- Invoque um tipo de ferramenta digitando o seguinte comando:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Deverá ver a seguinte saída:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> Normalmente é muito mais rápido executar o inspector em modo CLI do que no navegador.
> Leia mais sobre o inspector [aqui](https://github.com/modelcontextprotocol/inspector).

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.