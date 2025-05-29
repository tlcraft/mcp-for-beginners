<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c37fabfbc0dcbc9a4afb6d17e7d3be9f",
  "translation_date": "2025-05-29T20:23:32+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "br"
}
-->
Vamos falar mais sobre como usamos a interface visual nas próximas seções.

## Abordagem

Aqui está como precisamos abordar isso em um nível geral:

- Configurar um arquivo para localizar nosso MCP Server.
- Iniciar/Conectar ao servidor para que ele liste suas capacidades.
- Usar essas capacidades através da interface de chat do GitHub Copilot.

Ótimo, agora que entendemos o fluxo, vamos tentar usar um MCP Server pelo Visual Studio Code através de um exercício.

## Exercício: Consumindo um servidor

Neste exercício, vamos configurar o Visual Studio Code para localizar seu MCP Server para que ele possa ser usado na interface de chat do GitHub Copilot.

### -0- Passo prévio, habilitar descoberta do MCP Server

Você pode precisar habilitar a descoberta dos MCP Servers.

1. Vá em `File -> Preferences -> Settings` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` no arquivo settings.json.

### -1- Criar arquivo de configuração

Comece criando um arquivo de configuração na raiz do seu projeto, você precisará de um arquivo chamado MCP.json e colocá-lo em uma pasta chamada .vscode. Deve ficar assim:

```text
.vscode
|-- mcp.json
```

Agora, vamos ver como adicionar uma entrada de servidor.

### -2- Configurar um servidor

Adicione o seguinte conteúdo ao *mcp.json*:

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "cmd",
           "args": [
               "/c", "node", "<absolute path>\\build\\index.js"
           ]
       }
    }
}
```

Acima há um exemplo simples de como iniciar um servidor escrito em Node.js; para outras linguagens, indique o comando correto para iniciar o servidor usando `command` and `args`.

### -3- Iniciar o servidor

Agora que você adicionou uma entrada, vamos iniciar o servidor:

1. Localize sua entrada em *mcp.json* e certifique-se de encontrar o ícone de "play":

  ![Iniciando servidor no Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.br.png)  

2. Clique no ícone de "play", você verá o ícone de ferramentas no chat do GitHub Copilot aumentar o número de ferramentas disponíveis. Se clicar nesse ícone, verá a lista de ferramentas registradas. Você pode marcar/desmarcar cada ferramenta dependendo se deseja que o GitHub Copilot as use como contexto:

  ![Iniciando servidor no Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.br.png)

3. Para executar uma ferramenta, digite um prompt que você saiba que corresponde à descrição de uma das suas ferramentas, por exemplo um prompt como "add 22 to 1":

  ![Executando uma ferramenta do GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.br.png)

  Você deve ver uma resposta dizendo 23.

## Tarefa

Tente adicionar uma entrada de servidor no seu arquivo *mcp.json* e certifique-se de que pode iniciar/parar o servidor. Também garanta que consiga se comunicar com as ferramentas no seu servidor via interface de chat do GitHub Copilot.

## Solução

[Solution](./solution/README.md)

## Principais aprendizados

Os principais aprendizados deste capítulo são:

- Visual Studio Code é um ótimo cliente que permite consumir vários MCP Servers e suas ferramentas.
- A interface de chat do GitHub Copilot é como você interage com os servidores.
- Você pode solicitar ao usuário entradas como chaves de API que podem ser passadas ao MCP Server ao configurar a entrada do servidor no arquivo *mcp.json*.

## Exemplos

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Recursos adicionais

- [Visual Studio docs](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## O que vem a seguir

- Próximo: [Criando um SSE Server](/03-GettingStarted/05-sse-server/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte oficial. Para informações críticas, recomenda-se a tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.