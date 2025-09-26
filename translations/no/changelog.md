<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T18:34:18+00:00",
  "source_file": "changelog.md",
  "language_code": "no"
}
-->
# Endringslogg: MCP for nybegynnere pensum

Dette dokumentet fungerer som en oversikt over alle betydelige endringer gjort i pensumet for Model Context Protocol (MCP) for nybegynnere. Endringer er dokumentert i omvendt kronologisk rekkefølge (nyeste endringer først).

## 26. september 2025

### Forbedring av casestudier - Integrasjon med GitHub MCP Registry

#### Casestudier (09-CaseStudy/) - Fokus på økosystemutvikling
- **README.md**: Større utvidelse med omfattende casestudie om GitHub MCP Registry
  - **GitHub MCP Registry casestudie**: Ny omfattende casestudie som undersøker lanseringen av GitHubs MCP Registry i september 2025
    - **Problemanalyse**: Detaljert undersøkelse av utfordringer med fragmentert MCP-serveroppdagelse og distribusjon
    - **Løsningsarkitektur**: GitHubs sentraliserte registertilnærming med ett-klikks installasjon i VS Code
    - **Forretningspåvirkning**: Målbare forbedringer i utvikleropplæring og produktivitet
    - **Strategisk verdi**: Fokus på modulær agentdistribusjon og interoperabilitet mellom verktøy
    - **Økosystemutvikling**: Posisjonering som en grunnleggende plattform for agentisk integrasjon
  - **Forbedret struktur for casestudier**: Oppdatert alle syv casestudier med konsistent format og omfattende beskrivelser
    - Azure AI Travel Agents: Vekt på multi-agent orkestrering
    - Azure DevOps-integrasjon: Fokus på arbeidsflytautomatisering
    - Sanntids dokumenthenting: Implementering av Python-konsollklient
    - Interaktiv studieplangenerator: Chainlit samtale-webapp
    - Dokumentasjon i editor: Integrasjon med VS Code og GitHub Copilot
    - Azure API Management: Mønstre for bedrifts-API-integrasjon
    - GitHub MCP Registry: Økosystemutvikling og plattform for fellesskap
  - **Omfattende konklusjon**: Omskrevet konklusjonsseksjon som fremhever syv casestudier som dekker flere MCP-implementeringsdimensjoner
    - Kategorisering av bedriftsintegrasjon, multi-agent orkestrering, utviklerproduktivitet
    - Økosystemutvikling, utdanningsapplikasjoner
    - Forbedrede innsikter i arkitektoniske mønstre, implementeringsstrategier og beste praksis
    - Vektlegging av MCP som en moden, produksjonsklar protokoll

#### Oppdateringer i studieguide (study_guide.md)
- **Visuell pensumkart**: Oppdatert tankekart for å inkludere GitHub MCP Registry i seksjonen for casestudier
- **Beskrivelse av casestudier**: Forbedret fra generelle beskrivelser til detaljert gjennomgang av syv omfattende casestudier
- **Repository-struktur**: Oppdatert seksjon 10 for å reflektere omfattende dekning av casestudier med spesifikke implementeringsdetaljer
- **Integrasjon av endringslogg**: Lagt til oppføring for 26. september 2025 som dokumenterer tillegg av GitHub MCP Registry og forbedringer i casestudier
- **Datooppdateringer**: Oppdatert tidsstempel i bunnteksten for å reflektere siste revisjon (26. september 2025)

### Forbedringer i dokumentasjonskvalitet
- **Konsistensforbedring**: Standardisert format og struktur for casestudier på tvers av alle syv eksempler
- **Omfattende dekning**: Casestudier dekker nå scenarier for bedrifter, utviklerproduktivitet og økosystemutvikling
- **Strategisk posisjonering**: Forsterket fokus på MCP som en grunnleggende plattform for distribusjon av agentiske systemer
- **Ressursintegrasjon**: Oppdatert tilleggsressurser for å inkludere lenke til GitHub MCP Registry

## 15. september 2025

### Utvidelse av avanserte emner - Tilpassede transportmekanismer og kontekstteknikk

#### MCP tilpassede transportmekanismer (05-AdvancedTopics/mcp-transport/) - Ny avansert implementeringsguide
- **README.md**: Komplett implementeringsguide for tilpassede MCP transportmekanismer
  - **Azure Event Grid Transport**: Omfattende serverløs hendelsesdrevet transportimplementering
    - Eksempler i C#, TypeScript og Python med integrasjon av Azure Functions
    - Arkitekturmønstre for hendelsesdrevet MCP-løsninger
    - Webhook-mottakere og push-basert meldingshåndtering
  - **Azure Event Hubs Transport**: Implementering av høy gjennomstrømming for strømming
    - Sanntids strømmekapasiteter for lav-latens scenarier
    - Partisjoneringsstrategier og sjekkpunktadministrasjon
    - Meldingsbatching og ytelsesoptimalisering
  - **Mønstre for bedriftsintegrasjon**: Produksjonsklare arkitektoniske eksempler
    - Distribuert MCP-prosessering på tvers av flere Azure Functions
    - Hybrid transportarkitekturer som kombinerer flere transporttyper
    - Meldingsholdbarhet, pålitelighet og feilhåndteringsstrategier
  - **Sikkerhet og overvåking**: Integrasjon med Azure Key Vault og mønstre for observasjon
    - Autentisering med administrert identitet og tilgang med minst privilegium
    - Telemetri med Application Insights og ytelsesovervåking
    - Kretsbrytere og mønstre for feiltoleranse
  - **Testingsrammeverk**: Omfattende teststrategier for tilpassede transportmekanismer
    - Enhetstesting med testdoubles og mocking-rammeverk
    - Integrasjonstesting med Azure Test Containers
    - Ytelses- og belastningstesting

#### Kontekstteknikk (05-AdvancedTopics/mcp-contextengineering/) - Fremvoksende AI-disiplin
- **README.md**: Omfattende utforskning av kontekstteknikk som et fremvoksende felt
  - **Kjerneprinsipper**: Fullstendig kontekstdeling, bevissthet om handlingsbeslutninger og kontekstvinduadministrasjon
  - **MCP-protokolltilpasning**: Hvordan MCP-design adresserer utfordringer innen kontekstteknikk
    - Begrensninger i kontekstvindu og progressive lastestrategier
    - Relevansbestemmelse og dynamisk konteksthenting
    - Håndtering av multimodal kontekst og sikkerhetsbetraktninger
  - **Implementeringsmetoder**: Enkelttrådede vs. multi-agent arkitekturer
    - Kontekstchunking og prioriteringsteknikker
    - Progressiv kontekstlasting og komprimeringsstrategier
    - Lagdelte konteksttilnærminger og optimalisering av henting
  - **Målingsrammeverk**: Fremvoksende metrikker for evaluering av konteksteffektivitet
    - Effektivitet, ytelse, kvalitet og brukeropplevelse
    - Eksperimentelle tilnærminger til kontekstoptimalisering
    - Feilanalyse og forbedringsmetodologier

#### Oppdateringer i pensumnavigasjon (README.md)
- **Forbedret modulstruktur**: Oppdatert pensumtabell for å inkludere nye avanserte emner
  - Lagt til Kontekstteknikk (5.14) og Tilpasset transport (5.15)
  - Konsistent format og navigasjonslenker på tvers av alle moduler
  - Oppdaterte beskrivelser for å reflektere nåværende innholdsomfang

### Forbedringer i katalogstruktur
- **Navnestandardisering**: Omdøpt "mcp transport" til "mcp-transport" for konsistens med andre avanserte emne-mapper
- **Innholdsorganisering**: Alle 05-AdvancedTopics-mapper følger nå et konsistent navnemønster (mcp-[emne])

### Forbedringer i dokumentasjonskvalitet
- **Tilpasning til MCP-spesifikasjon**: Alt nytt innhold refererer til gjeldende MCP-spesifikasjon 2025-06-18
- **Eksempler på flere språk**: Omfattende kodeeksempler i C#, TypeScript og Python
- **Fokus på bedrifter**: Produksjonsklare mønstre og integrasjon med Azure-skyen gjennomgående
- **Visuell dokumentasjon**: Mermaid-diagrammer for visualisering av arkitektur og flyt

## 18. august 2025

### Omfattende oppdatering av dokumentasjon - MCP 2025-06-18 standarder

#### MCP sikkerhetspraksis (02-Security/) - Fullstendig modernisering
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Fullstendig omskriving tilpasset MCP-spesifikasjon 2025-06-18
  - **Obligatoriske krav**: Lagt til eksplisitte MÅ/MÅ IKKE-krav fra offisiell spesifikasjon med klare visuelle indikatorer
  - **12 kjernepraksiser for sikkerhet**: Restrukturert fra 15-punkts liste til omfattende sikkerhetsdomener
    - Tokensikkerhet og autentisering med integrasjon av eksterne identitetsleverandører
    - Sesjonsadministrasjon og transportsikkerhet med kryptografiske krav
    - AI-spesifikk trusselbeskyttelse med Microsoft Prompt Shields-integrasjon
    - Tilgangskontroll og tillatelser med prinsippet om minst privilegium
    - Innholdssikkerhet og overvåking med Azure Content Safety-integrasjon
    - Forsyningskjedesikkerhet med omfattende komponentverifisering
    - OAuth-sikkerhet og forebygging av forvirret stedfortreder med PKCE-implementering
    - Hendelsesrespons og gjenoppretting med automatiserte kapabiliteter
    - Samsvar og styring med regulatorisk tilpasning
    - Avanserte sikkerhetskontroller med null tillit-arkitektur
    - Microsoft sikkerhetsøkosystemintegrasjon med omfattende løsninger
    - Kontinuerlig sikkerhetsevolusjon med adaptive praksiser
  - **Microsoft sikkerhetsløsninger**: Forbedret veiledning for integrasjon av Prompt Shields, Azure Content Safety, Entra ID og GitHub Advanced Security
  - **Implementeringsressurser**: Kategoriserte omfattende ressurslenker etter Offisiell MCP-dokumentasjon, Microsoft sikkerhetsløsninger, sikkerhetsstandarder og implementeringsguider

#### Avanserte sikkerhetskontroller (02-Security/) - Implementering for bedrifter
- **MCP-SECURITY-CONTROLS-2025.md**: Fullstendig overhaling med sikkerhetsrammeverk for bedrifter
  - **9 omfattende sikkerhetsdomener**: Utvidet fra grunnleggende kontroller til detaljert rammeverk for bedrifter
    - Avansert autentisering og autorisasjon med Microsoft Entra ID-integrasjon
    - Tokensikkerhet og anti-pass-through kontroller med omfattende validering
    - Sesjonssikkerhetskontroller med forebygging av kapring
    - AI-spesifikke sikkerhetskontroller med forebygging av prompt-injeksjon og verktøyforgiftning
    - Forebygging av forvirret stedfortreder-angrep med OAuth proxy-sikkerhet
    - Verktøyutførelsessikkerhet med sandkasse og isolasjon
    - Forsyningskjedesikkerhetskontroller med verifisering av avhengigheter
    - Overvåkings- og deteksjonskontroller med SIEM-integrasjon
    - Hendelsesrespons og gjenoppretting med automatiserte kapabiliteter
  - **Implementeringseksempler**: Lagt til detaljerte YAML-konfigurasjonsblokker og kodeeksempler
  - **Microsoft-løsninger integrasjon**: Omfattende dekning av Azure sikkerhetstjenester, GitHub Advanced Security og administrasjon av bedriftsidentitet

#### Avanserte emner sikkerhet (05-AdvancedTopics/mcp-security/) - Produksjonsklar implementering
- **README.md**: Fullstendig omskriving for implementering av sikkerhet for bedrifter
  - **Tilpasning til gjeldende spesifikasjon**: Oppdatert til MCP-spesifikasjon 2025-06-18 med obligatoriske sikkerhetskrav
  - **Forbedret autentisering**: Microsoft Entra ID-integrasjon med omfattende eksempler i .NET og Java Spring Security
  - **AI-sikkerhetsintegrasjon**: Implementering av Microsoft Prompt Shields og Azure Content Safety med detaljerte eksempler i Python
  - **Avansert trusselmitigering**: Omfattende implementeringseksempler for
    - Forebygging av forvirret stedfortreder-angrep med PKCE og validering av brukersamtykke
    - Forebygging av token-pass-through med validering av publikum og sikker tokenadministrasjon
    - Forebygging av sesjonskapring med kryptografisk binding og atferdsanalyse
  - **Integrasjon av sikkerhet for bedrifter**: Overvåking med Azure Application Insights, trusseldeteksjonspipelines og forsyningskjedesikkerhet
  - **Implementeringssjekkliste**: Klare obligatoriske vs. anbefalte sikkerhetskontroller med fordeler fra Microsofts sikkerhetsøkosystem

### Forbedringer i dokumentasjonskvalitet og standardtilpasning
- **Referanser til spesifikasjon**: Oppdatert alle referanser til gjeldende MCP-spesifikasjon 2025-06-18
- **Microsoft sikkerhetsøkosystem**: Forbedret veiledning for integrasjon gjennom hele sikkerhetsdokumentasjonen
- **Praktisk implementering**: Lagt til detaljerte kodeeksempler i .NET, Java og Python med mønstre for bedrifter
- **Ressursorganisering**: Omfattende kategorisering av offisiell dokumentasjon, sikkerhetsstandarder og implementeringsguider
- **Visuelle indikatorer**: Klare markeringer av obligatoriske krav vs. anbefalte praksiser

#### Kjernekonsepter (01-CoreConcepts/) - Fullstendig modernisering
- **Oppdatering av protokollversjon**: Oppdatert til å referere til gjeldende MCP-spesifikasjon 2025-06-18 med dato-basert versjonering (YYYY-MM-DD format)
- **Forbedring av arkitektur**: Forbedrede beskrivelser av Hosts, Clients og Servers for å reflektere nåværende MCP-arkitekturmønstre
  - Hosts nå tydelig definert som AI-applikasjoner som koordinerer flere MCP-klienttilkoblinger
  - Klienter beskrevet som protokollkoblinger som opprettholder én-til-én serverforhold
  - Servere forbedret med lokale vs. eksterne distribusjonsscenarier
- **Restrukturering av primitiver**: Fullstendig overhaling av server- og klientprimitiver
  - Serverprimitiver: Ressurser (datakilder), Prompts (maler), Tools (eksekverbare funksjoner) med detaljerte forklaringer og eksempler
  - Klientprimitiver: Sampling (LLM fullføringer), Elicitation (brukerinndata), Logging (feilsøking/overvåking)
  - Oppdatert med nåværende oppdagelse (`*/list`), henting (`*/get`) og eksekvering (`*/call`) metode-mønstre
- **Protokollarkitektur**: Introduksjon av to-lags arkitekturmodell
  - Datalag: JSON-RPC 2.0 grunnlag med livssyklusadministrasjon og primitiver
  - Transportlag: STDIO (lokal) og Streamable HTTP med SSE (ekstern) transportmekanismer
- **Sikkerhetsrammeverk**: Omfattende sikkerhetsprinsipper inkludert eksplisitt brukersamtykke, databeskyttelse, verktøyutførelsessikkerhet og transportsikkerhet
- **Kommunikasjonsmønstre**: Oppdaterte protokollmeldinger for å vise initialisering, oppdagelse, eksekvering og varslingsflyt
- **Kodeeksempler**: Oppfriskede eksempler på flere språk (.NET, Java, Python, JavaScript) for å reflektere nåværende MCP SDK-mønstre

#### Sikkerhet (02-Security/) - Omfattende sikkerhetsmodernisering  
- **Standardtilpasning**: Full tilpasning til MCP-spesifikasjon 2025-06-18 sikkerhetskrav
- **Evolusjon av autentisering**: Dokumentert utvikling fra tilpassede OAuth-servere til delegasjon til eksterne identitetsleverandører (Microsoft Entra ID)
- **AI-spesifikk trusselanalyse**: Forbedret dekning av moderne AI-angrepsvektorer
  - Detaljerte scenarier for prompt-injeksjonsangrep med virkelige eksempler
  - Mekanismer for verktøyforgiftning og "rug pull"-angrepsmønstre
  - Kontekstvindu-forgiftning og modellforvirringsangrep
- **Microsoft AI-sikkerhetsløsninger**: Omfattende dekning av Microsofts sikkerhetsøkosystem
  - AI Prompt Shields med avansert deteksjon, spotlighting og delimiter-teknikker
  - Integrasjonsmønstre for Azure Content Safety
  - GitHub Advanced Security for forsyningskjede-beskyttelse
- **Avansert trusselmitigering**: Detaljerte sikkerhetskontroller
- Erstattet `<details>`-tagger med et mer tilgjengelig tabellbasert format
- Opprettet alternative layoutalternativer i den nye "alternative_layouts"-mappen
- La til eksempler på kortbasert, fanebasert og trekkspillbasert navigasjon
- Oppdaterte delen om repository-struktur for å inkludere alle nyeste filer
- Forbedret "Hvordan bruke dette pensumet"-seksjonen med klare anbefalinger
- Oppdaterte MCP-spesifikasjonslenker til å peke på riktige URL-er
- La til seksjonen Kontekstingeniørkunst (5.14) i pensumstrukturen

### Oppdateringer i studieveiledningen
- Fullstendig revidert studieveiledningen for å samsvare med gjeldende repository-struktur
- La til nye seksjoner for MCP-klienter og verktøy, samt populære MCP-servere
- Oppdaterte det visuelle pensumkartet for å nøyaktig reflektere alle emner
- Forbedret beskrivelser av avanserte emner for å dekke alle spesialiserte områder
- Oppdaterte delen om casestudier for å reflektere faktiske eksempler
- La til denne omfattende endringsloggen

### Bidrag fra fellesskapet (06-CommunityContributions/)
- La til detaljert informasjon om MCP-servere for bildegenerering
- La til omfattende seksjon om bruk av Claude i VSCode
- La til oppsett og bruksanvisning for Cline terminalklient
- Oppdaterte MCP-klientseksjonen for å inkludere alle populære klientalternativer
- Forbedret eksempler på bidrag med mer nøyaktige kodeeksempler

### Avanserte emner (05-AdvancedTopics/)
- Organiserte alle spesialiserte emnemapper med konsistent navngivning
- La til materialer og eksempler for kontekstingeniørkunst
- La til dokumentasjon for Foundry-agentintegrasjon
- Forbedret dokumentasjon for Entra ID-sikkerhetsintegrasjon

## 11. juni 2025

### Første opprettelse
- Lanserte første versjon av MCP for nybegynnere-pensumet
- Opprettet grunnleggende struktur for alle 10 hovedseksjoner
- Implementerte visuelt pensumkart for navigasjon
- La til innledende prøveprosjekter i flere programmeringsspråk

### Komme i gang (03-GettingStarted/)
- Opprettet de første eksemplene på serverimplementering
- La til veiledning for klientutvikling
- Inkluderte instruksjoner for LLM-klientintegrasjon
- La til dokumentasjon for VS Code-integrasjon
- Implementerte eksempler på Server-Sent Events (SSE)-servere

### Grunnleggende konsepter (01-CoreConcepts/)
- La til detaljert forklaring på klient-server-arkitektur
- Opprettet dokumentasjon om nøkkelkomponenter i protokollen
- Dokumenterte meldingsmønstre i MCP

## 23. mai 2025

### Repository-struktur
- Initialiserte repository med grunnleggende mappestruktur
- Opprettet README-filer for hver hovedseksjon
- Satt opp oversettelsesinfrastruktur
- La til bildeelementer og diagrammer

### Dokumentasjon
- Opprettet innledende README.md med oversikt over pensumet
- La til CODE_OF_CONDUCT.md og SECURITY.md
- Satt opp SUPPORT.md med veiledning for å få hjelp
- Opprettet foreløpig struktur for studieveiledningen

## 15. april 2025

### Planlegging og rammeverk
- Innledende planlegging for MCP for nybegynnere-pensumet
- Definerte læringsmål og målgruppe
- Skisserte 10-seksjonsstrukturen for pensumet
- Utviklet konseptuelt rammeverk for eksempler og casestudier
- Opprettet innledende prototypeeksempler for nøkkelkonsepter

---

