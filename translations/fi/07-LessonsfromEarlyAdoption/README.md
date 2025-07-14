<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-07-14T04:31:21+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "fi"
}
-->
# Varhaisten käyttäjien opit

## Yleiskatsaus

Tässä oppitunnissa tarkastellaan, miten varhaiset käyttäjät ovat hyödyntäneet Model Context Protocolia (MCP) ratkaistakseen käytännön haasteita ja edistääkseen innovaatioita eri toimialoilla. Yksityiskohtaisten tapaustutkimusten ja käytännön projektien kautta näet, miten MCP mahdollistaa standardoidun, turvallisen ja skaalautuvan tekoälyn integroinnin — yhdistäen suuria kielimalleja, työkaluja ja yritystietoja yhtenäiseen kehykseen. Saat käytännön kokemusta MCP-pohjaisten ratkaisujen suunnittelusta ja rakentamisesta, opit todetuista toteutusmalleista ja löydät parhaat käytännöt MCP:n käyttöönottoon tuotantoympäristöissä. Oppitunti korostaa myös nousevia trendejä, tulevia suuntauksia ja avoimen lähdekoodin resursseja, jotka auttavat sinua pysymään MCP-teknologian ja sen kehittyvän ekosysteemin kärjessä.

## Oppimistavoitteet

- Analysoida käytännön MCP-toteutuksia eri toimialoilla  
- Suunnitella ja rakentaa kokonaisia MCP-pohjaisia sovelluksia  
- Tutkia MCP-teknologian nousevia trendejä ja tulevia suuntauksia  
- Soveltaa parhaita käytäntöjä todellisissa kehitystilanteissa  

## Käytännön MCP-toteutukset

### Tapaustutkimus 1: Yrityksen asiakastuen automaatio

Monikansallinen yritys otti käyttöön MCP-pohjaisen ratkaisun standardoidakseen tekoälyvuorovaikutukset asiakastukijärjestelmissään. Tämä mahdollisti heille:

- Yhdenmukaisen käyttöliittymän useille LLM-palveluntarjoajille  
- Johdonmukaisen kehotteiden hallinnan eri osastojen välillä  
- Vahvat turvallisuus- ja vaatimustenmukaisuuden valvontamekanismit  
- Helpon siirtymisen eri tekoälymallien välillä tarpeen mukaan  

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

**Tulokset:** Mallikustannusten 30 %:n vähennys, vastausten johdonmukaisuuden 45 %:n parannus ja parannettu vaatimustenmukaisuus globaalissa toiminnassa.

### Tapaustutkimus 2: Terveydenhuollon diagnostiikka-avustaja

Terveydenhuollon palveluntarjoaja kehitti MCP-infrastruktuurin integroidakseen useita erikoistuneita lääketieteellisiä tekoälymalleja varmistaen samalla potilastietojen suojan:

- Saumaton vaihto yleis- ja erikoismallien välillä  
- Tiukat tietosuojakontrollit ja auditointijäljet  
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

**Tulokset:** Parantuneet diagnoosiehdotukset lääkäreille, täysi HIPAA-vaatimustenmukaisuus ja merkittävä kontekstinvaihtojen väheneminen järjestelmien välillä.

### Tapaustutkimus 3: Rahoituspalveluiden riskianalyysi

Rahoituslaitos otti MCP:n käyttöön standardoidakseen riskianalyysiprosessinsa eri osastoilla:

- Yhtenäinen käyttöliittymä luottoriskin, petosten tunnistuksen ja sijoitusriskimallien hallintaan  
- Tiukat käyttöoikeuksien hallinnat ja malliversiointi  
- Kaikkien tekoälysuositusten auditointimahdollisuus  
- Johdonmukainen tietomuotoilu eri järjestelmien välillä  

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

**Tulokset:** Parantunut sääntelyvaatimusten noudattaminen, 40 % nopeammat mallien käyttöönottoajat ja parempi riskinarvioinnin johdonmukaisuus osastojen välillä.

### Tapaustutkimus 4: Microsoft Playwright MCP -palvelin selainautomaatiolle

Microsoft kehitti [Playwright MCP -palvelimen](https://github.com/microsoft/playwright-mcp) mahdollistamaan turvallisen ja standardoidun selainautomaation Model Context Protocolin kautta. Tämä ratkaisu antaa tekoälyagenttien ja LLM:ien olla vuorovaikutuksessa verkkoselainten kanssa hallitusti, auditoitavasti ja laajennettavasti — mahdollistaen käyttötapauksia kuten automatisoitu verkkotestaus, tiedonkeruu ja kokonaisvaltaiset työnkulut.

- Tarjoaa selainautomaation toiminnot (navigointi, lomakkeiden täyttö, kuvakaappaukset jne.) MCP-työkaluina  
- Toteuttaa tiukat käyttöoikeudet ja hiekkalaatikkoympäristön estämään luvattomat toimet  
- Tarjoaa yksityiskohtaiset auditointilokit kaikista selainvuorovaikutuksista  
- Tukee integraatiota Azure OpenAI:n ja muiden LLM-palveluntarjoajien kanssa agenttiohjattuun automaatioon  

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
- Vähensi manuaalisen testauksen tarvetta ja paransi testikattavuutta verkkosovelluksissa  
- Tarjosi uudelleenkäytettävän ja laajennettavan kehyksen selainpohjaisten työkalujen integrointiin yritysympäristöissä  

**Viitteet:**  
- [Playwright MCP Server GitHub -varasto](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI- ja automaatioratkaisut](https://azure.microsoft.com/en-us/products/ai-services/)

### Tapaustutkimus 5: Azure MCP – Yritystason Model Context Protocol palveluna

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) on Microsoftin hallinnoima, yritystason Model Context Protocol -toteutus, joka tarjoaa skaalautuvat, turvalliset ja vaatimustenmukaiset MCP-palvelinominaisuudet pilvipalveluna. Azure MCP mahdollistaa organisaatioiden nopean MCP-palvelinten käyttöönoton, hallinnan ja integroinnin Azure AI:n, datan ja turvallisuuspalveluiden kanssa, vähentäen operatiivista kuormaa ja nopeuttaen tekoälyn käyttöönottoa.

- Täysin hallinnoitu MCP-palvelimen isännöinti sisäänrakennetulla skaalaus-, valvonta- ja turvallisuusominaisuudella  
- Natiivisti integroitu Azure OpenAI:n, Azure AI Searchin ja muiden Azuren palveluiden kanssa  
- Yritystason tunnistus ja valtuutus Microsoft Entra ID:n kautta  
- Tuki räätälöidyille työkaluilla, kehotepohjille ja resurssiliittimille  
- Vaatimustenmukaisuus yritysturvallisuus- ja sääntelyvaatimusten kanssa  

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
- Yksinkertaisti LLM:ien, työkalujen ja yritystietolähteiden integrointia  
- Paransi turvallisuutta, havaittavuutta ja operatiivista tehokkuutta MCP-kuormituksissa  

**Viitteet:**  
- [Azure MCP -dokumentaatio](https://aka.ms/azmcp)  
- [Azure AI -palvelut](https://azure.microsoft.com/en-us/products/ai-services/)

## Tapaustutkimus 6: NLWeb  
MCP (Model Context Protocol) on nouseva protokolla chatbotien ja tekoälyavustajien työkalujen kanssa vuorovaikutukseen. Jokainen NLWeb-instanssi on myös MCP-palvelin, joka tukee yhtä ydintoimintoa, ask, jolla voi esittää verkkosivustolle luonnollisella kielellä kysymyksen. Palautettu vastaus hyödyntää schema.org:ia, laajasti käytettyä sanastoa verkkotietojen kuvaamiseen. Vapaasti sanottuna MCP on NLWeb samalla tavalla kuin Http on HTML:lle. NLWeb yhdistää protokollat, Schema.org-muodot ja esimerkkikoodin auttaakseen sivustoja luomaan nopeasti nämä päätepisteet, hyödyttäen sekä ihmisiä keskustelukäyttöliittymien kautta että koneita luonnollisessa agenttien välisessä vuorovaikutuksessa.

NLWeb koostuu kahdesta erillisestä osasta:  
- Protokolla, joka on hyvin yksinkertainen aloittaa, sivuston luonnollisen kielen rajapinta ja muoto, joka hyödyntää jsonia ja schema.org:ia vastauksessa. Katso REST API -dokumentaatio lisätietoja varten.  
- Yksinkertainen toteutus (1), joka hyödyntää olemassa olevaa merkintää sivustoille, jotka voidaan abstrahoida listaksi kohteita (tuotteet, reseptit, nähtävyydet, arvostelut jne.). Yhdessä käyttöliittymäwidgettien kanssa sivustot voivat helposti tarjota keskustelukäyttöliittymiä sisältöönsä. Katso dokumentaatio Life of a chat query saadaksesi lisätietoja toiminnasta.  

**Viitteet:**  
- [Azure MCP -dokumentaatio](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Tapaustutkimus 7: MCP Foundrylle – Azure AI -agenttien integrointi

Azure AI Foundry MCP -palvelimet osoittavat, miten MCP:tä voidaan käyttää AI-agenttien ja työnkulkujen orkestrointiin ja hallintaan yritysympäristöissä. Integroimalla MCP Azure AI Foundryn kanssa organisaatiot voivat standardoida agenttien vuorovaikutukset, hyödyntää Foundryn työnkulun hallintaa ja varmistaa turvalliset, skaalautuvat käyttöönotot. Tämä lähestymistapa mahdollistaa nopean prototypoinnin, vahvan valvonnan ja saumattoman integraation Azure AI -palveluihin, tukien kehittyneitä skenaarioita kuten tiedonhallintaa ja agenttien arviointia. Kehittäjät hyötyvät yhtenäisestä käyttöliittymästä agenttiputkien rakentamiseen, käyttöönottoon ja valvontaan, kun IT-tiimit saavat parannetun turvallisuuden, vaatimustenmukaisuuden ja operatiivisen tehokkuuden. Ratkaisu sopii erinomaisesti yrityksille, jotka haluavat nopeuttaa tekoälyn käyttöönottoa ja säilyttää hallinnan monimutkaisissa agenttiohjatuissa prosesseissa.

**Viitteet:**  
- [MCP Foundry GitHub -varasto](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Azure AI -agenttien integrointi MCP:n kanssa (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Tapaustutkimus 8: Foundry MCP Playground – Kokeilu ja prototypointi

Foundry MCP Playground tarjoaa valmiin ympäristön MCP-palvelimien ja Azure AI Foundryn integraatioiden kokeiluun. Kehittäjät voivat nopeasti prototypoida, testata ja arvioida tekoälymalleja ja agenttityönkulkuja hyödyntäen Azure AI Foundry Catalogin ja Labsin resursseja. Playground helpottaa käyttöönottoa, tarjoaa esimerkkiprojekteja ja tukee yhteiskehitystä, tehden parhaiden käytäntöjen ja uusien skenaarioiden tutkimisesta helppoa ilman monimutkaista infrastruktuuria. Se on erityisen hyödyllinen tiimeille, jotka haluavat validoida ideoita, jakaa kokeiluja ja nopeuttaa oppimista. Alhaisemman aloituskynnyksen ansiosta playground edistää innovaatioita ja yhteisön panoksia MCP- ja Azure AI Foundry -ekosysteemissä.

**Viitteet:**  
- [Foundry MCP Playground GitHub -varasto](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Tapaustutkimus 9: Microsoft Docs MCP Server – Oppiminen ja osaamisen kehittäminen  
Microsoft Docs MCP Server toteuttaa Model Context Protocol -palvelimen, joka tarjoaa tekoälyavustajille reaaliaikaisen pääsyn viralliseen Microsoftin dokumentaatioon. Suorittaa semanttisen haun Microsoftin virallista teknistä dokumentaatiota vastaan.

**Viitteet:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## Käytännön projektit

### Projekti 1: Monitoimittajainen MCP-palvelin

**Tavoite:** Luo MCP-palvelin, joka voi ohjata pyyntöjä useille tekoälymallipalveluntarjoajille tiettyjen kriteerien perusteella.

**Vaatimukset:**  
- Tuki vähintään kolmelle eri mallipalveluntarjoajalle (esim. OpenAI, Anthropic, paikalliset mallit)  
- Reititysmekanismi pyyntöjen metatietojen perusteella  
- Konfigurointijärjestelmä palveluntarjoajien tunnistetietojen hallintaan  
- Välimuisti suorituskyvyn ja kustannusten optimointiin  
- Yksinkertainen hallintapaneeli käytön seurantaan  

**Toteutusvaiheet:**  
1. Perustetaan MCP-palvelininfrastruktuuri  
2. Toteutetaan palveluntarjoajien adapterit jokaiselle tekoälymallipalvelulle  
3. Luodaan reitityslogiikka pyyntöjen attribuuttien perusteella  
4. Lisätään välimuistimekanismit usein toistuviin pyyntöihin  
5. Kehitetään seurantapaneeli  
6. Testataan erilaisilla pyyntökuvioilla  

**Teknologiat:** Valitse Python (.NET/Java/Python mieltymyksesi mukaan), Redis välimuistiksi ja yksinkertainen web-kehys hallintapaneelille.

### Projekti 2: Yrityksen kehotteiden hallintajärjestelmä

**Tavoite:** Kehitä MCP-pohjainen järjestelmä kehotepohjien hallintaan, versiointiin ja käyttöönottoon organisaation sisällä.

**Vaatimukset:**  
- Keskitetty arkisto kehotepohjille  
- Versiointi- ja hyväksymisprosessit  
- Pohjien testausominaisuudet esimerkkisyötteillä  
- Roolipohjaiset käyttöoikeudet  
- API pohjien hakemiseen ja käyttöönottoon  

**Toteutusvaiheet:**  
1. Suunnittele tietokantakaavio pohjien tallennukseen  
2. Luo ydintoiminnot pohjien CRUD-operaatioille  
3. Toteuta versiointijärjestelmä  
4. Rakenna hyväksymisprosessi  
5. Kehitä testauskehys  
6. Luo yksinkertainen web-käyttöliittymä hallintaan  
7. Integroi MCP-palvelimen kanssa  

**Teknologiat:** Valitse haluamasi backend-kehys, SQL- tai NoSQL-tietokanta ja frontend-kehys hallintaliittymälle.

### Projekti 3: MCP-pohjainen sisällöntuotantoalusta

**Tavoite:** Rakenna sisällöntuotantoalusta, joka hyödyntää MCP:tä tarjotakseen johdonmukaisia tuloksia eri sisältötyypeille.

**Vaatimukset:**  
- Tuki useille sisältömuodoille (blogikirjoitukset, sosiaalinen media, markkinointitekstit)  
- Mallipohjainen generointi muokkausmahdollisuuksilla  
- Sisällön arviointi- ja palautteenantojärjestelmä  
- Sisällön suorituskykymittareiden seuranta  
- Sisällön versiointi ja iterointi  

**Toteutusvaiheet:**  
1. Perusta MCP-asiakasinfrastruktuuri  
2. Luo pohjat eri sisältötyypeille  
3. Rakenna sisällöntuotantoputki  
4. Toteuta arviointijärjestelmä  
5. Kehitä mittareiden seuranta  
6. Luo käyttöliittymä pohjien hallintaan ja sisällöntuotantoon  

**Teknologiat:** Valitse suosikkiohjelmointikielesi, web-kehys ja tietokantajärjestelmä.

## MCP-teknologian tulevaisuuden suuntaukset

### Nousevat trendit

1. **Monimodaalinen MCP**  
   - MCP:n laajentaminen standardoimaan vuorovaikutuksia kuvan, äänen ja videon mallien kanssa  
   - Ristimodaalisten päättelykykyjen kehittäminen  
   - Standardoidut kehotemuodot eri modaliteeteille  

2. **Federatiivinen MCP-infrastruktuuri**  
   - Hajautetut MCP-verkostot, jotka voivat jakaa resursseja organisaatioiden välillä  
   - Standardoidut protokollat turvalliseen mallien jakamiseen  
   - Yksityisyyttä suojaavat laskentatekniikat  

3. **MCP-markkinapaikat**  
   - Ekosysteemit MCP-pohjaisten mallipoh
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Etusivu Remote MCP Server -toteutuksille Azure Functions -ympäristössä, sisältäen linkit kielikohtaisiin repositorioihin  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Pikakäynnistysmalli räätälöityjen etä-MCP-palvelimien rakentamiseen ja käyttöönottoon Azure Functionsilla Pythonilla  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Pikakäynnistysmalli räätälöityjen etä-MCP-palvelimien rakentamiseen ja käyttöönottoon Azure Functionsilla .NET/C#:lla  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Pikakäynnistysmalli räätälöityjen etä-MCP-palvelimien rakentamiseen ja käyttöönottoon Azure Functionsilla TypeScriptillä  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management AI-porttina etä-MCP-palvelimille Pythonilla  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI -kokeiluja, jotka sisältävät MCP-ominaisuuksia ja integroivat Azure OpenAI:n sekä AI Foundryn

Nämä repositoriot tarjoavat erilaisia toteutuksia, malleja ja resursseja Model Context Protocolin käyttöön eri ohjelmointikielillä ja Azure-palveluissa. Ne kattavat laajan kirjon käyttötapauksia peruspalvelimien toteutuksista autentikointiin, pilvikäyttöönottoon ja yritysintegrointiin.

#### MCP Resources Directory

Virallisen Microsoft MCP -repositorion [MCP Resources -hakemisto](https://github.com/microsoft/mcp/tree/main/Resources) tarjoaa valikoiman esimerkkiresursseja, prompt-malleja ja työkalumäärittelyjä Model Context Protocol -palvelimien käyttöön. Tämä hakemisto on suunniteltu auttamaan kehittäjiä pääsemään nopeasti alkuun MCP:n kanssa tarjoamalla uudelleenkäytettäviä rakennuspalikoita ja parhaiden käytäntöjen esimerkkejä:

- **Prompt Templates:** Valmiita prompt-malleja yleisiin tekoälytehtäviin ja -tilanteisiin, joita voi mukauttaa omiin MCP-palvelintoteutuksiin.  
- **Tool Definitions:** Esimerkkityökalujen skeemat ja metatiedot työkalujen integroinnin ja kutsumisen standardoimiseksi eri MCP-palvelimissa.  
- **Resource Samples:** Esimerkkiresurssimäärittelyjä, jotka kuvaavat yhteyksiä tietolähteisiin, rajapintoihin ja ulkoisiin palveluihin MCP-kehyksessä.  
- **Reference Implementations:** Käytännön esimerkkejä, jotka näyttävät, miten resurssit, promptit ja työkalut voidaan jäsentää ja organisoida todellisissa MCP-projekteissa.

Nämä resurssit nopeuttavat kehitystä, edistävät standardointia ja auttavat varmistamaan parhaat käytännöt MCP-pohjaisten ratkaisujen rakentamisessa ja käyttöönotossa.

#### MCP Resources Directory
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Tutkimusmahdollisuudet

- Tehokkaat promptin optimointimenetelmät MCP-kehyksissä  
- Turvallisuusmallit monivuokraajaympäristöihin MCP:n käyttöönotossa  
- Suorituskyvyn vertailu eri MCP-toteutusten välillä  
- Formaalit varmennusmenetelmät MCP-palvelimille

## Yhteenveto

Model Context Protocol (MCP) muokkaa nopeasti tulevaisuutta kohti standardoitua, turvallista ja yhteentoimivaa tekoälyn integrointia eri toimialoilla. Tässä oppitunnissa esiteltyjen tapaustutkimusten ja käytännön projektien kautta olet nähnyt, miten varhaiset omaksujat — mukaan lukien Microsoft ja Azure — hyödyntävät MCP:tä ratkaistakseen todellisia haasteita, nopeuttaakseen tekoälyn käyttöönottoa sekä varmistaakseen vaatimustenmukaisuuden, turvallisuuden ja skaalautuvuuden. MCP:n modulaarinen lähestymistapa mahdollistaa organisaatioiden yhdistää suuria kielimalleja, työkaluja ja yritystietoja yhtenäiseen, auditoitavaan kehykseen. MCP:n kehittyessä aktiivinen osallistuminen yhteisöön, avoimen lähdekoodin resurssien hyödyntäminen ja parhaiden käytäntöjen soveltaminen ovat avainasemassa kestävien ja tulevaisuuden tarpeisiin vastaavien tekoälyratkaisujen rakentamisessa.

## Lisäresurssit

- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  
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

## Harjoitukset

1. Analysoi yksi tapaustutkimuksista ja ehdota vaihtoehtoinen toteutustapa.  
2. Valitse yksi projektiehdotus ja laadi siitä yksityiskohtainen tekninen määrittely.  
3. Tutki toimiala, jota ei ole käsitelty tapaustutkimuksissa, ja hahmottele, miten MCP voisi ratkaista sen erityishaasteet.  
4. Tutki yksi tulevaisuuden suuntaus ja luo konsepti uudelle MCP-laajennukselle sen tukemiseksi.

Seuraava: [Best Practices](../08-BestPractices/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.