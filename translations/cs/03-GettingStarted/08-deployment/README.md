<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-27T16:20:20+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "cs"
}
-->
# Deploying MCP Servers

Развертывание вашего MCP сервера позволяет другим получить доступ к его инструментам и ресурсам вне вашей локальной среды. Существует несколько стратегий развертывания, которые стоит рассмотреть в зависимости от требований к масштабируемости, надежности и удобству управления. Ниже вы найдете рекомендации по развертыванию MCP серверов локально, в контейнерах и в облаке.

## Overview

В этом уроке рассказывается, как развернуть ваше приложение MCP Server.

## Learning Objectives

К концу урока вы сможете:

- Оценивать различные подходы к развертыванию.
- Развернуть ваше приложение.

## Local development and deployment

Если ваш сервер предназначен для использования на машине пользователя, выполните следующие шаги:

1. **Скачайте сервер**. Если вы не писали сервер, сначала скачайте его на свою машину.  
1. **Запустите процесс сервера**: Запустите ваше приложение MCP server.

Для SSE (не требуется для сервера типа stdio)

1. **Настройте сеть**: Убедитесь, что сервер доступен на ожидаемом порту.  
1. **Подключите клиентов**: Используйте локальные URL подключения, например `http://localhost:3000`.

## Cloud Deployment

MCP серверы можно развернуть на различных облачных платформах:

- **Serverless Functions**: Развертывайте легковесные MCP серверы как безсерверные функции.  
- **Container Services**: Используйте сервисы вроде Azure Container Apps, AWS ECS или Google Cloud Run.  
- **Kubernetes**: Развертывайте и управляйте MCP серверами в кластерах Kubernetes для высокой доступности.

### Example: Azure Container Apps

Azure Container Apps поддерживают развертывание MCP Servers. Это еще в разработке, и в настоящее время поддерживаются SSE серверы.

Вот как это можно сделать:

1. Клонируйте репозиторий:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Запустите локально для тестирования:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Чтобы попробовать локально, создайте файл *mcp.json* в каталоге *.vscode* и добавьте следующий контент:

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

  После запуска SSE сервера вы можете нажать на иконку воспроизведения в JSON файле, теперь инструменты сервера должны определяться GitHub Copilot, смотрите иконку Tool.

1. Для развертывания выполните следующую команду:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Вот и все — разверните локально или в Azure, следуя этим шагам.

## Additional Resources

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)  
- [Azure Container Apps article](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)  
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)  


## What's Next

- Далее: [Practical Implementation](/04-PracticalImplementation/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo mylné výklady vyplývající z použití tohoto překladu.