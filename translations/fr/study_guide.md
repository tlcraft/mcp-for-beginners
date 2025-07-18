<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e2c6ed897fa98fa08e0146101776c7ff",
  "translation_date": "2025-07-18T09:06:51+00:00",
  "source_file": "study_guide.md",
  "language_code": "fr"
}
-->
# Protocole de Contexte de Modèle (MCP) pour Débutants - Guide d’Étude

Ce guide d’étude offre un aperçu de la structure et du contenu du dépôt pour le programme « Protocole de Contexte de Modèle (MCP) pour Débutants ». Utilisez ce guide pour naviguer efficacement dans le dépôt et tirer le meilleur parti des ressources disponibles.

## Aperçu du Dépôt

Le Protocole de Contexte de Modèle (MCP) est un cadre standardisé pour les interactions entre les modèles d’IA et les applications clientes. Initialement créé par Anthropic, le MCP est désormais maintenu par la communauté MCP via l’organisation officielle GitHub. Ce dépôt propose un programme complet avec des exemples de code pratiques en C#, Java, JavaScript, Python et TypeScript, destiné aux développeurs IA, architectes systèmes et ingénieurs logiciels.

## Carte Visuelle du Programme

```mermaid
mindmap
  root((MCP for Beginners))
    00. Introduction
      ::icon(fa fa-book)
      (Protocol Overview)
      (Standardization Benefits)
      (Real-world Use Cases)
      (AI Integration Fundamentals)
    01. Core Concepts
      ::icon(fa fa-puzzle-piece)
      (Client-Server Architecture)
      (Protocol Components)
      (Messaging Patterns)
      (Transport Mechanisms)
    02. Security
      ::icon(fa fa-shield)
      (AI-Specific Threats)
      (Best Practices 2025)
      (Azure Content Safety)
      (Auth & Authorization)
      (Microsoft Prompt Shields)
    03. Getting Started
      ::icon(fa fa-rocket)
      (First Server Implementation)
      (Client Development)
      (LLM Client Integration)
      (VS Code Extensions)
      (SSE Server Setup)
      (HTTP Streaming)
      (AI Toolkit Integration)
      (Testing Frameworks)
      (Deployment Strategies)
    04. Practical Implementation
      ::icon(fa fa-code)
      (Multi-Language SDKs)
      (Testing & Debugging)
      (Prompt Templates)
      (Sample Projects)
      (Production Patterns)
    05. Advanced Topics
      ::icon(fa fa-graduation-cap)
      (Context Engineering)
      (Foundry Agent Integration)
      (Multi-modal AI Workflows)
      (OAuth2 Authentication)
      (Real-time Search)
      (Streaming Protocols)
      (Root Contexts)
      (Routing Strategies)
      (Sampling Techniques)
      (Scaling Solutions)
      (Security Hardening)
      (Entra ID Integration)
      (Web Search MCP)
      
    06. Community
      ::icon(fa fa-users)
      (Code Contributions)
      (Documentation)
      (MCP Client Ecosystem)
      (MCP Server Registry)
      (Image Generation Tools)
      (GitHub Collaboration)
    07. Early Adoption
      ::icon(fa fa-lightbulb)
      (Production Deployments)
      (Microsoft MCP Servers)
      (Azure MCP Service)
      (Enterprise Case Studies)
      (Future Roadmap)
    08. Best Practices
      ::icon(fa fa-check)
      (Performance Optimization)
      (Fault Tolerance)
      (System Resilience)
      (Monitoring & Observability)
    09. Case Studies
      ::icon(fa fa-file-text)
      (Azure API Management)
      (AI Travel Agent)
      (Azure DevOps Integration)
      (Documentation MCP)
      (Real-world Implementations)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (MCP Server Fundamentals)
      (Advanced Development)
      (AI Toolkit Integration)
      (Production Deployment)
      (4-Lab Structure)
```

## Structure du Dépôt

Le dépôt est organisé en dix sections principales, chacune abordant différents aspects du MCP :

1. **Introduction (00-Introduction/)**
   - Présentation du Protocole de Contexte de Modèle
   - Pourquoi la standardisation est importante dans les pipelines IA
   - Cas d’usage pratiques et avantages

2. **Concepts de Base (01-CoreConcepts/)**
   - Architecture client-serveur
   - Composants clés du protocole
   - Schémas de messagerie dans MCP

3. **Sécurité (02-Security/)**
   - Menaces de sécurité dans les systèmes basés sur MCP
   - Bonnes pratiques pour sécuriser les implémentations
   - Stratégies d’authentification et d’autorisation
   - **Documentation complète sur la sécurité** :
     - Meilleures pratiques de sécurité MCP 2025
     - Guide d’implémentation Azure Content Safety
     - Contrôles et techniques de sécurité MCP
     - Référence rapide des meilleures pratiques MCP
   - **Sujets clés en sécurité** :
     - Attaques par injection de prompt et empoisonnement d’outils
     - Détournement de session et problèmes de délégué confus
     - Vulnérabilités liées au passage de jetons
     - Permissions excessives et contrôle d’accès
     - Sécurité de la chaîne d’approvisionnement pour les composants IA
     - Intégration Microsoft Prompt Shields

4. **Premiers Pas (03-GettingStarted/)**
   - Configuration et préparation de l’environnement
   - Création de serveurs et clients MCP basiques
   - Intégration avec des applications existantes
   - Sections incluses pour :
     - Première implémentation de serveur
     - Développement client
     - Intégration client LLM
     - Intégration VS Code
     - Serveur Server-Sent Events (SSE)
     - Streaming HTTP
     - Intégration AI Toolkit
     - Stratégies de test
     - Directives de déploiement

5. **Implémentation Pratique (04-PracticalImplementation/)**
   - Utilisation des SDK dans différents langages
   - Techniques de débogage, test et validation
   - Création de modèles de prompt et workflows réutilisables
   - Projets exemples avec cas d’implémentation

6. **Sujets Avancés (05-AdvancedTopics/)**
   - Techniques d’ingénierie du contexte
   - Intégration de l’agent Foundry
   - Workflows IA multimodaux
   - Démos d’authentification OAuth2
   - Capacités de recherche en temps réel
   - Streaming en temps réel
   - Implémentation des contextes racines
   - Stratégies de routage
   - Techniques d’échantillonnage
   - Approches de montée en charge
   - Considérations de sécurité
   - Intégration sécurité Entra ID
   - Intégration recherche web

7. **Contributions Communautaires (06-CommunityContributions/)**
   - Comment contribuer au code et à la documentation
   - Collaboration via GitHub
   - Améliorations et retours communautaires
   - Utilisation de divers clients MCP (Claude Desktop, Cline, VSCode)
   - Travail avec des serveurs MCP populaires incluant la génération d’images

8. **Leçons des Premières Adoptions (07-LessonsfromEarlyAdoption/)**
   - Implémentations réelles et retours d’expérience
   - Construction et déploiement de solutions basées sur MCP
   - Tendances et feuille de route future
   - **Guide des serveurs Microsoft MCP** : Guide complet de 10 serveurs Microsoft MCP prêts pour la production, incluant :
     - Microsoft Learn Docs MCP Server
     - Azure MCP Server (plus de 15 connecteurs spécialisés)
     - GitHub MCP Server
     - Azure DevOps MCP Server
     - MarkItDown MCP Server
     - SQL Server MCP Server
     - Playwright MCP Server
     - Dev Box MCP Server
     - Azure AI Foundry MCP Server
     - Microsoft 365 Agents Toolkit MCP Server

9. **Bonnes Pratiques (08-BestPractices/)**
   - Optimisation des performances
   - Conception de systèmes MCP tolérants aux pannes
   - Stratégies de test et de résilience

10. **Études de Cas (09-CaseStudy/)**
    - Exemple d’intégration Azure API Management
    - Exemple d’implémentation pour agent de voyage
    - Intégration Azure DevOps avec mises à jour YouTube
    - Exemples d’implémentation MCP pour documentation
    - Exemples détaillés avec documentation complète

11. **Atelier Pratique (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - Atelier pratique complet combinant MCP et AI Toolkit
    - Création d’applications intelligentes reliant modèles IA et outils réels
    - Modules pratiques couvrant les fondamentaux, développement serveur personnalisé et stratégies de déploiement en production
    - **Structure du laboratoire** :
      - Lab 1 : Fondamentaux du serveur MCP
      - Lab 2 : Développement avancé de serveur MCP
      - Lab 3 : Intégration AI Toolkit
      - Lab 4 : Déploiement en production et montée en charge
    - Approche d’apprentissage par laboratoire avec instructions pas à pas

## Ressources Supplémentaires

Le dépôt inclut des ressources complémentaires :

- **Dossier Images** : Contient diagrammes et illustrations utilisés dans le programme
- **Traductions** : Support multilingue avec traductions automatiques de la documentation
- **Ressources Officielles MCP** :
  - [MCP Documentation](https://modelcontextprotocol.io/)
  - [MCP Specification](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## Comment Utiliser Ce Dépôt

1. **Apprentissage Séquentiel** : Suivez les chapitres dans l’ordre (de 00 à 10) pour une progression structurée.
2. **Focus Langage Spécifique** : Si vous êtes intéressé par un langage particulier, explorez les dossiers d’exemples pour des implémentations dans votre langage préféré.
3. **Implémentation Pratique** : Commencez par la section « Premiers Pas » pour configurer votre environnement et créer votre premier serveur et client MCP.
4. **Exploration Avancée** : Une fois les bases maîtrisées, plongez dans les sujets avancés pour approfondir vos connaissances.
5. **Engagement Communautaire** : Rejoignez la communauté MCP via les discussions GitHub et les canaux Discord pour échanger avec des experts et d’autres développeurs.

## Clients et Outils MCP

Le programme couvre divers clients et outils MCP :

1. **Clients Officiels** :
   - Visual Studio Code
   - MCP dans Visual Studio Code
   - Claude Desktop
   - Claude dans VSCode
   - Claude API

2. **Clients Communautaires** :
   - Cline (terminal)
   - Cursor (éditeur de code)
   - ChatMCP
   - Windsurf

3. **Outils de Gestion MCP** :
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## Serveurs MCP Populaires

Le dépôt présente plusieurs serveurs MCP, notamment :

1. **Serveurs Microsoft MCP Officiels** :
   - Microsoft Learn Docs MCP Server
   - Azure MCP Server (plus de 15 connecteurs spécialisés)
   - GitHub MCP Server
   - Azure DevOps MCP Server
   - MarkItDown MCP Server
   - SQL Server MCP Server
   - Playwright MCP Server
   - Dev Box MCP Server
   - Azure AI Foundry MCP Server
   - Microsoft 365 Agents Toolkit MCP Server

2. **Serveurs de Référence Officiels** :
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

3. **Génération d’Images** :
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

4. **Outils de Développement** :
   - Git MCP
   - Terminal Control
   - Code Assistant

5. **Serveurs Spécialisés** :
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## Contributions

Ce dépôt accueille les contributions de la communauté. Consultez la section Contributions Communautaires pour savoir comment contribuer efficacement à l’écosystème MCP.

## Journal des Modifications

| Date | Modifications |
|------|---------------|
| 18 juillet 2025 | - Mise à jour de la structure du dépôt pour inclure le Guide des serveurs Microsoft MCP<br>- Ajout d’une liste complète de 10 serveurs Microsoft MCP prêts pour la production<br>- Amélioration de la section Serveurs MCP Populaires avec les serveurs Microsoft officiels<br>- Mise à jour de la section Études de Cas avec des exemples de fichiers réels<br>- Ajout des détails sur la structure des laboratoires pour l’Atelier Pratique |
| 16 juillet 2025 | - Mise à jour de la structure du dépôt pour refléter le contenu actuel<br>- Ajout de la section Clients et Outils MCP<br>- Ajout de la section Serveurs MCP Populaires<br>- Mise à jour de la Carte Visuelle du Programme avec tous les sujets actuels<br>- Enrichissement de la section Sujets Avancés avec toutes les spécialités<br>- Mise à jour des Études de Cas avec des exemples concrets<br>- Clarification de l’origine du MCP créé par Anthropic |
| 11 juin 2025 | - Création initiale du guide d’étude<br>- Ajout de la Carte Visuelle du Programme<br>- Description de la structure du dépôt<br>- Inclusion de projets exemples et ressources supplémentaires |

---

*Ce guide d’étude a été mis à jour le 18 juillet 2025 et offre un aperçu du dépôt à cette date. Le contenu du dépôt peut être modifié après cette date.*

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.