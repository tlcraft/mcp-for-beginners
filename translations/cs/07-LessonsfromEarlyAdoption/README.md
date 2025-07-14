<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-07-14T04:38:19+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "cs"
}
-->
# Lekce od raných uživatelů

## Přehled

Tato lekce zkoumá, jak raní uživatelé využili Model Context Protocol (MCP) k řešení reálných problémů a podpoře inovací v různých odvětvích. Prostřednictvím podrobných případových studií a praktických projektů uvidíte, jak MCP umožňuje standardizovanou, bezpečnou a škálovatelnou integraci AI – propojující velké jazykové modely, nástroje a podniková data v jednotném rámci. Získáte praktické zkušenosti s navrhováním a vytvářením řešení založených na MCP, naučíte se osvědčené implementační vzory a objevíte nejlepší postupy pro nasazení MCP v produkčním prostředí. Lekce také zdůrazňuje nové trendy, budoucí směřování a open-source zdroje, které vám pomohou zůstat na špici technologie MCP a jejího vyvíjejícího se ekosystému.

## Výukové cíle

- Analyzovat reálné implementace MCP v různých odvětvích  
- Navrhnout a vytvořit kompletní aplikace založené na MCP  
- Prozkoumat nové trendy a budoucí směřování technologie MCP  
- Aplikovat nejlepší postupy v reálných vývojových scénářích  

## Reálné implementace MCP

### Případová studie 1: Automatizace zákaznické podpory ve firmě

Nadnárodní korporace implementovala řešení založené na MCP, aby standardizovala AI interakce napříč svými systémy zákaznické podpory. Díky tomu mohli:

- Vytvořit jednotné rozhraní pro více poskytovatelů LLM  
- Udržovat konzistentní správu promptů napříč odděleními  
- Zavést robustní bezpečnostní a compliance kontroly  
- Snadno přepínat mezi různými AI modely podle konkrétních potřeb  

**Technická implementace:**  
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

**Výsledky:** 30% snížení nákladů na modely, 45% zlepšení konzistence odpovědí a zvýšená compliance v globálním měřítku.

### Případová studie 2: Diagnostický asistent ve zdravotnictví

Poskytovatel zdravotní péče vyvinul infrastrukturu MCP pro integraci více specializovaných lékařských AI modelů, přičemž zajistil ochranu citlivých pacientských dat:

- Plynulé přepínání mezi obecnými a specializovanými lékařskými modely  
- Přísné zásady ochrany soukromí a auditní stopy  
- Integrace s existujícími systémy Elektronických zdravotních záznamů (EHR)  
- Konzistentní prompt engineering pro lékařskou terminologii  

**Technická implementace:**  
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

**Výsledky:** Zlepšená diagnostická doporučení pro lékaře při plné shodě s HIPAA a výrazné snížení přepínání kontextu mezi systémy.

### Případová studie 3: Analýza rizik ve finančních službách

Finanční instituce implementovala MCP pro standardizaci procesů analýzy rizik napříč různými odděleními:

- Vytvoření jednotného rozhraní pro modely kreditního rizika, detekce podvodů a investičního rizika  
- Zavedení přísných přístupových kontrol a verzování modelů  
- Zajištění auditovatelnosti všech AI doporučení  
- Udržení konzistentního formátování dat napříč různorodými systémy  

**Technická implementace:**  
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

**Výsledky:** Zvýšená shoda s regulacemi, o 40 % rychlejší nasazení modelů a lepší konzistence hodnocení rizik napříč odděleními.

### Případová studie 4: Microsoft Playwright MCP Server pro automatizaci prohlížeče

Microsoft vyvinul [Playwright MCP server](https://github.com/microsoft/playwright-mcp), který umožňuje bezpečnou a standardizovanou automatizaci prohlížeče pomocí Model Context Protocol. Toto řešení umožňuje AI agentům a LLM komunikovat s webovými prohlížeči kontrolovaným, auditovatelným a rozšiřitelným způsobem – podporující scénáře jako automatizované testování webu, extrakce dat a end-to-end workflow.

- Zpřístupňuje funkce automatizace prohlížeče (navigace, vyplňování formulářů, snímání obrazovky atd.) jako MCP nástroje  
- Zavádí přísné přístupové kontroly a sandboxing k zabránění neoprávněným akcím  
- Poskytuje podrobné auditní záznamy všech interakcí s prohlížečem  
- Podporuje integraci s Azure OpenAI a dalšími poskytovateli LLM pro agentní automatizaci  

**Technická implementace:**  
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
- Umožnil bezpečnou programovou automatizaci prohlížeče pro AI agenty a LLM  
- Snížil manuální testovací úsilí a zlepšil pokrytí testů webových aplikací  
- Poskytl znovupoužitelný a rozšiřitelný rámec pro integraci nástrojů založených na prohlížeči v podnikovém prostředí  

**Reference:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Případová studie 5: Azure MCP – Podniková služba Model Context Protocol

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) je spravovaná, podniková implementace Model Context Protocol od Microsoftu, navržená tak, aby poskytovala škálovatelné, bezpečné a vyhovující MCP serverové funkce jako cloudovou službu. Azure MCP umožňuje organizacím rychle nasazovat, spravovat a integrovat MCP servery s Azure AI, datovými a bezpečnostními službami, čímž snižuje provozní náklady a urychluje adopci AI.

- Plně spravovaný hosting MCP serveru s vestavěným škálováním, monitorováním a bezpečností  
- Nativní integrace s Azure OpenAI, Azure AI Search a dalšími službami Azure  
- Podniková autentizace a autorizace přes Microsoft Entra ID  
- Podpora vlastních nástrojů, šablon promptů a konektorů zdrojů  
- Soulad s bezpečnostními a regulačními požadavky podniků  

**Technická implementace:**  
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
- Zkrácení doby potřebné k dosažení hodnoty u podnikových AI projektů díky připravené, vyhovující MCP serverové platformě  
- Zjednodušení integrace LLM, nástrojů a podnikových datových zdrojů  
- Zvýšení bezpečnosti, pozorovatelnosti a provozní efektivity MCP workloadů  

**Reference:**  
- [Azure MCP Dokumentace](https://aka.ms/azmcp)  
- [Azure AI Služby](https://azure.microsoft.com/en-us/products/ai-services/)

## Případová studie 6: NLWeb  
MCP (Model Context Protocol) je vznikající protokol pro chatboty a AI asistenty k interakci s nástroji. Každá instance NLWeb je zároveň MCP server, který podporuje jednu základní metodu ask, používanou k položení otázky webové stránce v přirozeném jazyce. Vrácená odpověď využívá schema.org, široce používaný slovník pro popis webových dat. Volně řečeno, MCP je k NLWebu to, co je Http k HTML. NLWeb kombinuje protokoly, formáty Schema.org a ukázkový kód, aby pomohl webům rychle vytvářet tyto koncové body, což prospívá jak lidem prostřednictvím konverzačních rozhraní, tak strojům díky přirozené agentní interakci.

NLWeb má dvě hlavní složky:  
- Protokol, velmi jednoduchý na začátek, pro komunikaci s webem v přirozeném jazyce a formát, který využívá json a schema.org pro vrácenou odpověď. Více informací najdete v dokumentaci REST API.  
- Jednoduchá implementace (1), která využívá existující značkování pro weby, které lze abstraktně pojmout jako seznamy položek (produkty, recepty, atrakce, recenze atd.). Spolu se sadou uživatelských widgetů mohou weby snadno poskytovat konverzační rozhraní ke svému obsahu. Více o tom, jak to funguje, najdete v dokumentaci Life of a chat query.  

**Reference:**  
- [Azure MCP Dokumentace](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Případová studie 7: MCP pro Foundry – Integrace Azure AI agentů

Azure AI Foundry MCP servery ukazují, jak lze MCP využít k orchestraci a správě AI agentů a workflow v podnikovém prostředí. Integrací MCP s Azure AI Foundry mohou organizace standardizovat interakce agentů, využívat správu workflow Foundry a zajistit bezpečné, škálovatelné nasazení. Tento přístup umožňuje rychlé prototypování, robustní monitorování a bezproblémovou integraci se službami Azure AI, podporující pokročilé scénáře jako správa znalostí a hodnocení agentů. Vývojáři získávají jednotné rozhraní pro tvorbu, nasazení a sledování agentních pipeline, zatímco IT týmy těží z lepší bezpečnosti, compliance a provozní efektivity. Řešení je ideální pro podniky, které chtějí urychlit adopci AI a udržet kontrolu nad složitými procesy řízenými agenty.

**Reference:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrace Azure AI agentů s MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Případová studie 8: Foundry MCP Playground – Experimentování a prototypování

Foundry MCP Playground nabízí připravené prostředí pro experimentování s MCP servery a integracemi Azure AI Foundry. Vývojáři mohou rychle prototypovat, testovat a hodnotit AI modely a agentní workflow pomocí zdrojů z Azure AI Foundry Catalog a Labs. Playground usnadňuje nastavení, poskytuje ukázkové projekty a podporuje spolupráci, což umožňuje snadno zkoumat nejlepší postupy a nové scénáře s minimální režii. Je zvláště užitečný pro týmy, které chtějí ověřovat nápady, sdílet experimenty a urychlit učení bez potřeby složité infrastruktury. Snížením vstupní bariéry podporuje inovace a komunitní příspěvky v ekosystému MCP a Azure AI Foundry.

**Reference:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Případová studie 9: Microsoft Docs MCP Server – Vzdělávání a rozvoj dovedností  
Microsoft Docs MCP Server implementuje Model Context Protocol server, který poskytuje AI asistentům přístup v reálném čase k oficiální dokumentaci Microsoftu. Provádí sémantické vyhledávání v oficiální technické dokumentaci Microsoftu.

**Reference:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## Praktické projekty

### Projekt 1: Vytvoření MCP serveru s více poskytovateli

**Cíl:** Vytvořit MCP server, který dokáže směrovat požadavky k více poskytovatelům AI modelů podle specifických kritérií.

**Požadavky:**  
- Podpora alespoň tří různých poskytovatelů modelů (např. OpenAI, Anthropic, lokální modely)  
- Implementace směrovacího mechanismu založeného na metadatech požadavku  
- Vytvoření konfiguračního systému pro správu přihlašovacích údajů poskytovatelů  
- Přidání cache pro optimalizaci výkonu a nákladů  
- Vytvoření jednoduchého dashboardu pro sledování využití  

**Kroky implementace:**  
1. Nastavení základní infrastruktury MCP serveru  
2. Implementace adaptérů poskytovatelů pro každý AI model  
3. Vytvoření směrovací logiky na základě atributů požadavku  
4. Přidání cache mechanismů pro časté požadavky  
5. Vývoj monitorovacího dashboardu  
6. Testování s různými vzory požadavků  

**Technologie:** Výběr z Pythonu (.NET/Java/Python dle preference), Redis pro cache a jednoduchý webový framework pro dashboard.

### Projekt 2: Podnikový systém správy promptů

**Cíl:** Vyvinout systém založený na MCP pro správu, verzování a nasazení šablon promptů v rámci organizace.

**Požadavky:**  
- Vytvoření centralizovaného repozitáře šablon promptů  
- Implementace verzování a schvalovacích workflow  
- Vytvoření testovacích funkcí šablon s ukázkovými vstupy  
- Vývoj řízení přístupu založeného na rolích  
- Vytvoření API pro získávání a nasazení šablon  

**Kroky implementace:**  
1. Návrh databázového schématu pro ukládání šablon  
2. Vytvoření základního API pro CRUD operace se šablonami  
3. Implementace systému verzování  
4. Vývoj schvalovacího workflow  
5. Vytvoření testovacího frameworku  
6. Vývoj jednoduchého webového rozhraní pro správu  
7. Integrace s MCP serverem  

**Technologie:** Volba backendového frameworku, SQL nebo NoSQL databáze a frontendového frameworku pro správu.

### Projekt 3: Platforma pro generování obsahu založená na MCP

**Cíl:** Vytvořit platformu pro generování obsahu, která využívá MCP k zajištění konzistentních výsledků napříč různými typy obsahu.

**Požadavky:**  
- Podpora více formátů obsahu (blogové příspěvky, sociální média, marketingové texty)  
- Implementace generování založeného na šablonách s možností přizpůsobení  
- Vytvoření systému pro recenze a zpětnou vazbu k obsahu  
- Sledování metrik výkonu obsahu  
- Podpora verzování a iterací obsahu  

**Kroky implementace:**  
1. Nastavení MCP klientské infrastruktury  
2. Vytvoření šablon pro různé typy obsahu  
3. Vývoj pipeline pro generování obsahu  
4. Implementace systému recenzí  
5. Vývoj systému sledování metrik  
6. Vytvoření uživatelského rozhraní pro správu šablon a generování obsahu  

**Technologie:** Vámi preferovaný programovací jazyk, webový framework a databázový systém.

## Budoucí směřování technologie MCP

### Nové trendy

1. **Multi-modální MCP**  
   - Rozšíření MCP pro standardizaci interakcí s modely pro obrázky, zvuk a video  
   - Vývoj schopností křížové modalitní dedukce  
   - Standardizované formáty promptů pro různé modality  

2. **Federovaná MCP infrastruktura**  
   - Distribuované MCP sítě sdílející zdroje mezi organizacemi  
   - Standardizované protokoly pro bezpečné sdílení modelů  
   - Techniky výpočtů zachovávajících soukromí  

3. **MCP tržiště**  
   - Ekosystémy pro sdílení a monetizaci MCP šablon a pluginů  
   - Procesy zajištění kvality a certifikace  
   - Integrace s tržišti modelů  

4. **MCP pro edge computing**  
   - Přizpůsobení MCP standardů pro zařízení s omezenými zdroji na okraji sítě  
   - Optimalizované protokoly pro prostředí s nízkou šířkou pásma  
   - Specializované MCP implementace pro IoT ekosystémy  

5. **Regulační rámce**  
   - Vývoj rozšíření MCP pro splnění regulačních požadavků  
   - Standardizované auditní stopy a rozhraní pro vysvětlitelnost  
   - Integrace s nově vznikajícími rámci správy AI  

### MCP řešení od Microsoftu

Microsoft a Azure vyvinuly několik open-source repozitářů, které pomáhají vývojářům implementovat MCP v různých scénářích:

#### Organizace Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – Playwright MCP server pro automatizaci a testování prohlížeče  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – Implementace OneDrive MCP serveru pro lokální testování a komunitní příspěvky  
3. [NLWeb](https://github.com/microsoft/NlWeb)
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Úvodní stránka pro implementace Remote MCP Serverů v Azure Functions s odkazy na repozitáře specifické pro jednotlivé jazyky  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Šablona pro rychlý start při vytváření a nasazování vlastních vzdálených MCP serverů pomocí Azure Functions v Pythonu  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Šablona pro rychlý start při vytváření a nasazování vlastních vzdálených MCP serverů pomocí Azure Functions v .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Šablona pro rychlý start při vytváření a nasazování vlastních vzdálených MCP serverů pomocí Azure Functions v TypeScriptu  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management jako AI Gateway pro vzdálené MCP servery pomocí Pythonu  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI experimenty včetně schopností MCP, integrace s Azure OpenAI a AI Foundry  

Tyto repozitáře poskytují různé implementace, šablony a zdroje pro práci s Model Context Protocol napříč různými programovacími jazyky a službami Azure. Pokrývají široké spektrum použití od základních implementací serverů až po autentizaci, nasazení v cloudu a scénáře podnikové integrace.

#### MCP Resources Directory

Adresář [MCP Resources directory](https://github.com/microsoft/mcp/tree/main/Resources) v oficiálním repozitáři Microsoft MCP nabízí pečlivě vybranou kolekci ukázkových zdrojů, šablon promptů a definic nástrojů pro použití s Model Context Protocol servery. Tento adresář je navržen tak, aby vývojářům usnadnil rychlý start s MCP tím, že nabízí znovupoužitelné stavební bloky a příklady osvědčených postupů pro:

- **Šablony promptů:** Připravené šablony promptů pro běžné AI úlohy a scénáře, které lze přizpůsobit pro vlastní implementace MCP serverů.  
- **Definice nástrojů:** Příklady schémat nástrojů a metadat pro standardizaci integrace a volání nástrojů napříč různými MCP servery.  
- **Ukázkové zdroje:** Příklady definic zdrojů pro připojení k datovým zdrojům, API a externím službám v rámci MCP.  
- **Referenční implementace:** Praktické ukázky, které demonstrují, jak strukturovat a organizovat zdroje, prompty a nástroje v reálných MCP projektech.  

Tyto zdroje urychlují vývoj, podporují standardizaci a pomáhají zajistit osvědčené postupy při vytváření a nasazování řešení založených na MCP.

#### MCP Resources Directory
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Výzkumné příležitosti

- Efektivní techniky optimalizace promptů v rámci MCP  
- Bezpečnostní modely pro multi-tenantní nasazení MCP  
- Výkonové testování napříč různými implementacemi MCP  
- Formální metody ověřování MCP serverů  

## Závěr

Model Context Protocol (MCP) rychle formuje budoucnost standardizované, bezpečné a interoperabilní AI integrace napříč odvětvími. Prostřednictvím případových studií a praktických projektů v této lekci jste viděli, jak raní uživatelé – včetně Microsoftu a Azure – využívají MCP k řešení reálných výzev, urychlení adopce AI a zajištění souladu, bezpečnosti a škálovatelnosti. Modulární přístup MCP umožňuje organizacím propojit velké jazykové modely, nástroje a podniková data v jednotném, auditovatelném rámci. Jak MCP pokračuje ve svém vývoji, klíčem k budování robustních a připravených AI řešení bude aktivní zapojení do komunity, využívání open-source zdrojů a aplikace osvědčených postupů.

## Další zdroje

- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)  
- [Integrace Azure AI agentů s MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  
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

## Cvičení

1. Analyzujte jednu z případových studií a navrhněte alternativní přístup k implementaci.  
2. Vyberte si jeden z projektových nápadů a vytvořte podrobnou technickou specifikaci.  
3. Prozkoumejte odvětví, které nebylo pokryto v případových studiích, a načrtněte, jak by MCP mohlo řešit jeho specifické výzvy.  
4. Prozkoumejte jeden z budoucích směrů a vytvořte koncept nové MCP rozšíření, které by jej podporovalo.  

Další: [Best Practices](../08-BestPractices/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.