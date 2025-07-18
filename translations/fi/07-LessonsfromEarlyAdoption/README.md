<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6755bc4f6d0293ce6c49cfc5efba0d8e",
  "translation_date": "2025-07-18T10:03:04+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "fi"
}
-->
# 🌟 Oppeja varhaisilta käyttäjiltä

## 🎯 Mitä tämä moduuli käsittelee

Tässä moduulissa tarkastellaan, miten todelliset organisaatiot ja kehittäjät hyödyntävät Model Context Protocolia (MCP) ratkaistakseen käytännön haasteita ja edistääkseen innovaatioita. Yksityiskohtaisten tapaustutkimusten ja käytännön projektien kautta opit, miten MCP mahdollistaa turvallisen, skaalautuvan tekoälyintegraation, joka yhdistää kielimallit, työkalut ja yritystiedot.

### 📚 Katso MCP käytännössä

Haluatko nähdä nämä periaatteet tuotantovalmiissa työkaluissa? Tutustu [**10 Microsoft MCP -palvelimeen, jotka mullistavat kehittäjien tuottavuutta**](microsoft-mcp-servers.md), joissa esitellään oikeita Microsoftin MCP-palvelimia, joita voit käyttää jo tänään.

## Yleiskatsaus

Tässä oppitunnissa tutustutaan siihen, miten varhaiset käyttäjät ovat hyödyntäneet Model Context Protocolia (MCP) ratkaistakseen todellisia haasteita ja edistääkseen innovaatioita eri toimialoilla. Yksityiskohtaisten tapaustutkimusten ja käytännön projektien avulla näet, miten MCP mahdollistaa standardoidun, turvallisen ja skaalautuvan tekoälyintegraation — yhdistäen suuria kielimalleja, työkaluja ja yritystietoja yhtenäiseksi kokonaisuudeksi. Saat käytännön kokemusta MCP-pohjaisten ratkaisujen suunnittelusta ja rakentamisesta, opit todistettuja toteutusmalleja ja parhaat käytännöt MCP:n käyttöönottoon tuotantoympäristöissä. Oppitunti korostaa myös nousevia trendejä, tulevaisuuden suuntauksia ja avoimen lähdekoodin resursseja, jotka auttavat sinua pysymään MCP-teknologian ja sen kehittyvän ekosysteemin kärjessä.

## Oppimistavoitteet

- Analysoida todellisia MCP-toteutuksia eri toimialoilla  
- Suunnitella ja rakentaa kokonaisia MCP-pohjaisia sovelluksia  
- Tutkia MCP-teknologian nousevia trendejä ja tulevaisuuden suuntauksia  
- Soveltaa parhaita käytäntöjä todellisissa kehitystilanteissa  

## Todelliset MCP-toteutukset

### Tapaustutkimus 1: Yrityksen asiakastuen automaatio

Monikansallinen yritys otti käyttöön MCP-pohjaisen ratkaisun standardoidakseen tekoälyvuorovaikutukset asiakastukijärjestelmissään. Tämä mahdollisti:

- Yhdenmukaisen käyttöliittymän useille LLM-palveluntarjoajille  
- Johdonmukaisen kehotteiden hallinnan eri osastoilla  
- Vahvat turvallisuus- ja vaatimustenmukaisuuskontrollit  
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

**Tulokset:** 30 %:n kustannussäästöt malleissa, 45 %:n parannus vastausten johdonmukaisuudessa ja parannettu vaatimustenmukaisuus globaalissa toiminnassa.

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

**Tulokset:** Parantuneet diagnoosiehdotukset lääkäreille, täysi HIPAA-vaatimustenmukaisuus ja merkittävä kontekstinvaihdon väheneminen järjestelmien välillä.

### Tapaustutkimus 3: Rahoituspalveluiden riskianalyysi

Rahoituslaitos otti MCP:n käyttöön standardoidakseen riskianalyysiprosessinsa eri osastoilla:

- Yhtenäinen käyttöliittymä luottoriskin, petostunnistuksen ja sijoitusriskimallien hallintaan  
- Tiukat käyttöoikeuskontrollit ja malliversioiden hallinta  
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

**Tulokset:** Parantunut sääntelynmukaisuus, 40 % nopeammat mallien käyttöönottoajat ja parempi riskinarvioinnin johdonmukaisuus osastojen välillä.

### Tapaustutkimus 4: Microsoft Playwright MCP -palvelin selainautomaatiolle

Microsoft kehitti [Playwright MCP -palvelimen](https://github.com/microsoft/playwright-mcp) mahdollistamaan turvallisen ja standardoidun selainautomaation Model Context Protocolin avulla. Tämä tuotantovalmiiksi suunniteltu palvelin antaa tekoälyagenttien ja LLM:ien olla vuorovaikutuksessa verkkoselainten kanssa hallitusti, auditoitavasti ja laajennettavasti — mahdollistaen käyttötapauksia kuten automatisoitu verkkotestaus, tiedonkeruu ja kokonaisvaltaiset työnkulut.

> **🎯 Tuotantovalmis työkalu**  
> Tämä tapaustutkimus esittelee oikean MCP-palvelimen, jota voit käyttää jo tänään! Lue lisää Playwright MCP -palvelimesta ja muista 9 tuotantovalmiista Microsoft MCP -palvelimesta [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#8--playwright-mcp-server).

**Keskeiset ominaisuudet:**  
- Selainautomaatiotoiminnot (navigointi, lomakkeiden täyttö, kuvakaappaukset jne.) MCP-työkaluina  
- Tiukat käyttöoikeuskontrollit ja hiekkalaatikkototeutus luvattomien toimien estämiseksi  
- Yksityiskohtaiset auditointilokit kaikista selaintoiminnoista  
- Integraatio Azure OpenAI:n ja muiden LLM-palveluntarjoajien kanssa agenttiohjattuun automaatioon  
- GitHub Copilotin Coding Agentin selainominaisuuksien voimanlähde  

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
- Vähensi manuaalista testaustyötä ja paransi testikattavuutta verkkosovelluksissa  
- Tarjosi uudelleenkäytettävän ja laajennettavan kehyksen selainpohjaisten työkalujen integrointiin yritysympäristöissä  
- Voimisti GitHub Copilotin selainominaisuuksia  

**Viitteet:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Tapaustutkimus 5: Azure MCP – Yritystason Model Context Protocol palveluna

Azure MCP Server ([https://aka.ms/azmcp](https://aka.ms/azmcp)) on Microsoftin hallinnoima, yritystason toteutus Model Context Protocolista, suunniteltu tarjoamaan skaalautuvia, turvallisia ja vaatimustenmukaisia MCP-palvelinominaisuuksia pilvipalveluna. Azure MCP mahdollistaa organisaatioiden nopean MCP-palvelimien käyttöönoton, hallinnan ja integroinnin Azure AI:n, datan ja turvallisuuspalveluiden kanssa, vähentäen operatiivista kuormaa ja nopeuttaen tekoälyn käyttöönottoa.

> **🎯 Tuotantovalmis työkalu**  
> Tämä on oikea MCP-palvelin, jota voit käyttää jo tänään! Lue lisää Azure AI Foundry MCP Serveristä [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md).

- Täysin hallinnoitu MCP-palvelimen isännöinti sisäänrakennetulla skaalaus-, valvonta- ja turvallisuusominaisuuksilla  
- Natiivinen integraatio Azure OpenAI:n, Azure AI Searchin ja muiden Azure-palveluiden kanssa  
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
- Paransi MCP-kuormien turvallisuutta, havaittavuutta ja operatiivista tehokkuutta  
- Paransi koodin laatua Azure SDK:n parhaiden käytäntöjen ja nykyisten tunnistusmallien avulla  

**Viitteet:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure MCP Server GitHub Repository](https://github.com/Azure/azure-mcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

### Tapaustutkimus 6: NLWeb – Luonnollisen kielen verkkoliittymäprotokolla

NLWeb edustaa Microsoftin visiota perustavanlaatuisesta kerroksesta tekoälyverkolle. Jokainen NLWeb-instanssi on myös MCP-palvelin, joka tukee yhtä ydintoimintoa, `ask`, jolla voi esittää verkkosivustolle kysymyksen luonnollisella kielellä. Palautettu vastaus hyödyntää schema.orgia, laajasti käytettyä sanastoa verkkodatan kuvaamiseen. Vapaasti ilmaistuna MCP on NLWebille sama kuin HTTP on HTML:lle.

**Keskeiset ominaisuudet:**  
- **Protokollakerros**: Yksinkertainen protokolla verkkosivustoille luonnollisen kielen kyselyihin  
- **Schema.org-muoto**: Hyödyntää JSON:ia ja schema.orgia rakenteellisiin, koneellisesti luettaviin vastauksiin  
- **Yhteisön toteutus**: Helppo toteuttaa sivustoille, jotka voidaan esittää listana kohteita (tuotteet, reseptit, nähtävyydet, arvostelut jne.)  
- **Käyttöliittymäkomponentit**: Valmiit käyttöliittymäelementit keskustelupohjaisiin rajapintoihin  

**Arkkitehtuurin osat:**  
1. **Protokolla**: Yksinkertainen REST-rajapinta luonnollisen kielen kyselyille verkkosivustoille  
2. **Toteutus**: Hyödyntää olemassa olevaa merkintää ja sivuston rakennetta automaattisiin vastauksiin  
3. **Käyttöliittymäkomponentit**: Valmiit komponentit keskustelurajapintojen integrointiin  

**Hyödyt:**  
- Mahdollistaa sekä ihmisen että agentin vuorovaikutuksen sivustojen kanssa  
- Tarjoaa rakenteellisia datavastauksia, joita tekoälyjärjestelmät voivat helposti käsitellä  
- Nopea käyttöönotto listapohjaisille sisältörakenteille  
- Standardoitu lähestymistapa verkkosivustojen tekoälykäyttöisyyden parantamiseen  

**Tulokset:**  
- Perusta tekoälyverkon vuorovaikutusstandardeille  
- Keskustelurajapintojen luomisen yksinkertaistaminen sisältösivustoille  
- Parantunut löydettävyys ja saavutettavuus tekoälyjärjestelmille  
- Edisti eri tekoälyagenttien ja verkkopalveluiden yhteentoimivuutta  

**Viitteet:**  
- [NLWeb GitHub Repository](https://github.com/microsoft/NlWeb)  
- [NLWeb Documentation](https://github.com/microsoft/NlWeb)

### Tapaustutkimus 7: Azure AI Foundry MCP Server – Yritystason tekoälyagenttien integraatio

Azure AI Foundry MCP -palvelimet osoittavat, miten MCP:tä voidaan käyttää tekoälyagenttien ja työnkulkujen orkestrointiin ja hallintaan yritysympäristöissä. Integroimalla MCP Azure AI Foundryn kanssa organisaatiot voivat standardoida agenttien vuorovaikutukset, hyödyntää Foundryn työnkulun hallintaa ja varmistaa turvalliset, skaalautuvat käyttöönotot.

> **🎯 Tuotantovalmis työkalu**  
> Tämä on oikea MCP-palvelin, jota voit käyttää jo tänään! Lue lisää Azure AI Foundry MCP Serveristä [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#9--azure-ai-foundry-mcp-server).

**Keskeiset ominaisuudet:**  
- Laaja pääsy Azuren tekoälyekosysteemiin, mukaan lukien malliluettelot ja käyttöönoton hallinta  
- Tietämyksen indeksointi Azure AI Searchilla RAG-sovelluksiin  
- Arviointityökalut tekoälymallien suorituskyvyn ja laadun varmistukseen  
- Integraatio Azure AI Foundry Catalogin ja Labsin huippututkimusmalleihin  
- Agenttien hallinta ja arviointimahdollisuudet tuotantotilanteissa  

**Tulokset:**  
- Nopea prototypointi ja vahva valvonta tekoälyagenttien työnkuluissa  
- Saumaton integraatio Azure AI -palveluihin edistyneissä käyttötapauksissa  
- Yhtenäinen käyttöliittymä agenttiputkien rakentamiseen, käyttöönottoon ja valvontaan  
- Parannettu turvallisuus, vaatimustenmukaisuus ja operatiivinen tehokkuus yrityksissä  
- Nopeutettu tekoälyn käyttöönotto säilyttäen hallinta monimutkaisissa agenttiohjatuissa prosesseissa  

**Viitteet:**  
- [Azure AI Foundry MCP Server GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Tapaustutkimus 8: Foundry MCP Playground – Kokeilu ja prototypointi

Foundry MCP Playground tarjoaa valmiin ympäristön MCP-palvelimien ja Azure AI Foundry -integraatioiden kokeiluun. Kehittäjät voivat nopeasti prototypoida, testata ja arvioida tekoälymalleja ja agenttien työnkulkuja hyödyntäen Azure AI Foundry Catalogin ja Labsin resursseja. Playground helpottaa käyttöönottoa, tarjoaa esimerkkiprojekteja ja tukee yhteiskehitystä, tehden parhaiden käytäntöjen ja uusien skenaarioiden tutkimisesta vaivatonta. Se on erityisen hyödyllinen tiimeille, jotka haluavat validoida ideoita, jakaa kokeiluja ja nopeuttaa oppimista ilman monimutkaista infrastruktuuria. Alentamalla kynnystä, playground edistää innovaatioita ja yhteisön panoksia MCP- ja Azure AI Foundry -ekosysteemissä.

**Viitteet:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Tapaustutkimus 9: Microsoft Learn Docs MCP Server – Tekoälyavusteinen dokumentaatio

Microsoft Learn Docs MCP Server on pilvipalveluna toimiva palvelin, joka tarjoaa tekoälyavustajille reaaliaikaisen pääsyn viralliseen Microsoftin dokumentaatioon Model Context Protocolin kautta. Tämä tuotantovalmiiksi suunniteltu palvelin yhdistää laajan Microsoft Learn -ekosysteemin ja mahdollistaa semanttisen haun kaikista virallisista Microsoftin lähteistä.
> **🎯 Tuotantovalmiit työkalut**
> 
> Tämä on oikea MCP-palvelin, jota voit käyttää jo tänään! Lue lisää Microsoft Learn Docs MCP Serveristä oppaastamme [**Microsoft MCP Servers Guide**](microsoft-mcp-servers.md#1--microsoft-learn-docs-mcp-server).
**Keskeiset ominaisuudet:**
- Reaaliaikainen pääsy viralliseen Microsoft-dokumentaatioon, Azure-dokumentaatioon ja Microsoft 365 -dokumentaatioon
- Edistyneet semanttiset hakutoiminnot, jotka ymmärtävät kontekstin ja tarkoituksen
- Aina ajan tasalla oleva tieto, kun Microsoft Learn -sisältö julkaistaan
- Laaja kattavuus Microsoft Learnista, Azure-dokumentaatiosta ja Microsoft 365 -lähteistä
- Palauttaa jopa 10 korkealaatuista sisältölohkoa artikkelien otsikoiden ja URL-osoitteiden kanssa

**Miksi se on kriittistä:**
- Ratkaisee "vanhentuneen tekoälytiedon" ongelman Microsoft-teknologioissa
- Varmistaa, että tekoälyavustajilla on pääsy uusimpiin .NET-, C#-, Azure- ja Microsoft 365 -ominaisuuksiin
- Tarjoaa auktoritatiivista, ensikäden tietoa tarkkaan koodin generointiin
- Välttämätöntä kehittäjille, jotka työskentelevät nopeasti kehittyvien Microsoft-teknologioiden parissa

**Tulokset:**
- Merkittävästi parantunut tekoälyn generoiman koodin tarkkuus Microsoft-teknologioissa
- Vähemmän aikaa kuluu ajantasaisen dokumentaation ja parhaiden käytäntöjen etsimiseen
- Parantunut kehittäjien tuottavuus kontekstia ymmärtävän dokumentaation haun avulla
- Saumaton integrointi kehitystyönkulkuun ilman, että tarvitsee poistua IDE:stä

**Viitteet:**
- [Microsoft Learn Docs MCP Server GitHub Repository](https://github.com/MicrosoftDocs/mcp)
- [Microsoft Learn Documentation](https://learn.microsoft.com/)

## Käytännön projektit

### Projekti 1: Monitoimittajainen MCP-palvelin

**Tavoite:** Luo MCP-palvelin, joka voi ohjata pyyntöjä useille tekoälymallien tarjoajille tiettyjen kriteerien perusteella.

**Vaatimukset:**
- Tuki vähintään kolmelle eri mallin tarjoajalle (esim. OpenAI, Anthropic, paikalliset mallit)
- Reititysmekanismin toteutus pyyntöjen metatietojen perusteella
- Konfigurointijärjestelmän luominen tarjoajien tunnistetietojen hallintaan
- Välimuistin lisääminen suorituskyvyn ja kustannusten optimointiin
- Yksinkertaisen hallintapaneelin rakentaminen käytön seurantaan

**Toteutusvaiheet:**
1. Perus MCP-palvelininfrastruktuurin pystytys
2. Tarjoajakohtaisten adapterien toteutus jokaiselle tekoälymallipalvelulle
3. Reitityslogiikan luominen pyyntöjen ominaisuuksien perusteella
4. Välimuistimekanismien lisääminen usein toistuviin pyyntöihin
5. Seurantapaneelin kehittäminen
6. Testaus erilaisilla pyyntökuvioilla

**Teknologiat:** Valitse Python (.NET/Java/Python mieltymyksesi mukaan), Redis välimuistiksi ja yksinkertainen web-kehys hallintapaneelille.

### Projekti 2: Yritystason kehotteiden hallintajärjestelmä

**Tavoite:** Kehitä MCP-pohjainen järjestelmä kehotteiden mallipohjien hallintaan, versiointiin ja käyttöönottoon organisaation sisällä.

**Vaatimukset:**
- Keskitetyn mallipohjarekisterin luominen kehotteille
- Versioinnin ja hyväksymisprosessien toteutus
- Mallipohjien testausmahdollisuuksien rakentaminen esimerkkisyötteillä
- Roolipohjaisten käyttöoikeuksien kehittäminen
- API mallipohjien hakemiseen ja käyttöönottoon

**Toteutusvaiheet:**
1. Tietokantakaavion suunnittelu mallipohjien tallennusta varten
2. Ydintoiminnallisuuden luominen mallipohjien CRUD-operaatioille
3. Versiointijärjestelmän toteutus
4. Hyväksymisprosessin rakentaminen
5. Testauskehyksen kehittäminen
6. Yksinkertaisen web-käyttöliittymän luominen hallintaan
7. Integrointi MCP-palvelimeen

**Teknologiat:** Valitse haluamasi backend-kehys, SQL- tai NoSQL-tietokanta ja frontend-kehys hallintaliittymälle.

### Projekti 3: MCP-pohjainen sisällöntuotantoalusta

**Tavoite:** Rakenna sisällöntuotantoalusta, joka hyödyntää MCP:tä tarjotakseen johdonmukaisia tuloksia eri sisältötyypeille.

**Vaatimukset:**
- Tuki useille sisältömuodoille (blogikirjoitukset, sosiaalinen media, markkinointitekstit)
- Mallipohjainen generointi mukautusmahdollisuuksilla
- Sisällön tarkastus- ja palautteenantojärjestelmä
- Sisällön suorituskykymittareiden seuranta
- Sisällön versiointi ja iterointi

**Toteutusvaiheet:**
1. MCP-asiakasinfrastruktuurin pystytys
2. Mallipohjien luominen eri sisältötyypeille
3. Sisällöntuotantoputken rakentaminen
4. Tarkastusjärjestelmän toteutus
5. Mittariseurantajärjestelmän kehittäminen
6. Käyttöliittymän luominen mallipohjien hallintaan ja sisällöntuotantoon

**Teknologiat:** Valitse oma suosikkiohjelmointikielesi, web-kehys ja tietokantajärjestelmä.

## MCP-teknologian tulevaisuuden suuntaukset

### Nousevat trendit

1. **Monimodaalinen MCP**
   - MCP:n laajentaminen vakioimaan vuorovaikutukset kuvan, äänen ja videon mallien kanssa
   - Ristimodaalisten päättelykykyjen kehittäminen
   - Vakioidut kehotemuodot eri modaliteeteille

2. **Federatiivinen MCP-infrastruktuuri**
   - Hajautetut MCP-verkostot, jotka voivat jakaa resursseja organisaatioiden välillä
   - Vakioidut protokollat turvalliseen mallien jakamiseen
   - Yksityisyyttä suojaavat laskentatekniikat

3. **MCP-markkinapaikat**
   - Ekosysteemit MCP-mallipohjien ja lisäosien jakamiseen ja kaupallistamiseen
   - Laadunvarmistus- ja sertifiointiprosessit
   - Integraatio mallimarkkinapaikkoihin

4. **MCP reunalaskennassa**
   - MCP-standardien sovittaminen resurssirajoitteisille reunalaitteille
   - Optimoidut protokollat vähäkaistaisiin ympäristöihin
   - Erityiset MCP-toteutukset IoT-ekosysteemeille

5. **Sääntelykehykset**
   - MCP-laajennusten kehittäminen sääntelyn noudattamiseksi
   - Vakioidut auditointilokit ja selitettävyyden rajapinnat
   - Integraatio nouseviin tekoälyn hallintakehyksiin

### Microsoftin MCP-ratkaisut

Microsoft ja Azure ovat kehittäneet useita avoimen lähdekoodin repositorioita auttamaan kehittäjiä MCP:n toteuttamisessa eri tilanteissa:

#### Microsoft Organization
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – Playwright MCP -palvelin selaimen automaatioon ja testaukseen
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – OneDrive MCP -palvelintoteutus paikalliseen testaukseen ja yhteisön kontribuutioihin
3. [NLWeb](https://github.com/microsoft/NlWeb) – NLWeb on kokoelma avoimia protokollia ja niihin liittyviä avoimen lähdekoodin työkaluja. Sen pääpaino on perustason luomisessa tekoälyverkolle

#### Azure-Samples Organization
1. [mcp](https://github.com/Azure-Samples/mcp) – Linkkejä esimerkkeihin, työkaluihin ja resursseihin MCP-palvelinten rakentamiseen ja integrointiin Azurella useilla kielillä
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) – Referenssipohjaiset MCP-palvelimet, jotka demonstroivat autentikointia nykyisen Model Context Protocol -määritelmän mukaisesti
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – Alkusivusto etä-MCP-palvelintoteutuksille Azure Functionsissa kielikohtaisilla repositorioilla
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Pikakäynnistysmalli räätälöityjen etä-MCP-palvelinten rakentamiseen ja käyttöönottoon Azure Functionsilla Pythonilla
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Pikakäynnistysmalli räätälöityjen etä-MCP-palvelinten rakentamiseen ja käyttöönottoon Azure Functionsilla .NET/C#:lla
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Pikakäynnistysmalli räätälöityjen etä-MCP-palvelinten rakentamiseen ja käyttöönottoon Azure Functionsilla TypeScriptillä
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) – Azure API Management tekoälyporttina etä-MCP-palvelimille Pythonilla
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) – APIM ❤️ tekoälykokeiluja, mukaan lukien MCP-ominaisuudet, integroitu Azure OpenAI:hin ja AI Foundryyn

Nämä repositoriot tarjoavat erilaisia toteutuksia, mallipohjia ja resursseja Model Context Protocolin käyttöön eri ohjelmointikielillä ja Azure-palveluissa. Ne kattavat laajan kirjon käyttötapauksia peruspalvelimista autentikointiin, pilvikäyttöönottoon ja yritysintegrointiin.

#### MCP Resources -hakemisto

Virallisessa Microsoft MCP -repositoriossa oleva [MCP Resources -hakemisto](https://github.com/microsoft/mcp/tree/main/Resources) tarjoaa valikoiman esimerkkiresursseja, kehotemalleja ja työkalumääritelmiä Model Context Protocol -palvelimien käyttöön. Tämä hakemisto on suunniteltu auttamaan kehittäjiä pääsemään nopeasti alkuun MCP:n kanssa tarjoamalla uudelleenkäytettäviä rakennuspalikoita ja parhaiden käytäntöjen esimerkkejä:

- **Kehotemallit:** Valmiita kehotemalleja yleisiin tekoälytehtäviin ja -tilanteisiin, joita voi mukauttaa omiin MCP-palvelintoteutuksiin.
- **Työkalumääritelmät:** Esimerkkityökalujen skeemat ja metatiedot työkalujen integroinnin ja kutsumisen vakioimiseksi eri MCP-palvelimissa.
- **Resurssiesimerkit:** Esimerkkimääritelmiä resurssien yhdistämiseen tietolähteisiin, rajapintoihin ja ulkoisiin palveluihin MCP-kehyksessä.
- **Referenssitoteutukset:** Käytännön esimerkkejä siitä, miten resursseja, kehotteita ja työkaluja voidaan jäsentää ja organisoida todellisissa MCP-projekteissa.

Nämä resurssit nopeuttavat kehitystä, edistävät standardointia ja auttavat varmistamaan parhaat käytännöt MCP-pohjaisten ratkaisujen rakentamisessa ja käyttöönotossa.

#### MCP Resources -hakemisto
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Tutkimusmahdollisuudet

- Tehokkaat kehotteiden optimointitekniikat MCP-kehyksissä
- Turvallisuusmallit monivuokraajaympäristöihin MCP:ssä
- Suorituskyvyn vertailu eri MCP-toteutusten välillä
- Formaalit varmennusmenetelmät MCP-palvelimille

## Yhteenveto

Model Context Protocol (MCP) muokkaa nopeasti tulevaisuutta kohti standardoitua, turvallista ja yhteentoimivaa tekoälyn integrointia eri toimialoilla. Tämän oppitunnin tapaustutkimusten ja käytännön projektien kautta olet nähnyt, miten varhaiset omaksujat – mukaan lukien Microsoft ja Azure – hyödyntävät MCP:tä ratkaistakseen todellisia haasteita, nopeuttaakseen tekoälyn käyttöönottoa sekä varmistaakseen säädösten noudattamisen, turvallisuuden ja skaalautuvuuden. MCP:n modulaarinen lähestymistapa mahdollistaa organisaatioiden yhdistää suuria kielimalleja, työkaluja ja yritystietoja yhtenäiseen, auditoitavaan kehykseen. MCP:n kehittyessä yhteisön aktiivinen seuraaminen, avoimen lähdekoodin resurssien hyödyntäminen ja parhaiden käytäntöjen soveltaminen ovat avainasemassa kestävien, tulevaisuuden tekoälyratkaisujen rakentamisessa.

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
2. Valitse yksi projektiehdotus ja laadi yksityiskohtainen tekninen spesifikaatio.
3. Tutki toimiala, jota ei ole käsitelty tapaustutkimuksissa, ja hahmottele, miten MCP voisi ratkaista sen erityishaasteet.
4. Tutki yhtä tulevaisuuden suuntausta ja luo konsepti uudelle MCP-laajennukselle sen tukemiseksi.

Seuraava: [Microsoft MCP Server](../07-LessonsfromEarlyAdoption/microsoft-mcp-servers.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.