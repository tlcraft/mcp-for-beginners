<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:51:50+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "pt"
}
-->
# Implantando Servidores MCP

Implantar seu servidor MCP permite que outros acessem suas ferramentas e recursos além do seu ambiente local. Existem várias estratégias de implantação a considerar, dependendo dos seus requisitos de escalabilidade, confiabilidade e facilidade de gerenciamento. Abaixo você encontrará orientações para implantar servidores MCP localmente, em contêineres e na nuvem.

## Visão Geral

Esta lição aborda como implantar seu aplicativo de Servidor MCP.

## Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:

- Avaliar diferentes abordagens de implantação.
- Implantar seu aplicativo.

## Desenvolvimento e Implantação Local

Se o seu servidor deve ser executado na máquina dos usuários, você pode seguir os seguintes passos:

1. **Baixar o servidor**. Se você não escreveu o servidor, baixe-o primeiro para sua máquina.
1. **Iniciar o processo do servidor**: Execute seu aplicativo de servidor MCP.

Para SSE (não necessário para servidor tipo stdio)

1. **Configurar a rede**: Certifique-se de que o servidor está acessível na porta esperada.
1. **Conectar clientes**: Use URLs de conexão local como `http://localhost:3000`.

## Implantação na Nuvem

Servidores MCP podem ser implantados em várias plataformas de nuvem:

- **Funções Serverless**: Implante servidores MCP leves como funções serverless.
- **Serviços de Contêiner**: Use serviços como Azure Container Apps, AWS ECS ou Google Cloud Run.
- **Kubernetes**: Implemente e gerencie servidores MCP em clusters Kubernetes para alta disponibilidade.

### Exemplo: Azure Container Apps

Azure Container Apps oferece suporte à implantação de Servidores MCP. Ainda está em desenvolvimento e atualmente suporta servidores SSE.

Veja como você pode proceder:

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

  Uma vez que o servidor SSE for iniciado, você pode clicar no ícone de play no arquivo JSON, você deve agora ver as ferramentas no servidor sendo captadas pelo GitHub Copilot, veja o ícone de Ferramenta.

1. Para implantar, execute o seguinte comando:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Pronto, implante localmente, implante no Azure através desses passos.

## Recursos Adicionais

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Artigo sobre Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Repositório Azure Container Apps MCP](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## O Que Vem a Seguir

- Próximo: [Implementação Prática](/04-PracticalImplementation/README.md)

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritativa. Para informações críticas, recomenda-se uma tradução humana profissional. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações errôneas decorrentes do uso desta tradução.