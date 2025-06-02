<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "677cecb63a0bf6c0f49e40ffc15f6189",
  "translation_date": "2025-06-02T12:57:42+00:00",
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


Sledite tem korakom, da začnete uporabljati te vire:
1. **Razvezi repozitorij**: Kliknite [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Kloniraj repozitorij**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Pridruži se Azure AI Foundry Discordu in spoznaj strokovnjake ter druge razvijalce**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Podpora za več jezikov

#### Podprto preko GitHub Action (avtomatizirano in vedno posodobljeno)

# 🚀 Model Context Protocol (MCP) Curriculum za začetnike

## **Nauči se MCP z praktičnimi primeri kode v C#, Java, JavaScript, Python in TypeScript**

## 🧠 Pregled učnega načrta Model Context Protocol

**Model Context Protocol (MCP)** je napreden okvir, zasnovan za standardizacijo interakcij med AI modeli in odjemalskimi aplikacijami. Ta odprtokodni učni načrt ponuja strukturirano pot učenja, skupaj s praktičnimi primeri kode in resničnimi primeri uporabe v priljubljenih programskih jezikih, kot so C#, Java, JavaScript, TypeScript in Python.

Ne glede na to, ali ste AI razvijalec, sistemski arhitekt ali programski inženir, je ta vodič vaš celovit vir za obvladovanje osnov MCP in strategij za implementacijo.

## 🔗 Uradni viri MCP

- 📘 [MCP Dokumentacija](https://modelcontextprotocol.io/) – Podrobni vodiči in uporabniška navodila  
- 📜 [MCP Specifikacija](https://spec.modelcontextprotocol.io/) – Arhitektura protokola in tehnične reference  
- 🧑‍💻 [MCP GitHub Repozitorij](https://github.com/modelcontextprotocol) – Odprtokodni SDK-ji, orodja in primeri kode  

## 🧭 Celotna struktura učnega načrta MCP

| Poglavje | Naslov | Opis | Povezava |
|--|--|--|--|
| 00 | **Uvod v MCP** | Pregled Model Context Protocol in njegov pomen v AI procesih, vključno s tem, kaj je Model Context Protocol, zakaj je standardizacija pomembna ter praktični primeri uporabe in koristi | [Uvod](./00-Introduction/README.md) |
| 01 | **Razlaga osnovnih konceptov** | Podroben pregled osnovnih konceptov MCP, vključno z arhitekturo klient-strežnik, ključnimi komponentami protokola in vzorci sporočanja | [Osnovni koncepti](./01-CoreConcepts/README.md) |
| 02 | **Varnost v MCP** | Prepoznavanje varnostnih groženj v sistemih, ki temeljijo na MCP, tehnike in najboljše prakse za varno implementacijo | [Varnost](./02-Security/README.md) |
| 03 | **Začetek z MCP** | Nastavitev okolja in konfiguracija, ustvarjanje osnovnih MCP strežnikov in odjemalcev, integracija MCP z obstoječimi aplikacijami | [Začetek](./03-GettingStarted/README.md) |
| 3.1 | **Prvi strežnik** | Nastavitev osnovnega strežnika z uporabo MCP protokola, razumevanje interakcije med strežnikom in odjemalcem ter testiranje strežnika | [Prvi strežnik](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Prvi odjemalec** | Nastavitev osnovnega odjemalca z uporabo MCP protokola, razumevanje interakcije med odjemalcem in strežnikom ter testiranje odjemalca | [Prvi odjemalec](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Odjemalec z LLM** | Nastavitev odjemalca z uporabo MCP protokola in velikega jezikovnega modela (LLM) | [Odjemalec z LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Uporaba strežnika z Visual Studio Code** | Nastavitev Visual Studio Code za uporabo strežnikov prek MCP protokola | [Uporaba strežnika z Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Ustvarjanje strežnika s SSE** | SSE nam omogoča izpostavitev strežnika na internet. Ta del vas bo vodil pri ustvarjanju strežnika s SSE | [Ustvarjanje strežnika s SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Uporaba AI Toolkit** | AI toolkit je odlično orodje, ki vam pomaga upravljati vaš AI in MCP potek dela. | [Uporaba AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Testiranje vašega strežnika** | Testiranje je pomemben del razvojnega procesa. Ta del vam bo pomagal uporabiti različna orodja za testiranje. | [Testiranje vašega strežnika](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Implementacija strežnika** | Kako preiti iz lokalnega razvoja v produkcijo? Ta del vas bo vodil pri razvoju in implementaciji strežnika. | [Implementacija strežnika](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Praktična implementacija** | Uporaba SDK-jev v različnih jezikih, odpravljanje napak, testiranje in validacija, izdelava ponovno uporabnih predlog in potekov dela | [Praktična implementacija](./04-PracticalImplementation/README.md) |
| 05 | **Napredne teme v MCP** | Večmodalni AI poteki dela in razširljivost, varne strategije skaliranja, MCP v podjetniških ekosistemih | [Napredne teme](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP OAuth2 Demo** | Implementacija OAuth2 avtentikacije z MCP strežniki, vključno z validacijo dostopnih žetonov, avtorizacijo na podlagi obsega in zaščito varnih API končnih točk | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.2 | **Spletno iskanje z MCP** | Implementacija spletnih iskalnih funkcionalnosti z Model Context Protocol, vključno z obdelavo iskalnih poizvedb, upravljanjem rezultatov in integracijo z iskalnimi API-ji | [Spletno iskanje MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Prispevki skupnosti** | Kako prispevati k kodi in dokumentaciji, sodelovanje preko GitHub, izboljšave in povratne informacije, ki jih vodi skupnost | [Prispevki skupnosti](./06-CommunityContributions/README.md) |
| 07 | **Izkušnje zgodnjih uporabnikov** | Resnične implementacije in kaj je delovalo, gradnja in uvajanje rešitev na osnovi MCP, trendi in prihodnja smernica | [Izkušnje](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najboljše prakse za MCP** | Nastavitve zmogljivosti in optimizacija, načrtovanje odpornosti MCP sistemov, testiranje in strategije vzdržljivosti | [Najboljše prakse](./08-BestPractices/README.md) |
| 09 | **Primeri uporabe MCP** | Podrobne analize arhitektur MCP rešitev, načrti uvajanja in nasveti za integracijo, opremljeni diagrami in predstavitve projektov | [Primeri uporabe](./09-CaseStudy/README.md) |

## Primeri projektov

### 🧮 MCP kalkulator - primeri projektov:
<details>
  <summary><strong>Razišči primere kode po jezikih</strong></summary>

  - [C# MCP strežnik - primer](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP kalkulator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP strežnik](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP primer](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Napredni MCP kalkulator projekti:
<details>
  <summary><strong>Razišči napredne primere</strong></summary>

  - [Napredni C# primer](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container App primer](./04-PracticalImplementation/samples/java/containerapp/README.md)
- [JavaScript Advanced Sample](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Complex Implementation](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Sample](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 MCP ඉගෙනීමට අවශ්‍ය පෙර අවශ්‍යතා

මෙම පාඨමාලාවෙන් උපරිම ප්‍රයෝජනයක් ගන්න, ඔබට තිබිය යුතුය:

- C#, Java හෝ Python මූලික දැනුම
- client-server ආකෘතිය සහ APIs පිළිබඳ අවබෝධය
- (විකල්ප) යන්ත්‍ර ඉගෙනුම් සංකල්ප හඳුනා ගැනීම

## 🛠️ මෙම පාඨමාලාව කාර්යක්ෂමව භාවිතා කරන ආකාරය

මෙම මාර්ගෝපදේශයේ සෑම පාඩමකම අඩංගු වන්නේ:

1. MCP සංකල්ප පැහැදිලි කිරීම  
2. බහු භාෂා වල සජීවී කේත උදාහරණ  
3. යථාර්ථ MCP යෙදුම් නිර්මාණය සඳහා පුහුණු අභ්‍යාස  
4. උසස් අධ්‍යයන සඳහා අමතර සම්පත්  

## 📜 බලපත්‍ර තොරතුරු

මෙම අන්තර්ගතය **MIT License** යටතේ බලපත්‍ර ලැබී ඇත. නියමයන් සහ කොන්දේසි සඳහා, බලන්න [LICENSE](../../LICENSE).

## 🤝 දායකත්ව මාර්ගෝපදේශ

මෙම ව්‍යාපෘතිය දායකත්ව සහ යෝජනා පිළිගනී. බොහෝ දායකත්ව සඳහා, ඔබට Contributor License Agreement (CLA) එකකට එකඟ වීම අවශ්‍ය වේ, එයින් ඔබට ඔබේ දායකත්වය භාවිතා කිරීමේ අයිතිය ඇති බව සහතික කිරීම සිදු වේ. විස්තර සඳහා, <https://cla.opensource.microsoft.com> වෙත පිවිසෙන්න.

ඔබ pull request එකක් ඉදිරිපත් කරන විට, CLA bot එක ඔබට CLA එකක් අවශ්‍යදැයි ස්වයංක්‍රීයව තීරණය කර, PR එකට අදාළ සලකුණු (උදා: තත්ත්ව පරීක්ෂණය, අදහස) එකතු කරයි. bot එක විසින් දෙන උපදෙස් පිළිපදින්න. අපගේ CLA භාවිතා කරන සියලුම repos සඳහා ඔබට මෙය එක්වරක් පමණි සිදු කිරීමට සිදු වන්නේ.

මෙම ව්‍යාපෘතිය [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/) අනුගමනය කරයි. වැඩි විස්තර සඳහා [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) බලන්න හෝ [opencode@microsoft.com](mailto:opencode@microsoft.com) වෙත අමතන්න.

## 🎒 අනෙක් පාඨමාලා
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


## ™️ වෙළඳ ලකුණු දැනුම්දීම

මෙම ව්‍යාපෘතියේ ව්‍යාපෘති, නිෂ්පාදන හෝ සේවාවන් සඳහා වෙළඳ ලකුණු හෝ ලාංඡන අඩංගු විය හැක. Microsoft වෙළඳ ලකුණු හෝ ලාංඡන භාවිතය Microsoft හි වෙළඳ ලකුණු සහ වෙළඳ නාම මාර්ගෝපදේශයන්ට (https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general) අනුකූලව සිදු කළ යුතුය. Microsoft වෙළඳ ලකුණු හෝ ලාංඡන වෙනස් කරන ලද අනුවාද වල භාවිතය Microsoft ආධාරකත්වය හෝ ගැටුමක් ඇති කර නොවිය යුතුය. තෙවන පාර්ශව වෙළඳ ලකුණු හෝ ලාංඡන භාවිතය එම පාර්ශවයන්ගේ ප්‍රතිපත්ති යටතේ පවති.

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za prevajanje z umetno inteligenco [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v izvorni jezik velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.