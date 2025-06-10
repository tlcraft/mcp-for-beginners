<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3ede7f051090bd4acfe5b068bab9f6b0",
  "translation_date": "2025-06-10T04:37:03+00:00",
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


Kövesd az alábbi lépéseket, hogy elkezdd használni ezeket az erőforrásokat:
1. **Forkold a tárat**: Kattints a [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork) gombra
2. **Klónozd a tárat**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Csatlakozz az Azure AI Foundry Discord szerverhez, és ismerkedj szakértőkkel és más fejlesztőkkel**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Többnyelvű támogatás

#### GitHub Action segítségével támogatott (Automatizált és mindig naprakész)

# 🚀 Model Context Protocol (MCP) Tananyag kezdőknek

## **Tanulj MCP-t gyakorlati kódpéldák segítségével C#, Java, JavaScript, Python és TypeScript nyelveken**

## 🧠 A Model Context Protocol tananyag áttekintése

A **Model Context Protocol (MCP)** egy élvonalbeli keretrendszer, amely az AI modellek és kliensalkalmazások közötti kommunikáció szabványosítására szolgál. Ez a nyílt forráskódú tananyag egy jól felépített tanulási utat kínál, gyakorlati kódpéldákkal és valós felhasználási esetekkel, népszerű programozási nyelveken, mint a C#, Java, JavaScript, TypeScript és Python.

Akár AI fejlesztő, rendszertervező vagy szoftvermérnök vagy, ez az útmutató átfogó forrásként szolgál az MCP alapjainak és megvalósítási stratégiáinak elsajátításához.

## 🔗 Hivatalos MCP források

- 📘 [MCP Dokumentáció](https://modelcontextprotocol.io/) – Részletes oktatóanyagok és felhasználói útmutatók  
- 📜 [MCP Specifikáció](https://spec.modelcontextprotocol.io/) – A protokoll felépítése és technikai hivatkozások  
- 🧑‍💻 [MCP GitHub tárhely](https://github.com/modelcontextprotocol) – Nyílt forráskódú SDK-k, eszközök és kódpéldák  

## 🧭 Az MCP tananyag teljes struktúrája

| Ch | Cím | Leírás | Link |
|--|--|--|--|
| 00 | **Bevezetés az MCP-be** | Áttekintés a Model Context Protocol-ról és annak jelentőségéről az AI folyamatokban, beleértve az MCP lényegét, a szabványosítás fontosságát, valamint gyakorlati felhasználási eseteket és előnyöket | [Bevezetés](./00-Introduction/README.md) |
| 01 | **Alapfogalmak magyarázata** | Az MCP alapfogalmainak mélyreható bemutatása, beleértve a kliens-szerver architektúrát, a protokoll kulcselemeit és az üzenetküldési mintákat | [Alapfogalmak](./01-CoreConcepts/README.md) |
| 02 | **Biztonság az MCP-ben** | Biztonsági fenyegetések felismerése MCP-alapú rendszerekben, technikák és bevált gyakorlatok a biztonságos megvalósításhoz | [Biztonság](./02-Security/README.md) |
| 03 | **Első lépések az MCP-vel** | Környezet beállítása és konfigurálása, alap MCP szerverek és kliensek létrehozása, MCP integrálása meglévő alkalmazásokkal | [Első lépések](./03-GettingStarted/README.md) |
| 3.1 | **Első szerver** | Alap szerver beállítása az MCP protokoll segítségével, a szerver-kliens interakció megértése és a szerver tesztelése | [Első szerver](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Első kliens** | Alap kliens beállítása az MCP protokoll segítségével, a kliens-szerver interakció megértése és a kliens tesztelése | [Első kliens](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Kliens LLM-mel** | Kliens létrehozása az MCP protokollal, amely egy Nagy Nyelvi Modellt (LLM) használ | [Kliens LLM-mel](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Szerver használata Visual Studio Code-dal** | Visual Studio Code beállítása MCP protokoll szerverek fogyasztásához | [Szerver használata Visual Studio Code-dal](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Szerver létrehozása SSE segítségével** | Az SSE segítségével szervert tehetünk elérhetővé az interneten. Ez a rész segít SSE alapú szerver létrehozásában | [Szerver létrehozása SSE segítségével](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **AI Toolkit használata** | Az AI toolkit nagyszerű eszköz az AI és MCP munkafolyamatok kezeléséhez | [AI Toolkit használata](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Szerver tesztelése** | A tesztelés fontos része a fejlesztési folyamatnak. Ez a rész különböző eszközök használatában segít | [Szerver tesztelése](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Szerver telepítése** | Hogyan juthatunk el a helyi fejlesztéstől a produkcióig? Ez a rész segít a szerver fejlesztésében és telepítésében | [Szerver telepítése](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Gyakorlati megvalósítás** | SDK-k használata különböző nyelveken, hibakeresés, tesztelés és validálás, újrafelhasználható prompt sablonok és munkafolyamatok készítése | [Gyakorlati megvalósítás](./04-PracticalImplementation/README.md) |
| 05 | **Fejlett témák az MCP-ben** | Többmodalitású AI munkafolyamatok és bővíthetőség, biztonságos skálázási stratégiák, MCP vállalati környezetekben | [Fejlett témák](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP integráció Azure-rel** | Azure integráció bemutatása | [MCP Azure integráció](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Többmodalitás** | Különböző modalitások, például képek kezelésének bemutatása | [Többmodalitás](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 bemutató** | Minimális Spring Boot alkalmazás az MCP-vel OAuth2 használatára, mint Authorization és Resource Server. Biztonságos token kibocsátást, védett végpontokat, Azure Container Apps telepítést és API Management integrációt mutat be | [MCP OAuth2 bemutató](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Tudj meg többet a root context-ről és annak megvalósításáról | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Különböző routing típusok megismerése | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Mintavételezéssel kapcsolatos ismeretek | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skálázás** | MCP szerverek skálázása, beleértve a horizontális és vertikális skálázási stratégiákat, erőforrás-optimalizálást és teljesítményhangolást | [Skálázás](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Biztonság** | MCP szerver biztonságának növelése, beleértve az autentikációt, autorizációt és adatvédelmi stratégiákat | [Biztonság](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP szerver és kliens integrációval SerpAPI-val valós idejű webes, hírek, termékkeresés és kérdés-válasz funkciókhoz. Többeszközös koordináció, külső API integráció és robosztus hibakezelés bemutatása | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Közösségi hozzájárulások** | Kód és dokumentáció hozzájárulás, együttműködés GitHub-on, közösségi fejlesztések és visszajelzések | [Közösségi hozzájárulások](./06-CommunityContributions/README.md) |
| 07 | **Tapasztalatok a korai alkalmazásból** | Valós megvalósítások és bevált gyakorlatok, MCP-alapú megoldások építése és telepítése, trendek és jövőbeli irányok | [Tapasztalatok](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Legjobb gyakorlatok az MCP-hez** | Teljesítményhangolás és optimalizáció, hibabiztos MCP rendszerek tervezése, tesztelési és ellenálló képesség stratégiák | [Legjobb gyakorlatok](./08-BestPractices/README.md) |
| 09 | **MCP esettanulmányok** | Mélyebb betekintés MCP megoldás architektúrákba, telepítési tervrajzokba és integrációs tippekbe, annotált diagramok és projektbemutatók | [Esettanulmányok](./09-CaseStudy/README.md) |
| 10 | **AI munkafolyamatok egyszerűsítése: MCP szerver építése az AI Toolkit segítségével** | Átfogó, gyakorlati workshop, amely az MCP-t és a Microsoft AI Toolkitjét egyesíti a VS Code-hoz. Tanulj meg intelligens alkalmazásokat építeni, amelyek AI modelleket kötnek össze valós eszközökkel, gyakorlati modulokon keresztül, amelyek lefedik az alapokat, egyedi szerverfejlesztést és a termelési bevezetési stratégiákat. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Minta projektek

### 🧮 MCP számológép mintaprojektek:
<details>
  <summary><strong>Kódmegvalósítások nyelvek szerint</strong></summary>

  - [C# MCP Server példa](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP számológép](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP demó](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP példa](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP haladó számológép projektek:
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

- Alapvető C#, Java vagy Python ismeretekkel  
- A kliens-szerver modell és API-k megértésével  
- (Opcionálisan) gépi tanulási alapfogalmakkal való ismerettel  

## 🛠️ Hogyan használd hatékonyan ezt a tananyagot

Minden lecke tartalmazza:

1. Az MCP fogalmak világos magyarázatát  
2. Élő kód példákat több nyelven  
3. Gyakorlatokat valós MCP alkalmazások építéséhez  
4. Kiegészítő forrásokat haladó tanulók számára  

## 📜 Licenc információk

Ez a tartalom az **MIT License** alatt áll. A feltételekért lásd a [LICENSE](../../LICENSE) fájlt.

## 🤝 Hozzájárulási irányelvek

Ez a projekt szívesen fogad hozzájárulásokat és javaslatokat. A legtöbb hozzájáruláshoz el kell fogadnod egy Contributor License Agreement-et (CLA), amelyben kijelented, hogy jogosult vagy, és valóban megadod számunkra a hozzájárulásod felhasználásának jogát. Részletekért látogass el ide: <https://cla.opensource.microsoft.com>.

Amikor pull request-et küldesz be, egy CLA bot automatikusan megállapítja, hogy szükséges-e CLA-t szolgáltatnod, és megfelelően jelzi a PR-t (pl. státusz ellenőrzés, komment). Egyszerűen kövesd a bot utasításait. Ezt csak egyszer kell megtenned az összes CLA-t használó repóban.

Ez a projekt a [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/) irányelveit követi. További információkért lásd a [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) oldalt, vagy írj az [opencode@microsoft.com](mailto:opencode@microsoft.com) címre kérdéseiddel vagy észrevételeiddel.

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
- [Choose Your Own Copilot Adventure](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)

## ™️ Védjegy értesítés

Ez a projekt tartalmazhat védjegyeket vagy logókat projektekhez, termékekhez vagy szolgáltatásokhoz. A Microsoft védjegyek vagy logók jogosult használata a [Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general) szabályainak megfelelően történhet. A Microsoft védjegyek vagy logók módosított verziókban történő használata nem okozhat félreértést, és nem sugallhat Microsoft támogatást. Harmadik féltől származó védjegyek vagy logók használata az adott harmadik felek szabályzatainak van alárendelve.

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár az pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum a saját nyelvén tekintendő hivatalos forrásnak. Fontos információk esetén professzionális, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félreértelmezésekért.