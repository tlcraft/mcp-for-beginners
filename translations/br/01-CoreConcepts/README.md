<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4bf553c18e7e226c3d76ab0cde627d26",
  "translation_date": "2025-05-29T20:26:59+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "br"
}
-->
# 📖 Conceitos Básicos do MCP: Dominando o Model Context Protocol para Integração de IA

O Model Context Protocol (MCP) é uma estrutura poderosa e padronizada que otimiza a comunicação entre Large Language Models (LLMs) e ferramentas, aplicações e fontes de dados externas. Este guia otimizado para SEO vai te conduzir pelos conceitos centrais do MCP, garantindo que você compreenda sua arquitetura cliente-servidor, componentes essenciais, mecânicas de comunicação e melhores práticas de implementação.

## Visão Geral

Esta lição explora a arquitetura fundamental e os componentes que formam o ecossistema do Model Context Protocol (MCP). Você vai aprender sobre a arquitetura cliente-servidor, os principais componentes e os mecanismos de comunicação que impulsionam as interações do MCP.

## 👩‍🎓 Principais Objetivos de Aprendizagem

Ao final desta lição, você irá:

- Entender a arquitetura cliente-servidor do MCP.
- Identificar os papéis e responsabilidades de Hosts, Clients e Servers.
- Analisar as características centrais que fazem do MCP uma camada flexível de integração.
- Aprender como a informação flui dentro do ecossistema MCP.
- Obter insights práticos através de exemplos de código em .NET, Java, Python e JavaScript.

## 🔎 Arquitetura MCP: Um Olhar Mais Profundo

O ecossistema MCP é construído sobre um modelo cliente-servidor. Essa estrutura modular permite que aplicações de IA interajam com ferramentas, bancos de dados, APIs e recursos contextuais de forma eficiente. Vamos detalhar essa arquitetura em seus componentes principais.

### 1. Hosts

No Model Context Protocol (MCP), os Hosts desempenham um papel crucial como a interface principal pela qual os usuários interagem com o protocolo. Hosts são aplicações ou ambientes que iniciam conexões com servidores MCP para acessar dados, ferramentas e prompts. Exemplos de Hosts incluem ambientes de desenvolvimento integrados (IDEs) como Visual Studio Code, ferramentas de IA como Claude Desktop, ou agentes personalizados criados para tarefas específicas.

**Hosts** são aplicações LLM que iniciam conexões. Eles:

- Executam ou interagem com modelos de IA para gerar respostas.
- Iniciam conexões com servidores MCP.
- Gerenciam o fluxo da conversa e a interface do usuário.
- Controlam permissões e restrições de segurança.
- Lidam com o consentimento do usuário para compartilhamento de dados e execução de ferramentas.

### 2. Clients

Clients são componentes essenciais que facilitam a interação entre Hosts e servidores MCP. Clients atuam como intermediários, permitindo que Hosts acessem e utilizem as funcionalidades oferecidas pelos servidores MCP. Eles têm papel fundamental em garantir uma comunicação fluida e troca eficiente de dados dentro da arquitetura MCP.

**Clients** são conectores dentro da aplicação host. Eles:

- Enviam solicitações aos servidores com prompts/instruções.
- Negociam capacidades com os servidores.
- Gerenciam solicitações de execução de ferramentas vindas dos modelos.
- Processam e exibem respostas aos usuários.

### 3. Servers

Servers são responsáveis por tratar as solicitações dos clients MCP e fornecer respostas adequadas. Eles gerenciam diversas operações como recuperação de dados, execução de ferramentas e geração de prompts. Os servers garantem que a comunicação entre clients e hosts seja eficiente e confiável, mantendo a integridade do processo de interação.

**Servers** são serviços que fornecem contexto e funcionalidades. Eles:

- Registram recursos disponíveis (recursos, prompts, ferramentas).
- Recebem e executam chamadas de ferramentas feitas pelo client.
- Fornecem informações contextuais para melhorar as respostas do modelo.
- Retornam os resultados para o client.
- Mantêm estado ao longo das interações quando necessário.

Servers podem ser desenvolvidos por qualquer pessoa para estender as capacidades do modelo com funcionalidades especializadas.

### 4. Recursos do Server

Os servers no Model Context Protocol (MCP) oferecem blocos fundamentais que permitem interações ricas entre clients, hosts e modelos de linguagem. Esses recursos são projetados para ampliar as capacidades do MCP oferecendo contexto estruturado, ferramentas e prompts.

Os servers MCP podem oferecer qualquer uma das seguintes funcionalidades:

#### 📑 Recursos

Recursos no Model Context Protocol (MCP) abrangem vários tipos de contexto e dados que podem ser utilizados por usuários ou modelos de IA. Estes incluem:

- **Dados Contextuais**: Informações e contexto que usuários ou modelos podem usar para tomada de decisão e execução de tarefas.
- **Bases de Conhecimento e Repositórios de Documentos**: Coleções de dados estruturados e não estruturados, como artigos, manuais e artigos científicos, que fornecem insights e informações valiosas.
- **Arquivos Locais e Bancos de Dados**: Dados armazenados localmente em dispositivos ou dentro de bancos de dados, acessíveis para processamento e análise.
- **APIs e Serviços Web**: Interfaces externas e serviços que oferecem dados adicionais e funcionalidades, permitindo integração com diversos recursos e ferramentas online.

Um exemplo de recurso pode ser um esquema de banco de dados ou um arquivo acessado assim:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts no Model Context Protocol (MCP) incluem vários templates pré-definidos e padrões de interação projetados para otimizar fluxos de trabalho dos usuários e melhorar a comunicação. Estes incluem:

- **Mensagens e Fluxos de Trabalho Modelados**: Mensagens e processos pré-estruturados que guiam os usuários por tarefas e interações específicas.
- **Padrões de Interação Pré-definidos**: Sequências padronizadas de ações e respostas que facilitam uma comunicação consistente e eficiente.
- **Templates de Conversação Especializados**: Modelos personalizáveis para tipos específicos de conversas, garantindo interações relevantes e contextualmente apropriadas.

Um template de prompt pode ser assim:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Ferramentas

Ferramentas no Model Context Protocol (MCP) são funções que o modelo de IA pode executar para realizar tarefas específicas. Essas ferramentas são projetadas para ampliar as capacidades do modelo de IA fornecendo operações estruturadas e confiáveis. Aspectos principais incluem:

- **Funções para o modelo de IA executar**: Ferramentas são funções executáveis que o modelo pode invocar para realizar diversas tarefas.
- **Nome Único e Descrição**: Cada ferramenta tem um nome distinto e uma descrição detalhada que explica seu propósito e funcionalidade.
- **Parâmetros e Resultados**: Ferramentas aceitam parâmetros específicos e retornam resultados estruturados, garantindo resultados consistentes e previsíveis.
- **Funções Discretas**: Ferramentas realizam funções específicas como buscas na web, cálculos e consultas a bancos de dados.

Um exemplo de ferramenta poderia ser assim:

```typescript
server.tool(
  "GetProducts",
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Recursos do Client

No Model Context Protocol (MCP), clients oferecem várias funcionalidades importantes para os servers, aprimorando a funcionalidade geral e a interação dentro do protocolo. Um dos recursos notáveis é o Sampling.

### 👉 Sampling

- **Comportamentos Agentes Iniciados pelo Server**: Clients permitem que servers iniciem ações ou comportamentos específicos de forma autônoma, ampliando as capacidades dinâmicas do sistema.
- **Interações Recursivas com LLMs**: Esse recurso possibilita interações recursivas com grandes modelos de linguagem (LLMs), permitindo um processamento mais complexo e iterativo das tarefas.
- **Solicitação de Completions Adicionais do Modelo**: Servers podem solicitar completions adicionais do modelo, garantindo que as respostas sejam completas e contextualmente relevantes.

## Fluxo de Informação no MCP

O Model Context Protocol (MCP) define um fluxo estruturado de informações entre hosts, clients, servers e modelos. Entender esse fluxo ajuda a esclarecer como as solicitações dos usuários são processadas e como ferramentas e dados externos são integrados nas respostas do modelo.

- **Host Inicia Conexão**  
  A aplicação host (como um IDE ou interface de chat) estabelece uma conexão com um servidor MCP, tipicamente via STDIO, WebSocket ou outro transporte suportado.

- **Negociação de Capacidades**  
  O client (embutido no host) e o server trocam informações sobre os recursos, ferramentas, versões do protocolo e funcionalidades suportadas. Isso garante que ambos os lados entendam as capacidades disponíveis para a sessão.

- **Solicitação do Usuário**  
  O usuário interage com o host (ex: insere um prompt ou comando). O host coleta essa entrada e a envia para o client para processamento.

- **Uso de Recurso ou Ferramenta**  
  - O client pode solicitar contexto ou recursos adicionais do server (como arquivos, entradas de banco de dados ou artigos de base de conhecimento) para enriquecer a compreensão do modelo.
  - Se o modelo determinar que uma ferramenta é necessária (ex: buscar dados, realizar cálculo ou chamar uma API), o client envia uma solicitação de invocação de ferramenta ao server, especificando o nome da ferramenta e os parâmetros.

- **Execução pelo Server**  
  O server recebe a solicitação de recurso ou ferramenta, executa as operações necessárias (como rodar uma função, consultar banco de dados ou recuperar arquivo) e retorna os resultados ao client em formato estruturado.

- **Geração da Resposta**  
  O client integra as respostas do server (dados de recurso, resultados de ferramenta, etc.) na interação em andamento com o modelo. O modelo usa essa informação para gerar uma resposta completa e contextualmente relevante.

- **Apresentação do Resultado**  
  O host recebe a saída final do client e a apresenta ao usuário, geralmente incluindo tanto o texto gerado pelo modelo quanto os resultados das execuções de ferramentas ou consultas a recursos.

Esse fluxo permite que o MCP suporte aplicações de IA avançadas, interativas e conscientes do contexto, conectando modelos a ferramentas e fontes de dados externas de forma fluida.

## Detalhes do Protocolo

O MCP (Model Context Protocol) é construído sobre [JSON-RPC 2.0](https://www.jsonrpc.org/), fornecendo um formato de mensagem padronizado e independente de linguagem para comunicação entre hosts, clients e servers. Essa base possibilita interações confiáveis, estruturadas e extensíveis em diversas plataformas e linguagens de programação.

### Principais Características do Protocolo

O MCP estende o JSON-RPC 2.0 com convenções adicionais para invocação de ferramentas, acesso a recursos e gerenciamento de prompts. Suporta múltiplas camadas de transporte (STDIO, WebSocket, SSE) e permite comunicação segura, extensível e independente de linguagem entre os componentes.

#### 🧢 Protocolo Base

- **Formato de Mensagem JSON-RPC**: Todas as solicitações e respostas usam a especificação JSON-RPC 2.0, garantindo estrutura consistente para chamadas de métodos, parâmetros, resultados e tratamento de erros.
- **Conexões com Estado**: Sessões MCP mantêm estado ao longo de múltiplas requisições, suportando conversas contínuas, acumulação de contexto e gerenciamento de recursos.
- **Negociação de Capacidades**: Durante a configuração da conexão, clients e servers trocam informações sobre recursos suportados, versões do protocolo, ferramentas e recursos disponíveis. Isso garante que ambos os lados compreendam as capacidades um do outro e possam se adaptar.

#### ➕ Utilitários Adicionais

A seguir, algumas utilidades e extensões do protocolo que o MCP oferece para melhorar a experiência do desenvolvedor e permitir cenários avançados:

- **Opções de Configuração**: MCP permite configuração dinâmica de parâmetros da sessão, como permissões de ferramentas, acesso a recursos e configurações do modelo, adaptados a cada interação.
- **Monitoramento de Progresso**: Operações longas podem reportar atualizações de progresso, permitindo interfaces responsivas e melhor experiência do usuário durante tarefas complexas.
- **Cancelamento de Solicitações**: Clients podem cancelar requisições em andamento, permitindo que usuários interrompam operações que não são mais necessárias ou estão demorando demais.
- **Relato de Erros**: Mensagens e códigos de erro padronizados ajudam a diagnosticar problemas, tratar falhas de forma elegante e fornecer feedback acionável para usuários e desenvolvedores.
- **Registro de Logs**: Tanto clients quanto servers podem emitir logs estruturados para auditoria, depuração e monitoramento das interações do protocolo.

Aproveitando esses recursos do protocolo, o MCP garante comunicação robusta, segura e flexível entre modelos de linguagem e ferramentas ou fontes de dados externas.

### 🔐 Considerações de Segurança

Implementações do MCP devem seguir alguns princípios-chave de segurança para garantir interações seguras e confiáveis:

- **Consentimento e Controle do Usuário**: Os usuários devem fornecer consentimento explícito antes que qualquer dado seja acessado ou operações realizadas. Eles devem ter controle claro sobre quais dados são compartilhados e quais ações são autorizadas, suportados por interfaces intuitivas para revisão e aprovação das atividades.

- **Privacidade dos Dados**: Dados dos usuários só devem ser expostos com consentimento explícito e devem ser protegidos por controles de acesso apropriados. Implementações MCP devem evitar transmissão não autorizada de dados e garantir que a privacidade seja mantida em todas as interações.

- **Segurança das Ferramentas**: Antes de invocar qualquer ferramenta, é necessário consentimento explícito do usuário. Os usuários devem compreender claramente a funcionalidade de cada ferramenta, e limites de segurança rigorosos devem ser aplicados para evitar execuções não intencionais ou inseguras.

Seguindo esses princípios, o MCP assegura que a confiança, privacidade e segurança dos usuários sejam mantidas em todas as interações do protocolo.

## Exemplos de Código: Componentes Principais

A seguir, exemplos de código em várias linguagens populares que ilustram como implementar componentes chave de servidores MCP e ferramentas.

### Exemplo .NET: Criando um Servidor MCP Simples com Ferramentas

Aqui está um exemplo prático em .NET demonstrando como implementar um servidor MCP simples com ferramentas personalizadas. Este exemplo mostra como definir e registrar ferramentas, tratar requisições e conectar o servidor usando o Model Context Protocol.

```csharp
using System;
using System.Threading.Tasks;
using ModelContextProtocol.Server;
using ModelContextProtocol.Server.Transport;
using ModelContextProtocol.Server.Tools;

public class WeatherServer
{
    public static async Task Main(string[] args)
    {
        // Create an MCP server
        var server = new McpServer(
            name: "Weather MCP Server",
            version: "1.0.0"
        );
        
        // Register our custom weather tool
        server.AddTool<string, WeatherData>("weatherTool", 
            description: "Gets current weather for a location",
            execute: async (location) => {
                // Call weather API (simplified)
                var weatherData = await GetWeatherDataAsync(location);
                return weatherData;
            });
        
        // Connect the server using stdio transport
        var transport = new StdioServerTransport();
        await server.ConnectAsync(transport);
        
        Console.WriteLine("Weather MCP Server started");
        
        // Keep the server running until process is terminated
        await Task.Delay(-1);
    }
    
    private static async Task<WeatherData> GetWeatherDataAsync(string location)
    {
        // This would normally call a weather API
        // Simplified for demonstration
        await Task.Delay(100); // Simulate API call
        return new WeatherData { 
            Temperature = 72.5,
            Conditions = "Sunny",
            Location = location
        };
    }
}

public class WeatherData
{
    public double Temperature { get; set; }
    public string Conditions { get; set; }
    public string Location { get; set; }
}
```

### Exemplo Java: Componentes do Servidor MCP

Este exemplo demonstra o mesmo servidor MCP e registro de ferramentas do exemplo .NET acima, mas implementado em Java.

```java
import io.modelcontextprotocol.server.McpServer;
import io.modelcontextprotocol.server.McpToolDefinition;
import io.modelcontextprotocol.server.transport.StdioServerTransport;
import io.modelcontextprotocol.server.tool.ToolExecutionContext;
import io.modelcontextprotocol.server.tool.ToolResponse;

public class WeatherMcpServer {
    public static void main(String[] args) throws Exception {
        // Create an MCP server
        McpServer server = McpServer.builder()
            .name("Weather MCP Server")
            .version("1.0.0")
            .build();
            
        // Register a weather tool
        server.registerTool(McpToolDefinition.builder("weatherTool")
            .description("Gets current weather for a location")
            .parameter("location", String.class)
            .execute((ToolExecutionContext ctx) -> {
                String location = ctx.getParameter("location", String.class);
                
                // Get weather data (simplified)
                WeatherData data = getWeatherData(location);
                
                // Return formatted response
                return ToolResponse.content(
                    String.format("Temperature: %.1f°F, Conditions: %s, Location: %s", 
                    data.getTemperature(), 
                    data.getConditions(), 
                    data.getLocation())
                );
            })
            .build());
        
        // Connect the server using stdio transport
        try (StdioServerTransport transport = new StdioServerTransport()) {
            server.connect(transport);
            System.out.println("Weather MCP Server started");
            // Keep server running until process is terminated
            Thread.currentThread().join();
        }
    }
    
    private static WeatherData getWeatherData(String location) {
        // Implementation would call a weather API
        // Simplified for example purposes
        return new WeatherData(72.5, "Sunny", location);
    }
}

class WeatherData {
    private double temperature;
    private String conditions;
    private String location;
    
    public WeatherData(double temperature, String conditions, String location) {
        this.temperature = temperature;
        this.conditions = conditions;
        this.location = location;
    }
    
    public double getTemperature() {
        return temperature;
    }
    
    public String getConditions() {
        return conditions;
    }
    
    public String getLocation() {
        return location;
    }
}
```

### Exemplo Python: Construindo um Servidor MCP

Neste exemplo mostramos como construir um servidor MCP em Python. Também são apresentadas duas formas diferentes de criar ferramentas.

```python
#!/usr/bin/env python3
import asyncio
from mcp.server.fastmcp import FastMCP
from mcp.server.transports.stdio import serve_stdio

# Create a FastMCP server
mcp = FastMCP(
    name="Weather MCP Server",
    version="1.0.0"
)

@mcp.tool()
def get_weather(location: str) -> dict:
    """Gets current weather for a location."""
    # This would normally call a weather API
    # Simplified for demonstration
    return {
        "temperature": 72.5,
        "conditions": "Sunny",
        "location": location
    }

# Alternative approach using a class
class WeatherTools:
    @mcp.tool()
    def forecast(self, location: str, days: int = 1) -> dict:
        """Gets weather forecast for a location for the specified number of days."""
        # This would normally call a weather API forecast endpoint
        # Simplified for demonstration
        return {
            "location": location,
            "forecast": [
                {"day": i+1, "temperature": 70 + i, "conditions": "Partly Cloudy"}
                for i in range(days)
            ]
        }

# Initialize class for its methods to be registered as tools
weather_tools = WeatherTools()

if __name__ == "__main__":
    # Start the server with stdio transport
    print("Weather MCP Server starting...")
    asyncio.run(serve_stdio(mcp))
```

### Exemplo JavaScript: Criando um Servidor MCP

Este exemplo mostra a criação de um servidor MCP em JavaScript e como registrar duas ferramentas relacionadas ao clima.

```javascript
// Using the official Model Context Protocol SDK
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod"; // For parameter validation

// Create an MCP server
const server = new McpServer({
  name: "Weather MCP Server",
  version: "1.0.0"
});

// Define a weather tool
server.tool(
  "weatherTool",
  {
    location: z.string().describe("The location to get weather for")
  },
  async ({ location }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const weatherData = await getWeatherData(location);
    
    return {
      content: [
        { 
          type: "text", 
          text: `Temperature: ${weatherData.temperature}°F, Conditions: ${weatherData.conditions}, Location: ${weatherData.location}` 
        }
      ]
    };
  }
);

// Define a forecast tool
server.tool(
  "forecastTool",
  {
    location: z.string(),
    days: z.number().default(3).describe("Number of days for forecast")
  },
  async ({ location, days }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const forecast = await getForecastData(location, days);
    
    return {
      content: [
        { 
          type: "text", 
          text: `${days}-day forecast for ${location}: ${JSON.stringify(forecast)}` 
        }
      ]
    };
  }
);

// Helper functions
async function getWeatherData(location) {
  // Simulate API call
  return {
    temperature: 72.5,
    conditions: "Sunny",
    location: location
  };
}

async function getForecastData(location, days) {
  // Simulate API call
  return Array.from({ length: days }, (_, i) => ({
    day: i + 1,
    temperature: 70 + Math.floor(Math.random() * 10),
    conditions: i % 2 === 0 ? "Sunny" : "Partly Cloudy"
  }));
}

// Connect the server using stdio transport
const transport = new StdioServerTransport();
server.connect(transport).catch(console.error);

console.log("Weather MCP Server started");
```

Este exemplo em JavaScript demonstra como criar um client MCP que se conecta a um servidor, envia um prompt e processa a resposta, incluindo quaisquer chamadas de ferramentas realizadas.

## Segurança e Autorização

O MCP inclui vários conceitos e mecanismos embutidos para gerenciar segurança e autorização ao longo do protocolo:

1. **Controle de Permissão de Ferramentas**  
  Clients podem especificar quais ferramentas um modelo pode usar durante uma sessão. Isso garante que apenas ferramentas explicitamente autorizadas estejam acessíveis, reduzindo riscos de operações não intencionais ou inseguras. Permissões podem ser configuradas dinamicamente com base em preferências do usuário, políticas organizacionais ou contexto da interação.

2. **Autenticação**  
  Servers podem exigir autenticação antes de conceder acesso a ferramentas, recursos ou operações sensíveis. Isso pode envolver chaves de API, tokens OAuth ou outros esquemas de autenticação. Autenticação adequada garante que apenas clients e usuários confiáveis possam invocar funcionalidades do servidor.

3. **Validação**  
  Validação de parâmetros é aplicada para todas as invocações de ferramentas. Cada ferramenta define os tipos, formatos e restrições esperados para seus parâmetros, e o servidor valida as requisições recebidas de acordo. Isso evita entrada malformada ou maliciosa e ajuda a manter a integridade das operações.

4. **Limitação de Taxa**  
  Para evitar abusos e garantir uso justo dos recursos do servidor, servers MCP podem implementar limitação de taxa para chamadas de ferramentas e acesso a recursos. Limites podem ser aplicados por usuário, por sessão ou globalmente, ajudando a proteger contra ataques de negação de serviço ou consumo excessivo.

Combinando esses mecanismos, o MCP oferece uma base segura para integrar modelos de linguagem com ferramentas e fontes de dados externas, ao mesmo tempo que oferece controle detalhado de acesso e uso para usuários e desenvolvedores.

## Mensagens do Protocolo

A comunicação MCP usa mensagens JSON estruturadas para facilitar interações claras e confiáveis entre clients, servers e modelos. Os principais tipos de mensagens incluem:

- **Solicitação do Client**  
  Enviada do client para o server, essa mensagem geralmente inclui:
  - O prompt ou comando do usuário
  - Histórico da conversa para contexto
  - Configuração e permissões das ferramentas
  - Metadados adicionais ou informações da sessão

- **Resposta do Modelo**  
  Retornada pelo modelo (via client), essa mensagem contém:
  - Texto gerado ou completion baseado no prompt e contexto
  - Instruções opcionais de chamada de ferramenta caso o modelo determine que deve ser invocada
  - Referências a recursos ou contexto adicional conforme necessário

- **Solicitação de Ferramenta**  
  Enviada do client para o server quando uma ferramenta precisa ser executada. Essa mensagem inclui:
  - Nome da ferramenta a ser invocada
  - Parâmetros requeridos pela ferramenta (validados conforme o esquema da ferramenta)
  - Informação contextual ou identificadores para rastrear a solicitação

- **Resposta de Ferramenta**  
  Retornada pelo server após executar a ferramenta. Essa mensagem fornece:
  - Resultados da execução da ferramenta (dados estruturados ou conteúdo)
  - Erros ou status caso a chamada tenha falhado
  - Opcionalmente, metadados ou logs relacionados à execução

Essas mensagens estruturadas garantem que cada etapa do fluxo MCP seja explícita, rastreável e extensível, suportando cenários avançados como conversas multi-turno, encadeamento de ferramentas e tratamento robusto de erros.

## Principais Conclusões

- MCP usa arquitetura cliente-servidor para conectar modelos a capacidades externas
- O ecossistema é formado por clients, hosts, servers, ferramentas e fontes de dados
- A comunicação pode ocorrer via STDIO, SSE ou WebSockets
- Ferramentas são as unidades fundamentais de funcionalidade expostas aos modelos
- Protocolos de comunicação estruturados garantem interações consistentes

## Exercício

Projete uma ferramenta MCP simples que seria útil no seu domínio. Defina:
1. Qual seria o nome da ferramenta
2. Quais parâmetros ela aceitaria
3. Qual saída ela retornaria
4. Como um modelo poderia usar essa ferramenta para resolver problemas dos usuários

---

## O que vem a seguir

Próximo: [Capítulo 2: Segurança](/02-Security/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, por favor, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.