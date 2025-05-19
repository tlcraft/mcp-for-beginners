<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "344a126b620ff7997158542fd31be6a4",
  "translation_date": "2025-05-19T22:09:17+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "fi"
}
-->
# Lessons from Early Adoprters

## Yleiskatsaus

Tässä oppitunnissa tutkitaan, miten varhaiset käyttäjät ovat hyödyntäneet Model Context Protocolia (MCP) ratkaistakseen käytännön haasteita ja edistääkseen innovaatioita eri toimialoilla. Yksityiskohtaisten tapaustutkimusten ja käytännön projektien kautta näet, miten MCP mahdollistaa standardoidun, turvallisen ja skaalautuvan tekoälyn integroinnin — yhdistäen suuria kielimalleja, työkaluja ja yritysten dataa yhtenäiseen kehykseen. Saat käytännön kokemusta MCP-pohjaisten ratkaisujen suunnittelusta ja rakentamisesta, opit todetuista toteutusmalleista ja löydät parhaat käytännöt MCP:n käyttöönottoon tuotantoympäristöissä. Oppitunti myös korostaa nousevia trendejä, tulevia suuntauksia ja avoimen lähdekoodin resursseja, jotka auttavat pysymään MCP-teknologian ja sen kehittyvän ekosysteemin kärjessä.

## Oppimistavoitteet

- Analysoida todellisia MCP-toteutuksia eri toimialoilla  
- Suunnitella ja rakentaa kokonaisia MCP-pohjaisia sovelluksia  
- Tutkia nousevia trendejä ja tulevia suuntia MCP-teknologiassa  
- Soveltaa parhaita käytäntöjä todellisissa kehitystilanteissa  

## Todelliset MCP-toteutukset

### Tapaustutkimus 1: Yrityksen asiakastuen automaatio

Monikansallinen yritys toteutti MCP-pohjaisen ratkaisun standardoidakseen tekoälyvuorovaikutukset asiakastukijärjestelmissään. Tämä mahdollisti heille:

- Yhdenmukaisen käyttöliittymän useille LLM-palveluntarjoajille  
- Johdonmukaisen kehotteiden hallinnan osastojen välillä  
- Vahvat turvallisuus- ja vaatimustenmukaisuuden valvontamekanismit  
- Helpon siirtymisen eri tekoälymallien välillä tarpeiden mukaan  

**Tekninen toteutus:**  
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

**Tulokset:** 30 % säästö mallikustannuksissa, 45 % parannus vastausten johdonmukaisuudessa ja parannettu vaatimustenmukaisuus globaalissa toiminnassa.

### Tapaustutkimus 2: Terveydenhuollon diagnostiikka-avustaja

Terveydenhuollon palveluntarjoaja kehitti MCP-infrastruktuurin integroidakseen useita erikoistuneita lääketieteellisiä tekoälymalleja varmistaen samalla potilastietojen tiukan suojan:

- Saumaton vaihto yleis- ja erikoismallien välillä  
- Tiukat tietosuoja- ja auditointijäljet  
- Integraatio olemassa oleviin sähköisiin potilastietojärjestelmiin (EHR)  
- Johdonmukainen kehotteiden suunnittelu lääketieteelliseen terminologiaan  

**Tekninen toteutus:**  
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

**Tulokset:** Parannetut diagnostiikkasuositukset lääkäreille, täydellinen HIPAA-vaatimusten noudattaminen ja merkittävä kontekstinvaihdon vähennys järjestelmien välillä.

### Tapaustutkimus 3: Rahoituspalveluiden riskianalyysi

Rahoituslaitos otti MCP:n käyttöön standardoidakseen riskianalyysiprosessinsa eri osastojen välillä:

- Yhdenmukainen käyttöliittymä luottoriskille, petostunnistukselle ja sijoitusriskimalleille  
- Tiukat käyttöoikeusvalvonnat ja malliversioiden hallinta  
- Kaikkien tekoälysuositusten auditointimahdollisuus  
- Johdonmukainen tietojen muotoilu eri järjestelmissä  

**Tekninen toteutus:**  
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

**Tulokset:** Parannettu sääntelyvaatimusten noudattaminen, 40 % nopeammat mallien käyttöönottoajat ja parempi riskinarvioinnin johdonmukaisuus osastojen välillä.

### Tapaustutkimus 4: Microsoft Playwright MCP Server selainautomaatiolle

Microsoft kehitti [Playwright MCP serverin](https://github.com/microsoft/playwright-mcp) mahdollistamaan turvallisen ja standardoidun selainautomaation Model Context Protocolin avulla. Tämä ratkaisu sallii tekoälyagenttien ja LLM:ien vuorovaikutuksen verkkoselaimien kanssa hallitusti, auditoitavasti ja laajennettavasti — mahdollistaen käyttötapauksia kuten automatisoitu web-testaus, datan keruu ja kokonaisvaltaiset työnkulut.

- Tarjoaa selainautomaation toiminnot (navigointi, lomakkeiden täyttö, kuvakaappausten ottaminen jne.) MCP-työkaluina  
- Toteuttaa tiukat käyttöoikeudet ja hiekkalaatikkoympäristön luvattomien toimien estämiseksi  
- Tarjoaa yksityiskohtaiset auditointilokit kaikista selainvuorovaikutuksista  
- Tukee integraatiota Azure OpenAI:n ja muiden LLM-palveluntarjoajien kanssa agenttiohjatulle automaatiolle  

**Tekninen toteutus:**  
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

**Tulokset:**  
- Mahdollisti turvallisen, ohjelmallisen selainautomaation tekoälyagenteille ja LLM:ille  
- Vähensi manuaalisen testauksen tarvetta ja paransi testikattavuutta web-sovelluksissa  
- Tarjosi uudelleenkäytettävän ja laajennettavan kehyksen selainpohjaisten työkalujen integrointiin yritysympäristöissä  

**Viitteet:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Tapaustutkimus 5: Azure MCP – Yritystason Model Context Protocol palveluna

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) on Microsoftin hallinnoima, yritystason toteutus Model Context Protocolista, suunniteltu tarjoamaan skaalautuvat, turvalliset ja vaatimustenmukaiset MCP-palvelinominaisuudet pilvipalveluna. Azure MCP mahdollistaa organisaatioiden nopean MCP-palvelimien käyttöönoton, hallinnan ja integroinnin Azure AI:n, datan ja turvallisuuspalveluiden kanssa, vähentäen operatiivista taakkaa ja nopeuttaen tekoälyn käyttöönottoa.

- Täysin hallinnoitu MCP-palvelin isännöinti sisäänrakennetulla skaalauksella, valvonnalla ja turvallisuudella  
- Luonnollinen integraatio Azure OpenAI:n, Azure AI Searchin ja muiden Azuren palveluiden kanssa  
- Yritystason tunnistus ja valtuutus Microsoft Entra ID:n kautta  
- Tuki mukautetuille työkaluilla, kehotepohjille ja resurssiliittimille  
- Vaatimustenmukaisuus yrityksen turvallisuus- ja sääntelyvaatimusten kanssa  

**Tekninen toteutus:**  
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

**Tulokset:**  
- Lyhensi yritysten tekoälyprojektien aika-arvoa tarjoamalla valmiin, vaatimustenmukaisen MCP-palvelinalustan  
- Yksinkertaisti LLM:ien, työkalujen ja yritysdatan lähteiden integrointia  
- Paransi turvallisuutta, näkyvyyttä ja operatiivista tehokkuutta MCP-kuormituksissa  

**Viitteet:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Tapaustutkimus 6: NLWeb

MCP (Model Context Protocol) on nouseva protokolla chatbotien ja tekoälyavustajien työkalujen kanssa kommunikointiin. Jokainen NLWeb-instanssi on myös MCP-palvelin, joka tukee yhtä ydintoimintoa, ask, jota käytetään esittämään verkkosivustolle luonnollisella kielellä kysymyksiä. Vastauksessa hyödynnetään schema.orgia, laajasti käytettyä sanastoa web-datan kuvaamiseen. Vapaasti sanottuna MCP on NLWebin suhde HTTP:hen HTML:n maailmassa. NLWeb yhdistää protokollat, schema.org-muodot ja esimerkkikoodin auttaakseen sivustoja luomaan nopeasti tällaisia päätepisteitä, hyödyttäen sekä ihmisiä keskustelupohjaisten käyttöliittymien kautta että koneita luonnollisessa agenttien välisessä vuorovaikutuksessa.

NLWeb koostuu kahdesta erillisestä osasta:  
- Protokolla, joka on aluksi hyvin yksinkertainen, mahdollistaa luonnollisen kielen käytön sivuston kanssa ja vastauksen formaatti hyödyntää jsonia ja schema.orgia. Katso REST API -dokumentaatiosta lisätietoja.  
- Yksinkertainen toteutus (1), joka hyödyntää olemassa olevaa merkintää sivustoille, jotka voidaan esittää kohdelistana (tuotteet, reseptit, nähtävyydet, arvostelut jne.). Yhdistettynä käyttöliittymä-widgetteihin, sivustot voivat helposti tarjota keskustelupohjaisia käyttöliittymiä sisältöönsä. Katso dokumentaatiosta Life of a chat query saadaksesi lisätietoja toiminnasta.  

**Viitteet:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

## Käytännön projektit

### Projekti 1: Monitoimittajainen MCP-palvelin

**Tavoite:** Luo MCP-palvelin, joka osaa ohjata pyynnöt useille tekoälymallien tarjoajille määriteltyjen kriteerien perusteella.

**Vaatimukset:**  
- Tue vähintään kolmea eri mallipalveluntarjoajaa (esim. OpenAI, Anthropic, paikalliset mallit)  
- Toteuta reititysmekanismi pyynnön metatietojen perusteella  
- Luo konfiguraatiojärjestelmä tarjoajien tunnistetietojen hallintaan  
- Lisää välimuisti suorituskyvyn ja kustannusten optimointiin  
- Rakenna yksinkertainen hallintapaneeli käytön seurantaan  

**Toteutusvaiheet:**  
1. Perusta MCP-palvelimen perusinfrastruktuuri  
2. Toteuta tarjoajien adapterit jokaiselle tekoälymallipalvelulle  
3. Luo reitityslogiikka pyyntöjen ominaisuuksien pohjalta  
4. Lisää välimuistimekanismit usein toistuville pyynnöille  
5. Kehitä seurantapaneeli  
6. Testaa erilaisilla pyyntökuvioilla  

**Teknologiat:** Valitse Python (.NET/Java/Python mieltymyksesi mukaan), Redis välimuistiksi ja yksinkertainen web-kehys hallintapaneelille.

### Projekti 2: Yrityksen kehotteiden hallintajärjestelmä

**Tavoite:** Kehitä MCP-pohjainen järjestelmä kehotepohjien hallintaan, versiointiin ja käyttöönottoon organisaation sisällä.

**Vaatimukset:**  
- Luo keskitetty varasto kehotepohjille  
- Toteuta versiointi ja hyväksymisprosessit  
- Rakenna testausominaisuudet pohjien kokeilemiseen esimerkkisyötteillä  
- Kehitä roolipohjaiset käyttöoikeudet  
- Luo API pohjien hakua ja käyttöönottoa varten  

**Toteutusvaiheet:**  
1. Suunnittele tietokantakaavio pohjatietojen tallennukseen  
2. Luo ydintoiminnot pohjien CRUD-operaatioille  
3. Toteuta versiointijärjestelmä  
4. Rakenna hyväksymisprosessi  
5. Kehitä testauskehys  
6. Luo yksinkertainen web-käyttöliittymä hallintaan  
7. Integroi MCP-palvelimen kanssa  

**Teknologiat:** Valitse haluamasi backend-kehys, SQL- tai NoSQL-tietokanta ja frontend-kehys hallintakäyttöliittymälle.

### Projekti 3: MCP-pohjainen sisällöntuotantoalusta

**Tavoite:** Rakenna sisällöntuotantoalusta, joka hyödyntää MCP:tä tarjotakseen johdonmukaisia tuloksia eri sisältötyypeille.

**Vaatimukset:**  
- Tue useita sisältöformaatteja (blogikirjoitukset, sosiaalinen media, markkinointitekstit)  
- Toteuta mallipohjainen generointi mukautusmahdollisuuksilla  
- Luo sisältöjen tarkastus- ja palautteenantojärjestelmä  
- Seuraa sisällön suorituskykymittareita  
- Tue sisällön versiointia ja iterointia  

**Toteutusvaiheet:**  
1. Perusta MCP-asiakasinfrastruktuuri  
2. Luo mallipohjat eri sisältötyypeille  
3. Rakenna sisällöntuotantoputki  
4. Toteuta tarkastusjärjestelmä  
5. Kehitä suorituskykymittareiden seuranta  
6. Luo käyttöliittymä mallien hallintaan ja sisällöntuotantoon  

**Teknologiat:** Valitse oma suosikkiohjelmointikielesi, web-kehys ja tietokanta.

## MCP-teknologian tulevaisuuden suuntaukset

### Nousevat trendit

1. **Monimodaalinen MCP**  
   - MCP:n laajentaminen standardoimaan vuorovaikutuksia kuvan, äänen ja videon mallien kanssa  
   - Ristimodaalisten päättelykykyjen kehittäminen  
   - Standardoidut kehotemuodot eri modaliteeteille  

2. **Federatiivinen MCP-infrastruktuuri**  
   - Hajautetut MCP-verkostot, jotka jakavat resursseja organisaatioiden välillä  
   - Standardoidut protokollat turvalliseen mallien jakamiseen  
   - Tietosuojaa parantavat laskentamenetelmät  

3. **MCP-markkinapaikat**  
   - Ekosysteemit MCP-pohjaisten mallipohjien ja lisäosien jakamiseen ja kaupallistamiseen  
   - Laadunvarmistus- ja sertifiointiprosessit  
   - Integraatio mallimarkkinapaikkoihin  

4. **MCP reunalaskennassa**  
   - MCP-standardien sovittaminen resurssirajoitteisille reunalaitteille  
   - Optimoidut protokollat matalan kaistanleveyden ympäristöihin  
   - Erikoistuneet MCP-toteutukset IoT-ekosysteemeille  

5. **Sääntelykehykset**  
   - MCP-laajennusten kehittäminen sääntelyvaatimusten täyttämiseksi  
   - Standardoidut auditointijäljet ja selitettävyyden rajapinnat  
   - Integraatio nouseviin tekoälyn hallintakehyksiin  

### Microsoftin MCP-ratkaisut

Microsoft ja Azure ovat kehittäneet useita avoimen lähdekoodin arkistoja auttaakseen kehittäjiä MCP:n toteutuksessa eri tilanteissa:

#### Microsoft Organization  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – Playwright MCP -palvelin selainautomaatiota ja testausta varten  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – OneDrive MCP -palvelin paikalliseen testaukseen ja yhteisön kontribuutioihin  
3. [NLWeb](https://github.com/microsoft/NlWeb) – Kokoelma avoimia protokollia ja työkaluja, keskittyen AI Webin perustan luomiseen  

#### Azure-Samples Organization  
1. [mcp](https://github.com/Azure-Samples/mcp) – Esimerkit, työkalut ja resurssit MCP-palvelimien rakentamiseen ja integrointiin Azurella eri kielillä  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) – Referenssipohjaiset MCP-palvelimet autentikointia varten nykyisen MCP-spesifikaation mukaisesti  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – Alkusivu etä-MCP-palvelintoteutuksille Azure Functions -ympäristössä kielikohtaisilla linkeillä  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Pikakäynnistysmalli omien etä-MCP-palvelimien rakentamiseen ja käyttöönottoon Pythonilla Azure Functionsissa  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Pikakäynnistysmalli .NET/C#-pohjaisten etä-MCP-palvelimien rakentamiseen ja käyttöönottoon Azure Functionsissa  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Pikakäynnistysmalli TypeScriptillä rakennettaville etä-MCP-palvelimille Azure Functionsissa  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) – Azure API Management tekoälysiltana etä-MCP-palvelimille Pythonilla  
8
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Harjoitukset

1. Analysoi yksi tapaustutkimuksista ja ehdota vaihtoehtoinen toteutustapa.
2. Valitse yksi projektiehdotuksista ja laadi yksityiskohtainen tekninen erittely.
3. Tutki toimiala, jota tapaustutkimukset eivät kata, ja hahmottele, miten MCP voisi ratkaista sen erityishaasteet.
4. Tutki yhtä tulevaisuuden suuntausta ja luo konsepti uudelle MCP-laajennukselle sen tukemiseksi.

Seuraava: [Best Practices](../08-BestPractices/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttäen tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäisellä kielellä tulee pitää auktoritatiivisena lähteenä. Tärkeiden tietojen osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.