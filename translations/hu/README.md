<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c7fbf0cdaa44b3245daff0c8bb4f439e",
  "translation_date": "2025-06-11T16:13:32+00:00",
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


Kövesd ezeket a lépéseket, hogy elkezdd használni ezeket az erőforrásokat:
1. **Forkold le a tárolót**: Kattints ide [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Klónozd a tárolót**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Csatlakozz az Azure AI Foundry Discord szerverhez, és ismerkedj meg szakértőkkel és fejlesztőtársakkal**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Többnyelvű támogatás

#### GitHub Action segítségével támogatott (Automatizált és mindig naprakész)

# 🚀 Model Context Protocol (MCP) Tananyag Kezdőknek

## **Tanulj MCP-t gyakorlati kódpéldákkal C#, Java, JavaScript, Python és TypeScript nyelveken**

## 🧠 A Model Context Protocol tananyag áttekintése

A **Model Context Protocol (MCP)** egy korszerű keretrendszer, amely az AI modellek és kliensalkalmazások közötti kommunikáció szabványosítására szolgál. Ez a nyílt forráskódú tananyag egy jól felépített tanulási útvonalat kínál, gyakorlati kódpéldákkal és valós használati esetekkel, népszerű programozási nyelveken, mint a C#, Java, JavaScript, TypeScript és Python.

Akár AI fejlesztő, rendszertervező vagy szoftvermérnök vagy, ez az útmutató átfogó forrás a MCP alapjainak és megvalósítási stratégiáinak elsajátításához.

## 🔗 Hivatalos MCP források

- 📘 [MCP Dokumentáció](https://modelcontextprotocol.io/) – Részletes oktatóanyagok és felhasználói kézikönyvek  
- 📜 [MCP Specifikáció](https://spec.modelcontextprotocol.io/) – Protokoll architektúra és technikai hivatkozások  
- 🧑‍💻 [MCP GitHub tárhely](https://github.com/modelcontextprotocol) – Nyílt forráskódú SDK-k, eszközök és kódminták  

## 🧭 Teljes MCP tananyag felépítése

| Fej. | Cím | Leírás | Link |
|--|--|--|--|
| 00 | **Bevezetés az MCP-be** | Áttekintés a Model Context Protocolról és jelentőségéről az AI folyamatokban, beleértve mi az MCP, miért fontos a szabványosítás, valamint gyakorlati példák és előnyök | [Bevezetés](./00-Introduction/README.md) |
| 01 | **Alapfogalmak magyarázata** | Mélyebb betekintés az MCP alapfogalmaiba, beleértve a kliens-szerver architektúrát, a protokoll főbb elemeit és üzenetküldési mintákat | [Alapfogalmak](./01-CoreConcepts/README.md) |
| 02 | **Biztonság az MCP-ben** | Biztonsági fenyegetések az MCP-alapú rendszerekben, technikák és bevált gyakorlatok a biztonságos megvalósításhoz | [Biztonság](./02-Security/README.md) |
| 03 | **MCP használatának megkezdése** | Környezet beállítása és konfigurálása, alap MCP szerverek és kliensek létrehozása, MCP integrálása meglévő alkalmazásokkal | [Kezdő lépések](./03-GettingStarted/README.md) |
| 3.1 | **Első szerver** | Egyszerű szerver beállítása az MCP protokollal, a szerver-kliens interakció megértése és a szerver tesztelése | [Első szerver](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Első kliens** | Egyszerű kliens beállítása az MCP protokollal, a kliens-szerver interakció megértése és a kliens tesztelése | [Első kliens](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Kliens LLM-mel** | Kliens beállítása MCP protokollal egy Nagy Nyelvi Modell (LLM) használatával | [Kliens LLM-mel](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Szerver használata Visual Studio Code-dal** | Visual Studio Code beállítása MCP protokollal kommunikáló szerverek használatához | [Szerver használata VS Code-dal](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Szerver létrehozása SSE-vel** | Az SSE segítségével a szerver az internet felé nyitható. Ebben a részben egy SSE alapú szerver létrehozását tanulhatod meg | [SSE szerver létrehozása](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **AI Toolkit használata** | Az AI Toolkit nagyszerű eszköz az AI és MCP munkafolyamatok kezelésére | [AI Toolkit használata](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Szerver tesztelése** | A tesztelés a fejlesztési folyamat fontos része. Ebben a részben többféle eszköz segítségével tesztelhetsz | [Szerver tesztelése](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Szerver telepítése** | Hogyan juthatsz el a helyi fejlesztéstől a termelési környezetig? Ebben a részben a szerver fejlesztését és telepítését tanulhatod meg | [Szerver telepítése](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Gyakorlati megvalósítás** | SDK-k használata különböző nyelveken, hibakeresés, tesztelés és validálás, újrahasznosítható prompt sablonok és munkafolyamatok készítése | [Gyakorlati megvalósítás](./04-PracticalImplementation/README.md) |
| 05 | **Haladó témák az MCP-ben** | Többmodalitású AI munkafolyamatok és bővíthetőség, biztonságos skálázási stratégiák, MCP vállalati ökoszisztémákban | [Haladó témák](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP integráció Azure-rel** | Az Azure-rel való integráció bemutatása | [MCP Azure integráció](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Többmodalitás** | Különböző modalitások, például képek és egyéb formátumok kezelése | [Többmodalitás](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 demó** | Minimális Spring Boot alkalmazás az MCP OAuth2 használatával, mint Authorization és Resource Server. Biztonságos token kibocsátás, védett végpontok, Azure Container Apps telepítés és API Management integráció bemutatása | [MCP OAuth2 demó](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Context-ek** | Mélyebb ismeretek a root context-ről és annak megvalósításáról | [Root Context-ek](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Különböző routing típusok megismerése | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Mintavételezéssel kapcsolatos ismeretek | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skálázás** | MCP szerverek skálázása, beleértve a horizontális és vertikális skálázási stratégiákat, erőforrás-optimalizálást és teljesítményhangolást | [Skálázás](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Biztonság** | MCP szerver biztonságos működtetése, beleértve hitelesítést, jogosultságkezelést és adatvédelmi stratégiákat | [Biztonság](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP szerver és kliens, amely integrál a SerpAPI-val valós idejű web-, hírek-, termékkeresés és kérdés-válasz funkciókhoz. Többeszközös összehangolás, külső API integráció és robusztus hibakezelés bemutatása | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Valós idejű adatfolyam** | A valós idejű adatfolyam kulcsfontosságú napjaink adatvezérelt világában, ahol az üzletek és alkalmazások azonnali információhozzáférést igényelnek a gyors döntéshozatalhoz | [Valós idejű adatfolyam](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 06 | **Közösségi hozzájárulások** | Kód és dokumentáció hozzájárulás, együttműködés GitHubon keresztül, közösség által vezérelt fejlesztések és visszajelzések | [Közösségi hozzájárulások](./06-CommunityContributions/README.md) |
| 07 | **Tapasztalatok a korai alkalmazásból** | Valós megvalósítások és eredmények, MCP-alapú megoldások építése és telepítése, trendek és jövőbeli útiterv | [Tapasztalatok](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **MCP legjobb gyakorlatai** | Teljesítményhangolás és optimalizálás, hibabiztos MCP rendszerek tervezése, tesztelési és ellenállóképességi stratégiák | [Legjobb gyakorlatok](./08-BestPractices/README.md) |
| 09 | **MCP Esettanulmányok** | Mélyreható elemzések az MCP megoldásarchitektúrákról, telepítési tervekről és integrációs tippekről, jegyzetelt ábrákkal és projektbemutatókkal | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **AI munkafolyamatok egyszerűsítése: MCP szerver építése AI Toolkit segítségével** | Átfogó, gyakorlati workshop, amely az MCP-t a Microsoft AI Toolkitjével kombinálja a VS Code-hoz. Tanulj meg intelligens alkalmazásokat építeni, amelyek összekapcsolják az AI modelleket a valós eszközökkel, gyakorlati modulokon keresztül, amelyek lefedik az alapokat, egyedi szerverfejlesztést és éles telepítési stratégiákat. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Minta projektek

### 🧮 MCP Számológép mintaprojektek:
<details>
  <summary><strong>Kódmegvalósítások nyelvek szerint</strong></summary>

  - [C# MCP Server példa](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Számológép](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP példa](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP Haladó számológép projektek:
<details>
  <summary><strong>Haladó minták felfedezése</strong></summary>

  - [Haladó C# minta](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java konténer alkalmazás példa](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript haladó minta](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python összetett megvalósítás](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript konténer minta](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 Az MCP tanulás előfeltételei

Ahhoz, hogy a legtöbbet hozd ki ebből a tananyagból, érdemes rendelkezned:

- Alapvető ismeretek C#, Java vagy Python nyelvből
- A kliens-szerver modell és az API-k megértése
- (Opcionális) Gépi tanulási alapfogalmak ismerete

## 📚 Tanulási útmutató

Elérhető egy átfogó [Tanulási útmutató](./study_guide.md), amely segít hatékonyan eligazodni ebben a tárházban. Az útmutató tartalmazza:

- Egy vizuális tantervtérképet az összes témával
- Részletes bontást a tárház egyes részeiről
- Útmutatót a minta projektek használatához
- Ajánlott tanulási útvonalakat különböző szintű tanulóknak
- Kiegészítő forrásokat a tanulási folyamat támogatásához

## 🛠️ Hogyan használd hatékonyan ezt a tananyagot

Minden leckében megtalálod:

1. Az MCP fogalmak világos magyarázatát  
2. Élő kódpéldákat több nyelven  
3. Gyakorlatokat valós MCP alkalmazások építéséhez  
4. További forrásokat haladó tanulók számára  

## 📜 Licenc információ

Ez a tartalom az **MIT License** alatt áll. A feltételekért lásd a [LICENSE](../../LICENSE) fájlt.

## 🤝 Hozzájárulási irányelvek

Ez a projekt szívesen fogad hozzájárulásokat és javaslatokat. A legtöbb hozzájárulás esetén el kell fogadnod egy Contributor License Agreement-et (CLA), amely igazolja, hogy jogod van a hozzájárulásod felhasználására, és valóban átadod nekünk ezeket a jogokat. Részletekért látogass el ide: <https://cla.opensource.microsoft.com>.

Amikor pull request-et küldesz, egy CLA bot automatikusan megállapítja, hogy szükséges-e CLA-t benyújtanod, és ennek megfelelően jelöli a PR-t (például státuszellenőrzéssel vagy megjegyzéssel). Egyszerűen kövesd a bot utasításait. Ezt csak egyszer kell megtenned minden CLA-t használó tárházban.

Ez a projekt a [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/) szabályzatát alkalmazza. További információkért lásd a [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) oldalt, vagy írj az [opencode@microsoft.com](mailto:opencode@microsoft.com) címre bármilyen kérdéssel vagy észrevétellel.

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
- [Mastering GitHub Copilot for AI Paired Programming](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Mastering GitHub Copilot for C#/.NET Developers](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Válaszd ki a saját Copilot kalandodat](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Védjegyértesítés

Ez a projekt tartalmazhat védjegyeket vagy logókat projektekhez, termékekhez vagy szolgáltatásokhoz. A Microsoft védjegyeinek vagy logóinak engedélyezett használata az alábbiak szerint történhet, és meg kell felelnie a
[Microsoft védjegy- és márka irányelveinek](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
A Microsoft védjegyek vagy logók használata a projekt módosított verzióiban nem okozhat félreértést, és nem sugallhat Microsoft támogatást.
Harmadik féltől származó védjegyek vagy logók használata a harmadik felek szabályzatai szerint történik.

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordítószolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hivatalos forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.