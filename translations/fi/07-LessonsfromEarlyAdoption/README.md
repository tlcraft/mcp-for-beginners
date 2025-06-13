<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T17:22:36+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "fi"
}
-->
# Lessons from Early Adopters

## Overview

Tässä oppitunnissa tarkastellaan, miten varhaiset käyttäjät ovat hyödyntäneet Model Context Protocolia (MCP) ratkaistakseen todellisia haasteita ja edistääkseen innovaatioita eri toimialoilla. Yksityiskohtaisten tapaustutkimusten ja käytännön projektien avulla näet, miten MCP mahdollistaa standardoidun, turvallisen ja skaalautuvan tekoälyn integroinnin – yhdistäen suuria kielimalleja, työkaluja ja yritysten dataa yhtenäiseen kehykseen. Saat käytännön kokemusta MCP-pohjaisten ratkaisujen suunnittelusta ja rakentamisesta, opit todetuista toteutusmalleista ja löydät parhaat käytännöt MCP:n käyttöönottoon tuotantoympäristöissä. Oppitunti korostaa myös nousevia trendejä, tulevia suuntauksia ja avoimen lähdekoodin resursseja, jotka auttavat pysymään MCP-teknologian ja sen kehittyvän ekosysteemin kärjessä.

## Learning Objectives

- Analysoida todellisia MCP-toteutuksia eri toimialoilla
- Suunnitella ja rakentaa kokonaisia MCP-pohjaisia sovelluksia
- Tutkia nousevia trendejä ja tulevia suuntauksia MCP-teknologiassa
- Soveltaa parhaita käytäntöjä todellisissa kehitystilanteissa

## Real-world MCP Implementations

### Case Study 1: Enterprise Customer Support Automation

Monikansallinen yritys otti käyttöön MCP-pohjaisen ratkaisun standardoidakseen tekoälyvuorovaikutukset asiakastukijärjestelmissään. Tämä mahdollisti:

- Yhdenmukaisen käyttöliittymän useille LLM-palveluntarjoajille
- Johdonmukaisen prompttien hallinnan eri osastojen välillä
- Vahvojen turvallisuus- ja vaatimustenmukaisuuskontrollien toteuttamisen
- Helpon siirtymisen eri tekoälymallien välillä tarpeiden mukaan

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

Terveydenhuollon palveluntarjoaja kehitti MCP-infrastruktuurin integroidakseen useita erikoistuneita lääketieteellisiä tekoälymalleja samalla varmistaen, että arkaluonteiset potilastiedot pysyivät suojattuina:

- Saumaton siirtyminen yleis- ja erikoismallien välillä
- Tiukat tietosuojakontrollit ja auditointijäljet
- Integrointi olemassa oleviin sähköisiin potilastietojärjestelmiin (EHR)
- Johdonmukainen prompttien suunnittelu lääketieteelliseen terminologiaan

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

**Results:** Parannettu diagnostiikka lääkäreille, täydellinen HIPAA-vaatimustenmukaisuus ja merkittävä kontekstinvaihdon väheneminen järjestelmien välillä.

### Case Study 3: Financial Services Risk Analysis

Rahoituslaitos otti MCP:n käyttöön standardoidakseen riskianalyysiprosessinsa eri osastoilla:

- Yhtenäinen käyttöliittymä luottoriskin, petosten tunnistuksen ja sijoitusriskin malleille
- Tiukat käyttöoikeuskontrollit ja malliversioiden hallinta
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

**Results:** Parantunut sääntelynmukaisuus, 40 % nopeammat mallien käyttöönottoajat ja parantunut riskinarvioinnin johdonmukaisuus osastoilla.

### Case Study 4: Microsoft Playwright MCP Server for Browser Automation

Microsoft kehitti [Playwright MCP serverin](https://github.com/microsoft/playwright-mcp) mahdollistamaan turvallisen ja standardoidun selainautomaation Model Context Protocolin avulla. Tämä ratkaisu mahdollistaa tekoälyagenttien ja LLM:ien vuorovaikutuksen verkkoselaimien kanssa hallitulla, auditoitavalla ja laajennettavalla tavalla – mahdollistaen esimerkiksi automatisoidun web-testaamisen, datan poiminnan ja kokonaisvaltaiset työnkulut.

- Tarjoaa selainautomaatiotoiminnot (navigointi, lomakkeiden täyttö, kuvakaappausten ottaminen jne.) MCP-työkaluina
- Toteuttaa tiukat käyttöoikeudet ja hiekkalaatikkoympäristön estämään luvattomat toimet
- Tarjoaa yksityiskohtaiset auditointilokit kaikista selainvuorovaikutuksista
- Tukee integraatiota Azure OpenAI:n ja muiden LLM-palveluntarjoajien kanssa agenttipohjaiseen automaatioon

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
- Vähensi manuaalisen testauksen tarvetta ja paransi testikattavuutta web-sovelluksissa  
- Tarjosi uudelleenkäytettävän ja laajennettavan kehyksen selainpohjaisten työkalujen integrointiin yritysympäristöissä  

**References:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Case Study 5: Azure MCP – Enterprise-Grade Model Context Protocol as a Service

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) on Microsoftin hallinnoima, yritystason toteutus Model Context Protocolista, joka tarjoaa skaalautuvat, turvalliset ja vaatimustenmukaiset MCP-palvelinominaisuudet pilvipalveluna. Azure MCP mahdollistaa organisaatioiden nopean MCP-palvelimien käyttöönoton, hallinnan ja integroinnin Azure AI:n, datan ja turvallisuuspalveluiden kanssa, vähentäen operatiivista kuormaa ja nopeuttaen tekoälyn käyttöönottoa.

- Täysin hallinnoitu MCP-palvelin, jossa sisäänrakennettu skaalautuvuus, valvonta ja turvallisuus
- Natiivi integraatio Azure OpenAI:n, Azure AI Searchin ja muiden Azuren palveluiden kanssa
- Yritystason tunnistus ja valtuutus Microsoft Entra ID:n kautta
- Tuki räätälöidyille työkaluille, prompttimalleille ja resurssiliittimille
- Vaatimustenmukaisuus yritysturvallisuuden ja sääntelyn kanssa

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
- Lyhensi yritysten tekoälyprojektien aika-arvoa valmiilla, vaatimustenmukaisella MCP-palvelinalustalla  
- Yksinkertaisti LLM:ien, työkalujen ja yritysdatalähteiden integrointia  
- Paransi MCP-kuormien turvallisuutta, havaittavuutta ja operatiivista tehokkuutta  

**References:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Case Study 6: NLWeb  
MCP (Model Context Protocol) on nouseva protokolla chatbotien ja tekoälyavustajien työkalujen kanssa kommunikointiin. Jokainen NLWeb-instanssi on myös MCP-palvelin, joka tukee yhtä ydintoimintoa, ask, jota käytetään verkkosivustolle luonnollisella kielellä esitettävien kysymysten esittämiseen. Vastauksessa hyödynnetään schema.orgia, laajasti käytettyä sanastoa verkkodatan kuvaamiseen. Vapaasti ilmaistuna MCP on NLWeb suhteessa HTTP:hen kuten HTML on HTTP:lle. NLWeb yhdistää protokollat, Schema.org-formaatit ja esimerkkikoodin auttaakseen sivustoja luomaan nopeasti näitä rajapintoja, hyödyttäen sekä ihmisiä keskustelupohjaisten käyttöliittymien kautta että koneita luonnollisen agenttien välisen vuorovaikutuksen avulla.

NLWebissä on kaksi erillistä osaa:  
- Protokolla, joka on aluksi hyvin yksinkertainen, rajapinta sivustolle luonnollisella kielellä ja vastausformaatti, joka hyödyntää jsonia ja schema.orgia. Katso REST API:n dokumentaatio lisätietoja varten.  
- Yksinkertainen toteutus (1):stä, joka hyödyntää olemassa olevaa merkintää, sivustoille, jotka voidaan abstrahoida kohdelistoiksi (tuotteet, reseptit, nähtävyydet, arvostelut jne.). Yhdessä käyttöliittymäwidgettien kanssa sivustot voivat helposti tarjota keskustelupohjaisia käyttöliittymiä sisältöönsä. Katso Life of a chat query -dokumentaatio lisätietoja toiminnasta.

**References:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Case Study 7: MCP for Foundry – Integrating Azure AI Agents

Azure AI Foundry MCP -palvelimet osoittavat, miten MCP:tä voidaan käyttää AI-agenttien ja työnkulkujen orkestrointiin ja hallintaan yritysympäristöissä. Integroimalla MCP Azure AI Foundryn kanssa organisaatiot voivat standardoida agenttien vuorovaikutukset, hyödyntää Foundryn työnkulunhallintaa ja varmistaa turvalliset, skaalautuvat käyttöönotot. Tämä lähestymistapa mahdollistaa nopean prototypoinnin, vahvan valvonnan ja saumattoman integraation Azure AI -palveluihin, tukien kehittyneitä skenaarioita, kuten tiedonhallintaa ja agenttien arviointia. Kehittäjät hyötyvät yhtenäisestä käyttöliittymästä agenttiputkien rakentamiseen, käyttöönottoon ja valvontaan, kun taas IT-tiimit saavat parannettua turvallisuutta, vaatimustenmukaisuutta ja operatiivista tehokkuutta. Ratkaisu on ihanteellinen yrityksille, jotka haluavat nopeuttaa tekoälyn käyttöönottoa ja hallita monimutkaisia agenttiohjattuja prosesseja.

**References:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Case Study 8: Foundry MCP Playground – Experimentation and Prototyping

Foundry MCP Playground tarjoaa valmiin ympäristön MCP-palvelimien ja Azure AI Foundry -integraatioiden kokeiluun. Kehittäjät voivat nopeasti prototypoida, testata ja arvioida tekoälymalleja ja agenttityönkulkuja hyödyntäen Azure AI Foundry Catalogin ja Labsin resursseja. Playground helpottaa käyttöönottoa, tarjoaa esimerkkiprojekteja ja tukee yhteistyökehitystä, tehden parhaiden käytäntöjen ja uusien skenaarioiden tutkimisesta vaivatonta. Se on erityisen hyödyllinen tiimeille, jotka haluavat validoida ideoita, jakaa kokeiluja ja nopeuttaa oppimista ilman monimutkaista infrastruktuuria. Alhaisemman kynnysarvon ansiosta playground edistää innovointia ja yhteisön panoksia MCP- ja Azure AI Foundry -ekosysteemissä.

**References:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Case Study 9. Microsoft Docs MCP Server - Learning and Skilling  
Microsoft Docs MCP Server toteuttaa Model Context Protocol (MCP) -palvelimen, joka tarjoaa tekoälyavustajille reaaliaikaisen pääsyn viralliseen Microsoftin dokumentaatioon. Suorittaa semanttisen haun Microsoftin virallista teknistä dokumentaatiota vastaan.

**References:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## Hands-on Projects

### Project 1: Build a Multi-Provider MCP Server

**Objective:** Luo MCP-palvelin, joka osaa ohjata pyynnöt useille eri tekoälymallien tarjoajille määriteltyjen kriteerien perusteella.

**Requirements:**  
- Tuki vähintään kolmelle eri mallin tarjoajalle (esim. OpenAI, Anthropic, paikalliset mallit)  
- Reititysmekanismi pyyntöjen metatietojen perusteella  
- Konfiguraatiojärjestelmä tarjoajien tunnistetietojen hallintaan  
- Välimuisti suorituskyvyn ja kustannusten optimointiin  
- Yksinkertainen hallintapaneeli käytön seurantaan  

**Implementation Steps:**  
1. Perusta MCP-palvelimen infrastruktuuri  
2. Toteuta tarjoajakohtaiset adapterit jokaiselle AI-mallipalvelulle  
3. Luo reitityslogiikka pyyntöjen attribuuttien perusteella  
4. Lisää välimuistimekanismit usein toistuviin pyyntöihin  
5. Kehitä seuranta-hallintapaneeli  
6. Testaa erilaisilla pyyntökuvioilla  

**Technologies:** Valitse Python (.NET/Java/Python mieltymyksesi mukaan), Redis välimuistiin ja kevyt web-kehys hallintapaneelille.

### Project 2: Enterprise Prompt Management System

**Objective:** Kehitä MCP-pohjainen järjestelmä prompttimallien hallintaan, versiointiin ja käyttöönottoon organisaation laajuisesti.

**Requirements:**  
- Keskitetty varasto prompttimalleille  
- Versiointi- ja hyväksyntätyönkulut  
- Mallien testausominaisuudet esimerkkisyötteillä  
- Roolipohjaiset käyttöoikeudet  
- API mallien hakemiseen ja käyttöönottoon  

**Implementation Steps:**  
1. Suunnittele tietokantakaavio mallien tallennukselle  
2. Luo ydintoiminnot mallien CRUD-operaatioille  
3. Toteuta versiointijärjestelmä  
4. Rakenna hyväksyntätyönkulku  
5. Kehitä testauskehys  
6. Luo yksinkertainen web-käyttöliittymä hallintaan  
7. Integroi MCP-palvelimeen  

**Technologies:** Valitse oma backend-kehys, SQL- tai NoSQL-tietokanta ja frontend-kehys hallintaliittymälle.

### Project 3: MCP-Based Content Generation Platform

**Objective:** Rakenna sisällöntuotantoalusta, joka hyödyntää MCP:tä tarjoten johdonmukaisia tuloksia eri sisältötyypeille.

**Requirements:**  
- Tuki useille sisältömuodoille (blogikirjoitukset, sosiaalinen media, markkinointitekstit)  
- Mallipohjainen generointi muokkausmahdollisuuksilla  
- Sisällön tarkastus- ja palautemekanismi  
- Sisällön suorituskykymittarit  
- Sisällön versiointi ja iterointi  

**Implementation Steps:**  
1. Perusta MCP-asiakasinfrastruktuuri  
2. Luo mallipohjat eri sisältötyypeille  
3. Rakenna sisällöntuotantoputki  
4. Toteuta tarkastusjärjestelmä  
5. Kehitä suorituskykymittaristo  
6. Luo käyttöliittymä mallien hallintaan ja sisällöntuotantoon  

**Technologies:** Valitse suosikkiohjelmointikielesi, web-kehys ja tietokantajärjestelmä.

## Future Directions for MCP Technology

### Emerging Trends

1. **Multi-Modal MCP**  
   - MCP:n laajentaminen standardoimaan vuorovaikutuksia kuva-, ääni- ja video-mallien kanssa  
   - Ristiinmodalisten päättelykykyjen kehittäminen  
   - Standardoidut prompttiformaatit eri modaliteeteille  

2. **Federated MCP Infrastructure**  
   - Hajautetut MCP-verkostot, jotka voivat jakaa resursseja organisaatioiden välillä  
   - Standardoidut protokollat turvalliseen mallien jakamiseen  
   - Yksityisyyttä suojaavat laskentatekniikat  

3. **MCP Marketplaces**  
   - Ekosysteemit MCP-mallipohjien ja lisäosien jakamiseen ja kaupallistamiseen  
   - Laadunvarmistus- ja sertifiointiprosessit  
   - Integraatiot mallimarkkinoihin  

4. **MCP for Edge Computing**  
   - MCP-standardien sovittaminen resurssirajoitteisille reunalaitteille  
   - Optimoidut protokollat vähäkaistaisiin ympäristöihin  
   - Erikoistuneet MCP-toteutukset IoT-ekosysteemeille  

5. **Regulatory Frameworks**  
   - MCP-laajennusten kehittäminen sääntelyvaatimusten täyttämiseen  
   - Standardoidut auditointijäljet ja selitettävyyden rajapinnat  
   - Integraatiot nouseviin tekoälyn hallintakehyksiin  

### MCP Solutions from Microsoft  

Microsoft ja Azure ovat kehittäneet useita avoimen lähdekoodin arkistoja, jotka auttavat kehittäjiä MCP:n toteuttamisessa eri tilanteissa:

#### Microsoft Organization  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) –
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
2. Valitse yksi projektiehdotuksista ja laadi yksityiskohtainen tekninen erittely.
3. Tutki toimiala, jota tapaustutkimukset eivät kata, ja hahmottele, miten MCP voisi ratkaista sen erityisiä haasteita.
4. Tutki yhtä tulevaisuuden suuntausta ja luo konsepti uudelle MCP-laajennukselle sen tukemiseksi.

Seuraava: [Parhaat käytännöt](../08-BestPractices/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeiden tietojen osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.