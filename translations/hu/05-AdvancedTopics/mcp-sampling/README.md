<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3cb0da3badd51d73ab78ebade2827d98",
  "translation_date": "2025-07-14T02:24:41+00:00",
  "source_file": "05-AdvancedTopics/mcp-sampling/README.md",
  "language_code": "hu"
}
-->
## Determinisztikus mintavételezés

Azoknál az alkalmazásoknál, ahol következetes eredményekre van szükség, a determinisztikus mintavételezés biztosítja az ismételhető kimeneteket. Ezt úgy éri el, hogy fix véletlenszám-generátort (seed) használ, és a hőmérsékletet nullára állítja.

Nézzük meg az alábbi példákat, amelyek bemutatják a determinisztikus mintavételezést különböző programozási nyelveken.

## Dinamikus mintavételi konfiguráció

Az intelligens mintavételezés a kontextus és a kérés igényei alapján állítja be a paramétereket. Ez azt jelenti, hogy dinamikusan módosítja a temperature, top_p és büntetőértékeket a feladat típusától, a felhasználói preferenciáktól vagy a korábbi teljesítménytől függően.

Nézzük meg, hogyan valósítható meg a dinamikus mintavételezés különböző programozási nyelveken.

## Mi következik

- [5.7 Skálázás](../mcp-scaling/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.