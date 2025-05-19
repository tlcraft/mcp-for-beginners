<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "344a126b620ff7997158542fd31be6a4",
  "translation_date": "2025-05-19T22:31:08+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "hr"
}
-->
# Lekcije od ranih korisnika

## Pregled

Ova lekcija istražuje kako su rani korisnici iskoristili Model Context Protocol (MCP) za rješavanje stvarnih izazova i poticanje inovacija u različitim industrijama. Kroz detaljne studije slučaja i praktične projekte vidjet ćete kako MCP omogućuje standardiziranu, sigurnu i skalabilnu integraciju AI-ja—povezujući velike jezične modele, alate i podatke poduzeća u jedinstvenom okviru. Steći ćete praktično iskustvo u dizajniranju i izgradnji rješenja temeljenih na MCP-u, naučiti provjerene obrasce implementacije i otkriti najbolje prakse za uvođenje MCP-a u produkcijska okruženja. Lekcija također ističe nove trendove, buduće smjerove i open-source resurse koji će vam pomoći da ostanete na čelu MCP tehnologije i njenog rastućeg ekosustava.

## Ciljevi učenja

- Analizirati stvarne MCP implementacije u različitim industrijama  
- Dizajnirati i izgraditi kompletne aplikacije temeljene na MCP-u  
- Istražiti nove trendove i buduće smjerove MCP tehnologije  
- Primijeniti najbolje prakse u stvarnim razvojnim scenarijima  

## Stvarne MCP implementacije

### Studija slučaja 1: Automatizacija korisničke podrške u poduzeću

Multinacionalna korporacija implementirala je rješenje temeljeno na MCP-u kako bi standardizirala AI interakcije u svojim sustavima korisničke podrške. To im je omogućilo:

- Kreiranje jedinstvenog sučelja za više LLM pružatelja usluga  
- Održavanje konzistentnog upravljanja promptovima između odjela  
- Implementaciju snažnih sigurnosnih i usklađenih kontrola  
- Jednostavnu promjenu između različitih AI modela prema specifičnim potrebama  

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

**Rezultati:** Smanjenje troškova modela za 30%, poboljšanje konzistentnosti odgovora za 45% i poboljšana usklađenost u globalnim operacijama.

### Studija slučaja 2: Dijagnostički asistent u zdravstvu

Zdravstveni pružatelj usluga razvio je MCP infrastrukturu za integraciju više specijaliziranih medicinskih AI modela, uz osiguranje zaštite osjetljivih pacijentovih podataka:

- Bešavno prebacivanje između općih i specijaliziranih medicinskih modela  
- Stroge kontrole privatnosti i audit tragovi  
- Integracija s postojećim sustavima Elektroničkog zdravstvenog kartona (EHR)  
- Konzistentno inženjerstvo promptova za medicinsku terminologiju  

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

**Rezultati:** Poboljšani dijagnostički prijedlozi za liječnike uz potpunu HIPAA usklađenost i značajno smanjenje prebacivanja konteksta između sustava.

### Studija slučaja 3: Analiza rizika u financijskim uslugama

Financijska institucija implementirala je MCP kako bi standardizirala procese analize rizika u različitim odjelima:

- Kreirano jedinstveno sučelje za modele kreditnog rizika, otkrivanja prijevara i investicijskog rizika  
- Implementirane stroge kontrole pristupa i verzioniranje modela  
- Osigurana auditabilnost svih AI preporuka  
- Održavanje konzistentnog formata podataka u različitim sustavima  

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

**Rezultati:** Poboljšana regulatorna usklađenost, 40% brži ciklusi implementacije modela i poboljšana konzistentnost procjene rizika između odjela.

### Studija slučaja 4: Microsoft Playwright MCP server za automatizaciju preglednika

Microsoft je razvio [Playwright MCP server](https://github.com/microsoft/playwright-mcp) koji omogućuje sigurnu, standardiziranu automatizaciju preglednika putem Model Context Protocol-a. Ovo rješenje omogućuje AI agentima i LLM-ovima interakciju s web preglednicima na kontroliran, auditabilan i proširiv način—podržavajući primjere korištenja poput automatiziranog web testiranja, ekstrakcije podataka i end-to-end radnih tokova.

- Izlaže mogućnosti automatizacije preglednika (navigacija, ispunjavanje obrazaca, snimanje zaslona itd.) kao MCP alate  
- Implementira stroge kontrole pristupa i sandboxing za sprječavanje neovlaštenih radnji  
- Pruža detaljne audit zapise za sve interakcije s preglednikom  
- Podržava integraciju s Azure OpenAI i drugim LLM pružateljima za automatizaciju vođenu agentima  

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
- Omogućena sigurna, programska automatizacija preglednika za AI agente i LLM-ove  
- Smanjen ručni napor testiranja i poboljšano pokrivanje testova za web aplikacije  
- Pružena višekratno upotrebljiva i proširiva platforma za integraciju alata baziranih na pregledniku u poslovnim okruženjima  

**Reference:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Studija slučaja 5: Azure MCP – Enterprise-grade Model Context Protocol kao usluga

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) je Microsoftova upravljana, enterprise-grade implementacija Model Context Protocol-a, dizajnirana za pružanje skalabilnih, sigurnih i usklađenih MCP server kapaciteta kao cloud usluge. Azure MCP omogućuje organizacijama brzo postavljanje, upravljanje i integraciju MCP servera s Azure AI, podacima i sigurnosnim uslugama, smanjujući operativne troškove i ubrzavajući usvajanje AI-ja.

- Potpuno upravljano hostanje MCP servera s ugrađenim skaliranjem, nadzorom i sigurnošću  
- Izvorna integracija s Azure OpenAI, Azure AI Search i drugim Azure uslugama  
- Enterprise autentikacija i autorizacija putem Microsoft Entra ID  
- Podrška za prilagođene alate, predloške promptova i konektore resursa  
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
- Smanjeno vrijeme do vrijednosti za enterprise AI projekte pružajući spremnu, usklađenu MCP server platformu  
- Pojednostavljena integracija LLM-ova, alata i izvora podataka poduzeća  
- Poboljšana sigurnost, vidljivost i operativna učinkovitost MCP radnih opterećenja  

**Reference:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Studija slučaja 6: NLWeb

MCP (Model Context Protocol) je novi protokol za chatbotove i AI asistente za interakciju s alatima. Svaka NLWeb instanca je također MCP server koji podržava jednu osnovnu metodu, ask, koja se koristi za postavljanje pitanja web stranici na prirodnom jeziku. Vraćeni odgovor koristi schema.org, široko korišteni vokabular za opisivanje web podataka. Slobodno rečeno, MCP je za NLWeb ono što je Http za HTML. NLWeb kombinira protokole, formate Schema.org i primjere koda kako bi pomogao web stranicama brzo kreirati ove krajnje točke, koristeći ih za korisničke sučelja temeljen na razgovoru i za interakciju između agenata.

Postoje dvije ključne komponente NLWeb-a:  
- Protokol, vrlo jednostavan za početak, za sučelje s web stranicom na prirodnom jeziku i format koji koristi json i schema.org za odgovor. Više detalja u dokumentaciji REST API-ja.  
- Jednostavna implementacija (1) koja koristi postojeću markup strukturu, za stranice koje se mogu apstrahirati kao liste stavki (proizvodi, recepti, atrakcije, recenzije itd.). Uz skup korisničkih sučelja, stranice lako mogu pružiti razgovorna sučelja za svoj sadržaj. Više o tome u dokumentaciji Life of a chat query.

**Reference:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

## Praktični projekti

### Projekt 1: Izgradnja MCP servera s više pružatelja

**Cilj:** Kreirati MCP server koji može usmjeravati zahtjeve prema različitim AI model pružateljima prema određenim kriterijima.

**Zahtjevi:**  
- Podrška za najmanje tri različita pružatelja modela (npr. OpenAI, Anthropic, lokalni modeli)  
- Implementirati mehanizam usmjeravanja temeljen na metapodacima zahtjeva  
- Kreirati sustav konfiguracije za upravljanje vjerodajnicama pružatelja  
- Dodati keširanje za optimizaciju performansi i troškova  
- Izgraditi jednostavnu nadzornu ploču za praćenje korištenja  

**Koraci implementacije:**  
1. Postaviti osnovnu infrastrukturu MCP servera  
2. Implementirati adaptere za pružatelje AI modela  
3. Kreirati logiku usmjeravanja temeljenu na atributima zahtjeva  
4. Dodati mehanizme keširanja za česte zahtjeve  
5. Razviti nadzornu ploču za praćenje  
6. Testirati s različitim obrascima zahtjeva  

**Tehnologije:** Odaberite između Python (.NET/Java/Python prema vašem izboru), Redis za keširanje i jednostavan web okvir za nadzornu ploču.

### Projekt 2: Enterprise sustav upravljanja promptovima

**Cilj:** Razviti sustav temeljen na MCP-u za upravljanje, verzioniranje i implementaciju predložaka promptova unutar organizacije.

**Zahtjevi:**  
- Kreirati centralizirani repozitorij za predloške promptova  
- Implementirati verzioniranje i tijekove odobrenja  
- Izgraditi mogućnosti testiranja predložaka s uzorcima ulaza  
- Razviti kontrole pristupa temeljene na ulogama  
- Kreirati API za dohvat i implementaciju predložaka  

**Koraci implementacije:**  
1. Dizajnirati shemu baze podataka za pohranu predložaka  
2. Kreirati osnovni API za CRUD operacije predložaka  
3. Implementirati sustav verzioniranja  
4. Izgraditi tijek odobrenja  
5. Razviti okvir za testiranje  
6. Kreirati jednostavno web sučelje za upravljanje  
7. Integrirati s MCP serverom  

**Tehnologije:** Po vašem izboru backend okvir, SQL ili NoSQL baza podataka i frontend okvir za sučelje upravljanja.

### Projekt 3: Platforma za generiranje sadržaja temeljena na MCP-u

**Cilj:** Izgraditi platformu za generiranje sadržaja koja koristi MCP za dosljedne rezultate u različitim vrstama sadržaja.

**Zahtjevi:**  
- Podrška za više formata sadržaja (blog postovi, društvene mreže, marketinški tekstovi)  
- Implementacija generiranja temeljena na predlošcima s opcijama prilagodbe  
- Kreirati sustav za pregled i povratne informacije o sadržaju  
- Pratiti metrike izvedbe sadržaja  
- Podrška za verzioniranje i iteraciju sadržaja  

**Koraci implementacije:**  
1. Postaviti MCP klijentsku infrastrukturu  
2. Kreirati predloške za različite vrste sadržaja  
3. Izgraditi pipeline za generiranje sadržaja  
4. Implementirati sustav pregleda  
5. Razviti sustav za praćenje metrika  
6. Kreirati korisničko sučelje za upravljanje predlošcima i generiranjem sadržaja  

**Tehnologije:** Vaš omiljeni programski jezik, web okvir i sustav baze podataka.

## Budući smjerovi MCP tehnologije

### Novi trendovi

1. **Multi-modalan MCP**  
   - Proširenje MCP-a za standardizaciju interakcija s modelima slike, zvuka i videa  
   - Razvoj sposobnosti cross-modalnog rezoniranja  
   - Standardizirani formati promptova za različite modalitete  

2. **Federirana MCP infrastruktura**  
   - Distribuirane MCP mreže koje mogu dijeliti resurse između organizacija  
   - Standardizirani protokoli za sigurnu razmjenu modela  
   - Tehnike računalstva koje štite privatnost  

3. **MCP tržišta**  
   - Ekosustavi za dijeljenje i monetizaciju MCP predložaka i dodataka  
   - Procesi osiguranja kvalitete i certifikacije  
   - Integracija s tržištima modela  

4. **MCP za edge računarstvo**  
   - Prilagodba MCP standarda za uređaje s ograničenim resursima na rubu mreže  
   - Optimizirani protokoli za okruženja s niskom propusnošću  
   - Specijalizirane MCP implementacije za IoT ekosustave  

5. **Regulatorni okviri**  
   - Razvoj MCP ekstenzija za regulatornu usklađenost  
   - Standardizirani audit tragovi i sučelja za objašnjivost  
   - Integracija s novim okvirima upravljanja AI-jem  

### MCP rješenja iz Microsofta

Microsoft i Azure razvili su nekoliko open-source repozitorija koji pomažu developerima u implementaciji MCP-a u različitim scenarijima:

#### Microsoft organizacija  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Playwright MCP server za automatizaciju i testiranje preglednika  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - OneDrive MCP server implementacija za lokalno testiranje i doprinos zajednice  
3. [NLWeb](https://github.com/microsoft/NlWeb) - Kolekcija otvorenih protokola i povezanih open-source alata, s fokusom na temeljni sloj za AI Web  

#### Azure-Samples organizacija  
1. [mcp](https://github.com/Azure-Samples/mcp) - Linkovi na primjere, alate i resurse za izgradnju i integraciju MCP servera na Azureu koristeći više jezika  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Referentni MCP serveri koji demonstriraju autentikaciju prema trenutnoj specifikaciji Model Context Protocol-a  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Početna stranica za Remote MCP Server implementacije u Azure Functions s linkovima na jezične repozitorije  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Brzi početak za izgradnju i implementaciju prilagođenih remote MCP servera koristeći Azure Functions i Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Brzi početak za izgradnju i implementaciju prilagođenih remote MCP servera koristeći Azure Functions i .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Brzi početak za izgradnju i implementaciju prilagođenih remote MCP servera koristeći Azure Functions i TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management kao AI Gateway za Remote MCP servere koristeći Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI eksperimenti uključujući MCP mogućnosti, integraciju s Azure OpenAI i AI Foundry  

Ovi repozitoriji pružaju razne implementacije, predloške i resurse za rad s Model Context Protocol-om na različitim programskim jezicima i Azure uslugama. Pokrivaju širok spektar slučajeva upotrebe od osnovnih server implementacija do autentikacije, cloud deploymenta i enterprise integracije.

#### MCP direktorij resursa

Direktorij [MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) u službenom Microsoft MCP repozitoriju nudi pažljivo odabranu kolekciju uzoraka resursa, predložaka promptova i definicija alata za korištenje s MCP serverima. Ovaj direktorij pomaže developerima da brzo započnu s MCP-om nudeći višekratno upotrebljive građevne blokove i najbolje primjere za:

- **Predloške promptova:** Spremni za upotrebu predlošci za uobičajene AI zadatke i scenarije, prilagodljivi za vlastite MCP implementacije.  
- **Definicije alata:** Primjeri shema i metapodataka alata za standardizaciju integracije i pozivanja alata na različitim MCP serverima.  
- **Primjeri resursa:** Definicije resursa za povezivanje s izvorima podataka, API-jima i vanjskim uslugama unutar MCP okvira.  
- **Referentne implementacije:** Praktični prim
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Vježbe

1. Analizirajte jedan od studija slučaja i predložite alternativni pristup implementaciji.
2. Odaberite jednu od ideja za projekt i izradite detaljnu tehničku specifikaciju.
3. Istražite industriju koja nije obrađena u studijama slučaja i opišite kako bi MCP mogao riješiti njezine specifične izazove.
4. Istražite jedan od budućih smjerova i osmislite koncept nove MCP ekstenzije koja bi ga podržavala.

Sljedeće: [Best Practices](../08-BestPractices/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument preveden je pomoću AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.