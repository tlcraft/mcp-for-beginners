<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-16T14:55:24+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "pl"
}
-->
## Rozpoczęcie  

Ta sekcja składa się z kilku lekcji:

- **-1- Twój pierwszy serwer**, w tej pierwszej lekcji nauczysz się, jak stworzyć swój pierwszy serwer i sprawdzić go za pomocą narzędzia inspektora, co jest cennym sposobem na testowanie i debugowanie serwera, [do lekcji](/03-GettingStarted/01-first-server/README.md)

- **-2- Klient**, w tej lekcji nauczysz się, jak napisać klienta, który może połączyć się z twoim serwerem, [do lekcji](/03-GettingStarted/02-client/README.md)

- **-3- Klient z LLM**, jeszcze lepszym sposobem na napisanie klienta jest dodanie do niego LLM, aby mógł „negocjować” z twoim serwerem, co zrobić, [do lekcji](/03-GettingStarted/03-llm-client/README.md)

- **-4- Konsumowanie trybu GitHub Copilot Agent serwera w Visual Studio Code**. Tutaj pokazujemy, jak uruchomić nasz MCP Server bezpośrednio w Visual Studio Code, [do lekcji](/03-GettingStarted/04-vscode/README.md)

- **-5- Konsumowanie z SSE (Server Sent Events)** SSE to standard do strumieniowania danych z serwera do klienta, pozwalający serwerom wysyłać aktualizacje w czasie rzeczywistym do klientów przez HTTP [do lekcji](/03-GettingStarted/05-sse-server/README.md)

- **-6- Wykorzystanie AI Toolkit dla VSCode** do konsumowania i testowania twoich MCP Klientów i Serwerów [do lekcji](/03-GettingStarted/06-aitk/README.md)

- **-7 Testowanie**. Tutaj skupimy się szczególnie na tym, jak testować nasz serwer i klienta na różne sposoby, [do lekcji](/03-GettingStarted/07-testing/README.md)

- **-8- Wdrażanie**. Ten rozdział pokaże różne sposoby wdrażania twoich rozwiązań MCP, [do lekcji](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) to otwarty protokół, który standaryzuje sposób, w jaki aplikacje dostarczają kontekst do LLM. Można porównać MCP do portu USB-C dla aplikacji AI – zapewnia ustandaryzowany sposób łączenia modeli AI z różnymi źródłami danych i narzędziami.

## Cele nauki

Pod koniec tej lekcji będziesz potrafił:

- Skonfigurować środowiska programistyczne dla MCP w C#, Java, Python, TypeScript i JavaScript
- Budować i wdrażać podstawowe serwery MCP z niestandardowymi funkcjami (zasoby, podpowiedzi i narzędzia)
- Tworzyć aplikacje hostujące, które łączą się z serwerami MCP
- Testować i debugować implementacje MCP
- Zrozumieć typowe wyzwania związane z konfiguracją i ich rozwiązania
- Łączyć swoje implementacje MCP z popularnymi usługami LLM

## Konfiguracja środowiska MCP

Zanim zaczniesz pracę z MCP, ważne jest, aby przygotować środowisko programistyczne i zrozumieć podstawowy przepływ pracy. Ta sekcja poprowadzi cię przez pierwsze kroki konfiguracji, aby zapewnić płynny start z MCP.

### Wymagania wstępne

Zanim zaczniesz rozwijać MCP, upewnij się, że masz:

- **Środowisko programistyczne**: dla wybranego języka (C#, Java, Python, TypeScript lub JavaScript)
- **IDE/Edytor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm lub dowolny nowoczesny edytor kodu
- **Menedżery pakietów**: NuGet, Maven/Gradle, pip lub npm/yarn
- **Klucze API**: do usług AI, które planujesz wykorzystać w swoich aplikacjach hostujących


### Oficjalne SDK

W kolejnych rozdziałach zobaczysz rozwiązania oparte na Pythonie, TypeScript, Javie i .NET. Oto wszystkie oficjalnie wspierane SDK.

MCP udostępnia oficjalne SDK dla wielu języków:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - utrzymywane we współpracy z Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - utrzymywane we współpracy ze Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - oficjalna implementacja TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - oficjalna implementacja Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - oficjalna implementacja Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - utrzymywane we współpracy z Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - oficjalna implementacja Rust

## Najważniejsze informacje

- Konfiguracja środowiska MCP jest prosta dzięki SDK specyficznym dla języków
- Budowa serwerów MCP polega na tworzeniu i rejestrowaniu narzędzi z jasnymi schematami
- Klienci MCP łączą się z serwerami i modelami, by wykorzystać rozszerzone możliwości
- Testowanie i debugowanie są kluczowe dla niezawodnych implementacji MCP
- Opcje wdrożenia obejmują zarówno lokalny rozwój, jak i rozwiązania w chmurze

## Ćwiczenia praktyczne

Mamy zestaw przykładów, które uzupełniają ćwiczenia dostępne we wszystkich rozdziałach tej sekcji. Dodatkowo każdy rozdział zawiera własne ćwiczenia i zadania.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Dodatkowe materiały

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Co dalej

Następne: [Tworzenie twojego pierwszego MCP Server](/03-GettingStarted/01-first-server/README.md)

**Zastrzeżenie**:  
Ten dokument został przetłumaczony za pomocą usługi tłumaczeń AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dążymy do dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub niedokładności. Oryginalny dokument w jego języku źródłowym powinien być uważany za źródło autorytatywne. W przypadku informacji krytycznych zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.