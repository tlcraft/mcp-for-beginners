<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T17:11:31+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "pl"
}
-->
# Lekcje od Wczesnych Użytkowników

## Przegląd

Ta lekcja pokazuje, jak wczesni użytkownicy wykorzystali Model Context Protocol (MCP) do rozwiązywania rzeczywistych problemów i napędzania innowacji w różnych branżach. Poprzez szczegółowe studia przypadków i projekty praktyczne zobaczysz, jak MCP umożliwia standaryzowaną, bezpieczną i skalowalną integrację AI — łącząc duże modele językowe, narzędzia i dane korporacyjne w jednolitym systemie. Zdobędziesz praktyczne doświadczenie w projektowaniu i tworzeniu rozwiązań opartych na MCP, poznasz sprawdzone wzorce implementacji oraz najlepsze praktyki wdrażania MCP w środowiskach produkcyjnych. Lekcja podkreśla także nowe trendy, kierunki rozwoju oraz zasoby open-source, które pomogą Ci pozostać na czele technologii MCP i jej rozwijającego się ekosystemu.

## Cele nauki

- Analizować rzeczywiste implementacje MCP w różnych branżach
- Projektować i tworzyć kompletne aplikacje oparte na MCP
- Poznawać pojawiające się trendy i przyszłe kierunki rozwoju technologii MCP
- Stosować najlepsze praktyki w rzeczywistych scenariuszach rozwojowych

## Rzeczywiste implementacje MCP

### Studium przypadku 1: Automatyzacja wsparcia klienta w przedsiębiorstwie

Międzynarodowa korporacja wdrożyła rozwiązanie oparte na MCP, aby ustandaryzować interakcje AI w systemach obsługi klienta. Dzięki temu mogli:

- Stworzyć zunifikowany interfejs dla wielu dostawców LLM
- Utrzymać spójne zarządzanie promptami w różnych działach
- Wprowadzić solidne zabezpieczenia i kontrole zgodności
- Łatwo przełączać się między różnymi modelami AI w zależności od potrzeb

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

**Wyniki:** 30% redukcja kosztów modeli, 45% poprawa spójności odpowiedzi oraz zwiększona zgodność na poziomie globalnym.

### Studium przypadku 2: Asystent diagnostyczny w opiece zdrowotnej

Dostawca usług medycznych stworzył infrastrukturę MCP integrującą wiele specjalistycznych modeli AI medycznych, jednocześnie chroniąc wrażliwe dane pacjentów:

- Płynne przełączanie między modelami ogólnymi i specjalistycznymi
- Surowe kontrole prywatności i ścieżki audytu
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

**Wyniki:** Lepsze sugestie diagnostyczne dla lekarzy przy pełnej zgodności z HIPAA oraz znaczne zmniejszenie przełączania kontekstów między systemami.

### Studium przypadku 3: Analiza ryzyka w usługach finansowych

Instytucja finansowa wdrożyła MCP, aby ustandaryzować procesy analizy ryzyka w różnych działach:

- Stworzono zunifikowany interfejs dla modeli ryzyka kredytowego, wykrywania oszustw i ryzyka inwestycyjnego
- Wprowadzono ścisłe kontrole dostępu i wersjonowanie modeli
- Zapewniono audytowalność wszystkich rekomendacji AI
- Utrzymano spójny format danych w różnorodnych systemach

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

**Wyniki:** Zwiększona zgodność regulacyjna, o 40% szybsze cykle wdrażania modeli oraz poprawa spójności oceny ryzyka w działach.

### Studium przypadku 4: Microsoft Playwright MCP Server do automatyzacji przeglądarki

Microsoft opracował [Playwright MCP server](https://github.com/microsoft/playwright-mcp), który umożliwia bezpieczną, ustandaryzowaną automatyzację przeglądarek za pomocą Model Context Protocol. To rozwiązanie pozwala agentom AI i LLM na kontrolowaną, audytowalną i rozszerzalną interakcję z przeglądarkami — umożliwiając takie zastosowania jak automatyczne testy stron, ekstrakcja danych i kompleksowe przepływy pracy.

- Udostępnia funkcje automatyzacji przeglądarki (nawigacja, wypełnianie formularzy, zrzuty ekranu itd.) jako narzędzia MCP
- Wprowadza ścisłe kontrole dostępu i sandboxing, aby zapobiegać nieautoryzowanym działaniom
- Dostarcza szczegółowe logi audytu wszystkich interakcji z przeglądarką
- Wspiera integrację z Azure OpenAI i innymi dostawcami LLM dla automatyzacji sterowanej przez agentów

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
- Umożliwiono bezpieczną, programową automatyzację przeglądarek dla agentów AI i LLM  
- Zredukowano ręczne testowanie i poprawiono pokrycie testów aplikacji webowych  
- Zapewniono wielokrotnego użytku, rozszerzalne środowisko do integracji narzędzi przeglądarkowych w środowiskach korporacyjnych

**Źródła:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Studium przypadku 5: Azure MCP – Model Context Protocol klasy korporacyjnej jako usługa

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) to zarządzana przez Microsoft implementacja Model Context Protocol na poziomie przedsiębiorstwa, zaprojektowana tak, aby oferować skalowalne, bezpieczne i zgodne z regulacjami serwery MCP jako usługę w chmurze. Azure MCP pozwala organizacjom szybko wdrażać, zarządzać i integrować serwery MCP z usługami Azure AI, danymi i bezpieczeństwem, redukując koszty operacyjne i przyspieszając adopcję AI.

- W pełni zarządzany hosting serwera MCP z wbudowanym skalowaniem, monitoringiem i zabezpieczeniami
- Natywna integracja z Azure OpenAI, Azure AI Search i innymi usługami Azure
- Uwierzytelnianie i autoryzacja klasy korporacyjnej przez Microsoft Entra ID
- Obsługa narzędzi niestandardowych, szablonów promptów i konektorów zasobów
- Zgodność z wymogami bezpieczeństwa i regulacyjnymi przedsiębiorstw

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
- Skrócenie czasu do wartości dla projektów AI w przedsiębiorstwach dzięki gotowej do użycia, zgodnej platformie serwera MCP  
- Uproszczenie integracji LLM, narzędzi i źródeł danych korporacyjnych  
- Zwiększone bezpieczeństwo, obserwowalność i efektywność operacyjna dla obciążeń MCP

**Źródła:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Studium przypadku 6: NLWeb  
MCP (Model Context Protocol) to nowy protokół dla chatbotów i asystentów AI do interakcji z narzędziami. Każda instancja NLWeb jest również serwerem MCP, który obsługuje jedną podstawową metodę ask, służącą do zadawania pytań stronie internetowej w naturalnym języku. Odpowiedź korzysta ze schema.org, powszechnie używanego słownika do opisywania danych internetowych. Mówiąc ogólnie, MCP jest dla NLWeb tym, czym Http dla HTML. NLWeb łączy protokoły, formaty Schema.org oraz przykładowy kod, aby pomóc witrynom szybko tworzyć takie punkty końcowe, przynosząc korzyści zarówno ludziom poprzez interfejsy konwersacyjne, jak i maszynom przez naturalną interakcję agent-agenta.

NLWeb składa się z dwóch odrębnych komponentów:
- Protokół, bardzo prosty na start, do komunikacji z witryną w naturalnym języku oraz format, wykorzystujący json i schema.org dla zwracanej odpowiedzi. Szczegóły w dokumentacji REST API.
- Prosta implementacja (1), wykorzystująca istniejące oznaczenia, dla witryn, które można sprowadzić do list elementów (produkty, przepisy, atrakcje, recenzje itp.). Razem z zestawem widżetów UI, witryny mogą łatwo udostępniać konwersacyjne interfejsy do swojej zawartości. Szczegóły w dokumentacji Life of a chat query.

**Źródła:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Studium przypadku 7: MCP dla Foundry – Integracja agentów Azure AI

Serwery Azure AI Foundry MCP pokazują, jak MCP może służyć do orkiestracji i zarządzania agentami AI oraz przepływami pracy w środowiskach korporacyjnych. Integrując MCP z Azure AI Foundry, organizacje mogą ustandaryzować interakcje agentów, korzystać z zarządzania przepływami Foundry i zapewnić bezpieczne, skalowalne wdrożenia. Podejście to umożliwia szybkie prototypowanie, solidny monitoring oraz płynną integrację z usługami Azure AI, wspierając zaawansowane scenariusze, takie jak zarządzanie wiedzą i ocena agentów. Deweloperzy zyskują zunifikowany interfejs do budowania, wdrażania i monitorowania pipeline’ów agentów, a zespoły IT poprawę bezpieczeństwa, zgodności i efektywności operacyjnej. Rozwiązanie idealne dla firm chcących przyspieszyć adopcję AI i zachować kontrolę nad złożonymi procesami sterowanymi przez agentów.

**Źródła:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Studium przypadku 8: Foundry MCP Playground – Eksperymenty i prototypowanie

Foundry MCP Playground oferuje gotowe środowisko do eksperymentów z serwerami MCP i integracjami Azure AI Foundry. Deweloperzy mogą szybko prototypować, testować i oceniać modele AI oraz przepływy agentów, korzystając z zasobów katalogu i laboratoriów Azure AI Foundry. Playground ułatwia konfigurację, oferuje przykładowe projekty i wspiera współpracę, umożliwiając łatwe poznawanie najlepszych praktyk i nowych scenariuszy przy minimalnym nakładzie. Szczególnie przydatny dla zespołów chcących zweryfikować pomysły, dzielić się eksperymentami i przyspieszyć naukę bez konieczności rozbudowanej infrastruktury. Obniżając próg wejścia, playground sprzyja innowacjom i wkładowi społeczności w ekosystem MCP i Azure AI Foundry.

**Źródła:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### Studium przypadku 9: Microsoft Docs MCP Server – Nauka i rozwój umiejętności  
Microsoft Docs MCP Server implementuje Model Context Protocol (MCP) serwer, który zapewnia asystentom AI dostęp w czasie rzeczywistym do oficjalnej dokumentacji Microsoft. Wykonuje wyszukiwanie semantyczne w oficjalnej dokumentacji technicznej Microsoft.

**Źródła:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## Projekty praktyczne

### Projekt 1: Budowa serwera MCP z wieloma dostawcami

**Cel:** Stworzyć serwer MCP, który będzie kierował zapytania do różnych dostawców modeli AI na podstawie określonych kryteriów.

**Wymagania:**  
- Obsługa co najmniej trzech różnych dostawców modeli (np. OpenAI, Anthropic, modele lokalne)  
- Implementacja mechanizmu routingu opartego na metadanych zapytania  
- System konfiguracji do zarządzania danymi uwierzytelniającymi dostawców  
- Dodanie cache’owania dla optymalizacji wydajności i kosztów  
- Prosty dashboard do monitorowania użycia

**Kroki implementacji:**  
1. Utworzenie podstawowej infrastruktury serwera MCP  
2. Implementacja adapterów dla każdego serwisu modelowego  
3. Stworzenie logiki routingu na podstawie atrybutów zapytania  
4. Dodanie mechanizmów cache’owania dla często powtarzanych zapytań  
5. Rozwój dashboardu monitorującego  
6. Testy z różnymi wzorcami zapytań

**Technologie:** Wybór spośród Python (.NET/Java/Python według preferencji), Redis do cache’owania oraz prosty framework webowy do dashboardu.

### Projekt 2: System zarządzania promptami dla przedsiębiorstw

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
5. Rozwój frameworku testowego  
6. Prosty interfejs webowy do zarządzania  
7. Integracja z serwerem MCP

**Technologie:** Dowolny framework backendowy, baza SQL lub NoSQL oraz framework frontendowy do interfejsu zarządzania.

### Projekt 3: Platforma generowania treści oparta na MCP

**Cel:** Zbudować platformę generującą treści, która wykorzystuje MCP do zapewnienia spójnych rezultatów w różnych typach treści.

**Wymagania:**  
- Obsługa wielu formatów treści (posty blogowe, media społecznościowe, teksty marketingowe)  
- Generowanie oparte na szablonach z opcjami personalizacji  
- System przeglądu i opiniowania treści  
- Śledzenie metryk wydajności treści  
- Wersjonowanie i iteracje treści

**Kroki implementacji:**  
1. Utworzenie infrastruktury klienta MCP  
2. Stworzenie szablonów dla różnych typów treści  
3. Budowa pipeline’u generowania treści  
4. Implementacja systemu przeglądu  
5. Rozwój systemu śledzenia metryk  
6. Stworzenie interfejsu użytkownika do zarządzania szablonami i generowaniem treści

**Technologie:** Preferowany język programowania, framework webowy oraz system bazy danych.

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
   - Adaptacja standardów MCP dla urządzeń edge o ograniczonych zasobach  
   - Optymalizacja protokołów pod kątem środowisk o niskiej przepustowości  
   - Specjalistyczne implementacje MCP dla ekosystemów IoT

5. **Ramowe regulacje prawne**  
   - Rozwój rozszerzeń MCP pod kątem zgodności regulacyjnej  
   - Standaryzowane ścieżki audytu i interfejsy wyjaśnialności  
   - Integracja z rozwijającymi się ramami zarządzania AI

### Rozwiązania MCP od Microsoft

Microsoft i Azure opracowały kilka repozytoriów open-source, które pomagają deweloperom wdrażać MCP w różnych scenariuszach:

#### Organizacja Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – serwer Playwright MCP do automatyzacji i testowania przeglądarek  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – implementacja serwera MCP dla OneDrive do testów lokalnych i wk
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

## Ćwiczenia

1. Przeanalizuj jedno z studiów przypadków i zaproponuj alternatywne podejście do implementacji.
2. Wybierz jeden z pomysłów na projekt i przygotuj szczegółową specyfikację techniczną.
3. Zbadaj branżę, która nie została uwzględniona w studiach przypadków, i nakreśl, jak MCP mógłby rozwiązać jej specyficzne wyzwania.
4. Zbadaj jeden z kierunków rozwoju i stwórz koncepcję nowego rozszerzenia MCP wspierającego ten kierunek.

Następne: [Best Practices](../08-BestPractices/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do dokładności, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym powinien być uznawany za źródło autorytatywne. W przypadku istotnych informacji zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.