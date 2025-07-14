<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8311f46a35cf608c9780f39b62c9dc3f",
  "translation_date": "2025-07-14T01:57:27+00:00",
  "source_file": "05-AdvancedTopics/mcp-root-contexts/README.md",
  "language_code": "fr"
}
-->
## Exemple : Implémentation d'un contexte racine pour l'analyse financière

Dans cet exemple, nous allons créer un contexte racine pour une session d'analyse financière, en montrant comment maintenir l'état à travers plusieurs interactions.

## Exemple : Gestion des contextes racines

Gérer efficacement les contextes racines est essentiel pour conserver l'historique des conversations et l'état. Voici un exemple de mise en œuvre de la gestion des contextes racines.

## Contexte racine pour une assistance multi-tours

Dans cet exemple, nous allons créer un contexte racine pour une session d'assistance multi-tours, en montrant comment maintenir l'état à travers plusieurs interactions.

## Bonnes pratiques pour les contextes racines

Voici quelques bonnes pratiques pour gérer efficacement les contextes racines :

- **Créer des contextes ciblés** : Créez des contextes racines distincts pour différents objectifs ou domaines de conversation afin de garder une bonne clarté.

- **Définir des politiques d'expiration** : Mettez en place des règles pour archiver ou supprimer les anciens contextes afin de gérer le stockage et respecter les politiques de conservation des données.

- **Stocker les métadonnées pertinentes** : Utilisez les métadonnées du contexte pour enregistrer des informations importantes sur la conversation qui pourraient être utiles ultérieurement.

- **Utiliser les identifiants de contexte de manière cohérente** : Une fois un contexte créé, utilisez son ID de façon constante pour toutes les requêtes associées afin de maintenir la continuité.

- **Générer des résumés** : Lorsque le contexte devient volumineux, envisagez de créer des résumés pour capturer les informations essentielles tout en maîtrisant la taille du contexte.

- **Mettre en place un contrôle d'accès** : Pour les systèmes multi-utilisateurs, implémentez des contrôles d'accès appropriés pour garantir la confidentialité et la sécurité des contextes de conversation.

- **Gérer les limitations des contextes** : Soyez conscient des limites de taille des contextes et mettez en place des stratégies pour gérer les conversations très longues.

- **Archiver une fois la conversation terminée** : Archivez les contextes lorsque les conversations sont terminées pour libérer des ressources tout en conservant l'historique.

## Et ensuite

- [5.5 Routage](../mcp-routing/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.