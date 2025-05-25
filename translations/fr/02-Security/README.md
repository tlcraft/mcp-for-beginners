<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T22:48:01+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "fr"
}
-->
# Meilleures pratiques de sécurité

L’adoption du Model Context Protocol (MCP) apporte des capacités puissantes aux applications pilotées par l’IA, mais introduit aussi des défis de sécurité spécifiques qui vont au-delà des risques logiciels traditionnels. En plus des préoccupations établies telles que la programmation sécurisée, le principe du moindre privilège et la sécurité de la chaîne d’approvisionnement, MCP et les charges de travail IA font face à de nouvelles menaces comme l’injection de prompt, l’empoisonnement d’outils et la modification dynamique d’outils. Ces risques peuvent entraîner une exfiltration de données, des atteintes à la vie privée et des comportements système inattendus s’ils ne sont pas correctement maîtrisés.

Cette leçon explore les risques de sécurité les plus pertinents liés au MCP — notamment l’authentification, l’autorisation, les permissions excessives, l’injection de prompt indirecte et les vulnérabilités de la chaîne d’approvisionnement — et propose des contrôles concrets et des bonnes pratiques pour les atténuer. Vous apprendrez également à exploiter les solutions Microsoft telles que Prompt Shields, Azure Content Safety et GitHub Advanced Security pour renforcer votre mise en œuvre MCP. En comprenant et en appliquant ces contrôles, vous réduirez significativement le risque de faille de sécurité et garantirez la robustesse et la fiabilité de vos systèmes IA.

# Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :

- Identifier et expliquer les risques de sécurité spécifiques introduits par le Model Context Protocol (MCP), tels que l’injection de prompt, l’empoisonnement d’outils, les permissions excessives et les vulnérabilités de la chaîne d’approvisionnement.
- Décrire et appliquer des contrôles efficaces pour atténuer les risques de sécurité liés au MCP, comme une authentification robuste, le principe du moindre privilège, la gestion sécurisée des jetons et la vérification de la chaîne d’approvisionnement.
- Comprendre et utiliser les solutions Microsoft telles que Prompt Shields, Azure Content Safety et GitHub Advanced Security pour protéger les charges de travail MCP et IA.
- Reconnaître l’importance de valider les métadonnées des outils, de surveiller les modifications dynamiques et de se défendre contre les attaques d’injection de prompt indirectes.
- Intégrer les bonnes pratiques de sécurité établies — telles que la programmation sécurisée, le durcissement des serveurs et l’architecture zéro confiance — dans votre implémentation MCP pour réduire la probabilité et l’impact des failles de sécurité.

# Contrôles de sécurité MCP

Tout système ayant accès à des ressources importantes présente des défis de sécurité implicites. Ces défis peuvent généralement être traités par l’application correcte de contrôles et concepts fondamentaux de sécurité. Comme le MCP est une spécification récente, elle évolue très rapidement. Au fur et à mesure de son évolution, les contrôles de sécurité intégrés mûriront, permettant une meilleure intégration avec les architectures et bonnes pratiques de sécurité d’entreprise établies.

Une recherche publiée dans le [Microsoft Digital Defense Report](https://aka.ms/mddr) indique que 98 % des violations signalées pourraient être évitées grâce à une hygiène de sécurité rigoureuse. La meilleure protection contre toute faille reste d’appliquer correctement les bonnes pratiques de base telles que l’hygiène de sécurité, la programmation sécurisée et la sécurité de la chaîne d’approvisionnement — ces pratiques éprouvées restent les plus efficaces pour réduire les risques.

Voyons quelques moyens de commencer à gérer les risques de sécurité lors de l’adoption du MCP.

# Authentification serveur MCP (si votre implémentation MCP est antérieure au 26 avril 2025)

> **Note :** Les informations suivantes sont exactes au 26 avril 2025. Le protocole MCP évolue continuellement, et les futures implémentations pourraient introduire de nouveaux schémas et contrôles d’authentification. Pour les mises à jour et conseils les plus récents, consultez toujours la [Spécification MCP](https://spec.modelcontextprotocol.io/) et le [dépôt officiel MCP sur GitHub](https://github.com/modelcontextprotocol).

### Problématique  
La spécification MCP originale supposait que les développeurs écriraient leur propre serveur d’authentification. Cela nécessitait une connaissance d’OAuth et des contraintes de sécurité associées. Les serveurs MCP agissaient comme serveurs d’autorisation OAuth 2.0, gérant directement l’authentification utilisateur au lieu de la déléguer à un service externe comme Microsoft Entra ID. Depuis le 26 avril 2025, une mise à jour de la spécification MCP permet aux serveurs MCP de déléguer l’authentification utilisateur à un service externe.

### Risques  
- Une logique d’autorisation mal configurée dans le serveur MCP peut entraîner l’exposition de données sensibles et des contrôles d’accès incorrectement appliqués.
- Le vol de jetons OAuth sur le serveur MCP local. Si un jeton est volé, il peut être utilisé pour usurper le serveur MCP et accéder aux ressources et données du service associé au jeton.

### Contrôles d’atténuation  
- **Réviser et renforcer la logique d’autorisation :** Auditez soigneusement l’implémentation d’autorisation de votre serveur MCP pour garantir que seuls les utilisateurs et clients prévus peuvent accéder aux ressources sensibles. Pour des conseils pratiques, consultez [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) et [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Appliquer des pratiques sécurisées pour les jetons :** Suivez les [meilleures pratiques Microsoft pour la validation et la durée de vie des jetons](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) afin d’éviter les usages abusifs et réduire les risques de rejouement ou de vol.
- **Protéger le stockage des jetons :** Stockez toujours les jetons de manière sécurisée et chiffrez-les au repos comme en transit. Pour des conseils d’implémentation, voir [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permissions excessives pour les serveurs MCP

### Problématique  
Les serveurs MCP peuvent se voir attribuer des permissions excessives sur les services ou ressources qu’ils accèdent. Par exemple, un serveur MCP utilisé dans une application IA de ventes connectée à un magasin de données d’entreprise devrait avoir un accès limité aux données de ventes, et non à tous les fichiers du magasin. En revenant au principe du moindre privilège (un des plus anciens principes de sécurité), aucune ressource ne doit disposer de permissions supérieures à celles nécessaires à l’exécution des tâches prévues. L’IA complique cette gestion car, pour garantir sa flexibilité, il est difficile de définir précisément les permissions requises.

### Risques  
- Accorder des permissions excessives peut permettre l’exfiltration ou la modification de données auxquelles le serveur MCP n’était pas censé accéder. Cela peut aussi poser un problème de confidentialité si les données sont des informations personnelles identifiables (PII).

### Contrôles d’atténuation  
- **Appliquer le principe du moindre privilège :** Accordez au serveur MCP uniquement les permissions minimales nécessaires à ses tâches. Passez en revue et mettez à jour régulièrement ces permissions pour éviter tout excès. Pour des conseils détaillés, voir [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Utiliser le contrôle d’accès basé sur les rôles (RBAC) :** Attribuez des rôles au serveur MCP strictement limités à des ressources et actions spécifiques, évitant les permissions larges ou inutiles.
- **Surveiller et auditer les permissions :** Suivez en continu l’utilisation des permissions et auditez les journaux d’accès pour détecter et corriger rapidement les privilèges excessifs ou inutilisés.

# Attaques d’injection de prompt indirectes

### Problématique

Des serveurs MCP malveillants ou compromis peuvent engendrer des risques importants en exposant des données clients ou en déclenchant des actions non désirées. Ces risques sont particulièrement critiques dans les charges de travail IA et MCP, où :

- **Attaques d’injection de prompt :** Les attaquants insèrent des instructions malveillantes dans les prompts ou contenus externes, poussant le système IA à effectuer des actions non prévues ou à divulguer des données sensibles. En savoir plus : [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Empoisonnement d’outils :** Les attaquants manipulent les métadonnées des outils (descriptions, paramètres) pour influencer le comportement de l’IA, contournant potentiellement les contrôles de sécurité ou exfiltrant des données. Détails : [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Injection de prompt cross-domain :** Des instructions malveillantes sont cachées dans des documents, pages web ou emails, traités ensuite par l’IA, provoquant fuites ou manipulations.
- **Modification dynamique d’outils (rug pulls) :** Les définitions d’outils peuvent être modifiées après approbation utilisateur, introduisant des comportements malveillants à l’insu de l’utilisateur.

Ces vulnérabilités soulignent l’importance d’une validation, d’une surveillance et de contrôles de sécurité solides lors de l’intégration des serveurs et outils MCP dans votre environnement. Pour approfondir, consultez les références ci-dessus.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.fr.png)

**Injection de prompt indirecte** (aussi appelée injection cross-domain ou XPIA) est une vulnérabilité critique dans les systèmes d’IA générative, y compris ceux utilisant MCP. Dans cette attaque, des instructions malveillantes sont dissimulées dans du contenu externe — documents, pages web ou emails. Quand le système IA traite ce contenu, il peut interpréter ces instructions comme des commandes utilisateur légitimes, entraînant des actions non prévues telles que la fuite de données, la génération de contenu nuisible ou la manipulation des interactions utilisateur. Pour une explication détaillée et des exemples concrets, voir [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Une forme particulièrement dangereuse de cette attaque est **l’empoisonnement d’outils**. Ici, les attaquants injectent des instructions malveillantes dans les métadonnées des outils MCP (descriptions, paramètres). Comme les grands modèles de langage (LLM) s’appuient sur ces métadonnées pour décider quels outils appeler, des descriptions compromises peuvent tromper le modèle en exécutant des appels d’outils non autorisés ou en contournant les contrôles de sécurité. Ces manipulations sont souvent invisibles pour l’utilisateur final mais interprétées par le système IA. Ce risque est accentué dans les environnements de serveurs MCP hébergés, où les définitions d’outils peuvent être mises à jour après approbation utilisateur — un scénario parfois appelé « [rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22) ». Dans ce cas, un outil auparavant sûr peut être modifié ultérieurement pour réaliser des actions malveillantes, comme exfiltrer des données ou altérer le comportement système, sans que l’utilisateur en soit informé. Pour plus d’informations, voir [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.fr.png)

## Risques  
Les actions non intentionnelles de l’IA présentent divers risques de sécurité, notamment l’exfiltration de données et les atteintes à la vie privée.

### Contrôles d’atténuation  
### Utilisation de prompt shields pour se protéger contre les attaques d’injection de prompt indirectes
-----------------------------------------------------------------------------

**AI Prompt Shields** sont une solution développée par Microsoft pour défendre contre les attaques d’injection de prompt directes et indirectes. Elles agissent par :

1.  **Détection et filtrage :** Prompt Shields utilisent des algorithmes avancés d’apprentissage automatique et de traitement du langage naturel pour détecter et filtrer les instructions malveillantes intégrées dans des contenus externes, tels que documents, pages web ou emails.
    
2.  **Spotlighting :** Cette technique aide le système IA à distinguer les instructions système valides des entrées externes potentiellement non fiables. En transformant le texte d’entrée pour le rendre plus pertinent pour le modèle, Spotlighting permet à l’IA d’identifier et d’ignorer plus efficacement les instructions malveillantes.
    
3.  **Délimiteurs et marquage des données :** L’inclusion de délimiteurs dans le message système indique explicitement la localisation du texte d’entrée, aidant l’IA à reconnaître et séparer les entrées utilisateur des contenus externes potentiellement dangereux. Le marquage des données étend ce concept en utilisant des marqueurs spéciaux pour souligner les frontières entre données fiables et non fiables.
    
4.  **Surveillance et mises à jour continues :** Microsoft surveille et met à jour en permanence Prompt Shields pour faire face aux menaces nouvelles et évolutives. Cette approche proactive garantit l’efficacité des défenses contre les techniques d’attaque les plus récentes.
    
5. **Intégration avec Azure Content Safety :** Prompt Shields font partie de la suite plus large Azure AI Content Safety, qui fournit des outils supplémentaires pour détecter les tentatives de jailbreak, les contenus nuisibles et autres risques de sécurité dans les applications IA.

Pour en savoir plus sur les AI prompt shields, consultez la [documentation Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.fr.png)

### Sécurité de la chaîne d’approvisionnement

La sécurité de la chaîne d’approvisionnement reste fondamentale à l’ère de l’IA, mais la portée de ce qui constitue votre chaîne d’approvisionnement s’est élargie. En plus des paquets de code traditionnels, vous devez désormais vérifier rigoureusement et surveiller tous les composants liés à l’IA, y compris les modèles de base, les services d’embeddings, les fournisseurs de contexte et les API tierces. Chacun peut introduire des vulnérabilités ou risques s’il n’est pas correctement géré.

**Pratiques clés de sécurité de la chaîne d’approvisionnement pour l’IA et MCP :**
- **Vérifier tous les composants avant intégration :** Cela inclut non seulement les bibliothèques open source, mais aussi les modèles IA, les sources de données et les API externes. Contrôlez toujours la provenance, les licences et les vulnérabilités connues.
- **Maintenir des pipelines de déploiement sécurisés :** Utilisez des pipelines CI/CD automatisés avec analyses de sécurité intégrées pour détecter tôt les problèmes. Assurez-vous que seuls des artefacts de confiance sont déployés en production.
- **Surveiller et auditer en continu :** Mettez en place une surveillance continue pour toutes les dépendances, y compris les modèles et services de données, afin de détecter de nouvelles vulnérabilités ou attaques sur la chaîne d’approvisionnement.
- **Appliquer le moindre privilège et des contrôles d’accès :** Restreignez l’accès aux modèles, données et services uniquement à ce qui est nécessaire au fonctionnement du serveur MCP.
- **Réagir rapidement aux menaces :** Disposez d’un processus pour patcher ou remplacer les composants compromis, et pour faire tourner les secrets ou identifiants en cas de faille détectée.

[GitHub Advanced Security](https://github.com/security/advanced-security) offre des fonctionnalités telles que le scan des secrets, l’analyse des dépendances et CodeQL. Ces outils s’intègrent avec [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) et [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) pour aider les équipes à identifier et atténuer les vulnérabilités dans le code et les composants de la chaîne d’approvisionnement IA.

Microsoft applique également en interne des pratiques étendues de sécurité de la chaîne d’approvisionnement pour tous ses produits. En savoir plus dans [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Bonnes pratiques de sécurité établies pour renforcer la posture de sécurité de votre implémentation MCP

Toute implémentation MCP hérite de la posture de sécurité existante de l’environnement de votre organisation sur lequel elle repose. Ainsi, en considérant la sécurité du MCP comme un composant de vos systèmes IA globaux, il est recommandé de renforcer votre posture de sécurité globale existante. Les contrôles de sécurité établis suivants sont particulièrement pertinents :

- Bonnes pratiques de programmation sécurisée dans votre application IA — protection contre [le Top 10 OWASP](https://owasp.org/www-project-top-ten/), le [Top 10 OWASP pour LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), utilisation de coffres-forts sécurisés pour les secrets et jetons, mise en œuvre de communications sécurisées de bout en bout entre tous les composants applicatifs, etc.
- Durcissement des serveurs — utiliser l’authentification multifactorielle (MFA) quand c’est possible, maintenir les correctifs à jour, intégrer le serveur avec un fournisseur d’identité tiers pour l’accès, etc.
- Maintenir à jour les appareils, l’infrastructure et les applications avec les derniers correctifs.
- Surveillance de la sécurité — mise en place de la journalisation et de la surveillance d’une application IA (y compris le client/serveur MCP) et envoi des journaux vers un SIEM central pour détecter les activités anormales.
- Architecture zéro confiance — isolation des composants via des contrôles réseau et d’identité de manière logique pour minimiser les mouvements latéraux en cas de compromission d’une application IA.

# Points clés à retenir

- Les fondamentaux de la sécurité restent essentiels : programmation sécurisée, moindre privilège, vérification de la chaîne d’approvisionnement et surveillance continue sont indispensables pour les charges de travail MCP et IA.
- MCP introduit de nouveaux risques — tels que l’injection de prompt, l’empoisonnement d’outils et les permissions excessives — qui nécessitent à la fois des contrôles
- [OWASP Top 10 pour les LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Le parcours pour sécuriser la chaîne d'approvisionnement logicielle chez Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Accès minimal sécurisé (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Bonnes pratiques pour la validation et la durée de vie des jetons](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Utiliser un stockage sécurisé des jetons et chiffrer les jetons (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management comme passerelle d’authentification pour MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Utiliser Microsoft Entra ID pour s’authentifier auprès des serveurs MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Suivant

Suivant : [Chapitre 3 : Premiers pas](/03-GettingStarted/README.md)

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforçons d'assurer l'exactitude, veuillez noter que les traductions automatisées peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle humaine est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou d'interprétations erronées résultant de l'utilisation de cette traduction.