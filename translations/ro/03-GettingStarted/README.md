<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:16:25+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ro"
}
-->
## Începutul  

Această secțiune cuprinde mai multe lecții:

- **1 Primul tău server**, în această primă lecție vei învăța cum să creezi primul tău server și să-l inspectezi cu ajutorul instrumentului inspector, o metodă valoroasă pentru testarea și depanarea serverului tău, [la lecție](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, în această lecție vei învăța cum să scrii un client care se poate conecta la serverul tău, [la lecție](/03-GettingStarted/02-client/README.md)

- **3 Client cu LLM**, o modalitate și mai bună de a scrie un client este adăugând un LLM, astfel încât să poată „negocia” cu serverul tău ce trebuie făcut, [la lecție](/03-GettingStarted/03-llm-client/README.md)

- **4 Consumarea unui server în modul GitHub Copilot Agent în Visual Studio Code**. Aici, ne uităm la rularea MCP Server-ului nostru direct din Visual Studio Code, [la lecție](/03-GettingStarted/04-vscode/README.md)

- **5 Consumarea dintr-un SSE (Server Sent Events)** SSE este un standard pentru streaming server-către-client, permițând serverelor să trimită actualizări în timp real către clienți prin HTTP [la lecție](/03-GettingStarted/05-sse-server/README.md)

- **6 Utilizarea AI Toolkit pentru VSCode** pentru a consuma și testa MCP Clients și Servers [la lecție](/03-GettingStarted/06-aitk/README.md)

- **7 Testare**. Aici ne vom concentra în special pe cum putem testa serverul și clientul nostru în diferite moduri, [la lecție](/03-GettingStarted/07-testing/README.md)

- **8 Implementare**. Acest capitol va analiza diferite modalități de a implementa soluțiile MCP, [la lecție](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) este un protocol deschis care standardizează modul în care aplicațiile furnizează context către LLM-uri. Gândește-te la MCP ca la un port USB-C pentru aplicațiile AI - oferă o metodă standardizată de a conecta modelele AI la diferite surse de date și instrumente.

## Obiectivele de învățare

La finalul acestei lecții vei putea:

- Configura medii de dezvoltare pentru MCP în C#, Java, Python, TypeScript și JavaScript
- Construi și implementa servere MCP de bază cu funcționalități personalizate (resurse, prompturi și unelte)
- Crea aplicații gazdă care se conectează la servere MCP
- Testa și depana implementările MCP
- Înțelege provocările comune în configurare și soluțiile lor
- Conecta implementările MCP la servicii populare LLM

## Configurarea mediului tău MCP

Înainte de a începe să lucrezi cu MCP, este important să pregătești mediul de dezvoltare și să înțelegi fluxul de lucru de bază. Această secțiune te va ghida prin pașii inițiali de configurare pentru a asigura un început lin cu MCP.

### Cerințe preliminare

Înainte de a începe dezvoltarea MCP, asigură-te că ai:

- **Mediu de dezvoltare**: Pentru limbajul ales (C#, Java, Python, TypeScript sau JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm sau orice editor modern de cod
- **Manageri de pachete**: NuGet, Maven/Gradle, pip sau npm/yarn
- **Chei API**: Pentru orice servicii AI pe care intenționezi să le folosești în aplicațiile gazdă


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

## Aspecte importante de reținut

- Configurarea mediului de dezvoltare MCP este simplă cu SDK-urile specifice fiecărui limbaj
- Construirea serverelor MCP implică crearea și înregistrarea uneltelor cu scheme clare
- Clienții MCP se conectează la servere și modele pentru a beneficia de capabilități extinse
- Testarea și depanarea sunt esențiale pentru implementări MCP de încredere
- Opțiunile de implementare variază de la dezvoltare locală până la soluții în cloud

## Exersare

Avem un set de exemple care completează exercițiile pe care le vei vedea în toate capitolele din această secțiune. În plus, fiecare capitol are propriile exerciții și teme.

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

Următorul pas: [Crearea primului tău MCP Server](/03-GettingStarted/01-first-server/README.md)

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea în urma utilizării acestei traduceri.