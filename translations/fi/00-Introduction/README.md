<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1446979020432f512c883848d7eca144",
  "translation_date": "2025-05-29T21:50:14+00:00",
  "source_file": "00-Introduction/README.md",
  "language_code": "fi"
}
-->
# Johdanto Model Context Protocoliin (MCP): Miksi se on tärkeä skaalautuville tekoälysovelluksille

Generatiiviset tekoälysovellukset ovat suuri askel eteenpäin, sillä ne usein mahdollistavat käyttäjän vuorovaikutuksen sovelluksen kanssa luonnollisen kielen kehotteilla. Kuitenkin, kun tällaisiin sovelluksiin investoidaan enemmän aikaa ja resursseja, haluat varmistaa, että voit helposti integroida toiminnallisuuksia ja resursseja tavalla, joka on helppo laajentaa, että sovelluksesi pystyy tukemaan useamman mallin käyttöä ja käsittelemään erilaisia mallien erityispiirteitä. Lyhyesti sanottuna, generatiivisten tekoälysovellusten rakentaminen on aluksi helppoa, mutta niiden kasvaessa ja monimutkaistuessa sinun täytyy alkaa määritellä arkkitehtuuria ja todennäköisesti luottaa standardiin, joka varmistaa, että sovelluksesi rakennetaan johdonmukaisella tavalla. Tässä kohtaa MCP astuu kuvaan järjestämään asioita ja tarjoamaan standardin.

---

## **🔍 Mikä on Model Context Protocol (MCP)?**

**Model Context Protocol (MCP)** on **avoin, standardoitu rajapinta**, joka mahdollistaa suurten kielimallien (LLM) saumattoman vuorovaikutuksen ulkoisten työkalujen, API:en ja tietolähteiden kanssa. Se tarjoaa johdonmukaisen arkkitehtuurin tekoälymallien toiminnallisuuden laajentamiseen koulutusdatan ulkopuolelle, mahdollistaen älykkäämmät, skaalautuvat ja reagoivammat tekoälyjärjestelmät.

---

## **🎯 Miksi standardointi tekoälyssä on tärkeää**

Kun generatiiviset tekoälysovellukset monimutkaistuvat, on olennaista ottaa käyttöön standardeja, jotka takaavat **skaalautuvuuden, laajennettavuuden** ja **ylläpidettävyyden**. MCP vastaa näihin tarpeisiin:

- Yhdistelemällä mallien ja työkalujen integraatiot
- Vähentämällä hauraita, kertaluonteisia räätälöityjä ratkaisuja
- Sallimalla useiden mallien toimia samassa ekosysteemissä

---

## **📚 Oppimistavoitteet**

Tämän artikkelin lopussa osaat:

- Määritellä **Model Context Protocolin (MCP)** ja sen käyttötapaukset
- Ymmärtää, miten MCP standardisoi mallin ja työkalun välisen viestinnän
- Tunnistaa MCP-arkkitehtuurin keskeiset osat
- Tutkia MCP:n käytännön sovelluksia yritys- ja kehitysympäristöissä

---

## **💡 Miksi Model Context Protocol (MCP) on mullistava**

### **🔗 MCP ratkaisee tekoälyn vuorovaikutuksen pirstoutumisen**

Ennen MCP:tä mallien yhdistäminen työkaluihin vaati:

- Räätälöityä koodia jokaista työkalu-malli-paria varten
- Ei-standardisoituja API:ita jokaiselta toimittajalta
- Usein katkoksia päivitysten vuoksi
- Huonoa skaalautuvuutta työkalujen määrän kasvaessa

### **✅ MCP-standardoinnin hyödyt**

| **Hyöty**                | **Kuvaus**                                                                     |
|--------------------------|--------------------------------------------------------------------------------|
| Yhteentoimivuus          | LLM:t toimivat saumattomasti erilaisten toimittajien työkalujen kanssa         |
| Johdonmukaisuus          | Tasainen käyttäytyminen eri alustoilla ja työkaluissa                          |
| Uudelleenkäytettävyys    | Kerran rakennettuja työkaluja voi käyttää useissa projekteissa ja järjestelmissä |
| Kehityksen nopeutus      | Kehitysaikaa säästyy standardoitujen, plug-and-play-rajapintojen ansiosta      |

---

## **🧱 Korkean tason MCP-arkkitehtuurin yleiskatsaus**

MCP noudattaa **asiakas-palvelin-mallia**, jossa:

- **MCP Hosts** pyörittävät tekoälymalleja
- **MCP Clients** tekevät pyyntöjä
- **MCP Servers** tarjoavat kontekstin, työkalut ja ominaisuudet

### **Keskeiset komponentit:**

- **Resurssit** – Staattista tai dynaamista dataa malleille  
- **Kehotteet** – Ennalta määriteltyjä työnkulkuja ohjattuun generointiin  
- **Työkalut** – Suoritettavia toimintoja kuten haku, laskenta  
- **Näytteistys** – Agenttimainen käyttäytyminen rekursiivisten vuorovaikutusten kautta

---

## Miten MCP-palvelimet toimivat

MCP-palvelimet toimivat seuraavasti:

- **Pyyntöjen kulku**:  
    1. MCP Client lähettää pyynnön AI-mallille, joka toimii MCP Hostissa.  
    2. AI-malli tunnistaa, milloin se tarvitsee ulkoisia työkaluja tai dataa.  
    3. Malli kommunikoi MCP Serverin kanssa standardoidun protokollan avulla.

- **MCP-palvelimen toiminnot**:  
    - Työkalurekisteri: Pitää kirjaa saatavilla olevista työkaluista ja niiden ominaisuuksista.  
    - Todentaminen: Varmistaa käyttöoikeudet työkalujen käyttöön.  
    - Pyyntöjen käsittelijä: Käsittelee mallin lähettämät työkalupyyntöjä.  
    - Vastauksen muotoilija: Jäsentää työkalujen tuottamat tulokset mallin ymmärtämään muotoon.

- **Työkalujen suoritus**:  
    - Palvelin ohjaa pyynnöt oikeille ulkoisille työkaluilla  
    - Työkalut suorittavat erikoistuneet toiminnot (haku, laskenta, tietokantakyselyt jne.)  
    - Tulokset palautetaan mallille yhtenäisessä muodossa.

- **Vastauksen viimeistely**:  
    - AI-malli yhdistää työkalujen tulokset vastaukseensa.  
    - Lopullinen vastaus lähetetään takaisin asiakassovellukselle.

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

## 👨‍💻 Miten rakentaa MCP-palvelin (esimerkkien kera)

MCP-palvelimet antavat sinun laajentaa LLM-mallien kyvykkyyksiä tarjoamalla dataa ja toiminnallisuutta.

Valmis kokeilemaan? Tässä esimerkkejä yksinkertaisen MCP-palvelimen luomisesta eri kielillä:

- **Python-esimerkki**: https://github.com/modelcontextprotocol/python-sdk

- **TypeScript-esimerkki**: https://github.com/modelcontextprotocol/typescript-sdk

- **Java-esimerkki**: https://github.com/modelcontextprotocol/java-sdk

- **C#/.NET-esimerkki**: https://github.com/modelcontextprotocol/csharp-sdk

## 🌍 MCP:n käytännön käyttötapaukset

MCP mahdollistaa monipuolisia sovelluksia laajentamalla tekoälyn kyvykkyyksiä:

| **Sovellus**                | **Kuvaus**                                                                     |
|----------------------------|--------------------------------------------------------------------------------|
| Yritysdatan integrointi    | Yhdistää LLM:t tietokantoihin, CRM-järjestelmiin tai sisäisiin työkaluihin     |
| Agenttipohjaiset tekoälyjärjestelmät | Mahdollistaa autonomiset agentit työkalujen käyttöoikeuksilla ja päätöksenteolla |
| Monimodaaliset sovellukset | Yhdistää teksti-, kuva- ja ääni työkalut yhdeksi yhtenäiseksi tekoälysovellukseksi |
| Reaaliaikainen dataintegrointi | Tuo live-dataa tekoälyn vuorovaikutuksiin tarkempien ja ajankohtaisten tulosten saamiseksi |

### 🧠 MCP = Yleinen standardi tekoälyn vuorovaikutuksille

Model Context Protocol (MCP) toimii yleisenä standardina tekoälyn vuorovaikutuksille, samalla tavoin kuin USB-C vakiinnutti fyysiset liitännät laitteille. Tekoälyn maailmassa MCP tarjoaa yhdenmukaisen rajapinnan, jonka avulla mallit (asiakkaat) voivat integroitua saumattomasti ulkoisten työkalujen ja datan tarjoajien (palvelinten) kanssa. Tämä poistaa tarpeen käyttää erilaisia räätälöityjä protokollia jokaiselle API:lle tai tietolähteelle.

MCP-yhteensopiva työkalu (jota kutsutaan MCP-palvelimeksi) noudattaa yhtenäistä standardia. Nämä palvelimet voivat listata tarjoamansa työkalut tai toiminnot ja suorittaa ne, kun tekoälyagentti pyytää. MCP:tä tukevat tekoälyagenttialustat pystyvät löytämään palvelimien tarjoamat työkalut ja kutsumaan niitä tämän standardoidun protokollan kautta.

### 💡 Helpottaa tiedon saatavuutta

Työkalujen tarjoamisen lisäksi MCP helpottaa myös tiedon saatavuutta. Se mahdollistaa sovellusten tarjoavan kontekstia suurille kielimalleille (LLM) yhdistämällä ne eri tietolähteisiin. Esimerkiksi MCP-palvelin voi edustaa yrityksen dokumenttivarastoa, jolloin agentit voivat hakea tarpeellista tietoa pyynnöstä. Toinen palvelin voi hoitaa tiettyjä toimintoja, kuten sähköpostien lähettämistä tai tietueiden päivittämistä. Agentin näkökulmasta nämä ovat vain työkaluja, joita se voi käyttää — jotkut työkalut palauttavat dataa (tietokontekstia), toiset suorittavat toimintoja. MCP hallinnoi molempia tehokkaasti.

Agentti, joka yhdistyy MCP-palvelimeen, oppii automaattisesti palvelimen saatavilla olevat ominaisuudet ja käytettävissä olevan datan standardoidun muodon kautta. Tämä standardointi mahdollistaa dynaamisen työkalujen saatavuuden. Esimerkiksi uuden MCP-palvelimen lisääminen agentin järjestelmään tekee sen toiminnot heti käyttökelpoisiksi ilman lisämuokkauksia agentin ohjeistuksiin.

Tämä virtaviivaistettu integraatio vastaa mermaid-kaaviossa kuvattua virtaa, jossa palvelimet tarjoavat sekä työkaluja että tietoa, varmistaen sujuvan yhteistyön järjestelmien välillä.

### 👉 Esimerkki: Skaalautuva agenttiratkaisu

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

### 🔄 Kehittyneet MCP-skenaariot, joissa LLM:t ovat myös asiakkaalla

Perus-MCP-arkkitehtuurin lisäksi on kehittyneitä tilanteita, joissa sekä asiakas että palvelin sisältävät LLM-malleja, mahdollistaen monimutkaisempia vuorovaikutuksia:

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

## 🔐 MCP:n käytännön hyödyt

Tässä MCP:n käytännön hyödyt:

- **Ajantasaisuus**: Mallit pääsevät käsiksi ajankohtaiseen tietoon koulutusdatan ulkopuolella  
- **Kyvykkyyksien laajennus**: Mallit voivat hyödyntää erikoistuneita työkaluja tehtäviin, joihin niitä ei ole koulutettu  
- **Harhojen vähentäminen**: Ulkoiset tietolähteet tarjoavat faktapohjan  
- **Yksityisyys**: Arkaluonteinen data voi pysyä suojatuissa ympäristöissä eikä sisälly kehotteisiin

## 📌 Keskeiset opit

Tärkeimmät opit MCP:n käytöstä:

- **MCP** standardisoi, miten tekoälymallit kommunikoivat työkalujen ja datan kanssa  
- Edistää **laajennettavuutta, johdonmukaisuutta ja yhteentoimivuutta**  
- MCP auttaa **vähentämään kehitysaikaa, parantamaan luotettavuutta ja laajentamaan mallien kyvykkyyksiä**  
- Asiakas-palvelin-arkkitehtuuri **mahdollistaa joustavat, laajennettavat tekoälysovellukset**

## 🧠 Harjoitus

Pohdi tekoälysovellusta, jota haluaisit rakentaa.

- Mitkä **ulkoiset työkalut tai data** voisivat parantaa sen kyvykkyyksiä?  
- Miten MCP voisi tehdä integraatiosta **yksinkertaisempaa ja luotettavampaa**?

## Lisäresurssit

- [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## Mitä seuraavaksi

Seuraava: [Luku 1: Peruskäsitteet](/01-CoreConcepts/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulee pitää auktoritatiivisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaisen ihmiskääntäjän käyttöä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinymmärryksistä tai tulkinnoista.