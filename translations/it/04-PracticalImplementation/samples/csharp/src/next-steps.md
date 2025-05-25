<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:16:30+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "it"
}
-->
# Prossimi Passi dopo `azd init`

## Indice

1. [Prossimi Passi](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Cosa è stato aggiunto](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Fatturazione](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Risoluzione dei problemi](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Prossimi Passi

### Provisioning dell'infrastruttura e distribuzione del codice applicativo

Esegui `azd up` per effettuare il provisioning della tua infrastruttura e distribuire su Azure in un solo passaggio (oppure esegui `azd provision` seguito da `azd deploy` per svolgere le attività separatamente). Visita gli endpoint dei servizi elencati per vedere la tua applicazione funzionante!

Per risolvere eventuali problemi, consulta [risoluzione dei problemi](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Configurazione della pipeline CI/CD

Esegui `azd pipeline config -e <environment name>` per configurare la pipeline di distribuzione per connettersi in modo sicuro ad Azure. Qui viene specificato un nome di ambiente per configurare la pipeline con un ambiente diverso a scopo di isolamento. Esegui `azd env list` e `azd env set` per riselezionare l'ambiente predefinito dopo questo passaggio.

- Distribuzione con `GitHub Actions`: Seleziona `GitHub` quando richiesto per un provider. Se il tuo progetto non ha il file `azure-dev.yml`, accetta il prompt per aggiungerlo e procedi con la configurazione della pipeline.

- Distribuzione con `Azure DevOps Pipeline`: Seleziona `Azure DevOps` quando richiesto per un provider. Se il tuo progetto non ha il file `azure-dev.yml`, accetta il prompt per aggiungerlo e procedi con la configurazione della pipeline.

## Cosa è stato aggiunto

### Configurazione dell'infrastruttura

Per descrivere l'infrastruttura e l'applicazione, è stato aggiunto un `azure.yaml` con la seguente struttura di directory:

```yaml
- azure.yaml     # azd project configuration
```

Questo file contiene un unico servizio, che fa riferimento all'App Host del tuo progetto. Quando necessario, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` per persisterlo su disco.

Se lo fai, verranno creati alcuni directory aggiuntivi:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Inoltre, per ogni risorsa del progetto referenziata dal tuo app host, un `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` progetto, visita i nostri [documenti ufficiali](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per garantire l'accuratezza, si prega di essere consapevoli che le traduzioni automatizzate possono contenere errori o imprecisioni. Il documento originale nella sua lingua madre dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali incomprensioni o interpretazioni errate derivanti dall'uso di questa traduzione.