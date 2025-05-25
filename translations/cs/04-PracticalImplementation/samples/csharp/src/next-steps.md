<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:19:55+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "cs"
}
-->
# Další kroky po `azd init`

## Obsah

1. [Další kroky](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Co bylo přidáno](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Účtování](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Řešení problémů](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Další kroky

### Zajištění infrastruktury a nasazení aplikačního kódu

Spusťte `azd up` pro zajištění vaší infrastruktury a nasazení do Azure v jednom kroku (nebo spusťte `azd provision` a následně `azd deploy` pro splnění úkolů samostatně). Navštivte uvedené koncové body služby, abyste viděli svou aplikaci v provozu!

Pokud potřebujete vyřešit nějaké problémy, podívejte se na [řešení problémů](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Konfigurace CI/CD pipeline

Spusťte `azd pipeline config -e <environment name>` pro konfiguraci nasazovacího pipeline, který se bezpečně připojí k Azure. Zde je specifikováno jméno prostředí pro konfiguraci pipeline s jiným prostředím za účelem izolace. Spusťte `azd env list` a `azd env set` pro znovuzvolení výchozího prostředí po tomto kroku.

- Nasazení pomocí `GitHub Actions`: Zvolte `GitHub`, když budete dotázáni na poskytovatele. Pokud váš projekt postrádá soubor `azure-dev.yml`, přijměte výzvu k jeho přidání a pokračujte v konfiguraci pipeline.

- Nasazení pomocí `Azure DevOps Pipeline`: Zvolte `Azure DevOps`, když budete dotázáni na poskytovatele. Pokud váš projekt postrádá soubor `azure-dev.yml`, přijměte výzvu k jeho přidání a pokračujte v konfiguraci pipeline.

## Co bylo přidáno

### Konfigurace infrastruktury

Pro popis infrastruktury a aplikace byl přidán `azure.yaml` s následující strukturou adresářů:

```yaml
- azure.yaml     # azd project configuration
```

Tento soubor obsahuje jedinou službu, která odkazuje na App Host vašeho projektu. Když je to potřeba, použijte `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` k jeho uložení na disk.

Pokud to uděláte, některé další adresáře budou vytvořeny:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Navíc, pro každý projektový zdroj, na který váš App Host odkazuje, bude vytvořen `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` projekt, navštivte naše oficiální [dokumentace](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Prohlášení**:  
Tento dokument byl přeložen pomocí služby AI pro překlad [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za žádná nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.