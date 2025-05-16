<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-16T15:41:53+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "fr"
}
-->
# Étapes suivantes après `azd init`

## Table des matières

1. [Étapes suivantes](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Ce qui a été ajouté](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Facturation](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Dépannage](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Étapes suivantes

### Provisionner l’infrastructure et déployer le code de l’application

Exécutez `azd up` pour provisionner votre infrastructure et déployer sur Azure en une seule étape (ou exécutez `azd provision` puis `azd deploy` pour réaliser ces tâches séparément). Consultez les points de terminaison du service listés pour voir votre application en fonctionnement !

Pour résoudre d’éventuels problèmes, consultez la section [dépannage](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Configurer le pipeline CI/CD

Exécutez `azd pipeline config -e <environment name>` pour configurer le pipeline de déploiement afin de se connecter en toute sécurité à Azure. Un nom d’environnement est spécifié ici pour configurer le pipeline avec un environnement différent à des fins d’isolation. Exécutez `azd env list` et `azd env set` pour re-sélectionner l’environnement par défaut après cette étape.

- Déploiement avec `GitHub Actions` : Sélectionnez `GitHub` lorsqu’on vous demande un fournisseur. Si votre projet ne contient pas le fichier `azure-dev.yml`, acceptez l’invite pour l’ajouter et poursuivez la configuration du pipeline.

- Déploiement avec `Azure DevOps Pipeline` : Sélectionnez `Azure DevOps` lorsqu’on vous demande un fournisseur. Si votre projet ne contient pas le fichier `azure-dev.yml`, acceptez l’invite pour l’ajouter et poursuivez la configuration du pipeline.

## Ce qui a été ajouté

### Configuration de l’infrastructure

Pour décrire l’infrastructure et l’application, un `azure.yaml` a été ajouté avec la structure de répertoires suivante :

```yaml
- azure.yaml     # azd project configuration
```

Ce fichier contient un seul service, qui fait référence à l’App Host de votre projet. Si nécessaire, utilisez `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` pour le sauvegarder sur le disque.

Si vous faites cela, certains répertoires supplémentaires seront créés :

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

De plus, pour chaque ressource de projet référencée par votre app host, un fichier `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

*Note*: Once you have synthesized your infrastructure to disk, changes made to your App Host will not be reflected in the infrastructure. You can re-generate the infrastructure by running `azd infra synth` again. It will prompt you before overwriting files. You can pass `--force` to force `azd infra synth` to overwrite the files without prompting.

*Note*: `azd infra synth` is currently an alpha feature and must be explicitly enabled by running `azd config set alpha.infraSynth on`. You only need to do this once.

## Billing

Visit the *Cost Management + Billing* page in Azure Portal to track current spend. For more information about how you're billed, and how you can monitor the costs incurred in your Azure subscriptions, visit [billing overview](https://learn.microsoft.com/azure/developer/intro/azure-developer-billing).

## Troubleshooting

Q: I visited the service endpoint listed, and I'm seeing a blank page, a generic welcome page, or an error page.

A: Your service may have failed to start, or it may be missing some configuration settings. To investigate further:

1. Run `azd show`. Click on the link under "View in Azure Portal" to open the resource group in Azure Portal.
2. Navigate to the specific Container App service that is failing to deploy.
3. Click on the failing revision under "Revisions with Issues".
4. Review "Status details" for more information about the type of failure.
5. Observe the log outputs from Console log stream and System log stream to identify any errors.
6. If logs are written to disk, use *Console* in the navigation to connect to a shell within the running container.

For more troubleshooting information, visit [Container Apps troubleshooting](https://learn.microsoft.com/azure/container-apps/troubleshooting). 

### Additional information

For additional information about setting up your `azd` projet, consultez notre documentation officielle [docs](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforçons d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, il est recommandé de recourir à une traduction professionnelle réalisée par un humain. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.