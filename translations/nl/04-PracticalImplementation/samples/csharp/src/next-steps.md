<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:18:12+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "nl"
}
-->
# Volgende stappen na `azd init`

## Inhoudsopgave

1. [Volgende stappen](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Wat is toegevoegd](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Facturering](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Probleemoplossing](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Volgende stappen

### Voorzie infrastructuur en implementeer applicatiecode

Voer `azd up` uit om je infrastructuur te voorzien en in één stap naar Azure te implementeren (of voer `azd provision` en vervolgens `azd deploy` uit om de taken afzonderlijk uit te voeren). Bezoek de vermelde service endpoints om je applicatie in werking te zien!

Zie [probleemoplossing](../../../../../../04-PracticalImplementation/samples/csharp/src) om eventuele problemen op te lossen.

### Configureer CI/CD-pijplijn

Voer `azd pipeline config -e <environment name>` uit om de implementatiepijplijn veilig te verbinden met Azure. Hier wordt een omgevingsnaam opgegeven om de pijplijn te configureren met een andere omgeving voor isolatiedoeleinden. Voer `azd env list` en `azd env set` uit om de standaardomgeving opnieuw te selecteren na deze stap.

- Implementeren met `GitHub Actions`: Selecteer `GitHub` wanneer er om een provider wordt gevraagd. Als je project het `azure-dev.yml`-bestand mist, accepteer dan de prompt om het toe te voegen en ga verder met de configuratie van de pijplijn.

- Implementeren met `Azure DevOps Pipeline`: Selecteer `Azure DevOps` wanneer er om een provider wordt gevraagd. Als je project het `azure-dev.yml`-bestand mist, accepteer dan de prompt om het toe te voegen en ga verder met de configuratie van de pijplijn.

## Wat is toegevoegd

### Infrastructuurconfiguratie

Om de infrastructuur en applicatie te beschrijven, is een `azure.yaml` toegevoegd met de volgende mapstructuur:

```yaml
- azure.yaml     # azd project configuration
```

Dit bestand bevat een enkele service die verwijst naar de App Host van je project. Wanneer nodig, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` om het op schijf te bewaren.

Als je dit doet, worden enkele extra mappen aangemaakt:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Daarnaast, voor elke projectbron die door je app host wordt verwezen, een `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` project, bezoek onze officiële [documentatie](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we ons best doen voor nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in zijn oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of misinterpretaties die voortvloeien uit het gebruik van deze vertaling.