<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:31:09+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "pl"
}
-->
# Studium przypadku: Udostępnianie REST API w API Management jako serwer MCP

Azure API Management to usługa, która zapewnia bramę nad Twoimi punktami końcowymi API. Działa ona jak proxy przed Twoimi API i może decydować, co zrobić z przychodzącymi żądaniami.

Korzystając z niej, zyskujesz szereg funkcji, takich jak:

- **Bezpieczeństwo** – możesz używać wszystkiego, od kluczy API, JWT po zarządzaną tożsamość.
- **Ograniczanie liczby wywołań** – świetna funkcja pozwalająca określić, ile wywołań może przejść w określonym czasie. Pomaga to zapewnić wszystkim użytkownikom dobrą jakość obsługi oraz chroni usługę przed przeciążeniem.
- **Skalowanie i równoważenie obciążenia** – możesz skonfigurować wiele punktów końcowych, aby rozłożyć obciążenie, a także zdecydować, jak ma działać równoważenie.
- **Funkcje AI, takie jak semantyczne buforowanie, limit tokenów i monitorowanie tokenów oraz inne**. To świetne funkcje, które poprawiają szybkość reakcji oraz pomagają kontrolować zużycie tokenów. [Dowiedz się więcej tutaj](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Dlaczego MCP + Azure API Management?

Model Context Protocol szybko staje się standardem dla agentowych aplikacji AI oraz sposobem na spójne udostępnianie narzędzi i danych. Azure API Management to naturalny wybór, gdy potrzebujesz „zarządzać” API. Serwery MCP często integrują się z innymi API, aby na przykład rozwiązywać żądania do narzędzi. Dlatego połączenie Azure API Management i MCP ma dużo sensu.

## Przegląd

W tym konkretnym przypadku użycia nauczymy się, jak udostępnić punkty końcowe API jako serwer MCP. Dzięki temu możemy łatwo uczynić te punkty częścią agentowej aplikacji, jednocześnie korzystając z funkcji Azure API Management.

## Kluczowe funkcje

- Wybierasz metody punktu końcowego, które chcesz udostępnić jako narzędzia.
- Dodatkowe funkcje zależą od tego, co skonfigurujesz w sekcji polityk dla swojego API. Tutaj pokażemy, jak dodać ograniczanie liczby wywołań.

## Krok wstępny: import API

Jeśli masz już API w Azure API Management, świetnie, możesz pominąć ten krok. Jeśli nie, sprawdź ten link: [importowanie API do Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Udostępnianie API jako serwer MCP

Aby udostępnić punkty końcowe API, wykonaj następujące kroki:

1. Przejdź do Azure Portal pod adresem <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
   Przejdź do swojej instancji API Management.

1. W lewym menu wybierz APIs > MCP Servers > + Create new MCP Server.

1. W API wybierz REST API, które chcesz udostępnić jako serwer MCP.

1. Wybierz jedną lub więcej operacji API, które chcesz udostępnić jako narzędzia. Możesz wybrać wszystkie operacje lub tylko wybrane.

    ![Wybierz metody do udostępnienia](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Wybierz **Create**.

1. Przejdź do menu **APIs** i **MCP Servers**, powinieneś zobaczyć następujące:

    ![Zobacz serwer MCP w głównym panelu](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    Serwer MCP został utworzony, a operacje API udostępnione jako narzędzia. Serwer MCP jest widoczny na liście MCP Servers. Kolumna URL pokazuje punkt końcowy serwera MCP, który możesz wywołać do testów lub w aplikacji klienckiej.

## Opcjonalnie: Konfiguracja polityk

Azure API Management opiera się na koncepcji polityk, gdzie definiujesz różne zasady dla swoich punktów końcowych, np. ograniczanie liczby wywołań czy semantyczne buforowanie. Polityki są definiowane w formacie XML.

Oto jak możesz ustawić politykę ograniczającą liczbę wywołań dla serwera MCP:

1. W portalu, w sekcji APIs, wybierz **MCP Servers**.

1. Wybierz utworzony serwer MCP.

1. W lewym menu, pod MCP, wybierz **Policies**.

1. W edytorze polityk dodaj lub edytuj polityki, które chcesz zastosować do narzędzi serwera MCP. Polityki definiuje się w formacie XML. Na przykład, możesz dodać politykę ograniczającą wywołania narzędzi serwera MCP (w tym przykładzie 5 wywołań na 30 sekund na adres IP klienta). Oto XML, który to realizuje:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Oto obraz edytora polityk:

    ![Edytor polityk](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Wypróbuj

Sprawdźmy, czy nasz serwer MCP działa zgodnie z oczekiwaniami.

Do tego użyjemy Visual Studio Code oraz GitHub Copilot w trybie agenta. Dodamy serwer MCP do pliku *mcp.json*. Dzięki temu Visual Studio Code będzie działać jako klient z możliwościami agentowymi, a użytkownicy końcowi będą mogli wpisywać polecenia i wchodzić w interakcję z serwerem.

Zobaczmy, jak dodać serwer MCP w Visual Studio Code:

1. Użyj polecenia MCP: **Add Server** z Command Palette.

1. Po wyświetleniu monitu wybierz typ serwera: **HTTP (HTTP lub Server Sent Events)**.

1. Wprowadź URL serwera MCP w API Management. Przykład: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (dla punktu końcowego SSE) lub **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (dla punktu końcowego MCP), zwróć uwagę na różnicę w transporcie: `/sse` lub `/mcp`.

1. Wprowadź dowolny identyfikator serwera. Nie jest to wartość krytyczna, ale pomoże Ci zapamiętać, czym jest ta instancja serwera.

1. Wybierz, czy zapisać konfigurację w ustawieniach workspace czy użytkownika.

  - **Ustawienia workspace** – konfiguracja serwera jest zapisywana w pliku .vscode/mcp.json dostępnym tylko w bieżącym workspace.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    lub jeśli wybierzesz streaming HTTP jako transport, będzie to wyglądać nieco inaczej:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **Ustawienia użytkownika** – konfiguracja serwera jest dodawana do globalnego pliku *settings.json* i jest dostępna we wszystkich workspace. Konfiguracja wygląda mniej więcej tak:

    ![Ustawienia użytkownika](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Musisz także dodać konfigurację nagłówka, aby poprawnie uwierzytelnić się w Azure API Management. Używa on nagłówka o nazwie **Ocp-Apim-Subscription-Key**.

    - Oto jak możesz dodać go do ustawień:

    ![Dodawanie nagłówka do uwierzytelniania](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), spowoduje to wyświetlenie monitu o podanie wartości klucza API, który znajdziesz w Azure Portal dla swojej instancji Azure API Management.

   - Aby dodać go do *mcp.json*, możesz zrobić to tak:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Użyj trybu agenta

Teraz, gdy wszystko jest skonfigurowane w ustawieniach lub w *.vscode/mcp.json*, wypróbujmy to.

Powinien pojawić się ikonka Narzędzi, gdzie widoczne są udostępnione narzędzia z Twojego serwera:

![Narzędzia z serwera](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Kliknij ikonę narzędzi, powinieneś zobaczyć listę narzędzi:

    ![Narzędzia](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Wpisz polecenie w czacie, aby wywołać narzędzie. Na przykład, jeśli wybrałeś narzędzie do pobierania informacji o zamówieniu, możesz zapytać agenta o zamówienie. Oto przykładowe polecenie:

    ```text
    get information from order 2
    ```

    Teraz pojawi się ikona narzędzi z prośbą o potwierdzenie wywołania narzędzia. Wybierz, aby kontynuować, a zobaczysz wynik podobny do tego:

    ![Wynik z polecenia](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **to, co zobaczysz powyżej, zależy od skonfigurowanych narzędzi, ale idea jest taka, że otrzymujesz odpowiedź tekstową, jak powyżej**

## Źródła

Oto gdzie możesz dowiedzieć się więcej:

- [Samouczek o Azure API Management i MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Przykład w Python: Bezpieczne zdalne serwery MCP z użyciem Azure API Management (eksperymentalne)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Laboratorium autoryzacji klienta MCP](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Użyj rozszerzenia Azure API Management dla VS Code do importu i zarządzania API](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Rejestracja i odkrywanie zdalnych serwerów MCP w Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Świetne repozytorium pokazujące wiele możliwości AI z Azure API Management
- [Warsztaty AI Gateway](https://azure-samples.github.io/AI-Gateway/) Zawiera warsztaty z użyciem Azure Portal, co jest świetnym sposobem na rozpoczęcie oceny możliwości AI.

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.