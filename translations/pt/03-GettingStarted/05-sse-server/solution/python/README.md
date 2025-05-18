<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:02:17+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "pt"
}
-->
# Executando este exemplo

Recomenda-se instalar `uv`, mas não é obrigatório, veja [instruções](https://docs.astral.sh/uv/#highlights)

## -0- Crie um ambiente virtual

```bash
python -m venv venv
```

## -1- Ative o ambiente virtual

```bash
venv\Scrips\activate
```

## -2- Instale as dependências

```bash
pip install "mcp[cli]"
```

## -3- Execute o exemplo

```bash
mcp run server.py
```

## -4- Teste o exemplo

Com o servidor rodando em um terminal, abra outro terminal e execute o seguinte comando:

```bash
mcp dev server.py
```

Isso deve iniciar um servidor web com uma interface visual que permite testar o exemplo.

Uma vez que o servidor estiver conectado:

- tente listar ferramentas e executar `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` é um wrapper ao redor dele.

Você pode iniciá-lo diretamente no modo CLI executando o seguinte comando:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Isso irá listar todas as ferramentas disponíveis no servidor. Você deve ver o seguinte resultado:

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

Para invocar uma ferramenta, digite:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Você deve ver o seguinte resultado:

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
Este documento foi traduzido usando o serviço de tradução de IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automatizadas podem conter erros ou imprecisões. O documento original em sua língua nativa deve ser considerado a fonte autoritária. Para informações críticas, recomenda-se a tradução humana profissional. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.