<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1949cb32394aeb1bdec8870f309005a3",
  "translation_date": "2025-07-16T21:23:38+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "fr"
}
-->
# Sujets avancés en MCP

Ce chapitre aborde une série de sujets avancés dans l’implémentation du Model Context Protocol (MCP), incluant l’intégration multimodale, la scalabilité, les bonnes pratiques de sécurité et l’intégration en entreprise. Ces thèmes sont essentiels pour construire des applications MCP robustes et prêtes pour la production, capables de répondre aux exigences des systèmes d’IA modernes.

## Aperçu

Cette leçon explore des concepts avancés dans l’implémentation du Model Context Protocol, en mettant l’accent sur l’intégration multimodale, la scalabilité, les bonnes pratiques de sécurité et l’intégration en entreprise. Ces sujets sont indispensables pour développer des applications MCP de qualité production capables de gérer des besoins complexes dans des environnements professionnels.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :

- Mettre en œuvre des capacités multimodales au sein des frameworks MCP
- Concevoir des architectures MCP évolutives pour des scénarios à forte demande
- Appliquer les meilleures pratiques de sécurité conformes aux principes de sécurité de MCP
- Intégrer MCP avec les systèmes et frameworks d’IA en entreprise
- Optimiser la performance et la fiabilité en environnement de production

## Leçons et projets d’exemple

| Lien | Titre | Description |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Intégration avec Azure | Apprenez à intégrer votre serveur MCP sur Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Exemples multimodaux MCP | Exemples pour réponses audio, image et multimodales |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Démo MCP OAuth2 | Application Spring Boot minimale montrant OAuth2 avec MCP, à la fois comme serveur d’autorisation et serveur de ressources. Démonstration de l’émission sécurisée de tokens, des endpoints protégés, du déploiement sur Azure Container Apps et de l’intégration avec API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Contextes racines | En savoir plus sur les contextes racines et leur implémentation |
| [5.5 Routing](./mcp-routing/README.md) | Routage | Découvrez les différents types de routage |
| [5.6 Sampling](./mcp-sampling/README.md) | Échantillonnage | Apprenez à travailler avec l’échantillonnage |
| [5.7 Scaling](./mcp-scaling/README.md) | Scalabilité | Découvrez la scalabilité |
| [5.8 Security](./mcp-security/README.md) | Sécurité | Sécurisez votre serveur MCP |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Recherche Web MCP | Serveur et client MCP en Python intégrant SerpAPI pour la recherche web, actualités, produits et Q&R en temps réel. Démonstration d’orchestration multi-outils, d’intégration d’API externes et de gestion robuste des erreurs. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Le streaming de données en temps réel est devenu essentiel dans le monde axé sur les données d’aujourd’hui, où les entreprises et applications ont besoin d’un accès immédiat à l’information pour prendre des décisions rapides. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Recherche Web en temps réel | Comment MCP transforme la recherche web en temps réel en fournissant une approche standardisée de la gestion du contexte entre modèles d’IA, moteurs de recherche et applications. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Authentification Entra ID | Microsoft Entra ID offre une solution robuste de gestion des identités et des accès basée sur le cloud, garantissant que seuls les utilisateurs et applications autorisés peuvent interagir avec votre serveur MCP. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Intégration Azure AI Foundry | Apprenez à intégrer les serveurs Model Context Protocol avec les agents Azure AI Foundry, permettant une orchestration puissante des outils et des capacités d’IA en entreprise grâce à des connexions standardisées aux sources de données externes. |

## Références supplémentaires

Pour les informations les plus récentes sur les sujets avancés MCP, consultez :
- [Documentation MCP](https://modelcontextprotocol.io/)
- [Spécification MCP](https://spec.modelcontextprotocol.io/)
- [Dépôt GitHub](https://github.com/modelcontextprotocol)

## Points clés à retenir

- Les implémentations MCP multimodales étendent les capacités d’IA au-delà du traitement du texte
- La scalabilité est cruciale pour les déploiements en entreprise et peut être abordée par le scaling horizontal et vertical
- Des mesures de sécurité complètes protègent les données et assurent un contrôle d’accès approprié
- L’intégration en entreprise avec des plateformes comme Azure OpenAI et Microsoft AI Foundry renforce les capacités MCP
- Les implémentations avancées MCP bénéficient d’architectures optimisées et d’une gestion rigoureuse des ressources

## Exercice

Concevez une implémentation MCP de niveau entreprise pour un cas d’usage spécifique :

1. Identifiez les besoins multimodaux de votre cas d’usage
2. Définissez les contrôles de sécurité nécessaires pour protéger les données sensibles
3. Concevez une architecture évolutive capable de gérer des charges variables
4. Planifiez les points d’intégration avec les systèmes d’IA en entreprise
5. Documentez les goulets d’étranglement potentiels en termes de performance et les stratégies d’atténuation

## Ressources supplémentaires

- [Documentation Azure OpenAI](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Documentation Microsoft AI Foundry](https://learn.microsoft.com/en-us/ai-services/)

---

## Et ensuite

- [5.1 MCP Integration](./mcp-integration/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.