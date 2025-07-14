<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:40:05+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "pl"
}
-->
# Generator planu nauki z Chainlit i Microsoft Learn Docs MCP

## Wymagania wstępne

- Python 3.8 lub nowszy
- pip (menedżer pakietów Pythona)
- Dostęp do internetu, aby połączyć się z serwerem Microsoft Learn Docs MCP

## Instalacja

1. Sklonuj to repozytorium lub pobierz pliki projektu.
2. Zainstaluj wymagane zależności:

   ```bash
   pip install -r requirements.txt
   ```

## Użytkowanie

### Scenariusz 1: Proste zapytanie do Docs MCP  
Klient wiersza poleceń, który łączy się z serwerem Docs MCP, wysyła zapytanie i wyświetla wynik.

1. Uruchom skrypt:  
   ```bash
   python scenario1.py
   ```  
2. Wprowadź swoje pytanie dotyczące dokumentacji w wyświetlonym wierszu poleceń.

### Scenariusz 2: Generator planu nauki (aplikacja webowa Chainlit)  
Interfejs webowy (oparty na Chainlit), który pozwala użytkownikom wygenerować spersonalizowany, tygodniowy plan nauki dla dowolnego tematu technicznego.

1. Uruchom aplikację Chainlit:  
   ```bash
   chainlit run scenario2.py
   ```  
2. Otwórz lokalny adres URL podany w terminalu (np. http://localhost:8000) w przeglądarce.  
3. W oknie czatu wpisz temat nauki oraz liczbę tygodni, przez które chcesz się uczyć (np. „certyfikacja AI-900, 8 tygodni”).  
4. Aplikacja odpowie tygodniowym planem nauki, zawierającym linki do odpowiedniej dokumentacji Microsoft Learn.

**Wymagane zmienne środowiskowe:**  

Aby korzystać ze Scenariusza 2 (aplikacji webowej Chainlit z Azure OpenAI), musisz ustawić następujące zmienne środowiskowe w pliku `.env` w katalogu `python`:

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Wypełnij te wartości danymi swojego zasobu Azure OpenAI przed uruchomieniem aplikacji.

> **Tip:** Możesz łatwo wdrożyć własne modele korzystając z [Azure AI Foundry](https://ai.azure.com/).

### Scenariusz 3: Dokumentacja w edytorze z serwerem MCP w VS Code

Zamiast przełączać się między kartami przeglądarki, aby szukać dokumentacji, możesz mieć Microsoft Learn Docs bezpośrednio w VS Code dzięki serwerowi MCP. Pozwala to na:  
- Wyszukiwanie i czytanie dokumentacji w VS Code bez opuszczania środowiska kodowania.  
- Odwoływanie się do dokumentacji i wstawianie linków bezpośrednio do plików README lub materiałów kursu.  
- Korzystanie z GitHub Copilot i MCP razem, tworząc płynny, wspierany AI workflow dokumentacyjny.

**Przykładowe zastosowania:**  
- Szybkie dodawanie linków referencyjnych do README podczas pisania dokumentacji kursu lub projektu.  
- Używanie Copilota do generowania kodu i MCP do natychmiastowego znajdowania i cytowania odpowiednich dokumentów.  
- Skupienie się na pracy w edytorze i zwiększenie produktywności.

> [!IMPORTANT]  
> Upewnij się, że masz poprawną konfigurację [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) w swoim workspace (lokalizacja to `.vscode/mcp.json`).

## Dlaczego Chainlit dla Scenariusza 2?

Chainlit to nowoczesny, open-source’owy framework do tworzenia konwersacyjnych aplikacji webowych. Umożliwia łatwe tworzenie interfejsów czatu, które łączą się z usługami backendowymi, takimi jak Microsoft Learn Docs MCP. Ten projekt wykorzystuje Chainlit, aby zapewnić prosty, interaktywny sposób generowania spersonalizowanych planów nauki w czasie rzeczywistym. Dzięki Chainlit możesz szybko budować i wdrażać narzędzia czatowe, które zwiększają produktywność i efektywność nauki.

## Co to robi

Ta aplikacja pozwala użytkownikom stworzyć spersonalizowany plan nauki, wystarczy wpisać temat i czas trwania. Aplikacja analizuje Twoje dane wejściowe, wysyła zapytanie do serwera Microsoft Learn Docs MCP o odpowiednie materiały i organizuje wyniki w przejrzysty, tygodniowy plan. Zalecenia na każdy tydzień są wyświetlane w czacie, co ułatwia śledzenie postępów. Integracja gwarantuje, że zawsze otrzymujesz najnowsze i najbardziej adekwatne materiały do nauki.

## Przykładowe zapytania

Wypróbuj te zapytania w oknie czatu, aby zobaczyć, jak aplikacja odpowiada:

- `certyfikacja AI-900, 8 tygodni`  
- `Nauka Azure Functions, 4 tygodnie`  
- `Azure DevOps, 6 tygodni`  
- `Inżynieria danych na Azure, 10 tygodni`  
- `Podstawy bezpieczeństwa Microsoft, 5 tygodni`  
- `Power Platform, 7 tygodni`  
- `Usługi Azure AI, 12 tygodni`  
- `Architektura chmury, 9 tygodni`

Te przykłady pokazują elastyczność aplikacji dla różnych celów i ram czasowych nauki.

## Źródła

- [Chainlit Documentation](https://docs.chainlit.io/)  
- [MCP Documentation](https://github.com/MicrosoftDocs/mcp)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do jak największej dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.