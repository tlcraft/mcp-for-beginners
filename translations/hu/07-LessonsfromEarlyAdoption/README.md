<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T22:18:53+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "hu"
}
-->
# Korai alkalmazók tapasztalatai

## Áttekintés

Ez a lecke azt vizsgálja, hogyan használták a korai alkalmazók a Model Context Protocolt (MCP) valós problémák megoldására és az innováció előmozdítására különböző iparágakban. Részletes esettanulmányokon és gyakorlati projektek révén megismerheted, miként teszi lehetővé az MCP a szabványosított, biztonságos és skálázható MI-integrációt—összekapcsolva a nagynyelvű modelleket, eszközöket és vállalati adatokat egy egységes keretrendszerben. Gyakorlati tapasztalatot szerezhetsz MCP-alapú megoldások tervezésében és építésében, megtanulhatod a bevált megvalósítási mintákat, valamint a legjobb gyakorlatokat a MCP éles környezetben történő alkalmazásához. A lecke kitér a felmerülő trendekre, jövőbeli irányokra és nyílt forráskódú erőforrásokra, hogy naprakész maradj az MCP technológia és annak fejlődő ökoszisztémája terén.

## Tanulási célok

- Valós MCP-megvalósítások elemzése különböző iparágakban  
- Teljes MCP-alapú alkalmazások tervezése és fejlesztése  
- Az MCP technológia felmerülő trendjeinek és jövőbeli irányainak feltérképezése  
- Legjobb gyakorlatok alkalmazása valós fejlesztési helyzetekben  

## Valós MCP-megvalósítások

### Esettanulmány 1: Vállalati ügyféltámogatás automatizálása

Egy multinacionális vállalat MCP-alapú megoldást vezetett be az MI-interakciók szabványosítására az ügyfélszolgálati rendszereikben. Ennek eredményeként:

- Egységes felületet hoztak létre több LLM szolgáltató számára  
- Egységes promptkezelést biztosítottak az osztályok között  
- Erős biztonsági és megfelelőségi kontrollokat vezettek be  
- Könnyen váltottak a különböző MI-modellek között az adott igények szerint  

**Technikai megvalósítás:**  
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

**Eredmények:** 30%-os költségcsökkenés a modellek terén, 45%-os válaszkonzisztencia javulás, és fokozott megfelelőség a globális működésben.

### Esettanulmány 2: Egészségügyi diagnosztikai asszisztens

Egy egészségügyi szolgáltató MCP-infrastruktúrát fejlesztett ki, hogy több speciális orvosi MI-modellt integráljon, miközben érzékeny betegadatokat védett:

- Zökkenőmentes váltás általános és szakosított orvosi modellek között  
- Szigorú adatvédelmi kontrollok és auditnaplók  
- Integráció a meglévő Elektronikus Egészségügyi Nyilvántartó (EHR) rendszerekkel  
- Egységes prompttervezés az orvosi terminológia számára  

**Technikai megvalósítás:**  
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

**Eredmények:** Javultak az orvosi diagnosztikai javaslatok, miközben teljes HIPAA megfelelőség fennmaradt, és jelentősen csökkent a rendszerek közötti kontextusváltás.

### Esettanulmány 3: Pénzügyi szolgáltatások kockázatelemzése

Egy pénzügyi intézmény MCP-t vezetett be, hogy szabványosítsa a kockázatelemzési folyamatait különböző osztályokon:

- Egységes felületet hoztak létre hitelkockázat, csalásfelderítés és befektetési kockázat modellekhez  
- Szigorú hozzáférés-vezérlést és modellverzió-kezelést alkalmaztak  
- Biztosították az összes MI-ajánlás auditálhatóságát  
- Egységes adatformátumot tartottak fenn a különböző rendszerek között  

**Technikai megvalósítás:**  
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

**Eredmények:** Javult a szabályozói megfelelés, 40%-kal gyorsabb modellbevezetési ciklusok, és jobb kockázatértékelési konzisztencia az osztályok között.

### Esettanulmány 4: Microsoft Playwright MCP szerver böngésző-automatizáláshoz

A Microsoft fejlesztette a [Playwright MCP szervert](https://github.com/microsoft/playwright-mcp), amely lehetővé teszi a biztonságos, szabványosított böngésző-automatizálást a Model Context Protocolon keresztül. Ez a megoldás lehetővé teszi, hogy MI-ügynökök és LLM-ek szabályozott, auditálható és bővíthető módon kommunikáljanak a webböngészőkkel, támogatva például az automatikus webes tesztelést, adatkinyerést és end-to-end munkafolyamatokat.

- Böngésző-automatizálási funkciók (navigáció, űrlapkitöltés, képernyőkép készítés stb.) MCP eszközként való elérhetősége  
- Szigorú hozzáférés-vezérlés és sandbox környezet az illetéktelen műveletek megakadályozására  
- Részletes auditnaplók minden böngésző-interakcióról  
- Integráció támogatása Azure OpenAI-val és más LLM szolgáltatókkal az ügynökvezérelt automatizáláshoz  

**Technikai megvalósítás:**  
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

**Eredmények:**  
- Biztonságos, programozott böngésző-automatizálás AI-ügynökök és LLM-ek számára  
- Csökkentett manuális tesztelési erőfeszítés és javított tesztlefedettség webalkalmazások esetén  
- Újrahasznosítható, bővíthető keretrendszer a böngészőalapú eszközintegrációhoz vállalati környezetben  

**Hivatkozások:**  
- [Playwright MCP Server GitHub tárhely](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI és automatizációs megoldások](https://azure.microsoft.com/en-us/products/ai-services/)

### Esettanulmány 5: Azure MCP – Vállalati szintű Model Context Protocol szolgáltatásként

Az Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) a Microsoft által kezelt, vállalati szintű Model Context Protocol megvalósítás, amely skálázható, biztonságos és megfelelőségi MCP szerver szolgáltatást nyújt felhőben. Az Azure MCP lehetővé teszi a szervezetek számára, hogy gyorsan telepítsék, kezeljék és integrálják az MCP szervereket az Azure MI-, adat- és biztonsági szolgáltatásaival, csökkentve az üzemeltetési terheket és gyorsítva az MI bevezetését.

- Teljesen menedzselt MCP szerver hoszting beépített skálázással, monitorozással és biztonsággal  
- Natív integráció az Azure OpenAI-val, Azure AI Search-sel és más Azure szolgáltatásokkal  
- Vállalati hitelesítés és jogosultságkezelés Microsoft Entra ID-n keresztül  
- Egyedi eszközök, prompt sablonok és erőforrás-kapcsolók támogatása  
- Megfelelés vállalati biztonsági és szabályozási követelményeknek  

**Technikai megvalósítás:**  
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

**Eredmények:**  
- Rövidebb idő az érték eléréséhez vállalati MI projektek esetén egy kész, megfelelőségi MCP szerver platformmal  
- Egyszerűbb integráció LLM-ekkel, eszközökkel és vállalati adatforrásokkal  
- Fokozott biztonság, megfigyelhetőség és üzemeltetési hatékonyság MCP terhelések esetén  

**Hivatkozások:**  
- [Azure MCP dokumentáció](https://aka.ms/azmcp)  
- [Azure AI szolgáltatások](https://azure.microsoft.com/en-us/products/ai-services/)

## Esettanulmány 6: NLWeb

Az MCP (Model Context Protocol) egy feljövő protokoll chatbotok és MI asszisztensek eszközökkel való interakciójához. Minden NLWeb példány egyben MCP szerver is, amely egy alapvető metódust, az ask-et támogatja, amellyel természetes nyelven lehet kérdéseket feltenni egy weboldalnak. A visszakapott válasz a schema.org szabványt használja, amely egy széles körben használt webadat-leíró szókincs. Egyszerűen fogalmazva, az MCP az NLWeb-hez hasonló, ahogy az Http a HTML-hez. Az NLWeb ötvözi a protokollokat, a Schema.org formátumokat és mintakódokat, hogy a weboldalak gyorsan létrehozhassák ezeket a végpontokat, előnyöket biztosítva az embereknek beszélgető felületeken keresztül, és gépeknek természetes ügynök-ügynök interakcióval.

Az NLWeb két különálló komponensből áll:  
- Egy egyszerű protokoll, amellyel természetes nyelven lehet interfészt biztosítani egy weboldal számára, és egy formátum, amely json-t és schema.org-ot használ a válaszokhoz. Részletekért lásd a REST API dokumentációt.  
- Egy egyszerű megvalósítás, amely a meglévő jelöléseket használja, olyan oldalak számára, amelyek elemek listájaként (termékek, receptek, látnivalók, értékelések stb.) absztrahálhatók. Egy készlet felhasználói felület widgettel együtt az oldalak könnyen biztosíthatnak beszélgető interfészeket tartalmaikhoz. Részletekért lásd a Life of a chat query dokumentációt.

**Hivatkozások:**  
- [Azure MCP dokumentáció](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Esettanulmány 7: MCP a Foundry számára – Azure AI ügynökök integrálása

Az Azure AI Foundry MCP szerverek bemutatják, hogyan használható az MCP AI ügynökök és munkafolyamatok irányítására és kezelésére vállalati környezetben. Az MCP integrációja az Azure AI Foundry-val lehetővé teszi az ügynökinterakciók szabványosítását, a Foundry munkafolyamat-kezelésének kihasználását, valamint a biztonságos, skálázható telepítést. Ez a megközelítés gyors prototípus-készítést, robosztus monitorozást és zökkenőmentes integrációt tesz lehetővé az Azure AI szolgáltatásokkal, támogatva fejlett forgatókönyveket, mint például tudásmenedzsment és ügynökértékelés. A fejlesztők egységes felületet kapnak az ügynökcsövek építéséhez, telepítéséhez és monitorozásához, míg az IT csapatok javított biztonságot, megfelelést és üzemeltetési hatékonyságot élveznek. A megoldás ideális vállalatok számára, amelyek gyorsítani szeretnék az MI bevezetését és kontrollt kívánnak gyakorolni a komplex ügynökvezérelt folyamatok felett.

**Hivatkozások:**  
- [MCP Foundry GitHub tárhely](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Azure AI ügynökök MCP-vel való integrálása (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Esettanulmány 8: Foundry MCP Playground – Kísérletezés és prototípus-készítés

A Foundry MCP Playground egy azonnal használható környezet MCP szerverekkel és Azure AI Foundry integrációkkal való kísérletezéshez. A fejlesztők gyorsan prototípust készíthetnek, tesztelhetnek és értékelhetnek MI modelleket és ügynökmunkafolyamatokat az Azure AI Foundry Katalógus és Laborok erőforrásaival. A playground egyszerűsíti a beállítást, mintaprojekteket kínál és támogatja az együttműködésen alapuló fejlesztést, megkönnyítve a legjobb gyakorlatok és új forgatókönyvek felfedezését minimális ráfordítással. Különösen hasznos csapatok számára, akik ötleteket szeretnének validálni, kísérleteket megosztani és gyorsan tanulni anélkül, hogy bonyolult infrastruktúrát kellene kiépíteniük. A belépési korlát csökkentésével elősegíti az innovációt és a közösségi hozzájárulásokat az MCP és Azure AI Foundry ökoszisztémában.

**Hivatkozások:**  
- [Foundry MCP Playground GitHub tárhely](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Gyakorlati projektek

### Projekt 1: Több szolgáltatót támogató MCP szerver építése

**Cél:** Olyan MCP szerver létrehozása, amely képes kéréseket több MI modell szolgáltatóhoz irányítani meghatározott kritériumok alapján.

**Követelmények:**  
- Legalább három különböző modell szolgáltató támogatása (pl. OpenAI, Anthropic, helyi modellek)  
- Kérések metaadatai alapján működő irányító mechanizmus  
- Konfigurációs rendszer a szolgáltatói hitelesítő adatok kezelésére  
- Gyorsítótárazás a teljesítmény és költségek optimalizálásához  
- Egyszerű műszerfal a használat nyomon követésére  

**Megvalósítás lépései:**  
1. Alap MCP szerver infrastruktúra felállítása  
2. Szolgáltató adapterek implementálása minden MI modell szolgáltatóhoz  
3. Irányítási logika létrehozása a kérés attribútumai alapján  
4. Gyorsítótárazási mechanizmusok hozzáadása gyakori kérésekhez  
5. Monitorozó műszerfal fejlesztése  
6. Tesztelés különböző kérésmintákkal  

**Technológiák:** Python (.NET/Java/Python a preferenciád szerint), Redis gyorsítótárazáshoz, egyszerű webes keretrendszer a műszerfalhoz.

### Projekt 2: Vállalati promptkezelő rendszer

**Cél:** MCP-alapú rendszer fejlesztése prompt sablonok kezelésére, verziózására és telepítésére szervezeti szinten.

**Követelmények:**  
- Központosított prompt sablon tár létrehozása  
- Verziózás és jóváhagyási munkafolyamatok megvalósítása  
- Sablon tesztelési lehetőségek mintabemenetekkel  
- Szerepalapú hozzáférés-vezérlés  
- API a sablonok lekérésére és telepítésére  

**Megvalósítás lépései:**  
1. Adatbázis séma tervezése sablonok tárolásához  
2. Alap API létrehozása sablon CRUD műveletekhez  
3. Verziózási rendszer megvalósítása  
4. Jóváhagyási munkafolyamat fejlesztése  
5. Tesztelési keretrendszer kiépítése  
6. Egyszerű webes felület készítése a kezeléshez  
7. Integráció MCP szerverrel  

**Technológiák:** Tetszőleges backend keretrendszer, SQL vagy NoSQL adatbázis, frontend keretrendszer a kezelőfelülethez.

### Projekt 3: MCP-alapú tartalomgeneráló platform

**Cél:** Olyan tartalomgeneráló platform építése, amely az MCP-t használva konzisztens eredményeket biztosít különböző tartalomtípusok esetén.

**Követelmények:**  
- Több tartalomformátum támogatása (blogbejegyzések, közösségi média, marketing szöveg)  
- Sablonalapú generálás testreszabási lehetőségekkel  
- Tartalom átnézési és visszacsatolási rendszer  
- Tartalom teljesítménymutatók nyomon követése  
- Tartalom verziózás és iteráció támogatása  

**Megvalósítás lépései:**  
1. MCP kliens infrastruktúra felállítása  
2. Sablonok létrehozása különböző tartalomtípusokhoz  
3. Tartalomgenerálási folyamat kiépítése  
4. Átné
- [Azure MCP Dokumentáció](https://aka.ms/azmcp)
- [Playwright MCP Server GitHub Tároló](https://github.com/microsoft/playwright-mcp)
- [Files MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP Auth Szerverek (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Távoli MCP Funkciók (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Távoli MCP Funkciók Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Távoli MCP Funkciók .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Távoli MCP Funkciók TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Távoli MCP APIM Funkciók Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI és Automatizálási Megoldások](https://azure.microsoft.com/en-us/products/ai-services/)

## Gyakorlatok

1. Elemezzen meg egy esettanulmányt, és javasoljon egy alternatív megvalósítási módot.
2. Válasszon ki egy projektötletet, és készítsen részletes műszaki specifikációt.
3. Kutasson egy olyan iparágat, amely nem szerepel az esettanulmányok között, és vázolja fel, hogyan kezelhetné az MCP az adott iparág specifikus kihívásait.
4. Vizsgáljon meg egy jövőbeli irányt, és alkosson egy koncepciót egy új MCP bővítményhez, amely támogatná azt.

Következő: [Legjobb gyakorlatok](../08-BestPractices/README.md)

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén szakmai emberi fordítást javasolunk. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy téves értelmezésekért.