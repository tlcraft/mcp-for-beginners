<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T17:51:39+00:00",
  "source_file": "changelog.md",
  "language_code": "no"
}
-->
# Endringslogg: MCP for Nybegynnere Pensum

Dette dokumentet fungerer som en oversikt over alle betydelige endringer gjort i pensumet for Model Context Protocol (MCP) for nybegynnere. Endringene er dokumentert i omvendt kronologisk rekkefølge (nyeste endringer først).

## 29. september 2025

### MCP Server Database Integrasjonslaboratorier - Omfattende Praktisk Læringssti

#### 11-MCPServerHandsOnLabs - Nytt Komplett Database Integrasjonspensum
- **Komplett 13-lab læringssti**: Lagt til omfattende praktisk pensum for å bygge produksjonsklare MCP-servere med PostgreSQL databaseintegrasjon
  - **Reell Implementering**: Zava Retail-analyse som demonstrerer mønstre på bedriftsnivå
  - **Strukturert Læringsprogresjon**:
    - **Lab 00-03: Grunnleggende** - Introduksjon, Kjernearkitektur, Sikkerhet & Multi-Tenancy, Miljøoppsett
    - **Lab 04-06: Bygging av MCP-serveren** - Databasedesign & Skjema, MCP Server Implementering, Verktøyutvikling  
    - **Lab 07-09: Avanserte Funksjoner** - Semantisk Søkeintegrasjon, Testing & Feilsøking, VS Code Integrasjon
    - **Lab 10-12: Produksjon & Beste Praksis** - Distribusjonsstrategier, Overvåking & Observasjon, Beste Praksis & Optimalisering
  - **Bedriftsteknologier**: FastMCP-rammeverk, PostgreSQL med pgvector, Azure OpenAI embeddings, Azure Container Apps, Application Insights
  - **Avanserte Funksjoner**: Row Level Security (RLS), semantisk søk, multi-tenant data tilgang, vektor embeddings, sanntids overvåking

#### Terminologistandardisering - Modul til Lab-konvertering
- **Omfattende Dokumentasjonsoppdatering**: Systematisk oppdatert alle README-filer i 11-MCPServerHandsOnLabs for å bruke "Lab"-terminologi i stedet for "Modul"
  - **Seksjonsoverskrifter**: Oppdatert "Hva denne modulen dekker" til "Hva denne laben dekker" i alle 13 laboratorier
  - **Innholdsbeskrivelse**: Endret "Denne modulen gir..." til "Denne laben gir..." gjennom hele dokumentasjonen
  - **Læringsmål**: Oppdatert "Ved slutten av denne modulen..." til "Ved slutten av denne laben..."
  - **Navigasjonslenker**: Konvertert alle "Modul XX:" referanser til "Lab XX:" i kryssreferanser og navigasjon
  - **Fullføringssporing**: Oppdatert "Etter å ha fullført denne modulen..." til "Etter å ha fullført denne laben..."
  - **Bevarte Tekniske Referanser**: Opprettholdt Python modulreferanser i konfigurasjonsfiler (f.eks., `"module": "mcp_server.main"`)

#### Forbedring av Studieveiledning (study_guide.md)
- **Visuell Pensumkart**: Lagt til ny "11. Database Integrasjonslaboratorier"-seksjon med omfattende labstrukturvisualisering
- **Repository-struktur**: Oppdatert fra ti til elleve hovedseksjoner med detaljert beskrivelse av 11-MCPServerHandsOnLabs
- **Veiledning for Læringssti**: Forbedret navigasjonsinstruksjoner for å dekke seksjoner 00-11
- **Teknologidekning**: Lagt til detaljer om FastMCP, PostgreSQL, Azure-tjenesteintegrasjon
- **Læringsresultater**: Fremhevet utvikling av produksjonsklare servere, databaseintegrasjonsmønstre og sikkerhet på bedriftsnivå

#### Hoved README-strukturforbedring
- **Lab-basert Terminologi**: Oppdatert hoved README.md i 11-MCPServerHandsOnLabs for konsekvent bruk av "Lab"-struktur
- **Organisering av Læringssti**: Klar progresjon fra grunnleggende konsepter til avansert implementering og produksjonsdistribusjon
- **Fokus på Reelle Eksempler**: Vektlegging av praktisk, praktisk læring med mønstre og teknologier på bedriftsnivå

### Dokumentasjonskvalitet & Konsistensforbedringer
- **Fokus på Praktisk Læring**: Forsterket praktisk, lab-basert tilnærming gjennom hele dokumentasjonen
- **Fokus på Bedriftsmønstre**: Fremhevet produksjonsklare implementeringer og sikkerhetsbetraktninger på bedriftsnivå
- **Teknologiintegrasjon**: Omfattende dekning av moderne Azure-tjenester og AI-integrasjonsmønstre
- **Læringsprogresjon**: Klar, strukturert sti fra grunnleggende konsepter til produksjonsdistribusjon

## 26. september 2025

### Forbedring av Casestudier - GitHub MCP Registry Integrasjon

#### Casestudier (09-CaseStudy/) - Fokus på Økosystemutvikling
- **README.md**: Stor utvidelse med omfattende GitHub MCP Registry casestudie
  - **GitHub MCP Registry Casestudie**: Ny omfattende casestudie som undersøker GitHubs MCP Registry-lansering i september 2025
    - **Problemanalyse**: Detaljert undersøkelse av fragmenterte MCP-serveroppdagelses- og distribusjonsutfordringer
    - **Løsningsarkitektur**: GitHubs sentraliserte registertilnærming med ett-klikks VS Code-installasjon
    - **Forretningspåvirkning**: Målbare forbedringer i utvikleropplæring og produktivitet
    - **Strategisk Verdi**: Fokus på modulær agentdistribusjon og kryssverktøy-interoperabilitet
    - **Økosystemutvikling**: Posisjonering som grunnleggende plattform for agentisk integrasjon
  - **Forbedret Casestudiestruktur**: Oppdatert alle syv casestudier med konsekvent formatering og omfattende beskrivelser
    - Azure AI Reiseagenter: Fokus på multi-agent orkestrering
    - Azure DevOps Integrasjon: Fokus på arbeidsflytautomatisering
    - Sanntids Dokumentasjonsinnhenting: Python konsollklientimplementering
    - Interaktiv Studieplan Generator: Chainlit samtale webapp
    - Dokumentasjon i Editor: VS Code og GitHub Copilot integrasjon
    - Azure API Management: Mønstre for API-integrasjon på bedriftsnivå
    - GitHub MCP Registry: Økosystemutvikling og samfunnsplattform
  - **Omfattende Konklusjon**: Omskrevet konklusjonsseksjon som fremhever syv casestudier som dekker flere MCP-implementeringsdimensjoner
    - Bedriftsintegrasjon, Multi-Agent Orkestrering, Utviklerproduktivitet
    - Økosystemutvikling, Utdanningsapplikasjoner kategorisering
    - Forbedrede innsikter i arkitekturmønstre, implementeringsstrategier og beste praksis
    - Vektlegging av MCP som moden, produksjonsklar protokoll

#### Oppdateringer i Studieveiledning (study_guide.md)
- **Visuell Pensumkart**: Oppdatert tankekart for å inkludere GitHub MCP Registry i Casestudier-seksjonen
- **Beskrivelse av Casestudier**: Forbedret fra generiske beskrivelser til detaljert oppdeling av syv omfattende casestudier
- **Repository-struktur**: Oppdatert seksjon 10 for å reflektere omfattende dekning av casestudier med spesifikke implementeringsdetaljer
- **Integrasjon av Endringslogg**: Lagt til 26. september 2025-oppføring som dokumenterer GitHub MCP Registry-tillegg og forbedringer av casestudier
- **Datooppdateringer**: Oppdatert bunnteksttidsstempel for å reflektere siste revisjon (26. september 2025)

### Forbedringer i Dokumentasjonskvalitet
- **Konsistensforbedring**: Standardisert formatering og struktur for casestudier på tvers av alle syv eksempler
- **Omfattende Dekning**: Casestudier dekker nå bedrifts-, utviklerproduktivitet- og økosystemutviklingsscenarier
- **Strategisk Posisjonering**: Forsterket fokus på MCP som grunnleggende plattform for agentiske systemdistribusjoner
- **Ressursintegrasjon**: Oppdatert tilleggsressurser for å inkludere GitHub MCP Registry-lenke

## 15. september 2025

### Utvidelse av Avanserte Emner - Tilpassede Transportsystemer & Kontekstteknikk

#### MCP Tilpassede Transportsystemer (05-AdvancedTopics/mcp-transport/) - Ny Avansert Implementeringsveiledning
- **README.md**: Komplett implementeringsveiledning for tilpassede MCP transportmekanismer
  - **Azure Event Grid Transport**: Omfattende serverløs hendelsesdrevet transportimplementering
    - Eksempler i C#, TypeScript og Python med Azure Functions-integrasjon
    - Hendelsesdrevet arkitekturmønstre for skalerbare MCP-løsninger
    - Webhook-mottakere og push-basert meldingshåndtering
  - **Azure Event Hubs Transport**: Implementering av høy gjennomstrømming for strømming
    - Sanntids strømmekapasiteter for lav-latens scenarier
    - Partisjoneringsstrategier og sjekkpunkthåndtering
    - Meldingsbatching og ytelsesoptimalisering
  - **Bedriftsintegrasjonsmønstre**: Produksjonsklare arkitektureksempler
    - Distribuert MCP-prosessering på tvers av flere Azure Functions
    - Hybrid transportarkitekturer som kombinerer flere transporttyper
    - Meldingsholdbarhet, pålitelighet og feilhåndteringsstrategier
  - **Sikkerhet & Overvåking**: Azure Key Vault-integrasjon og observasjonsmønstre
    - Autentisering med administrerte identiteter og minst privilegert tilgang
    - Application Insights-telemetri og ytelsesovervåking
    - Kretsbrytere og feiltoleransemønstre
  - **Testingsrammeverk**: Omfattende teststrategier for tilpassede transportsystemer
    - Enhetstesting med testdoubles og mocking-rammeverk
    - Integrasjonstesting med Azure Test Containers
    - Ytelses- og belastningstesting betraktninger

#### Kontekstteknikk (05-AdvancedTopics/mcp-contextengineering/) - Fremvoksende AI-disiplin
- **README.md**: Omfattende utforskning av kontekstteknikk som et fremvoksende felt
  - **Kjerneprinsipper**: Fullstendig kontekstdeling, bevissthet om handlingsbeslutninger og kontekstvinduadministrasjon
  - **MCP Protokolltilpasning**: Hvordan MCP-design adresserer utfordringer innen kontekstteknikk
    - Begrensninger i kontekstvindu og progressive lastestrategier
    - Relevansbestemmelse og dynamisk kontekstinnhenting
    - Multi-modal konteksthåndtering og sikkerhetsbetraktninger
  - **Implementeringsmetoder**: Enkelttrådede vs. multi-agent arkitekturer
    - Kontekstchunking og prioriteringsteknikker
    - Progressiv kontekstlasting og komprimeringsstrategier
    - Lagdelte konteksttilnærminger og optimalisering av innhenting
  - **Målingsrammeverk**: Fremvoksende metrikker for evaluering av konteksteffektivitet
    - Inndataeffektivitet, ytelse, kvalitet og brukeropplevelsesbetraktninger
    - Eksperimentelle tilnærminger til kontekstoptimalisering
    - Feilanalyse og forbedringsmetodologier

#### Oppdateringer i Pensumnavigasjon (README.md)
- **Forbedret Modulstruktur**: Oppdatert pensumtabell for å inkludere nye avanserte emner
  - Lagt til Kontekstteknikk (5.14) og Tilpasset Transport (5.15) oppføringer
  - Konsistent formatering og navigasjonslenker på tvers av alle moduler
  - Oppdaterte beskrivelser for å reflektere nåværende innholdsomfang

### Forbedringer i Katalogstruktur
- **Navnestandardisering**: Omdøpt "mcp transport" til "mcp-transport" for konsistens med andre avanserte emne-mapper
- **Innholdsorganisering**: Alle 05-AdvancedTopics-mapper følger nå konsistent navnemønster (mcp-[tema])

### Forbedringer i Dokumentasjonskvalitet
- **MCP Spesifikasjonsjustering**: Alt nytt innhold refererer til gjeldende MCP Spesifikasjon 2025-06-18
- **Flerspråklige Eksempler**: Omfattende kodeeksempler i C#, TypeScript og Python
- **Fokus på Bedriftsnivå**: Produksjonsklare mønstre og Azure-skyintegrasjon gjennom hele
- **Visuell Dokumentasjon**: Mermaid-diagrammer for arkitektur og flytvisualisering

## 18. august 2025

### Omfattende Dokumentasjonsoppdatering - MCP 2025-06-18 Standarder

#### MCP Sikkerhetsbestepraksis (02-Security/) - Fullstendig Modernisering
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Fullstendig omskriving i tråd med MCP Spesifikasjon 2025-06-18
  - **Obligatoriske Krav**: Lagt til eksplisitte MÅ/MÅ IKKE krav fra offisiell spesifikasjon med klare visuelle indikatorer
  - **12 Kjerne Sikkerhetspraksiser**: Restrukturert fra 15-punkts liste til omfattende sikkerhetsdomener
    - Tokensikkerhet & Autentisering med ekstern identitetsleverandørintegrasjon
    - Sesjonsadministrasjon & Transport-sikkerhet med kryptografiske krav
    - AI-spesifikk Trusselbeskyttelse med Microsoft Prompt Shields-integrasjon
    - Tilgangskontroll & Tillatelser med prinsippet om minst privilegium
    - Innholdssikkerhet & Overvåking med Azure Content Safety-integrasjon
    - Forsyningskjedesikkerhet med omfattende komponentverifisering
    - OAuth-sikkerhet & Forebygging av Forvirret Stedfortreder med PKCE-implementering
    - Hendelsesrespons & Gjenoppretting med automatiserte kapabiliteter
    - Samsvar & Styring med regulatorisk tilpasning
    - Avanserte Sikkerhetskontroller med null tillit-arkitektur
    - Microsoft Sikkerhetsøkosystem Integrasjon med omfattende løsninger
    - Kontinuerlig Sikkerhetsevolusjon med adaptive praksiser
  - **Microsoft Sikkerhetsløsninger**: Forbedret integrasjonsveiledning for Prompt Shields, Azure Content Safety, Entra ID og GitHub Advanced Security
  - **Implementeringsressurser**: Kategorisert omfattende ressurslenker etter Offisiell MCP Dokumentasjon, Microsoft Sikkerhetsløsninger, Sikkerhetsstandarder og Implementeringsveiledninger

#### Avanserte Sikkerhetskontroller (02-Security/) - Implementering på Bedriftsnivå
- **MCP-SECURITY-CONTROLS-2025.md**: Fullstendig overhaling med sikkerhetsrammeverk på bedriftsnivå
  - **9 Omfattende Sikkerhetsdomener**: Utvidet fra grunnleggende kontroller til detaljert rammeverk på bedriftsnivå
    - Avansert Autentisering & Autorisasjon med Microsoft Entra ID-integrasjon
    - Tokensikkerhet & Anti-Passthrough Kontroller med omfattende validering
    - Sesjonssikkerhetskontroller med kapringforebygging
    - AI-spesifikke Sikkerhetskontroller med promptinjeksjon og verktøyforgiftningforebygging
    - Forebygging av Forvirret Stedfortreder Angrep med OAuth proxy-sikkerhet
    - Verktøyutførelsessikkerhet med sandkasse og isolasjon
    - Forsyningskjedesikkerhetskontroller med avhengighetsverifisering
    - Overvåking & Deteksjonskontroller med SIEM-integrasjon
    - Hendelsesrespons & Gjenoppretting med automatiserte kapabiliteter
  - **Implementeringseksempler**: Lagt til detaljerte YAML-konfigurasjonsblokker og kodeeksempler
  - **Microsoft Løsninger Integrasjon**: Omfattende dekning av Azure sikkerhetstjenester, GitHub Advanced Security og identitetsadministrasjon på bedriftsnivå

#### Avanserte Emner Sikkerhet (05-AdvancedTopics/mcp-security/) - Produksjonsklar Implementering
- **README.md**: Fullstendig omskriving for implementering av sikkerhet på bedriftsnivå
  - **Gjeldende Spesifikasjonsjustering**: Oppdatert til MCP Spesifikasjon 2025-06-18 med obligatoriske sikkerhetskrav
  - **Forbedret Autentisering**: Microsoft Entra ID-integrasjon med omfattende .NET og Java Spring Security-eksempler
  - **AI Sikkerhetsintegrasjon**: Microsoft Prompt Shields og Azure Content Safety-implementering med detaljerte Python-eksempler
  - **Avansert Trusselmitigering**: Omfattende implementeringseksempler for
    - Fore
- **Visuelle indikatorer**: Tydelig markering av obligatoriske krav vs. anbefalte praksiser

#### Kjernekonsepter (01-CoreConcepts/) - Fullstendig modernisering
- **Oppdatering av protokollversjon**: Oppdatert til å referere til gjeldende MCP-spesifikasjon 2025-06-18 med dato-basert versjonering (YYYY-MM-DD-format)
- **Arkitekturforbedring**: Forbedrede beskrivelser av verter, klienter og servere for å reflektere dagens MCP-arkitektur
  - Verter nå tydelig definert som AI-applikasjoner som koordinerer flere MCP-klienttilkoblinger
  - Klienter beskrevet som protokollkoblinger som opprettholder én-til-én forhold til servere
  - Servere forbedret med lokale vs. eksterne distribusjonsscenarier
- **Omstrukturering av primitiver**: Fullstendig overhaling av server- og klientprimitiver
  - Serverprimitiver: Ressurser (datakilder), Prompter (maler), Verktøy (utførbare funksjoner) med detaljerte forklaringer og eksempler
  - Klientprimitiver: Sampling (LLM-fullføringer), Elicitering (brukerinndata), Logging (feilsøking/overvåking)
  - Oppdatert med gjeldende oppdagelsesmetoder (`*/list`), hentingsmetoder (`*/get`) og utførelsesmetoder (`*/call`)
- **Protokollarkitektur**: Innført tolags arkitekturmodell
  - Datalag: JSON-RPC 2.0-grunnlag med livssyklusadministrasjon og primitiver
  - Transportlag: STDIO (lokalt) og Streamable HTTP med SSE (eksternt) transportmekanismer
- **Sikkerhetsrammeverk**: Omfattende sikkerhetsprinsipper inkludert eksplisitt brukersamtykke, databeskyttelse, verktøysikkerhet og transportlagssikkerhet
- **Kommunikasjonsmønstre**: Oppdaterte protokollmeldinger for å vise initiering, oppdagelse, utførelse og varsling
- **Kodeeksempler**: Oppdaterte flerspråklige eksempler (.NET, Java, Python, JavaScript) for å reflektere gjeldende MCP SDK-mønstre

#### Sikkerhet (02-Security/) - Omfattende sikkerhetsoverhaling  
- **Standardtilpasning**: Full tilpasning til MCP-spesifikasjonens sikkerhetskrav 2025-06-18
- **Autentiseringsevolusjon**: Dokumentert overgang fra tilpassede OAuth-servere til delegasjon via eksterne identitetsleverandører (Microsoft Entra ID)
- **AI-spesifikk trusselanalyse**: Forbedret dekning av moderne AI-angrepsvektorer
  - Detaljerte scenarier for prompt-injeksjonsangrep med virkelige eksempler
  - Mekanismer for verktøyforgiftning og "rug pull"-angrepsmønstre
  - Forgiftning av kontekstvindu og modellforvirringsangrep
- **Microsoft AI-sikkerhetsløsninger**: Omfattende dekning av Microsofts sikkerhetsøkosystem
  - AI Prompt Shields med avansert deteksjon, fremheving og avgrensningsteknikker
  - Azure Content Safety-integrasjonsmønstre
  - GitHub Advanced Security for forsyningskjedevern
- **Avansert trusselredusering**: Detaljerte sikkerhetskontroller for
  - Sesjonskapring med MCP-spesifikke angrepsscenarier og krav til kryptografiske sesjons-ID-er
  - Problemer med forvirrede stedfortredere i MCP-proxy-scenarier med eksplisitte samtykkekrav
  - Sårbarheter ved token-gjennomstrømning med obligatoriske valideringskontroller
- **Forsyningskjedesikkerhet**: Utvidet dekning av AI-forsyningskjeden inkludert grunnmodeller, embedding-tjenester, kontekstleverandører og tredjeparts-API-er
- **Grunnsikkerhet**: Forbedret integrasjon med bedriftsikkerhetsmønstre inkludert nulltillitsarkitektur og Microsofts sikkerhetsøkosystem
- **Ressursorganisering**: Kategorisert omfattende ressurslenker etter type (Offisielle dokumenter, standarder, forskning, Microsoft-løsninger, implementeringsguider)

### Forbedringer i dokumentasjonskvalitet
- **Strukturerte læringsmål**: Forbedrede læringsmål med spesifikke, handlingsrettede utfall
- **Kryssreferanser**: Lagt til lenker mellom relaterte sikkerhets- og kjernekonseptemner
- **Oppdatert informasjon**: Oppdatert alle datoreferanser og spesifikasjonslenker til gjeldende standarder
- **Implementeringsveiledning**: Lagt til spesifikke, handlingsrettede implementeringsveiledninger gjennom begge seksjoner

## 16. juli 2025

### README og navigasjonsforbedringer
- Fullstendig redesignet navigasjonen i README.md
- Erstattet `<details>`-tagger med mer tilgjengelig tabellbasert format
- Opprettet alternative layoutalternativer i ny "alternative_layouts"-mappe
- Lagt til eksempler på kortbasert, fanebasert og trekkspillbasert navigasjon
- Oppdatert seksjonen om mappestruktur for å inkludere alle nyeste filer
- Forbedret "Hvordan bruke dette pensumet"-seksjonen med klare anbefalinger
- Oppdatert MCP-spesifikasjonslenker til riktige URL-er
- Lagt til seksjonen om kontekstingeniørkunst (5.14) i pensumstrukturen

### Oppdateringer i studieveiledningen
- Fullstendig revidert studieveiledningen for å tilpasse seg gjeldende mappestruktur
- Lagt til nye seksjoner for MCP-klienter og verktøy, samt populære MCP-servere
- Oppdatert det visuelle pensumkartet for å nøyaktig reflektere alle emner
- Forbedret beskrivelser av avanserte emner for å dekke alle spesialiserte områder
- Oppdatert seksjonen om casestudier for å reflektere faktiske eksempler
- Lagt til denne omfattende endringsloggen

### Felles bidrag (06-CommunityContributions/)
- Lagt til detaljert informasjon om MCP-servere for bildegenerering
- Lagt til omfattende seksjon om bruk av Claude i VSCode
- Lagt til oppsett og bruksanvisning for Cline terminalklient
- Oppdatert MCP-klientseksjonen for å inkludere alle populære klientalternativer
- Forbedret bidragseksempler med mer nøyaktige kodeeksempler

### Avanserte emner (05-AdvancedTopics/)
- Organisert alle spesialiserte emnemapper med konsistent navngivning
- Lagt til materiale og eksempler for kontekstingeniørkunst
- Lagt til dokumentasjon for Foundry-agentintegrasjon
- Forbedret dokumentasjon for Entra ID-sikkerhetsintegrasjon

## 11. juni 2025

### Første opprettelse
- Utgitt første versjon av MCP for nybegynnere-pensumet
- Opprettet grunnleggende struktur for alle 10 hovedseksjoner
- Implementert visuelt pensumkart for navigasjon
- Lagt til innledende prøveprosjekter i flere programmeringsspråk

### Komme i gang (03-GettingStarted/)
- Opprettet første eksempler på serverimplementering
- Lagt til veiledning for klientutvikling
- Inkludert integrasjonsinstruksjoner for LLM-klienter
- Lagt til dokumentasjon for VS Code-integrasjon
- Implementert eksempler på servere med Server-Sent Events (SSE)

### Kjernekonsepter (01-CoreConcepts/)
- Lagt til detaljert forklaring av klient-server-arkitektur
- Opprettet dokumentasjon om nøkkelprotokollkomponenter
- Dokumentert meldingsmønstre i MCP

## 23. mai 2025

### Mappestruktur
- Initialisert depotet med grunnleggende mappestruktur
- Opprettet README-filer for hver hovedseksjon
- Satt opp oversettelsesinfrastruktur
- Lagt til bildeaktiva og diagrammer

### Dokumentasjon
- Opprettet innledende README.md med pensumoversikt
- Lagt til CODE_OF_CONDUCT.md og SECURITY.md
- Satt opp SUPPORT.md med veiledning for å få hjelp
- Opprettet foreløpig struktur for studieveiledning

## 15. april 2025

### Planlegging og rammeverk
- Innledende planlegging for MCP for nybegynnere-pensumet
- Definerte læringsmål og målgruppe
- Skisserte 10-seksjonsstrukturen for pensumet
- Utviklet konseptuelt rammeverk for eksempler og casestudier
- Opprettet innledende prototypeeksempler for nøkkelkonsepter

---

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi tilstreber nøyaktighet, vær oppmerksom på at automatiserte oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på sitt opprinnelige språk bør anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.