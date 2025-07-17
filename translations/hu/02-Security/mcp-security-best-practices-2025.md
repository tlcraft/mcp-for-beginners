<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T13:45:32+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "hu"
}
-->
# MCP Biztonsági Legjobb Gyakorlatok – 2025 júliusi frissítés

## Átfogó biztonsági legjobb gyakorlatok MCP megvalósításokhoz

MCP szerverek használata során kövesse az alábbi biztonsági legjobb gyakorlatokat, hogy megvédje adatait, infrastruktúráját és felhasználóit:

1. **Bemeneti érvényesítés**: Mindig ellenőrizze és tisztítsa meg a bemeneteket, hogy megelőzze az injekciós támadásokat és a zavart helyzeteket.
   - Szigorú érvényesítést alkalmazzon minden eszközparaméterre
   - Használjon sémavizsgálatot, hogy a kérések megfeleljenek a várt formátumnak
   - Szűrje ki a potenciálisan káros tartalmakat a feldolgozás előtt

2. **Hozzáférés-vezérlés**: Alkalmazzon megfelelő hitelesítést és jogosultságkezelést MCP szerverén finomhangolt engedélyekkel.
   - Használja az OAuth 2.0-t megbízható identitásszolgáltatókkal, például Microsoft Entra ID-vel
   - Valósítson meg szerepalapú hozzáférés-vezérlést (RBAC) az MCP eszközökhöz
   - Soha ne fejlesszen egyedi hitelesítést, ha léteznek bevált megoldások

3. **Biztonságos kommunikáció**: Minden kommunikációhoz az MCP szerverrel használjon HTTPS/TLS-t, és fontolja meg további titkosítás alkalmazását érzékeny adatok esetén.
   - Konfigurálja a TLS 1.3-at, ahol csak lehetséges
   - Alkalmazzon tanúsítvány-pinninget kritikus kapcsolatokhoz
   - Rendszeresen cserélje a tanúsítványokat és ellenőrizze azok érvényességét

4. **Korlátozás bevezetése**: Alkalmazzon lekérdezési korlátozásokat a visszaélések, DoS támadások megelőzésére és az erőforrások hatékony kezelésére.
   - Állítson be megfelelő lekérdezési határokat a várható használati minták alapján
   - Vezessen be fokozatos válaszokat a túlzott lekérdezésekre
   - Vegye figyelembe a felhasználói státusz szerinti korlátozásokat

5. **Naplózás és megfigyelés**: Figyelje MCP szerverét gyanús tevékenységek után, és valósítson meg átfogó auditnaplókat.
   - Naplózza az összes hitelesítési kísérletet és eszközhasználatot
   - Alkalmazzon valós idejű riasztásokat gyanús minták esetén
   - Biztosítsa, hogy a naplók biztonságosan tárolódjanak és ne lehessen azokat manipulálni

6. **Biztonságos tárolás**: Védeni kell az érzékeny adatokat és hitelesítő adatokat megfelelő titkosítással tárolás közben.
   - Használjon kulcstárolókat vagy biztonságos hitelesítő tárolókat minden titokhoz
   - Alkalmazzon mezőszintű titkosítást érzékeny adatokra
   - Rendszeresen cserélje a titkosítási kulcsokat és hitelesítő adatokat

7. **Token-kezelés**: Kerülje a token átengedési sebezhetőségeket az összes modellbemenet és -kimenet érvényesítésével és tisztításával.
   - Valósítson meg token-ellenőrzést az audience (célközönség) állítások alapján
   - Soha ne fogadjon el olyan tokeneket, amelyeket nem kifejezetten az MCP szerverének bocsátottak ki
   - Gondoskodjon a tokenek élettartamának megfelelő kezeléséről és cseréjéről

8. **Munkamenet-kezelés**: Biztosítson biztonságos munkamenet-kezelést a munkamenet eltérítés és rögzítés elleni védelemhez.
   - Használjon biztonságos, nem determinisztikus munkamenet-azonosítókat
   - Kösse a munkameneteket felhasználó-specifikus adatokhoz
   - Alkalmazzon megfelelő munkamenet lejáratot és cserét

9. **Eszközvégrehajtás izolálása**: Futtassa az eszközök végrehajtását elkülönített környezetekben, hogy megakadályozza a laterális mozgást kompromittálódás esetén.
   - Valósítson meg konténerizált izolációt az eszközvégrehajtáshoz
   - Alkalmazzon erőforrás-korlátozásokat az erőforrás-kimerülés elleni védelemhez
   - Használjon külön végrehajtási kontextusokat különböző biztonsági doménekhez

10. **Rendszeres biztonsági auditok**: Végezzen időszakos biztonsági felülvizsgálatokat MCP megvalósításain és függőségein.
    - Ütemezzen rendszeres penetrációs teszteket
    - Használjon automatizált szkennelő eszközöket a sebezhetőségek felderítésére
    - Tartsa naprakészen a függőségeket a ismert biztonsági problémák kezelése érdekében

11. **Tartalombiztonsági szűrés**: Alkalmazzon tartalombiztonsági szűrőket mind a bemenetekre, mind a kimenetekre.
    - Használja az Azure Content Safety vagy hasonló szolgáltatásokat káros tartalmak felismerésére
    - Valósítson meg promptvédelmi technikákat a prompt-injekció megelőzésére
    - Vizsgálja át a generált tartalmat esetleges érzékeny adat szivárgás miatt

12. **Ellátási lánc biztonság**: Ellenőrizze az AI ellátási lánc minden komponensének integritását és hitelességét.
    - Használjon aláírt csomagokat és ellenőrizze az aláírásokat
    - Valósítson meg szoftverösszetevő-lista (SBOM) elemzést
    - Figyelje a függőségek rosszindulatú frissítéseit

13. **Eszközdefiníció védelme**: Előzze meg az eszközmérgezést az eszközdefiníciók és metaadatok védelmével.
    - Érvényesítse az eszközdefiníciókat használat előtt
    - Figyelje az eszközmetaadatok váratlan változásait
    - Alkalmazzon integritásellenőrzéseket az eszközdefiníciókra

14. **Dinamikus végrehajtás megfigyelése**: Figyelje az MCP szerverek és eszközök futásidejű viselkedését.
    - Valósítson meg viselkedéselemzést anomáliák felismerésére
    - Állítson be riasztásokat váratlan végrehajtási minták esetén
    - Használjon futásidejű alkalmazás önvédelmi (RASP) technikákat

15. **Legkisebb jogosultság elve**: Biztosítsa, hogy az MCP szerverek és eszközök csak a szükséges minimális jogosultságokkal működjenek.
    - Csak az adott művelethez szükséges konkrét jogosultságokat adja meg
    - Rendszeresen vizsgálja felül és auditálja a jogosultságok használatát
    - Alkalmazzon just-in-time hozzáférést az adminisztratív funkciókhoz

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy téves értelmezésekért.