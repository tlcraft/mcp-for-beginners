<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T17:39:52+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "sr"
}
-->
# Lekcije od ranih korisnika

## Pregled

Ova lekcija istražuje kako su rani korisnici iskoristili Model Context Protocol (MCP) za rešavanje stvarnih problema i podsticanje inovacija u različitim industrijama. Kroz detaljne studije slučaja i praktične projekte, videćete kako MCP omogućava standardizovanu, sigurnu i skalabilnu AI integraciju—povezujući velike jezičke modele, alate i poslovne podatke u jedinstvenom okviru. Steći ćete praktično iskustvo u dizajniranju i izgradnji rešenja zasnovanih na MCP-u, naučiti iz proverenih obrazaca implementacije i otkriti najbolje prakse za primenu MCP-a u produkcionim okruženjima. Lekcija takođe ističe nove trendove, buduće pravce razvoja i open-source resurse koji će vam pomoći da ostanete u vrhu MCP tehnologije i njenog rastućeg ekosistema.

## Ciljevi učenja

- Analizirati stvarne implementacije MCP-a u različitim industrijama  
- Dizajnirati i izgraditi kompletne aplikacije zasnovane na MCP-u  
- Istražiti nove trendove i buduće pravce MCP tehnologije  
- Primijeniti najbolje prakse u stvarnim razvojim scenarijima  

## Stvarne MCP implementacije

### Studija slučaja 1: Automatizacija korisničke podrške u preduzećima

Multinacionalna kompanija je implementirala rešenje zasnovano na MCP-u kako bi standardizovala AI interakcije u svojim sistemima korisničke podrške. Ovo im je omogućilo da:

- Kreiraju jedinstveni interfejs za više LLM provajdera  
- Održavaju dosledno upravljanje promptovima u različitim odeljenjima  
- Implementiraju robusne sigurnosne i usklađene kontrole  
- Lako prelaze između različitih AI modela prema specifičnim potrebama  

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

**Rezultati:** Smanjenje troškova modela za 30%, poboljšanje konzistentnosti odgovora za 45% i unapređena usklađenost u globalnim operacijama.

### Studija slučaja 2: Dijagnostički asistent u zdravstvu

Zdravstveni pružalac usluga razvio je MCP infrastrukturu za integraciju više specijalizovanih medicinskih AI modela, uz osiguranje zaštite osetljivih podataka pacijenata:

- Neprimetno prebacivanje između opštih i specijalizovanih medicinskih modela  
- Stroge kontrole privatnosti i evidencija revizije  
- Integracija sa postojećim sistemima elektronskih zdravstvenih kartona (EHR)  
- Dosledno inženjerstvo promptova za medicinsku terminologiju  

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

**Rezultati:** Poboljšani dijagnostički predlozi za lekare, uz punu HIPAA usklađenost i značajno smanjenje prebacivanja konteksta između sistema.

### Studija slučaja 3: Analiza rizika u finansijskim uslugama

Finansijska institucija je implementirala MCP za standardizaciju procesa analize rizika u različitim odeljenjima:

- Kreiran jedinstveni interfejs za modele kreditnog rizika, detekciju prevara i investicionog rizika  
- Implementirane stroge kontrole pristupa i verzionisanje modela  
- Obezbeđena revizibilnost svih AI preporuka  
- Održavan dosledan format podataka u različitim sistemima  

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

**Rezultati:** Poboljšana usklađenost sa regulativom, 40% brži ciklusi implementacije modela i poboljšana konzistentnost procene rizika u odeljenjima.

### Studija slučaja 4: Microsoft Playwright MCP server za automatizaciju pretraživača

Microsoft je razvio [Playwright MCP server](https://github.com/microsoft/playwright-mcp) koji omogućava sigurnu, standardizovanu automatizaciju pretraživača preko Model Context Protocol-a. Ovo rešenje omogućava AI agentima i LLM-ovima interakciju sa web pretraživačima na kontrolisan, proverljiv i proširiv način—omogućavajući upotrebu za automatizovano testiranje weba, ekstrakciju podataka i end-to-end radne tokove.

- Izlaže mogućnosti automatizacije pretraživača (navigacija, popunjavanje formi, pravljenje screenshot-ova itd.) kao MCP alate  
- Implementira stroge kontrole pristupa i sandboxing da bi sprečio neovlašćene akcije  
- Pruža detaljne evidencije revizije za sve interakcije sa pretraživačem  
- Podržava integraciju sa Azure OpenAI i drugim LLM provajderima za automatizaciju vođenu agentima  

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
- Omogućena sigurna, programabilna automatizacija pretraživača za AI agente i LLM-ove  
- Smanjen manuelni rad na testiranju i poboljšan obuhvat testova za web aplikacije  
- Pružena višekratno upotrebljiva, proširiva platforma za integraciju alata zasnovanih na pretraživaču u poslovnim okruženjima  

**Reference:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Studija slučaja 5: Azure MCP – Model Context Protocol kao enterprise servis

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) je Microsoftova upravljana, enterprise-grade implementacija Model Context Protocol-a, dizajnirana da pruži skalabilne, sigurne i usklađene MCP serverske funkcionalnosti kao cloud servis. Azure MCP omogućava organizacijama brzo postavljanje, upravljanje i integraciju MCP servera sa Azure AI, podacima i sigurnosnim servisima, smanjujući operativni teret i ubrzavajući usvajanje AI.

- Potpuno upravljani hosting MCP servera sa ugrađenim skaliranjem, nadzorom i sigurnošću  
- Nativna integracija sa Azure OpenAI, Azure AI Search i drugim Azure servisima  
- Enterprise autentikacija i autorizacija preko Microsoft Entra ID  
- Podrška za prilagođene alate, šablone promptova i konektore resursa  
- Usklađenost sa sigurnosnim i regulatornim zahtevima za preduzeća  

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
- Smanjeno vreme do vrednosti za enterprise AI projekte pružajući spremnu, usklađenu MCP serversku platformu  
- Pojednostavljena integracija LLM-ova, alata i poslovnih izvora podataka  
- Unapređena sigurnost, posmatranje i operativna efikasnost MCP opterećenja  

**Reference:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Studija slučaja 6: NLWeb

MCP (Model Context Protocol) je novi protokol za chatbotove i AI asistente za interakciju sa alatima. Svaka NLWeb instanca je takođe MCP server koji podržava jednu osnovnu metodu, ask, koja se koristi za postavljanje pitanja sajtu na prirodnom jeziku. Odgovor koristi schema.org, široko korišćeni vokabular za opisivanje web podataka. Ukratko, MCP je za NLWeb ono što je Http za HTML. NLWeb kombinuje protokole, Schema.org formate i primer koda kako bi sajtovima omogućio brzo kreiranje ovih krajnjih tačaka, koristeći koristi i za ljude kroz konverzacione interfejse i za mašine kroz prirodnu agent-agenta interakciju.

NLWeb ima dve jasno odvojene komponente:  
- Protokol, vrlo jednostavan za početak, za interfejs sa sajtom na prirodnom jeziku i format, koristeći json i schema.org za vraćeni odgovor. Pogledajte dokumentaciju REST API-ja za više detalja.  
- Jednostavna implementacija (1) koja koristi postojeći markup za sajtove koji se mogu predstaviti kao liste stavki (proizvodi, recepti, atrakcije, recenzije itd.). Zajedno sa setom UI vidžeta, sajtovi lako mogu pružiti konverzacione interfejse za svoj sadržaj. Pogledajte dokumentaciju "Life of a chat query" za više detalja o radu.  

**Reference:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Studija slučaja 7: MCP za Foundry – Integracija Azure AI agenata

Azure AI Foundry MCP serveri pokazuju kako se MCP može koristiti za orkestraciju i upravljanje AI agentima i radnim tokovima u poslovnim okruženjima. Integracijom MCP-a sa Azure AI Foundry, organizacije mogu standardizovati interakcije agenata, iskoristiti Foundry za upravljanje radnim tokovima i osigurati sigurne, skalabilne implementacije. Ovaj pristup omogućava brzo prototipisanje, robusni nadzor i besprekornu integraciju sa Azure AI servisima, podržavajući napredne scenarije poput upravljanja znanjem i evaluacije agenata. Programeri dobijaju jedinstveni interfejs za izgradnju, implementaciju i nadzor pipeline-ova agenata, dok IT timovi dobijaju poboljšanu sigurnost, usklađenost i operativnu efikasnost. Rešenje je idealno za preduzeća koja žele ubrzati usvajanje AI i zadržati kontrolu nad složenim procesima vođenim agentima.

**Reference:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Studija slučaja 8: Foundry MCP Playground – Eksperimentisanje i prototipisanje

Foundry MCP Playground nudi spremno okruženje za eksperimentisanje sa MCP serverima i Azure AI Foundry integracijama. Programeri mogu brzo praviti prototipe, testirati i evaluirati AI modele i radne tokove agenata koristeći resurse iz Azure AI Foundry kataloga i laboratorija. Playground olakšava postavljanje, pruža primere projekata i podržava kolaborativni razvoj, čineći jednostavnim istraživanje najboljih praksi i novih scenarija uz minimalan trošak. Posebno je koristan za timove koji žele da validiraju ideje, podele eksperimente i ubrzaju učenje bez potrebe za složenom infrastrukturom. Smanjujući prepreke za ulazak, playground podstiče inovacije i doprinos zajednice u MCP i Azure AI Foundry ekosistemu.

**Reference:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Studija slučaja 9: Microsoft Docs MCP Server – Učenje i usavršavanje

Microsoft Docs MCP Server implementira Model Context Protocol server koji omogućava AI asistentima pristup u realnom vremenu zvaničnoj Microsoft dokumentaciji. Izvodi semantičko pretraživanje zvanične Microsoft tehničke dokumentacije.

**Reference:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## Praktični projekti

### Projekat 1: Izgradnja MCP servera sa više provajdera

**Cilj:** Kreirati MCP server koji može usmeravati zahteve ka više provajdera AI modela na osnovu određenih kriterijuma.

**Zahtevi:**  
- Podrška za najmanje tri različita provajdera modela (npr. OpenAI, Anthropic, lokalni modeli)  
- Implementacija mehanizma rutiranja baziranog na metapodacima zahteva  
- Kreiranje sistema konfiguracije za upravljanje akreditivima provajdera  
- Dodavanje keširanja radi optimizacije performansi i troškova  
- Izgradnja jednostavne kontrolne table za praćenje upotrebe  

**Koraci implementacije:**  
1. Postaviti osnovnu MCP server infrastrukturu  
2. Implementirati adaptere za svakog AI model provajdera  
3. Kreirati logiku rutiranja na osnovu atributa zahteva  
4. Dodati mehanizme keširanja za česte zahteve  
5. Razviti kontrolnu tablu za nadzor  
6. Testirati sa različitim obrascima zahteva  

**Tehnologije:** Izbor između Python (.NET/Java/Python po vašem izboru), Redis za keširanje i jednostavan web okvir za kontrolnu tablu.

### Projekat 2: Sistem za upravljanje promptovima u preduzećima

**Cilj:** Razviti sistem zasnovan na MCP-u za upravljanje, verzionisanje i implementaciju šablona promptova u organizaciji.

**Zahtevi:**  
- Kreirati centralizovani repozitorijum za šablone promptova  
- Implementirati verzionisanje i tokove odobravanja  
- Izgraditi mogućnosti testiranja šablona sa primerima unosa  
- Razviti kontrole pristupa zasnovane na ulogama  
- Kreirati API za preuzimanje i implementaciju šablona  

**Koraci implementacije:**  
1. Dizajnirati šemu baze podataka za skladištenje šablona  
2. Kreirati osnovni API za CRUD operacije nad šablonima  
3. Implementirati sistem verzionisanja  
4. Izgraditi tok odobravanja  
5. Razviti okvir za testiranje  
6. Kreirati jednostavan web interfejs za upravljanje  
7. Integrisati sa MCP serverom  

**Tehnologije:** Vaš izbor backend okvira, SQL ili NoSQL baza i frontend okvir za upravljački interfejs.

### Projekat 3: Platforma za generisanje sadržaja zasnovana na MCP-u

**Cilj:** Izgraditi platformu za generisanje sadržaja koja koristi MCP za dosledne rezultate u različitim formatima sadržaja.

**Zahtevi:**  
- Podrška za više formata sadržaja (blog postovi, društvene mreže, marketinški tekstovi)  
- Implementacija generisanja zasnovanog na šablonima sa opcijama prilagođavanja  
- Kreiranje sistema za pregled i povratne informacije o sadržaju  
- Praćenje metrika performansi sadržaja  
- Podrška za verzionisanje i iteraciju sadržaja  

**Koraci implementacije:**  
1. Postaviti MCP klijentsku infrastrukturu  
2. Kreirati šablone za različite tipove sadržaja  
3. Izgraditi pipeline za generisanje sadržaja  
4. Implementirati sistem za pregled  
5. Razviti sistem za praćenje metrika  
6. Kreirati korisnički interfejs za upravljanje šablonima i generisanje sadržaja  

**Tehnologije:** Vaš omiljeni programski jezik, web okvir i sistem baze podataka.

## Budući pravci MCP tehnologije

### Novi trendovi

1. **Multi-modalni MCP**  
   - Proširenje MCP za standardizaciju interakcija sa slikama, zvukom i video modelima  
   - Razvoj sposobnosti za kros-modalno rezonovanje  
   - Standardizovani formati promptova za različite modalitete  

2. **Federisana MCP infrastruktura**  
   - Distribuirane MCP mreže koje mogu deliti resurse između organizacija  
   - Standardizovani protokoli za sigurnu razmenu modela  
   - Tehnike računanja koje čuvaju privatnost  

3. **MCP tržišta**  
   - Ekosistemi za deljenje i monetizaciju MCP šablona i dodataka  
   - Procesi osiguranja kvaliteta i sertifikacije  
   - Integracija sa tržištima modela  

4. **MCP za edge computing**  
   - Prilagođavanje MCP standarda za uređaje sa ograničenim resursima  
   - Optimizovani protokoli za okruženja sa malim protokom podataka  
   - Specijalizovane MCP implementacije za IoT ekosisteme  

5. **Regulatorni okviri**  
   - Razvoj MCP ekstenzija za usklađenost sa propisima  
   - Standardizovani tragovi revizije i interfejsi za objašnjivost  
   - Integracija sa novim okvirima za upravljanje AI-jem  

### MCP rešenja iz Microsofta

Microsoft i Azure su razvili nekoliko open-source repozitorijuma koji pomažu programerima da implementiraju MCP u različitim scenarijima:

#### Microsoft organizacija  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Playwright MCP server za automatizaciju i testiranje pretraživača  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Implementacija OneDrive MCP servera za lokalno testiranje i doprinos zajednice  
3. [NLWeb](https://github.com/microsoft/NlWeb) - Kolekcija otvorenih protokola i alata fokusiranih na uspostavljanje temeljnog sloja za AI Web  

#### Azure-Samples organizacija  
1. [mcp](https://github.com/Azure-Samples/mcp) - Linkovi ka primerima, alatima i resursima za izgradnju i integraciju MCP servera na Azure-u koriste
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

## Vežbe

1. Analizirajte jedan od studija slučaja i predložite alternativni pristup implementaciji.
2. Izaberite jednu od ideja za projekat i napravite detaljnu tehničku specifikaciju.
3. Istražite industriju koja nije pokrivena u studijama slučaja i predstavite kako MCP može rešiti njene specifične izazove.
4. Istražite jedan od budućih pravaca i osmislite koncept nove MCP ekstenzije koja bi ga podržala.

Sledeće: [Best Practices](../08-BestPractices/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем АИ преводилачке услуге [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, имајте у виду да аутоматизовани преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења настала коришћењем овог превода.