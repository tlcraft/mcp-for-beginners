<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-29T20:21:51+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "br"
}
-->
# Deploying MCP Servers

Deployar seu servidor MCP permite que outras pessoas acessem suas ferramentas e recursos além do seu ambiente local. Existem várias estratégias de deploy a considerar, dependendo das suas necessidades de escalabilidade, confiabilidade e facilidade de gerenciamento. Abaixo você encontra orientações para deploy de servidores MCP localmente, em containers e na nuvem.

## Overview

Esta lição cobre como fazer o deploy do seu app MCP Server.

## Learning Objectives

Ao final desta lição, você será capaz de:

- Avaliar diferentes abordagens de deploy.
- Fazer o deploy do seu app.

## Local development and deployment

Se seu servidor for para ser usado rodando na máquina dos usuários, você pode seguir os passos abaixo:

1. **Baixe o servidor**. Se você não escreveu o servidor, faça o download dele para sua máquina.
1. **Inicie o processo do servidor**: Execute sua aplicação MCP server

Para SSE (não necessário para servidor do tipo stdio)

1. **Configure a rede**: Garanta que o servidor esteja acessível na porta esperada
1. **Conecte os clientes**: Use URLs de conexão locais como `http://localhost:3000`

## Cloud Deployment

Servidores MCP podem ser deployados em várias plataformas de nuvem:

- **Serverless Functions**: Faça deploy de servidores MCP leves como funções serverless
- **Container Services**: Use serviços como Azure Container Apps, AWS ECS ou Google Cloud Run
- **Kubernetes**: Faça deploy e gerencie servidores MCP em clusters Kubernetes para alta disponibilidade

### Example: Azure Container Apps

Azure Container Apps suporta o deploy de MCP Servers. Ainda está em desenvolvimento e atualmente suporta servidores SSE.

Veja como proceder:

1. Clone um repositório:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Execute localmente para testar:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Para testar localmente, crie um arquivo *mcp.json* dentro de um diretório *.vscode* e adicione o seguinte conteúdo:

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

  Quando o servidor SSE estiver rodando, você pode clicar no ícone de play no arquivo JSON, e agora deve ver as ferramentas no servidor sendo detectadas pelo GitHub Copilot, veja o ícone de Tool.

1. Para fazer o deploy, execute o seguinte comando:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Pronto, faça o deploy localmente ou na Azure seguindo esses passos.

## Additional Resources

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps article](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## What's Next

- Next: [Practical Implementation](/04-PracticalImplementation/README.md)

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte oficial. Para informações críticas, recomenda-se a tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.