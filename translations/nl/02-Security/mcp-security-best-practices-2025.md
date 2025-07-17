<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T08:53:26+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "nl"
}
-->
# MCP Security Best Practices - Update juli 2025

## Uitgebreide beveiligingsrichtlijnen voor MCP-implementaties

Bij het werken met MCP-servers, volg deze beveiligingsrichtlijnen om je data, infrastructuur en gebruikers te beschermen:

1. **Inputvalidatie**: Valideer en reinig altijd invoer om injectieaanvallen en confused deputy-problemen te voorkomen.
   - Implementeer strikte validatie voor alle toolparameters
   - Gebruik schema-validatie om te zorgen dat verzoeken aan de verwachte formaten voldoen
   - Filter mogelijk kwaadaardige inhoud voordat je deze verwerkt

2. **Toegangscontrole**: Zorg voor juiste authenticatie en autorisatie voor je MCP-server met fijnmazige permissies.
   - Gebruik OAuth 2.0 met gevestigde identiteitsproviders zoals Microsoft Entra ID
   - Implementeer role-based access control (RBAC) voor MCP-tools
   - Implementeer nooit eigen authenticatie als er al gevestigde oplossingen zijn

3. **Veilige communicatie**: Gebruik HTTPS/TLS voor alle communicatie met je MCP-server en overweeg extra versleuteling voor gevoelige data.
   - Configureer TLS 1.3 waar mogelijk
   - Implementeer certificate pinning voor kritieke verbindingen
   - Wissel certificaten regelmatig en controleer hun geldigheid

4. **Rate limiting**: Voer rate limiting in om misbruik, DoS-aanvallen en overmatig gebruik van resources te voorkomen.
   - Stel passende limieten in op basis van verwachte gebruikspatronen
   - Implementeer graduele reacties op overmatige verzoeken
   - Overweeg gebruikersspecifieke limieten op basis van authenticatiestatus

5. **Logging en monitoring**: Houd je MCP-server in de gaten op verdachte activiteiten en zorg voor uitgebreide audit trails.
   - Log alle authenticatiepogingen en toolaanroepen
   - Implementeer realtime waarschuwingen bij verdachte patronen
   - Zorg dat logs veilig worden opgeslagen en niet kunnen worden aangepast

6. **Veilige opslag**: Bescherm gevoelige data en inloggegevens met goede versleuteling in rust.
   - Gebruik key vaults of beveiligde credential stores voor alle geheimen
   - Implementeer veldniveau-encryptie voor gevoelige data
   - Wissel encryptiesleutels en inloggegevens regelmatig

7. **Tokenbeheer**: Voorkom kwetsbaarheden bij token-passthrough door alle modelinvoer en -uitvoer te valideren en te reinigen.
   - Implementeer tokenvalidatie op basis van audience claims
   - Accepteer nooit tokens die niet expliciet voor jouw MCP-server zijn uitgegeven
   - Zorg voor goed beheer van tokenlevensduur en rotatie

8. **Sessiebeheer**: Zorg voor veilige sessieafhandeling om session hijacking en fixation-aanvallen te voorkomen.
   - Gebruik veilige, niet-deterministische sessie-ID’s
   - Koppel sessies aan gebruikersspecifieke informatie
   - Implementeer correcte sessieverval en rotatie

9. **Sandboxing van tooluitvoering**: Voer tools uit in geïsoleerde omgevingen om laterale beweging bij compromittering te voorkomen.
   - Implementeer containerisolatie voor tooluitvoering
   - Stel resource-limieten in om resource-uitputtingsaanvallen te voorkomen
   - Gebruik aparte uitvoeringscontexten voor verschillende beveiligingsdomeinen

10. **Regelmatige beveiligingsaudits**: Voer periodieke beveiligingsreviews uit van je MCP-implementaties en afhankelijkheden.
    - Plan regelmatige penetratietests
    - Gebruik geautomatiseerde scan-tools om kwetsbaarheden te detecteren
    - Houd afhankelijkheden up-to-date om bekende beveiligingsproblemen aan te pakken

11. **Content safety filtering**: Implementeer content safety-filters voor zowel invoer als uitvoer.
    - Gebruik Azure Content Safety of vergelijkbare diensten om schadelijke inhoud te detecteren
    - Pas prompt shield-technieken toe om promptinjectie te voorkomen
    - Scan gegenereerde content op mogelijke lekken van gevoelige data

12. **Supply chain security**: Verifieer de integriteit en authenticiteit van alle componenten in je AI-leveringsketen.
    - Gebruik ondertekende pakketten en controleer handtekeningen
    - Implementeer software bill of materials (SBOM)-analyse
    - Houd verdachte updates van afhankelijkheden in de gaten

13. **Bescherming van tooldefinities**: Voorkom tool poisoning door tooldefinities en metadata te beveiligen.
    - Valideer tooldefinities vóór gebruik
    - Houd onverwachte wijzigingen in toolmetadata in de gaten
    - Implementeer integriteitscontroles voor tooldefinities

14. **Dynamische uitvoeringsmonitoring**: Houd het runtime-gedrag van MCP-servers en tools in de gaten.
    - Implementeer gedragsanalyse om afwijkingen te detecteren
    - Stel waarschuwingen in voor onverwachte uitvoeringspatronen
    - Gebruik runtime application self-protection (RASP)-technieken

15. **Principe van minste privilege**: Zorg dat MCP-servers en tools alleen de minimaal benodigde rechten hebben.
    - Verleen alleen de specifieke permissies die nodig zijn voor elke handeling
    - Review en audit regelmatig het gebruik van permissies
    - Implementeer just-in-time toegang voor administratieve functies

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.