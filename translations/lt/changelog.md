<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:40:46+00:00",
  "source_file": "changelog.md",
  "language_code": "lt"
}
-->
# Keitimų žurnalas: MCP pradedančiųjų mokymo programa

Šis dokumentas yra visų reikšmingų pakeitimų, atliktų Model Context Protocol (MCP) pradedančiųjų mokymo programoje, įrašas. Pakeitimai dokumentuojami atvirkštine chronologine tvarka (naujausi pakeitimai pirmiausia).

## 2025 m. rugsėjo 15 d.

### Išplėstinės temos - Individualūs transportai ir konteksto inžinerija

#### MCP individualūs transportai (05-AdvancedTopics/mcp-transport/) - Naujas išplėstinis įgyvendinimo vadovas
- **README.md**: Išsamus vadovas apie MCP individualių transporto mechanizmų įgyvendinimą
  - **Azure Event Grid Transport**: Išsamus serverless įvykių valdomo transporto įgyvendinimas
    - C#, TypeScript ir Python pavyzdžiai su Azure Functions integracija
    - Įvykių valdomos architektūros modeliai, skirti mastelio MCP sprendimams
    - Webhook gavėjai ir pranešimų apdorojimas stūmimo būdu
  - **Azure Event Hubs Transport**: Didelio pralaidumo srautinio transporto įgyvendinimas
    - Realiojo laiko srautinės galimybės mažo delsimo scenarijams
    - Skirstymo strategijos ir kontrolės taškų valdymas
    - Pranešimų grupavimas ir našumo optimizavimas
  - **Įmonės integracijos modeliai**: Paruošti gamybai architektūriniai pavyzdžiai
    - Paskirstytas MCP apdorojimas per kelias Azure Functions
    - Hibridinės transporto architektūros, derinančios kelis transporto tipus
    - Pranešimų patvarumo, patikimumo ir klaidų tvarkymo strategijos
  - **Saugumas ir stebėjimas**: Azure Key Vault integracija ir stebėjimo modeliai
    - Valdomos tapatybės autentifikacija ir minimalios prieigos teisės
    - Application Insights telemetrija ir našumo stebėjimas
    - Apsaugos mechanizmai ir gedimų tolerancijos modeliai
  - **Testavimo sistemos**: Išsamios testavimo strategijos individualiems transportams
    - Vienetų testavimas naudojant testavimo dvigubus ir imitavimo sistemas
    - Integracijos testavimas su Azure Test Containers
    - Našumo ir apkrovos testavimo aspektai

#### Konteksto inžinerija (05-AdvancedTopics/mcp-contextengineering/) - Nauja AI disciplina
- **README.md**: Išsamus konteksto inžinerijos kaip naujos srities tyrimas
  - **Pagrindiniai principai**: Visiškas konteksto dalijimasis, veiksmų sprendimų supratimas ir konteksto lango valdymas
  - **MCP protokolo suderinamumas**: Kaip MCP dizainas sprendžia konteksto inžinerijos iššūkius
    - Konteksto lango apribojimai ir progresyvaus įkėlimo strategijos
    - Reikšmingumo nustatymas ir dinaminis konteksto gavimas
    - Daugiarūšio konteksto tvarkymas ir saugumo aspektai
  - **Įgyvendinimo metodai**: Vienos gijos ir daugiaveiksnių architektūros
    - Konteksto skaidymas ir prioritizavimo technikos
    - Progresyvus konteksto įkėlimas ir suspaudimo strategijos
    - Sluoksniuotos konteksto metodikos ir optimizuotas gavimas
  - **Matavimo sistema**: Nauji metrikos konteksto efektyvumo vertinimui
    - Įvesties efektyvumas, našumas, kokybė ir vartotojo patirties aspektai
    - Eksperimentiniai konteksto optimizavimo metodai
    - Klaidų analizė ir tobulinimo metodologijos

#### Mokymo programos navigacijos atnaujinimai (README.md)
- **Patobulinta modulio struktūra**: Atnaujinta mokymo programos lentelė, įtraukiant naujas išplėstines temas
  - Pridėta Konteksto inžinerija (5.14) ir Individualus transportas (5.15)
  - Nuoseklus formatavimas ir navigacijos nuorodos visuose moduliuose
  - Atnaujinti aprašymai, atspindintys dabartinį turinio apimtį

### Katalogo struktūros patobulinimai
- **Pavadinimų standartizavimas**: Pervadinta „mcp transport“ į „mcp-transport“, kad būtų nuoseklumas su kitais išplėstiniais temų aplankais
- **Turinio organizavimas**: Visi 05-AdvancedTopics aplankai dabar laikosi nuoseklaus pavadinimų modelio (mcp-[tema])

### Dokumentacijos kokybės patobulinimai
- **MCP specifikacijos suderinamumas**: Visas naujas turinys remiasi dabartine MCP specifikacija 2025-06-18
- **Daugiakalbiai pavyzdžiai**: Išsamūs kodų pavyzdžiai C#, TypeScript ir Python
- **Įmonės dėmesys**: Paruošti gamybai modeliai ir Azure debesų integracija visame turinyje
- **Vizualinė dokumentacija**: Mermaid diagramos architektūros ir srauto vizualizacijai

## 2025 m. rugpjūčio 18 d.

### Dokumentacijos išsamus atnaujinimas - MCP 2025-06-18 standartai

#### MCP saugumo geriausios praktikos (02-Security/) - Visiška modernizacija
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Visiškai perrašyta, suderinta su MCP specifikacija 2025-06-18
  - **Privalomi reikalavimai**: Pridėti aiškūs MUST/MUST NOT reikalavimai iš oficialios specifikacijos su aiškiais vizualiniais indikatoriais
  - **12 pagrindinių saugumo praktikų**: Restruktūrizuota iš 15 punktų sąrašo į išsamias saugumo sritis
    - Tokenų saugumas ir autentifikacija su išorinių tapatybės teikėjų integracija
    - Sesijos valdymas ir transporto saugumas su kriptografiniais reikalavimais
    - AI specifinė grėsmių apsauga su Microsoft Prompt Shields integracija
    - Prieigos kontrolė ir leidimai su minimalios prieigos principu
    - Turinio saugumas ir stebėjimas su Azure Content Safety integracija
    - Tiekimo grandinės saugumas su išsamiu komponentų patikrinimu
    - OAuth saugumas ir „Confused Deputy“ prevencija su PKCE įgyvendinimu
    - Incidentų reagavimas ir atkūrimas su automatizuotomis galimybėmis
    - Atitiktis ir valdymas su reguliavimo suderinamumu
    - Išplėstiniai saugumo kontrolės mechanizmai su „Zero Trust“ architektūra
    - Microsoft saugumo ekosistemos integracija su išsamiais sprendimais
    - Nuolatinė saugumo evoliucija su adaptacinėmis praktikomis
  - **Microsoft saugumo sprendimai**: Patobulinta integracijos gairė Prompt Shields, Azure Content Safety, Entra ID ir GitHub Advanced Security
  - **Įgyvendinimo ištekliai**: Kategorizuoti išsamūs išteklių nuorodos pagal oficialią MCP dokumentaciją, Microsoft saugumo sprendimus, saugumo standartus ir įgyvendinimo vadovus

#### Išplėstiniai saugumo kontrolės mechanizmai (02-Security/) - Įmonės įgyvendinimas
- **MCP-SECURITY-CONTROLS-2025.md**: Visiškai perrašyta su įmonės lygio saugumo sistema
  - **9 išsamios saugumo sritys**: Išplėsta nuo pagrindinių kontrolės mechanizmų iki detalių įmonės sistemų
    - Išplėstinė autentifikacija ir autorizacija su Microsoft Entra ID integracija
    - Tokenų saugumas ir anti-passthrough kontrolės su išsamia validacija
    - Sesijos saugumo kontrolės su užgrobimo prevencija
    - AI specifiniai saugumo kontrolės mechanizmai su prompt injection ir įrankių apsinuodijimo prevencija
    - „Confused Deputy“ atakų prevencija su OAuth proxy saugumu
    - Įrankių vykdymo saugumas su sandboxing ir izoliacija
    - Tiekimo grandinės saugumo kontrolės su priklausomybių patikrinimu
    - Stebėjimo ir aptikimo kontrolės su SIEM integracija
    - Incidentų reagavimas ir atkūrimas su automatizuotomis galimybėmis
  - **Įgyvendinimo pavyzdžiai**: Pridėti detalūs YAML konfigūracijos blokai ir kodų pavyzdžiai
  - **Microsoft sprendimų integracija**: Išsamus Azure saugumo paslaugų, GitHub Advanced Security ir įmonės tapatybės valdymo aprėptis

#### Išplėstinės temos saugumas (05-AdvancedTopics/mcp-security/) - Paruoštas gamybai įgyvendinimas
- **README.md**: Visiškai perrašyta įmonės saugumo įgyvendinimui
  - **Dabartinės specifikacijos suderinamumas**: Atnaujinta pagal MCP specifikaciją 2025-06-18 su privalomais saugumo reikalavimais
  - **Patobulinta autentifikacija**: Microsoft Entra ID integracija su išsamiais .NET ir Java Spring Security pavyzdžiais
  - **AI saugumo integracija**: Microsoft Prompt Shields ir Azure Content Safety įgyvendinimas su detaliais Python pavyzdžiais
  - **Išplėstinė grėsmių mažinimas**: Išsamūs įgyvendinimo pavyzdžiai
    - „Confused Deputy“ atakų prevencija su PKCE ir vartotojo sutikimo validacija
    - Tokenų passthrough prevencija su auditorijos validacija ir saugiu tokenų valdymu
    - Sesijos užgrobimo prevencija su kriptografiniu susiejimu ir elgesio analize
  - **Įmonės saugumo integracija**: Azure Application Insights stebėjimas, grėsmių aptikimo kanalai ir tiekimo grandinės saugumas
  - **Įgyvendinimo kontrolinis sąrašas**: Aiškūs privalomi ir rekomenduojami saugumo kontrolės mechanizmai su Microsoft saugumo ekosistemos privalumais

### Dokumentacijos kokybės ir standartų suderinamumas
- **Specifikacijos nuorodos**: Atnaujintos visos nuorodos į dabartinę MCP specifikaciją 2025-06-18
- **Microsoft saugumo ekosistema**: Patobulintos integracijos gairės visoje saugumo dokumentacijoje
- **Praktinis įgyvendinimas**: Pridėti detalūs kodų pavyzdžiai .NET, Java ir Python su įmonės modeliais
- **Išteklių organizavimas**: Išsamus oficialios dokumentacijos, saugumo standartų ir įgyvendinimo vadovų kategorizavimas
- **Vizualiniai indikatoriai**: Aiškus privalomų reikalavimų ir rekomenduojamų praktikų žymėjimas



---

**Atsakomybės apribojimas**:  
Šis dokumentas buvo išverstas naudojant AI vertimo paslaugą [Co-op Translator](https://github.com/Azure/co-op-translator). Nors siekiame tikslumo, prašome atkreipti dėmesį, kad automatiniai vertimai gali turėti klaidų ar netikslumų. Originalus dokumentas jo gimtąja kalba turėtų būti laikomas autoritetingu šaltiniu. Kritinei informacijai rekomenduojama profesionali žmogaus vertimo paslauga. Mes neprisiimame atsakomybės už nesusipratimus ar klaidingus interpretavimus, atsiradusius dėl šio vertimo naudojimo.