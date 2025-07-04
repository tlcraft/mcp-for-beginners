<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-04T18:21:44+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "tl"
}
-->
# Security Best Practices

Ang paggamit ng Model Context Protocol (MCP) ay nagdadala ng makapangyarihang bagong kakayahan sa mga AI-driven na aplikasyon, ngunit nagdudulot din ito ng mga natatanging hamon sa seguridad na lampas sa mga tradisyunal na panganib sa software. Bukod sa mga kilalang isyu tulad ng secure coding, least privilege, at supply chain security, ang MCP at mga AI workload ay nahaharap sa mga bagong banta gaya ng prompt injection, tool poisoning, at dynamic tool modification. Ang mga panganib na ito ay maaaring magdulot ng pagnanakaw ng datos, paglabag sa privacy, at hindi inaasahang pag-uugali ng sistema kung hindi maayos na mapangasiwaan.

Tinutuklas ng araling ito ang mga pinaka-mahalagang panganib sa seguridad na kaugnay ng MCP—kabilang ang authentication, authorization, labis na permiso, indirect prompt injection, at mga kahinaan sa supply chain—at nagbibigay ng mga praktikal na kontrol at pinakamahusay na mga gawi upang mapagaan ang mga ito. Matututuhan mo rin kung paano gamitin ang mga solusyon ng Microsoft tulad ng Prompt Shields, Azure Content Safety, at GitHub Advanced Security upang palakasin ang iyong implementasyon ng MCP. Sa pamamagitan ng pag-unawa at paggamit ng mga kontrol na ito, malaki ang maitutulong mo upang mabawasan ang posibilidad ng security breach at matiyak na ang iyong mga AI system ay nananatiling matatag at mapagkakatiwalaan.

# Learning Objectives

Sa pagtatapos ng araling ito, magagawa mong:

- Tukuyin at ipaliwanag ang mga natatanging panganib sa seguridad na dala ng Model Context Protocol (MCP), kabilang ang prompt injection, tool poisoning, labis na permiso, at mga kahinaan sa supply chain.
- Ilahad at gamitin ang mga epektibong kontrol para mapagaan ang mga panganib sa seguridad ng MCP, tulad ng matibay na authentication, least privilege, secure token management, at supply chain verification.
- Unawain at gamitin ang mga solusyon ng Microsoft tulad ng Prompt Shields, Azure Content Safety, at GitHub Advanced Security upang protektahan ang MCP at mga AI workload.
- Kilalanin ang kahalagahan ng pag-validate ng tool metadata, pagmamanman sa mga dynamic na pagbabago, at pagtatanggol laban sa indirect prompt injection attacks.
- Isama ang mga itinatag na pinakamahusay na gawi sa seguridad—tulad ng secure coding, server hardening, at zero trust architecture—sa iyong implementasyon ng MCP upang mabawasan ang posibilidad at epekto ng mga security breach.

# MCP security controls

Ang anumang sistema na may access sa mahahalagang resources ay may kaakibat na mga hamon sa seguridad. Karaniwang natutugunan ang mga hamong ito sa pamamagitan ng tamang aplikasyon ng mga pangunahing kontrol at konsepto sa seguridad. Dahil ang MCP ay bagong tukoy lamang, mabilis ang pagbabago ng espesipikasyon habang umuunlad ang protocol. Sa kalaunan, huhubugin at huhusayin ang mga kontrol sa seguridad nito, na magpapadali ng mas mahusay na integrasyon sa mga enterprise at itinatag na mga arkitektura at pinakamahusay na gawi sa seguridad.

Ayon sa pananaliksik na inilathala sa [Microsoft Digital Defense Report](https://aka.ms/mddr), 98% ng mga naiulat na paglabag ay maiiwasan sa pamamagitan ng matibay na security hygiene at ang pinakamahusay na proteksyon laban sa anumang uri ng paglabag ay ang pagkakaroon ng tamang baseline security hygiene, secure coding best practices, at supply chain security—ang mga subok na gawi na ito ang may pinakamalaking epekto sa pagbawas ng panganib sa seguridad.

Tingnan natin ang ilang paraan kung paano mo masisimulan tugunan ang mga panganib sa seguridad kapag ginagamit ang MCP.

> **Note:** Ang sumusunod na impormasyon ay tama hanggang sa **29 Mayo 2025**. Patuloy na umuunlad ang MCP protocol, at maaaring magpakilala ang mga susunod na implementasyon ng mga bagong pattern at kontrol sa authentication. Para sa pinakabagong update at gabay, palaging sumangguni sa [MCP Specification](https://spec.modelcontextprotocol.io/) at sa opisyal na [MCP GitHub repository](https://github.com/modelcontextprotocol) at [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problem statement  
Ang orihinal na espesipikasyon ng MCP ay inaasahan na ang mga developer ang gagawa ng kanilang sariling authentication server. Nangangailangan ito ng kaalaman sa OAuth at mga kaugnay na limitasyon sa seguridad. Ang mga MCP server ay kumikilos bilang OAuth 2.0 Authorization Servers, na direktang namamahala sa kinakailangang user authentication sa halip na ipasa ito sa isang panlabas na serbisyo tulad ng Microsoft Entra ID. Simula noong **26 Abril 2025**, isang update sa MCP specification ang nagpapahintulot sa mga MCP server na ipasa ang user authentication sa isang panlabas na serbisyo.

### Risks
- Ang maling pagkakaayos ng authorization logic sa MCP server ay maaaring magdulot ng paglantad ng sensitibong datos at maling paglalapat ng access controls.
- Pagnanakaw ng OAuth token sa lokal na MCP server. Kapag nakawin, maaaring gamitin ang token upang magpanggap bilang MCP server at ma-access ang mga resources at datos mula sa serbisyong kinakatawan ng OAuth token.

#### Token Passthrough
Mahigpit na ipinagbabawal ang token passthrough sa authorization specification dahil nagdudulot ito ng ilang panganib sa seguridad, kabilang ang:

#### Security Control Circumvention
Maaaring ipatupad ng MCP Server o downstream APIs ang mahahalagang kontrol sa seguridad tulad ng rate limiting, request validation, o traffic monitoring, na nakadepende sa token audience o iba pang credential constraints. Kung makakakuha ang mga kliyente at magagamit ang mga token nang direkta sa downstream APIs nang hindi sinusuri ng MCP server ang mga ito nang maayos o tinitiyak na ang mga token ay inilabas para sa tamang serbisyo, nalalampasan nila ang mga kontrol na ito.

#### Accountability and Audit Trail Issues
Hindi matutukoy o mahihiwalay ng MCP Server ang mga MCP Clients kapag tumatawag ang mga kliyente gamit ang access token na inilabas ng upstream na maaaring opaque sa MCP Server.  
Maaaring ipakita ng mga log ng downstream Resource Server ang mga kahilingan na tila nagmumula sa ibang pinagmulan na may ibang pagkakakilanlan, sa halip na mula sa MCP server na aktwal na nagpapasa ng mga token.  
Pinapahirap ng mga salik na ito ang pagsisiyasat ng insidente, kontrol, at pag-audit.  
Kung ipapasa ng MCP Server ang mga token nang hindi sinusuri ang kanilang mga claim (hal., mga role, pribilehiyo, o audience) o iba pang metadata, maaaring gamitin ng isang malisyosong aktor na may hawak ng nakaw na token ang server bilang proxy para sa pagnanakaw ng datos.

#### Trust Boundary Issues
Nagbibigay ang downstream Resource Server ng tiwala sa mga partikular na entidad. Maaaring kasama sa tiwalang ito ang mga palagay tungkol sa pinagmulan o mga pattern ng pag-uugali ng kliyente. Ang paglabag sa trust boundary na ito ay maaaring magdulot ng hindi inaasahang mga isyu.  
Kung tatanggapin ng maraming serbisyo ang token nang walang tamang pagsusuri, maaaring gamitin ng isang attacker na nakompromiso ang isang serbisyo ang token upang ma-access ang iba pang konektadong serbisyo.

#### Future Compatibility Risk
Kahit na magsimula ang MCP Server bilang isang “pure proxy” ngayon, maaaring kailanganin nitong magdagdag ng mga kontrol sa seguridad sa hinaharap. Ang pagsisimula sa tamang paghihiwalay ng token audience ay nagpapadali sa pag-unlad ng modelo ng seguridad.

### Mitigating controls

**HINDI DAPAT tumanggap ang MCP servers ng anumang token na hindi tahasang inilabas para sa MCP server**

- **Suriin at Patatagin ang Authorization Logic:** Maingat na i-audit ang implementasyon ng authorization ng iyong MCP server upang matiyak na tanging ang mga inaasahang user at kliyente lamang ang may access sa sensitibong resources. Para sa praktikal na gabay, tingnan ang [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) at [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Ipairal ang Secure Token Practices:** Sundin ang [pinakamahusay na gawi ng Microsoft para sa token validation at lifetime](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) upang maiwasan ang maling paggamit ng access tokens at mabawasan ang panganib ng token replay o pagnanakaw.
- **Protektahan ang Imbakan ng Token:** Laging itago ang mga token nang ligtas at gumamit ng encryption upang maprotektahan ang mga ito habang nakaimbak at habang ipinapadala. Para sa mga tip sa implementasyon, tingnan ang [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
Maaaring nabigyan ang mga MCP server ng labis na permiso sa serbisyong o resource na kanilang ina-access. Halimbawa, ang isang MCP server na bahagi ng AI sales application na kumokonekta sa enterprise data store ay dapat may access lamang sa sales data at hindi pinapayagang ma-access ang lahat ng mga file sa store. Balikan ang prinsipyo ng least privilege (isa sa pinakamatandang prinsipyo sa seguridad), na walang resource ang dapat magkaroon ng permiso na lampas sa kinakailangan upang maisagawa ang mga tungkuling inilaan para dito. Nagdudulot ng dagdag na hamon ang AI sa aspetong ito dahil upang maging flexible ito, mahirap tukuyin nang eksakto ang mga kinakailangang permiso.

### Risks  
- Ang pagbibigay ng labis na permiso ay maaaring magdulot ng pagnanakaw o pagbabago ng datos na hindi dapat ma-access ng MCP server. Maaari rin itong maging isyu sa privacy kung ang datos ay personal na impormasyon (PII).

### Mitigating controls  
- **Ipatupad ang Prinsipyo ng Least Privilege:** Bigyan lamang ang MCP server ng pinakamababang permiso na kinakailangan upang maisagawa ang mga tungkulin nito. Regular na suriin at i-update ang mga permiso upang matiyak na hindi ito lumalampas sa kinakailangan. Para sa detalyadong gabay, tingnan ang [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Gumamit ng Role-Based Access Control (RBAC):** Magtalaga ng mga role sa MCP server na mahigpit na nakatuon sa mga partikular na resources at aksyon, iwasan ang malawak o hindi kinakailangang mga permiso.
- **Subaybayan at I-audit ang mga Permiso:** Patuloy na subaybayan ang paggamit ng permiso at i-audit ang mga access log upang mabilis na matukoy at maitama ang labis o hindi nagagamit na mga pribilehiyo.

# Indirect prompt injection attacks

### Problem statement

Ang mga malisyoso o nakompromisong MCP server ay maaaring magdulot ng malalaking panganib sa pamamagitan ng paglantad ng datos ng customer o pagpapahintulot ng mga hindi inaasahang aksyon. Lalo na itong mahalaga sa mga AI at MCP-based na workload, kung saan:

- **Prompt Injection Attacks**: Naglalagay ang mga attacker ng malisyosong mga utos sa mga prompt o panlabas na nilalaman, na nagiging sanhi ng AI system na magsagawa ng mga hindi inaasahang aksyon o magbunyag ng sensitibong datos. Alamin pa: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Pinapalitan ng mga attacker ang metadata ng tool (tulad ng mga paglalarawan o parameter) upang maimpluwensyahan ang pag-uugali ng AI, na posibleng makalusot sa mga kontrol sa seguridad o magnakaw ng datos. Detalye: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Ang malisyosong mga utos ay inilalagay sa mga dokumento, web page, o email, na pagkatapos ay pinoproseso ng AI, na nagreresulta sa paglabas o pagmamanipula ng datos.
- **Dynamic Tool Modification (Rug Pulls)**: Maaaring baguhin ang mga depinisyon ng tool pagkatapos ng pag-apruba ng user, na nagdadala ng bagong malisyosong pag-uugali nang hindi nalalaman ng user.

Ipinapakita ng mga kahinaan na ito ang pangangailangan para sa matibay na pag-validate, pagmamanman, at mga kontrol sa seguridad kapag isinama ang mga MCP server at tool sa iyong kapaligiran. Para sa mas malalim na pagtalakay, tingnan ang mga naka-link na sanggunian sa itaas.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.tl.png)

Ang **Indirect Prompt Injection** (kilala rin bilang cross-domain prompt injection o XPIA) ay isang kritikal na kahinaan sa mga generative AI system, kabilang ang mga gumagamit ng Model Context Protocol (MCP). Sa atakeng ito, ang malisyosong mga utos ay nakatago sa panlabas na nilalaman—tulad ng mga dokumento, web page, o email. Kapag pinoproseso ng AI system ang nilalamang ito, maaaring ituring nito ang mga nakatagong utos bilang lehitimong mga utos ng user, na nagreresulta sa mga hindi inaasahang aksyon tulad ng paglabas ng datos, paggawa ng mapanganib na nilalaman, o pagmamanipula ng interaksyon ng user. Para sa detalyadong paliwanag at mga totoong halimbawa, tingnan ang [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Isang partikular na mapanganib na anyo ng atakeng ito ay ang **Tool Poisoning**. Dito, naglalagay ang mga attacker ng malisyosong mga utos sa metadata ng mga MCP tool (tulad ng mga paglalarawan o parameter ng tool). Dahil umaasa ang mga malalaking language model (LLM) sa metadata na ito upang magpasya kung aling mga tool ang tatawagin, maaaring linlangin ng mga kompromisadong paglalarawan ang modelo upang magsagawa ng hindi awtorisadong mga tawag sa tool o makalusot sa mga kontrol sa seguridad. Madalas na hindi nakikita ng mga end user ang mga manipulasyong ito ngunit maaaring ma-interpret at maisagawa ng AI system. Mas tumitindi ang panganib na ito sa mga hosted MCP server environment, kung saan maaaring baguhin ang mga depinisyon ng tool pagkatapos ng pag-apruba ng user—isang sitwasyon na tinatawag minsan na "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Sa ganitong mga kaso, ang isang dating ligtas na tool ay maaaring baguhin upang magsagawa ng malisyosong aksyon, tulad ng pagnanakaw ng datos o pagbabago ng pag-uugali ng sistema, nang hindi nalalaman ng user. Para sa karagdagang impormasyon tungkol sa attack vector na ito, tingnan ang [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.tl.png)

## Risks  
Ang mga hindi inaasahang aksyon ng AI ay nagdudulot ng iba't ibang panganib sa seguridad kabilang ang pagnanakaw ng datos at paglabag sa privacy.

### Mitigating controls  
### Paggamit ng prompt shields upang protektahan laban sa Indirect Prompt Injection attacks
-----------------------------------------------------------------------------

Ang **AI Prompt Shields** ay isang solusyon na binuo ng Microsoft upang ipagtanggol laban sa parehong direct at indirect prompt injection attacks. Nakakatulong ito sa pamamagitan ng:

1.  **Detection and Filtering**: Gumagamit ang Prompt Shields ng advanced na machine learning algorithms at natural language processing upang matukoy at salain ang malisyosong mga utos na nakapaloob sa panlabas na nilalaman, tulad ng mga dokumento, web page, o email.
    
2.  **Spotlighting**: Tinutulungan ng teknik na ito ang AI system na makilala ang pagitan ng mga wastong utos ng sistema at mga posibleng hindi mapagkakatiwalaang panlabas na input. Sa pamamagitan ng pagbabago ng input text upang maging mas kaugnay sa modelo, tinitiyak ng Spotlighting na mas mahusay na matutukoy at maiiwasan ng AI ang malisyosong mga utos.
    
3.  **Delimiters and Datamarking**: Ang pagsasama ng delimiters sa system message ay tahasang inilalagay ang lokasyon ng input text, na tumutulong sa AI system na makilala at paghiwalayin ang mga input ng user mula sa posibleng mapanganib na panlabas na nilalaman. Pinalalawak ng datamarking ang konseptong ito sa pamamagitan ng paggamit ng mga espesyal na marka upang itampok ang mga hangganan ng pinagkakatiwalaan at hindi pinagkakatiwalaang datos.
    
4.  **Continuous Monitoring and Updates**: Patuloy na minomonitor at ina-update ng Microsoft ang Prompt Shields upang tugunan ang mga bagong at umuusbong na banta. Ang proaktibong pamamaraang ito ay nagsisiguro na nananatiling epektibo ang depensa laban sa pinakabagong mga teknik ng pag-atake.
    
5. **Integration with Azure Content Safety:** Bahagi ang Prompt Shields ng mas malawak na Azure AI Content Safety suite, na nagbibigay ng karagdagang mga tool para matukoy ang mga jailbreak attempts, mapanganib na nilalaman, at iba pang panganib sa seguridad sa mga AI application.

Maaari kang magbasa pa tungkol sa AI prompt shields sa [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.tl.png)

### Supply chain security
Nanatiling mahalaga ang seguridad ng supply chain sa panahon ng AI, ngunit lumawak na ang saklaw ng tinuturing na bahagi ng iyong supply chain. Bukod sa tradisyunal na mga code package, kailangan mo na ngayong masusing beripikahin at subaybayan ang lahat ng kaugnay na bahagi ng AI, kabilang ang foundation models, embedding services, context providers, at third-party APIs. Bawat isa sa mga ito ay maaaring magdala ng kahinaan o panganib kung hindi maayos na mapangasiwaan.

**Pangunahing mga gawi sa seguridad ng supply chain para sa AI at MCP:**
- **Beripikahin ang lahat ng bahagi bago isama:** Hindi lang ito para sa open-source libraries, kundi pati na rin sa AI models, mga pinagkukunan ng data, at mga external API. Palaging suriin ang pinagmulan, lisensya, at mga kilalang kahinaan.
- **Panatilihin ang ligtas na deployment pipelines:** Gumamit ng automated CI/CD pipelines na may kasamang security scanning upang maagapan ang mga isyu nang maaga. Siguraduhing tanging mga pinagkakatiwalaang artifacts lamang ang ide-deploy sa production.
- **Patuloy na subaybayan at i-audit:** Magpatupad ng tuloy-tuloy na monitoring para sa lahat ng dependencies, kabilang ang mga modelo at data services, upang matukoy ang mga bagong kahinaan o pag-atake sa supply chain.
- **Ipatupad ang least privilege at access controls:** Limitahan ang access sa mga modelo, data, at serbisyo sa tanging kinakailangan lamang para gumana ang iyong MCP server.
- **Mabilis na tumugon sa mga banta:** Magkaroon ng proseso para sa pag-patch o pagpapalit ng mga kompromisadong bahagi, at para sa pag-ikot ng mga sikreto o kredensyal kung may matukoy na paglabag.

Nagbibigay ang [GitHub Advanced Security](https://github.com/security/advanced-security) ng mga tampok tulad ng secret scanning, dependency scanning, at CodeQL analysis. Ang mga tool na ito ay nakikipag-integrate sa [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) at [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) upang tulungan ang mga koponan na tuklasin at mabawasan ang mga kahinaan sa parehong code at mga bahagi ng AI supply chain.

Nagpapatupad din ang Microsoft ng malawakang mga gawi sa seguridad ng supply chain sa loob ng kumpanya para sa lahat ng produkto. Alamin pa sa [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Mga Naitatag na Pinakamahuhusay na Gawi sa Seguridad na Magpapalakas sa Seguridad ng Iyong MCP Implementation

Anumang MCP implementation ay namamana ang umiiral na seguridad ng kapaligiran ng iyong organisasyon kung saan ito itinayo, kaya kapag isinasaalang-alang ang seguridad ng MCP bilang bahagi ng iyong kabuuang AI system, inirerekomenda na pagbutihin mo ang pangkalahatang umiiral na seguridad. Ang mga sumusunod na naitatag na kontrol sa seguridad ay partikular na mahalaga:

-   Pinakamahuhusay na gawi sa secure coding sa iyong AI application – protektahan laban sa [the OWASP Top 10](https://owasp.org/www-project-top-ten/), ang [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), paggamit ng secure vaults para sa mga sikreto at token, pagpapatupad ng end-to-end secure communications sa pagitan ng lahat ng bahagi ng application, atbp.
-   Server hardening – gumamit ng MFA kung maaari, panatilihing updated ang mga patch, i-integrate ang server sa third party identity provider para sa access, atbp.
-   Panatilihing updated ang mga device, imprastruktura, at aplikasyon gamit ang mga patch
-   Security monitoring – pagpapatupad ng logging at monitoring ng AI application (kabilang ang MCP client/servers) at pagpapadala ng mga log na ito sa isang sentral na SIEM para sa pagtuklas ng mga kakaibang aktibidad
-   Zero trust architecture – paghihiwalay ng mga bahagi gamit ang network at identity controls sa isang lohikal na paraan upang mabawasan ang lateral movement kung sakaling ma-kompromiso ang AI application.

# Pangunahing Mga Punto

- Mahalaga pa rin ang mga pundasyon ng seguridad: Secure coding, least privilege, beripikasyon ng supply chain, at tuloy-tuloy na monitoring ay mahalaga para sa MCP at AI workloads.
- Nagdadala ang MCP ng mga bagong panganib—tulad ng prompt injection, tool poisoning, at labis na mga permiso—na nangangailangan ng parehong tradisyunal at AI-specific na mga kontrol.
- Gumamit ng matibay na authentication, authorization, at token management na mga gawi, gamit ang mga external identity provider tulad ng Microsoft Entra ID kung maaari.
- Protektahan laban sa indirect prompt injection at tool poisoning sa pamamagitan ng pag-validate ng tool metadata, pagmamanman sa mga dynamic na pagbabago, at paggamit ng mga solusyon tulad ng Microsoft Prompt Shields.
- Tratuhin ang lahat ng bahagi sa iyong AI supply chain—kabilang ang mga modelo, embeddings, at context providers—ng may parehong kaseryosohan tulad ng mga code dependencies.
- Manatiling updated sa mga nagbabagong MCP specifications at makibahagi sa komunidad upang makatulong sa paghubog ng mga ligtas na pamantayan.

# Karagdagang Mga Mapagkukunan

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Susunod

Susunod: [Chapter 3: Getting Started](../03-GettingStarted/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.