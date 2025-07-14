<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:43:17+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "hu"
}
-->
# Tanulási Terv Generátor Chainlit és Microsoft Learn Docs MCP segítségével

## Előfeltételek

- Python 3.8 vagy újabb
- pip (Python csomagkezelő)
- Internetkapcsolat a Microsoft Learn Docs MCP szerver eléréséhez

## Telepítés

1. Klónozd ezt a tárolót vagy töltsd le a projekt fájljait.
2. Telepítsd a szükséges függőségeket:

   ```bash
   pip install -r requirements.txt
   ```

## Használat

### 1. Forgatókönyv: Egyszerű lekérdezés a Docs MCP-hez
Egy parancssori kliens, amely kapcsolódik a Docs MCP szerverhez, elküldi a lekérdezést, és kiírja az eredményt.

1. Futtasd a szkriptet:
   ```bash
   python scenario1.py
   ```
2. Írd be a dokumentációs kérdésed a promptnál.

### 2. Forgatókönyv: Tanulási terv generátor (Chainlit webalkalmazás)
Egy webes felület (Chainlit használatával), amely lehetővé teszi, hogy személyre szabott, heti bontású tanulási tervet készíts bármilyen technikai témához.

1. Indítsd el a Chainlit alkalmazást:
   ```bash
   chainlit run scenario2.py
   ```
2. Nyisd meg a terminálban megjelenő helyi URL-t (pl. http://localhost:8000) a böngésződben.
3. A csevegőablakba írd be a tanulási témádat és a tanulni kívánt hetek számát (pl. „AI-900 tanúsítvány, 8 hét”).
4. Az alkalmazás válaszként egy heti bontású tanulási tervet ad, beleértve a kapcsolódó Microsoft Learn dokumentációs linkeket.

**Szükséges környezeti változók:**

A 2. forgatókönyv (Chainlit webalkalmazás Azure OpenAI-val) használatához a `python` könyvtárban létre kell hoznod egy `.env` fájlt, és be kell állítanod az alábbi környezeti változókat:

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Töltsd ki ezeket az értékeket az Azure OpenAI erőforrásod adataival, mielőtt elindítod az alkalmazást.

> **Tip:** Saját modellek egyszerű telepítéséhez használd az [Azure AI Foundry](https://ai.azure.com/) szolgáltatást.

### 3. Forgatókönyv: Dokumentáció szerkesztőben MCP szerverrel VS Code-ban

Ahelyett, hogy böngészőfüleket váltogatnál a dokumentáció kereséséhez, behozhatod a Microsoft Learn Docs-ot közvetlenül a VS Code szerkesztődbe az MCP szerver segítségével. Ez lehetővé teszi, hogy:
- Keresd és olvasd a dokumentációt a VS Code-ban anélkül, hogy elhagynád a fejlesztői környezetet.
- Hivatkozásokat illessz be közvetlenül a README vagy tananyag fájljaidba.
- Használd együtt a GitHub Copilotot és az MCP-t egy zökkenőmentes, AI-alapú dokumentációs munkafolyamathoz.

**Példák a használatra:**
- Gyorsan adj hozzá hivatkozásokat egy README-hez tananyag vagy projekt dokumentáció írása közben.
- Használd a Copilotot kód generálásra, és az MCP-t a releváns dokumentáció azonnali megtalálására és idézésére.
- Maradj fókuszban a szerkesztődben, és növeld a hatékonyságod.

> [!IMPORTANT]
> Győződj meg róla, hogy érvényes [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) konfiguráció van a munkaterületedben (helye: `.vscode/mcp.json`).

## Miért Chainlit a 2. forgatókönyvhöz?

A Chainlit egy modern, nyílt forráskódú keretrendszer beszélgetés-alapú webalkalmazások készítéséhez. Megkönnyíti chat alapú felhasználói felületek létrehozását, amelyek kapcsolódnak backend szolgáltatásokhoz, például a Microsoft Learn Docs MCP szerverhez. Ez a projekt a Chainlit-et használja, hogy egyszerű, interaktív módon generáljon személyre szabott tanulási terveket valós időben. A Chainlit segítségével gyorsan építhetsz és telepíthetsz chat alapú eszközöket, amelyek növelik a hatékonyságot és a tanulást.

## Mit csinál ez az alkalmazás?

Ez az alkalmazás lehetővé teszi, hogy a felhasználók egyszerűen megadják a témát és az időtartamot, majd személyre szabott tanulási tervet készítsenek. Az alkalmazás feldolgozza a bemenetet, lekérdezi a Microsoft Learn Docs MCP szervert a releváns tartalomért, és strukturált, heti bontású tervbe rendezi az eredményeket. Minden hét ajánlásai megjelennek a csevegésben, így könnyen követhető és nyomon követhető a haladás. Az integráció biztosítja, hogy mindig a legfrissebb és legrelevánsabb tanulási forrásokat kapd.

## Minta lekérdezések

Próbáld ki ezeket a lekérdezéseket a csevegőablakban, hogy lásd, hogyan válaszol az alkalmazás:

- `AI-900 tanúsítvány, 8 hét`
- `Azure Functions tanulása, 4 hét`
- `Azure DevOps, 6 hét`
- `Adatmérnökség Azure-on, 10 hét`
- `Microsoft biztonsági alapok, 5 hét`
- `Power Platform, 7 hét`
- `Azure AI szolgáltatások, 12 hét`
- `Felhőarchitektúra, 9 hét`

Ezek a példák bemutatják az alkalmazás rugalmasságát különböző tanulási célokhoz és időkeretekhez.

## Hivatkozások

- [Chainlit dokumentáció](https://docs.chainlit.io/)
- [MCP dokumentáció](https://github.com/MicrosoftDocs/mcp)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.