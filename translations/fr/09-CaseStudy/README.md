<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-07-29T00:01:15+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "fr"
}
-->
# MCP en action : Études de cas réelles

[![MCP en action : Études de cas réelles](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.fr.png)](https://youtu.be/IxshWb2Az5w)

_(Cliquez sur l'image ci-dessus pour visionner la vidéo de cette leçon)_

Le protocole Model Context Protocol (MCP) transforme la manière dont les applications d'IA interagissent avec les données, les outils et les services. Cette section présente des études de cas réelles qui illustrent les applications pratiques du MCP dans divers scénarios d'entreprise.

## Aperçu

Cette section met en avant des exemples concrets d'implémentations du MCP, montrant comment les organisations utilisent ce protocole pour résoudre des défis complexes. En examinant ces études de cas, vous découvrirez la polyvalence, l'évolutivité et les avantages pratiques du MCP dans des situations réelles.

## Objectifs d'apprentissage clés

En explorant ces études de cas, vous allez :

- Comprendre comment le MCP peut être appliqué pour résoudre des problèmes spécifiques en entreprise
- Découvrir différents modèles d'intégration et approches architecturales
- Identifier les meilleures pratiques pour implémenter le MCP dans des environnements professionnels
- Obtenir des informations sur les défis et solutions rencontrés lors d'implémentations réelles
- Repérer des opportunités pour appliquer des modèles similaires dans vos propres projets

## Études de cas présentées

### 1. [Agents de voyage Azure AI – Implémentation de référence](./travelagentsample.md)

Cette étude de cas examine la solution de référence complète de Microsoft qui montre comment créer une application de planification de voyage alimentée par l'IA et multi-agents en utilisant MCP, Azure OpenAI et Azure AI Search. Le projet met en avant :

- L'orchestration multi-agents via MCP
- L'intégration des données d'entreprise avec Azure AI Search
- Une architecture sécurisée et évolutive utilisant les services Azure
- Des outils extensibles avec des composants MCP réutilisables
- Une expérience utilisateur conversationnelle alimentée par Azure OpenAI

Les détails de l'architecture et de l'implémentation offrent des informations précieuses sur la construction de systèmes complexes multi-agents avec MCP comme couche de coordination.

### 2. [Mise à jour des éléments Azure DevOps à partir des données YouTube](./UpdateADOItemsFromYT.md)

Cette étude de cas montre une application pratique du MCP pour automatiser les processus de workflow. Elle démontre comment les outils MCP peuvent être utilisés pour :

- Extraire des données de plateformes en ligne (YouTube)
- Mettre à jour des éléments de travail dans les systèmes Azure DevOps
- Créer des workflows d'automatisation reproductibles
- Intégrer des données entre des systèmes disparates

Cet exemple illustre comment même des implémentations MCP relativement simples peuvent offrir des gains d'efficacité significatifs en automatisant des tâches routinières et en améliorant la cohérence des données entre les systèmes.

### 3. [Récupération de documentation en temps réel avec MCP](./docs-mcp/README.md)

Cette étude de cas vous guide dans la connexion d'un client console Python à un serveur Model Context Protocol (MCP) pour récupérer et enregistrer en temps réel des documentations Microsoft contextuelles. Vous apprendrez à :

- Connecter un client Python à un serveur MCP en utilisant le SDK officiel MCP
- Utiliser des clients HTTP en streaming pour une récupération de données efficace en temps réel
- Appeler des outils de documentation sur le serveur et enregistrer les réponses directement dans la console
- Intégrer des documentations Microsoft à jour dans votre workflow sans quitter le terminal

Le chapitre inclut un exercice pratique, un exemple de code fonctionnel minimal et des liens vers des ressources supplémentaires pour approfondir vos connaissances. Consultez le guide complet et le code dans le chapitre lié pour comprendre comment le MCP peut transformer l'accès à la documentation et la productivité des développeurs dans des environnements basés sur la console.

### 4. [Application web génératrice de plans d'étude interactifs avec MCP](./docs-mcp/README.md)

Cette étude de cas montre comment créer une application web interactive en utilisant Chainlit et le Model Context Protocol (MCP) pour générer des plans d'étude personnalisés sur n'importe quel sujet. Les utilisateurs peuvent spécifier un sujet (comme "certification AI-900") et une durée d'étude (par exemple, 8 semaines), et l'application fournira une répartition hebdomadaire des contenus recommandés. Chainlit permet une interface de chat conversationnelle, rendant l'expérience engageante et adaptative.

- Application web conversationnelle alimentée par Chainlit
- Prompts utilisateur pour le sujet et la durée
- Recommandations de contenu semaine par semaine via MCP
- Réponses adaptatives en temps réel dans une interface de chat

Le projet illustre comment l'IA conversationnelle et le MCP peuvent être combinés pour créer des outils éducatifs dynamiques et centrés sur l'utilisateur dans un environnement web moderne.

### 5. [Documentation intégrée dans l'éditeur avec serveur MCP dans VS Code](./docs-mcp/README.md)

Cette étude de cas montre comment intégrer directement les documentations Microsoft Learn dans votre environnement VS Code en utilisant le serveur MCP—plus besoin de changer d'onglet de navigateur ! Vous découvrirez comment :

- Rechercher et lire instantanément des documentations dans VS Code via le panneau MCP ou la palette de commandes
- Référencer des documentations et insérer des liens directement dans vos fichiers README ou markdown de cours
- Utiliser GitHub Copilot et MCP ensemble pour des workflows de documentation et de code alimentés par l'IA
- Valider et améliorer vos documentations avec des retours en temps réel et une précision basée sur les sources Microsoft
- Intégrer MCP avec les workflows GitHub pour une validation continue des documentations

L'implémentation inclut :

- Un exemple de configuration `.vscode/mcp.json` pour une installation facile
- Des guides illustrés par captures d'écran de l'expérience dans l'éditeur
- Des conseils pour combiner Copilot et MCP pour une productivité maximale

Ce scénario est idéal pour les auteurs de cours, les rédacteurs de documentation et les développeurs souhaitant rester concentrés dans leur éditeur tout en travaillant avec des documentations, Copilot et des outils de validation—tout cela grâce au MCP.

### 6. [Création d'un serveur MCP avec APIM](./apimsample.md)

Cette étude de cas fournit un guide étape par étape pour créer un serveur MCP en utilisant Azure API Management (APIM). Elle couvre :

- La configuration d'un serveur MCP dans Azure API Management
- L'exposition des opérations API en tant qu'outils MCP
- La configuration de politiques pour la limitation de débit et la sécurité
- Les tests du serveur MCP avec Visual Studio Code et GitHub Copilot

Cet exemple illustre comment exploiter les capacités d'Azure pour créer un serveur MCP robuste pouvant être utilisé dans diverses applications, améliorant l'intégration des systèmes d'IA avec les API d'entreprise.

## Conclusion

Ces études de cas mettent en lumière la polyvalence et les applications pratiques du Model Context Protocol dans des scénarios réels. Des systèmes multi-agents complexes aux workflows d'automatisation ciblés, le MCP offre une méthode standardisée pour connecter les systèmes d'IA aux outils et données nécessaires pour générer de la valeur.

En étudiant ces implémentations, vous pouvez acquérir des connaissances sur les modèles architecturaux, les stratégies d'implémentation et les meilleures pratiques applicables à vos propres projets MCP. Les exemples démontrent que le MCP n'est pas seulement un cadre théorique, mais une solution pratique aux défis réels des entreprises.

## Ressources supplémentaires

- [Référentiel GitHub des agents de voyage Azure AI](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Outil MCP Azure DevOps](https://github.com/microsoft/azure-devops-mcp)
- [Outil MCP Playwright](https://github.com/microsoft/playwright-mcp)
- [Serveur MCP Microsoft Docs](https://github.com/MicrosoftDocs/mcp)
- [Exemples communautaires MCP](https://github.com/microsoft/mcp)

Suivant : Atelier pratique [Rationalisation des workflows IA : Création d'un serveur MCP avec AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d'assurer l'exactitude, veuillez noter que les traductions automatisées peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant autorité. Pour des informations critiques, il est recommandé de recourir à une traduction professionnelle réalisée par un humain. Nous ne sommes pas responsables des malentendus ou des interprétations erronées résultant de l'utilisation de cette traduction.