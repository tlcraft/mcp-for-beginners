<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T08:45:10+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "da"
}
-->
# Seneste MCP Sikkerhedskontroller - Opdatering juli 2025

Efterhånden som Model Context Protocol (MCP) fortsætter med at udvikle sig, forbliver sikkerhed en afgørende faktor. Dette dokument beskriver de nyeste sikkerhedskontroller og bedste praksis for sikker implementering af MCP pr. juli 2025.

## Autentificering og Autorisation

### OAuth 2.0 Delegationsunderstøttelse

De seneste opdateringer til MCP-specifikationen tillader nu, at MCP-servere kan delegere brugerautentificering til eksterne tjenester som Microsoft Entra ID. Dette forbedrer sikkerheden markant ved at:

1. **Eliminere brugerdefineret autentificeringsimplementering**: Mindsker risikoen for sikkerhedssvagheder i brugerdefineret autentificeringskode  
2. **Udnytte etablerede identitetsudbydere**: Drage fordel af sikkerhedsfunktioner på virksomhedsniveau  
3. **Centralisere identitetsstyring**: Forenkler håndtering af brugerlivscyklus og adgangskontrol  

## Forebyggelse af Token Passthrough

MCP Authorization Specification forbyder eksplicit token passthrough for at forhindre omgåelse af sikkerhedskontroller og ansvarlighedsproblemer.

### Vigtige krav

1. **MCP-servere MÅ IKKE acceptere tokens, der ikke er udstedt til dem**: Valider at alle tokens har korrekt audience-claim  
2. **Implementer korrekt tokenvalidering**: Tjek issuer, audience, udløbstid og signatur  
3. **Brug separat tokenudstedelse**: Udsted nye tokens til downstream-tjenester i stedet for at videresende eksisterende tokens  

## Sikker Sessionhåndtering

For at forhindre session hijacking og fixation-angreb, implementer følgende kontroller:

1. **Brug sikre, ikke-deterministiske session-ID’er**: Genereret med kryptografisk sikre tilfældige talgeneratorer  
2. **Bind sessioner til brugeridentitet**: Kombiner session-ID’er med bruger-specifik information  
3. **Implementer korrekt sessionrotation**: Efter autentificeringsændringer eller privilegieoptrapning  
4. **Sæt passende sessionstimeouts**: Balancer sikkerhed med brugeroplevelse  

## Sandboxing af Værktøjsudførelse

For at forhindre lateral bevægelse og indeholde potentielle kompromitteringer:

1. **Isoler værktøjsudførelsesmiljøer**: Brug containere eller separate processer  
2. **Anvend ressourcebegrænsninger**: Forhindre angreb baseret på ressourceudtømning  
3. **Implementer mindst privilegie-adgang**: Giv kun nødvendige tilladelser  
4. **Overvåg udførelsesmønstre**: Opdag unormal adfærd  

## Beskyttelse af Værktøjsdefinitioner

For at forhindre værktøjsforgiftning:

1. **Valider værktøjsdefinitioner før brug**: Tjek for ondsindede instruktioner eller upassende mønstre  
2. **Brug integritetsverifikation**: Hash eller signer værktøjsdefinitioner for at opdage uautoriserede ændringer  
3. **Implementer ændringsovervågning**: Alarmer ved uventede modifikationer af værktøjsmetadata  
4. **Versionsstyr værktøjsdefinitioner**: Spor ændringer og muliggør rollback om nødvendigt  

Disse kontroller arbejder sammen for at skabe en robust sikkerhedsposition for MCP-implementeringer, der adresserer de unikke udfordringer ved AI-drevne systemer samtidig med at traditionelle sikkerhedsprincipper opretholdes.

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.