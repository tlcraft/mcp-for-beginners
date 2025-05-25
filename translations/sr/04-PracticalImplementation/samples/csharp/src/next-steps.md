<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:20:38+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "sr"
}
-->
# Sledeći koraci nakon `azd init`

## Sadržaj

1. [Sledeći koraci](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Šta je dodato](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Fakturacija](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Rešavanje problema](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Sledeći koraci

### Priprema infrastrukture i postavljanje aplikacionog koda

Pokrenite `azd up` da pripremite svoju infrastrukturu i postavite na Azure u jednom koraku (ili pokrenite `azd provision` zatim `azd deploy` da izvršite zadatke odvojeno). Posetite navedene krajnje tačke servisa da biste videli svoju aplikaciju kako radi!

Da biste rešili bilo kakve probleme, pogledajte [rešavanje problema](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Konfigurisanje CI/CD pipeline-a

Pokrenite `azd pipeline config -e <environment name>` da konfigurišete pipeline za bezbedno povezivanje sa Azure. Ovdje se navodi ime okruženja da se pipeline konfiguriše sa različitim okruženjem radi izolacije. Pokrenite `azd env list` i `azd env set` da ponovo izaberete podrazumevano okruženje nakon ovog koraka.

- Postavljanje sa `GitHub Actions`: Izaberite `GitHub` kada se zatraži pružalac usluga. Ako vaš projekat nema datoteku `azure-dev.yml`, prihvatite zahtev da je dodate i nastavite sa konfiguracijom pipeline-a.

- Postavljanje sa `Azure DevOps Pipeline`: Izaberite `Azure DevOps` kada se zatraži pružalac usluga. Ako vaš projekat nema datoteku `azure-dev.yml`, prihvatite zahtev da je dodate i nastavite sa konfiguracijom pipeline-a.

## Šta je dodato

### Konfiguracija infrastrukture

Da bi se opisala infrastruktura i aplikacija, dodat je `azure.yaml` sa sledećom strukturom direktorijuma:

```yaml
- azure.yaml     # azd project configuration
```

Ova datoteka sadrži jedan servis koji se odnosi na App Host vašeg projekta. Kada je potrebno, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` da ga sačuvate na disku.

Ako to učinite, neki dodatni direktorijumi će biti kreirani:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Pored toga, za svaki resurs projekta koji vaš app host referencira, `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` projekat, posetite našu zvaničnu [dokumentaciju](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, имајте на уму да аутоматизовани преводи могу садржати грешке или нетачности. Оригинални документ на свом изворном језику треба сматрати меродавним извором. За критичне информације препоручује се професионални људски превод. Не сносимо одговорност за било каква погрешна схватања или погрешна тумачења која произилазе из употребе овог превода.