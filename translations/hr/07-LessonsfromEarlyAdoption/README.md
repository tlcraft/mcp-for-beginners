<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T17:41:29+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "hr"
}
-->
# Lekcije od ranih korisnika

## Pregled

Ova lekcija istražuje kako su rani korisnici iskoristili Model Context Protocol (MCP) za rješavanje stvarnih izazova i poticanje inovacija u različitim industrijama. Kroz detaljne studije slučaja i praktične projekte vidjet ćete kako MCP omogućava standardiziranu, sigurnu i skalabilnu AI integraciju—povezujući velike jezične modele, alate i podatke poduzeća u jedinstvenom okviru. Steći ćete praktično iskustvo u dizajniranju i izgradnji rješenja temeljenih na MCP-u, naučiti iz dokazanih obrazaca implementacije i otkriti najbolje prakse za primjenu MCP-a u produkcijskim okruženjima. Lekcija također ističe nove trendove, buduće smjerove i open-source resurse koji će vam pomoći da ostanete na čelu MCP tehnologije i njenog razvijajućeg se ekosustava.

## Ciljevi učenja

- Analizirati stvarne implementacije MCP-a u različitim industrijama  
- Dizajnirati i izgraditi kompletne aplikacije temeljene na MCP-u  
- Istražiti nove trendove i buduće smjerove u MCP tehnologiji  
- Primijeniti najbolje prakse u stvarnim razvojnim scenarijima  

## Stvarne MCP implementacije

### Studija slučaja 1: Automatizacija korisničke podrške u poduzeću

Multinacionalna korporacija implementirala je rješenje temeljeno na MCP-u kako bi standardizirala AI interakcije u svojim sustavima korisničke podrške. To im je omogućilo:

- Kreiranje jedinstvenog sučelja za više LLM pružatelja  
- Održavanje konzistentnog upravljanja promptovima u različitim odjelima  
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

**Rezultati:** 30% smanjenje troškova modela, 45% poboljšanje konzistentnosti odgovora i unaprijeđena usklađenost u globalnim operacijama.

### Studija slučaja 2: Pomoćnik za dijagnostiku u zdravstvu

Zdravstveni pružatelj razvio je MCP infrastrukturu za integraciju više specijaliziranih medicinskih AI modela uz osiguranje zaštite osjetljivih pacijentovih podataka:

- Bešavno prebacivanje između općih i specijalističkih medicinskih modela  
- Stroge kontrole privatnosti i audit tragovi  
- Integracija s postojećim sustavima elektroničkih zdravstvenih kartona (EHR)  
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

**Rezultati:** Poboljšani dijagnostički prijedlozi za liječnike uz održavanje potpune HIPAA usklađenosti i značajno smanjenje prebacivanja konteksta između sustava.

### Studija slučaja 3: Analiza rizika u financijskim uslugama

Financijska institucija implementirala je MCP za standardizaciju procesa analize rizika u različitim odjelima:

- Kreirano jedinstveno sučelje za modele kreditnog rizika, otkrivanja prijevara i investicijskog rizika  
- Implementirane stroge kontrole pristupa i verzioniranje modela  
- Osigurana auditabilnost svih AI preporuka  
- Održano konzistentno formatiranje podataka u raznolikim sustavima  

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

**Rezultati:** Poboljšana regulatorna usklađenost, 40% brži ciklusi implementacije modela i poboljšana konzistentnost procjene rizika u odjelima.

### Studija slučaja 4: Microsoft Playwright MCP Server za automatizaciju preglednika

Microsoft je razvio [Playwright MCP server](https://github.com/microsoft/playwright-mcp) kako bi omogućio sigurnu, standardiziranu automatizaciju preglednika putem Model Context Protocol-a. Ovo rješenje omogućava AI agentima i LLM-ovima interakciju s web preglednicima na kontrolirani, auditabilan i proširiv način—podržavajući slučajeve korištenja poput automatiziranog testiranja weba, ekstrakcije podataka i end-to-end radnih tokova.

- Izlaže mogućnosti automatizacije preglednika (navigacija, ispunjavanje obrazaca, snimanje zaslona itd.) kao MCP alate  
- Implementira stroge kontrole pristupa i sandboxing za sprječavanje neovlaštenih radnji  
- Pruža detaljne audit zapise svih interakcija s preglednikom  
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
- Smanjen ručni napor testiranja i poboljšan obuhvat testova za web aplikacije  
- Pružena ponovno upotrebljiva i proširiva platforma za integraciju alata baziranih na pregledniku u poslovnim okruženjima  

**Reference:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)  

### Studija slučaja 5: Azure MCP – Model Context Protocol razine poduzeća kao usluga

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) je Microsoftova upravljana, enterprise-grade implementacija Model Context Protocol-a, dizajnirana za pružanje skalabilnih, sigurnih i usklađenih MCP server mogućnosti kao cloud usluge. Azure MCP omogućava organizacijama brzo postavljanje, upravljanje i integraciju MCP servera s Azure AI, podacima i sigurnosnim uslugama, smanjujući operativne troškove i ubrzavajući usvajanje AI-a.

- Potpuno upravljano hostanje MCP servera s ugrađenim skaliranjem, nadzorom i sigurnošću  
- Izvorna integracija s Azure OpenAI, Azure AI Search i ostalim Azure uslugama  
- Enterprise autentikacija i autorizacija putem Microsoft Entra ID-a  
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
- Smanjeno vrijeme do vrijednosti za enterprise AI projekte pružajući spremnu za korištenje, usklađenu MCP server platformu  
- Pojednostavljena integracija LLM-ova, alata i izvora podataka poduzeća  
- Poboljšana sigurnost, uvid i operativna učinkovitost MCP radnih opterećenja  

**Reference:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)  

## Studija slučaja 6: NLWeb  
MCP (Model Context Protocol) je novi protokol za chatbotove i AI asistente za interakciju s alatima. Svaki NLWeb instance je također MCP server koji podržava jednu osnovnu metodu, ask, koja se koristi za postavljanje pitanja web stranici na prirodnom jeziku. Povratni odgovor koristi schema.org, široko korišteni vokabular za opisivanje web podataka. U slobodnijem smislu, MCP je za NLWeb kao što je Http za HTML. NLWeb kombinira protokole, Schema.org formate i primjere koda kako bi pomogao web stranicama brzo kreirati ove endpoint-e, koristeći ih i ljudi kroz konverzacijska sučelja i strojevi kroz prirodnu agent-agent interakciju.

Postoje dvije ključne komponente NLWeb-a:  
- Protokol, vrlo jednostavan za početak, za sučelje sa stranicom na prirodnom jeziku i format koji koristi json i schema.org za odgovor. Pogledajte dokumentaciju o REST API-ju za više detalja.  
- Jednostavna implementacija (1) koja koristi postojeći markup, za stranice koje se mogu apstrahirati kao liste stavki (proizvodi, recepti, atrakcije, recenzije itd.). Zajedno sa skupom korisničkih widgeta, stranice mogu lako pružiti konverzacijska sučelja za svoj sadržaj. Pogledajte dokumentaciju o Life of a chat query za više detalja o funkcioniranju.  

**Reference:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)  

### Studija slučaja 7: MCP za Foundry – Integracija Azure AI agenata

Azure AI Foundry MCP serveri pokazuju kako se MCP može koristiti za orkestraciju i upravljanje AI agentima i radnim tokovima u poslovnim okruženjima. Integracijom MCP-a s Azure AI Foundry, organizacije mogu standardizirati interakcije agenata, iskoristiti Foundry-jev sustav upravljanja radnim tokovima i osigurati sigurne, skalabilne implementacije. Ovaj pristup omogućava brzo prototipiranje, robusno praćenje i besprijekornu integraciju s Azure AI uslugama, podržavajući napredne scenarije poput upravljanja znanjem i evaluacije agenata. Programeri imaju jedinstveno sučelje za izgradnju, implementaciju i praćenje pipeline-a agenata, dok IT timovi dobivaju poboljšanu sigurnost, usklađenost i operativnu učinkovitost. Rješenje je idealno za poduzeća koja žele ubrzati usvajanje AI-a i zadržati kontrolu nad složenim procesima vođenim agentima.

**Reference:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  

### Studija slučaja 8: Foundry MCP Playground – Eksperimentiranje i prototipiranje

Foundry MCP Playground nudi spremno okruženje za eksperimentiranje s MCP serverima i integracijama Azure AI Foundry-a. Programeri mogu brzo prototipirati, testirati i evaluirati AI modele i radne tokove agenata koristeći resurse iz Azure AI Foundry kataloga i laboratorija. Playground pojednostavljuje postavljanje, pruža primjere projekata i podržava timski razvoj, olakšavajući istraživanje najboljih praksi i novih scenarija uz minimalni napor. Posebno je koristan za timove koji žele potvrditi ideje, dijeliti eksperimente i ubrzati učenje bez potrebe za složenom infrastrukturom. Smanjujući prepreke za ulazak, playground potiče inovacije i doprinos zajednice u MCP i Azure AI Foundry ekosustavu.

**Reference:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)  

### Studija slučaja 9: Microsoft Docs MCP Server - Učenje i usavršavanje  
Microsoft Docs MCP Server implementira Model Context Protocol server koji AI asistentima pruža pristup u stvarnom vremenu službenoj Microsoft dokumentaciji. Izvršava semantičko pretraživanje službene Microsoft tehničke dokumentacije.

**Reference:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)  

## Praktični projekti

### Projekt 1: Izgradnja MCP servera s više pružatelja

**Cilj:** Kreirati MCP server koji može usmjeravati zahtjeve prema više pružatelja AI modela na temelju određenih kriterija.

**Zahtjevi:**  
- Podrška za najmanje tri različita pružatelja modela (npr. OpenAI, Anthropic, lokalni modeli)  
- Implementirati mehanizam usmjeravanja temeljen na metapodacima zahtjeva  
- Kreirati sustav konfiguracije za upravljanje vjerodajnicama pružatelja  
- Dodati keširanje za optimizaciju performansi i troškova  
- Izgraditi jednostavnu nadzornu ploču za praćenje korištenja  

**Koraci implementacije:**  
1. Postaviti osnovnu MCP server infrastrukturu  
2. Implementirati adaptere pružatelja za svaku AI model uslugu  
3. Kreirati logiku usmjeravanja na temelju atributa zahtjeva  
4. Dodati keširanje za česte zahtjeve  
5. Razviti nadzornu ploču za praćenje  
6. Testirati s različitim obrascima zahtjeva  

**Tehnologije:** Odaberite između Python (.NET/Java/Python po želji), Redis za keširanje i jednostavan web framework za nadzornu ploču.

### Projekt 2: Sustav upravljanja promptovima u poduzeću

**Cilj:** Razviti sustav temeljen na MCP-u za upravljanje, verzioniranje i implementaciju predložaka promptova unutar organizacije.

**Zahtjevi:**  
- Kreirati centralizirani repozitorij za predloške promptova  
- Implementirati verzioniranje i tijekove odobravanja  
- Izgraditi mogućnosti testiranja predložaka s uzorcima ulaza  
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

**Tehnologije:** Po vašem izboru backend framework, SQL ili NoSQL baza podataka i frontend framework za sučelje upravljanja.

### Projekt 3: Platforma za generiranje sadržaja temeljena na MCP-u

**Cilj:** Izgraditi platformu za generiranje sadržaja koja koristi MCP za pružanje konzistentnih rezultata kroz različite vrste sadržaja.

**Zahtjevi:**  
- Podrška za više formata sadržaja (blog postovi, društvene mreže, marketinški tekstovi)  
- Implementirati generiranje temeljeno na predlošcima s opcijama prilagodbe  
- Kreirati sustav za pregled i povratne informacije o sadržaju  
- Pratiti metrike performansi sadržaja  
- Podržati verzioniranje i iteraciju sadržaja  

**Koraci implementacije:**  
1. Postaviti MCP klijentsku infrastrukturu  
2. Kreirati predloške za različite vrste sadržaja  
3. Izgraditi pipeline za generiranje sadržaja  
4. Implementirati sustav za pregled  
5. Razviti sustav za praćenje metrika  
6. Kreirati korisničko sučelje za upravljanje predlošcima i generiranje sadržaja  

**Tehnologije:** Po želji programski jezik, web framework i sustav baze podataka.

## Budući smjerovi MCP tehnologije

### Novi trendovi

1. **Multi-modalni MCP**  
   - Proširenje MCP-a za standardizaciju interakcija s modelima slike, zvuka i videa  
   - Razvoj sposobnosti za cross-modalno rezoniranje  
   - Standardizirani formati promptova za različite modalitete  

2. **Federirana MCP infrastruktura**  
   - Distribuirane MCP mreže koje mogu dijeliti resurse među organizacijama  
   - Standardizirani protokoli za sigurno dijeljenje modela  
   - Tehnike izračuna koje čuvaju privatnost  

3. **MCP tržišta**  
   - Ekosustavi za dijeljenje i monetizaciju MCP predložaka i dodataka  
   - Procesi osiguranja kvalitete i certifikacije  
   - Integracija s tržištima modela  

4. **MCP za edge računarstvo**  
   - Prilagodba MCP standarda za uređaje s ograničenim resursima  
   - Optimizirani protokoli za okruženja s niskom propusnošću  
   - Specijalizirane MCP implementacije za IoT ekosustave  

5. **Regulatorni okviri**  
   - Razvoj MCP ekstenzija za regulatornu usklađenost  
   - Standardizirani audit tragovi i sučelja za objašnjivost  
   - Integracija s novim okvirima za upravljanje AI-jem  

### MCP rješenja od Microsofta

Microsoft i Azure razvili su nekoliko open-source repozitorija za pomoć programerima u implementaciji MCP-a u različitim scenarijima:

#### Microsoft Organization  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Playwright MCP server za automatizaciju i testiranje preglednika  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - OneDrive MCP server implementacija za lokalno testiranje i doprinos zajednice  
3. [NLWeb](https://github.com/microsoft/NlWeb) - NLWeb je skup otvorenih protokola i pridruženih open source alata. Glavni fokus je uspostavljanje temeljne slojeve za AI Web  

#### Azure-Samples Organization  
1. [mcp](https://github.com/Azure-Samples/mcp) - Linkovi na primjere, alate i resurse za izgradnju i integraciju MCP servera na Azureu koristeći
- [MCP Community & Documentation](https://modelcontextprotocol.io/introduction)
- [Azure MCP Documentation](https://aka.ms/azmcp)
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
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Vježbe

1. Analizirajte jedan od studija slučaja i predložite alternativni pristup implementaciji.
2. Odaberite jednu od ideja za projekt i izradite detaljnu tehničku specifikaciju.
3. Istražite industriju koja nije obrađena u studijama slučaja i opišite kako MCP može riješiti njezine specifične izazove.
4. Istražite jedan od budućih smjerova i osmislite koncept nove MCP ekstenzije koja bi ga podržavala.

Sljedeće: [Best Practices](../08-BestPractices/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument preveden je korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.