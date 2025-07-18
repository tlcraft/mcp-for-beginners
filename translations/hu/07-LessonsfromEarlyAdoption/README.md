<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6755bc4f6d0293ce6c49cfc5efba0d8e",
  "translation_date": "2025-07-18T10:17:54+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "hu"
}
-->
# 🌟 Tanulságok a korai alkalmazóktól

## 🎯 Mit fed le ez a modul

Ez a modul bemutatja, hogyan használják valós szervezetek és fejlesztők a Model Context Protocolt (MCP) valós problémák megoldására és az innováció előmozdítására. Részletes esettanulmányokon és gyakorlati projekteken keresztül fedezheted fel, hogyan teszi lehetővé az MCP a biztonságos, skálázható AI integrációt, amely összekapcsolja a nyelvi modelleket, eszközöket és vállalati adatokat.

### Esettanulmány 5: Azure MCP – Vállalati szintű Model Context Protocol szolgáltatásként

Az Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) a Microsoft által kezelt, vállalati szintű Model Context Protocol megvalósítás, amely skálázható, biztonságos és megfelelőségi szempontból megbízható MCP szerver képességeket nyújt felhőszolgáltatásként. Ez a komplex csomag több speciális MCP szervert tartalmaz különböző Azure szolgáltatásokhoz és forgatókönyvekhez.

> **🎯 Éles környezetre kész eszközök**
> 
> Ez az esettanulmány több éles környezetben használható MCP szervert mutat be! Ismerd meg az Azure MCP szervert és más Azure-ral integrált szervereket a [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#2--azure-mcp-server) dokumentációban.

**Főbb jellemzők:**
- Teljesen kezelt MCP szerver hoszting beépített skálázással, monitorozással és biztonsággal
- Natív integráció az Azure OpenAI, Azure AI Search és más Azure szolgáltatásokkal
- Vállalati hitelesítés és jogosultságkezelés Microsoft Entra ID-n keresztül
- Egyedi eszközök, prompt sablonok és erőforrás csatlakozók támogatása
- Megfelelés vállalati biztonsági és szabályozási követelményeknek
- Több mint 15 speciális Azure szolgáltatás csatlakozó, beleértve adatbázisokat, monitorozást és tárolást

**Az Azure MCP szerver képességei:**
- **Erőforrás-kezelés**: Teljes Azure erőforrás életciklus-kezelés
- **Adatbázis csatlakozók**: Közvetlen hozzáférés az Azure Database for PostgreSQL és SQL Server adatbázisokhoz
- **Azure Monitor**: KQL-alapú naplóelemzés és működési betekintések
- **Hitelesítés**: DefaultAzureCredential és kezelt identitás minták
- **Tárolási szolgáltatások**: Blob Storage, Queue Storage és Table Storage műveletek
- **Konténer szolgáltatások**: Azure Container Apps, Container Instances és AKS kezelése

### 📚 Nézd meg az MCP-t működés közben

Szeretnéd látni, hogyan alkalmazzák ezeket az elveket éles környezetre kész eszközökben? Tekintsd meg a [**10 Microsoft MCP szervert, amelyek forradalmasítják a fejlesztők hatékonyságát**](microsoft-mcp-servers.md), ahol valós Microsoft MCP szervereket mutatunk be, amelyeket ma is használhatsz.

## Áttekintés

Ez a lecke bemutatja, hogyan használták a korai alkalmazók a Model Context Protocolt (MCP) valós kihívások megoldására és az innováció előmozdítására különböző iparágakban. Részletes esettanulmányokon és gyakorlati projekteken keresztül megismerheted, hogyan teszi lehetővé az MCP a szabványosított, biztonságos és skálázható AI integrációt — összekapcsolva a nagy nyelvi modelleket, eszközöket és vállalati adatokat egy egységes keretrendszerben. Gyakorlati tapasztalatot szerezhetsz MCP-alapú megoldások tervezésében és építésében, tanulhatsz bevált megvalósítási mintákat, és megismerheted a legjobb gyakorlatokat az MCP éles környezetben történő bevezetéséhez. A lecke kitér a feltörekvő trendekre, jövőbeli irányokra és nyílt forráskódú erőforrásokra is, hogy segítsen naprakész maradni az MCP technológiában és annak fejlődő ökoszisztémájában.

## Tanulási célok

- Valós MCP megvalósítások elemzése különböző iparágakban
- Teljes MCP-alapú alkalmazások tervezése és fejlesztése
- Feltörekvő trendek és jövőbeli irányok felfedezése az MCP technológiában
- Legjobb gyakorlatok alkalmazása valós fejlesztési helyzetekben

## Valós MCP megvalósítások

### Esettanulmány 1: Vállalati ügyféltámogatás automatizálása

Egy multinacionális vállalat MCP-alapú megoldást vezetett be az AI interakciók szabványosítására ügyféltámogatási rendszereikben. Ennek eredményeként:

- Egységes felületet hoztak létre több LLM szolgáltató számára
- Egységes prompt kezelést tartottak fenn osztályok között
- Erős biztonsági és megfelelőségi kontrollokat vezettek be
- Könnyen váltogattak különböző AI modellek között az igények szerint

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

**Eredmények:** 30%-os költségcsökkenés a modellek esetében, 45%-os javulás a válaszok következetességében, és fokozott megfelelőség a globális működés során.

### Esettanulmány 2: Egészségügyi diagnosztikai asszisztens

Egy egészségügyi szolgáltató MCP infrastruktúrát fejlesztett ki több speciális orvosi AI modell integrálására, miközben biztosította a érzékeny betegadatok védelmét:

- Zökkenőmentes váltás általános és speciális orvosi modellek között
- Szigorú adatvédelmi szabályok és audit nyomvonalak
- Integráció a meglévő Elektronikus Egészségügyi Nyilvántartó (EHR) rendszerekkel
- Következetes prompt tervezés az orvosi terminológia számára

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

**Eredmények:** Javultak az orvosi diagnosztikai javaslatok, miközben teljes HIPAA megfelelőség biztosított volt, és jelentősen csökkent a rendszerek közötti kontextusváltás.

### Esettanulmány 3: Pénzügyi szolgáltatások kockázatelemzése

Egy pénzügyi intézmény MCP-t vezetett be a kockázatelemzési folyamatok szabványosítására különböző osztályokon:

- Egységes felületet hoztak létre hitelkockázat, csalásfelderítés és befektetési kockázat modellekhez
- Szigorú hozzáférés-ellenőrzést és modell verziókezelést valósítottak meg
- Biztosították az AI ajánlások auditálhatóságát
- Következetes adatformázást tartottak fenn különböző rendszerek között

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

**Eredmények:** Javult a szabályozói megfelelőség, 40%-kal gyorsabb modell bevezetési ciklusok, és jobb kockázatértékelési következetesség az osztályok között.

### Esettanulmány 4: Microsoft Playwright MCP szerver böngésző automatizáláshoz

A Microsoft kifejlesztette a [Playwright MCP szervert](https://github.com/microsoft/playwright-mcp), amely lehetővé teszi a biztonságos, szabványosított böngésző automatizálást a Model Context Protocol segítségével. Ez az éles környezetre kész szerver lehetővé teszi, hogy AI ügynökök és LLM-ek kontrollált, auditálható és bővíthető módon lépjenek kapcsolatba web böngészőkkel — támogatva olyan felhasználási eseteket, mint az automatikus webes tesztelés, adatkinyerés és end-to-end munkafolyamatok.

> **🎯 Éles környezetre kész eszköz**
> 
> Ez az esettanulmány egy valós MCP szervert mutat be, amelyet ma is használhatsz! Tudj meg többet a Playwright MCP szerverről és további 9 éles Microsoft MCP szerverről a [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#8--playwright-mcp-server) dokumentációban.

**Főbb jellemzők:**
- Böngésző automatizálási funkciók (navigáció, űrlapkitöltés, képernyőkép készítés stb.) MCP eszközként való elérhetősége
- Szigorú hozzáférés-ellenőrzés és sandboxing az illetéktelen műveletek megakadályozására
- Részletes audit naplók minden böngésző interakcióról
- Integráció támogatása Azure OpenAI és más LLM szolgáltatókkal az ügynökalapú automatizációhoz
- A GitHub Copilot Coding Agent böngészési képességeinek működtetése

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
- Biztonságos, programozott böngésző automatizálás AI ügynökök és LLM-ek számára  
- Csökkentett manuális tesztelési erőfeszítés és javított tesztlefedettség webalkalmazásoknál  
- Újrahasznosítható, bővíthető keretrendszer böngésző alapú eszközintegrációhoz vállalati környezetben  
- A GitHub Copilot böngészési képességeinek támogatása

**Hivatkozások:**  
- [Playwright MCP Server GitHub tárhely](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI és automatizációs megoldások](https://azure.microsoft.com/en-us/products/ai-services/)

### Esettanulmány 5: Azure MCP – Vállalati szintű Model Context Protocol szolgáltatásként

Az Azure MCP szerver ([https://aka.ms/azmcp](https://aka.ms/azmcp)) a Microsoft által kezelt, vállalati szintű Model Context Protocol megvalósítás, amely skálázható, biztonságos és megfelelőségi szempontból megbízható MCP szerver képességeket nyújt felhőszolgáltatásként. Az Azure MCP lehetővé teszi a szervezetek számára, hogy gyorsan telepítsék, kezeljék és integrálják az MCP szervereket az Azure AI, adat- és biztonsági szolgáltatásaival, csökkentve az üzemeltetési terheket és felgyorsítva az AI bevezetését.

> **🎯 Éles környezetre kész eszköz**
> 
> Ez egy valós MCP szerver, amelyet ma is használhatsz! Tudj meg többet az Azure AI Foundry MCP szerverről a [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md) dokumentációban.

- Teljesen kezelt MCP szerver hoszting beépített skálázással, monitorozással és biztonsággal  
- Natív integráció az Azure OpenAI, Azure AI Search és más Azure szolgáltatásokkal  
- Vállalati hitelesítés és jogosultságkezelés Microsoft Entra ID-n keresztül  
- Egyedi eszközök, prompt sablonok és erőforrás csatlakozók támogatása  
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
- Csökkentették az értékteremtésig eltelt időt vállalati AI projektek esetében, kész, megfelelőségi szempontból megbízható MCP szerver platform biztosításával  
- Egyszerűsítették a LLM-ek, eszközök és vállalati adatforrások integrációját  
- Javították az MCP munkaterhelések biztonságát, megfigyelhetőségét és működési hatékonyságát  
- Fejlesztették a kódminőséget az Azure SDK legjobb gyakorlatai és aktuális hitelesítési minták alkalmazásával

**Hivatkozások:**  
- [Azure MCP dokumentáció](https://aka.ms/azmcp)  
- [Azure MCP Server GitHub tárhely](https://github.com/Azure/azure-mcp)  
- [Azure AI szolgáltatások](https://azure.microsoft.com/en-us/products/ai-services/)

### Esettanulmány 6: NLWeb – Természetes nyelvű webes interfész protokoll

Az NLWeb a Microsoft vízióját képviseli az AI Web alaprétegének megteremtésére. Minden NLWeb példány egyben MCP szerver is, amely egyetlen alapvető metódust, az `ask`-et támogatja, amellyel természetes nyelven lehet kérdéseket feltenni egy weboldalnak. A visszakapott válasz a schema.org szabványt használja, amely egy széles körben alkalmazott szókincs a webes adatok leírására. Egyszerűen fogalmazva, az MCP az NLWeb számára olyan, mint az HTTP a HTML-nek.

**Főbb jellemzők:**
- **Protokoll réteg**: Egyszerű protokoll a weboldalakkal való természetes nyelvű kommunikációhoz  
- **Schema.org formátum**: JSON és schema.org használata strukturált, gépileg feldolgozható válaszokhoz  
- **Közösségi megvalósítás**: Egyszerű implementáció olyan oldalak számára, amelyek listákból állnak (termékek, receptek, látnivalók, értékelések stb.)  
- **UI widgetek**: Előre elkészített felhasználói felület komponensek beszélgetős interfészekhez

**Architektúra elemei:**
1. **Protokoll**: Egyszerű REST API természetes nyelvű lekérdezésekhez weboldalakhoz  
2. **Megvalósítás**: Meglévő jelölések és oldalstruktúra felhasználása automatikus válaszokhoz  
3. **UI widgetek**: Kész komponensek beszélgetős interfészek integrálásához

**Előnyök:**
- Ember és oldal, valamint ügynök és ügynök közötti interakció lehetősége  
- Strukturált adatválaszok, amelyeket az AI rendszerek könnyen feldolgozhatnak  
- Gyors telepítés listaalapú tartalomszerkezetű oldalakhoz  
- Szabványos megközelítés a weboldalak AI számára való elérhetővé tételéhez

**Eredmények:**
- Alapot teremtett az AI-web interakciós szabványokhoz  
- Egyszerűsítette a beszélgetős interfészek létrehozását tartalmi oldalak számára  
- Javította a webes tartalom felfedezhetőségét és elérhetőségét AI rendszerek számára  
- Elősegítette az interoperabilitást különböző AI ügynökök és webszolgáltatások között

**Hivatkozások:**  
- [NLWeb GitHub tárhely](https://github.com/microsoft/NlWeb)  
- [NLWeb dokumentáció](https://github.com/microsoft/NlWeb)

### Esettanulmány 7: Azure AI Foundry MCP szerver – Vállalati AI ügynök integráció

Az Azure AI Foundry MCP szerverek bemutatják, hogyan használható az MCP AI ügynökök és munkafolyamatok irányítására és kezelésére vállalati környezetben. Az MCP integrálásával az Azure AI Foundry-val a szervezetek szabványosíthatják az ügynökök közötti interakciókat, kihasználhatják a Foundry munkafolyamat-kezelését, és biztosíthatják a biztonságos, skálázható telepítéseket.

> **🎯 Éles környezetre kész eszköz**
> 
> Ez egy valós MCP szerver, amelyet ma is használhatsz! Tudj meg többet az Azure AI Foundry MCP szerverről a [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#9--azure-ai-foundry-mcp-server) dokumentációban.

**Főbb jellemzők:**
- Átfogó hozzáférés az Azure AI ökoszisztémához, beleértve a modell katalógusokat és telepítéskezelést  
- Tudásindexelés Azure
> **🎯 Éles Használatra Kész Eszköz**
> 
> Ez egy valódi MCP szerver, amit ma már használhatsz! Tudj meg többet a Microsoft Learn Docs MCP Serverről a [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#1--microsoft-learn-docs-mcp-server) oldalon.
**Főbb jellemzők:**
- Valós idejű hozzáférés a hivatalos Microsoft dokumentációhoz, Azure dokumentumokhoz és Microsoft 365 dokumentációhoz
- Fejlett szemantikus keresési képességek, amelyek értik a kontextust és a szándékot
- Mindig naprakész információk, mivel a Microsoft Learn tartalmak folyamatosan frissülnek
- Átfogó lefedettség a Microsoft Learn, Azure dokumentáció és Microsoft 365 források között
- Legfeljebb 10 magas minőségű tartalmi egységet ad vissza cikkcímekkel és URL-ekkel

**Miért kritikus:**
- Megoldja a „elavult AI tudás” problémát a Microsoft technológiák esetében
- Biztosítja, hogy az AI asszisztensek hozzáférjenek a legfrissebb .NET, C#, Azure és Microsoft 365 funkciókhoz
- Hiteles, első kézből származó információkat nyújt a pontos kódgeneráláshoz
- Elengedhetetlen a gyorsan fejlődő Microsoft technológiákkal dolgozó fejlesztők számára

**Eredmények:**
- Drámaian javult az AI által generált kód pontossága Microsoft technológiák esetén
- Csökkent a dokumentáció és legjobb gyakorlatok keresésére fordított idő
- Növelte a fejlesztők termelékenységét a kontextusérzékeny dokumentáció lekéréssel
- Zökkenőmentes integráció a fejlesztési munkafolyamatokba anélkül, hogy el kellene hagyni az IDE-t

**Hivatkozások:**
- [Microsoft Learn Docs MCP Server GitHub Repository](https://github.com/MicrosoftDocs/mcp)
- [Microsoft Learn Documentation](https://learn.microsoft.com/)

## Gyakorlati projektek

### 1. projekt: Több szolgáltatós MCP szerver építése

**Cél:** Olyan MCP szerver létrehozása, amely képes kéréseket több AI modell szolgáltatóhoz irányítani meghatározott feltételek alapján.

**Követelmények:**
- Legalább három különböző modell szolgáltató támogatása (pl. OpenAI, Anthropic, helyi modellek)
- Kérések metaadatai alapján működő irányítási mechanizmus megvalósítása
- Konfigurációs rendszer létrehozása a szolgáltatói hitelesítő adatok kezelésére
- Gyorsítótárazás hozzáadása a teljesítmény és költségek optimalizálásához
- Egyszerű irányítópult építése a használat figyelésére

**Megvalósítás lépései:**
1. Alap MCP szerver infrastruktúra beállítása
2. Szolgáltató adapterek implementálása minden AI modell szolgáltatáshoz
3. Irányítási logika létrehozása a kérés attribútumai alapján
4. Gyorsítótárazási mechanizmusok hozzáadása gyakori kérésekhez
5. Figyelő irányítópult fejlesztése
6. Tesztelés különböző kérésmintákkal

**Technológiák:** Választható Python (.NET/Java/Python preferencia szerint), Redis gyorsítótárazáshoz, és egyszerű webes keretrendszer az irányítópulthoz.

### 2. projekt: Vállalati prompt kezelő rendszer

**Cél:** MCP alapú rendszer fejlesztése prompt sablonok kezelésére, verziózására és telepítésére szervezeten belül.

**Követelmények:**
- Központosított tároló létrehozása prompt sablonok számára
- Verziózás és jóváhagyási munkafolyamatok megvalósítása
- Sablontesztelési lehetőségek fejlesztése mintabemenetekkel
- Szerepalapú hozzáférés-vezérlés kialakítása
- API létrehozása sablonok lekérésére és telepítésére

**Megvalósítás lépései:**
1. Adatbázis séma tervezése a sablonok tárolásához
2. Alap API létrehozása sablon CRUD műveletekhez
3. Verziózási rendszer implementálása
4. Jóváhagyási munkafolyamat kiépítése
5. Tesztelési keretrendszer fejlesztése
6. Egyszerű webes felület készítése a kezeléshez
7. Integráció MCP szerverrel

**Technológiák:** Tetszőleges backend keretrendszer, SQL vagy NoSQL adatbázis, frontend keretrendszer a kezelőfelülethez.

### 3. projekt: MCP alapú tartalomgeneráló platform

**Cél:** Olyan tartalomgeneráló platform építése, amely az MCP-t használva egységes eredményeket biztosít különböző tartalomtípusok esetén.

**Követelmények:**
- Több tartalomformátum támogatása (blogbejegyzések, közösségi média, marketing szövegek)
- Sablonalapú generálás testreszabási lehetőségekkel
- Tartalom átnézési és visszajelzési rendszer létrehozása
- Tartalom teljesítménymutatók követése
- Tartalom verziózás és iteráció támogatása

**Megvalósítás lépései:**
1. MCP kliens infrastruktúra beállítása
2. Sablonok létrehozása különböző tartalomtípusokhoz
3. Tartalomgenerálási folyamat kiépítése
4. Átnézési rendszer implementálása
5. Teljesítménymutatók követési rendszerének fejlesztése
6. Felhasználói felület készítése sablonkezeléshez és tartalomgeneráláshoz

**Technológiák:** Kedvenc programozási nyelv, webes keretrendszer és adatbázis rendszer.

## MCP technológia jövőbeli irányai

### Felmerülő trendek

1. **Multi-Modal MCP**
   - MCP kiterjesztése képi, hang- és videómodellek szabványos interakcióira
   - Keresztmodalitású érvelési képességek fejlesztése
   - Szabványosított prompt formátumok különböző modalitásokhoz

2. **Federált MCP infrastruktúra**
   - Elosztott MCP hálózatok, amelyek erőforrásokat oszthatnak meg szervezetek között
   - Szabványosított protokollok biztonságos modellmegosztáshoz
   - Adatvédelmet biztosító számítási technikák

3. **MCP piacterek**
   - Ökoszisztémák MCP sablonok és bővítmények megosztására és monetizálására
   - Minőségbiztosítási és tanúsítási folyamatok
   - Integráció modell piacterekkel

4. **MCP az Edge Computing számára**
   - MCP szabványok adaptálása erőforrás-korlátozott edge eszközökre
   - Optimalizált protokollok alacsony sávszélességű környezetekhez
   - Speciális MCP megvalósítások IoT ökoszisztémákhoz

5. **Szabályozási keretrendszerek**
   - MCP kiterjesztések fejlesztése szabályozási megfeleléshez
   - Szabványosított audit nyomvonalak és magyarázhatósági felületek
   - Integráció a fejlődő AI irányítási keretrendszerekkel

### Microsoft MCP megoldások

A Microsoft és az Azure több nyílt forráskódú tárolót fejlesztett, hogy segítsék a fejlesztőket az MCP különböző helyzetekben történő megvalósításában:

#### Microsoft szervezet
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – Playwright MCP szerver böngésző automatizáláshoz és teszteléshez
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – OneDrive MCP szerver megvalósítás helyi teszteléshez és közösségi hozzájáruláshoz
3. [NLWeb](https://github.com/microsoft/NlWeb) – Nyílt protokollok és eszközök gyűjteménye, amely az AI Web alaprétegének megteremtésére fókuszál

#### Azure-Samples szervezet
1. [mcp](https://github.com/Azure-Samples/mcp) – Minták, eszközök és források MCP szerverek építéséhez és integrálásához Azure-on több nyelven
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) – Referencia MCP szerverek hitelesítéssel a jelenlegi Model Context Protocol specifikáció alapján
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – Kezdőlap távoli MCP szerver megvalósításokhoz Azure Functions-ben, nyelvspecifikus tárolókkal
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Gyorsindító sablon egyedi távoli MCP szerverek építéséhez és telepítéséhez Azure Functions Python használatával
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Gyorsindító sablon egyedi távoli MCP szerverek építéséhez és telepítéséhez Azure Functions .NET/C# használatával
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Gyorsindító sablon egyedi távoli MCP szerverek építéséhez és telepítéséhez Azure Functions TypeScript használatával
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) – Azure API Management mint AI átjáró távoli MCP szerverekhez Python használatával
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) – APIM ❤️ AI kísérletek MCP képességekkel, integrálva Azure OpenAI és AI Foundry-val

Ezek a tárolók különféle megvalósításokat, sablonokat és forrásokat kínálnak a Model Context Protocol használatához különböző programozási nyelveken és Azure szolgáltatásokkal. Lefedik az alap szerver megvalósításoktól kezdve a hitelesítésen, felhőbe telepítésen át a vállalati integrációs forgatókönyveket.

#### MCP erőforrás könyvtár

A hivatalos Microsoft MCP tárolóban található [MCP Resources könyvtár](https://github.com/microsoft/mcp/tree/main/Resources) válogatott mintaforrásokat, prompt sablonokat és eszközdefiníciókat tartalmaz az MCP szerverekhez. Ez a könyvtár segíti a fejlesztőket, hogy gyorsan elinduljanak MCP-vel, újrahasznosítható építőelemekkel és bevált példákkal:

- **Prompt sablonok:** Kész, használatra kész prompt sablonok gyakori AI feladatokhoz és helyzetekhez, amelyeket testre szabhat saját MCP szerver megvalósításához.
- **Eszközdefiníciók:** Példa eszköz sémák és metaadatok az eszköz integráció és hívás szabványosításához különböző MCP szerverek között.
- **Erőforrás minták:** Példa erőforrás definíciók adatforrásokhoz, API-khoz és külső szolgáltatásokhoz való kapcsolódáshoz az MCP keretrendszerben.
- **Referencia megvalósítások:** Gyakorlati minták, amelyek bemutatják, hogyan kell strukturálni és rendszerezni az erőforrásokat, promptokat és eszközöket valós MCP projektekben.

Ezek az erőforrások felgyorsítják a fejlesztést, elősegítik a szabványosítást, és támogatják a legjobb gyakorlatok alkalmazását MCP alapú megoldások építésekor és telepítésekor.

#### MCP erőforrás könyvtár
- [MCP Resources (mintapromptok, eszközök és erőforrás definíciók)](https://github.com/microsoft/mcp/tree/main/Resources)

### Kutatási lehetőségek

- Hatékony prompt optimalizálási technikák MCP keretrendszerekben
- Biztonsági modellek többbérlős MCP telepítésekhez
- Teljesítmény összehasonlító vizsgálatok különböző MCP megvalósítások között
- Formális verifikációs módszerek MCP szerverekhez

## Összefoglalás

A Model Context Protocol (MCP) gyorsan formálja a szabványosított, biztonságos és interoperábilis AI integráció jövőjét az iparágakban. A leckében bemutatott esettanulmányok és gyakorlati projektek révén láthattad, hogyan használják az elsőként alkalmazók – köztük a Microsoft és az Azure – az MCP-t valós kihívások megoldására, az AI elfogadásának felgyorsítására, valamint a megfelelőség, biztonság és skálázhatóság biztosítására. Az MCP moduláris megközelítése lehetővé teszi a szervezetek számára, hogy nagy nyelvi modelleket, eszközöket és vállalati adatokat egy egységes, auditálható keretrendszerben kapcsoljanak össze. Ahogy az MCP tovább fejlődik, a közösséggel való aktív részvétel, a nyílt forráskódú erőforrások felfedezése és a bevált gyakorlatok alkalmazása kulcsfontosságú lesz a robusztus, jövőálló AI megoldások építéséhez.

## További források

- [MCP Foundry GitHub tároló](https://github.com/azure-ai-foundry/mcp-foundry)
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)
- [Azure AI ügynökök integrálása MCP-vel (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)
- [MCP GitHub tároló (Microsoft)](https://github.com/microsoft/mcp)
- [MCP erőforrás könyvtár (mintapromptok, eszközök és erőforrás definíciók)](https://github.com/microsoft/mcp/tree/main/Resources)
- [MCP közösség és dokumentáció](https://modelcontextprotocol.io/introduction)
- [Azure MCP dokumentáció](https://aka.ms/azmcp)
- [Playwright MCP szerver GitHub tároló](https://github.com/microsoft/playwright-mcp)
- [Files MCP szerver (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP Auth szerverek (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Remote MCP Functions (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI és automatizálási megoldások](https://azure.microsoft.com/en-us/products/ai-services/)

## Gyakorlatok

1. Elemezz egy esettanulmányt, és javasolj alternatív megvalósítási megközelítést.
2. Válassz egy projektötletet, és készíts részletes műszaki specifikációt.
3. Kutass egy iparágat, amely nem szerepel az esettanulmányok között, és vázold fel, hogyan oldhatná meg az MCP az adott iparág specifikus kihívásait.
4. Fedezz fel egy jövőbeli irányt, és alkoss egy koncepciót egy új MCP kiterjesztéshez, amely támogatja azt.

Következő: [Microsoft MCP Server](../07-LessonsfromEarlyAdoption/microsoft-mcp-servers.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.