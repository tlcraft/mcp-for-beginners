<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T12:27:52+00:00",
  "source_file": "changelog.md",
  "language_code": "fr"
}
-->
# Journal des modifications : Curriculum MCP pour débutants

Ce document sert de registre pour toutes les modifications significatives apportées au curriculum du protocole de contexte modèle (MCP) pour débutants. Les changements sont documentés dans un ordre chronologique inversé (les plus récents en premier).

## 29 septembre 2025

### Laboratoires d'intégration de bases de données MCP Server - Parcours d'apprentissage pratique complet

#### 11-MCPServerHandsOnLabs - Nouveau curriculum complet d'intégration de bases de données
- **Parcours d'apprentissage en 13 laboratoires** : Ajout d'un curriculum pratique complet pour construire des serveurs MCP prêts pour la production avec intégration de bases de données PostgreSQL
  - **Mise en œuvre réelle** : Cas d'utilisation analytique de Zava Retail démontrant des modèles de niveau entreprise
  - **Progression structurée de l'apprentissage** :
    - **Laboratoires 00-03 : Fondations** - Introduction, architecture de base, sécurité et multi-location, configuration de l'environnement
    - **Laboratoires 04-06 : Construction du serveur MCP** - Conception et schéma de base de données, mise en œuvre du serveur MCP, développement d'outils  
    - **Laboratoires 07-09 : Fonctionnalités avancées** - Intégration de recherche sémantique, tests et débogage, intégration avec VS Code
    - **Laboratoires 10-12 : Production et meilleures pratiques** - Stratégies de déploiement, surveillance et observabilité, optimisation et meilleures pratiques
  - **Technologies d'entreprise** : Framework FastMCP, PostgreSQL avec pgvector, embeddings Azure OpenAI, Azure Container Apps, Application Insights
  - **Fonctionnalités avancées** : Sécurité au niveau des lignes (RLS), recherche sémantique, accès multi-locataires aux données, embeddings vectoriels, surveillance en temps réel

#### Standardisation de la terminologie - Conversion de "Module" en "Laboratoire"
- **Mise à jour complète de la documentation** : Mise à jour systématique de tous les fichiers README dans 11-MCPServerHandsOnLabs pour utiliser la terminologie "Laboratoire" au lieu de "Module"
  - **En-têtes de section** : Modification de "Ce que couvre ce module" en "Ce que couvre ce laboratoire" dans les 13 laboratoires
  - **Description du contenu** : Remplacement de "Ce module fournit..." par "Ce laboratoire fournit..." dans toute la documentation
  - **Objectifs d'apprentissage** : Modification de "À la fin de ce module..." en "À la fin de ce laboratoire..."
  - **Liens de navigation** : Conversion de toutes les références "Module XX:" en "Laboratoire XX:" dans les références croisées et la navigation
  - **Suivi de la progression** : Modification de "Après avoir terminé ce module..." en "Après avoir terminé ce laboratoire..."
  - **Références techniques préservées** : Maintien des références aux modules Python dans les fichiers de configuration (par ex., `"module": "mcp_server.main"`)

#### Amélioration du guide d'étude (study_guide.md)
- **Carte visuelle du curriculum** : Ajout d'une nouvelle section "11. Laboratoires d'intégration de bases de données" avec une visualisation complète de la structure des laboratoires
- **Structure du dépôt** : Mise à jour de dix à onze sections principales avec une description détaillée de 11-MCPServerHandsOnLabs
- **Orientation du parcours d'apprentissage** : Instructions de navigation améliorées pour couvrir les sections 00-11
- **Couverture technologique** : Ajout de détails sur l'intégration de FastMCP, PostgreSQL et des services Azure
- **Résultats d'apprentissage** : Accent mis sur le développement de serveurs prêts pour la production, les modèles d'intégration de bases de données et la sécurité d'entreprise

#### Amélioration de la structure du README principal
- **Terminologie basée sur les laboratoires** : Mise à jour du fichier README.md principal dans 11-MCPServerHandsOnLabs pour utiliser de manière cohérente la structure "Laboratoire"
- **Organisation du parcours d'apprentissage** : Progression claire des concepts fondamentaux à la mise en œuvre avancée jusqu'au déploiement en production
- **Orientation pratique** : Accent sur l'apprentissage pratique avec des modèles et des technologies de niveau entreprise

### Améliorations de la qualité et de la cohérence de la documentation
- **Accent sur l'apprentissage pratique** : Renforcement de l'approche pratique basée sur les laboratoires dans toute la documentation
- **Focalisation sur les modèles d'entreprise** : Mise en avant des implémentations prêtes pour la production et des considérations de sécurité d'entreprise
- **Intégration technologique** : Couverture complète des services modernes Azure et des modèles d'intégration de l'IA
- **Progression de l'apprentissage** : Chemin structuré et clair des concepts de base au déploiement en production

## 26 septembre 2025

### Amélioration des études de cas - Intégration du registre MCP GitHub

#### Études de cas (09-CaseStudy/) - Accent sur le développement de l'écosystème
- **README.md** : Expansion majeure avec une étude de cas complète sur le registre MCP GitHub
  - **Étude de cas sur le registre MCP GitHub** : Nouvelle étude de cas complète examinant le lancement du registre MCP GitHub en septembre 2025
    - **Analyse du problème** : Examen détaillé des défis liés à la découverte et au déploiement fragmentés des serveurs MCP
    - **Architecture de la solution** : Approche centralisée du registre de GitHub avec installation en un clic dans VS Code
    - **Impact commercial** : Améliorations mesurables de l'intégration des développeurs et de la productivité
    - **Valeur stratégique** : Accent sur le déploiement modulaire des agents et l'interopérabilité entre outils
    - **Développement de l'écosystème** : Positionnement en tant que plateforme fondamentale pour l'intégration agentique
  - **Structure améliorée des études de cas** : Mise à jour des sept études de cas avec un formatage cohérent et des descriptions complètes
    - Agents de voyage Azure AI : Accent sur l'orchestration multi-agents
    - Intégration Azure DevOps : Accent sur l'automatisation des workflows
    - Récupération de documentation en temps réel : Implémentation client console Python
    - Générateur de plan d'étude interactif : Application web conversationnelle Chainlit
    - Documentation dans l'éditeur : Intégration VS Code et GitHub Copilot
    - Gestion des API Azure : Modèles d'intégration d'API d'entreprise
    - Registre MCP GitHub : Développement de l'écosystème et plateforme communautaire
  - **Conclusion complète** : Réécriture de la section de conclusion mettant en avant sept études de cas couvrant plusieurs dimensions de mise en œuvre MCP
    - Intégration d'entreprise, orchestration multi-agents, productivité des développeurs
    - Développement de l'écosystème, applications éducatives
    - Perspectives améliorées sur les modèles architecturaux, les stratégies de mise en œuvre et les meilleures pratiques
    - Accent sur le MCP en tant que protocole mature et prêt pour la production

#### Mises à jour du guide d'étude (study_guide.md)
- **Carte visuelle du curriculum** : Mise à jour de la carte mentale pour inclure le registre MCP GitHub dans la section Études de cas
- **Description des études de cas** : Amélioration des descriptions génériques en une ventilation détaillée des sept études de cas complètes
- **Structure du dépôt** : Mise à jour de la section 10 pour refléter la couverture complète des études de cas avec des détails spécifiques sur la mise en œuvre
- **Intégration du journal des modifications** : Ajout de l'entrée du 26 septembre 2025 documentant l'ajout du registre MCP GitHub et les améliorations des études de cas
- **Mises à jour des dates** : Mise à jour de l'horodatage du pied de page pour refléter la dernière révision (26 septembre 2025)

### Améliorations de la qualité de la documentation
- **Amélioration de la cohérence** : Standardisation du formatage et de la structure des études de cas dans les sept exemples
- **Couverture complète** : Les études de cas couvrent désormais des scénarios d'entreprise, de productivité des développeurs et de développement de l'écosystème
- **Positionnement stratégique** : Accent renforcé sur le MCP en tant que plateforme fondamentale pour le déploiement de systèmes agentiques
- **Intégration des ressources** : Mise à jour des ressources supplémentaires pour inclure le lien vers le registre MCP GitHub

## 15 septembre 2025

### Expansion des sujets avancés - Transports personnalisés et ingénierie du contexte

#### Transports personnalisés MCP (05-AdvancedTopics/mcp-transport/) - Nouveau guide de mise en œuvre avancée
- **README.md** : Guide complet de mise en œuvre pour les mécanismes de transport personnalisés MCP
  - **Transport Azure Event Grid** : Implémentation complète de transport événementiel sans serveur
    - Exemples en C#, TypeScript et Python avec intégration Azure Functions
    - Modèles d'architecture événementielle pour des solutions MCP évolutives
    - Récepteurs webhook et gestion des messages en mode push
  - **Transport Azure Event Hubs** : Implémentation de transport en streaming à haut débit
    - Capacités de streaming en temps réel pour des scénarios à faible latence
    - Stratégies de partitionnement et gestion des points de contrôle
    - Regroupement des messages et optimisation des performances
  - **Modèles d'intégration d'entreprise** : Exemples architecturaux prêts pour la production
    - Traitement MCP distribué sur plusieurs Azure Functions
    - Architectures de transport hybrides combinant plusieurs types de transport
    - Stratégies de durabilité, fiabilité et gestion des erreurs des messages
  - **Sécurité et surveillance** : Intégration Azure Key Vault et modèles d'observabilité
    - Authentification par identité managée et accès au moindre privilège
    - Télémétrie Application Insights et surveillance des performances
    - Disjoncteurs et modèles de tolérance aux pannes
  - **Cadres de test** : Stratégies de test complètes pour les transports personnalisés
    - Tests unitaires avec doubles de test et frameworks de simulation
    - Tests d'intégration avec Azure Test Containers
    - Considérations sur les tests de performance et de charge

#### Ingénierie du contexte (05-AdvancedTopics/mcp-contextengineering/) - Discipline émergente en IA
- **README.md** : Exploration complète de l'ingénierie du contexte en tant que domaine émergent
  - **Principes fondamentaux** : Partage complet du contexte, sensibilisation à la prise de décision d'action et gestion des fenêtres de contexte
  - **Alignement avec le protocole MCP** : Comment la conception MCP répond aux défis de l'ingénierie du contexte
    - Limitations des fenêtres de contexte et stratégies de chargement progressif
    - Détermination de la pertinence et récupération dynamique du contexte
    - Gestion multi-modale du contexte et considérations de sécurité
  - **Approches de mise en œuvre** : Architectures mono-thread et multi-agents
    - Techniques de découpage et de hiérarchisation du contexte
    - Chargement progressif du contexte et stratégies de compression
    - Approches contextuelles en couches et optimisation de la récupération
  - **Cadre de mesure** : Nouveaux indicateurs pour évaluer l'efficacité du contexte
    - Efficacité des entrées, performances, qualité et considérations sur l'expérience utilisateur
    - Approches expérimentales pour l'optimisation du contexte
    - Analyse des échecs et méthodologies d'amélioration

#### Mises à jour de la navigation dans le curriculum (README.md)
- **Structure des modules améliorée** : Mise à jour du tableau du curriculum pour inclure les nouveaux sujets avancés
  - Ajout des entrées Ingénierie du contexte (5.14) et Transport personnalisé (5.15)
  - Formatage cohérent et liens de navigation dans tous les modules
  - Descriptions mises à jour pour refléter la portée actuelle du contenu

### Améliorations de la structure des répertoires
- **Standardisation des noms** : Renommage de "mcp transport" en "mcp-transport" pour la cohérence avec les autres dossiers de sujets avancés
- **Organisation du contenu** : Tous les dossiers 05-AdvancedTopics suivent désormais un modèle de nommage cohérent (mcp-[sujet])

### Améliorations de la qualité de la documentation
- **Alignement avec la spécification MCP** : Tout le nouveau contenu fait référence à la spécification MCP actuelle 2025-06-18
- **Exemples multi-langages** : Exemples de code complets en C#, TypeScript et Python
- **Accent sur l'entreprise** : Modèles prêts pour la production et intégration au cloud Azure dans tout le contenu
- **Documentation visuelle** : Diagrammes Mermaid pour la visualisation des architectures et des flux

## 18 août 2025

### Mise à jour complète de la documentation - Normes MCP 2025-06-18

#### Meilleures pratiques de sécurité MCP (02-Security/) - Modernisation complète
- **MCP-SECURITY-BEST-PRACTICES-2025.md** : Réécriture complète alignée avec la spécification MCP 2025-06-18
  - **Exigences obligatoires** : Ajout d'exigences explicites DOIT/NE DOIT PAS issues de la spécification officielle avec des indicateurs visuels clairs
  - **12 pratiques de sécurité essentielles** : Restructuration d'une liste de 15 éléments en domaines de sécurité complets
    - Sécurité des jetons et authentification avec intégration de fournisseurs d'identité externes
    - Gestion des sessions et sécurité des transports avec exigences cryptographiques
    - Protection contre les menaces spécifiques à l'IA avec intégration de Microsoft Prompt Shields
    - Contrôle d'accès et permissions selon le principe du moindre privilège
    - Sécurité et surveillance du contenu avec intégration Azure Content Safety
    - Sécurité de la chaîne d'approvisionnement avec vérification complète des composants
    - Sécurité OAuth et prévention des attaques de type "Confused Deputy" avec implémentation PKCE
    - Réponse aux incidents et récupération avec capacités automatisées
    - Conformité et gouvernance avec alignement réglementaire
    - Contrôles de sécurité avancés avec architecture Zero Trust
    - Intégration de l'écosystème de sécurité Microsoft avec solutions complètes
    - Évolution continue de la sécurité avec pratiques adaptatives
  - **Solutions de sécurité Microsoft** : Directives d'intégration améliorées pour Prompt Shields, Azure Content Safety, Entra ID et GitHub Advanced Security
  - **Ressources de mise en œuvre** : Liens de ressources complets catégorisés par documentation officielle MCP, solutions de sécurité Microsoft, normes de sécurité et guides de mise en œuvre

#### Contrôles de sécurité avancés (02-Security/) - Mise en œuvre d'entreprise
- **MCP-SECURITY-CONTROLS-2025.md** : Révision complète avec cadre de sécurité de niveau entreprise
  - **9 domaines de sécurité complets** : Expansion des contrôles de base à un cadre d'entreprise détaillé
    - Authentification et autorisation avancées avec intégration Microsoft Entra ID
    - Sécurité des jetons et contrôles anti-passage avec validation complète
    - Contrôles de sécurité des sessions avec prévention des détournements
    - Contrôles de sécurité spécifiques à l'IA avec prévention des injections de prompts et empoisonnement des outils
    - Prévention des attaques de type "Confused Deputy" avec sécurité proxy OAuth
    - Sécurité de l'exécution des outils avec sandboxing et isolation
    - Contrôles de sécurité de la chaîne d'approvisionnement avec vérification des dépendances
    - Contrôles de surveillance et de détection avec intégration SIEM
    - Réponse aux incidents et récupération avec capacités automatisées
  - **Exemples de mise en œuvre** : Ajout de blocs de configuration YAML détaillés et d'exemples de code
  - **Intégration des solutions Microsoft** : Couverture complète des services de sécurité Azure, GitHub Advanced Security et gestion des identités d'entreprise

#### Sécurité des sujets avancés (05-AdvancedTopics/mcp-security/) - Mise en œuvre prête pour la production
- **README.md** : Réécriture complète pour la mise en œuvre de la sécurité d'entreprise
  - **Alignement avec la spécification actuelle** : Mise à jour vers la spécification MCP 2025-06-18 avec exigences de sécurité obligatoires
  - **Authentification améliorée** : Intégration Microsoft Entra ID avec exemples complets en .NET et Java Spring Security
  - **Intégration de la sécurité IA** : Implémentation de Microsoft Prompt Shields et Azure Content Safety avec exemples détaillés en Python
  - **Atténuation avancée des menaces** : Exemples d'implémentation complets pour
    - Prévention des attaques de type "Confused Deputy" avec PKCE et validation du consentement utilisateur
    - Prévention du passage des jetons avec validation de l'audience et gestion sécurisée des jetons
    - Prévention des détournements de session avec liaison cryptographique et analyse comportementale
  - **Intégration de la sécurité d'entreprise** : Surveillance Azure Application Insights, pipelines de détection des menaces et sécurité de la chaîne d'approvisionnement
  - **Liste de contrôle de mise en œuvre** : Contrôles de sécurité obligatoires vs recommandés avec avantages de l'écosystème de sécurité Microsoft

### Qualité et alignement des normes de la documentation
- **Références à la spécification** : Mise à jour de toutes les références à la spécification MCP actuelle 2025-06-18
- **Écosystème de sécurité Microsoft** : Directives d'intégration améliorées dans toute la documentation de sécurité
- **Mise en œuvre pratique** : Ajout d'exemples de code détaillés en .NET, Java et Python avec modèles d'entreprise
- **Organisation des ressources** : Catégorisation complète de la documentation officielle, des normes de sécurité et des guides de mise en œuvre
- **Indicateurs Visuels** : Marquage clair des exigences obligatoires par rapport aux pratiques recommandées

#### Concepts de Base (01-CoreConcepts/) - Modernisation Complète
- **Mise à jour de la version du protocole** : Références mises à jour vers la spécification MCP actuelle du 18/06/2025 avec versionnement basé sur la date (format AAAA-MM-JJ)
- **Affinement de l'architecture** : Descriptions améliorées des Hôtes, Clients et Serveurs pour refléter les modèles d'architecture MCP actuels
  - Les Hôtes sont désormais clairement définis comme des applications d'IA coordonnant plusieurs connexions client MCP
  - Les Clients sont décrits comme des connecteurs de protocole maintenant des relations serveur un-à-un
  - Les Serveurs sont enrichis avec des scénarios de déploiement local et distant
- **Restructuration des Primitives** : Refonte complète des primitives serveur et client
  - Primitives Serveur : Ressources (sources de données), Invites (modèles), Outils (fonctions exécutables) avec explications détaillées et exemples
  - Primitives Client : Échantillonnage (complétions LLM), Sollicitation (entrée utilisateur), Journalisation (débogage/surveillance)
  - Mise à jour avec les modèles actuels de découverte (`*/list`), récupération (`*/get`) et exécution (`*/call`)
- **Architecture du Protocole** : Introduction d'un modèle d'architecture à deux couches
  - Couche Données : Fondation JSON-RPC 2.0 avec gestion du cycle de vie et primitives
  - Couche Transport : Mécanismes de transport STDIO (local) et HTTP avec SSE (distant)
- **Cadre de Sécurité** : Principes de sécurité complets incluant consentement explicite de l'utilisateur, protection de la confidentialité des données, sécurité d'exécution des outils et sécurité de la couche transport
- **Modèles de Communication** : Messages de protocole mis à jour pour montrer les flux d'initialisation, de découverte, d'exécution et de notification
- **Exemples de Code** : Exemples multilingues actualisés (.NET, Java, Python, JavaScript) pour refléter les modèles actuels du SDK MCP

#### Sécurité (02-Security/) - Révision Complète de la Sécurité  
- **Alignement sur les Normes** : Alignement complet avec les exigences de sécurité de la spécification MCP 2025-06-18
- **Évolution de l'Authentification** : Documentation de l'évolution des serveurs OAuth personnalisés vers la délégation à des fournisseurs d'identité externes (Microsoft Entra ID)
- **Analyse des Menaces Spécifiques à l'IA** : Couverture améliorée des vecteurs d'attaque modernes liés à l'IA
  - Scénarios détaillés d'attaques par injection d'invites avec exemples réels
  - Mécanismes de contamination des outils et modèles d'attaques "rug pull"
  - Empoisonnement de la fenêtre contextuelle et attaques de confusion des modèles
- **Solutions de Sécurité IA de Microsoft** : Couverture complète de l'écosystème de sécurité Microsoft
  - Boucliers d'Invites IA avec techniques avancées de détection, mise en lumière et délimitation
  - Modèles d'intégration Azure Content Safety
  - Sécurité Avancée GitHub pour la protection de la chaîne d'approvisionnement
- **Atténuation des Menaces Avancées** : Contrôles de sécurité détaillés pour
  - Détournement de session avec scénarios d'attaque spécifiques au MCP et exigences cryptographiques pour les ID de session
  - Problèmes de mandataire confus dans les scénarios de proxy MCP avec exigences de consentement explicite
  - Vulnérabilités de transmission de jetons avec contrôles de validation obligatoires
- **Sécurité de la Chaîne d'Approvisionnement** : Couverture élargie de la chaîne d'approvisionnement IA incluant les modèles de base, services d'embeddings, fournisseurs de contexte et API tierces
- **Sécurité Fondamentale** : Intégration renforcée avec les modèles de sécurité d'entreprise incluant l'architecture de confiance zéro et l'écosystème de sécurité Microsoft
- **Organisation des Ressources** : Liens de ressources complets catégorisés par type (Docs officiels, Normes, Recherche, Solutions Microsoft, Guides d'implémentation)

### Améliorations de la Qualité de la Documentation
- **Objectifs d'Apprentissage Structurés** : Objectifs d'apprentissage améliorés avec des résultats spécifiques et actionnables
- **Références Croisées** : Ajout de liens entre les sujets liés à la sécurité et aux concepts de base
- **Informations Actuelles** : Mise à jour de toutes les références de dates et des liens de spécifications vers les normes actuelles
- **Guides d'Implémentation** : Ajout de directives d'implémentation spécifiques et actionnables dans les deux sections

## 16 juillet 2025

### README et Améliorations de Navigation
- Refonte complète de la navigation du curriculum dans README.md
- Remplacement des balises `<details>` par un format basé sur des tableaux plus accessible
- Création d'options de mise en page alternatives dans le nouveau dossier "alternative_layouts"
- Ajout d'exemples de navigation en style cartes, onglets et accordéon
- Mise à jour de la section de structure du dépôt pour inclure tous les fichiers récents
- Amélioration de la section "Comment utiliser ce curriculum" avec des recommandations claires
- Mise à jour des liens de spécification MCP pour pointer vers les URL correctes
- Ajout de la section Ingénierie de Contexte (5.14) à la structure du curriculum

### Mises à Jour du Guide d'Étude
- Révision complète du guide d'étude pour s'aligner sur la structure actuelle du dépôt
- Ajout de nouvelles sections pour les Clients MCP et Outils, et les Serveurs MCP populaires
- Mise à jour de la Carte Visuelle du Curriculum pour refléter avec précision tous les sujets
- Descriptions améliorées des Sujets Avancés pour couvrir toutes les zones spécialisées
- Mise à jour de la section Études de Cas pour refléter des exemples réels
- Ajout de ce journal des modifications complet

### Contributions Communautaires (06-CommunityContributions/)
- Ajout d'informations détaillées sur les serveurs MCP pour la génération d'images
- Ajout d'une section complète sur l'utilisation de Claude dans VSCode
- Ajout des instructions de configuration et d'utilisation du client terminal Cline
- Mise à jour de la section client MCP pour inclure toutes les options populaires
- Amélioration des exemples de contributions avec des échantillons de code plus précis

### Sujets Avancés (05-AdvancedTopics/)
- Organisation de tous les dossiers de sujets spécialisés avec des noms cohérents
- Ajout de matériaux et exemples d'ingénierie de contexte
- Ajout de documentation sur l'intégration des agents Foundry
- Amélioration de la documentation d'intégration de sécurité Entra ID

## 11 juin 2025

### Création Initiale
- Publication de la première version du curriculum MCP pour Débutants
- Création de la structure de base pour les 10 sections principales
- Mise en œuvre de la Carte Visuelle du Curriculum pour la navigation
- Ajout de projets d'exemple initiaux dans plusieurs langages de programmation

### Premiers Pas (03-GettingStarted/)
- Création des premiers exemples d'implémentation de serveur
- Ajout de directives pour le développement de clients
- Inclusion des instructions d'intégration des clients LLM
- Ajout de la documentation d'intégration VS Code
- Mise en œuvre d'exemples de serveur avec événements envoyés par le serveur (SSE)

### Concepts de Base (01-CoreConcepts/)
- Ajout d'explications détaillées sur l'architecture client-serveur
- Création de documentation sur les composants clés du protocole
- Documentation des modèles de messagerie dans MCP

## 23 mai 2025

### Structure du Dépôt
- Initialisation du dépôt avec une structure de dossiers de base
- Création de fichiers README pour chaque section majeure
- Mise en place de l'infrastructure de traduction
- Ajout d'actifs d'image et de diagrammes

### Documentation
- Création du README.md initial avec un aperçu du curriculum
- Ajout de CODE_OF_CONDUCT.md et SECURITY.md
- Mise en place de SUPPORT.md avec des conseils pour obtenir de l'aide
- Création de la structure préliminaire du guide d'étude

## 15 avril 2025

### Planification et Cadre
- Planification initiale du curriculum MCP pour Débutants
- Définition des objectifs d'apprentissage et du public cible
- Définition de la structure en 10 sections du curriculum
- Développement du cadre conceptuel pour les exemples et études de cas
- Création de prototypes initiaux pour les concepts clés

---

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d'assurer l'exactitude, veuillez noter que les traductions automatisées peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant autorité. Pour des informations critiques, il est recommandé de recourir à une traduction humaine professionnelle. Nous déclinons toute responsabilité en cas de malentendus ou d'interprétations erronées résultant de l'utilisation de cette traduction.