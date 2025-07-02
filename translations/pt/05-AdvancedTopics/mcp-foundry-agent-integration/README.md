<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:13:42+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "pt"
}
-->
# Integração do Model Context Protocol (MCP) com Azure AI Foundry

Este guia demonstra como integrar servidores Model Context Protocol (MCP) com agentes Azure AI Foundry, permitindo uma orquestração avançada de ferramentas e capacidades de IA empresarial.

## Introdução

O Model Context Protocol (MCP) é um padrão aberto que permite que aplicações de IA se conectem de forma segura a fontes de dados externas e ferramentas. Quando integrado com o Azure AI Foundry, o MCP permite que agentes acedam e interajam com vários serviços externos, APIs e fontes de dados de forma padronizada.

Esta integração combina a flexibilidade do ecossistema de ferramentas do MCP com a robusta estrutura de agentes do Azure AI Foundry, proporcionando soluções de IA empresariais com amplas capacidades de personalização.

**Note:** Se pretende usar MCP no Azure AI Foundry Agent Service, atualmente apenas as seguintes regiões são suportadas: westus, westus2, uaenorth, southindia e switzerlandnorth

## Objetivos de Aprendizagem

No final deste guia, será capaz de:

- Compreender o Model Context Protocol e os seus benefícios
- Configurar servidores MCP para uso com agentes Azure AI Foundry
- Criar e configurar agentes com integração de ferramentas MCP
- Implementar exemplos práticos usando servidores MCP reais
- Gerir respostas das ferramentas e citações em conversas dos agentes

## Pré-requisitos

Antes de começar, assegure-se de que tem:

- Uma subscrição Azure com acesso ao AI Foundry
- Python 3.10+ 
- Azure CLI instalado e configurado
- Permissões adequadas para criar recursos de IA

## O que é o Model Context Protocol (MCP)?

O Model Context Protocol é uma forma padronizada para aplicações de IA se ligarem a fontes de dados externas e ferramentas. Os principais benefícios incluem:

- **Integração Padronizada**: Interface consistente entre diferentes ferramentas e serviços
- **Segurança**: Mecanismos seguros de autenticação e autorização
- **Flexibilidade**: Suporte para várias fontes de dados, APIs e ferramentas personalizadas
- **Extensibilidade**: Fácil adição de novas capacidades e integrações

## Configuração do MCP com Azure AI Foundry

### 1. Configuração do Ambiente

Primeiro, configure as suas variáveis de ambiente e dependências:

```python
import os
import time
import json
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential


### 1. Initialize the AI Project Client

```python
project_client = AIProjectClient(
    endpoint="https://your-project-endpoint.services.ai.azure.com/api/projects/your-project",
    credential=DefaultAzureCredential(),
)
```

### 2. Create an Agent with MCP Tools

Configure an agent with MCP server integration:

```python
with project_client:
    agent = project_client.agents.create_agent(
        model="gpt-4.1-nano", 
        name="mcp_agent", 
        instructions="És um assistente prestável. Usa as ferramentas fornecidas para responder às perguntas. Assegura-te de citar as tuas fontes.",
        tools=[
            {
                "type": "mcp",
                "server_label": "microsoft_docs",
                "server_url": "https://learn.microsoft.com/api/mcp",
                "require_approval": "never"
            }
        ],
        tool_resources=None
    )
    print(f"Agente criado, ID do agente: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Identificador para o servidor MCP
    "server_url": "https://api.example.com/mcp", # Endpoint do servidor MCP
    "require_approval": "never"                 # Política de aprovação: atualmente só suporta "never"
}
```

## Complete Example: Using Microsoft Learn MCP Server

Here's a complete example that demonstrates creating an agent with MCP integration and processing a conversation:

```python
import time
import json
import os
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential

def create_mcp_agent_example():

    project_client = AIProjectClient(
        endpoint="https://your-endpoint.services.ai.azure.com/api/projects/your-project",
        credential=DefaultAzureCredential(),
    )

    with project_client:
        # Criar agente com ferramentas MCP
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="És um assistente prestável especializado na documentação Microsoft. Usa o servidor MCP do Microsoft Learn para pesquisar informação precisa e atualizada. Cita sempre as tuas fontes.",
            tools=[
                {
                    "type": "mcp",
                    "server_label": "mslearn",
                    "server_url": "https://learn.microsoft.com/api/mcp",
                    "require_approval": "never"
                }
            ],
            tool_resources=None
        )
        print(f"Agente criado, ID do agente: {agent.id}")    
        
        # Criar tópico de conversa
        thread = project_client.agents.threads.create()
        print(f"Tópico criado, ID do tópico: {thread.id}")

        # Enviar mensagem
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="O que é o .NET MAUI? Como se compara ao Xamarin.Forms?",
        )
        print(f"Mensagem criada, ID da mensagem: {message.id}")

        # Executar o agente
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Aguardar conclusão
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Estado da execução: {run.status}")

        # Analisar passos da execução e chamadas de ferramentas
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Passo da execução: {step.id}, estado: {step.status}, tipo: {step.type}")
            if step.type == "tool_calls":
                print("Detalhes da chamada da ferramenta:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Mostrar conversa
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()


## Resolução de Problemas Comuns

### 1. Problemas de Conexão
- Verifique se o URL do servidor MCP está acessível
- Confirme as credenciais de autenticação
- Assegure a conectividade de rede

### 2. Falhas em Chamadas de Ferramentas
- Reveja os argumentos e formato das chamadas às ferramentas
- Verifique os requisitos específicos do servidor
- Implemente um tratamento adequado de erros

### 3. Problemas de Performance
- Otimize a frequência das chamadas às ferramentas
- Utilize cache quando apropriado
- Monitorize os tempos de resposta do servidor

## Próximos Passos

Para melhorar ainda mais a sua integração MCP:

1. **Explore Servidores MCP Personalizados**: Construa os seus próprios servidores MCP para fontes de dados proprietárias
2. **Implemente Segurança Avançada**: Adicione OAuth2 ou mecanismos personalizados de autenticação
3. **Monitorização e Análise**: Implemente registos e monitorização do uso das ferramentas
4. **Escale a Sua Solução**: Considere balanceamento de carga e arquiteturas distribuídas de servidores MCP

## Recursos Adicionais

- [Documentação Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- [Exemplos do Model Context Protocol](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Visão Geral dos Agentes Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [Especificação MCP](https://spec.modelcontextprotocol.io/)

## Suporte

Para suporte adicional e dúvidas:
- Consulte a [documentação Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- Verifique os [recursos da comunidade MCP](https://modelcontextprotocol.io/)

## O que vem a seguir

- [6. Contribuições da Comunidade](../../06-CommunityContributions/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em atenção que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional por um humano. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações erradas decorrentes da utilização desta tradução.