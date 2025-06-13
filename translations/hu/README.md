<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3b97186cd9162b9fe9b90261e63e32d",
  "translation_date": "2025-06-13T14:25:48+00:00",
  "source_file": "README.md",
  "language_code": "hu"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.hu.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Kövesd ezeket a lépéseket, hogy elkezdhess dolgozni ezekkel az erőforrásokkal:
1. **Forkold a tárolót**: Kattints ide [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Klónozd a tárolót**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Csatlakozz az Azure AI Foundry Discord szerveréhez, és ismerkedj meg szakértőkkel és fejlesztőtársaiddal**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Többnyelvű támogatás

#### GitHub Action segítségével támogatott (Automatizált és mindig naprakész)

# 🚀 Model Context Protocol (MCP) Tananyag Kezdőknek

## **Ismerd meg az MCP-t gyakorlati kódpéldákon keresztül C#, Java, JavaScript, Python és TypeScript nyelveken**

## 🧠 A Model Context Protocol tananyag áttekintése

A **Model Context Protocol (MCP)** egy élvonalbeli keretrendszer, amely az AI modellek és kliensalkalmazások közötti kommunikáció egységesítésére szolgál. Ez a nyílt forráskódú tananyag jól felépített tanulási útvonalat kínál, gyakorlati kódpéldákkal és valós alkalmazási esetekkel, népszerű programozási nyelveken, mint a C#, Java, JavaScript, TypeScript és Python.

Legyél akár AI fejlesztő, rendszermérnök vagy szoftvermérnök, ez az útmutató átfogó forrásként szolgál az MCP alapjainak és megvalósítási stratégiáinak elsajátításához.

## 🔗 Hivatalos MCP források

- 📘 [MCP Dokumentáció](https://modelcontextprotocol.io/) – Részletes oktatóanyagok és felhasználói útmutatók  
- 📜 [MCP Specifikáció](https://spec.modelcontextprotocol.io/) – Protokoll felépítése és technikai hivatkozások  
- 🧑‍💻 [MCP GitHub tárhely](https://github.com/modelcontextprotocol) – Nyílt forráskódú SDK-k, eszközök és kódminták  

## 🧭 Teljes MCP tananyag felépítése

| Fej. | Cím | Leírás | Link |
|--|--|--|--|
| 00 | **Bevezetés az MCP-be** | Áttekintés a Model Context Protocol-ról és jelentőségéről az AI folyamatokban, mit jelent az MCP, miért fontos a szabványosítás, valamint gyakorlati alkalmazások és előnyök | [Bevezetés](./00-Introduction/README.md) |
| 01 | **Alapfogalmak magyarázata** | Mélyebb betekintés az MCP alapfogalmaiba, beleértve a kliens-szerver architektúrát, a protokoll kulcselemeit és az üzenetküldési mintákat | [Alapfogalmak](./01-CoreConcepts/README.md) |
| 02 | **Biztonság az MCP-ben** | Biztonsági fenyegetések az MCP-alapú rendszerekben, technikák és bevált gyakorlatok a biztonságos megvalósításhoz | [Biztonság](./02-Security/README.md) |
| 03 | **MCP használatának megkezdése** | Környezet beállítása és konfigurálása, egyszerű MCP szerverek és kliensek létrehozása, MCP integrálása meglévő alkalmazásokba | [Kezdő lépések](./03-GettingStarted/README.md) |
| 3.1 | **Első szerver** | Egyszerű szerver beállítása az MCP protokoll segítségével, a szerver-kliens interakció megértése és a szerver tesztelése | [Első szerver](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Első kliens** | Egyszerű kliens beállítása az MCP protokoll segítségével, a kliens-szerver interakció megértése és a kliens tesztelése | [Első kliens](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Kliens LLM-mel** | Kliens beállítása MCP protokollal egy Nagy Nyelvi Modell (LLM) használatával | [Kliens LLM-mel](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Szerver fogyasztása Visual Studio Code-dal** | Visual Studio Code beállítása MCP protokoll szerverek használatához | [Szerver fogyasztása Visual Studio Code-dal](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Szerver létrehozása SSE-vel** | Az SSE segítségével szervert tehetünk elérhetővé az interneten. Ez a rész segít SSE-vel szervert létrehozni | [Szerver létrehozása SSE-vel](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP streaming** | Tanuld meg, hogyan valósítható meg a HTTP streaming a valós idejű adatátvitelhez kliensek és MCP szerverek között | [HTTP streaming](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **AI Toolkit használata** | Az AI toolkit nagyszerű eszköz az AI és MCP munkafolyamatok kezeléséhez | [AI Toolkit használata](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Szerver tesztelése** | A tesztelés a fejlesztési folyamat fontos része. Ez a rész több különböző eszköz használatával segít a tesztelésben | [Szerver tesztelése](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Szerver telepítése** | Hogyan juthatsz el a helyi fejlesztéstől a termelési környezetig? Ez a rész segít a szerver fejlesztésében és telepítésében | [Szerver telepítése](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Gyakorlati megvalósítás** | SDK-k használata különböző nyelveken, hibakeresés, tesztelés és validálás, újrahasználható prompt sablonok és munkafolyamatok készítése | [Gyakorlati megvalósítás](./04-PracticalImplementation/README.md) |
| 05 | **Haladó témák az MCP-ben** | Többmodalitású AI munkafolyamatok és bővíthetőség, biztonságos skálázási stratégiák, MCP vállalati környezetben | [Haladó témák](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP integráció Azure-rel** | Bemutatja az Azure-rel való integrációt | [MCP Azure integráció](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Többmodalitás** | Bemutatja, hogyan lehet különböző modalitásokkal, például képekkel dolgozni | [Többmodalitás](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 demó** | Minimális Spring Boot alkalmazás az MCP OAuth2 használatával, mint Authorization és Resource Server. Biztonságos token kibocsátást, védett végpontokat, Azure Container Apps telepítést és API Management integrációt mutat be | [MCP OAuth2 demó](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | További ismeretek a root context-ről és megvalósításukról | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Különböző routing típusok megismerése | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | A sampling használatának megismerése | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skálázás** | MCP szerverek skálázásának megértése, beleértve a horizontális és vertikális skálázási stratégiákat, erőforrás-optimalizálást és teljesítményhangolást | [Skálázás](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Biztonság** | MCP szerver biztonságos működtetése, beleértve hitelesítést, jogosultságkezelést és adatvédelmi stratégiákat | [Biztonság](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP szerver és kliens integrálva a SerpAPI-val valós idejű webes, hírek, termékkereséshez és kérdés-válasz funkciókhoz. Többeszközös összehangolást, külső API integrációt és megbízható hibakezelést mutat be | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Valós idejű streaming** | A valós idejű adatstreaming elengedhetetlen napjaink adatközpontú világában, ahol a vállalatoknak és alkalmazásoknak azonnali információ-hozzáférésre van szükségük a gyors döntéshozatalhoz | [Valós idejű streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Valós idejű webes keresés** | Hogyan alakítja át az MCP a valós idejű webes keresést azáltal, hogy egységesített megközelítést kínál a kontextuskezeléshez AI modellek, keresőmotorok és alkalmazások között | [Valós idejű webes keresés](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Közösségi hozzájárulások** | Kód és dokumentáció hozzájárulása, együttműködés GitHub-on keresztül, közösségi fejlesztések és visszajelzések | [Közösségi hozzájárulások](./06-CommunityContributions/README.md) |
| 07 | **Korai alkalmazásból származó betekintések** | Valós implementációk és bevált megoldások, MCP-alapú megoldások építése és telepítése, trendek és jövőbeli útiterv | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **MCP legjobb gyakorlatai** | Teljesítményhangolás és optimalizálás, hibabiztos MCP rendszerek tervezése, tesztelési és ellenállóképességi stratégiák | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP esettanulmányok** | Mélyreható elemzések MCP megoldásarchitektúrákról, telepítési minták és integrációs tippek, magyarázott ábrák és projektbemutatók | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **AI munkafolyamatok egyszerűsítése: MCP szerver építése AI Toolkit segítségével** | Átfogó, gyakorlati workshop, amely ötvözi az MCP-t a Microsoft AI Toolkitjével VS Code-hoz. Tanulj meg intelligens alkalmazásokat építeni, amelyek AI modelleket kötnek össze valós eszközökkel gyakorlati modulokon keresztül, lefedve az alapokat, egyedi szerverfejlesztést és éles telepítési stratégiákat. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Minta projektek

### 🧮 MCP kalkulátor minta projektek:
<details>
  <summary><strong>Kódmegvalósítások felfedezése nyelvenként</strong></summary>

  - [C# MCP szerver példa](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP kalkulátor](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP demó](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP szerver](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP példa](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP haladó kalkulátor projektek:
<details>
  <summary><strong>Haladó minták felfedezése</strong></summary>

  - [Haladó C# minta](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java konténeralkalmazás példa](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript haladó minta](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python összetett megvalósítás](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript konténer minta](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 Előfeltételek az MCP tanulásához

Ahhoz, hogy a legtöbbet hozd ki ebből a tananyagból, érdemes, ha rendelkezel:

- Alapvető ismeretek C#, Java vagy Python nyelvből  
- Ügyfél-szerver modell és API-k ismerete  
- (Opcionális) Gépi tanulás alapfogalmainak ismerete  

## 📚 Tanulmányi útmutató

Egy átfogó [Tanulmányi útmutató](./study_guide.md) áll rendelkezésre, amely segít hatékonyan eligazodni ebben a tárházban. Az útmutató tartalmazza:

- Vizualizált tantervtérképet az összes témakörrel  
- Részletes bontást a tárház egyes részeiről  
- Útmutatót a minta projektek használatához  
- Ajánlott tanulási útvonalakat különböző szintű tanulóknak  
- További forrásokat a tanulási folyamat kiegészítéséhez  

## 🛠️ Hogyan használd hatékonyan ezt a tananyagot

Minden lecke tartalmaz:

1. Egyértelmű magyarázatokat az MCP fogalmakról  
2. Élő kódpéldákat több nyelven  
3. Gyakorlatokat valós MCP alkalmazások építéséhez  
4. Kiegészítő forrásokat haladó tanulók számára  

## 📜 Licenc információk

A tartalom az **MIT License** alatt érhető el. A feltételekért lásd a [LICENSE](../../LICENSE) fájlt.

## 🤝 Hozzájárulási irányelvek

Ez a projekt szívesen fogad hozzájárulásokat és javaslatokat. A legtöbb hozzájáruláshoz szükséges, hogy elfogadd a Contributor License Agreement (CLA) feltételeit, amelyben kijelented, hogy jogosult vagy és ténylegesen engedélyezed számunkra a hozzájárulásod felhasználását. Részletekért látogass el a <https://cla.opensource.microsoft.com> oldalra.

Amikor pull request-et nyújtasz be, egy CLA bot automatikusan megállapítja, hogy szükséges-e CLA-t benyújtanod, és ennek megfelelően jelöli a PR-t (pl. állapotellenőrzés, komment). Csak kövesd a bot utasításait. Ezt egyszer kell elvégezned az összes CLA-t használó tárházban.

Ez a projekt elfogadta a [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/) irányelveit. További információkért lásd a [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) oldalt, vagy írj az [opencode@microsoft.com](mailto:opencode@microsoft.com) címre kérdéseiddel, észrevételeiddel.

## 🎒 Egyéb tanfolyamok
Csapatunk más tanfolyamokat is készít! Nézd meg:

- [AI Agents For Beginners](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)  
- [Generative AI for Beginners using .NET](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)  
- [Generative AI for Beginners using JavaScript](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)  
- [Generative AI for Beginners](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)  
- [ML for Beginners](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)  
- [Data Science for Beginners](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)  
- [AI for Beginners](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)  
- [Cybersecurity for Beginners](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)  
- [Web Dev for Beginners](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)  
- [IoT for Beginners](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)  
- [XR Development for Beginners](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [GitHub Copilot mesteri szintű használata AI páros programozáshoz](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [GitHub Copilot mesteri szintű használata C#/.NET fejlesztőknek](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Válaszd ki a saját Copilot kalandodat](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Védjegy értesítés

Ez a projekt tartalmazhat védjegyeket vagy logókat projektekhez, termékekhez vagy szolgáltatásokhoz. A Microsoft védjegyek vagy logók engedélyezett használata a
[Microsoft védjegy- és márka irányelveinek](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general) betartása mellett történhet.
A Microsoft védjegyek vagy logók módosított verziókban való használata nem okozhat félreértést, és nem sugallhat Microsoft támogatást.
Bármely harmadik fél védjegyeinek vagy logóinak használata az adott harmadik fél szabályzatai szerint történik.

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum anyanyelvű változata tekintendő hiteles forrásnak. Fontos információk esetén professzionális, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.