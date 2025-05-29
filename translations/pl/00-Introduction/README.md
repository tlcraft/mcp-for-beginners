<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1446979020432f512c883848d7eca144",
  "translation_date": "2025-05-29T21:47:32+00:00",
  "source_file": "00-Introduction/README.md",
  "language_code": "pl"
}
-->
# Wprowadzenie do Model Context Protocol (MCP): Dlaczego ma znaczenie dla skalowalnych aplikacji AI

Generatywne aplikacje AI to duży krok naprzód, ponieważ często pozwalają użytkownikowi na interakcję z aplikacją za pomocą naturalnych poleceń językowych. Jednak w miarę inwestowania coraz większej ilości czasu i zasobów w takie aplikacje, chcesz mieć pewność, że łatwo zintegrujesz funkcje i zasoby w sposób umożliwiający ich łatwe rozszerzanie, obsługę wielu modeli jednocześnie oraz radzenie sobie z różnymi niuansami modeli. Krótko mówiąc, tworzenie aplikacji Gen AI jest na początku proste, ale w miarę ich rozwoju i rosnącej złożoności trzeba zacząć definiować architekturę i prawdopodobnie oprzeć się na standardzie, który zapewni spójność budowy aplikacji. W tym właśnie miejscu pojawia się MCP, które organizuje proces i dostarcza standard.

---

## **🔍 Czym jest Model Context Protocol (MCP)?**

**Model Context Protocol (MCP)** to **otwarty, ustandaryzowany interfejs**, który pozwala dużym modelom językowym (LLM) na płynną współpracę z zewnętrznymi narzędziami, API i źródłami danych. Zapewnia spójną architekturę, która rozszerza funkcjonalność modeli AI poza dane treningowe, umożliwiając tworzenie inteligentniejszych, skalowalnych i bardziej responsywnych systemów AI.

---

## **🎯 Dlaczego standaryzacja w AI jest ważna**

W miarę jak aplikacje generatywne AI stają się coraz bardziej złożone, niezbędne jest przyjęcie standardów gwarantujących **skalowalność, rozszerzalność** i **łatwość utrzymania**. MCP odpowiada na te potrzeby poprzez:

- Ujednolicenie integracji modeli z narzędziami  
- Ograniczenie kruchych, jednorazowych rozwiązań  
- Pozwolenie na współistnienie wielu modeli w jednym ekosystemie  

---

## **📚 Cele nauki**

Po przeczytaniu tego artykułu będziesz potrafił:

- Zdefiniować **Model Context Protocol (MCP)** oraz jego zastosowania  
- Zrozumieć, jak MCP ustandaryzowało komunikację model–narzędzie  
- Wymienić kluczowe elementy architektury MCP  
- Poznać przykłady zastosowań MCP w kontekście biznesowym i developerskim  

---

## **💡 Dlaczego Model Context Protocol (MCP) to przełom**

### **🔗 MCP rozwiązuje problem fragmentacji w interakcjach AI**

Przed MCP integracja modeli z narzędziami wymagała:

- Pisania dedykowanego kodu dla każdej pary narzędzie–model  
- Korzystania z niestandardowych API dla każdego dostawcy  
- Częstych przerw spowodowanych aktualizacjami  
- Słabej skalowalności wraz z rosnącą liczbą narzędzi  

### **✅ Korzyści ze standaryzacji MCP**

| **Korzyść**             | **Opis**                                                                       |
|-------------------------|--------------------------------------------------------------------------------|
| Interoperacyjność       | LLM współpracują płynnie z narzędziami różnych dostawców                      |
| Spójność                | Jednolite zachowanie na różnych platformach i narzędziach                     |
| Możliwość ponownego użycia | Narzędzia stworzone raz można wykorzystywać w różnych projektach i systemach  |
| Przyspieszenie rozwoju  | Skrócenie czasu tworzenia dzięki standardowym, plug-and-play interfejsom      |

---

## **🧱 Przegląd architektury MCP na wysokim poziomie**

MCP opiera się na **modelu klient-serwer**, gdzie:

- **MCP Hosts** uruchamiają modele AI  
- **MCP Clients** inicjują żądania  
- **MCP Servers** dostarczają kontekst, narzędzia i funkcjonalności  

### **Kluczowe komponenty:**

- **Resources** – statyczne lub dynamiczne dane dla modeli  
- **Prompts** – zdefiniowane wcześniej workflow do sterowanego generowania  
- **Tools** – wykonywalne funkcje, takie jak wyszukiwanie, obliczenia  
- **Sampling** – zachowanie agentowe poprzez rekurencyjne interakcje  

---

## Jak działają MCP Servers

Serwery MCP funkcjonują w następujący sposób:

- **Przepływ żądania**:  
    1. MCP Client wysyła żądanie do modelu AI działającego na MCP Host.  
    2. Model AI rozpoznaje, kiedy potrzebuje zewnętrznych narzędzi lub danych.  
    3. Model komunikuje się z MCP Serverem za pomocą ustandaryzowanego protokołu.  

- **Funkcje MCP Servera**:  
    - Rejestr narzędzi: utrzymuje katalog dostępnych narzędzi i ich możliwości.  
    - Uwierzytelnianie: weryfikuje uprawnienia do korzystania z narzędzi.  
    - Obsługa żądań: przetwarza przychodzące żądania narzędzi od modelu.  
    - Formatowanie odpowiedzi: strukturyzuje wyniki narzędzi w formacie zrozumiałym dla modelu.  

- **Wykonanie narzędzia**:  
    - Serwer kieruje żądania do odpowiednich zewnętrznych narzędzi  
    - Narzędzia wykonują swoje specjalistyczne funkcje (wyszukiwanie, obliczenia, zapytania do baz danych itd.)  
    - Wyniki są zwracane do modelu w spójnym formacie  

- **Zakończenie odpowiedzi**:  
    - Model AI włącza wyniki narzędzi do swojej odpowiedzi  
    - Ostateczna odpowiedź jest wysyłana do aplikacji-klienta  

```mermaid
---
title: MCP Server Architecture and Component Interactions
description: A diagram showing how AI models interact with MCP servers and various tools, depicting the request flow and server components including Tool Registry, Authentication, Request Handler, and Response Formatter
---
graph TD
    A[AI Model in MCP Host] <-->|MCP Protocol| B[MCP Server]
    B <-->|Tool Interface| C[Tool 1: Web Search]
    B <-->|Tool Interface| D[Tool 2: Calculator]
    B <-->|Tool Interface| E[Tool 3: Database Access]
    B <-->|Tool Interface| F[Tool 4: File System]
    
    Client[MCP Client/Application] -->|Sends Request| A
    A -->|Returns Response| Client
    
    subgraph "MCP Server Components"
        B
        G[Tool Registry]
        H[Authentication]
        I[Request Handler]
        J[Response Formatter]
    end
    
    B <--> G
    B <--> H
    B <--> I
    B <--> J
    
    style A fill:#f9d5e5,stroke:#333,stroke-width:2px
    style B fill:#eeeeee,stroke:#333,stroke-width:2px
    style Client fill:#d5e8f9,stroke:#333,stroke-width:2px
    style C fill:#c2f0c2,stroke:#333,stroke-width:1px
    style D fill:#c2f0c2,stroke:#333,stroke-width:1px
    style E fill:#c2f0c2,stroke:#333,stroke-width:1px
    style F fill:#c2f0c2,stroke:#333,stroke-width:1px    
```

## 👨‍💻 Jak zbudować MCP Server (z przykładami)

Serwery MCP pozwalają rozszerzyć możliwości LLM, dostarczając dane i funkcjonalności.

Chcesz spróbować? Oto przykłady tworzenia prostego serwera MCP w różnych językach:

- **Przykład w Pythonie**: https://github.com/modelcontextprotocol/python-sdk

- **Przykład w TypeScript**: https://github.com/modelcontextprotocol/typescript-sdk

- **Przykład w Javie**: https://github.com/modelcontextprotocol/java-sdk

- **Przykład w C#/.NET**: https://github.com/modelcontextprotocol/csharp-sdk


## 🌍 Przykłady zastosowań MCP w rzeczywistych projektach

MCP umożliwia szeroki zakres zastosowań poprzez rozszerzenie możliwości AI:

| **Zastosowanie**           | **Opis**                                                                       |
|----------------------------|--------------------------------------------------------------------------------|
| Integracja danych w przedsiębiorstwie | Łączenie LLM z bazami danych, CRM-ami lub narzędziami wewnętrznymi       |
| Systemy agentowe AI         | Umożliwienie autonomicznym agentom dostępu do narzędzi i podejmowania decyzji |
| Aplikacje multimodalne      | Łączenie narzędzi tekstowych, obrazowych i audio w jednej zunifikowanej aplikacji AI |
| Integracja danych w czasie rzeczywistym | Dostarczanie aktualnych danych do interakcji AI dla dokładniejszych wyników |

### 🧠 MCP = uniwersalny standard dla interakcji AI

Model Context Protocol (MCP) działa jak uniwersalny standard dla interakcji AI, podobnie jak USB-C ustandaryzowało fizyczne połączenia urządzeń. W świecie AI MCP dostarcza spójny interfejs, który pozwala modelom (klientom) na płynną integrację z zewnętrznymi narzędziami i dostawcami danych (serwerami). Dzięki temu nie ma potrzeby stosowania różnych, niestandardowych protokołów dla każdego API lub źródła danych.

W ramach MCP narzędzie kompatybilne z MCP (zwane MCP serverem) działa według jednolitego standardu. Serwery te mogą wymieniać listę dostępnych narzędzi lub akcji i wykonywać je na żądanie agenta AI. Platformy agentowe wspierające MCP potrafią odkrywać dostępne narzędzia na serwerach i wywoływać je za pomocą tego standardowego protokołu.

### 💡 Ułatwia dostęp do wiedzy

Poza dostarczaniem narzędzi MCP ułatwia też dostęp do wiedzy. Pozwala aplikacjom dostarczać kontekst dużym modelom językowym (LLM) poprzez łączenie ich z różnymi źródłami danych. Na przykład MCP server może reprezentować repozytorium dokumentów firmy, umożliwiając agentom pobieranie istotnych informacji na żądanie. Inny serwer może obsługiwać konkretne akcje, jak wysyłanie maili czy aktualizacja rekordów. Z perspektywy agenta to po prostu narzędzia — niektóre zwracają dane (kontekst wiedzy), inne wykonują akcje. MCP efektywnie zarządza oboma przypadkami.

Agent łączący się z MCP serverem automatycznie poznaje dostępne funkcjonalności i dane dzięki standardowemu formatowi. Ta standaryzacja umożliwia dynamiczną dostępność narzędzi. Na przykład dodanie nowego serwera MCP do systemu agenta sprawia, że jego funkcje są od razu dostępne, bez konieczności dalszej konfiguracji czy modyfikacji instrukcji agenta.

Tak uproszczona integracja odpowiada schematowi przedstawionemu na diagramie mermaid, gdzie serwery dostarczają zarówno narzędzia, jak i wiedzę, zapewniając płynną współpracę między systemami.

### 👉 Przykład: skalowalne rozwiązanie agentowe

```mermaid
---
title: Scalable Agent Solution with MCP
description: A diagram illustrating how a user interacts with an LLM that connects to multiple MCP servers, with each server providing both knowledge and tools, creating a scalable AI system architecture
---
graph TD
    User -->|Prompt| LLM
    LLM -->|Response| User
    LLM -->|MCP| ServerA
    LLM -->|MCP| ServerB
    ServerA -->|Universal connector| ServerB
    ServerA --> KnowledgeA
    ServerA --> ToolsA
    ServerB --> KnowledgeB
    ServerB --> ToolsB

    subgraph Server A
        KnowledgeA[Knowledge]
        ToolsA[Tools]
    end

    subgraph Server B
        KnowledgeB[Knowledge]
        ToolsB[Tools]
    end
```

### 🔄 Zaawansowane scenariusze MCP z integracją LLM po stronie klienta

Poza podstawową architekturą MCP istnieją zaawansowane scenariusze, w których zarówno klient, jak i serwer zawierają LLM, co umożliwia bardziej złożone interakcje:

```mermaid
---
title: Advanced MCP Scenarios with Client-Server LLM Integration
description: A sequence diagram showing the detailed interaction flow between user, client application, client LLM, multiple MCP servers, and server LLM, illustrating tool discovery, user interaction, direct tool calling, and feature negotiation phases
---
sequenceDiagram
    autonumber
    actor User as 👤 User
    participant ClientApp as 🖥️ Client App
    participant ClientLLM as 🧠 Client LLM
    participant Server1 as 🔧 MCP Server 1
    participant Server2 as 📚 MCP Server 2
    participant ServerLLM as 🤖 Server LLM
    
    %% Discovery Phase
    rect rgb(220, 240, 255)
        Note over ClientApp, Server2: TOOL DISCOVERY PHASE
        ClientApp->>+Server1: Request available tools/resources
        Server1-->>-ClientApp: Return tool list (JSON)
        ClientApp->>+Server2: Request available tools/resources
        Server2-->>-ClientApp: Return tool list (JSON)
        Note right of ClientApp: Store combined tool<br/>catalog locally
    end
    
    %% User Interaction
    rect rgb(255, 240, 220)
        Note over User, ClientLLM: USER INTERACTION PHASE
        User->>+ClientApp: Enter natural language prompt
        ClientApp->>+ClientLLM: Forward prompt + tool catalog
        ClientLLM->>-ClientLLM: Analyze prompt & select tools
    end
    
    %% Scenario A: Direct Tool Calling
    alt Direct Tool Calling
        rect rgb(220, 255, 220)
            Note over ClientApp, Server1: SCENARIO A: DIRECT TOOL CALLING
            ClientLLM->>+ClientApp: Request tool execution
            ClientApp->>+Server1: Execute specific tool
            Server1-->>-ClientApp: Return results
            ClientApp->>+ClientLLM: Process results
            ClientLLM-->>-ClientApp: Generate response
            ClientApp-->>-User: Display final answer
        end
    
    %% Scenario B: Feature Negotiation (VS Code style)
    else Feature Negotiation (VS Code style)
        rect rgb(255, 220, 220)
            Note over ClientApp, ServerLLM: SCENARIO B: FEATURE NEGOTIATION
            ClientLLM->>+ClientApp: Identify needed capabilities
            ClientApp->>+Server2: Negotiate features/capabilities
            Server2->>+ServerLLM: Request additional context
            ServerLLM-->>-Server2: Provide context
            Server2-->>-ClientApp: Return available features
            ClientApp->>+Server2: Call negotiated tools
            Server2-->>-ClientApp: Return results
            ClientApp->>+ClientLLM: Process results
            ClientLLM-->>-ClientApp: Generate response
            ClientApp-->>-User: Display final answer
        end
    end
```

## 🔐 Praktyczne korzyści MCP

Oto praktyczne zalety korzystania z MCP:

- **Aktualność**: Modele mają dostęp do najnowszych informacji poza danymi treningowymi  
- **Rozszerzenie możliwości**: Modele mogą korzystać ze specjalistycznych narzędzi do zadań, do których nie były trenowane  
- **Zmniejszenie halucynacji**: Zewnętrzne źródła danych zapewniają oparcie w faktach  
- **Prywatność**: Wrażliwe dane mogą pozostać w bezpiecznym środowisku, zamiast być osadzone w promptach  

## 📌 Najważniejsze wnioski

Kluczowe punkty dotyczące MCP:

- **MCP** ustandaryzowało sposób, w jaki modele AI komunikują się z narzędziami i danymi  
- Promuje **rozszerzalność, spójność i interoperacyjność**  
- MCP pomaga **skrócić czas rozwoju, poprawić niezawodność i rozszerzyć możliwości modeli**  
- Architektura klient-serwer **umożliwia tworzenie elastycznych, rozszerzalnych aplikacji AI**  

## 🧠 Ćwiczenie

Pomyśl o aplikacji AI, którą chciałbyś stworzyć.

- Jakie **zewnętrzne narzędzia lub dane** mogłyby zwiększyć jej możliwości?  
- W jaki sposób MCP może uczynić integrację **prostszą i bardziej niezawodną**?  

## Dodatkowe zasoby

- [MCP GitHub Repository](https://github.com/modelcontextprotocol)


## Co dalej

Następny rozdział: [Chapter 1: Core Concepts](/01-CoreConcepts/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczeń AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy wszelkich starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym należy traktować jako źródło wiążące. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.