<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:20:54+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "hr"
}
-->
# Sljedeći koraci nakon `azd init`

## Sadržaj

1. [Sljedeći koraci](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Što je dodano](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Naplate](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Rješavanje problema](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Sljedeći koraci

### Pripremite infrastrukturu i implementirajte kod aplikacije

Pokrenite `azd up` kako biste pripremili infrastrukturu i implementirali na Azure u jednom koraku (ili pokrenite `azd provision` pa `azd deploy` kako biste obavili zadatke zasebno). Posjetite navedene krajnje točke usluge kako biste vidjeli svoju aplikaciju u radu!

Za rješavanje bilo kakvih problema, pogledajte [rješavanje problema](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Konfigurirajte CI/CD pipeline

Pokrenite `azd pipeline config -e <environment name>` kako biste konfigurirali pipeline za sigurno povezivanje s Azureom. Ovdje je navedeno ime okruženja za konfiguraciju pipelinea s različitim okruženjem radi izolacije. Pokrenite `azd env list` i `azd env set` za ponovno odabir zadane okoline nakon ovog koraka.

- Implementacija s `GitHub Actions`: Odaberite `GitHub` kada se zatraži odabir pružatelja. Ako vaš projekt nema datoteku `azure-dev.yml`, prihvatite zahtjev za dodavanje i nastavite s konfiguracijom pipelinea.

- Implementacija s `Azure DevOps Pipeline`: Odaberite `Azure DevOps` kada se zatraži odabir pružatelja. Ako vaš projekt nema datoteku `azure-dev.yml`, prihvatite zahtjev za dodavanje i nastavite s konfiguracijom pipelinea.

## Što je dodano

### Konfiguracija infrastrukture

Za opis infrastrukture i aplikacije dodan je `azure.yaml` sa sljedećom strukturom direktorija:

```yaml
- azure.yaml     # azd project configuration
```

Ova datoteka sadrži jednu uslugu koja referencira App Host vašeg projekta. Kada je potrebno, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` za spremanje na disk.

Ako to učinite, bit će kreirani neki dodatni direktoriji:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Osim toga, za svaki resurs projekta na koji se referencira vaš app host, `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` projekt, posjetite našu službenu [dokumentaciju](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Odricanje odgovornosti**:  
Ovaj dokument je preveden pomoću AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatizirani prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za ključne informacije preporučuje se profesionalni prijevod od strane čovjeka. Ne odgovaramo za nesporazume ili pogrešne interpretacije koje proizlaze iz korištenja ovog prijevoda.