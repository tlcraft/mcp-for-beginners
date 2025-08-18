<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b2b9e15e78b9d9a2b3ff3e8fd7d1f434",
  "translation_date": "2025-08-18T16:01:01+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "ro"
}
-->
# Cele mai bune practici de securitate MCP 2025

Acest ghid cuprinzător prezintă cele mai bune practici esențiale pentru implementarea sistemelor Model Context Protocol (MCP) conform celor mai recente **Specificații MCP 2025-06-18** și standardelor actuale din industrie. Aceste practici abordează atât preocupările tradiționale de securitate, cât și amenințările specifice AI unice pentru implementările MCP.

## Cerințe critice de securitate

### Controale de securitate obligatorii (Cerințe MUST)

1. **Validarea token-urilor**: Serverele MCP **NU TREBUIE** să accepte token-uri care nu au fost emise explicit pentru serverul MCP în cauză.
2. **Verificarea autorizării**: Serverele MCP care implementează autorizarea **TREBUIE** să verifice TOATE cererile primite și **NU TREBUIE** să utilizeze sesiuni pentru autentificare.  
3. **Consimțământul utilizatorului**: Serverele proxy MCP care folosesc ID-uri de client statice **TREBUIE** să obțină consimțământul explicit al utilizatorului pentru fiecare client înregistrat dinamic.
4. **ID-uri de sesiune securizate**: Serverele MCP **TREBUIE** să utilizeze ID-uri de sesiune criptografic sigure, nedeterministe, generate cu generatoare de numere aleatorii securizate.

## Practici fundamentale de securitate

### 1. Validarea și igienizarea intrărilor
- **Validare cuprinzătoare a intrărilor**: Validați și igienizați toate intrările pentru a preveni atacurile de tip injecție, problemele de tip „confused deputy” și vulnerabilitățile de tip injecție de prompturi.
- **Aplicarea schemelor de parametri**: Implementați validarea strictă a schemelor JSON pentru toți parametrii uneltelor și intrările API.
- **Filtrarea conținutului**: Utilizați Microsoft Prompt Shields și Azure Content Safety pentru a filtra conținutul malițios din prompturi și răspunsuri.
- **Igienizarea ieșirilor**: Validați și igienizați toate ieșirile modelului înainte de a le prezenta utilizatorilor sau sistemelor din aval.

### 2. Excelență în autentificare și autorizare  
- **Furnizori externi de identitate**: Delegați autentificarea către furnizori de identitate consacrați (Microsoft Entra ID, furnizori OAuth 2.1) în loc să implementați soluții personalizate.
- **Permisiuni detaliate**: Implementați permisiuni granulare, specifice uneltelor, urmând principiul privilegiului minim.
- **Gestionarea ciclului de viață al token-urilor**: Utilizați token-uri de acces cu durată scurtă de viață, cu rotație securizată și validare corespunzătoare a audienței.
- **Autentificare multi-factor**: Solicitați MFA pentru toate accesările administrative și operațiunile sensibile.

### 3. Protocoale de comunicare securizate
- **Securitatea stratului de transport**: Utilizați HTTPS/TLS 1.3 pentru toate comunicațiile MCP, cu validarea corespunzătoare a certificatelor.
- **Criptare end-to-end**: Implementați straturi suplimentare de criptare pentru datele extrem de sensibile în tranzit și în repaus.
- **Gestionarea certificatelor**: Mențineți un ciclu de viață corespunzător al certificatelor, cu procese automate de reînnoire.
- **Aplicarea versiunii protocolului**: Utilizați versiunea curentă a protocolului MCP (2025-06-18) cu negocierea corespunzătoare a versiunii.

### 4. Limitarea avansată a ratei și protecția resurselor
- **Limitarea ratei pe mai multe niveluri**: Implementați limitarea ratei la nivel de utilizator, sesiune, unealtă și resursă pentru a preveni abuzurile.
- **Limitarea adaptivă a ratei**: Utilizați limitarea ratei bazată pe învățare automată, care se adaptează la tiparele de utilizare și indicatorii de amenințare.
- **Gestionarea cotelor de resurse**: Stabiliți limite adecvate pentru resursele computaționale, utilizarea memoriei și timpul de execuție.
- **Protecție DDoS**: Implementați sisteme cuprinzătoare de protecție DDoS și analiză a traficului.

### 5. Jurnalizare și monitorizare cuprinzătoare
- **Jurnalizare audit structurată**: Implementați jurnale detaliate, căutabile, pentru toate operațiunile MCP, execuțiile uneltelor și evenimentele de securitate.
- **Monitorizare în timp real a securității**: Implementați sisteme SIEM cu detectare a anomaliilor bazată pe AI pentru sarcinile MCP.
- **Jurnalizare conformă cu confidențialitatea**: Înregistrați evenimentele de securitate respectând cerințele și reglementările privind confidențialitatea datelor.
- **Integrarea răspunsului la incidente**: Conectați sistemele de jurnalizare la fluxuri de lucru automate de răspuns la incidente.

### 6. Practici îmbunătățite de stocare securizată
- **Module de securitate hardware**: Utilizați stocare de chei susținută de HSM (Azure Key Vault, AWS CloudHSM) pentru operațiuni criptografice critice.
- **Gestionarea cheilor de criptare**: Implementați rotația corespunzătoare a cheilor, segregarea și controalele de acces pentru cheile de criptare.
- **Gestionarea secretelor**: Stocați toate cheile API, token-urile și acreditivele în sisteme dedicate de gestionare a secretelor.
- **Clasificarea datelor**: Clasificați datele pe baza nivelurilor de sensibilitate și aplicați măsuri de protecție adecvate.

### 7. Gestionarea avansată a token-urilor
- **Prevenirea transmiterii token-urilor**: Interziceți explicit modelele de transmitere a token-urilor care ocolesc controalele de securitate.
- **Validarea audienței**: Verificați întotdeauna dacă revendicările de audiență ale token-urilor corespund identității serverului MCP vizat.
- **Autorizare bazată pe revendicări**: Implementați autorizare detaliată bazată pe revendicările token-urilor și atributele utilizatorilor.
- **Legarea token-urilor**: Legați token-urile de sesiuni, utilizatori sau dispozitive specifice, acolo unde este cazul.

### 8. Gestionarea securizată a sesiunilor
- **ID-uri de sesiune criptografice**: Generați ID-uri de sesiune utilizând generatoare de numere aleatorii criptografic sigure (nu secvențe predictibile).
- **Legare specifică utilizatorului**: Legați ID-urile de sesiune de informații specifice utilizatorului utilizând formate sigure precum `<user_id>:<session_id>`.
- **Controale ale ciclului de viață al sesiunilor**: Implementați mecanisme corespunzătoare de expirare, rotație și invalidare a sesiunilor.
- **Antete de securitate pentru sesiuni**: Utilizați antete HTTP corespunzătoare pentru protecția sesiunilor.

### 9. Controale de securitate specifice AI
- **Apărarea împotriva injecției de prompturi**: Implementați Microsoft Prompt Shields cu tehnici de spotlighting, delimitatori și marcare a datelor.
- **Prevenirea otrăvirii uneltelor**: Validați metadatele uneltelor, monitorizați schimbările dinamice și verificați integritatea uneltelor.
- **Validarea ieșirilor modelului**: Scanați ieșirile modelului pentru posibile scurgeri de date, conținut dăunător sau încălcări ale politicilor de securitate.
- **Protecția ferestrei de context**: Implementați controale pentru a preveni otrăvirea ferestrei de context și atacurile de manipulare.

### 10. Securitatea execuției uneltelor
- **Izolarea execuției**: Rulați execuțiile uneltelor în medii containerizate, izolate, cu limite de resurse.
- **Separarea privilegiilor**: Executați uneltele cu privilegii minime necesare și conturi de serviciu separate.
- **Izolarea rețelei**: Implementați segmentarea rețelei pentru mediile de execuție ale uneltelor.
- **Monitorizarea execuției**: Monitorizați execuția uneltelor pentru comportamente anormale, utilizarea resurselor și încălcări ale securității.

### 11. Validarea continuă a securității
- **Testare automată a securității**: Integrați testarea securității în pipeline-urile CI/CD cu instrumente precum GitHub Advanced Security.
- **Gestionarea vulnerabilităților**: Scanați regulat toate dependențele, inclusiv modelele AI și serviciile externe.
- **Testare de penetrare**: Efectuați evaluări regulate de securitate care vizează în mod specific implementările MCP.
- **Revizuiri de cod pentru securitate**: Implementați revizuiri obligatorii de securitate pentru toate modificările de cod legate de MCP.

### 12. Securitatea lanțului de aprovizionare pentru AI
- **Verificarea componentelor**: Verificați proveniența, integritatea și securitatea tuturor componentelor AI (modele, embeddings, API-uri).
- **Gestionarea dependențelor**: Mențineți inventare actualizate ale tuturor dependențelor software și AI, cu urmărirea vulnerabilităților.
- **Depozite de încredere**: Utilizați surse verificate și de încredere pentru toate modelele AI, bibliotecile și uneltele.
- **Monitorizarea lanțului de aprovizionare**: Monitorizați continuu compromisurile în furnizorii de servicii AI și depozitele de modele.

## Modele avansate de securitate

### Arhitectura Zero Trust pentru MCP
- **Nu aveți încredere, verificați întotdeauna**: Implementați verificarea continuă pentru toți participanții MCP.
- **Micro-segmentare**: Izolați componentele MCP cu controale granulare de rețea și identitate.
- **Acces condiționat**: Implementați controale de acces bazate pe risc, care se adaptează la context și comportament.
- **Evaluare continuă a riscurilor**: Evaluați dinamic postura de securitate pe baza indicatorilor actuali de amenințare.

### Implementarea AI care protejează confidențialitatea
- **Minimizarea datelor**: Expuneți doar datele strict necesare pentru fiecare operațiune MCP.
- **Confidențialitate diferențială**: Implementați tehnici de protecție a confidențialității pentru procesarea datelor sensibile.
- **Criptare omomorfă**: Utilizați tehnici avansate de criptare pentru calculul securizat pe date criptate.
- **Învățare federată**: Implementați abordări distribuite de învățare care păstrează localitatea și confidențialitatea datelor.

### Răspuns la incidente pentru sisteme AI
- **Proceduri specifice incidentelor AI**: Dezvoltați proceduri de răspuns la incidente adaptate amenințărilor specifice AI și MCP.
- **Răspuns automatizat**: Implementați măsuri automate de izolare și remediere pentru incidentele comune de securitate AI.  
- **Capabilități de investigație**: Mențineți pregătirea pentru investigații în caz de compromitere a sistemelor AI și breșe de date.
- **Proceduri de recuperare**: Stabiliți proceduri pentru recuperarea după otrăvirea modelelor AI, atacuri de injecție de prompturi și compromiterea serviciilor.


- **Dezvoltarea de instrumente**: Dezvoltă și distribuie instrumente și biblioteci de securitate pentru ecosistemul MCP

---

*Acest document reflectă cele mai bune practici de securitate MCP la data de 18 august 2025, conform Specificației MCP 2025-06-18. Practicile de securitate ar trebui revizuite și actualizate periodic pe măsură ce protocolul și peisajul amenințărilor evoluează.*

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa natală ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.