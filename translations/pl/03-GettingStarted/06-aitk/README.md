<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:37:17+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "pl"
}
-->
# Konsumowanie serwera z rozszerzenia AI Toolkit dla Visual Studio Code

Gdy tworzysz agenta AI, nie chodzi tylko o generowanie inteligentnych odpowiedzi; ważne jest także, aby agent potrafił podejmować działania. W tym pomaga Model Context Protocol (MCP). MCP ułatwia agentom dostęp do zewnętrznych narzędzi i usług w spójny sposób. Można to porównać do podłączenia agenta do skrzynki narzędziowej, z której *naprawdę* może korzystać.

Załóżmy, że podłączysz agenta do serwera MCP kalkulatora. Nagle agent będzie mógł wykonywać operacje matematyczne, otrzymując proste polecenie, np. „Ile to jest 47 razy 89?” — bez konieczności kodowania logiki czy tworzenia niestandardowych API.

## Przegląd

Ta lekcja pokazuje, jak połączyć serwer MCP kalkulatora z agentem za pomocą rozszerzenia [AI Toolkit](https://aka.ms/AIToolkit) w Visual Studio Code, co pozwoli agentowi wykonywać operacje matematyczne takie jak dodawanie, odejmowanie, mnożenie i dzielenie za pomocą języka naturalnego.

AI Toolkit to potężne rozszerzenie dla Visual Studio Code, które upraszcza tworzenie agentów. Inżynierowie AI mogą łatwo budować aplikacje AI, rozwijając i testując modele generatywne AI — lokalnie lub w chmurze. Rozszerzenie obsługuje większość dostępnych obecnie głównych modeli generatywnych.

*Uwaga*: AI Toolkit obecnie wspiera Python i TypeScript.

## Cele nauki

Po ukończeniu tej lekcji będziesz potrafił:

- Konsumować serwer MCP za pomocą AI Toolkit.
- Skonfigurować ustawienia agenta, aby mógł odkrywać i korzystać z narzędzi udostępnianych przez serwer MCP.
- Wykorzystywać narzędzia MCP za pomocą języka naturalnego.

## Podejście

Oto jak powinniśmy podejść do tego na wysokim poziomie:

- Utwórz agenta i zdefiniuj jego systemowy prompt.
- Utwórz serwer MCP z narzędziami kalkulatora.
- Połącz Agent Builder z serwerem MCP.
- Przetestuj wywołania narzędzi agenta za pomocą języka naturalnego.

Świetnie, teraz gdy znamy cały proces, skonfigurujmy agenta AI, aby korzystał z zewnętrznych narzędzi przez MCP, rozszerzając jego możliwości!

## Wymagania wstępne

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit dla Visual Studio Code](https://aka.ms/AIToolkit)

## Ćwiczenie: Konsumowanie serwera

W tym ćwiczeniu zbudujesz, uruchomisz i rozbudujesz agenta AI z narzędziami z serwera MCP w Visual Studio Code, używając AI Toolkit.

### -0- Krok wstępny, dodaj model OpenAI GPT-4o do My Models

Ćwiczenie wykorzystuje model **GPT-4o**. Model powinien zostać dodany do **My Models** przed utworzeniem agenta.

![Zrzut ekranu interfejsu wyboru modelu w rozszerzeniu AI Toolkit dla Visual Studio Code. Nagłówek brzmi „Find the right model for your AI Solution” z podtytułem zachęcającym do odkrywania, testowania i wdrażania modeli AI. Poniżej, w sekcji „Popular Models”, wyświetlonych jest sześć kart modeli: DeepSeek-R1 (hostowany na GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast) oraz DeepSeek-R1 (hostowany na Ollama). Każda karta zawiera opcje „Add” lub „Try in Playground”.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.pl.png)

1. Otwórz rozszerzenie **AI Toolkit** z **Activity Bar**.
1. W sekcji **Catalog** wybierz **Models**, aby otworzyć **Model Catalog**. Wybranie **Models** otwiera **Model Catalog** w nowej karcie edytora.
1. W pasku wyszukiwania **Model Catalog** wpisz **OpenAI GPT-4o**.
1. Kliknij **+ Add**, aby dodać model do listy **My Models**. Upewnij się, że wybrałeś model **Hosted by GitHub**.
1. Na **Activity Bar** sprawdź, czy model **OpenAI GPT-4o** pojawił się na liście.

### -1- Utwórz agenta

**Agent (Prompt) Builder** umożliwia tworzenie i dostosowywanie własnych agentów AI. W tej sekcji utworzysz nowego agenta i przypiszesz mu model do prowadzenia rozmowy.

![Zrzut ekranu interfejsu "Calculator Agent" w AI Toolkit dla Visual Studio Code. W panelu po lewej wybrany model to "OpenAI GPT-4o (via GitHub)". Systemowy prompt brzmi "You are a professor in university teaching math", a prompt użytkownika to "Explain to me the Fourier equation in simple terms." Dodatkowo dostępne są przyciski do dodawania narzędzi, włączania MCP Server i wyboru strukturalnego outputu. Na dole znajduje się niebieski przycisk „Run”. Po prawej, pod „Get Started with Examples”, wymienione są trzy przykładowe agenty: Web Developer (z MCP Server, Second-Grade Simplifier i Dream Interpreter, każdy z krótkim opisem funkcji).](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.pl.png)

1. Otwórz rozszerzenie **AI Toolkit** z **Activity Bar**.
1. W sekcji **Tools** wybierz **Agent (Prompt) Builder**. Wybranie tej opcji otworzy **Agent (Prompt) Builder** w nowej karcie edytora.
1. Kliknij przycisk **+ New Agent**. Rozszerzenie uruchomi kreatora konfiguracji przez **Command Palette**.
1. Wpisz nazwę **Calculator Agent** i naciśnij **Enter**.
1. W **Agent (Prompt) Builder**, w polu **Model** wybierz model **OpenAI GPT-4o (via GitHub)**.

### -2- Utwórz systemowy prompt dla agenta

Gdy agent jest już zainicjowany, czas zdefiniować jego osobowość i cel. W tej sekcji skorzystasz z funkcji **Generate system prompt**, aby opisać zamierzone zachowanie agenta — w tym przypadku agenta kalkulatora — i pozwolić modelowi wygenerować dla niego systemowy prompt.

![Zrzut ekranu interfejsu "Calculator Agent" w AI Toolkit dla Visual Studio Code z otwartym oknem modalnym zatytułowanym „Generate a prompt”. Modal wyjaśnia, że szablon promptu można wygenerować, podając podstawowe informacje. W polu tekstowym znajduje się przykładowy systemowy prompt: „You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.” Poniżej pola są przyciski „Close” i „Generate”. W tle widoczna jest część konfiguracji agenta, w tym wybrany model "OpenAI GPT-4o (via GitHub)" oraz pola na systemowy i użytkownika prompt.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.pl.png)

1. W sekcji **Prompts** kliknij przycisk **Generate system prompt**. Otworzy się kreator promptów, który wykorzystuje AI do wygenerowania systemowego promptu dla agenta.
1. W oknie **Generate a prompt** wpisz: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Kliknij **Generate**. W prawym dolnym rogu pojawi się powiadomienie potwierdzające generowanie promptu. Po zakończeniu wygenerowany prompt pojawi się w polu **System prompt** w **Agent (Prompt) Builder**.
1. Przejrzyj **System prompt** i w razie potrzeby wprowadź zmiany.

### -3- Utwórz serwer MCP

Gdy zdefiniowałeś już systemowy prompt agenta — który kieruje jego zachowaniem i odpowiedziami — czas wyposażyć agenta w praktyczne możliwości. W tej sekcji utworzysz serwer MCP kalkulatora z narzędziami do wykonywania dodawania, odejmowania, mnożenia i dzielenia. Ten serwer pozwoli agentowi wykonywać operacje matematyczne w czasie rzeczywistym, reagując na polecenia w języku naturalnym.

![Zrzut ekranu dolnej części interfejsu Calculator Agent w AI Toolkit dla Visual Studio Code. Widać rozwijane menu „Tools” i „Structure output”, a także menu wyboru formatu wyjścia ustawione na „text”. Po prawej znajduje się przycisk „+ MCP Server” do dodawania serwera Model Context Protocol. Nad sekcją Tools widoczny jest placeholder ikony obrazka.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.pl.png)

AI Toolkit posiada szablony, które ułatwiają tworzenie własnego serwera MCP. Skorzystamy z szablonu Python do utworzenia serwera MCP kalkulatora.

*Uwaga*: AI Toolkit obecnie wspiera Python i TypeScript.

1. W sekcji **Tools** w **Agent (Prompt) Builder** kliknij przycisk **+ MCP Server**. Rozszerzenie uruchomi kreatora konfiguracji przez **Command Palette**.
1. Wybierz **+ Add Server**.
1. Wybierz **Create a New MCP Server**.
1. Wybierz szablon **python-weather**.
1. Wybierz **Default folder**, aby zapisać szablon serwera MCP.
1. Wpisz nazwę serwera: **Calculator**
1. Otworzy się nowe okno Visual Studio Code. Wybierz **Yes, I trust the authors**.
1. W terminalu (**Terminal** > **New Terminal**) utwórz wirtualne środowisko: `python -m venv .venv`
1. W terminalu aktywuj wirtualne środowisko:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. W terminalu zainstaluj zależności: `pip install -e .[dev]`
1. W widoku **Explorer** w **Activity Bar** rozwiń katalog **src** i otwórz plik **server.py**.
1. Zamień zawartość pliku **server.py** na poniższy kod i zapisz:

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

Teraz, gdy agent ma już narzędzia, czas ich użyć! W tej sekcji wyślesz zapytania do agenta, aby przetestować i zweryfikować, czy agent korzysta z odpowiednich narzędzi serwera MCP kalkulatora.

![Zrzut ekranu interfejsu Calculator Agent w AI Toolkit dla Visual Studio Code. W lewym panelu, w sekcji „Tools”, dodany jest serwer MCP o nazwie local-server-calculator_server, pokazujący cztery dostępne narzędzia: add, subtract, multiply i divide. Obok wyświetlana jest odznaka informująca o czterech aktywnych narzędziach. Poniżej jest zwinięta sekcja „Structure output” oraz niebieski przycisk „Run”. W prawym panelu, pod „Model Response”, agent wywołuje narzędzia multiply i subtract z wartościami {"a": 3, "b": 25} i {"a": 75, "b": 20}. Ostateczna „Tool Response” to 75.0. Na dole widoczny jest przycisk „View Code”.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.pl.png)

Będziesz uruchamiać serwer MCP kalkulatora lokalnie na swoim komputerze deweloperskim, korzystając z **Agent Builder** jako klienta MCP.

1. Naciśnij `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` — wartości są przypisane dla narzędzia **subtract**.
    - Odpowiedź z każdego narzędzia pojawi się w odpowiednim polu **Tool Response**.
    - Końcowa odpowiedź modelu pojawi się w polu **Model Response**.
1. Prześlij dodatkowe zapytania, aby dalej testować agenta. Możesz zmodyfikować istniejący prompt w polu **User prompt**, klikając w to pole i zastępując tekst.
1. Po zakończeniu testów możesz zatrzymać serwer w terminalu, wpisując **CTRL/CMD+C**.

## Zadanie

Spróbuj dodać dodatkowe narzędzie do pliku **server.py** (np. funkcję zwracającą pierwiastek kwadratowy liczby). Prześlij zapytania, które zmuszą agenta do użycia nowego (lub istniejących) narzędzi. Pamiętaj, aby ponownie uruchomić serwer, aby załadować nowe narzędzia.

## Rozwiązanie

[Solution](./solution/README.md)

## Najważniejsze wnioski

Najważniejsze wnioski z tego rozdziału to:

- Rozszerzenie AI Toolkit to świetny klient, który pozwala konsumować serwery MCP i ich narzędzia.
- Możesz dodawać nowe narzędzia do serwerów MCP, rozszerzając możliwości agenta zgodnie z rosnącymi potrzebami.
- AI Toolkit zawiera szablony (np. szablony serwerów MCP w Pythonie), które upraszczają tworzenie niestandardowych narzędzi.

## Dodatkowe zasoby

- [Dokumentacja AI Toolkit](https://aka.ms/AIToolkit/doc)

## Co dalej

Następny krok: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do jak największej dokładności, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym powinien być traktowany jako źródło ostateczne. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.