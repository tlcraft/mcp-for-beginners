<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-07-14T04:39:00+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "sk"
}
-->
# Lekcie od skorých používateľov

## Prehľad

Táto lekcia skúma, ako skorí používatelia využili Model Context Protocol (MCP) na riešenie reálnych problémov a podporu inovácií v rôznych odvetviach. Prostredníctvom podrobných prípadových štúdií a praktických projektov uvidíte, ako MCP umožňuje štandardizovanú, bezpečnú a škálovateľnú integráciu AI – spájajúc veľké jazykové modely, nástroje a podnikové dáta v jednotnom rámci. Získate praktické skúsenosti s navrhovaním a tvorbou riešení založených na MCP, naučíte sa overené implementačné vzory a objavíte najlepšie postupy pre nasadenie MCP v produkčných prostrediach. Lekcia tiež zdôrazňuje vznikajúce trendy, budúce smery a open-source zdroje, ktoré vám pomôžu zostať na čele technológie MCP a jej vyvíjajúceho sa ekosystému.

## Ciele učenia

- Analyzovať reálne implementácie MCP v rôznych odvetviach  
- Navrhnúť a vytvoriť kompletné aplikácie založené na MCP  
- Preskúmať vznikajúce trendy a budúce smery v technológii MCP  
- Aplikovať najlepšie postupy v reálnych vývojových scenároch  

## Reálne implementácie MCP

### Prípadová štúdia 1: Automatizácia zákazníckej podpory v podniku

Multinárodná spoločnosť implementovala riešenie založené na MCP na štandardizáciu AI interakcií v ich systémoch zákazníckej podpory. To im umožnilo:

- Vytvoriť jednotné rozhranie pre viacerých poskytovateľov LLM  
- Udržiavať konzistentnú správu promptov naprieč oddeleniami  
- Zaviesť robustné bezpečnostné a súladové kontroly  
- Jednoducho prepínať medzi rôznymi AI modelmi podľa konkrétnych potrieb  

**Technická implementácia:**  
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

**Výsledky:** Zníženie nákladov na modely o 30 %, zlepšenie konzistencie odpovedí o 45 % a zvýšená súladnosť v globálnych operáciách.

### Prípadová štúdia 2: Diagnostický asistent v zdravotníctve

Poskytovateľ zdravotnej starostlivosti vyvinul infraštruktúru MCP na integráciu viacerých špecializovaných medicínskych AI modelov pri zachovaní ochrany citlivých pacientskych údajov:

- Plynulé prepínanie medzi všeobecnými a špecializovanými medicínskymi modelmi  
- Prísne kontroly súkromia a auditné stopy  
- Integrácia s existujúcimi systémami Elektronických zdravotných záznamov (EHR)  
- Konzistentné navrhovanie promptov pre medicínsku terminológiu  

**Technická implementácia:**  
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

**Výsledky:** Zlepšené diagnostické návrhy pre lekárov pri plnom dodržaní HIPAA a výrazné zníženie prepínania kontextu medzi systémami.

### Prípadová štúdia 3: Analýza rizík vo finančných službách

Finančná inštitúcia implementovala MCP na štandardizáciu procesov analýzy rizík v rôznych oddeleniach:

- Vytvorenie jednotného rozhrania pre modely kreditného rizika, detekcie podvodov a investičného rizika  
- Zavedenie prísnych prístupových kontrol a verziovania modelov  
- Zabezpečenie auditovateľnosti všetkých AI odporúčaní  
- Udržiavanie konzistentného formátovania dát naprieč rôznorodými systémami  

**Technická implementácia:**  
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

**Výsledky:** Zvýšená regulačná súladnosť, o 40 % rýchlejšie cykly nasadenia modelov a zlepšená konzistencia hodnotenia rizík v oddeleniach.

### Prípadová štúdia 4: Microsoft Playwright MCP Server pre automatizáciu prehliadača

Microsoft vyvinul [Playwright MCP server](https://github.com/microsoft/playwright-mcp) na zabezpečenú a štandardizovanú automatizáciu prehliadača cez Model Context Protocol. Toto riešenie umožňuje AI agentom a LLM interagovať s webovými prehliadačmi kontrolovaným, auditovateľným a rozšíriteľným spôsobom – podporujúc použitia ako automatizované testovanie webu, extrakcia dát a end-to-end pracovné postupy.

- Zverejňuje schopnosti automatizácie prehliadača (navigácia, vyplňovanie formulárov, snímanie obrazovky a pod.) ako MCP nástroje  
- Zavádza prísne prístupové kontroly a sandboxing na zabránenie neoprávneným akciám  
- Poskytuje detailné auditné záznamy všetkých interakcií s prehliadačom  
- Podporuje integráciu s Azure OpenAI a ďalšími poskytovateľmi LLM pre agentnú automatizáciu  

**Technická implementácia:**  
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

**Výsledky:**  
- Umožnená bezpečná, programovateľná automatizácia prehliadača pre AI agentov a LLM  
- Znížená manuálna námaha pri testovaní a zlepšené pokrytie testami webových aplikácií  
- Poskytnutý znovupoužiteľný a rozšíriteľný rámec pre integráciu nástrojov založených na prehliadači v podnikových prostrediach  

**Referencie:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Prípadová štúdia 5: Azure MCP – Podnikový Model Context Protocol ako služba

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) je spravovaná, podniková implementácia Model Context Protocol od Microsoftu, navrhnutá na poskytovanie škálovateľných, bezpečných a súladových MCP serverových kapacít ako cloudovej služby. Azure MCP umožňuje organizáciám rýchlo nasadzovať, spravovať a integrovať MCP servery s Azure AI, dátovými a bezpečnostnými službami, čím znižuje prevádzkové náklady a urýchľuje adopciu AI.

- Plne spravované hostovanie MCP servera s integrovaným škálovaním, monitorovaním a bezpečnosťou  
- Nativna integrácia s Azure OpenAI, Azure AI Search a ďalšími Azure službami  
- Podniková autentifikácia a autorizácia cez Microsoft Entra ID  
- Podpora vlastných nástrojov, šablón promptov a konektorov zdrojov  
- Súlad s podnikateľskými bezpečnostnými a regulačnými požiadavkami  

**Technická implementácia:**  
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

**Výsledky:**  
- Skrátenie času na dosiahnutie hodnoty pre podnikové AI projekty vďaka pripravenému, súladovému MCP serveru  
- Zjednodušená integrácia LLM, nástrojov a podnikových dátových zdrojov  
- Zvýšená bezpečnosť, pozorovateľnosť a prevádzková efektívnosť MCP záťaží  

**Referencie:**  
- [Azure MCP Dokumentácia](https://aka.ms/azmcp)  
- [Azure AI Služby](https://azure.microsoft.com/en-us/products/ai-services/)

## Prípadová štúdia 6: NLWeb  
MCP (Model Context Protocol) je vznikajúci protokol pre chatboty a AI asistentov na interakciu s nástrojmi. Každá inštancia NLWeb je zároveň MCP server, ktorý podporuje jednu základnú metódu ask, používanú na kladenie otázok webovej stránke v prirodzenom jazyku. Vrátená odpoveď využíva schema.org, široko používaný slovník na popis webových dát. Voľne povedané, MCP je pre NLWeb to, čo je Http pre HTML. NLWeb kombinuje protokoly, formáty schema.org a ukážkový kód, aby pomohol stránkam rýchlo vytvárať tieto koncové body, čím prospieva ľuďom cez konverzačné rozhrania a strojom cez prirodzenú agent-agent interakciu.

NLWeb pozostáva z dvoch samostatných častí:  
- Protokol, veľmi jednoduchý na začiatok, na komunikáciu so stránkou v prirodzenom jazyku a formát, ktorý využíva json a schema.org pre vrátenú odpoveď. Viac informácií nájdete v dokumentácii REST API.  
- Jednoduchá implementácia (1), ktorá využíva existujúce značkovanie pre stránky, ktoré možno abstraktne zobraziť ako zoznamy položiek (produkty, recepty, atrakcie, recenzie a pod.). Spolu so súborom používateľských widgetov môžu stránky ľahko poskytovať konverzačné rozhrania k ich obsahu. Viac o tom, ako to funguje, nájdete v dokumentácii Life of a chat query.  

**Referencie:**  
- [Azure MCP Dokumentácia](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Prípadová štúdia 7: MCP pre Foundry – Integrácia Azure AI agentov

Azure AI Foundry MCP servery ukazujú, ako možno MCP využiť na orchestráciu a správu AI agentov a pracovných tokov v podnikových prostrediach. Integráciou MCP s Azure AI Foundry môžu organizácie štandardizovať interakcie agentov, využiť správu pracovných tokov Foundry a zabezpečiť bezpečné, škálovateľné nasadenia. Tento prístup umožňuje rýchle prototypovanie, robustné monitorovanie a bezproblémovú integráciu so službami Azure AI, podporujúc pokročilé scenáre ako správa znalostí a hodnotenie agentov. Vývojári získavajú jednotné rozhranie na tvorbu, nasadenie a monitorovanie agentných pipeline, zatiaľ čo IT tímy profitujú zo zlepšenej bezpečnosti, súladu a prevádzkovej efektívnosti. Riešenie je ideálne pre podniky, ktoré chcú urýchliť adopciu AI a zároveň si udržať kontrolu nad komplexnými procesmi riadenými agentmi.

**Referencie:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrácia Azure AI agentov s MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Prípadová štúdia 8: Foundry MCP Playground – Experimentovanie a prototypovanie

Foundry MCP Playground ponúka pripravené prostredie na experimentovanie s MCP servermi a integráciami Azure AI Foundry. Vývojári môžu rýchlo prototypovať, testovať a hodnotiť AI modely a agentné pracovné toky pomocou zdrojov z Azure AI Foundry Catalog a Labs. Playground zjednodušuje nastavenie, poskytuje ukážkové projekty a podporuje spoluprácu na vývoji, čo uľahčuje skúmanie najlepších postupov a nových scenárov s minimálnou záťažou. Je obzvlášť užitočný pre tímy, ktoré chcú overiť nápady, zdieľať experimenty a urýchliť učenie bez potreby zložitej infraštruktúry. Znížením vstupnej bariéry podporuje inovácie a komunitné príspevky v ekosystéme MCP a Azure AI Foundry.

**Referencie:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Prípadová štúdia 9: Microsoft Docs MCP Server – Vzdelávanie a rozvoj zručností  
Microsoft Docs MCP Server implementuje Model Context Protocol (MCP) server, ktorý poskytuje AI asistentom prístup v reálnom čase k oficiálnej dokumentácii Microsoftu. Vykonáva sémantické vyhľadávanie v oficiálnej technickej dokumentácii Microsoftu.

**Referencie:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## Praktické projekty

### Projekt 1: Vytvorte MCP server s viacerými poskytovateľmi

**Cieľ:** Vytvoriť MCP server, ktorý dokáže smerovať požiadavky k viacerým poskytovateľom AI modelov na základe špecifických kritérií.

**Požiadavky:**  
- Podpora aspoň troch rôznych poskytovateľov modelov (napr. OpenAI, Anthropic, lokálne modely)  
- Implementácia smerovacieho mechanizmu založeného na metadátach požiadavky  
- Vytvorenie konfiguračného systému na správu prihlasovacích údajov poskytovateľov  
- Pridanie cache na optimalizáciu výkonu a nákladov  
- Vytvorenie jednoduchého dashboardu na monitorovanie používania  

**Kroky implementácie:**  
1. Nastaviť základnú infraštruktúru MCP servera  
2. Implementovať adaptéry poskytovateľov pre každý AI model  
3. Vytvoriť smerovaciu logiku na základe atribútov požiadavky  
4. Pridať cache mechanizmy pre časté požiadavky  
5. Vyvinúť monitorovací dashboard  
6. Testovať s rôznymi vzormi požiadaviek  

**Technológie:** Vyberte si z Pythonu (.NET/Java/Python podľa preferencie), Redis pre cache a jednoduchý webový framework pre dashboard.

### Projekt 2: Podnikový systém správy promptov

**Cieľ:** Vyvinúť systém založený na MCP na správu, verziovanie a nasadzovanie šablón promptov v rámci organizácie.

**Požiadavky:**  
- Vytvoriť centralizované úložisko šablón promptov  
- Implementovať verziovanie a schvaľovacie workflow  
- Vybudovať testovacie schopnosti šablón s ukážkovými vstupmi  
- Vyvinúť prístupové kontroly založené na rolách  
- Vytvoriť API na získavanie a nasadzovanie šablón  

**Kroky implementácie:**  
1. Navrhnúť databázové schéma pre ukladanie šablón  
2. Vytvoriť základné API pre CRUD operácie so šablónami  
3. Implementovať systém verziovania  
4. Vybudovať schvaľovací workflow  
5. Vyvinúť testovací rámec  
6. Vytvoriť jednoduché webové rozhranie na správu  
7. Integrovať s MCP serverom  

**Technológie:** Výber backend frameworku, SQL alebo NoSQL databázy a frontend frameworku pre správu.

### Projekt 3: Platforma na generovanie obsahu založená na MCP

**Cieľ:** Vytvoriť platformu na generovanie obsahu, ktorá využíva MCP na poskytovanie konzistentných výsledkov pre rôzne typy obsahu.

**Požiadavky:**  
- Podpora viacerých formátov obsahu (blogové príspevky, sociálne médiá, marketingové texty)  
- Implementácia generovania na základe šablón s možnosťou prispôsobenia  
- Vytvorenie systému na recenziu a spätnú väzbu k obsahu  
- Sledovanie metrík výkonnosti obsahu  
- Podpora verziovania a iterácie obsahu  

**Kroky implementácie:**  
1. Nastaviť MCP klientsku infraštruktúru  
2. Vytvoriť šablóny pre rôzne typy obsahu  
3. Vybudovať pipeline generovania obsahu  
4. Implementovať systém recenzií  
5. Vyvinúť systém sledovania metrík  
6. Vytvoriť používateľské rozhranie na správu šablón a generovanie obsahu  

**Technológie:** Preferovaný programovací jazyk, webový framework a databázový systém.

## Budúce smery technológie MCP

### Vznikajúce trendy

1. **Multi-modálny MCP**  
   - Rozšírenie MCP na štandardizáciu interakcií s obrazovými, audio a video modelmi  
   - Vývoj schopností medzi-modalitného uvažovania  
   - Štandardizované formáty promptov pre rôzne modality  

2. **Federovaná MCP infraštruktúra**  
   - Distribuované MCP siete zdieľajúce zdroje medzi organizáciami  
   - Štandardizované protokoly na bezpečné zdieľanie modelov  
   - Techniky výpočtov zachovávajúcich súkromie  

3. **MCP trhy**  
   - Ekosystémy na zdieľanie a monetizáciu MCP šablón a pluginov  
   - Procesy zabezpečenia kvality a certifikácie  
   - Integrácia s trhmi modelov  

4. **MCP pre edge computing**  
   - Adaptácia MCP štandardov pre zariadenia s obmedzenými
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Úvodná stránka pre implementácie Remote MCP Serverov v Azure Functions s odkazmi na repozitáre pre jednotlivé programovacie jazyky  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Šablóna na rýchly štart pre vytváranie a nasadzovanie vlastných vzdialených MCP serverov pomocou Azure Functions v Pythone  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Šablóna na rýchly štart pre vytváranie a nasadzovanie vlastných vzdialených MCP serverov pomocou Azure Functions v .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Šablóna na rýchly štart pre vytváranie a nasadzovanie vlastných vzdialených MCP serverov pomocou Azure Functions v TypeScripte  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management ako AI Gateway pre vzdialené MCP servery pomocou Pythonu  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI experimenty vrátane MCP funkcií, integrujúce Azure OpenAI a AI Foundry  

Tieto repozitáre poskytujú rôzne implementácie, šablóny a zdroje na prácu s Model Context Protocol v rôznych programovacích jazykoch a službách Azure. Pokrývajú široké spektrum použitia od základných implementácií serverov až po autentifikáciu, nasadenie v cloude a scenáre integrácie v podnikovej sfére.

#### MCP Resources Directory

Adresár [MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) v oficiálnom repozitári Microsoft MCP ponúka starostlivo vybranú kolekciu ukážkových zdrojov, šablón promptov a definícií nástrojov na použitie s Model Context Protocol servermi. Tento adresár je navrhnutý tak, aby vývojárom umožnil rýchly štart s MCP tým, že poskytuje znovupoužiteľné stavebné bloky a príklady osvedčených postupov pre:

- **Šablóny promptov:** Hotové šablóny promptov pre bežné AI úlohy a scenáre, ktoré je možné prispôsobiť pre vlastné implementácie MCP serverov.  
- **Definície nástrojov:** Príklady schém a metadát nástrojov na štandardizáciu integrácie a volania nástrojov naprieč rôznymi MCP servermi.  
- **Ukážkové zdroje:** Príklady definícií zdrojov na pripojenie k dátovým zdrojom, API a externým službám v rámci MCP.  
- **Referenčné implementácie:** Praktické ukážky, ktoré demonštrujú, ako štruktúrovať a organizovať zdroje, prompty a nástroje v reálnych MCP projektoch.  

Tieto zdroje urýchľujú vývoj, podporujú štandardizáciu a pomáhajú zabezpečiť osvedčené postupy pri tvorbe a nasadzovaní riešení založených na MCP.

#### MCP Resources Directory
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Výskumné príležitosti

- Efektívne techniky optimalizácie promptov v rámci MCP  
- Bezpečnostné modely pre multi-tenantné nasadenia MCP  
- Výkonnostné benchmarky rôznych implementácií MCP  
- Formálne overovacie metódy pre MCP servery  

## Záver

Model Context Protocol (MCP) rýchlo formuje budúcnosť štandardizovanej, bezpečnej a interoperabilnej AI integrácie naprieč odvetviami. Prostredníctvom prípadových štúdií a praktických projektov v tejto lekcii ste videli, ako skorí používatelia – vrátane Microsoftu a Azure – využívajú MCP na riešenie reálnych problémov, zrýchlenie adopcie AI a zabezpečenie súladu, bezpečnosti a škálovateľnosti. Modulárny prístup MCP umožňuje organizáciám prepojiť veľké jazykové modely, nástroje a podnikové dáta v jednotnom, auditovateľnom rámci. Ako MCP pokračuje vo vývoji, kľúčové bude zostať aktívnym v komunite, skúmať open-source zdroje a aplikovať osvedčené postupy na vytváranie robustných, budúcnosti pripravených AI riešení.

## Ďalšie zdroje

- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)  
- [Integrácia Azure AI agentov s MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  
- [MCP GitHub Repository (Microsoft)](https://github.com/microsoft/mcp)  
- [MCP Resources Directory (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)  
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

## Cvičenia

1. Analyzujte jednu z prípadových štúdií a navrhnite alternatívny prístup k implementácii.  
2. Vyberte si jeden z projektových nápadov a vytvorte podrobnú technickú špecifikáciu.  
3. Preskúmajte odvetvie, ktoré nebolo pokryté v prípadových štúdiách, a načrtnite, ako by MCP mohlo riešiť jeho špecifické výzvy.  
4. Preskúmajte jeden z budúcich smerov a vytvorte koncept novej MCP rozšírenia na jeho podporu.  

Ďalej: [Best Practices](../08-BestPractices/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.