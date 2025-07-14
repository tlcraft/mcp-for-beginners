<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:19:33+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "es"
}
-->
# Estudio de caso: Exponer REST API en API Management como un servidor MCP

Azure API Management es un servicio que proporciona una puerta de enlace sobre tus puntos finales de API. Su funcionamiento es que Azure API Management actúa como un proxy frente a tus APIs y puede decidir qué hacer con las solicitudes entrantes.

Al usarlo, agregas una gran cantidad de características como:

- **Seguridad**, puedes usar desde claves API, JWT hasta identidad administrada.
- **Limitación de tasa**, una función excelente es poder decidir cuántas llamadas se permiten en una unidad de tiempo determinada. Esto ayuda a garantizar que todos los usuarios tengan una gran experiencia y también que tu servicio no se vea saturado con solicitudes.
- **Escalado y balanceo de carga**. Puedes configurar varios puntos finales para distribuir la carga y también decidir cómo hacer el "balanceo de carga".
- **Funciones de IA como caché semántica**, límite de tokens, monitoreo de tokens y más. Estas son funciones excelentes que mejoran la capacidad de respuesta y te ayudan a controlar el gasto de tokens. [Lee más aquí](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## ¿Por qué MCP + Azure API Management?

Model Context Protocol está convirtiéndose rápidamente en un estándar para aplicaciones de IA agentica y para exponer herramientas y datos de manera consistente. Azure API Management es una opción natural cuando necesitas "gestionar" APIs. Los servidores MCP a menudo se integran con otras APIs para resolver solicitudes a una herramienta, por ejemplo. Por lo tanto, combinar Azure API Management y MCP tiene mucho sentido.

## Resumen

En este caso de uso específico aprenderemos a exponer puntos finales de API como un servidor MCP. Al hacer esto, podemos fácilmente integrar estos puntos finales en una aplicación agentica y al mismo tiempo aprovechar las funciones de Azure API Management.

## Características clave

- Seleccionas los métodos del endpoint que quieres exponer como herramientas.
- Las funciones adicionales que obtienes dependen de lo que configures en la sección de políticas para tu API. Pero aquí te mostraremos cómo agregar limitación de tasa.

## Paso previo: importar una API

Si ya tienes una API en Azure API Management, perfecto, puedes saltarte este paso. Si no, revisa este enlace, [importar una API a Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Exponer API como servidor MCP

Para exponer los puntos finales de la API, sigamos estos pasos:

1. Navega al Portal de Azure y a la siguiente dirección <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Navega a tu instancia de API Management.

1. En el menú izquierdo, selecciona APIs > MCP Servers > + Crear nuevo MCP Server.

1. En API, selecciona una REST API para exponer como servidor MCP.

1. Selecciona una o más operaciones de API para exponer como herramientas. Puedes seleccionar todas las operaciones o solo algunas específicas.

    ![Selecciona los métodos a exponer](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Selecciona **Crear**.

1. Navega a la opción de menú **APIs** y **MCP Servers**, deberías ver lo siguiente:

    ![Ver el servidor MCP en el panel principal](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    El servidor MCP está creado y las operaciones de API están expuestas como herramientas. El servidor MCP aparece listado en el panel de MCP Servers. La columna URL muestra el endpoint del servidor MCP que puedes llamar para pruebas o desde una aplicación cliente.

## Opcional: Configurar políticas

Azure API Management tiene el concepto central de políticas donde configuras diferentes reglas para tus endpoints, como por ejemplo limitación de tasa o caché semántica. Estas políticas se escriben en XML.

Aquí te mostramos cómo configurar una política para limitar la tasa en tu servidor MCP:

1. En el portal, bajo APIs, selecciona **MCP Servers**.

1. Selecciona el servidor MCP que creaste.

1. En el menú izquierdo, bajo MCP, selecciona **Policies**.

1. En el editor de políticas, agrega o edita las políticas que quieres aplicar a las herramientas del servidor MCP. Las políticas se definen en formato XML. Por ejemplo, puedes agregar una política para limitar las llamadas a las herramientas del servidor MCP (en este ejemplo, 5 llamadas por 30 segundos por dirección IP cliente). Aquí está el XML que causará la limitación de tasa:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Aquí una imagen del editor de políticas:

    ![Editor de políticas](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Pruébalo

Vamos a asegurarnos de que nuestro servidor MCP funciona como se espera.

Para esto, usaremos Visual Studio Code y GitHub Copilot en modo Agente. Añadiremos el servidor MCP a un archivo *mcp.json*. Al hacerlo, Visual Studio Code actuará como un cliente con capacidades agenticas y los usuarios finales podrán escribir un prompt e interactuar con dicho servidor.

Veamos cómo agregar el servidor MCP en Visual Studio Code:

1. Usa el comando MCP: **Add Server desde la Paleta de Comandos**.

1. Cuando se te pida, selecciona el tipo de servidor: **HTTP (HTTP o Server Sent Events)**.

1. Ingresa la URL del servidor MCP en API Management. Ejemplo: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (para endpoint SSE) o **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (para endpoint MCP), nota la diferencia entre los transportes es `/sse` o `/mcp`.

1. Ingresa un ID para el servidor a tu elección. No es un valor importante, pero te ayudará a recordar qué instancia de servidor es.

1. Selecciona si quieres guardar la configuración en la configuración del espacio de trabajo o en la configuración de usuario.

  - **Configuración del espacio de trabajo** - La configuración del servidor se guarda en un archivo .vscode/mcp.json disponible solo en el espacio de trabajo actual.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    o si eliges HTTP streaming como transporte sería ligeramente diferente:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **Configuración de usuario** - La configuración del servidor se añade a tu archivo global *settings.json* y está disponible en todos los espacios de trabajo. La configuración se ve similar a la siguiente:

    ![Configuración de usuario](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. También necesitas agregar configuración, un encabezado para asegurarte de que se autentica correctamente hacia Azure API Management. Usa un encabezado llamado **Ocp-Apim-Subscription-Key**.

    - Así es como puedes agregarlo a la configuración:

    ![Agregar encabezado para autenticación](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), esto hará que se muestre un prompt para pedirte el valor de la clave API que puedes encontrar en el Portal de Azure para tu instancia de Azure API Management.

   - Para agregarlo en *mcp.json* en su lugar, puedes hacerlo así:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Usar modo Agente

Ahora que todo está configurado ya sea en la configuración o en *.vscode/mcp.json*, probémoslo.

Debería aparecer un ícono de Herramientas así, donde se listan las herramientas expuestas desde tu servidor:

![Herramientas del servidor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Haz clic en el ícono de herramientas y deberías ver una lista de herramientas así:

    ![Herramientas](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Ingresa un prompt en el chat para invocar la herramienta. Por ejemplo, si seleccionaste una herramienta para obtener información sobre un pedido, puedes preguntarle al agente sobre un pedido. Aquí un ejemplo de prompt:

    ```text
    get information from order 2
    ```

    Ahora se te mostrará un ícono de herramientas pidiéndote que continúes llamando a una herramienta. Selecciona para continuar ejecutando la herramienta, deberías ver una salida así:

    ![Resultado del prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **lo que ves arriba depende de las herramientas que hayas configurado, pero la idea es que obtengas una respuesta textual como la mostrada**


## Referencias

Aquí puedes aprender más:

- [Tutorial sobre Azure API Management y MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Ejemplo en Python: Servidores MCP remotos seguros usando Azure API Management (experimental)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Laboratorio de autorización de cliente MCP](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Usa la extensión de Azure API Management para VS Code para importar y gestionar APIs](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Registrar y descubrir servidores MCP remotos en Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Excelente repositorio que muestra muchas capacidades de IA con Azure API Management
- [Talleres de AI Gateway](https://azure-samples.github.io/AI-Gateway/) Contiene talleres usando Azure Portal, que es una excelente forma de comenzar a evaluar capacidades de IA.

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.