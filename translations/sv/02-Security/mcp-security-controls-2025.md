<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T08:44:59+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "sv"
}
-->
# Senaste MCP-säkerhetskontrollerna – Uppdatering juli 2025

När Model Context Protocol (MCP) fortsätter att utvecklas är säkerhet en avgörande faktor. Detta dokument beskriver de senaste säkerhetskontrollerna och bästa metoderna för att implementera MCP på ett säkert sätt från och med juli 2025.

## Autentisering och auktorisering

### OAuth 2.0-delegeringsstöd

Senaste uppdateringarna i MCP-specifikationen tillåter nu MCP-servrar att delegera användarautentisering till externa tjänster som Microsoft Entra ID. Detta förbättrar säkerheten avsevärt genom att:

1. **Eliminera egen autentiseringsimplementation**: Minskar risken för säkerhetsbrister i egen autentiseringskod  
2. **Utnyttja etablerade identitetsleverantörer**: Drar nytta av säkerhetsfunktioner på företagsnivå  
3. **Centralisera identitetshantering**: Förenklar hantering av användarlivscykel och åtkomstkontroll  

## Förhindrande av token-passthrough

MCP Authorization Specification förbjuder uttryckligen token-passthrough för att förhindra kringgående av säkerhetskontroller och ansvarighetsproblem.

### Viktiga krav

1. **MCP-servrar FÅR INTE acceptera tokens som inte är utfärdade för dem**: Validera att alla tokens har korrekt audience-claim  
2. **Implementera korrekt tokenvalidering**: Kontrollera utfärdare, audience, utgångsdatum och signatur  
3. **Använd separat tokenutfärdande**: Utfärda nya tokens för nedströms tjänster istället för att vidarebefordra befintliga tokens  

## Säker sessionshantering

För att förhindra sessionkapning och sessionfixeringsattacker, implementera följande kontroller:

1. **Använd säkra, icke-deterministiska sessions-ID:n**: Genererade med kryptografiskt säkra slumptalsgeneratorer  
2. **Koppla sessioner till användaridentitet**: Kombinera sessions-ID med användarspecifik information  
3. **Implementera korrekt sessionsrotation**: Efter autentiseringsändringar eller privilegiehöjningar  
4. **Sätt lämpliga sessionstidsgränser**: Balans mellan säkerhet och användarupplevelse  

## Sandlådemiljö för verktygsexekvering

För att förhindra laterala rörelser och begränsa potentiella intrång:

1. **Isolera verktygsexekveringsmiljöer**: Använd containers eller separata processer  
2. **Tillämpa resursbegränsningar**: Förhindra attacker som utnyttjar resursutarmning  
3. **Implementera principen om minsta privilegium**: Ge endast nödvändiga behörigheter  
4. **Övervaka exekveringsmönster**: Upptäck avvikande beteenden  

## Skydd av verktygsdefinitioner

För att förhindra verktygsförgiftning:

1. **Validera verktygsdefinitioner innan användning**: Kontrollera efter skadliga instruktioner eller olämpliga mönster  
2. **Använd integritetsverifiering**: Hasha eller signera verktygsdefinitioner för att upptäcka obehöriga ändringar  
3. **Implementera förändringsövervakning**: Larma vid oväntade ändringar i verktygsmetadata  
4. **Versionshantera verktygsdefinitioner**: Spåra ändringar och möjliggör återställning vid behov  

Dessa kontroller samverkar för att skapa en robust säkerhetsnivå för MCP-implementationer, som hanterar de unika utmaningarna med AI-drivna system samtidigt som starka traditionella säkerhetsrutiner upprätthålls.

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår till följd av användningen av denna översättning.