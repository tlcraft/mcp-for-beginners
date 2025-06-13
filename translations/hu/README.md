<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26ab12045ee411ab7ad0eb0b1b7b1cbb",
  "translation_date": "2025-06-13T00:48:36+00:00",
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
1. **Forkold le a tárat**: Kattints ide [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Klónozd le a tárat**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Csatlakozz az Azure AI Foundry Discord szerverhez, és ismerkedj meg szakértőkkel és fejlesztőtársaiddal**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Többnyelvű támogatás

#### GitHub Action segítségével támogatott (Automatizált és mindig naprakész)

# 🚀 Model Context Protocol (MCP) Tananyag Kezdőknek

## **Ismerd meg az MCP-t gyakorlati kódpéldákon keresztül C#, Java, JavaScript, Python és TypeScript nyelveken**

## 🧠 A Model Context Protocol tananyag áttekintése

A **Model Context Protocol (MCP)** egy korszerű keretrendszer, amely az AI modellek és kliensalkalmazások közötti interakciók szabványosítására készült. Ez a nyílt forráskódú tananyag strukturált tanulási utat kínál, gyakorlati kódpéldákkal és valós használati esetekkel, népszerű programozási nyelveken, mint a C#, Java, JavaScript, TypeScript és Python.

Legyél akár AI fejlesztő, rendszertervező vagy szoftvermérnök, ez az útmutató átfogó forrás az MCP alapjainak elsajátításához és a megvalósítási stratégiák megértéséhez.

## 🔗 Hivatalos MCP források

- 📘 [MCP Dokumentáció](https://modelcontextprotocol.io/) – Részletes oktatóanyagok és felhasználói kézikönyvek  
- 📜 [MCP Specifikáció](https://spec.modelcontextprotocol.io/) – Protokoll architektúra és műszaki hivatkozások  
- 🧑‍💻 [MCP GitHub tároló](https://github.com/modelcontextprotocol) – Nyílt forráskódú SDK-k, eszközök és kódpéldák  

## 🧭 Az MCP tananyag teljes szerkezete

| Fejezet | Cím | Leírás | Link |
|--|--|--|--|
| 00 | **Bevezetés az MCP-be** | Áttekintés a Model Context Protocolról és annak jelentőségéről az AI folyamatokban, beleértve, hogy mi az MCP, miért fontos a szabványosítás, valamint gyakorlati használati esetek és előnyök | [Bevezetés](./00-Introduction/README.md) |
| 01 | **Alapfogalmak magyarázata** | Mélyebb betekintés az MCP alapfogalmaiba, beleértve az ügyfél-szerver architektúrát, a protokoll kulcselemeit és az üzenetküldési mintákat | [Alapfogalmak](./01-CoreConcepts/README.md) |
| 02 | **Biztonság az MCP-ben** | Biztonsági fenyegetések az MCP alapú rendszerekben, technikák és bevált gyakorlatok a biztonságos megvalósításhoz | [Biztonság](./02-Security/README.md) |
| 03 | **MCP használatának megkezdése** | Környezet beállítása és konfigurálása, alap MCP szerverek és kliensek létrehozása, MCP integrálása meglévő alkalmazásokkal | [Első lépések](./03-GettingStarted/README.md) |
| 3.1 | **Első szerver** | Alap szerver beállítása az MCP protokollal, a szerver-ügyfél interakció megértése és a szerver tesztelése | [Első szerver](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Első kliens** | Alap kliens beállítása az MCP protokollal, a kliens-szerver interakció megértése és a kliens tesztelése | [Első kliens](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Kliens LLM-mel** | Kliens beállítása az MCP protokollal egy nagy nyelvi modellel (LLM) | [Kliens LLM-mel](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Szerver használata Visual Studio Code-dal** | Visual Studio Code beállítása MCP protokollt használó szerverek fogyasztásához | [Szerver használata Visual Studio Code-dal](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Szerver létrehozása SSE-vel** | Az SSE segítségével elérhetővé tehetjük a szervert az interneten. Ez a rész segít egy szerver létrehozásában SSE-vel | [Szerver létrehozása SSE-vel](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **AI Toolkit használata** | Az AI toolkit egy nagyszerű eszköz, amely segít az AI és MCP munkafolyamatok kezelésében | [AI Toolkit használata](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Szerver tesztelése** | A tesztelés fontos része a fejlesztési folyamatnak. Ez a rész több különböző eszköz használatát mutatja be a teszteléshez | [Szerver tesztelése](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Szerver üzembe helyezése** | Hogyan juthatsz el a helyi fejlesztéstől a termelésig? Ez a rész segít a szerver fejlesztésében és üzembe helyezésében | [Szerver üzembe helyezése](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Gyakorlati megvalósítás** | SDK-k használata különböző nyelveken, hibakeresés, tesztelés és validáció, újrahasznosítható prompt sablonok és munkafolyamatok készítése | [Gyakorlati megvalósítás](./04-PracticalImplementation/README.md) |
| 05 | **Haladó MCP témák** | Többmodalitású AI munkafolyamatok és bővíthetőség, biztonságos skálázási stratégiák, MCP vállalati ökoszisztémákban | [Haladó témák](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP integráció Azure-rel** | Bemutatja az Azure integrációját | [MCP Azure integráció](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Többmodalitás** | Bemutatja, hogyan lehet különböző modalitásokkal, például képekkel dolgozni | [Többmodalitás](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 bemutató** | Egy minimális Spring Boot alkalmazás, amely bemutatja az OAuth2 használatát MCP-vel, mint hitelesítési és erőforrás szerver. Biztonságos token kibocsátás, védett végpontok, Azure Container Apps telepítés és API Management integráció | [MCP OAuth2 bemutató](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Context-ek** | Tudj meg többet a root context-ről és annak megvalósításáról | [Root Context-ek](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Ismerd meg a különböző routing típusokat | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Tanuld meg, hogyan kell sampling-et használni | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skálázás** | Ismerd meg az MCP szerverek skálázását, beleértve a horizontális és vertikális skálázási stratégiákat, az erőforrás-optimalizálást és a teljesítményhangolást | [Skálázás](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Biztonság** | Biztosítsd MCP szervered, beleértve az autentikációt, autorizációt és adatvédelmi stratégiákat | [Biztonság](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP szerver és kliens integrálva a SerpAPI-val valós idejű web-, hírek-, termékkereséshez és kérdés-válasz funkciókhoz. Bemutatja a többeszközös koordinációt, külső API integrációt és robusztus hibakezelést | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Valós idejű adatfolyam** | A valós idejű adatfolyam mára elengedhetetlen lett a mai adatvezérelt világban, ahol a vállalkozások és alkalmazások azonnali információhoz jutnak, hogy időben hozhassanak döntéseket | [Valós idejű adatfolyam](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Valós idejű webkeresés** | Hogyan alakítja át az MCP a valós idejű webkeresést azáltal, hogy egységes megközelítést kínál a kontextuskezeléshez AI modellek, keresőmotorok és alkalmazások között | [Valós idejű webkeresés](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Közösségi hozzájárulások** | Hogyan járulhatsz hozzá kódokkal és dokumentációval, együttműködés GitHubon keresztül, közösségi fejlesztések és visszajelzések | [Közösségi hozzájárulások](./06-CommunityContributions/README.md) |
| 07 | **Tapasztalatok a korai alkalmazásból** | Valós megvalósítások és a bevált gyakorlatok, MCP alapú megoldások építése és telepítése, trendek és jövőbeli irányok | [Tapasztalatok](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Legjobb gyakorlatok MCP-hez** | Teljesítményhangolás és optimalizálás, hibabiztos MCP rendszerek tervezése, tesztelési és ellenállóképességi stratégiák | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP esettanulmányok** | Mélyreható elemzések MCP megoldásarchitektúrákról, telepítési tervekről és integrációs tippekről, magyarázott diagramok és projektbemutatók | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **AI munkafolyamatok egyszerűsítése: MCP szerver építése AI Toolkit segítségével** | Átfogó, gyakorlati workshop, amely ötvözi az MCP-t a Microsoft AI Toolkitjével VS Code-ban. Tanulj meg intelligens alkalmazásokat építeni, amelyek AI modelleket kapcsolnak a valós eszközökhöz gyakorlati modulokon keresztül, lefedve az alapokat, egyedi szerverfejlesztést és éles üzembe helyezési stratégiákat. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

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
  - [Java konténer alkalmazás példa](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript haladó minta](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python összetett megvalósítás](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript konténer minta](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 Előfeltételek MCP tanulásához

Ahhoz, hogy a legtöbbet hozd ki ebből a tananyagból, érdemes:

- Alapvető ismeretek C#, Java vagy Python nyelvekből  
- A kliens-szerver modell és az API-k megértése  
- (Opcionális) Gépi tanulási alapfogalmak ismerete  

## 📚 Tanulmányi útmutató

Egy átfogó [Tanulmányi útmutató](./study_guide.md) áll rendelkezésre, amely segít hatékonyan eligazodni ebben a tárolóban. Az útmutató tartalmazza:

- Egy vizuális tananyag térképet az összes témakörrel  
- Részletes bontást a tároló egyes részeiről  
- Útmutatást a mintaprojektek használatához  
- Ajánlott tanulási útvonalakat különböző szintekhez  
- Kiegészítő forrásokat a tanulási folyamat támogatására  

## 🛠️ Hogyan használd hatékonyan ezt a tananyagot

Minden leckében megtalálod:

1. Az MCP fogalmak világos magyarázatát  
2. Élő kódpéldákat több nyelven  
3. Gyakorlatokat valódi MCP alkalmazások készítéséhez  
4. Kiegészítő anyagokat haladó tanulóknak  

## 📜 Licenc információ

Ez a tartalom az **MIT License** feltételei szerint érhető el. A feltételeket lásd a [LICENSE](../../LICENSE) fájlban.

## 🤝 Hozzájárulási irányelvek

Ez a projekt örömmel fogadja a hozzájárulásokat és javaslatokat. A legtöbb hozzájáruláshoz szükséges, hogy elfogadd a Contributor License Agreement (CLA) feltételeit, amelyben kijelented, hogy jogodban áll és ténylegesen megadod nekünk a jogokat a hozzájárulásod használatához. Részletekért látogass el ide: <https://cla.opensource.microsoft.com>.

Amikor pull request-et küldesz, a CLA bot automatikusan megállapítja, hogy szükséges-e CLA-t benyújtanod, és ennek megfelelően jelöli a PR-t (pl. státusz ellenőrzés, komment). Egyszerűen kövesd a bot utasításait. Ezt csak egyszer kell megtenned az összes CLA-t használó tárolónál.

Ez a projekt a [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/) irányelveit követi. További információkért lásd a [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) oldalt, vagy írj az [opencode@microsoft.com](mailto:opencode@microsoft.com) címre kérdéseiddel, észrevételeiddel.

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
- [GitHub Copilot mesteri szintű használata C#/.NET fejlesztőknek](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Válaszd ki a saját Copilot kalandodat](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Védjegyértesítés

Ez a projekt tartalmazhat védjegyeket vagy logókat projektekhez, termékekhez vagy szolgáltatásokhoz. A Microsoft védjegyeinek vagy logóinak jogos használata a [Microsoft védjegy- és márka irányelveinek](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general) betartásával lehetséges. A Microsoft védjegyek vagy logók módosított változatban történő használata nem okozhat félreértést és nem sugallhat Microsoft támogatást. Harmadik fél védjegyeinek vagy logóinak használata az adott harmadik fél szabályzatának hatálya alá tartozik.

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén szakmai emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.