<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0df1ee78a6dd8300f3a040ca5b411c2e",
  "translation_date": "2025-08-18T16:20:09+00:00",
  "source_file": "00-Introduction/README.md",
  "language_code": "fi"
}
-->
# Johdanto Model Context Protocoliin (MCP): Miksi se on tärkeä skaalautuville tekoälysovelluksille

[![Johdanto Model Context Protocoliin](../../../translated_images/01.a467036d886b5fb5b9cf7b39bac0e743b6ca0a4a18a492de90061daaf0cc55f0.fi.png)](https://youtu.be/agBbdiOPLQA)

_(Klikkaa yllä olevaa kuvaa katsoaksesi tämän oppitunnin videon)_

Generatiiviset tekoälysovellukset ovat merkittävä edistysaskel, sillä ne mahdollistavat usein käyttäjän vuorovaikutuksen sovelluksen kanssa luonnollisen kielen avulla. Kuitenkin, kun tällaisiin sovelluksiin investoidaan enemmän aikaa ja resursseja, haluat varmistaa, että voit helposti integroida toiminnallisuuksia ja resursseja tavalla, joka on helppo laajentaa, joka tukee useampia malleja ja käsittelee eri mallien erityispiirteitä. Lyhyesti sanottuna generatiivisten tekoälysovellusten rakentaminen on aluksi helppoa, mutta niiden kasvaessa ja monimutkaistuessa sinun on alettava määritellä arkkitehtuuria ja todennäköisesti tukeuduttava standardiin varmistaaksesi, että sovelluksesi rakennetaan johdonmukaisesti. Tässä kohtaa MCP astuu kuvaan järjestämään asiat ja tarjoamaan standardin.

---

## **🔍 Mikä on Model Context Protocol (MCP)?**

**Model Context Protocol (MCP)** on **avoin, standardoitu rajapinta**, joka mahdollistaa suurten kielimallien (LLM) saumattoman vuorovaikutuksen ulkoisten työkalujen, API:iden ja tietolähteiden kanssa. Se tarjoaa yhtenäisen arkkitehtuurin tekoälymallien toiminnallisuuden laajentamiseksi niiden koulutusdatan ulkopuolelle, mahdollistaen älykkäämmät, skaalautuvammat ja reagoivammat tekoälyjärjestelmät.

---

## **🎯 Miksi standardointi tekoälyssä on tärkeää**

Kun generatiiviset tekoälysovellukset monimutkaistuvat, on tärkeää ottaa käyttöön standardeja, jotka takaavat **skaalautuvuuden, laajennettavuuden, ylläpidettävyyden** ja **toimittajalukon välttämisen**. MCP vastaa näihin tarpeisiin:

- Yhdistämällä mallien ja työkalujen integraatiot
- Vähentämällä hauraiden, kertaluonteisten räätälöityjen ratkaisujen tarvetta
- Mahdollistamalla useiden eri toimittajien mallien yhteiselon samassa ekosysteemissä

**Huom:** Vaikka MCP esittää itsensä avoimena standardina, ei ole suunnitelmia standardoida MCP:tä minkään olemassa olevan standardointielimen, kuten IEEE:n, IETF:n, W3C:n, ISO:n tai muiden kautta.

---

## **📚 Oppimistavoitteet**

Tämän artikkelin lopussa osaat:

- Määritellä **Model Context Protocolin (MCP)** ja sen käyttötapaukset
- Ymmärtää, miten MCP standardoi mallien ja työkalujen välisen viestinnän
- Tunnistaa MCP-arkkitehtuurin keskeiset osat
- Tutkia MCP:n todellisia sovelluksia yritys- ja kehityskonteksteissa

---

## **💡 Miksi Model Context Protocol (MCP) on mullistava**

### **🔗 MCP ratkaisee tekoälyvuorovaikutusten pirstaleisuuden**

Ennen MCP:tä mallien ja työkalujen integrointi vaati:

- Räätälöityä koodia jokaiselle työkalu-malliparille
- Ei-standardisoituja API:ita jokaiselle toimittajalle
- Toistuvia ongelmia päivitysten yhteydessä
- Huonoa skaalautuvuutta useampien työkalujen kanssa

### **✅ MCP-standardoinnin hyödyt**

| **Hyöty**                 | **Kuvaus**                                                                     |
|---------------------------|-------------------------------------------------------------------------------|
| Yhteentoimivuus           | LLM:t toimivat saumattomasti eri toimittajien työkalujen kanssa               |
| Johdonmukaisuus           | Yhtenäinen käyttäytyminen eri alustojen ja työkalujen välillä                 |
| Uudelleenkäytettävyys     | Kerran rakennetut työkalut voidaan käyttää eri projekteissa ja järjestelmissä |
| Nopeutettu kehitys        | Kehitysaika lyhenee standardoitujen, plug-and-play-rajapintojen ansiosta      |

---

## **🧱 MCP-arkkitehtuurin yleiskatsaus**

MCP noudattaa **asiakas-palvelin-mallia**, jossa:

- **MCP-isännät** suorittavat tekoälymalleja
- **MCP-asiakkaat** aloittavat pyynnöt
- **MCP-palvelimet** tarjoavat kontekstin, työkalut ja kyvykkyydet

### **Keskeiset komponentit:**

- **Resurssit** – Staattiset tai dynaamiset tiedot malleille  
- **Kehoitteet** – Ennalta määritellyt työnkulut ohjattua generointia varten  
- **Työkalut** – Suoritettavat toiminnot, kuten haku, laskelmat  
- **Näytteenotto** – Agenttimainen käyttäytyminen rekursiivisten vuorovaikutusten kautta  

---

## Miten MCP-palvelimet toimivat

MCP-palvelimet toimivat seuraavasti:

- **Pyyntöprosessi**:
    1. Käyttäjä tai hänen puolestaan toimiva ohjelmisto aloittaa pyynnön.
    2. **MCP-asiakas** lähettää pyynnön **MCP-isännälle**, joka hallinnoi tekoälymallin suoritusympäristöä.
    3. **Tekoälymalli** vastaanottaa käyttäjän kehotteen ja voi pyytää pääsyä ulkoisiin työkaluihin tai tietoihin yhden tai useamman työkalupyynnön kautta.
    4. **MCP-isäntä**, ei malli suoraan, kommunikoi asianmukaisten **MCP-palvelimien** kanssa käyttäen standardoitua protokollaa.
- **MCP-isännän toiminnallisuus**:
    - **Työkalurekisteri**: Ylläpitää luetteloa käytettävissä olevista työkaluista ja niiden kyvykkyyksistä.
    - **Autentikointi**: Varmistaa työkalujen käyttöoikeudet.
    - **Pyyntöjen käsittelijä**: Käsittelee mallilta tulevat työkalupyynnöt.
    - **Vastausmuotoilija**: Muotoilee työkalujen tuotokset mallin ymmärtämään muotoon.
- **MCP-palvelimen suoritus**:
    - **MCP-isäntä** ohjaa työkalupyynnöt yhdelle tai useammalle **MCP-palvelimelle**, jotka tarjoavat erikoistuneita toimintoja (esim. haku, laskelmat, tietokantakyselyt).
    - **MCP-palvelimet** suorittavat tehtävänsä ja palauttavat tulokset **MCP-isännälle** yhtenäisessä muodossa.
    - **MCP-isäntä** muotoilee ja välittää nämä tulokset **tekoälymallille**.
- **Vastauksen viimeistely**:
    - **Tekoälymalli** sisällyttää työkalujen tuotokset lopulliseen vastaukseen.
    - **MCP-isäntä** lähettää tämän vastauksen takaisin **MCP-asiakkaalle**, joka toimittaa sen loppukäyttäjälle tai kutsuvalle ohjelmistolle.

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

## 👨‍💻 Miten rakentaa MCP-palvelin (esimerkkien avulla)

MCP-palvelimet mahdollistavat LLM-kyvykkyyksien laajentamisen tarjoamalla dataa ja toiminnallisuuksia. 

Valmis kokeilemaan? Tässä on kieli- ja/tai stack-kohtaisia SDK:ita esimerkkeineen yksinkertaisten MCP-palvelimien luomiseksi eri kielillä/stäkeillä:

- **Python SDK**: https://github.com/modelcontextprotocol/python-sdk

- **TypeScript SDK**: https://github.com/modelcontextprotocol/typescript-sdk

- **Java SDK**: https://github.com/modelcontextprotocol/java-sdk

- **C#/.NET SDK**: https://github.com/modelcontextprotocol/csharp-sdk

## 🌍 MCP:n todelliset käyttötapaukset

MCP mahdollistaa laajan valikoiman sovelluksia laajentamalla tekoälyn kyvykkyyksiä:

| **Sovellus**               | **Kuvaus**                                                                     |
|----------------------------|-------------------------------------------------------------------------------|
| Yritysdatan integrointi    | Yhdistä LLM:t tietokantoihin, CRM-järjestelmiin tai sisäisiin työkaluihin     |
| Agenttimaiset tekoälyjärjestelmät | Mahdollista autonomiset agentit työkalujen käytöllä ja päätöksentekotyönkuluilla |
| Multimodaaliset sovellukset | Yhdistä teksti-, kuva- ja äänityökalut yhteen yhtenäiseen tekoälysovellukseen |
| Reaaliaikainen dataintegraatio | Tuo reaaliaikainen data tekoälyvuorovaikutuksiin tarkempia ja ajantasaisempia tuloksia varten |

### 🧠 MCP = Yleinen standardi tekoälyvuorovaikutuksille

Model Context Protocol (MCP) toimii yleisenä standardina tekoälyvuorovaikutuksille, aivan kuten USB-C standardoi fyysiset liitännät laitteille. Tekoälyn maailmassa MCP tarjoaa yhtenäisen rajapinnan, joka mahdollistaa mallien (asiakkaiden) saumattoman integraation ulkoisten työkalujen ja tietolähteiden (palvelimien) kanssa. Tämä poistaa tarpeen moninaisille, räätälöidyille protokollille jokaiselle API:lle tai tietolähteelle.

MCP:n alaisuudessa MCP-yhteensopiva työkalu (jota kutsutaan MCP-palvelimeksi) noudattaa yhtenäistä standardia. Nämä palvelimet voivat listata tarjoamansa työkalut tai toiminnot ja suorittaa niitä tekoälyagentin pyynnöstä. MCP:tä tukevat tekoälyalustat voivat löytää palvelimien tarjoamat työkalut ja kutsua niitä tämän standardoidun protokollan kautta.

### 💡 Mahdollistaa tiedon hyödyntämisen

Työkalujen tarjoamisen lisäksi MCP mahdollistaa tiedon hyödyntämisen. Se mahdollistaa sovellusten tarjoavan kontekstia suurille kielimalleille (LLM) yhdistämällä ne erilaisiin tietolähteisiin. Esimerkiksi MCP-palvelin voi edustaa yrityksen dokumenttivarastoa, jolloin agentit voivat hakea tarvittavaa tietoa tarpeen mukaan. Toinen palvelin voi hoitaa tiettyjä toimintoja, kuten sähköpostien lähettämistä tai tietueiden päivittämistä. Agentin näkökulmasta nämä ovat yksinkertaisesti työkaluja, joita se voi käyttää—jotkut työkalut palauttavat dataa (tietokonteksti), kun taas toiset suorittavat toimintoja. MCP hallitsee molemmat tehokkaasti.

Agentti, joka yhdistyy MCP-palvelimeen, oppii automaattisesti palvelimen tarjoamat kyvykkyydet ja käytettävissä olevan datan standardoidussa muodossa. Tämä standardointi mahdollistaa dynaamisen työkalujen saatavuuden. Esimerkiksi uuden MCP-palvelimen lisääminen agentin järjestelmään tekee sen toiminnot heti käytettäviksi ilman, että agentin ohjeita tarvitsee mukauttaa.

Tämä virtaviivaistettu integraatio vastaa seuraavassa kaaviossa kuvattua virtausta, jossa palvelimet tarjoavat sekä työkaluja että tietoa, varmistaen saumattoman yhteistyön järjestelmien välillä.

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

### 🔄 Edistyneet MCP-skenaariot asiakaspuolen LLM-integraatiolla

Perus-MCP-arkkitehtuurin lisäksi on olemassa edistyneitä skenaarioita, joissa sekä asiakas- että palvelinpuolella on LLM:itä, mahdollistaen monimutkaisempia vuorovaikutuksia. Seuraavassa kaaviossa **asiakassovellus** voi olla IDE, jossa on useita MCP-työkaluja käyttäjän LLM:n käytettävissä:

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

Tässä ovat MCP:n käytännön hyödyt:

- **Ajantasaisuus**: Mallit voivat käyttää ajankohtaista tietoa koulutusdatan ulkopuolelta
- **Kyvykkyyksien laajentaminen**: Mallit voivat hyödyntää erikoistyökaluja tehtäviin, joihin niitä ei ole koulutettu
- **Vähentyneet hallusinaatiot**: Ulkoiset tietolähteet tarjoavat faktapohjaa
- **Yksityisyys**: Arkaluontoiset tiedot voivat pysyä turvallisissa ympäristöissä sen sijaan, että ne sisällytettäisiin kehotteisiin

## 📌 Keskeiset opit

Seuraavat ovat keskeisiä oppeja MCP:n käytöstä:

- **MCP** standardoi, miten tekoälymallit vuorovaikuttavat työkalujen ja datan kanssa
- Edistää **laajennettavuutta, johdonmukaisuutta ja yhteentoimivuutta**
- MCP auttaa **lyhentämään kehitysaikaa, parantamaan luotettavuutta ja laajentamaan mallien kyvykkyyksiä**
- Asiakas-palvelin-arkkitehtuuri mahdollistaa **joustavat, laajennettavat tekoälysovellukset**

## 🧠 Harjoitus

Ajattele tekoälysovellusta, jonka haluaisit rakentaa.

- Mitkä **ulkoiset työkalut tai tiedot** voisivat parantaa sen kyvykkyyksiä?
- Miten MCP voisi tehdä integraatiosta **yksinkertaisempaa ja luotettavampaa**?

## Lisäresurssit

- [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## Mitä seuraavaksi

Seuraavaksi: [Luku 1: Peruskäsitteet](../01-CoreConcepts/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäisellä kielellä tulisi pitää ensisijaisena lähteenä. Kriittisen tiedon osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.