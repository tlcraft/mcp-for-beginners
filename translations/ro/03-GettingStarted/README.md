<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "860935ff95d05b006d1d3323e8e3f9e8",
  "translation_date": "2025-07-09T22:35:05+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ro"
}
-->
## Începutul  

Această secțiune cuprinde mai multe lecții:

- **1 Primul tău server**, în această primă lecție vei învăța cum să creezi primul tău server și să îl inspectezi cu instrumentul inspector, o metodă valoroasă pentru testarea și depanarea serverului tău, [la lecție](01-first-server/README.md)

- **2 Client**, în această lecție vei învăța cum să scrii un client care se poate conecta la serverul tău, [la lecție](02-client/README.md)

- **3 Client cu LLM**, o metodă și mai bună de a scrie un client este să adaugi un LLM astfel încât să poată „negocia” cu serverul tău ce trebuie făcut, [la lecție](03-llm-client/README.md)

- **4 Consumarea unui server în modul Agent GitHub Copilot în Visual Studio Code**. Aici vom vedea cum să rulăm MCP Server-ul nostru din interiorul Visual Studio Code, [la lecție](04-vscode/README.md)

- **5 Consumarea prin SSE (Server Sent Events)** SSE este un standard pentru streaming server-către-client, permițând serverelor să trimită actualizări în timp real către clienți prin HTTP [la lecție](05-sse-server/README.md)

- **6 Streaming HTTP cu MCP (Streamable HTTP)**. Află despre streaming-ul HTTP modern, notificările de progres și cum să implementezi servere și clienți MCP scalabili, în timp real, folosind Streamable HTTP. [la lecție](06-http-streaming/README.md)

- **7 Utilizarea AI Toolkit pentru VSCode** pentru a consuma și testa MCP Clients și Servers [la lecție](07-aitk/README.md)

- **8 Testare**. Aici ne vom concentra în special pe diferite metode de testare a serverului și clientului nostru, [la lecție](08-testing/README.md)

- **9 Implementare**. Acest capitol va analiza diferite modalități de a implementa soluțiile tale MCP, [la lecție](09-deployment/README.md)


Model Context Protocol (MCP) este un protocol deschis care standardizează modul în care aplicațiile oferă context LLM-urilor. Gândește-te la MCP ca la un port USB-C pentru aplicațiile AI - oferă o modalitate standardizată de a conecta modelele AI la diferite surse de date și unelte.

## Obiective de învățare

La finalul acestei lecții vei putea:

- Configura medii de dezvoltare pentru MCP în C#, Java, Python, TypeScript și JavaScript
- Construi și implementa servere MCP de bază cu funcționalități personalizate (resurse, prompturi și unelte)
- Crea aplicații gazdă care se conectează la servere MCP
- Testa și depana implementările MCP
- Înțelege provocările comune de configurare și soluțiile lor
- Conecta implementările MCP la servicii populare LLM

## Configurarea mediului tău MCP

Înainte de a începe să lucrezi cu MCP, este important să pregătești mediul de dezvoltare și să înțelegi fluxul de lucru de bază. Această secțiune te va ghida prin pașii inițiali pentru a asigura un început fără probleme cu MCP.

### Cerințe preliminare

Înainte de a te apuca de dezvoltarea MCP, asigură-te că ai:

- **Mediu de dezvoltare**: pentru limbajul ales (C#, Java, Python, TypeScript sau JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm sau orice editor modern de cod
- **Manageri de pachete**: NuGet, Maven/Gradle, pip sau npm/yarn
- **Chei API**: pentru orice servicii AI pe care intenționezi să le folosești în aplicațiile gazdă


### SDK-uri oficiale

În capitolele următoare vei vedea soluții construite folosind Python, TypeScript, Java și .NET. Iată toate SDK-urile oficial suportate.

MCP oferă SDK-uri oficiale pentru mai multe limbaje:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Menținut în colaborare cu Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Menținut în colaborare cu Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementarea oficială TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementarea oficială Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementarea oficială Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Menținut în colaborare cu Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementarea oficială Rust

## Aspecte esențiale

- Configurarea unui mediu de dezvoltare MCP este simplă cu SDK-urile specifice fiecărui limbaj
- Construirea serverelor MCP implică crearea și înregistrarea uneltelor cu scheme clare
- Clienții MCP se conectează la servere și modele pentru a valorifica capabilitățile extinse
- Testarea și depanarea sunt esențiale pentru implementări MCP fiabile
- Opțiunile de implementare variază de la dezvoltare locală la soluții cloud

## Exersare

Avem un set de exemple care completează exercițiile pe care le vei vedea în toate capitolele din această secțiune. În plus, fiecare capitol are propriile exerciții și teme

- [Calculator Java](./samples/java/calculator/README.md)
- [Calculator .Net](../../../03-GettingStarted/samples/csharp)
- [Calculator JavaScript](./samples/javascript/README.md)
- [Calculator TypeScript](./samples/typescript/README.md)
- [Calculator Python](../../../03-GettingStarted/samples/python)

## Resurse suplimentare

- [Construirea de agenți folosind Model Context Protocol pe Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP Remote cu Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [Agent MCP OpenAI .NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Ce urmează

Următorul: [Crearea primului tău MCP Server](01-first-server/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.