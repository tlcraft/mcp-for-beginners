<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T08:52:48+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "no"
}
-->
# MCP Security Best Practices - Oppdatering juli 2025

## Omfattende sikkerhetsrutiner for MCP-implementasjoner

Når du jobber med MCP-servere, følg disse sikkerhetsrutinene for å beskytte data, infrastruktur og brukere:

1. **Inputvalidering**: Valider og rens alltid input for å forhindre injeksjonsangrep og confused deputy-problemer.
   - Implementer streng validering for alle verktøyparametere
   - Bruk skjema-validering for å sikre at forespørsler følger forventede formater
   - Filtrer potensielt skadelig innhold før behandling

2. **Tilgangskontroll**: Implementer riktig autentisering og autorisasjon for MCP-serveren med detaljerte tillatelser.
   - Bruk OAuth 2.0 med etablerte identitetsleverandører som Microsoft Entra ID
   - Implementer rollebasert tilgangskontroll (RBAC) for MCP-verktøy
   - Unngå å lage egen autentisering når etablerte løsninger finnes

3. **Sikker kommunikasjon**: Bruk HTTPS/TLS for all kommunikasjon med MCP-serveren, og vurder ekstra kryptering for sensitiv data.
   - Konfigurer TLS 1.3 der det er mulig
   - Implementer sertifikat-pinning for kritiske tilkoblinger
   - Roter sertifikater jevnlig og verifiser gyldigheten

4. **Ratebegrensning**: Implementer ratebegrensning for å forhindre misbruk, DoS-angrep og for å styre ressursbruk.
   - Sett passende forespørselsgrenser basert på forventet bruksmønster
   - Implementer gradvis respons ved overdreven trafikk
   - Vurder bruker-spesifikke ratebegrensninger basert på autentiseringsstatus

5. **Logging og overvåking**: Overvåk MCP-serveren for mistenkelig aktivitet og implementer omfattende revisjonsspor.
   - Logg alle autentiseringsforsøk og verktøybruk
   - Implementer varsling i sanntid ved mistenkelige mønstre
   - Sørg for at logger lagres sikkert og ikke kan manipuleres

6. **Sikker lagring**: Beskytt sensitiv data og legitimasjon med riktig kryptering i hvilemodus.
   - Bruk nøkkellagre eller sikre legitimasjonslagre for alle hemmeligheter
   - Implementer felt-nivå kryptering for sensitiv data
   - Roter krypteringsnøkler og legitimasjon jevnlig

7. **Tokenhåndtering**: Forhindre token-passthrough-sårbarheter ved å validere og rense alle modell-input og -output.
   - Implementer tokenvalidering basert på audience-claims
   - Aksepter aldri tokens som ikke er eksplisitt utstedt for din MCP-server
   - Implementer riktig håndtering av tokenlevetid og rotasjon

8. **Sessionshåndtering**: Implementer sikker håndtering av økter for å forhindre session hijacking og fixation-angrep.
   - Bruk sikre, ikke-deterministiske session-IDer
   - Knytt økter til bruker-spesifikk informasjon
   - Implementer riktig utløp og rotasjon av økter

9. **Sandboxing av verktøykjøring**: Kjør verktøy i isolerte miljøer for å forhindre lateral bevegelse ved kompromittering.
   - Implementer container-isolasjon for verktøykjøring
   - Sett ressursgrenser for å forhindre ressursutmattelsesangrep
   - Bruk separate kjøringskontekster for ulike sikkerhetsdomener

10. **Regelmessige sikkerhetsrevisjoner**: Gjennomfør periodiske sikkerhetsvurderinger av MCP-implementasjoner og avhengigheter.
    - Planlegg regelmessig penetrasjonstesting
    - Bruk automatiserte skanneverktøy for å oppdage sårbarheter
    - Hold avhengigheter oppdatert for å adressere kjente sikkerhetsproblemer

11. **Innholdssikkerhetsfiltrering**: Implementer innholdsfiltre for både input og output.
    - Bruk Azure Content Safety eller lignende tjenester for å oppdage skadelig innhold
    - Implementer prompt shield-teknikker for å forhindre prompt-injeksjon
    - Skann generert innhold for potensiell lekkasje av sensitiv data

12. **Sikkerhet i leverandørkjeden**: Verifiser integriteten og ektheten til alle komponenter i AI-leverandørkjeden.
    - Bruk signerte pakker og verifiser signaturer
    - Implementer analyse av software bill of materials (SBOM)
    - Overvåk for ondsinnede oppdateringer til avhengigheter

13. **Beskyttelse av verktøydefinisjoner**: Forhindre verktøyforgiftning ved å sikre verktøydefinisjoner og metadata.
    - Valider verktøydefinisjoner før bruk
    - Overvåk for uventede endringer i verktøymetadata
    - Implementer integritetskontroller for verktøydefinisjoner

14. **Dynamisk overvåking av kjøring**: Overvåk kjøreatferd til MCP-servere og verktøy.
    - Implementer atferdsanalyse for å oppdage avvik
    - Sett opp varsling for uventede kjøringsmønstre
    - Bruk runtime application self-protection (RASP)-teknikker

15. **Prinsippet om minste privilegium**: Sørg for at MCP-servere og verktøy opererer med minimale nødvendige tillatelser.
    - Gi kun de spesifikke tillatelsene som trengs for hver operasjon
    - Gjennomgå og revider tillatelser jevnlig
    - Implementer just-in-time-tilgang for administrative funksjoner

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.