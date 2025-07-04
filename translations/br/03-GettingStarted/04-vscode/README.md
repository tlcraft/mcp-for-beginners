<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "54e9ffc5dba01afcb8880a9949fd1881",
  "translation_date": "2025-07-04T17:00:57+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "br"
}
-->
Vamos falar mais sobre como usamos a interface visual nas próximas seções.

## Abordagem

Aqui está como precisamos abordar isso em um nível geral:

- Configurar um arquivo para localizar nosso MCP Server.
- Iniciar/Conectar ao servidor para que ele liste suas capacidades.
- Usar essas capacidades através da interface do GitHub Copilot Chat.

Ótimo, agora que entendemos o fluxo, vamos tentar usar um MCP Server pelo Visual Studio Code através de um exercício.

## Exercício: Consumindo um servidor

Neste exercício, vamos configurar o Visual Studio Code para encontrar seu MCP server para que ele possa ser usado pela interface do GitHub Copilot Chat.

### -0- Passo prévio, habilitar descoberta do MCP Server

Pode ser necessário habilitar a descoberta dos MCP Servers.

1. Vá em `Arquivo -> Preferências -> Configurações` no Visual Studio Code.

1. Procure por "MCP" e habilite `chat.mcp.discovery.enabled` no arquivo settings.json.

### -1- Criar arquivo de configuração

Comece criando um arquivo de configuração na raiz do seu projeto, você precisará de um arquivo chamado MCP.json dentro de uma pasta chamada .vscode. Deve ficar assim:

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
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

Aqui está um exemplo simples de como iniciar um servidor escrito em Node.js, para outras plataformas indique o comando correto para iniciar o servidor usando `command` e `args`.

### -3- Iniciar o servidor

Agora que você adicionou uma entrada, vamos iniciar o servidor:

1. Localize sua entrada em *mcp.json* e certifique-se de encontrar o ícone de "play":

  ![Iniciando servidor no Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.br.png)  

1. Clique no ícone de "play", você deve ver o ícone de ferramentas no GitHub Copilot Chat aumentar o número de ferramentas disponíveis. Se clicar nesse ícone de ferramentas, verá uma lista das ferramentas registradas. Você pode marcar/desmarcar cada ferramenta dependendo se quer que o GitHub Copilot as use como contexto:

  ![Iniciando servidor no Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.br.png)

1. Para executar uma ferramenta, digite um prompt que você sabe que corresponde à descrição de uma das suas ferramentas, por exemplo um prompt como "add 22 to 1":

  ![Executando uma ferramenta pelo GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.br.png)

  Você deve ver uma resposta dizendo 23.

## Tarefa

Tente adicionar uma entrada de servidor no seu arquivo *mcp.json* e certifique-se de que consegue iniciar/parar o servidor. Também verifique se consegue se comunicar com as ferramentas do seu servidor via interface do GitHub Copilot Chat.

## Solução

[Solução](./solution/README.md)

## Principais aprendizados

Os principais aprendizados deste capítulo são:

- Visual Studio Code é um ótimo cliente que permite consumir vários MCP Servers e suas ferramentas.
- A interface do GitHub Copilot Chat é como você interage com os servidores.
- Você pode solicitar ao usuário entradas como chaves de API que podem ser passadas para o MCP Server ao configurar a entrada do servidor no arquivo *mcp.json*.

## Exemplos

- [Calculadora Java](../samples/java/calculator/README.md)
- [Calculadora .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](../samples/javascript/README.md)
- [Calculadora TypeScript](../samples/typescript/README.md)
- [Calculadora Python](../../../../03-GettingStarted/samples/python)

## Recursos adicionais

- [Documentação do Visual Studio](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## O que vem a seguir

- Próximo: [Criando um servidor SSE](../05-sse-server/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.