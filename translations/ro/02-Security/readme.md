<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:52:48+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "ro"
}
-->
# Cele mai bune practici de securitate

Adoptarea Model Context Protocol (MCP) aduce noi capabilități puternice aplicațiilor bazate pe inteligență artificială, dar introduce și provocări unice de securitate care depășesc riscurile software tradiționale. În plus față de preocupările stabilite, cum ar fi codarea securizată, principiul celui mai mic privilegiu și securitatea lanțului de aprovizionare, MCP și sarcinile de lucru AI se confruntă cu noi amenințări, cum ar fi injecția de prompt, otrăvirea uneltelor și modificarea dinamică a uneltelor. Aceste riscuri pot duce la exfiltrarea datelor, încălcări ale confidențialității și comportamente neintenționate ale sistemului dacă nu sunt gestionate corespunzător.

Această lecție explorează cele mai relevante riscuri de securitate asociate cu MCP — inclusiv autentificarea, autorizarea, permisiunile excesive, injecția indirectă de prompt și vulnerabilitățile lanțului de aprovizionare — și oferă controale acționabile și cele mai bune practici pentru a le atenua. De asemenea, veți învăța cum să valorificați soluțiile Microsoft, cum ar fi Prompt Shields, Azure Content Safety și GitHub Advanced Security pentru a întări implementarea MCP. Prin înțelegerea și aplicarea acestor controale, puteți reduce semnificativ probabilitatea unei încălcări de securitate și asigura că sistemele dvs. AI rămân robuste și de încredere.

# Obiective de învățare

Până la sfârșitul acestei lecții, veți putea:

- Identifica și explica riscurile unice de securitate introduse de Model Context Protocol (MCP), inclusiv injecția de prompt, otrăvirea uneltelor, permisiunile excesive și vulnerabilitățile lanțului de aprovizionare.
- Descrie și aplica controale eficiente de atenuare pentru riscurile de securitate MCP, cum ar fi autentificarea robustă, principiul celui mai mic privilegiu, gestionarea securizată a tokenurilor și verificarea lanțului de aprovizionare.
- Înțelege și valorifica soluțiile Microsoft, cum ar fi Prompt Shields, Azure Content Safety și GitHub Advanced Security pentru a proteja sarcinile de lucru MCP și AI.
- Recunoaște importanța validării metadatelor uneltelor, monitorizării schimbărilor dinamice și apărării împotriva atacurilor indirecte de injecție de prompt.
- Integra cele mai bune practici de securitate stabilite — cum ar fi codarea securizată, întărirea serverului și arhitectura zero trust — în implementarea MCP pentru a reduce probabilitatea și impactul încălcărilor de securitate.

# Controale de securitate MCP

Orice sistem care are acces la resurse importante implică provocări de securitate. Provocările de securitate pot fi în general abordate prin aplicarea corectă a controalelor și conceptelor fundamentale de securitate. Deoarece MCP este doar recent definit, specificația se schimbă foarte rapid pe măsură ce protocolul evoluează. În cele din urmă, controalele de securitate din cadrul acestuia vor maturiza, permițând o mai bună integrare cu arhitecturile de securitate și cele mai bune practici ale întreprinderii.

Cercetările publicate în [Raportul Microsoft Digital Defense](https://aka.ms/mddr) afirmă că 98% dintre încălcările raportate ar fi prevenite printr-o igienă robustă de securitate, iar cea mai bună protecție împotriva oricărui tip de încălcare este să obțineți igiena de bază a securității, cele mai bune practici de codare securizată și securitatea lanțului de aprovizionare — acele practici încercate și testate pe care le cunoaștem deja continuă să aibă cel mai mare impact în reducerea riscului de securitate.

Să analizăm câteva dintre modalitățile prin care puteți începe să abordați riscurile de securitate atunci când adoptați MCP.

# Autentificarea serverului MCP (dacă implementarea MCP a fost înainte de 26 aprilie 2025)

> **Note:** Informațiile următoare sunt corecte până la 26 aprilie 2025. Protocolul MCP evoluează continuu, iar implementările viitoare pot introduce noi modele și controale de autentificare. Pentru cele mai recente actualizări și îndrumări, consultați întotdeauna [Specificația MCP](https://spec.modelcontextprotocol.io/) și [depozitul oficial MCP GitHub](https://github.com/modelcontextprotocol).

### Declarația problemei
Specificația originală MCP a presupus că dezvoltatorii își vor scrie propriul server de autentificare. Acest lucru a necesitat cunoștințe de OAuth și constrângeri de securitate aferente. Serverele MCP au acționat ca Servere de Autorizare OAuth 2.0, gestionând direct autentificarea utilizatorului necesară în loc să o delege unui serviciu extern, cum ar fi Microsoft Entra ID. Începând cu 26 aprilie 2025, o actualizare a specificației MCP permite serverelor MCP să delege autentificarea utilizatorului unui serviciu extern.

### Riscuri
- Logica de autorizare configurată greșit în serverul MCP poate duce la expunerea datelor sensibile și aplicarea incorectă a controalelor de acces.
- Furtul de token OAuth pe serverul local MCP. Dacă este furat, tokenul poate fi folosit pentru a se da drept serverul MCP și a accesa resursele și datele de la serviciul pentru care este tokenul OAuth.

### Controale de atenuare
- **Revizuirea și întărirea logicii de autorizare:** Auditați cu atenție implementarea autorizării serverului MCP pentru a vă asigura că doar utilizatorii și clienții intenționați pot accesa resursele sensibile. Pentru îndrumări practice, vedeți [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) și [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Aplicarea practicilor de securizare a tokenurilor:** Urmați [cele mai bune practici Microsoft pentru validarea și durata de viață a tokenurilor](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) pentru a preveni utilizarea greșită a tokenurilor de acces și a reduce riscul de repetare sau furt al tokenului.
- **Protejarea stocării tokenurilor:** Stocați întotdeauna tokenurile în siguranță și folosiți criptarea pentru a le proteja atât în repaus, cât și în tranzit. Pentru sfaturi de implementare, vedeți [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permisiuni excesive pentru serverele MCP

### Declarația problemei
Serverele MCP pot fi acordate permisiuni excesive pentru serviciul/resursa la care accesează. De exemplu, un server MCP care face parte dintr-o aplicație de vânzări AI conectându-se la un depozit de date al întreprinderii ar trebui să aibă acces limitat la datele de vânzări și să nu aibă voie să acceseze toate fișierele din depozit. Referindu-se la principiul celui mai mic privilegiu (unul dintre cele mai vechi principii de securitate), nicio resursă nu ar trebui să aibă permisiuni care depășesc ceea ce este necesar pentru a executa sarcinile pentru care a fost destinată. AI prezintă o provocare crescută în acest domeniu deoarece, pentru a-i permite să fie flexibilă, poate fi dificil să definești permisiunile exacte necesare.

### Riscuri 
- Acordarea de permisiuni excesive poate permite exfiltrarea sau modificarea datelor pe care serverul MCP nu ar trebui să le poată accesa. Acest lucru ar putea fi, de asemenea, o problemă de confidențialitate dacă datele sunt informații personale identificabile (PII).

### Controale de atenuare
- **Aplicarea principiului celui mai mic privilegiu:** Acordați serverului MCP doar permisiunile minime necesare pentru a-și îndeplini sarcinile cerute. Revizuiți și actualizați regulat aceste permisiuni pentru a vă asigura că nu depășesc ceea ce este necesar. Pentru îndrumări detaliate, vedeți [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Utilizarea controlului accesului bazat pe roluri (RBAC):** Atribuiți roluri serverului MCP care sunt strict limitate la resurse și acțiuni specifice, evitând permisiuni largi sau inutile.
- **Monitorizarea și auditarea permisiunilor:** Monitorizați continuu utilizarea permisiunilor și auditați jurnalele de acces pentru a detecta și remedia permisiunile excesive sau neutilizate prompt.

# Atacuri indirecte de injecție de prompt

### Declarația problemei

Serverele MCP malițioase sau compromise pot introduce riscuri semnificative prin expunerea datelor clienților sau permiterea acțiunilor neintenționate. Aceste riscuri sunt deosebit de relevante în sarcinile de lucru bazate pe AI și MCP, unde:

- **Atacuri de injecție de prompt**: Atacatorii încorporează instrucțiuni malițioase în prompturi sau conținut extern, determinând sistemul AI să efectueze acțiuni neintenționate sau să scurgă date sensibile. Aflați mai multe: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Otrăvirea uneltelor**: Atacatorii manipulează metadatele uneltelor (cum ar fi descrierile sau parametrii) pentru a influența comportamentul AI, potențial ocolind controalele de securitate sau exfiltrând date. Detalii: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Injecție de prompt cross-domain**: Instrucțiuni malițioase sunt încorporate în documente, pagini web sau emailuri, care sunt apoi procesate de AI, ducând la scurgeri de date sau manipulare.
- **Modificarea dinamică a uneltelor (Rug Pulls)**: Definițiile uneltelor pot fi schimbate după aprobarea utilizatorului, introducând noi comportamente malițioase fără cunoașterea utilizatorului.

Aceste vulnerabilități subliniază necesitatea unei validări robuste, monitorizări și controale de securitate atunci când integrați serverele și uneltele MCP în mediul dvs. Pentru o explorare mai profundă, vedeți referințele legate de mai sus.

**Injecția indirectă de prompt** (cunoscută și sub numele de injecție de prompt cross-domain sau XPIA) este o vulnerabilitate critică în sistemele AI generative, inclusiv cele care folosesc Model Context Protocol (MCP). În acest atac, instrucțiuni malițioase sunt ascunse în conținut extern — cum ar fi documente, pagini web sau emailuri. Când sistemul AI procesează acest conținut, poate interpreta instrucțiunile încorporate ca fiind comenzi legitime ale utilizatorului, rezultând acțiuni neintenționate precum scurgerea de date, generarea de conținut dăunător sau manipularea interacțiunilor utilizatorului. Pentru o explicație detaliată și exemple din lumea reală, vedeți [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

O formă deosebit de periculoasă a acestui atac este **Otrăvirea uneltelor**. Aici, atacatorii injectează instrucțiuni malițioase în metadatele uneltelor MCP (cum ar fi descrierile uneltelor sau parametrii). Deoarece modelele de limbaj mare (LLM) se bazează pe aceste metadate pentru a decide ce unelte să invoce, descrierile compromise pot păcăli modelul să execute apeluri de unelte neautorizate sau să ocolească controalele de securitate. Aceste manipulări sunt adesea invizibile pentru utilizatorii finali, dar pot fi interpretate și acționate de sistemul AI. Acest risc este amplificat în mediile de server MCP găzduite, unde definițiile uneltelor pot fi actualizate după aprobarea utilizatorului — un scenariu denumit uneori "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". În astfel de cazuri, o unealtă care a fost anterior sigură poate fi ulterior modificată pentru a efectua acțiuni malițioase, cum ar fi exfiltrarea datelor sau modificarea comportamentului sistemului, fără cunoașterea utilizatorului. Pentru mai multe despre acest vector de atac, vedeți [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

## Riscuri
Acțiunile neintenționate ale AI prezintă o varietate de riscuri de securitate care includ exfiltrarea datelor și încălcări ale confidențialității.

### Controale de atenuare
### Utilizarea scuturilor de prompt pentru a proteja împotriva atacurilor indirecte de injecție de prompt

**Scuturile de prompt AI** sunt o soluție dezvoltată de Microsoft pentru a se apăra împotriva atacurilor de injecție de prompt atât directe, cât și indirecte. Ele ajută prin:

1.  **Detecție și filtrare**: Scuturile de prompt folosesc algoritmi avansați de învățare automată și procesare a limbajului natural pentru a detecta și filtra instrucțiunile malițioase încorporate în conținut extern, cum ar fi documente, pagini web sau emailuri.
    
2.  **Spotlighting**: Această tehnică ajută sistemul AI să distingă între instrucțiuni de sistem valide și intrări externe potențial nesigure. Prin transformarea textului de intrare într-un mod care îl face mai relevant pentru model, Spotlighting asigură că AI poate identifica și ignora mai bine instrucțiunile malițioase.
    
3.  **Delimitatori și marcaje de date**: Includerea de delimitatori în mesajul sistemului conturează explicit locația textului de intrare, ajutând sistemul AI să recunoască și să separe intrările utilizatorului de conținutul extern potențial dăunător. Marcajele de date extind acest concept prin utilizarea de marcaje speciale pentru a evidenția granițele datelor de încredere și neîncredere.
    
4.  **Monitorizare și actualizări continue**: Microsoft monitorizează și actualizează continuu Scuturile de prompt pentru a aborda amenințările noi și în evoluție. Această abordare proactivă asigură că apărările rămân eficiente împotriva celor mai recente tehnici de atac.
    
5. **Integrarea cu Azure Content Safety:** Scuturile de prompt fac parte din suita mai largă Azure AI Content Safety, care oferă unelte suplimentare pentru detectarea tentativelor de jailbreak, conținut dăunător și alte riscuri de securitate în aplicațiile AI.

Puteți citi mai multe despre scuturile de prompt AI în [documentația Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

### Securitatea lanțului de aprovizionare

Securitatea lanțului de aprovizionare rămâne fundamentală în era AI, dar domeniul a ceea ce constituie lanțul dvs. de aprovizionare s-a extins. În plus față de pachetele de cod tradiționale, trebuie acum să verificați și să monitorizați riguros toate componentele legate de AI, inclusiv modelele de bază, serviciile de embedding, furnizorii de context și API-urile terțe. Fiecare dintre acestea poate introduce vulnerabilități sau riscuri dacă nu sunt gestionate corespunzător.

**Practici cheie de securitate a lanțului de aprovizionare pentru AI și MCP:**
- **Verificați toate componentele înainte de integrare:** Aceasta include nu doar biblioteci open-source, ci și modele AI, surse de date și API-uri externe. Verificați întotdeauna proveniența, licențierea și vulnerabilitățile cunoscute.
- **Mențineți fluxuri de implementare securizate:** Folosiți fluxuri CI/CD automate cu scanare de securitate integrată pentru a detecta problemele devreme. Asigurați-vă că doar artefactele de încredere sunt implementate în producție.
- **Monitorizați și auditați continuu:** Implementați monitorizarea continuă a tuturor dependențelor, inclusiv modele și servicii de date, pentru a detecta vulnerabilități noi sau atacuri asupra lanțului de aprovizionare.
- **Aplicați principiul celui mai mic privilegiu și controale de acces:** Restricționa
- [OWASP Top 10 pentru LLM-uri](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Călătoria pentru a securiza lanțul de aprovizionare software la Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Acces securizat cu privilegii minime (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Cele mai bune practici pentru validarea și durata de viață a tokenurilor](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Utilizați stocarea securizată a tokenurilor și criptați tokenurile (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management ca poartă de autentificare pentru MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Utilizarea Microsoft Entra ID pentru autentificarea cu serverele MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Următorul 

Următorul: [Capitolul 3: Începutul](/03-GettingStarted/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa natală ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională umană. Nu suntem răspunzători pentru neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.