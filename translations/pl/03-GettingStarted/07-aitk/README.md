<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-04T17:12:45+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "pl"
}
-->
# Korzystanie z serwera z rozszerzenia AI Toolkit dla Visual Studio Code

Budując agenta AI, nie chodzi tylko o generowanie inteligentnych odpowiedzi; ważne jest także, aby agent potrafił podejmować działania. W tym pomaga Model Context Protocol (MCP). MCP ułatwia agentom dostęp do zewnętrznych narzędzi i usług w spójny sposób. Można to porównać do podłączenia agenta do skrzynki z narzędziami, z której *naprawdę* może korzystać.

Załóżmy, że podłączysz agenta do serwera MCP kalkulatora. Nagle agent będzie mógł wykonywać działania matematyczne, otrzymując proste polecenia, takie jak „Ile to jest 47 razy 89?” — bez potrzeby kodowania logiki czy tworzenia niestandardowych API.

## Przegląd

Ta lekcja pokazuje, jak połączyć serwer MCP kalkulatora z agentem za pomocą rozszerzenia [AI Toolkit](https://aka.ms/AIToolkit) w Visual Studio Code, umożliwiając agentowi wykonywanie działań matematycznych, takich jak dodawanie, odejmowanie, mnożenie i dzielenie, za pomocą języka naturalnego.

AI Toolkit to potężne rozszerzenie dla Visual Studio Code, które usprawnia tworzenie agentów. Inżynierowie AI mogą łatwo budować aplikacje AI, rozwijając i testując modele generatywnej sztucznej inteligencji — lokalnie lub w chmurze. Rozszerzenie obsługuje większość popularnych modeli generatywnych dostępnych obecnie na rynku.

*Uwaga*: AI Toolkit obecnie wspiera Python i TypeScript.

## Cele nauki

Po ukończeniu tej lekcji będziesz potrafił:

- Korzystać z serwera MCP za pomocą AI Toolkit.
- Skonfigurować agenta tak, aby mógł odnajdywać i wykorzystywać narzędzia udostępniane przez serwer MCP.
- Wykorzystywać narzędzia MCP za pomocą języka naturalnego.

## Podejście

Oto jak powinniśmy podejść do tego na wysokim poziomie:

- Utwórz agenta i zdefiniuj jego systemowy prompt.
- Stwórz serwer MCP z narzędziami kalkulatora.
- Połącz Agent Builder z serwerem MCP.
- Przetestuj wywoływanie narzędzi agenta za pomocą języka naturalnego.

Świetnie, skoro znamy już ogólny przebieg, skonfigurujmy agenta AI, aby korzystał z zewnętrznych narzędzi przez MCP, zwiększając jego możliwości!

## Wymagania wstępne

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit dla Visual Studio Code](https://aka.ms/AIToolkit)

## Ćwiczenie: Korzystanie z serwera

W tym ćwiczeniu zbudujesz, uruchomisz i rozbudujesz agenta AI o narzędzia z serwera MCP w Visual Studio Code, korzystając z AI Toolkit.

### -0- Krok wstępny, dodaj model OpenAI GPT-4o do Moich modeli

Ćwiczenie wykorzystuje model **GPT-4o**. Model powinien zostać dodany do **Moich modeli** przed utworzeniem agenta.

![Zrzut ekranu interfejsu wyboru modelu w rozszerzeniu AI Toolkit dla Visual Studio Code. Nagłówek brzmi „Find the right model for your AI Solution” z podtytułem zachęcającym do odkrywania, testowania i wdrażania modeli AI. Poniżej, w sekcji „Popular Models”, wyświetlonych jest sześć kart modeli: DeepSeek-R1 (hostowany na GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast) oraz DeepSeek-R1 (hostowany na Ollama). Każda karta zawiera opcje „Add” lub „Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.pl.png)

1. Otwórz rozszerzenie **AI Toolkit** z **paska aktywności**.
2. W sekcji **Catalog** wybierz **Models**, aby otworzyć **Model Catalog**. Wybranie **Models** otworzy **Model Catalog** w nowej karcie edytora.
3. W pasku wyszukiwania **Model Catalog** wpisz **OpenAI GPT-4o**.
4. Kliknij **+ Add**, aby dodać model do listy **My Models**. Upewnij się, że wybrałeś model **hostowany przez GitHub**.
5. Na **pasku aktywności** sprawdź, czy model **OpenAI GPT-4o** pojawił się na liście.

### -1- Utwórz agenta

**Agent (Prompt) Builder** pozwala tworzyć i dostosowywać własnych agentów zasilanych AI. W tej sekcji utworzysz nowego agenta i przypiszesz mu model, który będzie napędzał rozmowę.

![Zrzut ekranu interfejsu „Calculator Agent” w rozszerzeniu AI Toolkit dla Visual Studio Code. Po lewej stronie wybrany model to „OpenAI GPT-4o (via GitHub)”. Systemowy prompt brzmi „You are a professor in university teaching math”, a prompt użytkownika to „Explain to me the Fourier equation in simple terms.” Dodatkowe opcje to przyciski do dodawania narzędzi, włączania MCP Server oraz wybór strukturalnego outputu. Na dole znajduje się niebieski przycisk „Run”. Po prawej stronie, w sekcji „Get Started with Examples”, wymienione są trzy przykładowe agenty: Web Developer (z MCP Server, Second-Grade Simplifier i Dream Interpreter, każdy z krótkim opisem funkcji).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.pl.png)

1. Otwórz rozszerzenie **AI Toolkit** z **paska aktywności**.
2. W sekcji **Tools** wybierz **Agent (Prompt) Builder**. Wybranie tej opcji otworzy **Agent (Prompt) Builder** w nowej karcie edytora.
3. Kliknij przycisk **+ New Agent**. Rozszerzenie uruchomi kreatora konfiguracji przez **Command Palette**.
4. Wpisz nazwę **Calculator Agent** i naciśnij **Enter**.
5. W polu **Model** w **Agent (Prompt) Builder** wybierz model **OpenAI GPT-4o (via GitHub)**.

### -2- Utwórz systemowy prompt dla agenta

Po utworzeniu szkieletu agenta czas zdefiniować jego osobowość i cel. W tej sekcji użyjesz funkcji **Generate system prompt**, aby opisać zamierzone zachowanie agenta — w tym przypadku agenta kalkulatora — i pozwolić modelowi wygenerować systemowy prompt.

![Zrzut ekranu interfejsu „Calculator Agent” w AI Toolkit dla Visual Studio Code z otwartym oknem modalnym zatytułowanym „Generate a prompt”. Modal wyjaśnia, że szablon promptu można wygenerować, podając podstawowe informacje, i zawiera pole tekstowe z przykładowym systemowym promptem: „You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.” Poniżej pola znajdują się przyciski „Close” i „Generate”. W tle widoczna jest część konfiguracji agenta, w tym wybrany model „OpenAI GPT-4o (via GitHub)” oraz pola na systemowy i użytkownika prompt.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.pl.png)

1. W sekcji **Prompts** kliknij przycisk **Generate system prompt**. Otworzy się kreator promptów, który wykorzystuje AI do wygenerowania systemowego promptu dla agenta.
2. W oknie **Generate a prompt** wpisz: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Kliknij przycisk **Generate**. W prawym dolnym rogu pojawi się powiadomienie potwierdzające generowanie promptu. Po zakończeniu prompt pojawi się w polu **System prompt** w **Agent (Prompt) Builder**.
4. Przejrzyj wygenerowany **System prompt** i w razie potrzeby go zmodyfikuj.

### -3- Utwórz serwer MCP

Teraz, gdy zdefiniowałeś systemowy prompt agenta — który kieruje jego zachowaniem i odpowiedziami — czas wyposażyć agenta w praktyczne możliwości. W tej sekcji stworzysz serwer MCP kalkulatora z narzędziami do wykonywania działań dodawania, odejmowania, mnożenia i dzielenia. Serwer ten pozwoli agentowi wykonywać obliczenia w czasie rzeczywistym na podstawie poleceń w języku naturalnym.

![Zrzut ekranu dolnej części interfejsu Calculator Agent w rozszerzeniu AI Toolkit dla Visual Studio Code. Widać rozwijane menu „Tools” i „Structure output” oraz rozwijaną listę „Choose output format” ustawioną na „text”. Po prawej znajduje się przycisk „+ MCP Server” do dodawania serwera Model Context Protocol. Nad sekcją Tools widoczny jest symbol zastępczy ikony obrazu.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.pl.png)

AI Toolkit jest wyposażony w szablony ułatwiające tworzenie własnych serwerów MCP. Skorzystamy z szablonu Pythona do stworzenia serwera MCP kalkulatora.

*Uwaga*: AI Toolkit obecnie wspiera Python i TypeScript.

1. W sekcji **Tools** w **Agent (Prompt) Builder** kliknij przycisk **+ MCP Server**. Rozszerzenie uruchomi kreatora konfiguracji przez **Command Palette**.
2. Wybierz **+ Add Server**.
3. Wybierz **Create a New MCP Server**.
4. Wybierz szablon **python-weather**.
5. Wybierz **Default folder** do zapisania szablonu serwera MCP.
6. Wpisz nazwę serwera: **Calculator**
7. Otworzy się nowe okno Visual Studio Code. Wybierz **Yes, I trust the authors**.
8. W terminalu (**Terminal** > **New Terminal**) utwórz środowisko wirtualne: `python -m venv .venv`
9. Aktywuj środowisko wirtualne w terminalu:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. Zainstaluj zależności: `pip install -e .[dev]`
11. W widoku **Explorer** na **pasku aktywności** rozwiń katalog **src** i otwórz plik **server.py**.
12. Zamień zawartość pliku **server.py** na poniższy kod i zapisz:

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

Teraz, gdy agent ma narzędzia, czas z nich skorzystać! W tej sekcji wyślesz do agenta polecenia, aby przetestować i zweryfikować, czy agent korzysta z odpowiednich narzędzi serwera MCP kalkulatora.

![Zrzut ekranu interfejsu Calculator Agent w rozszerzeniu AI Toolkit dla Visual Studio Code. Po lewej, w sekcji „Tools”, dodany jest serwer MCP o nazwie local-server-calculator_server, pokazujący cztery dostępne narzędzia: add, subtract, multiply i divide. Widoczna jest odznaka informująca o czterech aktywnych narzędziach. Poniżej znajduje się zwinięta sekcja „Structure output” oraz niebieski przycisk „Run”. Po prawej, w sekcji „Model Response”, agent wywołuje narzędzia multiply i subtract z danymi wejściowymi {"a": 3, "b": 25} oraz {"a": 75, "b": 20}. Końcowa „Tool Response” to 75.0. Na dole widoczny jest przycisk „View Code”.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.pl.png)

Uruchomisz serwer MCP kalkulatora lokalnie na swoim komputerze deweloperskim, korzystając z **Agent Builder** jako klienta MCP.

1. Naciśnij `F5`, aby rozpocząć debugowanie serwera MCP. **Agent (Prompt) Builder** otworzy się w nowej karcie edytora. Status serwera jest widoczny w terminalu.
2. W polu **User prompt** w **Agent (Prompt) Builder** wpisz: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
3. Kliknij przycisk **Run**, aby wygenerować odpowiedź agenta.
4. Przejrzyj odpowiedź agenta. Model powinien dojść do wniosku, że zapłaciłeś **55 dolarów**.
5. Oto, co powinno się wydarzyć:
    - Agent wybiera narzędzia **multiply** i **subtract**, aby pomóc w obliczeniach.
    - Przypisywane są odpowiednie wartości `a` i `b` dla narzędzia **multiply**.
    - Przypisywane są odpowiednie wartości `a` i `b` dla narzędzia **subtract**.
    - Odpowiedzi z każdego narzędzia są zwracane w polu **Tool Response**.
    - Końcowa odpowiedź modelu pojawia się w polu **Model Response**.
6. Wysyłaj kolejne polecenia, aby dalej testować agenta. Możesz zmienić istniejący prompt w polu **User prompt**, klikając w pole i wpisując nowy tekst.
7. Po zakończeniu testów możesz zatrzymać serwer w terminalu, naciskając **CTRL/CMD+C**.

## Zadanie

Spróbuj dodać dodatkowe narzędzie do pliku **server.py** (np. zwracające pierwiastek kwadratowy z liczby). Wysyłaj kolejne polecenia, które będą wymagały od agenta użycia nowego narzędzia (lub istniejących). Pamiętaj, aby zrestartować serwer, aby załadować nowe narzędzia.

## Rozwiązanie

[Rozwiązanie](./solution/README.md)

## Najważniejsze wnioski

Najważniejsze wnioski z tego rozdziału to:

- Rozszerzenie AI Toolkit to świetny klient, który pozwala korzystać z serwerów MCP i ich narzędzi.
- Możesz dodawać nowe narzędzia do serwerów MCP, rozszerzając możliwości agenta, aby sprostać zmieniającym się wymaganiom.
- AI Toolkit zawiera szablony (np. szablony serwerów MCP w Pythonie), które upraszczają tworzenie własnych narzędzi.

## Dodatkowe zasoby

- [Dokumentacja AI Toolkit](https://aka.ms/AIToolkit/doc)

## Co dalej
- Następny temat: [Testowanie i debugowanie](../08-testing/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do jak największej dokładności, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.