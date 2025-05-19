<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "344a126b620ff7997158542fd31be6a4",
  "translation_date": "2025-05-19T22:33:10+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "sl"
}
-->
# Lekcije od zgodnjih uporabnikov

## Pregled

Ta lekcija raziskuje, kako so zgodnji uporabniki izkoristili Model Context Protocol (MCP) za reševanje resničnih izzivov in spodbujanje inovacij v različnih panogah. S podrobnimi študijami primerov in praktičnimi projekti boste videli, kako MCP omogoča standardizirano, varno in razširljivo integracijo umetne inteligence – povezuje velike jezikovne modele, orodja in podatke podjetij v enotnem okviru. Pridobili boste praktične izkušnje z načrtovanjem in izdelavo rešitev na osnovi MCP, se naučili preverjenih vzorcev implementacije ter odkrili najboljše prakse za uvajanje MCP v produkcijska okolja. Lekcija prav tako izpostavlja nastajajoče trende, prihodnje smernice in odprtokodne vire, ki vam bodo pomagali ostati na čelu MCP tehnologije in njenega spreminjajočega se ekosistema.

## Cilji učenja

- Analizirati resnične implementacije MCP v različnih panogah  
- Načrtovati in zgraditi celovite aplikacije na osnovi MCP  
- Raziskati nastajajoče trende in prihodnje smeri MCP tehnologije  
- Uporabiti najboljše prakse v dejanskih razvojnih scenarijih  

## Resnične implementacije MCP

### Študija primera 1: Avtomatizacija podpore strankam v podjetjih

Multinacionalno podjetje je uvedlo rešitev na osnovi MCP za standardizacijo AI interakcij v svojih sistemih za podporo strankam. To jim je omogočilo:

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

**Rezultati:** 30 % znižanje stroškov modelov, 45 % izboljšana konsistentnost odgovorov in izboljšana skladnost v globalnih operacijah.

### Študija primera 2: Diagnostični pomočnik v zdravstvu

Zdravstveni ponudnik je razvil MCP infrastrukturo za integracijo več specializiranih medicinskih AI modelov ob hkratnem zagotavljanju zaščite občutljivih pacientovih podatkov:

- Nemoteno preklapljanje med splošnimi in specialističnimi medicinskimi modeli  
- Stroge zasebnostne kontrole in revizijske sledi  
- Integracija z obstoječimi sistemi elektronskih zdravstvenih kartonov (EHR)  
- Dosledno inženirstvo pozivov za medicinsko terminologijo  

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

Finančna institucija je uvedla MCP za standardizacijo procesov analize tveganj v različnih oddelkih:

- Ustvarili so enoten vmesnik za modele kreditnega tveganja, odkrivanja prevar in investicijskih tveganj  
- Uvedli stroge kontrole dostopa in verzioniranje modelov  
- Zagotovili revizijsko sled za vse AI priporočila  
- Ohranjali dosledno obliko podatkov med različnimi sistemi  

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

Microsoft je razvil [Playwright MCP strežnik](https://github.com/microsoft/playwright-mcp) za varno in standardizirano avtomatizacijo brskalnikov prek Model Context Protocola. Ta rešitev omogoča AI agentom in LLM-jem interakcijo z brskalniki na nadzorovan, revizijski in razširljiv način – omogoča primere uporabe, kot so avtomatizirano spletno testiranje, ekstrakcija podatkov in celoviti delovni tokovi.

- Izpostavlja zmogljivosti avtomatizacije brskalnika (navigacija, izpolnjevanje obrazcev, zajem zaslonskih slik itd.) kot MCP orodja  
- Uvaja stroge kontrole dostopa in peskovnik za preprečevanje nepooblaščenih dejanj  
- Ponuja podrobne revizijske dnevnike vseh interakcij z brskalnikom  
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
- Omogočeno varno, programabilno avtomatizacijo brskalnika za AI agente in LLM-je  
- Zmanjšan ročni trud pri testiranju in izboljšano pokritje testov spletnih aplikacij  
- Zagotovljen večkratno uporaben, razširljiv okvir za integracijo orodij, ki temeljijo na brskalniku, v podjetniških okoljih  

**Reference:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Študija primera 5: Azure MCP – podjetniški Model Context Protocol kot storitev

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) je Microsoftova upravljana, podjetniška implementacija Model Context Protocola, zasnovana za zagotavljanje razširljivih, varnih in skladnih MCP strežniških zmogljivosti kot oblačne storitve. Azure MCP omogoča organizacijam hitro uvajanje, upravljanje in integracijo MCP strežnikov z Azure AI, podatki in varnostnimi storitvami, zmanjšuje operativno breme in pospešuje sprejemanje AI.

- Popolnoma upravljano gostovanje MCP strežnika z vgrajenim skaliranjem, nadzorom in varnostjo  
- Nativna integracija z Azure OpenAI, Azure AI Search in drugimi Azure storitvami  
- Podjetniška avtentikacija in avtorizacija preko Microsoft Entra ID  
- Podpora za prilagojena orodja, predloge pozivov in povezovalnike virov  
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
- Izboljšana varnost, opazovanje in operativna učinkovitost za delovne obremenitve MCP  

**Reference:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Študija primera 6: NLWeb  
MCP (Model Context Protocol) je nastajajoči protokol za klepetalne bote in AI asistente za interakcijo z orodji. Vsak primer NLWeb je tudi MCP strežnik, ki podpira eno osnovno metodo, ask, ki omogoča postavljanje vprašanj spletnim mestom v naravnem jeziku. Vrnjen odgovor uporablja schema.org, široko uporabljeno slovarno zbirko za opis spletnih podatkov. Poenostavljeno rečeno, MCP je NLWeb, kot je HTTP za HTML. NLWeb združuje protokole, formate schema.org in vzorčno kodo, da pomaga spletnim mestom hitro ustvariti te končne točke, kar koristi tako ljudem prek pogovornih vmesnikov kot strojem prek naravne interakcije agent-agent.

NLWeb ima dva ločena sestavna dela:  
- Protokol, zelo preprost za začetek, za vmesnik z mestom v naravnem jeziku in format, ki uporablja json in schema.org za vrnjene odgovore. Več podrobnosti najdete v dokumentaciji REST API.  
- Enostavna implementacija (1), ki uporablja obstoječe označevanje za spletna mesta, ki jih je mogoče abstraktno predstaviti kot sezname elementov (izdelki, recepti, znamenitosti, ocene itd.). Skupaj z nizom uporabniških vmesnikov lahko spletna mesta enostavno ponudijo pogovorne vmesnike za svojo vsebino. Več o tem, kako to deluje, je v dokumentaciji o življenjskem ciklu klepetalnega poizvedovanja.  

**Reference:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

## Praktični projekti

### Projekt 1: Zgradite MCP strežnik z več ponudniki

**Cilj:** Ustvariti MCP strežnik, ki lahko usmerja zahteve do več ponudnikov AI modelov glede na določena merila.

**Zahteve:**  
- Podpora za vsaj tri različne ponudnike modelov (npr. OpenAI, Anthropic, lokalni modeli)  
- Implementacija mehanizma usmerjanja na podlagi metapodatkov zahtev  
- Ustvariti konfiguracijski sistem za upravljanje poverilnic ponudnikov  
- Dodati predpomnjenje za optimizacijo zmogljivosti in stroškov  
- Zgraditi preprost nadzorni plošči za spremljanje uporabe  

**Koraki implementacije:**  
1. Nastaviti osnovno infrastrukturo MCP strežnika  
2. Implementirati adapterje ponudnikov za vsako AI storitev modelov  
3. Ustvariti logiko usmerjanja glede na atribute zahtev  
4. Dodati mehanizme predpomnjenja za pogoste zahteve  
5. Razviti nadzorno ploščo za spremljanje  
6. Testirati z različnimi vzorci zahtev  

**Tehnologije:** Izberite med Python (.NET/Java/Python glede na vašo izbiro), Redis za predpomnjenje in preprost spletni okvir za nadzorno ploščo.

### Projekt 2: Podjetniški sistem za upravljanje pozivov

**Cilj:** Razviti sistem na osnovi MCP za upravljanje, verzioniranje in uvajanje predlog pozivov v organizaciji.

**Zahteve:**  
- Ustvariti centralizirano skladišče za predloge pozivov  
- Implementirati verzioniranje in odobritvene delovne tokove  
- Zgraditi zmogljivosti testiranja predlog s primeri vhodov  
- Razviti nadzor dostopa na podlagi vlog  
- Ustvariti API za pridobivanje in uvajanje predlog  

**Koraki implementacije:**  
1. Načrtovati shemo baze podatkov za shranjevanje predlog  
2. Ustvariti osnovni API za CRUD operacije predlog  
3. Implementirati sistem verzioniranja  
4. Zgraditi odobritveni delovni tok  
5. Razviti testni okvir  
6. Ustvariti preprost spletni vmesnik za upravljanje  
7. Integrirati z MCP strežnikom  

**Tehnologije:** Poljubna izbira backend okvira, SQL ali NoSQL baza in frontend okvir za upravljalski vmesnik.

### Projekt 3: Platforma za generiranje vsebin na osnovi MCP

**Cilj:** Zgraditi platformo za generiranje vsebin, ki uporablja MCP za zagotavljanje doslednih rezultatov v različnih vrstah vsebin.

**Zahteve:**  
- Podpora za več formatov vsebin (blog zapisi, družbena omrežja, marketinški teksti)  
- Implementacija generiranja na osnovi predlog z možnostmi prilagoditve  
- Ustvariti sistem za pregled in povratne informacije vsebin  
- Spremljati metrike uspešnosti vsebin  
- Podpora verzioniranju in iteraciji vsebin  

**Koraki implementacije:**  
1. Nastaviti MCP klient infrastrukturo  
2. Ustvariti predloge za različne vrste vsebin  
3. Zgraditi proces generiranja vsebin  
4. Implementirati sistem za pregled  
5. Razviti sistem za spremljanje metrik  
6. Ustvariti uporabniški vmesnik za upravljanje predlog in generiranje vsebin  

**Tehnologije:** Vaš izbrani programski jezik, spletni okvir in sistem za baze podatkov.

## Prihodnje smeri MCP tehnologije

### Nastajajoči trendi

1. **Večmodalni MCP**  
   - Razširitev MCP za standardizacijo interakcij z modeli za slike, zvok in video  
   - Razvoj zmogljivosti medmodalnega sklepanja  
   - Standardizirani formati pozivov za različne modalitete  

2. **Federirana MCP infrastruktura**  
   - Porazdeljene MCP mreže, ki lahko delijo vire med organizacijami  
   - Standardizirani protokoli za varno deljenje modelov  
   - Tehnike računalništva, ki varujejo zasebnost  

3. **MCP tržnice**  
   - Ekosistemi za deljenje in monetizacijo MCP predlog in vtičnikov  
   - Procesi zagotavljanja kakovosti in certificiranja  
   - Integracija s tržnicami modelov  

4. **MCP za edge računalništvo**  
   - Prilagoditev MCP standardov za naprave z omejenimi viri na robu omrežja  
   - Optimizirani protokoli za okolja z nizko pasovno širino  
   - Specializirane implementacije MCP za IoT ekosisteme  

5. **Regulativni okviri**  
   - Razvoj MCP razširitev za skladnost z regulativami  
   - Standardizirane revizijske sledi in vmesniki za pojasnljivost  
   - Integracija z nastajajočimi okviri upravljanja AI  

### MCP rešitve iz Microsofta

Microsoft in Azure sta razvila več odprtokodnih repozitorijev, ki razvijalcem pomagajo implementirati MCP v različnih scenarijih:

#### Microsoft organizacija  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – Playwright MCP strežnik za avtomatizacijo in testiranje brskalnika  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – Implementacija MCP strežnika za OneDrive za lokalno testiranje in prispevke skupnosti  
3. [NLWeb](https://github.com/microsoft/NlWeb) – Zbirka odprtih protokolov in pripadajočih odprtokodnih orodij, osredotočena na vzpostavitev temeljnega sloja za AI splet  

#### Azure-Samples organizacija  
1. [mcp](https://github.com/Azure-Samples/mcp) – Povezave do vzorcev, orodij in virov za gradnjo in integracijo MCP strežnikov na Azure z več programskimi jeziki  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) – Referenčni MCP strežniki, ki prikazujejo avtentikacijo s trenutnimi specifikacijami Model Context Protocola  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – Vstopna stran za oddaljene MCP strežnike v Azure Functions z povezavami do jezikovno specifičnih repozitorijev  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Hitri začetek za gradnjo in uvajanje prilagojenih oddaljenih MCP strežnikov z Azure Functions v Pythonu  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Hitri začetek za gradnjo in uvajanje prilagojenih oddaljenih MCP strežnikov z Azure Functions v .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Hitri začetek za gradnjo in uvajanje prilagojenih oddaljenih MCP strežnikov z Azure Functions v TypeScriptu  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) – Azure API Management kot AI prehod do oddaljenih MCP strežnikov z uporabo Pythona  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) – Eksperimenti APIM ❤️ AI, vključno z MCP zmogljivostmi, integracija z Azure OpenAI in AI Foundry  

Ti repozitoriji ponujajo različne implementacije, predloge in vire za delo z Model Context Protocolom v različnih programskih jezikih in Azure storitvah. Pokrivajo širok nabor primerov uporabe, od osnovnih strežniških implementacij do avtentikacije, uvajanja v oblak in podjetniške integracije.

#### MCP imenik virov

[Imenik MCP virov](https://github.com/microsoft/mcp/tree/main/Resources) v uradnem Microsoft MCP repozitoriju ponuja skrbno izbrano zbirko vzorčnih virov, predlog pozivov in definicij orodij za uporabo z MCP strežniki. Ta imenik je zasnovan, da razvijalcem pomaga hitro začeti z MCP z zagotavljanjem večkratno uporabnih grad
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Vježbe

1. Analizirajte jedan od studija slučaja i predložite alternativni pristup implementaciji.
2. Odaberite jednu od ideja za projekt i izradite detaljnu tehničku specifikaciju.
3. Istražite industriju koja nije pokrivena studijama slučaja i opišite kako bi MCP mogao riješiti njene specifične izazove.
4. Istražite jedan od budućih pravaca i osmislite koncept nove MCP ekstenzije koja bi ga podržavala.

Sljedeće: [Best Practices](../08-BestPractices/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Ne odgovarjamo za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.