<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T13:38:40+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "hu"
}
-->
# Legújabb MCP Biztonsági Intézkedések – 2025. júliusi frissítés

Ahogy a Model Context Protocol (MCP) folyamatosan fejlődik, a biztonság továbbra is kiemelt szempont. Ez a dokumentum ismerteti a legfrissebb biztonsági intézkedéseket és legjobb gyakorlatokat az MCP biztonságos megvalósításához 2025 júliusától.

## Hitelesítés és jogosultságkezelés

### OAuth 2.0 delegálási támogatás

Az MCP specifikáció legutóbbi frissítései lehetővé teszik, hogy az MCP szerverek a felhasználói hitelesítést külső szolgáltatásokra, például a Microsoft Entra ID-re bízzák. Ez jelentősen javítja a biztonsági helyzetet az alábbiak révén:

1. **Egyedi hitelesítési megoldások elkerülése**: Csökkenti az egyedi hitelesítési kód hibáinak kockázatát  
2. **Megbízható identitásszolgáltatók kihasználása**: Vállalati szintű biztonsági funkciók előnyei  
3. **Identitáskezelés központosítása**: Egyszerűsíti a felhasználói életciklus és hozzáférés-kezelést  

## Token továbbításának megakadályozása

Az MCP Authorization Specification kifejezetten tiltja a tokenek továbbítását, hogy megelőzze a biztonsági intézkedések megkerülését és az elszámoltathatósági problémákat.

### Fő követelmények

1. **Az MCP szerverek NEM fogadhatnak el olyan tokeneket, amelyeket nem nekik bocsátottak ki**: Ellenőrizni kell, hogy minden token megfelelő audience (célközönség) mezővel rendelkezzen  
2. **Megfelelő token-ellenőrzés végrehajtása**: Ellenőrizni kell a kibocsátót, a célközönséget, a lejárati időt és az aláírást  
3. **Külön token kibocsátás alkalmazása**: Új tokeneket kell kiadni a downstream szolgáltatások számára, a meglévő tokenek továbbítása helyett  

## Biztonságos munkamenet-kezelés

A munkamenet eltérítés és rögzítés elleni védelem érdekében az alábbi intézkedéseket kell alkalmazni:

1. **Biztonságos, nem determinisztikus munkamenet-azonosítók használata**: Kriptográfiailag biztonságos véletlenszám-generátorral előállítva  
2. **Munkamenetek kötése a felhasználói identitáshoz**: A munkamenet-azonosítókat felhasználóspecifikus adatokkal kombinálva  
3. **Megfelelő munkamenet-rotáció végrehajtása**: Hitelesítés változásakor vagy jogosultság-emeléskor  
4. **Megfelelő munkamenet-időtúllépések beállítása**: Biztonság és felhasználói élmény egyensúlyának megtartása  

## Eszközök futtatásának sandboxolása

Az oldalirányú mozgás megakadályozása és a potenciális kompromittálódás korlátozása érdekében:

1. **Eszközök futtatási környezetének izolálása**: Konténerek vagy külön folyamatok használata  
2. **Erőforrás-korlátozások alkalmazása**: Erőforrás-kimerülési támadások megelőzése  
3. **Legkisebb jogosultság elve szerinti hozzáférés biztosítása**: Csak a szükséges engedélyek megadása  
4. **Futtatási minták monitorozása**: Anomáliák észlelése  

## Eszközdefiníciók védelme

Az eszközök megfertőzésének megelőzése érdekében:

1. **Eszközdefiníciók ellenőrzése használat előtt**: Rosszindulatú utasítások vagy nem megfelelő minták keresése  
2. **Integritás-ellenőrzés alkalmazása**: Eszközdefiníciók hash-elése vagy aláírása az illetéktelen módosítások felismerésére  
3. **Változásfigyelés bevezetése**: Figyelmeztetés váratlan módosítások esetén az eszköz metaadataiban  
4. **Eszközdefiníciók verziókezelése**: Változások nyomon követése és szükség esetén visszaállítás lehetősége  

Ezek az intézkedések együtt erős biztonsági alapot teremtenek az MCP megvalósítások számára, kezelve az AI-alapú rendszerek egyedi kihívásait, miközben megőrzik a hagyományos biztonsági gyakorlatok szilárdságát.

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.