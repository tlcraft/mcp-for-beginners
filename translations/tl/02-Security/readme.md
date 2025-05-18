<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:44:47+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "tl"
}
-->
# Mga Pinakamahusay na Kasanayan sa Seguridad

Ang paggamit ng Model Context Protocol (MCP) ay nagdadala ng makapangyarihang bagong kakayahan sa mga aplikasyon na pinapagana ng AI, ngunit nagdudulot din ito ng natatanging mga hamon sa seguridad na lumalampas sa mga tradisyonal na panganib ng software. Bukod sa mga naitatag na alalahanin tulad ng secure coding, least privilege, at seguridad ng supply chain, ang MCP at mga workload ng AI ay nahaharap sa mga bagong banta tulad ng prompt injection, tool poisoning, at dynamic tool modification. Ang mga panganib na ito ay maaaring humantong sa pag-exfiltrate ng data, paglabag sa privacy, at hindi inaasahang pag-uugali ng sistema kung hindi maayos na pinamahalaan.

Tatalakayin ng araling ito ang pinaka-nauugnay na mga panganib sa seguridad na nauugnay sa MCP—kabilang ang authentication, authorization, labis na mga pahintulot, hindi direktang prompt injection, at mga kahinaan sa supply chain—at magbibigay ng mga naaaksyunang kontrol at pinakamahusay na kasanayan upang mapagaan ang mga ito. Matututuhan mo rin kung paano gamitin ang mga solusyon ng Microsoft tulad ng Prompt Shields, Azure Content Safety, at GitHub Advanced Security upang palakasin ang iyong pagpapatupad ng MCP. Sa pamamagitan ng pag-unawa at paglalapat ng mga kontrol na ito, maaari mong makabuluhang bawasan ang posibilidad ng isang paglabag sa seguridad at tiyakin na ang iyong mga sistema ng AI ay mananatiling matibay at mapagkakatiwalaan.

# Mga Layunin sa Pag-aaral

Sa pagtatapos ng araling ito, magagawa mong:

- Tukuyin at ipaliwanag ang mga natatanging panganib sa seguridad na ipinakilala ng Model Context Protocol (MCP), kabilang ang prompt injection, tool poisoning, labis na mga pahintulot, at mga kahinaan sa supply chain.
- Ilarawan at ilapat ang mabisang mga kontrol sa pagpapagaan para sa mga panganib sa seguridad ng MCP, tulad ng matatag na authentication, least privilege, secure token management, at pag-verify ng supply chain.
- Maunawaan at gamitin ang mga solusyon ng Microsoft tulad ng Prompt Shields, Azure Content Safety, at GitHub Advanced Security upang protektahan ang mga workload ng MCP at AI.
- Kilalanin ang kahalagahan ng pag-validate ng metadata ng tool, pagmamanman ng mga dynamic na pagbabago, at pagtatanggol laban sa hindi direktang mga pag-atake ng prompt injection.
- Isama ang mga itinatag na pinakamahusay na kasanayan sa seguridad—tulad ng secure coding, server hardening, at zero trust architecture—sa iyong pagpapatupad ng MCP upang mabawasan ang posibilidad at epekto ng mga paglabag sa seguridad.

# Mga kontrol sa seguridad ng MCP

Anumang sistema na may access sa mahahalagang mapagkukunan ay may ipinahiwatig na mga hamon sa seguridad. Ang mga hamon sa seguridad ay karaniwang matutugunan sa pamamagitan ng tamang aplikasyon ng mga pangunahing kontrol sa seguridad at konsepto. Habang ang MCP ay bagong tinukoy lamang, ang detalye ay mabilis na nagbabago at habang umuunlad ang protocol. Sa kalaunan, ang mga kontrol sa seguridad sa loob nito ay magiging mas mature, na magbibigay-daan sa mas mahusay na pagsasama sa mga arkitektura ng seguridad ng enterprise at itinatag na mga pinakamahusay na kasanayan.

Ang pananaliksik na inilathala sa [Microsoft Digital Defense Report](https://aka.ms/mddr) ay nagsasaad na 98% ng mga naiulat na paglabag ay maiiwasan sa pamamagitan ng matatag na kalinisan sa seguridad at ang pinakamahusay na proteksyon laban sa anumang uri ng paglabag ay upang makuha ang iyong pangunahing kalinisan sa seguridad, pinakamahusay na kasanayan sa secure coding at seguridad ng supply chain nang tama -- ang mga subok at nasubok na mga kasanayan na alam na natin ay mayroon pa ring pinakamalaking epekto sa pagbabawas ng panganib sa seguridad.

Tingnan natin ang ilan sa mga paraan na maaari mong simulan upang matugunan ang mga panganib sa seguridad kapag gumagamit ng MCP.

# Authentication ng server ng MCP (kung ang iyong pagpapatupad ng MCP ay bago ang ika-26 ng Abril 2025)

### Pahayag ng problema
Ang orihinal na detalye ng MCP ay ipinapalagay na ang mga developer ay magsusulat ng kanilang sariling authentication server. Nangangailangan ito ng kaalaman sa OAuth at mga kaugnay na hadlang sa seguridad. Ang mga server ng MCP ay kumilos bilang mga OAuth 2.0 Authorization Servers, na direktang namamahala sa kinakailangang authentication ng gumagamit sa halip na i-delegate ito sa isang panlabas na serbisyo tulad ng Microsoft Entra ID. Noong ika-26 ng Abril 2025, pinapayagan ng isang update sa detalye ng MCP ang mga server ng MCP na i-delegate ang authentication ng gumagamit sa isang panlabas na serbisyo.

### Mga Panganib
- Ang maling pagkaka-configure ng lohika ng authorization sa server ng MCP ay maaaring humantong sa pagkakalantad ng sensitibong data at maling paggamit ng mga kontrol sa access.
- Pagnanakaw ng token ng OAuth sa lokal na server ng MCP. Kung nanakaw, ang token ay maaaring gamitin upang magpanggap bilang server ng MCP at ma-access ang mga mapagkukunan at data mula sa serbisyo na para sa OAuth token.

### Mga kontrol sa pagpapagaan
- **Suriin at Palakasin ang Lohika ng Authorization:** Maingat na i-audit ang pagpapatupad ng authorization ng iyong server ng MCP upang matiyak na ang mga nilalayong gumagamit at kliyente lamang ang makaka-access sa mga sensitibong mapagkukunan. Para sa praktikal na gabay, tingnan ang [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) at [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Ipapatupad ang Secure Token Practices:** Sundin ang [pinakamahusay na kasanayan ng Microsoft para sa pag-validate ng token at buhay ng token](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) upang maiwasan ang maling paggamit ng mga access token at bawasan ang panganib ng token replay o pagnanakaw.
- **Protektahan ang Token Storage:** Palaging iimbak ang mga token nang ligtas at gumamit ng encryption upang protektahan ang mga ito sa pamamahinga at sa transit. Para sa mga tip sa pagpapatupad, tingnan ang [Gumamit ng secure na imbakan ng token at i-encrypt ang mga token](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Labis na mga pahintulot para sa mga server ng MCP

### Pahayag ng problema
Ang mga server ng MCP ay maaaring nabigyan ng labis na mga pahintulot sa serbisyo/mapagkukunan na kanilang ina-access. Halimbawa, ang isang server ng MCP na bahagi ng isang aplikasyon sa pagbebenta ng AI na kumokonekta sa isang enterprise data store ay dapat na may access na limitado sa data ng pagbebenta at hindi pinapayagang ma-access ang lahat ng mga file sa store. Sa pag-refer sa prinsipyo ng least privilege (isa sa pinakalumang prinsipyo ng seguridad), walang mapagkukunan ang dapat magkaroon ng mga pahintulot na labis sa kung ano ang kinakailangan para maisagawa nito ang mga gawain na nilayon para dito. Ang AI ay nagdudulot ng isang nadagdagang hamon sa puwang na ito dahil upang paganahin ito upang maging flexible, maaari itong maging mahirap tukuyin ang eksaktong mga pahintulot na kinakailangan.

### Mga Panganib
- Ang pagbibigay ng labis na mga pahintulot ay maaaring magbigay-daan sa pag-exfiltrate o pagbabago ng data na hindi nilayon na ma-access ng server ng MCP. Maaari rin itong maging isang isyu sa privacy kung ang data ay personal na makikilalang impormasyon (PII).

### Mga kontrol sa pagpapagaan
- **Ilapat ang Prinsipyo ng Least Privilege:** Bigyan ang server ng MCP ng tanging pinakamababang pahintulot na kinakailangan upang maisagawa ang kinakailangang mga gawain. Regular na suriin at i-update ang mga pahintulot na ito upang matiyak na hindi sila lumalampas sa kung ano ang kinakailangan. Para sa detalyadong gabay, tingnan ang [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Gumamit ng Role-Based Access Control (RBAC):** Magtalaga ng mga tungkulin sa server ng MCP na mahigpit na naka-scope sa mga partikular na mapagkukunan at aksyon, na iniiwasan ang malawak o hindi kinakailangang mga pahintulot.
- **Subaybayan at I-audit ang mga Pahintulot:** Patuloy na subaybayan ang paggamit ng pahintulot at i-audit ang mga log ng access upang agad na matukoy at malunasan ang labis o hindi nagamit na mga pribilehiyo.

# Hindi direktang mga pag-atake ng prompt injection

### Pahayag ng problema

Ang mga mapanlinlang o nakompromisong server ng MCP ay maaaring magpakilala ng mga makabuluhang panganib sa pamamagitan ng paglalantad ng data ng customer o pagpapagana ng hindi inaasahang mga aksyon. Ang mga panganib na ito ay partikular na nauugnay sa mga workload na batay sa AI at MCP, kung saan:

- **Prompt Injection Attacks**: Ang mga umaatake ay naglalagay ng mapanlinlang na mga tagubilin sa mga prompt o panlabas na nilalaman, na nagiging sanhi ng sistema ng AI na magsagawa ng hindi inaasahang mga aksyon o mag-leak ng sensitibong data. Matuto pa: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Ang mga umaatake ay nagmamanipula ng metadata ng tool (tulad ng mga paglalarawan o parameter) upang maimpluwensyahan ang pag-uugali ng AI, na potensyal na binabalewala ang mga kontrol sa seguridad o nag-e-exfiltrate ng data. Mga Detalye: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Ang mga mapanlinlang na tagubilin ay naka-embed sa mga dokumento, web page, o email, na pagkatapos ay pinoproseso ng AI, na humahantong sa pag-leak o pagmamanipula ng data.
- **Dynamic Tool Modification (Rug Pulls)**: Ang mga kahulugan ng tool ay maaaring mabago pagkatapos ng pag-apruba ng gumagamit, na nagpapakilala ng mga bagong mapanlinlang na pag-uugali nang walang kaalaman ng gumagamit.

Ang mga kahinaan na ito ay nagha-highlight ng pangangailangan para sa matatag na pag-validate, pagmamanman, at mga kontrol sa seguridad kapag isinama ang mga server at tool ng MCP sa iyong kapaligiran. Para sa mas malalim na pagsisid, tingnan ang mga naka-link na sanggunian sa itaas.

**Indirect Prompt Injection** (kilala rin bilang cross-domain prompt injection o XPIA) ay isang kritikal na kahinaan sa mga generative AI system, kabilang ang mga gumagamit ng Model Context Protocol (MCP). Sa pag-atakeng ito, ang mga mapanlinlang na tagubilin ay nakatago sa loob ng panlabas na nilalaman—tulad ng mga dokumento, web page, o email. Kapag pinoproseso ng sistema ng AI ang nilalamang ito, maaari nitong i-interpret ang mga naka-embed na tagubilin bilang mga lehitimong utos ng gumagamit, na nagreresulta sa hindi inaasahang mga aksyon tulad ng pag-leak ng data, pagbuo ng mapanganib na nilalaman, o pagmamanipula ng mga pakikipag-ugnayan ng gumagamit. Para sa detalyadong paliwanag at mga halimbawa sa totoong mundo, tingnan ang [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Isang partikular na mapanganib na anyo ng pag-atakeng ito ay ang **Tool Poisoning**. Dito, ang mga umaatake ay naglalagay ng mapanlinlang na tagubilin sa metadata ng mga tool ng MCP (tulad ng mga paglalarawan ng tool o mga parameter). Dahil ang mga malalaking modelo ng wika (LLMs) ay umaasa sa metadata na ito upang magpasya kung aling mga tool ang tatawagin, ang mga nakompromisong paglalarawan ay maaaring linlangin ang modelo na magsagawa ng hindi awtorisadong tawag sa tool o i-bypass ang mga kontrol sa seguridad. Ang mga manipulasyong ito ay madalas na hindi nakikita ng mga end user ngunit maaaring i-interpret at isagawa ng sistema ng AI. Ang panganib na ito ay nadagdagan sa mga kapaligirang naka-host sa server ng MCP, kung saan ang mga kahulugan ng tool ay maaaring i-update pagkatapos ng pag-apruba ng gumagamit—isang senaryo na minsang tinutukoy bilang isang "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Sa mga ganitong kaso, ang isang tool na dati ay ligtas ay maaaring kalaunan ay mabago upang magsagawa ng mga mapanlinlang na aksyon, tulad ng pag-exfiltrate ng data o pagbabago ng pag-uugali ng sistema, nang walang kaalaman ng gumagamit. Para sa higit pang impormasyon sa vector ng pag-atake na ito, tingnan ang [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

## Mga Panganib
Ang hindi inaasahang mga aksyon ng AI ay nagdudulot ng iba't ibang mga panganib sa seguridad na kinabibilangan ng pag-exfiltrate ng data at paglabag sa privacy.

### Mga kontrol sa pagpapagaan
### Paggamit ng prompt shields upang protektahan laban sa Indirect Prompt Injection attacks
-----------------------------------------------------------------------------

Ang **AI Prompt Shields** ay isang solusyon na binuo ng Microsoft upang ipagtanggol laban sa parehong direktang at hindi direktang prompt injection attacks. Tumutulong ang mga ito sa pamamagitan ng:

1. **Pagtuklas at Pagsala**: Ang Prompt Shields ay gumagamit ng mga advanced na algorithm ng machine learning at natural language processing upang makita at salain ang mga mapanlinlang na tagubilin na naka-embed sa panlabas na nilalaman, tulad ng mga dokumento, web page, o email.
    
2. **Spotlighting**: Ang diskarteng ito ay tumutulong sa sistema ng AI na makilala sa pagitan ng mga wastong tagubilin ng sistema at potensyal na hindi mapagkakatiwalaang mga panlabas na input. Sa pamamagitan ng pagbabago ng input na teksto sa paraang mas nauugnay sa modelo, tinitiyak ng Spotlighting na mas mahusay na makikilala at maiiwasan ng AI ang mga mapanlinlang na tagubilin.
    
3. **Mga Delimiter at Datamarking**: Ang paglalagay ng mga delimiter sa mensahe ng sistema ay malinaw na binabalangkas ang lokasyon ng input na teksto, na tumutulong sa sistema ng AI na makilala at paghiwalayin ang mga input ng gumagamit mula sa potensyal na mapanganib na panlabas na nilalaman. Ang Datamarking ay nagpapalawak ng konseptong ito sa pamamagitan ng paggamit ng mga espesyal na marker upang i-highlight ang mga hangganan ng pinagkakatiwalaan at hindi pinagkakatiwalaang data.
    
4. **Patuloy na Pagmamanman at Pag-update**: Ang Microsoft ay patuloy na nagmamanman at nag-a-update ng Prompt Shields upang matugunan ang mga bago at umuusbong na banta. Tinitiyak ng proaktibong pamamaraang ito na ang mga depensa ay mananatiling epektibo laban sa pinakabagong mga diskarte sa pag-atake.
    
5. **Pagsasama sa Azure Content Safety:** Ang Prompt Shields ay bahagi ng mas malawak na suite ng Azure AI Content Safety, na nagbibigay ng karagdagang mga tool para sa pagtuklas ng mga jailbreak attempt, mapanganib na nilalaman, at iba pang mga panganib sa seguridad sa mga aplikasyon ng AI.

Maaari kang magbasa nang higit pa tungkol sa AI prompt shields sa [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

### Seguridad ng supply chain

Ang seguridad ng supply chain ay nananatiling pangunahing sa panahon ng AI, ngunit ang saklaw ng kung ano ang bumubuo sa iyong supply chain ay lumawak. Bilang karagdagan sa mga tradisyonal na package ng code, dapat mo na ngayong mahigpit na i-verify at subaybayan ang lahat ng mga bahagi na nauugnay sa AI, kabilang ang mga foundation model, mga embedding service, mga provider ng konteksto, at mga third-party na API. Ang bawat isa sa mga ito ay maaaring magpakilala ng mga kahinaan o panganib kung hindi maayos na pinamahalaan.

**Pangunahing mga kasanayan sa seguridad ng supply chain para sa AI at MCP:**
- **I-verify ang lahat ng mga bahagi bago isama:** Kasama dito hindi lamang ang mga open-source na library, kundi pati na rin ang mga modelo ng AI, mga pinagmumulan ng data, at mga panlabas na API. Palaging suriin ang pinagmulan, paglilisensya, at mga kilalang kahinaan.
- **Panatilihin ang mga secure na deployment pipeline:** Gumamit ng mga automated na CI/CD pipeline na may pinagsamang pag-scan sa seguridad upang mahuli ang mga isyu nang maaga. Tiyakin na ang tanging pinagkakatiwalaang mga artifact lamang ang na-deploy sa produksyon.
- **Patuloy na subaybayan at i-audit:** Magpatupad ng patuloy na pagmamanman para sa lahat ng mga dependency, kabilang ang mga modelo at serbisyo ng data, upang makita ang mga bagong kahinaan o pag-atake sa supply chain.
- **Ilapat ang least privilege at mga kontrol sa access:** I-restrict ang access sa mga modelo, data
- [OWASP Top 10 para sa LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Ang Paglalakbay para Siguraduhin ang Software Supply Chain sa Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Mga Pinakamahusay na Praktis para sa Pag-validate ng Token at Buhay ng Token](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Gamitin ang Secure Token Storage at I-encrypt ang mga Token (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management bilang Auth Gateway para sa MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Gamit ang Microsoft Entra ID para Mag-authenticate sa MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Susunod

Susunod: [Kabanata 3: Pagsisimula](/03-GettingStarted/README.md)

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). Habang sinisikap namin ang kawastuhan, mangyaring tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatumpak. Ang orihinal na dokumento sa kanyang katutubong wika ay dapat ituring na mapagkakatiwalaang pinagmulan. Para sa kritikal na impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na dulot ng paggamit ng pagsasaling ito.