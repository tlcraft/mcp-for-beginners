<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T17:43:04+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "sl"
}
-->
# Lekcije od zgodnjih uporabnikov

## Pregled

Ta lekcija raziskuje, kako so zgodnji uporabniki izkoristili Model Context Protocol (MCP) za reševanje dejanskih izzivov in spodbujanje inovacij v različnih panogah. S podrobnimi študijami primerov in praktičnimi projekti boste videli, kako MCP omogoča standardizirano, varno in razširljivo integracijo AI — povezuje velike jezikovne modele, orodja in podatke podjetij v enotno ogrodje. Pridobili boste praktične izkušnje z načrtovanjem in gradnjo rešitev na osnovi MCP, se naučili preverjenih vzorcev implementacije in odkrili najboljše prakse za uvajanje MCP v produkcijska okolja. Lekcija prav tako izpostavlja nastajajoče trende, prihodnje smernice in odprtokodne vire, ki vam bodo pomagali ostati na čelu tehnologije MCP in njenega spreminjajočega se ekosistema.

## Cilji učenja

- Analizirati dejanske implementacije MCP v različnih panogah  
- Načrtovati in zgraditi celovite aplikacije na osnovi MCP  
- Raziskati nastajajoče trende in prihodnje smeri tehnologije MCP  
- Uporabiti najboljše prakse v resničnih razvojnih scenarijih  

## Dejanske implementacije MCP

### Študija primera 1: Avtomatizacija podpore strankam v podjetju

Multinacionalka je uvedla rešitev na osnovi MCP za standardizacijo AI interakcij v svojih sistemih podpore strankam. To jim je omogočilo:

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

### Študija primera 2: Diagnostični asistent v zdravstvu

Zdravstveni ponudnik je razvil MCP infrastrukturo za integracijo več specializiranih medicinskih AI modelov, hkrati pa zagotovil zaščito občutljivih pacientovih podatkov:

- Gladko preklapljanje med splošnimi in specialističnimi medicinskimi modeli  
- Strogi nadzor zasebnosti in revizijske sledi  
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

Finančna institucija je uvedla MCP za standardizacijo procesov analize tveganj med različnimi oddelki:

- Ustvarili so enotno vmesnik za modele kreditnega tveganja, odkrivanja prevar in investicijskega tveganja  
- Uvedli stroge kontrole dostopa in verzioniranje modelov  
- Zagotovili revizijsko sled vseh AI priporočil  
- Ohranjali dosledno obliko podatkov v različnih sistemih  

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

Microsoft je razvil [Playwright MCP strežnik](https://github.com/microsoft/playwright-mcp), ki omogoča varno in standardizirano avtomatizacijo brskalnikov preko Model Context Protocol. Ta rešitev omogoča AI agentom in LLM, da nadzorujejo spletne brskalnike na nadzorovan, revizijski in razširljiv način — za primere uporabe, kot so avtomatizirano testiranje spletnih strani, ekstrakcija podatkov in celoviti delovni tokovi.

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
- Omogočena varna, programska avtomatizacija brskalnika za AI agente in LLM  
- Zmanjšan ročni napor pri testiranju in izboljšano pokritje testov spletnih aplikacij  
- Ponuja ponovno uporabno in razširljivo ogrodje za integracijo orodij na osnovi brskalnika v podjetjih  

**Reference:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Študija primera 5: Azure MCP – Model Context Protocol kot storitev na podjetniški ravni

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) je Microsoftova upravljana, podjetniško usmerjena implementacija Model Context Protocol, zasnovana za zagotavljanje razširljivih, varnih in skladnih MCP strežniških zmogljivosti kot oblačne storitve. Azure MCP omogoča organizacijam hitro uvajanje, upravljanje in integracijo MCP strežnikov z Azure AI, podatkovnimi in varnostnimi storitvami, s čimer zmanjšuje operativne stroške in pospešuje uvajanje AI.

- Popolnoma upravljano gostovanje MCP strežnikov z vgrajenim skaliranjem, nadzorom in varnostjo  
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
- Poenostavljena integracija LLM, orodij in virov podatkov podjetij  
- Izboljšana varnost, opazovanje in operativna učinkovitost za MCP delovne obremenitve  

**Reference:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Študija primera 6: NLWeb  
MCP (Model Context Protocol) je nastajajoči protokol za klepetalne bote in AI asistente za interakcijo z orodji. Vsak primer NLWeb je tudi MCP strežnik, ki podpira eno osnovno metodo, ask, ki omogoča postavljanje vprašanj spletni strani v naravnem jeziku. Vrnjen odgovor uporablja schema.org, široko uporabljeno slovarno bazo za opis spletnih podatkov. Poenostavljeno rečeno, MCP je za NLWeb kot HTTP za HTML. NLWeb združuje protokole, formate Schema.org in vzorčno kodo, da pomaga spletnim mestom hitro ustvariti te končne točke, kar koristi tako ljudem prek pogovornih vmesnikov kot strojem prek naravne interakcije med agenti.

NLWeb ima dve ločeni komponenti:  
- Protokol, zelo preprost za začetek, za komunikacijo s spletno stranjo v naravnem jeziku in format, ki uporablja json in schema.org za vrnjen odgovor. Več podrobnosti najdete v dokumentaciji REST API.  
- Enostavna implementacija (1), ki izkorišča obstoječo označbo za spletna mesta, ki jih je mogoče predstaviti kot sezname elementov (izdelki, recepti, znamenitosti, ocene itd.). Skupaj s sklopom uporabniških vmesnikov lahko spletna mesta enostavno ponudijo pogovorne vmesnike za svojo vsebino. Več o tem v dokumentaciji o življenjskem ciklu poizvedbe klepeta.  

**Reference:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Študija primera 7: MCP za Foundry – integracija Azure AI agentov

Azure AI Foundry MCP strežniki prikazujejo, kako se MCP lahko uporablja za orkestracijo in upravljanje AI agentov ter delovnih tokov v podjetniških okoljih. Z integracijo MCP z Azure AI Foundry lahko organizacije standardizirajo interakcije agentov, izkoristijo upravljanje delovnih tokov Foundry in zagotovijo varne, razširljive uvedbe. Ta pristop omogoča hitro prototipiranje, robustno spremljanje in brezhibno integracijo z Azure AI storitvami, podpira napredne primere uporabe, kot so upravljanje znanja in ocenjevanje agentov. Razvijalci imajo enoten vmesnik za gradnjo, uvajanje in spremljanje agentnih procesov, IT ekipe pa pridobijo izboljšano varnost, skladnost in operativno učinkovitost. Rešitev je idealna za podjetja, ki želijo pospešiti uvajanje AI in ohraniti nadzor nad zapletenimi procesi, ki jih vodijo agenti.

**Reference:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Študija primera 8: Foundry MCP Playground – eksperimentiranje in prototipiranje

Foundry MCP Playground ponuja pripravljeno okolje za eksperimentiranje z MCP strežniki in integracijami Azure AI Foundry. Razvijalci lahko hitro izdelajo prototipe, testirajo in ocenjujejo AI modele ter agentne delovne tokove z viri iz Azure AI Foundry kataloga in laboratorijev. Playground poenostavlja nastavitev, ponuja vzorčne projekte in podpira sodelovalni razvoj, kar olajša raziskovanje najboljših praks in novih scenarijev z minimalnimi stroški. Še posebej je uporaben za ekipe, ki želijo preveriti ideje, deliti eksperimente in pospešiti učenje brez potrebe po zapleteni infrastrukturi. Z nižanjem vstopnih ovir playground spodbuja inovacije in prispevke skupnosti v ekosistemu MCP in Azure AI Foundry.

**Reference:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Študija primera 9: Microsoft Docs MCP strežnik – učenje in usposabljanje  
Microsoft Docs MCP strežnik implementira Model Context Protocol strežnik, ki AI asistentom omogoča dostop v realnem času do uradne Microsoft dokumentacije. Izvaja semantično iskanje v uradni tehnični dokumentaciji Microsofta.

**Reference:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## Praktični projekti

### Projekt 1: Izdelava MCP strežnika z več ponudniki

**Cilj:** Ustvariti MCP strežnik, ki lahko usmerja zahteve do več ponudnikov AI modelov glede na določena merila.

**Zahteve:**  
- Podpora za vsaj tri različne ponudnike modelov (npr. OpenAI, Anthropic, lokalni modeli)  
- Implementacija mehanizma usmerjanja na podlagi metapodatkov zahtevka  
- Sistem konfiguracije za upravljanje poverilnic ponudnikov  
- Dodajanje predpomnjenja za optimizacijo zmogljivosti in stroškov  
- Preprost nadzorni panel za spremljanje uporabe  

**Koraki implementacije:**  
1. Nastavitev osnovne infrastrukture MCP strežnika  
2. Implementacija adapterjev za vsak AI model  
3. Ustvarjanje logike usmerjanja na podlagi atributov zahtevka  
4. Dodajanje mehanizmov predpomnjenja za pogoste zahteve  
5. Razvoj nadzornega panela  
6. Testiranje z različnimi vzorci zahtev  

**Tehnologije:** Izbira med Python (.NET/Java/Python glede na preference), Redis za predpomnjenje in preprost spletni okvir za nadzorni panel.

### Projekt 2: Podjetniški sistem upravljanja pozivov

**Cilj:** Razviti sistem na osnovi MCP za upravljanje, verzioniranje in uvajanje predlog pozivov v organizaciji.

**Zahteve:**  
- Centraliziran repozitorij za predloge pozivov  
- Implementacija verzioniranja in odobritvenih procesov  
- Zmožnosti testiranja predlog s primeri vhodov  
- Vzpostavitev nadzora dostopa na podlagi vlog  
- API za pridobivanje in uvajanje predlog  

**Koraki implementacije:**  
1. Oblikovanje sheme baze podatkov za shranjevanje predlog  
2. Ustvarjanje osnovnega API za CRUD operacije predlog  
3. Implementacija sistema verzioniranja  
4. Razvoj odobritvenega procesa  
5. Izdelava testnega okvira  
6. Preprost spletni vmesnik za upravljanje  
7. Integracija z MCP strežnikom  

**Tehnologije:** Izbira backend ogrodja, SQL ali NoSQL baze in frontend ogrodja za upravljalni vmesnik.

### Projekt 3: Platforma za generiranje vsebin na osnovi MCP

**Cilj:** Zgraditi platformo za generiranje vsebin, ki uporablja MCP za zagotavljanje doslednih rezultatov pri različnih vrstah vsebin.

**Zahteve:**  
- Podpora za več formatov vsebin (blog objave, družbena omrežja, marketinški teksti)  
- Implementacija generiranja na osnovi predlog s prilagoditvami  
- Sistem za pregled in povratne informacije o vsebinah  
- Spremljanje metrik uspešnosti vsebin  
- Podpora verzioniranju in iteracijam vsebin  

**Koraki implementacije:**  
1. Nastavitev MCP odjemalske infrastrukture  
2. Ustvarjanje predlog za različne vrste vsebin  
3. Izgradnja procesa generiranja vsebin  
4. Implementacija sistema za pregled  
5. Razvoj sistema za spremljanje metrik  
6. Ustvarjanje uporabniškega vmesnika za upravljanje predlog in generiranje vsebin  

**Tehnologije:** Vaš izbrani programski jezik, spletni okvir in sistem za shranjevanje podatkov.

## Prihodnje smeri tehnologije MCP

### Nastajajoči trendi

1. **Večmodalni MCP**  
   - Razširitev MCP za standardizacijo interakcij z modeli za slike, zvok in video  
   - Razvoj zmožnosti medmodalnega sklepanja  
   - Standardizirani formati pozivov za različne modalitete  

2. **Federirana MCP infrastruktura**  
   - Razpršene MCP mreže za deljenje virov med organizacijami  
   - Standardizirani protokoli za varno deljenje modelov  
   - Tehnike varovanja zasebnosti pri izračunih  

3. **MCP tržnice**  
   - Ekosistemi za deljenje in monetizacijo MCP predlog in vtičnikov  
   - Procesi zagotavljanja kakovosti in certificiranja  
   - Integracija s tržnicami modelov  

4. **MCP za edge računalništvo**  
   - Prilagoditev MCP standardov za naprave z omejenimi viri na robu omrežja  
   - Optimizirani protokoli za okolja z nizko pasovno širino  
   - Specializirane MCP implementacije za IoT ekosisteme  

5. **Regulativni okviri**  
   - Razvoj MCP razširitev za skladnost z regulativami  
   - Standardizirane revizijske sledi in vmesniki za pojasnitev delovanja  
   - Integracija z nastajajočimi okviri za upravljanje AI  

### MCP rešitve od Microsofta

Microsoft in Azure so razvili več odprtokodnih repozitorijev za pomoč razvijalcem pri implementaciji MCP v različnih scenarijih:

#### Microsoft organizacija  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – Playwright MCP strežnik za avtomatizacijo brskalnika in testiranje  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – OneDrive MCP strežnik za lokalno testiranje in skupnostni prispevek  
3. [NLWeb](https://github.com/microsoft/NlWeb) – zbirka odprtih protokolov in povezanih odprtokodnih orodij, osredotočena na vzpostavitev temeljne plasti za AI splet  

#### Azure-Samples organizacija  

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

## Vadbe

1. Analizirajte eno od študij primerov in predlagajte alternativni pristop k izvedbi.
2. Izberite eno izmed idej za projekt in pripravite podrobno tehnično specifikacijo.
3. Raziskujte industrijo, ki ni zajeta v študijah primerov, in opišite, kako bi MCP lahko naslovil njene posebne izzive.
4. Raziščite eno od prihodnjih smernic in oblikujte koncept nove MCP razširitve za njeno podporo.

Naslednje: [Best Practices](../08-BestPractices/README.md)

**Opozorilo**:  
Ta dokument je bil preveden z uporabo storitve za prevajanje z umetno inteligenco [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne prevzemamo odgovornosti.