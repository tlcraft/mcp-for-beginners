<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:21:06+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "sl"
}
-->
# Naslednji koraki po `azd init`

## Kazalo

1. [Naslednji koraki](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Kaj je bilo dodano](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Zaračunavanje](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Odpravljanje težav](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Naslednji koraki

### Priprava infrastrukture in namestitev aplikacijske kode

Za pripravo infrastrukture in namestitev na Azure v enem koraku zaženite `azd up` (ali zaženite `azd provision` in nato `azd deploy`, da opravite naloge ločeno). Obiščite navedene končne točke storitev, da si ogledate delovanje vaše aplikacije!

Za odpravljanje morebitnih težav si oglejte [odpravljanje težav](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Konfiguracija CI/CD pipeline

Za konfiguracijo pipeline za varno povezavo z Azure zaženite `azd pipeline config -e <environment name>`. Tukaj je določeno ime okolja za konfiguracijo pipeline z različnim okoljem za namene izolacije. Za ponovni izbor privzetega okolja po tem koraku zaženite `azd env list` in `azd env set`.

- Namestitev z `GitHub Actions`: Ko se pojavi poziv za ponudnika, izberite `GitHub`. Če vašemu projektu manjka datoteka `azure-dev.yml`, sprejmite poziv za dodajanje in nadaljujte s konfiguracijo pipeline.

- Namestitev z `Azure DevOps Pipeline`: Ko se pojavi poziv za ponudnika, izberite `Azure DevOps`. Če vašemu projektu manjka datoteka `azure-dev.yml`, sprejmite poziv za dodajanje in nadaljujte s konfiguracijo pipeline.

## Kaj je bilo dodano

### Konfiguracija infrastrukture

Za opis infrastrukture in aplikacije je bil dodan `azure.yaml` z naslednjo strukturo imenika:

```yaml
- azure.yaml     # azd project configuration
```

Ta datoteka vsebuje eno storitev, ki se nanaša na gostitelja aplikacije vašega projekta. Ko je potrebno, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` za trajno shranjevanje na disk.

Če to storite, bodo ustvarjeni nekateri dodatni imeniki:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Poleg tega, za vsak vir projekta, na katerega se nanaša vaš gostitelj aplikacije, `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` projekt, obiščite naše uradne [dokumente](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Omejitev odgovornosti**: 
Ta dokument je bil preveden z uporabo storitve AI prevajanja [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za kritične informacije se priporoča profesionalni človeški prevod. Ne odgovarjamo za kakršne koli nesporazume ali napačne razlage, ki bi izhajale iz uporabe tega prevoda.