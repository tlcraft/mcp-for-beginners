<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9730a53698bf9df8166d0080a8d5b61f",
  "translation_date": "2025-06-02T19:57:38+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "hu"
}
-->
## Függőleges skálázás és erőforrás-optimalizálás

A függőleges skálázás arra összpontosít, hogy egyetlen MCP szerver példányt optimalizáljunk a hatékonyabb kéréskezelés érdekében. Ezt konfigurációk finomhangolásával, hatékony algoritmusok alkalmazásával és az erőforrások megfelelő kezelésével érhetjük el. Például beállíthatjuk a szálkészleteket, a kérés-időtúllépéseket és a memóriahatárokat a teljesítmény javítása érdekében.

Nézzünk egy példát arra, hogyan lehet egy MCP szervert optimalizálni függőleges skálázás és erőforrás-kezelés céljából.

## Elosztott architektúra

Az elosztott architektúrák több MCP csomópont együttműködését jelentik a kérések kezelésére, az erőforrások megosztására és a redundancia biztosítására. Ez a megközelítés javítja a skálázhatóságot és a hibabiztosságot azáltal, hogy a csomópontok egy elosztott rendszeren keresztül kommunikálnak és koordinálódnak.

Nézzünk egy példát arra, hogyan valósítható meg egy elosztott MCP szerver architektúra Redis használatával a koordinációhoz.

## Mi következik

- [Biztonság](../mcp-security/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár az pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hivatalos forrásnak. Fontos információk esetén szakmai, emberi fordítást javasolunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félreértelmezésekért.