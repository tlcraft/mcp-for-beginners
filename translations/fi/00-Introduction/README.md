<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "25a94c681cf43612ff394d8cf78a74de",
  "translation_date": "2025-05-27T16:06:59+00:00",
  "source_file": "00-Introduction/README.md",
  "language_code": "fi"
}
-->
# Johdanto Model Context Protocoliin (MCP): Miksi se on tärkeä skaalautuville tekoälysovelluksille

Generatiiviset tekoälysovellukset ovat suuri edistysaskel, sillä ne mahdollistavat käyttäjän vuorovaikutuksen sovelluksen kanssa luonnollisella kielellä. Kuitenkin, kun sovelluksiin investoidaan enemmän aikaa ja resursseja, haluat varmistaa, että voit helposti integroida toiminnallisuuksia ja resursseja siten, että sovellusta on helppo laajentaa, että se pystyy käsittelemään useamman mallin samanaikaisesti ja hallitsemaan mallien erilaisia yksityiskohtia. Lyhyesti sanottuna, generatiivisten tekoälysovellusten rakentaminen on aluksi helppoa, mutta kun ne kasvavat ja monimutkaistuvat, täytyy alkaa määritellä arkkitehtuuria ja todennäköisesti luottaa standardiin, jotta sovellukset rakennetaan johdonmukaisesti. Tässä MCP astuu kuvaan järjestämään asiat ja tarjoamaan standardin.

---

## **🔍 Mikä on Model Context Protocol (MCP)?**

**Model Context Protocol (MCP)** on **avoin, standardoitu rajapinta**, joka mahdollistaa suurten kielimallien (LLM) saumattoman vuorovaikutuksen ulkoisten työkalujen, API:en ja tietolähteiden kanssa. Se tarjoaa yhtenäisen arkkitehtuurin tekoälymallien toiminnallisuuden laajentamiseksi koulutusdatan ulkopuolelle, mahdollistaen älykkäämmät, skaalautuvat ja reagoivammat tekoälyjärjestelmät.

---

## **🎯 Miksi standardisointi tekoälyssä on tärkeää**

Kun generatiiviset tekoälysovellukset monimutkaistuvat, on välttämätöntä ottaa käyttöön standardeja, jotka takaavat **skaalautuvuuden, laajennettavuuden** ja **ylläpidettävyyden**. MCP vastaa näihin tarpeisiin:

- Yhdistämällä mallit ja työkalut yhtenäiseksi kokonaisuudeksi
- Vähentämällä hauraita, kertakäyttöisiä räätälöityjä ratkaisuja
- Mahdollistamalla useiden mallien rinnakkaisen käytön yhdessä ekosysteemissä

---

## **📚 Oppimistavoitteet**

Tämän artikkelin lopussa osaat:

- Määritellä **Model Context Protocolin (MCP)** ja sen käyttötapaukset
- Ymmärtää, miten MCP standardisoi mallin ja työkalun välisen viestinnän
- Tunnistaa MCP-arkkitehtuurin keskeiset osat
- Tutkia MCP:n käytännön sovelluksia yritys- ja kehitysympäristöissä

---

## **💡 Miksi Model Context Protocol (MCP) on mullistava**

### **🔗 MCP ratkaisee tekoälyn vuorovaikutuksen pirstaloitumisen**

Ennen MCP:tä mallien yhdistäminen työkaluihin vaati:

- Räätälöityä koodia jokaista työkalu-malli-paria varten
- Ei-standardisoituja API-rajapintoja jokaiselta toimittajalta
- Usein katkeavia yhteyksiä päivitysten vuoksi
- Huonoa skaalautuvuutta työkalujen määrän kasvaessa

### **✅ MCP-standardoinnin hyödyt**

| **Hyöty**                | **Kuvaus**                                                                    |
|--------------------------|-------------------------------------------------------------------------------|
| Yhteensopivuus           | LLM:t toimivat saumattomasti eri toimittajien työkalujen kanssa              |
| Johdonmukaisuus          | Tasainen käyttäytyminen eri alustoilla ja työkaluissa                        |
| Uudelleenkäytettävyys    | Kerran rakennettuja työkaluja voi käyttää useissa projekteissa ja järjestelmissä |
| Kehityksen nopeutuminen  | Kehitysaika lyhenee standardoitujen, plug-and-play -rajapintojen ansiosta    |

---

## **🧱 MCP-arkkitehtuurin yleiskuva**

MCP perustuu **asiakas-palvelin-malliin**, jossa:

- **MCP Hosts** pyörittävät tekoälymalleja  
- **MCP Clients** aloittavat pyyntöjä  
- **MCP Servers** tarjoavat kontekstin, työkalut ja ominaisuudet  

### **Keskeiset osat:**

- **Resurssit** – Staattiset tai dynaamiset tiedot malleille  
- **Kehotteet** – Ennalta määritellyt työnkulut ohjattuun generointiin  
- **Työkalut** – Suoritettavat funktiot kuten haku, laskelmat  
- **Näytteistys** – Agenttimainen käyttäytyminen rekursiivisten vuorovaikutusten kautta  

---

## Kuinka MCP-palvelimet toimivat

MCP-palvelimet toimivat seuraavasti:

- **Pyyntöjen kulku**:  
    1. MCP Client lähettää pyynnön AI-mallille, joka toimii MCP Hostissa.  
    2. AI-malli tunnistaa, milloin se tarvitsee ulkoisia työkaluja tai dataa.  
    3. Malli kommunikoi MCP Serverin kanssa standardoidun protokollan avulla.

- **MCP Serverin toiminnot**:  
    - Työkalurekisteri: Ylläpitää luetteloa käytettävissä olevista työkaluista ja niiden ominaisuuksista.  
    - Autentikointi: Tarkistaa käyttöoikeudet työkaluihin.  
    - Pyyntöjen käsittelijä: Käsittelee mallilta tulevat työkalupyyntöjä.  
    - Vastausten muotoilija: Jäsentää työkalujen tuotokset mallin ymmärtämään muotoon.

- **Työkalujen suoritus**:  
    - Palvelin ohjaa pyynnöt oikeille ulkoisille työkaluille  
    - Työkalut suorittavat erikoistuneet toiminnot (haku, laskenta, tietokantakyselyt jne.)  
    - Tulokset palautetaan mallille yhtenäisessä muodossa.

- **Vastauksen viimeistely**:  
    - AI-malli liittää työkalujen tuotokset vastaukseensa.  
    - Lopullinen vastaus lähetetään takaisin asiakassovellukselle.

```mermaid
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

## 👨‍💻 Kuinka rakentaa MCP-palvelin (esimerkkien kera)

MCP-palvelimet mahdollistavat LLM:n toimintojen laajentamisen tarjoamalla dataa ja toiminnallisuutta.

Valmis kokeilemaan? Tässä esimerkkejä yksinkertaisen MCP-palvelimen luomisesta eri kielillä:

- **Python-esimerkki**: https://github.com/modelcontextprotocol/python-sdk

- **TypeScript-esimerkki**: https://github.com/modelcontextprotocol/typescript-sdk

- **Java-esimerkki**: https://github.com/modelcontextprotocol/java-sdk

- **C#/.NET-esimerkki**: https://github.com/modelcontextprotocol/csharp-sdk

## 🌍 MCP:n käytännön sovelluksia

MCP mahdollistaa monipuolisia sovelluksia laajentamalla tekoälyn kyvykkyyksiä:

| **Sovellus**                | **Kuvaus**                                                                    |
|----------------------------|-------------------------------------------------------------------------------|
| Yritysten dataintegraatio  | Yhdistää LLM:t tietokantoihin, CRM-järjestelmiin tai sisäisiin työkaluihin   |
| Agenttipohjaiset tekoälyjärjestelmät | Mahdollistaa autonomiset agentit työkalujen käyttöoikeuksilla ja päätöksentekotyönkuluilla |
| Monimodaaliset sovellukset | Yhdistää teksti-, kuva- ja ääni-työkalut yhteen yhtenäiseen tekoälysovellukseen |
| Reaaliaikainen dataintegraatio | Tuo live-dataa tekoälyn vuorovaikutuksiin tarkempien ja ajankohtaisten tulosten saavuttamiseksi |

### 🧠 MCP = Universaali standardi tekoälyn vuorovaikutuksille

Model Context Protocol toimii tekoälyn vuorovaikutusten universaalina standardina, aivan kuten USB-C standardisoi laitteiden fyysiset liitännät. Tekoälyn maailmassa MCP tarjoaa yhdenmukaisen rajapinnan, jonka avulla mallit (asiakkaat) voivat integroitua saumattomasti ulkoisiin työkaluihin ja datan tarjoajiin (palvelimet). Tämä poistaa tarpeen käyttää erilaisia, räätälöityjä protokollia jokaiselle API:lle tai tietolähteelle.

MCP-yhteensopiva työkalu (eli MCP-palvelin) noudattaa yhtenäistä standardia. Nämä palvelimet voivat listata tarjoamansa työkalut tai toiminnot ja suorittaa ne, kun tekoälyagentti niitä pyytää. MCP:tä tukevat tekoälyagenttialustat pystyvät löytämään palvelimien tarjoamat työkalut ja kutsumaan niitä tämän standardin kautta.

### 💡 Helpottaa tiedon saatavuutta

Työkalujen tarjoamisen lisäksi MCP helpottaa tiedon saatavuutta. Se mahdollistaa sovellusten tarjoavan kontekstia suurille kielimalleille linkittämällä ne erilaisiin tietolähteisiin. Esimerkiksi MCP-palvelin voi edustaa yrityksen dokumenttivarastoa, jolloin agentit voivat hakea tarpeellista tietoa pyynnöstä. Toinen palvelin voi hoitaa tiettyjä toimintoja, kuten sähköpostien lähettämistä tai tietueiden päivittämistä. Agentin näkökulmasta nämä ovat vain työkaluja — jotkut palauttavat dataa (tietokontekstia), toiset suorittavat toimintoja. MCP hallinnoi molempia tehokkaasti.

Agentti, joka yhdistyy MCP-palvelimeen, oppii automaattisesti palvelimen käytettävissä olevat ominaisuudet ja saatavilla olevan datan standardoidun muodon kautta. Tämä standardisointi mahdollistaa työkalujen dynaamisen saatavuuden. Esimerkiksi uuden MCP-palvelimen lisääminen agentin järjestelmään tekee sen toiminnot heti käytettäväksi ilman, että agentin ohjeita tarvitsee muuttaa.

Tämä virtaviivainen integraatio vastaa mermaid-kaaviossa kuvattua toimintaa, jossa palvelimet tarjoavat sekä työkaluja että tietoa, varmistaen sujuvan yhteistyön järjestelmien välillä.

### 👉 Esimerkki: Skaalautuva agenttiratkaisu

```mermaid
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

### 🔄 Kehittyneet MCP-skenaariot asiakaspuolen LLM-integraatiolla

Perus MCP-arkkitehtuurin lisäksi on kehittyneitä skenaarioita, joissa sekä asiakas että palvelin sisältävät LLM-malleja, mahdollistaen monipuolisemmat vuorovaikutukset:

```mermaid
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

- **Ajantasaisuus**: Mallit pääsevät käsiksi päivitettyyn tietoon koulutusdatan ulkopuolelta  
- **Kyvykkyyksien laajennus**: Mallit voivat hyödyntää erikoistyökaluja tehtäviin, joihin niitä ei ole koulutettu  
- **Harhojen vähentäminen**: Ulkoiset tietolähteet tarjoavat faktapohjan  
- **Yksityisyys**: Herkkä data voi pysyä suojatuissa ympäristöissä sen sijaan, että se upotettaisiin kehotteisiin

## 📌 Keskeiset opit

Tärkeimmät asiat MCP:n käytöstä:

- **MCP** standardisoi, miten tekoälymallit kommunikoivat työkalujen ja datan kanssa  
- Edistää **laajennettavuutta, johdonmukaisuutta ja yhteensopivuutta**  
- MCP auttaa **vähentämään kehitysaikaa, parantamaan luotettavuutta ja laajentamaan mallien kyvykkyyksiä**  
- Asiakas-palvelin-arkkitehtuuri mahdollistaa **joustavat, laajennettavat tekoälysovellukset**

## 🧠 Harjoitus

Mieti tekoälysovellusta, jota haluaisit rakentaa.

- Mitkä **ulkoiset työkalut tai data** voisivat parantaa sen kyvykkyyksiä?  
- Miten MCP voisi tehdä integraatiosta **yksinkertaisempaa ja luotettavampaa?**

## Lisäresurssit

- [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## Mitä seuraavaksi

Seuraava: [Luku 1: Keskeiset käsitteet](/01-CoreConcepts/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty tekoälypohjaisella käännöspalvelulla [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäiskielellä on virallinen lähde. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.