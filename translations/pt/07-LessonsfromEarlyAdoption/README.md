<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T21:13:21+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "pt"
}
-->
# Lições dos Primeiros Usuários

## Visão Geral

Esta lição explora como os primeiros usuários aproveitaram o Model Context Protocol (MCP) para resolver desafios do mundo real e impulsionar a inovação em diversos setores. Por meio de estudos de caso detalhados e projetos práticos, você verá como o MCP possibilita uma integração de IA padronizada, segura e escalável — conectando grandes modelos de linguagem, ferramentas e dados empresariais em uma estrutura unificada. Você ganhará experiência prática no design e construção de soluções baseadas em MCP, aprenderá com padrões de implementação comprovados e descobrirá as melhores práticas para implantar MCP em ambientes de produção. A lição também destaca tendências emergentes, direções futuras e recursos open-source para ajudá-lo a se manter na vanguarda da tecnologia MCP e seu ecossistema em evolução.

## Objetivos de Aprendizagem

- Analisar implementações reais de MCP em diferentes setores
- Projetar e construir aplicações completas baseadas em MCP
- Explorar tendências emergentes e direções futuras na tecnologia MCP
- Aplicar melhores práticas em cenários reais de desenvolvimento

## Implementações Reais de MCP

### Estudo de Caso 1: Automação de Suporte ao Cliente Empresarial

Uma corporação multinacional implementou uma solução baseada em MCP para padronizar as interações de IA em seus sistemas de suporte ao cliente. Isso permitiu que eles:

- Criassem uma interface unificada para múltiplos provedores de LLM
- Mantivessem um gerenciamento consistente de prompts entre departamentos
- Implementassem controles robustos de segurança e conformidade
- Alternassem facilmente entre diferentes modelos de IA conforme necessidades específicas

**Implementação Técnica:**  
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

**Resultados:** redução de 30% nos custos com modelos, melhoria de 45% na consistência das respostas e maior conformidade nas operações globais.

### Estudo de Caso 2: Assistente de Diagnóstico em Saúde

Um provedor de saúde desenvolveu uma infraestrutura MCP para integrar múltiplos modelos médicos especializados em IA, garantindo a proteção dos dados sensíveis dos pacientes:

- Alternância fluida entre modelos médicos generalistas e especialistas
- Controles rígidos de privacidade e trilhas de auditoria
- Integração com sistemas existentes de Prontuário Eletrônico do Paciente (EHR)
- Engenharia consistente de prompts para terminologia médica

**Implementação Técnica:**  
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

**Resultados:** sugestões diagnósticas aprimoradas para médicos, mantendo total conformidade com HIPAA e redução significativa na troca de contexto entre sistemas.

### Estudo de Caso 3: Análise de Risco em Serviços Financeiros

Uma instituição financeira implementou MCP para padronizar seus processos de análise de risco em diferentes departamentos:

- Criou uma interface unificada para modelos de risco de crédito, detecção de fraudes e risco de investimento
- Implementou controles de acesso rigorosos e versionamento de modelos
- Garantiu auditabilidade de todas as recomendações de IA
- Manteve formatação consistente dos dados em sistemas diversos

**Implementação Técnica:**  
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

**Resultados:** maior conformidade regulatória, ciclos de implantação de modelos 40% mais rápidos e consistência aprimorada na avaliação de riscos entre departamentos.

### Estudo de Caso 4: Microsoft Playwright MCP Server para Automação de Navegador

A Microsoft desenvolveu o [Playwright MCP server](https://github.com/microsoft/playwright-mcp) para permitir automação de navegador segura e padronizada através do Model Context Protocol. Essa solução permite que agentes de IA e LLMs interajam com navegadores web de forma controlada, auditável e extensível — possibilitando casos de uso como testes automatizados, extração de dados e fluxos de trabalho ponta a ponta.

- Expõe capacidades de automação do navegador (navegação, preenchimento de formulários, captura de tela, etc.) como ferramentas MCP
- Implementa controles de acesso rigorosos e sandboxing para evitar ações não autorizadas
- Fornece logs detalhados de auditoria para todas as interações com o navegador
- Suporta integração com Azure OpenAI e outros provedores de LLM para automação dirigida por agentes

**Implementação Técnica:**  
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

**Resultados:**  
- Automação segura e programática de navegadores para agentes de IA e LLMs  
- Redução do esforço em testes manuais e aumento da cobertura de testes para aplicações web  
- Estrutura reutilizável e extensível para integração de ferramentas baseadas em navegador em ambientes corporativos  

**Referências:**  
- [Repositório Playwright MCP Server no GitHub](https://github.com/microsoft/playwright-mcp)  
- [Soluções de IA e Automação da Microsoft](https://azure.microsoft.com/en-us/products/ai-services/)

### Estudo de Caso 5: Azure MCP – Model Context Protocol Corporativo como Serviço

O Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) é a implementação gerenciada e corporativa do Model Context Protocol pela Microsoft, projetada para oferecer capacidades escaláveis, seguras e compatíveis de servidor MCP como um serviço na nuvem. O Azure MCP permite que organizações implantem, gerenciem e integrem servidores MCP rapidamente com serviços Azure AI, dados e segurança, reduzindo a complexidade operacional e acelerando a adoção de IA.

- Hospedagem totalmente gerenciada de servidores MCP com escalabilidade, monitoramento e segurança embutidos
- Integração nativa com Azure OpenAI, Azure AI Search e outros serviços Azure
- Autenticação e autorização corporativas via Microsoft Entra ID
- Suporte para ferramentas personalizadas, templates de prompt e conectores de recursos
- Conformidade com requisitos de segurança e regulamentação corporativa

**Implementação Técnica:**  
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

**Resultados:**  
- Redução do tempo para entrega de valor em projetos corporativos de IA, fornecendo uma plataforma MCP pronta e compatível  
- Integração simplificada de LLMs, ferramentas e fontes de dados empresariais  
- Segurança, observabilidade e eficiência operacional aprimoradas para cargas de trabalho MCP  

**Referências:**  
- [Documentação Azure MCP](https://aka.ms/azmcp)  
- [Serviços Azure AI](https://azure.microsoft.com/en-us/products/ai-services/)

## Estudo de Caso 6: NLWeb  
MCP (Model Context Protocol) é um protocolo emergente para chatbots e assistentes de IA interagirem com ferramentas. Cada instância NLWeb também é um servidor MCP, que suporta um método principal, ask, usado para fazer perguntas a um site em linguagem natural. A resposta retornada utiliza schema.org, um vocabulário amplamente usado para descrever dados web. De forma geral, MCP é para NLWeb o que HTTP é para HTML. NLWeb combina protocolos, formatos Schema.org e código de exemplo para ajudar sites a criar rapidamente esses endpoints, beneficiando tanto humanos, via interfaces conversacionais, quanto máquinas, por meio de interação natural entre agentes.

Existem dois componentes distintos no NLWeb:  
- Um protocolo, muito simples no início, para interfacear com um site em linguagem natural e um formato, usando json e schema.org para a resposta. Veja a documentação da REST API para mais detalhes.  
- Uma implementação direta do (1) que aproveita marcação existente, para sites que podem ser abstraídos como listas de itens (produtos, receitas, atrações, avaliações, etc.). Junto com um conjunto de widgets de interface, os sites podem fornecer interfaces conversacionais para seu conteúdo. Veja a documentação sobre Life of a chat query para mais detalhes sobre como isso funciona.

**Referências:**  
- [Documentação Azure MCP](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### Estudo de Caso 7: MCP para Foundry – Integração de Agentes Azure AI

Os servidores Azure AI Foundry MCP demonstram como o MCP pode ser usado para orquestrar e gerenciar agentes de IA e fluxos de trabalho em ambientes corporativos. Ao integrar MCP com Azure AI Foundry, organizações podem padronizar interações entre agentes, aproveitar o gerenciamento de fluxos do Foundry e garantir implantações seguras e escaláveis. Essa abordagem permite prototipagem rápida, monitoramento robusto e integração perfeita com serviços Azure AI, suportando cenários avançados como gestão do conhecimento e avaliação de agentes. Desenvolvedores se beneficiam de uma interface unificada para construir, implantar e monitorar pipelines de agentes, enquanto equipes de TI ganham em segurança, conformidade e eficiência operacional. A solução é ideal para empresas que buscam acelerar a adoção de IA mantendo controle sobre processos complexos dirigidos por agentes.

**Referências:**  
- [Repositório MCP Foundry no GitHub](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrando Agentes Azure AI com MCP (Blog Microsoft Foundry)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### Estudo de Caso 8: Foundry MCP Playground – Experimentação e Prototipagem

O Foundry MCP Playground oferece um ambiente pronto para uso para experimentar com servidores MCP e integrações Azure AI Foundry. Desenvolvedores podem prototipar, testar e avaliar modelos de IA e fluxos de agentes usando recursos do Azure AI Foundry Catalog e Labs. O playground simplifica a configuração, fornece projetos de exemplo e suporta desenvolvimento colaborativo, facilitando a exploração de melhores práticas e novos cenários com baixa complexidade. É especialmente útil para equipes que querem validar ideias, compartilhar experimentos e acelerar o aprendizado sem precisar de infraestrutura complexa. Ao reduzir barreiras, o playground ajuda a fomentar inovação e contribuições da comunidade no ecossistema MCP e Azure AI Foundry.

**Referências:**  
- [Repositório Foundry MCP Playground no GitHub](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## Projetos Práticos

### Projeto 1: Construir um Servidor MCP Multi-Provedor

**Objetivo:** Criar um servidor MCP capaz de direcionar requisições para múltiplos provedores de modelos de IA com base em critérios específicos.

**Requisitos:**  
- Suportar pelo menos três provedores diferentes de modelos (ex: OpenAI, Anthropic, modelos locais)  
- Implementar um mecanismo de roteamento baseado em metadados da requisição  
- Criar um sistema de configuração para gerenciar credenciais dos provedores  
- Adicionar cache para otimizar desempenho e custos  
- Construir um painel simples para monitoramento de uso

**Passos para Implementação:**  
1. Configurar a infraestrutura básica do servidor MCP  
2. Implementar adaptadores para cada serviço de modelo de IA  
3. Criar a lógica de roteamento baseada nos atributos da requisição  
4. Adicionar mecanismos de cache para requisições frequentes  
5. Desenvolver o painel de monitoramento  
6. Testar com diversos padrões de requisição

**Tecnologias:** Escolha entre Python (.NET/Java/Python conforme sua preferência), Redis para cache e um framework web simples para o painel.

### Projeto 2: Sistema Corporativo de Gerenciamento de Prompts

**Objetivo:** Desenvolver um sistema baseado em MCP para gerenciar, versionar e implantar templates de prompt em uma organização.

**Requisitos:**  
- Criar um repositório centralizado para templates de prompt  
- Implementar versionamento e fluxos de aprovação  
- Construir capacidades de teste de templates com entradas de exemplo  
- Desenvolver controles de acesso baseados em função  
- Criar uma API para recuperação e implantação de templates

**Passos para Implementação:**  
1. Projetar o esquema de banco de dados para armazenamento dos templates  
2. Criar a API principal para operações CRUD nos templates  
3. Implementar o sistema de versionamento  
4. Construir o fluxo de aprovação  
5. Desenvolver a estrutura de testes  
6. Criar uma interface web simples para gerenciamento  
7. Integrar com um servidor MCP

**Tecnologias:** Sua escolha de framework backend, banco de dados SQL ou NoSQL e framework frontend para a interface de gerenciamento.

### Projeto 3: Plataforma de Geração de Conteúdo Baseada em MCP

**Objetivo:** Construir uma plataforma de geração de conteúdo que utilize MCP para fornecer resultados consistentes em diferentes tipos de conteúdo.

**Requisitos:**  
- Suportar múltiplos formatos de conteúdo (posts de blog, redes sociais, textos de marketing)  
- Implementar geração baseada em templates com opções de personalização  
- Criar sistema de revisão e feedback de conteúdo  
- Rastrear métricas de desempenho do conteúdo  
- Suportar versionamento e iteração do conteúdo

**Passos para Implementação:**  
1. Configurar a infraestrutura cliente MCP  
2. Criar templates para diferentes tipos de conteúdo  
3. Construir pipeline de geração de conteúdo  
4. Implementar sistema de revisão  
5. Desenvolver sistema de rastreamento de métricas  
6. Criar interface para gerenciamento de templates e geração de conteúdo

**Tecnologias:** Linguagem de programação, framework web e sistema de banco de dados de sua preferência.

## Direções Futuras para a Tecnologia MCP

### Tendências Emergentes

1. **MCP Multimodal**  
   - Expansão do MCP para padronizar interações com modelos de imagem, áudio e vídeo  
   - Desenvolvimento de capacidades de raciocínio cross-modal  
   - Formatos padronizados de prompts para diferentes modalidades

2. **Infraestrutura MCP Federada**  
   - Redes MCP distribuídas que compartilham recursos entre organizações  
   - Protocolos padronizados para compartilhamento seguro de modelos  
   - Técnicas de computação que preservam a privacidade

3. **Mercados MCP**  
   - Ecossistemas para compartilhamento e monetização de templates e plugins MCP  
   - Processos de garantia de qualidade e certificação  
   - Integração com marketplaces de modelos

4. **MCP para Computação de Borda**  
   - Adaptação dos padrões MCP para dispositivos de borda com recursos limitados  
   - Protocolos otimizados para ambientes de baixa largura de banda  
   - Implementações especializadas para ecossistemas IoT

5. **Estruturas Regulatórias**  
   - Desenvolvimento de extensões MCP para conformidade regulatória  
   - Trilhas de auditoria padronizadas e interfaces de explicabilidade  
   - Integração com estruturas emergentes de governança de IA

### Soluções MCP da Microsoft

A Microsoft e o Azure desenvolveram diversos repositórios open-source para ajudar desenvolvedores a implementar MCP em vários cenários:

#### Organização Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – Servidor Playwright MCP para automação e testes de navegador  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – Implementação de servidor MCP para OneDrive, para testes locais e contribuição comunitária  
3. [NLWeb](https://github.com/microsoft/NlWeb) – Coleção de protocolos abertos e ferramentas open source focada em estabelecer uma camada fundamental para a Web de IA  

#### Organização Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) – Links para exemplos, ferramentas e recursos para construir e integrar servidores MCP no Azure usando várias linguagens  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) – Servidores MCP de referência demonstrando autenticação conforme a especificação atual do Model Context Protocol  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – Página inicial para implementações de servidores MCP remotos em Azure Functions, com links para repositórios por linguagem  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) – Template rápido para construir e implantar servidores MCP remotos personalizados com Azure Functions em Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – Template rápido para construir e implantar servidores MCP remotos personalizados com Azure Functions em .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – Template rápido para construir e implantar servidores MCP remotos personalizados com Azure Functions em TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) – Azure API Management como gateway de IA para servidores MCP remotos usando Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) – Experimentos APIM ❤️ IA incluindo capacidades MCP, integrando com Azure OpenAI e AI Foundry  

Esses repositórios fornecem diversas implementações, templates e recursos para trabalhar com o Model Context Protocol em diferentes linguagens de programação e serviços Azure. Cobrem casos de uso que vão desde implementações básicas de servidores até autenticação, implantação em nuvem e cenários corporativos.

#### Diretório de Recursos MCP

O [diretório MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) no repositório oficial Microsoft MCP oferece uma coleção selecionada de recursos de exemplo, templates de prompt e definições de ferramentas para uso com servidores Model Context Protocol. Este diretório foi criado para ajudar desenvolvedores a começarem rapidamente com MCP, oferecendo blocos reutilizáveis e exemplos de melhores práticas para:

- **Templates de Prompt:** Templates prontos para tarefas e cenários comuns de IA, adaptáveis para suas próprias implementações MCP  
- **Definições de Ferramentas:** Esquemas e metadados de ferramentas exemplares para padronizar integração e invocação de ferramentas entre servidores MCP  
- **Amostras de Recursos:** Definições de recursos exemplares para conexão com fontes de dados, APIs e serviços externos dentro do framework MCP  
- **Implementações de Referência:** Exemplos práticos que demonstram como estruturar e organizar recursos, prompts e ferramentas em projetos MCP reais  

Esses recursos aceleram o desenvolvimento, promovem padronização e ajudam a garantir melhores práticas na construção e implantação de soluções baseadas em MCP.

#### Diretório de Recursos MCP  
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### Oportunidades de Pesquisa

- Técnicas eficientes de otimização de prompts dentro de frameworks MCP  
- Modelos de segurança para implantações MCP multi-inquilino  
- Benchmarking de desempenho entre diferentes implementações MCP  
- Métodos formais de verificação para servidores MCP

## Conclusão

O Model Context Protocol (MCP) está rapidamente moldando o futuro da integração de IA padronizada, segura e interoperável em diversos setores. Através dos estudos de caso e projetos práticos desta lição, você viu como os primeiros usuários — incluindo Microsoft e Azure — estão aproveitando o MCP para resolver desafios reais, acelerar a adoção de IA e garantir conformidade, segurança e escalabilidade. A abordagem modular do MCP permite que organizações conectem grandes modelos de
- [Documentação Azure MCP](https://aka.ms/azmcp)
- [Repositório GitHub do Playwright MCP Server](https://github.com/microsoft/playwright-mcp)
- [Files MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP Auth Servers (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Remote MCP Functions (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Soluções Microsoft de IA e Automação](https://azure.microsoft.com/en-us/products/ai-services/)

## Exercícios

1. Analise um dos estudos de caso e proponha uma abordagem alternativa de implementação.
2. Escolha uma das ideias de projeto e crie uma especificação técnica detalhada.
3. Pesquise um setor não abordado nos estudos de caso e descreva como o MCP poderia resolver seus desafios específicos.
4. Explore uma das direções futuras e crie um conceito para uma nova extensão MCP que a suporte.

Próximo: [Melhores Práticas](../08-BestPractices/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.