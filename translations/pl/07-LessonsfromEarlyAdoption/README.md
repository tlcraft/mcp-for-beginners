<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1ccfe1a6ea77e42862b92ae53cb6cddf",
  "translation_date": "2025-05-20T16:57:40+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "pl"
}
-->
# Lekcje od Wczesnych Użytkowników

## Przegląd

Ta lekcja pokazuje, jak wczesni użytkownicy wykorzystali Model Context Protocol (MCP) do rozwiązywania rzeczywistych problemów i napędzania innowacji w różnych branżach. Poprzez szczegółowe studia przypadków i praktyczne projekty zobaczysz, jak MCP umożliwia standaryzowaną, bezpieczną i skalowalną integrację AI — łącząc duże modele językowe, narzędzia i dane korporacyjne w jednolitym systemie. Zdobędziesz praktyczne doświadczenie w projektowaniu i tworzeniu rozwiązań opartych na MCP, poznasz sprawdzone wzorce wdrożeń oraz najlepsze praktyki dotyczące uruchamiania MCP w środowiskach produkcyjnych. Lekcja podkreśla również nowe trendy, przyszłe kierunki rozwoju oraz zasoby open-source, które pomogą Ci pozostać na czele technologii MCP i jej rozwijającego się ekosystemu.

## Cele nauki

- Analizować rzeczywiste wdrożenia MCP w różnych branżach  
- Projektować i tworzyć kompletne aplikacje oparte na MCP  
- Poznawać nowe trendy i przyszłe kierunki rozwoju technologii MCP  
- Stosować najlepsze praktyki w rzeczywistych scenariuszach rozwoju  

## Rzeczywiste wdrożenia MCP

### Studium przypadku 1: Automatyzacja obsługi klienta w przedsiębiorstwie

Międzynarodowa korporacja wdrożyła rozwiązanie oparte na MCP, aby ujednolicić interakcje AI w swoich systemach obsługi klienta. Pozwoliło to na:

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

Dostawca usług medycznych stworzył infrastrukturę MCP do integracji wielu specjalistycznych medycznych modeli AI, jednocześnie dbając o ochronę wrażliwych danych pacjentów:

- Płynne przełączanie między modelami ogólnymi i specjalistycznymi  
- Ścisłe kontrole prywatności i ścieżki audytu  
- Integracja z istniejącymi systemami Elektronicznej Dokumentacji Medycznej (EHR)  
- Spójne tworzenie promptów dla terminologii medycznej  

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

**Wyniki:** Ulepszone sugestie diagnostyczne dla lekarzy przy zachowaniu pełnej zgodności z HIPAA oraz znaczne zmniejszenie konieczności przełączania kontekstu między systemami.

### Studium przypadku 3: Analiza ryzyka w usługach finansowych

Instytucja finansowa wdrożyła MCP, aby ujednolicić procesy analizy ryzyka w różnych działach:

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

**Wyniki:** Zwiększona zgodność regulacyjna, 40% szybsze cykle wdrażania modeli oraz poprawiona spójność oceny ryzyka w działach.

### Studium przypadku 4: Microsoft Playwright MCP Server do automatyzacji przeglądarki

Microsoft opracował [Playwright MCP server](https://github.com/microsoft/playwright-mcp), który umożliwia bezpieczną, standaryzowaną automatyzację przeglądarek za pomocą Model Context Protocol. To rozwiązanie pozwala agentom AI i LLM na interakcję z przeglądarkami w kontrolowany, audytowalny i rozszerzalny sposób — umożliwiając m.in. automatyczne testy stron, ekstrakcję danych i kompleksowe workflow.

- Udostępnia możliwości automatyzacji przeglądarki (nawigacja, wypełnianie formularzy, zrzuty ekranu itd.) jako narzędzia MCP  
- Wdrożenie ścisłych kontroli dostępu i sandboxingu, aby zapobiegać nieautoryzowanym działaniom  
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
- Zredukowano nakład pracy manualnego testowania i poprawiono pokrycie testów aplikacji webowych  
- Zapewniono wielokrotnego użytku, rozszerzalne ramy integracji narzędzi przeglądarkowych w środowiskach korporacyjnych  

**Referencje:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### Studium przypadku 5: Azure MCP – Model Context Protocol klasy korporacyjnej jako usługa

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) to zarządzane, korporacyjne wdrożenie Model Context Protocol przez Microsoft, zaprojektowane tak, by zapewnić skalowalne, bezpieczne i zgodne z regulacjami możliwości serwera MCP w chmurze. Azure MCP umożliwia organizacjom szybkie wdrażanie, zarządzanie i integrację serwerów MCP z usługami Azure AI, danymi i bezpieczeństwem, zmniejszając koszty operacyjne i przyspieszając adopcję AI.

- W pełni zarządzany hosting serwera MCP z wbudowanym skalowaniem, monitorowaniem i bezpieczeństwem  
- Natychmiastowa integracja z Azure OpenAI, Azure AI Search i innymi usługami Azure  
- Uwierzytelnianie i autoryzacja korporacyjna za pomocą Microsoft Entra ID  
- Obsługa niestandardowych narzędzi, szablonów promptów i konektorów zasobów  
- Zgodność z wymaganiami bezpieczeństwa i regulacyjnymi na poziomie przedsiębiorstwa  

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
- Skrócenie czasu do uzyskania wartości dla projektów AI w przedsiębiorstwach dzięki gotowej, zgodnej platformie serwera MCP  
- Uproszczenie integracji LLM, narzędzi i źródeł danych korporacyjnych  
- Zwiększenie bezpieczeństwa, obserwowalności i efektywności operacyjnej obciążeń MCP  

**Referencje:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## Studium przypadku 6: NLWeb  
MCP (Model Context Protocol) to rozwijający się protokół umożliwiający chatbotom i asystentom AI interakcję z narzędziami. Każda instancja NLWeb jest także serwerem MCP, obsługującym jedną podstawową metodę, ask, służącą do zadawania pytań stronie internetowej w języku naturalnym. Odpowiedź wykorzystuje schema.org, powszechnie stosowany słownik do opisu danych webowych. Mówiąc luźno, MCP jest do NLWeb tym, czym HTTP jest do HTML. NLWeb łączy protokoły, formaty Schema.org i przykładowy kod, aby pomóc witrynom szybko tworzyć takie punkty końcowe, co przynosi korzyści zarówno ludziom poprzez interfejsy konwersacyjne, jak i maszynom poprzez naturalną interakcję agent-agenta.

NLWeb składa się z dwóch głównych komponentów:  
- Protokół, bardzo prosty na początek, do interfejsu z witryną w języku naturalnym oraz format odpowiedzi wykorzystujący json i schema.org. Szczegóły w dokumentacji REST API.  
- Prosta implementacja (1), wykorzystująca istniejące oznaczenia, dla stron, które można sprowadzić do list elementów (produkty, przepisy, atrakcje, recenzje itd.). W połączeniu z zestawem widgetów UI witryny mogą łatwo oferować interfejsy konwersacyjne do swojej zawartości. Szczegóły w dokumentacji Life of a chat query.

**Referencje:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Studium przypadku 7: MCP dla Foundry – Integracja agentów Azure AI

Serwery Azure AI Foundry MCP pokazują, jak MCP może służyć do orkiestracji i zarządzania agentami AI oraz workflow w środowiskach korporacyjnych. Integrując MCP z Azure AI Foundry, organizacje mogą ujednolicić interakcje agentów, korzystać z zarządzania workflow Foundry oraz zapewnić bezpieczne i skalowalne wdrożenia. Podejście to umożliwia szybkie prototypowanie, solidne monitorowanie i płynną integrację z usługami Azure AI, wspierając zaawansowane scenariusze, takie jak zarządzanie wiedzą i ocena agentów. Deweloperzy zyskują zunifikowany interfejs do tworzenia, wdrażania i monitorowania pipeline’ów agentów, a zespoły IT lepsze bezpieczeństwo, zgodność i efektywność operacyjną. Rozwiązanie jest idealne dla przedsiębiorstw chcących przyspieszyć adopcję AI i zachować kontrolę nad złożonymi procesami sterowanymi przez agentów.

**Referencje:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Studium przypadku 8: Foundry MCP Playground – eksperymenty i prototypowanie

Foundry MCP Playground oferuje gotowe środowisko do eksperymentów z serwerami MCP i integracjami Azure AI Foundry. Deweloperzy mogą szybko prototypować, testować i oceniać modele AI oraz workflow agentów, korzystając z zasobów katalogu i laboratoriów Azure AI Foundry. Playground upraszcza konfigurację, dostarcza przykładowe projekty i wspiera współpracę, ułatwiając poznawanie najlepszych praktyk i nowych scenariuszy przy minimalnym nakładzie. Jest szczególnie przydatny dla zespołów chcących zweryfikować pomysły, dzielić się eksperymentami i przyspieszyć naukę bez potrzeby skomplikowanej infrastruktury. Obniżając próg wejścia, playground sprzyja innowacjom i wkładowi społeczności w ekosystem MCP i Azure AI Foundry.

**Referencje:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Projekty praktyczne

### Projekt 1: Budowa serwera MCP obsługującego wielu dostawców

**Cel:** Stworzyć serwer MCP, który będzie kierował żądania do różnych dostawców modeli AI na podstawie określonych kryteriów.

**Wymagania:**  
- Obsługa co najmniej trzech różnych dostawców modeli (np. OpenAI, Anthropic, modele lokalne)  
- Implementacja mechanizmu routingu opartego na metadanych żądania  
- System konfiguracji do zarządzania poświadczeniami dostawców  
- Dodanie cache’owania dla optymalizacji wydajności i kosztów  
- Prosty dashboard do monitorowania użycia  

**Kroki implementacji:**  
1. Przygotowanie podstawowej infrastruktury serwera MCP  
2. Implementacja adapterów dostawców dla każdego serwisu modelowego AI  
3. Stworzenie logiki routingu na podstawie atrybutów żądania  
4. Dodanie mechanizmów cache’owania dla często powtarzających się zapytań  
5. Opracowanie dashboardu monitorującego  
6. Testowanie z różnymi wzorcami żądań  

**Technologie:** Do wyboru Python (.NET/Java/Python według preferencji), Redis do cache’owania oraz prosty framework webowy do dashboardu.

### Projekt 2: Korporacyjny system zarządzania promptami

**Cel:** Rozwinąć system oparty na MCP do zarządzania, wersjonowania i wdrażania szablonów promptów w całej organizacji.

**Wymagania:**  
- Centralne repozytorium szablonów promptów  
- Wersjonowanie i workflow zatwierdzania  
- Możliwości testowania szablonów na przykładowych danych  
- Kontrole dostępu oparte na rolach  
- API do pobierania i wdrażania szablonów  

**Kroki implementacji:**  
1. Zaprojektowanie schematu bazy danych dla przechowywania szablonów  
2. Stworzenie podstawowego API do operacji CRUD na szablonach  
3. Implementacja systemu wersjonowania  
4. Budowa workflow zatwierdzania  
5. Opracowanie frameworka testowego  
6. Stworzenie prostego interfejsu webowego do zarządzania  
7. Integracja z serwerem MCP  

**Technologie:** Dowolny wybrany framework backendowy, baza SQL lub NoSQL oraz frontendowy framework do interfejsu zarządzania.

### Projekt 3: Platforma generowania treści oparta na MCP

**Cel:** Zbudować platformę generującą treści, która wykorzystuje MCP do zapewnienia spójnych rezultatów w różnych typach zawartości.

**Wymagania:**  
- Obsługa wielu formatów treści (posty blogowe, media społecznościowe, teksty marketingowe)  
- Generowanie oparte na szablonach z opcjami dostosowania  
- System przeglądu i feedbacku treści  
- Monitorowanie metryk wydajności treści  
- Wersjonowanie i iteracja treści  

**Kroki implementacji:**  
1. Przygotowanie infrastruktury klienta MCP  
2. Stworzenie szablonów dla różnych typów treści  
3. Budowa pipeline’u generowania treści  
4. Implementacja systemu przeglądu  
5. Rozwój systemu śledzenia metryk  
6. Stworzenie interfejsu użytkownika do zarządzania szablonami i generowania treści  

**Technologie:** Preferowany język programowania, framework webowy i system bazy danych.

## Przyszłe kierunki rozwoju technologii MCP

### Nowe trendy

1. **Multi-modalne MCP**  
   - Rozszerzenie MCP o standaryzację interakcji z modelami obrazów, dźwięku i wideo  
   - Rozwój zdolności rozumowania między modalnościami  
   - Standaryzowane formaty promptów dla różnych modalności  

2. **Federacyjna infrastruktura MCP**  
   - Rozproszone sieci MCP umożliwiające współdzielenie zasobów między organizacjami  
   - Standaryzowane protokoły bezpiecznego udostępniania modeli  
   - Techniki obliczeń chroniących prywatność  

3. **Rynki MCP**  
   - Ekosystemy do dzielenia się i monetyzacji szablonów i wtyczek MCP  
   - Procesy zapewniania jakości i certyfikacji  
   - Integracja z rynkami modeli  

4. **MCP dla edge computingu**  
   - Adaptacja standardów MCP do urządzeń edge o ograniczonych zasobach  
   - Optymalizowane protokoły dla środowisk o niskiej przepustowości  
   - Specjalistyczne implementacje MCP dla ekosystemów IoT  

5. **Ramowe regulacje**  
   - Rozwój rozszerzeń MCP dla zgodności regulacyjnej  
   - Standaryzowane ścieżki audytu i interfejsy wyjaśnialności  
   - Integracja z rosnącymi ramami zarządzania AI  

### Rozwiązania MCP od Microsoft

Microsoft i Azure opracowały kilka repozytoriów open-source, które pomagają deweloperom wdrażać MCP w różnych scenariuszach:

#### Organizacja Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – serwer Playwright MCP do automatyzacji i testów przeglądarki  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – implementacja serwera MCP dla OneDrive do lokalnych testów i wkładu społeczności  
3. [NLWeb](https://github.com/microsoft/NlWeb) – zestaw otwartych protokołów i narzędzi open source. Głównym celem jest stworzenie fundamentu dla AI Web  

#### Organizacja Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) – linki do przykładów, narzędzi i zasobów
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

1. Przeanalizuj jedno z studiów przypadku i zaproponuj alternatywne podejście do implementacji.
2. Wybierz jeden z pomysłów na projekt i stwórz szczegółową specyfikację techniczną.
3. Zbadaj branżę, która nie została objęta studiami przypadku, i nakreśl, jak MCP mógłby rozwiązać jej specyficzne wyzwania.
4. Zbadaj jeden z kierunków rozwoju i stwórz koncepcję nowego rozszerzenia MCP, które go wspiera.

Następny: [Best Practices](../08-BestPractices/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą automatycznej usługi tłumaczeniowej AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było precyzyjne, prosimy mieć na uwadze, że automatyczne przekłady mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym należy uważać za autorytatywne źródło. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.