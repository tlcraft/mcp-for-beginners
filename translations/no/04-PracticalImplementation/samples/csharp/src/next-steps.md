<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:17:50+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "no"
}
-->
# Neste trinn etter `azd init`

## Innholdsfortegnelse

1. [Neste trinn](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Hva ble lagt til](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Fakturering](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Feilsøking](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Neste trinn

### Klargjør infrastruktur og distribuer applikasjonskode

Kjør `azd up` for å klargjøre infrastrukturen din og distribuere til Azure i ett steg (eller kjør `azd provision` deretter `azd deploy` for å utføre oppgavene separat). Besøk de oppførte tjenesteendepunktene for å se applikasjonen din i drift!

For å feilsøke eventuelle problemer, se [feilsøking](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Konfigurer CI/CD pipeline

Kjør `azd pipeline config -e <environment name>` for å konfigurere distribusjonspipelinen til å koble seg sikkert til Azure. Et miljønavn er spesifisert her for å konfigurere pipelinen med et annet miljø for isoleringsformål. Kjør `azd env list` og `azd env set` for å velge tilbake til standardmiljøet etter dette steget.

- Distribuering med `GitHub Actions`: Velg `GitHub` når du blir bedt om en leverandør. Hvis prosjektet ditt mangler filen `azure-dev.yml`, godta meldingen om å legge den til og fortsett med pipeline-konfigurasjonen.

- Distribuering med `Azure DevOps Pipeline`: Velg `Azure DevOps` når du blir bedt om en leverandør. Hvis prosjektet ditt mangler filen `azure-dev.yml`, godta meldingen om å legge den til og fortsett med pipeline-konfigurasjonen.

## Hva ble lagt til

### Infrastrukturkonfigurasjon

For å beskrive infrastrukturen og applikasjonen ble en `azure.yaml` lagt til med følgende katalogstruktur:

```yaml
- azure.yaml     # azd project configuration
```

Denne filen inneholder en enkelt tjeneste, som refererer til prosjektets App Host. Når det er nødvendig, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` for å lagre den på disk.

Hvis du gjør dette, vil noen ekstra kataloger bli opprettet:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

I tillegg, for hver prosjektressurs som refereres av din app host, en `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` prosjekt, besøk vår offisielle [dokumentasjon](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi etterstreber nøyaktighet, vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på sitt opprinnelige språk bør betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.