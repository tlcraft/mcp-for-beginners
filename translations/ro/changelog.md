<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T21:41:09+00:00",
  "source_file": "changelog.md",
  "language_code": "ro"
}
-->
# Jurnal de modificări: Curriculum MCP pentru Începători

Acest document servește ca un registru al tuturor modificărilor semnificative aduse curriculumului Model Context Protocol (MCP) pentru Începători. Modificările sunt documentate în ordine invers cronologică (cele mai recente modificări primele).

## 29 septembrie 2025

### Laboratoare de integrare a bazei de date MCP Server - Parcurs de învățare practic și cuprinzător

#### 11-MCPServerHandsOnLabs - Curriculum complet pentru integrarea bazei de date
- **Parcurs de învățare cu 13 laboratoare complete**: Adăugat curriculum practic cuprinzător pentru construirea serverelor MCP pregătite pentru producție, cu integrare PostgreSQL
  - **Implementare în lumea reală**: Studiu de caz Zava Retail Analytics demonstrând modele de nivel enterprise
  - **Progresie structurată a învățării**:
    - **Laboratoare 00-03: Fundamente** - Introducere, Arhitectură de bază, Securitate și Multi-Tenancy, Configurarea mediului
    - **Laboratoare 04-06: Construirea serverului MCP** - Design și schemă de bază de date, Implementarea serverului MCP, Dezvoltarea instrumentelor  
    - **Laboratoare 07-09: Funcționalități avansate** - Integrarea căutării semantice, Testare și depanare, Integrare VS Code
    - **Laboratoare 10-12: Producție și bune practici** - Strategii de implementare, Monitorizare și observabilitate, Optimizare și bune practici
  - **Tehnologii enterprise**: Framework FastMCP, PostgreSQL cu pgvector, Azure OpenAI embeddings, Azure Container Apps, Application Insights
  - **Funcționalități avansate**: Securitate la nivel de rând (RLS), căutare semantică, acces multi-tenant la date, vector embeddings, monitorizare în timp real

#### Standardizarea terminologiei - Conversia modulelor în laboratoare
- **Actualizare cuprinzătoare a documentației**: Actualizate sistematic toate fișierele README din 11-MCPServerHandsOnLabs pentru a utiliza terminologia "Laborator" în loc de "Modul"
  - **Titluri de secțiuni**: Modificat "Ce acoperă acest modul" în "Ce acoperă acest laborator" în toate cele 13 laboratoare
  - **Descrierea conținutului**: Schimbat "Acest modul oferă..." în "Acest laborator oferă..." în întreaga documentație
  - **Obiective de învățare**: Actualizat "Până la sfârșitul acestui modul..." în "Până la sfârșitul acestui laborator..."
  - **Linkuri de navigare**: Convertit toate referințele "Modul XX:" în "Laborator XX:" în referințe încrucișate și navigare
  - **Urmărirea progresului**: Actualizat "După finalizarea acestui modul..." în "După finalizarea acestui laborator..."
  - **Referințe tehnice păstrate**: Menținut referințele la modulele Python în fișierele de configurare (ex.: `"module": "mcp_server.main"`)

#### Îmbunătățirea ghidului de studiu (study_guide.md)
- **Hartă vizuală a curriculumului**: Adăugată noua secțiune "11. Laboratoare de integrare a bazei de date" cu vizualizarea structurii complete a laboratoarelor
- **Structura depozitului**: Actualizat de la zece la unsprezece secțiuni principale cu descriere detaliată a 11-MCPServerHandsOnLabs
- **Ghid pentru parcursul de învățare**: Instrucțiuni de navigare îmbunătățite pentru a acoperi secțiunile 00-11
- **Acoperirea tehnologiilor**: Adăugate detalii despre integrarea FastMCP, PostgreSQL și serviciile Azure
- **Rezultate ale învățării**: Accent pe dezvoltarea serverelor pregătite pentru producție, modele de integrare a bazelor de date și securitate enterprise

#### Îmbunătățirea structurii README principale
- **Terminologie bazată pe laboratoare**: Actualizat README.md principal în 11-MCPServerHandsOnLabs pentru a utiliza în mod constant structura "Laborator"
- **Organizarea parcursului de învățare**: Progresie clară de la concepte fundamentale la implementare avansată și implementare în producție
- **Accent pe lumea reală**: Emfază pe învățarea practică, cu modele și tehnologii de nivel enterprise

### Îmbunătățiri ale calității și consistenței documentației
- **Accent pe învățarea practică**: Consolidat abordarea practică, bazată pe laboratoare, în întreaga documentație
- **Focalizare pe modele enterprise**: Evidențiat implementările pregătite pentru producție și considerațiile de securitate enterprise
- **Integrarea tehnologiilor**: Acoperire cuprinzătoare a serviciilor moderne Azure și modelelor de integrare AI
- **Progresie în învățare**: Parcurs clar și structurat de la concepte de bază la implementare în producție

## 26 septembrie 2025

### Îmbunătățirea studiilor de caz - Integrarea registrului MCP GitHub

#### Studii de caz (09-CaseStudy/) - Focalizare pe dezvoltarea ecosistemului
- **README.md**: Extindere majoră cu studiu de caz cuprinzător despre registrul MCP GitHub
  - **Studiu de caz Registrul MCP GitHub**: Nou studiu de caz cuprinzător examinând lansarea registrului MCP GitHub în septembrie 2025
    - **Analiza problemei**: Examinare detaliată a provocărilor fragmentării descoperirii și implementării serverelor MCP
    - **Arhitectura soluției**: Abordarea registrului centralizat GitHub cu instalare cu un singur clic în VS Code
    - **Impactul asupra afacerii**: Îmbunătățiri măsurabile în onboarding-ul și productivitatea dezvoltatorilor
    - **Valoare strategică**: Accent pe implementarea modulară a agenților și interoperabilitatea între instrumente
    - **Dezvoltarea ecosistemului**: Poziționare ca platformă fundamentală pentru integrarea agentică
  - **Structură îmbunătățită a studiilor de caz**: Actualizate toate cele șapte studii de caz cu formatare consistentă și descrieri cuprinzătoare
    - Agenți AI pentru călătorii Azure: Accent pe orchestrarea multi-agent
    - Integrarea Azure DevOps: Focalizare pe automatizarea fluxurilor de lucru
    - Recuperarea documentației în timp real: Implementare client Python în consolă
    - Generator interactiv de planuri de studiu: Aplicație web conversațională Chainlit
    - Documentație în editor: Integrare VS Code și GitHub Copilot
    - Managementul API Azure: Modele de integrare API enterprise
    - Registrul MCP GitHub: Dezvoltarea ecosistemului și platforma comunității
  - **Concluzie cuprinzătoare**: Rescrisă secțiunea de concluzie evidențiind cele șapte studii de caz care acoperă multiple dimensiuni ale implementării MCP
    - Integrare enterprise, orchestrare multi-agent, productivitatea dezvoltatorilor
    - Dezvoltarea ecosistemului, aplicații educaționale
    - Perspective îmbunătățite asupra modelelor arhitecturale, strategiilor de implementare și bunelor practici
    - Accent pe MCP ca protocol matur, pregătit pentru producție

#### Actualizări ale ghidului de studiu (study_guide.md)
- **Hartă vizuală a curriculumului**: Actualizat mindmap-ul pentru a include Registrul MCP GitHub în secțiunea Studii de caz
- **Descrierea studiilor de caz**: Îmbunătățită de la descrieri generice la detalii despre cele șapte studii de caz cuprinzătoare
- **Structura depozitului**: Secțiunea 10 actualizată pentru a reflecta acoperirea cuprinzătoare a studiilor de caz cu detalii specifice de implementare
- **Integrarea jurnalului de modificări**: Adăugată intrarea din 26 septembrie 2025 documentând adăugarea Registrului MCP GitHub și îmbunătățirile studiilor de caz
- **Actualizări de dată**: Actualizat timestamp-ul din subsol pentru a reflecta ultima revizuire (26 septembrie 2025)

### Îmbunătățiri ale calității documentației
- **Îmbunătățirea consistenței**: Formatare și structură standardizate pentru toate cele șapte exemple de studii de caz
- **Acoperire cuprinzătoare**: Studiile de caz acoperă acum scenarii enterprise, productivitatea dezvoltatorilor și dezvoltarea ecosistemului
- **Poziționare strategică**: Accent îmbunătățit pe MCP ca platformă fundamentală pentru implementarea sistemelor agentice
- **Integrarea resurselor**: Actualizat resursele suplimentare pentru a include linkul Registrului MCP GitHub

## 15 septembrie 2025

### Extinderea subiectelor avansate - Transporturi personalizate și ingineria contextului

#### Transporturi personalizate MCP (05-AdvancedTopics/mcp-transport/) - Nou ghid de implementare avansată
- **README.md**: Ghid complet de implementare pentru mecanismele de transport personalizate MCP
  - **Transport Azure Event Grid**: Implementare completă serverless bazată pe evenimente
    - Exemple în C#, TypeScript și Python cu integrare Azure Functions
    - Modele de arhitectură bazate pe evenimente pentru soluții MCP scalabile
    - Receptoare webhook și gestionarea mesajelor push
  - **Transport Azure Event Hubs**: Implementare de transport pentru streaming de mare viteză
    - Capacități de streaming în timp real pentru scenarii cu latență redusă
    - Strategii de partiționare și gestionarea punctelor de control
    - Optimizarea performanței și gruparea mesajelor
  - **Modele de integrare enterprise**: Exemple arhitecturale pregătite pentru producție
    - Procesare distribuită MCP pe mai multe funcții Azure
    - Arhitecturi hibride de transport combinând mai multe tipuri de transport
    - Durabilitatea mesajelor, fiabilitate și strategii de gestionare a erorilor
  - **Securitate și monitorizare**: Integrare Azure Key Vault și modele de observabilitate
    - Autentificare cu identitate gestionată și acces cu privilegii minime
    - Telemetrie Application Insights și monitorizarea performanței
    - Modele de toleranță la erori și întrerupătoare de circuit
  - **Framework-uri de testare**: Strategii cuprinzătoare de testare pentru transporturi personalizate
    - Testare unitară cu dubluri de test și framework-uri de simulare
    - Testare de integrare cu containere de test Azure
    - Considerații pentru testarea performanței și încărcării

#### Ingineria contextului (05-AdvancedTopics/mcp-contextengineering/) - Disciplină emergentă AI
- **README.md**: Explorare cuprinzătoare a ingineriei contextului ca domeniu emergent
  - **Principii de bază**: Partajare completă a contextului, conștientizare a deciziilor de acțiune și gestionarea ferestrei de context
  - **Alinierea la protocolul MCP**: Cum designul MCP abordează provocările ingineriei contextului
    - Limitările ferestrei de context și strategii de încărcare progresivă
    - Determinarea relevanței și recuperarea dinamică a contextului
    - Gestionarea contextului multi-modal și considerații de securitate
  - **Abordări de implementare**: Arhitecturi single-threaded vs. multi-agent
    - Tehnici de fragmentare și prioritizare a contextului
    - Încărcare progresivă a contextului și strategii de compresie
    - Abordări stratificate ale contextului și optimizarea recuperării
  - **Framework de măsurare**: Metrici emergente pentru evaluarea eficienței contextului
    - Eficiența inputului, performanța, calitatea și considerațiile experienței utilizatorului
    - Abordări experimentale pentru optimizarea contextului
    - Analiza eșecurilor și metodologii de îmbunătățire

#### Actualizări de navigare în curriculum (README.md)
- **Structură îmbunătățită a modulelor**: Actualizat tabelul curriculumului pentru a include subiectele avansate noi
  - Adăugate Ingineria Contextului (5.14) și Transport Personalizat (5.15)
  - Formatare și linkuri de navigare consistente în toate modulele
  - Descrieri actualizate pentru a reflecta domeniul actual al conținutului

### Îmbunătățiri ale structurii directoarelor
- **Standardizarea denumirilor**: Redenumit "mcp transport" în "mcp-transport" pentru consistență cu alte foldere de subiecte avansate
- **Organizarea conținutului**: Toate folderele 05-AdvancedTopics urmează acum un model de denumire consistent (mcp-[subiect])

### Îmbunătățiri ale calității documentației
- **Alinierea la specificația MCP**: Tot conținutul nou face referire la specificația MCP actuală 2025-06-18
- **Exemple multi-limbaj**: Exemple de cod cuprinzătoare în C#, TypeScript și Python
- **Focalizare enterprise**: Modele pregătite pentru producție și integrare cloud Azure în întreaga documentație
- **Documentație vizuală**: Diagrame Mermaid pentru vizualizarea arhitecturii și fluxurilor

## 18 august 2025

### Actualizare cuprinzătoare a documentației - Standarde MCP 2025-06-18

#### Bune practici de securitate MCP (02-Security/) - Modernizare completă
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Rescriere completă aliniată la specificația MCP 2025-06-18
  - **Cerințe obligatorii**: Adăugate cerințe explicite MUST/MUST NOT din specificația oficială cu indicatori vizuali clari
  - **12 Practici de securitate de bază**: Restructurate de la o listă de 15 elemente la domenii de securitate cuprinzătoare
    - Securitatea token-urilor și autentificarea cu integrarea furnizorului extern de identitate
    - Managementul sesiunilor și securitatea transportului cu cerințe criptografice
    - Protecția împotriva amenințărilor AI cu integrarea Microsoft Prompt Shields
    - Controlul accesului și permisiunilor cu principiul privilegiului minim
    - Siguranța conținutului și monitorizarea cu integrarea Azure Content Safety
    - Securitatea lanțului de aprovizionare cu verificarea cuprinzătoare a componentelor
    - Securitatea OAuth și prevenirea atacurilor Confused Deputy cu implementarea PKCE
    - Răspuns la incidente și recuperare cu capabilități automatizate
    - Conformitate și guvernanță cu aliniere la reglementări
    - Controale avansate de securitate cu arhitectură zero trust
    - Integrarea ecosistemului de securitate Microsoft cu soluții cuprinzătoare
    - Evoluția continuă a securității cu practici adaptive
  - **Soluții de securitate Microsoft**: Ghid de integrare îmbunătățit pentru Prompt Shields, Azure Content Safety, Entra ID și GitHub Advanced Security
  - **Resurse de implementare**: Linkuri de resurse cuprinzătoare categorisite după Documentația oficială MCP, Soluții de securitate Microsoft, Standarde de securitate și Ghiduri de implementare

#### Controale avansate de securitate (02-Security/) - Implementare enterprise
- **MCP-SECURITY-CONTROLS-2025.md**: Revizuire completă cu cadru de securitate de nivel enterprise
  - **9 Domenii de securitate cuprinzătoare**: Extinse de la controale de bază la cadru detaliat enterprise
    - Autentificare și autorizare avansată cu integrarea Microsoft Entra ID
    - Securitatea token-urilor și controale anti-passthrough cu validare cuprinzătoare
    - Controale de securitate ale sesiunii cu prevenirea deturnării
    - Controale de securitate specifice AI cu prevenirea injecției de prompturi și otrăvirii instrumentelor
    - Prevenirea atacurilor Confused Deputy cu securitatea proxy OAuth
    - Securitatea execuției instrumentelor cu sandboxing și izolare
    - Controale de securitate ale lanțului de aprovizionare cu verificarea dependențelor
    - Controale de monitorizare și detectare cu integrarea SIEM
    - Răspuns la incidente și recuperare cu capabilități automatizate
  - **Exemple de implementare**: Adăugate blocuri de configurare YAML detali
- **Indicatori Vizuali**: Marcarea clară a cerințelor obligatorii față de practicile recomandate

#### Concepte de Bază (01-CoreConcepts/) - Modernizare Completă
- **Actualizare Versiune Protocol**: Actualizat pentru a face referire la specificația MCP curentă 2025-06-18 cu versiuni bazate pe dată (format YYYY-MM-DD)
- **Rafinarea Arhitecturii**: Descrieri îmbunătățite ale Gazdelor, Clienților și Serverelor pentru a reflecta modelele actuale de arhitectură MCP
  - Gazdele sunt acum definite clar ca aplicații AI care coordonează multiple conexiuni ale clienților MCP
  - Clienții sunt descriși ca conectori de protocol care mențin relații unu-la-unu cu serverele
  - Serverele sunt îmbunătățite cu scenarii de implementare locală vs. la distanță
- **Restructurarea Primitivelor**: Revizuire completă a primitivelor server și client
  - Primitve Server: Resurse (surse de date), Prompts (șabloane), Instrumente (funcții executabile) cu explicații și exemple detaliate
  - Primitive Client: Sampling (completări LLM), Elicitation (input utilizator), Logging (debugging/monitorizare)
  - Actualizat cu modelele curente de descoperire (`*/list`), recuperare (`*/get`) și execuție (`*/call`)
- **Arhitectura Protocolului**: Introducerea unui model de arhitectură pe două straturi
  - Strat de Date: Fundament JSON-RPC 2.0 cu gestionarea ciclului de viață și primitive
  - Strat de Transport: STDIO (local) și HTTP Streamable cu SSE (la distanță)
- **Cadru de Securitate**: Principii de securitate cuprinzătoare, inclusiv consimțământ explicit al utilizatorului, protecția confidențialității datelor, siguranța execuției instrumentelor și securitatea stratului de transport
- **Modele de Comunicare**: Mesaje de protocol actualizate pentru a arăta fluxurile de inițializare, descoperire, execuție și notificare
- **Exemple de Cod**: Exemple multi-limbaj actualizate (.NET, Java, Python, JavaScript) pentru a reflecta modelele curente MCP SDK

#### Securitate (02-Security/) - Revizuire Cuprinzătoare a Securității  
- **Aliniere la Standard**: Aliniere completă cu cerințele de securitate ale specificației MCP 2025-06-18
- **Evoluția Autentificării**: Documentarea evoluției de la servere OAuth personalizate la delegarea furnizorilor externi de identitate (Microsoft Entra ID)
- **Analiza Amenințărilor AI**: Acoperire extinsă a vectorilor moderni de atac AI
  - Scenarii detaliate de atac prin injectare de prompturi cu exemple reale
  - Mecanisme de otrăvire a instrumentelor și modele de atac "rug pull"
  - Otrăvirea ferestrei de context și atacuri de confuzie a modelului
- **Soluții de Securitate AI Microsoft**: Acoperire cuprinzătoare a ecosistemului de securitate Microsoft
  - AI Prompt Shields cu tehnici avansate de detectare, evidențiere și delimitare
  - Modele de integrare Azure Content Safety
  - GitHub Advanced Security pentru protecția lanțului de aprovizionare
- **Mitigarea Amenințărilor Avansate**: Controale de securitate detaliate pentru
  - Deturnarea sesiunii cu scenarii de atac specifice MCP și cerințe criptografice pentru ID-ul sesiunii
  - Probleme de confuzie a delegatului în scenarii proxy MCP cu cerințe de consimțământ explicit
  - Vulnerabilități de trecere a token-urilor cu controale obligatorii de validare
- **Securitatea Lanțului de Aprovizionare**: Acoperire extinsă a lanțului de aprovizionare AI, inclusiv modele fundamentale, servicii de încorporare, furnizori de context și API-uri terțe
- **Securitate Fundamentală**: Integrare îmbunătățită cu modelele de securitate enterprise, inclusiv arhitectura zero trust și ecosistemul de securitate Microsoft
- **Organizarea Resurselor**: Linkuri cuprinzătoare de resurse categorisite pe tip (Documentație Oficială, Standarde, Cercetare, Soluții Microsoft, Ghiduri de Implementare)

### Îmbunătățiri ale Calității Documentației
- **Obiective de Învățare Structurate**: Obiective de învățare îmbunătățite cu rezultate specifice și acționabile
- **Referințe Încrucișate**: Adăugarea de linkuri între subiecte de securitate și concepte de bază conexe
- **Informații Actuale**: Actualizarea tuturor referințelor de dată și linkurilor de specificație la standardele curente
- **Ghiduri de Implementare**: Adăugarea de ghiduri de implementare specifice și acționabile în ambele secțiuni

## 16 iulie 2025

### Îmbunătățiri README și Navigare
- Redesign complet al navigării curriculumului în README.md
- Înlocuirea tagurilor `<details>` cu format tabelar mai accesibil
- Crearea de opțiuni alternative de layout în noul folder "alternative_layouts"
- Adăugarea de exemple de navigare în stil carduri, taburi și acordeon
- Actualizarea secțiunii de structură a depozitului pentru a include toate fișierele recente
- Îmbunătățirea secțiunii "Cum să folosești acest curriculum" cu recomandări clare
- Actualizarea linkurilor de specificație MCP pentru a indica URL-urile corecte
- Adăugarea secțiunii de Inginerie Contextuală (5.14) în structura curriculumului

### Actualizări Ghid de Studiu
- Revizuirea completă a ghidului de studiu pentru a se alinia cu structura curentă a depozitului
- Adăugarea de secțiuni noi pentru Clienți MCP și Instrumente, și Servere MCP Populare
- Actualizarea Hărții Vizuale a Curriculumului pentru a reflecta toate subiectele
- Îmbunătățirea descrierilor subiectelor avansate pentru a acoperi toate domeniile specializate
- Actualizarea secțiunii de Studii de Caz pentru a reflecta exemple reale
- Adăugarea acestui changelog cuprinzător

### Contribuții Comunitare (06-CommunityContributions/)
- Adăugarea de informații detaliate despre serverele MCP pentru generarea de imagini
- Adăugarea unei secțiuni cuprinzătoare despre utilizarea Claude în VSCode
- Adăugarea instrucțiunilor de configurare și utilizare pentru clientul terminal Cline
- Actualizarea secțiunii de clienți MCP pentru a include toate opțiunile populare de clienți
- Îmbunătățirea exemplelor de contribuții cu mostre de cod mai precise

### Subiecte Avansate (05-AdvancedTopics/)
- Organizarea tuturor folderelor de subiecte specializate cu denumiri consistente
- Adăugarea de materiale și exemple de inginerie contextuală
- Adăugarea documentației de integrare a agenților Foundry
- Îmbunătățirea documentației de integrare a securității Entra ID

## 11 iunie 2025

### Creare Inițială
- Lansarea primei versiuni a curriculumului MCP pentru Începători
- Crearea structurii de bază pentru toate cele 10 secțiuni principale
- Implementarea Hărții Vizuale a Curriculumului pentru navigare
- Adăugarea proiectelor inițiale de exemplu în mai multe limbaje de programare

### Început (03-GettingStarted/)
- Crearea primelor exemple de implementare a serverului
- Adăugarea ghidului de dezvoltare a clienților
- Incluzionarea instrucțiunilor de integrare a clienților LLM
- Adăugarea documentației de integrare VS Code
- Implementarea exemplelor de server cu Server-Sent Events (SSE)

### Concepte de Bază (01-CoreConcepts/)
- Adăugarea unei explicații detaliate despre arhitectura client-server
- Crearea documentației despre componentele cheie ale protocolului
- Documentarea modelelor de mesagerie în MCP

## 23 mai 2025

### Structura Depozitului
- Inițializarea depozitului cu structura de foldere de bază
- Crearea fișierelor README pentru fiecare secțiune majoră
- Configurarea infrastructurii de traducere
- Adăugarea de resurse grafice și diagrame

### Documentație
- Crearea fișierului README.md inițial cu o privire de ansamblu asupra curriculumului
- Adăugarea CODE_OF_CONDUCT.md și SECURITY.md
- Configurarea SUPPORT.md cu ghiduri pentru obținerea de ajutor
- Crearea structurii preliminare a ghidului de studiu

## 15 aprilie 2025

### Planificare și Cadru
- Planificarea inițială pentru curriculumul MCP pentru Începători
- Definirea obiectivelor de învățare și a publicului țintă
- Schițarea structurii în 10 secțiuni a curriculumului
- Dezvoltarea cadrului conceptual pentru exemple și studii de caz
- Crearea prototipurilor inițiale de exemple pentru concepte cheie

---

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa natală ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.