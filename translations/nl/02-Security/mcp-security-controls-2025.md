<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T08:45:47+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "nl"
}
-->
# Laatste MCP Beveiligingscontroles - Update juli 2025

Naarmate het Model Context Protocol (MCP) zich blijft ontwikkelen, blijft beveiliging een cruciale factor. Dit document beschrijft de nieuwste beveiligingscontroles en best practices voor het veilig implementeren van MCP per juli 2025.

## Authenticatie en Autorisatie

### OAuth 2.0 Delegatie Ondersteuning

Recente updates van de MCP-specificatie maken het mogelijk dat MCP-servers gebruikersauthenticatie delegeren aan externe diensten zoals Microsoft Entra ID. Dit verbetert de beveiliging aanzienlijk door:

1. **Het vermijden van eigen authenticatie-implementaties**: Vermindert het risico op beveiligingsfouten in zelfgeschreven authenticatiecode  
2. **Gebruik maken van gevestigde identity providers**: Profiteren van beveiligingsfuncties op ondernemingsniveau  
3. **Centraliseren van identiteitsbeheer**: Vereenvoudigt het beheer van gebruikerslevenscyclus en toegangscontrole  

## Voorkomen van Token Passthrough

De MCP Authorization Specification verbiedt expliciet token passthrough om het omzeilen van beveiligingscontroles en problemen met verantwoordelijkheid te voorkomen.

### Belangrijke Vereisten

1. **MCP-servers MOGEN GEEN tokens accepteren die niet voor hen zijn uitgegeven**: Valideer dat alle tokens de juiste audience claim bevatten  
2. **Implementeer correcte tokenvalidatie**: Controleer issuer, audience, vervaldatum en handtekening  
3. **Gebruik aparte tokenuitgifte**: Geef nieuwe tokens uit voor downstream services in plaats van bestaande tokens door te geven  

## Beheer van Veilige Sessies

Om sessiekapingen en sessiefixatie-aanvallen te voorkomen, implementeer de volgende maatregelen:

1. **Gebruik veilige, niet-deterministische sessie-ID’s**: Genereer met cryptografisch veilige willekeurige getalgeneratoren  
2. **Koppel sessies aan gebruikersidentiteit**: Combineer sessie-ID’s met gebruikersspecifieke informatie  
3. **Implementeer correcte sessierotatie**: Na authenticatiewijzigingen of privilegeverhogingen  
4. **Stel passende sessietime-outs in**: Vind een balans tussen beveiliging en gebruikerservaring  

## Sandboxen van Tooluitvoering

Om laterale bewegingen te voorkomen en mogelijke compromitteringen te beperken:

1. **Isoleer tooluitvoeringsomgevingen**: Gebruik containers of aparte processen  
2. **Pas resourcebeperkingen toe**: Voorkom aanvallen gericht op het uitputten van resources  
3. **Implementeer het principe van minste privilege**: Verleen alleen noodzakelijke rechten  
4. **Monitor uitvoeringspatronen**: Detecteer afwijkend gedrag  

## Bescherming van Tooldefinities

Om toolvergiftiging te voorkomen:

1. **Valideer tooldefinities vóór gebruik**: Controleer op kwaadaardige instructies of ongepaste patronen  
2. **Gebruik integriteitsverificatie**: Hash of onderteken tooldefinities om ongeautoriseerde wijzigingen te detecteren  
3. **Implementeer wijzigingsmonitoring**: Waarschuw bij onverwachte aanpassingen aan toolmetadata  
4. **Versiebeheer van tooldefinities**: Houd wijzigingen bij en maak rollback mogelijk indien nodig  

Deze controles werken samen om een robuuste beveiligingshouding te creëren voor MCP-implementaties, waarbij de unieke uitdagingen van AI-gestuurde systemen worden aangepakt zonder de sterke traditionele beveiligingspraktijken uit het oog te verliezen.

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.