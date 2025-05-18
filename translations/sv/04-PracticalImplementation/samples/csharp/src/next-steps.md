<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:17:23+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "sv"
}
-->
# Nästa steg efter `azd init`

## Innehållsförteckning

1. [Nästa steg](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Vad som lades till](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Fakturering](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Felsökning](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Nästa steg

### Tillhandahåll infrastruktur och distribuera applikationskod

Kör `azd up` för att tillhandahålla din infrastruktur och distribuera till Azure i ett steg (eller kör `azd provision` sedan `azd deploy` för att utföra uppgifterna separat). Besök de tjänstendpunkter som listas för att se din applikation igång!

För att felsöka eventuella problem, se [felsökning](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Konfigurera CI/CD-pipeline

Kör `azd pipeline config -e <environment name>` för att konfigurera distributionspipelinjen för att ansluta säkert till Azure. Ett miljönamn anges här för att konfigurera pipelinjen med en annan miljö för isoleringsändamål. Kör `azd env list` och `azd env set` för att välja den ursprungliga miljön igen efter detta steg.

- Distribuera med `GitHub Actions`: Välj `GitHub` när du blir ombedd att välja en leverantör. Om ditt projekt saknar `azure-dev.yml`-filen, acceptera uppmaningen att lägga till den och fortsätt med pipeline-konfigurationen.

- Distribuera med `Azure DevOps Pipeline`: Välj `Azure DevOps` när du blir ombedd att välja en leverantör. Om ditt projekt saknar `azure-dev.yml`-filen, acceptera uppmaningen att lägga till den och fortsätt med pipeline-konfigurationen.

## Vad som lades till

### Infrastrukturkonfiguration

För att beskriva infrastrukturen och applikationen lades en `azure.yaml` till med följande katalogstruktur:

```yaml
- azure.yaml     # azd project configuration
```

Denna fil innehåller en enda tjänst som refererar till ditt projekts App Host. När det behövs, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` för att spara den på disk.

Om du gör detta, kommer några ytterligare kataloger att skapas:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Dessutom, för varje projektresurs som refereras av din appvärd, en `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd`-projekt, besök vår officiella [dokumentation](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen var medveten om att automatiserade översättningar kan innehålla fel eller oriktigheter. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi är inte ansvariga för eventuella missförstånd eller feltolkningar som uppstår från användningen av denna översättning.