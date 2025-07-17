<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T11:20:15+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "ro"
}
-->
# Cele mai bune practici de securitate

Adoptarea Model Context Protocol (MCP) aduce capabilități noi și puternice aplicațiilor bazate pe AI, dar introduce și provocări unice de securitate care depășesc riscurile tradiționale ale software-ului. Pe lângă preocupările deja cunoscute, cum ar fi codarea sigură, principiul privilegiului minim și securitatea lanțului de aprovizionare, MCP și sarcinile de lucru AI se confruntă cu noi amenințări precum injecția de prompturi, otrăvirea uneltelor, modificarea dinamică a uneltelor, deturnarea sesiunilor, atacurile de tip confused deputy și vulnerabilitățile de tip token passthrough. Aceste riscuri pot conduce la exfiltrarea datelor, încălcări ale confidențialității și comportamente neintenționate ale sistemului dacă nu sunt gestionate corespunzător.

Această lecție explorează cele mai relevante riscuri de securitate asociate cu MCP — inclusiv autentificarea, autorizarea, permisiunile excesive, injecția indirectă de prompturi, securitatea sesiunii, problemele de tip confused deputy, vulnerabilitățile token passthrough și vulnerabilitățile lanțului de aprovizionare — și oferă controale practice și cele mai bune practici pentru a le atenua. De asemenea, vei învăța cum să folosești soluții Microsoft precum Prompt Shields, Azure Content Safety și GitHub Advanced Security pentru a-ți întări implementarea MCP. Prin înțelegerea și aplicarea acestor controale, poți reduce semnificativ probabilitatea unui incident de securitate și poți asigura că sistemele tale AI rămân robuste și de încredere.

# Obiectivele de învățare

La finalul acestei lecții, vei putea:

- Identifica și explica riscurile unice de securitate introduse de Model Context Protocol (MCP), inclusiv injecția de prompturi, otrăvirea uneltelor, permisiunile excesive, deturnarea sesiunilor, problemele de tip confused deputy, vulnerabilitățile token passthrough și vulnerabilitățile lanțului de aprovizionare.
- Descrie și aplica controale eficiente de atenuare pentru riscurile de securitate MCP, cum ar fi autentificarea robustă, principiul privilegiului minim, gestionarea sigură a tokenurilor, controalele de securitate a sesiunii și verificarea lanțului de aprovizionare.
- Înțelege și utiliza soluții Microsoft precum Prompt Shields, Azure Content Safety și GitHub Advanced Security pentru a proteja sarcinile de lucru MCP și AI.
- Recunoaște importanța validării metadatelor uneltelor, monitorizării modificărilor dinamice, apărării împotriva atacurilor indirecte de injecție de prompturi și prevenirea deturnării sesiunilor.
- Integra cele mai bune practici de securitate deja stabilite — cum ar fi codarea sigură, întărirea serverelor și arhitectura zero trust — în implementarea MCP pentru a reduce probabilitatea și impactul breșelor de securitate.

# Controale de securitate MCP

Orice sistem care are acces la resurse importante implică provocări de securitate. Aceste provocări pot fi, în general, abordate prin aplicarea corectă a controalelor și conceptelor fundamentale de securitate. Deoarece MCP este un protocol nou definit, specificația se schimbă rapid pe măsură ce protocolul evoluează. În cele din urmă, controalele de securitate vor ajunge la maturitate, permițând o integrare mai bună cu arhitecturile și cele mai bune practici de securitate enterprise deja stabilite.

Cercetările publicate în [Microsoft Digital Defense Report](https://aka.ms/mddr) arată că 98% din breșele raportate ar putea fi prevenite printr-o igienă de securitate robustă, iar cea mai bună protecție împotriva oricărui tip de breșă este să ai o igienă de securitate de bază corectă, cele mai bune practici de codare sigură și securitatea lanțului de aprovizionare — acele practici testate și dovedite care încă au cel mai mare impact în reducerea riscului de securitate.

Să analizăm câteva modalități prin care poți începe să abordezi riscurile de securitate atunci când adopți MCP.

> **Note:** Informațiile de mai jos sunt corecte la data de **29 mai 2025**. Protocolul MCP este în continuă evoluție, iar implementările viitoare pot introduce noi modele și controale de autentificare. Pentru cele mai recente actualizări și recomandări, consultă întotdeauna [Specificația MCP](https://spec.modelcontextprotocol.io/) și depozitul oficial [MCP GitHub](https://github.com/modelcontextprotocol) și [pagina de bune practici de securitate](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Declarația problemei  
Specificația originală MCP presupunea că dezvoltatorii vor scrie propriul server de autentificare. Acest lucru necesita cunoștințe despre OAuth și constrângerile de securitate aferente. Serverele MCP acționau ca servere de autorizare OAuth 2.0, gestionând autentificarea utilizatorului direct, în loc să o delege către un serviciu extern, cum ar fi Microsoft Entra ID. Începând cu **26 aprilie 2025**, o actualizare a specificației MCP permite serverelor MCP să delege autentificarea utilizatorului către un serviciu extern.

### Riscuri
- Logica de autorizare configurată greșit în serverul MCP poate duce la expunerea datelor sensibile și aplicarea incorectă a controalelor de acces.
- Furtul tokenului OAuth pe serverul local MCP. Dacă este furat, tokenul poate fi folosit pentru a se da drept serverul MCP și a accesa resurse și date ale serviciului pentru care tokenul OAuth este emis.

#### Token Passthrough  
Token passthrough este explicit interzis în specificația de autorizare deoarece introduce o serie de riscuri de securitate, care includ:

#### Ocolirea controalelor de securitate  
Serverul MCP sau API-urile downstream pot implementa controale importante de securitate, cum ar fi limitarea ratei, validarea cererilor sau monitorizarea traficului, care depind de audiența tokenului sau alte constrângeri ale acreditărilor. Dacă clienții pot obține și folosi tokenuri direct cu API-urile downstream fără ca serverul MCP să le valideze corect sau să se asigure că tokenurile sunt emise pentru serviciul potrivit, aceștia ocolesc aceste controale.

#### Probleme de responsabilitate și trasabilitate  
Serverul MCP nu va putea identifica sau distinge între clienții MCP atunci când aceștia apelează cu un token de acces emis upstream, care poate fi opac pentru serverul MCP.  
Jurnalele serverului de resurse downstream pot arăta cereri care par să vină dintr-o sursă diferită, cu o identitate diferită, în loc de serverul MCP care de fapt transmite tokenurile.  
Ambele aspecte fac investigarea incidentelor, controalele și auditul mai dificile.  
Dacă serverul MCP transmite tokenuri fără a valida revendicările acestora (de exemplu, roluri, privilegii sau audiență) sau alte metadate, un actor rău intenționat care deține un token furat poate folosi serverul ca proxy pentru exfiltrarea datelor.

#### Probleme legate de granița de încredere  
Serverul de resurse downstream acordă încredere unor entități specifice. Această încredere poate include presupuneri despre originea sau comportamentul clientului. Încălcarea acestei granițe de încredere poate duce la probleme neașteptate.  
Dacă tokenul este acceptat de mai multe servicii fără o validare corespunzătoare, un atacator care compromite un serviciu poate folosi tokenul pentru a accesa alte servicii conectate.

#### Riscul compatibilității viitoare  
Chiar dacă un server MCP începe astăzi ca un „proxy pur”, este posibil să fie nevoie să adauge controale de securitate ulterior. Începerea cu o separare corectă a audienței tokenului face mai ușoară evoluția modelului de securitate.

### Controale de atenuare

**Serverele MCP NU TREBUIE să accepte tokenuri care nu au fost emise explicit pentru serverul MCP**

- **Revizuiește și întărește logica de autorizare:** Auditează cu atenție implementarea autorizării serverului MCP pentru a te asigura că doar utilizatorii și clienții intenționați pot accesa resurse sensibile. Pentru ghidaj practic, vezi [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) și [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Aplică practici sigure pentru tokenuri:** Urmează [cele mai bune practici Microsoft pentru validarea și durata de viață a tokenurilor](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) pentru a preveni utilizarea abuzivă a tokenurilor de acces și a reduce riscul de redare sau furt al tokenurilor.
- **Protejează stocarea tokenurilor:** Stochează întotdeauna tokenurile în siguranță și folosește criptarea pentru a le proteja atât în repaus, cât și în tranzit. Pentru sfaturi de implementare, vezi [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permisiuni excesive pentru serverele MCP

### Declarația problemei  
Serverele MCP pot primi permisiuni excesive asupra serviciului sau resursei la care accesează. De exemplu, un server MCP care face parte dintr-o aplicație AI de vânzări conectată la un depozit de date enterprise ar trebui să aibă acces limitat la datele de vânzări și să nu poată accesa toate fișierele din depozit. Revenind la principiul privilegiului minim (unul dintre cele mai vechi principii de securitate), nicio resursă nu ar trebui să aibă permisiuni mai mari decât cele necesare pentru a-și îndeplini sarcinile. AI aduce o provocare suplimentară în acest sens, deoarece pentru a fi flexibilă, poate fi dificil să definești exact permisiunile necesare.

### Riscuri  
- Acordarea de permisiuni excesive poate permite exfiltrarea sau modificarea datelor la care serverul MCP nu ar trebui să aibă acces. Acest lucru poate reprezenta și o problemă de confidențialitate dacă datele conțin informații personale identificabile (PII).

### Controale de atenuare  
- **Aplică principiul privilegiului minim:** Acordă serverului MCP doar permisiunile minime necesare pentru a-și îndeplini sarcinile. Revizuiește și actualizează regulat aceste permisiuni pentru a te asigura că nu depășesc ceea ce este necesar. Pentru ghidaj detaliat, vezi [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Folosește controlul accesului bazat pe roluri (RBAC):** Atribuie roluri serverului MCP care sunt strict limitate la resurse și acțiuni specifice, evitând permisiunile largi sau inutile.
- **Monitorizează și auditează permisiunile:** Monitorizează continuu utilizarea permisiunilor și auditează jurnalele de acces pentru a detecta și remedia rapid privilegiile excesive sau neutilizate.

# Atacuri indirecte de injecție de prompturi

### Declarația problemei

Serverele MCP malițioase sau compromise pot introduce riscuri semnificative prin expunerea datelor clienților sau prin permiterea unor acțiuni neintenționate. Aceste riscuri sunt deosebit de relevante în sarcinile de lucru AI și MCP, unde:

- **Atacuri de injecție de prompturi:** Atacatorii încorporează instrucțiuni malițioase în prompturi sau conținut extern, determinând sistemul AI să execute acțiuni neintenționate sau să divulge date sensibile. Află mai multe: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Otrăvirea uneltelor:** Atacatorii manipulează metadatele uneltelor (cum ar fi descrierile sau parametrii) pentru a influența comportamentul AI, posibil ocolind controalele de securitate sau exfiltrând date. Detalii: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Injecție de prompturi cross-domain:** Instrucțiuni malițioase sunt încorporate în documente, pagini web sau emailuri, care sunt apoi procesate de AI, ducând la scurgeri sau manipulări de date.
- **Modificarea dinamică a uneltelor (Rug Pulls):** Definițiile uneltelor pot fi schimbate după aprobarea utilizatorului, introducând comportamente malițioase noi fără știrea acestuia.

Aceste vulnerabilități subliniază necesitatea validării robuste, monitorizării și controalelor de securitate atunci când integrezi servere MCP și unelte în mediul tău. Pentru o analiză mai detaliată, vezi referințele de mai sus.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.ro.png)

**Injecția indirectă de prompturi** (cunoscută și ca injecție cross-domain sau XPIA) este o vulnerabilitate critică în sistemele AI generative, inclusiv cele care folosesc Model Context Protocol (MCP). În acest atac, instrucțiuni malițioase sunt ascunse în conținut extern — cum ar fi documente, pagini web sau emailuri. Când sistemul AI procesează acest conținut, poate interpreta instrucțiunile încorporate ca fiind comenzi legitime ale utilizatorului, rezultând acțiuni neintenționate precum scurgeri de date, generare de conținut dăunător sau manipularea interacțiunilor cu utilizatorul. Pentru o explicație detaliată și exemple din lumea reală, vezi [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

O formă deosebit de periculoasă a acestui atac este **Otrăvirea uneltelor**. Aici, atacatorii injectează instrucțiuni malițioase în metadatele uneltelor MCP (cum ar fi descrierile sau parametrii uneltelor). Deoarece modelele mari de limbaj (LLM) se bazează pe aceste metadate pentru a decide ce unelte să invoce, descrierile compromise pot păcăli modelul să execute apeluri neautorizate către unelte sau să ocolească controalele de securitate. Aceste manipulări sunt adesea invizibile pentru utilizatorii finali, dar pot fi interpretate și puse în aplicare de sistemul AI. Acest risc este amplificat în mediile găzduite de servere MCP, unde definițiile uneltelor pot fi actualizate după aprobarea utilizatorului — un scenariu uneori numit „[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)”. În astfel de cazuri, o unealtă care anterior era sigură poate fi modificată ulterior pentru a efectua acțiuni malițioase, cum ar fi exfiltrarea datelor sau modificarea comportamentului sistemului, fără știrea utilizatorului. Pentru mai multe detalii despre acest vector de atac, vezi [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.ro.png)

## Riscuri  
Acțiunile neintenționate ale AI prezintă o varietate de riscuri de securitate, inclusiv exfiltrarea datelor și încălcări ale confidențialității.

### Controale de atenuare  
### Folosirea prompt shields pentru protecția împotriva atacurilor de injecție indirectă de prompturi
-----------------------------------------------------------------------------

**AI Prompt Shields** sunt o soluție dezvoltată de Microsoft pentru a apăra împotriva atacurilor de injecție de prompturi, atât directe, cât și indirecte. Ele ajută prin:

1.  **Detectare și filtrare:** Prompt Shields folosesc algoritmi avansați de machine learning și procesare a limbajului natural pentru a detecta și filtra instrucțiunile malițioase încorporate în conținut extern, cum ar fi documente, pagini web sau emailuri.
    
2.  **Spotlighting:** Această tehnică ajută sistemul AI să distingă între instrucțiunile valide ale sistemului și inputurile externe potențial nesigure. Prin transformarea textului de intrare într-un mod care îl face mai relevant pentru model, Spotlighting asigură că AI poate identifica mai bine și ignora instrucțiunile malițioase.
    
3.  **Delimitatori și marcaje de date:** Includerea delimitatorilor în mesajul sistemului indică clar locația textului de intrare, ajutând sistemul AI să rec
Problema „confused deputy” este o vulnerabilitate de securitate care apare atunci când un server MCP acționează ca un proxy între clienții MCP și API-urile terțe. Această vulnerabilitate poate fi exploatată atunci când serverul MCP folosește un ID static de client pentru autentificarea cu un server de autorizare terț care nu suportă înregistrarea dinamică a clienților.

### Riscuri

- **Ocolirea consimțământului bazat pe cookie-uri**: Dacă un utilizator s-a autentificat anterior prin serverul proxy MCP, un server de autorizare terț poate seta un cookie de consimțământ în browserul utilizatorului. Un atacator poate exploata acest lucru trimițând utilizatorului un link malițios cu o cerere de autorizare creată special, care conține un URI de redirecționare malițios.
- **Furtul codului de autorizare**: Când utilizatorul face clic pe linkul malițios, serverul de autorizare terț poate sări peste ecranul de consimțământ din cauza cookie-ului existent, iar codul de autorizare ar putea fi redirecționat către serverul atacatorului.
- **Acces neautorizat la API**: Atacatorul poate schimba codul de autorizare furat pentru token-uri de acces și se poate da drept utilizator pentru a accesa API-ul terț fără aprobare explicită.

### Măsuri de atenuare

- **Cereri explicite de consimțământ**: Serverele proxy MCP care folosesc ID-uri statice de client **TREBUIE** să obțină consimțământul utilizatorului pentru fiecare client înregistrat dinamic înainte de a redirecționa către serverele de autorizare terțe.
- **Implementare corectă OAuth**: Urmați cele mai bune practici de securitate OAuth 2.1, inclusiv utilizarea provocărilor de cod (PKCE) pentru cererile de autorizare, pentru a preveni atacurile de interceptare.
- **Validarea clientului**: Implementați o validare strictă a URI-urilor de redirecționare și a identificatorilor de client pentru a preveni exploatarea de către actori malițioși.


# Vulnerabilități de tip Token Passthrough

### Descrierea problemei

„Token passthrough” este un anti-pattern în care un server MCP acceptă token-uri de la un client MCP fără a valida dacă token-urile au fost emise corect pentru serverul MCP și apoi le „transmite” mai departe către API-urile downstream. Această practică încalcă explicit specificația de autorizare MCP și introduce riscuri serioase de securitate.

### Riscuri

- **Ocolirea controalelor de securitate**: Clienții ar putea ocoli controale importante de securitate, cum ar fi limitarea ratei, validarea cererilor sau monitorizarea traficului, dacă pot folosi token-uri direct cu API-urile downstream fără validare corespunzătoare.
- **Probleme de responsabilitate și audit**: Serverul MCP nu va putea identifica sau diferenția clienții MCP atunci când aceștia folosesc token-uri de acces emise upstream, ceea ce face investigarea incidentelor și auditul mai dificil.
- **Exfiltrarea datelor**: Dacă token-urile sunt transmise fără o validare corectă a revendicărilor, un actor malițios cu un token furat ar putea folosi serverul ca proxy pentru exfiltrarea datelor.
- **Încălcarea limitelor de încredere**: Serverele de resurse downstream pot acorda încredere unor entități specifice pe baza unor presupuneri legate de origine sau comportament. Încălcarea acestei limite de încredere poate duce la probleme neașteptate de securitate.
- **Utilizarea abuzivă a token-urilor multi-serviciu**: Dacă token-urile sunt acceptate de mai multe servicii fără validare corespunzătoare, un atacator care compromite un serviciu ar putea folosi token-ul pentru a accesa alte servicii conectate.

### Măsuri de atenuare

- **Validarea token-urilor**: Serverele MCP **NU TREBUIE** să accepte token-uri care nu au fost emise explicit pentru serverul MCP.
- **Verificarea audienței**: Verificați întotdeauna că token-urile au revendicarea audienței corecte, care să corespundă identității serverului MCP.
- **Gestionarea corectă a ciclului de viață al token-urilor**: Implementați token-uri de acces cu durată scurtă de viață și practici adecvate de rotație a token-urilor pentru a reduce riscul furtului și utilizării abuzive.


# Preluarea sesiunii (Session Hijacking)

### Descrierea problemei

Preluarea sesiunii este un vector de atac în care un client primește un ID de sesiune de la server, iar o parte neautorizată obține și folosește același ID de sesiune pentru a se da drept clientul original și a efectua acțiuni neautorizate în numele acestuia. Acest lucru este deosebit de problematic în serverele HTTP stateful care gestionează cereri MCP.

### Riscuri

- **Injectarea de prompturi prin preluarea sesiunii**: Un atacator care obține un ID de sesiune ar putea trimite evenimente malițioase către un server care partajează starea sesiunii cu serverul la care este conectat clientul, declanșând acțiuni dăunătoare sau accesând date sensibile.
- **Impersonarea prin preluarea sesiunii**: Un atacator cu un ID de sesiune furat ar putea face apeluri direct către serverul MCP, ocolind autentificarea și fiind tratat ca utilizatorul legitim.
- **Fluxuri reluabile compromise**: Când un server suportă redeliveri sau fluxuri reluabile, un atacator ar putea întrerupe prematur o cerere, ceea ce ar duce la reluarea acesteia ulterior de către clientul original cu conținut potențial malițios.

### Măsuri de atenuare

- **Verificarea autorizării**: Serverele MCP care implementează autorizare **TREBUIE** să verifice toate cererile primite și **NU TREBUIE** să folosească sesiuni pentru autentificare.
- **ID-uri de sesiune securizate**: Serverele MCP **TREBUIE** să folosească ID-uri de sesiune securizate, nedeterministe, generate cu generatoare de numere aleatoare sigure. Evitați identificatorii predictibili sau secvențiali.
- **Legarea sesiunii de utilizator**: Serverele MCP **AR TREBUIE** să lege ID-urile de sesiune de informații specifice utilizatorului, combinând ID-ul sesiunii cu informații unice ale utilizatorului autorizat (cum ar fi ID-ul intern al utilizatorului) folosind un format de tipul `<user_id>:<session_id>`.
- **Expirarea sesiunii**: Implementați expirarea și rotația corectă a sesiunilor pentru a limita fereastra de vulnerabilitate în cazul compromiterii unui ID de sesiune.
- **Securitatea transportului**: Folosiți întotdeauna HTTPS pentru toate comunicațiile pentru a preveni interceptarea ID-urilor de sesiune.


# Securitatea lanțului de aprovizionare

Securitatea lanțului de aprovizionare rămâne fundamentală în era AI, însă sfera a ceea ce constituie lanțul tău de aprovizionare s-a extins. Pe lângă pachetele tradiționale de cod, trebuie acum să verifici și să monitorizezi riguros toate componentele legate de AI, inclusiv modelele fundamentale, serviciile de embeddings, furnizorii de context și API-urile terțe. Fiecare dintre acestea poate introduce vulnerabilități sau riscuri dacă nu sunt gestionate corespunzător.

**Practici cheie de securitate a lanțului de aprovizionare pentru AI și MCP:**
- **Verifică toate componentele înainte de integrare:** Aceasta include nu doar biblioteci open-source, ci și modele AI, surse de date și API-uri externe. Verifică întotdeauna proveniența, licențierea și vulnerabilitățile cunoscute.
- **Menține pipeline-uri de implementare securizate:** Folosește pipeline-uri automate CI/CD cu scanare integrată de securitate pentru a detecta problemele din timp. Asigură-te că doar artefactele de încredere sunt implementate în producție.
- **Monitorizează și auditează continuu:** Implementează monitorizare continuă pentru toate dependențele, inclusiv modele și servicii de date, pentru a detecta noi vulnerabilități sau atacuri asupra lanțului de aprovizionare.
- **Aplică principiul privilegiului minim și controale de acces:** Restricționează accesul la modele, date și servicii doar la ceea ce este necesar pentru funcționarea serverului MCP.
- **Răspunde rapid la amenințări:** Ai un proces pentru patch-uri sau înlocuirea componentelor compromise și pentru rotația secretelor sau acreditărilor în cazul detectării unei breșe.

[GitHub Advanced Security](https://github.com/security/advanced-security) oferă funcționalități precum scanarea secretelor, scanarea dependențelor și analiza CodeQL. Aceste instrumente se integrează cu [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) și [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) pentru a ajuta echipele să identifice și să atenueze vulnerabilitățile atât în cod, cât și în componentele lanțului de aprovizionare AI.

Microsoft implementează, de asemenea, practici extinse de securitate a lanțului de aprovizionare intern pentru toate produsele. Află mai multe în [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Cele mai bune practici de securitate consacrate care vor îmbunătăți postura de securitate a implementării MCP

Orice implementare MCP moștenește postura de securitate existentă a mediului organizației pe care este construită, așa că, atunci când iei în considerare securitatea MCP ca parte a sistemelor tale AI, este recomandat să îți îmbunătățești postura generală de securitate existentă. Următoarele controale de securitate consacrate sunt deosebit de relevante:

-   Cele mai bune practici de programare sigură în aplicația ta AI - protecție împotriva [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 pentru LLM-uri](https://genai.owasp.org/download/43299/?tmstv=1731900559), utilizarea de seifuri securizate pentru secrete și token-uri, implementarea comunicațiilor securizate end-to-end între toate componentele aplicației etc.
-   Hardening-ul serverului – folosește MFA acolo unde este posibil, menține patch-urile actualizate, integrează serverul cu un furnizor de identitate terț pentru acces etc.
-   Menține dispozitivele, infrastructura și aplicațiile actualizate cu patch-uri
-   Monitorizarea securității – implementează logare și monitorizare pentru o aplicație AI (inclusiv client/servere MCP) și trimite aceste loguri către un SIEM central pentru detectarea activităților anormale
-   Arhitectură zero trust – izolează componentele prin controale de rețea și identitate într-un mod logic pentru a minimiza mișcarea laterală în cazul compromiterii unei aplicații AI.

# Concluzii cheie

- Fundamentele securității rămân critice: programarea sigură, privilegiul minim, verificarea lanțului de aprovizionare și monitorizarea continuă sunt esențiale pentru MCP și sarcinile AI.
- MCP introduce riscuri noi — cum ar fi injectarea de prompturi, otrăvirea uneltelor, preluarea sesiunii, problema „confused deputy”, vulnerabilitățile token passthrough și permisiunile excesive — care necesită atât controale tradiționale, cât și specifice AI.
- Folosește practici robuste de autentificare, autorizare și gestionare a token-urilor, valorificând furnizori externi de identitate precum Microsoft Entra ID, acolo unde este posibil.
- Protejează-te împotriva injectării indirecte de prompturi și otrăvirii uneltelor prin validarea metadatelor uneltelor, monitorizarea schimbărilor dinamice și utilizarea soluțiilor precum Microsoft Prompt Shields.
- Implementează o gestionare securizată a sesiunilor folosind ID-uri de sesiune nedeterministe, legând sesiunile de identitățile utilizatorilor și evitând utilizarea sesiunilor pentru autentificare.
- Previne atacurile „confused deputy” solicitând consimțământ explicit al utilizatorului pentru fiecare client înregistrat dinamic și implementând practici corecte de securitate OAuth.
- Evită vulnerabilitățile token passthrough asigurându-te că serverele MCP acceptă doar token-uri emise explicit pentru ele și validează corespunzător revendicările token-urilor.
- Tratează toate componentele din lanțul tău de aprovizionare AI — inclusiv modele, embeddings și furnizori de context — cu aceeași rigurozitate ca dependențele de cod.
- Fii la curent cu specificațiile MCP în evoluție și contribuie la comunitate pentru a ajuta la conturarea unor standarde securizate.

# Resurse suplimentare

## Resurse externe
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
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
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Documente suplimentare de securitate

Pentru ghiduri de securitate mai detaliate, consultă aceste documente:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) - Listă cuprinzătoare de cele mai bune practici de securitate pentru implementările MCP
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) - Exemple de implementare pentru integrarea Azure Content Safety cu serverele MCP
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) - Cele mai recente controale și tehnici de securitate pentru protejarea implementărilor MCP
- [MCP Best Practices](./mcp-best-practices.md) - Ghid rapid de referință pentru securitatea MCP

### Următorul

Următorul: [Capitolul 3: Începutul](../03-GettingStarted/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.