<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "671162f2687253f22af11187919ed02d",
  "translation_date": "2025-06-21T13:31:30+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "fr"
}
-->
# MCP en Action : Études de Cas Concrètes

Le Model Context Protocol (MCP) révolutionne la manière dont les applications d’IA interagissent avec les données, les outils et les services. Cette section présente des études de cas réelles qui illustrent des applications pratiques du MCP dans divers contextes d’entreprise.

## Vue d’ensemble

Cette section met en lumière des exemples concrets d’implémentations du MCP, soulignant comment les organisations utilisent ce protocole pour résoudre des problématiques métier complexes. En explorant ces études de cas, vous découvrirez la polyvalence, l’évolutivité et les avantages concrets du MCP dans des situations réelles.

## Objectifs clés d’apprentissage

En parcourant ces études de cas, vous allez :

- Comprendre comment le MCP peut être utilisé pour résoudre des problèmes métier spécifiques
- Découvrir différents modèles d’intégration et approches architecturales
- Identifier les bonnes pratiques pour implémenter le MCP en environnement d’entreprise
- Appréhender les défis et solutions rencontrés lors d’implémentations réelles
- Repérer des opportunités pour appliquer des modèles similaires dans vos propres projets

## Études de cas mises en avant

### 1. [Azure AI Travel Agents – Implémentation de Référence](./travelagentsample.md)

Cette étude de cas analyse la solution de référence complète de Microsoft qui montre comment créer une application de planification de voyages multi-agents et alimentée par l’IA en utilisant MCP, Azure OpenAI et Azure AI Search. Le projet met en avant :

- L’orchestration multi-agents via MCP
- L’intégration des données d’entreprise avec Azure AI Search
- Une architecture sécurisée et évolutive grâce aux services Azure
- Des outils extensibles avec des composants MCP réutilisables
- Une expérience utilisateur conversationnelle propulsée par Azure OpenAI

L’architecture et les détails d’implémentation offrent un éclairage précieux pour construire des systèmes multi-agents complexes avec MCP comme couche de coordination.

### 2. [Mise à jour des éléments Azure DevOps à partir des données YouTube](./UpdateADOItemsFromYT.md)

Cette étude de cas illustre une application pratique du MCP pour automatiser des processus de travail. Elle montre comment les outils MCP peuvent servir à :

- Extraire des données depuis des plateformes en ligne (YouTube)
- Mettre à jour des éléments de travail dans Azure DevOps
- Créer des workflows d’automatisation reproductibles
- Intégrer des données issues de systèmes disparates

Cet exemple démontre comment des implémentations MCP relativement simples peuvent générer des gains d’efficacité importants en automatisant les tâches répétitives et en améliorant la cohérence des données entre systèmes.

### 3. [Récupération en temps réel de documentation avec MCP](./docs-mcp/README.md)

Cette étude de cas vous guide pour connecter un client console Python à un serveur Model Context Protocol (MCP) afin de récupérer et enregistrer en temps réel la documentation Microsoft contextuelle. Vous apprendrez à :

- Vous connecter à un serveur MCP via un client Python et le SDK officiel MCP
- Utiliser des clients HTTP en streaming pour une récupération efficace et en temps réel des données
- Appeler les outils de documentation sur le serveur et enregistrer les réponses directement dans la console
- Intégrer la documentation Microsoft à jour dans votre flux de travail sans quitter le terminal

Le chapitre inclut un exercice pratique, un exemple de code minimal fonctionnel, ainsi que des liens vers des ressources complémentaires pour approfondir vos connaissances. Consultez le tutoriel complet et le code dans le chapitre lié pour comprendre comment MCP peut transformer l’accès à la documentation et la productivité des développeurs en environnement console.

### 4. [Application web interactive de génération de plans d’étude avec MCP](./docs-mcp/README.md)

Cette étude de cas montre comment créer une application web interactive avec Chainlit et le Model Context Protocol (MCP) pour générer des plans d’étude personnalisés sur n’importe quel sujet. Les utilisateurs peuvent spécifier un thème (comme la certification « AI-900 ») et une durée d’étude (par exemple 8 semaines), et l’application fournit un découpage semaine par semaine des contenus recommandés. Chainlit offre une interface de chat conversationnelle, rendant l’expérience engageante et adaptable.

- Application web conversationnelle propulsée par Chainlit
- Saisie utilisateur pour le sujet et la durée
- Recommandations de contenu hebdomadaires grâce au MCP
- Réponses adaptatives en temps réel dans une interface de chat

Le projet illustre comment combiner IA conversationnelle et MCP pour créer des outils éducatifs dynamiques et centrés utilisateur dans un environnement web moderne.

### 5. [Documentation intégrée à l’éditeur avec MCP Server dans VS Code](./docs-mcp/README.md)

Cette étude de cas montre comment intégrer directement la documentation Microsoft Learn dans votre environnement VS Code grâce au serveur MCP—plus besoin de changer d’onglet dans le navigateur ! Vous verrez comment :

- Rechercher et lire instantanément la documentation dans VS Code via le panneau MCP ou la palette de commandes
- Référencer la documentation et insérer des liens directement dans vos fichiers README ou markdown de cours
- Utiliser GitHub Copilot et MCP ensemble pour des workflows de documentation et de code assistés par IA fluides
- Valider et enrichir votre documentation avec des retours en temps réel et une précision garantie par Microsoft
- Intégrer MCP aux workflows GitHub pour une validation continue de la documentation

L’implémentation inclut :
- Une configuration d’exemple `.vscode/mcp.json` pour une mise en place simplifiée
- Des captures d’écran illustrant l’expérience dans l’éditeur
- Des astuces pour combiner Copilot et MCP afin d’optimiser la productivité

Ce scénario est idéal pour les auteurs de cours, rédacteurs techniques et développeurs souhaitant rester concentrés dans leur éditeur tout en travaillant avec la documentation, Copilot et les outils de validation—le tout propulsé par MCP.

## Conclusion

Ces études de cas mettent en avant la polyvalence et les applications concrètes du Model Context Protocol dans des situations réelles. Des systèmes multi-agents complexes aux workflows d’automatisation ciblés, MCP offre une méthode standardisée pour connecter les systèmes d’IA aux outils et données nécessaires à la création de valeur.

En étudiant ces implémentations, vous découvrirez des modèles architecturaux, des stratégies d’implémentation et des bonnes pratiques applicables à vos propres projets MCP. Ces exemples montrent que MCP n’est pas qu’un cadre théorique, mais une solution concrète aux défis métiers actuels.

## Ressources supplémentaires

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforçons d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle humaine est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.