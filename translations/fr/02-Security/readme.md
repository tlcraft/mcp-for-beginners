<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-16T14:40:04+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "fr"
}
-->
# Meilleures pratiques de sécurité

L’adoption du Model Context Protocol (MCP) apporte des capacités puissantes aux applications pilotées par l’IA, mais introduit également des défis de sécurité uniques qui vont au-delà des risques logiciels traditionnels. En plus des préoccupations classiques telles que le codage sécurisé, le principe du moindre privilège et la sécurité de la chaîne d’approvisionnement, le MCP et les charges de travail IA font face à de nouvelles menaces comme l’injection de prompt, l’empoisonnement d’outils et la modification dynamique des outils. Ces risques peuvent entraîner une exfiltration de données, des violations de la vie privée et des comportements systèmes non souhaités s’ils ne sont pas correctement maîtrisés.

Cette leçon explore les risques de sécurité les plus pertinents associés au MCP — notamment l’authentification, l’autorisation, les permissions excessives, l’injection de prompt indirecte et les vulnérabilités de la chaîne d’approvisionnement — et fournit des contrôles et bonnes pratiques concrètes pour les atténuer. Vous apprendrez également comment exploiter les solutions Microsoft telles que Prompt Shields, Azure Content Safety et GitHub Advanced Security pour renforcer votre mise en œuvre MCP. En comprenant et appliquant ces contrôles, vous pouvez réduire significativement la probabilité d’une faille de sécurité et garantir que vos systèmes IA restent robustes et fiables.

# Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :

- Identifier et expliquer les risques de sécurité spécifiques introduits par le Model Context Protocol (MCP), y compris l’injection de prompt, l’empoisonnement d’outils, les permissions excessives et les vulnérabilités de la chaîne d’approvisionnement.
- Décrire et appliquer des contrôles efficaces pour atténuer les risques de sécurité liés au MCP, tels qu’une authentification robuste, le principe du moindre privilège, une gestion sécurisée des tokens et la vérification de la chaîne d’approvisionnement.
- Comprendre et exploiter les solutions Microsoft comme Prompt Shields, Azure Content Safety et GitHub Advanced Security pour protéger les charges de travail MCP et IA.
- Reconnaître l’importance de valider les métadonnées des outils, de surveiller les modifications dynamiques et de se défendre contre les attaques d’injection de prompt indirecte.
- Intégrer des bonnes pratiques de sécurité établies — comme le codage sécurisé, le durcissement des serveurs et l’architecture zero trust — dans votre implémentation MCP pour réduire la probabilité et l’impact des failles de sécurité.

# Contrôles de sécurité MCP

Tout système ayant accès à des ressources importantes présente des défis de sécurité implicites. Ces défis peuvent généralement être traités par l’application correcte de contrôles et concepts fondamentaux de sécurité. Comme le MCP est une spécification récente, celle-ci évolue rapidement. Au fil de son évolution, les contrôles de sécurité qu’il intègre mûriront, permettant une meilleure intégration avec les architectures et bonnes pratiques de sécurité d’entreprise établies.

La recherche publiée dans le [Microsoft Digital Defense Report](https://aka.ms/mddr) indique que 98 % des violations signalées auraient pu être évitées grâce à une hygiène de sécurité rigoureuse, et la meilleure protection contre toute forme de faille reste de bien maîtriser votre hygiène de sécurité de base, les bonnes pratiques de codage sécurisé et la sécurité de la chaîne d’approvisionnement — ces pratiques éprouvées restent les plus efficaces pour réduire les risques.

Examinons quelques façons de commencer à adresser les risques de sécurité lors de l’adoption du MCP.

# Authentification du serveur MCP (si votre implémentation MCP date d’avant le 26 avril 2025)

> **Note :** Les informations suivantes sont exactes au 26 avril 2025. Le protocole MCP évolue constamment, et les futures implémentations pourraient introduire de nouveaux schémas d’authentification et contrôles. Pour les dernières mises à jour et recommandations, consultez toujours la [Spécification MCP](https://spec.modelcontextprotocol.io/) et le [dépôt officiel MCP sur GitHub](https://github.com/modelcontextprotocol).

### Problématique  
La spécification MCP originale supposait que les développeurs écriraient leur propre serveur d’authentification. Cela nécessitait une connaissance d’OAuth et des contraintes de sécurité associées. Les serveurs MCP agissaient comme serveurs d’autorisation OAuth 2.0, gérant directement l’authentification utilisateur requise, au lieu de la déléguer à un service externe comme Microsoft Entra ID. Depuis le 26 avril 2025, une mise à jour de la spécification MCP permet aux serveurs MCP de déléguer l’authentification utilisateur à un service externe.

### Risques
- Une logique d’autorisation mal configurée dans le serveur MCP peut entraîner une exposition de données sensibles et des contrôles d’accès appliqués incorrectement.
- Le vol de tokens OAuth sur le serveur MCP local. Si un token est volé, il peut être utilisé pour usurper l’identité du serveur MCP et accéder aux ressources et données associées au token.

### Contrôles d’atténuation
- **Revoir et durcir la logique d’autorisation :** Auditez soigneusement l’implémentation de l’autorisation de votre serveur MCP pour garantir que seuls les utilisateurs et clients prévus peuvent accéder aux ressources sensibles. Pour des conseils pratiques, voir [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) et [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Appliquer des pratiques sécurisées de gestion des tokens :** Suivez les [meilleures pratiques Microsoft pour la validation et la durée de vie des tokens](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) afin de prévenir les usages abusifs des tokens d’accès et réduire le risque de rejouement ou de vol.
- **Protéger le stockage des tokens :** Stockez toujours les tokens de manière sécurisée et utilisez le chiffrement pour les protéger au repos et en transit. Pour des conseils d’implémentation, voir [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permissions excessives pour les serveurs MCP

### Problématique  
Les serveurs MCP peuvent se voir attribuer des permissions excessives sur les services ou ressources qu’ils accèdent. Par exemple, un serveur MCP faisant partie d’une application de vente IA connectée à une base de données d’entreprise devrait avoir un accès limité aux données de vente, et non à tous les fichiers du magasin. En référence au principe du moindre privilège (l’un des plus anciens principes de sécurité), aucune ressource ne devrait disposer de permissions supérieures à ce qui est nécessaire pour exécuter les tâches prévues. L’IA complique ce domaine car, pour rester flexible, il peut être difficile de définir précisément les permissions requises.

### Risques  
- Accorder des permissions excessives peut permettre l’exfiltration ou la modification de données auxquelles le serveur MCP n’était pas censé accéder. Cela peut aussi poser un problème de confidentialité si les données sont des informations personnelles identifiables (PII).

### Contrôles d’atténuation
- **Appliquer le principe du moindre privilège :** Accordez au serveur MCP uniquement les permissions minimales nécessaires à ses tâches. Révisez et mettez régulièrement à jour ces permissions pour éviter tout excès. Pour un guide détaillé, voir [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Utiliser le contrôle d’accès basé sur les rôles (RBAC) :** Attribuez des rôles au serveur MCP strictement limités aux ressources et actions spécifiques, en évitant les permissions larges ou inutiles.
- **Surveiller et auditer les permissions :** Contrôlez en continu l’usage des permissions et auditez les journaux d’accès pour détecter et corriger rapidement les privilèges excessifs ou inutilisés.

# Attaques d’injection de prompt indirecte

### Problématique

Les serveurs MCP malveillants ou compromis peuvent introduire des risques importants en exposant des données clients ou en provoquant des actions non souhaitées. Ces risques sont particulièrement pertinents dans les charges de travail IA et MCP, où :

- **Attaques d’injection de prompt :** Les attaquants insèrent des instructions malveillantes dans des prompts ou contenus externes, amenant le système IA à effectuer des actions non prévues ou à divulguer des données sensibles. En savoir plus : [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Empoisonnement d’outils :** Les attaquants manipulent les métadonnées des outils (comme les descriptions ou paramètres) pour influencer le comportement de l’IA, contournant potentiellement les contrôles de sécurité ou exfiltrant des données. Détails : [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Injection de prompt cross-domain :** Des instructions malveillantes sont intégrées dans des documents, pages web ou emails, qui sont ensuite traités par l’IA, provoquant des fuites ou manipulations de données.
- **Modification dynamique d’outils (Rug Pulls) :** Les définitions d’outils peuvent être modifiées après approbation utilisateur, introduisant de nouveaux comportements malveillants à l’insu de l’utilisateur.

Ces vulnérabilités soulignent la nécessité d’une validation rigoureuse, d’une surveillance et de contrôles de sécurité robustes lors de l’intégration des serveurs et outils MCP dans votre environnement. Pour approfondir, consultez les références ci-dessus.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.fr.png)

**Injection de prompt indirecte** (également appelée injection de prompt cross-domain ou XPIA) est une vulnérabilité critique dans les systèmes d’IA générative, y compris ceux utilisant le Model Context Protocol (MCP). Dans cette attaque, des instructions malveillantes sont cachées dans du contenu externe — comme des documents, pages web ou emails. Lorsque le système IA traite ce contenu, il peut interpréter ces instructions comme des commandes légitimes de l’utilisateur, entraînant des actions non souhaitées telles que la fuite de données, la génération de contenu nuisible ou la manipulation des interactions utilisateur. Pour une explication détaillée et des exemples concrets, voir [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Une forme particulièrement dangereuse de cette attaque est **l’empoisonnement d’outils**. Ici, les attaquants injectent des instructions malveillantes dans les métadonnées des outils MCP (comme les descriptions ou paramètres). Comme les grands modèles de langage (LLM) s’appuient sur ces métadonnées pour décider quels outils invoquer, des descriptions compromises peuvent tromper le modèle en l’incitant à exécuter des appels d’outils non autorisés ou à contourner les contrôles de sécurité. Ces manipulations sont souvent invisibles pour les utilisateurs finaux mais peuvent être interprétées et exploitées par le système IA. Ce risque est accru dans les environnements hébergés de serveurs MCP, où les définitions d’outils peuvent être mises à jour après approbation utilisateur — un scénario parfois appelé « [rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22) ». Dans ces cas, un outil auparavant sûr peut être modifié ultérieurement pour exécuter des actions malveillantes, comme exfiltrer des données ou altérer le comportement du système, sans que l’utilisateur en soit informé. Pour plus d’informations sur ce vecteur d’attaque, voir [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.fr.png)

## Risques  
Les actions non intentionnelles de l’IA présentent divers risques de sécurité, notamment l’exfiltration de données et les violations de la vie privée.

### Contrôles d’atténuation  
### Utilisation des prompt shields pour se protéger contre les attaques d’injection de prompt indirecte
-----------------------------------------------------------------------------

**AI Prompt Shields** sont une solution développée par Microsoft pour défendre contre les attaques d’injection de prompt directes et indirectes. Ils aident grâce à :

1.  **Détection et filtrage :** Les Prompt Shields utilisent des algorithmes avancés d’apprentissage automatique et de traitement du langage naturel pour détecter et filtrer les instructions malveillantes intégrées dans des contenus externes, tels que documents, pages web ou emails.
    
2.  **Spotlighting :** Cette technique aide le système IA à distinguer les instructions système valides des entrées externes potentiellement non fiables. En transformant le texte d’entrée de manière à le rendre plus pertinent pour le modèle, Spotlighting permet à l’IA d’identifier et d’ignorer plus efficacement les instructions malveillantes.
    
3.  **Délimiteurs et marquage des données :** L’inclusion de délimiteurs dans le message système indique explicitement la localisation du texte d’entrée, aidant l’IA à reconnaître et séparer les entrées utilisateur des contenus externes potentiellement dangereux. Le datamarking étend ce concept en utilisant des marqueurs spéciaux pour souligner les frontières entre données fiables et non fiables.
    
4.  **Surveillance continue et mises à jour :** Microsoft surveille et met régulièrement à jour les Prompt Shields pour faire face aux menaces nouvelles et évolutives. Cette approche proactive garantit que les défenses restent efficaces face aux dernières techniques d’attaque.
    
5. **Intégration avec Azure Content Safety :** Les Prompt Shields font partie de la suite plus large Azure AI Content Safety, qui offre des outils supplémentaires pour détecter les tentatives de jailbreak, contenus nuisibles et autres risques de sécurité dans les applications IA.

Vous pouvez en apprendre davantage sur les AI prompt shields dans la [documentation Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.fr.png)

### Sécurité de la chaîne d’approvisionnement

La sécurité de la chaîne d’approvisionnement reste fondamentale à l’ère de l’IA, mais le périmètre de ce qui constitue votre chaîne d’approvisionnement s’est élargi. En plus des packages de code traditionnels, vous devez désormais vérifier et surveiller rigoureusement tous les composants liés à l’IA, notamment les modèles de base, les services d’embedings, les fournisseurs de contexte et les API tierces. Chacun de ces éléments peut introduire des vulnérabilités ou des risques s’ils ne sont pas correctement gérés.

**Principales pratiques de sécurité de la chaîne d’approvisionnement pour l’IA et le MCP :**
- **Vérifier tous les composants avant intégration :** Cela inclut non seulement les bibliothèques open source, mais aussi les modèles IA, sources de données et API externes. Vérifiez toujours la provenance, les licences et les vulnérabilités connues.
- **Maintenir des pipelines de déploiement sécurisés :** Utilisez des pipelines CI/CD automatisés avec intégration de scans de sécurité pour détecter les problèmes tôt. Assurez-vous que seuls des artefacts fiables sont déployés en production.
- **Surveiller et auditer en continu :** Mettez en place une surveillance continue de toutes les dépendances, y compris les modèles et services de données, pour détecter de nouvelles vulnérabilités ou attaques sur la chaîne d’approvisionnement.
- **Appliquer le moindre privilège et les contrôles d’accès :** Limitez l’accès aux modèles, données et services uniquement à ce qui est nécessaire au fonctionnement du serveur MCP.
- **Réagir rapidement aux menaces :** Disposez d’un processus pour patcher ou remplacer les composants compromis, et pour faire tourner les secrets ou identifiants en cas de faille détectée.

[GitHub Advanced Security](https://github.com/security/advanced-security) offre des fonctionnalités telles que la détection de secrets, l’analyse des dépendances et l’analyse CodeQL. Ces outils s’intègrent avec [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) et [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) pour aider les équipes à identifier et atténuer les vulnérabilités à la fois dans le code et dans les composants de la chaîne d’approvisionnement IA.

Microsoft applique également en interne des pratiques étendues de sécurité de la chaîne d’approvisionnement pour tous ses produits. En savoir plus dans [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Bonnes pratiques de sécurité établies qui renforceront la posture de sécurité de votre implémentation MCP

Toute implémentation MCP hérite de la posture de sécurité existante de l’environnement de votre organisation sur lequel elle est construite. Ainsi, en considérant la sécurité du MCP comme composant de vos systèmes IA globaux, il est recommandé d’améliorer votre posture de sécurité globale existante. Les contrôles de sécurité établis suivants sont particulièrement pertinents :

- Bonnes pratiques de codage sécurisé dans votre application IA — protection contre [l’OWASP Top 10](https://owasp.org/www-project-top-ten/), le [OWASP Top 10 pour LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), utilisation de coffres sécurisés pour secrets et tokens, mise en place de communications sécurisées de bout en bout entre tous les composants de l’application, etc.
- Durcissement des serveurs — utiliser l’authentification multifactorielle (MFA) quand c’est possible, maintenir les correctifs à jour, intégrer le serveur à un fournisseur d’identité tiers pour l’accès, etc.
- Maintenir les appareils, infrastructures et applications à jour avec les derniers correctifs
- Surveillance de la sécurité — implémenter la journalisation et la surveillance d’une application IA (y compris les clients/serveurs MCP) et envoyer ces journaux vers un SIEM centralisé pour détecter les activités anormales
- Architecture zero trust — isoler les composants via des contrôles réseau et d’identité de manière logique pour minimiser les mouvements latéraux en cas de compromission d’une application IA.

# Points clés à retenir

- Les fondamentaux de la sécurité restent essentiels : codage sécurisé, moindre privilège, vérification de la chaîne d’approvisionnement et surveillance continue sont indispensables pour les charges de
- [OWASP Top 10 pour les LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Le parcours pour sécuriser la chaîne d’approvisionnement logicielle chez Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Accès minimal sécurisé (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Bonnes pratiques pour la validation et la durée de vie des tokens](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Utiliser un stockage sécurisé des tokens et chiffrer les tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management comme passerelle d’authentification pour MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Utiliser Microsoft Entra ID pour s’authentifier auprès des serveurs MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Suivant

Suivant : [Chapitre 3 : Premiers pas](/03-GettingStarted/README.md)

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d'assurer l'exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l'utilisation de cette traduction.