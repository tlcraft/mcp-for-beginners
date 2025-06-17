<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:09:56+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "es"
}
-->
# Ejecutando el ejemplo

Aquí asumimos que ya tienes un código de servidor funcionando. Por favor, ubica un servidor de alguno de los capítulos anteriores.

## Configura mcp.json

Aquí tienes un archivo que puedes usar como referencia, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Modifica la entrada del servidor según sea necesario para indicar la ruta absoluta a tu servidor, incluyendo el comando completo necesario para ejecutarlo.

En el archivo de ejemplo mencionado arriba, la entrada del servidor se ve así:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Esto corresponde a ejecutar un comando como: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` escribe algo como "add 3 to 20".

    Deberías ver una herramienta presentada arriba del cuadro de texto del chat que te indica seleccionar para ejecutar la herramienta, como en esta imagen:

    ![VS Code indicando que quiere ejecutar una herramienta](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.es.png)

    Seleccionar la herramienta debería producir un resultado numérico que diga "23" si tu prompt fue como mencionamos anteriormente.

**Aviso Legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de ningún malentendido o interpretación errónea derivada del uso de esta traducción.