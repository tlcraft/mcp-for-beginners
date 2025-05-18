<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:19:24+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "sw"
}
-->
# Hatua Zifuatazo baada ya `azd init`

## Yaliyomo

1. [Hatua Zifuatazo](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Kipi kilichoongezwa](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Malipo](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Kutatua matatizo](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Hatua Zifuatazo

### Tengeneza miundombinu na weka msimbo wa programu

Run `azd up` ili kutengeneza miundombinu yako na kuweka kwenye Azure kwa hatua moja (au run `azd provision` kisha `azd deploy` ili kutekeleza kazi hizi kando). Tembelea viunganishi vya huduma vilivyoorodheshwa kuona programu yako ikifanya kazi!

Ili kutatua matatizo yoyote, angalia [kutatua matatizo](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Sanidi mkondo wa CI/CD

Run `azd pipeline config -e <environment name>` ili kusanidi mkondo wa kuweka programu ili kuunganishwa kwa usalama na Azure. Jina la mazingira linatolewa hapa ili kusanidi mkondo na mazingira tofauti kwa madhumuni ya kutengwa. Run `azd env list` na `azd env set` ili kuchagua tena mazingira ya default baada ya hatua hii.

- Kuweka na `GitHub Actions`: Chagua `GitHub` unapoulizwa kuhusu mtoa huduma. Ikiwa mradi wako hauna faili `azure-dev.yml`, kubali mwongozo wa kuiongeza na endelea na usanidi wa mkondo.

- Kuweka na `Azure DevOps Pipeline`: Chagua `Azure DevOps` unapoulizwa kuhusu mtoa huduma. Ikiwa mradi wako hauna faili `azure-dev.yml`, kubali mwongozo wa kuiongeza na endelea na usanidi wa mkondo.

## Kipi kilichoongezwa

### Usanidi wa miundombinu

Ili kuelezea miundombinu na programu, `azure.yaml` imeongezwa na muundo wa saraka ufuatao:

```yaml
- azure.yaml     # azd project configuration
```

Faili hii ina huduma moja, ambayo inarejelea App Host ya mradi wako. Inapohitajika, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` ili kuhifadhi kwenye diski.

Ukifanya hivi, baadhi ya saraka za ziada zitaumbwa:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Zaidi ya hayo, kwa kila rasilimali ya mradi inayorejelewa na app host yako, `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` mradi, tembelea [docs](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert) rasmi yetu.

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, inashauriwa kupata tafsiri ya kibinadamu ya kitaalamu. Hatutawajibika kwa kutoelewana au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.