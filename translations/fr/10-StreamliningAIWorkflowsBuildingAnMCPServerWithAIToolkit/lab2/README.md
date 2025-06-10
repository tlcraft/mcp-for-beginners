<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a22b7dd11cd7690f99f9195877cafdc3",
  "translation_date": "2025-06-10T05:34:23+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab2/README.md",
  "language_code": "fr"
}
-->
# 🌐 Module 2 : Fondamentaux de MCP avec AI Toolkit

[![Durée](https://img.shields.io/badge/Duration-20%20minutes-blue.svg)]()
[![Difficulté](https://img.shields.io/badge/Difficulty-Intermediate-yellow.svg)]()
[![Prérequis](https://img.shields.io/badge/Prerequisites-Module%201%20Complete-orange.svg)]()

## 📋 Objectifs d’apprentissage

À la fin de ce module, vous serez capable de :
- ✅ Comprendre l’architecture et les avantages du Model Context Protocol (MCP)
- ✅ Explorer l’écosystème des serveurs MCP de Microsoft
- ✅ Intégrer les serveurs MCP avec AI Toolkit Agent Builder
- ✅ Créer un agent d’automatisation de navigateur fonctionnel avec Playwright MCP
- ✅ Configurer et tester les outils MCP dans vos agents
- ✅ Exporter et déployer des agents propulsés par MCP pour la production

## 🎯 Suite du Module 1

Dans le Module 1, nous avons maîtrisé les bases d’AI Toolkit et créé notre premier Agent Python. Maintenant, nous allons **booster** vos agents en les connectant à des outils et services externes via le révolutionnaire **Model Context Protocol (MCP)**.

Imaginez cela comme passer d’une simple calculatrice à un ordinateur complet – vos agents IA pourront désormais :
- 🌐 Naviguer et interagir avec des sites web
- 📁 Accéder et manipuler des fichiers
- 🔧 S’intégrer aux systèmes d’entreprise
- 📊 Traiter des données en temps réel via des API

## 🧠 Comprendre le Model Context Protocol (MCP)

### 🔍 Qu’est-ce que le MCP ?

Le Model Context Protocol (MCP) est le **« USB-C des applications IA »** – un standard ouvert révolutionnaire qui connecte les Large Language Models (LLM) à des outils externes, sources de données et services. Tout comme l’USB-C a mis fin au chaos des câbles en offrant un connecteur universel, MCP simplifie l’intégration IA avec un protocole standardisé unique.

### 🎯 Le problème que résout MCP

**Avant MCP :**
- 🔧 Intégrations personnalisées pour chaque outil
- 🔄 Verrouillage fournisseur avec des solutions propriétaires
- 🔒 Vulnérabilités de sécurité dues à des connexions ad hoc
- ⏱️ Des mois de développement pour des intégrations basiques

**Avec MCP :**
- ⚡ Intégration d’outils plug-and-play
- 🔄 Architecture indépendante des fournisseurs
- 🛡️ Meilleures pratiques de sécurité intégrées
- 🚀 Ajout de nouvelles fonctionnalités en quelques minutes

### 🏗️ Architecture MCP en détail

MCP suit une **architecture client-serveur** qui crée un écosystème sécurisé et évolutif :

```mermaid
graph TB
    A[AI Application/Agent] --> B[MCP Client]
    B --> C[MCP Server 1: Files]
    B --> D[MCP Server 2: Web APIs]
    B --> E[MCP Server 3: Database]
    B --> F[MCP Server N: Custom Tools]
    
    C --> G[Local File System]
    D --> H[External APIs]
    E --> I[Database Systems]
    F --> J[Enterprise Systems]
```

**🔧 Composants principaux :**

| Composant | Rôle | Exemples |
|-----------|------|----------|
| **MCP Hosts** | Applications consommant les services MCP | Claude Desktop, VS Code, AI Toolkit |
| **MCP Clients** | Gestionnaires du protocole (1:1 avec les serveurs) | Intégrés aux applications hôtes |
| **MCP Servers** | Exposent des fonctionnalités via un protocole standard | Playwright, Files, Azure, GitHub |
| **Couche de transport** | Méthodes de communication | stdio, HTTP, WebSockets |


## 🏢 Écosystème des serveurs MCP de Microsoft

Microsoft est à la pointe de l’écosystème MCP avec une suite complète de serveurs de niveau entreprise répondant aux besoins réels des entreprises.

### 🌟 Serveurs MCP Microsoft phares

#### 1. ☁️ Azure MCP Server  
**🔗 Repository** : [azure/azure-mcp](https://github.com/azure/azure-mcp)  
**🎯 Objectif** : Gestion complète des ressources Azure avec intégration IA

**✨ Fonctionnalités clés :**  
- Provisionnement d’infrastructure déclaratif  
- Surveillance des ressources en temps réel  
- Recommandations d’optimisation des coûts  
- Vérification de conformité en matière de sécurité

**🚀 Cas d’usage :**  
- Infrastructure-as-Code assistée par IA  
- Mise à l’échelle automatisée des ressources  
- Optimisation des coûts cloud  
- Automatisation des workflows DevOps

#### 2. 📊 Microsoft Dataverse MCP  
**📚 Documentation** : [Microsoft Dataverse Integration](https://go.microsoft.com/fwlink/?linkid=2320176)  
**🎯 Objectif** : Interface en langage naturel pour les données métier

**✨ Fonctionnalités clés :**  
- Requêtes en langage naturel sur base de données  
- Compréhension du contexte métier  
- Modèles de prompts personnalisés  
- Gouvernance des données d’entreprise

**🚀 Cas d’usage :**  
- Reporting business intelligence  
- Analyse des données clients  
- Insights sur le pipeline de ventes  
- Requêtes de conformité

#### 3. 🌐 Playwright MCP Server  
**🔗 Repository** : [microsoft/playwright-mcp](https://github.com/microsoft/playwright-mcp)  
**🎯 Objectif** : Automatisation de navigateur et interaction web

**✨ Fonctionnalités clés :**  
- Automatisation multi-navigateurs (Chrome, Firefox, Safari)  
- Détection intelligente des éléments  
- Capture d’écran et génération PDF  
- Surveillance du trafic réseau

**🚀 Cas d’usage :**  
- Workflows de tests automatisés  
- Web scraping et extraction de données  
- Monitoring UI/UX  
- Automatisation d’analyse concurrentielle

#### 4. 📁 Files MCP Server  
**🔗 Repository** : [microsoft/files-mcp-server](https://github.com/microsoft/files-mcp-server)  
**🎯 Objectif** : Opérations intelligentes sur le système de fichiers

**✨ Fonctionnalités clés :**  
- Gestion déclarative des fichiers  
- Synchronisation de contenu  
- Intégration contrôle de version  
- Extraction de métadonnées

**🚀 Cas d’usage :**  
- Gestion documentaire  
- Organisation de dépôts de code  
- Workflows de publication de contenu  
- Gestion des fichiers dans les pipelines de données

#### 5. 📝 MarkItDown MCP Server  
**🔗 Repository** : [microsoft/markitdown](https://github.com/microsoft/markitdown)  
**🎯 Objectif** : Traitement avancé et manipulation Markdown

**✨ Fonctionnalités clés :**  
- Parsing avancé Markdown  
- Conversion de formats (MD ↔ HTML ↔ PDF)  
- Analyse de la structure du contenu  
- Traitement de templates

**🚀 Cas d’usage :**  
- Workflows de documentation technique  
- Systèmes de gestion de contenu  
- Génération de rapports  
- Automatisation de bases de connaissances

#### 6. 📈 Clarity MCP Server  
**📦 Package** : [@microsoft/clarity-mcp-server](https://www.npmjs.com/package/@microsoft/clarity-mcp-server)  
**🎯 Objectif** : Analyse web et insights sur le comportement utilisateur

**✨ Fonctionnalités clés :**  
- Analyse de cartes de chaleur  
- Enregistrements de sessions utilisateurs  
- Mesures de performance  
- Analyse des tunnels de conversion

**🚀 Cas d’usage :**  
- Optimisation de sites web  
- Recherche sur l’expérience utilisateur  
- Analyse A/B testing  
- Tableaux de bord business intelligence

### 🌍 Écosystème communautaire

Au-delà des serveurs Microsoft, l’écosystème MCP comprend :  
- **🐙 GitHub MCP** : Gestion de dépôts et analyse de code  
- **🗄️ MCP Bases de données** : Intégrations PostgreSQL, MySQL, MongoDB  
- **☁️ MCP fournisseurs cloud** : Outils AWS, GCP, Digital Ocean  
- **📧 MCP communications** : Intégrations Slack, Teams, Email

## 🛠️ Atelier pratique : Créer un agent d’automatisation de navigateur

**🎯 Objectif du projet** : Créer un agent intelligent d’automatisation de navigateur avec Playwright MCP capable de naviguer sur des sites, extraire des informations et réaliser des interactions web complexes.

### 🚀 Phase 1 : Mise en place de la base de l’agent

#### Étape 1 : Initialiser votre agent  
1. **Ouvrir AI Toolkit Agent Builder**  
2. **Créer un nouvel agent** avec la configuration suivante :  
   - **Nom** : `BrowserAgent`
   - **Model**: Choose GPT-4o 

![BrowserAgent](../../../../translated_images/BrowserAgent.09c1adde5e136573b64ab1baecd830049830e295eac66cb18bebb85fb386e00a.fr.png)


### 🔧 Phase 2: MCP Integration Workflow

#### Step 3: Add MCP Server Integration
1. **Navigate to Tools Section** in Agent Builder
2. **Click "Add Tool"** to open the integration menu
3. **Select "MCP Server"** from available options

![AddMCP](../../../../translated_images/AddMCP.afe3308ac20aa94469a5717b632d77b2197b9838a438b05d39aeb2db3ec47ef1.fr.png)

**🔍 Understanding Tool Types:**
- **Built-in Tools**: Pre-configured AI Toolkit functions
- **MCP Servers**: External service integrations
- **Custom APIs**: Your own service endpoints
- **Function Calling**: Direct model function access

#### Step 4: MCP Server Selection
1. **Choose "MCP Server"** option to proceed
![AddMCPServer](../../../../translated_images/AddMCPServer.69b911ccef872cbd0d0c0c2e6a00806916e1673e543b902a23dee23e6ff54b4c.fr.png)

2. **Browse MCP Catalog** to explore available integrations
![MCPCatalog](../../../../translated_images/MCPCatalog.a817d053145699006264f5a475f2b48fbd744e43633f656b6453c15a09ba5130.fr.png)


### 🎮 Phase 3: Playwright MCP Configuration

#### Step 5: Select and Configure Playwright
1. **Click "Use Featured MCP Servers"** to access Microsoft's verified servers
2. **Select "Playwright"** from the featured list
3. **Accept Default MCP ID** or customize for your environment

![MCPID](../../../../translated_images/MCPID.67d446052979e819c945ff7b6430196ef587f5217daadd3ca52fa9659c1245c9.fr.png)

#### Step 6: Enable Playwright Capabilities
**🔑 Critical Step**: Select **ALL** available Playwright methods for maximum functionality

![Tools](../../../../translated_images/Tools.3ea23c447b4d9feccbd7101e6dcf9e27cb0e5273f351995fde62c5abf9a78b4c.fr.png)

**🛠️ Essential Playwright Tools:**
- **Navigation**: `goto`, `goBack`, `goForward`, `reload`
- **Interaction**: `click`, `fill`, `press`, `hover`, `drag`
- **Extraction**: `textContent`, `innerHTML`, `getAttribute`
- **Validation**: `isVisible`, `isEnabled`, `waitForSelector`
- **Capture**: `screenshot`, `pdf`, `video`
- **Network**: `setExtraHTTPHeaders`, `route`, `waitForResponse`

#### Étape 7 : Vérifier la réussite de l’intégration  
**✅ Indicateurs de succès :**  
- Tous les outils apparaissent dans l’interface Agent Builder  
- Aucune erreur dans le panneau d’intégration  
- Le statut du serveur Playwright indique « Connected »

![AgentTools](../../../../translated_images/AgentTools.053cfb96a17e02199dcc6563010d2b324d4fc3ebdd24889657a6950647a52f63.fr.png)

**🔧 Résolution des problèmes courants :**  
- **Échec de connexion** : Vérifiez la connexion internet et les paramètres du pare-feu  
- **Outils manquants** : Assurez-vous que toutes les capacités ont été sélectionnées lors de la configuration  
- **Erreurs de permission** : Vérifiez que VS Code dispose des autorisations système nécessaires

### 🎯 Phase 4 : Ingénierie avancée des prompts

#### Étape 8 : Concevoir des prompts système intelligents  
Créez des prompts sophistiqués exploitant toutes les capacités de Playwright :

```markdown
# Web Automation Expert System Prompt

## Core Identity
You are an advanced web automation specialist with deep expertise in browser automation, web scraping, and user experience analysis. You have access to Playwright tools for comprehensive browser control.

## Capabilities & Approach
### Navigation Strategy
- Always start with screenshots to understand page layout
- Use semantic selectors (text content, labels) when possible
- Implement wait strategies for dynamic content
- Handle single-page applications (SPAs) effectively

### Error Handling
- Retry failed operations with exponential backoff
- Provide clear error descriptions and solutions
- Suggest alternative approaches when primary methods fail
- Always capture diagnostic screenshots on errors

### Data Extraction
- Extract structured data in JSON format when possible
- Provide confidence scores for extracted information
- Validate data completeness and accuracy
- Handle pagination and infinite scroll scenarios

### Reporting
- Include step-by-step execution logs
- Provide before/after screenshots for verification
- Suggest optimizations and alternative approaches
- Document any limitations or edge cases encountered

## Ethical Guidelines
- Respect robots.txt and rate limiting
- Avoid overloading target servers
- Only extract publicly available information
- Follow website terms of service
```

#### Étape 9 : Créer des prompts utilisateurs dynamiques  
Concevez des prompts démontrant diverses fonctionnalités :

**🌐 Exemple d’analyse web :**  
```markdown
Navigate to github.com/kinfey and provide a comprehensive analysis including:
1. Repository structure and organization
2. Recent activity and contribution patterns  
3. Documentation quality assessment
4. Technology stack identification
5. Community engagement metrics
6. Notable projects and their purposes

Include screenshots at key steps and provide actionable insights.
```

![Prompt](../../../../translated_images/Prompt.bfc846605db4999f4d9c1b09c710ef63cae7b3057444e68bf07240fb142d9f8f.fr.png)

### 🚀 Phase 5 : Exécution et tests

#### Étape 10 : Exécuter votre première automatisation  
1. **Cliquez sur « Run »** pour lancer la séquence d’automatisation  
2. **Surveillez l’exécution en temps réel** :  
   - Le navigateur Chrome se lance automatiquement  
   - L’agent navigue vers le site cible  
   - Des captures d’écran sont prises à chaque étape majeure  
   - Les résultats d’analyse sont diffusés en temps réel

![Browser](../../../../translated_images/Browser.ec011d0bd64d0d112c8a29bd8cc44c76d0bbfd0b019cb2983ef679328435ce5d.fr.png)

#### Étape 11 : Analyser les résultats et insights  
Consultez l’analyse complète dans l’interface Agent Builder :

![Result](../../../../translated_images/Result.8638f2b6703e9ea6d58d4e4475e39456b6a51d4c787f9bf481bae694d370a69a.fr.png)

### 🌟 Phase 6 : Fonctionnalités avancées et déploiement

#### Étape 12 : Exporter et déployer en production  
Agent Builder prend en charge plusieurs options de déploiement :

![Code](../../../../translated_images/Code.d9eeeead0b96db0ca19c5b10ad64cfea8c1d0d1736584262970a4d43e1403d13.fr.png)

## 🎓 Résumé du Module 2 & prochaines étapes

### 🏆 Succès débloqué : Maîtrise de l’intégration MCP

**✅ Compétences acquises :**  
- [ ] Comprendre l’architecture et les bénéfices du MCP  
- [ ] Naviguer dans l’écosystème des serveurs MCP de Microsoft  
- [ ] Intégrer Playwright MCP avec AI Toolkit  
- [ ] Construire des agents d’automatisation de navigateur sophistiqués  
- [ ] Ingénierie avancée des prompts pour l’automatisation web

### 📚 Ressources supplémentaires

- **🔗 Spécification MCP** : [Documentation officielle du protocole](https://modelcontextprotocol.io/)  
- **🛠️ API Playwright** : [Référence complète des méthodes](https://playwright.dev/docs/api/class-playwright)  
- **🏢 Serveurs MCP Microsoft** : [Guide d’intégration entreprise](https://github.com/microsoft/mcp-servers)  
- **🌍 Exemples communautaires** : [Galerie des serveurs MCP](https://github.com/modelcontextprotocol/servers)

**🎉 Félicitations !** Vous avez maîtrisé l’intégration MCP et pouvez désormais créer des agents IA prêts pour la production avec des capacités d’outils externes !

### 🔜 Poursuivez vers le module suivant

Prêt à approfondir vos compétences MCP ? Passez au **[Module 3 : Développement avancé MCP avec AI Toolkit](../lab3/README.md)** où vous apprendrez à :  
- Créer vos propres serveurs MCP personnalisés  
- Configurer et utiliser le dernier SDK MCP Python  
- Installer MCP Inspector pour le débogage  
- Maîtriser les workflows avancés de développement de serveurs MCP  
- Construire un Weather MCP Server from scratch

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour des informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous ne saurions être tenus responsables des malentendus ou des interprétations erronées résultant de l’utilisation de cette traduction.