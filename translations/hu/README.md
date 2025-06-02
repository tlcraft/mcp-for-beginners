<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4458d89100952180348d8775b149295e",
  "translation_date": "2025-06-02T19:26:06+00:00",
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
2. **Klónozd a tárolót**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Csatlakozz az Azure AI Foundry Discord szerverhez, és ismerkedj szakértőkkel és fejlesztőtársaiddal**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Többnyelvű támogatás

#### GitHub Action segítségével támogatott (Automatizált és mindig naprakész)

# 🚀 Model Context Protocol (MCP) Tananyag Kezdőknek

## **Ismerd meg az MCP-t gyakorlati kódpéldákon keresztül C#, Java, JavaScript, Python és TypeScript nyelveken**

## 🧠 Áttekintés a Model Context Protocol tananyagról

A **Model Context Protocol (MCP)** egy élvonalbeli keretrendszer, amely az AI modellek és kliens alkalmazások közötti kommunikáció szabványosítására szolgál. Ez a nyílt forráskódú tananyag egy jól felépített tanulási útvonalat kínál, gyakorlati kódpéldákkal és valós alkalmazási esetekkel, népszerű programozási nyelveken, mint a C#, Java, JavaScript, TypeScript és Python.

Akár AI fejlesztő, rendszertervező vagy szoftvermérnök vagy, ez az útmutató átfogó forrás a MCP alapjainak és megvalósítási stratégiáinak elsajátításához.

## 🔗 Hivatalos MCP források

- 📘 [MCP Dokumentáció](https://modelcontextprotocol.io/) – Részletes oktatóanyagok és felhasználói kézikönyvek  
- 📜 [MCP Specifikáció](https://spec.modelcontextprotocol.io/) – Protokoll architektúra és technikai hivatkozások  
- 🧑‍💻 [MCP GitHub Tároló](https://github.com/modelcontextprotocol) – Nyílt forráskódú SDK-k, eszközök és kódminták  

## 🧭 Teljes MCP tananyag felépítése

| Fej. | Cím | Leírás | Link |
|--|--|--|--|
| 00 | **Bevezetés az MCP-be** | Áttekintés a Model Context Protocol-ról és annak jelentőségéről az AI folyamatokban, beleértve, hogy mi az MCP, miért fontos a szabványosítás, gyakorlati példák és előnyök | [Bevezetés](./00-Introduction/README.md) |
| 01 | **Alapfogalmak magyarázata** | Az MCP alapfogalmainak mélyreható bemutatása, beleértve a kliens-szerver architektúrát, a protokoll fő összetevőit és az üzenetküldési mintákat | [Alapfogalmak](./01-CoreConcepts/README.md) |
| 02 | **Biztonság az MCP-ben** | Biztonsági fenyegetések az MCP alapú rendszerekben, technikák és bevált gyakorlatok a biztonságos megvalósításhoz | [Biztonság](./02-Security/README.md) |
| 03 | **MCP használatának megkezdése** | Környezet beállítása és konfigurálása, alap MCP szerverek és kliensek létrehozása, MCP integrálása meglévő alkalmazásokkal | [Kezdetek](./03-GettingStarted/README.md) |
| 3.1 | **Első szerver** | Alap szerver beállítása az MCP protokollal, a szerver-kliens interakció megértése és a szerver tesztelése | [Első szerver](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Első kliens** | Alap kliens beállítása az MCP protokollal, a kliens-szerver interakció megértése és a kliens tesztelése | [Első kliens](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Kliens LLM-mel** | Kliens beállítása MCP protokollal és egy Nagy Nyelvi Modell (LLM) használatával | [Kliens LLM-mel](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Szerver használata Visual Studio Code-dal** | Visual Studio Code beállítása MCP protokoll szerverek használatához | [Szerver használata Visual Studio Code-dal](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Szerver létrehozása SSE-vel** | Az SSE segít a szerver internetre történő kitettségében. Ebben a részben megtanulhatod, hogyan hozz létre szervert SSE segítségével | [Szerver létrehozása SSE-vel](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **AI Toolkit használata** | Az AI toolkit egy nagyszerű eszköz, amely segít az AI és MCP munkafolyamatok kezelésében | [AI Toolkit használata](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Szerver tesztelése** | A tesztelés fontos része a fejlesztési folyamatnak. Ez a rész segít különböző eszközök használatában | [Szerver tesztelése](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Szerver telepítése** | Hogyan jutsz el a helyi fejlesztéstől a termelésig? Ez a rész segít a szerver fejlesztésében és telepítésében | [Szerver telepítése](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Gyakorlati megvalósítás** | SDK-k használata különböző nyelveken, hibakeresés, tesztelés, validálás, újrahasznosítható prompt sablonok és munkafolyamatok készítése | [Gyakorlati megvalósítás](./04-PracticalImplementation/README.md) |
| 05 | **Haladó témák az MCP-ben** | Többmodalitású AI munkafolyamatok és bővíthetőség, biztonságos skálázási stratégiák, MCP vállalati környezetben | [Haladó témák](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP integráció Azure-rel** | Azure integráció bemutatása | [MCP Azure integráció](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Többmodalitás** | Különböző modalitások, például képek kezelése | [Többmodalitás](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demó** | Minimális Spring Boot alkalmazás az OAuth2 MCP-vel történő használatáról, mint Authorization és Resource Server. Bemutatja a biztonságos token kibocsátást, védett végpontokat, Azure Container Apps telepítést és API Management integrációt | [MCP OAuth2 Demó](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Context-ek** | Tudj meg többet a root context-ről és annak megvalósításáról | [Root Context-ek](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Ismerd meg a különböző routing típusokat | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Ismerd meg a sampling kezelését | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skálázás** | Ismerd meg az MCP szerverek skálázását, beleértve a horizontális és vertikális skálázási stratégiákat, erőforrás-optimalizálást és teljesítményhangolást | [Skálázás](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Biztonság** | Biztosítsd az MCP szervered, beleértve az autentikációt, autorizációt és adatvédelmi stratégiákat | [Biztonság](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP szerver és kliens SerpAPI integrációval valós idejű webes, hírek, termék kereséshez és kérdés-válasz funkcióhoz. Több eszköz összehangolását, külső API integrációt és robosztus hibakezelést mutat be | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Közösségi hozzájárulások** | Kód és dokumentáció hozzájárulás, együttműködés GitHub-on keresztül, közösségi fejlesztések és visszajelzések | [Közösségi hozzájárulások](./06-CommunityContributions/README.md) |
| 07 | **Tapasztalatok a korai alkalmazásból** | Valós megvalósítások, működő megoldások építése és telepítése MCP alapokon, trendek és jövőbeli tervek | [Tapasztalatok](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Legjobb gyakorlatok az MCP-hez** | Teljesítményhangolás és optimalizálás, hibabiztos MCP rendszerek tervezése, tesztelési és ellenállóképességi stratégiák | [Legjobb gyakorlatok](./08-BestPractices/README.md) |
| 09 | **MCP esettanulmányok** | Mélyreható elemzések MCP megoldás architektúrákról, telepítési tervek és integrációs tippek, jegyzetelt diagramok és projekt bemutatók | [Esettanulmányok](./09-CaseStudy/README.md) |

## Minta projektek

### 🧮 MCP Kalkulátor minta projektek:
<details>
  <summary><strong>Kódmegvalósítások nyelvek szerint</strong></summary>
- [C# MCP Server Példa](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Számológép](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Bemutató](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Szerver](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP Példa](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP Haladó Számológép Projektek:
<details>
  <summary><strong>Fedezd fel a Haladó Mintákat</strong></summary>

  - [Haladó C# Minta](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Konténer Alkalmazás Példa](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript Haladó Minta](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Összetett Megvalósítás](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Konténer Minta](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 MCP Tanulás Előfeltételei

Ahhoz, hogy a legtöbbet hozd ki ebből a tananyagból, érdemes, ha rendelkezel:

- Alapvető ismeretek C#, Java vagy Python nyelvekből  
- A kliens-szerver modell és API-k megértése  
- (Opcionális) Gépi tanulás alapfogalmainak ismerete  

## 🛠️ Hogyan Használd Hatékonyan Ezt a Tananyagot

Minden leckében megtalálod:

1. Az MCP fogalmainak világos magyarázatait  
2. Élő kód példákat több nyelven  
3. Gyakorlatokat valós MCP alkalmazások építéséhez  
4. Kiegészítő forrásokat haladó tanulók számára  

## 📜 Licenc Információ

Ez a tartalom az **MIT License** feltételei alatt érhető el. A részletekért lásd a [LICENSE](../../LICENSE) fájlt.

## 🤝 Hozzájárulási Irányelvek

Ez a projekt szívesen fogad hozzájárulásokat és javaslatokat. A legtöbb hozzájáruláshoz szükség van arra, hogy elfogadd a
Contributor License Agreement (CLA) megállapodást, amely igazolja, hogy jogodban áll, és valóban megadod nekünk
a jogot a hozzájárulásod használatára. Részletekért látogass el ide: <https://cla.opensource.microsoft.com>.

Amikor pull request-et küldesz be, egy CLA bot automatikusan eldönti, hogy szükséges-e CLA-t benyújtanod, és ennek megfelelően jelzi a PR-t (pl. státusz ellenőrzés, komment). Egyszerűen kövesd a bot utasításait. Ezt csak egyszer kell megtenned az összes CLA-t használó repóban.

Ez a projekt a [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/) irányelveit alkalmazza.
További információkért lásd a [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) oldalt, vagy írj az [opencode@microsoft.com](mailto:opencode@microsoft.com) címre kérdéseiddel, észrevételeiddel.

## 🎒 Egyéb Tanfolyamok
Csapatunk más tanfolyamokat is készít! Nézd meg:

- [AI Agents Kezdőknek](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Generatív AI Kezdőknek .NET használatával](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)
- [Generatív AI Kezdőknek JavaScript-tel](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)
- [Generatív AI Kezdőknek](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)
- [ML Kezdőknek](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)
- [Adattudomány Kezdőknek](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)
- [AI Kezdőknek](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)
- [Kiberbiztonság Kezdőknek](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)
- [Webfejlesztés Kezdőknek](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [IoT Kezdőknek](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [XR Fejlesztés Kezdőknek](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [GitHub Copilot Mesterkurzus AI páros programozáshoz](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [GitHub Copilot Mesterkurzus C#/.NET fejlesztőknek](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Válaszd ki a saját Copilot kalandodat](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Védjegy Közlemény

Ez a projekt tartalmazhat védjegyeket vagy logókat projektekhez, termékekhez vagy szolgáltatásokhoz. A Microsoft védjegyek vagy logók használata csak az alábbiak szerint engedélyezett, és meg kell felelnie a
[Microsoft védjegy- és márka irányelveinek](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
A Microsoft védjegyek vagy logók módosított verzióban történő használata nem okozhat félreértést, és nem sugallhat Microsoft támogatást.
Harmadik féltől származó védjegyek vagy logók használata azok szabályzatai szerint történik.

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordítószolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár az pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén professzionális, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy félreértelmezésekért.