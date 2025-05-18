<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:17:32+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "da"
}
-->
# Næste skridt efter `azd init`

## Indholdsfortegnelse

1. [Næste skridt](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Hvad blev tilføjet](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Fakturering](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Fejlfinding](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Næste skridt

### Opsæt infrastruktur og implementer applikationskode

Kør `azd up` for at opsætte din infrastruktur og implementere til Azure i ét trin (eller kør `azd provision` derefter `azd deploy` for at udføre opgaverne separat). Besøg de listede serviceendepunkter for at se din applikation i drift!

For at fejlfinding af eventuelle problemer, se [fejlfinding](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Konfigurer CI/CD pipeline

Kør `azd pipeline config -e <environment name>` for at konfigurere implementeringspipelinjen til at forbinde sikkert til Azure. Et miljønavn er angivet her for at konfigurere pipelinen med et andet miljø for isolationsformål. Kør `azd env list` og `azd env set` for at vælge standardmiljøet igen efter dette trin.

- Implementering med `GitHub Actions`: Vælg `GitHub` når der bliver spurgt om en udbyder. Hvis dit projekt mangler `azure-dev.yml` filen, accepter prompten for at tilføje den og fortsæt med pipeline-konfigurationen.

- Implementering med `Azure DevOps Pipeline`: Vælg `Azure DevOps` når der bliver spurgt om en udbyder. Hvis dit projekt mangler `azure-dev.yml` filen, accepter prompten for at tilføje den og fortsæt med pipeline-konfigurationen.

## Hvad blev tilføjet

### Infrastrukturkonfiguration

For at beskrive infrastrukturen og applikationen blev en `azure.yaml` tilføjet med følgende mappestruktur:

```yaml
- azure.yaml     # azd project configuration
```

Denne fil indeholder en enkelt service, som refererer til dit projekts App Host. Når det er nødvendigt, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` for at gemme det på disken.

Hvis du gør dette, vil nogle yderligere mapper blive oprettet:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Derudover, for hver projektressource der refereres til af din app host, en `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` projekt, besøg vores officielle [dokumentation](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi stræber efter nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi er ikke ansvarlige for eventuelle misforståelser eller fejltolkninger som følge af brugen af denne oversættelse.