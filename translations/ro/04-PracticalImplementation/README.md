<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T14:01:44+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ro"
}
-->
# Implementare Practică

Implementarea practică este locul unde puterea Model Context Protocol (MCP) devine tangibilă. Deși înțelegerea teoriei și arhitecturii din spatele MCP este importantă, adevărata valoare apare atunci când aplici aceste concepte pentru a construi, testa și implementa soluții care rezolvă probleme reale. Acest capitol face legătura între cunoștințele conceptuale și dezvoltarea practică, ghidându-te prin procesul de a aduce la viață aplicații bazate pe MCP.

Fie că dezvolți asistenți inteligenți, integrezi AI în fluxurile de lucru ale afacerii sau construiești instrumente personalizate pentru procesarea datelor, MCP oferă o fundație flexibilă. Designul său independent de limbaj și SDK-urile oficiale pentru limbaje de programare populare îl fac accesibil unei game largi de dezvoltatori. Prin valorificarea acestor SDK-uri, poți prototipa rapid, itera și scala soluțiile tale pe diferite platforme și medii.

În secțiunile următoare, vei găsi exemple practice, cod de probă și strategii de implementare care demonstrează cum să implementezi MCP în C#, Java, TypeScript, JavaScript și Python. Vei învăța, de asemenea, cum să depanezi și să testezi serverele MCP, să gestionezi API-urile și să implementezi soluții în cloud folosind Azure. Aceste resurse practice sunt concepute pentru a accelera învățarea ta și pentru a te ajuta să construiești cu încredere aplicații MCP robuste, gata pentru producție.

## Prezentare Generală

Această lecție se concentrează pe aspectele practice ale implementării MCP în mai multe limbaje de programare. Vom explora cum să folosim SDK-urile MCP în C#, Java, TypeScript, JavaScript și Python pentru a construi aplicații robuste, a depana și a testa serverele MCP și a crea resurse, prompturi și instrumente reutilizabile.

## Obiectivele Învățării

Până la sfârșitul acestei lecții, vei fi capabil să:
- Implementezi soluții MCP folosind SDK-urile oficiale în diverse limbaje de programare
- Depanezi și testezi sistematic serverele MCP
- Creezi și utilizezi funcționalități de server (Resurse, Prompturi și Instrumente)
- Proiectezi fluxuri de lucru MCP eficiente pentru sarcini complexe
- Optimizezi implementările MCP pentru performanță și fiabilitate

## Resurse Oficiale SDK

Model Context Protocol oferă SDK-uri oficiale pentru mai multe limbaje:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Lucrul cu SDK-urile MCP

Această secțiune oferă exemple practice de implementare a MCP în mai multe limbaje de programare. Poți găsi cod de probă în directorul `samples` organizat pe limbaje.

### Exemple Disponibile

Repository-ul include implementări de probă în următoarele limbaje:

- C#
- Java
- TypeScript
- JavaScript
- Python

Fiecare exemplu demonstrează concepte cheie MCP și modele de implementare pentru acel limbaj și ecosistem specific.

## Funcționalități de Bază ale Serverului

Serverele MCP pot implementa orice combinație a acestor funcționalități:

### Resurse
Resursele oferă context și date pentru utilizator sau modelul AI să le utilizeze:
- Repozitoare de documente
- Baze de cunoștințe
- Surse de date structurate
- Sisteme de fișiere

### Prompturi
Prompturile sunt mesaje și fluxuri de lucru șablon pentru utilizatori:
- Șabloane de conversație predefinite
- Modele de interacțiune ghidată
- Structuri de dialog specializate

### Instrumente
Instrumentele sunt funcții pe care modelul AI le poate executa:
- Utilitare de procesare a datelor
- Integrări API externe
- Capabilități computaționale
- Funcționalitate de căutare

## Implementări de Probă: C#

Repository-ul oficial C# SDK conține mai multe implementări de probă care demonstrează diferite aspecte ale MCP:

- **Client MCP de Bază**: Exemplu simplu care arată cum să creezi un client MCP și să apelezi instrumente
- **Server MCP de Bază**: Implementare minimă de server cu înregistrare de instrumente de bază
- **Server MCP Avansat**: Server complet echipat cu înregistrare de instrumente, autentificare și gestionare a erorilor
- **Integrare ASP.NET**: Exemple care demonstrează integrarea cu ASP.NET Core
- **Modele de Implementare a Instrumentelor**: Diverse modele pentru implementarea instrumentelor cu diferite niveluri de complexitate

SDK-ul MCP C# este în previzualizare și API-urile pot suferi modificări. Vom actualiza continuu acest blog pe măsură ce SDK-ul evoluează.

### Funcționalități Cheie
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Construirea [primului tău Server MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Pentru exemple complete de implementare C#, vizitează [repository-ul oficial de exemple C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Implementare de Probă: Implementare Java

SDK-ul Java oferă opțiuni robuste de implementare MCP cu funcționalități de nivel enterprise.

### Funcționalități Cheie

- Integrare cu Spring Framework
- Siguranță puternică a tipurilor
- Suport pentru programare reactivă
- Gestionare cuprinzătoare a erorilor

Pentru un exemplu complet de implementare Java, vezi [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) în directorul de exemple.

## Implementare de Probă: Implementare JavaScript

SDK-ul JavaScript oferă o abordare ușoară și flexibilă pentru implementarea MCP.

### Funcționalități Cheie

- Suport pentru Node.js și browser
- API bazat pe promisiuni
- Integrare ușoară cu Express și alte framework-uri
- Suport WebSocket pentru streaming

Pentru un exemplu complet de implementare JavaScript, vezi [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) în directorul de exemple.

## Implementare de Probă: Implementare Python

SDK-ul Python oferă o abordare Pythonică pentru implementarea MCP cu integrații excelente cu framework-urile ML.

### Funcționalități Cheie

- Suport Async/await cu asyncio
- Integrare cu Flask și FastAPI
- Înregistrare simplă a instrumentelor
- Integrare nativă cu biblioteci ML populare

Pentru un exemplu complet de implementare Python, vezi [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) în directorul de exemple.

## Gestionarea API-urilor

Azure API Management este o soluție excelentă pentru cum putem securiza serverele MCP. Ideea este să pui o instanță Azure API Management în fața serverului tău MCP și să lași să gestioneze funcționalități pe care probabil le dorești, cum ar fi:

- limitarea ratei
- gestionarea token-urilor
- monitorizarea
- echilibrarea încărcării
- securitatea

### Exemplu Azure

Iată un exemplu Azure care face exact asta, adică [crearea unui server MCP și securizarea lui cu Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Vezi cum are loc fluxul de autorizare în imaginea de mai jos:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

În imaginea anterioară, are loc următoarele:

- Autentificarea/Autorizarea are loc folosind Microsoft Entra.
- Azure API Management acționează ca un gateway și folosește politici pentru a direcționa și gestiona traficul.
- Azure Monitor înregistrează toate cererile pentru analize ulterioare.

#### Fluxul de autorizare

Să aruncăm o privire mai detaliată asupra fluxului de autorizare:

![Diagramă de Secvență](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Specificația de autorizare MCP

Află mai multe despre [specificația de autorizare MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Implementarea Serverului MCP Remote pe Azure

Să vedem dacă putem implementa exemplul pe care l-am menționat mai devreme:

1. Clonează repo-ul

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Înregistrează `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` după un timp pentru a verifica dacă înregistrarea este completă.

2. Rulează această comandă [azd](https://aka.ms/azd) pentru a provisiona serviciul de management al API-urilor, aplicația de funcții (cu cod) și toate celelalte resurse Azure necesare

    ```shell
    azd up
    ```

    Această comandă ar trebui să implementeze toate resursele cloud pe Azure

### Testarea serverului tău cu MCP Inspector

1. Într-o **fereastră nouă de terminal**, instalează și rulează MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Ar trebui să vezi o interfață similară cu:

    ![Conectează-te la inspectorul Node](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.ro.png)

1. CTRL click pentru a încărca aplicația web MCP Inspector din URL-ul afișat de aplicație (de ex. http://127.0.0.1:6274/#resources)
1. Setează tipul de transport la `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` și **Conectează-te**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Listează Instrumentele**. Fă clic pe un instrument și **Rulează Instrumentul**.

Dacă toți pașii au funcționat, ar trebui acum să fii conectat la serverul MCP și să fi putut apela un instrument.

## Servere MCP pentru Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Acest set de repozitoare sunt șabloane de pornire rapidă pentru construirea și implementarea serverelor MCP (Model Context Protocol) remote personalizate folosind Azure Functions cu Python, C# .NET sau Node/TypeScript.

Exemplele oferă o soluție completă care permite dezvoltatorilor să:

- Construiască și ruleze local: Dezvolte și depaneze un server MCP pe o mașină locală
- Implementeze pe Azure: Implementeze cu ușurință în cloud cu o comandă simplă azd up
- Conecteze de la clienți: Conecteze la serverul MCP de la diferiți clienți, inclusiv modul agent al VS Code și instrumentul MCP Inspector

### Funcționalități Cheie:

- Securitate prin design: Serverul MCP este securizat folosind chei și HTTPS
- Opțiuni de autentificare: Suportă OAuth folosind autentificare încorporată și/sau Management API
- Izolare de rețea: Permite izolarea rețelei folosind Rețele Virtuale Azure (VNET)
- Arhitectură fără server: Folosește Azure Functions pentru execuție scalabilă, bazată pe evenimente
- Dezvoltare locală: Suport cuprinzător pentru dezvoltare și depanare locală
- Implementare simplă: Proces de implementare simplificat către Azure

Repository-ul include toate fișierele de configurare necesare, codul sursă și definițiile infrastructurii pentru a începe rapid cu o implementare de server MCP gata de producție.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Implementare de probă a MCP folosind Azure Functions cu Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Implementare de probă a MCP folosind Azure Functions cu C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Implementare de probă a MCP folosind Azure Functions cu Node/TypeScript.

## Concluzii Cheie

- SDK-urile MCP oferă instrumente specifice limbajului pentru implementarea soluțiilor MCP robuste
- Procesul de depanare și testare este esențial pentru aplicațiile MCP fiabile
- Șabloanele de prompt reutilizabile permit interacțiuni AI consistente
- Fluxurile de lucru bine proiectate pot orchestra sarcini complexe folosind multiple instrumente
- Implementarea soluțiilor MCP necesită luarea în considerare a securității, performanței și gestionării erorilor

## Exercițiu

Proiectează un flux de lucru MCP practic care abordează o problemă reală din domeniul tău:

1. Identifică 3-4 instrumente care ar fi utile pentru rezolvarea acestei probleme
2. Creează o diagramă de flux care arată cum interacționează aceste instrumente
3. Implementează o versiune de bază a unuia dintre instrumente folosind limbajul tău preferat
4. Creează un șablon de prompt care ar ajuta modelul să utilizeze eficient instrumentul tău

## Resurse Suplimentare

---

Următorul: [Subiecte Avansate](../05-AdvancedTopics/README.md)

**Declinarea responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa natală ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea umană profesională. Nu suntem responsabili pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.