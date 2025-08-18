<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b2b9e15e78b9d9a2b3ff3e8fd7d1f434",
  "translation_date": "2025-08-18T20:46:06+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "ro"
}
-->
# Cele Mai Bune Practici de Securitate MCP 2025

Acest ghid cuprinzător prezintă cele mai bune practici esențiale de securitate pentru implementarea sistemelor Model Context Protocol (MCP), bazate pe cea mai recentă **Specificație MCP 2025-06-18** și pe standardele actuale din industrie. Aceste practici abordează atât preocupările tradiționale de securitate, cât și amenințările specifice AI, unice pentru implementările MCP.

## Cerințe Critice de Securitate

### Controale de Securitate Obligatorii (Cerințe MUST)

1. **Validarea Token-urilor**: Serverele MCP **NU TREBUIE** să accepte token-uri care nu au fost emise explicit pentru serverul MCP respectiv.
2. **Verificarea Autorizării**: Serverele MCP care implementează autorizarea **TREBUIE** să verifice TOATE cererile primite și **NU TREBUIE** să utilizeze sesiuni pentru autentificare.  
3. **Consimțământul Utilizatorului**: Serverele proxy MCP care folosesc ID-uri de client statice **TREBUIE** să obțină consimțământul explicit al utilizatorului pentru fiecare client înregistrat dinamic.
4. **ID-uri de Sesiune Securizate**: Serverele MCP **TREBUIE** să utilizeze ID-uri de sesiune criptografic sigure, nedeterministe, generate cu generatoare de numere aleatorii sigure.

## Practici Fundamentale de Securitate

### 1. Validarea și Igienizarea Inputurilor
- **Validare Completă a Inputurilor**: Validați și igienizați toate inputurile pentru a preveni atacurile de tip injecție, problemele de tip "confused deputy" și vulnerabilitățile de tip injecție de prompturi.
- **Aplicarea Schemelor de Parametri**: Implementați validarea strictă a schemelor JSON pentru toți parametrii uneltelor și inputurile API.
- **Filtrarea Conținutului**: Utilizați Microsoft Prompt Shields și Azure Content Safety pentru a filtra conținutul malițios din prompturi și răspunsuri.
- **Igienizarea Outputurilor**: Validați și igienizați toate outputurile modelului înainte de a le prezenta utilizatorilor sau sistemelor downstream.

### 2. Excelență în Autentificare și Autorizare  
- **Furnizori Externi de Identitate**: Delegați autentificarea către furnizori de identitate consacrați (Microsoft Entra ID, furnizori OAuth 2.1) în loc să implementați autentificare personalizată.
- **Permisiuni Granulare**: Implementați permisiuni detaliate, specifice uneltelor, urmând principiul privilegiului minim.
- **Managementul Ciclu de Viață al Token-urilor**: Utilizați token-uri de acces cu durată scurtă, rotație sigură și validare corectă a audienței.
- **Autentificare Multi-Factor**: Solicitați MFA pentru toate accesările administrative și operațiunile sensibile.

### 3. Protocoale de Comunicare Securizate
- **Securitatea Stratului de Transport**: Utilizați HTTPS/TLS 1.3 pentru toate comunicațiile MCP cu validarea corectă a certificatelor.
- **Criptare End-to-End**: Implementați straturi suplimentare de criptare pentru date extrem de sensibile în tranzit și în repaus.
- **Managementul Certificatelor**: Mențineți un ciclu de viață corect al certificatelor cu procese automate de reînnoire.
- **Aplicarea Versiunii Protocolului**: Utilizați versiunea curentă a protocolului MCP (2025-06-18) cu negocierea corectă a versiunii.

### 4. Limitarea Avansată a Ratelor și Protecția Resurselor
- **Limitarea Multi-strat a Ratelor**: Implementați limitarea ratelor la nivel de utilizator, sesiune, unealtă și resurse pentru a preveni abuzurile.
- **Limitarea Adaptivă a Ratelor**: Utilizați limitarea ratelor bazată pe învățare automată, care se adaptează la tiparele de utilizare și indicatorii de amenințare.
- **Managementul Cotelor de Resurse**: Stabiliți limite adecvate pentru resursele computaționale, utilizarea memoriei și timpul de execuție.
- **Protecție DDoS**: Implementați protecție completă împotriva atacurilor DDoS și sisteme de analiză a traficului.

### 5. Jurnalizare și Monitorizare Cuprinzătoare
- **Jurnalizare Structurată a Auditului**: Implementați jurnale detaliate, căutabile, pentru toate operațiunile MCP, execuțiile uneltelor și evenimentele de securitate.
- **Monitorizare de Securitate în Timp Real**: Implementați sisteme SIEM cu detectare a anomaliilor bazată pe AI pentru sarcinile MCP.
- **Jurnalizare Conformă cu Confidențialitatea**: Jurnalizați evenimentele de securitate respectând cerințele și reglementările privind confidențialitatea datelor.
- **Integrarea Răspunsului la Incidente**: Conectați sistemele de jurnalizare la fluxuri de lucru automate de răspuns la incidente.

### 6. Practici Îmbunătățite de Stocare Securizată
- **Module de Securitate Hardware**: Utilizați stocare de chei susținută de HSM (Azure Key Vault, AWS CloudHSM) pentru operațiuni criptografice critice.
- **Managementul Cheilor de Criptare**: Implementați rotația corectă a cheilor, segregarea și controalele de acces pentru cheile de criptare.
- **Managementul Secretelor**: Stocați toate cheile API, token-urile și acreditivele în sisteme dedicate de management al secretelor.
- **Clasificarea Datelor**: Clasificați datele în funcție de nivelurile de sensibilitate și aplicați măsuri de protecție adecvate.

### 7. Management Avansat al Token-urilor
- **Prevenirea Passthrough-ului Token-urilor**: Interziceți explicit modelele de passthrough al token-urilor care ocolesc controalele de securitate.
- **Validarea Audienței**: Verificați întotdeauna dacă revendicările de audiență ale token-urilor corespund identității serverului MCP vizat.
- **Autorizare Bazată pe Revendicări**: Implementați autorizare detaliată bazată pe revendicările token-urilor și atributele utilizatorilor.
- **Legarea Token-urilor**: Legați token-urile de sesiuni, utilizatori sau dispozitive specifice, acolo unde este cazul.

### 8. Management Securizat al Sesiunilor
- **ID-uri de Sesiune Criptografice**: Generați ID-uri de sesiune utilizând generatoare de numere aleatorii criptografic sigure (nu secvențe predictibile).
- **Legare Specifică Utilizatorului**: Legați ID-urile de sesiune de informații specifice utilizatorului utilizând formate sigure precum `<user_id>:<session_id>`.
- **Controale ale Ciclu de Viață al Sesiunilor**: Implementați mecanisme corecte de expirare, rotație și invalidare a sesiunilor.
- **Antete de Securitate pentru Sesiuni**: Utilizați antete HTTP adecvate pentru protecția sesiunilor.

### 9. Controale de Securitate Specifice AI
- **Apărarea Împotriva Injecției de Prompturi**: Implementați Microsoft Prompt Shields cu tehnici de spotlighting, delimitatori și datamarking.
- **Prevenirea Otrăvirii Uneltelor**: Validați metadatele uneltelor, monitorizați schimbările dinamice și verificați integritatea uneltelor.
- **Validarea Outputurilor Modelului**: Scanați outputurile modelului pentru posibile scurgeri de date, conținut dăunător sau încălcări ale politicilor de securitate.
- **Protecția Ferestrei de Context**: Implementați controale pentru a preveni otrăvirea ferestrei de context și atacurile de manipulare.

### 10. Securitatea Execuției Uneltelor
- **Izolarea Execuției**: Rulați execuțiile uneltelor în medii containerizate, izolate, cu limite de resurse.
- **Separarea Privilegiilor**: Executați uneltele cu privilegii minime necesare și conturi de serviciu separate.
- **Izolarea Rețelei**: Implementați segmentarea rețelei pentru mediile de execuție ale uneltelor.
- **Monitorizarea Execuției**: Monitorizați execuția uneltelor pentru comportamente anormale, utilizarea resurselor și încălcări ale securității.

### 11. Validare Continuă a Securității
- **Testare Automată a Securității**: Integrați testarea securității în pipeline-urile CI/CD cu instrumente precum GitHub Advanced Security.
- **Managementul Vulnerabilităților**: Scanați regulat toate dependențele, inclusiv modelele AI și serviciile externe.
- **Testare de Penetrare**: Efectuați evaluări regulate de securitate care vizează în mod specific implementările MCP.
- **Revizuiri de Cod de Securitate**: Implementați revizuiri obligatorii de securitate pentru toate modificările de cod legate de MCP.

### 12. Securitatea Lanțului de Aprovizionare pentru AI
- **Verificarea Componentelor**: Verificați proveniența, integritatea și securitatea tuturor componentelor AI (modele, embeddings, API-uri).
- **Managementul Dependențelor**: Mențineți inventare actualizate ale tuturor dependențelor software și AI cu urmărirea vulnerabilităților.
- **Depozite de Încredere**: Utilizați surse verificate și de încredere pentru toate modelele AI, bibliotecile și uneltele.
- **Monitorizarea Lanțului de Aprovizionare**: Monitorizați continuu compromisurile în furnizorii de servicii AI și depozitele de modele.

## Modele Avansate de Securitate

### Arhitectura Zero Trust pentru MCP
- **Nu Aveți Încredere, Verificați Întotdeauna**: Implementați verificarea continuă pentru toți participanții MCP.
- **Micro-segmentare**: Izolați componentele MCP cu controale granulare de rețea și identitate.
- **Acces Condiționat**: Implementați controale de acces bazate pe risc, care se adaptează la context și comportament.
- **Evaluare Continuă a Riscurilor**: Evaluați dinamic postura de securitate pe baza indicatorilor actuali de amenințare.

### Implementare AI care Respectă Confidențialitatea
- **Minimizarea Datelor**: Expuneți doar datele strict necesare pentru fiecare operațiune MCP.
- **Confidențialitate Diferențială**: Implementați tehnici de protecție a confidențialității pentru procesarea datelor sensibile.
- **Criptare Omomorfă**: Utilizați tehnici avansate de criptare pentru calculul sigur pe date criptate.
- **Învățare Federată**: Implementați abordări de învățare distribuită care păstrează localitatea și confidențialitatea datelor.

### Răspuns la Incidente pentru Sisteme AI
- **Proceduri Specifice AI pentru Incidente**: Dezvoltați proceduri de răspuns la incidente adaptate amenințărilor specifice AI și MCP.
- **Răspuns Automatizat**: Implementați măsuri automate de izolare și remediere pentru incidentele comune de securitate AI.  
- **Capabilități Forensice**: Mențineți pregătirea forensică pentru compromiterea sistemelor AI și breșele de date.
- **Proceduri de Recuperare**: Stabiliți proceduri pentru recuperarea după otrăvirea modelelor AI, atacurile de injecție de prompturi și compromiterea serviciilor.

## Resurse și Standarde pentru Implementare

### Documentația Oficială MCP
- [MCP Specification 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) - Specificația curentă a protocolului MCP
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) - Ghid oficial de securitate
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization) - Modele de autentificare și autorizare
- [MCP Transport Security](https://modelcontextprotocol.io/specification/2025-06-18/transports/) - Cerințe de securitate pentru stratul de transport

### Soluții de Securitate Microsoft
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) - Protecție avansată împotriva injecției de prompturi
- [Azure Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/) - Filtrare cuprinzătoare a conținutului AI
- [Microsoft Entra ID](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow) - Managementul identității și accesului la nivel enterprise
- [Azure Key Vault](https://learn.microsoft.com/azure/key-vault/general/basic-concepts) - Management securizat al secretelor și acreditivelor
- [GitHub Advanced Security](https://github.com/security/advanced-security) - Scanare de securitate pentru lanțul de aprovizionare și cod

### Standarde și Cadre de Securitate
- [OAuth 2.1 Security Best Practices](https://datatracker.ietf.org/doc/html/draft-ietf-oauth-security-topics) - Ghidul actual de securitate OAuth
- [OWASP Top 10](https://owasp.org/www-project-top-ten/) - Riscuri de securitate pentru aplicații web
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559) - Riscuri de securitate specifice AI
- [NIST AI Risk Management Framework](https://www.nist.gov/itl/ai-risk-management-framework) - Management cuprinzător al riscurilor AI
- [ISO 27001:2022](https://www.iso.org/standard/27001) - Sisteme de management al securității informațiilor

### Ghiduri și Tutoriale pentru Implementare
- [Azure API Management as MCP Auth Gateway](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) - Modele de autentificare la nivel enterprise
- [Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/) - Integrarea furnizorilor de identitate
- [Secure Token Storage Implementation](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) - Cele mai bune practici pentru managementul token-urilor
- [End-to-End Encryption for AI](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption) - Modele avansate de criptare

### Resurse Avansate de Securitate
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl) - Practici de dezvoltare securizată
- [AI Red Team Guidance](https://learn.microsoft.com/security/ai-red-team/) - Testare de securitate specifică AI
- [Threat Modeling for AI Systems](https://learn.microsoft.com/security/adoption/approach/threats-ai) - Metodologie de modelare a amenințărilor AI
- [Privacy Engineering for AI](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/) - Tehnici de protecție a confidențialității pentru AI

### Conformitate și Guvernanță
- [GDPR Compliance for AI](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments) - Conformitate privind confidențialitatea în sistemele AI
- [AI Governance Framework](https://learn.microsoft.com/azure/architecture/guide/responsible-ai/responsible-ai-overview) - Implementare AI responsabilă
- [SOC 2 for AI Services](https://learn.microsoft.com/compliance/regulatory/offering-soc) - Controale de securitate pentru furnizorii de servicii AI
- [HIPAA Compliance for AI](https://learn.microsoft.com/compliance/regulatory/offering-hipaa-hitech) - Cerințe de conformitate AI pentru domeniul sănătății

### DevSecOps și Automatizare
- [DevSecOps Pipeline for AI](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline) - Pipeline-uri de dezvoltare AI securizate
- [Automated Security Testing](https://learn.microsoft.com/security/engineering/devsecops) - Validare continuă a securității
- [Infrastructure as Code Security](https://learn.microsoft.com/security/engineering/infrastructure-security) - Implementare securizată a infrastructurii
- [Container Security for AI](https://learn.microsoft.com/azure/container-instances/container-instances-image-security) - Securitatea containerizării sarcinilor AI

### Monitorizare și Răspuns la Incidente
- **Dezvoltarea uneltelor**: Dezvoltă și distribuie unelte și biblioteci de securitate pentru ecosistemul MCP

---

*Acest document reflectă cele mai bune practici de securitate MCP valabile la data de 18 august 2025, conform Specificației MCP 2025-06-18. Practicile de securitate ar trebui revizuite și actualizate periodic pe măsură ce protocolul și peisajul amenințărilor evoluează.*

**Declinarea responsabilității**:  
Acest document a fost tradus utilizând serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși depunem eforturi pentru a asigura acuratețea, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.