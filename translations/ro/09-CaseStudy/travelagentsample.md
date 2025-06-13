<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:53:24+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "ro"
}
-->
# Studiu de caz: Azure AI Travel Agents – Implementare de referință

## Prezentare generală

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) este o soluție de referință completă dezvoltată de Microsoft, care demonstrează cum să construiești o aplicație de planificare a călătoriilor bazată pe mai mulți agenți AI, folosind Model Context Protocol (MCP), Azure OpenAI și Azure AI Search. Acest proiect evidențiază cele mai bune practici pentru coordonarea mai multor agenți AI, integrarea datelor enterprise și oferirea unei platforme securizate și extensibile pentru scenarii din viața reală.

## Caracteristici cheie
- **Orchestrare multi-agent:** Folosește MCP pentru a coordona agenți specializați (de exemplu, agenți pentru zboruri, hoteluri și itinerarii) care colaborează pentru a îndeplini sarcini complexe de planificare a călătoriilor.
- **Integrare date enterprise:** Se conectează la Azure AI Search și alte surse de date enterprise pentru a oferi informații actualizate și relevante pentru recomandările de călătorie.
- **Arhitectură sigură și scalabilă:** Utilizează serviciile Azure pentru autentificare, autorizare și implementare scalabilă, urmând cele mai bune practici de securitate enterprise.
- **Instrumente extensibile:** Implementează unelte MCP reutilizabile și șabloane de prompturi, permițând adaptarea rapidă la noi domenii sau cerințe de business.
- **Experiență utilizator:** Oferă o interfață conversațională prin care utilizatorii pot interacționa cu agenții de călătorie, alimentată de Azure OpenAI și MCP.

## Arhitectură
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Descrierea diagramei arhitecturale

Soluția Azure AI Travel Agents este proiectată pentru modularitate, scalabilitate și integrare sigură a mai multor agenți AI și surse de date enterprise. Componentele principale și fluxul de date sunt următoarele:

- **Interfața utilizator:** Utilizatorii interacționează cu sistemul printr-o interfață conversațională (cum ar fi un chat web sau un bot Teams), care trimite întrebările utilizatorului și primește recomandări de călătorie.
- **Server MCP:** Funcționează ca un coordonator central, primind inputul utilizatorului, gestionând contextul și coordonând acțiunile agenților specializați (de exemplu, FlightAgent, HotelAgent, ItineraryAgent) prin Model Context Protocol.
- **Agenți AI:** Fiecare agent este responsabil pentru un domeniu specific (zboruri, hoteluri, itinerarii) și este implementat ca un tool MCP. Agenții folosesc șabloane de prompturi și logică pentru a procesa cererile și a genera răspunsuri.
- **Azure OpenAI Service:** Oferă înțelegere și generare avansată a limbajului natural, permițând agenților să interpreteze intenția utilizatorului și să genereze răspunsuri conversaționale.
- **Azure AI Search & Date enterprise:** Agenții interoghează Azure AI Search și alte surse de date enterprise pentru a obține informații actualizate despre zboruri, hoteluri și opțiuni de călătorie.
- **Autentificare și securitate:** Se integrează cu Microsoft Entra ID pentru autentificare securizată și aplică controale de acces cu privilegii minime pentru toate resursele.
- **Implementare:** Proiectată pentru implementare pe Azure Container Apps, asigurând scalabilitate, monitorizare și eficiență operațională.

Această arhitectură permite orchestrarea fluentă a mai multor agenți AI, integrarea sigură cu date enterprise și o platformă robustă și extensibilă pentru construirea de soluții AI specifice domeniului.

## Explicație pas cu pas a diagramei arhitecturale
Imaginează-ți că planifici o călătorie mare și ai o echipă de asistenți experți care te ajută cu fiecare detaliu. Sistemul Azure AI Travel Agents funcționează într-un mod similar, folosind părți diferite (ca membri ai echipei) care au fiecare un rol special. Iată cum se leagă totul:

### Interfața utilizator (UI):
Gândește-te la aceasta ca la recepția agentului tău de turism. Aici tu (utilizatorul) pui întrebări sau faci cereri, cum ar fi „Găsește-mi un zbor spre Paris.” Aceasta poate fi o fereastră de chat pe un site web sau o aplicație de mesagerie.

### Server MCP (Coordonatorul):
Serverul MCP este ca un manager care ascultă cererea ta la recepție și decide care specialist trebuie să se ocupe de fiecare parte. El ține evidența conversației și se asigură că totul merge bine.

### Agenți AI (Asistenți specialiști):
Fiecare agent este expert într-un domeniu specific — unul știe totul despre zboruri, altul despre hoteluri, iar altul despre planificarea itinerariului. Când ceri o călătorie, Serverul MCP trimite cererea ta agentului sau agenților potriviți. Acești agenți folosesc cunoștințele și instrumentele lor pentru a găsi cele mai bune opțiuni pentru tine.

### Azure OpenAI Service (Expertul în limbaj):
Este ca și cum ai avea un expert în limbaj care înțelege exact ce ceri, indiferent cum formulezi întrebarea. Acesta ajută agenții să înțeleagă cererile tale și să răspundă într-un limbaj natural, conversațional.

### Azure AI Search & Date enterprise (Biblioteca de informații):
Imaginează-ți o bibliotecă imensă, mereu actualizată, cu toate informațiile despre călătorii — orare de zbor, disponibilitate hoteluri și altele. Agenții caută în această bibliotecă pentru a-ți oferi cele mai precise răspunsuri.

### Autentificare și securitate (Agentul de securitate):
La fel cum un agent de securitate verifică cine poate intra în anumite zone, această componentă se asigură că doar persoanele și agenții autorizați pot accesa informații sensibile. Astfel, datele tale sunt păstrate în siguranță și confidențialitate.

### Implementare pe Azure Container Apps (Clădirea):
Toți acești asistenți și unelte lucrează împreună într-o clădire sigură și scalabilă (cloud-ul). Asta înseamnă că sistemul poate deservi mulți utilizatori simultan și este mereu disponibil când ai nevoie.

## Cum funcționează totul împreună:

Pornești prin a pune o întrebare la recepție (UI).  
Managerul (Server MCP) decide care specialist (agent) te poate ajuta.  
Specialistul folosește expertul în limbaj (OpenAI) pentru a înțelege cererea și biblioteca de informații (AI Search) pentru a găsi cel mai bun răspuns.  
Agentul de securitate (Autentificare) se asigură că totul este sigur.  
Toate acestea se întâmplă într-o clădire fiabilă și scalabilă (Azure Container Apps), pentru ca experiența ta să fie fluidă și protejată.  
Această colaborare permite sistemului să te ajute rapid și în siguranță să-ți planifici călătoria, exact ca o echipă de agenți de turism experți care lucrează împreună într-un birou modern!

## Implementare tehnică
- **Server MCP:** Găzduiește logica centrală de orchestrare, expune uneltele agenților și gestionează contextul pentru fluxuri de lucru complexe de planificare a călătoriilor.
- **Agenți:** Fiecare agent (de ex., FlightAgent, HotelAgent) este implementat ca un tool MCP cu propriile șabloane de prompturi și logică.
- **Integrare Azure:** Folosește Azure OpenAI pentru înțelegerea limbajului natural și Azure AI Search pentru extragerea datelor.
- **Securitate:** Se integrează cu Microsoft Entra ID pentru autentificare și aplică controale de acces cu privilegii minime pentru toate resursele.
- **Implementare:** Suportă implementarea pe Azure Container Apps pentru scalabilitate și eficiență operațională.

## Rezultate și impact
- Demonstrează cum MCP poate fi folosit pentru a orchestra mai mulți agenți AI într-un scenariu real, de producție.
- Accelerează dezvoltarea soluțiilor prin oferirea de modele reutilizabile pentru coordonarea agenților, integrarea datelor și implementarea securizată.
- Servește drept model pentru construirea de aplicații AI specifice domeniului, folosind MCP și serviciile Azure.

## Referințe
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere automată AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.