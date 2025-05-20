<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1ccfe1a6ea77e42862b92ae53cb6cddf",
  "translation_date": "2025-05-20T17:28:17+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "fi"
}
-->
# Lessons from Early Adoprters

## Overview

Tässä oppitunnissa tarkastellaan, miten varhaiset omaksujat ovat hyödyntäneet Model Context Protocolia (MCP) ratkaistakseen käytännön haasteita ja edistääkseen innovaatioita eri toimialoilla. Yksityiskohtaisten tapaustutkimusten ja käytännön projektien kautta näet, kuinka MCP mahdollistaa standardoidun, turvallisen ja skaalautuvan tekoälyn integroinnin – yhdistäen suuria kielimalleja, työkaluja ja yritystietoja yhtenäiseen kokonaisuuteen. Saat käytännön kokemusta MCP-pohjaisten ratkaisujen suunnittelusta ja rakentamisesta, opit toimivista toteutusmalleista sekä parhaista käytännöistä MCP:n käyttöönotossa tuotantoympäristöissä. Oppitunnissa korostetaan myös nousevia trendejä, tulevaisuuden suuntauksia ja avoimen lähdekoodin resursseja, joiden avulla pysyt MCP-teknologian ja sen kehittyvän ekosysteemin kärjessä.

## Learning Objectives

- Analysoida MCP:n käytännön toteutuksia eri toimialoilla
- Suunnitella ja rakentaa kokonaisia MCP-pohjaisia sovelluksia
- Tutkia MCP-teknologian nousevia trendejä ja tulevaisuuden suuntauksia
- Soveltaa parhaita käytäntöjä todellisissa kehitystilanteissa

## Real-world MCP Implementations

### Case Study 1: Enterprise Customer Support Automation

Monikansallinen yritys toteutti MCP-pohjaisen ratkaisun standardoidakseen tekoälyvuorovaikutukset asiakastukijärjestelmissään. Tämä mahdollisti heille:

- Yhdenmukaisen käyttöliittymän useille LLM-palveluntarjoajille
- Johdonmukaisen kehotteiden hallinnan eri osastojen välillä
- Vahvojen turvallisuus- ja vaatimustenmukaisuuskontrollien toteuttamisen
- Helpon siirtymisen eri tekoälymallien välillä tarpeen mukaan

**Technical Implementation:**  
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

**Results:** 30 % kustannussäästö malleissa, 45 % parannus vastausten johdonmukaisuudessa ja parannettu vaatimustenmukaisuus globaalissa toiminnassa.

### Case Study 2: Healthcare Diagnostic Assistant

Terveydenhuollon tarjoaja kehitti MCP-infrastruktuurin integroidakseen useita erikoistuneita lääketieteellisiä tekoälymalleja varmistaen samalla potilastietojen suojan:

- Saumaton vaihto yleis- ja erikoismallien välillä
- Tiukat tietosuojakontrollit ja auditointijäljet
- Integrointi olemassa oleviin sähköisiin potilastietojärjestelmiin (EHR)
- Johdonmukainen kehotteiden suunnittelu lääketieteelliseen terminologiaan

**Technical Implementation:**  
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

**Results:** Parannettu diagnostiikkasuositukset lääkäreille, täysi HIPAA-vaatimustenmukaisuus ja merkittävä kontekstinvaihdon väheneminen järjestelmien välillä.

### Case Study 3: Financial Services Risk Analysis

Rahoituslaitos otti MCP:n käyttöön standardoidakseen riskianalyysiprosessinsa eri osastoilla:

- Yhdenmukainen käyttöliittymä luottoriskille, petostunnistukselle ja sijoitusriskimalleille
- Tiukat käyttöoikeuksien hallinnat ja malliversiointi
- Kaikkien tekoälysuositusten auditointimahdollisuus
- Johdonmukainen tietojen muotoilu eri järjestelmien välillä

**Technical Implementation:**  
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

**Results:** Parantunut sääntelyvaatimusten noudattaminen, 40 % nopeammat mallien käyttöönotot ja parempi riskinarvioinnin johdonmukaisuus osastojen välillä.

### Case Study 4: Microsoft Playwright MCP Server for Browser Automation

Microsoft kehitti [Playwright MCP serverin](https://github.com/microsoft/playwright-mcp) mahdollistamaan turvallisen, standardoidun selainautomaation Model Context Protocolin avulla. Tämä ratkaisu antaa tekoälyagenttien ja LLM:ien hallita verkkoselaimia kontrolloidusti, auditointikelpoisesti ja laajennettavasti – mahdollistaen esimerkiksi automaattisen verkkotestauksen, tiedonkeruun ja kokonaisvaltaiset työnkulut.

- Tarjoaa selainautomaation toiminnot (navigointi, lomakkeiden täyttö, kuvakaappaukset jne.) MCP-työkaluina
- Toteuttaa tiukat käyttöoikeudet ja hiekkalaatikkoympäristön estämään luvattomia toimia
- Tarjoaa yksityiskohtaiset auditointilokit kaikista selaintoiminnoista
- Tukee integraatiota Azure OpenAI:n ja muiden LLM-palveluntarjoajien kanssa agenttivetoiseen automaatioon

**Technical Implementation:**  
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

**Results:**  
- Mahdollisti turvallisen, ohjelmallisen selainautomaation tekoälyagenteille ja LLM:ille  
- Vähensi manuaalisen testauksen tarvetta ja paransi testikattavuutta verkkosovelluksissa  
- Tarjosi uudelleenkäytettävän ja laajennettavan kehyksen selainpohjaisten työkalujen integrointiin yritysympäristöissä

**References:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Case Study 5: Azure MCP – Enterprise-Grade Model Context Protocol as a Service

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) on Microsoftin hallinnoima, yritystason Model Context Protocol -palvelu, joka tarjoaa skaalautuvat, turvalliset ja vaatimustenmukaiset MCP-palvelinominaisuudet pilvipalveluna. Azure MCP mahdollistaa organisaatioiden nopean MCP-palvelimien käyttöönoton, hallinnan ja integroinnin Azure AI:n, datan ja turvallisuuspalveluiden kanssa, vähentäen operatiivista kuormaa ja nopeuttaen tekoälyn käyttöönottoa.

- Täysin hallinnoitu MCP-palvelin, jossa sisäänrakennettu skaalautuvuus, valvonta ja turvallisuus  
- Natiivi integraatio Azure OpenAI:n, Azure AI Searchin ja muiden Azure-palveluiden kanssa  
- Yritystason todennus ja valtuutus Microsoft Entra ID:n kautta  
- Tuki räätälöidyille työkaluilla, kehotepohjille ja resurssiliittimille  
- Vaatimustenmukaisuus yritysturvallisuus- ja sääntelyvaatimusten kanssa

**Technical Implementation:**  
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

**Results:**  
- Lyhensi yritysten tekoälyprojektien aika-arvoa tarjoamalla käyttövalmiin, vaatimustenmukaisen MCP-palvelinympäristön  
- Yksinkertaisti LLM:ien, työkalujen ja yritysdatalähteiden integrointia  
- Paransi turvallisuutta, havaittavuutta ja operatiivista tehokkuutta MCP-kuormissa  

**References:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Case Study 6: NLWeb  
MCP (Model Context Protocol) on nouseva protokolla chatbotien ja tekoälyavustajien työkalujen kanssa vuorovaikutukseen. Jokainen NLWeb-instanssi on myös MCP-palvelin, joka tukee yhtä ydintoimintoa, ask, jota käytetään verkkosivustolle luonnollisella kielellä esitettävien kysymysten tekemiseen. Vastauksessa hyödynnetään schema.org-sanakirjaa, joka on laajalti käytetty verkkodatan kuvaamiseen. Vapaasti sanottuna MCP on NLWeb samalla tavalla kuin HTTP on HTML:lle. NLWeb yhdistää protokollat, schema.org-muodot ja esimerkkikoodin, jotta sivustot voivat nopeasti luoda näitä päätepisteitä, hyödyttäen sekä ihmisiä keskustelukäyttöliittymien kautta että koneita luonnollisen agenttien välisen vuorovaikutuksen avulla.

NLWeb koostuu kahdesta erillisestä osasta.  
- Protokolla, hyvin yksinkertainen aluksi, jolla voi kommunikoida sivuston kanssa luonnollisella kielellä ja muoto, joka hyödyntää jsonia ja schema.orgia vastauksen esittämiseen. Katso dokumentaatio REST API:sta lisätietoja varten.  
- Yksinkertainen toteutus (1):stä, joka hyödyntää olemassa olevaa merkintää sivustoille, jotka voidaan abstrahoida tuoteluetteloiksi (tuotteet, reseptit, nähtävyydet, arvostelut jne.). Yhdessä käyttöliittymäwidgettien kanssa sivustot voivat helposti tarjota keskustelukäyttöliittymiä sisällölleen. Katso dokumentaatio Life of a chat query -osiosta lisätietoja toiminnasta.

**References:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Case Study 7: MCP for Foundry – Integrating Azure AI Agents

Azure AI Foundry MCP -palvelimet osoittavat, miten MCP:tä voidaan käyttää AI-agenttien ja työnkulkujen orkestrointiin ja hallintaan yritysympäristöissä. Integroimalla MCP Azure AI Foundryn kanssa organisaatiot voivat standardoida agenttien vuorovaikutukset, hyödyntää Foundryn työnkulun hallintaa ja varmistaa turvalliset, skaalautuvat käyttöönotot. Tämä lähestymistapa mahdollistaa nopean prototypoinnin, vahvan valvonnan ja saumattoman integraation Azure AI -palveluihin, tukien edistyneitä skenaarioita kuten tiedonhallinta ja agenttien arviointi. Kehittäjät hyötyvät yhtenäisestä käyttöliittymästä agenttiputkien rakentamiseen, käyttöönottoon ja valvontaan, kun IT-tiimit saavat parannetun turvallisuuden, vaatimustenmukaisuuden ja operatiivisen tehokkuuden. Ratkaisu on ihanteellinen yrityksille, jotka haluavat nopeuttaa tekoälyn käyttöönottoa ja hallita monimutkaisia agenttivetoisia prosesseja.

**References:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Case Study 8: Foundry MCP Playground – Experimentation and Prototyping

Foundry MCP Playground tarjoaa valmiin ympäristön MCP-palvelimien ja Azure AI Foundry -integraatioiden kokeiluun. Kehittäjät voivat nopeasti prototypoida, testata ja arvioida tekoälymalleja ja agenttien työnkulkuja hyödyntäen Azure AI Foundry Catalogin ja Labsin resursseja. Leikkikenttä yksinkertaistaa käyttöönottoa, tarjoaa esimerkkiprojekteja ja tukee yhteistyökehitystä, tehden parhaiden käytäntöjen ja uusien skenaarioiden tutkimisesta helppoa vähäisellä vaivalla. Se on erityisen hyödyllinen tiimeille, jotka haluavat validoida ideoita, jakaa kokeiluja ja nopeuttaa oppimista ilman monimutkaista infrastruktuuria. Kynnystä madaltamalla leikkikenttä edistää innovaatioita ja yhteisön panoksia MCP:n ja Azure AI Foundryn ekosysteemissä.

**References:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Hands-on Projects

### Project 1: Build a Multi-Provider MCP Server

**Objective:** Luo MCP-palvelin, joka osaa ohjata pyyntöjä useille tekoälymallipalveluntarjoajille tietyin kriteerein.

**Requirements:**  
- Tuki vähintään kolmelle eri mallipalveluntarjoajalle (esim. OpenAI, Anthropic, paikalliset mallit)  
- Reititysmekanismi pyyntöjen metatietojen perusteella  
- Konfigurointijärjestelmä palveluntarjoajien tunnistetietojen hallintaan  
- Välimuistitus suorituskyvyn ja kustannusten optimointiin  
- Yksinkertainen hallintapaneeli käytön seurantaan

**Implementation Steps:**  
1. Perusta MCP-palvelimen perusinfrastruktuuri  
2. Toteuta palveluntarjoajien adapterit jokaiselle AI-mallipalvelulle  
3. Luo reitityslogiikka pyyntöjen ominaisuuksien perusteella  
4. Lisää välimuistituki usein toistuviin pyyntöihin  
5. Kehitä käyttöseurannan hallintapaneeli  
6. Testaa erilaisilla pyyntökuvioilla

**Technologies:** Valitse Python (.NET/Java/Python mieltymyksesi mukaan), Redis välimuistiin ja yksinkertainen web-kehys hallintapaneelille.

### Project 2: Enterprise Prompt Management System

**Objective:** Kehitä MCP-pohjainen järjestelmä, jolla hallitaan, versioidaan ja otetaan käyttöön kehotepohjia organisaation sisällä.

**Requirements:**  
- Keskitetty arkisto kehotepohjille  
- Versiointi ja hyväksymisprosessit  
- Pohjien testausominaisuudet esimerkkisyötteillä  
- Roolipohjainen käyttöoikeuksien hallinta  
- API pohjien hakua ja käyttöönottoa varten

**Implementation Steps:**  
1. Suunnittele tietokantakaavio pohjatietojen tallennukseen  
2. Luo ydintoiminnot pohjien CRUD-operaatioihin  
3. Toteuta versiointijärjestelmä  
4. Rakenna hyväksymisprosessit  
5. Kehitä testauskehys  
6. Luo yksinkertainen web-käyttöliittymä hallintaan  
7. Integroi MCP-palvelimen kanssa

**Technologies:** Valitse haluamasi backend-kehys, SQL- tai NoSQL-tietokanta ja frontend-kehys hallintaliittymälle.

### Project 3: MCP-Based Content Generation Platform

**Objective:** Rakenna sisällöntuotantoalusta, joka hyödyntää MCP:tä tarjotakseen johdonmukaisia tuloksia eri sisältötyypeille.

**Requirements:**  
- Tuki useille sisältömuodoille (blogikirjoitukset, some, markkinointitekstit)  
- Pohjapohjainen generointi muokkausmahdollisuuksilla  
- Sisällön tarkastus- ja palautteenantojärjestelmä  
- Sisällön suorituskykymittareiden seuranta  
- Sisällön versiointi ja iterointi

**Implementation Steps:**  
1. Perusta MCP-asiakasinfrastruktuuri  
2. Luo pohjat eri sisältötyypeille  
3. Rakenna sisällöntuotantoputki  
4. Toteuta tarkastusjärjestelmä  
5. Kehitä mittareiden seuranta  
6. Luo käyttöliittymä pohjien hallintaan ja sisällöntuotantoon

**Technologies:** Valitse ohjelmointikieli, web-kehys ja tietokanta mieltymyksesi mukaan.

## Future Directions for MCP Technology

### Emerging Trends

1. **Multi-Modal MCP**  
   - MCP:n laajentaminen vakioimaan vuorovaikutus kuvan, äänen ja videon mallien kanssa  
   - Ristimodaalisten päättelykykyjen kehittäminen  
   - Standardoidut kehotemuodot eri modaliteeteille

2. **Federated MCP Infrastructure**  
   - Hajautetut MCP-verkostot, jotka jakavat resursseja organisaatioiden välillä  
   - Standardoidut protokollat turvalliseen mallien jakamiseen  
   - Yksityisyyttä suojaavat laskentamenetelmät

3. **MCP Marketplaces**  
   - Ekosysteemit MCP-pohjaisten pohjien ja lisäosien jakamiseen ja kaupallistamiseen  
   - Laadunvarmistus- ja sertifiointiprosessit  
   - Integraatio mallimarkkinapaikkoihin

4. **MCP for Edge Computing**  
   - MCP-standardien mukauttaminen resurssirajoitetuille reunalaitteille  
   - Optimoidut protokollat vähäkaistaisiin ympäristöihin  
   - Erikoistuneet MCP-toteutukset IoT-ekosysteemeille

5. **Regulatory Frameworks**  
   - MCP-laajennusten kehittäminen sääntelyvaatimusten täyttämiseksi  
   - Standardoidut auditointijäljet ja selitettävyyden rajapinnat  
   - Integraatio nouseviin tekoälyn hallintakehyksiin

### MCP Solutions from Microsoft 

Microsoft ja Azure ovat kehittäneet useita avoimen lähdekoodin repositorioita auttamaan kehittäjiä MCP:n toteuttamisessa eri skenaarioissa:

#### Microsoft Organization  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – Playwright MCP -palvelin selainautomaatiota ja testausta varten  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – OneDrive MCP -palvelin paikalliseen testaukseen ja yhteisön kontribuutioihin  
3. [NLWeb](https://github.com/microsoft/NlWeb) – K
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
2. Valitse yksi projektiehdotus ja laadi yksityiskohtainen tekninen erittely.
3. Tutki toimiala, jota ei ole käsitelty tapaustutkimuksissa, ja hahmottele, miten MCP voisi ratkaista sen erityishaasteet.
4. Tutki yksi tulevaisuuden suuntaus ja luo konsepti uudelle MCP-laajennukselle sen tukemiseksi.

Seuraava: [Best Practices](../08-BestPractices/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää auktoritatiivisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaisen ihmiskääntäjän käyttöä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.