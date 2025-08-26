<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T10:51:11+00:00",
  "source_file": "changelog.md",
  "language_code": "fr"
}
-->
# Journal des modifications : Curriculum MCP pour débutants

Ce document sert de registre pour toutes les modifications significatives apportées au curriculum du Model Context Protocol (MCP) pour débutants. Les changements sont documentés dans un ordre chronologique inversé (les plus récents en premier).

## 18 août 2025

### Mise à jour complète de la documentation - Normes MCP 2025-06-18

#### Bonnes pratiques de sécurité MCP (02-Security/) - Modernisation complète
- **MCP-SECURITY-BEST-PRACTICES-2025.md** : Réécriture complète alignée avec la spécification MCP 2025-06-18
  - **Exigences obligatoires** : Ajout explicite des exigences MUST/MUST NOT de la spécification officielle avec des indicateurs visuels clairs
  - **12 pratiques de sécurité essentielles** : Restructuration d'une liste de 15 éléments en domaines de sécurité complets
    - Sécurité des jetons et authentification avec intégration d'un fournisseur d'identité externe
    - Gestion des sessions et sécurité des transports avec exigences cryptographiques
    - Protection contre les menaces spécifiques à l'IA avec intégration de Microsoft Prompt Shields
    - Contrôle d'accès et permissions selon le principe du moindre privilège
    - Sécurité et surveillance des contenus avec intégration d'Azure Content Safety
    - Sécurité de la chaîne d'approvisionnement avec vérification complète des composants
    - Sécurité OAuth et prévention des attaques de type "Confused Deputy" avec implémentation PKCE
    - Réponse aux incidents et récupération avec capacités automatisées
    - Conformité et gouvernance alignées sur les réglementations
    - Contrôles de sécurité avancés avec architecture Zero Trust
    - Intégration de l'écosystème de sécurité Microsoft avec solutions complètes
    - Évolution continue de la sécurité avec pratiques adaptatives
  - **Solutions de sécurité Microsoft** : Guide d'intégration amélioré pour Prompt Shields, Azure Content Safety, Entra ID et GitHub Advanced Security
  - **Ressources d'implémentation** : Liens de ressources complets catégorisés par documentation officielle MCP, solutions de sécurité Microsoft, normes de sécurité et guides d'implémentation

#### Contrôles de sécurité avancés (02-Security/) - Implémentation en entreprise
- **MCP-SECURITY-CONTROLS-2025.md** : Refonte complète avec un cadre de sécurité de niveau entreprise
  - **9 domaines de sécurité complets** : Passé de contrôles de base à un cadre détaillé pour les entreprises
    - Authentification et autorisation avancées avec intégration de Microsoft Entra ID
    - Sécurité des jetons et contrôles anti-passage avec validation complète
    - Contrôles de sécurité des sessions avec prévention des détournements
    - Contrôles de sécurité spécifiques à l'IA avec prévention des injections de prompts et empoisonnement des outils
    - Prévention des attaques de type "Confused Deputy" avec sécurité proxy OAuth
    - Sécurité de l'exécution des outils avec sandboxing et isolation
    - Contrôles de sécurité de la chaîne d'approvisionnement avec vérification des dépendances
    - Contrôles de surveillance et détection avec intégration SIEM
    - Réponse aux incidents et récupération avec capacités automatisées
  - **Exemples d'implémentation** : Ajout de blocs de configuration YAML détaillés et d'exemples de code
  - **Intégration des solutions Microsoft** : Couverture complète des services de sécurité Azure, GitHub Advanced Security et gestion des identités en entreprise

#### Sécurité des sujets avancés (05-AdvancedTopics/mcp-security/) - Implémentation prête pour la production
- **README.md** : Réécriture complète pour l'implémentation de la sécurité en entreprise
  - **Alignement avec la spécification actuelle** : Mise à jour selon la spécification MCP 2025-06-18 avec exigences de sécurité obligatoires
  - **Authentification améliorée** : Intégration de Microsoft Entra ID avec exemples complets en .NET et Java Spring Security
  - **Intégration de la sécurité IA** : Implémentation de Microsoft Prompt Shields et Azure Content Safety avec exemples détaillés en Python
  - **Atténuation avancée des menaces** : Exemples d'implémentation complets pour
    - Prévention des attaques de type "Confused Deputy" avec PKCE et validation du consentement utilisateur
    - Prévention du passage de jetons avec validation des audiences et gestion sécurisée des jetons
    - Prévention des détournements de session avec liaison cryptographique et analyse comportementale
  - **Intégration de la sécurité en entreprise** : Surveillance avec Azure Application Insights, pipelines de détection des menaces et sécurité de la chaîne d'approvisionnement
  - **Liste de contrôle d'implémentation** : Contrôles de sécurité obligatoires vs recommandés avec avantages de l'écosystème de sécurité Microsoft

### Qualité de la documentation et alignement sur les normes
- **Références aux spécifications** : Mise à jour de toutes les références à la spécification MCP actuelle 2025-06-18
- **Écosystème de sécurité Microsoft** : Guide d'intégration amélioré dans toute la documentation de sécurité
- **Implémentation pratique** : Ajout d'exemples de code détaillés en .NET, Java et Python avec modèles d'entreprise
- **Organisation des ressources** : Catégorisation complète de la documentation officielle, des normes de sécurité et des guides d'implémentation
- **Indicateurs visuels** : Marquage clair des exigences obligatoires vs pratiques recommandées

#### Concepts de base (01-CoreConcepts/) - Modernisation complète
- **Mise à jour de la version du protocole** : Références mises à jour à la spécification MCP actuelle 2025-06-18 avec versionnement basé sur la date (format AAAA-MM-JJ)
- **Affinement de l'architecture** : Descriptions améliorées des hôtes, clients et serveurs pour refléter les modèles d'architecture MCP actuels
  - Hôtes désormais clairement définis comme des applications IA coordonnant plusieurs connexions client MCP
  - Clients décrits comme des connecteurs de protocole maintenant des relations serveur un-à-un
  - Serveurs enrichis avec scénarios de déploiement local vs distant
- **Restructuration des primitives** : Refonte complète des primitives serveur et client
  - Primitives serveur : Ressources (sources de données), Prompts (modèles), Outils (fonctions exécutables) avec explications et exemples détaillés
  - Primitives client : Échantillonnage (complétions LLM), Élicitation (entrée utilisateur), Journalisation (débogage/surveillance)
  - Mise à jour avec les modèles actuels de découverte (`*/list`), récupération (`*/get`) et exécution (`*/call`)
- **Architecture du protocole** : Introduction d'un modèle d'architecture à deux couches
  - Couche de données : Fondation JSON-RPC 2.0 avec gestion du cycle de vie et primitives
  - Couche de transport : STDIO (local) et HTTP avec SSE (distant)
- **Cadre de sécurité** : Principes de sécurité complets incluant consentement explicite de l'utilisateur, protection de la confidentialité des données, sécurité de l'exécution des outils et sécurité de la couche de transport
- **Modèles de communication** : Mise à jour des messages du protocole pour montrer les flux d'initialisation, de découverte, d'exécution et de notification
- **Exemples de code** : Exemples multilingues actualisés (.NET, Java, Python, JavaScript) reflétant les modèles actuels du SDK MCP

#### Sécurité (02-Security/) - Refonte complète de la sécurité  
- **Alignement sur les normes** : Alignement complet avec les exigences de sécurité de la spécification MCP 2025-06-18
- **Évolution de l'authentification** : Documentation de l'évolution des serveurs OAuth personnalisés vers la délégation à des fournisseurs d'identité externes (Microsoft Entra ID)
- **Analyse des menaces spécifiques à l'IA** : Couverture améliorée des vecteurs d'attaque modernes liés à l'IA
  - Scénarios détaillés d'attaques par injection de prompts avec exemples réels
  - Mécanismes d'empoisonnement des outils et modèles d'attaques "rug pull"
  - Empoisonnement des fenêtres contextuelles et attaques de confusion des modèles
- **Solutions de sécurité IA Microsoft** : Couverture complète de l'écosystème de sécurité Microsoft
  - Prompt Shields IA avec détection avancée, mise en évidence et techniques de délimitation
  - Modèles d'intégration Azure Content Safety
  - GitHub Advanced Security pour la protection de la chaîne d'approvisionnement
- **Atténuation avancée des menaces** : Contrôles de sécurité détaillés pour
  - Détournement de session avec scénarios d'attaque spécifiques à MCP et exigences cryptographiques pour les ID de session
  - Problèmes de type "Confused Deputy" dans les scénarios proxy MCP avec exigences explicites de consentement
  - Vulnérabilités de passage de jetons avec contrôles de validation obligatoires
- **Sécurité de la chaîne d'approvisionnement** : Couverture élargie de la chaîne d'approvisionnement IA incluant modèles de base, services d'embeddings, fournisseurs de contexte et API tierces
- **Sécurité de base** : Intégration renforcée avec des modèles de sécurité d'entreprise incluant l'architecture Zero Trust et l'écosystème de sécurité Microsoft
- **Organisation des ressources** : Liens de ressources complets catégorisés par type (Docs officiels, Normes, Recherche, Solutions Microsoft, Guides d'implémentation)

### Améliorations de la qualité de la documentation
- **Objectifs d'apprentissage structurés** : Objectifs d'apprentissage améliorés avec résultats spécifiques et actionnables
- **Références croisées** : Ajout de liens entre les sujets liés à la sécurité et aux concepts de base
- **Informations actuelles** : Mise à jour de toutes les références de dates et liens de spécifications aux normes actuelles
- **Directives d'implémentation** : Ajout de directives d'implémentation spécifiques et actionnables dans toutes les sections

## 16 juillet 2025

### Améliorations du README et de la navigation
- Refonte complète de la navigation du curriculum dans README.md
- Remplacement des balises `<details>` par un format basé sur des tableaux plus accessible
- Création d'options de mise en page alternatives dans le nouveau dossier "alternative_layouts"
- Ajout d'exemples de navigation sous forme de cartes, d'onglets et d'accordéons
- Mise à jour de la section sur la structure du dépôt pour inclure tous les fichiers récents
- Amélioration de la section "Comment utiliser ce curriculum" avec des recommandations claires
- Mise à jour des liens vers les spécifications MCP pour pointer vers les URL correctes
- Ajout de la section sur l'ingénierie contextuelle (5.14) à la structure du curriculum

### Mises à jour du guide d'étude
- Révision complète du guide d'étude pour l'aligner avec la structure actuelle du dépôt
- Ajout de nouvelles sections sur les clients et outils MCP, et les serveurs MCP populaires
- Mise à jour de la carte visuelle du curriculum pour refléter avec précision tous les sujets
- Amélioration des descriptions des sujets avancés pour couvrir toutes les zones spécialisées
- Mise à jour de la section des études de cas pour refléter des exemples réels
- Ajout de ce journal des modifications complet

### Contributions communautaires (06-CommunityContributions/)
- Ajout d'informations détaillées sur les serveurs MCP pour la génération d'images
- Ajout d'une section complète sur l'utilisation de Claude dans VSCode
- Ajout des instructions de configuration et d'utilisation du client terminal Cline
- Mise à jour de la section client MCP pour inclure toutes les options client populaires
- Amélioration des exemples de contributions avec des échantillons de code plus précis

### Sujets avancés (05-AdvancedTopics/)
- Organisation de tous les dossiers de sujets spécialisés avec une nomenclature cohérente
- Ajout de matériel et d'exemples sur l'ingénierie contextuelle
- Ajout de la documentation sur l'intégration des agents Foundry
- Amélioration de la documentation sur l'intégration de la sécurité Entra ID

## 11 juin 2025

### Création initiale
- Publication de la première version du curriculum MCP pour débutants
- Création de la structure de base pour les 10 sections principales
- Implémentation de la carte visuelle du curriculum pour la navigation
- Ajout de projets d'exemple initiaux dans plusieurs langages de programmation

### Premiers pas (03-GettingStarted/)
- Création des premiers exemples d'implémentation de serveurs
- Ajout de conseils pour le développement de clients
- Inclusion des instructions d'intégration des clients LLM
- Ajout de la documentation d'intégration VS Code
- Implémentation d'exemples de serveurs avec Server-Sent Events (SSE)

### Concepts de base (01-CoreConcepts/)
- Ajout d'explications détaillées sur l'architecture client-serveur
- Création de la documentation sur les composants clés du protocole
- Documentation des modèles de messagerie dans MCP

## 23 mai 2025

### Structure du dépôt
- Initialisation du dépôt avec une structure de dossiers de base
- Création des fichiers README pour chaque section majeure
- Mise en place de l'infrastructure de traduction
- Ajout d'actifs visuels et de diagrammes

### Documentation
- Création du README.md initial avec un aperçu du curriculum
- Ajout des fichiers CODE_OF_CONDUCT.md et SECURITY.md
- Mise en place de SUPPORT.md avec des conseils pour obtenir de l'aide
- Création de la structure préliminaire du guide d'étude

## 15 avril 2025

### Planification et cadre
- Planification initiale du curriculum MCP pour débutants
- Définition des objectifs d'apprentissage et du public cible
- Élaboration de la structure en 10 sections du curriculum
- Développement du cadre conceptuel pour les exemples et études de cas
- Création des premiers prototypes d'exemples pour les concepts clés

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d'assurer l'exactitude, veuillez noter que les traductions automatisées peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant autorité. Pour des informations critiques, il est recommandé de faire appel à une traduction humaine professionnelle. Nous déclinons toute responsabilité en cas de malentendus ou d'interprétations erronées résultant de l'utilisation de cette traduction.