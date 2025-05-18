<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:35:11+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "ro"
}
-->
# Studiu de caz: Agenți de călătorie Azure AI – Implementare de referință

## Prezentare generală

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) este o soluție de referință cuprinzătoare dezvoltată de Microsoft, care demonstrează cum să construiești o aplicație de planificare a călătoriilor bazată pe AI și multi-agent, folosind Model Context Protocol (MCP), Azure OpenAI și Azure AI Search. Acest proiect prezintă cele mai bune practici pentru orchestrarea mai multor agenți AI, integrarea datelor de întreprindere și furnizarea unei platforme sigure și extensibile pentru scenarii din lumea reală.

## Caracteristici cheie
- **Orchestrarea multi-agent:** Utilizează MCP pentru a coordona agenți specializați (de exemplu, agenți de zbor, hotel și itinerariu) care colaborează pentru a îndeplini sarcini complexe de planificare a călătoriilor.
- **Integrarea datelor de întreprindere:** Se conectează la Azure AI Search și alte surse de date de întreprindere pentru a oferi informații actualizate și relevante pentru recomandările de călătorie.
- **Arhitectură sigură și scalabilă:** Utilizează serviciile Azure pentru autentificare, autorizare și implementare scalabilă, urmând cele mai bune practici de securitate ale întreprinderii.
- **Instrumente extensibile:** Implementează instrumente MCP reutilizabile și șabloane de prompturi, permițând adaptarea rapidă la noi domenii sau cerințe de afaceri.
- **Experiența utilizatorului:** Oferă o interfață conversațională pentru utilizatori pentru a interacționa cu agenții de călătorie, alimentată de Azure OpenAI și MCP.

## Arhitectură
![Arhitectură](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Descrierea diagramei de arhitectură

Soluția Azure AI Travel Agents este proiectată pentru modularitate, scalabilitate și integrarea sigură a mai multor agenți AI și surse de date de întreprindere. Componentele principale și fluxul de date sunt următoarele:

- **Interfața utilizatorului:** Utilizatorii interacționează cu sistemul printr-o interfață conversațională (cum ar fi un chat web sau un bot Teams), care trimite întrebările utilizatorilor și primește recomandările de călătorie.
- **Serverul MCP:** Servește ca orchestrator central, primind inputul utilizatorului, gestionând contextul și coordonând acțiunile agenților specializați (de exemplu, FlightAgent, HotelAgent, ItineraryAgent) prin Model Context Protocol.
- **Agenții AI:** Fiecare agent este responsabil pentru un domeniu specific (zboruri, hoteluri, itinerarii) și este implementat ca un instrument MCP. Agenții folosesc șabloane de prompturi și logică pentru a procesa cererile și a genera răspunsuri.
- **Serviciul Azure OpenAI:** Oferă înțelegere și generare avansată a limbajului natural, permițând agenților să interpreteze intenția utilizatorului și să genereze răspunsuri conversaționale.
- **Azure AI Search & Date de întreprindere:** Agenții interoghează Azure AI Search și alte surse de date de întreprindere pentru a obține informații actualizate despre zboruri, hoteluri și opțiuni de călătorie.
- **Autentificare și securitate:** Integrează cu Microsoft Entra ID pentru autentificare sigură și aplică controale de acces cu cel mai mic privilegiu pentru toate resursele.
- **Implementare:** Proiectată pentru implementare pe Azure Container Apps, asigurând scalabilitate, monitorizare și eficiență operațională.

Această arhitectură permite orchestrarea fără probleme a mai multor agenți AI, integrarea sigură cu datele de întreprindere și o platformă robustă și extensibilă pentru construirea de soluții AI specifice domeniului.

## Explicație pas cu pas a diagramei de arhitectură
Imaginează-ți că planifici o călătorie mare și ai o echipă de asistenți experți care te ajută cu fiecare detaliu. Sistemul Azure AI Travel Agents funcționează într-un mod similar, folosind diferite părți (ca membri ai echipei) care au fiecare un rol special. Iată cum se potrivește totul:

### Interfața utilizatorului (UI):
Gândește-te la aceasta ca la recepția agentului tău de călătorie. Este locul unde tu (utilizatorul) pui întrebări sau faci cereri, cum ar fi „Găsește-mi un zbor spre Paris.” Acesta ar putea fi o fereastră de chat pe un site web sau o aplicație de mesagerie.

### Serverul MCP (Coordonatorul):
Serverul MCP este ca managerul care ascultă cererea ta la recepție și decide care specialist ar trebui să se ocupe de fiecare parte. Păstrează evidența conversației tale și se asigură că totul funcționează fără probleme.

### Agenții AI (Asistenți specialiști):
Fiecare agent este un expert într-un domeniu specific—unul știe totul despre zboruri, altul despre hoteluri și altul despre planificarea itinerariului tău. Când ceri o călătorie, serverul MCP trimite cererea ta agentului(i) potrivit(i). Acești agenți folosesc cunoștințele și instrumentele lor pentru a găsi cele mai bune opțiuni pentru tine.

### Serviciul Azure OpenAI (Expert în limbaj):
Este ca și cum ai avea un expert în limbaj care înțelege exact ce ceri, indiferent cum formulezi. Ajută agenții să înțeleagă cererile tale și să răspundă într-un limbaj natural, conversațional.

### Azure AI Search & Date de întreprindere (Biblioteca de informații):
Imaginează-ți o bibliotecă uriașă, actualizată, cu toate informațiile recente despre călătorii—orar de zboruri, disponibilitate hoteluri și altele. Agenții caută în această bibliotecă pentru a obține cele mai precise răspunsuri pentru tine.

### Autentificare și securitate (Gardianul de securitate):
La fel cum un gardian de securitate verifică cine poate intra în anumite zone, această parte se asigură că doar persoanele și agenții autorizați pot accesa informații sensibile. Îți păstrează datele în siguranță și private.

### Implementare pe Azure Container Apps (Clădirea):
Toți acești asistenți și instrumente lucrează împreună într-o clădire sigură și scalabilă (norul). Acest lucru înseamnă că sistemul poate gestiona mulți utilizatori simultan și este întotdeauna disponibil când ai nevoie de el.

## Cum funcționează totul împreună:

Începi prin a pune o întrebare la recepție (UI).
Managerul (Serverul MCP) își dă seama care specialist (agent) ar trebui să te ajute.
Specialistul folosește expertul în limbaj (OpenAI) pentru a înțelege cererea ta și biblioteca (AI Search) pentru a găsi cel mai bun răspuns.
Gardianul de securitate (Autentificare) se asigură că totul este în siguranță.
Toate acestea se întâmplă într-o clădire fiabilă și scalabilă (Azure Container Apps), astfel încât experiența ta să fie lină și sigură.
Această colaborare permite sistemului să te ajute rapid și în siguranță să îți planifici călătoria, la fel ca o echipă de agenți de călătorie experți care lucrează împreună într-un birou modern!

## Implementare tehnică
- **Serverul MCP:** Găzduiește logica principală de orchestrare, expune instrumentele agenților și gestionează contextul pentru fluxurile de lucru de planificare a călătoriilor în mai mulți pași.
- **Agenți:** Fiecare agent (de exemplu, FlightAgent, HotelAgent) este implementat ca un instrument MCP cu propriile șabloane de prompturi și logică.
- **Integrare Azure:** Utilizează Azure OpenAI pentru înțelegerea limbajului natural și Azure AI Search pentru recuperarea datelor.
- **Securitate:** Integrează cu Microsoft Entra ID pentru autentificare și aplică controale de acces cu cel mai mic privilegiu pentru toate resursele.
- **Implementare:** Suportă implementarea pe Azure Container Apps pentru scalabilitate și eficiență operațională.

## Rezultate și impact
- Demonstrează cum poate fi utilizat MCP pentru a orchestra mai mulți agenți AI într-un scenariu real, de producție.
- Accelerează dezvoltarea soluțiilor prin furnizarea de modele reutilizabile pentru coordonarea agenților, integrarea datelor și implementarea sigură.
- Servește ca un plan pentru construirea de aplicații specifice domeniului, bazate pe AI, folosind MCP și serviciile Azure.

## Referințe
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Declinarea responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să obținem acuratețe, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa natală ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională umană. Nu suntem responsabili pentru niciun fel de neînțelegeri sau interpretări greșite care rezultă din utilizarea acestei traduceri.