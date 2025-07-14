<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-13T17:02:27+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "ro"
}
-->
# Cele mai bune practici de securitate

Adoptarea Model Context Protocol (MCP) aduce capabilități noi și puternice aplicațiilor bazate pe AI, dar introduce și provocări unice de securitate care depășesc riscurile tradiționale ale software-ului. Pe lângă preocupările deja cunoscute, cum ar fi codarea sigură, principiul privilegiului minim și securitatea lanțului de aprovizionare, MCP și sarcinile de lucru AI se confruntă cu amenințări noi, precum injecția de prompturi, otrăvirea uneltelor și modificarea dinamică a uneltelor. Aceste riscuri pot conduce la exfiltrarea datelor, încălcări ale confidențialității și comportamente neintenționate ale sistemului dacă nu sunt gestionate corespunzător.

Această lecție explorează cele mai relevante riscuri de securitate asociate MCP—incluzând autentificarea, autorizarea, permisiunile excesive, injecția indirectă de prompturi și vulnerabilitățile lanțului de aprovizionare—și oferă controale practice și cele mai bune practici pentru a le atenua. Veți învăța, de asemenea, cum să folosiți soluții Microsoft precum Prompt Shields, Azure Content Safety și GitHub Advanced Security pentru a întări implementarea MCP. Prin înțelegerea și aplicarea acestor controale, puteți reduce semnificativ probabilitatea unui incident de securitate și asigurați că sistemele AI rămân robuste și de încredere.

# Obiective de învățare

La finalul acestei lecții, veți putea:

- Identifica și explica riscurile unice de securitate introduse de Model Context Protocol (MCP), inclusiv injecția de prompturi, otrăvirea uneltelor, permisiunile excesive și vulnerabilitățile lanțului de aprovizionare.
- Descrie și aplica controale eficiente pentru atenuarea riscurilor de securitate MCP, cum ar fi autentificarea robustă, principiul privilegiului minim, gestionarea sigură a token-urilor și verificarea lanțului de aprovizionare.
- Înțelege și utiliza soluții Microsoft precum Prompt Shields, Azure Content Safety și GitHub Advanced Security pentru a proteja MCP și sarcinile de lucru AI.
- Recunoaște importanța validării metadatelor uneltelor, monitorizării modificărilor dinamice și apărării împotriva atacurilor de injecție indirectă de prompturi.
- Integra cele mai bune practici de securitate deja stabilite—cum ar fi codarea sigură, întărirea serverelor și arhitectura zero trust—în implementarea MCP pentru a reduce probabilitatea și impactul breșelor de securitate.

# Controale de securitate MCP

Orice sistem care are acces la resurse importante implică provocări de securitate. Aceste provocări pot fi, în general, abordate prin aplicarea corectă a controalelor și conceptelor fundamentale de securitate. Deoarece MCP este un protocol nou definit, specificația se schimbă rapid pe măsură ce protocolul evoluează. În cele din urmă, controalele de securitate vor ajunge la maturitate, permițând o integrare mai bună cu arhitecturile și cele mai bune practici de securitate enterprise deja stabilite.

Cercetările publicate în [Microsoft Digital Defense Report](https://aka.ms/mddr) arată că 98% din breșele raportate ar putea fi prevenite printr-o igienă robustă de securitate, iar cea mai bună protecție împotriva oricărui tip de breșă este să ai o igienă de bază corectă, cele mai bune practici de codare sigură și securitatea lanțului de aprovizionare bine implementate — aceste practici testate și dovedite încă au cel mai mare impact în reducerea riscului de securitate.

Să analizăm câteva modalități prin care puteți începe să abordați riscurile de securitate atunci când adoptați MCP.

> **Note:** Informațiile de mai jos sunt corecte la data de **29 mai 2025**. Protocolul MCP este în continuă evoluție, iar implementările viitoare pot introduce noi modele și controale de autentificare. Pentru cele mai recente actualizări și recomandări, consultați întotdeauna [Specificația MCP](https://spec.modelcontextprotocol.io/) și depozitul oficial [MCP GitHub](https://github.com/modelcontextprotocol) și [pagina de bune practici de securitate](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Declarația problemei  
Specificația originală MCP presupunea că dezvoltatorii vor scrie propriul server de autentificare. Acest lucru necesita cunoștințe despre OAuth și constrângerile de securitate aferente. Serverele MCP acționau ca servere de autorizare OAuth 2.0, gestionând autentificarea utilizatorului direct, în loc să o delege către un serviciu extern, cum ar fi Microsoft Entra ID. Din data de **26 aprilie 2025**, o actualizare a specificației MCP permite serverelor MCP să delege autentificarea utilizatorului către un serviciu extern.

### Riscuri
- Logica de autorizare configurată greșit în serverul MCP poate duce la expunerea datelor sensibile și aplicarea incorectă a controalelor de acces.
- Furtul token-ului OAuth pe serverul local MCP. Dacă este furat, token-ul poate fi folosit pentru a se da drept serverul MCP și a accesa resurse și date ale serviciului pentru care token-ul OAuth este emis.

#### Token Passthrough  
Token passthrough este explicit interzis în specificația de autorizare deoarece introduce o serie de riscuri de securitate, care includ:

#### Ocolirea controalelor de securitate  
Serverul MCP sau API-urile downstream pot implementa controale importante de securitate, cum ar fi limitarea ratei, validarea cererilor sau monitorizarea traficului, care depind de audiența token-ului sau alte constrângeri ale acreditărilor. Dacă clienții pot obține și folosi token-uri direct cu API-urile downstream fără ca serverul MCP să le valideze corect sau să se asigure că token-urile sunt emise pentru serviciul corect, aceștia ocolesc aceste controale.

#### Probleme de responsabilitate și trasabilitate  
Serverul MCP nu va putea identifica sau distinge între clienții MCP atunci când aceștia apelează cu un token de acces emis upstream, care poate fi opac pentru serverul MCP.  
Jurnalele serverului de resurse downstream pot arăta cereri care par să vină dintr-o sursă diferită, cu o identitate diferită, în loc de serverul MCP care de fapt transmite token-urile.  
Ambele aspecte fac investigarea incidentelor, controlul și auditul mai dificile.  
Dacă serverul MCP transmite token-uri fără a valida revendicările acestora (de exemplu, roluri, privilegii sau audiență) sau alte metadate, un actor rău intenționat care deține un token furat poate folosi serverul ca proxy pentru exfiltrarea datelor.

#### Probleme legate de granița de încredere  
Serverul de resurse downstream acordă încredere unor entități specifice. Această încredere poate include presupuneri despre originea sau comportamentul clientului. Încălcarea acestei granițe de încredere poate duce la probleme neașteptate.  
Dacă token-ul este acceptat de mai multe servicii fără o validare corespunzătoare, un atacator care compromite un serviciu poate folosi token-ul pentru a accesa alte servicii conectate.

#### Riscul compatibilității viitoare  
Chiar dacă un server MCP începe astăzi ca un „proxy pur”, este posibil să fie nevoie să adauge controale de securitate ulterior. Începerea cu o separare corectă a audienței token-ului face mai ușoară evoluția modelului de securitate.

### Controale de atenuare

**Serverele MCP NU TREBUIE să accepte token-uri care nu au fost emise explicit pentru serverul MCP**

- **Revizuirea și întărirea logicii de autorizare:** Auditați cu atenție implementarea autorizării serverului MCP pentru a vă asigura că doar utilizatorii și clienții intenționați pot accesa resurse sensibile. Pentru ghidaj practic, consultați [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) și [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Aplicarea practicilor sigure pentru token-uri:** Urmați [cele mai bune practici Microsoft pentru validarea și durata token-urilor](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) pentru a preveni utilizarea abuzivă a token-urilor de acces și a reduce riscul de redare sau furt al token-urilor.
- **Protejarea stocării token-urilor:** Stocați întotdeauna token-urile în siguranță și folosiți criptarea pentru a le proteja atât în repaus, cât și în tranzit. Pentru sfaturi de implementare, consultați [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permisiuni excesive pentru serverele MCP

### Declarația problemei  
Serverele MCP pot primi permisiuni excesive asupra serviciului sau resursei la care accesează. De exemplu, un server MCP care face parte dintr-o aplicație AI de vânzări conectată la un depozit de date enterprise ar trebui să aibă acces limitat la datele de vânzări și să nu poată accesa toate fișierele din depozit. Revenind la principiul privilegiului minim (unul dintre cele mai vechi principii de securitate), nicio resursă nu ar trebui să aibă permisiuni mai mari decât cele necesare pentru a-și îndeplini sarcinile. AI aduce o provocare suplimentară în acest sens, deoarece pentru a fi flexibilă, poate fi dificil să definim exact permisiunile necesare.

### Riscuri  
- Acordarea de permisiuni excesive poate permite exfiltrarea sau modificarea datelor la care serverul MCP nu ar trebui să aibă acces. Acest lucru poate reprezenta și o problemă de confidențialitate dacă datele conțin informații personale identificabile (PII).

### Controale de atenuare  
- **Aplicarea principiului privilegiului minim:** Acordați serverului MCP doar permisiunile minime necesare pentru a-și îndeplini sarcinile. Revizuiți și actualizați regulat aceste permisiuni pentru a vă asigura că nu depășesc ceea ce este necesar. Pentru ghidaj detaliat, consultați [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Utilizarea controlului accesului bazat pe roluri (RBAC):** Atribuiți roluri serverului MCP care sunt strict limitate la resurse și acțiuni specifice, evitând permisiunile largi sau inutile.
- **Monitorizarea și auditarea permisiunilor:** Monitorizați continuu utilizarea permisiunilor și auditați jurnalele de acces pentru a detecta și remedia rapid privilegiile excesive sau neutilizate.

# Atacuri de injecție indirectă de prompturi

### Declarația problemei

Serverele MCP rău intenționate sau compromise pot introduce riscuri semnificative prin expunerea datelor clienților sau prin permiterea unor acțiuni neintenționate. Aceste riscuri sunt deosebit de relevante în sarcinile de lucru AI și MCP, unde:

- **Atacuri de injecție de prompturi:** Atacatorii încorporează instrucțiuni malițioase în prompturi sau conținut extern, determinând sistemul AI să execute acțiuni neintenționate sau să divulge date sensibile. Aflați mai multe: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Otrăvirea uneltelor:** Atacatorii manipulează metadatele uneltelor (cum ar fi descrierile sau parametrii) pentru a influența comportamentul AI, posibil ocolind controalele de securitate sau exfiltrând date. Detalii: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Injecție cross-domain de prompturi:** Instrucțiuni malițioase sunt încorporate în documente, pagini web sau emailuri, care sunt apoi procesate de AI, ducând la scurgeri sau manipulări de date.
- **Modificarea dinamică a uneltelor (Rug Pulls):** Definițiile uneltelor pot fi schimbate după aprobarea utilizatorului, introducând comportamente malițioase noi fără știrea acestuia.

Aceste vulnerabilități subliniază necesitatea unor controale robuste de validare, monitorizare și securitate atunci când integrați servere MCP și unelte în mediul dvs. Pentru o analiză mai detaliată, consultați referințele indicate mai sus.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.ro.png)

**Injecția indirectă de prompturi** (cunoscută și ca injecție cross-domain de prompturi sau XPIA) este o vulnerabilitate critică în sistemele AI generative, inclusiv cele care folosesc Model Context Protocol (MCP). În acest atac, instrucțiuni malițioase sunt ascunse în conținut extern—cum ar fi documente, pagini web sau emailuri. Când sistemul AI procesează acest conținut, poate interpreta instrucțiunile încorporate ca fiind comenzi legitime ale utilizatorului, rezultând acțiuni neintenționate precum scurgeri de date, generare de conținut dăunător sau manipularea interacțiunilor cu utilizatorul. Pentru o explicație detaliată și exemple din viața reală, consultați [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

O formă deosebit de periculoasă a acestui atac este **Otrăvirea uneltelor**. Aici, atacatorii injectează instrucțiuni malițioase în metadatele uneltelor MCP (cum ar fi descrierile sau parametrii uneltelor). Deoarece modelele mari de limbaj (LLM) se bazează pe aceste metadate pentru a decide ce unelte să invoce, descrierile compromise pot păcăli modelul să execute apeluri neautorizate ale uneltelor sau să ocolească controalele de securitate. Aceste manipulări sunt adesea invizibile pentru utilizatorii finali, dar pot fi interpretate și puse în aplicare de sistemul AI. Acest risc este amplificat în mediile găzduite de servere MCP, unde definițiile uneltelor pot fi actualizate după aprobarea utilizatorului—un scenariu uneori numit „[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)”. În astfel de cazuri, o unealtă care anterior era sigură poate fi modificată ulterior pentru a efectua acțiuni malițioase, cum ar fi exfiltrarea datelor sau modificarea comportamentului sistemului, fără știrea utilizatorului. Pentru mai multe informații despre acest vector de atac, consultați [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.ro.png)

## Riscuri  
Acțiunile neintenționate ale AI prezintă o varietate de riscuri de securitate, inclusiv exfiltrarea datelor și încălcări ale confidențialității.

### Controale de atenuare  
### Utilizarea prompt shields pentru protecția împotriva atacurilor de injecție indirectă de prompturi  
-----------------------------------------------------------------------------

**AI Prompt Shields** sunt o soluție dezvoltată de Microsoft pentru a apăra împotriva atacurilor de injecție de prompturi, atât directe, cât și indirecte. Ele ajută prin:

1.  **Detectare și filtrare:** Prompt Shields folosesc algoritmi avansați de învățare automată și procesare a limbajului natural pentru a detecta și filtra instrucțiunile malițioase încorporate în conținut extern, cum ar fi documente, pagini web sau emailuri.
    
2.  **Spotlighting:** Această tehnică ajută sistemul AI să distingă între instrucțiunile valide ale sistemului și inputurile externe potențial nesigure. Prin transformarea textului de intrare într-un mod care îl face mai relevant pentru model, Spotlighting asigură că AI poate identifica mai bine și ignora instrucțiunile malițioase.
    
3.  **Delimitatori și marcaje de date:** Includerea delimitatorilor în mesajul sistemului indică clar locația textului de intrare, ajutând sistemul AI să recunoască și să separe inputurile utilizatorului de conținutul extern potențial periculos. Marcajele de date extind acest concept prin utilizarea unor markeri speciali pentru a evidenția limitele datelor de încredere și neîncredere.
    
4.  **Monitorizare și actualizări continue:** Microsoft monitorizează și actualizează constant
Securitatea lanțului de aprovizionare rămâne fundamentală în era AI, însă domeniul care definește lanțul tău de aprovizionare s-a extins. Pe lângă pachetele tradiționale de cod, trebuie acum să verifici și să monitorizezi riguros toate componentele legate de AI, inclusiv modelele fundamentale, serviciile de embeddings, furnizorii de context și API-urile terțe. Fiecare dintre acestea poate introduce vulnerabilități sau riscuri dacă nu sunt gestionate corespunzător.

**Practici cheie pentru securitatea lanțului de aprovizionare în AI și MCP:**
- **Verifică toate componentele înainte de integrare:** Aceasta include nu doar bibliotecile open-source, ci și modelele AI, sursele de date și API-urile externe. Verifică întotdeauna proveniența, licențierea și vulnerabilitățile cunoscute.
- **Menține pipeline-uri de implementare securizate:** Folosește pipeline-uri automate CI/CD cu scanare de securitate integrată pentru a identifica problemele din timp. Asigură-te că doar artefactele de încredere sunt implementate în producție.
- **Monitorizează și auditează continuu:** Implementează monitorizare continuă pentru toate dependențele, inclusiv modelele și serviciile de date, pentru a detecta noi vulnerabilități sau atacuri asupra lanțului de aprovizionare.
- **Aplică principiul privilegiului minim și controale de acces:** Restricționează accesul la modele, date și servicii doar la ceea ce este necesar pentru funcționarea serverului MCP.
- **Răspunde rapid la amenințări:** Ai un proces pentru patch-uri sau înlocuirea componentelor compromise și pentru rotirea secretelor sau acreditărilor în cazul detectării unei breșe.

[GitHub Advanced Security](https://github.com/security/advanced-security) oferă funcționalități precum scanarea secretelor, scanarea dependențelor și analiza CodeQL. Aceste instrumente se integrează cu [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) și [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) pentru a ajuta echipele să identifice și să atenueze vulnerabilitățile atât în cod, cât și în componentele lanțului de aprovizionare AI.

Microsoft implementează, de asemenea, practici extinse de securitate a lanțului de aprovizionare intern pentru toate produsele. Află mai multe în [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Practici de securitate consacrate care vor îmbunătăți postura de securitate a implementării MCP

Orice implementare MCP moștenește postura de securitate existentă a mediului organizației pe care este construită, așa că, atunci când iei în considerare securitatea MCP ca parte a sistemelor tale AI, este recomandat să îți îmbunătățești postura generală de securitate existentă. Următoarele controale de securitate consacrate sunt deosebit de relevante:

-   Cele mai bune practici de codare securizată în aplicația ta AI – protecție împotriva [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 pentru LLM-uri](https://genai.owasp.org/download/43299/?tmstv=1731900559), utilizarea de seifuri securizate pentru secrete și token-uri, implementarea comunicațiilor securizate end-to-end între toate componentele aplicației etc.
-   Hardening-ul serverului – folosește MFA acolo unde este posibil, menține patch-urile actualizate, integrează serverul cu un furnizor de identitate terț pentru acces etc.
-   Menține dispozitivele, infrastructura și aplicațiile actualizate cu patch-uri
-   Monitorizarea securității – implementează logare și monitorizare pentru o aplicație AI (inclusiv clientul/serverele MCP) și trimite aceste loguri către un SIEM central pentru detectarea activităților anormale
-   Arhitectură zero trust – izolează componentele prin controale de rețea și identitate într-un mod logic pentru a minimiza mișcarea laterală în cazul compromiterii unei aplicații AI.

# Concluzii cheie

- Fundamentele securității rămân critice: codarea securizată, privilegiul minim, verificarea lanțului de aprovizionare și monitorizarea continuă sunt esențiale pentru sarcinile MCP și AI.
- MCP introduce riscuri noi — cum ar fi injecția de prompturi, otrăvirea uneltelor și permisiunile excesive — care necesită atât controale tradiționale, cât și specifice AI.
- Folosește practici robuste de autentificare, autorizare și gestionare a token-urilor, valorificând furnizori externi de identitate precum Microsoft Entra ID, acolo unde este posibil.
- Protejează-te împotriva injecției indirecte de prompturi și otrăvirii uneltelor prin validarea metadatelor uneltelor, monitorizarea modificărilor dinamice și utilizarea soluțiilor precum Microsoft Prompt Shields.
- Tratează toate componentele din lanțul tău de aprovizionare AI — inclusiv modelele, embeddings și furnizorii de context — cu aceeași rigurozitate ca dependențele de cod.
- Rămâi la curent cu specificațiile MCP în evoluție și contribuie la comunitate pentru a ajuta la conturarea unor standarde sigure.

# Resurse suplimentare

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection în MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Atacuri de otrăvire a uneltelor (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls în MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Documentația Prompt Shields (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 pentru LLM-uri](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Acces securizat cu privilegiu minim (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Cele mai bune practici pentru validarea token-urilor și durata lor](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Folosește stocare securizată a token-urilor și criptează token-urile (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management ca poartă de autentificare pentru MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Cele mai bune practici de securitate MCP](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Utilizarea Microsoft Entra ID pentru autentificarea cu serverele MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Următorul

Următorul: [Capitolul 3: Începutul](../03-GettingStarted/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.