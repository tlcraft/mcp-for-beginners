<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5384bbb2a92d00d5d7e66274dbe0331d",
  "translation_date": "2025-07-13T22:59:27+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ro"
}
-->
# Implementare practică

Implementarea practică este momentul în care puterea Model Context Protocol (MCP) devine concretă. Deși înțelegerea teoriei și arhitecturii din spatele MCP este importantă, adevărata valoare apare atunci când aplici aceste concepte pentru a construi, testa și implementa soluții care rezolvă probleme reale. Acest capitol face legătura între cunoștințele conceptuale și dezvoltarea practică, ghidându-te prin procesul de a aduce la viață aplicații bazate pe MCP.

Indiferent dacă dezvolți asistenți inteligenți, integrezi AI în fluxuri de lucru de business sau construiești unelte personalizate pentru procesarea datelor, MCP oferă o bază flexibilă. Designul său independent de limbaj și SDK-urile oficiale pentru limbaje de programare populare îl fac accesibil pentru o gamă largă de dezvoltatori. Folosind aceste SDK-uri, poți prototipa rapid, itera și scala soluțiile tale pe diferite platforme și medii.

În secțiunile următoare vei găsi exemple practice, coduri de probă și strategii de implementare care demonstrează cum să implementezi MCP în C#, Java, TypeScript, JavaScript și Python. De asemenea, vei învăța cum să depanezi și să testezi serverele MCP, să gestionezi API-urile și să implementezi soluții în cloud folosind Azure. Aceste resurse practice sunt concepute să accelereze procesul tău de învățare și să te ajute să construiești cu încredere aplicații MCP robuste, gata pentru producție.

## Prezentare generală

Această lecție se concentrează pe aspectele practice ale implementării MCP în mai multe limbaje de programare. Vom explora cum să folosești SDK-urile MCP în C#, Java, TypeScript, JavaScript și Python pentru a construi aplicații robuste, a depana și testa serverele MCP și a crea resurse, prompturi și unelte reutilizabile.

## Obiective de învățare

La finalul acestei lecții vei putea:
- Implementa soluții MCP folosind SDK-urile oficiale în diverse limbaje de programare
- Depana și testa serverele MCP în mod sistematic
- Crea și utiliza funcționalități ale serverului (Resurse, Prompturi și Unelte)
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

Această secțiune oferă exemple practice de implementare MCP în mai multe limbaje de programare. Poți găsi coduri de probă în directorul `samples`, organizate pe limbaje.

### Exemple disponibile

Repository-ul include [implementări de probă](../../../04-PracticalImplementation/samples) în următoarele limbaje:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Fiecare exemplu demonstrează conceptele cheie MCP și tiparele de implementare specifice limbajului și ecosistemului respectiv.

## Funcționalități principale ale serverului

Serverele MCP pot implementa orice combinație dintre aceste funcționalități:

### Resurse
Resursele oferă context și date pentru utilizator sau modelul AI:
- Repozitoare de documente
- Baze de cunoștințe
- Surse de date structurate
- Sisteme de fișiere

### Prompturi
Prompturile sunt mesaje și fluxuri de lucru șablonizate pentru utilizatori:
- Șabloane predefinite de conversație
- Modele ghidate de interacțiune
- Structuri specializate de dialog

### Unelte
Uneltele sunt funcții pe care modelul AI le poate executa:
- Utilitare pentru procesarea datelor
- Integrări cu API-uri externe
- Capacități de calcul
- Funcționalități de căutare

## Implementări de probă: C#

Repository-ul oficial C# SDK conține mai multe implementări de probă care demonstrează diferite aspecte ale MCP:

- **Client MCP de bază**: Exemplu simplu care arată cum să creezi un client MCP și să apelezi unelte
- **Server MCP de bază**: Implementare minimală a unui server cu înregistrare simplă a uneltelor
- **Server MCP avansat**: Server complet cu înregistrare unelte, autentificare și gestionare a erorilor
- **Integrare ASP.NET**: Exemple care demonstrează integrarea cu ASP.NET Core
- **Tipare de implementare a uneltelor**: Diverse tipare pentru implementarea uneltelor cu diferite niveluri de complexitate

SDK-ul MCP pentru C# este în stadiu de previzualizare și API-urile pot suferi modificări. Vom actualiza continuu acest blog pe măsură ce SDK-ul evoluează.

### Funcționalități cheie
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Construirea [primului tău server MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Pentru exemple complete de implementare în C#, vizitează [repository-ul oficial cu exemple C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Implementare de probă: Implementare Java

SDK-ul Java oferă opțiuni robuste pentru implementarea MCP cu funcționalități de nivel enterprise.

### Funcționalități cheie

- Integrare cu Spring Framework
- Siguranță puternică a tipurilor
- Suport pentru programare reactivă
- Gestionare completă a erorilor

Pentru un exemplu complet de implementare Java, vezi [exemplul Java](samples/java/containerapp/README.md) din directorul de exemple.

## Implementare de probă: Implementare JavaScript

SDK-ul JavaScript oferă o abordare ușoară și flexibilă pentru implementarea MCP.

### Funcționalități cheie

- Suport pentru Node.js și browser
- API bazat pe Promises
- Integrare ușoară cu Express și alte framework-uri
- Suport WebSocket pentru streaming

Pentru un exemplu complet de implementare JavaScript, vezi [exemplul JavaScript](samples/javascript/README.md) din directorul de exemple.

## Implementare de probă: Implementare Python

SDK-ul Python oferă o abordare pythonică pentru implementarea MCP, cu integrări excelente pentru framework-uri ML.

### Funcționalități cheie

- Suport async/await cu asyncio
- Integrare cu Flask și FastAPI
- Înregistrare simplă a uneltelor
- Integrare nativă cu biblioteci ML populare

Pentru un exemplu complet de implementare Python, vezi [exemplul Python](samples/python/README.md) din directorul de exemple.

## Gestionarea API-urilor

Azure API Management este o soluție excelentă pentru securizarea serverelor MCP. Ideea este să plasezi o instanță Azure API Management în fața serverului MCP și să lași aceasta să gestioneze funcționalități pe care probabil le vei dori, cum ar fi:

- limitarea ratei de acces
- gestionarea token-urilor
- monitorizare
- echilibrarea încărcării
- securitate

### Exemplu Azure

Iată un exemplu Azure care face exact asta, adică [crearea unui server MCP și securizarea lui cu Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Vezi cum se desfășoară fluxul de autorizare în imaginea de mai jos:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

În imaginea de mai sus, au loc următoarele:

- Autentificarea/Autorizarea se realizează folosind Microsoft Entra.
- Azure API Management acționează ca un gateway și folosește politici pentru a direcționa și gestiona traficul.
- Azure Monitor înregistrează toate cererile pentru analize ulterioare.

#### Fluxul de autorizare

Să analizăm mai în detaliu fluxul de autorizare:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Specificația autorizării MCP

Află mai multe despre [specificația autorizării MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Implementarea unui server MCP remote pe Azure

Să vedem dacă putem implementa exemplul menționat anterior:

1. Clonează repository-ul

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Înregistrează providerul de resurse `Microsoft.App`.
    * Dacă folosești Azure CLI, rulează `az provider register --namespace Microsoft.App --wait`.
    * Dacă folosești Azure PowerShell, rulează `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Apoi rulează `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` după un timp pentru a verifica dacă înregistrarea s-a finalizat.

2. Rulează această comandă [azd](https://aka.ms/azd) pentru a provisiona serviciul de gestionare API, aplicația funcție (cu cod) și toate celelalte resurse Azure necesare

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

1. Apasă CTRL și fă click pentru a încărca aplicația web MCP Inspector de la URL-ul afișat de aplicație (ex. http://127.0.0.1:6274/#resources)
1. Setează tipul de transport la `SSE`
1. Setează URL-ul către endpoint-ul SSE al API Management afișat după comanda `azd up` și **Conectează-te**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Listează uneltele**. Apasă pe o unealtă și **Rulează unealta**.  

Dacă toate pașii au fost urmați corect, acum ar trebui să fii conectat la serverul MCP și să fi reușit să apelezi o unealtă.

## Servere MCP pentru Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Acest set de repository-uri este un șablon rapid pentru construirea și implementarea serverelor MCP remote personalizate folosind Azure Functions cu Python, C# .NET sau Node/TypeScript.

Exemplele oferă o soluție completă care permite dezvoltatorilor să:

- Construiască și ruleze local: Dezvoltă și depanează un server MCP pe o mașină locală
- Implementeze în Azure: Implementează ușor în cloud cu o simplă comandă azd up
- Se conecteze de la clienți: Conectează-te la serverul MCP din diverse clienți, inclusiv modul agent Copilot din VS Code și instrumentul MCP Inspector

### Funcționalități cheie:

- Securitate prin design: Serverul MCP este securizat folosind chei și HTTPS
- Opțiuni de autentificare: Suportă OAuth folosind autentificare încorporată și/sau API Management
- Izolare de rețea: Permite izolarea rețelei folosind Azure Virtual Networks (VNET)
- Arhitectură serverless: Folosește Azure Functions pentru execuție scalabilă, bazată pe evenimente
- Dezvoltare locală: Suport complet pentru dezvoltare și depanare locală
- Implementare simplificată: Proces simplificat de implementare în Azure

Repository-ul include toate fișierele de configurare necesare, codul sursă și definițiile infrastructurii pentru a începe rapid cu o implementare MCP gata pentru producție.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Implementare de probă MCP folosind Azure Functions cu Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Implementare de probă MCP folosind Azure Functions cu C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Implementare de probă MCP folosind Azure Functions cu Node/TypeScript.

## Concluzii cheie

- SDK-urile MCP oferă unelte specifice limbajului pentru implementarea soluțiilor MCP robuste
- Procesul de depanare și testare este esențial pentru aplicații MCP fiabile
- Șabloanele de prompturi reutilizabile permit interacțiuni AI consistente
- Fluxurile de lucru bine proiectate pot orchestra sarcini complexe folosind mai multe unelte
- Implementarea soluțiilor MCP necesită luarea în considerare a securității, performanței și gestionării erorilor

## Exercițiu

Proiectează un flux de lucru MCP practic care să rezolve o problemă reală din domeniul tău:

1. Identifică 3-4 unelte care ar fi utile pentru rezolvarea acestei probleme
2. Creează un diagramă a fluxului de lucru care să arate cum interacționează aceste unelte
3. Implementează o versiune de bază a uneia dintre unelte folosind limbajul preferat
4. Creează un șablon de prompt care să ajute modelul să folosească eficient unealta ta

## Resurse suplimentare


---

Următorul: [Subiecte avansate](../05-AdvancedTopics/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.