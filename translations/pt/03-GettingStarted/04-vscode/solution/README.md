<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:39:45+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "pt"
}
-->
# Executar o exemplo

Aqui assumimos que já tem um código de servidor funcional. Por favor, localize um servidor de um dos capítulos anteriores.

## Configurar o mcp.json

Aqui está um ficheiro que pode usar como referência, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Altere a entrada do servidor conforme necessário para indicar o caminho absoluto para o seu servidor, incluindo o comando completo necessário para executar.

No ficheiro de exemplo referido acima, a entrada do servidor é assim:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Isto corresponde a executar um comando como este: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` escreva algo como "add 3 to 20".

    Deve ver uma ferramenta apresentada acima da caixa de texto do chat, indicando para selecionar para executar a ferramenta, como nesta imagem:

    ![VS Code indicando que quer executar uma ferramenta](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.pt.png)

    Selecionar a ferramenta deverá produzir um resultado numérico dizendo "23" se o seu prompt for como mencionámos anteriormente.

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte oficial. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações erradas decorrentes da utilização desta tradução.