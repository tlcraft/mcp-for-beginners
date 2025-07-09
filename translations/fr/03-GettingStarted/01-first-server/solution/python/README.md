<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d0f0d7012325b286e4a717791b23ae7e",
  "translation_date": "2025-07-09T22:54:17+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "fr"
}
-->
# Exécuter cet exemple

Il est recommandé d’installer `uv` mais ce n’est pas obligatoire, voir [instructions](https://docs.astral.sh/uv/#highlights)

## -0- Créer un environnement virtuel

```bash
python -m venv venv
```

## -1- Activer l’environnement virtuel

```bash
venv\Scrips\activate
```

## -2- Installer les dépendances

```bash
pip install "mcp[cli]"
```

## -3- Exécuter l’exemple


```bash
mcp run server.py
```

## -4- Tester l’exemple

Avec le serveur en cours d’exécution dans un terminal, ouvrez un autre terminal et lancez la commande suivante :

```bash
mcp dev server.py
```

Cela devrait démarrer un serveur web avec une interface visuelle vous permettant de tester l’exemple.

Une fois le serveur connecté :

- essayez de lister les outils et exécutez `add`, avec les arguments 2 et 4, vous devriez voir 6 dans le résultat.

- allez dans resources et resource template et appelez get_greeting, saisissez un nom et vous devriez voir un message de bienvenue avec le nom que vous avez fourni.

### Tester en mode CLI

L’inspecteur que vous avez lancé est en fait une application Node.js et `mcp dev` est un wrapper autour de celle-ci.

Vous pouvez le lancer directement en mode CLI en exécutant la commande suivante :

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
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
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Il est généralement beaucoup plus rapide d’exécuter l’inspecteur en mode CLI que dans le navigateur.
> Pour en savoir plus sur l’inspecteur, consultez [ici](https://github.com/modelcontextprotocol/inspector).

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.