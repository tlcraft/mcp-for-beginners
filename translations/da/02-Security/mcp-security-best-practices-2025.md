<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T08:52:33+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "da"
}
-->
# MCP Security Best Practices - Juli 2025 Opdatering

## Omfattende sikkerhedspraksis for MCP-implementeringer

Når du arbejder med MCP-servere, skal du følge disse sikkerhedspraksisser for at beskytte dine data, infrastruktur og brugere:

1. **Inputvalidering**: Valider og rens altid input for at forhindre injektionsangreb og confused deputy-problemer.  
   - Implementer streng validering for alle værktøjsparametre  
   - Brug skemavalidering for at sikre, at forespørgsler overholder forventede formater  
   - Filtrer potentielt skadeligt indhold før behandling  

2. **Adgangskontrol**: Implementer korrekt autentificering og autorisation for din MCP-server med detaljerede tilladelser.  
   - Brug OAuth 2.0 med etablerede identitetsudbydere som Microsoft Entra ID  
   - Implementer rollebaseret adgangskontrol (RBAC) for MCP-værktøjer  
   - Implementer aldrig brugerdefineret autentificering, når etablerede løsninger findes  

3. **Sikker kommunikation**: Brug HTTPS/TLS til al kommunikation med din MCP-server og overvej ekstra kryptering for følsomme data.  
   - Konfigurer TLS 1.3 hvor det er muligt  
   - Implementer certifikatpinning for kritiske forbindelser  
   - Udskift certifikater regelmæssigt og verificer deres gyldighed  

4. **Ratebegrænsning**: Implementer ratebegrænsning for at forhindre misbrug, DoS-angreb og styre ressourceforbrug.  
   - Sæt passende grænser for forespørgsler baseret på forventede brugsmønstre  
   - Implementer graduerede reaktioner på overdrevne forespørgsler  
   - Overvej bruger-specifikke ratebegrænsninger baseret på autentificeringsstatus  

5. **Logning og overvågning**: Overvåg din MCP-server for mistænkelig aktivitet og implementer omfattende revisionsspor.  
   - Log alle autentificeringsforsøg og værktøjskald  
   - Implementer realtidsalarmer for mistænkelige mønstre  
   - Sørg for, at logs opbevares sikkert og ikke kan manipuleres med  

6. **Sikker lagring**: Beskyt følsomme data og legitimationsoplysninger med korrekt kryptering i hvile.  
   - Brug key vaults eller sikre legitimationslagre til alle hemmeligheder  
   - Implementer felt-niveau kryptering for følsomme data  
   - Udskift krypteringsnøgler og legitimationsoplysninger regelmæssigt  

7. **Tokenhåndtering**: Forhindre token passthrough-sårbarheder ved at validere og rense alle modelinput og -output.  
   - Implementer tokenvalidering baseret på audience claims  
   - Accepter aldrig tokens, der ikke eksplicit er udstedt til din MCP-server  
   - Implementer korrekt tokenlevetidshåndtering og rotation  

8. **Sessionshåndtering**: Implementer sikker sessionhåndtering for at forhindre session hijacking og fixation-angreb.  
   - Brug sikre, ikke-deterministiske session-ID’er  
   - Bind sessioner til bruger-specifik information  
   - Implementer korrekt sessionudløb og rotation  

9. **Sandboxing af værktøjsudførelse**: Kør værktøjsudførelser i isolerede miljøer for at forhindre lateral bevægelse ved kompromittering.  
   - Implementer container-isolering for værktøjsudførelse  
   - Anvend ressourcebegrænsninger for at forhindre ressourceudtømningsangreb  
   - Brug separate eksekveringskontekster for forskellige sikkerhedsdomaener  

10. **Regelmæssige sikkerhedsrevisioner**: Gennemfør periodiske sikkerhedsvurderinger af dine MCP-implementeringer og afhængigheder.  
    - Planlæg regelmæssig penetrationstest  
    - Brug automatiserede scanningværktøjer til at opdage sårbarheder  
    - Hold afhængigheder opdaterede for at adressere kendte sikkerhedsproblemer  

11. **Indholdsfiltrering for sikkerhed**: Implementer indholdsfiltre for både input og output.  
    - Brug Azure Content Safety eller lignende tjenester til at opdage skadeligt indhold  
    - Implementer prompt shield-teknikker for at forhindre prompt injection  
    - Scan genereret indhold for potentielt læk af følsomme data  

12. **Supply Chain-sikkerhed**: Verificer integriteten og ægtheden af alle komponenter i din AI supply chain.  
    - Brug signerede pakker og verificer signaturer  
    - Implementer software bill of materials (SBOM) analyse  
    - Overvåg for ondsindede opdateringer til afhængigheder  

13. **Beskyttelse af værktøjsdefinitioner**: Forhindre værktøjsforgiftning ved at sikre værktøjsdefinitioner og metadata.  
    - Valider værktøjsdefinitioner før brug  
    - Overvåg for uventede ændringer i værktøjsmetadata  
    - Implementer integritetskontroller for værktøjsdefinitioner  

14. **Dynamisk eksekveringsovervågning**: Overvåg runtime-adfærd for MCP-servere og værktøjer.  
    - Implementer adfærdsanalyse for at opdage anomalier  
    - Opsæt alarmer for uventede eksekveringsmønstre  
    - Brug runtime application self-protection (RASP) teknikker  

15. **Princip om mindst privilegium**: Sørg for, at MCP-servere og værktøjer kun har de nødvendige tilladelser.  
    - Tildel kun de specifikke tilladelser, der er nødvendige for hver operation  
    - Gennemgå og revider regelmæssigt tilladelsesbrug  
    - Implementer just-in-time adgang til administrative funktioner

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.