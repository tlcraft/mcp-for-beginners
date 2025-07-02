<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-02T08:48:02+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "fr"
}
-->
# Sujets Avancés en MCP

Ce chapitre couvre une série de sujets avancés dans l’implémentation du Model Context Protocol (MCP), incluant l’intégration multimodale, la scalabilité, les bonnes pratiques de sécurité et l’intégration en entreprise. Ces thèmes sont essentiels pour construire des applications MCP robustes et prêtes pour la production, capables de répondre aux exigences des systèmes d’IA modernes.

## Aperçu

Cette leçon explore des concepts avancés dans l’implémentation du Model Context Protocol, en mettant l’accent sur l’intégration multimodale, la scalabilité, les bonnes pratiques de sécurité et l’intégration en entreprise. Ces sujets sont indispensables pour développer des applications MCP de niveau production capables de gérer des besoins complexes en environnement professionnel.

## Objectifs d’Apprentissage

À la fin de cette leçon, vous serez capable de :

- Implémenter des capacités multimodales au sein des frameworks MCP  
- Concevoir des architectures MCP évolutives pour des scénarios à forte demande  
- Appliquer les meilleures pratiques de sécurité conformes aux principes de sécurité MCP  
- Intégrer MCP avec les systèmes et frameworks IA d’entreprise  
- Optimiser la performance et la fiabilité en environnement de production  

## Leçons et Projets d’Exemple

| Lien | Titre | Description |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Intégration avec Azure | Apprenez à intégrer votre serveur MCP sur Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Exemples multimodaux MCP | Exemples pour réponses audio, image et multimodales |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Démo MCP OAuth2 | Application Spring Boot minimale montrant OAuth2 avec MCP, à la fois comme serveur d’autorisation et serveur de ressources. Démonstration de l’émission sécurisée de tokens, des points d’accès protégés, du déploiement sur Azure Container Apps et de l’intégration avec API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Contextes racines | En savoir plus sur les contextes racines et comment les implémenter |
| [5.5 Routing](./mcp-routing/README.md) | Routage | Apprenez les différents types de routage |
| [5.6 Sampling](./mcp-sampling/README.md) | Échantillonnage | Apprenez à travailler avec l’échantillonnage |
| [5.7 Scaling](./mcp-scaling/README.md) | Scalabilité | Découvrez la scalabilité |
| [5.8 Security](./mcp-security/README.md) | Sécurité | Sécurisez votre serveur MCP |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Recherche Web MCP | Serveur et client MCP en Python intégrant SerpAPI pour la recherche web, d’actualités, de produits et Q&A en temps réel. Démonstration de l’orchestration multi-outils, de l’intégration d’API externes et d’une gestion robuste des erreurs. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Le streaming de données en temps réel est devenu essentiel dans un monde axé sur les données, où entreprises et applications nécessitent un accès immédiat à l’information pour prendre des décisions rapides. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Recherche Web | Comment MCP transforme la recherche web en temps réel en offrant une approche standardisée de la gestion du contexte entre modèles IA, moteurs de recherche et applications. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Authentification Entra ID | Microsoft Entra ID fournit une solution robuste de gestion des identités et des accès dans le cloud, garantissant que seuls les utilisateurs et applications autorisés peuvent interagir avec votre serveur MCP. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Intégration Azure AI Foundry | Apprenez à intégrer les serveurs Model Context Protocol avec les agents Azure AI Foundry, permettant une orchestration puissante d’outils et des capacités IA d’entreprise avec des connexions standardisées aux sources de données externes. |

## Références Supplémentaires

Pour les informations les plus récentes sur les sujets avancés MCP, consultez :  
- [MCP Documentation](https://modelcontextprotocol.io/)  
- [MCP Specification](https://spec.modelcontextprotocol.io/)  
- [GitHub Repository](https://github.com/modelcontextprotocol)  

## Points Clés à Retenir

- Les implémentations MCP multimodales étendent les capacités IA au-delà du traitement textuel  
- La scalabilité est cruciale pour les déploiements en entreprise et peut être abordée par une montée en charge horizontale et verticale  
- Des mesures de sécurité complètes protègent les données et assurent un contrôle d’accès approprié  
- L’intégration en entreprise avec des plateformes comme Azure OpenAI et Microsoft AI Foundry renforce les capacités MCP  
- Les implémentations avancées MCP bénéficient d’architectures optimisées et d’une gestion rigoureuse des ressources  

## Exercice

Concevez une implémentation MCP de niveau entreprise pour un cas d’usage spécifique :

1. Identifiez les besoins multimodaux de votre cas d’usage  
2. Définissez les contrôles de sécurité nécessaires pour protéger les données sensibles  
3. Concevez une architecture évolutive capable de gérer des charges variables  
4. Planifiez les points d’intégration avec les systèmes IA d’entreprise  
5. Documentez les éventuels goulets d’étranglement en performance et les stratégies d’atténuation  

## Ressources Supplémentaires

- [Documentation Azure OpenAI](https://learn.microsoft.com/en-us/azure/ai-services/openai/)  
- [Documentation Microsoft AI Foundry](https://learn.microsoft.com/en-us/ai-services/)  

---

## Quelle est la suite

- [5.1 MCP Integration](./mcp-integration/README.md)

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d'assurer l'exactitude, veuillez noter que les traductions automatisées peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant autorité. Pour les informations critiques, il est recommandé de recourir à une traduction professionnelle réalisée par un humain. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l'utilisation de cette traduction.