<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-16T21:28:28+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "fr"
}
-->
# Bonnes pratiques de sécurité

L’adoption du Model Context Protocol (MCP) apporte des capacités puissantes aux applications pilotées par l’IA, mais introduit également des défis de sécurité uniques qui vont au-delà des risques logiciels traditionnels. En plus des préoccupations établies telles que le codage sécurisé, le principe du moindre privilège et la sécurité de la chaîne d’approvisionnement, le MCP et les charges de travail IA font face à de nouvelles menaces comme l’injection de prompt, l’empoisonnement d’outils, la modification dynamique d’outils, le détournement de session, les attaques du délégué confus et les vulnérabilités de passage de jetons. Ces risques peuvent entraîner une exfiltration de données, des violations de la vie privée et des comportements système non souhaités s’ils ne sont pas correctement gérés.

Cette leçon explore les risques de sécurité les plus pertinents associés au MCP — notamment l’authentification, l’autorisation, les permissions excessives, l’injection indirecte de prompt, la sécurité des sessions, les problèmes de délégué confus, les vulnérabilités de passage de jetons et les vulnérabilités de la chaîne d’approvisionnement — et fournit des contrôles concrets et des bonnes pratiques pour les atténuer. Vous apprendrez également à tirer parti des solutions Microsoft telles que Prompt Shields, Azure Content Safety et GitHub Advanced Security pour renforcer votre implémentation MCP. En comprenant et en appliquant ces contrôles, vous pouvez réduire significativement la probabilité d’une faille de sécurité et garantir que vos systèmes IA restent robustes et fiables.

# Objectifs d’apprentissage

À la fin de cette leçon, vous serez capable de :

- Identifier et expliquer les risques de sécurité uniques introduits par le Model Context Protocol (MCP), notamment l’injection de prompt, l’empoisonnement d’outils, les permissions excessives, le détournement de session, les problèmes de délégué confus, les vulnérabilités de passage de jetons et les vulnérabilités de la chaîne d’approvisionnement.
- Décrire et appliquer des contrôles efficaces pour atténuer les risques de sécurité du MCP, tels qu’une authentification robuste, le principe du moindre privilège, une gestion sécurisée des jetons, des contrôles de sécurité des sessions et la vérification de la chaîne d’approvisionnement.
- Comprendre et exploiter les solutions Microsoft comme Prompt Shields, Azure Content Safety et GitHub Advanced Security pour protéger les charges de travail MCP et IA.
- Reconnaître l’importance de valider les métadonnées des outils, de surveiller les modifications dynamiques, de se défendre contre les attaques d’injection indirecte de prompt et de prévenir le détournement de session.
- Intégrer les bonnes pratiques de sécurité établies — telles que le codage sécurisé, le durcissement des serveurs et l’architecture zero trust — dans votre implémentation MCP pour réduire la probabilité et l’impact des failles de sécurité.

# Contrôles de sécurité MCP

Tout système ayant accès à des ressources importantes présente des défis de sécurité implicites. Ces défis peuvent généralement être traités par l’application correcte de contrôles et concepts fondamentaux de sécurité. Comme le MCP est une spécification récente, celle-ci évolue très rapidement. Au fur et à mesure de l’évolution du protocole, les contrôles de sécurité qu’il intègre mûriront, permettant une meilleure intégration avec les architectures de sécurité d’entreprise et les bonnes pratiques établies.

Une recherche publiée dans le [Microsoft Digital Defense Report](https://aka.ms/mddr) indique que 98 % des violations signalées auraient pu être évitées grâce à une hygiène de sécurité rigoureuse. La meilleure protection contre toute forme de faille est d’avoir une hygiène de sécurité de base solide, des bonnes pratiques de codage sécurisé et une sécurité renforcée de la chaîne d’approvisionnement — ces pratiques éprouvées restent les plus efficaces pour réduire les risques de sécurité.

Voyons quelques façons de commencer à adresser les risques de sécurité lors de l’adoption du MCP.

> **Note :** Les informations suivantes sont exactes au **29 mai 2025**. Le protocole MCP évolue continuellement, et les futures implémentations pourraient introduire de nouveaux schémas d’authentification et contrôles. Pour les dernières mises à jour et recommandations, référez-vous toujours à la [spécification MCP](https://spec.modelcontextprotocol.io/), au [dépôt officiel MCP GitHub](https://github.com/modelcontextprotocol) et à la [page des bonnes pratiques de sécurité](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Énoncé du problème  
La spécification MCP originale supposait que les développeurs écriraient leur propre serveur d’authentification. Cela nécessitait une connaissance d’OAuth et des contraintes de sécurité associées. Les serveurs MCP agissaient comme des serveurs d’autorisation OAuth 2.0, gérant directement l’authentification utilisateur requise plutôt que de la déléguer à un service externe tel que Microsoft Entra ID. Depuis le **26 avril 2025**, une mise à jour de la spécification MCP permet aux serveurs MCP de déléguer l’authentification utilisateur à un service externe.

### Risques
- Une logique d’autorisation mal configurée dans le serveur MCP peut entraîner une exposition de données sensibles et des contrôles d’accès incorrectement appliqués.
- Le vol de jetons OAuth sur le serveur MCP local. Si un jeton est volé, il peut être utilisé pour usurper le serveur MCP et accéder aux ressources et données du service associé au jeton OAuth.

#### Passage de jetons
Le passage de jetons est explicitement interdit dans la spécification d’autorisation car il introduit plusieurs risques de sécurité, notamment :

#### Contournement des contrôles de sécurité
Le serveur MCP ou les API en aval peuvent implémenter des contrôles de sécurité importants comme la limitation de débit, la validation des requêtes ou la surveillance du trafic, qui dépendent de l’audience du jeton ou d’autres contraintes d’identifiants. Si les clients peuvent obtenir et utiliser des jetons directement avec les API en aval sans que le serveur MCP ne les valide correctement ou ne s’assure que les jetons sont émis pour le bon service, ils contournent ces contrôles.

#### Problèmes de responsabilité et de traçabilité
Le serveur MCP ne pourra pas identifier ou distinguer les clients MCP lorsque ceux-ci appellent avec un jeton d’accès émis en amont, qui peut être opaque pour le serveur MCP.  
Les journaux du serveur de ressources en aval peuvent montrer des requêtes semblant provenir d’une source différente avec une identité différente, plutôt que du serveur MCP qui transmet réellement les jetons.  
Ces deux facteurs compliquent l’investigation des incidents, les contrôles et les audits.  
Si le serveur MCP transmet des jetons sans valider leurs revendications (par exemple, rôles, privilèges ou audience) ou autres métadonnées, un acteur malveillant en possession d’un jeton volé peut utiliser le serveur comme proxy pour exfiltrer des données.

#### Problèmes de frontière de confiance
Le serveur de ressources en aval accorde sa confiance à des entités spécifiques. Cette confiance peut inclure des hypothèses sur l’origine ou les comportements clients. Briser cette frontière de confiance peut entraîner des problèmes inattendus.  
Si le jeton est accepté par plusieurs services sans validation appropriée, un attaquant compromettant un service peut utiliser le jeton pour accéder à d’autres services connectés.

#### Risque de compatibilité future
Même si un serveur MCP commence aujourd’hui comme un « proxy pur », il pourrait devoir ajouter des contrôles de sécurité plus tard. Commencer avec une séparation correcte de l’audience des jetons facilite l’évolution du modèle de sécurité.

### Contrôles d’atténuation

**Les serveurs MCP NE DOIVENT PAS accepter de jetons qui n’ont pas été explicitement émis pour le serveur MCP**

- **Revoir et renforcer la logique d’autorisation :** Auditez soigneusement l’implémentation d’autorisation de votre serveur MCP pour garantir que seuls les utilisateurs et clients prévus peuvent accéder aux ressources sensibles. Pour des conseils pratiques, consultez [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) et [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Appliquer des pratiques sécurisées pour les jetons :** Suivez [les meilleures pratiques Microsoft pour la validation et la durée de vie des jetons](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) afin d’éviter les usages abusifs des jetons d’accès et réduire le risque de rejouement ou de vol.
- **Protéger le stockage des jetons :** Stockez toujours les jetons de manière sécurisée et utilisez le chiffrement pour les protéger au repos et en transit. Pour des conseils d’implémentation, voir [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permissions excessives pour les serveurs MCP

### Énoncé du problème  
Les serveurs MCP peuvent se voir accorder des permissions excessives sur le service ou la ressource qu’ils accèdent. Par exemple, un serveur MCP faisant partie d’une application de vente IA connectée à un magasin de données d’entreprise devrait avoir un accès limité aux données de vente et ne pas pouvoir accéder à tous les fichiers du magasin. En se référant au principe du moindre privilège (l’un des plus anciens principes de sécurité), aucune ressource ne devrait avoir des permissions supérieures à ce qui est nécessaire pour exécuter les tâches prévues. L’IA pose un défi accru dans ce domaine car, pour lui permettre d’être flexible, il peut être difficile de définir précisément les permissions requises.

### Risques  
- Accorder des permissions excessives peut permettre l’exfiltration ou la modification de données auxquelles le serveur MCP n’était pas censé accéder. Cela peut aussi poser un problème de confidentialité si les données sont des informations personnelles identifiables (PII).

### Contrôles d’atténuation  
- **Appliquer le principe du moindre privilège :** Accordez au serveur MCP uniquement les permissions minimales nécessaires pour accomplir ses tâches. Révisez et mettez régulièrement à jour ces permissions pour vous assurer qu’elles ne dépassent pas ce qui est nécessaire. Pour des conseils détaillés, voir [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Utiliser le contrôle d’accès basé sur les rôles (RBAC) :** Attribuez des rôles au serveur MCP qui sont strictement limités à des ressources et actions spécifiques, en évitant les permissions larges ou inutiles.
- **Surveiller et auditer les permissions :** Surveillez en continu l’utilisation des permissions et auditez les journaux d’accès pour détecter et corriger rapidement les privilèges excessifs ou inutilisés.

# Attaques d’injection de prompt indirectes

### Énoncé du problème

Les serveurs MCP malveillants ou compromis peuvent introduire des risques importants en exposant des données clients ou en permettant des actions non souhaitées. Ces risques sont particulièrement pertinents dans les charges de travail IA et MCP, où :

- **Attaques d’injection de prompt :** Les attaquants intègrent des instructions malveillantes dans des prompts ou contenus externes, poussant le système IA à effectuer des actions non prévues ou à divulguer des données sensibles. En savoir plus : [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Empoisonnement d’outils :** Les attaquants manipulent les métadonnées des outils (comme les descriptions ou paramètres) pour influencer le comportement de l’IA, contournant potentiellement les contrôles de sécurité ou exfiltrant des données. Détails : [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Injection de prompt cross-domain :** Des instructions malveillantes sont intégrées dans des documents, pages web ou emails, qui sont ensuite traités par l’IA, entraînant des fuites ou manipulations de données.
- **Modification dynamique d’outils (Rug Pulls) :** Les définitions d’outils peuvent être modifiées après approbation utilisateur, introduisant de nouveaux comportements malveillants à l’insu de l’utilisateur.

Ces vulnérabilités soulignent la nécessité de validations robustes, de surveillance et de contrôles de sécurité lors de l’intégration des serveurs MCP et outils dans votre environnement. Pour approfondir, consultez les références ci-dessus.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.fr.png)

**Injection de prompt indirecte** (également appelée injection de prompt cross-domain ou XPIA) est une vulnérabilité critique dans les systèmes d’IA générative, y compris ceux utilisant le Model Context Protocol (MCP). Dans cette attaque, des instructions malveillantes sont cachées dans du contenu externe — comme des documents, pages web ou emails. Lorsque le système IA traite ce contenu, il peut interpréter ces instructions intégrées comme des commandes légitimes de l’utilisateur, entraînant des actions non souhaitées telles que des fuites de données, la génération de contenu nuisible ou la manipulation des interactions utilisateur. Pour une explication détaillée et des exemples concrets, voir [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Une forme particulièrement dangereuse de cette attaque est **l’empoisonnement d’outils**. Ici, les attaquants injectent des instructions malveillantes dans les métadonnées des outils MCP (comme les descriptions ou paramètres). Comme les grands modèles de langage (LLM) s’appuient sur ces métadonnées pour décider quels outils invoquer, des descriptions compromises peuvent tromper le modèle en l’incitant à exécuter des appels d’outils non autorisés ou à contourner les contrôles de sécurité. Ces manipulations sont souvent invisibles pour les utilisateurs finaux mais peuvent être interprétées et exploitées par le système IA. Ce risque est accentué dans les environnements de serveurs MCP hébergés, où les définitions d’outils peuvent être mises à jour après approbation utilisateur — un scénario parfois appelé « [rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22) ». Dans ces cas, un outil auparavant sûr peut être modifié ultérieurement pour effectuer des actions malveillantes, comme exfiltrer des données ou altérer le comportement du système, sans que l’utilisateur en soit informé. Pour en savoir plus sur ce vecteur d’attaque, voir [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.fr.png)

## Risques  
Les actions non intentionnelles de l’IA présentent divers risques de sécurité, notamment l’exfiltration de données et les violations de la vie privée.

### Contrôles d’atténuation  
### Utilisation de prompt shields pour se protéger contre les attaques d’injection de prompt indirecte
-----------------------------------------------------------------------------

**AI Prompt Shields** sont une solution développée par Microsoft pour se défendre contre les attaques d’injection de prompt directes et indirectes. Ils aident grâce à :

1.  **Détection et filtrage :** Les Prompt Shields utilisent des algorithmes avancés d’apprentissage automatique et de traitement du langage naturel pour détecter et filtrer les instructions malveillantes intégrées dans des contenus externes, tels que documents, pages web ou emails.
    
2.  **Spotlighting :** Cette technique aide le système IA à distinguer les instructions système valides des entrées externes potentiellement non fiables. En transformant le texte d’entrée de manière à le rendre plus pertinent pour le modèle, Spotlighting permet à l’IA d’identifier et d’ignorer plus efficacement les instructions malveillantes.
    
3.  **Délimiteurs et marquage des données :** L’inclusion de délimiteurs dans le message système indique explicitement l’emplacement du texte d’entrée, aidant l’IA à reconnaître et séparer les entrées utilisateur du contenu externe potentiellement dangereux. Le marquage des données étend ce concept en utilisant des marqueurs spéciaux pour souligner les limites des données fiables et non fiables.
    
4.  **Surveillance continue et mises à jour :** Microsoft surveille et met à jour en permanence les Prompt Shields pour faire face aux menaces nouvelles et évolutives. Cette approche proactive garantit que les défenses restent efficaces contre les dernières techniques d’attaque.
    
5. **Intégration avec Azure Content Safety :** Les Prompt Shields font partie de la suite plus large Azure AI Content Safety, qui fournit des outils supplémentaires pour détecter les tentatives de jailbreak, les contenus nuisibles et autres risques de sécurité dans les applications IA.

Vous pouvez en apprendre davantage sur les AI prompt shields dans la [documentation Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.fr.png)

# Problème du délégué confus

### Énoncé du problème
Le problème du délégué confus est une vulnérabilité de sécurité qui survient lorsqu’un serveur MCP agit comme un proxy entre des clients MCP et des API tierces. Cette vulnérabilité peut être exploitée lorsque le serveur MCP utilise un ID client statique pour s’authentifier auprès d’un serveur d’autorisation tiers qui ne prend pas en charge l’enregistrement dynamique des clients.

### Risques

- **Contournement du consentement basé sur les cookies** : Si un utilisateur s’est déjà authentifié via le serveur proxy MCP, un serveur d’autorisation tiers peut définir un cookie de consentement dans le navigateur de l’utilisateur. Un attaquant peut ensuite exploiter cela en envoyant à l’utilisateur un lien malveillant contenant une requête d’autorisation avec une URI de redirection malicieuse.
- **Vol de code d’autorisation** : Lorsque l’utilisateur clique sur le lien malveillant, le serveur d’autorisation tiers peut ignorer l’écran de consentement à cause du cookie existant, et le code d’autorisation pourrait être redirigé vers le serveur de l’attaquant.
- **Accès non autorisé à l’API** : L’attaquant peut échanger le code d’autorisation volé contre des jetons d’accès et usurper l’identité de l’utilisateur pour accéder à l’API tierce sans approbation explicite.

### Contrôles d’atténuation

- **Exigences de consentement explicite** : Les serveurs proxy MCP utilisant des ID clients statiques **DOIVENT** obtenir le consentement de l’utilisateur pour chaque client enregistré dynamiquement avant de transmettre aux serveurs d’autorisation tiers.
- **Mise en œuvre correcte d’OAuth** : Suivre les meilleures pratiques de sécurité OAuth 2.1, notamment l’utilisation de challenges de code (PKCE) pour les requêtes d’autorisation afin d’éviter les attaques par interception.
- **Validation des clients** : Mettre en place une validation stricte des URI de redirection et des identifiants clients pour empêcher l’exploitation par des acteurs malveillants.


# Vulnérabilités liées au passage de jetons

### Énoncé du problème

Le « passage de jetons » est un anti-pattern où un serveur MCP accepte des jetons d’un client MCP sans vérifier que ces jetons ont été correctement émis pour le serveur MCP lui-même, puis les « transmet » aux API en aval. Cette pratique viole explicitement la spécification d’autorisation MCP et introduit des risques de sécurité importants.

### Risques

- **Contournement des contrôles de sécurité** : Les clients pourraient contourner des contrôles importants comme la limitation de débit, la validation des requêtes ou la surveillance du trafic s’ils peuvent utiliser des jetons directement avec les API en aval sans validation appropriée.
- **Problèmes de responsabilité et de traçabilité** : Le serveur MCP ne pourra pas identifier ou distinguer les clients MCP lorsque ceux-ci utilisent des jetons d’accès émis en amont, compliquant ainsi les enquêtes et audits en cas d’incident.
- **Exfiltration de données** : Si les jetons sont transmis sans validation correcte des revendications, un acteur malveillant disposant d’un jeton volé pourrait utiliser le serveur comme proxy pour exfiltrer des données.
- **Violation des frontières de confiance** : Les serveurs de ressources en aval peuvent accorder leur confiance à des entités spécifiques en se basant sur leur origine ou leurs comportements. Briser cette frontière de confiance peut entraîner des problèmes de sécurité inattendus.
- **Mauvaise utilisation des jetons multi-services** : Si des jetons sont acceptés par plusieurs services sans validation appropriée, un attaquant compromettant un service pourrait utiliser le jeton pour accéder à d’autres services connectés.

### Contrôles d’atténuation

- **Validation des jetons** : Les serveurs MCP **NE DOIVENT PAS** accepter de jetons qui n’ont pas été explicitement émis pour le serveur MCP lui-même.
- **Vérification de l’audience** : Toujours valider que les jetons contiennent la bonne revendication d’audience correspondant à l’identité du serveur MCP.
- **Gestion appropriée du cycle de vie des jetons** : Mettre en œuvre des jetons d’accès à courte durée de vie et des pratiques de rotation des jetons pour réduire le risque de vol et d’utilisation abusive.


# Détournement de session

### Énoncé du problème

Le détournement de session est un vecteur d’attaque où un client reçoit un ID de session du serveur, et une partie non autorisée obtient et utilise ce même ID de session pour usurper l’identité du client original et effectuer des actions non autorisées en son nom. Cela est particulièrement préoccupant dans les serveurs HTTP avec état traitant des requêtes MCP.

### Risques

- **Injection de prompt via détournement de session** : Un attaquant qui obtient un ID de session pourrait envoyer des événements malveillants à un serveur partageant l’état de session avec le serveur auquel le client est connecté, déclenchant potentiellement des actions nuisibles ou accédant à des données sensibles.
- **Usurpation via détournement de session** : Un attaquant disposant d’un ID de session volé pourrait effectuer des appels directement au serveur MCP, contournant l’authentification et étant traité comme l’utilisateur légitime.
- **Flux résumables compromis** : Lorsqu’un serveur supporte la rediffusion ou les flux résumables, un attaquant pourrait interrompre prématurément une requête, qui serait ensuite reprise par le client original avec un contenu potentiellement malveillant.

### Contrôles d’atténuation

- **Vérification de l’autorisation** : Les serveurs MCP qui implémentent une autorisation **DOIVENT** vérifier toutes les requêtes entrantes et **NE DOIVENT PAS** utiliser les sessions pour l’authentification.
- **IDs de session sécurisés** : Les serveurs MCP **DOIVENT** utiliser des IDs de session sécurisés, non déterministes, générés avec des générateurs de nombres aléatoires sécurisés. Éviter les identifiants prévisibles ou séquentiels.
- **Association spécifique à l’utilisateur** : Les serveurs MCP **DOIVENT** lier les IDs de session à des informations spécifiques à l’utilisateur, en combinant l’ID de session avec des informations uniques à l’utilisateur autorisé (comme son ID interne) selon un format tel que `
<user_id>:<session_id>`.
- **Expiration des sessions** : Mettre en place une expiration et une rotation appropriées des sessions pour limiter la fenêtre de vulnérabilité en cas de compromission d’un ID de session.
- **Sécurité du transport** : Toujours utiliser HTTPS pour toutes les communications afin d’éviter l’interception des IDs de session.


# Sécurité de la chaîne d’approvisionnement

La sécurité de la chaîne d’approvisionnement reste fondamentale à l’ère de l’IA, mais la portée de ce qui constitue votre chaîne d’approvisionnement s’est élargie. En plus des packages de code traditionnels, vous devez désormais vérifier et surveiller rigoureusement tous les composants liés à l’IA, y compris les modèles de base, les services d’embeddings, les fournisseurs de contexte et les API tierces. Chacun de ces éléments peut introduire des vulnérabilités ou des risques s’ils ne sont pas correctement gérés.

**Pratiques clés de sécurité de la chaîne d’approvisionnement pour l’IA et MCP :**
- **Vérifier tous les composants avant intégration :** Cela inclut non seulement les bibliothèques open source, mais aussi les modèles d’IA, les sources de données et les API externes. Toujours vérifier la provenance, les licences et les vulnérabilités connues.
- **Maintenir des pipelines de déploiement sécurisés :** Utiliser des pipelines CI/CD automatisés avec des analyses de sécurité intégrées pour détecter les problèmes tôt. S’assurer que seuls des artefacts de confiance sont déployés en production.
- **Surveiller et auditer en continu :** Mettre en place une surveillance continue de toutes les dépendances, y compris les modèles et services de données, pour détecter de nouvelles vulnérabilités ou attaques sur la chaîne d’approvisionnement.
- **Appliquer le principe du moindre privilège et des contrôles d’accès :** Restreindre l’accès aux modèles, données et services uniquement à ce qui est nécessaire au fonctionnement de votre serveur MCP.
- **Réagir rapidement aux menaces :** Disposer d’un processus pour patcher ou remplacer les composants compromis, et pour faire tourner les secrets ou identifiants en cas de violation.

[GitHub Advanced Security](https://github.com/security/advanced-security) offre des fonctionnalités telles que la détection de secrets, l’analyse des dépendances et l’analyse CodeQL. Ces outils s’intègrent avec [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) et [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) pour aider les équipes à identifier et atténuer les vulnérabilités à la fois dans le code et dans les composants de la chaîne d’approvisionnement IA.

Microsoft applique également en interne des pratiques étendues de sécurité de la chaîne d’approvisionnement pour tous ses produits. En savoir plus dans [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Bonnes pratiques de sécurité établies pour renforcer la posture de sécurité de votre implémentation MCP

Toute implémentation MCP hérite de la posture de sécurité existante de l’environnement de votre organisation sur lequel elle est construite. Ainsi, lorsqu’on considère la sécurité de MCP comme un composant de vos systèmes IA globaux, il est recommandé d’améliorer la posture de sécurité globale existante. Les contrôles de sécurité établis suivants sont particulièrement pertinents :

-   Bonnes pratiques de codage sécurisé dans votre application IA – se protéger contre [le Top 10 OWASP](https://owasp.org/www-project-top-ten/), le [Top 10 OWASP pour les LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559), l’utilisation de coffres-forts sécurisés pour les secrets et jetons, la mise en œuvre de communications sécurisées de bout en bout entre tous les composants de l’application, etc.
-   Durcissement des serveurs – utiliser l’authentification multifactorielle (MFA) lorsque c’est possible, maintenir les correctifs à jour, intégrer le serveur avec un fournisseur d’identité tiers pour l’accès, etc.
-   Maintenir les appareils, infrastructures et applications à jour avec les correctifs
-   Surveillance de la sécurité – mettre en place la journalisation et la surveillance d’une application IA (y compris les clients/serveurs MCP) et envoyer ces journaux à un SIEM central pour détecter les activités anormales
-   Architecture Zero Trust – isoler les composants via des contrôles réseau et d’identité de manière logique pour minimiser les mouvements latéraux en cas de compromission d’une application IA.

# Points clés à retenir

- Les fondamentaux de la sécurité restent essentiels : codage sécurisé, moindre privilège, vérification de la chaîne d’approvisionnement et surveillance continue sont indispensables pour les charges de travail MCP et IA.
- MCP introduit de nouveaux risques — tels que l’injection de prompt, l’empoisonnement d’outils, le détournement de session, le problème du délégué confus, les vulnérabilités de passage de jetons et les permissions excessives — qui nécessitent des contrôles à la fois traditionnels et spécifiques à l’IA.
- Utiliser des pratiques robustes d’authentification, d’autorisation et de gestion des jetons, en tirant parti de fournisseurs d’identité externes comme Microsoft Entra ID lorsque c’est possible.
- Se protéger contre l’injection indirecte de prompt et l’empoisonnement d’outils en validant les métadonnées des outils, en surveillant les changements dynamiques et en utilisant des solutions comme Microsoft Prompt Shields.
- Mettre en œuvre une gestion sécurisée des sessions en utilisant des IDs de session non déterministes, en liant les sessions aux identités des utilisateurs, et en n’utilisant jamais les sessions pour l’authentification.
- Prévenir les attaques du délégué confus en exigeant un consentement explicite de l’utilisateur pour chaque client enregistré dynamiquement et en appliquant les bonnes pratiques de sécurité OAuth.
- Éviter les vulnérabilités de passage de jetons en s’assurant que les serveurs MCP n’acceptent que les jetons explicitement émis pour eux et en validant correctement les revendications des jetons.
- Traiter tous les composants de votre chaîne d’approvisionnement IA — y compris les modèles, embeddings et fournisseurs de contexte — avec la même rigueur que les dépendances de code.
- Rester à jour avec l’évolution des spécifications MCP et contribuer à la communauté pour aider à façonner des standards sécurisés.

# Ressources supplémentaires

## Ressources externes
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [Spécification MCP](https://spec.modelcontextprotocol.io/)
- [Bonnes pratiques de sécurité MCP](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Spécification d’autorisation MCP](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Meilleures pratiques de sécurité OAuth 2.0 (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Injection de prompt dans MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Attaques d’empoisonnement d’outils (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls dans MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Documentation Prompt Shields (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 pour LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Accès sécurisé au moindre privilège (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Bonnes pratiques pour la validation et la durée de vie des jetons](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Utiliser un stockage sécurisé des jetons et chiffrer les jetons (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management comme passerelle d’authentification pour MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Utiliser Microsoft Entra ID pour s’authentifier auprès des serveurs MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Documents de sécurité supplémentaires

Pour des conseils de sécurité plus détaillés, veuillez consulter ces documents :

- [Bonnes pratiques de sécurité MCP 2025](./mcp-security-best-practices-2025.md) – Liste complète des bonnes pratiques de sécurité pour les implémentations MCP
- [Implémentation Azure Content Safety](./azure-content-safety-implementation.md) – Exemples d’intégration d’Azure Content Safety avec les serveurs MCP
- [Contrôles de sécurité MCP 2025](./mcp-security-controls-2025.md) – Derniers contrôles et techniques de sécurité pour sécuriser les déploiements MCP
- [Bonnes pratiques MCP](./mcp-best-practices.md) – Guide de référence rapide pour la sécurité MCP

### Suivant

Suivant : [Chapitre 3 : Premiers pas](../03-GettingStarted/README.md)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.