<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:20:17+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "ro"
}
-->
# Pașii următori după `azd init`

## Cuprins

1. [Pașii următori](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Ce a fost adăugat](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Facturare](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Depanare](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Pașii următori

### Asigurarea infrastructurii și implementarea codului aplicației

Rulează `azd up` pentru a asigura infrastructura și a implementa în Azure într-un singur pas (sau rulează `azd provision` apoi `azd deploy` pentru a îndeplini sarcinile separat). Vizitează punctele de acces ale serviciului listate pentru a vedea aplicația funcționând!

Pentru a rezolva orice probleme, vezi [depanare](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Configurarea pipeline-ului CI/CD

Rulează `azd pipeline config -e <environment name>` pentru a configura pipeline-ul de implementare să se conecteze în siguranță la Azure. Un nume de mediu este specificat aici pentru a configura pipeline-ul cu un mediu diferit pentru scopuri de izolare. Rulează `azd env list` și `azd env set` pentru a selecta din nou mediul implicit după acest pas.

- Implementare cu `GitHub Actions`: Selectează `GitHub` când ți se cere un furnizor. Dacă proiectul tău nu are fișierul `azure-dev.yml`, acceptă promptul pentru a-l adăuga și continuă cu configurarea pipeline-ului.

- Implementare cu `Azure DevOps Pipeline`: Selectează `Azure DevOps` când ți se cere un furnizor. Dacă proiectul tău nu are fișierul `azure-dev.yml`, acceptă promptul pentru a-l adăuga și continuă cu configurarea pipeline-ului.

## Ce a fost adăugat

### Configurarea infrastructurii

Pentru a descrie infrastructura și aplicația, a fost adăugat un `azure.yaml` cu următoarea structură de directoare:

```yaml
- azure.yaml     # azd project configuration
```

Acest fișier conține un singur serviciu, care face referire la gazda aplicației proiectului tău. Când este nevoie, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` pentru a-l păstra pe disc.

Dacă faci asta, vor fi create câteva directoare suplimentare:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

În plus, pentru fiecare resursă de proiect la care face referire gazda aplicației tale, un `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` proiect, vizitează [documentația](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert) oficială.

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa natală ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională umană. Nu suntem răspunzători pentru niciun fel de neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.