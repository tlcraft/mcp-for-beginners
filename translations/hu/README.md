<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "677cecb63a0bf6c0f49e40ffc15f6189",
  "translation_date": "2025-06-02T12:46:15+00:00",
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


Kövesd ezeket a lépéseket, hogy elkezdhesd használni ezeket az erőforrásokat:
1. **Forkold a tárolót**: Kattints [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Klónozd a tárolót**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Csatlakozz az Azure AI Foundry Discord szerveréhez, és ismerkedj meg szakértőkkel és fejlesztőtársakkal**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Többnyelvű támogatás

#### GitHub Action segítségével támogatott (Automatikus és mindig naprakész)

# 🚀 Model Context Protocol (MCP) Tananyag Kezdőknek

## **Tanulj MCP-t gyakorlati kódpéldákon keresztül C#, Java, JavaScript, Python és TypeScript nyelveken**

## 🧠 A Model Context Protocol tananyag áttekintése

A **Model Context Protocol (MCP)** egy élvonalbeli keretrendszer, amely az AI modellek és kliensalkalmazások közötti kommunikáció szabványosítására szolgál. Ez a nyílt forráskódú tananyag egy jól strukturált tanulási útvonalat kínál, gyakorlati kódpéldákkal és valós használati esetekkel, népszerű programozási nyelveken, mint a C#, Java, JavaScript, TypeScript és Python.

Legyél akár AI fejlesztő, rendszertervező vagy szoftvermérnök, ez az útmutató átfogó forrás a MCP alapjainak és megvalósítási stratégiáinak elsajátításához.

## 🔗 Hivatalos MCP források

- 📘 [MCP Dokumentáció](https://modelcontextprotocol.io/) – Részletes oktatóanyagok és felhasználói útmutatók  
- 📜 [MCP Specifikáció](https://spec.modelcontextprotocol.io/) – Protokoll felépítése és műszaki hivatkozások  
- 🧑‍💻 [MCP GitHub tárhely](https://github.com/modelcontextprotocol) – Nyílt forráskódú SDK-k, eszközök és kódminták  

## 🧭 A teljes MCP tananyag felépítése

| Fej. | Cím | Leírás | Link |
|--|--|--|--|
| 00 | **Bevezetés az MCP-be** | Áttekintés a Model Context Protocolról és annak jelentőségéről az AI folyamatokban, beleértve mi az MCP, miért fontos a szabványosítás, gyakorlati felhasználási esetek és előnyök | [Bevezetés](./00-Introduction/README.md) |
| 01 | **Alapfogalmak magyarázata** | Az MCP alapfogalmainak részletes bemutatása, beleértve a kliens-szerver architektúrát, a protokoll főbb elemeit és az üzenetküldési mintákat | [Alapfogalmak](./01-CoreConcepts/README.md) |
| 02 | **Biztonság az MCP-ben** | Biztonsági fenyegetések az MCP-alapú rendszerekben, technikák és bevált gyakorlatok a biztonságos megvalósításhoz | [Biztonság](./02-Security/README.md) |
| 03 | **MCP használatának megkezdése** | Környezet beállítása és konfigurálása, alap MCP szerverek és kliensek létrehozása, MCP integrálása meglévő alkalmazásokkal | [Kezdő lépések](./03-GettingStarted/README.md) |
| 3.1 | **Első szerver** | Alap szerver felállítása az MCP protokollal, a szerver-kliens interakció megértése és a szerver tesztelése | [Első szerver](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Első kliens**  | Alap kliens létrehozása az MCP protokollal, a kliens-szerver kapcsolat megértése és a kliens tesztelése | [Első kliens](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Kliens LLM-mel**  | Kliens létrehozása MCP protokollal és Nagy Nyelvi Modellel (LLM) | [Kliens LLM-mel](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Szerver használata Visual Studio Code-dal** | Visual Studio Code beállítása MCP protokollal működő szerverekhez | [Szerver használata Visual Studio Code-dal](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Szerver létrehozása SSE-vel** | Az SSE segítségével szervert tehetünk elérhetővé az interneten. Ebben a részben egy SSE szerver létrehozását mutatjuk be | [Szerver létrehozása SSE-vel](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **AI Toolkit használata** | Az AI toolkit egy remek eszköz az AI és MCP munkafolyamatok kezeléséhez | [AI Toolkit használata](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Szerver tesztelése** | A tesztelés fontos része a fejlesztésnek. Ez a rész többféle eszköz használatában segít | [Szerver tesztelése](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Szerver élesítése** | Hogyan lehet a helyi fejlesztésből éles környezetbe lépni? Ez a rész segít a szerver fejlesztésében és élesítésében | [Szerver élesítése](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Gyakorlati megvalósítás** | SDK-k használata különböző nyelveken, hibakeresés, tesztelés, validálás, újrahasználható prompt sablonok és munkafolyamatok készítése | [Gyakorlati megvalósítás](./04-PracticalImplementation/README.md) |
| 05 | **Haladó témák az MCP-ben** | Többmodális AI munkafolyamatok és bővíthetőség, biztonságos skálázási stratégiák, MCP vállalati környezetben | [Haladó témák](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP OAuth2 demó** | OAuth2 hitelesítés megvalósítása MCP szervereken, beleértve a hozzáférési tokenek ellenőrzését, jogosultságok kezelését és biztonságos API végpontokat | [MCP OAuth2 demó](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.2 | **Webes keresés MCP-vel** | Webes keresési funkciók megvalósítása a Model Context Protocol segítségével, keresési lekérdezések feldolgozása, eredmények kezelése és kereső API-k integrálása | [Webes keresés MCP-vel](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Közösségi hozzájárulások** | Kód és dokumentáció hozzájárulása, együttműködés GitHubon, közösségi fejlesztések és visszajelzések | [Közösségi hozzájárulások](./06-CommunityContributions/README.md) |
| 07 | **Tapasztalatok a korai alkalmazásból** | Valós megvalósítások, mi működött jól, MCP alapú megoldások fejlesztése és élesítése, trendek és jövőbeli tervek | [Tapasztalatok](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Legjobb gyakorlatok az MCP-hez** | Teljesítményoptimalizálás, hibabiztos MCP rendszerek tervezése, tesztelési és ellenállóképességi stratégiák | [Legjobb gyakorlatok](./08-BestPractices/README.md) |
| 09 | **MCP esettanulmányok** | Mélyreható elemzések MCP megoldás architektúrákról, telepítési tervek és integrációs tippek, kommentált ábrák és projektbemutatók | [Esettanulmányok](./09-CaseStudy/README.md) |

## Minta projektek

### 🧮 MCP Számológép minta projektek:
<details>
  <summary><strong>Kódpéldák nyelvenként</strong></summary>

  - [C# MCP szerver példa](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP számológép](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP demó](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP szerver](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP példa](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP Haladó számológép projektek:
<details>
  <summary><strong>Haladó minták</strong></summary>

  - [Haladó C# példa](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java konténer alkalmazás példa](./04-PracticalImplementation/samples/java/containerapp/README.md)
- [JavaScript Advanced Sample](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Complex Implementation](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Sample](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Előfeltételek az MCP tanulásához

Ahhoz, hogy a legtöbbet hozd ki ebből a tananyagból, érdemes, ha rendelkezel:

- Alapvető ismeretek C#, Java vagy Python nyelvekből  
- Ügyfél-szerver modell és API-k megértése  
- (Opcionális) Gépi tanulási alapfogalmak ismerete  

## 🛠️ Hogyan használd hatékonyan ezt a tananyagot

Minden leckében megtalálod:

1. Az MCP fogalmak világos magyarázatát  
2. Élő kód példákat több nyelven  
3. Gyakorlatokat valódi MCP alkalmazások építéséhez  
4. Kiegészítő forrásokat haladó tanulók számára  

## 📜 Licenc információk

A tartalom az **MIT License** feltételei szerint érhető el. A részletes feltételeket a [LICENSE](../../LICENSE) fájlban találod.

## 🤝 Hozzájárulási irányelvek

Ez a projekt szívesen fogad hozzájárulásokat és javaslatokat. A legtöbb hozzájárulás esetén el kell fogadnod egy Contributor License Agreement (CLA) megállapodást, amelyben igazolod, hogy jogod van a hozzájárulásod felhasználására. Részletekért látogass el ide: <https://cla.opensource.microsoft.com>.

Amikor pull request-et nyújtasz be, egy CLA bot automatikusan megállapítja, hogy szükséges-e a CLA aláírása, és ennek megfelelően jelöli a PR-t (pl. státusz ellenőrzés, komment). Kövesd a bot utasításait. Ezt csak egyszer kell megtenned az összes, CLA-t használó repóban.

Ez a projekt elfogadta a [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/) irányelveit. További információért lásd a [Code of Conduct GYIK](https://opensource.microsoft.com/codeofconduct/faq/) oldalt, vagy írj az [opencode@microsoft.com](mailto:opencode@microsoft.com) címre kérdéseiddel vagy észrevételeiddel.

## 🎒 Egyéb tanfolyamok
Csapatunk további tanfolyamokat is készít! Nézd meg:

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


## ™️ Védjegyfigyelmeztetés

Ez a projekt tartalmazhat védjegyeket vagy logókat projektekhez, termékekhez vagy szolgáltatásokhoz. A Microsoft védjegyek vagy logók jogosult használata a [Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general) előírásai szerint történhet. A Microsoft védjegyek vagy logók módosított változatokban való használata nem okozhat félreértést, és nem sugallhat Microsoft támogatást. Harmadik fél védjegyeinek vagy logóinak használata a vonatkozó harmadik fél szabályzatok szerint történik.

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár az pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy félreértelmezésekért.