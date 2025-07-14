<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:18:01+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "fr"
}
-->
# Exécution de cet exemple

## -1- Installer les dépendances

```bash
npm install
```

## -3- Exécuter l'exemple

```bash
npm run build
```

## -4- Tester l'exemple

Avec le serveur en cours d'exécution dans un terminal, ouvrez un autre terminal et lancez la commande suivante :

```bash
npm run inspector
```

Cela devrait démarrer un serveur web avec une interface visuelle vous permettant de tester l'exemple.

Une fois le serveur connecté :

- essayez de lister les outils et exécutez `add` avec les arguments 2 et 4, vous devriez voir 6 dans le résultat.
- allez dans resources et resource template et appelez "greeting", saisissez un nom et vous devriez voir un message de salutation avec le nom que vous avez fourni.

### Test en mode CLI

L'inspecteur que vous avez lancé est en fait une application Node.js et `mcp dev` est un wrapper autour de celle-ci.

- Démarrez le serveur avec la commande `npm run build`.

- Dans un terminal séparé, exécutez la commande suivante :

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    Cela affichera tous les outils disponibles sur le serveur. Vous devriez voir la sortie suivante :

    ```text
    {
    "tools": [
        {
        "name": "add",
        "description": "Add two numbers",
        "inputSchema": {
            "type": "object",
            "properties": {
            "a": {
                "title": "A",
                "type": "integer"
            },
            "b": {
                "title": "B",
                "type": "integer"
            }
            },
            "required": [
            "a",
            "b"
            ],
            "title": "addArguments"
        }
        }
    ]
    }
    ```

- Appelez un type d'outil en tapant la commande suivante :

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Vous devriez voir la sortie suivante :

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> Il est généralement beaucoup plus rapide d’exécuter l’inspecteur en mode CLI que dans le navigateur.
> Pour en savoir plus sur l’inspecteur, consultez [ici](https://github.com/modelcontextprotocol/inspector).

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.