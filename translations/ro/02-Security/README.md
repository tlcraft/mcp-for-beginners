<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:36:23+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "ro"
}
-->
# Security Best Practices

Adoptarea Model Context Protocol (MCP) aduce capabilități noi și puternice aplicațiilor bazate pe AI, dar introduce și provocări de securitate unice, care depășesc riscurile tradiționale din software. Pe lângă preocupările cunoscute precum codarea sigură, principiul privilegiului minim și securitatea lanțului de aprovizionare, MCP și sarcinile AI se confruntă cu amenințări noi, cum ar fi injectarea de prompturi, otrăvirea uneltelor și modificarea dinamică a uneltelor. Aceste riscuri pot conduce la exfiltrarea datelor, încălcări ale confidențialității și comportamente neintenționate ale sistemului dacă nu sunt gestionate corect.

Această lecție explorează cele mai relevante riscuri de securitate asociate cu MCP — inclusiv autentificarea, autorizarea, permisiunile excesive, injectarea indirectă de prompturi și vulnerabilitățile lanțului de aprovizionare — și oferă controale și bune practici aplicabile pentru a le atenua. De asemenea, vei învăța cum să folosești soluții Microsoft precum Prompt Shields, Azure Content Safety și GitHub Advanced Security pentru a întări implementarea MCP. Prin înțelegerea și aplicarea acestor controale, poți reduce semnificativ probabilitatea unui incident de securitate și poți asigura că sistemele tale AI rămân robuste și de încredere.

# Learning Objectives

La finalul acestei lecții, vei putea să:

- Identifici și să explici riscurile unice de securitate introduse de Model Context Protocol (MCP), inclusiv injectarea de prompturi, otrăvirea uneltelor, permisiunile excesive și vulnerabilitățile lanțului de aprovizionare.
- Descrii și să aplici controale eficiente de atenuare a riscurilor de securitate MCP, cum ar fi autentificarea robustă, principiul privilegiului minim, gestionarea sigură a token-urilor și verificarea lanțului de aprovizionare.
- Înțelegi și să valorifici soluțiile Microsoft precum Prompt Shields, Azure Content Safety și GitHub Advanced Security pentru a proteja sarcinile MCP și AI.
- Recunoști importanța validării metadatelor uneltelor, monitorizării modificărilor dinamice și apărării împotriva atacurilor de injectare indirectă a prompturilor.
- Integrezi bune practici de securitate consacrate — cum ar fi codarea sigură, întărirea serverelor și arhitectura zero trust — în implementarea MCP pentru a reduce probabilitatea și impactul incidentelor de securitate.

# MCP security controls

Orice sistem care are acces la resurse importante implică provocări de securitate. Aceste provocări pot fi abordate, în general, prin aplicarea corectă a controalelor și conceptelor fundamentale de securitate. Deoarece MCP este un protocol nou definit, specificația se schimbă rapid pe măsură ce protocolul evoluează. În timp, controalele de securitate integrate vor deveni mai mature, permițând o integrare mai bună cu arhitecturile și bunele practici de securitate enterprise deja stabilite.

Cercetări publicate în [Microsoft Digital Defense Report](https://aka.ms/mddr) arată că 98% din breșele raportate ar putea fi prevenite printr-o igienă riguroasă de securitate, iar cea mai bună protecție împotriva oricărui tip de breșă este să ai o igienă de securitate de bază bine pusă la punct, bune practici de codare sigură și securitatea lanțului de aprovizionare — aceste practici testate și dovedite continuă să aibă cel mai mare impact în reducerea riscului de securitate.

Să vedem câteva modalități prin care poți începe să abordezi riscurile de securitate atunci când adopți MCP.

> **Note:** Informațiile de mai jos sunt corecte la data de **29 mai 2025**. Protocolul MCP evoluează continuu, iar implementările viitoare pot introduce noi modele și controale de autentificare. Pentru cele mai recente actualizări și recomandări, consultă întotdeauna [MCP Specification](https://spec.modelcontextprotocol.io/) și depozitul oficial [MCP GitHub](https://github.com/modelcontextprotocol) și [pagina de bune practici de securitate](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problem statement  
Specificația originală MCP presupunea că dezvoltatorii vor scrie propriul server de autentificare. Acest lucru necesita cunoștințe despre OAuth și constrângeri de securitate aferente. Serverele MCP acționau ca OAuth 2.0 Authorization Servers, gestionând autentificarea utilizatorilor direct, în loc să o delege către un serviciu extern precum Microsoft Entra ID. Din data de **26 aprilie 2025**, o actualizare a specificației MCP permite serverelor MCP să delege autentificarea utilizatorilor către un serviciu extern.

### Risks
- Logica de autorizare configurată greșit pe serverul MCP poate duce la expunerea datelor sensibile și la aplicarea incorectă a controalelor de acces.
- Furtul token-ului OAuth de pe serverul local MCP. Dacă este furat, token-ul poate fi folosit pentru a se deghiza în serverul MCP și a accesa resursele și datele serviciului pentru care este emis token-ul OAuth.

#### Token Passthrough  
Passthrough-ul token-urilor este interzis explicit în specificația de autorizare deoarece introduce o serie de riscuri de securitate, care includ:

#### Ocolirea controlului de securitate  
Serverul MCP sau API-urile din aval ar putea implementa controale importante de securitate precum limitarea ratei, validarea cererilor sau monitorizarea traficului, care depind de audiența token-ului sau alte constrângeri ale acreditărilor. Dacă clienții pot obține și folosi token-uri direct cu API-urile din aval fără ca serverul MCP să le valideze corect sau să se asigure că token-urile sunt emise pentru serviciul potrivit, aceste controale sunt ocolite.

#### Probleme de responsabilitate și trasabilitate  
Serverul MCP nu va putea identifica sau diferenția între clienții MCP când aceștia apelează cu un token de acces emis în amonte, care poate fi opac pentru serverul MCP.  
Jurnalele serverului de resurse din aval pot arăta cereri care par să vină dintr-o sursă diferită, cu o identitate diferită, în loc de serverul MCP care de fapt transmite token-urile.  
Ambele aspecte îngreunează investigațiile, controalele și auditul incidentelor.  
Dacă serverul MCP transmite token-uri fără a valida revendicările lor (ex. roluri, privilegii sau audiență) sau alte metadate, un actor rău intenționat care deține un token furat poate folosi serverul ca proxy pentru exfiltrarea datelor.

#### Probleme legate de limita de încredere  
Serverul de resurse din aval acordă încredere unor entități specifice. Această încredere poate include presupuneri despre origine sau comportamentul clientului. Încălcarea acestei limite de încredere poate genera probleme neașteptate.  
Dacă token-ul este acceptat de mai multe servicii fără o validare corectă, un atacator care compromite un serviciu poate folosi token-ul pentru a accesa alte servicii conectate.

#### Riscul de compatibilitate viitoare  
Chiar dacă un server MCP începe astăzi ca un „proxy pur”, ar putea fi necesar să adauge ulterior controale de securitate. Începerea cu o separare corectă a audienței token-ului face mai ușoară evoluția modelului de securitate.

### Mitigating controls

**Serverele MCP NU TREBUIE să accepte token-uri care nu au fost emise explicit pentru serverul MCP**

- **Revizuiește și întărește logica de autorizare:** Auditează cu atenție implementarea autorizării pe serverul MCP pentru a te asigura că doar utilizatorii și clienții intenționați pot accesa resurse sensibile. Pentru ghidaj practic, vezi [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) și [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Aplică practici sigure pentru token-uri:** Urmează [cele mai bune practici Microsoft pentru validarea token-urilor și durata lor](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) pentru a preveni abuzul token-urilor de acces și a reduce riscul de redare sau furt.
- **Protejează stocarea token-urilor:** Stochează întotdeauna token-urile în siguranță și folosește criptarea pentru a le proteja atât în repaus, cât și în tranzit. Pentru sfaturi de implementare, vezi [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
Serverele MCP pot avea permisiuni excesive pentru serviciul/resursa la care accesează. De exemplu, un server MCP care face parte dintr-o aplicație AI de vânzări care se conectează la un depozit de date enterprise ar trebui să aibă acces limitat doar la datele de vânzări și nu să poată accesa toate fișierele din depozit. Revenind la principiul privilegiului minim (unul dintre cele mai vechi principii de securitate), nicio resursă nu ar trebui să aibă permisiuni mai mari decât cele necesare pentru a-și îndeplini sarcinile. AI aduce o provocare sporită aici, deoarece pentru a fi flexibilă, poate fi dificil să definești exact permisiunile necesare.

### Risks  
- Acordarea de permisiuni excesive poate permite exfiltrarea sau modificarea datelor la care serverul MCP nu ar trebui să aibă acces. Acest lucru poate fi și o problemă de confidențialitate dacă datele conțin informații personale identificabile (PII).

### Mitigating controls  
- **Aplică principiul privilegiului minim:** Acordă serverului MCP doar permisiunile minime necesare pentru a-și îndeplini sarcinile. Revizuiește și actualizează regulat aceste permisiuni pentru a te asigura că nu depășesc ce este necesar. Pentru ghidaj detaliat, vezi [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Folosește controlul accesului bazat pe roluri (RBAC):** Atribuie roluri serverului MCP care sunt strict limitate la resurse și acțiuni specifice, evitând permisiunile largi sau inutile.
- **Monitorizează și auditează permisiunile:** Monitorizează continuu utilizarea permisiunilor și auditează jurnalele de acces pentru a detecta și remedia prompt privilegiile excesive sau nefolosite.

# Indirect prompt injection attacks

### Problem statement

Serverele MCP compromise sau rău intenționate pot introduce riscuri semnificative prin expunerea datelor clienților sau permiterea unor acțiuni neintenționate. Aceste riscuri sunt deosebit de relevante în sarcinile AI și MCP, unde:

- **Atacuri de injectare a prompturilor:** Atacatorii încorporează instrucțiuni malițioase în prompturi sau conținut extern, determinând sistemul AI să execute acțiuni neintenționate sau să divulge date sensibile. Mai multe detalii: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Otrăvirea uneltelor:** Atacatorii manipulează metadatele uneltelor (cum ar fi descrierile sau parametrii) pentru a influența comportamentul AI, posibil ocolind controalele de securitate sau exfiltrând date. Detalii: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Injectare cross-domain de prompturi:** Instrucțiuni malițioase sunt ascunse în documente, pagini web sau emailuri, care apoi sunt procesate de AI, ducând la scurgeri de date sau manipulare.
- **Modificarea dinamică a uneltelor (Rug Pulls):** Definițiile uneltelor pot fi schimbate după aprobarea utilizatorului, introducând comportamente malițioase noi fără știrea acestuia.

Aceste vulnerabilități evidențiază necesitatea validării riguroase, monitorizării și controalelor de securitate atunci când integrezi servere MCP și unelte în mediul tău. Pentru o analiză mai detaliată, vezi referințele de mai sus.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.ro.png)

**Injectarea indirectă a prompturilor** (cunoscută și ca injectare cross-domain sau XPIA) este o vulnerabilitate critică în sistemele AI generative, inclusiv cele care folosesc Model Context Protocol (MCP). În acest atac, instrucțiuni malițioase sunt ascunse în conținut extern — cum ar fi documente, pagini web sau emailuri. Când sistemul AI procesează acest conținut, poate interpreta instrucțiunile încorporate ca fiind comenzi legitime ale utilizatorului, ceea ce duce la acțiuni neintenționate precum scurgerea de date, generarea de conținut dăunător sau manipularea interacțiunilor cu utilizatorul. Pentru o explicație detaliată și exemple din lumea reală, vezi [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

O formă deosebit de periculoasă a acestui atac este **Otrăvirea uneltelor**. Aici, atacatorii injectează instrucțiuni malițioase în metadatele uneltelor MCP (cum ar fi descrierile sau parametrii). Deoarece modelele mari de limbaj (LLM) se bazează pe aceste metadate pentru a decide ce unelte să invoce, descrierile compromise pot păcăli modelul să execute apeluri neautorizate ale uneltelor sau să ocolească controalele de securitate. Aceste manipulări sunt adesea invizibile pentru utilizatori, dar pot fi interpretate și puse în aplicare de sistemul AI. Acest risc este amplificat în mediile găzduite de servere MCP, unde definițiile uneltelor pot fi actualizate după aprobarea utilizatorului — un scenariu denumit uneori „[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)”. În astfel de cazuri, o unealtă care anterior era sigură poate fi modificată ulterior pentru a executa acțiuni malițioase, cum ar fi exfiltrarea de date sau modificarea comportamentului sistemului, fără știrea utilizatorului. Pentru mai multe informații despre acest vector de atac, vezi [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.ro.png)

## Risks  
Acțiunile neintenționate ale AI prezintă o varietate de riscuri de securitate, inclusiv exfiltrarea datelor și încălcări ale confidențialității.

### Mitigating controls  
### Utilizarea prompt shields pentru protecția împotriva atacurilor de injectare indirectă a prompturilor  
-----------------------------------------------------------------------------

**AI Prompt Shields** sunt o soluție dezvoltată de Microsoft pentru a apăra atât împotriva atacurilor directe, cât și a celor indirecte de injectare a prompturilor. Ele ajută prin:

1.  **Detectare și filtrare:** Prompt Shields folosesc algoritmi avansați de machine learning și procesare a limbajului natural pentru a detecta și filtra instrucțiunile malițioase ascunse în conținut extern, cum ar fi documente, pagini web sau emailuri.
    
2.  **Spotlighting:** Această tehnică ajută sistemul AI să distingă între instrucțiunile valide ale sistemului și inputurile externe potențial nesigure. Prin transformarea textului de intrare într-un mod care îl face mai relevant pentru model, Spotlighting asigură că AI poate identifica mai bine și ignora instrucțiunile malițioase.
    
3.  **Delimitatori și marcaje de date:** Incluzând delimitatori în mesajul sistemului se indică explicit locația textului de intrare, ajutând AI să recunoască și să separe inputurile utilizatorului de conținutul extern potențial periculos. Datamarking extinde acest concept folosind marcaje speciale pentru a evidenția granițele dintre datele de încredere și cele neîncrezătoare.
    
4.  **Monitorizare și actualizări continue:** Microsoft monitorizează și actualizează constant Prompt Shields pentru a răspunde amenințărilor noi și în evoluție. Această abordare proactivă asigură că apărarea rămâne eficientă împotriva celor mai recente tehnici de atac.
    
5. **Integrare cu Azure Content Safety:** Prompt Shields fac parte din suita mai largă Azure AI Content Safety, care oferă unelte suplimentare pentru detectarea tentativelor de jailbreak,
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

### Următorul

Următorul: [Capitolul 3: Începutul](/03-GettingStarted/README.md)

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere automată AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.