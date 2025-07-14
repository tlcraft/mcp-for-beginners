<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-07-14T02:32:37+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "hu"
}
-->
## Vertikális skálázás és erőforrás-optimalizálás

A vertikális skálázás arra összpontosít, hogy egyetlen MCP szerver példányt optimalizáljunk a hatékonyabb kéréskezelés érdekében. Ezt konfigurációk finomhangolásával, hatékony algoritmusok alkalmazásával és az erőforrások megfelelő kezelésével érhetjük el. Például beállíthatjuk a szálkészleteket, a kérés időkorlátokat és a memóriahatárokat a teljesítmény javítása érdekében.

Nézzünk egy példát arra, hogyan lehet optimalizálni egy MCP szervert vertikális skálázásra és erőforrás-kezelésre.

## Elosztott architektúra

Az elosztott architektúrák több MCP csomópont együttműködését jelentik a kérések kezelésére, az erőforrások megosztására és a redundancia biztosítására. Ez a megközelítés növeli a skálázhatóságot és a hibabiztosságot azáltal, hogy a csomópontok egy elosztott rendszeren keresztül kommunikálnak és koordinálódnak.

Nézzünk egy példát arra, hogyan valósítható meg egy elosztott MCP szerver architektúra Redis használatával a koordinációhoz.

## Mi következik

- [5.8 Biztonság](../mcp-security/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy téves értelmezésekért.