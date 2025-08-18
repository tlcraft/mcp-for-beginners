<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1c767a35642f753127dc08545c25a290",
  "translation_date": "2025-08-18T20:44:52+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "ro"
}
-->
# MCP Securitate: Protecție Cuprinzătoare pentru Sisteme AI

[![Cele mai bune practici de securitate MCP](../../../translated_images/03.175aed6dedae133f9d41e49cefd0f0a9a39c3317e1eaa7ef7182696af7534308.ro.png)](https://youtu.be/88No8pw706o)

_(Faceți clic pe imaginea de mai sus pentru a viziona videoclipul acestei lecții)_

Securitatea este fundamentală în proiectarea sistemelor AI, motiv pentru care o prioritizăm ca a doua secțiune. Acest lucru este aliniat cu principiul Microsoft **Secure by Design** din [Secure Future Initiative](https://www.microsoft.com/security/blog/2025/04/17/microsofts-secure-by-design-journey-one-year-of-success/).

Model Context Protocol (MCP) aduce capabilități noi și puternice aplicațiilor bazate pe AI, dar introduce și provocări unice de securitate care depășesc riscurile software tradiționale. Sistemele MCP se confruntă atât cu preocupări de securitate consacrate (codare sigură, privilegii minime, securitatea lanțului de aprovizionare), cât și cu amenințări noi specifice AI, inclusiv injecția de prompturi, otrăvirea uneltelor, deturnarea sesiunilor, atacuri de tip "confused deputy", vulnerabilități de trecere a token-urilor și modificarea dinamică a capabilităților.

Această lecție explorează cele mai critice riscuri de securitate în implementările MCP—acoperind autentificarea, autorizarea, permisiunile excesive, injecția indirectă de prompturi, securitatea sesiunilor, problemele de tip "confused deputy", gestionarea token-urilor și vulnerabilitățile lanțului de aprovizionare. Veți învăța controale practice și cele mai bune practici pentru a atenua aceste riscuri, utilizând soluții Microsoft precum Prompt Shields, Azure Content Safety și GitHub Advanced Security pentru a consolida implementarea MCP.

## Obiective de Învățare

Până la sfârșitul acestei lecții, veți putea:

- **Identifica Amenințările Specifice MCP**: Recunoaște riscurile unice de securitate în sistemele MCP, inclusiv injecția de prompturi, otrăvirea uneltelor, permisiunile excesive, deturnarea sesiunilor, problemele de tip "confused deputy", vulnerabilitățile de trecere a token-urilor și riscurile lanțului de aprovizionare
- **Aplica Controale de Securitate**: Implementa măsuri eficiente, inclusiv autentificare robustă, acces cu privilegii minime, gestionarea sigură a token-urilor, controale de securitate a sesiunilor și verificarea lanțului de aprovizionare
- **Utiliza Soluții de Securitate Microsoft**: Înțelege și implementa Microsoft Prompt Shields, Azure Content Safety și GitHub Advanced Security pentru protecția sarcinilor MCP
- **Valida Securitatea Uneltelor**: Recunoaște importanța validării metadatelor uneltelor, monitorizării schimbărilor dinamice și apărării împotriva atacurilor de injecție indirectă de prompturi
- **Integra Cele Mai Bune Practici**: Combina fundamentele de securitate consacrate (codare sigură, întărirea serverelor, zero trust) cu controale specifice MCP pentru o protecție cuprinzătoare

# Arhitectura și Controalele de Securitate MCP

Implementările moderne MCP necesită abordări stratificate de securitate care să abordeze atât amenințările tradiționale de securitate software, cât și cele specifice AI. Specificația MCP, în continuă evoluție, își maturizează controalele de securitate, permițând o mai bună integrare cu arhitecturile de securitate ale întreprinderilor și cele mai bune practici consacrate.

Cercetările din [Microsoft Digital Defense Report](https://aka.ms/mddr) demonstrează că **98% dintre breșele raportate ar fi prevenite printr-o igienă robustă de securitate**. Cea mai eficientă strategie de protecție combină practicile fundamentale de securitate cu controale specifice MCP—măsurile de securitate de bază dovedite rămân cele mai impactante în reducerea riscului general de securitate.

## Peisajul Actual al Securității

> **Note:** Aceste informații reflectă standardele de securitate MCP din **18 august 2025**. Protocolul MCP continuă să evolueze rapid, iar implementările viitoare pot introduce noi modele de autentificare și controale îmbunătățite. Consultați întotdeauna [Specificația MCP](https://spec.modelcontextprotocol.io/), [repositorul GitHub MCP](https://github.com/modelcontextprotocol) și [documentația celor mai bune practici de securitate](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) pentru cele mai recente îndrumări.

### Evoluția Autentificării MCP

Specificația MCP a evoluat semnificativ în abordarea autentificării și autorizării:

- **Abordarea Inițială**: Specificațiile timpurii cereau dezvoltatorilor să implementeze servere de autentificare personalizate, serverele MCP acționând ca servere de autorizare OAuth 2.0 care gestionau direct autentificarea utilizatorilor
- **Standardul Curent (2025-06-18)**: Specificația actualizată permite serverelor MCP să delege autentificarea către furnizori externi de identitate (cum ar fi Microsoft Entra ID), îmbunătățind postura de securitate și reducând complexitatea implementării
- **Securitatea Transportului**: Suport îmbunătățit pentru mecanisme de transport securizat cu modele adecvate de autentificare pentru conexiuni locale (STDIO) și la distanță (Streamable HTTP)

## Securitatea Autentificării și Autorizării

### Provocări Actuale de Securitate

Implementările moderne MCP se confruntă cu mai multe provocări legate de autentificare și autorizare:

### Riscuri și Vectori de Amenințare

- **Logică de Autorizare Configurată Greșit**: Implementarea defectuoasă a autorizării în serverele MCP poate expune date sensibile și aplica controale de acces incorecte
- **Compromiterea Token-urilor OAuth**: Furtul de token-uri de pe serverele MCP locale permite atacatorilor să se dea drept servere și să acceseze servicii în aval
- **Vulnerabilități de Trecere a Token-urilor**: Gestionarea necorespunzătoare a token-urilor creează breșe în controalele de securitate și lacune în responsabilitate
- **Permisiuni Excesive**: Serverele MCP cu privilegii excesive încalcă principiile de minimizare a privilegiilor și extind suprafețele de atac

#### Trecerea Token-urilor: Un Anti-Model Critic

**Trecerea token-urilor este explicit interzisă** în specificația actuală de autorizare MCP din cauza implicațiilor severe de securitate:

##### Ocolirea Controalelor de Securitate
- Serverele MCP și API-urile în aval implementează controale critice de securitate (limitarea ratei, validarea cererilor, monitorizarea traficului) care depind de validarea corectă a token-urilor
- Utilizarea directă a token-urilor client-API ocolește aceste protecții esențiale, subminând arhitectura de securitate

##### Provocări de Responsabilitate și Audit  
- Serverele MCP nu pot distinge între clienții care utilizează token-uri emise în amonte, rupând traseele de audit
- Jurnalele serverelor de resurse în aval arată origini de cereri înșelătoare în loc de intermediarii reali ai serverului MCP
- Investigațiile incidentelor și auditările de conformitate devin semnificativ mai dificile

##### Riscuri de Exfiltrare a Datelor
- Afirmările nevalidate ale token-urilor permit actorilor rău intenționați cu token-uri furate să utilizeze serverele MCP ca proxy-uri pentru exfiltrarea datelor
- Încălcările granițelor de încredere permit modele de acces neautorizate care ocolesc controalele de securitate intenționate

##### Vectori de Atac Multi-Serviciu
- Token-urile compromise acceptate de mai multe servicii permit mișcări laterale între sistemele conectate
- Presupunerile de încredere între servicii pot fi încălcate atunci când originile token-urilor nu pot fi verificate

### Controale și Măsuri de Atenuare a Securității

**Cerințe Critice de Securitate:**

> **MANDATORY**: Serverele MCP **NU TREBUIE** să accepte token-uri care nu au fost emise explicit pentru serverul MCP

#### Controale de Autentificare și Autorizare

- **Revizuire Riguroasă a Autorizării**: Efectuați audituri cuprinzătoare ale logicii de autorizare a serverelor MCP pentru a vă asigura că doar utilizatorii și clienții intenționați pot accesa resurse sensibile
  - **Ghid de Implementare**: [Azure API Management ca Gateway de Autentificare pentru Serverele MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
  - **Integrare Identitate**: [Utilizarea Microsoft Entra ID pentru Autentificarea Serverelor MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

- **Gestionarea Securizată a Token-urilor**: Implementați [cele mai bune practici Microsoft pentru validarea și ciclul de viață al token-urilor](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)
  - Validați afirmațiile de audiență ale token-urilor pentru a se potrivi cu identitatea serverului MCP
  - Implementați politici adecvate de rotație și expirare a token-urilor
  - Preveniți atacurile de reluare a token-urilor și utilizarea neautorizată

- **Stocare Protejată a Token-urilor**: Asigurați stocarea token-urilor cu criptare atât în repaus, cât și în tranzit
  - **Cele Mai Bune Practici**: [Ghiduri pentru Stocarea și Criptarea Securizată a Token-urilor](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

#### Implementarea Controlului Accesului

- **Principiul Privilegiilor Minime**: Acordați serverelor MCP doar permisiunile minime necesare pentru funcționalitatea intenționată
  - Revizuiri și actualizări regulate ale permisiunilor pentru a preveni acumularea excesivă de privilegii
  - **Documentație Microsoft**: [Acces Securizat cu Privilegii Minime](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)

- **Control de Acces Bazat pe Roluri (RBAC)**: Implementați atribuiri de roluri detaliate
  - Restrângeți rolurile la resurse și acțiuni specifice
  - Evitați permisiunile largi sau inutile care extind suprafețele de atac

- **Monitorizarea Continuă a Permisiunilor**: Implementați audituri și monitorizări continue ale accesului
  - Monitorizați modelele de utilizare a permisiunilor pentru anomalii
  - Remediați prompt permisiunile excesive sau neutilizate
- **Generare Sesiuni Securizate**: Folosiți ID-uri de sesiune criptografic sigure, nedeterministe, generate cu generatoare de numere aleatorii securizate  
- **Legare Specifică Utilizatorului**: Asociați ID-urile de sesiune cu informații specifice utilizatorului folosind formate precum `<user_id>:<session_id>` pentru a preveni abuzul sesiunilor între utilizatori  
- **Gestionarea Ciclu de Viață al Sesiunii**: Implementați expirarea, rotația și invalidarea corespunzătoare pentru a limita ferestrele de vulnerabilitate  
- **Securitatea Transportului**: HTTPS obligatoriu pentru toate comunicațiile pentru a preveni interceptarea ID-urilor de sesiune  

### Problema „Confused Deputy”

Problema **confused deputy** apare atunci când serverele MCP acționează ca proxy-uri de autentificare între clienți și servicii terțe, creând oportunități de ocolire a autorizării prin exploatarea ID-urilor statice ale clienților.

#### **Mecanismele Atacului & Riscuri**

- **Ocolirea Consimțământului pe Bază de Cookie-uri**: Autentificarea anterioară a utilizatorului creează cookie-uri de consimțământ pe care atacatorii le exploatează prin cereri de autorizare malițioase cu URI-uri de redirecționare manipulate  
- **Furtul Codurilor de Autorizare**: Cookie-urile de consimțământ existente pot determina serverele de autorizare să sară peste ecranele de consimțământ, redirecționând codurile către puncte de control controlate de atacatori  
- **Acces Neautorizat la API-uri**: Codurile de autorizare furate permit schimbul de token-uri și uzurparea identității utilizatorului fără aprobare explicită  

#### **Strategii de Atenuare**

**Controale Obligatorii:**
- **Cereri Explicite de Consimțământ**: Serverele proxy MCP care utilizează ID-uri statice ale clienților **TREBUIE** să obțină consimțământul utilizatorului pentru fiecare client înregistrat dinamic  
- **Implementarea Securității OAuth 2.1**: Urmați cele mai bune practici actuale de securitate OAuth, inclusiv PKCE (Proof Key for Code Exchange) pentru toate cererile de autorizare  
- **Validarea Strictă a Clienților**: Implementați validarea riguroasă a URI-urilor de redirecționare și a identificatorilor clienților pentru a preveni exploatarea  

### Vulnerabilități de Tip „Token Passthrough”  

**Token passthrough** reprezintă un anti-pattern explicit în care serverele MCP acceptă token-uri ale clienților fără validare corespunzătoare și le transmit către API-uri downstream, încălcând specificațiile de autorizare MCP.

#### **Implicații de Securitate**

- **Ocolirea Controalelor**: Utilizarea directă a token-urilor client-API ocolește controale critice precum limitarea ratei, validarea și monitorizarea  
- **Coruperea Jurnalelor de Audit**: Token-urile emise upstream fac imposibilă identificarea clientului, afectând capacitățile de investigare a incidentelor  
- **Exfiltrarea Datelor prin Proxy**: Token-urile nevalidate permit actorilor malițioși să utilizeze serverele ca proxy-uri pentru acces neautorizat la date  
- **Încălcarea Granițelor de Încredere**: Presupunerile de încredere ale serviciilor downstream pot fi încălcate atunci când originea token-urilor nu poate fi verificată  
- **Extinderea Atacurilor Multi-servicii**: Token-urile compromise acceptate între mai multe servicii permit mișcarea laterală  

#### **Controale de Securitate Necesare**

**Cerințe Nenegociabile:**
- **Validarea Token-urilor**: Serverele MCP **NU TREBUIE** să accepte token-uri care nu sunt emise explicit pentru serverul MCP  
- **Verificarea Publicului (Audience)**: Verificați întotdeauna ca afirmațiile despre publicul token-ului să corespundă identității serverului MCP  
- **Ciclu de Viață Corect al Token-urilor**: Implementați token-uri de acces cu durată scurtă de viață și practici sigure de rotație  

## Securitatea Lanțului de Aprovizionare pentru Sisteme AI

Securitatea lanțului de aprovizionare a evoluat dincolo de dependențele software tradiționale pentru a include întregul ecosistem AI. Implementările moderne MCP trebuie să verifice și să monitorizeze riguros toate componentele legate de AI, deoarece fiecare introduce potențiale vulnerabilități care ar putea compromite integritatea sistemului.

### Componente Extinse ale Lanțului de Aprovizionare AI

**Dependențe Software Tradiționale:**
- Biblioteci și cadre open-source  
- Imagini de containere și sisteme de bază  
- Instrumente de dezvoltare și pipeline-uri de build  
- Componente și servicii de infrastructură  

**Elemente Specifice AI ale Lanțului de Aprovizionare:**
- **Modele Fundamentale**: Modele pre-antrenate de la diverși furnizori care necesită verificarea provenienței  
- **Servicii de Încorporare**: Servicii externe de vectorizare și căutare semantică  
- **Furnizori de Context**: Surse de date, baze de cunoștințe și depozite de documente  
- **API-uri Terțe**: Servicii AI externe, pipeline-uri ML și puncte finale de procesare a datelor  
- **Artefacte ale Modelului**: Greutăți, configurații și variante de model ajustate  
- **Surse de Date pentru Antrenare**: Seturi de date utilizate pentru antrenarea și ajustarea modelelor  

### Strategie Cuprinzătoare de Securitate a Lanțului de Aprovizionare

#### **Verificarea Componentei & Încredere**
- **Validarea Provenienței**: Verificați originea, licențierea și integritatea tuturor componentelor AI înainte de integrare  
- **Evaluarea Securității**: Efectuați scanări de vulnerabilitate și revizuiri de securitate pentru modele, surse de date și servicii AI  
- **Analiza Reputației**: Evaluați istoricul de securitate și practicile furnizorilor de servicii AI  
- **Verificarea Conformității**: Asigurați-vă că toate componentele respectă cerințele organizaționale de securitate și reglementare  

#### **Pipeline-uri de Implementare Securizate**  
- **Securitate CI/CD Automatizată**: Integrați scanarea de securitate pe tot parcursul pipeline-urilor de implementare automatizate  
- **Integritatea Artefactelor**: Implementați verificarea criptografică pentru toate artefactele implementate (cod, modele, configurații)  
- **Implementare Etapizată**: Utilizați strategii de implementare progresivă cu validare de securitate la fiecare etapă  
- **Depozite de Artefacte de Încredere**: Implementați doar din registre și depozite de artefacte verificate și securizate  

#### **Monitorizare Continuă & Răspuns**
- **Scanarea Dependențelor**: Monitorizare continuă a vulnerabilităților pentru toate dependențele software și componentele AI  
- **Monitorizarea Modelului**: Evaluare continuă a comportamentului modelului, a derivelor de performanță și a anomaliilor de securitate  
- **Urmărirea Sănătății Serviciilor**: Monitorizați serviciile AI externe pentru disponibilitate, incidente de securitate și modificări de politici  
- **Integrarea Informațiilor despre Amenințări**: Includeți fluxuri de amenințări specifice riscurilor de securitate AI și ML  

#### **Controlul Accesului & Privilegiul Minim**
- **Permisiuni la Nivel de Componentă**: Restricționați accesul la modele, date și servicii pe baza necesității de afaceri  
- **Gestionarea Conturilor de Serviciu**: Implementați conturi de serviciu dedicate cu permisiuni minime necesare  
- **Segmentarea Rețelei**: Izolați componentele AI și limitați accesul rețelei între servicii  
- **Controale API Gateway**: Utilizați gateway-uri API centralizate pentru a controla și monitoriza accesul la serviciile AI externe  

#### **Răspuns la Incidente & Recuperare**
- **Proceduri de Răspuns Rapid**: Procese stabilite pentru aplicarea de patch-uri sau înlocuirea componentelor AI compromise  
- **Rotația Credencialelor**: Sisteme automatizate pentru rotația secretelor, cheilor API și credențialelor de serviciu  
- **Capacități de Rollback**: Posibilitatea de a reveni rapid la versiunile anterioare cunoscute ca fiind bune ale componentelor AI  
- **Recuperarea după Breșe în Lanțul de Aprovizionare**: Proceduri specifice pentru a răspunde la compromiterea serviciilor AI upstream  

### Instrumente de Securitate Microsoft & Integrare

**GitHub Advanced Security** oferă protecție cuprinzătoare a lanțului de aprovizionare, inclusiv:
- **Scanarea Secretelor**: Detectarea automată a credențialelor, cheilor API și token-urilor în depozite  
- **Scanarea Dependențelor**: Evaluarea vulnerabilităților pentru dependențele și bibliotecile open-source  
- **Analiza CodeQL**: Analiză statică a codului pentru vulnerabilități de securitate și probleme de codare  
- **Informații despre Lanțul de Aprovizionare**: Vizibilitate asupra sănătății și stării de securitate a dependențelor  

**Integrarea Azure DevOps & Azure Repos:**
- Integrare fără întreruperi a scanării de securitate pe platformele de dezvoltare Microsoft  
- Verificări automate de securitate în Azure Pipelines pentru sarcinile de lucru AI  
- Aplicarea politicilor pentru implementarea componentelor AI securizate  

**Practici Interne Microsoft:**
Microsoft implementează practici extinse de securitate a lanțului de aprovizionare în toate produsele. Aflați despre abordările dovedite în [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).
### **Soluții de Securitate Microsoft**
- [Documentația Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Serviciul Azure Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Securitatea Microsoft Entra ID](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Cele mai bune practici pentru gestionarea token-urilor Azure](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Securitate avansată GitHub](https://github.com/security/advanced-security)

### **Ghiduri de Implementare și Tutoriale**
- [Azure API Management ca Gateway de Autentificare MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Autentificare Microsoft Entra ID cu Servere MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Stocarea și criptarea securizată a token-urilor (Video)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### **DevOps și Securitatea Lanțului de Aprovizionare**
- [Securitatea Azure DevOps](https://azure.microsoft.com/products/devops)
- [Securitatea Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Călătoria Microsoft în Securizarea Lanțului de Aprovizionare Software](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)

## **Documentație Suplimentară de Securitate**

Pentru ghiduri complete de securitate, consultați aceste documente specializate din această secțiune:

- **[Cele mai bune practici de securitate MCP 2025](./mcp-security-best-practices-2025.md)** - Cele mai bune practici complete de securitate pentru implementările MCP  
- **[Implementarea Azure Content Safety](./azure-content-safety-implementation.md)** - Exemple practice de integrare Azure Content Safety  
- **[Controale de securitate MCP 2025](./mcp-security-controls-2025.md)** - Cele mai recente controale și tehnici de securitate pentru implementările MCP  
- **[Ghid rapid de bune practici MCP](./mcp-best-practices.md)** - Ghid de referință rapid pentru practicile esențiale de securitate MCP  

---

## Ce urmează

Următorul: [Capitolul 3: Începeți](../03-GettingStarted/README.md)

**Declinarea responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși depunem eforturi pentru a asigura acuratețea, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.