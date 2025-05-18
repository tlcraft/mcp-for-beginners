<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a6482c201133cb6cb0742918b373a523",
  "translation_date": "2025-05-17T16:40:57+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "hr"
}
-->
# Lekcije od ranih usvojitelja

## Pregled

Ova lekcija istražuje kako su rani usvojitelji iskoristili Model Context Protocol (MCP) za rješavanje stvarnih izazova i poticanje inovacija u različitim industrijama. Kroz detaljne studije slučaja i praktične projekte, vidjet ćete kako MCP omogućuje standardiziranu, sigurnu i skalabilnu AI integraciju—povezujući velike jezične modele, alate i podatke poduzeća u jedinstven okvir. Steći ćete praktično iskustvo u dizajniranju i izgradnji rješenja temeljenih na MCP-u, učiti iz dokazanih obrazaca implementacije i otkriti najbolje prakse za implementaciju MCP-a u proizvodnim okruženjima. Lekcija također ističe nove trendove, buduće smjerove i resurse otvorenog koda kako biste ostali na čelu MCP tehnologije i njezinog razvijajućeg ekosustava.

## Ciljevi učenja

- Analizirati stvarne MCP implementacije u različitim industrijama
- Dizajnirati i izgraditi kompletne aplikacije temeljene na MCP-u
- Istražiti nove trendove i buduće smjerove u MCP tehnologiji
- Primijeniti najbolje prakse u stvarnim razvojnim scenarijima

## Stvarne MCP implementacije

### Studija slučaja 1: Automatizacija korisničke podrške u poduzeću

Multinacionalna korporacija implementirala je rješenje temeljeno na MCP-u za standardizaciju AI interakcija unutar svojih sustava korisničke podrške. To im je omogućilo:

- Stvoriti jedinstveno sučelje za više LLM pružatelja
- Održavati dosljedno upravljanje upitima među odjelima
- Implementirati robusne sigurnosne i usklađene kontrole
- Lako prebacivati između različitih AI modela prema specifičnim potrebama

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

**Rezultati:** 30% smanjenje troškova modela, 45% poboljšanje u dosljednosti odgovora i poboljšana usklađenost u globalnim operacijama.

### Studija slučaja 2: Asistent za dijagnostiku u zdravstvu

Pružatelj zdravstvenih usluga razvio je MCP infrastrukturu za integraciju više specijaliziranih medicinskih AI modela uz osiguranje zaštite osjetljivih podataka pacijenata:

- Besprijekorno prebacivanje između općih i specijaliziranih medicinskih modela
- Stroge kontrole privatnosti i tragovi revizije
- Integracija s postojećim sustavima elektroničkih zdravstvenih kartona (EHR)
- Dosljedno inženjering upita za medicinsku terminologiju

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

**Rezultati:** Poboljšane dijagnostičke sugestije za liječnike uz potpuno poštivanje HIPAA-e i značajno smanjenje prebacivanja konteksta između sustava.

### Studija slučaja 3: Analiza rizika u financijskim uslugama

Financijska institucija implementirala je MCP za standardizaciju svojih procesa analize rizika među različitim odjelima:

- Stvoreno jedinstveno sučelje za modele kreditnog rizika, otkrivanja prijevara i investicijskog rizika
- Implementirane stroge kontrole pristupa i verzioniranje modela
- Osigurana revizija svih AI preporuka
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

### Studija slučaja 4: Microsoft Playwright MCP Server za automatizaciju preglednika

Microsoft je razvio [Playwright MCP server](https://github.com/microsoft/playwright-mcp) kako bi omogućio sigurnu, standardiziranu automatizaciju preglednika putem Model Context Protocola. Ovo rješenje omogućuje AI agentima i LLM-ovima interakciju s web preglednicima na kontroliran, revizibilan i proširiv način—omogućujući slučajeve upotrebe kao što su automatizirano testiranje weba, izvlačenje podataka i end-to-end tijekovi rada.

- Izlaže mogućnosti automatizacije preglednika (navigacija, popunjavanje obrazaca, snimanje zaslona, itd.) kao MCP alate
- Implementira stroge kontrole pristupa i sandboxing za sprječavanje neovlaštenih radnji
- Pruža detaljne zapisnike revizije za sve interakcije preglednika
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
- Smanjen ručni napor testiranja i poboljšana pokrivenost testiranja za web aplikacije
- Pružena ponovna iskoristiva, proširiva platforma za integraciju alata temeljenih na pregledniku u poslovnim okruženjima

**Reference:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Studija slučaja 5: Azure MCP – Protokol konteksta modela na razini poduzeća kao usluga

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) je Microsoftova upravljana, implementacija Model Context Protocola na razini poduzeća, dizajnirana za pružanje skalabilnih, sigurnih i usklađenih mogućnosti MCP servera kao usluge u oblaku. Azure MCP omogućuje organizacijama brzo implementiranje, upravljanje i integraciju MCP servera s Azure AI, podacima i sigurnosnim uslugama, smanjujući operativne troškove i ubrzavajući usvajanje AI.

- Potpuno upravljano hosting MCP servera s ugrađenim skaliranjem, praćenjem i sigurnošću
- Izvorna integracija s Azure OpenAI, Azure AI Search i drugim Azure uslugama
- Poslovna autentifikacija i autorizacija putem Microsoft Entra ID
- Podrška za prilagođene alate, predloške upita i konektore resursa
- Usklađenost sa sigurnosnim i regulatornim zahtjevima poduzeća

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
- Smanjeno vrijeme do vrijednosti za AI projekte u poduzeću pružanjem spremne platforme za MCP servere u skladu s propisima
- Pojednostavljena integracija LLM-ova, alata i izvora podataka poduzeća
- Poboljšana sigurnost, vidljivost i operativna učinkovitost za MCP radna opterećenja

**Reference:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Praktični projekti

### Projekt 1: Izgradnja MCP servera s više pružatelja usluga

**Cilj:** Stvoriti MCP server koji može usmjeravati zahtjeve prema više pružatelja AI modela na temelju specifičnih kriterija.

**Zahtjevi:**
- Podrška za najmanje tri različita pružatelja modela (npr. OpenAI, Anthropic, lokalni modeli)
- Implementacija mehanizma usmjeravanja na temelju metapodataka zahtjeva
- Kreiranje sustava konfiguracije za upravljanje vjerodajnicama pružatelja
- Dodavanje predmemoriranja za optimizaciju performansi i troškova
- Izgradnja jednostavne nadzorne ploče za praćenje upotrebe

**Koraci implementacije:**
1. Postavljanje osnovne infrastrukture MCP servera
2. Implementacija adaptera pružatelja za svaku AI model uslugu
3. Kreiranje logike usmjeravanja na temelju atributa zahtjeva
4. Dodavanje mehanizama predmemoriranja za česte zahtjeve
5. Razvoj nadzorne ploče za praćenje
6. Testiranje s raznim obrascima zahtjeva

**Tehnologije:** Izaberite između Python (.NET/Java/Python prema vašoj preferenciji), Redis za predmemoriranje i jednostavni web okvir za nadzornu ploču.

### Projekt 2: Sustav za upravljanje upitima u poduzeću

**Cilj:** Razviti sustav temeljen na MCP-u za upravljanje, verzioniranje i implementaciju predložaka upita unutar organizacije.

**Zahtjevi:**
- Kreiranje centraliziranog spremišta za predloške upita
- Implementacija verzioniranja i radnih tijekova odobrenja
- Izgradnja mogućnosti testiranja predložaka sa uzorcima unosa
- Razvoj kontrole pristupa temeljenog na ulogama
- Kreiranje API-ja za dohvaćanje i implementaciju predložaka

**Koraci implementacije:**
1. Dizajn sheme baze podataka za pohranu predložaka
2. Kreiranje osnovnog API-ja za CRUD operacije predložaka
3. Implementacija sustava verzioniranja
4. Izgradnja tijeka rada za odobrenje
5. Razvoj okvira za testiranje
6. Kreiranje jednostavnog web sučelja za upravljanje
7. Integracija s MCP serverom

**Tehnologije:** Vaš izbor backend okvira, SQL ili NoSQL baze podataka i frontend okvir za upravljačko sučelje.

### Projekt 3: Platforma za generiranje sadržaja temeljena na MCP-u

**Cilj:** Izgraditi platformu za generiranje sadržaja koja koristi MCP za pružanje dosljednih rezultata za različite vrste sadržaja.

**Zahtjevi:**
- Podrška za više formata sadržaja (blog postovi, društveni mediji, marketinški tekstovi)
- Implementacija generiranja temeljenog na predlošcima s opcijama prilagodbe
- Kreiranje sustava za pregled i povratne informacije o sadržaju
- Praćenje metrika izvedbe sadržaja
- Podrška za verzioniranje i iteraciju sadržaja

**Koraci implementacije:**
1. Postavljanje infrastrukture MCP klijenta
2. Kreiranje predložaka za različite vrste sadržaja
3. Izgradnja cjevovoda za generiranje sadržaja
4. Implementacija sustava pregleda
5. Razvoj sustava za praćenje metrika
6. Kreiranje korisničkog sučelja za upravljanje predlošcima i generiranje sadržaja

**Tehnologije:** Vaš preferirani programski jezik, web okvir i sustav baze podataka.

## Budući smjerovi za MCP tehnologiju

### Novi trendovi

1. **Višemedijski MCP**
   - Proširenje MCP-a za standardizaciju interakcija s modelima za slike, zvuk i video
   - Razvoj sposobnosti zaključivanja između modaliteta
   - Standardizirani formati upita za različite modalitete

2. **Federirana MCP infrastruktura**
   - Distribuirane MCP mreže koje mogu dijeliti resurse među organizacijama
   - Standardizirani protokoli za sigurno dijeljenje modela
   - Tehnike privatnog računanja

3. **MCP tržišta**
   - Ekosustavi za dijeljenje i monetizaciju MCP predložaka i dodataka
   - Procesi osiguranja kvalitete i certificiranja
   - Integracija s tržištima modela

4. **MCP za rubno računalstvo**
   - Prilagodba MCP standarda za uređaje s ograničenim resursima
   - Optimizirani protokoli za okruženja s niskom propusnošću
   - Specijalizirane MCP implementacije za IoT ekosustave

5. **Regulatorni okviri**
   - Razvoj MCP proširenja za regulatornu usklađenost
   - Standardizirani tragovi revizije i sučelja za objašnjivost
   - Integracija s novim okvirima upravljanja AI-jem

### MCP rješenja iz Microsofta

Microsoft i Azure razvili su nekoliko repozitorija otvorenog koda kako bi pomogli developerima u implementaciji MCP-a u raznim scenarijima:

#### Microsoftova organizacija
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Playwright MCP server za automatizaciju i testiranje preglednika
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Implementacija OneDrive MCP servera za lokalno testiranje i doprinos zajednice

#### Azure-Samples organizacija
1. [mcp](https://github.com/Azure-Samples/mcp) - Poveznice na uzorke, alate i resurse za izgradnju i integraciju MCP servera na Azureu koristeći više jezika
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Referentni MCP serveri koji demonstriraju autentifikaciju s trenutnom specifikacijom Model Context Protocola
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Početna stranica za implementacije Remote MCP servera u Azure Functions s poveznicama na repozitorije specifične za jezik
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Predložak za brzo pokretanje za izgradnju i implementaciju prilagođenih udaljenih MCP servera koristeći Azure Functions s Pythonom
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Predložak za brzo pokretanje za izgradnju i implementaciju prilagođenih udaljenih MCP servera koristeći Azure Functions s .NET/C#
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Predložak za brzo pokretanje za izgradnju i implementaciju prilagođenih udaljenih MCP servera koristeći Azure Functions s TypeScriptom
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management kao AI Gateway za Remote MCP servere koristeći Python
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI eksperimenti uključujući MCP mogućnosti, integraciju s Azure OpenAI i AI Foundry

Ovi repozitoriji pružaju razne implementacije, predloške i resurse za rad s Model Context Protocolom kroz različite programske jezike i Azure usluge. Oni pokrivaju niz slučajeva upotrebe od osnovnih implementacija servera do autentifikacije, implementacije u oblaku i scenarija integracije u poduzeću.

#### Direktorij MCP resursa

Direktorij [MCP resursa](https://github.com/microsoft/mcp/tree/main/Resources) u službenom Microsoft MCP repozitoriju pruža kuriranu zbirku uzoraka resursa, predložaka upita i definicija alata za korištenje s Model Context Protocol serverima. Ovaj direktorij je dizajniran kako bi pomogao developerima da brzo započnu s MCP-om nudeći ponovo iskoristive građevne blokove i primjere najboljih praksi za:

- **Predlošci upita:** Predlošci upita spremni za korištenje za uobičajene AI zadatke i scenarije, koji se mogu prilagoditi za vlastite MCP server implementacije.
- **Definicije alata:** Primjeri shema alata i metapodaci za standardizaciju integracije i pozivanja alata na različitim MCP serverima.
- **Uzorci resursa:** Primjeri definicija resursa za povezivanje s izvorima podataka, API-ima i vanjskim uslugama unutar MCP okvira.
- **Referentne implementacije:** Praktični uzorci koji pokazuju kako strukturirati i organizirati resurse, upite i alate u stvarnim MCP projektima.

Ovi resursi ubrzavaju razvoj, promiču standardizaciju i pomažu osigurati najbolje prakse pri izgradnji i implementaciji rješenja temeljenih na MCP-u.

#### Direktorij MCP resursa
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Istraživačke mogućnosti

- Učinkovite tehnike optimizacije upita unutar MCP okvira
- Sigurnosni modeli za MCP implementacije s više stanara
- Benchmarking performansi različitih MCP implementacija
- Formalne metode verifikacije za MCP servere

## Zaključak

Model Context Protocol (MCP) brzo oblikuje budućnost standardizirane, sigurne i interoperabilne AI integracije u različitim industrijama. Kroz studije slučaja i praktične projekte u ovoj lekciji, vidjeli ste kako rani usvojitelji—uključujući Microsoft i Azure—koriste MCP za rješavanje stvarnih izazova, ubrzanje usvajanja AI i osiguranje usklađenosti, sigurnosti i skalabilnosti. MCP-ov modularni pristup omogućuje organizacijama povezivanje velikih jezičnih modela, alata i podataka poduzeća u jedinstven, revizibilan okvir. Kako MCP nastavlja evoluirati, ostati angažiran s zajednicom, istraživ
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Vježbe

1. Analizirajte jednu od studija slučaja i predložite alternativni pristup implementaciji.
2. Odaberite jednu od ideja za projekte i izradite detaljnu tehničku specifikaciju.
3. Istražite industriju koja nije pokrivena u studijama slučaja i opišite kako MCP može riješiti njezine specifične izazove.
4. Istražite jedan od budućih smjerova i izradite koncept za novu MCP ekstenziju koja će ga podržati.

Sljedeće: [Najbolje prakse](../08-BestPractices/README.md)

**Odricanje odgovornosti**:  
Ovaj dokument je preveden pomoću AI usluge prevođenja [Co-op Translator](https://github.com/Azure/co-op-translator). Iako se trudimo da prevod bude tačan, imajte na umu da automatski prevodi mogu sadržavati greške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.