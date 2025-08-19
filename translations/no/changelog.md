<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T15:28:45+00:00",
  "source_file": "changelog.md",
  "language_code": "no"
}
-->
# Endringslogg: MCP for nybegynnere

Dette dokumentet fungerer som en oversikt over alle betydelige endringer gjort i læreplanen for Model Context Protocol (MCP) for nybegynnere. Endringer er dokumentert i omvendt kronologisk rekkefølge (nyeste endringer først).

## 18. august 2025

### Omfattende oppdatering av dokumentasjon - MCP-standarder 2025-06-18

#### MCP Sikkerhetspraksis (02-Security/) - Full modernisering
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Fullstendig omskriving i tråd med MCP-spesifikasjon 2025-06-18
  - **Obligatoriske krav**: La til eksplisitte MÅ/MÅ IKKE-krav fra offisiell spesifikasjon med tydelige visuelle indikatorer
  - **12 kjernepraksiser for sikkerhet**: Restrukturert fra en liste med 15 punkter til omfattende sikkerhetsdomener
    - Tokensikkerhet og autentisering med integrasjon av eksterne identitetsleverandører
    - Sesjonsstyring og transportsikkerhet med kryptografiske krav
    - AI-spesifikk trusselbeskyttelse med Microsoft Prompt Shields-integrasjon
    - Tilgangskontroll og tillatelser med prinsippet om minst privilegium
    - Innholdssikkerhet og overvåking med Azure Content Safety-integrasjon
    - Forsyningskjede-sikkerhet med omfattende komponentverifisering
    - OAuth-sikkerhet og forebygging av "Confused Deputy"-angrep med PKCE-implementering
    - Hendelseshåndtering og gjenoppretting med automatiserte kapabiliteter
    - Samsvar og styring med regulatorisk tilpasning
    - Avanserte sikkerhetskontroller med nulltillitsarkitektur
    - Microsofts sikkerhetsøkosystemintegrasjon med omfattende løsninger
    - Kontinuerlig sikkerhetsevolusjon med adaptive praksiser
  - **Microsofts sikkerhetsløsninger**: Forbedret integrasjonsveiledning for Prompt Shields, Azure Content Safety, Entra ID og GitHub Advanced Security
  - **Implementeringsressurser**: Kategoriserte omfattende ressurslenker etter Offisiell MCP-dokumentasjon, Microsofts sikkerhetsløsninger, sikkerhetsstandarder og implementeringsveiledninger

#### Avanserte sikkerhetskontroller (02-Security/) - Implementering for bedrifter
- **MCP-SECURITY-CONTROLS-2025.md**: Fullstendig overhaling med sikkerhetsrammeverk for bedrifter
  - **9 omfattende sikkerhetsdomener**: Utvidet fra grunnleggende kontroller til detaljert rammeverk for bedrifter
    - Avansert autentisering og autorisasjon med Microsoft Entra ID-integrasjon
    - Tokensikkerhet og anti-pass-through-kontroller med omfattende validering
    - Sesjonssikkerhetskontroller med forebygging av kapring
    - AI-spesifikke sikkerhetskontroller med forebygging av prompt-injeksjon og verktøyforgiftning
    - Forebygging av "Confused Deputy"-angrep med OAuth-proxy-sikkerhet
    - Verktøyeksekveringssikkerhet med sandkasse og isolasjon
    - Forsyningskjede-sikkerhetskontroller med avhengighetsverifisering
    - Overvåking og deteksjonskontroller med SIEM-integrasjon
    - Hendelseshåndtering og gjenoppretting med automatiserte kapabiliteter
  - **Implementeringseksempler**: La til detaljerte YAML-konfigurasjonsblokker og kodeeksempler
  - **Microsofts løsninger**: Omfattende dekning av Azure sikkerhetstjenester, GitHub Advanced Security og identitetsstyring for bedrifter

#### Avanserte emner sikkerhet (05-AdvancedTopics/mcp-security/) - Klar for produksjon
- **README.md**: Fullstendig omskriving for sikkerhetsimplementering i bedrifter
  - **Nåværende spesifikasjonsjustering**: Oppdatert til MCP-spesifikasjon 2025-06-18 med obligatoriske sikkerhetskrav
  - **Forbedret autentisering**: Microsoft Entra ID-integrasjon med omfattende .NET- og Java Spring Security-eksempler
  - **AI-sikkerhetsintegrasjon**: Microsoft Prompt Shields og Azure Content Safety-implementering med detaljerte Python-eksempler
  - **Avansert trusselmitigering**: Omfattende implementeringseksempler for
    - Forebygging av "Confused Deputy"-angrep med PKCE og validering av brukersamtykke
    - Forebygging av token-pass-through med validering av publikum og sikker tokenhåndtering
    - Forebygging av sesjonskapring med kryptografisk binding og atferdsanalyse
  - **Sikkerhetsintegrasjon for bedrifter**: Overvåking med Azure Application Insights, trusseldeteksjonspipelines og forsyningskjede-sikkerhet
  - **Implementeringssjekkliste**: Klare obligatoriske vs. anbefalte sikkerhetskontroller med fordeler fra Microsofts sikkerhetsøkosystem

### Dokumentasjonskvalitet og standardjustering
- **Spesifikasjonsreferanser**: Oppdatert alle referanser til gjeldende MCP-spesifikasjon 2025-06-18
- **Microsofts sikkerhetsøkosystem**: Forbedret integrasjonsveiledning gjennom all sikkerhetsdokumentasjon
- **Praktisk implementering**: La til detaljerte kodeeksempler i .NET, Java og Python med mønstre for bedrifter
- **Ressursorganisering**: Omfattende kategorisering av offisiell dokumentasjon, sikkerhetsstandarder og implementeringsveiledninger
- **Visuelle indikatorer**: Tydelig merking av obligatoriske krav vs. anbefalte praksiser

#### Grunnleggende konsepter (01-CoreConcepts/) - Full modernisering
- **Protokollversjonsoppdatering**: Oppdatert til å referere gjeldende MCP-spesifikasjon 2025-06-18 med datobasert versjonering (YYYY-MM-DD-format)
- **Arkitekturbeskrivelse**: Forbedret beskrivelser av verter, klienter og servere for å reflektere gjeldende MCP-arkitektur
  - Verter nå tydelig definert som AI-applikasjoner som koordinerer flere MCP-klienttilkoblinger
  - Klienter beskrevet som protokollkoblinger som opprettholder én-til-én serverforhold
  - Servere forbedret med lokale vs. eksterne distribusjonsscenarier
- **Primitive restrukturering**: Fullstendig overhaling av server- og klientprimitiver
  - Serverprimitiver: Ressurser (datakilder), Prompter (maler), Verktøy (eksekverbare funksjoner) med detaljerte forklaringer og eksempler
  - Klientprimitiver: Sampling (LLM-fullføringer), Elicitering (brukerinndata), Logging (feilsøking/overvåking)
  - Oppdatert med gjeldende oppdagelse (`*/list`), henting (`*/get`) og eksekvering (`*/call`) metode-mønstre
- **Protokollarkitektur**: Introduserte to-lags arkitekturmodell
  - Datalag: JSON-RPC 2.0-grunnlag med livssyklusstyring og primitiver
  - Transportlag: STDIO (lokalt) og Streamable HTTP med SSE (eksternt) transportmekanismer
- **Sikkerhetsrammeverk**: Omfattende sikkerhetsprinsipper inkludert eksplisitt brukersamtykke, databeskyttelse, verktøyeksekveringssikkerhet og transportsikkerhet
- **Kommunikasjonsmønstre**: Oppdaterte protokollmeldinger for å vise initialisering, oppdagelse, eksekvering og varslingsflyt
- **Kodeeksempler**: Oppfrisket flerspråklige eksempler (.NET, Java, Python, JavaScript) for å reflektere gjeldende MCP SDK-mønstre

#### Sikkerhet (02-Security/) - Omfattende sikkerhetsrevisjon  
- **Standardjustering**: Full justering med MCP-spesifikasjon 2025-06-18 sikkerhetskrav
- **Autentiseringsevolusjon**: Dokumentert utvikling fra tilpassede OAuth-servere til delegasjon av eksterne identitetsleverandører (Microsoft Entra ID)
- **AI-spesifikk trusselanalyse**: Forbedret dekning av moderne AI-angrepsvektorer
  - Detaljerte scenarier for prompt-injeksjonsangrep med virkelige eksempler
  - Verktøyforgiftningsmekanismer og "rug pull"-angrepsmønstre
  - Kontekstvindu-forgiftning og modellforvirringsangrep
- **Microsoft AI-sikkerhetsløsninger**: Omfattende dekning av Microsofts sikkerhetsøkosystem
  - AI Prompt Shields med avansert deteksjon, spotlighting og avgrensningsteknikker
  - Azure Content Safety-integrasjonsmønstre
  - GitHub Advanced Security for forsyningskjede-beskyttelse
- **Avansert trusselmitigering**: Detaljerte sikkerhetskontroller for
  - Sesjonskapring med MCP-spesifikke angrepsscenarier og kryptografiske sesjons-ID-krav
  - "Confused Deputy"-problemer i MCP-proxy-scenarier med eksplisitte samtykkekrav
  - Token-pass-through-sårbarheter med obligatoriske valideringskontroller
- **Forsyningskjede-sikkerhet**: Utvidet dekning av AI-forsyningskjeden inkludert grunnmodeller, embeddings-tjenester, kontekstleverandører og tredjeparts-APIer
- **Grunnleggende sikkerhet**: Forbedret integrasjon med sikkerhetsmønstre for bedrifter inkludert nulltillitsarkitektur og Microsofts sikkerhetsøkosystem
- **Ressursorganisering**: Kategoriserte omfattende ressurslenker etter type (Offisielle dokumenter, standarder, forskning, Microsoft-løsninger, implementeringsveiledninger)

### Dokumentasjonskvalitetsforbedringer
- **Strukturerte læringsmål**: Forbedret læringsmål med spesifikke, handlingsrettede utfall 
- **Kryssreferanser**: La til lenker mellom relaterte sikkerhets- og grunnkonseptemner
- **Oppdatert informasjon**: Oppdatert alle datoreferanser og spesifikasjonslenker til gjeldende standarder
- **Implementeringsveiledning**: La til spesifikke, handlingsrettede implementeringsretningslinjer gjennom begge seksjoner

## 16. juli 2025

### README og navigasjonsforbedringer
- Fullstendig redesignet navigasjonen i README.md
- Erstattet `<details>`-tagger med mer tilgjengelig tabellbasert format
- Opprettet alternative layoutalternativer i ny "alternative_layouts"-mappe
- La til kortbaserte, fanebaserte og trekkspillbaserte navigasjonseksempler
- Oppdatert seksjonen for mappestruktur til å inkludere alle nyeste filer
- Forbedret "Hvordan bruke denne læreplanen"-seksjonen med klare anbefalinger
- Oppdatert MCP-spesifikasjonslenker til riktige URL-er
- La til seksjonen for kontekstingeniørarbeid (5.14) i læreplanstrukturen

### Oppdateringer i studieveiledning
- Fullstendig revidert studieveiledningen for å tilpasse seg gjeldende mappestruktur
- La til nye seksjoner for MCP-klienter og verktøy, og populære MCP-servere
- Oppdatert det visuelle læreplan-kartet for å nøyaktig reflektere alle emner
- Forbedret beskrivelser av avanserte emner for å dekke alle spesialiserte områder
- Oppdatert seksjonen for casestudier for å reflektere faktiske eksempler
- La til denne omfattende endringsloggen

### Felles bidrag (06-CommunityContributions/)
- La til detaljert informasjon om MCP-servere for bildegenerering
- La til omfattende seksjon om bruk av Claude i VSCode
- La til oppsett og bruksanvisning for Cline terminalklient
- Oppdatert MCP-klientseksjonen for å inkludere alle populære klientalternativer
- Forbedret bidragseksempler med mer nøyaktige kodeprøver

### Avanserte emner (05-AdvancedTopics/)
- Organisert alle spesialiserte emnemapper med konsistent navngivning
- La til kontekstingeniørmaterialer og eksempler
- La til dokumentasjon for Foundry-agentintegrasjon
- Forbedret dokumentasjon for Entra ID-sikkerhetsintegrasjon

## 11. juni 2025

### Første opprettelse
- Utgitt første versjon av MCP for nybegynnere-læreplanen
- Opprettet grunnleggende struktur for alle 10 hovedseksjoner
- Implementert visuelt læreplan-kart for navigasjon
- La til innledende prøveprosjekter i flere programmeringsspråk

### Komme i gang (03-GettingStarted/)
- Opprettet første serverimplementeringseksempler
- La til veiledning for klientutvikling
- Inkludert integrasjonsinstruksjoner for LLM-klienter
- La til dokumentasjon for VS Code-integrasjon
- Implementert eksempler på Server-Sent Events (SSE)-servere

### Grunnleggende konsepter (01-CoreConcepts/)
- La til detaljert forklaring av klient-server-arkitektur
- Opprettet dokumentasjon om nøkkelprotokollkomponenter
- Dokumentert meldingsmønstre i MCP

## 23. mai 2025

### Mappestruktur
- Initialisert repository med grunnleggende mappestruktur
- Opprettet README-filer for hver hovedseksjon
- Satt opp oversettelsesinfrastruktur
- La til bildeaktiva og diagrammer

### Dokumentasjon
- Opprettet innledende README.md med oversikt over læreplanen
- La til CODE_OF_CONDUCT.md og SECURITY.md
- Satt opp SUPPORT.md med veiledning for å få hjelp
- Opprettet foreløpig struktur for studieveiledning

## 15. april 2025

### Planlegging og rammeverk
- Innledende planlegging for MCP for nybegynnere-læreplanen
- Definerte læringsmål og målgruppe
- Skisserte 10-seksjonsstrukturen for læreplanen
- Utviklet konseptuelt rammeverk for eksempler og casestudier
- Opprettet innledende prototypeeksempler for nøkkelkonsepter

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vær oppmerksom på at automatiserte oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på sitt opprinnelige språk bør anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.