<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:25:31+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "ro"
}
-->
# Security Best Practices

Adoptarea Model Context Protocol (MCP) aduce capabilități puternice pentru aplicațiile bazate pe AI, dar introduce și provocări unice de securitate care depășesc riscurile software tradiționale. Pe lângă preocupările deja cunoscute, precum codarea securizată, principiul privilegiului minim și securitatea lanțului de aprovizionare, MCP și sarcinile de lucru AI se confruntă cu amenințări noi, cum ar fi injectarea de prompturi, otrăvirea uneltelor și modificarea dinamică a uneltelor. Aceste riscuri pot duce la exfiltrarea datelor, încălcări ale confidențialității și comportamente neintenționate ale sistemului dacă nu sunt gestionate corespunzător.

Această lecție explorează cele mai relevante riscuri de securitate asociate cu MCP — inclusiv autentificarea, autorizarea, permisiunile excesive, injectarea indirectă de prompturi și vulnerabilitățile lanțului de aprovizionare — și oferă controale practice și bune practici pentru a le atenua. Vei învăța, de asemenea, cum să folosești soluții Microsoft precum Prompt Shields, Azure Content Safety și GitHub Advanced Security pentru a-ți consolida implementarea MCP. Înțelegând și aplicând aceste controale, poți reduce semnificativ probabilitatea unui incident de securitate și poți asigura că sistemele tale AI rămân robuste și de încredere.

# Learning Objectives

La finalul acestei lecții, vei putea să:

- Identifici și să explici riscurile unice de securitate introduse de Model Context Protocol (MCP), inclusiv injectarea de prompturi, otrăvirea uneltelor, permisiunile excesive și vulnerabilitățile lanțului de aprovizionare.
- Descrii și aplici controale eficiente pentru atenuarea riscurilor de securitate MCP, cum ar fi autentificarea robustă, principiul privilegiului minim, gestionarea securizată a tokenurilor și verificarea lanțului de aprovizionare.
- Înțelegi și utilizezi soluții Microsoft precum Prompt Shields, Azure Content Safety și GitHub Advanced Security pentru protejarea MCP și a sarcinilor de lucru AI.
- Recunoști importanța validării metadatelor uneltelor, monitorizării modificărilor dinamice și apărării împotriva atacurilor de injectare indirectă a prompturilor.
- Integrezi bune practici de securitate consacrate — cum ar fi codarea securizată, întărirea serverelor și arhitectura zero trust — în implementarea MCP pentru a reduce probabilitatea și impactul breșelor de securitate.

# MCP security controls

Orice sistem care are acces la resurse importante are provocări implicite de securitate. Aceste provocări pot fi, în general, abordate prin aplicarea corectă a controalelor și conceptelor fundamentale de securitate. Deoarece MCP este un protocol nou definit, specificația se schimbă foarte rapid pe măsură ce protocolul evoluează. În cele din urmă, controalele de securitate vor ajunge la maturitate, permițând o integrare mai bună cu arhitecturile și bunele practici de securitate deja stabilite în mediile enterprise.

Cercetările publicate în [Microsoft Digital Defense Report](https://aka.ms/mddr) arată că 98% dintre breșele raportate ar putea fi prevenite printr-o igienă riguroasă a securității, iar cea mai bună protecție împotriva oricărui tip de breșă este să ai o igienă de bază corectă, bune practici de codare securizată și securitate a lanțului de aprovizionare — practicile testate și validate pe care le cunoaștem deja au cel mai mare impact în reducerea riscului de securitate.

Să vedem câteva moduri prin care poți începe să abordezi riscurile de securitate atunci când adopți MCP.

# MCP server authentication (if your MCP implementation was before 26th April 2025)

> **Note:** Informațiile următoare sunt corecte la data de 26 aprilie 2025. Protocolul MCP evoluează continuu, iar implementările viitoare pot introduce noi modele și controale de autentificare. Pentru cele mai recente actualizări și recomandări, consultă întotdeauna [MCP Specification](https://spec.modelcontextprotocol.io/) și depozitul oficial [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Problem statement  
Specificația originală MCP presupunea că dezvoltatorii vor scrie propriul server de autentificare. Acest lucru necesita cunoștințe despre OAuth și constrângerile de securitate aferente. Serverele MCP acționau ca servere de autorizare OAuth 2.0, gestionând autentificarea utilizatorului direct, în loc să o delege către un serviciu extern, cum ar fi Microsoft Entra ID. Din 26 aprilie 2025, o actualizare a specificației MCP permite serverelor MCP să delege autentificarea utilizatorului către un serviciu extern.

### Risks
- Logica de autorizare configurată greșit pe serverul MCP poate duce la expunerea datelor sensibile și la aplicarea incorectă a controalelor de acces.
- Furtul tokenurilor OAuth de pe serverul local MCP. Dacă un token este furat, poate fi folosit pentru a se da drept serverul MCP și pentru a accesa resurse și date din serviciul pentru care tokenul OAuth este valid.

### Mitigating controls
- **Review and Harden Authorization Logic:** Auditează atent implementarea autorizării pe serverul MCP pentru a te asigura că doar utilizatorii și clienții intenționați au acces la resurse sensibile. Pentru ghidaj practic, vezi [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) și [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Enforce Secure Token Practices:** Urmează [cele mai bune practici Microsoft pentru validarea și durata tokenurilor](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) pentru a preveni utilizarea necorespunzătoare a tokenurilor de acces și a reduce riscul de redare sau furt al tokenurilor.
- **Protect Token Storage:** Stochează întotdeauna tokenurile în siguranță și folosește criptarea pentru a le proteja atât în repaus, cât și în tranzit. Pentru sfaturi de implementare, vezi [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
Serverele MCP pot primi permisiuni excesive asupra serviciului sau resursei la care accesează. De exemplu, un server MCP care face parte dintr-o aplicație AI pentru vânzări și care se conectează la un depozit de date enterprise ar trebui să aibă acces limitat doar la datele de vânzări și nu să poată accesa toate fișierele din depozit. Revenind la principiul privilegiului minim (unul dintre cele mai vechi principii de securitate), nicio resursă nu ar trebui să aibă permisiuni mai mari decât cele necesare pentru a executa sarcinile pentru care a fost creată. AI aduce o provocare suplimentară aici, deoarece pentru a fi flexibilă, este dificil să definești exact permisiunile necesare.

### Risks  
- Acordarea de permisiuni excesive poate permite exfiltrarea sau modificarea datelor la care serverul MCP nu ar trebui să aibă acces. Aceasta poate fi, de asemenea, o problemă de confidențialitate dacă datele conțin informații personale identificabile (PII).

### Mitigating controls
- **Apply the Principle of Least Privilege:** Acordă serverului MCP doar permisiunile minime necesare pentru a-și îndeplini sarcinile. Revizuiește și actualizează regulat aceste permisiuni pentru a te asigura că nu depășesc ce este necesar. Pentru ghidaj detaliat, vezi [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Use Role-Based Access Control (RBAC):** Atribuie roluri serverului MCP care sunt strict limitate la resursele și acțiunile specifice, evitând permisiunile largi sau inutile.
- **Monitor and Audit Permissions:** Monitorizează continuu utilizarea permisiunilor și auditează jurnalele de acces pentru a detecta și remedia rapid privilegiile excesive sau neutilizate.

# Indirect prompt injection attacks

### Problem statement

Serverele MCP compromise sau malițioase pot introduce riscuri semnificative prin expunerea datelor clienților sau prin declanșarea unor acțiuni neintenționate. Aceste riscuri sunt deosebit de relevante în sarcinile de lucru AI și MCP, unde:

- **Prompt Injection Attacks**: Atacatorii încorporează instrucțiuni malițioase în prompturi sau conținut extern, determinând sistemul AI să execute acțiuni neintenționate sau să dezvăluie date sensibile. Află mai multe: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Atacatorii manipulează metadatele uneltelor (cum ar fi descrierile sau parametrii) pentru a influența comportamentul AI, posibil ocolind controalele de securitate sau exfiltrând date. Detalii: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Instrucțiuni malițioase sunt ascunse în documente, pagini web sau emailuri, care sunt apoi procesate de AI, ducând la scurgeri de date sau manipulare.
- **Dynamic Tool Modification (Rug Pulls)**: Definițiile uneltelor pot fi modificate după aprobarea utilizatorului, introducând comportamente malițioase fără știrea acestuia.

Aceste vulnerabilități evidențiază necesitatea unor validări riguroase, monitorizare și controale de securitate când integrezi servere MCP și unelte în mediul tău. Pentru o aprofundare, vezi referințele de mai sus.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.ro.png)

**Indirect Prompt Injection** (cunoscută și ca cross-domain prompt injection sau XPIA) este o vulnerabilitate critică în sistemele AI generative, inclusiv cele care folosesc Model Context Protocol (MCP). În acest atac, instrucțiuni malițioase sunt ascunse în conținut extern — precum documente, pagini web sau emailuri. Când sistemul AI procesează acest conținut, poate interpreta instrucțiunile ascunse ca fiind comenzi legitime ale utilizatorului, rezultând în acțiuni neintenționate, cum ar fi scurgeri de date, generare de conținut dăunător sau manipularea interacțiunilor cu utilizatorul. Pentru o explicație detaliată și exemple din viața reală, vezi [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

O formă deosebit de periculoasă a acestui atac este **Tool Poisoning**. Aici, atacatorii injectează instrucțiuni malițioase în metadatele uneltelor MCP (cum ar fi descrierile sau parametrii uneltelor). Deoarece modelele mari de limbaj (LLM) se bazează pe aceste metadate pentru a decide ce unelte să invoce, descrierile compromise pot păcăli modelul să execute apeluri neautorizate ale uneltelor sau să ocolească controalele de securitate. Aceste manipulări sunt adesea invizibile pentru utilizatorii finali, dar pot fi interpretate și executate de sistemul AI. Riscul este mai mare în mediile MCP găzduite, unde definițiile uneltelor pot fi actualizate după aprobarea utilizatorului — un scenariu uneori numit "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". În astfel de cazuri, o unealtă care anterior era sigură poate fi modificată ulterior pentru a efectua acțiuni malițioase, cum ar fi exfiltrarea de date sau modificarea comportamentului sistemului, fără știrea utilizatorului. Pentru mai multe detalii despre acest vector de atac, vezi [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.ro.png)

## Risks  
Acțiunile neintenționate ale AI prezintă o varietate de riscuri de securitate, inclusiv exfiltrarea datelor și încălcări ale confidențialității.

### Mitigating controls  
### Using prompt shields to protect against Indirect Prompt Injection attacks  
-----------------------------------------------------------------------------

**AI Prompt Shields** sunt o soluție dezvoltată de Microsoft pentru a apăra împotriva atacurilor de injectare de prompturi directe și indirecte. Ele ajută prin:

1.  **Detecție și filtrare:** Prompt Shields folosesc algoritmi avansați de machine learning și procesare a limbajului natural pentru a detecta și filtra instrucțiunile malițioase ascunse în conținut extern, cum ar fi documente, pagini web sau emailuri.
    
2.  **Spotlighting:** Această tehnică ajută sistemul AI să distingă între instrucțiunile valide ale sistemului și inputurile externe potențial neîncrezătoare. Prin transformarea textului de intrare într-un mod care îl face mai relevant pentru model, Spotlighting asigură că AI poate identifica și ignora mai bine instrucțiunile malițioase.
    
3.  **Delimitatori și Datamarking:** Includerea delimitatorilor în mesajul sistemului evidențiază explicit locația textului de intrare, ajutând AI să recunoască și să separe inputurile utilizatorului de conținutul extern potențial periculos. Datamarking extinde acest concept prin utilizarea unor marcatori speciali pentru a evidenția limitele datelor de încredere și neîncredere.
    
4.  **Monitorizare continuă și actualizări:** Microsoft monitorizează și actualizează constant Prompt Shields pentru a face față amenințărilor noi și în evoluție. Această abordare proactivă asigură că apărarea rămâne eficientă împotriva celor mai recente tehnici de atac.
    
5. **Integrare cu Azure Content Safety:** Prompt Shields fac parte din suita mai largă Azure AI Content Safety, care oferă unelte suplimentare pentru detectarea tentativelor de jailbreak, conținutului dăunător și altor riscuri de securitate în aplicațiile AI.

Poți afla mai multe despre AI prompt shields în [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.ro.png)

### Supply chain security

Securitatea lanțului de aprovizionare rămâne fundamentală în era AI, însă sfera componentelor considerate parte a lanțului de aprovizionare s-a extins. Pe lângă pachetele tradiționale de cod, trebuie să verifici și să monitorizezi riguros toate componentele legate de AI, inclusiv modelele fundamentale, serviciile de embedding, furnizorii de context și API-urile terțe. Oricare dintre acestea poate introduce vulnerabilități sau riscuri dacă nu sunt gestionate corespunzător.

**Practici cheie pentru securitatea lanțului de aprovizionare în AI și MCP:**
- **Verifică toate componentele înainte de integrare:** Aceasta include nu doar bibliotecile open-source, ci și modelele AI, sursele de date și API-urile externe. Verifică întotdeauna proveniența, licențierea și vulnerabilitățile cunoscute.
- **Menține pipeline-uri de implementare securizate:** Folosește pipeline-uri CI/CD automate cu scanare de securitate integrată pentru a detecta problemele din timp. Asigură-te că doar artefactele de încredere sunt implementate în producție.
- **Monitorizare și audit continuu:** Implementează monitorizare continuă pentru toate dependențele, inclusiv modele și servicii de date, pentru a detecta vulnerabilități noi sau atacuri asupra lanțului de aprovizionare.
- **Aplică principiul privilegiului minim și controale de acces:** Restricționează accesul la modele, date și servicii doar la ceea ce este necesar pentru funcționarea serverului MCP.
- **Răspunde rapid la amenințări:** Ai un proces pentru aplicarea de patch-uri sau înlocuirea componentelor compromise și pentru rotirea secretelor sau acreditărilor dacă se detectează o breșă.

[GitHub Advanced Security](https://github.com/security/advanced-security) oferă funcționalități precum scanarea secretelor, scanarea dependențelor și analiza CodeQL. Aceste unelte se integrează cu [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) și [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) pentru a ajuta echipele să identifice și să atenueze vulnerabilitățile atât în cod, cât și în componentele lanțului de
- [OWASP Top 10 pentru LLM-uri](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Drumul către securizarea lanțului de aprovizionare software la Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Acces sigur cu privilegii minime (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Cele mai bune practici pentru validarea token-urilor și durata lor](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Folosește stocarea sigură a token-urilor și criptează token-urile (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management ca gateway de autentificare pentru MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Utilizarea Microsoft Entra ID pentru autentificarea cu serverele MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Următorul

Următorul: [Capitolul 3: Începutul](/03-GettingStarted/README.md)

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite care pot rezulta din utilizarea acestei traduceri.