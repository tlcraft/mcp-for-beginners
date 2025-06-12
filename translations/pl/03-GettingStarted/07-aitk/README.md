<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-12T22:29:56+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "pl"
}
-->
# Korzystanie z serwera z rozszerzenia AI Toolkit dla Visual Studio Code

Tworząc agenta AI, nie chodzi tylko o generowanie inteligentnych odpowiedzi; ważne jest także, aby agent potrafił podejmować działania. Właśnie tutaj wchodzi w grę Model Context Protocol (MCP). MCP ułatwia agentom dostęp do zewnętrznych narzędzi i usług w spójny sposób. Można to porównać do podłączenia agenta do skrzynki z narzędziami, z której naprawdę może korzystać.

Załóżmy, że podłączysz agenta do serwera MCP kalkulatora. Nagle twój agent będzie mógł wykonywać działania matematyczne, otrzymując proste polecenie, takie jak „Ile to jest 47 razy 89?” — bez konieczności kodowania logiki czy tworzenia niestandardowych API.

## Przegląd

Ta lekcja pokazuje, jak połączyć serwer MCP kalkulatora z agentem za pomocą rozszerzenia [AI Toolkit](https://aka.ms/AIToolkit) w Visual Studio Code, umożliwiając agentowi wykonywanie działań matematycznych, takich jak dodawanie, odejmowanie, mnożenie i dzielenie, za pomocą języka naturalnego.

AI Toolkit to potężne rozszerzenie dla Visual Studio Code, które usprawnia tworzenie agentów. Inżynierowie AI mogą łatwo budować aplikacje AI, rozwijając i testując modele generatywne AI — lokalnie lub w chmurze. Rozszerzenie obsługuje większość popularnych modeli generatywnych dostępnych obecnie.

*Uwaga*: AI Toolkit obecnie wspiera Python i TypeScript.

## Cele nauki

Po zakończeniu tej lekcji będziesz potrafił:

- Korzystać z serwera MCP za pomocą AI Toolkit.
- Skonfigurować konfigurację agenta, aby mógł wykrywać i używać narzędzi udostępnionych przez serwer MCP.
- Wykorzystywać narzędzia MCP za pomocą języka naturalnego.

## Podejście

Oto ogólny sposób postępowania:

- Utwórz agenta i zdefiniuj jego systemowy prompt.
- Utwórz serwer MCP z narzędziami kalkulatora.
- Połącz Agent Builder z serwerem MCP.
- Przetestuj wywołania narzędzi agenta za pomocą języka naturalnego.

Świetnie, teraz gdy znamy ogólny przebieg, skonfigurujmy agenta AI, aby mógł korzystać z zewnętrznych narzędzi przez MCP, rozszerzając jego możliwości!

## Wymagania wstępne

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## Ćwiczenie: Korzystanie z serwera

W tym ćwiczeniu zbudujesz, uruchomisz i rozbudujesz agenta AI z narzędziami z serwera MCP w Visual Studio Code, korzystając z AI Toolkit.

### -0- Krok wstępny, dodaj model OpenAI GPT-4o do My Models

Ćwiczenie wykorzystuje model **GPT-4o**. Model należy dodać do **My Models** przed utworzeniem agenta.

![Zrzut ekranu interfejsu wyboru modelu w rozszerzeniu AI Toolkit dla Visual Studio Code. Nagłówek brzmi "Find the right model for your AI Solution" z podtytułem zachęcającym do odkrywania, testowania i wdrażania modeli AI. Poniżej, w sekcji „Popular Models,” wyświetlonych jest sześć kart modeli: DeepSeek-R1 (hostowany na GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast) oraz DeepSeek-R1 (hostowany na Ollama). Każda karta zawiera opcje „Add” lub „Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.pl.png)

1. Otwórz rozszerzenie **AI Toolkit** z **Activity Bar**.
1. W sekcji **Catalog** wybierz **Models**, aby otworzyć **Model Catalog**. Wybranie **Models** otworzy **Model Catalog** na nowej karcie edytora.
1. W pasku wyszukiwania **Model Catalog** wpisz **OpenAI GPT-4o**.
1. Kliknij **+ Add**, aby dodać model do listy **My Models**. Upewnij się, że wybrałeś model **Hosted by GitHub**.
1. W **Activity Bar** potwierdź, że model **OpenAI GPT-4o** pojawił się na liście.

### -1- Utwórz agenta

**Agent (Prompt) Builder** pozwala tworzyć i dostosowywać własnych agentów AI. W tej sekcji utworzysz nowego agenta i przypiszesz model do obsługi konwersacji.

![Zrzut ekranu interfejsu „Calculator Agent” w AI Toolkit dla Visual Studio Code. Po lewej panel, wybrany model to "OpenAI GPT-4o (via GitHub)." Systemowy prompt brzmi "You are a professor in university teaching math," a prompt użytkownika to "Explain to me the Fourier equation in simple terms." Dodatkowe opcje to przyciski do dodawania narzędzi, włączania MCP Server i wyboru strukturalnego outputu. Na dole niebieski przycisk „Run.” Po prawej panel „Get Started with Examples” z trzema przykładowymi agentami: Web Developer (z MCP Server, Second-Grade Simplifier i Dream Interpreter), każdy z krótkim opisem funkcji.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.pl.png)

1. Otwórz rozszerzenie **AI Toolkit** z **Activity Bar**.
1. W sekcji **Tools** wybierz **Agent (Prompt) Builder**. Wybranie tej opcji otworzy **Agent (Prompt) Builder** na nowej karcie edytora.
1. Kliknij przycisk **+ New Agent**. Rozszerzenie uruchomi kreatora konfiguracji przez **Command Palette**.
1. Wprowadź nazwę **Calculator Agent** i naciśnij **Enter**.
1. W **Agent (Prompt) Builder**, w polu **Model** wybierz model **OpenAI GPT-4o (via GitHub)**.

### -2- Utwórz systemowy prompt dla agenta

Po utworzeniu szkieletu agenta czas zdefiniować jego osobowość i cel. W tej sekcji użyjesz funkcji **Generate system prompt**, aby opisać zamierzone zachowanie agenta — w tym przypadku agenta kalkulatora — i pozwolić modelowi wygenerować systemowy prompt.

![Zrzut ekranu interfejsu „Calculator Agent” w AI Toolkit dla Visual Studio Code z otwartym oknem modalnym zatytułowanym „Generate a prompt.” Modal wyjaśnia, że szablon promptu można wygenerować, podając podstawowe informacje, i zawiera pole tekstowe z przykładowym promptem systemowym: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Poniżej pola są przyciski „Close” i „Generate.” W tle widoczna jest część konfiguracji agenta, w tym wybrany model "OpenAI GPT-4o (via GitHub)" oraz pola promptów systemowego i użytkownika.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.pl.png)

1. W sekcji **Prompts** kliknij przycisk **Generate system prompt**. Otworzy on kreatora promptów, który wykorzystuje AI do wygenerowania promptu systemowego dla agenta.
1. W oknie **Generate a prompt** wpisz: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Kliknij przycisk **Generate**. W prawym dolnym rogu pojawi się powiadomienie potwierdzające generowanie promptu. Po zakończeniu wygenerowany prompt pojawi się w polu **System prompt** w **Agent (Prompt) Builder**.
1. Przejrzyj **System prompt** i w razie potrzeby zmodyfikuj.

### -3- Utwórz serwer MCP

Teraz, gdy zdefiniowałeś systemowy prompt agenta — który kieruje jego zachowaniem i odpowiedziami — czas wyposażyć agenta w praktyczne możliwości. W tej sekcji utworzysz serwer MCP kalkulatora z narzędziami do wykonywania działań dodawania, odejmowania, mnożenia i dzielenia. Ten serwer pozwoli twojemu agentowi wykonywać działania matematyczne w czasie rzeczywistym w odpowiedzi na polecenia w języku naturalnym.

![Zrzut ekranu dolnej części interfejsu Calculator Agent w AI Toolkit dla Visual Studio Code. Widoczne są rozwijane menu „Tools” i „Structure output” oraz rozwijane menu „Choose output format” ustawione na „text.” Po prawej przycisk „+ MCP Server” do dodania serwera Model Context Protocol. Powyżej sekcji Tools jest miejsce na ikonę obrazu.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.pl.png)

AI Toolkit posiada szablony ułatwiające tworzenie własnych serwerów MCP. W tym przypadku użyjemy szablonu Python do stworzenia serwera MCP kalkulatora.

*Uwaga*: AI Toolkit obecnie wspiera Python i TypeScript.

1. W sekcji **Tools** w **Agent (Prompt) Builder** kliknij przycisk **+ MCP Server**. Rozszerzenie uruchomi kreatora konfiguracji przez **Command Palette**.
1. Wybierz **+ Add Server**.
1. Wybierz **Create a New MCP Server**.
1. Wybierz szablon **python-weather**.
1. Wybierz **Default folder** do zapisania szablonu serwera MCP.
1. Wprowadź nazwę serwera: **Calculator**
1. Otworzy się nowe okno Visual Studio Code. Wybierz **Yes, I trust the authors**.
1. W terminalu (**Terminal** > **New Terminal**) utwórz środowisko wirtualne: `python -m venv .venv`
1. W terminalu aktywuj środowisko wirtualne:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. W terminalu zainstaluj zależności: `pip install -e .[dev]`
1. W widoku **Explorer** w **Activity Bar** rozwiń katalog **src** i otwórz plik **server.py** w edytorze.
1. Zamień kod w pliku **server.py** na poniższy i zapisz:

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- Uruchom agenta z serwerem MCP kalkulatora

Teraz, gdy twój agent ma narzędzia, czas z nich skorzystać! W tej sekcji wyślesz prompt do agenta, aby przetestować i sprawdzić, czy agent wykorzystuje odpowiednie narzędzie z serwera MCP kalkulatora.

![Zrzut ekranu interfejsu Calculator Agent w AI Toolkit dla Visual Studio Code. Po lewej, w sekcji „Tools,” dodany jest serwer MCP o nazwie local-server-calculator_server, pokazujący cztery dostępne narzędzia: add, subtract, multiply i divide. Obok jest odznaka informująca, że cztery narzędzia są aktywne. Poniżej jest zwinięta sekcja „Structure output” i niebieski przycisk „Run.” Po prawej, w sekcji „Model Response,” agent wywołuje narzędzia multiply i subtract z danymi wejściowymi {"a": 3, "b": 25} oraz {"a": 75, "b": 20}. Ostateczna odpowiedź narzędzia to 75.0. Na dole jest przycisk „View Code.”](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.pl.png)

Uruchomisz serwer MCP kalkulatora lokalnie na swojej maszynie developerskiej za pomocą **Agent Builder** jako klienta MCP.

1. Naciśnij `F5`
1. W polu **User prompt** wpisz pytanie, np.: „Kupiłem 3 przedmioty po 25 dolarów każdy, a następnie użyłem rabatu 20 dolarów. Ile zapłaciłem?”.
1. Wartości `a` i `b` zostaną przypisane dla narzędzia **subtract**.
    - Odpowiedź z każdego narzędzia pojawi się w sekcji **Tool Response**.
    - Końcowy wynik modelu pojawi się w sekcji **Model Response**.
1. Wysyłaj kolejne polecenia, aby dalej testować agenta. Możesz zmieniać istniejący prompt w polu **User prompt**, klikając w pole i zastępując go nowym tekstem.
1. Po zakończeniu testów możesz zatrzymać serwer w terminalu, naciskając **CTRL/CMD+C**.

## Zadanie

Spróbuj dodać nowe narzędzie do pliku **server.py** (np. obliczające pierwiastek kwadratowy liczby). Wyślij dodatkowe polecenia, które będą wymagały od agenta skorzystania z twojego nowego narzędzia (lub istniejących). Pamiętaj, aby zrestartować serwer, aby załadować nowe narzędzia.

## Rozwiązanie

[Solution](./solution/README.md)

## Najważniejsze wnioski

Najważniejsze punkty z tego rozdziału to:

- Rozszerzenie AI Toolkit to świetny klient pozwalający korzystać z serwerów MCP i ich narzędzi.
- Możesz dodawać nowe narzędzia do serwerów MCP, rozszerzając możliwości agenta, by sprostać zmieniającym się wymaganiom.
- AI Toolkit zawiera szablony (np. dla serwerów MCP w Pythonie), które upraszczają tworzenie własnych narzędzi.

## Dodatkowe zasoby

- [Dokumentacja AI Toolkit](https://aka.ms/AIToolkit/doc)

## Co dalej
- Dalej: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy wszelkich starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w jego rodzimym języku powinien być uważany za źródło wiarygodne. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.