<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:31:58+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "cs"
}
-->
# Развёртывание MCP серверов

Развёртывание вашего MCP сервера позволяет другим получить доступ к его инструментам и ресурсам за пределами вашей локальной среды. Существует несколько стратегий развёртывания, которые стоит учитывать в зависимости от требований к масштабируемости, надёжности и удобству управления. Ниже вы найдёте рекомендации по развёртыванию MCP серверов локально, в контейнерах и в облаке.

## Обзор

В этом уроке рассматривается, как развернуть ваше MCP Server приложение.

## Цели обучения

К концу этого урока вы сможете:

- Оценивать различные подходы к развёртыванию.
- Развернуть ваше приложение.

## Локальная разработка и развёртывание

Если ваш сервер предназначен для использования на машинах пользователей, вы можете следовать следующим шагам:

1. **Скачать сервер**. Если вы не писали сервер, сначала скачайте его на свою машину.  
1. **Запустить серверный процесс**: Запустите ваше MCP серверное приложение.

Для SSE (не требуется для серверов типа stdio)

1. **Настроить сеть**: Убедитесь, что сервер доступен на ожидаемом порту.  
1. **Подключить клиентов**: Используйте локальные URL подключения, такие как `http://localhost:3000`.

## Облачное развёртывание

MCP серверы можно развернуть на различных облачных платформах:

- **Serverless функции**: Развёртывание лёгких MCP серверов в виде serverless функций.  
- **Контейнерные сервисы**: Использование таких сервисов, как Azure Container Apps, AWS ECS или Google Cloud Run.  
- **Kubernetes**: Развёртывание и управление MCP серверами в кластерах Kubernetes для высокой доступности.

### Пример: Azure Container Apps

Azure Container Apps поддерживают развёртывание MCP серверов. Это всё ещё в разработке, и на данный момент поддерживаются SSE серверы.

Вот как это можно сделать:

1. Клонируйте репозиторий:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Запустите локально, чтобы протестировать:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Чтобы попробовать локально, создайте файл *mcp.json* в директории *.vscode* и добавьте следующий контент:

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

  После запуска SSE сервера вы можете нажать на иконку запуска в JSON-файле, теперь инструменты сервера будут распознаваться GitHub Copilot, смотрите иконку Tool.

1. Для развёртывания выполните следующую команду:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Вот и всё, разверните локально или в Azure, следуя этим шагам.

## Дополнительные ресурсы

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Статья про Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Репозиторий Azure Container Apps MCP](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Что дальше

- Далее: [Практическая реализация](/04-PracticalImplementation/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.