<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:27:27+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ro"
}
-->
# Implementare Practică

Implementarea practică este momentul în care puterea Model Context Protocol (MCP) devine palpabilă. Deși înțelegerea teoriei și arhitecturii din spatele MCP este importantă, valoarea reală apare atunci când aplici aceste concepte pentru a construi, testa și implementa soluții care rezolvă probleme din lumea reală. Acest capitol face legătura între cunoștințele conceptuale și dezvoltarea practică, ghidându-te prin procesul de aducere la viață a aplicațiilor bazate pe MCP.

Indiferent dacă dezvolți asistenți inteligenți, integrezi AI în fluxuri de lucru de afaceri sau construiești unelte personalizate pentru procesarea datelor, MCP oferă o fundație flexibilă. Designul său independent de limbaj și SDK-urile oficiale pentru limbaje de programare populare îl fac accesibil pentru o gamă largă de dezvoltatori. Folosind aceste SDK-uri, poți prototipa rapid, itera și scala soluțiile tale pe diferite platforme și medii.

În secțiunile următoare vei găsi exemple practice, cod demonstrativ și strategii de implementare care arată cum să implementezi MCP în C#, Java, TypeScript, JavaScript și Python. De asemenea, vei învăța cum să faci depanare și testare a serverelor MCP, să gestionezi API-urile și să implementezi soluții în cloud folosind Azure. Aceste resurse practice sunt concepute pentru a accelera procesul tău de învățare și pentru a te ajuta să construiești cu încredere aplicații MCP robuste, gata pentru producție.

## Prezentare generală

Această lecție se concentrează pe aspectele practice ale implementării MCP în mai multe limbaje de programare. Vom explora cum să folosești SDK-urile MCP în C#, Java, TypeScript, JavaScript și Python pentru a construi aplicații robuste, a depana și testa servere MCP, și a crea resurse, prompturi și unelte reutilizabile.

## Obiective de învățare

La finalul acestei lecții vei putea:
- Implementa soluții MCP folosind SDK-urile oficiale în diverse limbaje de programare
- Depana și testa servere MCP în mod sistematic
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

Această secțiune oferă exemple practice de implementare MCP în mai multe limbaje de programare. Poți găsi cod de exemplu în directorul `samples` organizat pe limbaje.

### Exemple disponibile

Repository-ul include implementări de exemplu în următoarele limbaje:

- C#
- Java
- TypeScript
- JavaScript
- Python

Fiecare exemplu demonstrează concepte cheie MCP și tipare de implementare specifice limbajului și ecosistemului respectiv.

## Funcționalități de bază ale serverului

Serverele MCP pot implementa orice combinație dintre aceste funcționalități:

### Resurse
Resursele oferă context și date pentru utilizator sau modelul AI:
- Repozitoare de documente
- Baze de cunoștințe
- Surse de date structurate
- Sisteme de fișiere

### Prompturi
Prompturile sunt mesaje și fluxuri de lucru șablonizate pentru utilizatori:
- Șabloane de conversații predefinite
- Modele de interacțiune ghidată
- Structuri specializate de dialog

### Unelte
Uneltele sunt funcții pe care modelul AI le poate executa:
- Utilitare de procesare a datelor
- Integrări cu API-uri externe
- Capacități computaționale
- Funcționalități de căutare

## Exemple de implementare: C#

Repository-ul oficial C# SDK conține mai multe exemple care demonstrează diferite aspecte ale MCP:

- **Client MCP de bază**: exemplu simplu care arată cum să creezi un client MCP și să apelezi unelte
- **Server MCP de bază**: implementare minimală a unui server cu înregistrare de unelte de bază
- **Server MCP avansat**: server complet cu înregistrare de unelte, autentificare și gestionare a erorilor
- **Integrare ASP.NET**: exemple de integrare cu ASP.NET Core
- **Tipare de implementare a uneltelor**: diverse tipare pentru implementarea uneltelor cu niveluri diferite de complexitate

SDK-ul MCP pentru C# este în preview și API-urile pot suferi modificări. Vom actualiza continuu acest blog pe măsură ce SDK-ul evoluează.

### Funcționalități cheie
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Construiește-ți [primul MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Pentru exemple complete de implementare C#, vizitează [repository-ul oficial cu exemple C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Exemplu de implementare: Java

SDK-ul Java oferă opțiuni robuste pentru implementarea MCP cu caracteristici de nivel enterprise.

### Funcționalități cheie

- Integrare cu Spring Framework
- Siguranță puternică a tipurilor
- Suport pentru programare reactivă
- Gestionare cuprinzătoare a erorilor

Pentru un exemplu complet de implementare Java, vezi [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) din directorul de exemple.

## Exemplu de implementare: JavaScript

SDK-ul JavaScript oferă o abordare ușoară și flexibilă pentru implementarea MCP.

### Funcționalități cheie

- Suport pentru Node.js și browser
- API bazat pe Promise-uri
- Integrare facilă cu Express și alte framework-uri
- Suport WebSocket pentru streaming

Pentru un exemplu complet de implementare JavaScript, vezi [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) în directorul de exemple.

## Exemplu de implementare: Python

SDK-ul Python oferă o abordare pythonică pentru implementarea MCP, cu integrări excelente pentru framework-urile ML.

### Funcționalități cheie

- Suport async/await cu asyncio
- Integrare cu Flask și FastAPI
- Înregistrare simplă a uneltelor
- Integrare nativă cu biblioteci ML populare

Pentru un exemplu complet de implementare Python, vezi [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) în directorul de exemple.

## Managementul API-urilor

Azure API Management este o soluție excelentă pentru securizarea serverelor MCP. Ideea este să plasezi o instanță Azure API Management în fața serverului tău MCP și să lași această instanță să gestioneze funcționalități pe care probabil le vei dori, cum ar fi:

- limitarea ratei de acces
- managementul token-urilor
- monitorizare
- echilibrare a încărcării
- securitate

### Exemplu Azure

Iată un exemplu Azure care face exact asta, adică [crearea unui MCP Server și securizarea lui cu Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Vezi cum se desfășoară fluxul de autorizare în imaginea de mai jos:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

În imaginea de mai sus, au loc următoarele:

- Autentificarea/Autorizarea se face folosind Microsoft Entra.
- Azure API Management acționează ca un gateway și folosește politici pentru a direcționa și gestiona traficul.
- Azure Monitor înregistrează toate cererile pentru analiza ulterioară.

#### Fluxul de autorizare

Să aruncăm o privire mai detaliată asupra fluxului de autorizare:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Specificația autorizării MCP

Află mai multe despre [specificația autorizării MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Implementarea unui MCP Server Remote pe Azure

Să vedem dacă putem implementa exemplul menționat anterior:

1. Clonează repository-ul

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Înregistrează `Microsoft.App` cu comanda `az provider register --namespace Microsoft.App --wait` sau `Register-AzResourceProvider -ProviderNamespace Microsoft.App`, apoi verifică după un timp dacă înregistrarea este completă cu `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`.

3. Rulează această comandă [azd](https://aka.ms/azd) pentru a provisiona serviciul API Management, aplicația funcțională (cu cod) și toate celelalte resurse Azure necesare

    ```shell
    azd up
    ```

    Această comandă ar trebui să implementeze toate resursele cloud pe Azure

### Testarea serverului cu MCP Inspector

1. Într-o **fereastră de terminal nouă**, instalează și rulează MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Ar trebui să vezi o interfață similară cu:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ro.png)

2. Apasă CTRL + click pentru a încărca aplicația web MCP Inspector de la URL-ul afișat de aplicație (ex. http://127.0.0.1:6274/#resources)
3. Setează tipul de transport la `SSE` și **Conectează-te**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Listează uneltele**. Apasă pe o unealtă și **Rulează unealta**.

Dacă toți pașii au fost urmați corect, acum ești conectat la serverul MCP și ai reușit să apelezi o unealtă.

## Servere MCP pentru Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): acest set de repository-uri este un șablon rapid pentru construirea și implementarea de servere MCP remote personalizate folosind Azure Functions cu Python, C# .NET sau Node/TypeScript.

Exemplele oferă o soluție completă care permite dezvoltatorilor să:

- Construiască și ruleze local: dezvoltă și depanează un server MCP pe mașina locală
- Implementeze în Azure: implementează ușor în cloud cu o simplă comandă azd up
- Se conecteze de pe clienți: conectează-te la serverul MCP de pe diferiți clienți, inclusiv modul agent Copilot din VS Code și instrumentul MCP Inspector

### Funcționalități cheie:

- Securitate prin design: serverul MCP este securizat folosind chei și HTTPS
- Opțiuni de autentificare: suportă OAuth folosind autentificare încorporată și/sau API Management
- Izolare de rețea: permite izolarea rețelei folosind Azure Virtual Networks (VNET)
- Arhitectură serverless: folosește Azure Functions pentru execuție scalabilă, bazată pe evenimente
- Dezvoltare locală: suport complet pentru dezvoltare și depanare locală
- Implementare simplă: proces simplificat de implementare în Azure

Repository-ul include toate fișierele de configurare necesare, codul sursă și definițiile de infrastructură pentru a începe rapid o implementare MCP gata de producție.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - exemplu de implementare MCP folosind Azure Functions cu Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - exemplu de implementare MCP folosind Azure Functions cu C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - exemplu de implementare MCP folosind Azure Functions cu Node/TypeScript.

## Concluzii importante

- SDK-urile MCP oferă unelte specifice limbajelor pentru implementarea de soluții MCP robuste
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

Următorul: [Subiecte Avansate](../05-AdvancedTopics/README.md)

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un traducător uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.