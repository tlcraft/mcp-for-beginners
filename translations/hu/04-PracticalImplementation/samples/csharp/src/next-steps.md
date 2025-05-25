<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:19:34+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "hu"
}
-->
# Következő lépések a `azd init` után

## Tartalomjegyzék

1. [Következő lépések](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Mi lett hozzáadva](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Számlázás](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Hibakeresés](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Következő lépések

### Infrastrukturális előkészítés és alkalmazás kódjának telepítése

Futtasd a `azd up` parancsot, hogy egy lépésben előkészítsd az infrastruktúrát és telepítsd az Azure-ra (vagy futtasd először a `azd provision`, majd a `azd deploy` parancsot, hogy külön-külön végezd el a feladatokat). Látogasd meg a felsorolt szolgáltatási végpontokat, hogy lásd, az alkalmazásod működik!

Ha problémák adódnak, nézd meg a [hibakeresést](../../../../../../04-PracticalImplementation/samples/csharp/src).

### CI/CD csővezeték konfigurálása

Futtasd a `azd pipeline config -e <environment name>` parancsot, hogy biztonságosan csatlakoztasd a telepítési csővezetéket az Azure-hoz. Itt meg van adva egy környezet neve, hogy különböző környezettel konfiguráld a csővezetéket izolációs célból. Futtasd a `azd env list` és `azd env set` parancsokat, hogy az alapértelmezett környezetet újra kiválaszd ezen lépés után.

- Telepítés `GitHub Actions` segítségével: Válaszd ki a `GitHub` opciót, amikor szolgáltatót kérnek. Ha a projektedben nincs `azure-dev.yml` fájl, fogadd el a felkérést annak hozzáadására, és folytasd a csővezeték konfigurálását.

- Telepítés `Azure DevOps Pipeline` segítségével: Válaszd ki a `Azure DevOps` opciót, amikor szolgáltatót kérnek. Ha a projektedben nincs `azure-dev.yml` fájl, fogadd el a felkérést annak hozzáadására, és folytasd a csővezeték konfigurálását.

## Mi lett hozzáadva

### Infrastrukturális konfiguráció

Az infrastruktúra és alkalmazás leírására hozzá lett adva egy `azure.yaml` az alábbi könyvtárstruktúrával:

```yaml
- azure.yaml     # azd project configuration
```

Ez a fájl egyetlen szolgáltatást tartalmaz, amely a projekted App Hostjára hivatkozik. Szükség esetén `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` parancsot futtass, hogy lemezre mentse.

Ha ezt megteszed, néhány további könyvtár létrejön:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Ezen kívül, minden projekt erőforrás esetén, amelyre az app hostod hivatkozik, egy `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` projekt, látogasd meg a hivatalos [dokumentációt](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Felelősségi nyilatkozat**:  
Ezt a dokumentumot AI fordítási szolgáltatással, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordították le. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum saját nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális emberi fordítás. Nem vállalunk felelősséget semmilyen félreértésért vagy téves értelmezésért, amely a fordítás használatából ered.