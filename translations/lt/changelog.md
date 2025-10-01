<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T22:55:01+00:00",
  "source_file": "changelog.md",
  "language_code": "lt"
}
-->
# Keitimų žurnalas: MCP pradedančiųjų mokymo programa

Šis dokumentas yra visų reikšmingų pakeitimų, atliktų Model Context Protocol (MCP) pradedančiųjų mokymo programoje, įrašas. Pakeitimai dokumentuojami atvirkštine chronologine tvarka (naujausi pakeitimai pirmiausia).

## 2025 m. rugsėjo 29 d.

### MCP serverio duomenų bazės integracijos laboratorijos – išsamus praktinis mokymosi kelias

#### 11-MCPServerHandsOnLabs – nauja pilna duomenų bazės integracijos mokymo programa
- **Pilnas 13 laboratorijų mokymosi kelias**: Pridėta išsami praktinė mokymo programa, skirta kurti gamybai paruoštus MCP serverius su PostgreSQL duomenų bazės integracija
  - **Praktinis pritaikymas**: Zava Retail analitikos atvejis, demonstruojantis įmonės lygio modelius
  - **Struktūrizuotas mokymosi progresas**:
    - **Laboratorijos 00-03: Pagrindai** – Įvadas, pagrindinė architektūra, saugumas ir daugiaklientė aplinka, aplinkos nustatymas
    - **Laboratorijos 04-06: MCP serverio kūrimas** – Duomenų bazės dizainas ir schema, MCP serverio įgyvendinimas, įrankių kūrimas  
    - **Laboratorijos 07-09: Pažangios funkcijos** – Semantinės paieškos integracija, testavimas ir derinimas, VS Code integracija
    - **Laboratorijos 10-12: Gamyba ir geriausios praktikos** – Diegimo strategijos, stebėjimas ir stebimumas, geriausios praktikos ir optimizavimas
  - **Įmonės technologijos**: FastMCP karkasas, PostgreSQL su pgvector, Azure OpenAI embeddings, Azure Container Apps, Application Insights
  - **Pažangios funkcijos**: Eilutės lygio saugumas (RLS), semantinė paieška, daugiaklientė duomenų prieiga, vektoriniai embeddings, realaus laiko stebėjimas

#### Terminologijos standartizavimas – modulio keitimas į laboratoriją
- **Išsamus dokumentacijos atnaujinimas**: Sistemingai atnaujinti visi README failai 11-MCPServerHandsOnLabs, kad būtų naudojama „Laboratorijos“ terminologija vietoj „Modulio“
  - **Skyriaus antraštės**: „Ką apima šis modulis“ pakeista į „Ką apima ši laboratorija“ visose 13 laboratorijų
  - **Turinio aprašymas**: „Šis modulis suteikia...“ pakeista į „Ši laboratorija suteikia...“ visoje dokumentacijoje
  - **Mokymosi tikslai**: „Iki šio modulio pabaigos...“ pakeista į „Iki šios laboratorijos pabaigos...“
  - **Navigacijos nuorodos**: Visos „Modulis XX:“ nuorodos pakeistos į „Laboratorija XX:“ kryžminėse nuorodose ir navigacijoje
  - **Užbaigimo stebėjimas**: „Baigus šį modulį...“ pakeista į „Baigus šią laboratoriją...“
  - **Techninių nuorodų išsaugojimas**: Išlaikytos Python modulio nuorodos konfigūracijos failuose (pvz., `"module": "mcp_server.main"`)

#### Mokymosi vadovo patobulinimas (study_guide.md)
- **Vizualus mokymo programos žemėlapis**: Pridėta nauja „11. Duomenų bazės integracijos laboratorijos“ sekcija su išsamia laboratorijų struktūros vizualizacija
- **Saugyklos struktūra**: Atnaujinta nuo dešimties iki vienuolikos pagrindinių sekcijų su detaliu 11-MCPServerHandsOnLabs aprašymu
- **Mokymosi kelio gairės**: Patobulintos navigacijos instrukcijos, apimančios sekcijas 00-11
- **Technologijų aprėptis**: Pridėta FastMCP, PostgreSQL, Azure paslaugų integracijos detalės
- **Mokymosi rezultatai**: Pabrėžtas gamybai paruoštų serverių kūrimas, duomenų bazės integracijos modeliai ir įmonės saugumas

#### Pagrindinio README struktūros patobulinimas
- **Laboratorijų terminologija**: Atnaujintas pagrindinis README.md 11-MCPServerHandsOnLabs, kad būtų nuosekliai naudojama „Laboratorijos“ struktūra
- **Mokymosi kelio organizavimas**: Aiškus progresas nuo pagrindinių koncepcijų iki pažangaus įgyvendinimo ir gamybos diegimo
- **Praktinis dėmesys**: Akcentuojamas praktinis, laboratorijomis pagrįstas mokymasis su įmonės lygio modeliais ir technologijomis

### Dokumentacijos kokybės ir nuoseklumo patobulinimai
- **Praktinio mokymosi akcentas**: Sustiprintas praktinis, laboratorijomis pagrįstas požiūris visoje dokumentacijoje
- **Įmonės modelių dėmesys**: Pabrėžtas gamybai paruoštų įgyvendinimų ir įmonės saugumo aspektai
- **Technologijų integracija**: Išsamiai aprašytos modernios Azure paslaugos ir AI integracijos modeliai
- **Mokymosi progresas**: Aiškus, struktūrizuotas kelias nuo pagrindinių koncepcijų iki gamybos diegimo

## 2025 m. rugsėjo 26 d.

### Atvejų studijų patobulinimas – GitHub MCP registracijos integracija

#### Atvejų studijos (09-CaseStudy/) – dėmesys ekosistemos plėtrai
- **README.md**: Didelis išplėtimas su išsamia GitHub MCP registracijos atvejo studija
  - **GitHub MCP registracijos atvejo studija**: Nauja išsami atvejo studija, nagrinėjanti GitHub MCP registracijos paleidimą 2025 m. rugsėjį
    - **Problemos analizė**: Išsamus suskaidytos MCP serverių paieškos ir diegimo iššūkių nagrinėjimas
    - **Sprendimo architektūra**: GitHub centralizuotos registracijos požiūris su vieno paspaudimo VS Code diegimu
    - **Verslo poveikis**: Matomi patobulinimai kūrėjų įsitraukime ir produktyvume
    - **Strateginė vertė**: Dėmesys modulinio agento diegimui ir kryžminiam įrankių suderinamumui
    - **Ekosistemos plėtra**: Pozicionavimas kaip pagrindinė platforma agentų integracijai
  - **Patobulinta atvejo studijų struktūra**: Atnaujintos visos septynios atvejų studijos su nuosekliu formatavimu ir išsamiais aprašymais
    - Azure AI kelionių agentai: Dėmesys daugiagentinei orkestracijai
    - Azure DevOps integracija: Dėmesys darbo eigos automatizavimui
    - Dokumentacijos gavimas realiu laiku: Python konsolės kliento įgyvendinimas
    - Interaktyvus mokymosi plano generatorius: Chainlit pokalbių internetinė programėlė
    - Dokumentacija redaktoriuje: VS Code ir GitHub Copilot integracija
    - Azure API valdymas: Įmonės API integracijos modeliai
    - GitHub MCP registracija: Ekosistemos plėtra ir bendruomenės platforma
  - **Išsamios išvados**: Perrašyta išvadų sekcija, pabrėžianti septynias atvejų studijas, apimančias įvairius MCP įgyvendinimo aspektus
    - Įmonės integracija, daugiagentinė orkestracija, kūrėjų produktyvumas
    - Ekosistemos plėtra, edukacinės aplikacijos kategorijos
    - Patobulintos įžvalgos apie architektūros modelius, įgyvendinimo strategijas ir geriausias praktikas
    - Akcentas MCP kaip brandžiam, gamybai paruoštam protokolui

#### Mokymosi vadovo atnaujinimai (study_guide.md)
- **Vizualus mokymo programos žemėlapis**: Atnaujintas minčių žemėlapis, įtraukiant GitHub MCP registraciją į atvejų studijų sekciją
- **Atvejų studijų aprašymas**: Patobulintas nuo bendrų aprašymų iki detalių septynių išsamių atvejų studijų aprašymų
- **Saugyklos struktūra**: Atnaujinta 10 sekcija, atspindinti išsamų atvejų studijų aprėptį su konkrečiomis įgyvendinimo detalėmis
- **Keitimų žurnalo integracija**: Pridėta 2025 m. rugsėjo 26 d. įrašas, dokumentuojantis GitHub MCP registracijos pridėjimą ir atvejų studijų patobulinimus
- **Datos atnaujinimai**: Atnaujintas poraštės laiko žymeklis, atspindintis naujausią peržiūrą (2025 m. rugsėjo 26 d.)

### Dokumentacijos kokybės patobulinimai
- **Nuoseklumo patobulinimas**: Standartizuotas atvejų studijų formatavimas ir struktūra visose septyniose pavyzdžiuose
- **Išsamus aprėptis**: Atvejų studijos dabar apima įmonės, kūrėjų produktyvumo ir ekosistemos plėtros scenarijus
- **Strateginis pozicionavimas**: Sustiprintas dėmesys MCP kaip pagrindinei platformai agentų sistemų diegimui
- **Resursų integracija**: Atnaujinti papildomi resursai, įtraukiant GitHub MCP registracijos nuorodą

## 2025 m. rugsėjo 15 d.

### Pažangių temų plėtra – pritaikyti transportai ir konteksto inžinerija

#### MCP pritaikyti transportai (05-AdvancedTopics/mcp-transport/) – naujas pažangus įgyvendinimo vadovas
- **README.md**: Pilnas pritaikytų MCP transporto mechanizmų įgyvendinimo vadovas
  - **Azure Event Grid transportas**: Išsamus serverless įvykių pagrindu veikiančio transporto įgyvendinimas
    - C#, TypeScript ir Python pavyzdžiai su Azure Functions integracija
    - Įvykių pagrindu veikiančios architektūros modeliai, skirti mastelio MCP sprendimams
    - Webhook gavėjai ir pranešimų apdorojimas stūmimo pagrindu
  - **Azure Event Hubs transportas**: Didelio pralaidumo srautinio transporto įgyvendinimas
    - Realiojo laiko srautinės galimybės mažo delsimo scenarijams
    - Skirstymo strategijos ir kontrolės taškų valdymas
    - Pranešimų grupavimas ir našumo optimizavimas
  - **Įmonės integracijos modeliai**: Gamybai paruošti architektūros pavyzdžiai
    - Paskirstytas MCP apdorojimas per kelias Azure Functions
    - Hibridinės transporto architektūros, derinančios kelis transporto tipus
    - Pranešimų patvarumas, patikimumas ir klaidų tvarkymo strategijos
  - **Saugumas ir stebėjimas**: Azure Key Vault integracija ir stebimumo modeliai
    - Valdomos tapatybės autentifikacija ir minimalios privilegijos prieiga
    - Application Insights telemetrija ir našumo stebėjimas
    - Apsaugos pertraukikliai ir gedimų tolerancijos modeliai
  - **Testavimo sistemos**: Išsamios testavimo strategijos pritaikytiems transportams
    - Vienetinis testavimas su testavimo dvigubais ir imitavimo sistemomis
    - Integracijos testavimas su Azure Test Containers
    - Našumo ir apkrovos testavimo aspektai

#### Konteksto inžinerija (05-AdvancedTopics/mcp-contextengineering/) – nauja AI disciplina
- **README.md**: Išsamus konteksto inžinerijos kaip naujos srities tyrimas
  - **Pagrindiniai principai**: Pilnas konteksto dalijimasis, veiksmų sprendimų supratimas ir konteksto lango valdymas
  - **MCP protokolo suderinamumas**: Kaip MCP dizainas sprendžia konteksto inžinerijos iššūkius
    - Konteksto lango apribojimai ir progresyvaus įkėlimo strategijos
    - Reikšmingumo nustatymas ir dinaminis konteksto gavimas
    - Daugiarūšio konteksto tvarkymas ir saugumo aspektai
  - **Įgyvendinimo metodai**: Vieno gijos ir daugiagentės architektūros
    - Konteksto skaidymas ir prioritetų nustatymo technikos
    - Progresyvus konteksto įkėlimas ir suspaudimo strategijos
    - Sluoksniuotas konteksto požiūris ir gavimo optimizavimas
  - **Matavimo sistema**: Nauji metrikos konteksto efektyvumo vertinimui
    - Įvesties efektyvumas, našumas, kokybė ir vartotojo patirties aspektai
    - Eksperimentiniai konteksto optimizavimo metodai
    - Klaidų analizė ir tobulinimo metodologijos

#### Mokymo programos navigacijos atnaujinimai (README.md)
- **Patobulinta modulio struktūra**: Atnaujinta mokymo programos lentelė, įtraukiant naujas pažangias temas
  - Pridėta Konteksto inžinerija (5.14) ir Pritaikyti transportai (5.15)
  - Nuoseklus formatavimas ir navigacijos nuorodos visiems moduliams
  - Atnaujinti aprašymai, atspindintys dabartinį turinio apimtį

### Katalogo struktūros patobulinimai
- **Pavadinimų standartizavimas**: Pervadinta „mcp transport“ į „mcp-transport“, kad būtų nuosekliai su kitais pažangių temų katalogais
- **Turinio organizavimas**: Visi 05-AdvancedTopics katalogai dabar laikosi nuoseklaus pavadinimų modelio (mcp-[tema])

### Dokumentacijos kokybės patobulinimai
- **MCP specifikacijos suderinamumas**: Visas naujas turinys remiasi dabartine MCP specifikacija 2025-06-18
- **Daugiakalbiai pavyzdžiai**: Išsamūs kodų pavyzdžiai C#, TypeScript ir Python
- **Įmonės dėmesys**: Gamybai paruošti modeliai ir Azure debesų integracija visame turinyje
- **Vizualinė dokumentacija**: Mermaid diagramos architektūros ir srauto vizualizacijai

## 2025 m. rugpjūčio 18 d.

### Dokumentacijos išsamus atnaujinimas – MCP 2025-06-18 standartai

#### MCP saugumo geriausios praktikos (02-Security/) – visiška modernizacija
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Visiškas perrašymas, suderintas su MCP specifikacija 2025-06-18
  - **Privalomi reikalavimai**: Pridėti aiškūs MUST/MUST NOT reikalavimai iš oficialios specifikacijos su aiškiais vizualiniais indikatoriais
  - **12 pagrindinių saugumo praktikų**: Pertvarkyta iš 15 punktų sąrašo į išsamius saugumo domenus
    - Žetonų saugumas ir autentifikacija su išorinių tapatybės teikėjų integracija
    - Sesijos valdymas ir transporto saugumas su kriptografiniais reikalavimais
    - AI specifinė grėsmių apsauga su Microsoft Prompt Shields integracija
    - Prieigos kontrolė ir leidimai su minimalios privilegijos principu
    - Turinio saugumas ir stebėjimas su Azure Content Safety integracija
    - Tiekimo grandinės saugumas su išsamiu komponentų patikrinimu
    - OAuth saugumas ir „Confused Deputy“ prevencija su PKCE įgyvendinimu
    - Incidentų reagavimas ir atkūrimas su automatizuotomis galimybėmis
    - Atitiktis ir valdymas su reguliavimo suderinamumu
    - Pažangios saugumo kontrolės su „Zero Trust“ architektūra
    - Microsoft saugumo ekosistemos integracija su išsamiais sprendimais
    - Nuolatin
- **Vizualiniai indikatoriai**: Aiškus privalomų reikalavimų ir rekomenduojamų praktikų žymėjimas

#### Pagrindinės sąvokos (01-CoreConcepts/) - Visiška modernizacija
- **Protokolo versijos atnaujinimas**: Atnaujinta, kad būtų nurodyta dabartinė MCP specifikacija 2025-06-18 su datų pagrindu versijavimu (YYYY-MM-DD formatas)
- **Architektūros patobulinimas**: Patobulinti aprašymai apie Host'us, Klientus ir Serverius, atspindint dabartinius MCP architektūros modelius
  - Host'ai dabar aiškiai apibrėžti kaip AI programos, koordinuojančios kelias MCP klientų jungtis
  - Klientai apibūdinti kaip protokolo jungtys, palaikančios vienas su vienu santykius su serveriais
  - Serveriai patobulinti, apimant vietinio ir nuotolinio diegimo scenarijus
- **Primitivų restruktūrizavimas**: Visiškas serverio ir kliento primitivų pertvarkymas
  - Serverio primityvai: Ištekliai (duomenų šaltiniai), Šablonai (prompt'ai), Įrankiai (vykdomos funkcijos) su išsamiais paaiškinimais ir pavyzdžiais
  - Kliento primityvai: Mėginių ėmimas (LLM užbaigimai), Informacijos rinkimas (vartotojo įvestis), Žurnalavimas (derinimas/stebėjimas)
  - Atnaujinta pagal dabartinius atradimo (`*/list`), gavimo (`*/get`) ir vykdymo (`*/call`) metodų modelius
- **Protokolo architektūra**: Įvesta dviejų sluoksnių architektūros modelis
  - Duomenų sluoksnis: JSON-RPC 2.0 pagrindas su gyvavimo ciklo valdymu ir primityvais
  - Transporto sluoksnis: STDIO (vietinis) ir Streamable HTTP su SSE (nuotolinis) transporto mechanizmais
- **Saugumo sistema**: Išsamūs saugumo principai, įskaitant aiškų vartotojo sutikimą, duomenų privatumo apsaugą, įrankių vykdymo saugumą ir transporto sluoksnio saugumą
- **Komunikacijos modeliai**: Atnaujinti protokolo pranešimai, rodantys inicijavimo, atradimo, vykdymo ir pranešimų srautus
- **Kodo pavyzdžiai**: Atnaujinti daugiakalbiai pavyzdžiai (.NET, Java, Python, JavaScript), atspindintys dabartinius MCP SDK modelius

#### Saugumas (02-Security/) - Išsamus saugumo pertvarkymas  
- **Standartų suderinimas**: Visiškas suderinimas su MCP specifikacijos 2025-06-18 saugumo reikalavimais
- **Autentifikacijos evoliucija**: Dokumentuota evoliucija nuo individualių OAuth serverių iki išorinių tapatybės tiekėjų delegavimo (Microsoft Entra ID)
- **AI-specifinių grėsmių analizė**: Patobulinta šiuolaikinių AI atakų vektorių aprėptis
  - Išsamūs prompt injekcijos atakų scenarijai su realiais pavyzdžiais
  - Įrankių užnuodijimo mechanizmai ir "kilimo patraukimo" atakų modeliai
  - Konteksto lango užnuodijimas ir modelio painiavos atakos
- **Microsoft AI saugumo sprendimai**: Išsamus Microsoft saugumo ekosistemos aprėptis
  - AI Prompt Shields su pažangia aptikimo, išryškinimo ir skyriklio technika
  - Azure turinio saugumo integracijos modeliai
  - GitHub Advanced Security tiekimo grandinės apsaugai
- **Pažangios grėsmių mažinimo priemonės**: Išsamios saugumo kontrolės
  - Sesijos užgrobimas su MCP-specifiniais atakų scenarijais ir kriptografiniais sesijos ID reikalavimais
  - Supainioto tarpininko problemos MCP proxy scenarijuose su aiškiais sutikimo reikalavimais
  - Tokenų perdavimo pažeidžiamumai su privalomais validacijos kontrolės mechanizmais
- **Tiekimo grandinės saugumas**: Išplėsta AI tiekimo grandinės aprėptis, apimanti bazinius modelius, įterpimo paslaugas, konteksto tiekėjus ir trečiųjų šalių API
- **Pagrindinis saugumas**: Patobulinta integracija su įmonės saugumo modeliais, įskaitant nulinio pasitikėjimo architektūrą ir Microsoft saugumo ekosistemą
- **Išteklių organizavimas**: Kategorizuoti išsamūs išteklių nuorodos pagal tipą (Oficialūs dokumentai, Standartai, Tyrimai, Microsoft sprendimai, Įgyvendinimo vadovai)

### Dokumentacijos kokybės patobulinimai
- **Struktūruoti mokymosi tikslai**: Patobulinti mokymosi tikslai su konkrečiais, veiksmais pagrįstais rezultatais
- **Kryžminės nuorodos**: Pridėtos nuorodos tarp susijusių saugumo ir pagrindinių sąvokų temų
- **Dabartinė informacija**: Atnaujintos visos datų nuorodos ir specifikacijų nuorodos pagal dabartinius standartus
- **Įgyvendinimo gairės**: Pridėtos konkrečios, veiksmais pagrįstos įgyvendinimo gairės visose sekcijose

## 2025 m. liepos 16 d.

### README ir navigacijos patobulinimai
- Visiškai pertvarkyta mokymo programos navigacija README.md
- Pakeisti `<details>` žymos į labiau prieinamą lentelės formatą
- Sukurti alternatyvūs išdėstymo variantai naujame "alternative_layouts" aplanke
- Pridėti kortelių, skirtukų ir akordeono stiliaus navigacijos pavyzdžiai
- Atnaujinta saugyklos struktūros sekcija, apimanti visus naujausius failus
- Patobulinta "Kaip naudoti šią mokymo programą" sekcija su aiškiomis rekomendacijomis
- Atnaujintos MCP specifikacijos nuorodos, kad būtų nukreipta į tinkamus URL
- Pridėta konteksto inžinerijos sekcija (5.14) į mokymo programos struktūrą

### Mokymosi vadovo atnaujinimai
- Visiškai peržiūrėtas mokymosi vadovas, kad atitiktų dabartinę saugyklos struktūrą
- Pridėtos naujos sekcijos apie MCP klientus ir įrankius bei populiarius MCP serverius
- Atnaujintas vizualinis mokymo programos žemėlapis, kad tiksliai atspindėtų visas temas
- Patobulinti pažangių temų aprašymai, apimantys visas specializuotas sritis
- Atnaujinta atvejų analizės sekcija, kad atspindėtų realius pavyzdžius
- Pridėtas šis išsamus pakeitimų žurnalas

### Bendruomenės indėliai (06-CommunityContributions/)
- Pridėta išsami informacija apie MCP serverius vaizdų generavimui
- Pridėta išsami sekcija apie Claude naudojimą VSCode
- Pridėtos Cline terminalo kliento nustatymo ir naudojimo instrukcijos
- Atnaujinta MCP klientų sekcija, apimanti visus populiarius klientų variantus
- Patobulinti indėlių pavyzdžiai su tikslesniais kodo pavyzdžiais

### Pažangios temos (05-AdvancedTopics/)
- Organizuoti visi specializuotų temų aplankai su nuosekliais pavadinimais
- Pridėta konteksto inžinerijos medžiaga ir pavyzdžiai
- Pridėta Foundry agento integracijos dokumentacija
- Patobulinta Entra ID saugumo integracijos dokumentacija

## 2025 m. birželio 11 d.

### Pradinis sukūrimas
- Išleista pirmoji MCP pradedantiesiems mokymo programos versija
- Sukurta pagrindinė struktūra visoms 10 pagrindinių sekcijų
- Įgyvendintas vizualinis mokymo programos žemėlapis navigacijai
- Pridėti pradiniai pavyzdiniai projektai keliomis programavimo kalbomis

### Pradžia (03-GettingStarted/)
- Sukurti pirmieji serverio įgyvendinimo pavyzdžiai
- Pridėtos klientų kūrimo gairės
- Įtrauktos LLM kliento integracijos instrukcijos
- Pridėta VS Code integracijos dokumentacija
- Įgyvendinti Server-Sent Events (SSE) serverio pavyzdžiai

### Pagrindinės sąvokos (01-CoreConcepts/)
- Pridėtas išsamus klientų-serverių architektūros paaiškinimas
- Sukurta dokumentacija apie pagrindinius protokolo komponentus
- Dokumentuoti MCP pranešimų modeliai

## 2025 m. gegužės 23 d.

### Saugyklos struktūra
- Inicializuota saugykla su pagrindine aplankų struktūra
- Sukurti README failai kiekvienai pagrindinei sekcijai
- Nustatyta vertimo infrastruktūra
- Pridėti vaizdo ištekliai ir diagramos

### Dokumentacija
- Sukurtas pradinis README.md su mokymo programos apžvalga
- Pridėti CODE_OF_CONDUCT.md ir SECURITY.md
- Nustatytas SUPPORT.md su pagalbos gavimo gairėmis
- Sukurta preliminari mokymosi vadovo struktūra

## 2025 m. balandžio 15 d.

### Planavimas ir struktūra
- Pradinis MCP pradedantiesiems mokymo programos planavimas
- Apibrėžti mokymosi tikslai ir tikslinė auditorija
- Nubrėžta 10 sekcijų mokymo programos struktūra
- Sukurtas konceptualus pagrindas pavyzdžiams ir atvejų analizėms
- Sukurti pradiniai prototipiniai pavyzdžiai pagrindinėms sąvokoms

---

**Atsakomybės atsisakymas**:  
Šis dokumentas buvo išverstas naudojant AI vertimo paslaugą [Co-op Translator](https://github.com/Azure/co-op-translator). Nors siekiame tikslumo, prašome atkreipti dėmesį, kad automatiniai vertimai gali turėti klaidų ar netikslumų. Originalus dokumentas jo gimtąja kalba turėtų būti laikomas autoritetingu šaltiniu. Kritinei informacijai rekomenduojama naudoti profesionalų žmogaus vertimą. Mes neprisiimame atsakomybės už nesusipratimus ar neteisingus aiškinimus, kilusius dėl šio vertimo naudojimo.