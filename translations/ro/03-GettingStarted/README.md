<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:46:00+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ro"
}
-->
## Getting Started  

Această secțiune conține mai multe lecții:

- **-1- Primul tău server**, în această primă lecție vei învăța cum să creezi primul tău server și să îl inspectezi cu instrumentul inspector, o metodă valoroasă pentru testarea și depanarea serverului, [la lecție](/03-GettingStarted/01-first-server/README.md)

- **-2- Client**, în această lecție vei învăța cum să scrii un client care se poate conecta la serverul tău, [la lecție](/03-GettingStarted/02-client/README.md)

- **-3- Client cu LLM**, o metodă și mai bună de a scrie un client este să adaugi un LLM care să "negocieze" cu serverul ce acțiuni să execute, [la lecție](/03-GettingStarted/03-llm-client/README.md)

- **-4- Consumarea unui server în modul GitHub Copilot Agent în Visual Studio Code**. Aici vom vedea cum să rulăm MCP Server din interiorul Visual Studio Code, [la lecție](/03-GettingStarted/04-vscode/README.md)

- **-5- Consumarea prin SSE (Server Sent Events)** SSE este un standard pentru streaming server-către-client, care permite serverelor să trimită actualizări în timp real către clienți prin HTTP [la lecție](/03-GettingStarted/05-sse-server/README.md)

- **-6- Utilizarea AI Toolkit pentru VSCode** pentru a consuma și testa MCP Clients și Servers [la lecție](/03-GettingStarted/06-aitk/README.md)

- **-7 Testare**. Aici ne vom concentra în special pe diferite metode de testare a serverului și clientului, [la lecție](/03-GettingStarted/07-testing/README.md)

- **-8- Deploy**. Acest capitol va analiza diferite modalități de a implementa soluțiile MCP, [la lecție](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) este un protocol deschis care standardizează modul în care aplicațiile oferă context către LLM-uri. Gândește-te la MCP ca la un port USB-C pentru aplicații AI - oferă o metodă standardizată de a conecta modelele AI la diferite surse de date și unelte.

## Obiectivele Învățării

La finalul acestei lecții vei putea:

- Configura medii de dezvoltare pentru MCP în C#, Java, Python, TypeScript și JavaScript
- Construi și implementa servere MCP de bază cu funcționalități personalizate (resurse, prompturi și unelte)
- Crea aplicații host care se conectează la serverele MCP
- Testa și depana implementările MCP
- Înțelege provocările comune de configurare și soluțiile acestora
- Conecta implementările MCP la servicii populare LLM

## Configurarea Mediului MCP

Înainte de a începe să lucrezi cu MCP, este important să îți pregătești mediul de dezvoltare și să înțelegi fluxul de lucru de bază. Această secțiune te va ghida prin pașii inițiali pentru a asigura un început fără probleme cu MCP.

### Cerințe preliminare

Înainte de a începe dezvoltarea MCP, asigură-te că ai:

- **Mediu de dezvoltare**: pentru limbajul ales (C#, Java, Python, TypeScript sau JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm sau orice editor modern de cod
- **Manageri de pachete**: NuGet, Maven/Gradle, pip sau npm/yarn
- **Chei API**: pentru orice servicii AI pe care intenționezi să le folosești în aplicațiile host


### SDK-uri oficiale

În capitolele următoare vei vedea soluții construite folosind Python, TypeScript, Java și .NET. Iată toate SDK-urile oficial suportate.

MCP oferă SDK-uri oficiale pentru mai multe limbaje:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Întreținut în colaborare cu Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Întreținut în colaborare cu Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementarea oficială TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementarea oficială Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementarea oficială Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Întreținut în colaborare cu Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementarea oficială Rust

## Puncte cheie

- Configurarea mediului de dezvoltare MCP este simplă cu SDK-urile specifice limbajelor
- Construirea serverelor MCP implică crearea și înregistrarea uneltelor cu scheme clare
- Clienții MCP se conectează la servere și modele pentru a valorifica capabilitățile extinse
- Testarea și depanarea sunt esențiale pentru implementări MCP fiabile
- Opțiunile de implementare variază de la dezvoltare locală la soluții cloud

## Exersare

Avem un set de exemple care completează exercițiile pe care le vei găsi în toate capitolele din această secțiune. În plus, fiecare capitol are propriile exerciții și teme

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Resurse suplimentare

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Ce urmează

Următorul: [Crearea primului tău MCP Server](/03-GettingStarted/01-first-server/README.md)

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.