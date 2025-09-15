<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:17:41+00:00",
  "source_file": "changelog.md",
  "language_code": "no"
}
-->
# Endringslogg: MCP for Nybegynnere Curriculum

Dette dokumentet fungerer som en oversikt over alle betydelige endringer gjort i Model Context Protocol (MCP) for Nybegynnere curriculum. Endringer er dokumentert i omvendt kronologisk rekkefølge (nyeste endringer først).

## 15. september 2025

### Utvidelse av Avanserte Emner - Tilpassede Transportsystemer & Kontekstteknikk

#### MCP Tilpassede Transportsystemer (05-AdvancedTopics/mcp-transport/) - Ny Avansert Implementeringsveiledning
- **README.md**: Fullstendig implementeringsveiledning for tilpassede MCP transportmekanismer
  - **Azure Event Grid Transport**: Omfattende serverløs hendelsesdrevet transportimplementering
    - Eksempler i C#, TypeScript og Python med Azure Functions-integrasjon
    - Hendelsesdrevet arkitektur for skalerbare MCP-løsninger
    - Webhook-mottakere og push-basert meldingshåndtering
  - **Azure Event Hubs Transport**: Høy gjennomstrømming for streamingtransport
    - Sanntids streaming for lav-latens scenarier
    - Partisjoneringsstrategier og sjekkpunktadministrasjon
    - Meldingsbatching og ytelsesoptimalisering
  - **Enterprise Integrasjonsmønstre**: Produksjonsklare arkitektureksempler
    - Distribuert MCP-prosessering på tvers av flere Azure Functions
    - Hybrid transportarkitekturer som kombinerer flere transporttyper
    - Meldingsholdbarhet, pålitelighet og feilhåndteringsstrategier
  - **Sikkerhet & Overvåking**: Azure Key Vault-integrasjon og observasjonsmønstre
    - Administrert identitetsautentisering og minst privilegert tilgang
    - Application Insights-telemetri og ytelsesovervåking
    - Kretsbrytere og feiltoleranse-mønstre
  - **Testrammeverk**: Omfattende teststrategier for tilpassede transportsystemer
    - Enhetstesting med testdoubles og mocking-rammeverk
    - Integrasjonstesting med Azure Test Containers
    - Ytelses- og belastningstesting

#### Kontekstteknikk (05-AdvancedTopics/mcp-contextengineering/) - Fremvoksende AI-disiplin
- **README.md**: Omfattende utforskning av kontekstteknikk som et fremvoksende felt
  - **Kjerneprinsipper**: Fullstendig kontekstdeling, handlingsbeslutningsbevissthet og kontekstvinduadministrasjon
  - **MCP Protokolltilpasning**: Hvordan MCP-design adresserer utfordringer innen kontekstteknikk
    - Begrensninger i kontekstvinduer og progressive lastestrategier
    - Relevansbestemmelse og dynamisk kontekstinnhenting
    - Multimodal konteksthåndtering og sikkerhetsbetraktninger
  - **Implementeringsmetoder**: Enkelttrådede vs. multi-agent arkitekturer
    - Kontekstchunking og prioriteringsteknikker
    - Progressiv kontekstlasting og komprimeringsstrategier
    - Lagdelte konteksttilnærminger og optimalisering av innhenting
  - **Målingsrammeverk**: Fremvoksende metrikker for evaluering av konteksteffektivitet
    - Inndataeffektivitet, ytelse, kvalitet og brukeropplevelse
    - Eksperimentelle tilnærminger til kontekstoptimalisering
    - Feilanalyse og forbedringsmetodologier

#### Oppdateringer i Curriculum-navigasjon (README.md)
- **Forbedret Modulstruktur**: Oppdatert curriculum-tabell for å inkludere nye avanserte emner
  - Lagt til Kontekstteknikk (5.14) og Tilpasset Transport (5.15) oppføringer
  - Konsistent formatering og navigasjonslenker på tvers av alle moduler
  - Oppdaterte beskrivelser for å reflektere nåværende innholdsomfang

### Forbedringer i Mappestruktur
- **Navnestandardisering**: Omdøpt "mcp transport" til "mcp-transport" for konsistens med andre avanserte emnemapper
- **Innholdsorganisering**: Alle 05-AdvancedTopics-mapper følger nå et konsistent navnemønster (mcp-[tema])

### Dokumentasjonskvalitetsforbedringer
- **MCP Spesifikasjonsjustering**: Alt nytt innhold refererer til gjeldende MCP Spesifikasjon 2025-06-18
- **Flerspråklige Eksempler**: Omfattende kodeeksempler i C#, TypeScript og Python
- **Enterprise-fokus**: Produksjonsklare mønstre og Azure-skyintegrasjon gjennomgående
- **Visuell Dokumentasjon**: Mermaid-diagrammer for arkitektur og flytvisualisering

## 18. august 2025

### Omfattende Dokumentasjonsoppdatering - MCP 2025-06-18 Standarder

#### MCP Sikkerhetsbestepraksis (02-Security/) - Full Modernisering
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Fullstendig omskriving i tråd med MCP Spesifikasjon 2025-06-18
  - **Obligatoriske Krav**: Lagt til eksplisitte MÅ/MÅ IKKE krav fra offisiell spesifikasjon med klare visuelle indikatorer
  - **12 Kjerne Sikkerhetspraksiser**: Restrukturert fra 15-punkts liste til omfattende sikkerhetsdomener
    - Tokensikkerhet & Autentisering med integrasjon av eksterne identitetsleverandører
    - Sesjonsadministrasjon & Transport-sikkerhet med kryptografiske krav
    - AI-spesifikk Trusselbeskyttelse med Microsoft Prompt Shields-integrasjon
    - Tilgangskontroll & Tillatelser med prinsippet om minst privilegium
    - Innholdssikkerhet & Overvåking med Azure Content Safety-integrasjon
    - Forsyningskjede-sikkerhet med omfattende komponentverifisering
    - OAuth-sikkerhet & Forebygging av "Confused Deputy"-angrep med PKCE-implementering
    - Hendelsesrespons & Gjenoppretting med automatiserte kapabiliteter
    - Samsvar & Styring med regulatorisk tilpasning
    - Avanserte Sikkerhetskontroller med nulltillitsarkitektur
    - Microsoft Sikkerhetsøkosystem Integrasjon med omfattende løsninger
    - Kontinuerlig Sikkerhetsevolusjon med adaptive praksiser
  - **Microsoft Sikkerhetsløsninger**: Forbedret integrasjonsveiledning for Prompt Shields, Azure Content Safety, Entra ID og GitHub Advanced Security
  - **Implementeringsressurser**: Kategoriserte omfattende ressurslenker etter Offisiell MCP Dokumentasjon, Microsoft Sikkerhetsløsninger, Sikkerhetsstandarder og Implementeringsveiledninger

#### Avanserte Sikkerhetskontroller (02-Security/) - Enterprise Implementering
- **MCP-SECURITY-CONTROLS-2025.md**: Fullstendig overhaling med enterprise-grade sikkerhetsrammeverk
  - **9 Omfattende Sikkerhetsdomener**: Utvidet fra grunnleggende kontroller til detaljert enterprise-rammeverk
    - Avansert Autentisering & Autorisasjon med Microsoft Entra ID-integrasjon
    - Tokensikkerhet & Anti-Passthrough Kontroller med omfattende validering
    - Sesjonssikkerhetskontroller med kapringforebygging
    - AI-spesifikke Sikkerhetskontroller med promptinjeksjon og verktøyforgiftningforebygging
    - Forebygging av "Confused Deputy"-angrep med OAuth proxy-sikkerhet
    - Verktøyutførelsessikkerhet med sandkasse og isolasjon
    - Forsyningskjede-sikkerhetskontroller med avhengighetsverifisering
    - Overvåkings- & Deteksjonskontroller med SIEM-integrasjon
    - Hendelsesrespons & Gjenoppretting med automatiserte kapabiliteter
  - **Implementeringseksempler**: Lagt til detaljerte YAML-konfigurasjonsblokker og kodeeksempler
  - **Microsoft Løsninger Integrasjon**: Omfattende dekning av Azure sikkerhetstjenester, GitHub Advanced Security og enterprise identitetsadministrasjon

#### Avanserte Emner Sikkerhet (05-AdvancedTopics/mcp-security/) - Produksjonsklar Implementering
- **README.md**: Fullstendig omskriving for enterprise sikkerhetsimplementering
  - **Gjeldende Spesifikasjonsjustering**: Oppdatert til MCP Spesifikasjon 2025-06-18 med obligatoriske sikkerhetskrav
  - **Forbedret Autentisering**: Microsoft Entra ID-integrasjon med omfattende .NET og Java Spring Security-eksempler
  - **AI Sikkerhetsintegrasjon**: Microsoft Prompt Shields og Azure Content Safety-implementering med detaljerte Python-eksempler
  - **Avansert Trusselmitigering**: Omfattende implementeringseksempler for
    - Forebygging av "Confused Deputy"-angrep med PKCE og brukersamtykkevalidering
    - Forebygging av Token Passthrough med publikumvalidering og sikker tokenadministrasjon
    - Forebygging av Sesjonskapring med kryptografisk binding og atferdsanalyse
  - **Enterprise Sikkerhetsintegrasjon**: Azure Application Insights-overvåking, trusseldeteksjonspipelines og forsyningskjede-sikkerhet
  - **Implementeringssjekkliste**: Klare obligatoriske vs. anbefalte sikkerhetskontroller med Microsoft sikkerhetsøkosystemfordeler

### Dokumentasjonskvalitet & Standardjustering
- **Spesifikasjonsreferanser**: Oppdatert alle referanser til gjeldende MCP Spesifikasjon 2025-06-18
- **Microsoft Sikkerhetsøkosystem**: Forbedret integrasjonsveiledning gjennom all sikkerhetsdokumentasjon
- **Praktisk Implementering**: Lagt til detaljerte kodeeksempler i .NET, Java og Python med enterprise-mønstre
- **Ressursorganisering**: Omfattende kategorisering av offisiell dokumentasjon, sikkerhetsstandarder og implementeringsveiledninger
- **Visuelle Indikatorer**: Klar merking av obligatoriske krav vs. anbefalte praksiser

## 16. juli 2025

### README og Navigasjonsforbedringer
- Fullstendig redesignet curriculum-navigasjon i README.md
- Erstattet `<details>`-tagger med mer tilgjengelig tabellbasert format
- Opprettet alternative layoutalternativer i ny "alternative_layouts"-mappe
- Lagt til kortbaserte, fanebaserte og trekkspillbaserte navigasjonseksempler
- Oppdatert seksjonen for mappestruktur for å inkludere alle nyeste filer
- Forbedret "Hvordan bruke dette curriculum"-seksjonen med klare anbefalinger
- Oppdatert MCP spesifikasjonslenker til å peke til riktige URL-er
- Lagt til Kontekstteknikk-seksjonen (5.14) i curriculum-strukturen

### Studieguideoppdateringer
- Fullstendig revidert studieguide for å tilpasse seg gjeldende mappestruktur
- Lagt til nye seksjoner for MCP Klienter og Verktøy, og Populære MCP Servere
- Oppdatert Visuell Curriculum Kart for å nøyaktig reflektere alle emner
- Forbedret beskrivelser av Avanserte Emner for å dekke alle spesialiserte områder
- Oppdatert Case Studies-seksjonen for å reflektere faktiske eksempler
- Lagt til denne omfattende endringsloggen

### Fellesbidrag (06-CommunityContributions/)
- Lagt til detaljert informasjon om MCP-servere for bildegenerering
- Lagt til omfattende seksjon om bruk av Claude i VSCode
- Lagt til Cline terminalklient oppsett og bruksanvisning
- Oppdatert MCP-klientseksjonen for å inkludere alle populære klientalternativer
- Forbedret bidragseksempler med mer nøyaktige kodeprøver

### Avanserte Emner (05-AdvancedTopics/)
- Organisert alle spesialiserte emnemapper med konsistent navngivning
- Lagt til kontekstteknikkmaterialer og eksempler
- Lagt til Foundry agentintegrasjonsdokumentasjon
- Forbedret Entra ID sikkerhetsintegrasjonsdokumentasjon

## 11. juni 2025

### Første Opprettelse
- Utgitt første versjon av MCP for Nybegynnere curriculum
- Opprettet grunnleggende struktur for alle 10 hovedseksjoner
- Implementert Visuell Curriculum Kart for navigasjon
- Lagt til innledende prøveprosjekter i flere programmeringsspråk

### Komme i Gang (03-GettingStarted/)
- Opprettet første serverimplementeringseksempler
- Lagt til veiledning for klientutvikling
- Inkludert LLM-klientintegrasjonsinstruksjoner
- Lagt til VS Code-integrasjonsdokumentasjon
- Implementert Server-Sent Events (SSE) servereksempler

### Kjernekonsepter (01-CoreConcepts/)
- Lagt til detaljert forklaring av klient-server arkitektur
- Opprettet dokumentasjon om nøkkelprotokollkomponenter
- Dokumentert meldingsmønstre i MCP

## 23. mai 2025

### Mappestruktur
- Initialisert repository med grunnleggende mappestruktur
- Opprettet README-filer for hver hovedseksjon
- Satt opp oversettelsesinfrastruktur
- Lagt til bildeaktiva og diagrammer

### Dokumentasjon
- Opprettet innledende README.md med curriculum-oversikt
- Lagt til CODE_OF_CONDUCT.md og SECURITY.md
- Satt opp SUPPORT.md med veiledning for å få hjelp
- Opprettet foreløpig studieguide-struktur

## 15. april 2025

### Planlegging og Rammeverk
- Innledende planlegging for MCP for Nybegynnere curriculum
- Definerte læringsmål og målgruppe
- Skisserte 10-seksjonsstruktur for curriculum
- Utviklet konseptuelt rammeverk for eksempler og case-studier
- Opprettet innledende prototypeeksempler for nøkkelkonsepter

---

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vær oppmerksom på at automatiserte oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på sitt opprinnelige språk bør anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.