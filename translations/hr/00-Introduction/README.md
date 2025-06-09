<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1446979020432f512c883848d7eca144",
  "translation_date": "2025-05-29T21:55:20+00:00",
  "source_file": "00-Introduction/README.md",
  "language_code": "hr"
}
-->
# Uvod u Model Context Protocol (MCP): Zašto je važan za skalabilne AI aplikacije

Generativne AI aplikacije predstavljaju veliki iskorak jer često omogućuju korisnicima da komuniciraju s aplikacijom koristeći prirodni jezik. Međutim, kako se ulaže više vremena i resursa u takve aplikacije, želite biti sigurni da možete lako integrirati funkcionalnosti i resurse na način koji omogućava jednostavno proširenje, da vaša aplikacija može podržavati više modela istovremeno i da može upravljati različitim složenostima modela. Ukratko, izrada Gen AI aplikacija je na početku jednostavna, ali kako rastu i postaju složenije, potrebno je definirati arhitekturu i vjerojatno se osloniti na standard koji će osigurati dosljednost u izgradnji aplikacija. Tu na scenu stupa MCP kako bi organizirao stvari i pružio standard.

---

## **🔍 Što je Model Context Protocol (MCP)?**

**Model Context Protocol (MCP)** je **otvoreno, standardizirano sučelje** koje omogućuje velikim jezičnim modelima (LLM) da se besprijekorno povežu s vanjskim alatima, API-jima i izvorima podataka. Pruža dosljednu arhitekturu za proširenje funkcionalnosti AI modela izvan njihovih podataka za treniranje, omogućujući pametnije, skalabilnije i responzivnije AI sustave.

---

## **🎯 Zašto je standardizacija u AI važna**

Kako generativne AI aplikacije postaju složenije, ključno je usvojiti standarde koji osiguravaju **skalabilnost, proširivost** i **održivost**. MCP rješava ove potrebe kroz:

- Ujednačavanje integracija modela i alata  
- Smanjenje krhkih, jedinstvenih rješenja  
- Omogućavanje istovremenog korištenja više modela unutar jednog ekosustava  

---

## **📚 Ciljevi učenja**

Na kraju ovog članka moći ćete:

- Definirati **Model Context Protocol (MCP)** i njegove primjene  
- Razumjeti kako MCP standardizira komunikaciju između modela i alata  
- Prepoznati ključne komponente MCP arhitekture  
- Istražiti primjere stvarnih primjena MCP-a u poslovnim i razvojim okruženjima  

---

## **💡 Zašto je Model Context Protocol (MCP) revolucionaran**

### **🔗 MCP rješava fragmentaciju u AI interakcijama**

Prije MCP-a, integracija modela s alatima zahtijevala je:

- Prilagođeni kod za svaki par alat-model  
- Nestandardizirane API-je za svakog dobavljača  
- Česte prekide zbog ažuriranja  
- Lošu skalabilnost s rastom broja alata  

### **✅ Prednosti MCP standardizacije**

| **Prednost**             | **Opis**                                                                       |
|--------------------------|--------------------------------------------------------------------------------|
| Interoperabilnost        | LLM modeli rade besprijekorno s alatima različitih dobavljača                 |
| Dosljednost              | Uniformno ponašanje na različitim platformama i alatima                        |
| Ponovna upotrebljivost   | Alati napravljeni jednom mogu se koristiti u različitim projektima i sustavima |
| Brži razvoj              | Smanjenje vremena razvoja korištenjem standardiziranih, plug-and-play sučelja |

---

## **🧱 Pregled MCP arhitekture na visokoj razini**

MCP slijedi **klijent-server model**, gdje:

- **MCP Hosts** pokreću AI modele  
- **MCP Clients** iniciraju zahtjeve  
- **MCP Servers** pružaju kontekst, alate i mogućnosti  

### **Ključne komponente:**

- **Resursi** – Statički ili dinamički podaci za modele  
- **Prompts** – Unaprijed definirani tijekovi rada za vođenu generaciju  
- **Alati** – Izvršne funkcije poput pretraživanja, izračuna  
- **Sampling** – Agentno ponašanje putem rekurzivnih interakcija  

---

## Kako MCP serveri rade

MCP serveri funkcioniraju na sljedeći način:

- **Tijek zahtjeva**:  
    1. MCP Client šalje zahtjev AI modelu koji radi u MCP Hostu.  
    2. AI model prepoznaje kada su mu potrebni vanjski alati ili podaci.  
    3. Model komunicira s MCP Serverom koristeći standardizirani protokol.

- **Funkcionalnosti MCP servera**:  
    - Registar alata: vodi katalog dostupnih alata i njihovih mogućnosti.  
    - Autentifikacija: provjerava dozvole za pristup alatima.  
    - Handler zahtjeva: obrađuje dolazne zahtjeve alata od modela.  
    - Formatiranje odgovora: strukturira izlaze alata u oblik razumljiv modelu.

- **Izvršenje alata**:  
    - Server usmjerava zahtjeve na odgovarajuće vanjske alate  
    - Alati izvršavaju svoje specijalizirane funkcije (pretraživanje, izračuni, upiti u bazu podataka itd.)  
    - Rezultati se vraćaju modelu u dosljednom formatu.

- **Dovršetak odgovora**:  
    - AI model uključi izlaze alata u svoj odgovor.  
    - Konačni odgovor se šalje natrag klijentskoj aplikaciji.

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

## 👨‍💻 Kako izgraditi MCP server (s primjerima)

MCP serveri omogućuju proširenje sposobnosti LLM-ova pružanjem podataka i funkcionalnosti.

Spremni za isprobati? Evo primjera izrade jednostavnog MCP servera u različitim jezicima:

- **Python primjer**: https://github.com/modelcontextprotocol/python-sdk

- **TypeScript primjer**: https://github.com/modelcontextprotocol/typescript-sdk

- **Java primjer**: https://github.com/modelcontextprotocol/java-sdk

- **C#/.NET primjer**: https://github.com/modelcontextprotocol/csharp-sdk

## 🌍 Primjeri stvarnih primjena MCP-a

MCP omogućuje širok raspon primjena proširujući AI mogućnosti:

| **Primjena**                | **Opis**                                                                       |
|----------------------------|--------------------------------------------------------------------------------|
| Integracija podataka u poduzeću | Povezivanje LLM-ova s bazama podataka, CRM-ovima ili internim alatima       |
| Agentni AI sustavi         | Omogućavanje autonomnih agenata s pristupom alatima i tijekovima donošenja odluka |
| Multimodalne aplikacije    | Kombiniranje teksta, slike i zvuka unutar jedne jedinstvene AI aplikacije       |
| Integracija podataka u stvarnom vremenu | Uvođenje živih podataka u AI interakcije za preciznije i ažurnije rezultate |

### 🧠 MCP = univerzalni standard za AI interakcije

Model Context Protocol (MCP) djeluje kao univerzalni standard za AI interakcije, slično kao što je USB-C standardizirao fizičke veze uređaja. U svijetu AI-a, MCP pruža dosljedno sučelje koje omogućuje modelima (klijentima) da se integriraju s vanjskim alatima i pružateljima podataka (serverima) bez potrebe za raznolikim, prilagođenim protokolima za svaki API ili izvor podataka.

U okviru MCP-a, alat kompatibilan s MCP-om (poznat kao MCP server) slijedi jedinstveni standard. Ti serveri mogu navesti alate ili akcije koje nude i izvršavati te akcije kada ih AI agent zatraži. Platforme AI agenata koje podržavaju MCP mogu otkrivati dostupne alate na serverima i pozivati ih putem ovog standardiziranog protokola.

### 💡 Omogućava pristup znanju

Osim što nudi alate, MCP također olakšava pristup znanju. Omogućuje aplikacijama da pruže kontekst velikim jezičnim modelima (LLM) povezivanjem s različitim izvorima podataka. Na primjer, MCP server može predstavljati repozitorij dokumenata tvrtke, dopuštajući agentima da po potrebi dohvaćaju relevantne informacije. Drugi server može upravljati specifičnim akcijama poput slanja e-mailova ili ažuriranja zapisa. Iz perspektive agenta, to su jednostavno alati koje može koristiti – neki alati vraćaju podatke (kontekst znanja), dok drugi izvršavaju radnje. MCP učinkovito upravlja oboje.

Agent koji se povezuje na MCP server automatski uči o dostupnim mogućnostima i podacima servera kroz standardizirani format. Ta standardizacija omogućuje dinamičnu dostupnost alata. Na primjer, dodavanjem novog MCP servera u sustav agenta, njegove funkcije postaju odmah dostupne bez dodatnih prilagodbi u uputama agenta.

Ova pojednostavljena integracija usklađena je s tijekom prikazanim na mermaid dijagramu, gdje serveri pružaju i alate i znanje, osiguravajući besprijekornu suradnju među sustavima.

### 👉 Primjer: skalabilno rješenje za agente

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

### 🔄 Napredni MCP scenariji s integracijom LLM-a na strani klijenta

Osim osnovne MCP arhitekture, postoje napredni scenariji u kojima i klijent i server sadrže LLM-ove, omogućujući sofisticiranije interakcije:

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

## 🔐 Praktične prednosti MCP-a

Evo praktičnih prednosti korištenja MCP-a:

- **Svježina podataka**: modeli mogu pristupiti najnovijim informacijama izvan podataka za treniranje  
- **Proširenje mogućnosti**: modeli mogu koristiti specijalizirane alate za zadatke za koje nisu trenirani  
- **Smanjenje halucinacija**: vanjski izvori podataka pružaju čvrstu činjenicu  
- **Privatnost**: osjetljivi podaci mogu ostati u sigurnom okruženju umjesto da budu ugrađeni u upite  

## 📌 Ključne spoznaje

Evo ključnih zaključaka o korištenju MCP-a:

- **MCP** standardizira način na koji AI modeli komuniciraju s alatima i podacima  
- Promiče **proširivost, dosljednost i interoperabilnost**  
- MCP pomaže **smanjiti vrijeme razvoja, poboljšati pouzdanost i proširiti mogućnosti modela**  
- Klijent-server arhitektura omogućuje **fleksibilne, proširive AI aplikacije**  

## 🧠 Vježba

Razmislite o AI aplikaciji koju želite razviti.

- Koji bi **vanjski alati ili podaci** mogli poboljšati njezine mogućnosti?  
- Kako bi MCP mogao učiniti integraciju **jednostavnijom i pouzdanijom**?  

## Dodatni resursi

- [MCP GitHub repozitorij](https://github.com/modelcontextprotocol)

## Što slijedi

Sljedeće: [Poglavlje 1: Osnovni pojmovi](/01-CoreConcepts/README.md)

**Izjava o odricanju od odgovornosti**:  
Ovaj dokument preveden je korištenjem AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.