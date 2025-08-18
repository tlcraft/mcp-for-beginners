<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0df1ee78a6dd8300f3a040ca5b411c2e",
  "translation_date": "2025-08-18T17:35:41+00:00",
  "source_file": "00-Introduction/README.md",
  "language_code": "hr"
}
-->
# Uvod u Model Context Protocol (MCP): Zašto je važan za skalabilne AI aplikacije

[![Uvod u Model Context Protocol](../../../translated_images/01.a467036d886b5fb5b9cf7b39bac0e743b6ca0a4a18a492de90061daaf0cc55f0.hr.png)](https://youtu.be/agBbdiOPLQA)

_(Kliknite na sliku iznad za video lekciju)_

Generativne AI aplikacije predstavljaju veliki korak naprijed jer često omogućuju korisnicima interakciju s aplikacijom putem prirodnog jezika. Međutim, kako se ulaže više vremena i resursa u takve aplikacije, važno je osigurati jednostavnu integraciju funkcionalnosti i resursa na način koji omogućuje lako proširenje, podršku za više modela i upravljanje različitim specifičnostima modela. Ukratko, izgradnja Gen AI aplikacija je jednostavna na početku, ali kako rastu i postaju složenije, potrebno je definirati arhitekturu i osloniti se na standard kako bi aplikacije bile konzistentno izgrađene. Tu MCP dolazi u igru kako bi organizirao stvari i pružio standard.

---

## **🔍 Što je Model Context Protocol (MCP)?**

**Model Context Protocol (MCP)** je **otvoreno, standardizirano sučelje** koje omogućuje Velikim Jezičnim Modelima (LLM-ovima) besprijekornu interakciju s vanjskim alatima, API-jevima i izvorima podataka. MCP pruža konzistentnu arhitekturu za proširenje funkcionalnosti AI modela izvan njihovih podataka za treniranje, omogućujući pametnije, skalabilnije i responzivnije AI sustave.

---

## **🎯 Zašto je standardizacija u AI-u važna**

Kako generativne AI aplikacije postaju složenije, ključno je usvojiti standarde koji osiguravaju **skalabilnost, proširivost, održivost** i **izbjegavanje ovisnosti o jednom dobavljaču**. MCP odgovara na ove potrebe:

- Ujedinjuje integracije modela i alata
- Smanjuje krhka, jednokratna prilagođena rješenja
- Omogućuje suživot više modela različitih dobavljača unutar jednog ekosustava

**Napomena:** Iako se MCP predstavlja kao otvoreni standard, nema planova za standardizaciju MCP-a putem postojećih tijela za standardizaciju poput IEEE, IETF, W3C, ISO ili drugih.

---

## **📚 Ciljevi učenja**

Na kraju ovog članka moći ćete:

- Definirati **Model Context Protocol (MCP)** i njegove slučajeve upotrebe
- Razumjeti kako MCP standardizira komunikaciju između modela i alata
- Identificirati ključne komponente MCP arhitekture
- Istražiti stvarne primjene MCP-a u poslovnim i razvojnim kontekstima

---

## **💡 Zašto je Model Context Protocol (MCP) revolucionaran**

### **🔗 MCP rješava fragmentaciju u AI interakcijama**

Prije MCP-a, integracija modela s alatima zahtijevala je:

- Prilagođeni kod za svaki par alat-model
- Nestandardizirane API-jeve za svakog dobavljača
- Česte prekide zbog ažuriranja
- Lošu skalabilnost s više alata

### **✅ Prednosti standardizacije MCP-a**

| **Prednost**              | **Opis**                                                                       |
|---------------------------|-------------------------------------------------------------------------------|
| Interoperabilnost         | LLM-ovi rade besprijekorno s alatima različitih dobavljača                   |
| Konzistentnost            | Ujednačeno ponašanje na različitim platformama i alatima                     |
| Ponovna upotreba          | Jednom izgrađeni alati mogu se koristiti u različitim projektima i sustavima |
| Ubrzani razvoj            | Smanjenje vremena razvoja korištenjem standardiziranih sučelja              |

---

## **🧱 Pregled arhitekture MCP-a na visokoj razini**

MCP slijedi **klijent-poslužitelj model**, gdje:

- **MCP domaćini** pokreću AI modele
- **MCP klijenti** iniciraju zahtjeve
- **MCP poslužitelji** pružaju kontekst, alate i mogućnosti

### **Ključne komponente:**

- **Resursi** – Statički ili dinamički podaci za modele  
- **Upiti** – Unaprijed definirani tijekovi rada za vođenu generaciju  
- **Alati** – Izvršne funkcije poput pretraživanja, izračuna  
- **Uzorci** – Agentičko ponašanje putem rekurzivnih interakcija  

---

## Kako MCP poslužitelji rade

MCP poslužitelji funkcioniraju na sljedeći način:

- **Tijek zahtjeva**:
    1. Krajnji korisnik ili softver u njegovo ime inicira zahtjev.
    2. **MCP klijent** šalje zahtjev **MCP domaćinu**, koji upravlja runtime-om AI modela.
    3. **AI model** prima korisnički upit i može zatražiti pristup vanjskim alatima ili podacima putem jednog ili više poziva alata.
    4. **MCP domaćin**, a ne model izravno, komunicira s odgovarajućim **MCP poslužiteljem/ima** koristeći standardizirani protokol.
- **Funkcionalnosti MCP domaćina**:
    - **Registar alata**: Održava katalog dostupnih alata i njihovih mogućnosti.
    - **Autentifikacija**: Provjerava dozvole za pristup alatima.
    - **Rukovatelj zahtjeva**: Obraduje dolazne zahtjeve alata od modela.
    - **Formatiranje odgovora**: Strukturira izlaze alata u format koji model može razumjeti.
- **Izvršenje MCP poslužitelja**:
    - **MCP domaćin** usmjerava pozive alata na jedan ili više **MCP poslužitelja**, od kojih svaki nudi specijalizirane funkcije (npr. pretraživanje, izračune, upite baze podataka).
    - **MCP poslužitelji** izvršavaju svoje operacije i vraćaju rezultate **MCP domaćinu** u konzistentnom formatu.
    - **MCP domaćin** formatira i prosljeđuje te rezultate **AI modelu**.
- **Dovršetak odgovora**:
    - **AI model** uključuje izlaze alata u konačni odgovor.
    - **MCP domaćin** šalje ovaj odgovor natrag **MCP klijentu**, koji ga isporučuje krajnjem korisniku ili pozivnom softveru.

```mermaid
---
title: MCP Architecture and Component Interactions
description: A diagram showing the flows of the components in MCP.
---
graph TD
    Client[MCP Client/Application] -->|Sends Request| H[MCP Host]
    H -->|Invokes| A[AI Model]
    A -->|Tool Call Request| H
    H -->|MCP Protocol| T1[MCP Server Tool 01: Web Search]
    H -->|MCP Protocol| T2[MCP Server Tool 02: Calculator tool]
    H -->|MCP Protocol| T3[MCP Server Tool 03: Database Access tool]
    H -->|MCP Protocol| T4[MCP Server Tool 04: File System tool]
    H -->|Sends Response| Client

    subgraph "MCP Host Components"
        H
        G[Tool Registry]
        I[Authentication]
        J[Request Handler]
        K[Response Formatter]
    end

    H <--> G
    H <--> I
    H <--> J
    H <--> K

    style A fill:#f9d5e5,stroke:#333,stroke-width:2px
    style H fill:#eeeeee,stroke:#333,stroke-width:2px
    style Client fill:#d5e8f9,stroke:#333,stroke-width:2px
    style G fill:#fffbe6,stroke:#333,stroke-width:1px
    style I fill:#fffbe6,stroke:#333,stroke-width:1px
    style J fill:#fffbe6,stroke:#333,stroke-width:1px
    style K fill:#fffbe6,stroke:#333,stroke-width:1px
    style T1 fill:#c2f0c2,stroke:#333,stroke-width:1px
    style T2 fill:#c2f0c2,stroke:#333,stroke-width:1px
    style T3 fill:#c2f0c2,stroke:#333,stroke-width:1px
    style T4 fill:#c2f0c2,stroke:#333,stroke-width:1px
```

## 👨‍💻 Kako izgraditi MCP poslužitelj (s primjerima)

MCP poslužitelji omogućuju proširenje mogućnosti LLM-ova pružanjem podataka i funkcionalnosti.

Spremni za isprobavanje? Evo SDK-ova specifičnih za jezik i/ili tehnologiju s primjerima izrade jednostavnih MCP poslužitelja:

- **Python SDK**: https://github.com/modelcontextprotocol/python-sdk

- **TypeScript SDK**: https://github.com/modelcontextprotocol/typescript-sdk

- **Java SDK**: https://github.com/modelcontextprotocol/java-sdk

- **C#/.NET SDK**: https://github.com/modelcontextprotocol/csharp-sdk

---

## 🌍 Stvarni primjeri upotrebe MCP-a

MCP omogućuje širok raspon aplikacija proširujući AI mogućnosti:

| **Aplikacija**             | **Opis**                                                                       |
|----------------------------|-------------------------------------------------------------------------------|
| Integracija poslovnih podataka | Povezivanje LLM-ova s bazama podataka, CRM-ovima ili internim alatima         |
| Agentički AI sustavi        | Omogućavanje autonomnih agenata s pristupom alatima i tijekovima odlučivanja |
| Multimodalne aplikacije     | Kombiniranje teksta, slike i zvuka unutar jedne AI aplikacije                |
| Integracija podataka u stvarnom vremenu | Uključivanje aktualnih podataka u AI interakcije za preciznije rezultate |

### 🧠 MCP = Univerzalni standard za AI interakcije

Model Context Protocol (MCP) djeluje kao univerzalni standard za AI interakcije, slično kao što je USB-C standardizirao fizičke veze za uređaje. U svijetu AI-ja, MCP pruža konzistentno sučelje, omogućujući modelima (klijentima) besprijekornu integraciju s vanjskim alatima i pružateljima podataka (poslužiteljima). Ovo eliminira potrebu za raznolikim, prilagođenim protokolima za svaki API ili izvor podataka.

Pod MCP-om, alat kompatibilan s MCP-om (poznat kao MCP poslužitelj) slijedi ujednačen standard. Ti poslužitelji mogu navesti alate ili radnje koje nude i izvršavati te radnje kada ih AI agent zatraži. Platforme AI agenata koje podržavaju MCP mogu otkriti dostupne alate s poslužitelja i pozivati ih putem ovog standardnog protokola.

### 💡 Omogućuje pristup znanju

Osim što nudi alate, MCP omogućuje pristup znanju. Omogućuje aplikacijama pružanje konteksta velikim jezičnim modelima (LLM-ovima) povezivanjem s različitim izvorima podataka. Na primjer, MCP poslužitelj može predstavljati repozitorij dokumenata tvrtke, omogućujući agentima dohvaćanje relevantnih informacija na zahtjev. Drugi poslužitelj može upravljati specifičnim radnjama poput slanja e-pošte ili ažuriranja zapisa. Iz perspektive agenta, to su jednostavno alati koje može koristiti—neki alati vraćaju podatke (kontekst znanja), dok drugi izvršavaju radnje. MCP učinkovito upravlja oboje.

Agent koji se povezuje s MCP poslužiteljem automatski uči o dostupnim mogućnostima i podacima poslužitelja putem standardnog formata. Ova standardizacija omogućuje dinamičnu dostupnost alata. Na primjer, dodavanje novog MCP poslužitelja u sustav agenta čini njegove funkcije odmah dostupnima bez potrebe za dodatnom prilagodbom uputa agenta.

Ova pojednostavljena integracija usklađena je s prikazanim tokom u sljedećem dijagramu, gdje poslužitelji pružaju i alate i znanje, osiguravajući besprijekornu suradnju između sustava.

### 👉 Primjer: Skalabilno rješenje za agente

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

### 🔄 Napredni MCP scenariji s integracijom LLM-ova na strani klijenta

Osim osnovne MCP arhitekture, postoje napredni scenariji gdje i klijent i poslužitelj sadrže LLM-ove, omogućujući sofisticiranije interakcije. U sljedećem dijagramu, **klijentska aplikacija** može biti IDE s nizom MCP alata dostupnih za korištenje od strane LLM-a:

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

---

## 🔐 Praktične prednosti MCP-a

Evo praktičnih prednosti korištenja MCP-a:

- **Ažurnost**: Modeli mogu pristupiti aktualnim informacijama izvan svojih podataka za treniranje
- **Proširenje mogućnosti**: Modeli mogu koristiti specijalizirane alate za zadatke za koje nisu trenirani
- **Smanjenje halucinacija**: Vanjski izvori podataka pružaju činjenično utemeljenje
- **Privatnost**: Osjetljivi podaci mogu ostati unutar sigurnih okruženja umjesto da se ugrađuju u upite

---

## 📌 Ključne točke

Sljedeće su ključne točke za korištenje MCP-a:

- **MCP** standardizira način na koji AI modeli komuniciraju s alatima i podacima
- Promiče **proširivost, konzistentnost i interoperabilnost**
- MCP pomaže **smanjiti vrijeme razvoja, poboljšati pouzdanost i proširiti mogućnosti modela**
- Arhitektura klijent-poslužitelj omogućuje **fleksibilne, proširive AI aplikacije**

---

## 🧠 Vježba

Razmislite o AI aplikaciji koju želite izgraditi.

- Koji bi **vanjski alati ili podaci** mogli poboljšati njezine mogućnosti?
- Kako bi MCP mogao učiniti integraciju **jednostavnijom i pouzdanijom**?

---

## Dodatni resursi

- [MCP GitHub repozitorij](https://github.com/modelcontextprotocol)

---

## Što slijedi

Dalje: [Poglavlje 1: Osnovni koncepti](../01-CoreConcepts/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prijevod [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo osigurati točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati mjerodavnim izvorom. Za ključne informacije preporučuje se profesionalni prijevod od strane stručnjaka. Ne preuzimamo odgovornost za bilo kakve nesporazume ili pogrešne interpretacije proizašle iz korištenja ovog prijevoda.