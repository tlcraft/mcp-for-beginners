<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1ccfe1a6ea77e42862b92ae53cb6cddf",
  "translation_date": "2025-05-20T18:22:01+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "hr"
}
-->
# Lekcije od ranih usvojitelja

## Pregled

Ova lekcija istražuje kako su rani usvojitelji iskoristili Model Context Protocol (MCP) za rješavanje stvarnih izazova i poticanje inovacija u različitim industrijama. Kroz detaljne studije slučaja i praktične projekte, vidjet ćete kako MCP omogućava standardiziranu, sigurnu i skalabilnu AI integraciju — povezujući velike jezične modele, alate i poslovne podatke u jedinstvenom okviru. Steći ćete praktično iskustvo u dizajniranju i izgradnji rješenja temeljenih na MCP-u, učiti iz provjerenih obrazaca implementacije te otkriti najbolje prakse za primjenu MCP-a u produkcijskim okruženjima. Lekcija također ističe nove trendove, buduće smjerove i open-source resurse koji će vam pomoći da ostanete na vrhu MCP tehnologije i njenog razvijajućeg se ekosustava.

## Ciljevi učenja

- Analizirati stvarne implementacije MCP-a u različitim industrijama  
- Dizajnirati i izgraditi kompletne aplikacije temeljene na MCP-u  
- Istražiti nove trendove i buduće smjerove MCP tehnologije  
- Primijeniti najbolje prakse u stvarnim razvojim scenarijima  

## Stvarne MCP implementacije

### Studija slučaja 1: Automatizacija korisničke podrške u poduzeću

Multinacionalna korporacija implementirala je rješenje temeljeno na MCP-u kako bi standardizirala AI interakcije u svojim sustavima korisničke podrške. To im je omogućilo:

- Kreiranje jedinstvenog sučelja za više LLM pružatelja  
- Održavanje dosljednog upravljanja promptovima kroz odjele  
- Implementaciju snažnih sigurnosnih i usklađenih kontrola  
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

**Rezultati:** Smanjenje troškova modela za 30%, poboljšanje konzistentnosti odgovora za 45% i unaprijeđena usklađenost u globalnim operacijama.

### Studija slučaja 2: Dijagnostički asistent u zdravstvu

Zdravstveni pružatelj usluga razvio je MCP infrastrukturu za integraciju više specijaliziranih medicinskih AI modela, uz osiguranje zaštite osjetljivih podataka pacijenata:

- Neprimjetno prebacivanje između generalističkih i specijalističkih medicinskih modela  
- Stroge kontrole privatnosti i audit tragovi  
- Integracija s postojećim sustavima Elektroničkih zdravstvenih kartona (EHR)  
- Dosljedno upravljanje promptovima za medicinsku terminologiju  

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

**Rezultati:** Poboljšani dijagnostički prijedlozi za liječnike uz potpunu HIPAA usklađenost i značajno smanjenje kontekstualnog prebacivanja između sustava.

### Studija slučaja 3: Analiza rizika u financijskim uslugama

Financijska institucija implementirala je MCP za standardizaciju procesa analize rizika u različitim odjelima:

- Kreirano jedinstveno sučelje za modele kreditnog rizika, detekcije prijevara i investicijskog rizika  
- Implementirane stroge kontrole pristupa i verzioniranje modela  
- Osigurana auditabilnost svih AI preporuka  
- Održano dosljedno formatiranje podataka kroz različite sustave  

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

**Rezultati:** Poboljšana regulatorna usklađenost, 40% brži ciklusi implementacije modela i veća konzistentnost procjene rizika među odjelima.

### Studija slučaja 4: Microsoft Playwright MCP Server za automatizaciju preglednika

Microsoft je razvio [Playwright MCP server](https://github.com/microsoft/playwright-mcp) kako bi omogućio sigurnu, standardiziranu automatizaciju preglednika putem Model Context Protocol-a. Ovo rješenje omogućuje AI agentima i LLM-ovima interakciju s web preglednicima na kontroliran, audibilan i proširiv način — omogućujući primjere korištenja poput automatiziranog testiranja weba, ekstrakcije podataka i end-to-end radnih tokova.

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
- Smanjen ručni napor testiranja i poboljšan opseg testiranja web aplikacija  
- Pružena višekratno upotrebljiva, proširiva platforma za integraciju alata baziranih na pregledniku u poslovnim okruženjima  

**Reference:**  
- [Playwright MCP Server GitHub repozitorij](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI i rješenja za automatizaciju](https://azure.microsoft.com/en-us/products/ai-services/)

### Studija slučaja 5: Azure MCP – Enterprise razina Model Context Protocol kao usluga

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) je Microsoftova upravljana, enterprise implementacija Model Context Protocol-a, dizajnirana za pružanje skalabilnih, sigurnih i usklađenih MCP serverskih mogućnosti kao cloud usluge. Azure MCP omogućava organizacijama brzo postavljanje, upravljanje i integraciju MCP servera s Azure AI, podacima i sigurnosnim uslugama, smanjujući operativni teret i ubrzavajući usvajanje AI tehnologija.

- Potpuno upravljano hostanje MCP servera s ugrađenim skaliranjem, nadzorom i sigurnošću  
- Izvorna integracija s Azure OpenAI, Azure AI Search i drugim Azure uslugama  
- Enterprise autentikacija i autorizacija putem Microsoft Entra ID  
- Podrška za prilagođene alate, predloške promptova i konektore resursa  
- Usklađenost s enterprise sigurnosnim i regulatornim zahtjevima  

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
- Smanjeno vrijeme do vrijednosti za enterprise AI projekte pružanjem gotove, usklađene MCP server platforme  
- Pojednostavljena integracija LLM-ova, alata i poslovnih izvora podataka  
- Poboljšana sigurnost, vidljivost i operativna učinkovitost za MCP radne zadatke  

**Reference:**  
- [Azure MCP Dokumentacija](https://aka.ms/azmcp)  
- [Azure AI usluge](https://azure.microsoft.com/en-us/products/ai-services/)

## Studija slučaja 6: NLWeb  
MCP (Model Context Protocol) je novi protokol za chatbotove i AI asistente za interakciju s alatima. Svaka NLWeb instanca također je MCP server koji podržava jednu ključnu metodu, ask, kojom se postavlja pitanje web stranici na prirodnom jeziku. Vraćeni odgovor koristi schema.org, široko korišteni vokabular za opisivanje web podataka. Ukratko, MCP je za NLWeb ono što je Http za HTML. NLWeb kombinira protokole, schema.org formate i primjere koda kako bi pomogao web stranicama brzo kreirati ove krajnje točke, koristeći ih za korisničke razgovorne sučelja i strojne interakcije agent-agent.

NLWeb se sastoji od dva odvojena dijela:  
- Protokol, vrlo jednostavan za početak, za sučelje sa stranicom na prirodnom jeziku i format, koristeći json i schema.org za odgovor. Više detalja u dokumentaciji REST API-ja.  
- Jednostavna implementacija (1) koja koristi postojeću oznaku, za stranice koje se mogu apstrahirati kao liste stavki (proizvodi, recepti, atrakcije, recenzije itd.). Zajedno s UI widgetima, stranice lako mogu pružiti razgovorna sučelja za svoj sadržaj. Više detalja u dokumentaciji Life of a chat query.  

**Reference:**  
- [Azure MCP Dokumentacija](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Studija slučaja 7: MCP za Foundry – Integracija Azure AI agenata

Azure AI Foundry MCP serveri pokazuju kako se MCP može koristiti za orkestraciju i upravljanje AI agentima i radnim tokovima u poslovnim okruženjima. Integracijom MCP-a s Azure AI Foundry, organizacije mogu standardizirati interakcije agenata, iskoristiti Foundry upravljanje radnim tokovima i osigurati sigurne, skalabilne implementacije. Ovaj pristup omogućuje brzo prototipiranje, robusni nadzor i besprijekornu integraciju s Azure AI uslugama, podržavajući napredne scenarije poput upravljanja znanjem i evaluacije agenata. Programeri dobivaju jedinstveno sučelje za izgradnju, implementaciju i nadzor agentnih cjevovoda, dok IT timovi ostvaruju poboljšanu sigurnost, usklađenost i operativnu učinkovitost. Rješenje je idealno za tvrtke koje žele ubrzati usvajanje AI-a i zadržati kontrolu nad složenim procesima vođenim agentima.

**Reference:**  
- [MCP Foundry GitHub repozitorij](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integracija Azure AI agenata s MCP-om (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Studija slučaja 8: Foundry MCP Playground – Eksperimentiranje i prototipiranje

Foundry MCP Playground nudi spremno okruženje za eksperimentiranje s MCP serverima i integracijama Azure AI Foundry. Programeri mogu brzo prototipirati, testirati i evaluirati AI modele i radne tokove koristeći resurse iz Azure AI Foundry kataloga i laboratorija. Playground pojednostavljuje postavljanje, pruža primjere projekata i podržava suradnički razvoj, olakšavajući istraživanje najboljih praksi i novih scenarija uz minimalan trošak. Posebno je koristan za timove koji žele validirati ideje, dijeliti eksperimente i ubrzati učenje bez potrebe za složenom infrastrukturom. Smanjujući prepreke za ulazak, playground potiče inovacije i doprinos zajednice u MCP i Azure AI Foundry ekosustavu.

**Reference:**  
- [Foundry MCP Playground GitHub repozitorij](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Praktični projekti

### Projekt 1: Izgradnja MCP servera s više pružatelja

**Cilj:** Kreirati MCP server koji može usmjeravati zahtjeve prema više pružatelja AI modela prema specifičnim kriterijima.

**Zahtjevi:**  
- Podrška za najmanje tri različita pružatelja modela (npr. OpenAI, Anthropic, lokalni modeli)  
- Implementacija mehanizma usmjeravanja temeljenog na metapodacima zahtjeva  
- Kreiranje sustava konfiguracije za upravljanje vjerodajnicama pružatelja  
- Dodavanje keširanja za optimizaciju performansi i troškova  
- Izgradnja jednostavne nadzorne ploče za praćenje korištenja  

**Koraci implementacije:**  
1. Postaviti osnovnu MCP server infrastrukturu  
2. Implementirati adaptere za svakog pružatelja AI modela  
3. Kreirati logiku usmjeravanja na temelju atributa zahtjeva  
4. Dodati keširanje za učestale zahtjeve  
5. Razviti nadzornu ploču za praćenje  
6. Testirati s različitim obrascima zahtjeva  

**Tehnologije:** Odaberite između Python (.NET/Java/Python prema preferenciji), Redis za keširanje i jednostavan web framework za nadzornu ploču.

### Projekt 2: Enterprise sustav upravljanja promptovima

**Cilj:** Razviti sustav temeljen na MCP-u za upravljanje, verzioniranje i implementaciju predložaka promptova u organizaciji.

**Zahtjevi:**  
- Kreirati centralizirani repozitorij predložaka promptova  
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

**Tehnologije:** Po izboru backend framework, SQL ili NoSQL baza podataka i frontend framework za upravljačko sučelje.

### Projekt 3: Platforma za generiranje sadržaja temeljena na MCP-u

**Cilj:** Izgraditi platformu za generiranje sadržaja koja koristi MCP za dosljedne rezultate kroz različite vrste sadržaja.

**Zahtjevi:**  
- Podrška za više formata sadržaja (blog postovi, društvene mreže, marketinški tekstovi)  
- Implementacija generiranja temeljenog na predlošcima s opcijama prilagodbe  
- Kreiranje sustava za pregled i povratne informacije o sadržaju  
- Praćenje metrike performansi sadržaja  
- Podrška za verzioniranje i iteracije sadržaja  

**Koraci implementacije:**  
1. Postaviti MCP klijentsku infrastrukturu  
2. Kreirati predloške za različite vrste sadržaja  
3. Izgraditi cjevovod za generiranje sadržaja  
4. Implementirati sustav pregleda  
5. Razviti sustav praćenja metrika  
6. Kreirati korisničko sučelje za upravljanje predlošcima i generiranje sadržaja  

**Tehnologije:** Po izboru programski jezik, web framework i sustav baze podataka.

## Budući smjerovi MCP tehnologije

### Novi trendovi

1. **Multi-modalni MCP**  
   - Proširenje MCP-a za standardizaciju interakcija s modelima za slike, zvuk i video  
   - Razvoj sposobnosti međumodalnog rezoniranja  
   - Standardizirani formati promptova za različite modalitete  

2. **Federirana MCP infrastruktura**  
   - Distribuirane MCP mreže koje mogu dijeliti resurse između organizacija  
   - Standardizirani protokoli za sigurnu razmjenu modela  
   - Tehnike privatnosti za očuvanje podataka tijekom izračuna  

3. **MCP tržišta**  
   - Ekosustavi za dijeljenje i unovčavanje MCP predložaka i dodataka  
   - Procesi osiguranja kvalitete i certifikacije  
   - Integracija s tržištima modela  

4. **MCP za Edge računarstvo**  
   - Prilagodba MCP standarda za uređaje s ograničenim resursima  
   - Optimizirani protokoli za okruženja s niskom propusnošću  
   - Specijalizirane MCP implementacije za IoT ekosustave  

5. **Regulatorni okviri**  
   - Razvoj MCP ekstenzija za usklađenost s regulativama  
   - Standardizirani audit tragovi i sučelja za objašnjivost  
   - Integracija s novim okvirima upravljanja AI-jem  

### MCP rješenja od Microsofta

Microsoft i Azure razvili su nekoliko open-source repozitorija koji pomažu developerima u implementaciji MCP-a u različitim scenarijima:

#### Microsoft Organization  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – Playwright MCP server za automatizaciju i testiranje preglednika  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – OneDrive MCP server implementacija za lokalno testiranje i doprinos zajednice  
3. [NLWeb](https://github.com/microsoft/NlWeb) – NLWeb je zbirka otvorenih protokola i povezanih open source alata, s fokusom na temeljni sloj za AI Web  

#### Azure-Samples Organization  
1. [mcp](https://github.com/Azure-Samples/mcp) – Linkovi na primjere, alate i resurse za izgradnju i integraciju MCP servera na Azureu koristeći više jezika  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) – Referentni MCP serveri koji demonstriraju autentikaciju prema trenutačnoj specifikaciji Model Context Protocol-a  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – Početna stranica za implementacije Remote MCP servera u Azure Functions s linkovima na jezične repozitorije  
4. [remote-mcp-functions-python](https://github.com/Azure
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
3. Istražite industriju koja nije obuhvaćena studijama slučaja i opišite kako bi MCP mogao riješiti njezine specifične izazove.
4. Istražite jedan od budućih smjerova i osmislite koncept nove MCP ekstenzije koja bi ga podržavala.

Sljedeće: [Best Practices](../08-BestPractices/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument preveden je korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.