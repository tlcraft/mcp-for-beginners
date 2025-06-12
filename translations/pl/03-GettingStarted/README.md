<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-12T22:01:10+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "pl"
}
-->
## Rozpoczęcie  

Ta sekcja składa się z kilku lekcji:

- **1 Twój pierwszy serwer**, w tej pierwszej lekcji nauczysz się, jak stworzyć swój pierwszy serwer i sprawdzić go za pomocą narzędzia inspektora, co jest cennym sposobem na testowanie i debugowanie serwera, [do lekcji](/03-GettingStarted/01-first-server/README.md)

- **2 Klient**, w tej lekcji dowiesz się, jak napisać klienta, który może połączyć się z twoim serwerem, [do lekcji](/03-GettingStarted/02-client/README.md)

- **3 Klient z LLM**, jeszcze lepszym sposobem na napisanie klienta jest dodanie do niego LLM, dzięki czemu może on "negocjować" z twoim serwerem, co zrobić, [do lekcji](/03-GettingStarted/03-llm-client/README.md)

- **4 Konsumpcja trybu agenta GitHub Copilot serwera w Visual Studio Code**. Tutaj przyglądamy się uruchamianiu naszego MCP Server z poziomu Visual Studio Code, [do lekcji](/03-GettingStarted/04-vscode/README.md)

- **5 Konsumpcja z SSE (Server Sent Events)** SSE to standard do strumieniowania danych z serwera do klienta, pozwalający serwerom wysyłać aktualizacje w czasie rzeczywistym do klientów przez HTTP [do lekcji](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP Streaming z MCP (Streamable HTTP)**. Poznaj nowoczesne strumieniowanie HTTP, powiadomienia o postępie oraz jak implementować skalowalne, działające w czasie rzeczywistym serwery i klientów MCP wykorzystując Streamable HTTP. [do lekcji](/03-GettingStarted/06-http-streaming/README.md)

- **7 Wykorzystanie AI Toolkit dla VSCode** do konsumpcji i testowania twoich klientów i serwerów MCP [do lekcji](/03-GettingStarted/07-aitk/README.md)

- **8 Testowanie**. Tutaj skupimy się szczególnie na tym, jak możemy testować nasz serwer i klienta na różne sposoby, [do lekcji](/03-GettingStarted/08-testing/README.md)

- **9 Wdrażanie**. Ten rozdział pokaże różne sposoby wdrażania twoich rozwiązań MCP, [do lekcji](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) to otwarty protokół standaryzujący sposób, w jaki aplikacje dostarczają kontekst do LLM. Można go porównać do portu USB-C dla aplikacji AI – zapewnia ustandaryzowany sposób łączenia modeli AI z różnymi źródłami danych i narzędziami.

## Cele nauki

Po zakończeniu tej lekcji będziesz potrafił:

- Skonfigurować środowiska programistyczne dla MCP w C#, Java, Python, TypeScript i JavaScript
- Tworzyć i wdrażać podstawowe serwery MCP z niestandardowymi funkcjami (zasoby, prompt’y i narzędzia)
- Tworzyć aplikacje hostujące, które łączą się z serwerami MCP
- Testować i debugować implementacje MCP
- Zrozumieć typowe wyzwania podczas konfiguracji i ich rozwiązania
- Łączyć swoje implementacje MCP z popularnymi usługami LLM

## Konfiguracja środowiska MCP

Zanim zaczniesz pracę z MCP, ważne jest przygotowanie środowiska programistycznego i zrozumienie podstawowego przebiegu pracy. Ta sekcja poprowadzi cię przez początkowe kroki konfiguracji, aby zapewnić płynny start z MCP.

### Wymagania wstępne

Zanim zaczniesz rozwój MCP, upewnij się, że masz:

- **Środowisko programistyczne**: dla wybranego języka (C#, Java, Python, TypeScript lub JavaScript)
- **IDE/Edytor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm lub dowolny nowoczesny edytor kodu
- **Menadżery pakietów**: NuGet, Maven/Gradle, pip lub npm/yarn
- **Klucze API**: do usług AI, które planujesz używać w aplikacjach hostujących


### Oficjalne SDK

W kolejnych rozdziałach zobaczysz rozwiązania zbudowane w Pythonie, TypeScript, Javie i .NET. Oto wszystkie oficjalnie wspierane SDK.

MCP oferuje oficjalne SDK dla wielu języków:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - utrzymywane we współpracy z Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - utrzymywane we współpracy ze Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - oficjalna implementacja TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - oficjalna implementacja Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - oficjalna implementacja Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - utrzymywane we współpracy z Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - oficjalna implementacja Rust

## Najważniejsze wnioski

- Konfiguracja środowiska MCP jest prosta dzięki dedykowanym SDK dla poszczególnych języków
- Budowa serwerów MCP polega na tworzeniu i rejestrowaniu narzędzi z jasnymi schematami
- Klienci MCP łączą się z serwerami i modelami, by wykorzystać rozszerzone możliwości
- Testowanie i debugowanie są kluczowe dla niezawodnych implementacji MCP
- Opcje wdrażania obejmują zarówno lokalny rozwój, jak i rozwiązania chmurowe

## Ćwiczenia praktyczne

Mamy zestaw przykładów, które uzupełniają ćwiczenia dostępne we wszystkich rozdziałach tej sekcji. Dodatkowo każdy rozdział zawiera własne ćwiczenia i zadania.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Dodatkowe zasoby

- [Budowanie agentów z użyciem Model Context Protocol na Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Zdalny MCP z Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Co dalej

Następny krok: [Tworzenie twojego pierwszego MCP Server](/03-GettingStarted/01-first-server/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub nieścisłości. Oryginalny dokument w jego języku źródłowym należy traktować jako źródło wiarygodne i ostateczne. W przypadku informacji o krytycznym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.