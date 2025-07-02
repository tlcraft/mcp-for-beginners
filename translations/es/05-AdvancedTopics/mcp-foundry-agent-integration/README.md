<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:08:12+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "es"
}
-->
# Integración del Protocolo de Contexto de Modelo (MCP) con Azure AI Foundry

Esta guía muestra cómo integrar servidores del Protocolo de Contexto de Modelo (MCP) con agentes de Azure AI Foundry, permitiendo una potente orquestación de herramientas y capacidades de IA empresarial.

## Introducción

El Protocolo de Contexto de Modelo (MCP) es un estándar abierto que permite a las aplicaciones de IA conectarse de forma segura a fuentes de datos y herramientas externas. Al integrarse con Azure AI Foundry, MCP permite que los agentes accedan e interactúen con diversos servicios externos, APIs y fuentes de datos de manera estandarizada.

Esta integración combina la flexibilidad del ecosistema de herramientas de MCP con el sólido marco de agentes de Azure AI Foundry, proporcionando soluciones de IA empresariales con amplias capacidades de personalización.

**Note:** Si deseas usar MCP en Azure AI Foundry Agent Service, actualmente solo se soportan las siguientes regiones: westus, westus2, uaenorth, southindia y switzerlandnorth

## Objetivos de aprendizaje

Al finalizar esta guía, podrás:

- Comprender el Protocolo de Contexto de Modelo y sus beneficios
- Configurar servidores MCP para usarlos con agentes de Azure AI Foundry
- Crear y configurar agentes con integración de herramientas MCP
- Implementar ejemplos prácticos usando servidores MCP reales
- Gestionar respuestas de herramientas y citas en conversaciones de agentes

## Requisitos previos

Antes de comenzar, asegúrate de contar con:

- Una suscripción de Azure con acceso a AI Foundry
- Python 3.10+
- Azure CLI instalado y configurado
- Permisos adecuados para crear recursos de IA

## ¿Qué es el Protocolo de Contexto de Modelo (MCP)?

El Protocolo de Contexto de Modelo es una forma estandarizada para que las aplicaciones de IA se conecten a fuentes de datos y herramientas externas. Sus principales beneficios incluyen:

- **Integración estandarizada**: Interfaz consistente entre distintas herramientas y servicios
- **Seguridad**: Mecanismos seguros de autenticación y autorización
- **Flexibilidad**: Soporte para diversas fuentes de datos, APIs y herramientas personalizadas
- **Extensibilidad**: Fácil incorporación de nuevas capacidades e integraciones

## Configuración de MCP con Azure AI Foundry

### 1. Configuración del entorno

Primero, configura tus variables de entorno y dependencias:

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
        instructions="Eres un asistente útil. Usa las herramientas proporcionadas para responder preguntas. Asegúrate de citar tus fuentes.",
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
    print(f"Agente creado, ID del agente: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Identificador para el servidor MCP
    "server_url": "https://api.example.com/mcp", # Punto de acceso del servidor MCP
    "require_approval": "never"                 # Política de aprobación: actualmente solo se soporta "never"
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
        # Crear agente con herramientas MCP
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Eres un asistente útil especializado en documentación de Microsoft. Usa el servidor MCP de Microsoft Learn para buscar información precisa y actualizada. Siempre cita tus fuentes.",
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
        print(f"Agente creado, ID del agente: {agent.id}")    
        
        # Crear hilo de conversación
        thread = project_client.agents.threads.create()
        print(f"Hilo creado, ID del hilo: {thread.id}")

        # Enviar mensaje
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="¿Qué es .NET MAUI? ¿Cómo se compara con Xamarin.Forms?",
        )
        print(f"Mensaje creado, ID del mensaje: {message.id}")

        # Ejecutar el agente
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Esperar a que termine
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Estado de la ejecución: {run.status}")

        # Examinar pasos de ejecución y llamadas a herramientas
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Paso de ejecución: {step.id}, estado: {step.status}, tipo: {step.type}")
            if step.type == "tool_calls":
                print("Detalles de la llamada a la herramienta:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Mostrar conversación
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## Solución de problemas comunes

### 1. Problemas de conexión
- Verifica que la URL del servidor MCP sea accesible
- Revisa las credenciales de autenticación
- Asegura la conectividad de red

### 2. Fallos en llamadas a herramientas
- Revisa los argumentos y el formato de las llamadas a herramientas
- Comprueba los requisitos específicos del servidor
- Implementa un manejo adecuado de errores

### 3. Problemas de rendimiento
- Optimiza la frecuencia de llamadas a herramientas
- Implementa caché cuando sea apropiado
- Monitorea los tiempos de respuesta del servidor

## Próximos pasos

Para mejorar aún más tu integración MCP:

1. **Explora servidores MCP personalizados**: Construye tus propios servidores MCP para fuentes de datos propietarias
2. **Implementa seguridad avanzada**: Añade OAuth2 o mecanismos personalizados de autenticación
3. **Monitoreo y análisis**: Implementa registro y monitoreo del uso de herramientas
4. **Escala tu solución**: Considera balanceo de carga y arquitecturas distribuidas para servidores MCP

## Recursos adicionales

- [Documentación de Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- [Ejemplos del Protocolo de Contexto de Modelo](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Resumen de agentes de Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [Especificación MCP](https://spec.modelcontextprotocol.io/)

## Soporte

Para soporte adicional y preguntas:
- Consulta la [documentación de Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- Revisa los [recursos comunitarios de MCP](https://modelcontextprotocol.io/)

## Qué sigue

- [6. Contribuciones de la comunidad](../../06-CommunityContributions/README.md)

**Aviso Legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda una traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.