<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-12T22:12:10+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "pl"
}
-->
# Deployowanie serwerów MCP

Deployowanie serwera MCP umożliwia innym dostęp do jego narzędzi i zasobów poza Twoim lokalnym środowiskiem. Istnieje kilka strategii wdrożenia, które warto rozważyć, w zależności od wymagań dotyczących skalowalności, niezawodności i łatwości zarządzania. Poniżej znajdziesz wskazówki dotyczące deployowania serwerów MCP lokalnie, w kontenerach oraz w chmurze.

## Przegląd

Ta lekcja omawia, jak wdrożyć aplikację MCP Server.

## Cele nauki

Po zakończeniu tej lekcji będziesz potrafił:

- Ocenić różne podejścia do wdrożenia.
- Wdrożyć swoją aplikację.

## Lokalny rozwój i wdrożenie

Jeśli Twój serwer ma działać na komputerze użytkownika, możesz postępować według następujących kroków:

1. **Pobierz serwer**. Jeśli nie napisałeś serwera, pobierz go najpierw na swój komputer.  
1. **Uruchom proces serwera**: Wystartuj swoją aplikację MCP Server.

Dla SSE (nie jest potrzebne dla serwera typu stdio):

1. **Skonfiguruj sieć**: Upewnij się, że serwer jest dostępny na oczekiwanym porcie.  
1. **Połącz klientów**: Użyj lokalnych adresów URL, takich jak `http://localhost:3000`.

## Wdrożenie w chmurze

Serwery MCP można wdrażać na różnych platformach chmurowych:

- **Funkcje serverless**: Wdrażaj lekkie serwery MCP jako funkcje serverless.  
- **Usługi kontenerowe**: Korzystaj z usług takich jak Azure Container Apps, AWS ECS czy Google Cloud Run.  
- **Kubernetes**: Wdrażaj i zarządzaj serwerami MCP w klastrach Kubernetes dla wysokiej dostępności.

### Przykład: Azure Container Apps

Azure Container Apps wspiera wdrażanie serwerów MCP. Projekt jest wciąż rozwijany i obecnie obsługuje serwery SSE.

Oto jak możesz to zrobić:

1. Sklonuj repozytorium:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Uruchom lokalnie, aby przetestować:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Aby przetestować lokalnie, utwórz plik *mcp.json* w katalogu *.vscode* i dodaj następującą zawartość:

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

  Po uruchomieniu serwera SSE możesz kliknąć ikonę odtwarzania w pliku JSON, wtedy narzędzia serwera powinny zostać wykryte przez GitHub Copilot, zobacz ikonę narzędzia.

1. Aby wdrożyć, uruchom następujące polecenie:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

I gotowe – wdrażaj lokalnie lub do Azure, postępując według tych kroków.

## Dodatkowe materiały

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)  
- [Artykuł o Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)  
- [Repozytorium Azure Container Apps MCP](https://github.com/anthonychu/azure-container-apps-mcp-sample)  

## Co dalej

- Dalej: [Praktyczna implementacja](/04-PracticalImplementation/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było precyzyjne, prosimy pamiętać, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym należy traktować jako źródło wiążące. W przypadku informacji krytycznych zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.