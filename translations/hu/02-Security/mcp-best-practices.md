<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T13:41:42+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "hu"
}
-->
# MCP Biztonsági Legjobb Gyakorlatok

MCP szerverek használata során kövesse az alábbi biztonsági legjobb gyakorlatokat, hogy megvédje adatait, infrastruktúráját és felhasználóit:

1. **Bemeneti Érvényesítés**: Mindig ellenőrizze és tisztítsa meg a bemeneteket, hogy megelőzze a befecskendezéses támadásokat és a zavart helyzeteket.
2. **Hozzáférés-vezérlés**: Alkalmazzon megfelelő hitelesítést és jogosultságkezelést az MCP szerverén, finomhangolt engedélyekkel.
3. **Biztonságos Kommunikáció**: Használjon HTTPS/TLS protokollt minden kommunikációhoz az MCP szerverrel, és fontolja meg további titkosítás alkalmazását érzékeny adatok esetén.
4. **Korlátozott Lekérések (Rate Limiting)**: Vezessen be lekéréskorlátozást a visszaélések, DoS támadások megelőzésére és az erőforrások hatékony kezelésére.
5. **Naplózás és Megfigyelés**: Figyelje MCP szerverét gyanús tevékenységek után, és valósítson meg átfogó audit naplókat.
6. **Biztonságos Tárolás**: Védeni kell az érzékeny adatokat és hitelesítő adatokat megfelelő titkosítással tárolás közben.
7. **Token Kezelés**: Kerülje el a token átengedési sebezhetőségeket az összes modellbemenet és -kimenet ellenőrzésével és tisztításával.
8. **Munkamenet-kezelés**: Biztosítsa a munkamenetek biztonságos kezelését, hogy megakadályozza a munkamenet eltérítést és rögzítést.
9. **Eszközvégrehajtás Homokozóban**: Futtassa az eszközök végrehajtását elkülönített környezetben, hogy megakadályozza az oldalirányú mozgást kompromittálódás esetén.
10. **Rendszeres Biztonsági Ellenőrzések**: Végezzen időszakos biztonsági felülvizsgálatokat MCP megvalósításain és függőségein.
11. **Prompt Érvényesítés**: Szűrje és ellenőrizze mind a bemeneti, mind a kimeneti promptokat, hogy megelőzze a prompt befecskendezéses támadásokat.
12. **Hitelesítés Delegálása**: Használjon bevált identitásszolgáltatókat a saját hitelesítés megvalósítása helyett.
13. **Jogosultságok Korlátozása**: Alkalmazzon részletes jogosultságkezelést minden eszközre és erőforrásra a legkisebb jogosultság elve alapján.
14. **Adatminimalizálás**: Csak a művelethez szükséges minimális adatot tegye elérhetővé a kockázati felület csökkentése érdekében.
15. **Automatizált Sebezhetőség-ellenőrzés**: Rendszeresen vizsgálja át MCP szervereit és függőségeit ismert sebezhetőségek után.

## Támogató Források az MCP Biztonsági Legjobb Gyakorlatokhoz

### Bemeneti Érvényesítés
- [OWASP Bemeneti Érvényesítés Gyorsreferencia](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Prompt Befecskendezés Megelőzése MCP-ben](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Tartalom Biztonság Megvalósítása](./azure-content-safety-implementation.md)

### Hozzáférés-vezérlés
- [MCP Jogosultságkezelési Specifikáció](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Microsoft Entra ID használata MCP szerverekkel](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management mint Auth Gateway MCP-hez](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Biztonságos Kommunikáció
- [Transport Layer Security (TLS) Legjobb Gyakorlatok](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Biztonsági Irányelvek](https://modelcontextprotocol.io/docs/concepts/transports)
- [Végpontok közötti titkosítás AI munkaterhelésekhez](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Korlátozott Lekérések (Rate Limiting)
- [API Lekéréskorlátozási Minták](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Token Bucket alapú lekéréskorlátozás megvalósítása](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Lekéréskorlátozás Azure API Management-ben](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Naplózás és Megfigyelés
- [Központosított naplózás AI rendszerekhez](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit naplózás legjobb gyakorlatai](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor AI munkaterhelésekhez](https://learn.microsoft.com/azure/azure-monitor/overview)

### Biztonságos Tárolás
- [Azure Key Vault hitelesítő adatok tárolásához](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Érzékeny adatok titkosítása tárolás közben](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Biztonságos token tárolás és tokenek titkosítása](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Token Kezelés
- [JWT Legjobb Gyakorlatok (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Biztonsági Legjobb Gyakorlatok (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Token érvényesítés és élettartam legjobb gyakorlatai](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Munkamenet-kezelés
- [OWASP Munkamenet-kezelési Gyorsreferencia](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP munkamenet-kezelési irányelvek](https://modelcontextprotocol.io/docs/guides/security)
- [Biztonságos munkamenet tervezési minták](https://learn.microsoft.com/security/engineering/session-security)

### Eszközvégrehajtás Homokozóban
- [Konténerbiztonsági legjobb gyakorlatok](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Folyamat izoláció megvalósítása](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Erőforrás-korlátozások konténerizált alkalmazásokhoz](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Rendszeres Biztonsági Ellenőrzések
- [Microsoft Biztonsági Fejlesztési Életciklus](https://www.microsoft.com/sdl)
- [OWASP Alkalmazásbiztonsági Ellenőrzési Szabvány](https://owasp.org/www-project-application-security-verification-standard/)
- [Biztonsági Kódellenőrzési Irányelvek](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Prompt Érvényesítés
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Tartalom Biztonság AI-hoz](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Prompt Befecskendezés Megelőzése](https://github.com/microsoft/prompt-shield-js)

### Hitelesítés Delegálása
- [Microsoft Entra ID Integráció](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 MCP szolgáltatásokhoz](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Biztonsági Kontrollok 2025](./mcp-security-controls-2025.md)

### Jogosultságok Korlátozása
- [Biztonságos, legkisebb jogosultság elve](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Szerepalapú hozzáférés-vezérlés (RBAC) tervezés](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Eszközspecifikus jogosultságkezelés MCP-ben](https://modelcontextprotocol.io/docs/guides/best-practices)

### Adatminimalizálás
- [Adatvédelem tervezés alapján](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI adatvédelmi legjobb gyakorlatok](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Adatvédelmet erősítő technológiák megvalósítása](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Automatizált Sebezhetőség-ellenőrzés
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline megvalósítása](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Folyamatos biztonsági ellenőrzés](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.