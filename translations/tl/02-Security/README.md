<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:19:56+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "tl"
}
-->
# Security Best Practices

Ang paggamit ng Model Context Protocol (MCP) ay nagdadala ng makapangyarihang kakayahan sa mga AI-driven na aplikasyon, ngunit nagdudulot din ito ng mga natatanging hamon sa seguridad na lampas sa mga tradisyunal na panganib sa software. Bukod sa mga kilalang isyu tulad ng secure coding, least privilege, at supply chain security, nahaharap ang MCP at AI workloads sa mga bagong banta gaya ng prompt injection, tool poisoning, at dynamic tool modification. Kung hindi maayos na mapangasiwaan, maaari itong magresulta sa pagnanakaw ng datos, paglabag sa privacy, at hindi inaasahang pag-uugali ng sistema.

Tatalakayin sa araling ito ang mga pinaka-mahalagang panganib sa seguridad na kaugnay ng MCP—kabilang ang authentication, authorization, labis na permiso, indirect prompt injection, at kahinaan sa supply chain—at magbibigay ng mga konkretong kontrol at pinakamahusay na gawi upang mabawasan ang mga ito. Matututuhan mo rin kung paano gamitin ang mga solusyon ng Microsoft tulad ng Prompt Shields, Azure Content Safety, at GitHub Advanced Security upang palakasin ang iyong implementasyon ng MCP. Sa pag-unawa at paggamit ng mga kontrol na ito, malaki ang maitutulong upang mabawasan ang posibilidad ng security breach at mapanatiling matatag at mapagkakatiwalaan ang iyong mga AI system.

# Learning Objectives

Sa pagtatapos ng araling ito, magagawa mong:

- Tukuyin at ipaliwanag ang mga natatanging panganib sa seguridad na dala ng Model Context Protocol (MCP), kabilang ang prompt injection, tool poisoning, labis na permiso, at kahinaan sa supply chain.
- Ilahad at gamitin ang epektibong mga kontrol upang mapagaan ang mga panganib sa seguridad ng MCP, tulad ng matibay na authentication, least privilege, secure token management, at supply chain verification.
- Unawain at gamitin ang mga solusyon ng Microsoft tulad ng Prompt Shields, Azure Content Safety, at GitHub Advanced Security para protektahan ang MCP at AI workloads.
- Kilalanin ang kahalagahan ng pag-validate ng tool metadata, pagmamanman sa mga dynamic na pagbabago, at pagtatanggol laban sa indirect prompt injection attacks.
- Isama ang mga itinatag na pinakamahusay na gawi sa seguridad—tulad ng secure coding, server hardening, at zero trust architecture—sa iyong implementasyon ng MCP upang mabawasan ang posibilidad at epekto ng mga security breach.

# MCP security controls

Ang anumang sistema na may access sa mahahalagang resources ay may kaakibat na mga hamon sa seguridad. Karaniwang natutugunan ang mga ito sa pamamagitan ng tamang aplikasyon ng mga pangunahing kontrol at konsepto sa seguridad. Dahil bagong-bago pa lamang ang MCP, mabilis ang pagbabago ng specification habang umuunlad ang protocol. Sa kalaunan, huhubugin at gagalingin ang mga kontrol sa seguridad nito upang mas mahusay na maisama sa mga enterprise at itinatag na arkitektura at pinakamahusay na gawi sa seguridad.

Ayon sa pananaliksik na inilathala sa [Microsoft Digital Defense Report](https://aka.ms/mddr), 98% ng mga naiulat na security breach ay maiiwasan kung may matibay na security hygiene. Ang pinakamahusay na proteksyon laban sa anumang breach ay ang pagkakaroon ng maayos na baseline security hygiene, secure coding best practices, at supply chain security—ang mga subok na gawi na ito pa rin ang may pinakamalaking epekto sa pagbabawas ng panganib sa seguridad.

Tingnan natin ang ilang paraan upang simulan ang pagtugon sa mga panganib sa seguridad kapag ginagamit ang MCP.

# MCP server authentication (kung ang iyong implementasyon ng MCP ay bago ang 26 Abril 2025)

> **Note:** Ang sumusunod na impormasyon ay tama hanggang 26 Abril 2025. Patuloy ang pag-unlad ng MCP protocol, at maaaring magpakilala ng mga bagong authentication pattern at kontrol ang mga susunod na implementasyon. Para sa pinakabagong update at gabay, palaging tingnan ang [MCP Specification](https://spec.modelcontextprotocol.io/) at ang opisyal na [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Problem statement  
Ang orihinal na MCP specification ay nag-assume na ang mga developer ang gagawa ng sariling authentication server. Nangangailangan ito ng kaalaman sa OAuth at kaugnay na mga security constraints. Ang mga MCP server ay gumaganap bilang OAuth 2.0 Authorization Servers, na direktang namamahala sa user authentication sa halip na ipasa ito sa isang external service tulad ng Microsoft Entra ID. Simula 26 Abril 2025, pinapayagan ng update sa MCP specification ang MCP servers na i-delegate ang user authentication sa isang external na serbisyo.

### Risks
- Ang maling pagkakaayos ng authorization logic sa MCP server ay maaaring magdulot ng paglantad ng sensitibong datos at maling pag-apply ng access controls.
- Pagkawala o pagnanakaw ng OAuth token sa lokal na MCP server. Kapag nakuha ito, maaaring gamitin ang token upang magpanggap bilang MCP server at ma-access ang mga resources at datos mula sa serbisyo na para saan ang OAuth token.

### Mitigating controls
- **Suriin at Patatagin ang Authorization Logic:** Maingat na i-audit ang authorization implementation ng iyong MCP server upang matiyak na tanging mga inaasahang user at client lamang ang may access sa sensitibong resources. Para sa praktikal na gabay, tingnan ang [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) at [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Ipairal ang Secure Token Practices:** Sundin ang [Microsoft’s best practices para sa token validation at lifetime](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) upang maiwasan ang maling paggamit ng access tokens at mabawasan ang panganib ng token replay o pagnanakaw.
- **Protektahan ang Token Storage:** Laging itago nang ligtas ang mga token at gumamit ng encryption para maprotektahan ang mga ito habang nakaimbak at habang ipinapadala. Para sa mga tips sa implementasyon, tingnan ang [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
Maaaring nabigyan ang MCP servers ng labis na permiso sa serbisyong o resource na kanilang ina-access. Halimbawa, ang isang MCP server na bahagi ng AI sales application na kumokonekta sa enterprise data store ay dapat limitado lamang sa access sa sales data at hindi dapat pinapayagang ma-access ang lahat ng files sa store. Balikan ang prinsipyo ng least privilege (isa sa pinakamatandang prinsipyo sa seguridad), na nagsasabing walang resource ang dapat magkaroon ng permiso na lampas sa kinakailangan para sa mga gawain nito. Mas mahirap ito sa AI dahil upang maging flexible, mahirap tukuyin nang eksakto ang mga kinakailangang permiso.

### Risks  
- Ang pagbibigay ng labis na permiso ay maaaring magdulot ng pagnanakaw o pagbabago ng data na hindi dapat ma-access ng MCP server. Maaari rin itong maging isyu sa privacy kung ang data ay personal na impormasyon (PII).

### Mitigating controls
- **Ipatupad ang Prinsipyo ng Least Privilege:** Bigyan lamang ang MCP server ng pinakamababang permiso na kailangan para maisagawa ang mga kinakailangang gawain. Regular na suriin at i-update ang mga permiso upang matiyak na hindi ito lumalampas sa kinakailangan. Para sa detalyadong gabay, tingnan ang [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Gamitin ang Role-Based Access Control (RBAC):** Magtalaga ng mga role sa MCP server na mahigpit na naka-scope sa mga partikular na resources at aksyon, iwasan ang malawak o hindi kinakailangang mga permiso.
- **Subaybayan at I-audit ang mga Permiso:** Patuloy na bantayan ang paggamit ng permiso at i-audit ang mga access logs upang mabilis matukoy at maayos ang labis o hindi nagagamit na mga permiso.

# Indirect prompt injection attacks

### Problem statement

Ang mga malisyoso o compromised na MCP server ay maaaring magdulot ng malalaking panganib sa pamamagitan ng paglantad ng data ng customer o pagpayag sa hindi inaasahang aksyon. Lalo na itong mahalaga sa AI at MCP-based workloads, kung saan:

- **Prompt Injection Attacks**: Nagtatago ang mga attacker ng malisyosong utos sa mga prompt o panlabas na nilalaman, na nagiging sanhi ng AI system na magsagawa ng hindi inaasahang aksyon o mag-leak ng sensitibong data. Matuto pa: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Binabago ng mga attacker ang metadata ng tool (tulad ng mga paglalarawan o parameter) upang maimpluwensyahan ang kilos ng AI, posibleng malampasan ang mga security control o makakuha ng data nang ilegal. Detalye: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Nagtatago ang malisyosong utos sa mga dokumento, web page, o email, na pagkatapos ay pinoproseso ng AI, na nagreresulta sa pag-leak o manipulasyon ng data.
- **Dynamic Tool Modification (Rug Pulls)**: Maaaring mabago ang mga depinisyon ng tool pagkatapos ng pag-apruba ng user, na nagdadala ng bagong malisyosong kilos nang hindi nalalaman ng user.

Ipinapakita ng mga kahinaan na ito ang pangangailangan para sa matibay na validation, pagmamanman, at kontrol sa seguridad kapag iniintegrate ang MCP servers at tools sa iyong kapaligiran. Para sa mas malalim na pagtalakay, tingnan ang mga link sa itaas.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.tl.png)

**Indirect Prompt Injection** (kilala rin bilang cross-domain prompt injection o XPIA) ay isang kritikal na kahinaan sa mga generative AI system, kabilang ang mga gumagamit ng Model Context Protocol (MCP). Sa atakeng ito, ang malisyosong utos ay nakatago sa panlabas na nilalaman—tulad ng mga dokumento, web page, o email. Kapag pinoproseso ng AI system ang nilalamang ito, maaaring ituring nitong lehitimong utos mula sa user ang nakatagong instruksiyon, na nagreresulta sa hindi inaasahang aksyon tulad ng pag-leak ng data, paglikha ng mapanganib na nilalaman, o manipulasyon ng pakikipag-ugnayan ng user. Para sa detalyadong paliwanag at mga totoong halimbawa, tingnan ang [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Isang partikular na delikadong uri ng atake ay ang **Tool Poisoning**. Dito, naglalagay ang mga attacker ng malisyosong utos sa metadata ng mga MCP tool (tulad ng mga paglalarawan o parameter). Dahil umaasa ang mga malalaking language model (LLMs) sa metadata na ito upang pumili ng gagamiting tool, maaaring lokohin ng mga compromised na paglalarawan ang modelo na magsagawa ng hindi awtorisadong tawag sa tool o lampasan ang mga security control. Madalas na hindi nakikita ng mga end user ang mga manipulasyong ito, ngunit maaaring basahin at isagawa ng AI system. Mas tumitindi ang panganib na ito sa mga hosted MCP server environment, kung saan maaaring baguhin ang mga depinisyon ng tool pagkatapos ng pag-apruba ng user—isang sitwasyon na tinatawag minsan na "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Sa ganitong kaso, ang isang tool na dati ay ligtas ay maaaring baguhin upang magsagawa ng malisyosong aksyon, tulad ng pagnanakaw ng data o pagbabago ng pag-uugali ng sistema, nang hindi nalalaman ng user. Para sa karagdagang impormasyon tungkol sa attack vector na ito, tingnan ang [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.tl.png)

## Risks
Ang hindi inaasahang aksyon ng AI ay nagdudulot ng iba't ibang panganib sa seguridad tulad ng pagnanakaw ng datos at paglabag sa privacy.

### Mitigating controls
### Paggamit ng prompt shields upang protektahan laban sa Indirect Prompt Injection attacks
-----------------------------------------------------------------------------

**AI Prompt Shields** ay solusyong binuo ng Microsoft upang ipagtanggol laban sa parehong direct at indirect prompt injection attacks. Nakakatulong ito sa pamamagitan ng:

1.  **Detection at Filtering**: Gumagamit ang Prompt Shields ng advanced machine learning algorithms at natural language processing upang matukoy at ma-filter ang malisyosong utos na nakatago sa panlabas na nilalaman tulad ng mga dokumento, web page, o email.
    
2.  **Spotlighting**: Tinutulungan ng teknik na ito ang AI system na makilala ang pagitan ng valid na system instructions at posibleng hindi mapagkakatiwalaang external inputs. Sa pamamagitan ng pagbabago ng input text upang maging mas relevant sa modelo, natutulungan ng Spotlighting ang AI na mas maayos na matukoy at balewalain ang malisyosong utos.
    
3.  **Delimiters at Datamarking**: Ang paglalagay ng delimiters sa system message ay malinaw na inilalagay kung saan nagsisimula at nagtatapos ang input text, na tumutulong sa AI system na maiba at makilala ang user inputs mula sa posibleng mapanganib na panlabas na nilalaman. Pinalalawak ng datamarking ang konseptong ito sa pamamagitan ng paggamit ng espesyal na marka upang i-highlight ang hangganan ng pinagkakatiwalaang at hindi pinagkakatiwalaang data.
    
4.  **Patuloy na Pagmamanman at Updates**: Patuloy na minomonitor at ina-update ng Microsoft ang Prompt Shields upang tugunan ang mga bagong at umuusbong na banta. Ang ganitong proactive na pamamaraan ay tinitiyak na nananatiling epektibo ang depensa laban sa pinakabagong teknik ng atake.
    
5. **Integrasyon sa Azure Content Safety:** Kasama ang Prompt Shields sa mas malawak na Azure AI Content Safety suite, na nagbibigay ng dagdag na mga kasangkapan para matukoy ang jailbreak attempts, mapanganib na nilalaman, at iba pang panganib sa seguridad sa AI applications.

Maaari kang magbasa pa tungkol sa AI prompt shields sa [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.tl.png)

### Supply chain security

Nanatiling pundamental ang supply chain security sa panahon ng AI, ngunit lumawak na ang saklaw ng kung ano ang itinuturing na supply chain mo. Bukod sa tradisyunal na mga code package, kailangan mo nang masusing beripikahin at subaybayan ang lahat ng AI-related na bahagi, kabilang ang foundation models, embedding services, context providers, at third-party APIs. Bawat isa rito ay maaaring magdala ng kahinaan o panganib kung hindi maayos na pinangangasiwaan.

**Pangunahing gawi sa supply chain security para sa AI at MCP:**
- **Beripikahin lahat ng bahagi bago isama:** Hindi lang mga open-source libraries, pati na rin ang AI models, data sources, at external APIs. Palaging suriin ang pinagmulan, lisensya, at kilalang kahinaan.
- **Panatilihing ligtas ang deployment pipelines:** Gumamit ng automated CI/CD pipelines na may kasamang security scanning upang maagapan ang mga isyu nang maaga. Siguraduhing tanging mga pinagkakatiwalaang artifacts lamang ang nade-deploy sa production.
- **Patuloy na pagmamanman at pag-audit:** Magpatupad ng tuloy-tuloy na pagmamanman sa lahat ng dependencies, kabilang ang models at data services, upang matukoy ang mga bagong kahinaan o supply chain attacks.
- **Ipatupad ang least privilege at access controls:** Limitahan ang access sa models, data, at serbisyo sa tanging kinakailangan lamang para gumana ang MCP server.
- **Mabilis na pagtugon sa mga banta:** Magkaroon ng proseso para sa pag-patch o pagpapalit ng mga compromised na bahagi, at para sa pag-ikot ng mga secrets o credentials kung may ma-detect na breach.

Nagbibigay ang [GitHub Advanced Security](https://github.com/security/advanced-security) ng mga tampok tulad ng secret scanning, dependency scanning, at CodeQL analysis. Ang mga kasangkapang ito ay nakikipag-integrate sa [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) at [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) upang tulungan ang mga koponan na tuklasin at bawasan ang mga kahinaan sa parehong code at AI supply chain components.

Nagpapatupad din ang Microsoft ng malawakang supply chain security practices sa loob para sa lahat ng produkto nito. Matuto pa sa [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Established security best practices that will uplift your MCP implementation's security posture

Ang anumang implementasyon ng MCP ay nagmamana ng umiiral na security posture ng kapaligiran ng iyong organisasyon kung saan ito binuo, kaya kapag isinasaalang-alang ang seguridad ng MCP bilang bahagi ng kabuuang AI system, inirerekomenda na paigtingin mo ang pangkalahatang umiiral na security posture. Ang mga sumusunod na itinatag na kontrol sa seguridad ay partikular na mahalaga:

- Mga pinakamahusay na gawi sa secure coding sa iyong AI application—protektahan laban sa [OWASP Top 10](https://owasp.org/www-project-top-ten/), ang [OWASP Top 10 para
- [OWASP Top 10 para sa LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Ang Paglalakbay para Siguraduhin ang Software Supply Chain sa Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Pinakamahusay na Paraan para sa Token Validation at Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Gamitin ang Secure Token Storage at Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management bilang Auth Gateway para sa MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Paggamit ng Microsoft Entra ID para Mag-authenticate sa MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Susunod

Susunod: [Kabanata 3: Pagsisimula](/03-GettingStarted/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami na maging tumpak, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.