<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6755bc4f6d0293ce6c49cfc5efba0d8e",
  "translation_date": "2025-07-18T10:30:53+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "hr"
}
-->
# 🌟 Lekcije od ranih korisnika

[![Lekcije od MCP ranih korisnika](../../../translated_images/08.980bb2babbaadd8a97739effc9b31e5f1abd8f4c4a3fbc90fb9f931a866674d0.hr.png)](https://youtu.be/jds7dSmNptE)

_(Kliknite na sliku iznad za pregled videa ove lekcije)_

## 🎯 Što ovaj modul pokriva

Ovaj modul istražuje kako stvarne organizacije i programeri koriste Model Context Protocol (MCP) za rješavanje stvarnih izazova i poticanje inovacija. Kroz detaljne studije slučaja i praktične primjere, otkrit ćete kako MCP omogućuje sigurnu, skalabilnu integraciju AI-ja koja povezuje jezične modele, alate i podatke poduzeća.

### Studija slučaja 5: Azure MCP – Model Context Protocol razine poduzeća kao usluga

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) je Microsoftova upravljana, enterprise implementacija Model Context Protocola, dizajnirana da pruži skalabilne, sigurne i usklađene MCP serverske mogućnosti kao uslugu u oblaku. Ovaj sveobuhvatni paket uključuje više specijaliziranih MCP servera za različite Azure usluge i scenarije.

> **🎯 Alati spremni za produkciju**
> 
> Ova studija slučaja predstavlja više MCP servera spremnih za produkciju! Saznajte više o Azure MCP Serveru i drugim Azure-integriranim serverima u našem [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#2--azure-mcp-server).

**Ključne značajke:**
- Potpuno upravljano MCP serversko hostanje s ugrađenim skaliranjem, nadzorom i sigurnošću
- Izvorna integracija s Azure OpenAI, Azure AI Search i drugim Azure uslugama
- Enterprise autentikacija i autorizacija putem Microsoft Entra ID
- Podrška za prilagođene alate, predloške upita i konektore resursa
- Usklađenost s sigurnosnim i regulatornim zahtjevima poduzeća
- Više od 15 specijaliziranih konektora za Azure usluge uključujući baze podataka, nadzor i pohranu

**Mogućnosti Azure MCP Servera:**
- **Upravljanje resursima**: Potpuno upravljanje životnim ciklusom Azure resursa
- **Konektori za baze podataka**: Izravan pristup Azure Database za PostgreSQL i SQL Server
- **Azure Monitor**: Analiza zapisa i operativni uvidi pomoću KQL-a
- **Autentikacija**: DefaultAzureCredential i obrasci upravljanih identiteta
- **Usluge pohrane**: Operacije Blob Storage, Queue Storage i Table Storage
- **Usluge kontejnera**: Upravljanje Azure Container Apps, Container Instances i AKS-om

### 📚 Pogledajte MCP u praksi

Želite vidjeti kako se ovi principi primjenjuju u alatima spremnim za produkciju? Pogledajte naš [**10 Microsoft MCP Servers That Are Transforming Developer Productivity**](microsoft-mcp-servers.md), koji prikazuje stvarne Microsoft MCP servere koje možete koristiti već danas.

## Pregled

Ova lekcija istražuje kako su rani korisnici iskoristili Model Context Protocol (MCP) za rješavanje stvarnih izazova i poticanje inovacija u različitim industrijama. Kroz detaljne studije slučaja i praktične projekte, vidjet ćete kako MCP omogućuje standardiziranu, sigurnu i skalabilnu AI integraciju—povezujući velike jezične modele, alate i podatke poduzeća u jedinstvenom okviru. Steći ćete praktično iskustvo u dizajniranju i izgradnji rješenja temeljenih na MCP-u, učiti iz dokazanih obrazaca implementacije i otkriti najbolje prakse za implementaciju MCP-a u proizvodnim okruženjima. Lekcija također ističe nove trendove, buduće smjerove i resurse otvorenog koda kako biste ostali na čelu MCP tehnologije i njenog ekosustava u razvoju.

## Ciljevi učenja

- Analizirati stvarne implementacije MCP-a u različitim industrijama
- Dizajnirati i izgraditi kompletne aplikacije temeljene na MCP-u
- Istražiti nove trendove i buduće smjerove u MCP tehnologiji
- Primijeniti najbolje prakse u stvarnim razvojnim scenarijima

## Stvarne implementacije MCP-a

### Studija slučaja 1: Automatizacija korisničke podrške u poduzeću

Multinacionalna korporacija implementirala je rješenje temeljeno na MCP-u kako bi standardizirala AI interakcije u svojim sustavima korisničke podrške. Ovo im je omogućilo:

- Stvaranje jedinstvenog sučelja za više LLM pružatelja
- Održavanje dosljednog upravljanja promptovima među odjelima
- Implementaciju robusnih sigurnosnih i usklađenih kontrola
- Jednostavno prebacivanje između različitih AI modela prema specifičnim potrebama

**Tehnička implementacija:**

```python
# Python MCP server implementation for customer support
import logging
import asyncio
from modelcontextprotocol import create_server, ServerConfig
from modelcontextprotocol.server import MCPServer
from modelcontextprotocol.transports import create_http_transport
from modelcontextprotocol.resources import ResourceDefinition
from modelcontextprotocol.prompts import PromptDefinition
from modelcontextprotocol.tool import ToolDefinition

# Configure logging
logging.basicConfig(level=logging.INFO)

async def main():
    # Create server configuration
    config = ServerConfig(
        name="Enterprise Customer Support Server",
        version="1.0.0",
        description="MCP server for handling customer support inquiries"
    )
    
    # Initialize MCP server
    server = create_server(config)
    
    # Register knowledge base resources
    server.resources.register(
        ResourceDefinition(
            name="customer_kb",
            description="Customer knowledge base documentation"
        ),
        lambda params: get_customer_documentation(params)
    )
    
    # Register prompt templates
    server.prompts.register(
        PromptDefinition(
            name="support_template",
            description="Templates for customer support responses"
        ),
        lambda params: get_support_templates(params)
    )
    
    # Register support tools
    server.tools.register(
        ToolDefinition(
            name="ticketing",
            description="Create and update support tickets"
        ),
        handle_ticketing_operations
    )
    
    # Start server with HTTP transport
    transport = create_http_transport(port=8080)
    await server.run(transport)

if __name__ == "__main__":
    asyncio.run(main())
```

**Rezultati:** 30% smanjenje troškova modela, 45% poboljšanje dosljednosti odgovora i poboljšana usklađenost u globalnim operacijama.

### Studija slučaja 2: Dijagnostički asistent u zdravstvu

Pružatelj zdravstvenih usluga razvio je MCP infrastrukturu za integraciju više specijaliziranih medicinskih AI modela uz osiguranje zaštite osjetljivih podataka pacijenata:

- Besprijekorno prebacivanje između općih i specijaliziranih medicinskih modela
- Stroge kontrole privatnosti i evidencije revizije
- Integracija s postojećim sustavima elektroničkih zdravstvenih kartona (EHR)
- Dosljedno oblikovanje upita za medicinsku terminologiju

**Tehnička implementacija:**

```csharp
// C# MCP host application implementation in healthcare application
using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.SDK.Client;
using ModelContextProtocol.SDK.Security;
using ModelContextProtocol.SDK.Resources;

public class DiagnosticAssistant
{
    private readonly MCPHostClient _mcpClient;
    private readonly PatientContext _patientContext;
    
    public DiagnosticAssistant(PatientContext patientContext)
    {
        _patientContext = patientContext;
        
        // Configure MCP client with healthcare-specific settings
        var clientOptions = new ClientOptions
        {
            Name = "Healthcare Diagnostic Assistant",
            Version = "1.0.0",
            Security = new SecurityOptions
            {
                Encryption = EncryptionLevel.Medical,
                AuditEnabled = true
            }
        };
        
        _mcpClient = new MCPHostClientBuilder()
            .WithOptions(clientOptions)
            .WithTransport(new HttpTransport("https://healthcare-mcp.example.org"))
            .WithAuthentication(new HIPAACompliantAuthProvider())
            .Build();
    }
    
    public async Task<DiagnosticSuggestion> GetDiagnosticAssistance(
        string symptoms, string patientHistory)
    {
        // Create request with appropriate resources and tool access
        var resourceRequest = new ResourceRequest
        {
            Name = "patient_records",
            Parameters = new Dictionary<string, object>
            {
                ["patientId"] = _patientContext.PatientId,
                ["requestingProvider"] = _patientContext.ProviderId
            }
        };
        
        // Request diagnostic assistance using appropriate prompt
        var response = await _mcpClient.SendPromptRequestAsync(
            promptName: "diagnostic_assistance",
            parameters: new Dictionary<string, object>
            {
                ["symptoms"] = symptoms,
                patientHistory = patientHistory,
                relevantGuidelines = _patientContext.GetRelevantGuidelines()
            });
            
        return DiagnosticSuggestion.FromMCPResponse(response);
    }
}
```

**Rezultati:** Poboljšane dijagnostičke sugestije za liječnike uz potpuno poštivanje HIPAA standarda i značajno smanjenje prebacivanja između sustava.

### Studija slučaja 3: Analiza rizika u financijskim uslugama

Financijska institucija implementirala je MCP kako bi standardizirala procese analize rizika u različitim odjelima:

- Stvoreno jedinstveno sučelje za modele kreditnog rizika, otkrivanja prijevara i investicijskog rizika
- Implementirane stroge kontrole pristupa i verzioniranje modela
- Osigurana auditabilnost svih AI preporuka
- Održano dosljedno formatiranje podataka u različitim sustavima

**Tehnička implementacija:**

```java
// Java MCP server for financial risk assessment
import org.mcp.server.*;
import org.mcp.security.*;

public class FinancialRiskMCPServer {
    public static void main(String[] args) {
        // Create MCP server with financial compliance features
        MCPServer server = new MCPServerBuilder()
            .withModelProviders(
                new ModelProvider("risk-assessment-primary", new AzureOpenAIProvider()),
                new ModelProvider("risk-assessment-audit", new LocalLlamaProvider())
            )
            .withPromptTemplateDirectory("./compliance/templates")
            .withAccessControls(new SOCCompliantAccessControl())
            .withDataEncryption(EncryptionStandard.FINANCIAL_GRADE)
            .withVersionControl(true)
            .withAuditLogging(new DatabaseAuditLogger())
            .build();
            
        server.addRequestValidator(new FinancialDataValidator());
        server.addResponseFilter(new PII_RedactionFilter());
        
        server.start(9000);
        
        System.out.println("Financial Risk MCP Server running on port 9000");
    }
}
```

**Rezultati:** Poboljšana regulatorna usklađenost, 40% brži ciklusi implementacije modela i poboljšana dosljednost procjene rizika među odjelima.

### Studija slučaja 4: Microsoft Playwright MCP poslužitelj za automatizaciju preglednika

Microsoft je razvio [Playwright MCP server](https://github.com/microsoft/playwright-mcp) za omogućavanje sigurne, standardizirane automatizacije preglednika putem Model Context Protocola. Ovaj server spreman za produkciju omogućuje AI agentima i LLM-ovima interakciju s web preglednicima na kontroliran, auditabilan i proširiv način—omogućujući primjere poput automatiziranog web testiranja, ekstrakcije podataka i end-to-end radnih tokova.

> **🎯 Alat spreman za proizvodnju**
> 
> Ova studija slučaja prikazuje stvarni MCP server koji možete koristiti već danas! Saznajte više o Playwright MCP Serveru i još 9 drugih Microsoft MCP servera spremnih za produkciju u našem [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#8--playwright-mcp-server).

**Ključne značajke:**
- Izlaže mogućnosti automatizacije preglednika (navigacija, ispunjavanje obrazaca, snimanje zaslona itd.) kao MCP alate
- Implementira stroge kontrole pristupa i sandboxing za sprječavanje neovlaštenih radnji
- Pruža detaljne audit zapise za sve interakcije s preglednikom
- Podržava integraciju s Azure OpenAI i drugim LLM pružateljima za automatizaciju vođenu agentima
- Pokreće mogućnosti pregledavanja GitHub Copilot Coding Agenta

**Tehnička implementacija:**

```typescript
// TypeScript: Registering Playwright browser automation tools in an MCP server
import { createServer, ToolDefinition } from 'modelcontextprotocol';
import { launch } from 'playwright';

const server = createServer({
  name: 'Playwright MCP Server',
  version: '1.0.0',
  description: 'MCP server for browser automation using Playwright'
});

// Register a tool for navigating to a URL and capturing a screenshot
server.tools.register(
  new ToolDefinition({
    name: 'navigate_and_screenshot',
    description: 'Navigate to a URL and capture a screenshot',
    parameters: {
      url: { type: 'string', description: 'The URL to visit' }
    }
  }),
  async ({ url }) => {
    const browser = await launch();
    const page = await browser.newPage();
    await page.goto(url);
    const screenshot = await page.screenshot();
    await browser.close();
    return { screenshot };
  }
);

// Start the MCP server
server.listen(8080);
```

**Rezultati:**

- Omogućena sigurna, programabilna automatizacija preglednika za AI agente i LLM-ove
- Smanjen ručni napor testiranja i poboljšana pokrivenost testiranja za web aplikacije
- Pružena ponovno upotrebljiva, proširiva infrastruktura za integraciju alata temeljenih na pregledniku u poslovnim okruženjima
- Pokreće mogućnosti pregledavanja GitHub Copilota

**Reference:**  
- [Playwright MCP Server GitHub repozitorij](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI i rješenja za automatizaciju](https://azure.microsoft.com/en-us/products/ai-services/)

### Studija slučaja 5: Azure MCP – Protokol konteksta modela na razini poduzeća kao usluga

Azure MCP Server ([https://aka.ms/azmcp](https://aka.ms/azmcp)) je Microsoftova upravljana, enterprise implementacija Model Context Protocola, dizajnirana da pruži skalabilne, sigurne i usklađene MCP serverske mogućnosti kao uslugu u oblaku. Azure MCP omogućuje organizacijama brzo postavljanje, upravljanje i integraciju MCP servera s Azure AI, podacima i sigurnosnim uslugama, smanjujući operativne troškove i ubrzavajući usvajanje AI-ja.

> **🎯 Alat spreman za proizvodnju**
> 
> Ovo je stvarni MCP server koji možete koristiti već danas! Saznajte više o Azure AI Foundry MCP Serveru u našem [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md).

- Potpuno upravljano MCP serversko hostanje s ugrađenim skaliranjem, nadzorom i sigurnošću  
- Izvorna integracija s Azure OpenAI, Azure AI Search i drugim Azure uslugama  
- Enterprise autentikacija i autorizacija putem Microsoft Entra ID  
- Podrška za prilagođene alate, predloške upita i konektore resursa  
- Usklađenost s sigurnosnim i regulatornim zahtjevima poduzeća  

**Tehnička implementacija:**

```yaml
# Example: Azure MCP server deployment configuration (YAML)
apiVersion: mcp.microsoft.com/v1
kind: McpServer
metadata:
  name: enterprise-mcp-server
spec:
  modelProviders:
    - name: azure-openai
      type: AzureOpenAI
      endpoint: https://<your-openai-resource>.openai.azure.com/
      apiKeySecret: <your-azure-keyvault-secret>
  tools:
    - name: document_search
      type: AzureAISearch
      endpoint: https://<your-search-resource>.search.windows.net/
      apiKeySecret: <your-azure-keyvault-secret>
  authentication:
    type: EntraID
    tenantId: <your-tenant-id>
  monitoring:
    enabled: true
    logAnalyticsWorkspace: <your-log-analytics-id>
```

**Rezultati:**  
- Smanjeno vrijeme do vrijednosti za AI projekte u poduzećima pružanjem platforme MCP servera spremne za korištenje i usklađene s propisima  
- Pojednostavljena integracija LLM-ova, alata i izvora podataka poduzeća  
- Poboljšana sigurnost, vidljivost i operativna učinkovitost MCP radnih opterećenja  
- Poboljšana kvaliteta koda uz najbolje prakse Azure SDK-a i aktualne obrasce autentikacije

**Reference:**  
- [Azure MCP dokumentacija](https://aka.ms/azmcp)  
- [Azure MCP Server GitHub repozitorij](https://github.com/Azure/azure-mcp)  
- [Azure AI usluge](https://azure.microsoft.com/en-us/products/ai-services/)

### Studija slučaja 6: NLWeb – Protokol za web sučelje prirodnog jezika

NLWeb predstavlja Microsoftovu viziju uspostavljanja temeljne slojeve za AI Web. Svaka NLWeb instanca je također MCP server koji podržava jednu osnovnu metodu, `ask`, koja se koristi za postavljanje pitanja web stranici na prirodnom jeziku. Vraćeni odgovor koristi schema.org, široko korišteni vokabular za opisivanje web podataka. U slobodnom prijevodu, MCP je za NLWeb kao što je HTTP za HTML.

**Ključne značajke:**
- **Protokolni sloj**: Jednostavan protokol za sučelje s web stranicama na prirodnom jeziku  
- **Schema.org format**: Koristi JSON i schema.org za strukturirane, strojno čitljive odgovore  
- **Implementacija zajednice**: Jednostavna implementacija za stranice koje se mogu apstrahirati kao liste stavki (proizvodi, recepti, atrakcije, recenzije itd.)  
- **UI widgeti**: Predizgrađeni korisnički sučeljski elementi za konverzacijska sučelja  

**Komponente arhitekture:**
1. **Protokol**: Jednostavan REST API za upite na prirodnom jeziku prema web stranicama  
2. **Implementacija**: Koristi postojeću oznaku i strukturu stranice za automatizirane odgovore  
3. **UI widgeti**: Spremni za korištenje elementi za integraciju konverzacijskih sučelja  

**Prednosti:**
- Omogućuje interakciju čovjeka sa stranicom i agenta s agentom  
- Pruža strukturirane podatke koje AI sustavi lako obrađuju  
- Brza implementacija za stranice s listama sadržaja  
- Standardizirani pristup za omogućavanje AI pristupa web stranicama  

**Rezultati:**
- Uspostavljen temelj za standarde interakcije AI i weba  
- Pojednostavljena izrada konverzacijskih sučelja za sadržajne stranice  
- Poboljšana otkrivljivost i pristupačnost web sadržaja za AI sustave  
- Promovirana interoperabilnost između različitih AI agenata i web usluga  

**Reference:**  
- [NLWeb GitHub repozitorij](https://github.com/microsoft/NlWeb)  
- [NLWeb dokumentacija](https://github.com/microsoft/NlWeb)

### Studija slučaja 7: Azure AI Foundry MCP Server – Integracija AI agenata u poduzećima

Azure AI Foundry MCP serveri pokazuju kako se MCP može koristiti za orkestraciju i upravljanje AI agentima i radnim tokovima u poduzećima. Integracijom MCP-a s Azure AI Foundry, organizacije mogu standardizirati interakcije agenata, iskoristiti Foundryjev sustav upravljanja radnim tokovima i osigurati sigurne, skalabilne implementacije.

> **🎯 Alat spreman za produkciju**
> 
> Ovo je stvarni MCP server koji možete koristiti već danas! Saznajte više o Azure AI Foundry MCP Serveru u našem [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#9--azure-ai-foundry-mcp-server).

**Ključne značajke:**
- Sveobuhvatan pristup Azure AI ekosustavu, uključujući kataloge modela i upravljanje implementacijama  
- Indeksiranje znanja s Azure AI Search za RAG aplikacije  
- Alati za evaluaciju performansi i osiguranje kvalitete AI modela  
- Integracija s Azure AI Foundry Catalog i Labs za najnovije istraživačke modele  
- Upravljanje agentima i evaluacijske mogućnosti za produkcijske scenarije  

**Rezultati:**
- Brzo prototipiranje i robusno praćenje radnih tokova AI agenata  
- Besprijekorna integracija s Azure AI uslugama za napredne scenarije  
- Jedinstveno sučelje za izgradnju, implementaciju i nadzor agentnih pipelineova  
- Poboljšana sigurnost, usklađenost i operativna učinkovitost u poduzećima  
- Ubrzano usvajanje AI-ja uz održavanje kontrole nad složenim procesima vođenim agentima  

**Reference:**  
- [Azure AI Foundry MCP Server GitHub repozitorij](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integracija Azure AI agenata s MCP-om (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Studija slučaja 8: Foundry MCP Playground – Eksperimentiranje i prototipiranje

Foundry MCP Playground nudi spremno okruženje za eksperimentiranje s MCP serverima i integracijama Azure AI Foundry. Programeri mogu brzo prototipirati, testirati i evaluirati AI modele i radne tokove agenata koristeći resurse iz Azure AI Foundry Catalog i Labs. Playground pojednostavljuje postavljanje, pruža primjere projekata i podržava suradnički razvoj, olakšavajući istraživanje najboljih praksi i novih scenarija s minimalnim opterećenjem. Posebno je koristan za timove koji žele potvrditi ideje, dijeliti eksperimente i ubrzati učenje bez potrebe za složenom infrastrukturom. Snižavanjem prepreka za ulazak, playground potiče inovacije i doprinos zajednice u MCP i Azure AI Foundry ekosustavu.

**Reference:**  
- [Foundry MCP Playground GitHub repozitorij](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Studija slučaja 9: Microsoft Learn Docs MCP Server – Pristup dokumentaciji uz AI podršku

Microsoft Learn Docs MCP Server je usluga u oblaku koja AI asistentima omogućuje pristup službenoj Microsoft dokumentaciji u stvarnom vremenu putem Model Context Protocola. Ovaj server spreman za produkciju povezuje se s opsežnim Microsoft Learn ekosustavom i omogućuje semantičko pretraživanje svih službenih Microsoft izvora.
> **🎯 Alat Spreman za Produkciju**
> 
> Ovo je pravi MCP server koji možete koristiti već danas! Saznajte više o Microsoft Learn Docs MCP Serveru u našem [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#1--microsoft-learn-docs-mcp-server).
**Ključne značajke:**
- Pristup u stvarnom vremenu službenoj Microsoft dokumentaciji, Azure dokumentaciji i Microsoft 365 dokumentaciji
- Napredne semantičke mogućnosti pretraživanja koje razumiju kontekst i namjeru
- Uvijek ažurirane informacije jer se sadržaj Microsoft Learna objavljuje kontinuirano
- Sveobuhvatno pokrivanje izvora iz Microsoft Learna, Azure dokumentacije i Microsoft 365
- Vraća do 10 visokokvalitetnih dijelova sadržaja s naslovima članaka i URL-ovima

**Zašto je to ključno:**
- Rješava problem "zastarjelih AI znanja" za Microsoft tehnologije
- Osigurava da AI asistenti imaju pristup najnovijim značajkama .NET-a, C#-a, Azurea i Microsoft 365
- Pruža autoritativne, izvornim izvorom potkrijepljene informacije za točno generiranje koda
- Neophodno za programere koji rade s brzo mijenjajućim Microsoft tehnologijama

**Rezultati:**
- Značajno poboljšana točnost AI-generiranog koda za Microsoft tehnologije
- Smanjeno vrijeme provedeno u traženju aktualne dokumentacije i najboljih praksi
- Povećana produktivnost programera uz dohvaćanje dokumentacije svjesne konteksta
- Besprijekorna integracija s razvojnim tijekovima rada bez napuštanja IDE-a

**Reference:**
- [Microsoft Learn Docs MCP Server GitHub Repository](https://github.com/MicrosoftDocs/mcp)
- [Microsoft Learn Documentation](https://learn.microsoft.com/)

## Praktični projekti

### Projekt 1: Izgradnja MCP poslužitelja s više pružatelja usluga

**Cilj:** Kreirati MCP server koji može usmjeravati zahtjeve prema više pružatelja AI modela na temelju određenih kriterija.

**Zahtjevi:**

- Podrška za najmanje tri različita pružatelja modela (npr. OpenAI, Anthropic, lokalni modeli)
- Implementirati mehanizam usmjeravanja temeljen na metapodacima zahtjeva
- Kreirati sustav konfiguracije za upravljanje vjerodajnicama pružatelja
- Dodati keširanje za optimizaciju performansi i troškova
- Izgraditi jednostavnu nadzornu ploču za praćenje korištenja

**Koraci implementacije:**
1. Postaviti osnovnu infrastrukturu MCP servera
2. Implementirati adaptere za pružatelje za svaku AI model uslugu
3. Kreirati logiku usmjeravanja na temelju atributa zahtjeva
4. Dodati mehanizme keširanja za česte zahtjeve
5. Razviti nadzornu ploču za praćenje
6. Testirati s različitim obrascima zahtjeva

**Tehnologije:** Odaberite između Python (.NET/Java/Python prema vašim preferencijama), Redis za keširanje i jednostavan web framework za nadzornu ploču.

### Projekt 2: Sustav za upravljanje promptovima u poduzeću

**Cilj:** Razviti sustav temeljen na MCP-u za upravljanje, verzioniranje i implementaciju predložaka prompta unutar organizacije.

**Zahtjevi:**
- Kreirati centralizirani repozitorij za predloške promptova
- Implementirati verzioniranje i tijekove odobravanja
- Izgraditi mogućnosti testiranja predložaka s uzorcima unosa
- Razviti kontrole pristupa temeljene na ulogama
- Kreirati API za dohvat i implementaciju predložaka

**Koraci implementacije:**
1. Dizajnirati shemu baze podataka za pohranu predložaka
2. Kreirati osnovni API za CRUD operacije predložaka
3. Implementirati sustav verzioniranja
4. Izgraditi tijek odobravanja
5. Razviti okvir za testiranje
6. Kreirati jednostavno web sučelje za upravljanje
7. Integrirati s MCP serverom

**Tehnologije:** Vaš izbor backend okvira, SQL ili NoSQL baze podataka i frontend okvira za upravljačko sučelje.

### Projekt 3: Platforma za generiranje sadržaja temeljena na MCP-u

**Cilj:** Izgraditi platformu za generiranje sadržaja koja koristi MCP za dosljedne rezultate u različitim vrstama sadržaja.

**Zahtjevi:**
- Podrška za više formata sadržaja (blog postovi, društvene mreže, marketinški tekstovi)
- Implementirati generiranje temeljeno na predlošcima s opcijama prilagodbe
- Kreirati sustav za pregled i povratne informacije o sadržaju
- Pratiti metrike uspješnosti sadržaja
- Podrška za verzioniranje i iteraciju sadržaja

**Koraci implementacije:**
1. Postaviti MCP klijentsku infrastrukturu
2. Kreirati predloške za različite vrste sadržaja
3. Izgraditi pipeline za generiranje sadržaja
4. Implementirati sustav pregleda
5. Razviti sustav praćenja metrika
6. Kreirati korisničko sučelje za upravljanje predlošcima i generiranje sadržaja

**Tehnologije:** Vaš preferirani programski jezik, web okvir i sustav baze podataka.

## Budući smjerovi za MCP tehnologiju

### Novi trendovi

1. **Višemodalni MCP**
   - Proširenje MCP-a za standardizaciju interakcija s modelima za slike, zvuk i video
   - Razvoj sposobnosti rezoniranja preko modaliteta
   - Standardizirani formati promptova za različite modalitete

2. **Federirana MCP infrastruktura**
   - Distribuirane MCP mreže koje mogu dijeliti resurse između organizacija
   - Standardizirani protokoli za sigurno dijeljenje modela
   - Tehnike za očuvanje privatnosti u računalnim procesima

3. **MCP tržišta**
   - Ekosustavi za dijeljenje i monetizaciju MCP predložaka i dodataka
   - Procesi osiguranja kvalitete i certifikacije
   - Integracija s tržištima modela

4. **MCP za rubno računalstvo**
   - Prilagodba MCP standarda za uređaje s ograničenim resursima
   - Optimizirani protokoli za okruženja s niskom propusnošću
   - Specijalizirane MCP implementacije za IoT ekosustave

5. **Regulatorni okviri**
   - Razvoj MCP proširenja za usklađenost s propisima
   - Standardizirani audit tragovi i sučelja za objašnjivost
   - Integracija s novim okvirima upravljanja AI-jem

### MCP rješenja od Microsofta

Microsoft i Azure razvili su nekoliko open-source repozitorija koji pomažu programerima u implementaciji MCP-a u različitim scenarijima:

#### Microsoft Organization
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Playwright MCP server za automatizaciju i testiranje preglednika
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Implementacija OneDrive MCP servera za lokalno testiranje i doprinos zajednice
3. [NLWeb](https://github.com/microsoft/NlWeb) - NLWeb je zbirka otvorenih protokola i povezanih open source alata. Glavni fokus je uspostava temeljne slojeve za AI Web

#### Azure-Samples Organization
1. [mcp](https://github.com/Azure-Samples/mcp) - Linkovi na primjere, alate i resurse za izgradnju i integraciju MCP servera na Azureu koristeći različite jezike
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Referentni MCP serveri koji demonstriraju autentifikaciju prema trenutnoj specifikaciji Model Context Protocola
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Početna stranica za implementacije Remote MCP servera u Azure Functions s linkovima na repozitorije za pojedine jezike
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Predložak za brzo pokretanje i implementaciju prilagođenih Remote MCP servera koristeći Azure Functions i Python
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Predložak za brzo pokretanje i implementaciju prilagođenih Remote MCP servera koristeći Azure Functions i .NET/C#
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Predložak za brzo pokretanje i implementaciju prilagođenih Remote MCP servera koristeći Azure Functions i TypeScript
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management kao AI Gateway za Remote MCP servere koristeći Python
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI eksperimenti uključujući MCP mogućnosti, integraciju s Azure OpenAI i AI Foundry

Ovi repozitoriji nude različite implementacije, predloške i resurse za rad s Model Context Protocolom na različitim programskim jezicima i Azure uslugama. Pokrivaju širok spektar slučajeva upotrebe od osnovnih implementacija servera do autentifikacije, cloud implementacije i scenarija integracije u poduzećima.

#### MCP Resources Directory

[Direktorij MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) u službenom Microsoft MCP repozitoriju pruža pažljivo odabranu zbirku primjera resursa, predložaka promptova i definicija alata za korištenje s Model Context Protocol serverima. Ovaj direktorij je osmišljen da pomogne programerima brzo započeti s MCP-om nudeći višekratno upotrebljive građevne blokove i primjere najboljih praksi za:

- **Predloške promptova:** Spremni za korištenje predlošci za uobičajene AI zadatke i scenarije, koje možete prilagoditi za vlastite MCP implementacije.
- **Definicije alata:** Primjeri shema alata i metapodataka za standardizaciju integracije i poziva alata preko različitih MCP servera.
- **Primjere resursa:** Primjeri definicija resursa za povezivanje s izvorima podataka, API-jima i vanjskim uslugama unutar MCP okvira.
- **Referentne implementacije:** Praktični primjeri koji pokazuju kako strukturirati i organizirati resurse, promptove i alate u stvarnim MCP projektima.

Ovi resursi ubrzavaju razvoj, promiču standardizaciju i pomažu osigurati najbolje prakse pri izgradnji i implementaciji rješenja temeljenih na MCP-u.

#### MCP Resources Directory
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Istraživačke prilike

- Učinkovite tehnike optimizacije prompta unutar MCP okvira
- Sigurnosni modeli za višekorisničke MCP implementacije
- Benchmarking performansi različitih MCP implementacija
- Formalne metode verifikacije MCP servera

## Zaključak

Model Context Protocol (MCP) brzo oblikuje budućnost standardizirane, sigurne i interoperabilne AI integracije u različitim industrijama. Kroz studije slučaja i praktične projekte u ovom poglavlju, vidjeli ste kako rani korisnici – uključujući Microsoft i Azure – koriste MCP za rješavanje stvarnih izazova, ubrzavanje usvajanja AI-ja te osiguravanje usklađenosti, sigurnosti i skalabilnosti. Modularni pristup MCP-a omogućuje organizacijama povezivanje velikih jezičnih modela, alata i podataka poduzeća u jedinstven, revizijski okvir. Kako MCP nastavlja evoluirati, aktivno sudjelovanje u zajednici, istraživanje open-source resursa i primjena najboljih praksi bit će ključni za izgradnju robusnih, spremnih za budućnost AI rješenja.

## Dodatni resursi

- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)
- [Integracija Azure AI agenata s MCP-om (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)
- [MCP GitHub Repository (Microsoft)](https://github.com/microsoft/mcp)
- [MCP Resources Directory (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)
- [MCP Zajednica i dokumentacija](https://modelcontextprotocol.io/introduction)
- [Azure MCP dokumentacija](https://aka.ms/azmcp)
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)
- [Files MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP Auth Servers (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Remote MCP Functions (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI i rješenja za automatizaciju](https://azure.microsoft.com/en-us/products/ai-services/)

## Vježbe

1. Analizirajte jednu od studija slučaja i predložite alternativni pristup implementaciji.
2. Odaberite jednu od ideja za projekt i izradite detaljnu tehničku specifikaciju.
3. Istražite industriju koja nije pokrivena u studijama slučaja i opišite kako MCP može riješiti njezine specifične izazove.
4. Istražite jedan od budućih smjerova i osmislite koncept za novo MCP proširenje koje bi ga podržalo.

Dalje: [Microsoft MCP Server](../07-LessonsfromEarlyAdoption/microsoft-mcp-servers.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.