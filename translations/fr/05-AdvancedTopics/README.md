<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T14:32:09+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "fr"
}
-->
# Sujets avancés en MCP

Ce chapitre aborde une série de sujets avancés dans l’implémentation du Model Context Protocol (MCP), notamment l’intégration multimodale, la scalabilité, les bonnes pratiques de sécurité et l’intégration en entreprise. Ces thèmes sont essentiels pour développer des applications MCP robustes et prêtes pour la production, capables de répondre aux exigences des systèmes d’IA modernes.

## Vue d’ensemble

Cette leçon explore des concepts avancés dans l’implémentation du Model Context Protocol, en mettant l’accent sur l’intégration multimodale, la scalabilité, les meilleures pratiques de sécurité et l’intégration en entreprise. Ces sujets sont indispensables pour construire des applications MCP de qualité production capables de gérer des exigences complexes en environnement professionnel.

## Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :

- Implémenter des fonctionnalités multimodales au sein des frameworks MCP
- Concevoir des architectures MCP scalables pour des scénarios à forte demande
- Appliquer les meilleures pratiques de sécurité conformes aux principes de sécurité de MCP
- Intégrer MCP avec des systèmes et frameworks IA d’entreprise
- Optimiser les performances et la fiabilité en environnement de production

## Leçons et projets exemples

| Lien | Titre | Description |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Intégration avec Azure | Apprenez à intégrer votre MCP Server sur Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Exemples multimodaux MCP | Exemples pour réponses audio, image et multimodales |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Démo MCP OAuth2 | Application Spring Boot minimale montrant OAuth2 avec MCP, à la fois comme serveur d’autorisation et serveur de ressources. Démonstration de l’émission sécurisée de tokens, des endpoints protégés, du déploiement sur Azure Container Apps et de l’intégration avec API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Contextes racines | En savoir plus sur les contextes racines et leur implémentation |
| [5.5 Routing](./mcp-routing/README.md) | Routage | Découvrez les différents types de routage |
| [5.6 Sampling](./mcp-sampling/README.md) | Échantillonnage | Apprenez à gérer l’échantillonnage |
| [5.7 Scaling](./mcp-scaling/README.md) | Scalabilité | Comprendre la scalabilité |
| [5.8 Security](./mcp-security/README.md) | Sécurité | Sécurisez votre MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Recherche Web MCP | Serveur et client MCP Python intégrant SerpAPI pour la recherche web, actualités, produits et Q&A en temps réel. Démonstration de l’orchestration multi-outils, de l’intégration d’API externes et d’une gestion robuste des erreurs. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Le streaming de données en temps réel est devenu essentiel dans le monde actuel axé sur les données, où les entreprises et applications ont besoin d’un accès immédiat à l’information pour prendre des décisions rapides. |

## Références supplémentaires

Pour les informations les plus récentes sur les sujets avancés MCP, consultez :
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Points clés à retenir

- Les implémentations MCP multimodales étendent les capacités de l’IA au-delà du traitement du texte
- La scalabilité est cruciale pour les déploiements en entreprise et peut être abordée via la montée en charge horizontale et verticale
- Des mesures de sécurité complètes protègent les données et garantissent un contrôle d’accès approprié
- L’intégration en entreprise avec des plateformes comme Azure OpenAI et Microsoft AI Foundry renforce les capacités MCP
- Les implémentations avancées de MCP bénéficient d’architectures optimisées et d’une gestion rigoureuse des ressources

## Exercice

Concevez une implémentation MCP de niveau entreprise pour un cas d’usage spécifique :

1. Identifiez les besoins multimodaux pour votre cas d’usage
2. Définissez les contrôles de sécurité nécessaires pour protéger les données sensibles
3. Concevez une architecture scalable capable de gérer des charges variables
4. Planifiez les points d’intégration avec les systèmes IA d’entreprise
5. Documentez les goulots d’étranglement potentiels en termes de performance et les stratégies d’atténuation

## Ressources complémentaires

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## La suite

- [5.1 MCP Integration](./mcp-integration/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforçons d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour des informations critiques, il est recommandé de recourir à une traduction professionnelle réalisée par un humain. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.