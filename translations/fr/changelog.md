<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T21:49:52+00:00",
  "source_file": "changelog.md",
  "language_code": "fr"
}
-->
# Journal des modifications : Curriculum MCP pour débutants

Ce document sert de registre de tous les changements significatifs apportés au curriculum du protocole de contexte modèle (MCP) pour débutants. Les modifications sont documentées dans un ordre chronologique inversé (les plus récentes en premier).

## 15 septembre 2025

### Extension des sujets avancés - Transports personnalisés et ingénierie du contexte

#### Transports personnalisés MCP (05-AdvancedTopics/mcp-transport/) - Nouveau guide d'implémentation avancée
- **README.md** : Guide complet pour les mécanismes de transport personnalisés MCP
  - **Transport Azure Event Grid** : Implémentation complète de transport événementiel sans serveur
    - Exemples en C#, TypeScript et Python avec intégration Azure Functions
    - Modèles d'architecture événementielle pour des solutions MCP évolutives
    - Récepteurs Webhook et gestion des messages en mode push
  - **Transport Azure Event Hubs** : Implémentation de transport en streaming à haut débit
    - Capacités de streaming en temps réel pour des scénarios à faible latence
    - Stratégies de partitionnement et gestion des points de contrôle
    - Optimisation des performances et regroupement des messages
  - **Modèles d'intégration d'entreprise** : Exemples architecturaux prêts pour la production
    - Traitement MCP distribué sur plusieurs fonctions Azure
    - Architectures hybrides combinant plusieurs types de transport
    - Stratégies de durabilité, fiabilité et gestion des erreurs des messages
  - **Sécurité et surveillance** : Intégration Azure Key Vault et modèles d'observabilité
    - Authentification par identité gérée et accès avec privilèges minimaux
    - Télémétrie Application Insights et surveillance des performances
    - Disjoncteurs et modèles de tolérance aux pannes
  - **Cadres de test** : Stratégies de test complètes pour les transports personnalisés
    - Tests unitaires avec doubles de test et cadres de simulation
    - Tests d'intégration avec Azure Test Containers
    - Considérations sur les tests de performance et de charge

#### Ingénierie du contexte (05-AdvancedTopics/mcp-contextengineering/) - Discipline émergente en IA
- **README.md** : Exploration complète de l'ingénierie du contexte en tant que domaine émergent
  - **Principes fondamentaux** : Partage complet du contexte, sensibilisation à la prise de décision et gestion des fenêtres de contexte
  - **Alignement avec le protocole MCP** : Comment la conception MCP répond aux défis de l'ingénierie du contexte
    - Limitations des fenêtres de contexte et stratégies de chargement progressif
    - Détermination de la pertinence et récupération dynamique du contexte
    - Gestion multimodale du contexte et considérations de sécurité
  - **Approches d'implémentation** : Architectures mono-thread et multi-agents
    - Techniques de découpage et de priorisation du contexte
    - Chargement progressif et stratégies de compression du contexte
    - Approches contextuelles en couches et optimisation de la récupération
  - **Cadre de mesure** : Métriques émergentes pour évaluer l'efficacité du contexte
    - Efficacité des entrées, performances, qualité et considérations sur l'expérience utilisateur
    - Approches expérimentales pour l'optimisation du contexte
    - Analyse des échecs et méthodologies d'amélioration

#### Mises à jour de navigation du curriculum (README.md)
- **Structure de module améliorée** : Table de curriculum mise à jour pour inclure les nouveaux sujets avancés
  - Ajout des entrées Ingénierie du contexte (5.14) et Transports personnalisés (5.15)
  - Formatage cohérent et liens de navigation dans tous les modules
  - Descriptions mises à jour pour refléter la portée actuelle du contenu

### Améliorations de la structure des répertoires
- **Standardisation des noms** : Renommage de "mcp transport" en "mcp-transport" pour une cohérence avec les autres dossiers de sujets avancés
- **Organisation du contenu** : Tous les dossiers 05-AdvancedTopics suivent désormais un modèle de nommage cohérent (mcp-[topic])

### Améliorations de la qualité de la documentation
- **Alignement avec la spécification MCP** : Tout le nouveau contenu fait référence à la spécification MCP actuelle 2025-06-18
- **Exemples multilingues** : Exemples de code complets en C#, TypeScript et Python
- **Focus sur l'entreprise** : Modèles prêts pour la production et intégration cloud Azure dans tout le contenu
- **Documentation visuelle** : Diagrammes Mermaid pour la visualisation des architectures et des flux

## 18 août 2025

### Mise à jour complète de la documentation - Normes MCP 2025-06-18

#### Meilleures pratiques de sécurité MCP (02-Security/) - Modernisation complète
- **MCP-SECURITY-BEST-PRACTICES-2025.md** : Réécriture complète alignée avec la spécification MCP 2025-06-18
  - **Exigences obligatoires** : Ajout des exigences explicites DOIT/NE DOIT PAS de la spécification officielle avec des indicateurs visuels clairs
  - **12 pratiques de sécurité fondamentales** : Restructuration de la liste de 15 éléments en domaines de sécurité complets
    - Sécurité des jetons et authentification avec intégration de fournisseurs d'identité externes
    - Gestion des sessions et sécurité des transports avec exigences cryptographiques
    - Protection contre les menaces spécifiques à l'IA avec intégration Microsoft Prompt Shields
    - Contrôle d'accès et permissions avec principe de privilège minimal
    - Sécurité du contenu et surveillance avec intégration Azure Content Safety
    - Sécurité de la chaîne d'approvisionnement avec vérification complète des composants
    - Sécurité OAuth et prévention des attaques de type "confused deputy" avec implémentation PKCE
    - Réponse aux incidents et récupération avec capacités automatisées
    - Conformité et gouvernance avec alignement réglementaire
    - Contrôles de sécurité avancés avec architecture zéro confiance
    - Intégration de l'écosystème de sécurité Microsoft avec solutions complètes
    - Évolution continue de la sécurité avec pratiques adaptatives
  - **Solutions de sécurité Microsoft** : Guide d'intégration amélioré pour Prompt Shields, Azure Content Safety, Entra ID et GitHub Advanced Security
  - **Ressources d'implémentation** : Liens de ressources complets catégorisés par documentation officielle MCP, solutions de sécurité Microsoft, normes de sécurité et guides d'implémentation

#### Contrôles de sécurité avancés (02-Security/) - Implémentation pour l'entreprise
- **MCP-SECURITY-CONTROLS-2025.md** : Refonte complète avec cadre de sécurité de niveau entreprise
  - **9 domaines de sécurité complets** : Expansion des contrôles de base en cadre détaillé pour l'entreprise
    - Authentification et autorisation avancées avec intégration Microsoft Entra ID
    - Sécurité des jetons et contrôles anti-passthrough avec validation complète
    - Contrôles de sécurité des sessions avec prévention des détournements
    - Contrôles de sécurité spécifiques à l'IA avec prévention des injections de prompts et empoisonnement des outils
    - Prévention des attaques de type "confused deputy" avec sécurité proxy OAuth
    - Sécurité de l'exécution des outils avec sandboxing et isolation
    - Contrôles de sécurité de la chaîne d'approvisionnement avec vérification des dépendances
    - Contrôles de surveillance et de détection avec intégration SIEM
    - Réponse aux incidents et récupération avec capacités automatisées
  - **Exemples d'implémentation** : Ajout de blocs de configuration YAML détaillés et exemples de code
  - **Intégration des solutions Microsoft** : Couverture complète des services de sécurité Azure, GitHub Advanced Security et gestion des identités d'entreprise

#### Sécurité des sujets avancés (05-AdvancedTopics/mcp-security/) - Implémentation prête pour la production
- **README.md** : Réécriture complète pour l'implémentation de la sécurité en entreprise
  - **Alignement avec la spécification actuelle** : Mise à jour selon la spécification MCP 2025-06-18 avec exigences de sécurité obligatoires
  - **Authentification améliorée** : Intégration Microsoft Entra ID avec exemples complets en .NET et Java Spring Security
  - **Intégration de la sécurité IA** : Implémentation Microsoft Prompt Shields et Azure Content Safety avec exemples détaillés en Python
  - **Atténuation avancée des menaces** : Exemples d'implémentation complets pour
    - Prévention des attaques de type "confused deputy" avec PKCE et validation du consentement utilisateur
    - Prévention du passage des jetons avec validation de l'audience et gestion sécurisée des jetons
    - Prévention des détournements de session avec liaison cryptographique et analyse comportementale
  - **Intégration de la sécurité en entreprise** : Surveillance Application Insights Azure, pipelines de détection des menaces et sécurité de la chaîne d'approvisionnement
  - **Liste de contrôle d'implémentation** : Contrôles de sécurité obligatoires vs recommandés avec avantages de l'écosystème de sécurité Microsoft

### Alignement de la qualité et des normes de la documentation
- **Références de spécification** : Mise à jour de toutes les références à la spécification MCP actuelle 2025-06-18
- **Écosystème de sécurité Microsoft** : Guide d'intégration amélioré dans toute la documentation de sécurité
- **Implémentation pratique** : Ajout d'exemples de code détaillés en .NET, Java et Python avec modèles d'entreprise
- **Organisation des ressources** : Catégorisation complète de la documentation officielle, des normes de sécurité et des guides d'implémentation
- **Indicateurs visuels** : Marquage clair des exigences obligatoires vs pratiques recommandées

#### Concepts fondamentaux (01-CoreConcepts/) - Modernisation complète
- **Mise à jour de la version du protocole** : Référence mise à jour à la spécification MCP actuelle 2025-06-18 avec versionnement basé sur la date (format YYYY-MM-DD)
- **Affinement de l'architecture** : Descriptions améliorées des hôtes, clients et serveurs pour refléter les modèles d'architecture MCP actuels
  - Les hôtes sont désormais clairement définis comme des applications IA coordonnant plusieurs connexions client MCP
  - Les clients sont décrits comme des connecteurs de protocole maintenant des relations serveur un-à-un
  - Les serveurs sont améliorés avec des scénarios de déploiement local vs distant
- **Restructuration des primitives** : Refonte complète des primitives serveur et client
  - Primitives serveur : Ressources (sources de données), Prompts (modèles), Outils (fonctions exécutables) avec explications et exemples détaillés
  - Primitives client : Échantillonnage (complétions LLM), Élicitation (entrée utilisateur), Journalisation (débogage/surveillance)
  - Mise à jour avec les modèles de découverte (`*/list`), récupération (`*/get`) et exécution (`*/call`)
- **Architecture du protocole** : Introduction d'un modèle d'architecture à deux couches
  - Couche de données : Fondation JSON-RPC 2.0 avec gestion du cycle de vie et primitives
  - Couche de transport : STDIO (local) et HTTP streamable avec SSE (distant)
- **Cadre de sécurité** : Principes de sécurité complets incluant consentement explicite de l'utilisateur, protection de la confidentialité des données, sécurité de l'exécution des outils et sécurité de la couche de transport
- **Modèles de communication** : Messages de protocole mis à jour pour montrer les flux d'initialisation, de découverte, d'exécution et de notification
- **Exemples de code** : Exemples multilingues actualisés (.NET, Java, Python, JavaScript) pour refléter les modèles SDK MCP actuels

#### Sécurité (02-Security/) - Refonte complète de la sécurité  
- **Alignement avec les normes** : Alignement complet avec les exigences de sécurité de la spécification MCP 2025-06-18
- **Évolution de l'authentification** : Documentation de l'évolution des serveurs OAuth personnalisés vers la délégation à des fournisseurs d'identité externes (Microsoft Entra ID)
- **Analyse des menaces spécifiques à l'IA** : Couverture améliorée des vecteurs d'attaque modernes en IA
  - Scénarios détaillés d'attaques par injection de prompts avec exemples réels
  - Mécanismes d'empoisonnement des outils et modèles d'attaques "rug pull"
  - Empoisonnement des fenêtres de contexte et attaques de confusion des modèles
- **Solutions de sécurité IA Microsoft** : Couverture complète de l'écosystème de sécurité Microsoft
  - Prompt Shields IA avec techniques avancées de détection, mise en lumière et délimitation
  - Modèles d'intégration Azure Content Safety
  - GitHub Advanced Security pour la protection de la chaîne d'approvisionnement
- **Atténuation avancée des menaces** : Contrôles de sécurité détaillés pour
  - Détournement de session avec scénarios d'attaque spécifiques MCP et exigences cryptographiques pour les ID de session
  - Problèmes de type "confused deputy" dans les scénarios proxy MCP avec exigences explicites de consentement
  - Vulnérabilités de passage des jetons avec contrôles de validation obligatoires
- **Sécurité de la chaîne d'approvisionnement** : Couverture étendue de la chaîne d'approvisionnement IA incluant modèles de base, services d'embeddings, fournisseurs de contexte et API tierces
- **Sécurité de base** : Intégration améliorée avec des modèles de sécurité d'entreprise incluant architecture zéro confiance et écosystème de sécurité Microsoft
- **Organisation des ressources** : Liens de ressources complets catégorisés par type (Docs officiels, Normes, Recherche, Solutions Microsoft, Guides d'implémentation)

### Améliorations de la qualité de la documentation
- **Objectifs d'apprentissage structurés** : Objectifs d'apprentissage améliorés avec résultats spécifiques et actionnables 
- **Références croisées** : Ajout de liens entre les sujets liés à la sécurité et aux concepts fondamentaux
- **Informations actuelles** : Mise à jour de toutes les références de date et des liens de spécification aux normes actuelles
- **Guide d'implémentation** : Ajout de directives d'implémentation spécifiques et actionnables dans les deux sections

## 16 juillet 2025

### Améliorations du README et de la navigation
- Refonte complète de la navigation du curriculum dans README.md
- Remplacement des balises `<details>` par un format basé sur des tableaux plus accessible
- Création d'options de mise en page alternatives dans le nouveau dossier "alternative_layouts"
- Ajout d'exemples de navigation en style cartes, onglets et accordéon
- Mise à jour de la section structure du dépôt pour inclure tous les derniers fichiers
- Amélioration de la section "Comment utiliser ce curriculum" avec des recommandations claires
- Mise à jour des liens de spécification MCP pour pointer vers les URL correctes
- Ajout de la section Ingénierie du contexte (5.14) à la structure du curriculum

### Mises à jour du guide d'étude
- Révision complète du guide d'étude pour s'aligner avec la structure actuelle du dépôt
- Ajout de nouvelles sections pour les clients MCP et outils, et serveurs MCP populaires
- Mise à jour de la carte visuelle du curriculum pour refléter avec précision tous les sujets
- Amélioration des descriptions des sujets avancés pour couvrir toutes les zones spécialisées
- Mise à jour de la section études de cas pour refléter des exemples réels
- Ajout de ce journal des modifications complet

### Contributions communautaires (06-CommunityContributions/)
- Ajout d'informations détaillées sur les serveurs MCP pour la génération d'images
- Ajout d'une section complète sur l'utilisation de Claude dans VSCode
- Ajout des instructions de configuration et d'utilisation du client terminal Cline
- Mise à jour de la section client MCP pour inclure toutes les options client populaires
- Amélioration des exemples de contributions avec des échantillons de code plus précis

### Sujets avancés (05-AdvancedTopics/)
- Organisation de tous les dossiers de sujets spécialisés avec un nommage cohérent
- Ajout de matériaux et exemples sur l'ingénierie du contexte
- Ajout de documentation sur l'intégration des agents Foundry
- Amélioration de la documentation sur l'intégration de la sécurité Entra ID

## 11 juin 2025

### Création initiale
- Publication de la première version du curriculum MCP pour débutants
- Création de la structure de base pour les 10 sections principales
- Implémentation de la carte visuelle du curriculum pour la navigation
- Ajout des projets d'exemple initiaux dans plusieurs langages de programmation

### Premiers pas (03-GettingStarted/)
- Création des premiers exemples d'implémentation de serveur
- Ajout de conseils pour le développement de clients
- Inclusion des instructions d'intégration des clients LLM
- Ajout de documentation sur l'intégration VS Code
- Implémentation d'exemples de serveur Server-Sent Events (SSE)

### Concepts fondamentaux (01-CoreConcepts/)
- Ajout d'explications détaillées sur l'architecture client-serveur
- Création de documentation sur les composants clés du protocole
- Documentation des modèles de messagerie dans MCP

## 23 mai 2025

### Structure du dépôt
- Initialisation du dépôt avec une structure de dossier de base
- Création de fichiers README pour chaque section majeure
- Mise en place de l'infrastructure de traduction
- Ajout d'actifs d'image et de diagrammes

### Documentation
- Création du README.md initial avec aperçu du curriculum
- Ajout des fichiers CODE_OF_CONDUCT.md et SECURITY.md
- Mise en place de SUPPORT.md avec des conseils pour obtenir de l'aide
- Création de la structure préliminaire du guide d'étude

## 15 avril 2025

### Planification et cadre
- Planification initiale du curriculum MCP pour débutants
- Définition des objectifs d'apprentissage et du public cible
- Développement de la structure en 10 sections du curriculum
- Élaboration du cadre conceptuel pour les exemples et études de cas
- Création des prototypes initiaux pour les concepts clés

---

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d'assurer l'exactitude, veuillez noter que les traductions automatisées peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant autorité. Pour des informations critiques, il est recommandé de recourir à une traduction professionnelle réalisée par un humain. Nous déclinons toute responsabilité en cas de malentendus ou d'interprétations erronées résultant de l'utilisation de cette traduction.