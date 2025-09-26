<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T19:24:15+00:00",
  "source_file": "changelog.md",
  "language_code": "lt"
}
-->
# Keitimų žurnalas: MCP pradedančiųjų mokymo programa

Šis dokumentas yra visų reikšmingų pakeitimų, atliktų Model Context Protocol (MCP) pradedančiųjų mokymo programoje, įrašas. Pakeitimai dokumentuojami atvirkštine chronologine tvarka (naujausi pakeitimai pirmiausia).

## 2025 m. rugsėjo 26 d.

### Atvejų analizės patobulinimas - GitHub MCP registracijos integracija

#### Atvejų analizės (09-CaseStudy/) - dėmesys ekosistemos plėtrai
- **README.md**: Didelis papildymas su išsamia GitHub MCP registracijos atvejo analize
  - **GitHub MCP registracijos atvejo analizė**: Nauja išsami analizė, nagrinėjanti GitHub MCP registracijos paleidimą 2025 m. rugsėjį
    - **Problemos analizė**: Išsamus suskaidytos MCP serverių paieškos ir diegimo iššūkių nagrinėjimas
    - **Sprendimo architektūra**: GitHub centralizuoto registro požiūris su vieno paspaudimo VS Code diegimu
    - **Verslo poveikis**: Matomi patobulinimai kūrėjų įsitraukime ir produktyvume
    - **Strateginė vertė**: Dėmesys modulinio agento diegimui ir įrankių tarpusavio sąveikai
    - **Ekosistemos plėtra**: Pozicionavimas kaip pagrindinė platforma agentų integracijai
  - **Patobulinta atvejų analizės struktūra**: Atnaujintos visos septynios atvejų analizės su nuosekliu formatavimu ir išsamiais aprašymais
    - Azure AI kelionių agentai: Dėmesys daugelio agentų koordinavimui
    - Azure DevOps integracija: Dėmesys darbo eigos automatizavimui
    - Dokumentacijos gavimas realiu laiku: Python konsolės kliento įgyvendinimas
    - Interaktyvus mokymosi plano generatorius: Chainlit pokalbių internetinė programėlė
    - Dokumentacija redaktoriuje: VS Code ir GitHub Copilot integracija
    - Azure API valdymas: Įmonės API integracijos modeliai
    - GitHub MCP registracija: Ekosistemos plėtra ir bendruomenės platforma
  - **Išsami išvada**: Perrašyta išvadų dalis, pabrėžianti septynias atvejų analizes, apimančias įvairius MCP įgyvendinimo aspektus
    - Įmonės integracija, daugelio agentų koordinavimas, kūrėjų produktyvumas
    - Ekosistemos plėtra, edukacinės aplikacijos kategorijos
    - Patobulintos įžvalgos apie architektūros modelius, įgyvendinimo strategijas ir geriausią praktiką
    - Dėmesys MCP kaip brandžiam, gamybai paruoštam protokolui

#### Mokymosi vadovo atnaujinimai (study_guide.md)
- **Vizualus mokymo programos žemėlapis**: Atnaujintas minčių žemėlapis, įtraukiant GitHub MCP registraciją į atvejų analizės skyrių
- **Atvejų analizės aprašymas**: Patobulintas nuo bendrų aprašymų iki išsamių septynių atvejų analizės aprašymų
- **Repozitorijos struktūra**: Atnaujintas 10 skyrius, atspindintis išsamų atvejų analizės aprėptį su konkrečiomis įgyvendinimo detalėmis
- **Keitimų žurnalo integracija**: Pridėta 2025 m. rugsėjo 26 d. įrašas, dokumentuojantis GitHub MCP registracijos papildymą ir atvejų analizės patobulinimus
- **Datos atnaujinimai**: Atnaujintas poraštės laiko žymuo, atspindintis naujausią peržiūrą (2025 m. rugsėjo 26 d.)

### Dokumentacijos kokybės patobulinimai
- **Nuoseklumo patobulinimas**: Standartizuotas atvejų analizės formatavimas ir struktūra visose septyniose pavyzdžiuose
- **Išsamus aprėptis**: Atvejų analizės dabar apima įmonės, kūrėjų produktyvumo ir ekosistemos plėtros scenarijus
- **Strateginis pozicionavimas**: Patobulintas dėmesys MCP kaip pagrindinei platformai agentinių sistemų diegimui
- **Resursų integracija**: Atnaujinti papildomi resursai, įtraukiant GitHub MCP registracijos nuorodą

## 2025 m. rugsėjo 15 d.

### Pažangių temų plėtra - pritaikyti transportai ir konteksto inžinerija

#### MCP pritaikyti transportai (05-AdvancedTopics/mcp-transport/) - naujas pažangus įgyvendinimo vadovas
- **README.md**: Pilnas pritaikytų MCP transporto mechanizmų įgyvendinimo vadovas
  - **Azure Event Grid transportas**: Išsamus serverless įvykių pagrindu veikiančio transporto įgyvendinimas
    - C#, TypeScript ir Python pavyzdžiai su Azure Functions integracija
    - Įvykių pagrindu veikiančios architektūros modeliai skalabiliems MCP sprendimams
    - Webhook gavėjai ir pranešimų apdorojimas
  - **Azure Event Hubs transportas**: Didelio pralaidumo srautinio transporto įgyvendinimas
    - Realiojo laiko srautinės galimybės mažo delsimo scenarijams
    - Skirstymo strategijos ir kontrolės taškų valdymas
    - Pranešimų grupavimas ir našumo optimizavimas
  - **Įmonės integracijos modeliai**: Gamybai paruošti architektūros pavyzdžiai
    - Paskirstytas MCP apdorojimas per kelias Azure Functions
    - Hibridinės transporto architektūros, derinančios kelis transporto tipus
    - Pranešimų patvarumas, patikimumas ir klaidų tvarkymo strategijos
  - **Saugumas ir stebėjimas**: Azure Key Vault integracija ir stebėjimo modeliai
    - Valdomos tapatybės autentifikacija ir minimalios prieigos principas
    - Application Insights telemetrija ir našumo stebėjimas
    - Apsaugos mechanizmai ir gedimų tolerancijos modeliai
  - **Testavimo sistemos**: Išsamios testavimo strategijos pritaikytiems transportams
    - Vienetų testavimas su testavimo dvigubais ir imitavimo sistemomis
    - Integracijos testavimas su Azure Test Containers
    - Našumo ir apkrovos testavimo aspektai

#### Konteksto inžinerija (05-AdvancedTopics/mcp-contextengineering/) - nauja AI disciplina
- **README.md**: Išsamus konteksto inžinerijos kaip naujos srities tyrimas
  - **Pagrindiniai principai**: Pilnas konteksto dalijimasis, veiksmų sprendimų supratimas ir konteksto lango valdymas
  - **MCP protokolo suderinamumas**: Kaip MCP dizainas sprendžia konteksto inžinerijos iššūkius
    - Konteksto lango apribojimai ir progresyvaus įkėlimo strategijos
    - Reikšmingumo nustatymas ir dinaminis konteksto gavimas
    - Daugiarūšio konteksto tvarkymas ir saugumo aspektai
  - **Įgyvendinimo metodai**: Vieno gijos ir daugelio agentų architektūros
    - Konteksto skaidymas ir prioritizavimo technikos
    - Progresyvus konteksto įkėlimas ir suspaudimo strategijos
    - Sluoksniuotas konteksto požiūris ir gavimo optimizavimas
  - **Matavimo sistema**: Nauji metrikos konteksto efektyvumo vertinimui
    - Įvesties efektyvumas, našumas, kokybė ir vartotojo patirties aspektai
    - Eksperimentiniai konteksto optimizavimo metodai
    - Klaidų analizė ir tobulinimo metodologijos

#### Mokymo programos navigacijos atnaujinimai (README.md)
- **Patobulinta modulio struktūra**: Atnaujinta mokymo programos lentelė, įtraukiant naujas pažangias temas
  - Pridėta Konteksto inžinerija (5.14) ir Pritaikyti transportai (5.15)
  - Nuoseklus formatavimas ir navigacijos nuorodos visuose moduliuose
  - Atnaujinti aprašymai, atspindintys dabartinį turinio apimtį

### Katalogo struktūros patobulinimai
- **Pavadinimų standartizavimas**: Pervadintas „mcp transport“ į „mcp-transport“, kad atitiktų kitus pažangių temų aplankus
- **Turinio organizavimas**: Visi 05-AdvancedTopics aplankai dabar laikosi nuoseklaus pavadinimų modelio (mcp-[tema])

### Dokumentacijos kokybės patobulinimai
- **MCP specifikacijos suderinamumas**: Visas naujas turinys remiasi dabartine MCP specifikacija 2025-06-18
- **Daugiakalbiai pavyzdžiai**: Išsamūs kodų pavyzdžiai C#, TypeScript ir Python
- **Dėmesys įmonėms**: Gamybai paruošti modeliai ir Azure debesų integracija visame turinyje
- **Vizualinė dokumentacija**: Mermaid diagramos architektūros ir srauto vizualizacijai

## 2025 m. rugpjūčio 18 d.

### Dokumentacijos išsamus atnaujinimas - MCP 2025-06-18 standartai

#### MCP saugumo geriausios praktikos (02-Security/) - pilnas modernizavimas
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Pilnas perrašymas, suderintas su MCP specifikacija 2025-06-18
  - **Privalomi reikalavimai**: Pridėti aiškūs MUST/MUST NOT reikalavimai iš oficialios specifikacijos su vizualiais žymekliais
  - **12 pagrindinių saugumo praktikų**: Restruktūrizuota iš 15 punktų sąrašo į išsamius saugumo domenus
    - Tokenų saugumas ir autentifikacija su išorinių tapatybės tiekėjų integracija
    - Sesijos valdymas ir transporto saugumas su kriptografiniais reikalavimais
    - AI specifinė grėsmių apsauga su Microsoft Prompt Shields integracija
    - Prieigos kontrolė ir leidimai su minimalios prieigos principu
    - Turinio saugumas ir stebėjimas su Azure Content Safety integracija
    - Tiekimo grandinės saugumas su išsamiu komponentų patikrinimu
    - OAuth saugumas ir „Confused Deputy“ prevencija su PKCE įgyvendinimu
    - Incidentų reagavimas ir atkūrimas su automatizuotomis galimybėmis
    - Atitiktis ir valdymas su reguliavimo suderinamumu
    - Pažangios saugumo kontrolės su „Zero Trust“ architektūra
    - Microsoft saugumo ekosistemos integracija su išsamiais sprendimais
    - Nuolatinė saugumo evoliucija su adaptacinėmis praktikomis
  - **Microsoft saugumo sprendimai**: Patobulinta integracijos gairė Prompt Shields, Azure Content Safety, Entra ID ir GitHub Advanced Security
  - **Įgyvendinimo resursai**: Kategorizuoti išsamūs resursų nuorodos pagal oficialią MCP dokumentaciją, Microsoft saugumo sprendimus, saugumo standartus ir įgyvendinimo vadovus

#### Pažangios saugumo kontrolės (02-Security/) - įmonės įgyvendinimas
- **MCP-SECURITY-CONTROLS-2025.md**: Pilnas perrašymas su įmonės lygio saugumo sistema
  - **9 išsamūs saugumo domenai**: Išplėsta nuo bazinių kontrolės iki detalių įmonės modelių
    - Pažangi autentifikacija ir autorizacija su Microsoft Entra ID integracija
    - Tokenų saugumas ir anti-passthrough kontrolės su išsamia validacija
    - Sesijos saugumo kontrolės su užgrobimo prevencija
    - AI specifinės saugumo kontrolės su promptų injekcijos ir įrankių apsinuodijimo prevencija
    - „Confused Deputy“ atakų prevencija su OAuth proxy saugumu
    - Įrankių vykdymo saugumas su sandboxing ir izoliacija
    - Tiekimo grandinės saugumo kontrolės su priklausomybių patikrinimu
    - Stebėjimo ir aptikimo kontrolės su SIEM integracija
    - Incidentų reagavimas ir atkūrimas su automatizuotomis galimybėmis
  - **Įgyvendinimo pavyzdžiai**: Pridėti detalūs YAML konfigūracijos blokai ir kodų pavyzdžiai
  - **Microsoft sprendimų integracija**: Išsamus Azure saugumo paslaugų, GitHub Advanced Security ir įmonės tapatybės valdymo aprėptis

#### Pažangios temos saugumas (05-AdvancedTopics/mcp-security/) - gamybai paruoštas įgyvendinimas
- **README.md**: Pilnas perrašymas įmonės saugumo įgyvendinimui
  - **Dabartinės specifikacijos suderinamumas**: Atnaujinta pagal MCP specifikaciją 2025-06-18 su privalomais saugumo reikalavimais
  - **Patobulinta autentifikacija**: Microsoft Entra ID integracija su išsamiais .NET ir Java Spring Security pavyzdžiais
  - **AI saugumo integracija**: Microsoft Prompt Shields ir Azure Content Safety įgyvendinimas su detaliais Python pavyzdžiais
  - **Pažangi grėsmių mažinimas**: Išsamūs įgyvendinimo pavyzdžiai
    - „Confused Deputy“ atakų prevencija su PKCE ir vartotojo sutikimo validacija
    - Tokenų passthrough prevencija su auditorijos validacija ir saugiu tokenų valdymu
    - Sesijos užgrobimo prevencija su kriptografiniu susiejimu ir elgesio analize
  - **Įmonės saugumo integracija**: Azure Application Insights stebėjimas, grėsmių aptikimo kanalai ir tiekimo grandinės saugumas
  - **Įgyvendinimo kontrolinis sąrašas**: Aiškios privalomos ir rekomenduojamos saugumo kontrolės su Microsoft saugumo ekosistemos privalumais

### Dokumentacijos kokybės ir standartų suderinamumas
- **Specifikacijos nuorodos**: Atnaujintos visos nuorodos į dabartinę MCP specifikaciją 2025-06-18
- **Microsoft saugumo ekosistema**: Patobulinta integracijos gairė visoje saugumo dokumentacijoje
- **Praktinis įgyvendinimas**: Pridėti detalūs kodų pavyzdžiai .NET, Java ir Python su įmonės modeliais
- **Resursų organizavimas**: Išsamus oficialios dokumentacijos, saugumo standartų ir įgyvendinimo vadovų kategorizavimas
- **Vizualiniai žymekliai**: Aiškus privalomų reikalavimų ir rekomenduojamų praktikų žymėjimas

#### Pagrindinės sąvokos (01-CoreConcepts/) - pilnas modernizavimas
- **Protokolo versijos atnaujinimas**: Atnaujinta, kad būtų nurodyta dabartinė MCP specifikacija 2025-06-18 su datos pagrindu versijavimu (YYYY-MM-DD formatas)
- **Architektūros patobulinimas**: Patobulinti aprašymai apie Hostus, Klientus ir Serverius, atspindint dabartinius MCP architektūros modelius
  - Hostai dabar aiškiai apibrėžti kaip AI aplikacijos, koordinuojančios kelis MCP klientų ryšius
  - Klientai aprašyti kaip protokolo jungtys, palaikančios vienas su vienu serverio ryšius
  - Serveriai patobulinti su vietinio ir nuotolinio diegimo scenarijais
- **Primitivų restruktūrizavimas**: Pilnas serverio ir kliento primitivų perrašymas
  - Serverio primityvai: Resursai (duomenų šaltiniai), Šablonai (promptai), Įrankiai (vykdomos funkcijos) su detaliais paaiškinimais
- Pakeistos `<details>` žymos į labiau prieinamą lentelės formatą
- Sukurtos alternatyvios išdėstymo parinktys naujame "alternative_layouts" aplanke
- Pridėti kortelių pagrindu, skirtukų stiliaus ir akordeono stiliaus navigacijos pavyzdžiai
- Atnaujinta saugyklos struktūros skiltis, įtraukiant visus naujausius failus
- Patobulinta skiltis "Kaip naudoti šią mokymo programą" su aiškiomis rekomendacijomis
- Atnaujintos MCP specifikacijos nuorodos, kad nukreiptų į teisingus URL
- Į mokymo programos struktūrą pridėta Kontekstinio inžinerijos skiltis (5.14)

### Mokymosi vadovo atnaujinimai
- Visiškai peržiūrėtas mokymosi vadovas, kad atitiktų dabartinę saugyklos struktūrą
- Pridėtos naujos skiltys apie MCP klientus ir įrankius bei populiarius MCP serverius
- Atnaujintas vizualinis mokymo programos žemėlapis, kad tiksliai atspindėtų visas temas
- Patobulinti pažangių temų aprašymai, apimantys visas specializuotas sritis
- Atnaujinta atvejų analizės skiltis, kad atspindėtų realius pavyzdžius
- Pridėtas šis išsamus pakeitimų žurnalas

### Bendruomenės indėlis (06-CommunityContributions/)
- Pridėta išsami informacija apie MCP serverius vaizdų generavimui
- Pridėta išsami skiltis apie Claude naudojimą VSCode
- Pridėtos Cline terminalo kliento nustatymo ir naudojimo instrukcijos
- Atnaujinta MCP klientų skiltis, įtraukiant visus populiarius klientų variantus
- Patobulinti indėlio pavyzdžiai su tikslesniais kodo pavyzdžiais

### Pažangios temos (05-AdvancedTopics/)
- Organizuoti visi specializuotų temų aplankai su nuosekliais pavadinimais
- Pridėta kontekstinio inžinerijos medžiaga ir pavyzdžiai
- Pridėta Foundry agento integracijos dokumentacija
- Patobulinta Entra ID saugumo integracijos dokumentacija

## 2025 m. birželio 11 d.

### Pradinis sukūrimas
- Išleista pirmoji MCP pradedantiesiems mokymo programos versija
- Sukurta pagrindinė struktūra visoms 10 pagrindinių skilčių
- Įgyvendintas vizualinis mokymo programos žemėlapis navigacijai
- Pridėti pradiniai pavyzdiniai projektai keliomis programavimo kalbomis

### Pradžia (03-GettingStarted/)
- Sukurti pirmieji serverio įgyvendinimo pavyzdžiai
- Pridėtos klientų kūrimo gairės
- Įtrauktos LLM kliento integracijos instrukcijos
- Pridėta VS Code integracijos dokumentacija
- Įgyvendinti Server-Sent Events (SSE) serverio pavyzdžiai

### Pagrindinės sąvokos (01-CoreConcepts/)
- Pridėtas išsamus klientų-serverio architektūros paaiškinimas
- Sukurta dokumentacija apie pagrindinius protokolo komponentus
- Dokumentuoti pranešimų modeliai MCP

## 2025 m. gegužės 23 d.

### Saugyklos struktūra
- Inicializuota saugykla su pagrindine aplankų struktūra
- Sukurti README failai kiekvienai pagrindinei skilčiai
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
- Nubrėžta 10 skilčių mokymo programos struktūra
- Sukurtas konceptualus pagrindas pavyzdžiams ir atvejų analizėms
- Sukurti pradiniai prototipiniai pavyzdžiai pagrindinėms sąvokoms

---

