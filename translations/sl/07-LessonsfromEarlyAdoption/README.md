<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6755bc4f6d0293ce6c49cfc5efba0d8e",
  "translation_date": "2025-07-18T10:32:26+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "sl"
}
-->
# 🌟 Lekcije zgodnjih uporabnikov

## 🎯 Kaj zajema ta modul

Ta modul raziskuje, kako resnične organizacije in razvijalci uporabljajo Model Context Protocol (MCP) za reševanje dejanskih izzivov in spodbujanje inovacij. S pomočjo podrobnih študij primerov, praktičnih primerov in projektov boste odkrili, kako MCP omogoča varno, razširljivo integracijo umetne inteligence, ki povezuje jezikovne modele, orodja in podatke podjetij.

### Študija primera 5: Azure MCP – Model Context Protocol za podjetja kot storitev

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) je Microsoftova upravljana, podjetjem prilagojena implementacija Model Context Protocola, zasnovana za zagotavljanje razširljivih, varnih in skladnih MCP strežniških zmogljivosti kot oblačne storitve. Ta obsežen paket vključuje več specializiranih MCP strežnikov za različne Azure storitve in scenarije.

> **🎯 Orodja pripravljena za produkcijo**
> 
> Ta študija primera predstavlja več MCP strežnikov, pripravljenih za produkcijo! Spoznajte Azure MCP Server in druge strežnike, integrirane z Azure, v našem [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#2--azure-mcp-server).

**Ključne lastnosti:**
- Popolnoma upravljano gostovanje MCP strežnika z vgrajenim skaliranjem, nadzorom in varnostjo
- Nativna integracija z Azure OpenAI, Azure AI Search in drugimi Azure storitvami
- Podjetniška avtentikacija in avtorizacija preko Microsoft Entra ID
- Podpora za prilagojena orodja, predloge pozivov in povezovalce virov
- Skladnost s podjetniškimi varnostnimi in regulativnimi zahtevami
- Več kot 15 specializiranih povezovalcev za Azure storitve, vključno z bazami podatkov, nadzorom in shranjevanjem

**Zmožnosti Azure MCP strežnika:**
- **Upravljanje virov**: Celoten življenjski cikel Azure virov
- **Povezovalci baz podatkov**: Neposreden dostop do Azure Database for PostgreSQL in SQL Server
- **Azure Monitor**: Analiza dnevnikov in operativni vpogledi z uporabo KQL
- **Avtentikacija**: DefaultAzureCredential in vzorci upravljanih identitet
- **Shranjevalne storitve**: Operacije z Blob Storage, Queue Storage in Table Storage
- **Storitve kontejnerjev**: Upravljanje Azure Container Apps, Container Instances in AKS

### 📚 Oglejte si MCP v akciji

Želite videti, kako se ti principi uporabljajo v orodjih, pripravljenih za produkcijo? Oglejte si naš [**10 Microsoft MCP Servers That Are Transforming Developer Productivity**](microsoft-mcp-servers.md), ki prikazuje resnične Microsoft MCP strežnike, ki jih lahko uporabljate že danes.

## Pregled

Ta lekcija raziskuje, kako so zgodnji uporabniki izkoristili Model Context Protocol (MCP) za reševanje resničnih izzivov in spodbujanje inovacij v različnih panogah. S pomočjo podrobnih študij primerov in praktičnih projektov boste videli, kako MCP omogoča standardizirano, varno in razširljivo integracijo umetne inteligence — povezuje velike jezikovne modele, orodja in podatke podjetij v enotnem okviru. Pridobili boste praktične izkušnje z načrtovanjem in gradnjo rešitev na osnovi MCP, se naučili preverjenih vzorcev implementacije in odkrili najboljše prakse za uvajanje MCP v produkcijska okolja. Lekcija prav tako izpostavlja nastajajoče trende, prihodnje smernice in odprtokodne vire, ki vam pomagajo ostati na čelu tehnologije MCP in njenega razvijajočega se ekosistema.

## Cilji učenja

- Analizirati resnične implementacije MCP v različnih panogah
- Načrtovati in zgraditi celovite aplikacije na osnovi MCP
- Raziskati nastajajoče trende in prihodnje smeri tehnologije MCP
- Uporabiti najboljše prakse v dejanskih razvojnih scenarijih

## Resnične implementacije MCP

### Študija primera 1: Avtomatizacija podpore strankam v podjetju

Multinacionalno podjetje je uvedlo rešitev na osnovi MCP za standardizacijo interakcij z umetno inteligenco v svojih sistemih za podporo strankam. To jim je omogočilo:

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

**Rezultati:** 30 % znižanje stroškov modelov, 45 % izboljšanje doslednosti odgovorov in izboljšana skladnost v globalnih operacijah.

### Študija primera 2: Diagnostični pomočnik v zdravstvu

Zdravstveni ponudnik je razvil MCP infrastrukturo za integracijo več specializiranih medicinskih AI modelov ob hkratnem zagotavljanju zaščite občutljivih pacientovih podatkov:

- Brezhibno preklapljanje med splošnimi in specialističnimi medicinskimi modeli
- Strogi nadzor zasebnosti in revizijske sledi
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

Finančna institucija je uvedla MCP za standardizacijo procesov analize tveganj v različnih oddelkih:

- Ustvarila enoten vmesnik za modele kreditnega tveganja, odkrivanja prevar in investicijskega tveganja
- Uvedla stroge kontrole dostopa in verzioniranje modelov
- Zagotovila revizijsko sled vseh AI priporočil
- Ohranjala dosledno obliko podatkov med različnimi sistemi

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

**Rezultati:** Izboljšana skladnost z regulativami, 40 % hitrejši cikli uvajanja modelov in izboljšana doslednost ocenjevanja tveganj med oddelki.

### Študija primera 4: Microsoft Playwright MCP strežnik za avtomatizacijo brskalnika

Microsoft je razvil [Playwright MCP strežnik](https://github.com/microsoft/playwright-mcp), ki omogoča varno, standardizirano avtomatizacijo brskalnika preko Model Context Protocola. Ta strežnik, pripravljen za produkcijo, omogoča AI agentom in LLM-jem interakcijo z brskalniki na nadzorovan, revizijski in razširljiv način — omogoča primere uporabe, kot so avtomatizirano testiranje spletnih strani, ekstrakcija podatkov in celoviti delovni tokovi.

> **🎯 Orodje pripravljeno za produkcijo**
> 
> Ta študija primera prikazuje resnični MCP strežnik, ki ga lahko uporabljate že danes! Več o Playwright MCP Serverju in 9 drugih Microsoft MCP strežnikih, pripravljenih za produkcijo, najdete v našem [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#8--playwright-mcp-server).

**Ključne lastnosti:**
- Izpostavlja zmogljivosti avtomatizacije brskalnika (navigacija, izpolnjevanje obrazcev, zajem zaslonskih slik itd.) kot MCP orodja
- Uvaja stroge kontrole dostopa in peskovnik za preprečevanje nepooblaščenih dejanj
- Ponuja podrobne revizijske dnevnike vseh interakcij z brskalnikom
- Podpira integracijo z Azure OpenAI in drugimi ponudniki LLM za avtomatizacijo, ki jo vodijo agenti
- Poganja GitHub Copilot Coding Agenta z zmogljivostmi brskanja po spletu

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
- Omogočena varna, programska avtomatizacija brskalnika za AI agente in LLM-je  
- Zmanjšan ročni napor pri testiranju in izboljšan doseg testov spletnih aplikacij  
- Zagotovljen ponovno uporaben, razširljiv okvir za integracijo orodij, ki temeljijo na brskalniku, v podjetniških okoljih  
- Poganja zmogljivosti brskanja po spletu GitHub Copilota

**Reference:**  
- [Playwright MCP Server GitHub repozitorij](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI in avtomatizacijske rešitve](https://azure.microsoft.com/en-us/products/ai-services/)

### Študija primera 5: Azure MCP – Model Context Protocol za podjetja kot storitev

Azure MCP Server ([https://aka.ms/azmcp](https://aka.ms/azmcp)) je Microsoftova upravljana, podjetjem prilagojena implementacija Model Context Protocola, zasnovana za zagotavljanje razširljivih, varnih in skladnih MCP strežniških zmogljivosti kot oblačne storitve. Azure MCP omogoča organizacijam hitro uvajanje, upravljanje in integracijo MCP strežnikov z Azure AI, podatki in varnostnimi storitvami, s čimer zmanjšuje operativne stroške in pospešuje sprejemanje umetne inteligence.

> **🎯 Orodje pripravljeno za produkcijo**
> 
> To je resnični MCP strežnik, ki ga lahko uporabljate že danes! Več o Azure AI Foundry MCP Serverju najdete v našem [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md).

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
- Zmanjšan čas do vrednosti za podjetniške AI projekte z zagotavljanjem platforme MCP strežnika, pripravljene za uporabo in skladne z zahtevami  
- Poenostavljena integracija LLM-jev, orodij in virov podatkov podjetij  
- Izboljšana varnost, opazovanje in operativna učinkovitost za delovne obremenitve MCP  
- Izboljšana kakovost kode z najboljšimi praksami Azure SDK in aktualnimi vzorci avtentikacije

**Reference:**  
- [Azure MCP dokumentacija](https://aka.ms/azmcp)  
- [Azure MCP Server GitHub repozitorij](https://github.com/Azure/azure-mcp)  
- [Azure AI storitve](https://azure.microsoft.com/en-us/products/ai-services/)

### Študija primera 6: NLWeb – Protokol naravnega jezika za spletni vmesnik

NLWeb predstavlja Microsoftovo vizijo vzpostavitve temeljnega sloja za AI splet. Vsak primer NLWeb je tudi MCP strežnik, ki podpira eno osnovno metodo, `ask`, s katero lahko v naravnem jeziku zastavite vprašanje spletni strani. Vrnjeni odgovor uporablja schema.org, široko uporabljeno slovarno oznako za opis spletnih podatkov. Poenostavljeno rečeno, MCP je za NLWeb kot HTTP za HTML.

**Ključne lastnosti:**
- **Protokolni sloj**: Enostaven protokol za komunikacijo s spletnimi stranmi v naravnem jeziku  
- **Oblika schema.org**: Uporablja JSON in schema.org za strukturirane, strojno berljive odgovore  
- **Skupnostna implementacija**: Preprosta implementacija za strani, ki jih je mogoče predstaviti kot sezname elementov (izdelki, recepti, znamenitosti, ocene itd.)  
- **UI pripomočki**: Vnaprej izdelani uporabniški vmesniki za pogovorne vmesnike

**Arhitekturne komponente:**
1. **Protokol**: Enostaven REST API za poizvedbe v naravnem jeziku do spletnih strani  
2. **Implementacija**: Izrablja obstoječo označbo in strukturo strani za avtomatizirane odgovore  
3. **UI pripomočki**: Pripomočki, pripravljeni za uporabo pri integraciji pogovornih vmesnikov

**Prednosti:**
- Omogoča interakcijo med človekom in spletno stranjo ter med agenti  
- Ponuja strukturirane podatke, ki jih AI sistemi lahko enostavno obdelajo  
- Hitro uvajanje za strani z vsebino, organizirano v sezname  
- Standardiziran pristop za omogočanje dostopa AI do spletnih strani

**Rezultati:**
- Ustanovitev temeljev za standarde interakcije AI s spletom  
- Poenostavljena izdelava pogovornih vmesnikov za vsebinske strani  
- Izboljšana odkritljivost in dostopnost spletnih vsebin za AI sisteme  
- Spodbujanje interoperabilnosti med različnimi AI agenti in spletnimi storitvami

**Reference:**  
- [NLWeb GitHub repozitorij](https://github.com/microsoft/NlWeb)  
- [NLWeb dokumentacija](https://github.com/microsoft/NlWeb)

### Študija primera 7: Azure AI Foundry MCP Server – Integracija podjetniških AI agentov

Azure AI Foundry MCP strežniki prikazujejo, kako se MCP lahko uporablja za orkestracijo in upravljanje AI agentov ter delovnih tokov v podjetniških okoljih. Z integracijo MCP z Azure AI Foundry lahko organizacije standardizirajo interakcije agentov, izkoristijo upravljanje delovnih tokov Foundry in zagotovijo varne, razširljive uvedbe.

> **🎯 Orodje pripravljeno za produkcijo**
> 
> To je resnični MCP strežnik, ki ga lahko uporabljate že danes! Več o Azure AI Foundry MCP Serverju najdete v našem [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#9--azure-ai-foundry-mcp-server).

**Ključne lastnosti:**
- Celovit dostop do Azure AI ekosistema, vključno s katalogi modelov in upravljanjem uvajanja  
- Indeksiranje znanja z Azure AI Search za RAG aplikacije  
- Orodja za ocenjevanje zmogljivosti in zagotavljanje kakovosti AI modelov  
- Integracija z Azure AI Foundry Catalog in Labs za najnovejše raziskovalne modele  
- Upravljanje agentov in ocenjevalne zmogljivosti za produkcijske scenarije

**Rezultati:**
- Hitro prototipiranje in robustno spremljanje delovnih tokov AI agentov  
- Brezhibna integracija z Azure AI storitvami za napredne scenarije  
- Enoten vmesnik za gradnjo, uvajanje in spremljanje agentnih procesov  
- Izboljšana varnost, skladnost in operativna učinkovitost za podjetja  
- Pospešeno sprejemanje AI ob ohranjanju nadzora nad kompleksnimi procesi, ki jih vodijo agenti

**Reference:**  
- [Azure AI Foundry MCP Server GitHub repozitorij](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integracija Azure AI agentov z MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Študija primera 8: Foundry MCP Playground – Eksperimentiranje in prototipiranje

Foundry MCP Playground ponuja okolje, pripravljeno za uporabo, za eksperimentiranje z MCP strežniki in integracijami Azure AI Foundry. Razvijalci lahko hitro izdelujejo prototipe, testirajo in ocenjujejo AI modele ter delovne tokove agentov z viri iz Azure AI Foundry Catalog in Labs. Playground poenostavlja nastavitev, ponuja vzorčne projekte in podpira sodelovalni razvoj, kar omogoča enostavno raziskovanje najboljših praks in novih scenarijev z minimalnim naporom. Še posebej je uporaben za ekipe, ki želijo potrditi ideje, deliti eksperimente in pospešiti učenje brez potrebe po zapleteni infrastrukturi. Z znižanjem vstopne ovire playground spodbuja inovacije in prispevke skupnosti v ekosistemu MCP in Azure AI Foundry.

**Reference:**  
- [Foundry MCP Playground GitHub repozitorij](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Študija primera 9: Microsoft Learn Docs MCP Server – Dostop do dokumentacije, podprt z AI

Microsoft Learn Docs MCP Server je oblačna storitev, ki AI pomočnikom omogoča dostop v realnem času do uradne Microsoftove dokument
> **🎯 Orodje pripravljeno za produkcijo**
> 
> To je pravi MCP strežnik, ki ga lahko uporabljate že danes! Več o Microsoft Learn Docs MCP strežniku izveste v našem [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#1--microsoft-learn-docs-mcp-server).
**Ključne lastnosti:**
- Dostop v realnem času do uradne Microsoft dokumentacije, Azure dokumentacije in Microsoft 365 dokumentacije
- Napredne semantične iskalne zmogljivosti, ki razumejo kontekst in namen
- Vedno posodobljene informacije, saj je vsebina Microsoft Learn sproti objavljena
- Celovito pokritje virov Microsoft Learn, Azure dokumentacije in Microsoft 365
- Vrne do 10 kakovostnih vsebinskih kosov z naslovi člankov in URL-ji

**Zakaj je to ključno:**
- Rešuje problem "zastarelih AI znanj" za Microsoft tehnologije
- Zagotavlja, da imajo AI asistenti dostop do najnovejših funkcij .NET, C#, Azure in Microsoft 365
- Ponuja avtoritativne, prvovrstne informacije za natančno generiranje kode
- Nepogrešljivo za razvijalce, ki delajo z hitro razvijajočimi se Microsoft tehnologijami

**Rezultati:**
- Drastično izboljšana natančnost AI-generirane kode za Microsoft tehnologije
- Zmanjšan čas iskanja aktualne dokumentacije in najboljših praks
- Povečana produktivnost razvijalcev z dokumentacijo, ki upošteva kontekst
- Nemotena integracija v razvojne procese brez zapuščanja IDE

**Reference:**
- [Microsoft Learn Docs MCP Server GitHub Repository](https://github.com/MicrosoftDocs/mcp)
- [Microsoft Learn Documentation](https://learn.microsoft.com/)

## Praktični projekti

### Projekt 1: Izgradnja MCP strežnika z več ponudniki

**Cilj:** Ustvariti MCP strežnik, ki lahko usmerja zahteve do več ponudnikov AI modelov glede na določena merila.

**Zahteve:**
- Podpora vsaj trem različnim ponudnikom modelov (npr. OpenAI, Anthropic, lokalni modeli)
- Implementacija mehanizma usmerjanja na podlagi metapodatkov zahtevka
- Ustvariti sistem konfiguracije za upravljanje poverilnic ponudnikov
- Dodati predpomnjenje za optimizacijo zmogljivosti in stroškov
- Zgraditi preprost nadzorni panel za spremljanje uporabe

**Koraki implementacije:**
1. Postavitev osnovne infrastrukture MCP strežnika
2. Implementacija adapterjev ponudnikov za vsako AI model storitev
3. Ustvarjanje logike usmerjanja na podlagi atributov zahtevka
4. Dodajanje mehanizmov predpomnjenja za pogoste zahteve
5. Razvoj nadzornega panela za spremljanje
6. Testiranje z različnimi vzorci zahtevkov

**Tehnologije:** Izberite med Python (.NET/Java/Python glede na vašo izbiro), Redis za predpomnjenje in preprosto spletno ogrodje za nadzorni panel.

### Projekt 2: Sistem za upravljanje predlogov v podjetju

**Cilj:** Razviti sistem na osnovi MCP za upravljanje, verzioniranje in nameščanje predlog pozivov po organizaciji.

**Zahteve:**
- Ustvariti centraliziran repozitorij za predloge pozivov
- Implementirati verzioniranje in odobritvene procese
- Zgraditi možnosti testiranja predlog z vzorčnimi vnosi
- Razviti nadzor dostopa na podlagi vlog
- Ustvariti API za pridobivanje in nameščanje predlog

**Koraki implementacije:**
1. Oblikovanje sheme baze podatkov za shranjevanje predlog
2. Ustvarjanje osnovnega API-ja za CRUD operacije s predlogami
3. Implementacija sistema verzioniranja
4. Izgradnja odobritvenega procesa
5. Razvoj testnega ogrodja
6. Ustvarjanje preprostega spletnega vmesnika za upravljanje
7. Integracija z MCP strežnikom

**Tehnologije:** Izbira backend ogrodja, SQL ali NoSQL baze podatkov in frontend ogrodja za upravljalski vmesnik.

### Projekt 3: Platforma za generiranje vsebin na osnovi MCP

**Cilj:** Zgraditi platformo za generiranje vsebin, ki uporablja MCP za zagotavljanje doslednih rezultatov pri različnih vrstah vsebin.

**Zahteve:**
- Podpora več formatom vsebin (blog objave, družbena omrežja, marketinški teksti)
- Implementacija generiranja na osnovi predlog z možnostmi prilagajanja
- Ustvariti sistem za pregled in povratne informacije o vsebinah
- Spremljanje metrik uspešnosti vsebin
- Podpora verzioniranju in iteraciji vsebin

**Koraki implementacije:**
1. Postavitev MCP odjemalske infrastrukture
2. Ustvarjanje predlog za različne vrste vsebin
3. Izgradnja procesa generiranja vsebin
4. Implementacija sistema za pregled
5. Razvoj sistema za spremljanje metrik
6. Ustvarjanje uporabniškega vmesnika za upravljanje predlog in generiranje vsebin

**Tehnologije:** Vaš izbrani programski jezik, spletno ogrodje in sistem baze podatkov.

## Prihodnje smernice za MCP tehnologijo

### Nastajajoči trendi

1. **Večmodalni MCP**
   - Razširitev MCP za standardizacijo interakcij z modeli za slike, zvok in video
   - Razvoj zmogljivosti za medmodalno sklepanje
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
   - Specializirane MCP implementacije za IoT ekosisteme

5. **Regulatorni okviri**
   - Razvoj MCP razširitev za skladnost z regulativami
   - Standardizirane revizijske sledi in vmesniki za razložljivost
   - Integracija z nastajajočimi okviri za upravljanje AI

### MCP rešitve iz Microsofta

Microsoft in Azure sta razvila več odprtokodnih repozitorijev, ki razvijalcem pomagajo implementirati MCP v različnih scenarijih:

#### Microsoft Organization
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Playwright MCP strežnik za avtomatizacijo in testiranje brskalnika
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - Implementacija OneDrive MCP strežnika za lokalno testiranje in prispevke skupnosti
3. [NLWeb](https://github.com/microsoft/NlWeb) - NLWeb je zbirka odprtih protokolov in pripadajočih odprtokodnih orodij. Glavni fokus je vzpostavitev temeljnega sloja za AI splet

#### Azure-Samples Organization
1. [mcp](https://github.com/Azure-Samples/mcp) - Povezave do primerov, orodij in virov za gradnjo in integracijo MCP strežnikov na Azure z več programskimi jeziki
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Referenčni MCP strežniki, ki prikazujejo avtentikacijo po trenutni specifikaciji Model Context Protocol
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Vstopna stran za implementacije Remote MCP strežnikov v Azure Functions z povezavami do jezikovno specifičnih repozitorijev
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Predloga za hitro začetek gradnje in nameščanja prilagojenih oddaljenih MCP strežnikov z Azure Functions v Pythonu
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Predloga za hitro začetek gradnje in nameščanja prilagojenih oddaljenih MCP strežnikov z Azure Functions v .NET/C#
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Predloga za hitro začetek gradnje in nameščanja prilagojenih oddaljenih MCP strežnikov z Azure Functions v TypeScriptu
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management kot AI prehod do oddaljenih MCP strežnikov z uporabo Pythona
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - Eksperimenti APIM ❤️ AI, vključno z MCP zmogljivostmi, integracija z Azure OpenAI in AI Foundry

Ti repozitoriji ponujajo različne implementacije, predloge in vire za delo z Model Context Protocol v različnih programskih jezikih in Azure storitvah. Pokrivajo širok spekter primerov uporabe od osnovnih strežniških implementacij do avtentikacije, oblačne namestitve in scenarijev integracije v podjetjih.

#### MCP Resources Directory

[Direktorij MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) v uradnem Microsoft MCP repozitoriju ponuja skrbno izbrano zbirko vzorčnih virov, predlog pozivov in definicij orodij za uporabo z MCP strežniki. Ta direktorij je zasnovan, da razvijalcem omogoči hiter začetek z MCP z uporabo ponovno uporabnih gradnikov in primerov najboljših praks za:

- **Predloge pozivov:** Pripravljenih za uporabo predlog pozivov za pogoste AI naloge in scenarije, ki jih lahko prilagodite za svoje MCP strežniške implementacije.
- **Definicije orodij:** Primeri shem orodij in metapodatkov za standardizacijo integracije in klicev orodij med različnimi MCP strežniki.
- **Vzorčni viri:** Primeri definicij virov za povezovanje z viri podatkov, API-ji in zunanjimi storitvami znotraj MCP okvira.
- **Referenčne implementacije:** Praktični primeri, ki prikazujejo, kako strukturirati in organizirati vire, pozive in orodja v realnih MCP projektih.

Ti viri pospešujejo razvoj, spodbujajo standardizacijo in pomagajo zagotoviti najboljše prakse pri gradnji in nameščanju rešitev na osnovi MCP.

#### MCP Resources Directory
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Raziskovalne priložnosti

- Učinkovite tehnike optimizacije pozivov znotraj MCP okvirov
- Varnostni modeli za večnajemniške MCP namestitve
- Merjenje zmogljivosti različnih MCP implementacij
- Formalne metode preverjanja MCP strežnikov

## Zaključek

Model Context Protocol (MCP) hitro oblikuje prihodnost standardizirane, varne in interoperabilne AI integracije v različnih panogah. S pomočjo študij primerov in praktičnih projektov v tej lekciji ste videli, kako zgodnji uporabniki – vključno z Microsoftom in Azure – izkoriščajo MCP za reševanje resničnih izzivov, pospeševanje uvajanja AI ter zagotavljanje skladnosti, varnosti in razširljivosti. Modularni pristop MCP omogoča organizacijam povezovanje velikih jezikovnih modelov, orodij in podatkov podjetja v enoten, revidiran okvir. Ko se MCP še naprej razvija, bo ključno ostati v stiku s skupnostjo, raziskovati odprtokodne vire in uporabljati najboljše prakse za gradnjo robustnih, na prihodnost pripravljenih AI rešitev.

## Dodatni viri

- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)
- [Integracija Azure AI agentov z MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)
- [MCP GitHub Repository (Microsoft)](https://github.com/microsoft/mcp)
- [MCP Resources Directory (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)
- [MCP skupnost in dokumentacija](https://modelcontextprotocol.io/introduction)
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
- [Microsoft AI in avtomatizacijske rešitve](https://azure.microsoft.com/en-us/products/ai-services/)

## Vaje

1. Analizirajte eno od študij primerov in predlagajte alternativni pristop implementacije.
2. Izberite eno izmed idej za projekt in pripravite podrobno tehnično specifikacijo.
3. Raziskujte industrijo, ki ni zajeta v študijah primerov, in opišite, kako bi MCP lahko rešil njene specifične izzive.
4. Raziskujte eno izmed prihodnjih smernic in ustvarite koncept nove MCP razširitve za njeno podporo.

Naslednje: [Microsoft MCP Server](../07-LessonsfromEarlyAdoption/microsoft-mcp-servers.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatski prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.