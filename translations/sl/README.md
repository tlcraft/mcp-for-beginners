<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3ede7f051090bd4acfe5b068bab9f6b0",
  "translation_date": "2025-06-10T04:43:47+00:00",
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


Sledi tem korakom, da začneš uporabljati te vire:
1. **Razvej repozitorij**: Klikni [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Kloniraj repozitorij**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Pridruži se Azure AI Foundry Discordu in spoznaj strokovnjake ter druge razvijalce**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Podpora za več jezikov

#### Podprto preko GitHub Action (avtomatsko in vedno posodobljeno)

# 🚀 Model Context Protocol (MCP) Curriculum za začetnike

## **Nauči se MCP z praktičnimi primeri kode v C#, Java, JavaScript, Python in TypeScript**

## 🧠 Pregled kurikuluma Model Context Protocol

**Model Context Protocol (MCP)** je napreden okvir, zasnovan za standardizacijo interakcij med AI modeli in odjemalskimi aplikacijami. Ta odprtokodni kurikulum ponuja strukturirano učno pot, ki vključuje praktične primere kode in resnične primere uporabe v priljubljenih programskih jezikih, kot so C#, Java, JavaScript, TypeScript in Python.

Ne glede na to, ali ste AI razvijalec, sistemski arhitekt ali programski inženir, je ta vodič vaš celovit vir za obvladovanje osnov MCP in strategij implementacije.

## 🔗 Uradni MCP viri

- 📘 [MCP Dokumentacija](https://modelcontextprotocol.io/) – Podrobni vodiči in uporabniški priročniki  
- 📜 [MCP Specifikacija](https://spec.modelcontextprotocol.io/) – Arhitektura protokola in tehnične reference  
- 🧑‍💻 [MCP GitHub repozitorij](https://github.com/modelcontextprotocol) – Odprtokodni SDK-ji, orodja in primeri kode  

## 🧭 Celotna struktura kurikuluma MCP

| Ch | Naslov | Opis | Povezava |
|--|--|--|--|
| 00 | **Uvod v MCP** | Pregled Model Context Protocol in njegov pomen v AI procesih, vključno s tem, kaj je Model Context Protocol, zakaj je standardizacija pomembna ter praktični primeri uporabe in koristi | [Uvod](./00-Introduction/README.md) |
| 01 | **Razlaga osnovnih pojmov** | Podroben pregled osnovnih konceptov MCP, vključno z arhitekturo klient-strežnik, ključnimi komponentami protokola in vzorci sporočanja | [Osnovni pojmi](./01-CoreConcepts/README.md) |
| 02 | **Varnost v MCP** | Prepoznavanje varnostnih groženj v sistemih na osnovi MCP, tehnike in najboljše prakse za varno implementacijo | [Varnost](./02-Security/README.md) |
| 03 | **Začetek z MCP** | Nastavitev okolja in konfiguracija, ustvarjanje osnovnih MCP strežnikov in odjemalcev, integracija MCP z obstoječimi aplikacijami | [Začetek](./03-GettingStarted/README.md) |
| 3.1 | **Prvi strežnik** | Nastavitev osnovnega strežnika z uporabo MCP protokola, razumevanje interakcije strežnik-odjemalec in testiranje strežnika | [Prvi strežnik](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Prvi odjemalec** | Nastavitev osnovnega odjemalca z uporabo MCP protokola, razumevanje interakcije odjemalec-strežnik in testiranje odjemalca | [Prvi odjemalec](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Odjemalec z LLM** | Nastavitev odjemalca z uporabo MCP protokola in velikega jezikovnega modela (LLM) | [Odjemalec z LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Uporaba strežnika z Visual Studio Code** | Nastavitev Visual Studio Code za uporabo strežnikov preko MCP protokola | [Uporaba strežnika z Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Ustvarjanje strežnika z SSE** | SSE nam omogoča izpostavitev strežnika na internetu. Ta del vam bo pomagal ustvariti strežnik z uporabo SSE | [Ustvarjanje strežnika z SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Uporaba AI Toolkit** | AI toolkit je odlično orodje, ki vam pomaga upravljati vaš AI in MCP delovni tok. | [Uporaba AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Testiranje vašega strežnika** | Testiranje je pomemben del razvojnega procesa. Ta del vam bo pomagal testirati z uporabo različnih orodij. | [Testiranje vašega strežnika](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Implementacija strežnika** | Kako preiti iz lokalnega razvoja v produkcijo? Ta del vam bo pomagal razviti in implementirati vaš strežnik. | [Implementacija strežnika](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Praktična implementacija** | Uporaba SDK-jev v različnih jezikih, odpravljanje napak, testiranje in validacija, izdelava ponovno uporabnih predlog in delovnih tokov | [Praktična implementacija](./04-PracticalImplementation/README.md) |
| 05 | **Napredne teme v MCP** | Večmodalni AI delovni tokovi in razširljivost, varne strategije skaliranja, MCP v podjetniških ekosistemih | [Napredne teme](./05-AdvancedTopics/README.md) |
| 5.1 | **Integracija MCP z Azure** | Prikaz integracije z Azure | [Integracija MCP z Azure](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Večmodalnost** | Prikaz dela z različnimi modalitetami, kot so slike in druge | [Večmodalnost](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | Minimalna Spring Boot aplikacija, ki prikazuje OAuth2 z MCP, tako kot avtoriteta kot tudi strežnik virov. Demonstrira varno izdajo žetonov, zaščitene končne točke, implementacijo na Azure Container Apps in integracijo z API Management | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Več o root context in kako jih implementirati | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Spoznajte različne vrste usmerjanja | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Naučite se dela s samplingom | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skaliranje** | Spoznajte skaliranje MCP strežnikov, vključno s horizontalnimi in vertikalnimi strategijami, optimizacijo virov in nastavitvijo zmogljivosti | [Skaliranje](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Varnost** | Zavarujte svoj MCP strežnik, vključno z avtentikacijo, avtorizacijo in strategijami zaščite podatkov | [Varnost](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP strežnik in odjemalec, ki integrira SerpAPI za iskanje v realnem času po spletu, novicah, izdelkih in Q&A. Prikazuje orkestracijo več orodij, integracijo zunanjih API-jev in robustno obravnavo napak | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Prispevki skupnosti** | Kako prispevati k kodi in dokumentaciji, sodelovanje preko GitHub, izboljšave in povratne informacije, ki jih vodi skupnost | [Prispevki skupnosti](./06-CommunityContributions/README.md) |
| 07 | **Vpogledi iz zgodnjih implementacij** | Resnični primeri uporabe in kaj je delovalo, gradnja in implementacija rešitev na osnovi MCP, trendi in prihodnji načrti | [Vpogledi](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najboljše prakse za MCP** | Nastavitev zmogljivosti in optimizacija, načrtovanje odpornosti MCP sistemov, testiranje in strategije odpornosti | [Najboljše prakse](./08-BestPractices/README.md) |
| 09 | **MCP študije primerov** | Podrobni pregledi arhitektur MCP rešitev, načrti za implementacijo in nasveti za integracijo, z anotiranimi diagrami in predstavitvami projektov | [Študije primerov](./09-CaseStudy/README.md) |
| 10 | **AI Workflow සරල කිරීම: AI Toolkit සමඟ MCP සේවාදායකයක් සාදමු** | MCP සහ Microsoft's AI Toolkit for VS Code එකට එක් කරමින් පුළුල් අත්හදා බැලීමේ වැඩමුළුවක්. AI ආකෘති සහ සැබෑ ලෝක මෙවලම් අතර බිඳිමින් බුද්ධිමත් යෙදුම් ගොඩනගන්න ඉගෙන ගන්න, මූලික කරුණු, පරිශීලක සේවාදායක සංවර්ධනය, සහ නිෂ්පාදන යොදීමේ रणනීති ආවරණය කරන ප්‍රායෝගික කොටස් හරහා. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## නියැදි ව්‍යාපෘති

### 🧮 MCP ගණක නියැදි ව්‍යාපෘති:
<details>
  <summary><strong>භාෂා අනුව කේත ක්‍රියාත්මක කිරීම් සොයා බලන්න</strong></summary>

  - [C# MCP Server උදාහරණය](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Calculator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP ප්‍රදර්ශනය](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP උදාහරණය](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP දියුණු ගණක ව්‍යාපෘති:
<details>
  <summary><strong>දියුණු නියැදි සොයා බලන්න</strong></summary>

  - [දියුණු C# නියැදි](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container යෙදුම් උදාහරණය](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript දියුණු නියැදි](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python සංකීර්ණ ක්‍රියාත්මක කිරීම](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container නියැදි](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 MCP ඉගෙන ගැනීමට අවශ්‍ය පෙර අවශ්‍යතා

මෙම පාඨමාලාවෙන් උපරිම ප්‍රයෝජනය ගැනීමට, ඔබට තිබිය යුතුයි:

- C#, Java, හෝ Python මූලික දැනුම
- සේවාදායක-සේවාලාභී ආකෘතිය සහ API ගැන අවබෝධයක්
- (විකල්ප) යන්ත්‍ර ඉගෙනුම් මූලධර්ම සමඟ හුරුබුහුටි බව

## 🛠️ මෙම පාඨමාලාව කාර්යක්ෂමව භාවිතා කරන ආකාරය

මෙම මාර්ගෝපදේශයේ සෑම පාඩමකම ඇතුළත් කර ඇති දේ:

1. MCP සංකල්ප පැහැදිලි කිරීම  
2. බහු භාෂාවල සජීවී කේත උදාහරණ  
3. සැබෑ MCP යෙදුම් ගොඩනැඟීම සඳහා අභ්‍යාස  
4. දියුණු ඉගෙනුම්කරුවන් සඳහා අමතර සම්පත්  

## 📜 බලපත්‍ර තොරතුරු

මෙම අන්තර්ගතය **MIT බලපත්‍රය** යටතේ බලපත්‍ර ලත් වේ. කොන්දේසි සඳහා [LICENSE](../../LICENSE) බලන්න.

## 🤝 දායකත්ව මාර්ගෝපදේශ

මෙම ව්‍යාපෘතියට දායකත්ව සහ යෝජනා පිළිගනී. බොහෝ දායකත්ව සඳහා ඔබට Contributor License Agreement (CLA) එකකට එකඟ වීම අවශ්‍ය වේ, එහිදී ඔබට ඔබේ දායකත්වය භාවිතා කිරීමට අවසර ඇති බව සහතික කරයි. විස්තර සඳහා <https://cla.opensource.microsoft.com> වෙත පිවිසෙන්න.

ඔබ pull request එකක් ඉදිරිපත් කරන විට, CLA බොට් එක ස්වයංක්‍රීයව ඔබට CLA අවශ්‍යදැයි තීරණය කරයි සහ PR එකට අනුව අලංකාරකරණය කරයි (උදාහරණයක් ලෙස, තත්ව පරීක්ෂණයක්, අදහසක්). බොට් විසින් දෙන උපදෙස් පිළිපදින්න. ඔබට මෙය එක් වතාවක් පමණක් සියලු repos සඳහා සිදු කළ යුතුය.

මෙම ව්‍යාපෘතිය [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/) අනුගමනය කරයි. වැඩි විස්තර සඳහා [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) බලන්න හෝ අමතර ප්‍රශ්න හෝ අදහස් සඳහා [opencode@microsoft.com](mailto:opencode@microsoft.com) වෙත සම්බන්ධ වන්න.

## 🎒 වෙනත් පාඨමාලා
අපගේ කණ්ඩායම වෙනත් පාඨමාලාද නිපදවයි! බලන්න:

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


## ™️ වෙළඳ ලකුණු නිවේදනය

මෙම ව්‍යාපෘතියේ ව්‍යාපෘති, නිෂ්පාදන හෝ සේවාවන් සඳහා වෙළඳ ලකුණු හෝ ලාංඡන අඩංගු විය හැක. Microsoft වෙළඳ ලකුණු හෝ ලාංඡන භාවිතය Microsoft වෙළඳ ලකුණු සහ සන්නාම මාර්ගෝපදේශයන්ට අනුව විය යුතුය සහ ඒවා අනුගමනය කළ යුතුය. මෙම ව්‍යාපෘතියේ සංස්කරණවල Microsoft වෙළඳ ලකුණු හෝ ලාංඡන භාවිතය Microsoft අනුග්‍රහයක් ඇති බව හෝ ගැටුමක් ඇති බව පෙන්විය නොහැක. තෙවන පාර්ශව වෙළඳ ලකුණු හෝ ලාංඡන භාවිතය ඒ තෙවන පාර්ශවයන්ගේ ප්‍රතිපත්ති යටතේ සිදු වේ.

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.