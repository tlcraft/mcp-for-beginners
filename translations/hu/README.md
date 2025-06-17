<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T16:06:11+00:00",
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


Kövesd az alábbi lépéseket, hogy elkezdhess dolgozni ezekkel az erőforrásokkal:
1. **Forkold a tárolót**: Kattints ide [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Klónozd a tárolót**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Csatlakozz az Azure AI Foundry Discord szerverhez, és ismerkedj meg szakértőkkel, valamint más fejlesztőkkel**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Többnyelvű támogatás

#### GitHub Action segítségével támogatott (automatikus és mindig naprakész)

# 🚀 Model Context Protocol (MCP) Tananyag Kezdőknek

## **Tanulj MCP-t gyakorlati kódpéldákkal C#, Java, JavaScript, Python és TypeScript nyelveken**

## 🧠 A Model Context Protocol Tananyag Áttekintése

A **Model Context Protocol (MCP)** egy élvonalbeli keretrendszer, amely az AI modellek és kliensalkalmazások közötti interakciók szabványosítására szolgál. Ez a nyílt forráskódú tananyag egy jól strukturált tanulási útvonalat kínál, gyakorlati kódpéldákkal és valós használati esetekkel, népszerű programozási nyelveken, mint a C#, Java, JavaScript, TypeScript és Python.

Akár AI fejlesztő, rendszerarchitekt vagy szoftvermérnök vagy, ez az útmutató átfogó forrásként szolgál az MCP alapjainak és megvalósítási stratégiáinak elsajátításához.

## 🔗 Hivatalos MCP Források

- 📘 [MCP Dokumentáció](https://modelcontextprotocol.io/) – Részletes oktatóanyagok és felhasználói útmutatók  
- 📜 [MCP Specifikáció](https://spec.modelcontextprotocol.io/) – A protokoll felépítése és technikai hivatkozások  
- 🧑‍💻 [MCP GitHub Tároló](https://github.com/modelcontextprotocol) – Nyílt forráskódú SDK-k, eszközök és kódminták  

## 🧭 Az MCP Teljes Tananyag Struktúrája

| Fej | Cím | Leírás | Link |
|--|--|--|--|
| 00 | **Bevezetés az MCP-be** | Áttekintés a Model Context Protocol-ról és annak jelentőségéről az AI folyamatokban, beleértve, hogy mi az MCP, miért fontos a szabványosítás, valamint gyakorlati használati esetek és előnyök | [Bevezetés](./00-Introduction/README.md) |
| 01 | **Alapfogalmak magyarázata** | Mélyreható bemutató az MCP alapfogalmairól, beleértve a kliens-szerver architektúrát, a protokoll kulcsfontosságú elemeit és az üzenetküldési mintákat | [Alapfogalmak](./01-CoreConcepts/README.md) |
| 02 | **Biztonság az MCP-ben** | Az MCP-alapú rendszerek biztonsági fenyegetéseinek azonosítása, technikák és bevált gyakorlatok a biztonságos megvalósításhoz | [Biztonság](./02-Security/README.md) |
| 03 | **MCP használatának megkezdése** | Környezet beállítása és konfigurálása, alap MCP szerverek és kliensek létrehozása, MCP integrálása meglévő alkalmazásokkal | [Első lépések](./03-GettingStarted/README.md) |
| 3.1 | **Első szerver** | Alap szerver beállítása az MCP protokoll segítségével, a szerver-kliens interakció megértése és a szerver tesztelése | [Első szerver](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Első kliens** | Alap kliens beállítása az MCP protokoll segítségével, a kliens-szerver interakció megértése és a kliens tesztelése | [Első kliens](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Kliens LLM-mel** | Kliens beállítása MCP protokollal egy Nagy Nyelvi Modell (LLM) használatával | [Kliens LLM-mel](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Szerver használata Visual Studio Code-dal** | Visual Studio Code beállítása MCP protokollal működő szerverek használatához | [Szerver használata Visual Studio Code-dal](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Szerver létrehozása SSE-vel** | Az SSE segít, hogy a szerver interneten elérhető legyen. Ez a rész segít SSE használatával szervert létrehozni | [Szerver létrehozása SSE-vel](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP Streaming** | Tanuld meg, hogyan valósítható meg a HTTP streaming valós idejű adatátvitelhez kliensek és MCP szerverek között | [HTTP Streaming](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **AI Toolkit használata** | Az AI toolkit nagyszerű eszköz az AI és MCP munkafolyamatok kezeléséhez | [AI Toolkit használata](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Szerver tesztelése** | A tesztelés fontos része a fejlesztési folyamatnak. Ez a rész több különböző eszköz használatával segít tesztelni | [Szerver tesztelése](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Szerver telepítése** | Hogyan juthatsz el a helyi fejlesztéstől a termelésig? Ez a rész segít a szerver fejlesztésében és telepítésében | [Szerver telepítése](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Gyakorlati megvalósítás** | SDK-k használata különböző nyelveken, hibakeresés, tesztelés és validálás, újrahasznosítható prompt sablonok és munkafolyamatok készítése | [Gyakorlati megvalósítás](./04-PracticalImplementation/README.md) |
| 05 | **Haladó témák az MCP-ben** | Többmodalitású AI munkafolyamatok és bővíthetőség, biztonságos skálázási stratégiák, MCP vállalati ökoszisztémákban | [Haladó témák](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP integráció Azure-rel** | Bemutatja az integrációt az Azure-rel | [MCP Azure integráció](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Többmodalitás** | Bemutatja, hogyan lehet különböző modalitásokkal, például képekkel dolgozni | [Többmodalitás](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 demó** | Minimális Spring Boot alkalmazás az MCP-vel OAuth2 használatával, mint Authorization és Resource Server. Bemutatja a biztonságos token kibocsátást, védett végpontokat, Azure Container Apps telepítést és API Management integrációt. | [MCP OAuth2 demó](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Tudj meg többet a root context-ről és annak megvalósításáról | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Ismerd meg a különböző routing típusokat | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Tanuld meg, hogyan kell samplinggel dolgozni | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skálázás** | Ismerd meg az MCP szerverek skálázását, beleértve a horizontális és vertikális skálázási stratégiákat, az erőforrás-optimalizálást és a teljesítményhangolást | [Skálázás](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Biztonság** | Biztonságossá teheted az MCP szerveredet, beleértve az autentikációt, autorizációt és az adatvédelmi stratégiákat | [Biztonság](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP szerver és kliens SerpAPI integrációval valós idejű webes, hírek, termék kereséshez és kérdés-válasz szolgáltatáshoz. Bemutatja a többeszközös koordinációt, külső API integrációt és robusztus hibakezelést | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Valós idejű streaming** | A valós idejű adatfolyam kulcsfontosságú napjaink adatvezérelt világában, ahol az üzletek és alkalmazások azonnali információhozzáférést igényelnek a gyors döntéshozatalhoz. | [Valós idejű streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Valós idejű webes keresés** | A valós idejű webes keresés, hogyan alakítja át az MCP a valós idejű keresést azáltal, hogy szabványosított megközelítést nyújt a kontextuskezeléshez AI modellek, keresőmotorok és alkalmazások között. | [Valós idejű webes keresés](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Közösségi hozzájárulások** | Hogyan járulhatsz hozzá kóddal és dokumentációval, együttműködés GitHubon keresztül, közösség által vezérelt fejlesztések és visszajelzések | [Közösségi hozzájárulások](./06-CommunityContributions/README.md) |
| 07 | **Korai elfogadásból származó tanulságok** | Valós megvalósítások és működő megoldások, MCP-alapú megoldások építése és telepítése, trendek és jövőbeli útiterv | [Tanulságok](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Legjobb gyakorlatok az MCP-hez** | Teljesítményhangolás és optimalizálás, hibamentes MCP-rendszerek tervezése, tesztelési és ellenállóképességi stratégiák | [Legjobb gyakorlatok](./08-BestPractices/README.md) |
| 09 | **MCP esettanulmányok** | Mélyreható elemzések MCP megoldásarchitektúrákról, telepítési tervrajzok és integrációs tippek, kommentált ábrák és projektbemutatók | [Esettanulmányok](./09-CaseStudy/README.md) |
| 10 | **AI munkafolyamatok egyszerűsítése: MCP szerver építése AI Toolkit segítségével** | Átfogó, gyakorlati workshop, amely az MCP-t a Microsoft AI Toolkitjével kombinálja VS Code-hoz. Tanulj meg intelligens alkalmazásokat építeni, amelyek AI modelleket kapcsolnak valós eszközökhöz, gyakorlati modulokon keresztül, amelyek lefedik az alapokat, egyedi szerverfejlesztést és éles telepítési stratégiákat. | [Gyakorlati labor](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Minta projektek

### 🧮 MCP kalkulátor mintaprojektek:
<details>
  <summary><strong>Kódmegvalósítások felfedezése nyelv szerint</strong></summary>

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


## 🎯 MCP tanulás előfeltételei

Ahhoz, hogy a legtöbbet hozd ki ebből a tananyagból, érdemes rendelkezned:

- Alapvető ismeretek C#, Java vagy Python nyelvből  
- Ügyfél-szerver modell és API-k megértése  
- (Opcionális) Gépi tanulás alapfogalmainak ismerete  

## 📚 Tanulmányi útmutató

Egy átfogó [Tanulmányi útmutató](./study_guide.md) áll rendelkezésedre, hogy hatékonyan eligazodj ebben a tárházban. Az útmutató tartalmazza:

- Vizualizált tananyag térkép az összes témakörrel  
- A tárház részeinek részletes bontását  
- Útmutatót a minta projektek használatához  
- Ajánlott tanulási utak különböző szintű tanulók számára  
- Kiegészítő források a tanulási folyamat támogatására  

## 🛠️ Hogyan használd hatékonyan ezt a tananyagot

Minden leckében megtalálod:

1. Az MCP fogalmak világos magyarázatát  
2. Élő kód példákat több nyelven  
3. Gyakorlatokat valós MCP alkalmazások építéséhez  
4. További anyagokat haladó tanulók számára  

## 📜 Licencinformáció

Ez a tartalom az **MIT Licenc** alatt áll. A feltételekért lásd a [LICENSE](../../LICENSE) fájlt.

## 🤝 Hozzájárulási irányelvek

Ez a projekt szívesen fogad hozzájárulásokat és javaslatokat. A legtöbb hozzájáruláshoz szükséges, hogy elfogadd a  
Contributor License Agreement (CLA) megállapodást, amelyben kijelented, hogy jogodban áll, és valóban megadod a jogokat hozzájárulásod használatára. Részletekért látogass el ide: <https://cla.opensource.microsoft.com>.

Amikor pull request-et küldesz, egy CLA bot automatikusan megállapítja, hogy szükséges-e CLA-t benyújtanod, és ennek megfelelően jelöli a PR-t (pl. státusz ellenőrzés, komment). Kövesd egyszerűen a bot utasításait. Ezt csak egyszer kell megtenned minden olyan tárházban, amely a CLA-t használja.

Ez a projekt a [Microsoft Nyílt Forráskódú Magatartási Kódexét](https://opensource.microsoft.com/codeofconduct/) alkalmazza. További információkért lásd a [Magatartási Kódex GYIK](https://opensource.microsoft.com/codeofconduct/faq/) oldalt, vagy írj az [opencode@microsoft.com](mailto:opencode@microsoft.com) címre bármilyen kérdés vagy észrevétel esetén.

## 🎒 Egyéb kurzusok
Csapatunk további kurzusokat is készít! Nézd meg:

- [AI ügynökök kezdőknek](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)  
- [Generatív AI kezdőknek .NET használatával](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)  
- [Generatív AI kezdőknek JavaScript-tel](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)  
- [Generatív AI kezdőknek](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)  
- [Gépi tanulás kezdőknek](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)  
- [Adattudomány kezdőknek](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)  
- [AI kezdőknek](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)  
- [Kiberbiztonság kezdőknek](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)  
- [Webfejlesztés kezdőknek](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)  
- [IoT kezdőknek](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)  
- [XR fejlesztés kezdőknek](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [GitHub Copilot mesteri használata AI páros programozáshoz](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [GitHub Copilot mesteri használata C#/.NET fejlesztőknek](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Válaszd ki a saját Copilot kalandodat](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Védjegyértesítés

Ez a projekt tartalmazhat védjegyeket vagy logókat projektekhez, termékekhez vagy szolgáltatásokhoz. A Microsoft védjegyek vagy logók jogosult használata a [Microsoft védjegy- és márka irányelveinek](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general) betartása mellett történhet.
A Microsoft védjegyek vagy logók használata a projekt módosított változataiban nem okozhat félreértést, és nem sugallhat Microsoft támogatást.
Harmadik fél védjegyeinek vagy logóinak használata a harmadik felek szabályzatai szerint történik.

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordítószolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy félreértelmezésekért.