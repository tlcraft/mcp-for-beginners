<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:19:12+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "tl"
}
-->
# Mga Susunod na Hakbang pagkatapos ng `azd init`

## Talaan ng Nilalaman

1. [Mga Susunod na Hakbang](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Ano ang idinagdag](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Pagbabayad](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Pag-aayos ng Problema](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Mga Susunod na Hakbang

### Maglaan ng imprastruktura at mag-deploy ng code ng aplikasyon

Patakbuhin ang `azd up` para maglaan ng iyong imprastruktura at mag-deploy sa Azure sa isang hakbang (o patakbuhin ang `azd provision` pagkatapos ang `azd deploy` para magawa ang mga gawain nang hiwalay). Bisitahin ang mga endpoint ng serbisyo na nakalista upang makita ang iyong aplikasyon na gumagana!

Para ayusin ang anumang mga isyu, tingnan ang [pag-aayos ng problema](../../../../../../04-PracticalImplementation/samples/csharp/src).

### I-configure ang CI/CD pipeline

Patakbuhin ang `azd pipeline config -e <environment name>` para i-configure ang deployment pipeline upang kumonekta nang ligtas sa Azure. Ang pangalan ng kapaligiran ay tinukoy dito upang i-configure ang pipeline na may ibang kapaligiran para sa layunin ng paghihiwalay. Patakbuhin ang `azd env list` at `azd env set` upang muling piliin ang default na kapaligiran pagkatapos ng hakbang na ito.

- Pag-deploy gamit ang `GitHub Actions`: Piliin ang `GitHub` kapag hiniling para sa isang provider. Kung kulang ang iyong proyekto ng file na `azure-dev.yml`, tanggapin ang prompt upang idagdag ito at magpatuloy sa pag-configure ng pipeline.

- Pag-deploy gamit ang `Azure DevOps Pipeline`: Piliin ang `Azure DevOps` kapag hiniling para sa isang provider. Kung kulang ang iyong proyekto ng file na `azure-dev.yml`, tanggapin ang prompt upang idagdag ito at magpatuloy sa pag-configure ng pipeline.

## Ano ang idinagdag

### Konfigurasyon ng imprastruktura

Para ilarawan ang imprastruktura at aplikasyon, isang `azure.yaml` ang idinagdag na may sumusunod na istruktura ng direktoryo:

```yaml
- azure.yaml     # azd project configuration
```

Ang file na ito ay naglalaman ng isang serbisyo, na tumutukoy sa App Host ng iyong proyekto. Kapag kailangan, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` upang i-persist ito sa disk.

Kung gagawin mo ito, ilang karagdagang direktoryo ang malilikha:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Bukod pa rito, para sa bawat resource ng proyekto na tinutukoy ng iyong app host, isang `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` na proyekto, bisitahin ang aming opisyal na [docs](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). Habang kami ay nagsusumikap para sa kawastuhan, mangyaring tandaan na ang awtomatikong mga pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkaka-ayon. Ang orihinal na dokumento sa kanyang katutubong wika ay dapat ituring na mapagkakatiwalaang pinagmulan. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Kami ay hindi mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na nagmumula sa paggamit ng pagsasaling ito.