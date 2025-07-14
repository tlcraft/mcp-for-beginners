<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-07-14T04:37:36+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "hu"
}
-->
# Korai Elfogadók Tapasztalatai

## Áttekintés

Ez a lecke azt vizsgálja, hogyan használták a korai elfogadók a Model Context Protocolt (MCP) valós problémák megoldására és az iparágak innovációjának előmozdítására. Részletes esettanulmányokon és gyakorlati projektek segítségével megismerheted, hogyan teszi lehetővé az MCP a szabványosított, biztonságos és skálázható AI integrációt—összekapcsolva a nagy nyelvi modelleket, eszközöket és vállalati adatokat egy egységes keretrendszerben. Gyakorlati tapasztalatot szerezhetsz MCP-alapú megoldások tervezésében és építésében, tanulhatsz bevált megvalósítási mintákat, és felfedezheted a legjobb gyakorlatokat az MCP éles környezetben történő alkalmazásához. A lecke kiemeli a feltörekvő trendeket, jövőbeli irányokat és nyílt forráskódú erőforrásokat, hogy segítsen naprakész maradni az MCP technológiában és annak folyamatosan fejlődő ökoszisztémájában.

## Tanulási Célok

- Valós MCP megvalósítások elemzése különböző iparágakban  
- Teljes MCP-alapú alkalmazások tervezése és fejlesztése  
- Feltörekvő trendek és jövőbeli irányok felfedezése az MCP technológiában  
- Legjobb gyakorlatok alkalmazása valós fejlesztési helyzetekben  

## Valós MCP Megvalósítások

### Esettanulmány 1: Vállalati Ügyfélszolgálati Automatizálás

Egy multinacionális vállalat MCP-alapú megoldást vezetett be az AI-interakciók szabványosítására az ügyfélszolgálati rendszereikben. Ennek eredményeként:

- Egységes felületet hoztak létre több LLM szolgáltató számára  
- Egységes promptkezelést tartottak fenn a különböző osztályok között  
- Erős biztonsági és megfelelőségi kontrollokat vezettek be  
- Könnyen válthattak különböző AI modellek között az adott igények szerint  

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

**Eredmények:** 30%-os költségcsökkenés a modellek terén, 45%-os javulás a válaszok következetességében, valamint fokozott megfelelőség a globális működés során.

### Esettanulmány 2: Egészségügyi Diagnosztikai Asszisztens

Egy egészségügyi szolgáltató MCP infrastruktúrát fejlesztett ki, hogy több speciális orvosi AI modellt integráljon, miközben biztosította a betegek érzékeny adatainak védelmét:

- Zökkenőmentes váltás általános és szakosodott orvosi modellek között  
- Szigorú adatvédelmi szabályozások és auditálási nyomvonalak  
- Integráció a meglévő Elektronikus Egészségügyi Nyilvántartó (EHR) rendszerekkel  
- Következetes prompttervezés az orvosi terminológia számára  

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

**Eredmények:** Javultak az orvosok számára adott diagnosztikai javaslatok, miközben teljes HIPAA megfelelőség biztosított volt, és jelentősen csökkent a rendszerek közötti kontextusváltás.

### Esettanulmány 3: Pénzügyi Szolgáltatások Kockázatelemzése

Egy pénzügyi intézmény MCP-t vezetett be a kockázatelemzési folyamatok szabványosítására különböző osztályokon:

- Egységes felületet hoztak létre hitelkockázat, csalásfelderítés és befektetési kockázat modellekhez  
- Szigorú hozzáférés-vezérlést és modell verziókezelést valósítottak meg  
- Biztosították az AI ajánlások auditálhatóságát  
- Következetes adatformázást tartottak fenn a különböző rendszerek között  

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

**Eredmények:** Javult a szabályozói megfelelőség, 40%-kal gyorsabb modellbevezetési ciklusok, és egységesebb kockázatértékelés az osztályok között.

### Esettanulmány 4: Microsoft Playwright MCP Szerver Böngészőautomatizáláshoz

A Microsoft kifejlesztette a [Playwright MCP szervert](https://github.com/microsoft/playwright-mcp), amely lehetővé teszi a biztonságos, szabványosított böngészőautomatizálást a Model Context Protocol segítségével. Ez a megoldás lehetővé teszi, hogy AI ügynökök és LLM-ek kontrollált, auditálható és bővíthető módon lépjenek kapcsolatba a webböngészőkkel—például automatizált webes tesztelés, adatkinyerés és end-to-end munkafolyamatok esetén.

- Böngészőautomatizálási funkciókat (navigáció, űrlapkitöltés, képernyőkép készítés stb.) MCP eszközként teszi elérhetővé  
- Szigorú hozzáférés-vezérlést és sandboxolást valósít meg az illetéktelen műveletek megakadályozására  
- Részletes audit naplókat biztosít minden böngészőinterakcióról  
- Támogatja az Azure OpenAI és más LLM szolgáltatók integrációját az ügynökalapú automatizáláshoz  

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
- Biztonságos, programozott böngészőautomatizálás AI ügynökök és LLM-ek számára  
- Csökkentette a manuális tesztelési erőfeszítést és javította a webalkalmazások tesztlefedettségét  
- Újrahasznosítható, bővíthető keretrendszert biztosított böngészőalapú eszközintegrációhoz vállalati környezetben  

**Hivatkozások:**  
- [Playwright MCP Server GitHub tárhely](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI és Automatizálási Megoldások](https://azure.microsoft.com/en-us/products/ai-services/)

### Esettanulmány 5: Azure MCP – Vállalati Szintű Model Context Protocol Szolgáltatásként

Az Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) a Microsoft által kezelt, vállalati szintű Model Context Protocol megvalósítás, amely skálázható, biztonságos és megfelelőségi szempontból megbízható MCP szerver képességeket nyújt felhőszolgáltatásként. Az Azure MCP lehetővé teszi a szervezetek számára, hogy gyorsan telepítsék, kezeljék és integrálják az MCP szervereket az Azure AI, adat- és biztonsági szolgáltatásaival, csökkentve az üzemeltetési terheket és felgyorsítva az AI bevezetését.

- Teljesen kezelt MCP szerver hoszting beépített skálázással, monitorozással és biztonsággal  
- Natív integráció az Azure OpenAI, Azure AI Search és más Azure szolgáltatásokkal  
- Vállalati hitelesítés és jogosultságkezelés Microsoft Entra ID-n keresztül  
- Támogatás egyedi eszközök, prompt sablonok és erőforrás-kapcsolók számára  
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
- Csökkentette az AI projektek értékteremtési idejét egy kész, megfelelőségi szempontból megbízható MCP szerver platform biztosításával  
- Egyszerűsítette a LLM-ek, eszközök és vállalati adatforrások integrációját  
- Javította a biztonságot, megfigyelhetőséget és az MCP munkaterhelések üzemeltetési hatékonyságát  

**Hivatkozások:**  
- [Azure MCP Dokumentáció](https://aka.ms/azmcp)  
- [Azure AI Szolgáltatások](https://azure.microsoft.com/en-us/products/ai-services/)

## Esettanulmány 6: NLWeb  
Az MCP (Model Context Protocol) egy feltörekvő protokoll chatbotok és AI asszisztensek számára, hogy eszközökkel kommunikáljanak. Minden NLWeb példány egyben MCP szerver is, amely egy alapvető metódust támogat, az ask-et, amellyel természetes nyelven lehet kérdéseket feltenni egy weboldalnak. A visszakapott válasz a schema.org-t használja, amely egy széles körben alkalmazott szókészlet a webes adatok leírására. Egyszerűen fogalmazva, az MCP olyan, mint az NLWeb az Http-hoz képest a HTML-ben. Az NLWeb protokollokat, schema.org formátumokat és mintakódokat egyesít, hogy a weboldalak gyorsan létrehozhassák ezeket a végpontokat, előnyöket biztosítva mind az embereknek a beszélgetés-alapú felületeken, mind a gépeknek az ügynök-ügynök közötti természetes interakcióban.

Az NLWeb két különálló összetevőből áll:  
- Egy protokoll, amely nagyon egyszerűen indul, hogy természetes nyelven lehessen kommunikálni egy weboldallal, és egy formátum, amely json-t és schema.org-t használ a válaszhoz. Részletekért lásd a REST API dokumentációt.  
- Egy egyszerű megvalósítás az (1)-re, amely meglévő jelöléseket használ, olyan oldalak számára, amelyek listákra (termékek, receptek, látnivalók, értékelések stb.) absztrahálhatók. Egy sor felhasználói felület widgettel együtt az oldalak könnyen biztosíthatnak beszélgetés-alapú felületeket a tartalmukhoz. Részletekért lásd a Life of a chat query dokumentációt.  

**Hivatkozások:**  
- [Azure MCP Dokumentáció](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Esettanulmány 7: MCP a Foundry-hoz – Azure AI Ügynökök Integrálása

Az Azure AI Foundry MCP szerverek bemutatják, hogyan használható az MCP AI ügynökök és munkafolyamatok irányítására és kezelésére vállalati környezetben. Az MCP integrálásával az Azure AI Foundry-val a szervezetek szabványosíthatják az ügynökök közötti interakciókat, kihasználhatják a Foundry munkafolyamat-kezelését, és biztosíthatják a biztonságos, skálázható telepítéseket. Ez a megközelítés lehetővé teszi a gyors prototípus-készítést, robusztus monitorozást és zökkenőmentes integrációt az Azure AI szolgáltatásokkal, támogatva fejlett forgatókönyveket, mint például a tudásmenedzsment és az ügynökértékelés. A fejlesztők egységes felületet kapnak az ügynök pipeline-ok építéséhez, telepítéséhez és monitorozásához, míg az IT csapatok javított biztonságot, megfelelőséget és üzemeltetési hatékonyságot élveznek. A megoldás ideális azoknak a vállalatoknak, amelyek gyorsítani szeretnék az AI bevezetését és kontrollt kívánnak tartani az összetett, ügynökvezérelt folyamatok felett.

**Hivatkozások:**  
- [MCP Foundry GitHub tárhely](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Azure AI Ügynökök Integrálása MCP-vel (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Esettanulmány 8: Foundry MCP Playground – Kísérletezés és Prototípus-készítés

A Foundry MCP Playground egy kész környezetet kínál az MCP szerverek és az Azure AI Foundry integrációk kipróbálására. A fejlesztők gyorsan prototípust készíthetnek, tesztelhetnek és értékelhetnek AI modelleket és ügynök munkafolyamatokat az Azure AI Foundry Katalógus és Laborok erőforrásaival. A playground leegyszerűsíti a beállítást, mintaprojekteket biztosít, és támogatja az együttműködésen alapuló fejlesztést, megkönnyítve a legjobb gyakorlatok és új forgatókönyvek felfedezését minimális ráfordítással. Különösen hasznos azoknak a csapatoknak, akik ötleteket szeretnének validálni, kísérleteket megosztani és gyorsítani a tanulást bonyolult infrastruktúra nélkül. Az alacsony belépési küszöb elősegíti az innovációt és a közösségi hozzájárulásokat az MCP és az Azure AI Foundry ökoszisztémában.

**Hivatkozások:**  
- [Foundry MCP Playground GitHub tárhely](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Esettanulmány 9: Microsoft Docs MCP Szerver – Tanulás és Képzés  
A Microsoft Docs MCP Szerver megvalósítja a Model Context Protocol szervert, amely valós idejű hozzáférést biztosít AI asszisztensek számára a hivatalos Microsoft dokumentációhoz. Szemantikus keresést végez a Microsoft hivatalos technikai dokumentációjában.

**Hivatkozások:**  
- [Microsoft Learn Docs MCP Szerver](https://github.com/MicrosoftDocs/mcp)

## Gyakorlati Projektek

### Projekt 1: Több Szolgáltatós MCP Szerver Építése

**Cél:** Olyan MCP szerver létrehozása, amely képes a kéréseket több AI modell szolgáltatóhoz irányítani adott feltételek alapján.

**Követelmények:**  
- Legalább három különböző modell szolgáltató támogatása (pl. OpenAI, Anthropic, helyi modellek)  
- Routing mechanizmus megvalósítása a kérés metaadatai alapján  
- Konfigurációs rendszer létrehozása a szolgáltatói hitelesítő adatok kezelésére  
- Gyorsítótárazás a teljesítmény és költségek optimalizálására  
- Egyszerű irányítópult készítése a használat monitorozásához  

**Megvalósítási lépések:**  
1. Alap MCP szerver infrastruktúra felállítása  
2. Szolgáltató adapterek implementálása minden AI modell szolgáltatáshoz  
3. Routing logika megalkotása a kérés attribútumai alapján  
4. Gyorsítótárazási mechanizmusok hozzáadása gyakori kérésekhez  
5. Monitorozó irányítópult fejlesztése  
6. Tesztelés különböző kérésmintákkal  

**Technológiák:** Választható Python (.NET/Java/Python preferencia szerint), Redis gyorsítótárazáshoz, és egyszerű webes keretrendszer az irányítópulthoz.

### Projekt 2: Vállalati Promptkezelő Rendszer

**Cél:** MCP-alapú rendszer fejlesztése prompt sablonok kezelésére, verziózására és telepítésére szervezeten belül.

**Követelmények:**  
- Központosított tároló létrehozása prompt sablonok számára  
- Verziózás és jóváhagyási munkafolyamatok megvalósítása  
- Sablon tesztelési lehetőségek fejlesztése mintabemenetekkel  
- Szerepalapú hozzáférés-vezérlés kialakítása  
- API készítése sablonok lekérésére és telepítésére  

**Megvalósítási lépések:**  
1. Adatbázis séma tervezése a sablonok tárolásához  
2. Alap API létrehozása sablon CRUD műveletekhez  
3. Verziózási rendszer implementálása  
4. Jóváhagyási munkafolyamat fejlesztése  
5. Tesztelési keretrendszer kidolgozása  
6. Egyszerű webes felület készítése a kezeléshez  
7. Integráció MCP szerverrel  

**Technológiák:** Tetszőleges backend keretrendszer, SQL vagy NoSQL adatbázis, frontend keretr
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – Kezdőoldal a Remote MCP Server megvalósításokhoz Azure Functions környezetben, nyelvspecifikus tárolók linkjeivel  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Gyorsindító sablon egyedi távoli MCP szerverek építéséhez és telepítéséhez Azure Functions használatával Python nyelven  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Gyorsindító sablon egyedi távoli MCP szerverek építéséhez és telepítéséhez Azure Functions használatával .NET/C# nyelven  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Gyorsindító sablon egyedi távoli MCP szerverek építéséhez és telepítéséhez Azure Functions használatával TypeScript nyelven  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) – Azure API Management mint AI Gateway távoli MCP szerverekhez Python nyelven  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) – APIM ❤️ AI kísérletek MCP képességekkel, integrálva az Azure OpenAI és AI Foundry szolgáltatásokkal  

Ezek a tárolók különféle megvalósításokat, sablonokat és erőforrásokat kínálnak a Model Context Protocol használatához különböző programozási nyelveken és Azure szolgáltatásokban. Lefedik az alapvető szervermegvalósításoktól kezdve az autentikáción, felhőbe történő telepítésen át az vállalati integrációs forgatókönyvekig terjedő felhasználási eseteket.

#### MCP Erőforrások Könyvtára

A hivatalos Microsoft MCP tárolóban található [MCP Resources könyvtár](https://github.com/microsoft/mcp/tree/main/Resources) egy válogatott gyűjtemény mintapéldákból, prompt sablonokból és eszközdefiníciókból, amelyeket a Model Context Protocol szerverekhez lehet használni. Ez a könyvtár segíti a fejlesztőket abban, hogy gyorsan elinduljanak az MCP-vel, újrahasznosítható építőelemeket és bevált példákat kínálva az alábbi területeken:

- **Prompt Sablonok:** Kész, használatra kész prompt sablonok gyakori AI feladatokhoz és forgatókönyvekhez, amelyeket testre lehet szabni saját MCP szerver megvalósításokhoz.  
- **Eszközdefiníciók:** Példa eszköz sémák és metaadatok az eszközök egységes integrációjához és meghívásához különböző MCP szervereken át.  
- **Erőforrás Minták:** Példa erőforrás definíciók adatforrásokhoz, API-khoz és külső szolgáltatásokhoz való kapcsolódáshoz az MCP keretrendszeren belül.  
- **Referencia Megvalósítások:** Gyakorlati példák, amelyek bemutatják, hogyan lehet strukturálni és rendszerezni az erőforrásokat, promptokat és eszközöket valós MCP projektekben.  

Ezek az erőforrások felgyorsítják a fejlesztést, elősegítik a szabványosítást, és támogatják a bevált gyakorlatok alkalmazását MCP-alapú megoldások építése és telepítése során.

#### MCP Erőforrások Könyvtára
- [MCP Resources (Mintapéldák, Eszközök és Erőforrás Definíciók)](https://github.com/microsoft/mcp/tree/main/Resources)

### Kutatási Lehetőségek

- Hatékony prompt optimalizációs technikák az MCP keretrendszerekben  
- Biztonsági modellek többbérlős MCP telepítésekhez  
- Teljesítmény összehasonlító vizsgálatok különböző MCP megvalósítások között  
- Formális verifikációs módszerek MCP szerverekhez  

## Összefoglalás

A Model Context Protocol (MCP) gyorsan formálja a jövőt a szabványosított, biztonságos és interoperábilis AI integráció terén az iparágakban. A leckében bemutatott esettanulmányok és gyakorlati projektek révén láthattad, hogyan használják az MCP-t az elsőként alkalmazók – köztük a Microsoft és az Azure –, hogy valós problémákat oldjanak meg, felgyorsítsák az AI elterjedését, és biztosítsák a megfelelést, biztonságot és skálázhatóságot. Az MCP moduláris megközelítése lehetővé teszi a szervezetek számára, hogy nagy nyelvi modelleket, eszközöket és vállalati adatokat egy egységes, auditálható keretrendszerben kapcsoljanak össze. Ahogy az MCP tovább fejlődik, a közösséggel való aktív részvétel, az open-source erőforrások felfedezése és a bevált gyakorlatok alkalmazása kulcsfontosságú lesz a robusztus, jövőálló AI megoldások építéséhez.

## További Erőforrások

- [MCP Foundry GitHub Tároló](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)  
- [Azure AI Ügynökök integrálása MCP-vel (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  
- [MCP GitHub Tároló (Microsoft)](https://github.com/microsoft/mcp)  
- [MCP Erőforrások Könyvtára (Mintapéldák, Eszközök és Erőforrás Definíciók)](https://github.com/microsoft/mcp/tree/main/Resources)  
- [MCP Közösség és Dokumentáció](https://modelcontextprotocol.io/introduction)  
- [Azure MCP Dokumentáció](https://aka.ms/azmcp)  
- [Playwright MCP Server GitHub Tároló](https://github.com/microsoft/playwright-mcp)  
- [Files MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)  
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)  
- [MCP Auth Servers (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)  
- [Remote MCP Functions (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)  
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)  
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)  
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)  
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)  
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)  
- [Microsoft AI és Automatizációs Megoldások](https://azure.microsoft.com/en-us/products/ai-services/)

## Gyakorlatok

1. Elemezz meg egy esettanulmányt, és javasolj alternatív megvalósítási megközelítést.  
2. Válassz ki egy projektötletet, és készíts részletes műszaki specifikációt.  
3. Kutass egy iparágat, amely nem szerepel az esettanulmányok között, és vázold fel, hogyan oldhatná meg az MCP az adott iparág specifikus kihívásait.  
4. Fedezz fel egy jövőbeli irányt, és alkoss egy koncepciót egy új MCP kiterjesztéshez, amely támogatja azt.  

Következő: [Bevált Gyakorlatok](../08-BestPractices/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.