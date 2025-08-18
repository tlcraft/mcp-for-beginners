<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b2b9e15e78b9d9a2b3ff3e8fd7d1f434",
  "translation_date": "2025-08-18T19:27:43+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "hu"
}
-->
# MCP Biztonsági Legjobb Gyakorlatok 2025

Ez az átfogó útmutató bemutatja a Model Context Protocol (MCP) rendszerek megvalósításához szükséges alapvető biztonsági legjobb gyakorlatokat a legújabb **MCP Specifikáció 2025-06-18** és az aktuális iparági szabványok alapján. Ezek a gyakorlatok a hagyományos biztonsági aggályokat és az MCP telepítésekre jellemző AI-specifikus fenyegetéseket is kezelik.

## Kritikus Biztonsági Követelmények

### Kötelező Biztonsági Ellenőrzések (MUST Követelmények)

1. **Token Ellenőrzés**: Az MCP szerverek **NEM FOGADHATNAK EL** olyan tokeneket, amelyeket nem kifejezetten az adott MCP szerver számára bocsátottak ki.
2. **Engedélyezés Ellenőrzése**: Az engedélyezést megvalósító MCP szervereknek **MINDEN** bejövő kérést ellenőrizniük kell, és **NEM HASZNÁLHATNAK** munkameneteket hitelesítéshez.  
3. **Felhasználói Hozzájárulás**: Az MCP proxy szerverek, amelyek statikus kliensazonosítókat használnak, **KÖTELESEK** kifejezett felhasználói hozzájárulást kérni minden dinamikusan regisztrált klienshez.
4. **Biztonságos Munkamenet-azonosítók**: Az MCP szervereknek **KRIPTOGRÁFIAILAG BIZTONSÁGOS**, nem determinisztikus munkamenet-azonosítókat kell használniuk, amelyeket biztonságos véletlenszám-generátorokkal hoznak létre.

## Alapvető Biztonsági Gyakorlatok

### 1. Bemeneti Érvényesítés és Tisztítás
- **Átfogó Bemeneti Érvényesítés**: Érvényesítsen és tisztítson minden bemenetet, hogy megelőzze az injekciós támadásokat, a zavart helyettesítő problémákat és a prompt injekciós sebezhetőségeket.
- **Paraméter Sémák Betartása**: Valósítson meg szigorú JSON séma érvényesítést minden eszközparaméterre és API bemenetre.
- **Tartalomszűrés**: Használja a Microsoft Prompt Shields és az Azure Content Safety megoldásokat a rosszindulatú tartalmak szűrésére a promptokban és válaszokban.
- **Kimeneti Tisztítás**: Érvényesítse és tisztítsa meg az összes modellkimenetet, mielőtt azt a felhasználóknak vagy downstream rendszereknek bemutatná.

### 2. Hitelesítés és Engedélyezés Kiválósága  
- **Külső Identitásszolgáltatók**: Delegálja a hitelesítést bevált identitásszolgáltatóknak (Microsoft Entra ID, OAuth 2.1 szolgáltatók) ahelyett, hogy egyedi hitelesítést valósítana meg.
- **Finomhangolt Engedélyek**: Valósítson meg eszközspecifikus, finomhangolt engedélyeket a legkisebb jogosultság elve alapján.
- **Token Életciklus Kezelés**: Használjon rövid élettartamú hozzáférési tokeneket biztonságos forgatással és megfelelő célközönség-ellenőrzéssel.
- **Többtényezős Hitelesítés**: Követelje meg az MFA-t minden adminisztratív hozzáféréshez és érzékeny művelethez.

### 3. Biztonságos Kommunikációs Protokollok
- **Szállítási Réteg Biztonság**: Használjon HTTPS/TLS 1.3-at minden MCP kommunikációhoz megfelelő tanúsítvány-ellenőrzéssel.
- **Végpontok Közötti Titkosítás**: Valósítson meg további titkosítási rétegeket az érzékeny adatok átviteléhez és tárolásához.
- **Tanúsítványkezelés**: Tartsa fenn a tanúsítványok életciklus-kezelését automatizált megújítási folyamatokkal.
- **Protokoll Verzió Kényszerítése**: Használja az aktuális MCP protokoll verziót (2025-06-18) megfelelő verziótárgyalással.

### 4. Fejlett Sebességkorlátozás és Erőforrás Védelem
- **Többrétegű Sebességkorlátozás**: Valósítson meg sebességkorlátozást felhasználói, munkameneti, eszköz- és erőforrás-szinten a visszaélések megelőzése érdekében.
- **Adaptív Sebességkorlátozás**: Használjon gépi tanuláson alapuló sebességkorlátozást, amely alkalmazkodik a használati mintákhoz és fenyegetési mutatókhoz.
- **Erőforrás Kvóta Kezelés**: Állítson be megfelelő korlátokat a számítási erőforrásokra, memóriahasználatra és végrehajtási időre.
- **DDoS Védelem**: Telepítsen átfogó DDoS védelmi és forgalomelemző rendszereket.

### 5. Átfogó Naplózás és Felügyelet
- **Strukturált Audit Naplózás**: Valósítson meg részletes, kereshető naplókat minden MCP művelethez, eszközvégrehajtáshoz és biztonsági eseményhez.
- **Valós idejű Biztonsági Felügyelet**: Telepítsen SIEM rendszereket AI-alapú anomáliaérzékeléssel az MCP munkaterhelésekhez.
- **Adatvédelmi Megfelelőségű Naplózás**: Naplózza a biztonsági eseményeket az adatvédelmi követelmények és szabályozások betartásával.
- **Incidensreagálás Integráció**: Kösse össze a naplózási rendszereket automatizált incidensreagálási munkafolyamatokkal.

### 6. Fejlett Biztonságos Tárolási Gyakorlatok
- **Hardver Biztonsági Modulok**: Használjon HSM-alapú kulcstárolást (Azure Key Vault, AWS CloudHSM) kritikus kriptográfiai műveletekhez.
- **Titkosítási Kulcs Kezelés**: Valósítson meg megfelelő kulcsforgatást, szegregációt és hozzáférés-ellenőrzést a titkosítási kulcsokhoz.
- **Titkok Kezelése**: Tároljon minden API kulcsot, tokent és hitelesítő adatot dedikált titokkezelő rendszerekben.
- **Adatosztályozás**: Osztályozza az adatokat érzékenységi szintek alapján, és alkalmazzon megfelelő védelmi intézkedéseket.

### 7. Fejlett Token Kezelés
- **Token Átadás Megakadályozása**: Kifejezetten tiltsa meg azokat a tokenátadási mintákat, amelyek megkerülik a biztonsági ellenőrzéseket.
- **Célközönség Ellenőrzése**: Mindig ellenőrizze, hogy a token célközönség-állításai megfelelnek-e a szándékolt MCP szerver azonosítónak.
- **Állítás-alapú Engedélyezés**: Valósítson meg finomhangolt engedélyezést token állítások és felhasználói attribútumok alapján.
- **Token Kötés**: Kösse a tokeneket adott munkamenetekhez, felhasználókhoz vagy eszközökhöz, ahol szükséges.

### 8. Biztonságos Munkamenet Kezelés
- **Kriptográfiai Munkamenet-azonosítók**: Generáljon munkamenet-azonosítókat kriptográfiailag biztonságos véletlenszám-generátorokkal (nem előrejelezhető sorozatokkal).
- **Felhasználóspecifikus Kötés**: Kösse a munkamenet-azonosítókat felhasználóspecifikus információkhoz biztonságos formátumokkal, mint például `<user_id>:<session_id>`.
- **Munkamenet Életciklus Ellenőrzések**: Valósítson meg megfelelő munkamenet-lejáratot, forgatást és érvénytelenítési mechanizmusokat.
- **Munkamenet Biztonsági Fejlécek**: Használjon megfelelő HTTP biztonsági fejléceket a munkamenet védelméhez.

### 9. AI-specifikus Biztonsági Ellenőrzések
- **Prompt Injekció Védelem**: Telepítse a Microsoft Prompt Shields megoldást kiemelési, elválasztási és adatjelölési technikákkal.
- **Eszközmérgezés Megelőzése**: Érvényesítse az eszköz metaadatait, figyelje a dinamikus változásokat, és ellenőrizze az eszköz integritását.
- **Modellkimenet Érvényesítés**: Vizsgálja meg a modellkimeneteket az esetleges adatvesztés, káros tartalom vagy biztonsági szabályzat megsértése szempontjából.
- **Kontekstsáv Védelem**: Valósítson meg ellenőrzéseket a kontekstsáv mérgezésének és manipulációjának megelőzésére.

### 10. Eszközvégrehajtási Biztonság
- **Végrehajtási Homokozó**: Futtassa az eszközvégrehajtásokat konténerizált, izolált környezetekben erőforrás-korlátokkal.
- **Jogosultság Elkülönítés**: Hajtsa végre az eszközöket a minimálisan szükséges jogosultságokkal és külön szolgáltatásfiókokkal.
- **Hálózati Izoláció**: Valósítson meg hálózati szegmentációt az eszközvégrehajtási környezetekhez.
- **Végrehajtás Felügyelete**: Figyelje az eszközvégrehajtásokat anomáliás viselkedés, erőforrás-használat és biztonsági szabálysértések szempontjából.

### 11. Folyamatos Biztonsági Érvényesítés
- **Automatizált Biztonsági Tesztelés**: Integrálja a biztonsági tesztelést a CI/CD folyamatokba olyan eszközökkel, mint a GitHub Advanced Security.
- **Sérülékenység Kezelés**: Rendszeresen vizsgálja az összes függőséget, beleértve az AI modelleket és külső szolgáltatásokat.
- **Penetrációs Tesztelés**: Végezzen rendszeres biztonsági értékeléseket, amelyek kifejezetten az MCP megvalósításokat célozzák.
- **Biztonsági Kódellenőrzések**: Valósítson meg kötelező biztonsági ellenőrzéseket minden MCP-vel kapcsolatos kódváltoztatásra.

### 12. AI Ellátási Lánc Biztonsága
- **Komponens Ellenőrzés**: Ellenőrizze az összes AI komponens (modellek, beágyazások, API-k) származását, integritását és biztonságát.
- **Függőség Kezelés**: Tartson naprakész nyilvántartást az összes szoftver- és AI-függőségről sérülékenységkövetéssel.
- **Megbízható Tárolók**: Használjon ellenőrzött, megbízható forrásokat minden AI modellhez, könyvtárhoz és eszközhöz.
- **Ellátási Lánc Felügyelet**: Folyamatosan figyelje az AI szolgáltatók és modell-tárolók kompromittálódását.

## Fejlett Biztonsági Minták

### Zero Trust Architektúra MCP-hez
- **Soha Ne Bízz, Mindig Ellenőrizz**: Valósítson meg folyamatos ellenőrzést minden MCP résztvevő számára.
- **Mikroszegmentáció**: Izolálja az MCP komponenseket finomhangolt hálózati és identitás-ellenőrzésekkel.
- **Feltételes Hozzáférés**: Valósítson meg kockázatalapú hozzáférés-ellenőrzéseket, amelyek alkalmazkodnak a kontextushoz és viselkedéshez.
- **Folyamatos Kockázatértékelés**: Dinamikusan értékelje a biztonsági helyzetet az aktuális fenyegetési mutatók alapján.

### Adatvédelmet Megőrző AI Megvalósítás
- **Adatminimalizálás**: Csak a minimálisan szükséges adatokat tegye elérhetővé minden MCP művelethez.
- **Differenciális Adatvédelem**: Valósítson meg adatvédelmet biztosító technikákat az érzékeny adatok feldolgozásához.
- **Homomorf Titkosítás**: Használjon fejlett titkosítási technikákat a titkosított adatokon végzett biztonságos számításokhoz.
- **Federált Tanulás**: Valósítson meg elosztott tanulási megközelítéseket, amelyek megőrzik az adatok helyi kezelését és adatvédelmét.

### Incidensreagálás AI Rendszerekhez
- **AI-specifikus Incidens Eljárások**: Fejlesszen ki incidensreagálási eljárásokat, amelyek az AI és MCP-specifikus fenyegetésekre szabottak.
- **Automatizált Reagálás**: Valósítson meg automatizált elszigetelést és helyreállítást a gyakori AI biztonsági incidensekhez.  
- **Igazságügyi Képességek**: Tartsa fenn az igazságügyi készenlétet az AI rendszerek kompromittálódására és adatvesztésére.
- **Helyreállítási Eljárások**: Hozzon létre eljárásokat az AI modell mérgezéséből, prompt injekciós támadásokból és szolgáltatáskompromittálódásokból való helyreállításhoz.

## Megvalósítási Erőforrások és Szabványok

### Hivatalos MCP Dokumentáció
- [MCP Specifikáció 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) - Aktuális MCP protokoll specifikáció
- [MCP Biztonsági Legjobb Gyakorlatok](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) - Hivatalos biztonsági útmutató
- [MCP Engedélyezési Specifikáció](https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization) - Hitelesítési és engedélyezési minták
- [MCP Szállítási Biztonság](https://modelcontextprotocol.io/specification/2025-06-18/transports/) - Szállítási réteg biztonsági követelmények

### Microsoft Biztonsági Megoldások
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) - Fejlett prompt injekció védelem
- [Azure Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/) - Átfogó AI tartalomszűrés
- [Microsoft Entra ID](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow) - Vállalati identitás- és hozzáférés-kezelés
- [Azure Key Vault](https://learn.microsoft.com/azure/key-vault/general/basic-concepts) - Biztonságos titok- és hitelesítő adatkezelés
- [GitHub Advanced Security](https://github.com/security/advanced-security) - Ellátási lánc és kód biztonsági vizsgálat

### Biztonsági Szabványok és Keretrendszerek
- [OAuth 2.1 Biztonsági Legjobb Gyakorlatok](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-security-topics) - Aktuális OAuth biztonsági útmutató
- [OWASP Top 10](https://owasp.org/www-project-top-ten/) - Webalkalmazás biztonsági kockázatok
- [OWASP Top 10 LLM-ekhez](https://genai.owasp.org/download/43299/?tmstv=1731900559) - AI-specifikus biztonsági kockázatok
- [NIST AI Kockázatkezelési Keretrendszer](https://www.nist.gov/itl/ai-risk-management-framework) - Átfogó AI kockázatkezelés
- [ISO 27001:2022](
- **Eszközfejlesztés**: Biztonsági eszközök és könyvtárak fejlesztése és megosztása az MCP ökoszisztéma számára

---

*Ez a dokumentum az MCP biztonsági legjobb gyakorlatokat tükrözi 2025. augusztus 18-i állapot szerint, az MCP Specifikáció 2025-06-18 alapján. A biztonsági gyakorlatokat rendszeresen felül kell vizsgálni és frissíteni, ahogy a protokoll és a fenyegetési környezet változik.*

**Felelősségkizárás**:  
Ez a dokumentum az [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítási szolgáltatás segítségével készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális, emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.