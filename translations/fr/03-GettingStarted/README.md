<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "97f1c99b5b12cf03d4b1be68b3636a4a",
  "translation_date": "2025-07-04T15:18:40+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "fr"
}
-->
## Prise en main  

Cette section comprend plusieurs leçons :

- **1 Votre premier serveur**, dans cette première leçon, vous apprendrez à créer votre premier serveur et à l’inspecter avec l’outil d’inspection, un moyen précieux pour tester et déboguer votre serveur, [vers la leçon](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, dans cette leçon, vous apprendrez à écrire un client capable de se connecter à votre serveur, [vers la leçon](/03-GettingStarted/02-client/README.md)

- **3 Client avec LLM**, une façon encore meilleure d’écrire un client est d’y ajouter un LLM pour qu’il puisse « négocier » avec votre serveur sur ce qu’il doit faire, [vers la leçon](/03-GettingStarted/03-llm-client/README.md)

- **4 Consommation d’un serveur en mode GitHub Copilot Agent dans Visual Studio Code**. Ici, nous verrons comment exécuter notre MCP Server depuis Visual Studio Code, [vers la leçon](/03-GettingStarted/04-vscode/README.md)

- **5 Consommation via SSE (Server Sent Events)** SSE est une norme pour le streaming serveur vers client, permettant aux serveurs d’envoyer des mises à jour en temps réel aux clients via HTTP [vers la leçon](/03-GettingStarted/05-sse-server/README.md)

- **6 Streaming HTTP avec MCP (Streamable HTTP)**. Découvrez le streaming HTTP moderne, les notifications de progression, et comment implémenter des serveurs et clients MCP évolutifs et en temps réel avec Streamable HTTP. [vers la leçon](/03-GettingStarted/06-http-streaming/README.md)

- **7 Utilisation de AI Toolkit pour VSCode** pour consommer et tester vos clients et serveurs MCP [vers la leçon](/03-GettingStarted/07-aitk/README.md)

- **8 Tests**. Ici, nous nous concentrerons particulièrement sur les différentes façons de tester notre serveur et client, [vers la leçon](/03-GettingStarted/08-testing/README.md)

- **9 Déploiement**. Ce chapitre abordera différentes méthodes pour déployer vos solutions MCP, [vers la leçon](/03-GettingStarted/09-deployment/README.md)


Le Model Context Protocol (MCP) est un protocole ouvert qui standardise la manière dont les applications fournissent du contexte aux LLM. Pensez à MCP comme à un port USB-C pour les applications d’IA – il offre un moyen standardisé de connecter les modèles d’IA à différentes sources de données et outils.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :

- Configurer des environnements de développement pour MCP en C#, Java, Python, TypeScript et JavaScript
- Construire et déployer des serveurs MCP basiques avec des fonctionnalités personnalisées (ressources, prompts et outils)
- Créer des applications hôtes qui se connectent aux serveurs MCP
- Tester et déboguer des implémentations MCP
- Comprendre les défis courants d’installation et leurs solutions
- Connecter vos implémentations MCP aux services LLM populaires

## Configuration de votre environnement MCP

Avant de commencer à travailler avec MCP, il est important de préparer votre environnement de développement et de comprendre le flux de travail de base. Cette section vous guidera à travers les étapes initiales pour garantir un démarrage fluide avec MCP.

### Prérequis

Avant de vous lancer dans le développement MCP, assurez-vous d’avoir :

- **Environnement de développement** : pour le langage choisi (C#, Java, Python, TypeScript ou JavaScript)
- **IDE/Éditeur** : Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ou tout éditeur de code moderne
- **Gestionnaires de paquets** : NuGet, Maven/Gradle, pip ou npm/yarn
- **Clés API** : pour tous les services d’IA que vous prévoyez d’utiliser dans vos applications hôtes


### SDK officiels

Dans les chapitres à venir, vous verrez des solutions construites avec Python, TypeScript, Java et .NET. Voici tous les SDK officiellement supportés.

MCP propose des SDK officiels pour plusieurs langages :
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Maintenu en collaboration avec Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Maintenu en collaboration avec Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - L’implémentation officielle en TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - L’implémentation officielle en Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - L’implémentation officielle en Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Maintenu en collaboration avec Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - L’implémentation officielle en Rust

## Points clés à retenir

- La configuration d’un environnement de développement MCP est simple grâce aux SDK spécifiques à chaque langage
- Construire des serveurs MCP implique de créer et d’enregistrer des outils avec des schémas clairs
- Les clients MCP se connectent aux serveurs et modèles pour exploiter des capacités étendues
- Les tests et le débogage sont essentiels pour des implémentations MCP fiables
- Les options de déploiement vont du développement local aux solutions cloud

## Pratique

Nous disposons d’un ensemble d’exemples qui complètent les exercices que vous trouverez dans tous les chapitres de cette section. De plus, chaque chapitre propose ses propres exercices et devoirs.

- [Calculatrice Java](./samples/java/calculator/README.md)
- [Calculatrice .Net](../../../03-GettingStarted/samples/csharp)
- [Calculatrice JavaScript](./samples/javascript/README.md)
- [Calculatrice TypeScript](./samples/typescript/README.md)
- [Calculatrice Python](../../../03-GettingStarted/samples/python)

## Ressources supplémentaires

- [Créer des agents avec Model Context Protocol sur Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP distant avec Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [Agent MCP OpenAI .NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Et ensuite

Suivant : [Créer votre premier serveur MCP](./01-first-server/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.