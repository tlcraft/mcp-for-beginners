<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c37fabfbc0dcbc9a4afb6d17e7d3be9f",
  "translation_date": "2025-05-16T15:12:53+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "es"
}
-->
Hablemos más sobre cómo usamos la interfaz visual en las siguientes secciones.

## Enfoque

Así es como debemos abordar esto a un nivel general:

- Configurar un archivo para encontrar nuestro MCP Server.
- Iniciar/Conectar con dicho servidor para que liste sus capacidades.
- Usar esas capacidades a través de la interfaz de chat de GitHub Copilot.

Genial, ahora que entendemos el flujo, intentemos usar un MCP Server a través de Visual Studio Code mediante un ejercicio.

## Ejercicio: Consumiendo un servidor

En este ejercicio, configuraremos Visual Studio Code para encontrar tu MCP Server y que pueda ser usado desde la interfaz de chat de GitHub Copilot.

### -0- Paso previo, habilitar el descubrimiento de MCP Server

Puede que necesites habilitar el descubrimiento de MCP Servers.

1. Ve a `Archivo -> Preferencias -> Configuración` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` en el archivo settings.json.

### -1- Crear archivo de configuración

Comienza creando un archivo de configuración en la raíz de tu proyecto, necesitarás un archivo llamado MCP.json que debe colocarse en una carpeta llamada .vscode. Debería verse así:

```text
.vscode
|-- mcp.json
```

A continuación, veamos cómo podemos agregar una entrada de servidor.

### -2- Configurar un servidor

Agrega el siguiente contenido a *mcp.json*:

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "cmd",
           "args": [
               "/c", "node", "<absolute path>\\build\\index.js"
           ]
       }
    }
}
```

Aquí tienes un ejemplo simple de cómo iniciar un servidor escrito en Node.js, para otros entornos indica el comando correcto para iniciar el servidor usando `command` and `args`.

### -3- Iniciar el servidor

Ahora que has agregado una entrada, vamos a iniciar el servidor:

1. Ubica tu entrada en *mcp.json* y asegúrate de encontrar el ícono de "play":

  ![Iniciando servidor en Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.es.png)  

1. Haz clic en el ícono de "play", deberías ver que el ícono de herramientas en el chat de GitHub Copilot aumenta el número de herramientas disponibles. Si haces clic en dicho ícono de herramientas, verás una lista de herramientas registradas. Puedes marcar o desmarcar cada herramienta dependiendo de si quieres que GitHub Copilot las use como contexto:

  ![Iniciando servidor en Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.es.png)

1. Para ejecutar una herramienta, escribe un prompt que sepas que coincidirá con la descripción de una de tus herramientas, por ejemplo un prompt como "add 22 to 1":

  ![Ejecutando una herramienta desde GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.es.png)

  Deberías ver una respuesta que diga 23.

## Tarea

Intenta agregar una entrada de servidor a tu archivo *mcp.json* y asegúrate de poder iniciar/detener el servidor. También asegúrate de poder comunicarte con las herramientas en tu servidor a través de la interfaz de chat de GitHub Copilot.

## Solución

[Solución](./solution/README.md)

## Puntos Clave

Los puntos clave de este capítulo son los siguientes:

- Visual Studio Code es un gran cliente que te permite consumir varios MCP Servers y sus herramientas.
- La interfaz de chat de GitHub Copilot es cómo interactúas con los servidores.
- Puedes solicitar al usuario entradas como claves API que pueden ser pasadas al MCP Server al configurar la entrada del servidor en el archivo *mcp.json*.

## Ejemplos

- [Calculadora Java](../samples/java/calculator/README.md)
- [Calculadora .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](../samples/javascript/README.md)
- [Calculadora TypeScript](../samples/typescript/README.md)
- [Calculadora Python](../../../../03-GettingStarted/samples/python)

## Recursos Adicionales

- [Documentación de Visual Studio](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Qué Sigue

- Siguiente: [Creando un servidor SSE](/03-GettingStarted/05-sse-server/README.md)

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda una traducción profesional realizada por humanos. No nos hacemos responsables de ningún malentendido o interpretación errónea derivada del uso de esta traducción.