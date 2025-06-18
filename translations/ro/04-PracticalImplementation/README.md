<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:31:45+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ro"
}
-->
# Implementare Practică

Implementarea practică este momentul în care puterea Model Context Protocol (MCP) devine palpabilă. Deși înțelegerea teoriei și a arhitecturii MCP este importantă, adevărata valoare apare atunci când aplici aceste concepte pentru a construi, testa și implementa soluții care rezolvă probleme din lumea reală. Acest capitol face legătura între cunoștințele conceptuale și dezvoltarea practică, ghidându-te prin procesul de aducere la viață a aplicațiilor bazate pe MCP.

Indiferent dacă dezvolți asistenți inteligenți, integrezi AI în fluxurile de lucru ale afacerii sau construiești instrumente personalizate pentru procesarea datelor, MCP oferă o bază flexibilă. Designul său independent de limbaj și SDK-urile oficiale pentru limbaje de programare populare îl fac accesibil unui spectru larg de dezvoltatori. Prin utilizarea acestor SDK-uri, poți prototipa rapid, itera și scala soluțiile tale pe diferite platforme și medii.

În secțiunile următoare vei găsi exemple practice, coduri demonstrative și strategii de implementare care arată cum să folosești MCP în C#, Java, TypeScript, JavaScript și Python. De asemenea, vei învăța cum să depanezi și să testezi serverele MCP, să gestionezi API-urile și să implementezi soluții în cloud folosind Azure. Aceste resurse practice sunt concepute să accelereze procesul tău de învățare și să te ajute să construiești cu încredere aplicații MCP robuste și pregătite pentru producție.

## Prezentare generală

Această lecție se concentrează pe aspectele practice ale implementării MCP în mai multe limbaje de programare. Vom explora cum să folosim SDK-urile MCP în C#, Java, TypeScript, JavaScript și Python pentru a construi aplicații robuste, a depana și testa serverele MCP, precum și pentru a crea resurse, prompturi și instrumente reutilizabile.

## Obiectivele de învățare

La finalul acestei lecții vei putea:
- Implementa soluții MCP folosind SDK-urile oficiale în diverse limbaje de programare
- Depana și testa serverele MCP în mod sistematic
- Crea și utiliza funcționalități ale serverului (Resurse, Prompturi și Instrumente)
- Proiecta fluxuri de lucru MCP eficiente pentru sarcini complexe
- Optimiza implementările MCP pentru performanță și fiabilitate

## Resurse SDK oficiale

Model Context Protocol oferă SDK-uri oficiale pentru mai multe limbaje:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Lucrul cu SDK-urile MCP

Această secțiune oferă exemple practice de implementare MCP în mai multe limbaje de programare. Poți găsi coduri demonstrative în directorul `samples` organizate pe limbaje.

### Exemple disponibile

Repository-ul include [implementări demonstrative](../../../04-PracticalImplementation/samples) în următoarele limbaje:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Fiecare exemplu demonstrează conceptele cheie MCP și modelele de implementare pentru limbajul și ecosistemul respectiv.

## Funcționalități de bază ale serverului

Serverele MCP pot implementa orice combinație dintre aceste funcționalități:

### Resurse
Resursele oferă context și date pentru utilizator sau modelul AI:
- Repozitoare de documente
- Baze de cunoștințe
- Surse de date structurate
- Sisteme de fișiere

### Prompturi
Prompturile sunt mesaje și fluxuri de lucru șablon pentru utilizatori:
- Șabloane predefinite de conversație
- Modele ghidate de interacțiune
- Structuri specializate de dialog

### Instrumente
Instrumentele sunt funcții pe care modelul AI le poate executa:
- Utilitare pentru procesarea datelor
- Integrări cu API-uri externe
- Capacități de calcul
- Funcționalități de căutare

## Exemple de implementare: C#

Repository-ul oficial al SDK-ului C# conține mai multe implementări demonstrative care arată diferite aspecte ale MCP:

- **Client MCP de bază**: Exemplu simplu care arată cum să creezi un client MCP și să apelezi instrumente
- **Server MCP de bază**: Implementare minimă a unui server cu înregistrare simplă a instrumentelor
- **Server MCP avansat**: Server complet cu înregistrare de instrumente, autentificare și gestionare a erorilor
- **Integrare ASP.NET**: Exemple care demonstrează integrarea cu ASP.NET Core
- **Modele de implementare a instrumentelor**: Diverse modele pentru implementarea instrumentelor cu diferite niveluri de complexitate

SDK-ul MCP pentru C# este în stadiu de previzualizare și API-urile pot suferi modificări. Vom actualiza continuu acest blog pe măsură ce SDK-ul evoluează.

### Funcționalități cheie 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Construiește-ți [primul server MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Pentru exemple complete de implementare în C#, vizitează [repository-ul oficial cu exemple C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Exemplu de implementare: Java

SDK-ul Java oferă opțiuni robuste pentru implementarea MCP cu funcționalități de nivel enterprise.

### Funcționalități cheie

- Integrare cu Spring Framework
- Tipare puternice de siguranță
- Suport pentru programare reactivă
- Gestionare completă a erorilor

Pentru un exemplu complet de implementare Java, vezi [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) din directorul de exemple.

## Exemplu de implementare: JavaScript

SDK-ul JavaScript oferă o abordare ușoară și flexibilă pentru implementarea MCP.

### Funcționalități cheie

- Suport pentru Node.js și browser
- API bazat pe Promise-uri
- Integrare ușoară cu Express și alte framework-uri
- Suport WebSocket pentru streaming

Pentru un exemplu complet de implementare JavaScript, vezi [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) din directorul de exemple.

## Exemplu de implementare: Python

SDK-ul Python oferă o abordare pythonică pentru implementarea MCP, cu integrări excelente pentru framework-uri ML.

### Funcționalități cheie

- Suport async/await cu asyncio
- Integrare cu Flask și FastAPI
- Înregistrare simplă a instrumentelor
- Integrare nativă cu biblioteci populare de ML

Pentru un exemplu complet de implementare Python, vezi [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) din directorul de exemple.

## Gestionarea API-urilor

Azure API Management este o soluție excelentă pentru securizarea serverelor MCP. Ideea este să pui o instanță Azure API Management în fața serverului tău MCP și să lași aceasta să gestioneze funcționalități pe care probabil le vei dori, cum ar fi:

- limitarea ratei de acces
- gestionarea token-urilor
- monitorizarea
- echilibrarea încărcării
- securitatea

### Exemplu Azure

Iată un exemplu Azure care face exact acest lucru, adică [crearea unui server MCP și securizarea lui cu Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Vezi cum se desfășoară fluxul de autorizare în imaginea de mai jos:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

În imaginea precedentă, au loc următoarele:

- Autentificarea/Autorizarea se face folosind Microsoft Entra.
- Azure API Management acționează ca un gateway și folosește politici pentru a direcționa și gestiona traficul.
- Azure Monitor înregistrează toate cererile pentru analize ulterioare.

#### Fluxul de autorizare

Să analizăm mai în detaliu fluxul de autorizare:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Specificația autorizării MCP

Află mai multe despre [specificația autorizării MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Implementarea unui server MCP la distanță pe Azure

Să vedem dacă putem implementa exemplul menționat anterior:

1. Clonează repository-ul

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Înregistrează `Microsoft.App` folosind comanda `az provider register --namespace Microsoft.App --wait` sau `Register-AzResourceProvider -ProviderNamespace Microsoft.App` și verifică starea înregistrării cu `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` după un timp.

3. Rulează această comandă [azd](https://aka.ms/azd) pentru a provisiona serviciul de management API, aplicația de funcții (cu cod) și toate celelalte resurse Azure necesare

    ```shell
    azd up
    ```

    Această comandă ar trebui să implementeze toate resursele cloud pe Azure

### Testarea serverului cu MCP Inspector

1. Într-o **fereastră nouă de terminal**, instalează și rulează MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Ar trebui să vezi o interfață similară cu:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ro.png) 

2. Apasă CTRL și fă clic pentru a încărca aplicația web MCP Inspector de la URL-ul afișat de aplicație (ex. http://127.0.0.1:6274/#resources)
3. Setează tipul de transport la `SSE` și **Conectează-te**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Listează Instrumentele**. Dă clic pe un instrument și **Rulează Instrumentul**.

Dacă toți pașii au fost parcurși cu succes, acum ar trebui să fii conectat la serverul MCP și să fi reușit să apelezi un instrument.

## Servere MCP pentru Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Acest set de repository-uri reprezintă un template de start rapid pentru construirea și implementarea serverelor MCP personalizate la distanță folosind Azure Functions cu Python, C# .NET sau Node/TypeScript.

Exemplele oferă o soluție completă care permite dezvoltatorilor să:

- Dezvolte și ruleze local: Dezvoltă și depanează un server MCP pe mașina locală
- Implementeze în Azure: Implementează ușor în cloud cu o comandă simplă azd up
- Se conecteze din clienți: Conectează-te la serverul MCP din diverse clienți, inclusiv modul agent Copilot din VS Code și instrumentul MCP Inspector

### Funcționalități cheie:

- Securitate prin design: Serverul MCP este securizat folosind chei și HTTPS
- Opțiuni de autentificare: Suportă OAuth folosind autentificarea încorporată și/sau API Management
- Izolare de rețea: Permite izolare de rețea folosind Azure Virtual Networks (VNET)
- Arhitectură serverless: Folosește Azure Functions pentru execuție scalabilă și bazată pe evenimente
- Dezvoltare locală: Suport complet pentru dezvoltare și depanare locală
- Implementare simplificată: Proces simplificat de implementare în Azure

Repository-ul include toate fișierele de configurare necesare, codul sursă și definițiile de infrastructură pentru a începe rapid cu o implementare MCP pregătită pentru producție.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Implementare demonstrativă MCP folosind Azure Functions cu Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Implementare demonstrativă MCP folosind Azure Functions cu C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Implementare demonstrativă MCP folosind Azure Functions cu Node/TypeScript.

## Concluzii cheie

- SDK-urile MCP oferă instrumente specifice limbajului pentru implementarea soluțiilor MCP robuste
- Procesul de depanare și testare este esențial pentru aplicații MCP fiabile
- Șabloanele de prompturi reutilizabile asigură interacțiuni AI consistente
- Fluxurile de lucru bine proiectate pot orchestra sarcini complexe folosind multiple instrumente
- Implementarea soluțiilor MCP necesită atenție la securitate, performanță și gestionarea erorilor

## Exercițiu

Proiectează un flux de lucru MCP practic care să abordeze o problemă reală din domeniul tău:

1. Identifică 3-4 instrumente care ar fi utile pentru rezolvarea acestei probleme
2. Creează un diagramă a fluxului de lucru care să arate cum interacționează aceste instrumente
3. Implementează o versiune de bază a unuia dintre instrumente folosind limbajul tău preferat
4. Creează un șablon de prompt care să ajute modelul să utilizeze eficient instrumentul tău

## Resurse suplimentare


---

Următorul: [Subiecte Avansate](../05-AdvancedTopics/README.md)

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere automată AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un traducător uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.