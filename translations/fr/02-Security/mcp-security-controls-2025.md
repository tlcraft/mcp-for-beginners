<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-16T23:05:32+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "fr"
}
-->
# Derniers Contrôles de Sécurité MCP - Mise à jour de juillet 2025

Alors que le Model Context Protocol (MCP) continue d’évoluer, la sécurité reste une considération essentielle. Ce document présente les derniers contrôles de sécurité et les meilleures pratiques pour une mise en œuvre sécurisée du MCP à la date de juillet 2025.

## Authentification et Autorisation

### Support de la délégation OAuth 2.0

Les récentes mises à jour de la spécification MCP permettent désormais aux serveurs MCP de déléguer l’authentification des utilisateurs à des services externes tels que Microsoft Entra ID. Cela améliore considérablement la posture de sécurité en :

1. **Éliminant l’implémentation d’authentification personnalisée** : Réduit le risque de failles dans le code d’authentification personnalisé  
2. **Tirant parti des fournisseurs d’identité établis** : Bénéficie des fonctionnalités de sécurité de niveau entreprise  
3. **Centralisant la gestion des identités** : Simplifie la gestion du cycle de vie des utilisateurs et le contrôle d’accès  

## Prévention du passage de jetons

La spécification MCP Authorization interdit explicitement le passage de jetons afin d’éviter la contournement des contrôles de sécurité et les problèmes de responsabilité.

### Exigences clés

1. **Les serveurs MCP NE DOIVENT PAS accepter de jetons non émis pour eux** : Valider que tous les jetons possèdent la bonne revendication d’audience  
2. **Mettre en œuvre une validation correcte des jetons** : Vérifier l’émetteur, l’audience, la date d’expiration et la signature  
3. **Utiliser une émission de jetons distincte** : Émettre de nouveaux jetons pour les services en aval plutôt que de transmettre les jetons existants  

## Gestion sécurisée des sessions

Pour prévenir les attaques de détournement et de fixation de session, appliquez les contrôles suivants :

1. **Utiliser des identifiants de session sécurisés et non déterministes** : Générés avec des générateurs de nombres aléatoires cryptographiquement sécurisés  
2. **Lier les sessions à l’identité utilisateur** : Combiner les identifiants de session avec des informations spécifiques à l’utilisateur  
3. **Mettre en place une rotation appropriée des sessions** : Après les changements d’authentification ou une élévation de privilèges  
4. **Définir des délais d’expiration de session adaptés** : Trouver un équilibre entre sécurité et expérience utilisateur  

## Isolation de l’exécution des outils

Pour empêcher les mouvements latéraux et contenir les compromissions potentielles :

1. **Isoler les environnements d’exécution des outils** : Utiliser des conteneurs ou des processus séparés  
2. **Appliquer des limites de ressources** : Prévenir les attaques par épuisement des ressources  
3. **Mettre en œuvre le principe du moindre privilège** : Accorder uniquement les permissions nécessaires  
4. **Surveiller les schémas d’exécution** : Détecter les comportements anormaux  

## Protection des définitions d’outils

Pour éviter la compromission des outils :

1. **Valider les définitions d’outils avant utilisation** : Vérifier la présence d’instructions malveillantes ou de motifs inappropriés  
2. **Utiliser la vérification d’intégrité** : Hasher ou signer les définitions d’outils pour détecter les modifications non autorisées  
3. **Mettre en place une surveillance des modifications** : Alerter en cas de changements inattendus des métadonnées des outils  
4. **Gérer les versions des définitions d’outils** : Suivre les modifications et permettre un retour en arrière si nécessaire  

Ces contrôles fonctionnent de concert pour établir une posture de sécurité robuste pour les implémentations MCP, répondant aux défis uniques des systèmes pilotés par l’IA tout en maintenant des pratiques de sécurité traditionnelles solides.

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.