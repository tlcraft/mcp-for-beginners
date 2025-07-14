<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-13T23:54:54+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "br"
}
-->
# Integração do Model Context Protocol (MCP) com Azure AI Foundry

Este guia demonstra como integrar servidores Model Context Protocol (MCP) com agentes Azure AI Foundry, possibilitando uma orquestração poderosa de ferramentas e capacidades de IA corporativa.

## Introdução

Model Context Protocol (MCP) é um padrão aberto que permite que aplicações de IA se conectem de forma segura a fontes de dados e ferramentas externas. Quando integrado ao Azure AI Foundry, o MCP permite que agentes acessem e interajam com diversos serviços externos, APIs e fontes de dados de maneira padronizada.

Essa integração combina a flexibilidade do ecossistema de ferramentas do MCP com a estrutura robusta de agentes do Azure AI Foundry, oferecendo soluções de IA corporativas com amplas possibilidades de personalização.

**Note:** Se você deseja usar MCP no Azure AI Foundry Agent Service, atualmente apenas as seguintes regiões são suportadas: westus, westus2, uaenorth, southindia e switzerlandnorth

## Objetivos de Aprendizagem

Ao final deste guia, você será capaz de:

- Compreender o Model Context Protocol e seus benefícios
- Configurar servidores MCP para uso com agentes Azure AI Foundry
- Criar e configurar agentes com integração de ferramentas MCP
- Implementar exemplos práticos usando servidores MCP reais
- Gerenciar respostas de ferramentas e citações em conversas de agentes

## Pré-requisitos

Antes de começar, certifique-se de que você possui:

- Uma assinatura Azure com acesso ao AI Foundry
- Python 3.10+
- Azure CLI instalado e configurado
- Permissões adequadas para criar recursos de IA

## O que é o Model Context Protocol (MCP)?

Model Context Protocol é uma forma padronizada para aplicações de IA se conectarem a fontes de dados e ferramentas externas. Os principais benefícios incluem:

- **Integração Padronizada**: Interface consistente entre diferentes ferramentas e serviços
- **Segurança**: Mecanismos seguros de autenticação e autorização
- **Flexibilidade**: Suporte a diversas fontes de dados, APIs e ferramentas personalizadas
- **Extensibilidade**: Facilidade para adicionar novas funcionalidades e integrações

## Configurando MCP com Azure AI Foundry

### 1. Configuração do Ambiente

Primeiro, configure suas variáveis de ambiente e dependências:

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
        instructions="Você é um assistente prestativo. Use as ferramentas fornecidas para responder às perguntas. Certifique-se de citar suas fontes.",
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
    "require_approval": "never"                 # Política de aprovação: atualmente suporta apenas "never"
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
        # Cria agente com ferramentas MCP
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Você é um assistente prestativo especializado em documentação Microsoft. Use o servidor MCP do Microsoft Learn para buscar informações precisas e atualizadas. Sempre cite suas fontes.",
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
        
        # Cria thread de conversa
        thread = project_client.agents.threads.create()
        print(f"Thread criada, ID da thread: {thread.id}")

        # Envia mensagem
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="O que é .NET MAUI? Como ele se compara ao Xamarin.Forms?",
        )
        print(f"Mensagem criada, ID da mensagem: {message.id}")

        # Executa o agente
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Aguarda conclusão
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Status da execução: {run.status}")

        # Examina etapas da execução e chamadas de ferramentas
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Etapa da execução: {step.id}, status: {step.status}, tipo: {step.type}")
            if step.type == "tool_calls":
                print("Detalhes da chamada da ferramenta:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Exibe a conversa
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## Solução de Problemas Comuns

### 1. Problemas de Conexão
- Verifique se a URL do servidor MCP está acessível
- Confira as credenciais de autenticação
- Garanta a conectividade de rede

### 2. Falhas em Chamadas de Ferramentas
- Revise os argumentos e a formatação das chamadas
- Verifique requisitos específicos do servidor
- Implemente tratamento adequado de erros

### 3. Problemas de Desempenho
- Otimize a frequência das chamadas às ferramentas
- Utilize cache quando apropriado
- Monitore os tempos de resposta do servidor

## Próximos Passos

Para aprimorar ainda mais sua integração MCP:

1. **Explore Servidores MCP Personalizados**: Crie seus próprios servidores MCP para fontes de dados proprietárias
2. **Implemente Segurança Avançada**: Adicione OAuth2 ou mecanismos personalizados de autenticação
3. **Monitore e Analise**: Implemente logs e monitoramento do uso das ferramentas
4. **Escale Sua Solução**: Considere balanceamento de carga e arquiteturas distribuídas para servidores MCP

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
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.