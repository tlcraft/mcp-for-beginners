<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:32:44+00:00",
  "source_file": "changelog.md",
  "language_code": "ro"
}
-->
# Jurnal de modificări: Curriculum MCP pentru Începători

Acest document servește ca o înregistrare a tuturor modificărilor semnificative aduse curriculumului Model Context Protocol (MCP) pentru Începători. Modificările sunt documentate în ordine invers cronologică (cele mai recente modificări primele).

## 15 Septembrie 2025

### Extinderea Subiectelor Avansate - Transporturi Personalizate & Ingineria Contextului

#### Transporturi Personalizate MCP (05-AdvancedTopics/mcp-transport/) - Ghid Nou de Implementare Avansată
- **README.md**: Ghid complet de implementare pentru mecanismele de transport personalizate MCP
  - **Transport Azure Event Grid**: Implementare serverless completă pentru transport bazat pe evenimente
    - Exemple în C#, TypeScript și Python cu integrare Azure Functions
    - Modele de arhitectură bazate pe evenimente pentru soluții MCP scalabile
    - Receptori webhook și gestionarea mesajelor bazată pe push
  - **Transport Azure Event Hubs**: Implementare de transport pentru streaming de mare viteză
    - Capacități de streaming în timp real pentru scenarii cu latență redusă
    - Strategii de partiționare și gestionarea punctelor de control
    - Optimizarea performanței și gruparea mesajelor
  - **Modele de Integrare Enterprise**: Exemple arhitecturale pregătite pentru producție
    - Procesare distribuită MCP prin multiple funcții Azure
    - Arhitecturi hibride de transport care combină mai multe tipuri de transport
    - Strategii de durabilitate, fiabilitate și gestionare a erorilor
  - **Securitate & Monitorizare**: Integrare Azure Key Vault și modele de observabilitate
    - Autentificare cu identitate gestionată și acces cu privilegii minime
    - Telemetrie Application Insights și monitorizarea performanței
    - Modele de toleranță la erori și întrerupătoare de circuit
  - **Framework-uri de Testare**: Strategii cuprinzătoare de testare pentru transporturi personalizate
    - Testare unitară cu dubluri de test și framework-uri de simulare
    - Testare de integrare cu Azure Test Containers
    - Considerații pentru testarea performanței și încărcării

#### Ingineria Contextului (05-AdvancedTopics/mcp-contextengineering/) - Disciplină Emergentă AI
- **README.md**: Explorare cuprinzătoare a ingineriei contextului ca domeniu emergent
  - **Principii de Bază**: Partajare completă a contextului, conștientizarea deciziilor de acțiune și gestionarea ferestrei de context
  - **Alinierea la Protocolul MCP**: Cum designul MCP abordează provocările ingineriei contextului
    - Limitările ferestrei de context și strategii de încărcare progresivă
    - Determinarea relevanței și recuperarea dinamică a contextului
    - Gestionarea contextului multi-modal și considerații de securitate
  - **Abordări de Implementare**: Arhitecturi single-threaded vs. multi-agent
    - Tehnici de fragmentare și prioritizare a contextului
    - Încărcare progresivă a contextului și strategii de compresie
    - Abordări stratificate ale contextului și optimizarea recuperării
  - **Framework de Măsurare**: Metrici emergente pentru evaluarea eficienței contextului
    - Eficiența inputului, performanța, calitatea și considerațiile privind experiența utilizatorului
    - Abordări experimentale pentru optimizarea contextului
    - Analiza eșecurilor și metodologii de îmbunătățire

#### Actualizări de Navigare în Curriculum (README.md)
- **Structură Modulară Îmbunătățită**: Tabelul curriculumului actualizat pentru a include subiectele avansate noi
  - Adăugate Ingineria Contextului (5.14) și Transport Personalizat (5.15)
  - Formatare consistentă și linkuri de navigare în toate modulele
  - Descrieri actualizate pentru a reflecta domeniul de conținut actual

### Îmbunătățiri ale Structurii Directorului
- **Standardizare Denumiri**: Redenumit "mcp transport" în "mcp-transport" pentru consistență cu alte foldere de subiecte avansate
- **Organizare Conținut**: Toate folderele 05-AdvancedTopics urmează acum un model de denumire consistent (mcp-[subiect])

### Îmbunătățiri ale Calității Documentației
- **Aliniere la Specificația MCP**: Tot conținutul nou face referire la Specificația MCP actuală 2025-06-18
- **Exemple Multi-Limbaj**: Exemple de cod cuprinzătoare în C#, TypeScript și Python
- **Focus Enterprise**: Modele pregătite pentru producție și integrare cloud Azure pe tot parcursul
- **Documentație Vizuală**: Diagrame Mermaid pentru vizualizarea arhitecturii și fluxurilor

## 18 August 2025

### Actualizare Cuprinzătoare a Documentației - Standarde MCP 2025-06-18

#### Cele Mai Bune Practici de Securitate MCP (02-Security/) - Modernizare Completă
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Rescriere completă aliniată la Specificația MCP 2025-06-18
  - **Cerințe Obligatorii**: Adăugate cerințe explicite MUST/MUST NOT din specificația oficială cu indicatori vizuali clari
  - **12 Practici Fundamentale de Securitate**: Restructurate dintr-o listă de 15 elemente în domenii de securitate cuprinzătoare
    - Securitatea Token-urilor & Autentificare cu integrarea furnizorilor de identitate externi
    - Managementul Sesiunilor & Securitatea Transportului cu cerințe criptografice
    - Protecția împotriva Amenințărilor AI cu integrarea Microsoft Prompt Shields
    - Controlul Accesului & Permisiuni cu principiul privilegiului minim
    - Siguranța Conținutului & Monitorizare cu integrarea Azure Content Safety
    - Securitatea Lanțului de Aprovizionare cu verificarea cuprinzătoare a componentelor
    - Securitatea OAuth & Prevenirea Atacurilor Confused Deputy cu implementarea PKCE
    - Răspuns la Incidente & Recuperare cu capabilități automatizate
    - Conformitate & Guvernanță cu aliniere la reglementări
    - Controale Avansate de Securitate cu arhitectură zero trust
    - Integrarea Ecosistemului de Securitate Microsoft cu soluții cuprinzătoare
    - Evoluția Continuă a Securității cu practici adaptive
  - **Soluții de Securitate Microsoft**: Ghid de integrare îmbunătățit pentru Prompt Shields, Azure Content Safety, Entra ID și GitHub Advanced Security
  - **Resurse de Implementare**: Linkuri cuprinzătoare de resurse categorisite după Documentația Oficială MCP, Soluții de Securitate Microsoft, Standarde de Securitate și Ghiduri de Implementare

#### Controale Avansate de Securitate (02-Security/) - Implementare Enterprise
- **MCP-SECURITY-CONTROLS-2025.md**: Restructurare completă cu un cadru de securitate de nivel enterprise
  - **9 Domenii Cuprinzătoare de Securitate**: Extinse de la controale de bază la un cadru detaliat de nivel enterprise
    - Autentificare & Autorizare Avansată cu integrarea Microsoft Entra ID
    - Securitatea Token-urilor & Controale Anti-Passthrough cu validare cuprinzătoare
    - Controale de Securitate ale Sesiunilor cu prevenirea deturnării
    - Controale de Securitate AI-Specifice cu prevenirea injecției de prompturi și otrăvirii instrumentelor
    - Prevenirea Atacurilor Confused Deputy cu securitatea proxy OAuth
    - Securitatea Execuției Instrumentelor cu sandboxing și izolare
    - Controale de Securitate ale Lanțului de Aprovizionare cu verificarea dependențelor
    - Controale de Monitorizare & Detectare cu integrarea SIEM
    - Răspuns la Incidente & Recuperare cu capabilități automatizate
  - **Exemple de Implementare**: Adăugate blocuri de configurare YAML detaliate și exemple de cod
  - **Integrarea Soluțiilor Microsoft**: Acoperire cuprinzătoare a serviciilor de securitate Azure, GitHub Advanced Security și managementul identității enterprise

#### Subiecte Avansate de Securitate (05-AdvancedTopics/mcp-security/) - Implementare Pregătită pentru Producție
- **README.md**: Rescriere completă pentru implementarea securității enterprise
  - **Aliniere la Specificația Curentă**: Actualizat la Specificația MCP 2025-06-18 cu cerințe obligatorii de securitate
  - **Autentificare Îmbunătățită**: Integrare Microsoft Entra ID cu exemple cuprinzătoare în .NET și Java Spring Security
  - **Integrare Securitate AI**: Implementare Microsoft Prompt Shields și Azure Content Safety cu exemple detaliate în Python
  - **Mitigare Avansată a Amenințărilor**: Exemple de implementare cuprinzătoare pentru
    - Prevenirea Atacurilor Confused Deputy cu PKCE și validarea consimțământului utilizatorului
    - Prevenirea Passthrough Token cu validarea audienței și gestionarea securizată a token-urilor
    - Prevenirea Deturnării Sesiunilor cu legare criptografică și analiză comportamentală
  - **Integrare Securitate Enterprise**: Monitorizare Application Insights Azure, pipeline-uri de detectare a amenințărilor și securitatea lanțului de aprovizionare
  - **Lista de Verificare a Implementării**: Controale de securitate obligatorii vs. recomandate cu beneficii ale ecosistemului de securitate Microsoft

### Îmbunătățiri ale Calității Documentației & Aliniere la Standarde
- **Referințe la Specificație**: Actualizate toate referințele la Specificația MCP curentă 2025-06-18
- **Ecosistemul de Securitate Microsoft**: Ghid de integrare îmbunătățit pe tot parcursul documentației de securitate
- **Implementare Practică**: Adăugate exemple de cod detaliate în .NET, Java și Python cu modele enterprise
- **Organizare Resurse**: Categorisire cuprinzătoare a documentației oficiale, standardelor de securitate și ghidurilor de implementare
- **Indicatori Vizuali**: Marcarea clară a cerințelor obligatorii vs. practicilor recomandate

#### Concepte Fundamentale (01-CoreConcepts/) - Modernizare Completă
- **Actualizare Versiune Protocol**: Actualizat pentru a face referire la Specificația MCP curentă 2025-06-18 cu versiuni bazate pe dată (format YYYY-MM-DD)
- **Rafinare Arhitectură**: Descrieri îmbunătățite ale Gazdelor, Clienților și Serverelor pentru a reflecta modelele actuale de arhitectură MCP
  - Gazdele sunt acum definite clar ca aplicații AI care coordonează multiple conexiuni client MCP
  - Clienții descriși ca conectori de protocol care mențin relații unu-la-unu cu serverele
  - Serverele îmbunătățite cu scenarii de implementare locală vs. la distanță
- **Restructurare Primitivă**: Restructurare completă a primitivelor server și client
  - Primitive Server: Resurse (surse de date), Prompturi (șabloane), Instrumente (funcții executabile) cu explicații și exemple detaliate
  - Primitive Client: Sampling (completări LLM), Elicitare (input utilizator), Logging (debugging/monitorizare)
  - Actualizat cu modelele curente de descoperire (`*/list`), recuperare (`*/get`) și execuție (`*/call`)
- **Arhitectură Protocol**: Introducerea unui model de arhitectură pe două straturi
  - Strat de Date: Fundație JSON-RPC 2.0 cu gestionarea ciclului de viață și primitive
  - Strat de Transport: STDIO (local) și HTTP Streamable cu SSE (la distanță)
- **Framework de Securitate**: Principii de securitate cuprinzătoare incluzând consimțământ explicit al utilizatorului, protecția confidențialității datelor, siguranța execuției instrumentelor și securitatea stratului de transport
- **Modele de Comunicare**: Mesaje de protocol actualizate pentru a arăta inițializarea, descoperirea, execuția și fluxurile de notificare
- **Exemple de Cod**: Exemple multi-limbaj actualizate (.NET, Java, Python, JavaScript) pentru a reflecta modelele SDK MCP curente

#### Securitate (02-Security/) - Restructurare Completă a Securității  
- **Aliniere la Standarde**: Aliniere completă cu cerințele de securitate ale Specificației MCP 2025-06-18
- **Evoluția Autentificării**: Documentată evoluția de la servere OAuth personalizate la delegarea furnizorilor de identitate externi (Microsoft Entra ID)
- **Analiza Amenințărilor AI-Specifice**: Acoperire îmbunătățită a vectorilor moderni de atac AI
  - Scenarii detaliate de atac prin injecție de prompturi cu exemple din lumea reală
  - Mecanisme de otrăvire a instrumentelor și modele de atac "rug pull"
  - Otrăvirea ferestrei de context și atacuri de confuzie a modelului
- **Soluții de Securitate AI Microsoft**: Acoperire cuprinzătoare a ecosistemului de securitate Microsoft
  - Prompt Shields AI cu tehnici avansate de detectare, evidențiere și delimitare
  - Modele de integrare Azure Content Safety
  - GitHub Advanced Security pentru protecția lanțului de aprovizionare
- **Mitigare Avansată a Amenințărilor**: Controale de securitate detaliate pentru
  - Deturnarea sesiunilor cu scenarii de atac specifice MCP și cerințe criptografice pentru ID-ul sesiunii
  - Problemele Confused Deputy în scenarii proxy MCP cu cerințe explicite de consimțământ
  - Vulnerabilități Passthrough Token cu controale obligatorii de validare
- **Securitatea Lanțului de Aprovizionare**: Acoperire extinsă a lanțului de aprovizionare AI incluzând modele fundamentale, servicii de embedding, furnizori de context și API-uri terțe
- **Securitate Fundamentală**: Integrare îmbunătățită cu modelele de securitate enterprise incluzând arhitectura zero trust și ecosistemul de securitate Microsoft
- **Organizare Resurse**: Categorisire cuprinzătoare a linkurilor de resurse oficiale, standarde, cercetare, soluții Microsoft și ghiduri de implementare

### Îmbunătățiri ale Calității Documentației
- **Obiective Structurate de Învățare**: Obiective de învățare îmbunătățite cu rezultate specifice și acționabile 
- **Referințe Încrucișate**: Adăugate linkuri între subiectele de securitate și concepte fundamentale conexe
- **Informații Curente**: Actualizate toate referințele de dată și linkurile la specificații la standardele curente
- **Ghiduri de Implementare**: Adăugate ghiduri de implementare specifice și acționabile în toate secțiunile

---

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa natală ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.