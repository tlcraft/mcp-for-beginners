<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T08:45:22+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "no"
}
-->
# Siste MCP-sikkerhetskontroller – Oppdatering juli 2025

Etter hvert som Model Context Protocol (MCP) fortsetter å utvikle seg, forblir sikkerhet en avgjørende faktor. Dette dokumentet beskriver de nyeste sikkerhetskontrollene og beste praksis for sikker implementering av MCP per juli 2025.

## Autentisering og autorisasjon

### OAuth 2.0 delegasjonsstøtte

Nylige oppdateringer i MCP-spesifikasjonen tillater nå at MCP-servere kan delegere brukerautentisering til eksterne tjenester som Microsoft Entra ID. Dette forbedrer sikkerhetsnivået betydelig ved å:

1. **Eliminere egendefinert autentiseringsimplementering**: Reduserer risikoen for sikkerhetssvakheter i egendefinert autentiseringskode  
2. **Utnytte etablerte identitetsleverandører**: Drar nytte av sikkerhetsfunksjoner på bedriftsnivå  
3. **Sentralisere identitetsadministrasjon**: Forenkler håndtering av brukerens livssyklus og tilgangskontroll  

## Forebygging av token-gjennomgang

MCP Authorization Specification forbyr eksplisitt token-gjennomgang for å hindre omgåelse av sikkerhetskontroller og ansvarsspørsmål.

### Viktige krav

1. **MCP-servere MÅ IKKE akseptere tokens som ikke er utstedt for dem**: Valider at alle tokens har korrekt audience-claim  
2. **Implementer korrekt token-validering**: Sjekk issuer, audience, utløpstid og signatur  
3. **Bruk separat token-utstedelse**: Utsted nye tokens for nedstrøms tjenester i stedet for å videreformidle eksisterende tokens  

## Sikker sesjonshåndtering

For å forhindre kapring og fikseringsangrep på sesjoner, implementer følgende kontroller:

1. **Bruk sikre, ikke-deterministiske sesjons-IDer**: Generert med kryptografisk sikre tilfeldige tallgeneratorer  
2. **Knytt sesjoner til brukeridentitet**: Kombiner sesjons-IDer med bruker-spesifikk informasjon  
3. **Implementer riktig sesjonsrotasjon**: Etter autentiseringsendringer eller privilegieheving  
4. **Sett passende sesjonsutløp**: Balanser sikkerhet med brukeropplevelse  

## Sandboxing av verktøykjøring

For å forhindre lateral bevegelse og begrense potensielle kompromitteringer:

1. **Isoler verktøykjøringsmiljøer**: Bruk containere eller separate prosesser  
2. **Sett ressursbegrensninger**: Forhindre angrep som utnytter ressursuttømming  
3. **Implementer minste privilegium-tilgang**: Gi kun nødvendige tillatelser  
4. **Overvåk kjøringsmønstre**: Oppdag unormal oppførsel  

## Beskyttelse av verktøydefinisjoner

For å forhindre forgiftning av verktøy:

1. **Valider verktøydefinisjoner før bruk**: Sjekk for ondsinnede instruksjoner eller upassende mønstre  
2. **Bruk integritetsverifisering**: Hash eller signer verktøydefinisjoner for å oppdage uautoriserte endringer  
3. **Implementer endringsovervåking**: Varsle ved uventede modifikasjoner i verktøymetadata  
4. **Versjonskontroller verktøydefinisjoner**: Spor endringer og muliggjør tilbakestilling ved behov  

Disse kontrollene fungerer sammen for å skape en robust sikkerhetsprofil for MCP-implementeringer, som tar høyde for de unike utfordringene i AI-drevne systemer samtidig som de opprettholder sterke tradisjonelle sikkerhetsrutiner.

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.