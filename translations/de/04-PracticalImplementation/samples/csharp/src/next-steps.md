<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-16T15:42:04+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "de"
}
-->
# Nächste Schritte nach `azd init`

## Inhaltsverzeichnis

1. [Nächste Schritte](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Was hinzugefügt wurde](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Abrechnung](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Fehlerbehebung](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Nächste Schritte

### Infrastruktur bereitstellen und Anwendungscode bereitstellen

Führen Sie `azd up` aus, um Ihre Infrastruktur bereitzustellen und in einem Schritt nach Azure zu deployen (oder führen Sie `azd provision` und anschließend `azd deploy` aus, um die Aufgaben getrennt zu erledigen). Besuchen Sie die aufgeführten Service-Endpunkte, um Ihre Anwendung in Betrieb zu sehen!

Zur Fehlerbehebung siehe [Fehlerbehebung](../../../../../../04-PracticalImplementation/samples/csharp/src).

### CI/CD-Pipeline konfigurieren

Führen Sie `azd pipeline config -e <environment name>` aus, um die Bereitstellungspipeline so zu konfigurieren, dass sie eine sichere Verbindung zu Azure herstellt. Hier wird ein Umgebungsname angegeben, um die Pipeline für eine andere Umgebung zur Isolierung zu konfigurieren. Führen Sie `azd env list` und `azd env set` aus, um nach diesem Schritt die Standardumgebung erneut auszuwählen.

- Bereitstellung mit `GitHub Actions`: Wählen Sie `GitHub` aus, wenn Sie nach einem Anbieter gefragt werden. Falls Ihr Projekt die Datei `azure-dev.yml` nicht enthält, akzeptieren Sie die Aufforderung zum Hinzufügen und fahren Sie mit der Pipeline-Konfiguration fort.

- Bereitstellung mit `Azure DevOps Pipeline`: Wählen Sie `Azure DevOps` aus, wenn Sie nach einem Anbieter gefragt werden. Falls Ihr Projekt die Datei `azure-dev.yml` nicht enthält, akzeptieren Sie die Aufforderung zum Hinzufügen und fahren Sie mit der Pipeline-Konfiguration fort.

## Was hinzugefügt wurde

### Infrastrukturkonfiguration

Um die Infrastruktur und Anwendung zu beschreiben, wurde eine `azure.yaml` mit folgender Verzeichnisstruktur hinzugefügt:

```yaml
- azure.yaml     # azd project configuration
```

Diese Datei enthält einen einzelnen Service, der auf den App Host Ihres Projekts verweist. Falls nötig, führen Sie `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` aus, um sie auf der Festplatte zu speichern.

Wenn Sie dies tun, werden einige zusätzliche Verzeichnisse erstellt:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Außerdem wird für jede Projektressource, die von Ihrem App Host referenziert wird, eine `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` Projekt, besuchen Sie unsere offiziellen [Dokumentation](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Haftungsausschluss**:  
Dieses Dokument wurde mithilfe des KI-Übersetzungsdienstes [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner ursprünglichen Sprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Verwendung dieser Übersetzung entstehen.