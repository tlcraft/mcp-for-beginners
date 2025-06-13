<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-06-13T00:54:16+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "hu"
}
-->
## Függőleges skálázás és erőforrás-optimalizálás

A függőleges skálázás egyetlen MCP szerver példányának optimalizálására összpontosít, hogy hatékonyabban tudjon több kérést kezelni. Ezt finomhangolással, hatékony algoritmusok használatával és az erőforrások hatékony kezelésével érhetjük el. Például beállíthatjuk a szálmedencéket, a kérés időkorlátokat és a memóriahatárokat a teljesítmény javítása érdekében.

Nézzünk egy példát arra, hogyan optimalizálhatunk egy MCP szervert függőleges skálázásra és erőforrás-kezelésre.

## Elosztott architektúra

Az elosztott architektúrák több MCP csomópont együttműködését jelentik a kérések kezelésére, az erőforrások megosztására és a redundancia biztosítására. Ez a megközelítés növeli a skálázhatóságot és a hibabiztosságot azáltal, hogy a csomópontok egy elosztott rendszer keretében kommunikálnak és koordinálnak.

Nézzünk egy példát arra, hogyan valósítható meg egy elosztott MCP szerver architektúra Redis használatával a koordinációhoz.

## Mi következik

- [5.8 Biztonság](../mcp-security/README.md)

**Nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum anyanyelvű változata tekintendő hiteles forrásnak. Fontos információk esetén szakmai emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.