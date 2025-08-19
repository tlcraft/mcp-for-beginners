<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
<<<<<<< HEAD
  "translation_date": "2025-08-18T20:34:26+00:00",
=======
  "translation_date": "2025-08-18T15:46:05+00:00",
>>>>>>> origin/main
  "source_file": "changelog.md",
  "language_code": "ro"
}
-->
# Jurnal de modificări: Curriculum MCP pentru Începători

<<<<<<< HEAD
Acest document servește ca o evidență a tuturor modificărilor semnificative aduse curriculumului Model Context Protocol (MCP) pentru Începători. Modificările sunt documentate în ordine invers cronologică (cele mai recente modificări primele).
=======
Acest document servește ca o înregistrare a tuturor modificărilor semnificative aduse curriculumului Model Context Protocol (MCP) pentru Începători. Modificările sunt documentate în ordine invers cronologică (cele mai recente modificări primele).
>>>>>>> origin/main

## 18 August 2025

### Actualizare cuprinzătoare a documentației - Standardele MCP 2025-06-18

#### Cele mai bune practici de securitate MCP (02-Security/) - Modernizare completă
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Rescriere completă aliniată la Specificația MCP 2025-06-18
  - **Cerințe obligatorii**: Adăugate cerințe explicite MUST/MUST NOT din specificația oficială cu indicatori vizuali clari
  - **12 Practici de bază în securitate**: Restructurate dintr-o listă de 15 elemente în domenii de securitate cuprinzătoare
    - Securitatea token-urilor și autentificarea cu integrarea unui furnizor extern de identitate
    - Managementul sesiunilor și securitatea transportului cu cerințe criptografice
    - Protecția împotriva amenințărilor specifice AI cu integrarea Microsoft Prompt Shields
    - Controlul accesului și permisiunilor conform principiului privilegiului minim
    - Siguranța conținutului și monitorizarea cu integrarea Azure Content Safety
    - Securitatea lanțului de aprovizionare cu verificarea cuprinzătoare a componentelor
    - Securitatea OAuth și prevenirea atacurilor Confused Deputy cu implementarea PKCE
    - Răspuns la incidente și recuperare cu capabilități automatizate
    - Conformitate și guvernanță cu aliniere la reglementări
    - Controale avansate de securitate cu arhitectură zero trust
    - Integrarea ecosistemului de securitate Microsoft cu soluții cuprinzătoare
    - Evoluția continuă a securității cu practici adaptive
  - **Soluții de securitate Microsoft**: Ghiduri de integrare îmbunătățite pentru Prompt Shields, Azure Content Safety, Entra ID și GitHub Advanced Security
  - **Resurse de implementare**: Linkuri cuprinzătoare de resurse categorisite după Documentația oficială MCP, Soluții de securitate Microsoft, Standarde de securitate și Ghiduri de implementare

#### Controale avansate de securitate (02-Security/) - Implementare la nivel de întreprindere
- **MCP-SECURITY-CONTROLS-2025.md**: Revizuire completă cu un cadru de securitate de nivel enterprise
<<<<<<< HEAD
  - **9 Domenii de securitate cuprinzătoare**: Extinse de la controale de bază la un cadru detaliat pentru întreprinderi
=======
  - **9 Domenii cuprinzătoare de securitate**: Extinse de la controale de bază la un cadru detaliat pentru întreprinderi
>>>>>>> origin/main
    - Autentificare și autorizare avansată cu integrarea Microsoft Entra ID
    - Securitatea token-urilor și controale anti-passthrough cu validare cuprinzătoare
    - Controale de securitate a sesiunilor cu prevenirea deturnării
    - Controale de securitate specifice AI cu prevenirea injecției de prompturi și otrăvirii instrumentelor
    - Prevenirea atacurilor Confused Deputy cu securitatea proxy OAuth
    - Securitatea execuției instrumentelor cu sandboxing și izolare
    - Controale de securitate ale lanțului de aprovizionare cu verificarea dependențelor
    - Controale de monitorizare și detectare cu integrarea SIEM
    - Răspuns la incidente și recuperare cu capabilități automatizate
  - **Exemple de implementare**: Adăugate blocuri de configurare YAML detaliate și exemple de cod
  - **Integrarea soluțiilor Microsoft**: Acoperire cuprinzătoare a serviciilor de securitate Azure, GitHub Advanced Security și managementul identității la nivel enterprise

#### Subiecte avansate de securitate (05-AdvancedTopics/mcp-security/) - Implementare pregătită pentru producție
- **README.md**: Rescriere completă pentru implementarea securității la nivel enterprise
  - **Aliniere la specificația actuală**: Actualizat la Specificația MCP 2025-06-18 cu cerințe obligatorii de securitate
  - **Autentificare îmbunătățită**: Integrarea Microsoft Entra ID cu exemple cuprinzătoare în .NET și Java Spring Security
  - **Integrarea securității AI**: Implementarea Microsoft Prompt Shields și Azure Content Safety cu exemple detaliate în Python
<<<<<<< HEAD
  - **Mitigarea amenințărilor avansate**: Exemple cuprinzătoare de implementare pentru
=======
  - **Mitigarea avansată a amenințărilor**: Exemple cuprinzătoare de implementare pentru
>>>>>>> origin/main
    - Prevenirea atacurilor Confused Deputy cu PKCE și validarea consimțământului utilizatorului
    - Prevenirea pasării token-urilor cu validarea audienței și gestionarea securizată a token-urilor
    - Prevenirea deturnării sesiunilor cu legături criptografice și analiză comportamentală
  - **Integrarea securității la nivel enterprise**: Monitorizarea Azure Application Insights, pipeline-uri de detectare a amenințărilor și securitatea lanțului de aprovizionare
<<<<<<< HEAD
  - **Listă de verificare pentru implementare**: Controale de securitate obligatorii vs. recomandate cu beneficii ale ecosistemului de securitate Microsoft
=======
  - **Lista de verificare pentru implementare**: Controale de securitate obligatorii vs. recomandate cu beneficii ale ecosistemului de securitate Microsoft
>>>>>>> origin/main

### Îmbunătățirea calității documentației și alinierea la standarde
- **Referințe la specificații**: Actualizate toate referințele la Specificația MCP 2025-06-18
- **Ecosistemul de securitate Microsoft**: Ghiduri de integrare îmbunătățite în întreaga documentație de securitate
- **Implementare practică**: Adăugate exemple detaliate de cod în .NET, Java și Python cu modele enterprise
- **Organizarea resurselor**: Categorisire cuprinzătoare a documentației oficiale, standardelor de securitate și ghidurilor de implementare
<<<<<<< HEAD
- **Indicatori vizuali**: Marcaje clare ale cerințelor obligatorii vs. practicilor recomandate

#### Concepte de bază (01-CoreConcepts/) - Modernizare completă
- **Actualizare versiune protocol**: Actualizat pentru a face referire la Specificația MCP 2025-06-18 cu versiuni bazate pe date (format YYYY-MM-DD)
- **Rafinarea arhitecturii**: Descrieri îmbunătățite ale gazdelor, clienților și serverelor pentru a reflecta modelele actuale de arhitectură MCP
  - Gazdele definite clar ca aplicații AI care coordonează multiple conexiuni client MCP
=======
- **Indicatori vizuali**: Marcarea clară a cerințelor obligatorii vs. practicilor recomandate

#### Concepte de bază (01-CoreConcepts/) - Modernizare completă
- **Actualizare versiune protocol**: Actualizat pentru a face referire la Specificația MCP 2025-06-18 cu versiuni bazate pe dată (format YYYY-MM-DD)
- **Rafinarea arhitecturii**: Descrieri îmbunătățite ale gazdelor, clienților și serverelor pentru a reflecta modelele actuale de arhitectură MCP
  - Gazdele sunt acum definite clar ca aplicații AI care coordonează multiple conexiuni client MCP
>>>>>>> origin/main
  - Clienții descriși ca conectori de protocol care mențin relații unu-la-unu cu serverele
  - Serverele îmbunătățite cu scenarii de implementare locală vs. la distanță
- **Restructurarea primitivelor**: Revizuire completă a primitivelor server și client
  - Primitive server: Resurse (surse de date), Prompturi (șabloane), Instrumente (funcții executabile) cu explicații și exemple detaliate
  - Primitive client: Sampling (completări LLM), Elicitation (input utilizator), Logging (debugging/monitorizare)
  - Actualizat cu modelele actuale de descoperire (`*/list`), recuperare (`*/get`) și execuție (`*/call`)
- **Arhitectura protocolului**: Introducerea unui model de arhitectură pe două straturi
  - Strat de date: Fundație JSON-RPC 2.0 cu managementul ciclului de viață și primitive
  - Strat de transport: STDIO (local) și HTTP streamabil cu SSE (transport la distanță)
- **Cadru de securitate**: Principii cuprinzătoare de securitate incluzând consimțământ explicit al utilizatorului, protecția confidențialității datelor, siguranța execuției instrumentelor și securitatea stratului de transport
- **Modele de comunicare**: Mesaje de protocol actualizate pentru a arăta fluxurile de inițializare, descoperire, execuție și notificare
<<<<<<< HEAD
- **Exemple de cod**: Exemple multi-limbaj actualizate (.NET, Java, Python, JavaScript) pentru a reflecta modelele actuale ale SDK MCP
=======
- **Exemple de cod**: Exemple multi-limbaj actualizate (.NET, Java, Python, JavaScript) pentru a reflecta modelele actuale ale SDK-ului MCP
>>>>>>> origin/main

#### Securitate (02-Security/) - Revizuire cuprinzătoare a securității  
- **Aliniere la standarde**: Aliniere completă cu cerințele de securitate ale Specificației MCP 2025-06-18
- **Evoluția autentificării**: Documentată evoluția de la servere OAuth personalizate la delegarea furnizorului extern de identitate (Microsoft Entra ID)
- **Analiza amenințărilor specifice AI**: Acoperire îmbunătățită a vectorilor moderni de atac AI
  - Scenarii detaliate de atac prin injecție de prompturi cu exemple din lumea reală
  - Mecanisme de otrăvire a instrumentelor și modele de atac "rug pull"
  - Otrăvirea ferestrei de context și atacuri de confuzie a modelului
- **Soluții de securitate AI Microsoft**: Acoperire cuprinzătoare a ecosistemului de securitate Microsoft
  - Prompt Shields AI cu detectare avansată, evidențiere și tehnici de delimitare
  - Modele de integrare Azure Content Safety
  - GitHub Advanced Security pentru protecția lanțului de aprovizionare
- **Mitigarea amenințărilor avansate**: Controale de securitate detaliate pentru
  - Deturnarea sesiunilor cu scenarii de atac specifice MCP și cerințe criptografice pentru ID-ul sesiunii
<<<<<<< HEAD
  - Problemele Confused Deputy în scenarii proxy MCP cu cerințe explicite de consimțământ
  - Vulnerabilitățile pasării token-urilor cu controale obligatorii de validare
=======
  - Probleme Confused Deputy în scenarii proxy MCP cu cerințe explicite de consimțământ
  - Vulnerabilități de pasare a token-urilor cu controale obligatorii de validare
>>>>>>> origin/main
- **Securitatea lanțului de aprovizionare**: Acoperire extinsă a lanțului de aprovizionare AI incluzând modele de bază, servicii de embeddings, furnizori de context și API-uri terțe
- **Securitate fundamentală**: Integrare îmbunătățită cu modele de securitate enterprise incluzând arhitectura zero trust și ecosistemul de securitate Microsoft
- **Organizarea resurselor**: Linkuri cuprinzătoare de resurse categorisite după tip (Documentație oficială, Standarde, Cercetare, Soluții Microsoft, Ghiduri de implementare)

### Îmbunătățiri ale calității documentației
- **Obiective de învățare structurate**: Obiective de învățare îmbunătățite cu rezultate specifice și acționabile 
- **Referințe încrucișate**: Adăugate linkuri între subiecte de securitate și concepte de bază conexe
<<<<<<< HEAD
- **Informații actuale**: Actualizate toate referințele de date și linkurile la specificații conform standardelor actuale
=======
- **Informații actuale**: Actualizate toate referințele de dată și linkurile la specificații la standardele actuale
>>>>>>> origin/main
- **Ghiduri de implementare**: Adăugate ghiduri de implementare specifice și acționabile în toate secțiunile

## 16 Iulie 2025

### Îmbunătățiri README și navigare
- Redesign complet al navigării curriculumului în README.md
- Înlocuite etichetele `<details>` cu format bazat pe tabel mai accesibil
<<<<<<< HEAD
- Create opțiuni de layout alternative în noul folder "alternative_layouts"
=======
- Create opțiuni alternative de layout în noul folder "alternative_layouts"
>>>>>>> origin/main
- Adăugate exemple de navigare în stil carduri, taburi și acordeon
- Actualizată secțiunea de structură a depozitului pentru a include toate fișierele recente
- Îmbunătățită secțiunea "Cum să folosești acest curriculum" cu recomandări clare
- Actualizate linkurile la specificația MCP pentru a indica URL-urile corecte
- Adăugată secțiunea de Inginerie Contextuală (5.14) în structura curriculumului

### Actualizări ale ghidului de studiu
- Revizuire completă a ghidului de studiu pentru alinierea la structura actuală a depozitului
<<<<<<< HEAD
- Adăugate secțiuni noi pentru Clienți și Instrumente MCP și Servere MCP populare
=======
- Adăugate secțiuni noi pentru Clienți MCP și Instrumente, și Servere MCP populare
>>>>>>> origin/main
- Actualizată Harta Vizuală a Curriculumului pentru a reflecta toate subiectele
- Îmbunătățite descrierile subiectelor avansate pentru a acoperi toate domeniile specializate
- Actualizată secțiunea Studii de Caz pentru a reflecta exemple reale
- Adăugat acest jurnal de modificări cuprinzător

### Contribuții comunitare (06-CommunityContributions/)
- Adăugate informații detaliate despre serverele MCP pentru generarea de imagini
- Adăugată secțiune cuprinzătoare despre utilizarea Claude în VSCode
- Adăugate instrucțiuni de configurare și utilizare pentru clientul terminal Cline
<<<<<<< HEAD
- Actualizată secțiunea de clienți MCP pentru a include toate opțiunile populare
=======
- Actualizată secțiunea de clienți MCP pentru a include toate opțiunile populare de client
>>>>>>> origin/main
- Îmbunătățite exemplele de contribuții cu mostre de cod mai precise

### Subiecte avansate (05-AdvancedTopics/)
- Organizate toate folderele de subiecte specializate cu denumiri consistente
- Adăugate materiale și exemple de inginerie contextuală
<<<<<<< HEAD
- Adăugată documentația de integrare a agentului Foundry
=======
- Adăugată documentație de integrare pentru agenții Foundry
>>>>>>> origin/main
- Îmbunătățită documentația de integrare a securității Entra ID

## 11 Iunie 2025

### Creare inițială
- Lansată prima versiune a curriculumului MCP pentru Începători
- Creată structura de bază pentru toate cele 10 secțiuni principale
- Implementată Harta Vizuală a Curriculumului pentru navigare
- Adăugate proiecte de probă inițiale în mai multe limbaje de programare

### Început (03-GettingStarted/)
- Create primele exemple de implementare a serverului
<<<<<<< HEAD
- Adăugate ghiduri pentru dezvoltarea clienților
- Incluse instrucțiuni de integrare a clienților LLM
- Adăugată documentația de integrare VS Code
=======
- Adăugate ghiduri pentru dezvoltarea clientului
- Incluse instrucțiuni de integrare a clientului LLM
- Adăugată documentație de integrare VS Code
>>>>>>> origin/main
- Implementate exemple de server Server-Sent Events (SSE)

### Concepte de bază (01-CoreConcepts/)
- Adăugată explicație detaliată a arhitecturii client-server
<<<<<<< HEAD
- Creată documentația despre componentele cheie ale protocolului
=======
- Creată documentație despre componentele cheie ale protocolului
>>>>>>> origin/main
- Documentate modelele de mesagerie în MCP

## 23 Mai 2025

### Structura depozitului
- Inițializat depozitul cu structura de foldere de bază
- Create fișiere README pentru fiecare secțiune majoră
- Configurată infrastructura de traducere
<<<<<<< HEAD
- Adăugate resurse vizuale și diagrame
=======
- Adăugate resurse de imagini și diagrame
>>>>>>> origin/main

### Documentație
- Creat README.md inițial cu o privire de ansamblu asupra curriculumului
- Adăugate CODE_OF_CONDUCT.md și SECURITY.md
- Configurat SUPPORT.md cu ghiduri pentru obținerea de ajutor
<<<<<<< HEAD
- Creat structura preliminară a ghidului de studiu
=======
- Creată structura preliminară a ghidului de studiu
>>>>>>> origin/main

## 15 Aprilie 2025

### Planificare și cadru
- Planificare inițială pentru curriculumul MCP pentru Începători
- Definite obiectivele de învățare și publicul țintă
- Schițată structura în 10 secțiuni a curriculumului
- Dezvoltat cadru conceptual pentru exemple și studii de caz
- Create prototipuri inițiale pentru concepte cheie

<<<<<<< HEAD
**Declinarea responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși depunem eforturi pentru a asigura acuratețea, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.
=======
**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa natală ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.
>>>>>>> origin/main
