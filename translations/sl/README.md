<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4458d89100952180348d8775b149295e",
  "translation_date": "2025-06-02T19:39:12+00:00",
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
1. **Razvejite repozitorij**: Kliknite [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Klonirajte repozitorij**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Pridružite se Azure AI Foundry Discordu in spoznajte strokovnjake ter druge razvijalce**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Podpora za več jezikov

#### Podprto preko GitHub Action (avtomatizirano in vedno posodobljeno)

# 🚀 Model Context Protocol (MCP) Curriculum for Beginners

## **Uči MCP z praktičnimi primeri kode v C#, Java, JavaScript, Python in TypeScript**

## 🧠 Pregled učnega načrta Model Context Protocol

**Model Context Protocol (MCP)** je sodoben okvir, zasnovan za standardizacijo interakcij med AI modeli in odjemalskimi aplikacijami. Ta odprtokodni učni načrt ponuja strukturirano pot učenja, vključno s praktičnimi primeri kode in resničnimi primeri uporabe v priljubljenih programskih jezikih, kot so C#, Java, JavaScript, TypeScript in Python.

Ne glede na to, ali ste razvijalec AI, sistemski arhitekt ali programski inženir, je ta vodič vaš celovit vir za obvladovanje osnov MCP in strategij implementacije.

## 🔗 Uradni MCP viri

- 📘 [MCP Dokumentacija](https://modelcontextprotocol.io/) – Podrobni vodiči in uporabniški priročniki  
- 📜 [MCP Specifikacija](https://spec.modelcontextprotocol.io/) – Arhitektura protokola in tehnične reference  
- 🧑‍💻 [MCP GitHub Repozitorij](https://github.com/modelcontextprotocol) – Odprtokodni SDK-ji, orodja in primeri kode  

## 🧭 Celotna struktura učnega načrta MCP

| Ch | Naslov | Opis | Povezava |
|--|--|--|--|
| 00 | **Uvod v MCP** | Pregled Model Context Protocol in njegovega pomena v AI procesih, vključno s tem, kaj je Model Context Protocol, zakaj je standardizacija pomembna ter praktični primeri in koristi | [Uvod](./00-Introduction/README.md) |
| 01 | **Razlaga osnovnih konceptov** | Poglobljen pregled osnovnih konceptov MCP, vključno s klient-strežniško arhitekturo, ključnimi komponentami protokola in vzorci sporočanja | [Osnovni koncepti](./01-CoreConcepts/README.md) |
| 02 | **Varnost v MCP** | Prepoznavanje varnostnih groženj v sistemih, ki temeljijo na MCP, tehnike in najboljše prakse za varno implementacijo | [Varnost](./02-Security/README.md) |
| 03 | **Začetek z MCP** | Nastavitev okolja in konfiguracija, ustvarjanje osnovnih MCP strežnikov in klientov, integracija MCP z obstoječimi aplikacijami | [Začetek](./03-GettingStarted/README.md) |
| 3.1 | **Prvi strežnik** | Nastavitev osnovnega strežnika z uporabo MCP protokola, razumevanje interakcije med strežnikom in klientom ter testiranje strežnika | [Prvi strežnik](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Prvi klient** | Nastavitev osnovnega klienta z uporabo MCP protokola, razumevanje interakcije med klientom in strežnikom ter testiranje klienta | [Prvi klient](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klient z LLM** | Nastavitev klienta z uporabo MCP protokola in velikega jezikovnega modela (LLM) | [Klient z LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Uporaba strežnika z Visual Studio Code** | Nastavitev Visual Studio Code za uporabo strežnikov prek MCP protokola | [Uporaba strežnika z Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Ustvarjanje strežnika s SSE** | SSE nam pomaga izpostaviti strežnik na internet. Ta razdelek vam bo pomagal ustvariti strežnik s SSE | [Ustvarjanje strežnika s SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Uporaba AI Toolkit** | AI toolkit je odlično orodje, ki vam pomaga upravljati vaš AI in MCP potek dela. | [Uporaba AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Testiranje vašega strežnika** | Testiranje je pomemben del razvojnega procesa. Ta razdelek vam bo pomagal preizkusiti strežnik z različnimi orodji. | [Testiranje vašega strežnika](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Namestitev strežnika** | Kako preiti iz lokalnega razvoja v produkcijo? Ta razdelek vam bo pomagal razviti in namestiti vaš strežnik. | [Namestitev strežnika](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Praktična implementacija** | Uporaba SDK-jev v različnih jezikih, odpravljanje napak, testiranje in validacija, izdelava ponovno uporabnih predlog in potekov dela | [Praktična implementacija](./04-PracticalImplementation/README.md) |
| 05 | **Napredne teme v MCP** | Večmodalni AI poteki dela in razširljivost, varne strategije skaliranja, MCP v podjetniških okoljih | [Napredne teme](./05-AdvancedTopics/README.md) |
| 5.1 | **Integracija MCP z Azure** | Prikaz integracije z Azure | [Integracija MCP z Azure](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Večmodalnost** | Prikaz dela z različnimi modalitetami, kot so slike in drugo | [Večmodalnost](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | Minimalna Spring Boot aplikacija, ki prikazuje OAuth2 z MCP, tako kot avtentikacijski kot tudi strežnik virov. Prikazuje varno izdajo žetonov, zaščitene končne točke, namestitev v Azure Container Apps in integracijo API Management. | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Več o root context in kako jih implementirati | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Usmerjanje** | Spoznajte različne vrste usmerjanja | [Usmerjanje](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Vzorcevanje** | Naučite se dela z vzorčevanjem | [Vzorcevanje](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skaliranje** | Spoznajte skaliranje MCP strežnikov, vključno s horizontalnimi in vertikalnimi strategijami, optimizacijo virov in nastavitvijo zmogljivosti | [Skaliranje](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Varnost** | Zavarujte svoj MCP strežnik, vključno z avtentikacijo, avtorizacijo in strategijami zaščite podatkov | [Varnost](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP strežnik in klient, ki integrirata SerpAPI za iskanje po spletu, novicah, izdelkih in Q&A v realnem času. Prikazuje večorodno orkestracijo, integracijo zunanjih API-jev in robustno ravnanje z napakami | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Prispevki skupnosti** | Kako prispevati k kodi in dokumentaciji, sodelovanje prek GitHub, izboljšave in povratne informacije, ki jih vodi skupnost | [Prispevki skupnosti](./06-CommunityContributions/README.md) |
| 07 | **Izkušnje zgodnjih uporabnikov** | Resnične implementacije in kaj je delovalo, gradnja in nameščanje rešitev na osnovi MCP, trendi in prihodnji načrt | [Izkušnje](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Najboljše prakse za MCP** | Nastavitev zmogljivosti in optimizacija, načrtovanje odpornih MCP sistemov, testiranje in strategije odpornosti | [Najboljše prakse](./08-BestPractices/README.md) |
| 09 | **MCP študije primerov** | Poglobljeni pregledi arhitektur MCP rešitev, načrti namestitev in nasveti za integracijo, označeni diagrami in predstavitve projektov | [Študije primerov](./09-CaseStudy/README.md) |

## Vzorčni projekti

### 🧮 MCP Kalkulator vzorčni projekti:
<details>
  <summary><strong>Raziskuj implementacije kode po jezikih</strong></summary>
- [C# MCP Server Udaharan](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Calculator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP Udaharan](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP Advanced Calculator Pariyojana:
<details>
  <summary><strong>Vistaarit Udaharan Khojo</strong></summary>

  - [Advanced C# Udaharan](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container App Udaharan](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript Advanced Udaharan](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Complex Implementation](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Udaharan](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 MCP Sikhne Ke Liye Zaruri Baatein

Is curriculum se poora fayda uthane ke liye, aapko hona chahiye:

- C#, Java, ya Python ki basic jaankari
- Client-server model aur APIs ki samajh
- (Optional) Machine learning ke concepts ki parichay

## 🛠️ Is Curriculum Kaise Prabhavit Roop Se Use Karen

Is guide ke har lesson mein shamil hain:

1. MCP concepts ki spasht vyakhya  
2. Kai bhashao mein live code udaharan  
3. Real MCP applications banane ke liye exercises  
4. Advanced learners ke liye extra resources  

## 📜 License Ki Jankari

Yeh samagri **MIT License** ke antargat licensed hai. Terms aur conditions ke liye dekhein [LICENSE](../../LICENSE).

## 🤝 Yogdan Nirdesh

Yeh project yogdan aur sujhavon ka swagat karta hai. Adhikansh yogdan ke liye aapko Contributor License Agreement (CLA) se sahmati deni hoti hai, jisme aap batate hain ki aapke paas apne yogdan ke adhikar hain aur aap humein un adhikaron ka upyog karne ka adhikar dete hain. Vivaran ke liye, yahan dekhein: <https://cla.opensource.microsoft.com>.

Jab aap pull request bhejte hain, ek CLA bot svatah tai karta hai ki aapko CLA dena zaruri hai ya nahi, aur PR par uske anuroop suchna deta hai (jaise status check, comment). Bas bot ke diye gaye nirdeshon ka palan karein. Yeh prakriya aapko sabhi repos mein sirf ek baar karni hoti hai jo hamara CLA istemal karte hain.

Is project ne [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/) ko apnaya hai. Adhik jankari ke liye dekhein [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) ya sampark karein [opencode@microsoft.com](mailto:opencode@microsoft.com) kisi bhi anya prashn ya tipanni ke liye.

## 🎒 Anya Courses
Hamari team anya courses bhi banati hai! Jaanch karein:

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


## ™️ Trademark Suchna

Is project mein kuch projects, products, ya services ke trademarks ya logos ho sakte hain. Microsoft ke trademarks ya logos ka adhikarik upyog [Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general) ke anusaar hi kiya jana chahiye. Microsoft ke trademarks ya logos ka sanshodhit roop mein istemal kisi bhi prakaar se bhranti nahi paida karna chahiye ya Microsoft ki sponsorship ka sanket nahi dena chahiye. Teesre paksh ke trademarks ya logos ka upyog unke niyamon ke anusar hota hai.

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za prevajanje z umetno inteligenco [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v izvorni jezik je treba obravnavati kot avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.