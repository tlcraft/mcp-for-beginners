<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:41:08+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "br"
}
-->
# Executando o exemplo

Aqui assumimos que você já tem um código de servidor funcionando. Por favor, localize um servidor de um dos capítulos anteriores.

## Configurando o mcp.json

Aqui está um arquivo que você pode usar como referência, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Altere a entrada do servidor conforme necessário para indicar o caminho absoluto do seu servidor, incluindo o comando completo necessário para executar.

No arquivo de exemplo mencionado acima, a entrada do servidor é assim:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Isso corresponde a executar um comando como: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` digite algo como "add 3 to 20".

    Você deverá ver uma ferramenta sendo apresentada acima da caixa de texto do chat, indicando que você pode selecioná-la para executar a ferramenta, como nesta imagem:

    ![VS Code indicando que quer executar uma ferramenta](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.br.png)

    Selecionar a ferramenta deve produzir um resultado numérico dizendo "23" se seu prompt foi como mencionamos anteriormente.

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações equivocadas decorrentes do uso desta tradução.