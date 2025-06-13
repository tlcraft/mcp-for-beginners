<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:29:06+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "br"
}
-->
# Deployando Servidores MCP

Deployar seu servidor MCP permite que outras pessoas acessem suas ferramentas e recursos além do seu ambiente local. Existem várias estratégias de deployment a considerar, dependendo das suas necessidades de escalabilidade, confiabilidade e facilidade de gerenciamento. Abaixo você encontrará orientações para deployar servidores MCP localmente, em containers e na nuvem.

## Visão Geral

Esta lição cobre como deployar sua aplicação MCP Server.

## Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:

- Avaliar diferentes abordagens de deployment.
- Deployar sua aplicação.

## Desenvolvimento e deployment local

Se seu servidor deve ser consumido rodando na máquina dos usuários, você pode seguir os seguintes passos:

1. **Baixe o servidor**. Se você não escreveu o servidor, baixe-o primeiro para sua máquina.  
1. **Inicie o processo do servidor**: Rode sua aplicação MCP server.

Para SSE (não necessário para servidores do tipo stdio)

1. **Configure a rede**: Garanta que o servidor esteja acessível na porta esperada.  
1. **Conecte os clientes**: Use URLs de conexão local como `http://localhost:3000`

## Deployment na Nuvem

Servidores MCP podem ser deployados em várias plataformas na nuvem:

- **Serverless Functions**: Deploy de servidores MCP leves como funções serverless  
- **Serviços de Container**: Use serviços como Azure Container Apps, AWS ECS ou Google Cloud Run  
- **Kubernetes**: Deploy e gerenciamento de servidores MCP em clusters Kubernetes para alta disponibilidade

### Exemplo: Azure Container Apps

Azure Container Apps suporta deployment de MCP Servers. Ainda está em desenvolvimento e atualmente suporta servidores SSE.

Veja como proceder:

1. Clone um repositório:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Rode localmente para testar:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Para testar localmente, crie um arquivo *mcp.json* em um diretório *.vscode* e adicione o seguinte conteúdo:

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  Depois que o servidor SSE for iniciado, você pode clicar no ícone de play no arquivo JSON, e deverá ver as ferramentas no servidor sendo reconhecidas pelo GitHub Copilot, veja o ícone da Tool.

1. Para deployar, execute o seguinte comando:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Pronto, deploy localmente ou na Azure seguindo esses passos.

## Recursos Adicionais

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Artigo Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Repositório Azure Container Apps MCP](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## O que vem a seguir

- Próximo: [Implementação Prática](/04-PracticalImplementation/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações equivocadas decorrentes do uso desta tradução.