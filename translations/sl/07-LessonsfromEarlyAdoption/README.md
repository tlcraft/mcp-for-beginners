<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T22:45:23+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "sl"
}
-->
# Lekcije od Rannih Korisnikov

## Pregled

Ta lekcija raziskuje, kako so ranni uporabniki izkoristili Model Context Protocol (MCP) za reševanje resničnih izzivov in spodbujanje inovacij v različnih panogah. S pomočjo podrobnih študij primerov in praktičnih projektov boste videli, kako MCP omogoča standardizirano, varno in razširljivo integracijo umetne inteligence – povezuje velike jezikovne modele, orodja in podatke podjetij v enotnem okviru. Pridobili boste praktične izkušnje pri načrtovanju in gradnji rešitev, ki temeljijo na MCP, spoznali preverjene vzorce implementacije in odkrili najboljše prakse za uvajanje MCP v produkcijska okolja. Lekcija prav tako izpostavlja nove trende, prihodnje usmeritve in odprtokodne vire, ki vam pomagajo ostati na čelu tehnologije MCP in njenega razvijajočega se ekosistema.

## Cilji učenja

- Analizirati resnične implementacije MCP v različnih industrijah
- Načrtovati in zgraditi celovite aplikacije na osnovi MCP
- Raziščite nastajajoče trende in prihodnje smernice v tehnologiji MCP
- Uporabiti najboljše prakse v dejanskih razvojnih scenarijih

## Resnične implementacije MCP

### Študija primera 1: Avtomatizacija podpore strankam v podjetjih

Mednarodno podjetje je uvedlo rešitev na osnovi MCP za standardizacijo interakcij z AI v svojih sistemih za podporo strankam. To jim je omogočilo:

- Ustvariti enoten vmesnik za več ponudnikov LLM
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

**Rezultati:** 30 % znižanje stroškov modelov, 45 % izboljšanje konsistence odzivov in izboljšana skladnost v globalnih operacijah.

### Študija primera 2: Zdravstveni diagnostični pomočnik

Zdravstveni ponudnik je razvil MCP infrastrukturo za integracijo več specializiranih medicinskih AI modelov ob hkratnem zagotavljanju zaščite občutljivih pacientovih podatkov:

- Brezhibno preklapljanje med splošnimi in specialističnimi medicinskimi modeli
- Stroge kontrole zasebnosti in sledljivost
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

**Rezultati:** Izboljšani diagnostični predlogi za zdravnike ob popolni skladnosti s HIPAA in znatno zmanjšanje preklapljanja konteksta med sistemi.

### Študija primera 3: Analiza tveganj v finančnih storitvah

Finančna institucija je uvedla MCP za standardizacijo svojih procesov analize tveganj v različnih oddelkih:

- Ustvarila enoten vmesnik za modele kreditnega tveganja, odkrivanja prevar in naložbenega tveganja
- Uvedla stroge kontrole dostopa in različice modelov
- Zagotovila sledljivost vseh AI priporočil
- Ohranjala dosledno obliko podatkov v različnih sistemih

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

Microsoft je razvil [Playwright MCP strežnik](https://github.com/microsoft/playwright-mcp), ki omogoča varno in standardizirano avtomatizacijo brskalnikov preko Model Context Protocol. Ta rešitev omogoča AI agentom in LLM-jem interakcijo z brskalniki na nadzorovan, sledljiv in razširljiv način – podpirajoč primere uporabe, kot so avtomatizirano testiranje spletnih strani, ekstrakcija podatkov in celoviti delovni tokovi.

- Izpostavlja zmogljivosti avtomatizacije brskalnika (navigacija, izpolnjevanje obrazcev, zajem zaslona itd.) kot MCP orodja  
- Uvaja stroge kontrole dostopa in peskovnik za preprečevanje nepooblaščenih dejanj  
- Ponuja podrobne revizijske zapise vseh interakcij z brskalnikom  
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
- Omogočena varna, programabilna avtomatizacija brskalnikov za AI agente in LLM  
- Zmanjšan ročni napor pri testiranju in izboljšano pokritje testov spletnih aplikacij  
- Ponuja ponovno uporabljiv in razširljiv okvir za integracijo orodij, ki temeljijo na brskalniku v podjetniških okoljih

**Reference:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Študija primera 5: Azure MCP – Podjetniški Model Context Protocol kot storitev

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) je Microsoftova upravljana, podjetniško usmerjena implementacija Model Context Protocol, zasnovana za zagotavljanje razširljivih, varnih in skladnih MCP strežniških zmogljivosti kot oblačne storitve. Azure MCP omogoča organizacijam hitro uvajanje, upravljanje in integracijo MCP strežnikov z Azure AI, podatkovnimi in varnostnimi storitvami, s čimer zmanjšuje operativno breme in pospešuje uporabo AI.

- Popolnoma upravljano gostovanje MCP strežnikov z vgrajenim skaliranjem, nadzorom in varnostjo  
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
- Zmanjšan čas do vrednosti za podjetniške AI projekte z zagotavljanjem pripravljenega, skladnega MCP strežniškega okolja  
- Poenostavljena integracija LLM, orodij in virov podatkov podjetij  
- Izboljšana varnost, opazovanje in operativna učinkovitost za MCP delovne obremenitve

**Reference:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Študija primera 6: NLWeb  
MCP (Model Context Protocol) je nastajajoči protokol za klepetalne bote in AI asistente za interakcijo z orodji. Vsak primer NLWeb je tudi MCP strežnik, ki podpira eno osnovno metodo, ask, ki se uporablja za postavljanje vprašanj spletni strani v naravnem jeziku. Vrnjeni odgovor uporablja schema.org, široko uporabljeno slovarno zbirko za opis spletnih podatkov. Poenostavljeno povedano, MCP je NLWeb, kot je Http za HTML. NLWeb združuje protokole, formate Schema.org in vzorčno kodo, da pomaga spletnim mestom hitro ustvariti te končne točke, kar koristi tako ljudem prek pogovornih vmesnikov kot tudi strojem prek naravne interakcije med agenti.

NLWeb ima dva ločena dela.  
- Protokol, zelo preprost za začetek, za vmesnik s spletno stranjo v naravnem jeziku in format, ki uporablja json in schema.org za vrnjeni odgovor. Za več podrobnosti glejte dokumentacijo REST API.  
- Enostavna implementacija (1), ki uporablja obstoječo označbo, za strani, ki jih je mogoče predstaviti kot sezname predmetov (izdelki, recepti, atrakcije, ocene itd.). Skupaj z naborom uporabniških vmesnikov lahko strani enostavno ponudijo pogovorne vmesnike za svojo vsebino. Za več informacij glejte dokumentacijo o življenjskem ciklu poizvedbe klepeta.

**Reference:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Študija primera 7: MCP za Foundry – Integracija Azure AI agentov

Azure AI Foundry MCP strežniki prikazujejo, kako se MCP lahko uporablja za orkestracijo in upravljanje AI agentov in delovnih tokov v podjetniških okoljih. Z integracijo MCP z Azure AI Foundry lahko organizacije standardizirajo interakcije agentov, izkoristijo upravljanje delovnih tokov Foundry in zagotovijo varne, razširljive uvedbe. Ta pristop omogoča hitro prototipiranje, robustno spremljanje in brezhibno integracijo z Azure AI storitvami, podpira napredne scenarije, kot so upravljanje znanja in ocenjevanje agentov. Razvijalci imajo koristi od enotnega vmesnika za gradnjo, uvajanje in spremljanje agentnih procesov, IT ekipe pa izboljšano varnost, skladnost in operativno učinkovitost. Rešitev je idealna za podjetja, ki želijo pospešiti uvajanje AI in ohraniti nadzor nad kompleksnimi procesi, ki jih vodijo agenti.

**Reference:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integracija Azure AI agentov z MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Študija primera 8: Foundry MCP Playground – Eksperimentiranje in prototipiranje

Foundry MCP Playground ponuja okolje, pripravljeno za uporabo, za eksperimentiranje z MCP strežniki in integracijami Azure AI Foundry. Razvijalci lahko hitro prototipirajo, testirajo in ocenjujejo AI modele ter agentne delovne tokove z uporabo virov iz Azure AI Foundry kataloga in laboratorijev. Playground poenostavlja nastavitev, ponuja vzorčne projekte in podpira sodelovalni razvoj, kar omogoča enostavno raziskovanje najboljših praks in novih scenarijev z minimalnim naporom. Je še posebej uporaben za ekipe, ki želijo potrditi ideje, deliti eksperimente in pospešiti učenje brez potrebe po kompleksni infrastrukturi. Z zniževanjem vstopnih ovir playground spodbuja inovacije in prispevke skupnosti v ekosistemu MCP in Azure AI Foundry.

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
- Izgradnja preprostega nadzornega panela za spremljanje porabe

**Koraki implementacije:**  
1. Nastavitev osnovne MCP strežniške infrastrukture  
2. Implementacija adapterjev za ponudnike AI modelov  
3. Ustvarjanje logike usmerjanja na podlagi atributov zahtev  
4. Dodajanje mehanizmov predpomnjenja za pogoste zahteve  
5. Razvoj nadzornega panela za spremljanje  
6. Testiranje z različnimi vzorci zahtev

**Tehnologije:** Izberite med Python (.NET/Java/Python glede na vaše preference), Redis za predpomnjenje in preprost spletni okvir za nadzorni panel.

### Projekt 2: Podjetniški sistem za upravljanje pozivov

**Cilj:** Razviti sistem na osnovi MCP za upravljanje, različiciranje in uvajanje predlog pozivov v organizaciji.

**Zahteve:**  
- Ustvariti centraliziran repozitorij za predloge pozivov  
- Implementirati različiciranje in odobritvene delovne tokove  
- Izgraditi zmogljivosti testiranja predlog z vzorčnimi vnosi  
- Razviti nadzor dostopa na osnovi vlog  
- Ustvariti API za pridobivanje in uvajanje predlog

**Koraki implementacije:**  
1. Oblikovanje sheme baze podatkov za shranjevanje predlog  
2. Ustvarjanje osnovnega API-ja za CRUD operacije s predlogami  
3. Implementacija sistema različiciranja  
4. Izgradnja odobritvenega delovnega toka  
5. Razvoj testnega ogrodja  
6. Ustvarjanje preprostega spletnega vmesnika za upravljanje  
7. Integracija z MCP strežnikom

**Tehnologije:** Izberite svoj priljubljeni backend okvir, SQL ali NoSQL bazo podatkov in frontend okvir za upravljalski vmesnik.

### Projekt 3: Platforma za generiranje vsebin na osnovi MCP

**Cilj:** Zgraditi platformo za generiranje vsebin, ki uporablja MCP za zagotavljanje doslednih rezultatov v različnih vrstah vsebin.

**Zahteve:**  
- Podpora za več formatov vsebin (blog zapisi, družbena omrežja, marketinški teksti)  
- Implementacija generiranja na osnovi predlog s prilagoditvami  
- Ustvarjanje sistema za pregled in povratne informacije vsebin  
- Spremljanje metrik uspešnosti vsebin  
- Podpora različiciranju in iteraciji vsebin

**Koraki implementacije:**  
1. Nastavitev MCP odjemalske infrastrukture  
2. Ustvarjanje predlog za različne vrste vsebin  
3. Izgradnja cevovoda za generiranje vsebin  
4. Implementacija sistema za pregledovanje  
5. Razvoj sistema za spremljanje metrik  
6. Ustvarjanje uporabniškega vmesnika za upravljanje predlog in generiranje vsebin

**Tehnologije:** Vaš izbrani programski jezik, spletni okvir in sistem za bazo podatkov.

## Prihodnje smernice za tehnologijo MCP

### Nastajajoči trendi

1. **Večmodalni MCP**  
   - Razširitev MCP za standardizacijo interakcij z modeli za slike, zvok in video  
   - Razvoj zmogljivosti za medmodalno sklepanje  
   - Standardizirani formati pozivov za različne modalitete

2. **Federirana MCP infrastruktura**  
   - Distribuirana MCP omrežja za izmenjavo virov med organizacijami  
   - Standardizirani protokoli za varno deljenje modelov  
   - Tehnike za varovanje zasebnosti pri izračunih

3. **MCP tržnice**  
   - Ekosistemi za deljenje in monetizacijo MCP predlog in vtičnikov  
   - Procesi zagotavljanja kakovosti in certificiranja  
   - Integracija s tržnicami modelov

4. **MCP za edge računalništvo**  
   - Prilagoditev MCP standardov za naprave z omejenimi viri na robu omrežja  
   - Optimizirani protokoli za okolja z nizko pasovno širino  
   - Specializirane implementacije MCP za IoT ekosisteme

5. **Regulativni okviri**  
   - Razvoj razširitev MCP za skladnost z regulativami  
   - Standardizirane revizijske sledi in vmesniki za razložljivost  
   - Integracija z nastajajočimi okviri za upravljanje AI

### MCP rešitve iz Microsofta

Microsoft in Azure sta razvila več odprtokodnih repozitorijev, ki pomagajo razvijalcem implementirati MCP v različnih scenarijih:

#### Microsoft organizacija  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – Playwright MCP strežnik za avtomatizacijo in testiranje brskalnikov  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – OneDrive MCP strežnik za lokalno testiranje in prispevke skupnosti  
3. [NLWeb](https://github.com/microsoft/NlWeb) – Zbirka odprtih protokolov in pripadajočih odprtokodnih orodij, osredotočenih na osnovno plast za AI splet

#### Azure-Samples organizacija  
1. [mcp](https://github.com/Azure-Samples/mcp) – Vzorci, orodja in viri za gradnjo in integracijo MCP strežnikov na Azure z več jeziki  
2. [mcp-auth-servers](
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
3. Istražite industriju koja nije obrađena u studijama slučaja i opišite kako bi MCP mogao riješiti njene specifične izazove.
4. Istražite jedan od budućih smjerova i osmislite koncept nove MCP ekstenzije koja bi ga podržavala.

Sljedeće: [Best Practices](../08-BestPractices/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za kakršne koli nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.