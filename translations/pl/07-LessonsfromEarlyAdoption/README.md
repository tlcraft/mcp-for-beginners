<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-07-14T04:24:33+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "pl"
}
-->
# Lekcje od Wczesnych Użytkowników

## Przegląd

Ta lekcja pokazuje, jak wczesni użytkownicy wykorzystali Model Context Protocol (MCP) do rozwiązywania rzeczywistych problemów i napędzania innowacji w różnych branżach. Poprzez szczegółowe studia przypadków i praktyczne projekty zobaczysz, jak MCP umożliwia standaryzowaną, bezpieczną i skalowalną integrację AI — łącząc duże modele językowe, narzędzia i dane przedsiębiorstwa w jednolitym frameworku. Zdobędziesz praktyczne doświadczenie w projektowaniu i budowaniu rozwiązań opartych na MCP, poznasz sprawdzone wzorce implementacji oraz najlepsze praktyki wdrażania MCP w środowiskach produkcyjnych. Lekcja podkreśla także pojawiające się trendy, kierunki rozwoju oraz zasoby open-source, które pomogą Ci pozostać na czele technologii MCP i jej rozwijającego się ekosystemu.

## Cele nauki

- Analizować rzeczywiste implementacje MCP w różnych branżach  
- Projektować i budować kompletne aplikacje oparte na MCP  
- Poznawać pojawiające się trendy i przyszłe kierunki rozwoju technologii MCP  
- Stosować najlepsze praktyki w rzeczywistych scenariuszach rozwojowych  

## Rzeczywiste implementacje MCP

### Studium przypadku 1: Automatyzacja obsługi klienta w przedsiębiorstwie

Międzynarodowa korporacja wdrożyła rozwiązanie oparte na MCP, aby ustandaryzować interakcje AI w swoich systemach obsługi klienta. Pozwoliło to na:

- Stworzenie zunifikowanego interfejsu dla wielu dostawców LLM  
- Utrzymanie spójnego zarządzania promptami w różnych działach  
- Wdrożenie solidnych kontroli bezpieczeństwa i zgodności  
- Łatwe przełączanie między różnymi modelami AI w zależności od potrzeb  

**Implementacja techniczna:**  
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

**Wyniki:** 30% redukcja kosztów modeli, 45% poprawa spójności odpowiedzi oraz zwiększona zgodność w globalnych operacjach.

### Studium przypadku 2: Asystent diagnostyczny w opiece zdrowotnej

Dostawca usług medycznych opracował infrastrukturę MCP do integracji wielu specjalistycznych modeli AI medycznych, jednocześnie zapewniając ochronę wrażliwych danych pacjentów:

- Płynne przełączanie między modelami ogólnymi a specjalistycznymi  
- Ścisłe kontrole prywatności i ścieżki audytu  
- Integracja z istniejącymi systemami Elektronicznej Dokumentacji Medycznej (EHR)  
- Spójne inżynieria promptów dla terminologii medycznej  

**Implementacja techniczna:**  
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

**Wyniki:** Lepsze sugestie diagnostyczne dla lekarzy przy pełnej zgodności z HIPAA oraz znaczne zmniejszenie przełączania kontekstu między systemami.

### Studium przypadku 3: Analiza ryzyka w usługach finansowych

Instytucja finansowa wdrożyła MCP, aby ustandaryzować procesy analizy ryzyka w różnych działach:

- Stworzenie zunifikowanego interfejsu dla modeli ryzyka kredytowego, wykrywania oszustw i ryzyka inwestycyjnego  
- Wdrożenie ścisłych kontroli dostępu i wersjonowania modeli  
- Zapewnienie audytowalności wszystkich rekomendacji AI  
- Utrzymanie spójnego formatowania danych w różnych systemach  

**Implementacja techniczna:**  
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

**Wyniki:** Zwiększona zgodność regulacyjna, 40% szybsze cykle wdrożeń modeli oraz poprawiona spójność oceny ryzyka w działach.

### Studium przypadku 4: Microsoft Playwright MCP Server do automatyzacji przeglądarki

Microsoft opracował [Playwright MCP server](https://github.com/microsoft/playwright-mcp), który umożliwia bezpieczną, standaryzowaną automatyzację przeglądarki za pomocą Model Context Protocol. To rozwiązanie pozwala agentom AI i LLM na interakcję z przeglądarkami internetowymi w kontrolowany, audytowalny i rozszerzalny sposób — umożliwiając takie zastosowania jak automatyczne testowanie stron, ekstrakcja danych i kompleksowe workflow.

- Udostępnia możliwości automatyzacji przeglądarki (nawigacja, wypełnianie formularzy, robienie zrzutów ekranu itp.) jako narzędzia MCP  
- Wdraża ścisłe kontrole dostępu i sandboxing, aby zapobiec nieautoryzowanym działaniom  
- Zapewnia szczegółowe logi audytowe wszystkich interakcji z przeglądarką  
- Wspiera integrację z Azure OpenAI i innymi dostawcami LLM dla automatyzacji sterowanej agentami  

**Implementacja techniczna:**  
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

**Wyniki:**  
- Umożliwiono bezpieczną, programową automatyzację przeglądarki dla agentów AI i LLM  
- Zredukowano nakład pracy manualnego testowania i poprawiono pokrycie testów aplikacji webowych  
- Dostarczono wielokrotnego użytku, rozszerzalny framework do integracji narzędzi przeglądarkowych w środowiskach korporacyjnych  

**Referencje:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Studium przypadku 5: Azure MCP – Model Context Protocol klasy enterprise jako usługa

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) to zarządzana, klasy enterprise implementacja Model Context Protocol od Microsoft, zaprojektowana, by dostarczać skalowalne, bezpieczne i zgodne z przepisami możliwości serwera MCP jako usługi w chmurze. Azure MCP umożliwia organizacjom szybkie wdrażanie, zarządzanie i integrację serwerów MCP z usługami Azure AI, danymi i bezpieczeństwem, redukując koszty operacyjne i przyspieszając adopcję AI.

- W pełni zarządzany hosting serwera MCP z wbudowanym skalowaniem, monitorowaniem i zabezpieczeniami  
- Natywna integracja z Azure OpenAI, Azure AI Search i innymi usługami Azure  
- Uwierzytelnianie i autoryzacja klasy enterprise przez Microsoft Entra ID  
- Wsparcie dla niestandardowych narzędzi, szablonów promptów i konektorów zasobów  
- Zgodność z wymaganiami bezpieczeństwa i regulacyjnymi dla przedsiębiorstw  

**Implementacja techniczna:**  
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

**Wyniki:**  
- Skrócenie czasu do wartości dla projektów AI w przedsiębiorstwach dzięki gotowej, zgodnej platformie serwera MCP  
- Uproszczenie integracji LLM, narzędzi i źródeł danych korporacyjnych  
- Zwiększone bezpieczeństwo, obserwowalność i efektywność operacyjna dla obciążeń MCP  

**Referencje:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Studium przypadku 6: NLWeb  
MCP (Model Context Protocol) to nowy protokół umożliwiający chatbotom i asystentom AI interakcję z narzędziami. Każda instancja NLWeb jest również serwerem MCP, który obsługuje jedną podstawową metodę, ask, służącą do zadawania pytań stronie internetowej w języku naturalnym. Odpowiedź wykorzystuje schema.org, powszechnie stosowany słownik do opisu danych webowych. Mówiąc obrazowo, MCP jest dla NLWeb tym, czym Http jest dla HTML. NLWeb łączy protokoły, formaty Schema.org i przykładowy kod, aby pomóc witrynom szybko tworzyć takie punkty końcowe, przynosząc korzyści zarówno ludziom poprzez interfejsy konwersacyjne, jak i maszynom poprzez naturalną interakcję agent-agent.

NLWeb składa się z dwóch odrębnych komponentów:  
- Protokół, bardzo prosty na start, do komunikacji z witryną w języku naturalnym oraz format odpowiedzi oparty na json i schema.org. Szczegóły w dokumentacji REST API.  
- Prosta implementacja (1), wykorzystująca istniejące oznaczenia, dla witryn, które można sprowadzić do list elementów (produkty, przepisy, atrakcje, recenzje itp.). Wraz z zestawem widgetów UI witryny mogą łatwo udostępniać konwersacyjne interfejsy do swoich treści. Więcej w dokumentacji Life of a chat query.  

**Referencje:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Studium przypadku 7: MCP dla Foundry – Integracja agentów Azure AI

Serwery MCP Azure AI Foundry pokazują, jak MCP może być używany do orkiestracji i zarządzania agentami AI oraz workflow w środowiskach korporacyjnych. Integrując MCP z Azure AI Foundry, organizacje mogą ustandaryzować interakcje agentów, wykorzystać zarządzanie workflow Foundry oraz zapewnić bezpieczne i skalowalne wdrożenia. Podejście to umożliwia szybkie prototypowanie, solidny monitoring i płynną integrację z usługami Azure AI, wspierając zaawansowane scenariusze, takie jak zarządzanie wiedzą i ocena agentów. Deweloperzy korzystają z zunifikowanego interfejsu do budowy, wdrażania i monitorowania pipeline’ów agentów, a zespoły IT zyskują lepsze bezpieczeństwo, zgodność i efektywność operacyjną. Rozwiązanie jest idealne dla przedsiębiorstw chcących przyspieszyć adopcję AI i zachować kontrolę nad złożonymi procesami sterowanymi agentami.

**Referencje:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Studium przypadku 8: Foundry MCP Playground – Eksperymenty i prototypowanie

Foundry MCP Playground oferuje gotowe środowisko do eksperymentowania z serwerami MCP i integracjami Azure AI Foundry. Deweloperzy mogą szybko prototypować, testować i oceniać modele AI oraz workflow agentów, korzystając z zasobów katalogu i laboratoriów Azure AI Foundry. Playground upraszcza konfigurację, dostarcza przykładowe projekty i wspiera współpracę, ułatwiając poznawanie najlepszych praktyk i nowych scenariuszy przy minimalnym nakładzie. Jest szczególnie przydatny dla zespołów chcących zweryfikować pomysły, dzielić się eksperymentami i przyspieszyć naukę bez potrzeby skomplikowanej infrastruktury. Obniżając próg wejścia, playground wspiera innowacje i wkład społeczności w ekosystem MCP i Azure AI Foundry.

**Referencje:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Studium przypadku 9: Microsoft Docs MCP Server – Nauka i rozwój umiejętności  
Microsoft Docs MCP Server implementuje Model Context Protocol (MCP) serwer, który zapewnia asystentom AI dostęp w czasie rzeczywistym do oficjalnej dokumentacji Microsoft. Wykonuje wyszukiwanie semantyczne w oficjalnej dokumentacji technicznej Microsoft.

**Referencje:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## Projekty praktyczne

### Projekt 1: Budowa serwera MCP obsługującego wielu dostawców

**Cel:** Stworzyć serwer MCP, który będzie kierował zapytania do różnych dostawców modeli AI na podstawie określonych kryteriów.

**Wymagania:**  
- Obsługa co najmniej trzech różnych dostawców modeli (np. OpenAI, Anthropic, modele lokalne)  
- Implementacja mechanizmu routingu opartego na metadanych zapytania  
- System konfiguracji do zarządzania poświadczeniami dostawców  
- Dodanie cache’owania dla optymalizacji wydajności i kosztów  
- Prosty dashboard do monitorowania użycia  

**Kroki implementacji:**  
1. Utworzenie podstawowej infrastruktury serwera MCP  
2. Implementacja adapterów dostawców dla każdego serwisu AI  
3. Stworzenie logiki routingu na podstawie atrybutów zapytania  
4. Dodanie mechanizmów cache’owania dla często powtarzających się zapytań  
5. Opracowanie dashboardu monitorującego  
6. Testowanie z różnymi wzorcami zapytań  

**Technologie:** Wybór spośród Python (.NET/Java/Python według preferencji), Redis do cache’owania oraz prosty framework webowy do dashboardu.

### Projekt 2: System zarządzania promptami w przedsiębiorstwie

**Cel:** Rozwinąć system oparty na MCP do zarządzania, wersjonowania i wdrażania szablonów promptów w organizacji.

**Wymagania:**  
- Centralne repozytorium szablonów promptów  
- Wersjonowanie i workflow zatwierdzania  
- Możliwości testowania szablonów na przykładowych danych  
- Kontrole dostępu oparte na rolach  
- API do pobierania i wdrażania szablonów  

**Kroki implementacji:**  
1. Zaprojektowanie schematu bazy danych do przechowywania szablonów  
2. Stworzenie podstawowego API do operacji CRUD na szablonach  
3. Implementacja systemu wersjonowania  
4. Budowa workflow zatwierdzania  
5. Opracowanie frameworku testowego  
6. Stworzenie prostego interfejsu webowego do zarządzania  
7. Integracja z serwerem MCP  

**Technologie:** Dowolny backend framework, baza SQL lub NoSQL oraz frontendowy framework do interfejsu zarządzania.

### Projekt 3: Platforma generowania treści oparta na MCP

**Cel:** Zbudować platformę generowania treści, która wykorzystuje MCP do zapewnienia spójnych wyników dla różnych typów treści.

**Wymagania:**  
- Obsługa wielu formatów treści (posty na bloga, media społecznościowe, teksty marketingowe)  
- Generowanie oparte na szablonach z opcjami personalizacji  
- System przeglądu i feedbacku treści  
- Śledzenie metryk wydajności treści  
- Wsparcie dla wersjonowania i iteracji treści  

**Kroki implementacji:**  
1. Utworzenie infrastruktury klienta MCP  
2. Stworzenie szablonów dla różnych typów treści  
3. Budowa pipeline’u generowania treści  
4. Implementacja systemu przeglądu  
5. Opracowanie systemu śledzenia metryk  
6. Stworzenie interfejsu użytkownika do zarządzania szablonami i generowaniem treści  

**Technologie:** Preferowany język programowania, framework webowy i system bazy danych.

## Przyszłe kierunki rozwoju technologii MCP

### Pojawiające się trendy

1. **Multi-modalny MCP**  
   - Rozszerzenie MCP o standaryzację interakcji z modelami obrazów, dźwięku i wideo  
   - Rozwój zdolności rozumowania międzymodalnego  
   - Standaryzowane formaty promptów dla różnych modalności  

2. **Federowana infrastruktura MCP**  
   - Rozproszone sieci MCP umożliwiające współdzielenie zasobów między organizacjami  
   - Standaryzowane protokoły bezpiecznego udostępniania modeli  
   - Techniki obliczeń chroniących prywatność  

3. **Rynki MCP**  
   - Ekosystemy do dzielenia się i monetyzacji szablonów i wtyczek MCP  
   - Procesy zapewniania jakości i certyfikacji  
   - Integracja z rynkami modeli  

4. **MCP dla edge computingu**  
   - Adaptacja standardów MCP dla urządzeń o ograniczonych zasobach  
   - Optymalizacja protokołów pod kątem środowisk o niskiej przepustowości  
   - Specjalistyczne implementacje MCP dla ekosystemów IoT  

5. **Ramowe regulacyjne**  
   - Rozwój rozszerzeń MCP dla zgodności regulacyjnej  
   - Standaryzowane ścieżki audytu i interfejsy wyjaśnialności  
   - Integracja z nowo powstającymi ramami zarządzania AI  

### Rozwiązania MCP od Microsoft

Microsoft i Azure opracowały kilka repozytoriów open-source, które pomagają deweloperom implementować MCP w różnych scenariuszach:

#### Organizacja Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – serwer Playwright MCP do automatyzacji i testowania przeglądarek  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – implementacja serwera MCP dla OneDrive do lokalnych testów i wkładu
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Strona startowa dla implementacji Remote MCP Server w Azure Functions z linkami do repozytoriów specyficznych dla języków
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Szablon szybkiego startu do tworzenia i wdrażania niestandardowych zdalnych serwerów MCP za pomocą Azure Functions i Pythona
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Szablon szybkiego startu do tworzenia i wdrażania niestandardowych zdalnych serwerów MCP za pomocą Azure Functions i .NET/C#
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Szablon szybkiego startu do tworzenia i wdrażania niestandardowych zdalnych serwerów MCP za pomocą Azure Functions i TypeScript
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API Management jako AI Gateway do zdalnych serwerów MCP z użyciem Pythona
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - Eksperymenty APIM ❤️ AI, w tym możliwości MCP, integrujące się z Azure OpenAI i AI Foundry

Te repozytoria oferują różne implementacje, szablony i zasoby do pracy z Model Context Protocol w różnych językach programowania i usługach Azure. Obejmują one szeroki zakres zastosowań, od podstawowych implementacji serwerów po uwierzytelnianie, wdrożenia w chmurze i scenariusze integracji korporacyjnej.

#### Katalog zasobów MCP

[Katalog zasobów MCP](https://github.com/microsoft/mcp/tree/main/Resources) w oficjalnym repozytorium Microsoft MCP zawiera starannie wyselekcjonowany zbiór przykładowych zasobów, szablonów promptów oraz definicji narzędzi do wykorzystania z serwerami Model Context Protocol. Ten katalog ma na celu pomóc programistom szybko rozpocząć pracę z MCP, oferując wielokrotnego użytku elementy budulcowe oraz przykłady najlepszych praktyk dla:

- **Szablony promptów:** Gotowe do użycia szablony promptów dla typowych zadań i scenariuszy AI, które można dostosować do własnych implementacji serwerów MCP.
- **Definicje narzędzi:** Przykładowe schematy narzędzi i metadane, które standaryzują integrację i wywoływanie narzędzi w różnych serwerach MCP.
- **Przykładowe zasoby:** Przykładowe definicje zasobów do łączenia się ze źródłami danych, API i usługami zewnętrznymi w ramach MCP.
- **Implementacje referencyjne:** Praktyczne przykłady pokazujące, jak strukturyzować i organizować zasoby, prompty i narzędzia w rzeczywistych projektach MCP.

Te zasoby przyspieszają rozwój, promują standaryzację i pomagają zapewnić najlepsze praktyki podczas tworzenia i wdrażania rozwiązań opartych na MCP.

#### Katalog zasobów MCP
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Możliwości badawcze

- Efektywne techniki optymalizacji promptów w ramach MCP
- Modele bezpieczeństwa dla wielodostępnych wdrożeń MCP
- Benchmarki wydajności różnych implementacji MCP
- Metody formalnej weryfikacji serwerów MCP

## Podsumowanie

Model Context Protocol (MCP) szybko kształtuje przyszłość standaryzowanej, bezpiecznej i interoperacyjnej integracji AI w różnych branżach. Dzięki studiom przypadków i praktycznym projektom w tej lekcji zobaczyłeś, jak pierwsi użytkownicy — w tym Microsoft i Azure — wykorzystują MCP do rozwiązywania rzeczywistych problemów, przyspieszania adopcji AI oraz zapewniania zgodności, bezpieczeństwa i skalowalności. Modularne podejście MCP umożliwia organizacjom łączenie dużych modeli językowych, narzędzi i danych korporacyjnych w jednolitym, audytowalnym środowisku. W miarę rozwoju MCP, aktywne uczestnictwo w społeczności, eksploracja zasobów open source oraz stosowanie najlepszych praktyk będą kluczowe dla budowania solidnych, gotowych na przyszłość rozwiązań AI.

## Dodatkowe zasoby

- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)
- [Integracja agentów Azure AI z MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)
- [MCP GitHub Repository (Microsoft)](https://github.com/microsoft/mcp)
- [Katalog zasobów MCP (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)
- [Społeczność i dokumentacja MCP](https://modelcontextprotocol.io/introduction)
- [Dokumentacja Azure MCP](https://aka.ms/azmcp)
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

## Ćwiczenia

1. Przeanalizuj jedno ze studiów przypadku i zaproponuj alternatywne podejście do implementacji.
2. Wybierz jeden z pomysłów na projekt i stwórz szczegółową specyfikację techniczną.
3. Zbadaj branżę nieobjętą studiami przypadku i nakreśl, jak MCP mógłby rozwiązać jej specyficzne wyzwania.
4. Zbadaj jeden z kierunków rozwoju i stwórz koncepcję nowego rozszerzenia MCP wspierającego ten kierunek.

Następny: [Best Practices](../08-BestPractices/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.