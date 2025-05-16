<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-16T15:10:20+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "fr"
}
-->
# Exécution de cet exemple

Il est recommandé d’installer `uv` mais ce n’est pas obligatoire, voir [instructions](https://docs.astral.sh/uv/#highlights)

## -1- Installer les dépendances

```bash
npm install
```

## -3- Exécuter l’exemple


```bash
npm run build
```

## -4- Tester l’exemple

Avec le serveur en fonctionnement dans un terminal, ouvrez un autre terminal et lancez la commande suivante :

```bash
npm run inspector
```

Cela devrait démarrer un serveur web avec une interface visuelle vous permettant de tester l’exemple.

Une fois le serveur connecté :

- essayez de lister les outils et exécutez `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` qui est un wrapper autour de celui-ci.

Vous pouvez le lancer directement en mode CLI en exécutant la commande suivante :

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Cela affichera la liste de tous les outils disponibles sur le serveur. Vous devriez voir la sortie suivante :

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

Pour invoquer un outil, tapez :

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Vous devriez voir la sortie suivante :

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Il est généralement beaucoup plus rapide d’exécuter l’inspector en mode CLI que dans le navigateur.
> Pour en savoir plus sur l’inspector, consultez [ici](https://github.com/modelcontextprotocol/inspector).

**Avertissement** :  
Ce document a été traduit à l'aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforçons d'assurer l'exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d'origine doit être considéré comme la source faisant foi. Pour les informations critiques, il est recommandé de faire appel à une traduction professionnelle réalisée par un humain. Nous déclinons toute responsabilité en cas de malentendus ou d'interprétations erronées résultant de l'utilisation de cette traduction.