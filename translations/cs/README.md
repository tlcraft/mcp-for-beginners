<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4458d89100952180348d8775b149295e",
  "translation_date": "2025-06-02T19:28:16+00:00",
  "source_file": "README.md",
  "language_code": "cs"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.cs.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Sigue estos pasos para comenzar a usar estos recursos:
1. **Haz un Fork del Repositorio**: Haz clic en [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Clona el Repositorio**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Únete al Discord de Azure AI Foundry y conecta con expertos y otros desarrolladores**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Soporte Multilenguaje

#### Compatible mediante GitHub Action (Automatizado y siempre actualizado)

# 🚀 Curriculum du protocole de contexte de modèle (MCP) pour débutants

## **Apprenez le MCP avec des exemples de code pratiques en C#, Java, JavaScript, Python et TypeScript**

## 🧠 Aperçu du curriculum du protocole de contexte de modèle

Le **Model Context Protocol (MCP)** est un cadre innovant conçu pour standardiser les interactions entre les modèles d'IA et les applications clientes. Ce curriculum open-source propose un parcours d'apprentissage structuré, avec des exemples de code pratiques et des cas d'utilisation réels, dans plusieurs langages populaires comme C#, Java, JavaScript, TypeScript et Python.

Que vous soyez développeur IA, architecte système ou ingénieur logiciel, ce guide est votre ressource complète pour maîtriser les fondamentaux et les stratégies d’implémentation du MCP.

## 🔗 Ressources officielles MCP

- 📘 [Documentation MCP](https://modelcontextprotocol.io/) – Tutoriels détaillés et guides utilisateurs  
- 📜 [Spécification MCP](https://spec.modelcontextprotocol.io/) – Architecture du protocole et références techniques  
- 🧑‍💻 [Dépôt GitHub MCP](https://github.com/modelcontextprotocol) – SDKs open-source, outils et exemples de code  

## 🧭 Structure complète du curriculum MCP

| Ch | Titre | Description | Lien |
|--|--|--|--|
| 00 | **Introduction au MCP** | Vue d'ensemble du protocole de contexte de modèle et de son importance dans les pipelines IA, incluant ce qu’est le MCP, pourquoi la standardisation est essentielle, ainsi que des cas d’usage et avantages concrets | [Introduction](./00-Introduction/README.md) |
| 01 | **Concepts clés expliqués** | Exploration approfondie des concepts fondamentaux du MCP, incluant l’architecture client-serveur, les composants clés du protocole, et les schémas de messagerie | [Concepts clés](./01-CoreConcepts/README.md) |
| 02 | **Sécurité dans le MCP** | Identification des menaces de sécurité dans les systèmes basés sur MCP, techniques et bonnes pratiques pour sécuriser les implémentations | [Sécurité](./02-Security/README.md) |
| 03 | **Premiers pas avec MCP** | Configuration de l’environnement, création de serveurs et clients MCP basiques, intégration du MCP dans des applications existantes | [Premiers pas](./03-GettingStarted/README.md) |
| 3.1 | **Premier serveur** | Mise en place d’un serveur basique utilisant le protocole MCP, compréhension de l’interaction serveur-client, et tests du serveur | [Premier serveur](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Premier client**  | Mise en place d’un client basique utilisant le protocole MCP, compréhension de l’interaction client-serveur, et tests du client | [Premier client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Client avec LLM**  | Mise en place d’un client utilisant le protocole MCP avec un Large Language Model (LLM) | [Client avec LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Consommer un serveur avec Visual Studio Code** | Configuration de Visual Studio Code pour consommer des serveurs via le protocole MCP | [Consommer un serveur avec Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Créer un serveur avec SSE** | SSE nous permet d’exposer un serveur sur Internet. Cette section vous guide pour créer un serveur avec SSE | [Créer un serveur avec SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Utiliser AI Toolkit** | AI Toolkit est un excellent outil pour gérer votre flux de travail IA et MCP | [Utiliser AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Tester votre serveur** | Les tests sont une étape cruciale du développement. Cette section vous aide à utiliser plusieurs outils de test | [Tester votre serveur](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Déployer votre serveur** | Comment passer du développement local à la production ? Cette section vous accompagne dans le développement et le déploiement de votre serveur | [Déployer votre serveur](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Implémentation pratique** | Utilisation des SDKs dans différents langages, débogage, tests et validation, création de modèles de prompts et workflows réutilisables | [Implémentation pratique](./04-PracticalImplementation/README.md) |
| 05 | **Sujets avancés dans MCP** | Workflows IA multimodaux et extensibilité, stratégies de montée en charge sécurisée, MCP dans les écosystèmes d’entreprise | [Sujets avancés](./05-AdvancedTopics/README.md) |
| 5.1 | **Intégration MCP avec Azure** | Présentation de l’intégration avec Azure | [Intégration MCP Azure](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Multimodalité** | Présentation du travail avec différentes modalités comme les images et plus | [Multimodalité](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **Démo MCP OAuth2** | Application Spring Boot minimaliste montrant OAuth2 avec MCP, à la fois comme serveur d’autorisation et serveur de ressources. Démonstration de l’émission sécurisée de tokens, des endpoints protégés, du déploiement Azure Container Apps, et de l’intégration API Management | [Démo MCP OAuth2](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Contexts racines** | En savoir plus sur les contexts racines et leur implémentation | [Contexts racines](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routage** | Apprendre les différents types de routage | [Routage](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Échantillonnage** | Apprendre à travailler avec l’échantillonnage | [Échantillonnage](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Montée en charge** | Apprendre à scaler les serveurs MCP, incluant stratégies horizontales et verticales, optimisation des ressources, et tuning des performances | [Montée en charge](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Sécurité** | Sécuriser votre serveur MCP, incluant authentification, autorisation, et stratégies de protection des données | [Sécurité](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Recherche web MCP** | Serveur et client MCP en Python intégrant SerpAPI pour la recherche web, actualités, produits, et Q&A en temps réel. Démonstration d’orchestration multi-outils, intégration d’API externes, et gestion robuste des erreurs | [Recherche web MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Contributions communautaires** | Comment contribuer au code et à la documentation, collaboration via GitHub, améliorations et retours communautaires | [Contributions communautaires](./06-CommunityContributions/README.md) |
| 07 | **Retours d’expérience des premiers utilisateurs** | Implémentations réelles et ce qui a fonctionné, construction et déploiement de solutions basées sur MCP, tendances et feuille de route future | [Retours d’expérience](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Bonnes pratiques pour MCP** | Optimisation des performances, conception de systèmes MCP tolérants aux pannes, stratégies de tests et de résilience | [Bonnes pratiques](./08-BestPractices/README.md) |
| 09 | **Études de cas MCP** | Analyses approfondies des architectures de solutions MCP, plans de déploiement et conseils d’intégration, diagrammes annotés et walkthroughs de projets | [Études de cas](./09-CaseStudy/README.md) |

## Projets d’exemple

### 🧮 Projets d’exemple MCP Calculator :
<details>
  <summary><strong>Explorez les implémentations de code par langage</strong></summary>
- [C# MCP Server Example](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Calculator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP Example](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP Advanced Calculator Projects:
<details>
  <summary><strong>Explore Advanced Samples</strong></summary>

  - [Advanced C# Sample](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container App Example](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript Advanced Sample](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Complex Implementation](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Sample](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Prerequisites for Learning MCP

To get the most out of this curriculum, you should have:

- Basic knowledge of C#, Java, or Python
- Understanding of client-server model and APIs
- (Optional) Familiarity with machine learning concepts

## 🛠️ How to Use This Curriculum Effectively

Each lesson in this guide includes:

1. Clear explanations of MCP concepts  
2. Live code examples in multiple languages  
3. Exercises to build real MCP applications  
4. Extra resources for advanced learners  

## 📜 License Information

This content is licensed under the **MIT License**. For terms and conditions, see the [LICENSE](../../LICENSE).

## 🤝 Contribution Guidelines

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit <https://cla.opensource.microsoft.com>.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## 🎒 Other Courses
Our team produces other courses! Check out:

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


## ™️ Trademark Notice

This project may contain trademarks or logos for projects, products, or services. Authorized use of Microsoft
trademarks or logos is subject to and must follow
[Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Use of Microsoft trademarks or logos in modified versions of this project must not cause confusion or imply Microsoft sponsorship.
Any use of third-party trademarks or logos is subject to those third-parties' policies.

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.