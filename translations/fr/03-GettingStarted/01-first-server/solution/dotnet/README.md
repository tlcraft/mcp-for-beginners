<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-16T15:11:04+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "fr"
}
-->
# Exécution de cet exemple

## -1- Installer les dépendances

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Exécuter l'exemple

```bash
dotnet run
```

## -4- Tester l'exemple

Avec le serveur en fonctionnement dans un terminal, ouvrez un autre terminal et lancez la commande suivante :

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Cela devrait démarrer un serveur web avec une interface visuelle vous permettant de tester l'exemple.

Une fois le serveur connecté :

- essayez de lister les outils et exécutez `add`, avec les arguments 2 et 4, vous devriez voir 6 dans le résultat.
- allez dans resources et resource template et appelez "greeting", saisissez un nom et vous devriez voir un message de bienvenue avec le nom que vous avez fourni.

### Tester en mode CLI

Vous pouvez le lancer directement en mode CLI en exécutant la commande suivante :

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Cela affichera tous les outils disponibles sur le serveur. Vous devriez voir la sortie suivante :

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Pour invoquer un outil, tapez :

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Vous devriez voir la sortie suivante :

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Il est généralement beaucoup plus rapide d'exécuter l'inspecteur en mode CLI qu'en navigateur.
> Pour en savoir plus sur l'inspecteur, consultez [ici](https://github.com/modelcontextprotocol/inspector).

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforçons d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous ne sommes pas responsables des malentendus ou des erreurs d’interprétation résultant de l’utilisation de cette traduction.