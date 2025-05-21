<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T21:51:31+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "fi"
}
-->
# Lessons from Early Adopters

## Overview

Tässä oppitunnissa tarkastellaan, miten varhaiset käyttäjät ovat hyödyntäneet Model Context Protocolia (MCP) ratkaistakseen käytännön haasteita ja edistääkseen innovaatiota eri toimialoilla. Yksityiskohtaisten tapaustutkimusten ja käytännön projektien kautta näet, miten MCP mahdollistaa standardoidun, turvallisen ja skaalautuvan tekoälyn integroinnin — yhdistäen suuria kielimalleja, työkaluja ja yritystietoja yhtenäiseksi kokonaisuudeksi. Saat käytännön kokemusta MCP-pohjaisten ratkaisujen suunnittelusta ja toteutuksesta, opit todetuista toteutusmalleista ja parhaista käytännöistä MCP:n käyttöönotossa tuotantoympäristöissä. Oppitunti korostaa myös nousevia trendejä, tulevia suuntia ja avoimen lähdekoodin resursseja, jotka auttavat pysymään MCP-teknologian ja sen kehittyvän ekosysteemin kärjessä.

## Learning Objectives

- Analysoida käytännön MCP-toteutuksia eri toimialoilla
- Suunnitella ja rakentaa kokonaisia MCP-pohjaisia sovelluksia
- Tutkia MCP-teknologian nousevia trendejä ja tulevia suuntia
- Soveltaa parhaita käytäntöjä todellisissa kehitystilanteissa

## Real-world MCP Implementations

### Case Study 1: Enterprise Customer Support Automation

Monikansallinen yritys otti käyttöön MCP-pohjaisen ratkaisun standardoidakseen tekoälyvuorovaikutukset asiakastukijärjestelmissään. Tämä mahdollisti heille:

- Yhtenäisen käyttöliittymän useille LLM-tarjoajille
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

**Results:** 30 %:n kustannussäästöt malleissa, 45 %:n parannus vastausten johdonmukaisuudessa ja vahvistunut vaatimustenmukaisuus globaalissa toiminnassa.

### Case Study 2: Healthcare Diagnostic Assistant

Terveydenhuollon tarjoaja kehitti MCP-infrastruktuurin useiden erikoistuneiden lääketieteellisten tekoälymallien integroimiseksi varmistaen samalla potilastietojen suojan:

- Saumaton siirtyminen yleis- ja erikoismallien välillä
- Tiukat tietosuojakontrollit ja auditointijäljet
- Integraatio olemassa oleviin sähköisiin potilastietojärjestelmiin (EHR)
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

**Results:** Parannetut diagnoosiehdotukset lääkäreille, täysi HIPAA-vaatimustenmukaisuus ja merkittävä kontekstinvaihdon vähennys järjestelmien välillä.

### Case Study 3: Financial Services Risk Analysis

Rahoituslaitos otti MCP:n käyttöön standardoidakseen riskianalyysiprosessinsa eri osastojen välillä:

- Yhtenäinen käyttöliittymä luottoriskin, petostunnistuksen ja sijoitusriskin malleille
- Tiukat käyttöoikeuksien hallinnat ja malliversiointi
- Kaikkien tekoälysuositusten auditointimahdollisuus
- Johdonmukainen tietomuotoilu eri järjestelmien välillä

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

**Results:** Parantunut sääntelynmukaisuus, 40 % nopeammat mallien käyttöönottoajat ja parempi riskinarvioinnin johdonmukaisuus osastojen välillä.

### Case Study 4: Microsoft Playwright MCP Server for Browser Automation

Microsoft kehitti [Playwright MCP serverin](https://github.com/microsoft/playwright-mcp) mahdollistaakseen turvallisen ja standardoidun selaimen automaation Model Context Protocolin kautta. Tämä ratkaisu mahdollistaa tekoälyagenttien ja LLM:ien vuorovaikutuksen verkkoselainten kanssa hallitusti, auditointikelpoisesti ja laajennettavasti — mahdollistaen esimerkiksi automaattisen web-testaamisen, datan poiminnan ja kokonaisvaltaiset työnkulut.

- Tarjoaa selaimen automaatiotoiminnot (navigointi, lomakkeiden täyttö, kuvakaappausten ottaminen jne.) MCP-työkaluina
- Toteuttaa tiukat pääsynhallinnat ja hiekkalaatikkoympäristön luvattomien toimien estämiseksi
- Tarjoaa yksityiskohtaiset auditointilokit kaikista selainvuorovaikutuksista
- Tukee integraatiota Azure OpenAI:n ja muiden LLM-tarjoajien kanssa agenttivetoiseen automaatioon

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
- Mahdollisti turvallisen, ohjelmallisen selaimen automaation tekoälyagenteille ja LLM:ille  
- Vähensi manuaalisen testauksen tarvetta ja paransi testikattavuutta web-sovelluksissa  
- Tarjosi uudelleenkäytettävän ja laajennettavan kehyksen selainpohjaisten työkalujen integrointiin yritysympäristöissä

**References:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Case Study 5: Azure MCP – Enterprise-Grade Model Context Protocol as a Service

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) on Microsoftin hallinnoitu, yritysluokan Model Context Protocol -toteutus, joka tarjoaa skaalautuvat, turvalliset ja vaatimustenmukaiset MCP-palvelinominaisuudet pilvipalveluna. Azure MCP mahdollistaa organisaatioiden nopean MCP-palvelinten käyttöönoton, hallinnan ja integroinnin Azure AI:n, datan ja turvallisuuspalvelujen kanssa, vähentäen operatiivista kuormaa ja kiihdyttäen tekoälyn käyttöönottoa.

- Täysin hallinnoitu MCP-palvelin, jossa sisäänrakennettu skaalaus, valvonta ja turvallisuus  
- Natiivi integraatio Azure OpenAI:n, Azure AI Searchin ja muiden Azure-palveluiden kanssa  
- Yritystason todennus ja valtuutus Microsoft Entra ID:n kautta  
- Tuki räätälöidyille työkaluillle, kehotepohjille ja resurssiliittimille  
- Vaatimustenmukaisuus yrityksen turvallisuus- ja sääntelyvaatimusten kanssa

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
- Lyhensi yritysten tekoälyprojektien arvoon pääsyä tarjoamalla käyttövalmiin, vaatimustenmukaisen MCP-palvelinalustan  
- Yksinkertaisti LLM:ien, työkalujen ja yritysdatalähteiden integrointia  
- Paransi MCP-kuormien turvallisuutta, havaittavuutta ja operatiivista tehokkuutta

**References:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Case Study 6: NLWeb  
MCP (Model Context Protocol) on nouseva protokolla chatbotien ja tekoälyavustajien työkalujen vuorovaikutukseen. Jokainen NLWeb-instanssi on myös MCP-palvelin, joka tukee yhtä ydintoimintoa, ask, jolla voi esittää verkkosivustolle luonnollisella kielellä kysymyksen. Palautettu vastaus hyödyntää schema.orgia, laajasti käytettyä sanastoa verkkodatan kuvaamiseen. Vapaasti ilmaistuna MCP on NLWeb samalla tavalla kuin Http on HTML:lle. NLWeb yhdistää protokollat, Schema.org-muodot ja esimerkkikoodin auttaakseen sivustoja luomaan nopeasti näitä rajapintoja, hyödyttäen sekä ihmisiä keskustelukäyttöliittymien kautta että koneita luonnollisessa agenttien välisessä vuorovaikutuksessa.

NLWeb koostuu kahdesta erillisestä osasta.  
- Protokolla, joka on hyvin yksinkertainen aluksi, sivuston luonnollisen kielen rajapinnan luomiseksi ja muoto, joka hyödyntää jsonia ja schema.orgia vastauksen esittämiseen. Katso REST API -dokumentaatio lisätietoja varten.  
- Yksinkertainen toteutus (1), joka hyödyntää olemassa olevaa merkintää sivustoille, jotka voidaan abstraktoida listaksi kohteita (tuotteita, reseptejä, nähtävyyksiä, arvosteluja jne.). Käyttöliittymäwidgettien kanssa sivustot voivat helposti tarjota keskustelukäyttöliittymiä sisältöönsä. Katso dokumentaatio Life of a chat query saadaksesi lisätietoja toiminnasta.

**References:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Case Study 7: MCP for Foundry – Integrating Azure AI Agents

Azure AI Foundry MCP -palvelimet demonstroivat, miten MCP:tä voidaan käyttää tekoälyagenttien ja työnkulkujen orkestrointiin ja hallintaan yritysympäristöissä. Integroimalla MCP Azure AI Foundryn kanssa organisaatiot voivat standardoida agenttien vuorovaikutukset, hyödyntää Foundryn työnkulun hallintaa ja varmistaa turvalliset, skaalautuvat käyttöönotot. Tämä lähestymistapa mahdollistaa nopean prototypoinnin, vahvan valvonnan ja saumattoman integraation Azure AI -palveluihin, tukien edistyneitä skenaarioita kuten tiedonhallintaa ja agenttien arviointia. Kehittäjät hyötyvät yhtenäisestä käyttöliittymästä agenttiputkien rakentamiseen, käyttöönottoon ja valvontaan, kun taas IT-tiimit saavat parannetun turvallisuuden, vaatimustenmukaisuuden ja operatiivisen tehokkuuden. Ratkaisu on ihanteellinen yrityksille, jotka haluavat nopeuttaa tekoälyn käyttöönottoa ja säilyttää hallinnan monimutkaisissa agenttivetoisissa prosesseissa.

**References:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Case Study 8: Foundry MCP Playground – Experimentation and Prototyping

Foundry MCP Playground tarjoaa valmiin ympäristön MCP-palvelimien ja Azure AI Foundry -integraatioiden kokeiluun. Kehittäjät voivat nopeasti prototyypittää, testata ja arvioida tekoälymalleja ja agenttityönkulkuja hyödyntäen resursseja Azure AI Foundry Catalogista ja Labsista. Playground helpottaa käyttöönottoa, tarjoaa esimerkkiprojekteja ja tukee yhteistyökehitystä, tehden parhaiden käytäntöjen ja uusien skenaarioiden tutkimisesta helppoa ilman monimutkaista infrastruktuuria. Se on erityisen hyödyllinen tiimeille, jotka haluavat validoida ideoita, jakaa kokeiluja ja nopeuttaa oppimista. Kynnys madaltuu, mikä edistää innovointia ja yhteisön panoksia MCP- ja Azure AI Foundry -ekosysteemissä.

**References:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Hands-on Projects

### Project 1: Build a Multi-Provider MCP Server

**Objective:** Luo MCP-palvelin, joka voi ohjata pyyntöjä useille tekoälymallien tarjoajille tiettyjen kriteerien perusteella.

**Requirements:**  
- Tuki vähintään kolmelle eri mallitarjoajalle (esim. OpenAI, Anthropic, paikalliset mallit)  
- Toteuta reititysmekanismi pyyntöjen metatietojen perusteella  
- Luo konfigurointijärjestelmä tarjoajien tunnistetietojen hallintaan  
- Lisää välimuisti suorituskyvyn ja kustannusten optimointiin  
- Rakenna yksinkertainen hallintapaneeli käytön seurantaan

**Implementation Steps:**  
1. Perusta MCP-palvelininfrastruktuuri  
2. Toteuta tarjoaja-adapterit jokaiselle tekoälymallipalvelulle  
3. Luo reitityslogiikka pyyntöjen attribuuttien perusteella  
4. Lisää välimuistimekanismit usein toistuviin pyyntöihin  
5. Kehitä valvontapaneeli  
6. Testaa erilaisilla pyyntökuvioilla

**Technologies:** Valitse Python (.NET/Java/Python mieltymyksesi mukaan), Redis välimuistiksi ja yksinkertainen web-kehys hallintapaneelille.

### Project 2: Enterprise Prompt Management System

**Objective:** Kehitä MCP-pohjainen järjestelmä kehotepohjien hallintaan, versiointiin ja käyttöönottoon organisaation sisällä.

**Requirements:**  
- Luo keskitetty varasto kehotepohjille  
- Toteuta versiointi ja hyväksymistyönkulut  
- Rakenna testausmahdollisuudet pohjien kokeiluun esimerkkisyötteillä  
- Kehitä roolipohjainen käyttöoikeuksien hallinta  
- Luo API pohjien hakemiseen ja käyttöönottoon

**Implementation Steps:**  
1. Suunnittele tietokantakaavio pohjien tallennukselle  
2. Luo ydintoiminnot pohjien CRUD-operaatioihin  
3. Toteuta versiointijärjestelmä  
4. Rakenna hyväksymistyönkulku  
5. Kehitä testauskehys  
6. Luo yksinkertainen web-käyttöliittymä hallintaan  
7. Integroi MCP-palvelimen kanssa

**Technologies:** Valitse oma backend-kehys, SQL- tai NoSQL-tietokanta ja frontend-kehys hallintaliittymälle.

### Project 3: MCP-Based Content Generation Platform

**Objective:** Rakenna sisällöntuotantoalusta, joka hyödyntää MCP:tä tarjotakseen johdonmukaisia tuloksia eri sisältötyypeille.

**Requirements:**  
- Tuki useille sisältömuodoille (blogikirjoitukset, sosiaalinen media, markkinointitekstit)  
- Toteuta pohjapohjainen generointi muokkausmahdollisuuksilla  
- Luo sisältöjen arviointi- ja palautteenantojärjestelmä  
- Seuraa sisällön suorituskykymittareita  
- Tuki sisällön versiointia ja iterointia

**Implementation Steps:**  
1. Perusta MCP-asiakasinfrastruktuuri  
2. Luo pohjat eri sisältötyypeille  
3. Rakenna sisällöntuotantoputki  
4. Toteuta arviointijärjestelmä  
5. Kehitä mittareiden seuranta  
6. Luo käyttöliittymä pohjien hallintaan ja sisällöntuotantoon

**Technologies:** Valitse oma ohjelmointikieli, web-kehys ja tietokantajärjestelmä.

## Future Directions for MCP Technology

### Emerging Trends

1. **Multi-Modal MCP**  
   - MCP:n laajentaminen standardoimaan vuorovaikutuksia kuvan, äänen ja videon mallien kanssa  
   - Ristimodaalisen päättelyn kehitys  
   - Standardoidut kehotemuodot eri modalityille

2. **Federated MCP Infrastructure**  
   - Hajautetut MCP-verkostot, jotka voivat jakaa resursseja organisaatioiden välillä  
   - Standardoidut protokollat turvalliseen mallien jakamiseen  
   - Yksityisyyttä suojaavat laskentamenetelmät

3. **MCP Marketplaces**  
   - Ekosysteemit MCP-pohjaisten pohjien ja lisäosien jakamiseen ja kaupallistamiseen  
   - Laadunvarmistus ja sertifiointiprosessit  
   - Integraatio mallimarkkinoiden kanssa

4. **MCP for Edge Computing**  
   - MCP-standardien sovittaminen resurssirajoitteisille reunalaitteille  
   - Optimoidut protokollat matalan kaistanleveyden ympäristöihin  
   - Erikoistuneet MCP-toteutukset IoT-ekosysteemeille

5. **Regulatory Frameworks**  
   - MCP-laajennusten kehitys sääntelynmukaisuuden tukemiseksi  
   - Standardoidut auditointijäljet ja selitettävyyden rajapinnat  
   - Integraatio nousevien tekoälyn hallintakehysten kanssa

### MCP Solutions from Microsoft 

Microsoft ja Azure ovat kehittäneet useita avoimen lähdekoodin repositorioita, jotka auttavat kehittäjiä toteuttamaan MCP:tä erilaisissa skenaarioissa:

#### Microsoft Organization  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – Playwright MCP -palvelin selaimen automaatioon ja testaukseen  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – OneDrive MCP -palvelintoteutus paikalliseen testaukseen ja yhteisön panoksiin  
3. [NLWeb](https://
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
3. Tutki toimiala, jota ei ole käsitelty tapaustutkimuksissa, ja hahmottele, miten MCP voisi ratkaista sen erityisiä haasteita.
4. Tutustu johonkin tulevaisuuden suuntaukseen ja luo konsepti uudelle MCP-laajennukselle sen tukemiseksi.

Seuraava: [Best Practices](../08-BestPractices/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäiskielellä tulee pitää auktoritatiivisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.