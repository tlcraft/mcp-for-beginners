<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T06:32:48+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "pt"
}
-->
# 📖 Conceitos Básicos do MCP: Dominando o Protocolo de Contexto de Modelo para Integração de IA

O Protocolo de Contexto de Modelo (MCP) é uma estrutura padronizada e poderosa que otimiza a comunicação entre Grandes Modelos de Linguagem (LLMs) e ferramentas, aplicativos e fontes de dados externas. Este guia otimizado para SEO irá guiá-lo pelos conceitos básicos do MCP, garantindo que você entenda sua arquitetura cliente-servidor, componentes essenciais, mecânica de comunicação e melhores práticas de implementação.

## Visão Geral

Esta lição explora a arquitetura fundamental e os componentes que compõem o ecossistema do Protocolo de Contexto de Modelo (MCP). Você aprenderá sobre a arquitetura cliente-servidor, componentes-chave e mecanismos de comunicação que impulsionam as interações do MCP.

## 👩‍🎓 Objetivos de Aprendizagem Principais

Ao final desta lição, você será capaz de:

- Compreender a arquitetura cliente-servidor do MCP.
- Identificar papéis e responsabilidades de Hosts, Clientes e Servidores.
- Analisar as características principais que tornam o MCP uma camada de integração flexível.
- Aprender como a informação flui dentro do ecossistema MCP.
- Adquirir insights práticos por meio de exemplos de código em .NET, Java, Python e JavaScript.

## 🔎 Arquitetura do MCP: Um Olhar Mais Profundo

O ecossistema MCP é construído sobre um modelo cliente-servidor. Esta estrutura modular permite que aplicativos de IA interajam eficientemente com ferramentas, bancos de dados, APIs e recursos contextuais. Vamos dividir esta arquitetura em seus componentes principais.

### 1. Hosts

No Protocolo de Contexto de Modelo (MCP), os Hosts desempenham um papel crucial como a interface principal através da qual os usuários interagem com o protocolo. Hosts são aplicativos ou ambientes que iniciam conexões com servidores MCP para acessar dados, ferramentas e prompts. Exemplos de Hosts incluem ambientes de desenvolvimento integrados (IDEs) como o Visual Studio Code, ferramentas de IA como o Claude Desktop, ou agentes personalizados projetados para tarefas específicas.

**Hosts** são aplicativos LLM que iniciam conexões. Eles:

- Executam ou interagem com modelos de IA para gerar respostas.
- Iniciam conexões com servidores MCP.
- Gerenciam o fluxo de conversa e a interface do usuário.
- Controlam permissões e restrições de segurança.
- Lidam com o consentimento do usuário para compartilhamento de dados e execução de ferramentas.

### 2. Clientes

Clientes são componentes essenciais que facilitam a interação entre Hosts e servidores MCP. Clientes atuam como intermediários, permitindo que Hosts acessem e utilizem as funcionalidades fornecidas por servidores MCP. Eles desempenham um papel crucial em garantir uma comunicação fluida e troca eficiente de dados dentro da arquitetura MCP.

**Clientes** são conectores dentro do aplicativo host. Eles:

- Enviam solicitações para servidores com prompts/instruções.
- Negociam capacidades com servidores.
- Gerenciam solicitações de execução de ferramentas dos modelos.
- Processam e exibem respostas aos usuários.

### 3. Servidores

Servidores são responsáveis por lidar com solicitações de clientes MCP e fornecer respostas apropriadas. Eles gerenciam várias operações, como recuperação de dados, execução de ferramentas e geração de prompts. Servidores garantem que a comunicação entre clientes e Hosts seja eficiente e confiável, mantendo a integridade do processo de interação.

**Servidores** são serviços que fornecem contexto e capacidades. Eles:

- Registram recursos disponíveis (recursos, prompts, ferramentas).
- Recebem e executam chamadas de ferramentas do cliente.
- Fornecem informações contextuais para melhorar as respostas do modelo.
- Retornam saídas de volta ao cliente.
- Mantêm o estado através das interações quando necessário.

Servidores podem ser desenvolvidos por qualquer pessoa para estender as capacidades do modelo com funcionalidades especializadas.

### 4. Recursos do Servidor

Servidores no Protocolo de Contexto de Modelo (MCP) fornecem blocos de construção fundamentais que possibilitam interações ricas entre clientes, hosts e modelos de linguagem. Esses recursos são projetados para aprimorar as capacidades do MCP oferecendo contexto estruturado, ferramentas e prompts.

Servidores MCP podem oferecer qualquer um dos seguintes recursos:

#### 📑 Recursos

Recursos no Protocolo de Contexto de Modelo (MCP) abrangem vários tipos de contexto e dados que podem ser utilizados por usuários ou modelos de IA. Estes incluem:

- **Dados Contextuais**: Informações e contexto que usuários ou modelos de IA podem utilizar para tomada de decisões e execução de tarefas.
- **Bases de Conhecimento e Repositórios de Documentos**: Coleções de dados estruturados e não estruturados, como artigos, manuais e artigos de pesquisa, que fornecem insights e informações valiosas.
- **Arquivos Locais e Bancos de Dados**: Dados armazenados localmente em dispositivos ou dentro de bancos de dados, acessíveis para processamento e análise.
- **APIs e Serviços Web**: Interfaces e serviços externos que oferecem dados e funcionalidades adicionais, permitindo integração com diversos recursos e ferramentas online.

Um exemplo de recurso pode ser um esquema de banco de dados ou um arquivo que pode ser acessado da seguinte forma:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Prompts no Protocolo de Contexto de Modelo (MCP) incluem vários modelos pré-definidos e padrões de interação projetados para otimizar os fluxos de trabalho dos usuários e melhorar a comunicação. Estes incluem:

- **Mensagens e Fluxos de Trabalho Modelados**: Mensagens e processos pré-estruturados que orientam os usuários através de tarefas e interações específicas.
- **Padrões de Interação Pré-definidos**: Sequências padronizadas de ações e respostas que facilitam uma comunicação consistente e eficiente.
- **Modelos de Conversação Especializados**: Modelos personalizáveis adaptados para tipos específicos de conversas, garantindo interações relevantes e contextualmente apropriadas.

Um modelo de prompt pode ser assim:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Ferramentas

Ferramentas no Protocolo de Contexto de Modelo (MCP) são funções que o modelo de IA pode executar para realizar tarefas específicas. Essas ferramentas são projetadas para aprimorar as capacidades do modelo de IA, fornecendo operações estruturadas e confiáveis. Os aspectos principais incluem:

- **Funções para o Modelo de IA Executar**: Ferramentas são funções executáveis que o modelo de IA pode invocar para realizar várias tarefas.
- **Nome e Descrição Únicos**: Cada ferramenta tem um nome distinto e uma descrição detalhada que explica seu propósito e funcionalidade.
- **Parâmetros e Saídas**: Ferramentas aceitam parâmetros específicos e retornam saídas estruturadas, garantindo resultados consistentes e previsíveis.
- **Funções Discretas**: Ferramentas executam funções discretas, como pesquisas na web, cálculos e consultas a bancos de dados.

Um exemplo de ferramenta pode ser assim:

```typescript
server.tool(
  "GetProducts"
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Recursos do Cliente

No Protocolo de Contexto de Modelo (MCP), clientes oferecem vários recursos-chave para servidores, aprimorando a funcionalidade geral e a interação dentro do protocolo. Um dos recursos notáveis é a Amostragem.

### 👉 Amostragem

- **Comportamentos Agentes Iniciados pelo Servidor**: Clientes permitem que servidores iniciem ações ou comportamentos específicos de forma autônoma, aprimorando as capacidades dinâmicas do sistema.
- **Interações Recursivas com LLMs**: Este recurso permite interações recursivas com grandes modelos de linguagem (LLMs), possibilitando processamento mais complexo e iterativo de tarefas.
- **Solicitação de Completações Adicionais do Modelo**: Servidores podem solicitar completações adicionais do modelo, garantindo que as respostas sejam completas e contextualmente relevantes.

## Fluxo de Informação no MCP

O Protocolo de Contexto de Modelo (MCP) define um fluxo estruturado de informações entre hosts, clientes, servidores e modelos. Compreender esse fluxo ajuda a esclarecer como as solicitações dos usuários são processadas e como ferramentas e dados externos são integrados nas respostas do modelo.

- **Host Inicia Conexão**  
  O aplicativo host (como um IDE ou interface de chat) estabelece uma conexão com um servidor MCP, geralmente via STDIO, WebSocket ou outro transporte suportado.

- **Negociação de Capacidade**  
  O cliente (embutido no host) e o servidor trocam informações sobre seus recursos, ferramentas, recursos e versões de protocolo suportados. Isso garante que ambos os lados entendam quais capacidades estão disponíveis para a sessão.

- **Solicitação do Usuário**  
  O usuário interage com o host (por exemplo, insere um prompt ou comando). O host coleta essa entrada e a passa para o cliente para processamento.

- **Uso de Recurso ou Ferramenta**  
  - O cliente pode solicitar contexto adicional ou recursos do servidor (como arquivos, entradas de banco de dados ou artigos de base de conhecimento) para enriquecer o entendimento do modelo.
  - Se o modelo determinar que uma ferramenta é necessária (por exemplo, para buscar dados, realizar um cálculo ou chamar uma API), o cliente envia uma solicitação de invocação de ferramenta para o servidor, especificando o nome da ferramenta e os parâmetros.

- **Execução do Servidor**  
  O servidor recebe a solicitação de recurso ou ferramenta, executa as operações necessárias (como executar uma função, consultar um banco de dados ou recuperar um arquivo) e retorna os resultados para o cliente em um formato estruturado.

- **Geração de Resposta**  
  O cliente integra as respostas do servidor (dados de recursos, saídas de ferramentas, etc.) na interação contínua do modelo. O modelo usa essas informações para gerar uma resposta abrangente e contextualmente relevante.

- **Apresentação do Resultado**  
  O host recebe a saída final do cliente e a apresenta ao usuário, geralmente incluindo tanto o texto gerado pelo modelo quanto quaisquer resultados de execuções de ferramentas ou consultas de recursos.

Esse fluxo permite que o MCP suporte aplicativos de IA avançados, interativos e conscientes do contexto, conectando modelos de forma contínua com ferramentas e fontes de dados externas.

## Detalhes do Protocolo

O MCP (Protocolo de Contexto de Modelo) é construído sobre o [JSON-RPC 2.0](https://www.jsonrpc.org/), fornecendo um formato de mensagem padronizado e independente de linguagem para comunicação entre hosts, clientes e servidores. Essa base permite interações confiáveis, estruturadas e extensíveis em diversas plataformas e linguagens de programação.

### Características Principais do Protocolo

O MCP estende o JSON-RPC 2.0 com convenções adicionais para invocação de ferramentas, acesso a recursos e gerenciamento de prompts. Ele suporta múltiplas camadas de transporte (STDIO, WebSocket, SSE) e permite comunicação segura, extensível e independente de linguagem entre componentes.

#### 🧢 Protocolo Base

- **Formato de Mensagem JSON-RPC**: Todas as solicitações e respostas usam a especificação JSON-RPC 2.0, garantindo estrutura consistente para chamadas de método, parâmetros, resultados e tratamento de erros.
- **Conexões com Estado**: Sessões MCP mantêm estado através de múltiplas solicitações, suportando conversas contínuas, acumulação de contexto e gerenciamento de recursos.
- **Negociação de Capacidade**: Durante a configuração da conexão, clientes e servidores trocam informações sobre recursos suportados, versões de protocolo, ferramentas disponíveis e recursos. Isso garante que ambos os lados compreendam as capacidades um do outro e possam se adaptar de acordo.

#### ➕ Utilitários Adicionais

Abaixo estão alguns utilitários adicionais e extensões de protocolo que o MCP fornece para melhorar a experiência do desenvolvedor e permitir cenários avançados:

- **Opções de Configuração**: O MCP permite a configuração dinâmica de parâmetros de sessão, como permissões de ferramentas, acesso a recursos e configurações de modelo, adaptadas a cada interação.
- **Acompanhamento de Progresso**: Operações de longa duração podem relatar atualizações de progresso, permitindo interfaces de usuário responsivas e melhor experiência do usuário durante tarefas complexas.
- **Cancelamento de Solicitações**: Clientes podem cancelar solicitações em andamento, permitindo que os usuários interrompam operações que não são mais necessárias ou que estão demorando muito.
- **Relatório de Erros**: Mensagens de erro padronizadas e códigos ajudam a diagnosticar problemas, lidar com falhas de forma graciosa e fornecer feedback acionável para usuários e desenvolvedores.
- **Registro de Logs**: Tanto clientes quanto servidores podem emitir logs estruturados para auditoria, depuração e monitoramento de interações de protocolo.

Ao aproveitar essas características do protocolo, o MCP garante comunicação robusta, segura e flexível entre modelos de linguagem e ferramentas ou fontes de dados externas.

### 🔐 Considerações de Segurança

Implementações do MCP devem aderir a vários princípios de segurança para garantir interações seguras e confiáveis:

- **Consentimento e Controle do Usuário**: Os usuários devem fornecer consentimento explícito antes que quaisquer dados sejam acessados ou operações sejam realizadas. Eles devem ter controle claro sobre quais dados são compartilhados e quais ações são autorizadas, apoiados por interfaces de usuário intuitivas para revisar e aprovar atividades.

- **Privacidade de Dados**: Dados do usuário devem ser expostos apenas com consentimento explícito e devem ser protegidos por controles de acesso apropriados. Implementações do MCP devem proteger contra transmissão não autorizada de dados e garantir que a privacidade seja mantida em todas as interações.

- **Segurança das Ferramentas**: Antes de invocar qualquer ferramenta, é necessário consentimento explícito do usuário. Os usuários devem ter uma compreensão clara da funcionalidade de cada ferramenta, e limites de segurança robustos devem ser aplicados para evitar execuções não intencionais ou inseguras de ferramentas.

Ao seguir esses princípios, o MCP garante que a confiança, privacidade e segurança do usuário sejam mantidas em todas as interações do protocolo.

## Exemplos de Código: Componentes Principais

Abaixo estão exemplos de código em várias linguagens de programação populares que ilustram como implementar componentes principais do servidor MCP e ferramentas.

### Exemplo .NET: Criando um Servidor MCP Simples com Ferramentas

Aqui está um exemplo prático de código .NET demonstrando como implementar um servidor MCP simples com ferramentas personalizadas. Este exemplo mostra como definir e registrar ferramentas, lidar com solicitações e conectar o servidor usando o Protocolo de Contexto de Modelo.

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

Neste exemplo, mostramos como construir um servidor MCP em Python. Você também verá duas maneiras diferentes de criar ferramentas.

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

Este exemplo em JavaScript demonstra como criar um cliente MCP que se conecta a um servidor, envia um prompt e processa a resposta, incluindo quaisquer chamadas de ferramentas que foram feitas.

## Segurança e Autorização

O MCP inclui vários conceitos e mecanismos embutidos para gerenciar segurança e autorização ao longo do protocolo:

1. **Controle de Permissão de Ferramentas**:  
   Clientes podem especificar quais ferramentas um modelo está autorizado a usar durante uma sessão. Isso garante que apenas ferramentas explicitamente autorizadas estejam acessíveis, reduzindo o risco de operações não intencionais ou inseguras. Permissões podem ser configuradas dinamicamente com base em preferências do usuário, políticas organizacionais ou o contexto da interação.

2. **Autenticação**:  
   Servidores podem exigir autenticação antes de conceder acesso a ferramentas, recursos ou operações sensíveis. Isso pode envolver chaves de API, tokens OAuth ou outros esquemas de autenticação. A autenticação adequada garante que apenas clientes e usuários confiáveis possam invocar capacidades do lado do servidor.

3. **Validação**:  
   A validação de parâmetros é aplicada para todas as invocações de ferramentas. Cada ferramenta define os tipos, formatos e restrições esperados para seus parâmetros, e o servidor valida as solicitações recebidas de acordo. Isso previne que entradas malformadas ou maliciosas alcancem implementações de ferramentas e ajuda a manter a integridade das operações.

4. **Limitação de Taxa**:  
   Para prevenir abusos e garantir uso justo dos recursos do servidor, servidores MCP podem implementar limitação de taxa para chamadas de ferramentas e acesso a recursos. Limitações de taxa podem ser aplicadas por usuário, por sessão ou globalmente, e ajudam a proteger contra ataques de negação de serviço ou consumo excessivo de recursos.

Ao combinar esses mecanismos, o MCP fornece uma base segura para integrar modelos de linguagem com ferramentas e fontes de dados externas, ao mesmo tempo em que oferece aos usuários e desenvolvedores controle detalhado sobre acesso e uso.

## Mensagens do Protocolo

A comunicação do MCP usa mensagens JSON estruturadas para facilitar interações claras e confiáveis entre clientes, servidores e modelos. Os principais tipos de mensagem incluem:

- **Solicitação do Cliente**  
  Enviada do cliente para o servidor, esta mensagem normalmente inclui:
  - O prompt ou comando do usuário
  - Histórico de conversação para contexto
  - Configuração de ferramentas e permissões
  - Quaisquer metadados adicionais ou informações de sessão

- **Resposta do Modelo**  
  Retornada pelo modelo (via cliente), esta mensagem contém:
  - Texto gerado ou conclusão com base no prompt e contexto
  - Instruções opcionais de chamada de ferramenta se o modelo determinar que uma ferramenta deve ser invocada
  - Referências a recursos ou contexto adicional conforme necessário

- **Solicitação de Ferramenta**  
  Enviada do cliente para o servidor quando uma ferramenta precisa ser executada. Esta mensagem inclui:
  - O nome da ferramenta a ser invocada
  - Parâmetros necessários pela ferramenta (validados contra o esquema da ferramenta)
  - Informações contextuais ou identificadores para rastrear a solicitação

- **Resposta de Ferramenta**  
  Retornada pelo servidor após executar uma ferramenta. Esta mensagem fornece:
  - Os resultados da execução da ferramenta (dados estruturados ou conteúdo)
  - Quaisquer erros ou informações de status se a chamada da ferramenta falhar
  - Opcionalmente, metadados adicionais ou logs relacionados à execução

Essas mensagens estruturadas garantem que cada etapa no fluxo de trabalho do MCP seja explícita, rastreável e extensível, suportando cenários avançados como conversas de múltiplas etapas, encadeamento de ferramentas e tratamento robusto de erros.

## Principais Conclusões

- O MCP usa uma arquitetura cliente-servidor para conectar modelos com capacidades externas
- O ecossistema consiste em clientes, hosts, servidores, ferramentas e fontes de dados
- A comunicação pode ocorrer através de STDIO, SSE ou WebSockets
- Ferramentas são as unidades fundamentais de funcional

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para alcançar precisão, esteja ciente de que traduções automatizadas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritária. Para informações críticas, é recomendada a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações errôneas decorrentes do uso desta tradução.