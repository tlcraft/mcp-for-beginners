<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1ccfe1a6ea77e42862b92ae53cb6cddf",
  "translation_date": "2025-05-20T18:26:17+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "sl"
}
-->
# Lekcije od zgodnjih uporabnikov

## Pregled

Ta lekcija raziskuje, kako so zgodnji uporabniki izkoristili Model Context Protocol (MCP) za reševanje resničnih izzivov in spodbujanje inovacij v različnih panogah. S podrobnimi študijami primerov in praktičnimi projekti boste videli, kako MCP omogoča standardizirano, varno in razširljivo integracijo AI — povezuje velike jezikovne modele, orodja in podatke podjetij v enotnem okviru. Pridobili boste praktične izkušnje z načrtovanjem in gradnjo rešitev na osnovi MCP, se naučili preverjenih vzorcev implementacije ter odkrili najboljše prakse za uvajanje MCP v produkcijska okolja. Lekcija prav tako izpostavlja nastajajoče trende, prihodnje smeri in odprtokodne vire, ki vam bodo pomagali ostati na čelu tehnologije MCP in njenega razvijajočega se ekosistema.

## Cilji učenja

- Analizirati resnične implementacije MCP v različnih panogah  
- Načrtovati in zgraditi celovite aplikacije na osnovi MCP  
- Raziščite nastajajoče trende in prihodnje smeri tehnologije MCP  
- Uporabiti najboljše prakse v dejanskih razvojnih scenarijih  

## Resnične implementacije MCP

### Študija primera 1: Avtomatizacija podpore strankam v podjetjih

Multinacionalno podjetje je uvedlo rešitev na osnovi MCP za standardizacijo AI interakcij v sistemih podpore strankam. To jim je omogočilo:

- Ustvariti enotno vmesnik za več ponudnikov LLM  
- Ohranjati dosledno upravljanje pozivov med oddelki  
- Uvesti robustne varnostne in skladnostne kontrole  
- Enostavno preklapljati med različnimi AI modeli glede na specifične potrebe  

**Tehnična implementacija:**  
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

**Rezultati:** 30 % zmanjšanje stroškov modelov, 45 % izboljšanje konsistence odgovorov in izboljšana skladnost v globalnih operacijah.

### Študija primera 2: Zdravstveni diagnostični pomočnik

Zdravstveni ponudnik je razvil MCP infrastrukturo za integracijo več specializiranih medicinskih AI modelov, ob zagotavljanju varstva občutljivih podatkov pacientov:

- Gladko preklapljanje med splošnimi in specialističnimi medicinskimi modeli  
- Stroge kontrole zasebnosti in revizijske sledi  
- Integracija z obstoječimi sistemi elektronskih zdravstvenih kartonov (EHR)  
- Dosledno oblikovanje pozivov za medicinsko terminologijo  

**Tehnična implementacija:**  
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

**Rezultati:** Izboljšani diagnostični predlogi za zdravnike, ohranjanje popolne skladnosti s HIPAA in znatno zmanjšanje menjave konteksta med sistemi.

### Študija primera 3: Analiza tveganj v finančnih storitvah

Finančna institucija je uvedla MCP za standardizacijo procesov analize tveganj v različnih oddelkih:

- Ustvarjen enoten vmesnik za modele kreditnega tveganja, odkrivanja prevar in investicijskega tveganja  
- Uvedene stroge kontrole dostopa in verzioniranje modelov  
- Zagotovljena revizijska sled vseh AI priporočil  
- Ohranjena dosledna oblikovanje podatkov med različnimi sistemi  

**Tehnična implementacija:**  
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

**Rezultati:** Izboljšana skladnost z regulativami, 40 % hitrejši cikli uvajanja modelov in izboljšana konsistentnost ocenjevanja tveganj med oddelki.

### Študija primera 4: Microsoft Playwright MCP strežnik za avtomatizacijo brskalnika

Microsoft je razvil [Playwright MCP strežnik](https://github.com/microsoft/playwright-mcp) za omogočanje varne, standardizirane avtomatizacije brskalnika preko Model Context Protocol. Ta rešitev omogoča AI agentom in LLM-jem interakcijo z brskalniki na nadzorovan, revizijski in razširljiv način — podpirajoč primere uporabe, kot so avtomatizirano spletno testiranje, ekstrakcija podatkov in celoviti delovni tokovi.

- Ponuja zmožnosti avtomatizacije brskalnika (navigacija, izpolnjevanje obrazcev, zajem zaslonskih slik itd.) kot MCP orodja  
- Uvaja stroge kontrole dostopa in peskovnik za preprečevanje nepooblaščenih dejanj  
- Zagotavlja podrobne revizijske dnevnike vseh interakcij z brskalnikom  
- Podpira integracijo z Azure OpenAI in drugimi ponudniki LLM za avtomatizacijo, ki jo vodijo agenti  

**Tehnična implementacija:**  
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
- Omogočena varna, programabilna avtomatizacija brskalnika za AI agente in LLM-je  
- Zmanjšano ročno testiranje in izboljšano pokritje testov spletnih aplikacij  
- Zagotovljen večkratni, razširljiv okvir za integracijo orodij na osnovi brskalnika v podjetniških okoljih  

**Reference:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Študija primera 5: Azure MCP – podjetniška izvedba Model Context Protocol kot storitve

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) je Microsoftova upravljana, podjetniško usmerjena implementacija Model Context Protocol, zasnovana za zagotavljanje razširljivih, varnih in skladnih MCP strežniških zmogljivosti kot oblačne storitve. Azure MCP omogoča organizacijam hitro uvajanje, upravljanje in integracijo MCP strežnikov z Azure AI, podatki in varnostnimi storitvami, s čimer zmanjšuje operativno breme in pospešuje sprejemanje AI.

- Popolnoma upravljano gostovanje MCP strežnika z vgrajenim skaliranjem, nadzorom in varnostjo  
- Nativna integracija z Azure OpenAI, Azure AI Search in drugimi Azure storitvami  
- Podjetniška avtentikacija in avtorizacija preko Microsoft Entra ID  
- Podpora za prilagojena orodja, predloge pozivov in povezovalce virov  
- Skladnost s podjetniškimi varnostnimi in regulativnimi zahtevami  

**Tehnična implementacija:**  
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
- Zmanjšan čas do vrednosti za podjetniške AI projekte z zagotavljanjem pripravljene, skladne MCP strežniške platforme  
- Poenostavljena integracija LLM-jev, orodij in virov podatkov podjetij  
- Izboljšana varnost, opazovanje in operativna učinkovitost za MCP delovne obremenitve  

**Reference:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Študija primera 6: NLWeb  
MCP (Model Context Protocol) je nastajajoči protokol za klepetalne bote in AI pomočnike za interakcijo z orodji. Vsak primer NLWeb je tudi MCP strežnik, ki podpira eno glavno metodo, ask, s katero lahko v naravnem jeziku postavite vprašanje spletni strani. Vrnjeni odgovor uporablja schema.org, široko uporabljeno slovarico za opis spletnih podatkov. Na grobo rečeno, MCP je NLWeb, kot je HTTP za HTML. NLWeb združuje protokole, formate Schema.org in vzorčno kodo, da pomaga spletnim mestom hitro ustvariti te končne točke, kar koristi tako ljudem prek pogovornih vmesnikov kot strojem prek naravne interakcije med agenti.

NLWeb ima dva ločena dela.  
- Protokol, zelo preprost za začetek, za povezavo s spletnim mestom v naravnem jeziku in format, ki uporablja json in schema.org za vrnjeni odgovor. Za več podrobnosti glejte dokumentacijo REST API.  
- Enostavna implementacija (1), ki uporablja obstoječo označbo za spletna mesta, ki jih je mogoče predstaviti kot sezname elementov (izdelki, recepti, znamenitosti, ocene itd.). Skupaj z naborom uporabniških vmesnikov lahko spletna mesta enostavno ponudijo pogovorne vmesnike do svoje vsebine. Za več podrobnosti glejte dokumentacijo o življenjskem ciklu klepetalnega poizvedovanja.  

**Reference:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Študija primera 7: MCP za Foundry – integracija Azure AI agentov

Azure AI Foundry MCP strežniki prikazujejo, kako se MCP lahko uporablja za orkestracijo in upravljanje AI agentov ter delovnih tokov v podjetniških okoljih. Z integracijo MCP z Azure AI Foundry lahko organizacije standardizirajo interakcije agentov, izkoristijo upravljanje delovnih tokov Foundry ter zagotovijo varna in razširljiva uvajanja. Ta pristop omogoča hitro prototipiranje, robustno spremljanje in brezhibno integracijo z Azure AI storitvami, podpira napredne primere, kot so upravljanje znanja in ocenjevanje agentov. Razvijalci pridobijo enoten vmesnik za gradnjo, uvajanje in spremljanje agentnih procesov, IT ekipe pa izboljšano varnost, skladnost in operativno učinkovitost. Rešitev je idealna za podjetja, ki želijo pospešiti sprejemanje AI in ohraniti nadzor nad kompleksnimi procesi, ki jih vodijo agenti.

**Reference:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Študija primera 8: Foundry MCP Playground – eksperimentiranje in prototipiranje

Foundry MCP Playground ponuja okolje, pripravljeno za uporabo, za eksperimentiranje s MCP strežniki in integracijami Azure AI Foundry. Razvijalci lahko hitro izdelujejo prototipe, testirajo in ocenjujejo AI modele ter agentne delovne tokove z viri iz Azure AI Foundry kataloga in laboratorijev. Playground poenostavi nastavitev, ponuja vzorčne projekte in podpira sodelovalni razvoj, kar olajša raziskovanje najboljših praks in novih scenarijev z minimalnim naporom. Še posebej je uporaben za ekipe, ki želijo potrditi ideje, deliti eksperimente in pospešiti učenje brez potrebe po kompleksni infrastrukturi. Z zniževanjem vstopnih ovir playground spodbuja inovacije in prispevke skupnosti v ekosistemu MCP in Azure AI Foundry.

**Reference:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Praktični projekti

### Projekt 1: Zgradite MCP strežnik z več ponudniki

**Cilj:** Ustvariti MCP strežnik, ki lahko usmerja zahteve do več ponudnikov AI modelov glede na določena merila.

**Zahteve:**  
- Podpora za vsaj tri različne ponudnike modelov (npr. OpenAI, Anthropic, lokalni modeli)  
- Implementacija mehanizma usmerjanja na podlagi metapodatkov zahtev  
- Ustvarjanje konfiguracijskega sistema za upravljanje poverilnic ponudnikov  
- Dodajanje predpomnjenja za optimizacijo zmogljivosti in stroškov  
- Izgradnja preprostega nadzornega panela za spremljanje uporabe  

**Koraki implementacije:**  
1. Nastavitev osnovne infrastrukture MCP strežnika  
2. Implementacija adapterjev ponudnikov za vsako AI storitev  
3. Ustvarjanje logike usmerjanja glede na atribute zahtev  
4. Dodajanje mehanizmov predpomnjenja za pogoste zahteve  
5. Razvoj nadzornega panela za spremljanje  
6. Testiranje z različnimi vzorci zahtev  

**Tehnologije:** Izberite med Python (.NET/Java/Python glede na vašo izbiro), Redis za predpomnjenje in preprost spletni okvir za nadzorni panel.

### Projekt 2: Podjetniški sistem za upravljanje pozivov

**Cilj:** Razviti sistem na osnovi MCP za upravljanje, verzioniranje in uvajanje predlog pozivov v organizaciji.

**Zahteve:**  
- Ustvariti centraliziran repozitorij za predloge pozivov  
- Implementirati verzioniranje in odobritvene delovne tokove  
- Razviti zmogljivosti testiranja predlog s primeri vhodov  
- Razviti nadzor dostopa na podlagi vlog  
- Ustvariti API za pridobivanje in uvajanje predlog  

**Koraki implementacije:**  
1. Oblikovanje sheme baze podatkov za shranjevanje predlog  
2. Ustvarjanje osnovnega API-ja za CRUD operacije s predlogami  
3. Implementacija sistema verzioniranja  
4. Izgradnja odobritvenega delovnega toka  
5. Razvoj testnega okvira  
6. Ustvarjanje preprostega spletnega vmesnika za upravljanje  
7. Integracija z MCP strežnikom  

**Tehnologije:** Poljubna izbira backend okvira, SQL ali NoSQL baze podatkov in frontend okvirja za upravljalski vmesnik.

### Projekt 3: Platforma za generiranje vsebin na osnovi MCP

**Cilj:** Zgraditi platformo za generiranje vsebin, ki uporablja MCP za zagotavljanje doslednih rezultatov v različnih vrstah vsebin.

**Zahteve:**  
- Podpora za več formatov vsebin (blog objave, družbena omrežja, marketinški tekst)  
- Implementacija generiranja na osnovi predlog s možnostmi prilagoditve  
- Ustvarjanje sistema za pregled in povratne informacije vsebin  
- Sledenje metrikam uspešnosti vsebin  
- Podpora verzioniranju in iteraciji vsebin  

**Koraki implementacije:**  
1. Nastavitev MCP odjemalske infrastrukture  
2. Ustvarjanje predlog za različne vrste vsebin  
3. Izgradnja procesa generiranja vsebin  
4. Implementacija sistema pregleda  
5. Razvoj sistema za sledenje metrik  
6. Ustvarjanje uporabniškega vmesnika za upravljanje predlog in generiranje vsebin  

**Tehnologije:** Vaš izbrani programski jezik, spletni okvir in sistem baze podatkov.

## Prihodnje smeri tehnologije MCP

### Nastajajoči trendi

1. **Večmodalni MCP**  
   - Razširitev MCP za standardizacijo interakcij z modeli slik, zvoka in videa  
   - Razvoj zmogljivosti medmodalnega sklepanja  
   - Standardizirani formati pozivov za različne modalitete  

2. **Federirana MCP infrastruktura**  
   - Distribuirana MCP omrežja za deljenje virov med organizacijami  
   - Standardizirani protokoli za varno deljenje modelov  
   - Tehnike računalništva za varovanje zasebnosti  

3. **MCP tržnice**  
   - Ekosistemi za deljenje in monetizacijo MCP predlog in vtičnikov  
   - Procesi zagotavljanja kakovosti in certificiranja  
   - Integracija s tržnicami modelov  

4. **MCP za edge računalništvo**  
   - Prilagoditev MCP standardov za naprave z omejenimi viri na robu omrežja  
   - Optimizirani protokoli za okolja z nizko pasovno širino  
   - Specializirane MCP implementacije za IoT ekosisteme  

5. **Regulativni okviri**  
   - Razvoj razširitev MCP za skladnost z regulativami  
   - Standardizirane revizijske sledi in vmesniki za pojasnljivost  
   - Integracija z nastajajočimi okviri upravljanja AI  

### MCP rešitve Microsofta

Microsoft in Azure so razvili več odprtokodnih repozitorijev za pomoč razvijalcem pri implementaciji MCP v različnih scenarijih:

#### Microsoft organizacija  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – Playwright MCP strežnik za avtomatizacijo in testiranje brskalnika  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – OneDrive MCP strežnik za lokalno testiranje in prispevke skupnosti  
3. [NLWeb](https://github.com/microsoft/NlWeb) – zbirka odprtih protokolov in pripadajočih odprtokodnih orodij, osredotočenih na vzpostavitev temeljnega sloja za AI splet  

#### Azure-Samples organizacija  
1. [mcp](https://github.com/Azure-Samples/mcp) – povezave do vzorcev, orodij in virov za gradnjo in integracijo MCP strežnikov na Azure z različnimi jeziki  
2. [mcp-auth-servers](https://github.com/Azure-S
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

## Vaje

1. Analizirajte eno od študij primerov in predlagajte alternativni pristop k izvedbi.
2. Izberite eno od idej za projekt in pripravite podrobno tehnično specifikacijo.
3. Raziskujte industrijo, ki ni zajeta v študijah primerov, in opišite, kako bi MCP lahko rešil njene posebne izzive.
4. Raziščite eno od prihodnjih smeri in ustvarite koncept za novo MCP razširitev, ki bi jo podpirala.

Naslednje: [Best Practices](../08-BestPractices/README.md)

**Izjava o omejitvi odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvor nem jeziku naj se šteje za avtoritativni vir. Za kritične informacije priporočamo strokovni človeški prevod. Za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne prevzemamo odgovornosti.