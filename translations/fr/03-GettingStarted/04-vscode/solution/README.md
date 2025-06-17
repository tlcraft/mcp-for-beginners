<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:08:27+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "fr"
}
-->
# Exécuter l'exemple

Ici, nous supposons que vous disposez déjà d’un code serveur fonctionnel. Veuillez localiser un serveur dans l’un des chapitres précédents.

## Configurer mcp.json

Voici un fichier que vous pouvez utiliser comme référence, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Modifiez l’entrée server selon vos besoins pour indiquer le chemin absolu vers votre serveur, y compris la commande complète nécessaire à son exécution.

Dans le fichier d’exemple mentionné ci-dessus, l’entrée server ressemble à ceci :

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Cela correspond à l’exécution d’une commande de ce type : `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` tapez quelque chose comme « add 3 to 20 ».

    Vous devriez voir un outil s’afficher au-dessus de la zone de saisie du chat vous invitant à sélectionner l’exécution de l’outil, comme dans cette illustration :

    ![VS Code indiquant qu’il souhaite exécuter un outil](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.fr.png)

    La sélection de l’outil devrait produire un résultat numérique affichant « 23 » si votre saisie était conforme à l’exemple précédent.

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforçons d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.