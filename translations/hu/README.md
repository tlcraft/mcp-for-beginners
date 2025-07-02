<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "292f96c64f54ba097daea9598111ed82",
  "translation_date": "2025-07-02T05:44:56+00:00",
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


[![Microsoft Azure AI Foundry Discord](https://dcbadge.limes.pink/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)

Kövesd ezeket a lépéseket, hogy elkezdhess dolgozni ezekkel az erőforrásokkal:
1. **Forkold a tárolót**: Kattints ide [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Klónozd a tárolót**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Csatlakozz az Azure AI Foundry Discord szerverhez, és ismerkedj meg szakértőkkel és fejlesztőtársaiddal**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Többnyelvű támogatás

#### GitHub Action által támogatott (Automatizált és mindig naprakész)

# 🚀 Model Context Protocol (MCP) Tananyag Kezdőknek

## **Tanulj MCP-t gyakorlati kódpéldák segítségével C#, Java, JavaScript, Python és TypeScript nyelveken**

## 🧠 A Model Context Protocol tananyag áttekintése

A **Model Context Protocol (MCP)** egy élvonalbeli keretrendszer, amely az AI modellek és kliensalkalmazások közötti interakciók szabványosítására szolgál. Ez a nyílt forráskódú tananyag egy jól strukturált tanulási útvonalat kínál, gyakorlati kódpéldákkal és valós használati esetekkel, népszerű programozási nyelveken, mint a C#, Java, JavaScript, TypeScript és Python.

Legyél akár AI fejlesztő, rendszertervező vagy szoftvermérnök, ez az útmutató átfogó forrás az MCP alapjainak és megvalósítási stratégiáinak elsajátításához.

## 🔗 Hivatalos MCP források

- 📘 [MCP Dokumentáció](https://modelcontextprotocol.io/) – Részletes oktatóanyagok és felhasználói útmutatók  
- 📜 [MCP Specifikáció](https://spec.modelcontextprotocol.io/) – A protokoll felépítése és technikai hivatkozások  
- 🧑‍💻 [MCP GitHub tárhely](https://github.com/modelcontextprotocol) – Nyílt forráskódú SDK-k, eszközök és kódminták  

## 🧭 MCP tananyag áttekintése

### Model Context Protocol alapok  
<details>
  <summary><strong> 1-3. Lecke: Model Context Protocol alapok</strong></summary>

- **00. Bevezetés az MCP-be**  
  Áttekintés a Model Context Protocolról és jelentőségéről az AI folyamatokban. [Tovább](./00-Introduction/README.md)
- **01. Alapfogalmak magyarázata**  
  Mélyebb betekintés az MCP alapfogalmaiba. [Tovább](./01-CoreConcepts/README.md)
- **02. Biztonság az MCP-ben**  
  Biztonsági fenyegetések és legjobb gyakorlatok. [Tovább](./02-Security/README.md)
- **03. Első lépések az MCP-vel**  
  Környezet beállítása, alapvető szerverek/kliens, integráció. [Tovább](./03-GettingStarted/README.md)
</details>

### Első MCP szervered és kliensed felépítése és telepítése, valamint gyakorlati laborok és szcenáriók  
<details>
  <summary><strong> 3. Lecke: Első MCP szerver és kliens építése és telepítése</strong></summary>

- **3.1. Első szerver** – [Útmutató](./03-GettingStarted/01-first-server/README.md)
- **3.2. Első kliens** – [Útmutató](./03-GettingStarted/02-client/README.md)
- **3.3. Kliens LLM-mel** – [Útmutató](./03-GettingStarted/03-llm-client/README.md)
- **3.4. Szerver használata Visual Studio Code-dal** – [Útmutató](./03-GettingStarted/04-vscode/README.md)
- **3.5. Szerver létrehozása SSE-vel** – [Útmutató](./03-GettingStarted/05-sse-server/README.md)
- **3.6. HTTP streaming** – [Útmutató](./03-GettingStarted/06-http-streaming/README.md)
- **3.7. AI Toolkit használata** – [Útmutató](./03-GettingStarted/07-aitk/README.md)
- **3.8. Szerver tesztelése** – [Útmutató](./03-GettingStarted/08-testing/README.md)
- **3.9. Szerver telepítése** – [Útmutató](./03-GettingStarted/09-deployment/README.md)
</details>

### Model Context Protocol gyakorlati megvalósítások és haladó tartalom  
<details>
  <summary><strong> 4-5. Lecke: Gyakorlati és haladó témák</strong></summary>

- **04. Gyakorlati megvalósítás**  
  SDK-k, hibakeresés, tesztelés, újrahasználható prompt sablonok. [Tovább](./04-PracticalImplementation/README.md)
- **05. Haladó MCP témák**  
  Többmodalitású AI, skálázás, vállalati felhasználás. [Tovább](./05-AdvancedTopics/README.md)
- **5.1. MCP integráció Azure-ral** – [Útmutató](./05-AdvancedTopics/mcp-integration/README.md)
- **5.2. Többmodalitás** – [Útmutató](./05-AdvancedTopics/mcp-multi-modality/README.md)
- **5.3. MCP OAuth2 bemutató** – [Útmutató](./05-AdvancedTopics/mcp-oauth2-demo/README.md)
- **5.4. Root Context-ek** – [Útmutató](./05-AdvancedTopics/mcp-root-contexts/README.md)
- **5.5. Routing** – [Útmutató](./05-AdvancedTopics/mcp-routing/README.md)
- **5.6. Mintavételezés** – [Útmutató](./05-AdvancedTopics/mcp-sampling/README.md)
- **5.7. Skálázás** – [Útmutató](./05-AdvancedTopics/mcp-scaling/README.md)
- **5.8. Biztonság** – [Útmutató](./05-AdvancedTopics/mcp-security/README.md)
- **5.9. Webes keresés MCP-vel** – [Útmutató](./05-AdvancedTopics/web-search-mcp/README.md)
- **5.10. Valós idejű streaming** – [Útmutató](./05-AdvancedTopics/mcp-realtimestreaming/README.md)
- **5.11. Valós idejű webes keresés** – [Útmutató](./05-AdvancedTopics/mcp-realtimesearch/README.md)
- **5.12. Entra ID hitelesítés Model Context Protocol szerverekhez** – [Útmutató](./05-AdvancedTopics/mcp-security-entra/README.md)
</details>

### Model Context Protocol legjobb gyakorlatok  
<details>
  <summary><strong> 6-9. Lecke: Közösség, legjobb gyakorlatok és laborok</strong></summary>
- **06. Közösségi hozzájárulások** – [Útmutató](./06-CommunityContributions/README.md)
- **07. Tapasztalatok a korai alkalmazásból** – [Útmutató](./07-LessonsFromEarlyAdoption/README.md)
- **08. Legjobb gyakorlatok az MCP-hez** – [Útmutató](./08-BestPractices/README.md)
- **09. MCP esettanulmányok** – [Útmutató](./09-CaseStudy/README.md)
</details>

### Model Context Protocol gyakorlati labor AI Toolkit használatával VScode-hoz
<details>
  <summary><strong>10. Lecke: Gyakorlati labor MCP szerver építése AI Toolkit-tel VScode-hoz</strong></summary>
    
- **10. Az AI munkafolyamatok egyszerűsítése: MCP szerver építése AI Toolkit-tel** – [Gyakorlati labor](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)
</details>

## Model Context Protocol mintaprojektek MCP számológép projekt építése Java, C#, JavaScript, TypeScript és Python nyelveken

### 🧮 MCP számológép mintaprojektek Java, C#, JavaScript, TypeScript és Python nyelveken
<details>
  <summary><strong>Kódmegvalósítások nyelvenként</strong></summary>

  - [C# MCP szerver példa](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP számológép](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP demó](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP szerver](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP példa](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP fejlett példa megoldás: számológép projektek C#, Java, JavaScript, TypeScript és Python nyelveken
<details>
  <summary><strong>Fejlett minták felfedezése</strong></summary>

  - [Fejlett C# példa](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java konténer alkalmazás példa](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript fejlett példa](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python összetett megvalósítás](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript konténer példa](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 Az MCP tanulásának előfeltételei

Ahhoz, hogy a legtöbbet hozd ki ebből a tananyagból, érdemes rendelkezned:

- Alapvető ismeretek C#, Java vagy Python nyelvekből  
- A kliens-szerver modell és API-k megértése  
- (Opcionális) Gépi tanulási fogalmak ismerete  

## 📚 Tanulmányi útmutató

Egy átfogó [Tanulmányi útmutató](./study_guide.md) áll rendelkezésedre, amely segít hatékonyan eligazodni ebben a tárban. Az útmutató tartalmazza:

- Egy vizuális tantervtérképet az összes témakörrel  
- A tárhely egyes részeinek részletes bontását  
- Útmutatást a mintaprojektek használatához  
- Ajánlott tanulási útvonalakat különböző szintekhez  
- További forrásokat a tanulási folyamat támogatására  

## 🛠️ Hogyan használd hatékonyan ezt a tananyagot

Minden lecke tartalmaz:

1. Az MCP fogalmainak világos magyarázatát  
2. Élő kódpéldákat több nyelven  
3. Gyakorlatokat valódi MCP alkalmazások építéséhez  
4. Kiegészítő forrásokat haladó tanulók számára  

## 🌟 Közösségi köszönetnyilvánítás

Köszönet a Microsoft Valued Professional [Shivam Goyal](https://www.linkedin.com/in/shivam2003/)-nak a fontos kódmintákért.

## 📜 Licencinformációk

Ez a tartalom az **MIT Licenc** alatt áll. A feltételekért lásd a [LICENSE](../../LICENSE) fájlt.

## 🤝 Hozzájárulási irányelvek

Ez a projekt szívesen fogad hozzájárulásokat és javaslatokat. A legtöbb hozzájáruláshoz el kell fogadnod egy  
Contributor License Agreement (CLA) megállapodást, amely igazolja, hogy rendelkezel a jogokkal és ténylegesen átadod nekünk  
a hozzájárulásod használatának jogát. Részletekért látogass el ide: <https://cla.opensource.microsoft.com>.

Amikor pull request-et nyújtasz be, egy CLA bot automatikusan megállapítja, hogy szükséges-e CLA-t benyújtanod, és megfelelően jelöli a PR-t (pl. státusz ellenőrzés, komment). Csak kövesd a bot utasításait. Ezt csak egyszer kell megtenned az összes CLA-t használó tárhely esetén.

Ez a projekt elfogadta a [Microsoft nyílt forráskódú magatartási kódexét](https://opensource.microsoft.com/codeofconduct/).  
További információkért lásd a [Magatartási kódex GYIK](https://opensource.microsoft.com/codeofconduct/faq/) oldalt vagy lépj kapcsolatba az [opencode@microsoft.com](mailto:opencode@microsoft.com) címen további kérdésekkel vagy észrevételekkel.

## 🎒 Egyéb tanfolyamok  
Csapatunk más tanfolyamokat is készít! Nézd meg:

- [AI Agents kezdőknek](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)  
- [Generatív AI kezdőknek .NET használatával](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)  
- [Generatív AI kezdőknek JavaScript használatával](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)  
- [Generatív AI kezdőknek](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)  
- [Gépi tanulás kezdőknek](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)  
- [Adattudomány kezdőknek](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)  
- [AI kezdőknek](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)  
- [Kiberbiztonság kezdőknek](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)  
- [Webfejlesztés kezdőknek](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [IoT kezdőknek](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [XR fejlesztés kezdőknek](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [GitHub Copilot mesterfokon AI páros programozáshoz](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [GitHub Copilot mesterfokon C#/.NET fejlesztőknek](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Válaszd ki a saját Copilot kalandodat](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Védjegyértesítés

Ez a projekt tartalmazhat védjegyeket vagy logókat projektekhez, termékekhez vagy szolgáltatásokhoz. A Microsoft védjegyek vagy logók jogosult használata az alábbiak szerint történhet, és be kell tartania a
[Microsoft Védjegy- és Márkaútmutatóját](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
A Microsoft védjegyek vagy logók használata a projekt módosított verzióiban nem okozhat félreértést, és nem sugallhat Microsoft általi támogatást.
Harmadik fél védjegyeinek vagy logóinak bármilyen használata a harmadik felek irányelveinek megfelelően történik.

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordítószolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum a saját nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.