<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-14T05:39:59+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "fr"
}
-->
# MCP en action : Études de cas réelles

Le Model Context Protocol (MCP) révolutionne la manière dont les applications d’IA interagissent avec les données, les outils et les services. Cette section présente des études de cas concrètes illustrant des applications pratiques du MCP dans divers scénarios d’entreprise.

## Aperçu

Cette section met en avant des exemples concrets d’implémentations du MCP, soulignant comment les organisations exploitent ce protocole pour résoudre des défis métier complexes. En examinant ces études de cas, vous découvrirez la polyvalence, la scalabilité et les bénéfices concrets du MCP dans des contextes réels.

## Objectifs d’apprentissage clés

En explorant ces études de cas, vous allez :

- Comprendre comment le MCP peut être utilisé pour résoudre des problèmes métier spécifiques
- Découvrir différents modèles d’intégration et approches architecturales
- Identifier les bonnes pratiques pour implémenter le MCP en environnement d’entreprise
- Obtenir des retours d’expérience sur les défis et solutions rencontrés lors d’implémentations réelles
- Repérer des opportunités pour appliquer des modèles similaires dans vos propres projets

## Études de cas présentées

### 1. [Agents de voyage Azure AI – Implémentation de référence](./travelagentsample.md)

Cette étude de cas analyse la solution de référence complète de Microsoft qui montre comment construire une application de planification de voyage multi-agents alimentée par l’IA, en utilisant MCP, Azure OpenAI et Azure AI Search. Le projet met en avant :

- L’orchestration multi-agents via MCP
- L’intégration des données d’entreprise avec Azure AI Search
- Une architecture sécurisée et scalable basée sur les services Azure
- Des outils extensibles avec des composants MCP réutilisables
- Une expérience utilisateur conversationnelle propulsée par Azure OpenAI

L’architecture et les détails d’implémentation offrent des enseignements précieux pour concevoir des systèmes multi-agents complexes avec MCP comme couche de coordination.

### 2. [Mise à jour des éléments Azure DevOps à partir des données YouTube](./UpdateADOItemsFromYT.md)

Cette étude de cas illustre une application pratique du MCP pour automatiser des processus de travail. Elle montre comment les outils MCP peuvent être utilisés pour :

- Extraire des données depuis des plateformes en ligne (YouTube)
- Mettre à jour des éléments de travail dans Azure DevOps
- Créer des workflows d’automatisation reproductibles
- Intégrer des données issues de systèmes disparates

Cet exemple démontre que même des implémentations MCP relativement simples peuvent générer des gains d’efficacité importants en automatisant des tâches routinières et en améliorant la cohérence des données entre systèmes.

### 3. [Récupération de documentation en temps réel avec MCP](./docs-mcp/README.md)

Cette étude de cas vous guide pour connecter un client console Python à un serveur Model Context Protocol (MCP) afin de récupérer et enregistrer en temps réel la documentation Microsoft contextuelle. Vous apprendrez à :

- Vous connecter à un serveur MCP avec un client Python et le SDK officiel MCP
- Utiliser des clients HTTP en streaming pour une récupération efficace et en temps réel des données
- Appeler les outils de documentation sur le serveur et enregistrer les réponses directement dans la console
- Intégrer la documentation Microsoft à jour dans votre flux de travail sans quitter le terminal

Le chapitre inclut un exercice pratique, un exemple de code minimal fonctionnel, ainsi que des liens vers des ressources complémentaires pour approfondir. Consultez le tutoriel complet et le code dans le chapitre lié pour comprendre comment MCP peut transformer l’accès à la documentation et la productivité des développeurs dans un environnement console.

### 4. [Application web interactive de génération de plans d’étude avec MCP](./docs-mcp/README.md)

Cette étude de cas montre comment créer une application web interactive utilisant Chainlit et le Model Context Protocol (MCP) pour générer des plans d’étude personnalisés sur n’importe quel sujet. Les utilisateurs peuvent spécifier un thème (par exemple « certification AI-900 ») et une durée d’étude (ex. 8 semaines), et l’application fournit un découpage hebdomadaire des contenus recommandés. Chainlit permet une interface de chat conversationnelle, rendant l’expérience engageante et adaptative.

- Application web conversationnelle propulsée par Chainlit
- Saisie utilisateur pour le sujet et la durée
- Recommandations de contenu semaine par semaine via MCP
- Réponses adaptatives en temps réel dans une interface de chat

Le projet illustre comment l’IA conversationnelle et MCP peuvent être combinés pour créer des outils éducatifs dynamiques et centrés utilisateur dans un environnement web moderne.

### 5. [Documentation intégrée dans l’éditeur avec MCP Server dans VS Code](./docs-mcp/README.md)

Cette étude de cas montre comment intégrer directement Microsoft Learn Docs dans votre environnement VS Code grâce au serveur MCP — plus besoin de changer d’onglet de navigateur ! Vous découvrirez comment :

- Rechercher et lire instantanément la documentation dans VS Code via le panneau MCP ou la palette de commandes
- Référencer la documentation et insérer des liens directement dans vos fichiers README ou markdown de cours
- Utiliser GitHub Copilot et MCP ensemble pour des workflows de documentation et de code assistés par IA
- Valider et enrichir votre documentation avec des retours en temps réel et une précision issue de Microsoft
- Intégrer MCP aux workflows GitHub pour une validation continue de la documentation

L’implémentation comprend :
- Un exemple de configuration `.vscode/mcp.json` pour une mise en place facile
- Des captures d’écran illustrant l’expérience dans l’éditeur
- Des conseils pour combiner Copilot et MCP pour une productivité optimale

Ce scénario est idéal pour les auteurs de cours, rédacteurs techniques et développeurs souhaitant rester concentrés dans leur éditeur tout en travaillant avec la documentation, Copilot et les outils de validation — le tout propulsé par MCP.

### 6. [Création d’un serveur MCP avec APIM](./apimsample.md)

Cette étude de cas propose un guide pas à pas pour créer un serveur MCP en utilisant Azure API Management (APIM). Elle couvre :

- La mise en place d’un serveur MCP dans Azure API Management
- L’exposition des opérations API en tant qu’outils MCP
- La configuration des politiques de limitation de débit et de sécurité
- Les tests du serveur MCP avec Visual Studio Code et GitHub Copilot

Cet exemple montre comment tirer parti des capacités d’Azure pour créer un serveur MCP robuste, utilisable dans diverses applications, améliorant l’intégration des systèmes IA avec les API d’entreprise.

## Conclusion

Ces études de cas illustrent la polyvalence et les applications concrètes du Model Context Protocol dans des contextes réels. Des systèmes multi-agents complexes aux workflows d’automatisation ciblés, MCP offre une méthode standardisée pour connecter les systèmes IA aux outils et données nécessaires à la création de valeur.

En étudiant ces implémentations, vous découvrirez des modèles architecturaux, des stratégies d’implémentation et des bonnes pratiques applicables à vos propres projets MCP. Ces exemples démontrent que MCP n’est pas qu’un cadre théorique, mais une solution pragmatique aux défis métier réels.

## Ressources supplémentaires

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Suivant : Hands on Lab [Streamlining AI Workflows: Building an MCP Server with AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.