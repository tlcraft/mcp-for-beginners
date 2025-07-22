<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "18f070888eb7266c0733fca698cb095e",
  "translation_date": "2025-07-22T07:37:46+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "fr"
}
-->
# MCP en Action : Études de Cas Réelles

Le protocole Model Context Protocol (MCP) transforme la manière dont les applications d'IA interagissent avec les données, les outils et les services. Cette section présente des études de cas réelles qui illustrent des applications pratiques de MCP dans divers scénarios d'entreprise.

## Vue d'ensemble

Cette section met en avant des exemples concrets d'implémentations de MCP, soulignant comment les organisations utilisent ce protocole pour résoudre des défis métier complexes. En examinant ces études de cas, vous découvrirez la polyvalence, l'évolutivité et les avantages pratiques de MCP dans des situations réelles.

## Objectifs d'apprentissage clés

En explorant ces études de cas, vous allez :

- Comprendre comment MCP peut être appliqué pour résoudre des problèmes métier spécifiques
- Découvrir différents modèles d'intégration et approches architecturales
- Identifier les meilleures pratiques pour implémenter MCP dans des environnements d'entreprise
- Obtenir des informations sur les défis et solutions rencontrés dans des implémentations réelles
- Repérer des opportunités pour appliquer des modèles similaires à vos propres projets

## Études de Cas Présentées

### 1. [Agents de Voyage Azure AI – Implémentation de Référence](./travelagentsample.md)

Cette étude de cas examine la solution de référence complète de Microsoft qui montre comment créer une application de planification de voyage alimentée par l'IA et multi-agents en utilisant MCP, Azure OpenAI et Azure AI Search. Le projet met en avant :

- L'orchestration multi-agents via MCP
- L'intégration de données d'entreprise avec Azure AI Search
- Une architecture sécurisée et évolutive utilisant les services Azure
- Des outils extensibles avec des composants MCP réutilisables
- Une expérience utilisateur conversationnelle alimentée par Azure OpenAI

Les détails d'architecture et d'implémentation fournissent des informations précieuses sur la construction de systèmes complexes multi-agents avec MCP comme couche de coordination.

### 2. [Mise à Jour des Éléments Azure DevOps à partir de Données YouTube](./UpdateADOItemsFromYT.md)

Cette étude de cas démontre une application pratique de MCP pour automatiser les processus de flux de travail. Elle montre comment les outils MCP peuvent être utilisés pour :

- Extraire des données de plateformes en ligne (YouTube)
- Mettre à jour des éléments de travail dans les systèmes Azure DevOps
- Créer des flux de travail d'automatisation reproductibles
- Intégrer des données entre des systèmes disparates

Cet exemple illustre comment même des implémentations MCP relativement simples peuvent offrir des gains d'efficacité significatifs en automatisant des tâches routinières et en améliorant la cohérence des données entre les systèmes.

### 3. [Récupération de Documentation en Temps Réel avec MCP](./docs-mcp/README.md)

Cette étude de cas vous guide dans la connexion d'un client console Python à un serveur Model Context Protocol (MCP) pour récupérer et enregistrer en temps réel des documentations Microsoft contextuelles. Vous apprendrez à :

- Connecter un client Python à un serveur MCP en utilisant le SDK officiel MCP
- Utiliser des clients HTTP en streaming pour une récupération de données efficace en temps réel
- Appeler des outils de documentation sur le serveur et enregistrer les réponses directement dans la console
- Intégrer des documentations Microsoft à jour dans votre flux de travail sans quitter le terminal

Le chapitre inclut un exercice pratique, un exemple de code minimal fonctionnel et des liens vers des ressources supplémentaires pour un apprentissage approfondi. Consultez le guide complet et le code dans le chapitre lié pour comprendre comment MCP peut transformer l'accès à la documentation et la productivité des développeurs dans des environnements basés sur la console.

### 4. [Application Web Interactive de Génération de Plans d'Étude avec MCP](./docs-mcp/README.md)

Cette étude de cas montre comment créer une application web interactive en utilisant Chainlit et le protocole Model Context Protocol (MCP) pour générer des plans d'étude personnalisés sur n'importe quel sujet. Les utilisateurs peuvent spécifier un sujet (par exemple, "certification AI-900") et une durée d'étude (par exemple, 8 semaines), et l'application fournira une répartition hebdomadaire du contenu recommandé. Chainlit permet une interface de chat conversationnelle, rendant l'expérience engageante et adaptative.

- Application web conversationnelle alimentée par Chainlit
- Prompts utilisateur pour le sujet et la durée
- Recommandations de contenu hebdomadaires via MCP
- Réponses adaptatives en temps réel dans une interface de chat

Le projet illustre comment l'IA conversationnelle et MCP peuvent être combinés pour créer des outils éducatifs dynamiques et centrés sur l'utilisateur dans un environnement web moderne.

### 5. [Documentation Intégrée dans l'Éditeur avec le Serveur MCP dans VS Code](./docs-mcp/README.md)

Cette étude de cas montre comment intégrer directement les documentations Microsoft Learn dans votre environnement VS Code en utilisant le serveur MCP—plus besoin de changer d'onglet de navigateur ! Vous découvrirez comment :

- Rechercher et lire instantanément des documentations dans VS Code via le panneau MCP ou la palette de commandes
- Référencer des documentations et insérer des liens directement dans vos fichiers README ou markdown de cours
- Utiliser GitHub Copilot et MCP ensemble pour des flux de travail de documentation et de code alimentés par l'IA
- Valider et améliorer vos documentations avec des retours en temps réel et la précision des sources Microsoft
- Intégrer MCP avec les workflows GitHub pour une validation continue des documentations

L'implémentation inclut :

- Un exemple de configuration `.vscode/mcp.json` pour une installation facile
- Des guides illustrés par captures d'écran de l'expérience dans l'éditeur
- Des conseils pour combiner Copilot et MCP pour une productivité maximale

Ce scénario est idéal pour les auteurs de cours, les rédacteurs de documentation et les développeurs souhaitant rester concentrés dans leur éditeur tout en travaillant avec des documentations, Copilot et des outils de validation—le tout alimenté par MCP.

### 6. [Création d'un Serveur MCP avec APIM](./apimsample.md)

Cette étude de cas fournit un guide étape par étape sur la création d'un serveur MCP en utilisant Azure API Management (APIM). Elle couvre :

- La configuration d'un serveur MCP dans Azure API Management
- L'exposition des opérations API en tant qu'outils MCP
- La configuration de politiques pour la limitation de débit et la sécurité
- Les tests du serveur MCP en utilisant Visual Studio Code et GitHub Copilot

Cet exemple illustre comment exploiter les capacités d'Azure pour créer un serveur MCP robuste pouvant être utilisé dans diverses applications, améliorant l'intégration des systèmes d'IA avec les API d'entreprise.

## Conclusion

Ces études de cas mettent en lumière la polyvalence et les applications pratiques du protocole Model Context Protocol dans des scénarios réels. Des systèmes multi-agents complexes aux flux de travail d'automatisation ciblés, MCP offre une méthode standardisée pour connecter les systèmes d'IA aux outils et données nécessaires pour générer de la valeur.

En étudiant ces implémentations, vous pouvez acquérir des connaissances sur les modèles architecturaux, les stratégies d'implémentation et les meilleures pratiques applicables à vos propres projets MCP. Les exemples démontrent que MCP n'est pas seulement un cadre théorique, mais une solution pratique à des défis métier réels.

## Ressources Supplémentaires

- [Dépôt GitHub des Agents de Voyage Azure AI](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Outil MCP pour Azure DevOps](https://github.com/microsoft/azure-devops-mcp)
- [Outil MCP pour Playwright](https://github.com/microsoft/playwright-mcp)
- [Serveur MCP pour Microsoft Docs](https://github.com/MicrosoftDocs/mcp)
- [Exemples Communautaires MCP](https://github.com/microsoft/mcp)

Prochain : Atelier Pratique [Optimisation des Flux de Travail IA : Création d'un Serveur MCP avec AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d'assurer l'exactitude, veuillez noter que les traductions automatisées peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant autorité. Pour des informations critiques, il est recommandé de recourir à une traduction professionnelle réalisée par un humain. Nous ne sommes pas responsables des malentendus ou des interprétations erronées résultant de l'utilisation de cette traduction.