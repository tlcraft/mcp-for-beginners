<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:15:13+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ro"
}
-->
## Începe

Această secțiune cuprinde mai multe lecții:

- **-1- Primul tău server**, în această primă lecție, vei învăța cum să creezi primul tău server și să-l inspectezi cu instrumentul de inspecție, o modalitate valoroasă de a testa și depana serverul tău, [la lecție](/03-GettingStarted/01-first-server/README.md)

- **-2- Client**, în această lecție, vei învăța cum să scrii un client care se poate conecta la serverul tău, [la lecție](/03-GettingStarted/02-client/README.md)

- **-3- Client cu LLM**, o modalitate și mai bună de a scrie un client este prin adăugarea unui LLM astfel încât să poată "negocia" cu serverul tău ce să facă, [la lecție](/03-GettingStarted/03-llm-client/README.md)

- **-4- Consumarea unui server în modul Agent GitHub Copilot în Visual Studio Code**. Aici, ne uităm la rularea serverului nostru MCP din Visual Studio Code, [la lecție](/03-GettingStarted/04-vscode/README.md)

- **-5- Consumarea de la SSE (Server Sent Events)** SSE este un standard pentru streaming de la server la client, permițând serverelor să trimită actualizări în timp real către clienți prin HTTP [la lecție](/03-GettingStarted/05-sse-server/README.md)

- **-6- Utilizarea AI Toolkit pentru VSCode** pentru a consuma și testa clienții și serverele MCP [la lecție](/03-GettingStarted/06-aitk/README.md)

- **-7 Testare**. Aici ne vom concentra în special pe cum putem testa serverul și clientul nostru în moduri diferite, [la lecție](/03-GettingStarted/07-testing/README.md)

- **-8- Implementare**. Acest capitol va analiza diferite moduri de implementare a soluțiilor MCP, [la lecție](/03-GettingStarted/08-deployment/README.md)

Protocolul Model Context (MCP) este un protocol deschis care standardizează modul în care aplicațiile oferă context pentru LLM-uri. Gândește-te la MCP ca la un port USB-C pentru aplicațiile AI - oferă o modalitate standardizată de a conecta modelele AI la diferite surse de date și instrumente.

## Obiective de învățare

La sfârșitul acestei lecții, vei putea:

- Configura medii de dezvoltare pentru MCP în C#, Java, Python, TypeScript și JavaScript
- Construi și implementa servere MCP de bază cu caracteristici personalizate (resurse, prompturi și instrumente)
- Crea aplicații gazdă care se conectează la serverele MCP
- Testa și depana implementările MCP
- Înțelege provocările comune de configurare și soluțiile acestora
- Conecta implementările tale MCP la servicii LLM populare

## Configurarea mediului tău MCP

Înainte de a începe să lucrezi cu MCP, este important să îți pregătești mediul de dezvoltare și să înțelegi fluxul de lucru de bază. Această secțiune te va ghida prin pașii inițiali de configurare pentru a asigura un început lin cu MCP.

### Cerințe preliminare

Înainte de a te aventura în dezvoltarea MCP, asigură-te că ai:

- **Mediu de dezvoltare**: Pentru limbajul ales (C#, Java, Python, TypeScript sau JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm sau orice editor de cod modern
- **Manageri de pachete**: NuGet, Maven/Gradle, pip sau npm/yarn
- **Chei API**: Pentru orice servicii AI pe care planifici să le folosești în aplicațiile tale gazdă

### SDK-uri oficiale

În capitolele următoare vei vedea soluții construite folosind Python, TypeScript, Java și .NET. Iată toate SDK-urile oficiale suportate.

MCP oferă SDK-uri oficiale pentru mai multe limbi:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Menținut în colaborare cu Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Menținut în colaborare cu Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementarea oficială TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementarea oficială Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementarea oficială Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Menținut în colaborare cu Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementarea oficială Rust

## Concluzii cheie

- Configurarea unui mediu de dezvoltare MCP este simplă cu SDK-uri specifice limbajului
- Construirea serverelor MCP implică crearea și înregistrarea instrumentelor cu scheme clare
- Clienții MCP se conectează la servere și modele pentru a valorifica capacități extinse
- Testarea și depanarea sunt esențiale pentru implementări MCP fiabile
- Opțiunile de implementare variază de la dezvoltarea locală la soluții bazate pe cloud

## Practică

Avem un set de exemple care completează exercițiile pe care le vei vedea în toate capitolele din această secțiune. În plus, fiecare capitol are și propriile exerciții și sarcini

- [Calculator Java](./samples/java/calculator/README.md)
- [Calculator .Net](../../../03-GettingStarted/samples/csharp)
- [Calculator JavaScript](./samples/javascript/README.md)
- [Calculator TypeScript](./samples/typescript/README.md)
- [Calculator Python](../../../03-GettingStarted/samples/python)

## Resurse suplimentare

- [Repository GitHub MCP](https://github.com/microsoft/mcp-for-beginners)

## Ce urmează

Următorul: [Crearea primului tău server MCP](/03-GettingStarted/01-first-server/README.md)

**Declinarea responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea umană profesională. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.