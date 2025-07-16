<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-16T23:10:50+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "fr"
}
-->
# Meilleures pratiques de sécurité MCP - Mise à jour de juillet 2025

## Meilleures pratiques de sécurité complètes pour les implémentations MCP

Lorsque vous travaillez avec des serveurs MCP, suivez ces meilleures pratiques de sécurité pour protéger vos données, votre infrastructure et vos utilisateurs :

1. **Validation des entrées** : Validez et assainissez toujours les entrées pour éviter les attaques par injection et les problèmes de délégué confus.
   - Mettez en place une validation stricte pour tous les paramètres des outils
   - Utilisez la validation de schéma pour garantir que les requêtes respectent les formats attendus
   - Filtrez les contenus potentiellement malveillants avant traitement

2. **Contrôle d’accès** : Mettez en œuvre une authentification et une autorisation appropriées pour votre serveur MCP avec des permissions granulaires.
   - Utilisez OAuth 2.0 avec des fournisseurs d’identité reconnus comme Microsoft Entra ID
   - Implémentez un contrôle d’accès basé sur les rôles (RBAC) pour les outils MCP
   - N’implémentez jamais d’authentification personnalisée lorsque des solutions établies existent

3. **Communication sécurisée** : Utilisez HTTPS/TLS pour toutes les communications avec votre serveur MCP et envisagez un chiffrement supplémentaire pour les données sensibles.
   - Configurez TLS 1.3 lorsque c’est possible
   - Mettez en place le pinning de certificats pour les connexions critiques
   - Renouvelez régulièrement les certificats et vérifiez leur validité

4. **Limitation du débit** : Implémentez une limitation du débit pour prévenir les abus, les attaques DoS et gérer la consommation des ressources.
   - Définissez des limites de requêtes adaptées aux usages prévus
   - Mettez en place des réponses graduées face aux requêtes excessives
   - Envisagez des limites spécifiques par utilisateur selon leur statut d’authentification

5. **Journalisation et surveillance** : Surveillez votre serveur MCP pour détecter toute activité suspecte et mettez en place des pistes d’audit complètes.
   - Enregistrez toutes les tentatives d’authentification et les invocations d’outils
   - Implémentez des alertes en temps réel pour les comportements suspects
   - Assurez-vous que les journaux sont stockés de manière sécurisée et ne peuvent pas être altérés

6. **Stockage sécurisé** : Protégez les données sensibles et les identifiants avec un chiffrement approprié au repos.
   - Utilisez des coffres-forts à clés ou des stockages sécurisés pour tous les secrets
   - Mettez en œuvre un chiffrement au niveau des champs pour les données sensibles
   - Renouvelez régulièrement les clés de chiffrement et les identifiants

7. **Gestion des tokens** : Évitez les vulnérabilités liées au passage de tokens en validant et assainissant toutes les entrées et sorties des modèles.
   - Implémentez la validation des tokens basée sur les revendications d’audience
   - N’acceptez jamais de tokens non explicitement émis pour votre serveur MCP
   - Gérez correctement la durée de vie des tokens et leur renouvellement

8. **Gestion des sessions** : Mettez en place une gestion sécurisée des sessions pour prévenir le détournement et la fixation de session.
   - Utilisez des identifiants de session sécurisés et non déterministes
   - Associez les sessions à des informations spécifiques à l’utilisateur
   - Implémentez une expiration et un renouvellement appropriés des sessions

9. **Sandboxing de l’exécution des outils** : Exécutez les outils dans des environnements isolés pour empêcher les mouvements latéraux en cas de compromission.
   - Mettez en place une isolation par conteneur pour l’exécution des outils
   - Appliquez des limites de ressources pour éviter les attaques par épuisement
   - Utilisez des contextes d’exécution séparés pour différents domaines de sécurité

10. **Audits de sécurité réguliers** : Réalisez des revues de sécurité périodiques de vos implémentations MCP et de leurs dépendances.
    - Planifiez des tests d’intrusion réguliers
    - Utilisez des outils d’analyse automatisés pour détecter les vulnérabilités
    - Maintenez les dépendances à jour pour corriger les failles connues

11. **Filtrage de sécurité du contenu** : Mettez en place des filtres de sécurité du contenu pour les entrées comme pour les sorties.
    - Utilisez Azure Content Safety ou des services similaires pour détecter les contenus nuisibles
    - Implémentez des techniques de protection des prompts pour éviter les injections
    - Analysez le contenu généré pour détecter toute fuite potentielle de données sensibles

12. **Sécurité de la chaîne d’approvisionnement** : Vérifiez l’intégrité et l’authenticité de tous les composants de votre chaîne d’approvisionnement IA.
    - Utilisez des packages signés et vérifiez les signatures
    - Mettez en œuvre une analyse du bill of materials logiciel (SBOM)
    - Surveillez les mises à jour malveillantes des dépendances

13. **Protection des définitions d’outils** : Prévenez l’empoisonnement des outils en sécurisant leurs définitions et métadonnées.
    - Validez les définitions d’outils avant leur utilisation
    - Surveillez les modifications inattendues des métadonnées des outils
    - Mettez en place des contrôles d’intégrité pour les définitions d’outils

14. **Surveillance dynamique de l’exécution** : Surveillez le comportement en temps réel des serveurs MCP et des outils.
    - Implémentez une analyse comportementale pour détecter les anomalies
    - Configurez des alertes pour les schémas d’exécution inattendus
    - Utilisez des techniques de protection applicative en temps réel (RASP)

15. **Principe du moindre privilège** : Assurez-vous que les serveurs MCP et les outils fonctionnent avec les permissions minimales nécessaires.
    - Accordez uniquement les permissions spécifiques requises pour chaque opération
    - Révisez et auditez régulièrement l’utilisation des permissions
    - Mettez en place un accès just-in-time pour les fonctions administratives

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.