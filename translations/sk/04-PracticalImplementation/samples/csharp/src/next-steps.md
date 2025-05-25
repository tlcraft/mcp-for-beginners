<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:20:06+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "sk"
}
-->
# Ďalšie kroky po `azd init`

## Obsah

1. [Ďalšie kroky](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Čo bolo pridané](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Fakturácia](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Riešenie problémov](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Ďalšie kroky

### Príprava infraštruktúry a nasadenie aplikačného kódu

Spustite `azd up` na prípravu infraštruktúry a nasadenie do Azure v jednom kroku (alebo spustite `azd provision` a potom `azd deploy` na vykonanie úloh samostatne). Navštívte uvedené koncové body služby, aby ste videli svoju aplikáciu v prevádzke!

Na riešenie akýchkoľvek problémov si pozrite [riešenie problémov](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Konfigurácia CI/CD pipeline

Spustite `azd pipeline config -e <environment name>` na konfiguráciu pipeline nasadenia pre bezpečné pripojenie k Azure. Tu je uvedený názov prostredia, aby sa pipeline nakonfigurovala s iným prostredím na účely izolácie. Spustite `azd env list` a `azd env set` na opätovný výber predvoleného prostredia po tomto kroku.

- Nasadenie pomocou `GitHub Actions`: Vyberte `GitHub`, keď sa zobrazí výzva na výber poskytovateľa. Ak váš projekt nemá súbor `azure-dev.yml`, prijmite výzvu na jeho pridanie a pokračujte v konfigurácii pipeline.

- Nasadenie pomocou `Azure DevOps Pipeline`: Vyberte `Azure DevOps`, keď sa zobrazí výzva na výber poskytovateľa. Ak váš projekt nemá súbor `azure-dev.yml`, prijmite výzvu na jeho pridanie a pokračujte v konfigurácii pipeline.

## Čo bolo pridané

### Konfigurácia infraštruktúry

Na popísanie infraštruktúry a aplikácie bol pridaný `azure.yaml` s nasledujúcou štruktúrou adresára:

```yaml
- azure.yaml     # azd project configuration
```

Tento súbor obsahuje jedinú službu, ktorá odkazuje na hostiteľa aplikácie vášho projektu. Ak je to potrebné, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` na jeho uloženie na disk.

Ak to urobíte, budú vytvorené niektoré ďalšie adresáre:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Okrem toho, pre každý zdroj projektu, na ktorý odkazuje váš hostiteľ aplikácie, `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` projekt, navštívte naše oficiálne [dokumenty](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou služby AI prekladu [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, uvedomte si, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by sa mal považovať za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.