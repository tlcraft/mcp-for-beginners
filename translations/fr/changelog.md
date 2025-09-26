<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T17:32:52+00:00",
  "source_file": "changelog.md",
  "language_code": "fr"
}
-->
# Journal des modifications : Curriculum MCP pour débutants

Ce document sert de registre de tous les changements significatifs apportés au curriculum du protocole de contexte modèle (MCP) pour débutants. Les modifications sont documentées dans un ordre chronologique inversé (les plus récentes en premier).

## 26 septembre 2025

### Amélioration des études de cas - Intégration du registre MCP de GitHub

#### Études de cas (09-CaseStudy/) - Focus sur le développement de l'écosystème
- **README.md** : Expansion majeure avec une étude de cas complète sur le registre MCP de GitHub
  - **Étude de cas sur le registre MCP de GitHub** : Nouvelle étude de cas approfondie examinant le lancement du registre MCP de GitHub en septembre 2025
    - **Analyse du problème** : Examen détaillé des défis liés à la découverte et au déploiement fragmentés des serveurs MCP
    - **Architecture de la solution** : Approche centralisée du registre de GitHub avec installation en un clic dans VS Code
    - **Impact commercial** : Améliorations mesurables de l'intégration des développeurs et de leur productivité
    - **Valeur stratégique** : Accent sur le déploiement modulaire des agents et l'interopérabilité entre outils
    - **Développement de l'écosystème** : Positionnement en tant que plateforme fondamentale pour l'intégration agentique
  - **Structure améliorée des études de cas** : Mise à jour des sept études de cas avec un format cohérent et des descriptions détaillées
    - Agents de voyage Azure AI : Accent sur l'orchestration multi-agents
    - Intégration Azure DevOps : Focus sur l'automatisation des workflows
    - Récupération de documentation en temps réel : Implémentation du client console Python
    - Générateur de plan d'étude interactif : Application web conversationnelle Chainlit
    - Documentation dans l'éditeur : Intégration VS Code et GitHub Copilot
    - Gestion des API Azure : Modèles d'intégration des API d'entreprise
    - Registre MCP de GitHub : Développement de l'écosystème et plateforme communautaire
  - **Conclusion complète** : Réécriture de la section conclusion mettant en avant les sept études de cas couvrant plusieurs dimensions d'implémentation MCP
    - Intégration d'entreprise, orchestration multi-agents, productivité des développeurs
    - Développement de l'écosystème, applications éducatives
    - Insights approfondis sur les modèles architecturaux, les stratégies d'implémentation et les meilleures pratiques
    - Accent sur le MCP en tant que protocole mature et prêt pour la production

#### Mises à jour du guide d'étude (study_guide.md)
- **Carte visuelle du curriculum** : Mise à jour de la carte mentale pour inclure le registre MCP de GitHub dans la section Études de cas
- **Description des études de cas** : Passée de descriptions génériques à une analyse détaillée des sept études de cas complètes
- **Structure du dépôt** : Mise à jour de la section 10 pour refléter la couverture complète des études de cas avec des détails spécifiques sur l'implémentation
- **Intégration du journal des modifications** : Ajout de l'entrée du 26 septembre 2025 documentant l'ajout du registre MCP de GitHub et les améliorations des études de cas
- **Mises à jour de la date** : Mise à jour de l'horodatage du pied de page pour refléter la dernière révision (26 septembre 2025)

### Améliorations de la qualité de la documentation
- **Amélioration de la cohérence** : Standardisation du format et de la structure des études de cas dans tous les exemples
- **Couverture complète** : Les études de cas couvrent désormais les scénarios d'entreprise, de productivité des développeurs et de développement de l'écosystème
- **Positionnement stratégique** : Accent renforcé sur le MCP en tant que plateforme fondamentale pour le déploiement des systèmes agentiques
- **Intégration des ressources** : Mise à jour des ressources supplémentaires pour inclure le lien vers le registre MCP de GitHub

## 15 septembre 2025

### Expansion des sujets avancés - Transports personnalisés et ingénierie du contexte

#### Transports personnalisés MCP (05-AdvancedTopics/mcp-transport/) - Nouveau guide d'implémentation avancée
- **README.md** : Guide complet d'implémentation des mécanismes de transport personnalisés MCP
  - **Transport Azure Event Grid** : Implémentation complète de transport événementiel sans serveur
    - Exemples en C#, TypeScript et Python avec intégration Azure Functions
    - Modèles d'architecture événementielle pour des solutions MCP évolutives
    - Récepteurs webhook et gestion des messages push
  - **Transport Azure Event Hubs** : Implémentation de transport en streaming à haut débit
    - Capacités de streaming en temps réel pour des scénarios à faible latence
    - Stratégies de partitionnement et gestion des points de contrôle
    - Regroupement des messages et optimisation des performances
  - **Modèles d'intégration d'entreprise** : Exemples architecturaux prêts pour la production
    - Traitement MCP distribué sur plusieurs fonctions Azure
    - Architectures hybrides de transport combinant plusieurs types de transport
    - Stratégies de durabilité, fiabilité et gestion des erreurs des messages
  - **Sécurité et surveillance** : Intégration Azure Key Vault et modèles d'observabilité
    - Authentification par identité gérée et accès avec privilèges minimaux
    - Télémétrie Application Insights et surveillance des performances
    - Disjoncteurs et modèles de tolérance aux pannes
  - **Cadres de test** : Stratégies de test complètes pour les transports personnalisés
    - Tests unitaires avec doubles de test et cadres de simulation
    - Tests d'intégration avec conteneurs de test Azure
    - Considérations sur les tests de performance et de charge

#### Ingénierie du contexte (05-AdvancedTopics/mcp-contextengineering/) - Discipline émergente en IA
- **README.md** : Exploration complète de l'ingénierie du contexte en tant que domaine émergent
  - **Principes fondamentaux** : Partage complet du contexte, sensibilisation à la prise de décision et gestion des fenêtres de contexte
  - **Alignement avec le protocole MCP** : Comment la conception MCP répond aux défis de l'ingénierie du contexte
    - Limitations des fenêtres de contexte et stratégies de chargement progressif
    - Détermination de la pertinence et récupération dynamique du contexte
    - Gestion multi-modale du contexte et considérations de sécurité
  - **Approches d'implémentation** : Architectures mono-thread vs multi-agents
    - Techniques de découpage et de priorisation du contexte
    - Chargement progressif du contexte et stratégies de compression
    - Approches contextuelles en couches et optimisation de la récupération
  - **Cadre de mesure** : Métriques émergentes pour l'évaluation de l'efficacité du contexte
    - Efficacité des entrées, performances, qualité et considérations sur l'expérience utilisateur
    - Approches expérimentales pour l'optimisation du contexte
    - Analyse des échecs et méthodologies d'amélioration

#### Mises à jour de la navigation dans le curriculum (README.md)
- **Structure améliorée des modules** : Mise à jour de la table du curriculum pour inclure les nouveaux sujets avancés
  - Ajout des entrées Ingénierie du contexte (5.14) et Transport personnalisé (5.15)
  - Formatage cohérent et liens de navigation dans tous les modules
  - Descriptions mises à jour pour refléter la portée actuelle du contenu

### Améliorations de la structure des répertoires
- **Standardisation des noms** : Renommage de "mcp transport" en "mcp-transport" pour la cohérence avec les autres dossiers de sujets avancés
- **Organisation du contenu** : Tous les dossiers 05-AdvancedTopics suivent désormais un modèle de nommage cohérent (mcp-[sujet])

### Améliorations de la qualité de la documentation
- **Alignement avec la spécification MCP** : Tout le nouveau contenu fait référence à la spécification MCP actuelle 2025-06-18
- **Exemples multi-langues** : Exemples de code complets en C#, TypeScript et Python
- **Focus sur l'entreprise** : Modèles prêts pour la production et intégration cloud Azure tout au long
- **Documentation visuelle** : Diagrammes Mermaid pour la visualisation des architectures et des flux

## 18 août 2025

### Mise à jour complète de la documentation - Normes MCP 2025-06-18

#### Meilleures pratiques de sécurité MCP (02-Security/) - Modernisation complète
- **MCP-SECURITY-BEST-PRACTICES-2025.md** : Réécriture complète alignée avec la spécification MCP 2025-06-18
  - **Exigences obligatoires** : Ajout d'exigences explicites DOIT/NE DOIT PAS de la spécification officielle avec des indicateurs visuels clairs
  - **12 pratiques de sécurité essentielles** : Restructuration d'une liste de 15 éléments en domaines de sécurité complets
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

#### Contrôles de sécurité avancés (02-Security/) - Implémentation d'entreprise
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
  - **Exemples d'implémentation** : Ajout de blocs de configuration YAML détaillés et d'exemples de code
  - **Intégration des solutions Microsoft** : Couverture complète des services de sécurité Azure, GitHub Advanced Security et gestion des identités d'entreprise

#### Sécurité des sujets avancés (05-AdvancedTopics/mcp-security/) - Implémentation prête pour la production
- **README.md** : Réécriture complète pour l'implémentation de la sécurité d'entreprise
  - **Alignement avec la spécification actuelle** : Mise à jour vers la spécification MCP 2025-06-18 avec exigences de sécurité obligatoires
  - **Authentification améliorée** : Intégration Microsoft Entra ID avec exemples complets en .NET et Java Spring Security
  - **Intégration de la sécurité IA** : Implémentation Microsoft Prompt Shields et Azure Content Safety avec exemples détaillés en Python
  - **Atténuation avancée des menaces** : Exemples d'implémentation complets pour
    - Prévention des attaques de type "confused deputy" avec PKCE et validation du consentement utilisateur
    - Prévention du passage des jetons avec validation de l'audience et gestion sécurisée des jetons
    - Prévention des détournements de session avec liaison cryptographique et analyse comportementale
  - **Intégration de la sécurité d'entreprise** : Surveillance Application Insights Azure, pipelines de détection des menaces et sécurité de la chaîne d'approvisionnement
  - **Liste de contrôle d'implémentation** : Contrôles de sécurité obligatoires vs recommandés avec avantages de l'écosystème de sécurité Microsoft

### Améliorations de la qualité et alignement avec les normes
- **Références de spécification** : Mise à jour de toutes les références vers la spécification MCP actuelle 2025-06-18
- **Écosystème de sécurité Microsoft** : Guide d'intégration amélioré dans toute la documentation de sécurité
- **Implémentation pratique** : Ajout d'exemples de code détaillés en .NET, Java et Python avec modèles d'entreprise
- **Organisation des ressources** : Catégorisation complète des liens de documentation officielle, normes de sécurité et guides d'implémentation
- **Indicateurs visuels** : Marquage clair des exigences obligatoires vs pratiques recommandées

#### Concepts fondamentaux (01-CoreConcepts/) - Modernisation complète
- **Mise à jour de la version du protocole** : Mise à jour pour référencer la spécification MCP actuelle 2025-06-18 avec versionnement basé sur la date (format AAAA-MM-JJ)
- **Affinement de l'architecture** : Descriptions améliorées des hôtes, clients et serveurs pour refléter les modèles d'architecture MCP actuels
  - Les hôtes sont désormais clairement définis comme des applications IA coordonnant plusieurs connexions client MCP
  - Les clients sont décrits comme des connecteurs de protocole maintenant des relations un-à-un avec les serveurs
  - Les serveurs sont améliorés avec des scénarios de déploiement local vs distant
- **Restructuration des primitives** : Refonte complète des primitives serveur et client
  - Primitives serveur : Ressources (sources de données), Prompts (modèles), Outils (fonctions exécutables) avec explications et exemples détaillés
  - Primitives client : Échantillonnage (complétions LLM), Élicitation (entrée utilisateur), Journalisation (débogage/surveillance)
  - Mise à jour avec les modèles actuels de découverte (`*/list`), récupération (`*/get`) et exécution (`*/call`)
- **Architecture du protocole** : Introduction d'un modèle d'architecture à deux couches
  - Couche de données : Fondation JSON-RPC 2.0 avec gestion du cycle de vie et primitives
  - Couche de transport : STDIO (local) et HTTP streamable avec SSE (transport distant)
- **Cadre de sécurité** : Principes de sécurité complets incluant consentement explicite de l'utilisateur, protection de la confidentialité des données, sécurité de l'exécution des outils et sécurité de la couche de transport
- **Modèles de communication** : Mise à jour des messages du protocole pour montrer les flux d'initialisation, de découverte, d'exécution et de notification
- **Exemples de code** : Actualisation des exemples multi-langues (.NET, Java, Python, JavaScript) pour refléter les modèles SDK MCP actuels

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
  - Détournement de session avec scénarios d'attaque spécifiques au MCP et exigences cryptographiques pour les ID de session
  - Problèmes de type "confused deputy" dans les scénarios proxy MCP avec exigences explicites de consentement
  - Vulnérabilités de passage des jetons avec contrôles de validation obligatoires
- **Sécurité de la chaîne d'approvisionnement** : Couverture étendue de la chaîne d'approvisionnement IA incluant modèles de base, services d'embeddings, fournisseurs de contexte et API tierces
- **Sécurité fondamentale** : Intégration renforcée avec des modèles de sécurité d'entreprise incluant architecture zéro confiance et écosystème de sécurité Microsoft
- **Organisation des ressources** : Catégorisation complète des liens de ressources par type (Docs officiels, Normes, Recherche, Solutions Microsoft, Guides d'implémentation)

### Améliorations de la qualité de la documentation
- **Objectifs d'apprentissage structurés** : Objectifs d'apprentissage améliorés avec résultats spécifiques et actionnables 
- **Références croisées** : Ajout de liens entre les sujets de sécurité et de concepts fondamentaux connexes
- **Informations actuelles** : Mise à jour de toutes les références de date et des liens de spécification vers les normes actuelles
- **Guide d'implémentation** : Ajout de directives d'implémentation spécifiques et actionnables dans toutes les sections

## 16 juillet 2025

### Améliorations
- Remplacé les balises `<details>` par un format basé sur des tableaux plus accessible
- Créé des options de mise en page alternatives dans le nouveau dossier "alternative_layouts"
- Ajouté des exemples de navigation basés sur des cartes, des onglets et des styles accordéon
- Mis à jour la section sur la structure du dépôt pour inclure tous les fichiers récents
- Amélioré la section "Comment utiliser ce programme" avec des recommandations claires
- Mis à jour les liens de spécification MCP pour pointer vers les URL correctes
- Ajouté la section "Ingénierie contextuelle" (5.14) à la structure du programme

### Mises à jour du guide d'étude
- Révision complète du guide d'étude pour s'aligner sur la structure actuelle du dépôt
- Ajout de nouvelles sections pour les clients et outils MCP, ainsi que pour les serveurs MCP populaires
- Mis à jour la carte visuelle du programme pour refléter précisément tous les sujets
- Amélioré les descriptions des sujets avancés pour couvrir toutes les zones spécialisées
- Mis à jour la section études de cas avec des exemples concrets
- Ajouté ce journal des modifications complet

### Contributions de la communauté (06-CommunityContributions/)
- Ajouté des informations détaillées sur les serveurs MCP pour la génération d'images
- Ajouté une section complète sur l'utilisation de Claude dans VSCode
- Ajouté des instructions de configuration et d'utilisation du client terminal Cline
- Mis à jour la section client MCP pour inclure toutes les options populaires
- Amélioré les exemples de contributions avec des échantillons de code plus précis

### Sujets avancés (05-AdvancedTopics/)
- Organisé tous les dossiers de sujets spécialisés avec une nomenclature cohérente
- Ajouté des matériaux et exemples sur l'ingénierie contextuelle
- Ajouté la documentation sur l'intégration des agents Foundry
- Amélioré la documentation sur l'intégration de la sécurité Entra ID

## 11 juin 2025

### Création initiale
- Publié la première version du programme MCP pour débutants
- Créé la structure de base pour les 10 sections principales
- Implémenté une carte visuelle du programme pour la navigation
- Ajouté des projets d'exemple initiaux dans plusieurs langages de programmation

### Premiers pas (03-GettingStarted/)
- Créé les premiers exemples d'implémentation de serveur
- Ajouté des conseils pour le développement de clients
- Inclus des instructions d'intégration de clients LLM
- Ajouté la documentation d'intégration VS Code
- Implémenté des exemples de serveur avec événements envoyés par le serveur (SSE)

### Concepts fondamentaux (01-CoreConcepts/)
- Ajouté une explication détaillée de l'architecture client-serveur
- Créé une documentation sur les composants clés du protocole
- Documenté les modèles de messagerie dans MCP

## 23 mai 2025

### Structure du dépôt
- Initialisé le dépôt avec une structure de dossiers de base
- Créé des fichiers README pour chaque section majeure
- Mis en place une infrastructure de traduction
- Ajouté des ressources d'image et des diagrammes

### Documentation
- Créé le README.md initial avec un aperçu du programme
- Ajouté CODE_OF_CONDUCT.md et SECURITY.md
- Mis en place SUPPORT.md avec des conseils pour obtenir de l'aide
- Créé une structure préliminaire pour le guide d'étude

## 15 avril 2025

### Planification et cadre
- Planification initiale du programme MCP pour débutants
- Définition des objectifs d'apprentissage et du public cible
- Ébauche de la structure en 10 sections du programme
- Développement du cadre conceptuel pour les exemples et études de cas
- Créé des prototypes initiaux pour les concepts clés

---

