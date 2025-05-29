<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:31:12+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "tl"
}
-->
# Mga Pinakamahusay na Kasanayan sa Seguridad

Ang paggamit ng Model Context Protocol (MCP) ay nagdadala ng makapangyarihang mga kakayahan sa mga AI-driven na aplikasyon, ngunit naglalaman din ito ng mga natatanging hamon sa seguridad na lampas sa karaniwang panganib sa software. Bukod sa mga kilalang isyu tulad ng secure coding, least privilege, at supply chain security, ang MCP at AI workloads ay nahaharap sa mga bagong banta tulad ng prompt injection, tool poisoning, at dynamic tool modification. Ang mga panganib na ito ay maaaring magdulot ng pagnanakaw ng datos, paglabag sa privacy, at hindi inaasahang kilos ng sistema kung hindi ito maayos na mapangasiwaan.

Tatalakayin sa araling ito ang mga pinaka-mahalagang panganib sa seguridad na kaugnay ng MCP—kabilang ang authentication, authorization, labis na permiso, indirect prompt injection, at mga kahinaan sa supply chain—at magbibigay ng mga konkretong kontrol at pinakamahusay na kasanayan para mabawasan ang mga ito. Matututuhan mo rin kung paano gamitin ang mga solusyon ng Microsoft tulad ng Prompt Shields, Azure Content Safety, at GitHub Advanced Security upang palakasin ang iyong implementasyon ng MCP. Sa pamamagitan ng pag-unawa at paggamit ng mga kontrol na ito, maaari mong mabawasan nang malaki ang posibilidad ng paglabag sa seguridad at matiyak na ang iyong mga AI system ay nananatiling matatag at mapagkakatiwalaan.

# Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:

- Tukuyin at ipaliwanag ang mga natatanging panganib sa seguridad na dala ng Model Context Protocol (MCP), kabilang ang prompt injection, tool poisoning, labis na permiso, at kahinaan sa supply chain.
- Ilahad at gamitin ang epektibong mga kontrol upang mabawasan ang panganib sa seguridad ng MCP, tulad ng matibay na authentication, least privilege, secure token management, at supply chain verification.
- Maunawaan at gamitin ang mga solusyon ng Microsoft tulad ng Prompt Shields, Azure Content Safety, at GitHub Advanced Security para protektahan ang MCP at AI workloads.
- Kilalanin ang kahalagahan ng pag-validate ng tool metadata, pagmamanman ng mga dynamic na pagbabago, at pagtatanggol laban sa indirect prompt injection attacks.
- Isama ang mga kilalang pinakamahusay na kasanayan sa seguridad—tulad ng secure coding, server hardening, at zero trust architecture—sa iyong implementasyon ng MCP upang mabawasan ang posibilidad at epekto ng paglabag sa seguridad.

# Mga Kontrol sa Seguridad ng MCP

Anumang sistema na may access sa mahahalagang resources ay may kasamang mga hamon sa seguridad. Karaniwang nalulutas ang mga ito sa pamamagitan ng tamang aplikasyon ng mga pangunahing kontrol at konsepto sa seguridad. Dahil ang MCP ay bagong tukoy lamang, mabilis ang pagbabago ng espesipikasyon habang umuunlad ang protocol. Sa kalaunan, huhubugin ng mga kontrol sa seguridad nito ang mas mahusay na integrasyon sa mga enterprise at mga kilalang arkitektura at pinakamahusay na kasanayan sa seguridad.

Ayon sa pananaliksik na inilathala sa [Microsoft Digital Defense Report](https://aka.ms/mddr), 98% ng mga naulat na paglabag ay maiiwasan kung maipatutupad ang matibay na hygiene sa seguridad. Ang pinakamahusay na proteksyon laban sa anumang uri ng paglabag ay ang maayos na baseline ng hygiene sa seguridad, pinakamahusay na kasanayan sa secure coding, at seguridad sa supply chain—ang mga subok na kasanayan na kilala na natin ang may pinakamalaking epekto sa pagbabawas ng panganib sa seguridad.

Tingnan natin ang ilang paraan kung paano mo masisimulan ang pagtugon sa mga panganib sa seguridad kapag ginagamit ang MCP.

> **Note:** Tama ang mga sumusunod na impormasyon hanggang **29 Mayo 2025**. Patuloy ang pag-unlad ng MCP protocol, at maaaring magpakilala ng mga bagong pattern sa authentication at kontrol ang mga susunod na implementasyon. Para sa pinakabagong update at gabay, palaging sumangguni sa [MCP Specification](https://spec.modelcontextprotocol.io/) at opisyal na [MCP GitHub repository](https://github.com/modelcontextprotocol) pati na rin sa [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Pahayag ng Problema  
Ang orihinal na MCP specification ay inaasahan na ang mga developer ay gagawa ng sarili nilang authentication server. Nangangailangan ito ng kaalaman sa OAuth at mga kaugnay na limitasyon sa seguridad. Ang mga MCP server ay kumilos bilang OAuth 2.0 Authorization Servers, na direktang pinamamahalaan ang authentication ng user sa halip na ipasa ito sa isang panlabas na serbisyo tulad ng Microsoft Entra ID. Simula **26 Abril 2025**, pinapayagan ng update sa MCP specification na ang mga MCP server ay maaaring ipasa ang authentication ng user sa isang panlabas na serbisyo.

### Mga Panganib
- Ang maling pagkakaayos ng authorization logic sa MCP server ay maaaring magdulot ng paglabas ng sensitibong datos at maling aplikasyon ng mga access control.
- Pagnanakaw ng OAuth token sa lokal na MCP server. Kapag ninakaw, magagamit ang token upang magpanggap bilang MCP server at ma-access ang mga resources at datos mula sa serbisyong kinakatawan ng OAuth token.

#### Token Passthrough
Mahigpit na ipinagbabawal ang token passthrough sa authorization specification dahil nagdudulot ito ng iba't ibang panganib sa seguridad, kabilang ang:

#### Pag-iwas sa Kontrol sa Seguridad
Maaaring ipatupad ng MCP Server o downstream APIs ang mahahalagang kontrol sa seguridad tulad ng rate limiting, request validation, o traffic monitoring, na nakadepende sa token audience o iba pang mga credential constraint. Kung makakakuha ang mga kliyente at magagamit ang mga token nang direkta sa downstream APIs nang hindi sinusuri ng MCP server ang mga ito nang maayos o tinitiyak na ang mga token ay inilabas para sa tamang serbisyo, nalalampasan nila ang mga kontrol na ito.

#### Isyu sa Pananagutan at Audit Trail
Hindi makikilala o mapaghihiwalay ng MCP Server ang mga MCP Clients kapag tumatawag ang mga kliyente gamit ang access token na inilabas ng upstream na maaaring opaque sa MCP Server. Maaaring ipakita sa mga log ng downstream Resource Server ang mga kahilingan na tila nanggaling sa ibang pinagmulan na may ibang pagkakakilanlan, sa halip na mula sa MCP server na talaga namang nagpapasa ng mga token. Pahirap ito sa pagsisiyasat ng insidente, kontrol, at pag-audit. Kung ipapasa ng MCP Server ang mga token nang hindi sinusuri ang kanilang mga claim (hal. mga role, pribilehiyo, o audience) o iba pang metadata, maaaring gamitin ng isang malisyosong aktor na may hawak ng ninakaw na token ang server bilang proxy para sa pagnanakaw ng datos.

#### Isyu sa Trust Boundary
Nagbibigay ang downstream Resource Server ng tiwala sa mga tiyak na entidad. Kasama dito ang mga palagay tungkol sa pinagmulan o mga pattern ng kilos ng kliyente. Ang paglabag sa trust boundary na ito ay maaaring magdulot ng mga hindi inaasahang problema. Kung tatanggapin ng maraming serbisyo ang token nang walang wastong pagsusuri, maaaring gamitin ng attacker na nakompromiso ang isang serbisyo ang token upang ma-access ang iba pang konektadong serbisyo.

#### Panganib sa Hinaharap na Compatibility
Kahit na magsimula ang MCP Server bilang “pure proxy” ngayon, maaaring kailanganin nitong magdagdag ng mga kontrol sa seguridad sa hinaharap. Ang pagsisimula sa tamang paghihiwalay ng token audience ay nagpapadali sa pag-unlad ng modelo ng seguridad.

### Mga Kontrol na Pampigil

**HINDI DAPAT tumanggap ang mga MCP server ng anumang token na hindi tahasang inilabas para sa MCP server**

- **Suriin at Palakasin ang Authorization Logic:** Maingat na i-audit ang implementasyon ng authorization ng iyong MCP server upang matiyak na tanging mga tamang user at kliyente lamang ang may access sa sensitibong resources. Para sa praktikal na gabay, tingnan ang [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) at [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Ipairal ang Secure Token Practices:** Sundin ang [pinakamahusay na kasanayan ng Microsoft para sa token validation at lifetime](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) upang maiwasan ang maling paggamit ng access tokens at mabawasan ang panganib ng token replay o pagnanakaw.
- **Protektahan ang Token Storage:** Palaging itago ang mga token nang ligtas at gumamit ng encryption upang maprotektahan ito habang nakaimbak at habang ipinapadala. Para sa mga tip sa implementasyon, tingnan ang [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Labis na Permiso para sa mga MCP Server

### Pahayag ng Problema  
Maaaring nabigyan ang mga MCP server ng labis na permiso sa serbisyong o resource na kanilang ina-access. Halimbawa, ang isang MCP server na bahagi ng AI sales application na nakakonekta sa enterprise data store ay dapat may access lamang sa sales data at hindi pinapayagan na ma-access ang lahat ng mga file sa store. Balikan natin ang prinsipyo ng least privilege (isa sa mga pinakamatandang prinsipyo sa seguridad), na nagsasaad na walang resource ang dapat magkaroon ng permiso na higit pa sa kinakailangan para maisagawa ang mga itinalagang gawain. Mas mahirap ito sa AI dahil upang maging flexible, mahirap tukuyin ang eksaktong mga permiso na kailangan.

### Mga Panganib  
- Ang pagbibigay ng labis na permiso ay maaaring magdulot ng pagnanakaw o pagbabago ng datos na hindi dapat ma-access ng MCP server. Maaari rin itong maging isyu sa privacy kung ang datos ay personal na nakikilalang impormasyon (PII).

### Mga Kontrol na Pampigil  
- **Ipairal ang Prinsipyo ng Least Privilege:** Bigyan lamang ang MCP server ng pinakamababang permiso na kinakailangan upang maisagawa ang mga gawain nito. Regular na suriin at i-update ang mga permiso upang matiyak na hindi ito lalabis sa kinakailangan. Para sa detalyadong gabay, tingnan ang [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Gamitin ang Role-Based Access Control (RBAC):** Mag-assign ng mga role sa MCP server na mahigpit ang saklaw sa mga partikular na resources at aksyon, iwasan ang malawak o hindi kinakailangang permiso.
- **Mag-monitor at Mag-audit ng Mga Permiso:** Patuloy na subaybayan ang paggamit ng permiso at i-audit ang mga access log upang agad na matukoy at maitama ang labis o hindi nagagamit na mga pribilehiyo.

# Mga Indirect Prompt Injection Attacks

### Pahayag ng Problema

Ang mga malisyoso o nakompromisong MCP server ay maaaring magdulot ng malalaking panganib sa pamamagitan ng paglalantad ng datos ng customer o pagpapahintulot ng hindi inaasahang aksyon. Lalo na itong mahalaga sa mga AI at MCP-based workloads, kung saan:

- **Prompt Injection Attacks**: Naglalagay ang mga attacker ng malisyosong utos sa mga prompt o panlabas na nilalaman, na nagiging sanhi ng AI system na magsagawa ng hindi inaasahang aksyon o mag-leak ng sensitibong datos. Alamin pa: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Manipulahin ng mga attacker ang metadata ng mga tool (tulad ng mga deskripsyon o parameter) upang maimpluwensyahan ang kilos ng AI, posibleng lampasan ang mga kontrol sa seguridad o magnakaw ng datos. Detalye: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Naglalagay ng malisyosong utos sa mga dokumento, web page, o email na pagkatapos ay pinoproseso ng AI, na nagreresulta sa pag-leak o manipulasyon ng datos.
- **Dynamic Tool Modification (Rug Pulls)**: Maaaring baguhin ang mga depinisyon ng tool pagkatapos ng pag-apruba ng user, na nagdudulot ng bagong malisyosong kilos nang hindi nalalaman ng user.

Ipinapakita ng mga kahinaang ito ang pangangailangan para sa matibay na pag-validate, pagmamanman, at mga kontrol sa seguridad kapag isinama ang MCP server at mga tool sa iyong kapaligiran. Para sa mas malalim na paliwanag, tingnan ang mga naka-link na sanggunian sa itaas.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.tl.png)

**Indirect Prompt Injection** (kilala rin bilang cross-domain prompt injection o XPIA) ay isang kritikal na kahinaan sa mga generative AI system, kabilang ang mga gumagamit ng Model Context Protocol (MCP). Sa atakeng ito, itinatago ang malisyosong mga utos sa panlabas na nilalaman—tulad ng mga dokumento, web page, o email. Kapag pinroseso ito ng AI system, maaaring ituring nito ang mga nakatagong utos bilang lehitimong mga utos ng user, na nagreresulta sa hindi inaasahang aksyon tulad ng pag-leak ng datos, paglikha ng mapanganib na nilalaman, o manipulasyon ng mga interaksyon ng user. Para sa detalyadong paliwanag at mga totoong halimbawa, tingnan ang [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Isang partikular na mapanganib na anyo ng atakeng ito ay ang **Tool Poisoning**. Dito, naglalagay ang mga attacker ng malisyosong utos sa metadata ng mga MCP tool (tulad ng deskripsyon o mga parameter ng tool). Dahil umaasa ang mga large language model (LLM) sa metadata na ito upang magpasya kung aling mga tool ang tatawagin, maaaring lokohin ng mga kompromisadong deskripsyon ang modelo upang magsagawa ng hindi awtorisadong tawag sa tool o lampasan ang mga kontrol sa seguridad. Madalas na hindi nakikita ng mga end user ang mga manipulasyong ito ngunit maaaring maintindihan at maisagawa ng AI system. Mas mataas ang panganib na ito sa mga hosted MCP server environment, kung saan maaaring baguhin ang mga depinisyon ng tool pagkatapos ng pag-apruba ng user—isang sitwasyon na tinatawag minsan na "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Sa ganitong mga kaso, ang isang tool na dating ligtas ay maaaring baguhin upang magsagawa ng malisyosong aksyon, tulad ng pagnanakaw ng datos o pagbabago ng kilos ng sistema, nang hindi nalalaman ng user. Para sa karagdagang impormasyon tungkol sa attack vector na ito, tingnan ang [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.tl.png)

## Mga Panganib  
Ang hindi inaasahang mga aksyon ng AI ay nagdudulot ng iba't ibang panganib sa seguridad tulad ng pagnanakaw ng datos at paglabag sa privacy.

### Mga Kontrol na Pampigil  
### Paggamit ng prompt shields para protektahan laban sa Indirect Prompt Injection attacks
-----------------------------------------------------------------------------

**AI Prompt Shields** ay solusyong binuo ng Microsoft upang ipagtanggol laban sa parehong direct at indirect prompt injection attacks. Nakakatulong ito sa pamamagitan ng:

1.  **Pagtuklas at Pag-filter:** Gumagamit ang Prompt Shields ng advanced na machine learning algorithms at natural language processing upang tuklasin at alisin ang malisyosong utos na nakapaloob sa panlabas na nilalaman, tulad ng mga dokumento, web page, o email.
    
2.  **Spotlighting:** Tinutulungan ng teknik na ito ang AI system na makilala ang pagitan ng wastong mga utos ng sistema at mga potensyal na hindi mapagkakatiwalaang panlabas na input. Sa pamamagitan ng pagbabago ng input text upang maging mas relevant sa modelo, tinitiyak ng Spotlighting na mas mahusay na matukoy at mapawalang-bisa ng AI ang malisyosong utos.
    
3.  **Delimiters at Datamarking:** Ang paglalagay ng delimiters sa system message ay malinaw na naglalarawan ng lokasyon ng input text, na tumutulong sa AI system na makilala at paghiwalayin ang mga input ng user mula sa posibleng mapanganib na panlabas na nilalaman. Pinalalawak ng datamarking ang konseptong ito sa pamamagitan ng paggamit ng mga espesyal na marka upang i-highlight ang mga hangganan ng pinagkakatiwalaang at hindi pinagkakatiwalaang datos.
    
4.  **Patuloy na Pagmamanman at Update:** Patuloy na minomonitor at ina-update ng Microsoft ang Prompt Shields upang tugunan ang mga bago at umuusbong na banta. Ang maagap na paraang ito ay nagsisiguro na nananatiling epektibo ang depensa laban sa pinakabagong mga teknik ng pag-atake.
    
5. **Integrasyon sa Azure Content Safety:** Bahagi ang Prompt Shields ng mas malawak na Azure AI Content Safety suite, na nagbibigay ng karagdagang mga tool para sa pagtuklas ng jailbreak attempts, mapanganib na nilalaman, at iba pang panganib sa seguridad sa mga AI application.

Maaari kang magbasa pa tungkol sa AI prompt shields sa [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.tl.png)

### Seguridad sa Supply Chain

Nanatiling mahalaga ang seguridad sa supply chain sa panahon ng AI,
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 para sa LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Ang Paglalakbay para Siguraduhin ang Software Supply Chain sa Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Mga Pinakamahusay na Praktis para sa Token Validation at Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Gamitin ang Secure Token Storage at I-encrypt ang mga Token (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management bilang Auth Gateway para sa MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Paggamit ng Microsoft Entra ID para Mag-authenticate sa MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Susunod

Susunod: [Kabanata 3: Pagsisimula](/03-GettingStarted/README.md)

**Pagsisiwalat**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na bahagi. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.