<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26ab12045ee411ab7ad0eb0b1b7b1cbb",
  "translation_date": "2025-06-13T01:23:00+00:00",
  "source_file": "README.md",
  "language_code": "sl"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.sl.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Následujte tyto kroky, abyste začali používat tyto zdroje:
1. **Vytvořte Fork repozitáře**: Klikněte na [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Naklonujte repozitář**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Připojte se k Azure AI Foundry Discordu a setkejte se s odborníky a dalšími vývojáři**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Podpora více jazyků

#### Podporováno přes GitHub Action (automatizováno a vždy aktuální)

# 🚀 Model Context Protocol (MCP) Curriculum for Beginners

## **Uči MCP s praktičnimi primeri kode v C#, Java, JavaScript, Python in TypeScript**

## 🧠 Pregled učnega načrta Model Context Protocol

**Model Context Protocol (MCP)** je najsodobnejši okvir, zasnovan za standardizacijo interakcij med AI modeli in odjemalskimi aplikacijami. Ta odprtokodni učni načrt ponuja strukturirano pot učenja, ki vključuje praktične primere kode in resnične primere uporabe v priljubljenih programskih jezikih, kot so C#, Java, JavaScript, TypeScript in Python.

Ne glede na to, ali ste AI razvijalec, sistemski arhitekt ali programski inženir, je ta vodič vaš celovit vir za obvladovanje osnov MCP in strategij njegove implementacije.

## 🔗 Uradni viri MCP

- 📘 [MCP Dokumentacija](https://modelcontextprotocol.io/) – Podrobni vodiči in uporabniški priročniki  
- 📜 [MCP Specifikacija](https://spec.modelcontextprotocol.io/) – Arhitektura protokola in tehnične reference  
- 🧑‍💻 [MCP GitHub repozitorij](https://github.com/modelcontextprotocol) – Odprtokodni SDK-ji, orodja in primeri kode  

## 🧭 Celotna struktura učnega načrta MCP

| Ch | Naslov | Opis | Povezava |
|--|--|--|--|
| 00 | **Uvod v MCP** | Pregled Model Context Protocol in njegovega pomena v AI procesih, vključno s tem, kaj je MCP, zakaj je standardizacija pomembna ter praktične uporabe in prednosti | [Uvod](./00-Introduction/README.md) |
| 01 | **Razlaga osnovnih konceptov** | Podroben pregled osnovnih konceptov MCP, vključno s klient-strežniško arhitekturo, ključnimi komponentami protokola in vzorci sporočanja | [Osnovni koncepti](./01-CoreConcepts/README.md) |
| 02 | **Varnost v MCP** | Prepoznavanje varnostnih groženj v sistemih na osnovi MCP, tehnike in najboljše prakse za varno implementacijo | [Varnost](./02-Security/README.md) |
| 03 | **Začetek dela z MCP** | Nastavitev okolja in konfiguracija, ustvarjanje osnovnih MCP strežnikov in klientov, integracija MCP v obstoječe aplikacije | [Začetek dela](./03-GettingStarted/README.md) |
| 3.1 | **Prvi strežnik** | Nastavitev osnovnega strežnika z uporabo MCP protokola, razumevanje interakcije med strežnikom in klientom ter testiranje strežnika | [Prvi strežnik](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Prvi klient**  | Nastavitev osnovnega klienta z uporabo MCP protokola, razumevanje interakcije med klientom in strežnikom ter testiranje klienta | [Prvi klient](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klient z LLM**  | Nastavitev klienta z uporabo MCP protokola in velikim jezikovnim modelom (LLM) | [Klient z LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Uporaba strežnika v Visual Studio Code** | Nastavitev Visual Studio Code za uporabo strežnikov preko MCP protokola | [Uporaba strežnika v Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Ustvarjanje strežnika z SSE** | SSE nam pomaga izpostaviti strežnik na internet. Ta del vas bo vodil pri ustvarjanju strežnika z SSE | [Ustvarjanje strežnika z SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Uporaba AI orodjarne** | AI orodjarna je odlično orodje, ki vam pomaga upravljati vaš AI in MCP delovni tok. | [Uporaba AI orodjarne](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Testiranje vašega strežnika** | Testiranje je pomemben del razvojnega procesa. Ta del vas bo naučil uporabljati več različnih orodij za testiranje. | [Testiranje vašega strežnika](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Implementacija strežnika** | Kako preiti iz lokalnega razvoja v produkcijo? Ta del vam bo pomagal razviti in implementirati strežnik. | [Implementacija strežnika](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Praktična implementacija** | Uporaba SDK-jev v različnih jezikih, odpravljanje napak, testiranje in validacija, ustvarjanje ponovno uporabnih predlog in delovnih tokov | [Praktična implementacija](./04-PracticalImplementation/README.md) |
| 05 | **Napredne teme v MCP** | Večmodalni AI delovni tokovi in razširljivost, varne strategije skaliranja, MCP v podjetniških okoljih | [Napredne teme](./05-AdvancedTopics/README.md) |
| 5.1 | **Integracija MCP z Azure** | Prikazuje integracijo z Azure | [Integracija MCP z Azure](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Večmodalnost** | Prikazuje delo z različnimi modalitetami, kot so slike in druge | [Večmodalnost](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | Minimalna Spring Boot aplikacija, ki prikazuje OAuth2 z MCP, tako kot avtoritativni kot tudi kot strežnik virov. Prikazuje varno izdajo žetonov, zaščitene končne točke, implementacijo v Azure Container Apps in integracijo API upravljanja. | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Več o root context in kako jih implementirati | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Usmerjanje** | Spoznajte različne vrste usmerjanja | [Usmerjanje](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Vzorčenje** | Naučite se, kako delati z vzorčenjem | [Vzorčenje](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skaliranje** | Spoznajte skaliranje MCP strežnikov, vključno s horizontalnimi in vertikalnimi strategijami, optimizacijo virov in prilagajanjem zmogljivosti | [Skaliranje](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Varnost** | Zavarujte svoj MCP strežnik, vključno z avtentikacijo, avtorizacijo in strategijami zaščite podatkov | [Varnost](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP strežnik in klient, ki integrirata SerpAPI za iskanje v spletu, novicah, izdelkih in Q&A v realnem času. Prikazuje orkestracijo več orodij, integracijo zunanjih API-jev in robustno ravnanje z napakami | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Pretakanje v realnem času** | Pretakanje podatkov v realnem času je danes ključno v svetu, ki temelji na podatkih, kjer podjetja in aplikacije potrebujejo takojšen dostop do informacij za pravočasne odločitve. | [Pretakanje v realnem času](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Iskanje v realnem času** | Kako MCP spreminja iskanje v realnem času z zagotavljanjem standardiziranega pristopa k upravljanju konteksta med AI modeli, iskalniki in aplikacijami. | [Iskanje v realnem času](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Prispevki skupnosti** | Kako prispevati k kodi in dokumentaciji, sodelovanje preko GitHub, izboljšave in povratne informacije skupnosti | [Prispevki skupnosti](./06-CommunityContributions/README.md) |
| 07 | **Vpogledi iz zgodnje uporabe** | Resnični primeri implementacij in kaj je delovalo, gradnja in uvajanje rešitev na osnovi MCP, trendi in prihodnja pot | [Vpogledi](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **MCP සඳහා හොඳම අභ්‍යාස** | කාර්යක්ෂමතාව වැඩිදියුණු කිරීම සහ සංවිධානය, දෝෂ-සහනය MCP පද්ධති සැලසුම් කිරීම, පරීක්ෂණ සහ සෘජුකරණ रणनीති | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP නඩු අධ්‍යයන** | MCP විසඳුම් ව්‍යුහ, යෙදුම් සැලැස්ම සහ ඒකාබද්ධ කිරීමේ උපදෙස්, සටහන් සහිත රූප සහ ව්‍යාපෘති සමාලෝචන | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **AI වැඩපිළිවෙළ සරල කිරීම: AI මෙවලම් සමඟ MCP සේවාදායකය ගොඩනැඟීම** | MCP හා Microsoft AI Toolkit for VS Code එකට එක් කරමින් සම්පූර්ණ අත්හදා බැලීමේ වැඩමුළුවක්. මූලික කරුණු, අභිරුචි සේවාදායක සංවර්ධනය සහ නිෂ්පාදන යෙදුම් සැලැස්ම ඇතුළත් ප්‍රායෝගික මොඩියුල හරහා බුද්ධිමත් යෙදුම් ගොඩනැඟීම ඉගෙන ගන්න. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## නියැදි ව්‍යාපෘති

### 🧮 MCP ගණක නියැදි ව්‍යාපෘති:
<details>
  <summary><strong>භාෂාව අනුව කේත ක්‍රියාත්මක කිරීම් විමසන්න</strong></summary>

  - [C# MCP සේවාදායක උදාහරණය](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP ගණකය](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP ප්‍රදර්ශනය](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP සේවාදායකය](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP උදාහරණය](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP උසස් ගණක ව්‍යාපෘති:
<details>
  <summary><strong>උසස් නියැදි විමසන්න</strong></summary>

  - [උසස් C# නියැදි](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java කොන්ටේනර් යෙදුම් උදාහරණය](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript උසස් නියැදි](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python සංකීර්ණ ක්‍රියාත්මක කිරීම](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript කොන්ටේනර් නියැදි](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 MCP ඉගෙනීමට අවශ්‍ය පෙර දැනුම

මෙම පාඨමාලාවෙන් හොඳම ප්‍රතිලාභ ලබා ගැනීමට, ඔබට තිබිය යුතුය:

- C#, Java, හෝ Python මූලික දැනුම  
- ගනුදෙනුකරු-සේවාදායක ආකෘතිය සහ API සම්බන්ධයෙන් අවබෝධය  
- (අවශ්‍යනම්) යන්ත්‍ර අධ්‍යයනයේ මූලික අදහස්

## 📚 අධ්‍යයන මාර්ගෝපදේශය

මෙම ගොනුවේ [අධ්‍යයන මාර්ගෝපදේශයක්](./study_guide.md) ඇත, ඔබට මෙම ගබඩාව කාර්යක්ෂමව පවත්වා ගැනීමට උපකාරී වේ. මාර්ගෝපදේශය අඩංගු කරයි:

- සෑම මාතෘකාවක්ම දැක්වෙන දෘශ්‍ය පාඨමාලා සිතියම  
- ගබඩාවේ එක් එක් කොටස පිළිබඳ විස්තරාත්මක විග්‍රහය  
- නියැදි ව්‍යාපෘති භාවිතා කිරීමේ මාර්ගෝපදේශ  
- විවිධ දක්ෂතා මට්ටම් සඳහා නිර්දේශිත ඉගෙනුම් මාර්ග  
- ඔබගේ ඉගෙනුම් ගමන සපුරාලීමට අමතර සම්පත්

## 🛠️ මෙම පාඨමාලාව කාර්යක්ෂමව භාවිතා කිරීම

මෙම මාර්ගෝපදෙශයේ සෑම පාඩමක්ම අඩංගු කරයි:

1. MCP අදහස් පැහැදිලි කිරීම  
2. බහු භාෂා වල සජීවී කේත උදාහරණ  
3. සැබෑ MCP යෙදුම් ගොඩනැඟීමට අභ්‍යාස  
4. උසස් ඉගෙනුම් සඳහා අමතර සම්පත්  

## 📜 බලපත්‍ර තොරතුරු

මෙම අන්තර්ගතය **MIT බලපත්‍රය** යටතේ බලපත්‍ර ලබා ඇත. කොන්දේසි සඳහා, [LICENSE](../../LICENSE) බලන්න.

## 🤝 දායකත්ව මාර්ගෝපදේශ

මෙම ව්‍යාපෘතියට දායකත්වය සහ යෝජනා සාදරයෙන් පිළිගනිමු. බොහෝ දායකත්ව සඳහා ඔබට Contributor License Agreement (CLA) එකට එකඟ වීම අවශ්‍ය වේ, එහිදී ඔබට ඔබේ දායකත්වය භාවිතා කිරීමට අයිතිය ඇති බව සහතික කරයි. විස්තර සඳහා, <https://cla.opensource.microsoft.com> වෙත පිවිසෙන්න.

ඔබ pull request එකක් ඉදිරිපත් කරන විට, CLA බොට් එක ඔබට CLA එක ඉදිරිපත් කළ යුතුදැයි ස්වයංක්‍රීයව තීරණය කර PR එකට අදාල සලකුණු (status check, comment) එක් කරයි. බොට් එක විසින් දෙන උපදෙස් පමණක් අනුගමනය කරන්න. ඔබට මෙය සියලු ගබඩා සඳහා එක් වතාවක් පමණක් කළ යුතුය.

මෙම ව්‍යාපෘතිය [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/) එක පිළිගෙන ඇත. වැඩි විස්තර සඳහා [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) හෝ [opencode@microsoft.com](mailto:opencode@microsoft.com) වෙත අමතන්න.

## 🎒 වෙනත් පාඨමාලා  
අපගේ කණ්ඩායම වෙනත් පාඨමාලාද නිෂ්පාදනය කරයි! බලන්න:

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


## ™️ Obvestilo o blagovni znamki

Ta projekt lahko vsebuje blagovne znamke ali logotipe za projekte, izdelke ali storitve. Pooblaščena uporaba Microsoftovih
blagovnih znamk ali logotipov je odvisna od in mora slediti
[Microsoftovim smernicam za uporabo blagovnih znamk in znamk](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Uporaba Microsoftovih blagovnih znamk ali logotipov v spremenjenih različicah tega projekta ne sme povzročiti zmede ali nakazovati sponzorstva Microsofta.
Vsaka uporaba blagovnih znamk ali logotipov tretjih oseb je odvisna od pravil teh tretjih oseb.

**Opozorilo**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Ne odgovarjamo za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.