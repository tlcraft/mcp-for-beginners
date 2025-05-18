<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a6482c201133cb6cb0742918b373a523",
  "translation_date": "2025-05-17T16:25:33+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "fi"
}
-->
# Opit varhaisilta omaksujilta

## Yleiskatsaus

Tässä oppitunnissa tarkastellaan, miten varhaiset omaksujat ovat hyödyntäneet Model Context Protocolia (MCP) ratkaistakseen todellisia haasteita ja edistäneet innovaatiota eri toimialoilla. Yksityiskohtaisten tapaustutkimusten ja käytännön projektien kautta näet, miten MCP mahdollistaa standardoidun, turvallisen ja skaalautuvan tekoälyn integroinnin—yhdistäen suuria kielimalleja, työkaluja ja yritysdataa yhtenäiseen kehykseen. Saat käytännön kokemusta MCP-pohjaisten ratkaisujen suunnittelusta ja rakentamisesta, opit todistetuista toteutusmalleista ja löydät parhaat käytännöt MCP:n käyttöönottoon tuotantoympäristöissä. Oppitunnissa korostetaan myös nousevia trendejä, tulevaisuuden suuntauksia ja avoimen lähdekoodin resursseja, jotka auttavat sinua pysymään MCP-teknologian ja sen kehittyvän ekosysteemin eturintamassa.

## Oppimistavoitteet

- Analysoida todellisia MCP-toteutuksia eri toimialoilla
- Suunnitella ja rakentaa täydellisiä MCP-pohjaisia sovelluksia
- Tutkia MCP-teknologian nousevia trendejä ja tulevaisuuden suuntauksia
- Soveltaa parhaita käytäntöjä todellisissa kehitysskenaarioissa

## Todelliset MCP-toteutukset

### Tapaustutkimus 1: Yritysasiakastuen automatisointi

Monikansallinen yritys toteutti MCP-pohjaisen ratkaisun standardoidakseen tekoälyinteraktiot asiakastukijärjestelmissään. Tämä mahdollisti heille:

- Luoda yhtenäinen käyttöliittymä useille LLM-toimittajille
- Säilyttää johdonmukainen kehotteiden hallinta osastojen välillä
- Toteuttaa vahvat turvallisuus- ja vaatimustenmukaisuusvalvonnat
- Vaihtaa helposti eri tekoälymallien välillä erityistarpeiden perusteella

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

**Tulokset:** 30 % vähennys mallikustannuksissa, 45 % parannus vastausten johdonmukaisuudessa ja parantunut vaatimustenmukaisuus maailmanlaajuisissa operaatioissa.

### Tapaustutkimus 2: Terveydenhuollon diagnostiikka-avustaja

Terveydenhuollon tarjoaja kehitti MCP-infrastruktuurin integroidakseen useita erikoistuneita lääketieteellisiä tekoälymalleja samalla kun varmistettiin, että herkät potilastiedot pysyivät suojattuina:

- Saumaton vaihto yleisten ja erikoistuneiden lääketieteellisten mallien välillä
- Tiukat tietosuojavalvonnat ja auditointipolut
- Integrointi olemassa oleviin sähköisiin potilastietojärjestelmiin (EHR)
- Johdonmukainen kehotteiden suunnittelu lääketieteellistä terminologiaa varten

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

**Tulokset:** Parannettu diagnoosiehdotukset lääkäreille samalla kun säilytettiin täydellinen HIPAA-vaatimustenmukaisuus ja merkittävä vähennys järjestelmien välisessä kontekstinvaihdossa.

### Tapaustutkimus 3: Rahoituspalveluiden riskianalyysi

Rahoituslaitos toteutti MCP:n standardoidakseen riskianalyysiprosessinsa eri osastojen välillä:

- Luotiin yhtenäinen käyttöliittymä luottoriskin, petosten havaitsemisen ja sijoitusriskimallien käyttöön
- Toteutettiin tiukat pääsynvalvonnat ja malliversiointi
- Varmistettiin kaikkien tekoälysuositusten auditointi
- Säilytettiin johdonmukainen datan muotoilu eri järjestelmien välillä

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

**Tulokset:** Parannettu sääntelyn noudattaminen, 40 % nopeammat mallien käyttöönottojaksot ja parantunut riskinarvioinnin johdonmukaisuus osastojen välillä.

### Tapaustutkimus 4: Microsoft Playwright MCP Server selaimen automaatioon

Microsoft kehitti [Playwright MCP serverin](https://github.com/microsoft/playwright-mcp) mahdollistamaan turvallisen, standardoidun selaimen automaation Model Context Protocolin kautta. Tämä ratkaisu mahdollistaa tekoälyagenttien ja LLM:ien vuorovaikutuksen verkkoselainten kanssa kontrolloidulla, auditoitavalla ja laajennettavalla tavalla—mahdollistaen käyttötilanteet kuten automatisoitu verkkotestaus, datan poiminta ja end-to-end työnkulut.

- Paljastaa selaimen automaatiokyvykkyydet (navigointi, lomakkeiden täyttö, kuvakaappaus jne.) MCP-työkaluina
- Toteuttaa tiukat pääsynvalvonnat ja hiekkalaatikot estääkseen luvattomat toimet
- Tarjoaa yksityiskohtaiset auditointilokit kaikille selaimen vuorovaikutuksille
- Tukee integraatiota Azure OpenAI:n ja muiden LLM-toimittajien kanssa agenttipohjaiseen automaatioon

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
- Mahdollisti turvallisen, ohjelmallisen selaimen automaation tekoälyagenteille ja LLM:ille
- Vähensi manuaalisen testauksen vaivaa ja paransi testauksen kattavuutta verkkosovelluksille
- Tarjosi uudelleenkäytettävän, laajennettavan kehyksen selaimen työkalujen integraatiolle yritysympäristöissä

**Viitteet:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Tapaustutkimus 5: Azure MCP – Yritystason Model Context Protocol palveluna

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) on Microsoftin hallinnoitu, yritystason Model Context Protocolin toteutus, joka on suunniteltu tarjoamaan skaalautuvia, turvallisia ja vaatimustenmukaisia MCP-palvelinkyvykkyyksiä pilvipalveluna. Azure MCP mahdollistaa organisaatioiden nopean MCP-palvelimien käyttöönoton, hallinnan ja integroinnin Azure AI-, data- ja turvallisuuspalveluiden kanssa, vähentäen operatiivista ylikuormitusta ja nopeuttaen tekoälyn omaksumista.

- Täysin hallinnoitu MCP-palvelimen hosting sisäänrakennetulla skaalauksella, valvonnalla ja turvallisuudella
- Natiivi integraatio Azure OpenAI:n, Azure AI Searchin ja muiden Azure-palveluiden kanssa
- Yritysautentikointi ja -valtuutus Microsoft Entra ID:n kautta
- Tuki mukautetuille työkaluille, kehotemalleille ja resurssiliittimille
- Vaatimustenmukaisuus yritysturvallisuuden ja sääntelyvaatimusten kanssa

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
- Vähensi yritystason tekoälyprojektien aika-arvoa tarjoamalla käyttövalmiin, vaatimustenmukaisen MCP-palvelinalustan
- Yksinkertaisti LLM:ien, työkalujen ja yritysdatapohjien integraatiota
- Paransi turvallisuutta, havaittavuutta ja operatiivista tehokkuutta MCP-työkuormille

**Viitteet:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Käytännön projektit

### Projekti 1: Monitoimittaja MCP-palvelimen rakentaminen

**Tavoite:** Luo MCP-palvelin, joka voi ohjata pyyntöjä useille tekoälymallitoimittajille tiettyjen kriteerien perusteella.

**Vaatimukset:**
- Tuki vähintään kolmelle eri mallitoimittajalle (esim. OpenAI, Anthropic, paikalliset mallit)
- Toteuta reititysmekanismi pyynnön metatietojen perusteella
- Luo konfigurointijärjestelmä toimittajien tunnistetietojen hallintaan
- Lisää välimuisti suorituskyvyn ja kustannusten optimointiin
- Rakenna yksinkertainen hallintapaneeli käytön valvontaan

**Toteutusaskeleet:**
1. Perusta MCP-palvelimen perusinfrastruktuuri
2. Toteuta toimittajasovittimet jokaiselle tekoälymallipalvelulle
3. Luo reitityksen logiikka pyynnön ominaisuuksien perusteella
4. Lisää välimuistimekanismit usein toistuville pyynnöille
5. Kehitä valvontapaneeli
6. Testaa erilaisilla pyyntökuvioilla

**Teknologiat:** Valitse Python (.NET/Java/Python mieltymyksesi mukaan), Redis välimuistille, ja yksinkertainen web-kehys hallintapaneelille.

### Projekti 2: Yrityksen kehotteiden hallintajärjestelmä

**Tavoite:** Kehitä MCP-pohjainen järjestelmä kehotemallien hallintaan, versiointiin ja käyttöönottoon organisaation sisällä.

**Vaatimukset:**
- Luo keskitetty säilö kehotemalleille
- Toteuta versiointi- ja hyväksymistyönkulut
- Rakenna mallien testauskyvykkyydet esimerkkisyötteillä
- Kehitä roolipohjaiset pääsynvalvonnat
- Luo API mallien noutamiseen ja käyttöönottoon

**Toteutusaskeleet:**
1. Suunnittele tietokannan skeema mallien säilytykseen
2. Luo ydin-API mallien CRUD-toiminnoille
3. Toteuta versiointijärjestelmä
4. Rakenna hyväksymistyönkulku
5. Kehitä testauskehys
6. Luo yksinkertainen verkkokäyttöliittymä hallintaan
7. Integroi MCP-palvelimen kanssa

**Teknologiat:** Valitsemasi taustakehys, SQL tai NoSQL-tietokanta, ja etukehys hallintakäyttöliittymälle.

### Projekti 3: MCP-pohjainen sisällöntuotantoalusta

**Tavoite:** Rakenna sisällöntuotantoalusta, joka hyödyntää MCP:tä tuottaakseen johdonmukaisia tuloksia eri sisältötyypeissä.

**Vaatimukset:**
- Tuki useille sisältöformaatteille (blogikirjoitukset, sosiaalinen media, markkinointitekstit)
- Toteuta mallipohjainen tuotanto mukautusvaihtoehdoilla
- Luo sisällön tarkistus- ja palautesysteemi
- Seuraa sisällön suorituskykymetriikoita
- Tuki sisällön versioinnille ja iteroinnille

**Toteutusaskeleet:**
1. Perusta MCP-asiakasinfrastruktuuri
2. Luo mallipohjat eri sisältötyypeille
3. Rakenna sisällöntuotantoputki
4. Toteuta tarkistusjärjestelmä
5. Kehitä metriikoiden seurantasysteemi
6. Luo käyttäjäliittymä mallien hallintaan ja sisällöntuotantoon

**Teknologiat:** Valitsemasi ohjelmointikieli, web-kehys, ja tietokantajärjestelmä.

## Tulevaisuuden suuntaukset MCP-teknologialle

### Nousevat trendit

1. **Monimodaalinen MCP**
   - MCP:n laajentaminen standardisoimaan vuorovaikutuksia kuva-, ääni- ja videomallien kanssa
   - Kehittää monimodaalisia päättelykyvykkyyksiä
   - Standardoidut kehotteiden muodot eri modaliteeteille

2. **Hajautettu MCP-infrastruktuuri**
   - Hajautetut MCP-verkostot, jotka voivat jakaa resursseja organisaatioiden välillä
   - Standardoidut protokollat turvalliseen mallien jakamiseen
   - Tietosuojan säilyttävät laskentatekniikat

3. **MCP-markkinapaikat**
   - Ekosysteemit MCP-mallien ja -laajennusten jakamiseen ja kaupallistamiseen
   - Laadunvarmistus- ja sertifiointiprosessit
   - Integraatio mallimarkkinapaikkojen kanssa

4. **MCP reunalaskentaan**
   - MCP-standardien mukauttaminen resurssirajoitteisille reunalaitteille
   - Optimoidut protokollat matalan kaistanleveyden ympäristöille
   - Erikoistuneet MCP-toteutukset IoT-ekosysteemeille

5. **Sääntelykehykset**
   - MCP-laajennusten kehittäminen sääntelyn noudattamiseksi
   - Standardoidut auditointipolut ja selitettävyyden rajapinnat
   - Integraatio nousevien tekoälyn hallintakehysten kanssa

### MCP-ratkaisut Microsoftilta

Microsoft ja Azure ovat kehittäneet useita avoimen lähdekoodin arkistoja auttaakseen kehittäjiä toteuttamaan MCP:tä eri tilanteissa:

#### Microsoft Organisaatio
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - Playwright MCP-palvelin selaimen automaatioon ja testaukseen
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - OneDrive MCP-palvelimen toteutus paikalliseen testaukseen ja yhteisön panokseen

#### Azure-Samples Organisaatio
1. [mcp](https://github.com/Azure-Samples/mcp) - Linkit esimerkkeihin, työkaluihin ja resursseihin MCP-palvelinten rakentamiseen ja integrointiin Azureen useilla kielillä
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Viite MCP-palvelimet, jotka esittävät autentikoinnin nykyisellä Model Context Protocol -spesifikaatiolla
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Laskeutumissivu etä-MCP-palvelimen toteutuksille Azure Functionsissa, linkit kielikohtaisiin arkistoihin
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Pikastarttimalli mukautettujen etä-MCP-palvelinten rakentamiseen ja käyttöönottoon Azure Functionsilla Pythonilla
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Pikastarttimalli mukautettujen etä-MCP-palvelinten rakentamiseen ja käyttöönottoon Azure Functionsilla .NET/C#:llä
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Pikastarttimalli mukautettujen etä-MCP-palvelinten rakentamiseen ja käyttöönottoon Azure Functionsilla TypeScriptillä
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management tekoälyporttina etä-MCP-palvelimille Pythonilla
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI kokeilut, mukaan lukien MCP-kyvykkyydet, integraatio Azure OpenAI:n ja AI Foundryn kanssa

Nämä arkistot tarjoavat erilaisia toteutuksia, malleja ja resursseja Model Context Protocolin kanssa työskentelyyn eri ohjelmointikielillä ja Azure-palveluilla. Ne kattavat laajan valikoiman käyttötilanteita perustason palvelintoteutuksista autentikointiin, pilvikäyttöönottoon ja yritysintegrointiskenaarioihin.

#### MCP-resurssihakemisto

[MCP-resurssihakemisto](https://github.com/microsoft/mcp/tree/main/Resources) virallisessa Microsoft MCP-arkistossa tarjoaa kuratoidun kokoelman esimerkkiresursseja, kehotemalleja ja työkalumääritelmiä käytettäväksi Model Context Protocol -palvelimilla. Tämä hakemisto on suunniteltu auttamaan kehittäjiä pääsemään nopeasti alkuun MCP:n kanssa tarjoamalla uudelleenkäytettäviä rakennuspalikoita ja parhaita käytännön esimerkkejä:

- **Kehotemallit:** Valmiita kehotemalleja yleisiin tekoälytehtäviin ja -skenaarioihin, joita voidaan mukauttaa omiin MCP-palvelintoteutuksiin.
- **Työkalumääritelmät:** Esimerkkityökalujen skeemat ja metatiedot työkalujen integroinnin ja kutsumisen standardisoimiseksi eri MCP-palvelimilla.
- **Resurssiesimerkit:** Esimerkkiresurssien määritelmät yhteyksien luomiseen datalähteisiin, API:hin ja ulkoisiin palveluihin MCP-kehyksen sisällä.
- **Viitetoteutukset:** Käytännön esimerkit, jotka demonstroivat, miten res
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## Harjoitukset

1. Analysoi yksi tapaustutkimuksista ja ehdota vaihtoehtoista toteutustapaa.
2. Valitse yksi projektiehdotuksista ja luo yksityiskohtainen tekninen spesifikaatio.
3. Tutki toimialaa, jota ei ole käsitelty tapaustutkimuksissa, ja hahmottele, miten MCP voisi vastata sen erityisiin haasteisiin.
4. Tutki yhtä tulevaisuuden suuntaa ja luo konsepti uudelle MCP-laajennukselle sen tukemiseksi.

Seuraavaksi: [Parhaat käytännöt](../08-BestPractices/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä AI-käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, ole tietoinen siitä, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää auktoritatiivisena lähteenä. Kriittisen tiedon osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa mistään väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.