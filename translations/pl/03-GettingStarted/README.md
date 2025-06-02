<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:31:43+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "pl"
}
-->
## Rozpoczęcie  

Ta sekcja składa się z kilku lekcji:

- **-1- Twój pierwszy serwer**, w tej pierwszej lekcji nauczysz się, jak stworzyć swój pierwszy serwer i sprawdzić go za pomocą narzędzia inspektora, co jest cennym sposobem testowania i debugowania serwera, [do lekcji](/03-GettingStarted/01-first-server/README.md)

- **-2- Klient**, w tej lekcji nauczysz się, jak napisać klienta, który może połączyć się z Twoim serwerem, [do lekcji](/03-GettingStarted/02-client/README.md)

- **-3- Klient z LLM**, jeszcze lepszym sposobem napisania klienta jest dodanie do niego LLM, aby mógł „negocjować” z Twoim serwerem, co zrobić, [do lekcji](/03-GettingStarted/03-llm-client/README.md)

- **-4- Konsumpcja trybu GitHub Copilot Agent serwera w Visual Studio Code**. Tutaj przyglądamy się uruchamianiu naszego MCP Server z poziomu Visual Studio Code, [do lekcji](/03-GettingStarted/04-vscode/README.md)

- **-5- Konsumpcja z SSE (Server Sent Events)**. SSE to standard przesyłania strumieniowego z serwera do klienta, pozwalający serwerom na wysyłanie aktualizacji w czasie rzeczywistym do klientów przez HTTP, [do lekcji](/03-GettingStarted/05-sse-server/README.md)

- **-6- Wykorzystanie AI Toolkit dla VSCode** do konsumpcji i testowania Twoich MCP Clients i Servers, [do lekcji](/03-GettingStarted/06-aitk/README.md)

- **-7 Testowanie**. Tutaj skupimy się szczególnie na różnych sposobach testowania naszego serwera i klienta, [do lekcji](/03-GettingStarted/07-testing/README.md)

- **-8- Wdrażanie**. Ten rozdział omówi różne sposoby wdrażania Twoich rozwiązań MCP, [do lekcji](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) to otwarty protokół standaryzujący sposób, w jaki aplikacje dostarczają kontekst do LLM. Można go porównać do portu USB-C dla aplikacji AI – zapewnia ustandaryzowany sposób łączenia modeli AI z różnymi źródłami danych i narzędziami.

## Cele nauki

Na koniec tej lekcji będziesz potrafił:

- Skonfigurować środowiska programistyczne dla MCP w C#, Javie, Pythonie, TypeScript i JavaScript
- Budować i wdrażać podstawowe serwery MCP z niestandardowymi funkcjami (zasoby, prompt’y i narzędzia)
- Tworzyć aplikacje hostujące, które łączą się z serwerami MCP
- Testować i debugować implementacje MCP
- Zrozumieć typowe wyzwania podczas konfiguracji i ich rozwiązania
- Łączyć swoje implementacje MCP z popularnymi usługami LLM

## Konfiguracja środowiska MCP

Zanim zaczniesz pracę z MCP, ważne jest, aby przygotować środowisko programistyczne i zrozumieć podstawowy przepływ pracy. Ta sekcja przeprowadzi Cię przez pierwsze kroki konfiguracji, aby zapewnić płynny start z MCP.

### Wymagania wstępne

Zanim zaczniesz rozwijać MCP, upewnij się, że masz:

- **Środowisko programistyczne**: dla wybranego języka (C#, Java, Python, TypeScript lub JavaScript)
- **IDE/Edytor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm lub dowolny nowoczesny edytor kodu
- **Menadżery pakietów**: NuGet, Maven/Gradle, pip lub npm/yarn
- **Klucze API**: do wszelkich usług AI, których planujesz używać w swoich aplikacjach hostujących


### Oficjalne SDK

W kolejnych rozdziałach zobaczysz rozwiązania zbudowane przy użyciu Pythona, TypeScript, Javy i .NET. Oto wszystkie oficjalnie wspierane SDK.

MCP dostarcza oficjalne SDK dla wielu języków:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - utrzymywane we współpracy z Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - utrzymywane we współpracy ze Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - oficjalna implementacja TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - oficjalna implementacja Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - oficjalna implementacja Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - utrzymywane we współpracy z Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - oficjalna implementacja Rust

## Kluczowe wnioski

- Konfiguracja środowiska MCP jest prosta dzięki SDK specyficznym dla języków
- Budowa serwerów MCP polega na tworzeniu i rejestrowaniu narzędzi z jasnymi schematami
- Klienci MCP łączą się z serwerami i modelami, by korzystać z rozszerzonych możliwości
- Testowanie i debugowanie są niezbędne dla niezawodnych implementacji MCP
- Opcje wdrożenia obejmują zarówno lokalny rozwój, jak i rozwiązania chmurowe

## Ćwiczenia praktyczne

Mamy zestaw przykładów, które uzupełniają ćwiczenia dostępne we wszystkich rozdziałach tej sekcji. Dodatkowo każdy rozdział ma własne ćwiczenia i zadania.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Dodatkowe zasoby

- [Budowanie agentów z użyciem Model Context Protocol na Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Zdalne MCP z Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Co dalej

Następny krok: [Tworzenie Twojego pierwszego MCP Server](/03-GettingStarted/01-first-server/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczeń AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy pamiętać, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym należy uważać za źródło autorytatywne. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.