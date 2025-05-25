<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-16T15:42:44+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "pl"
}
-->
# Kolejne kroki po `azd init`

## Spis treści

1. [Kolejne kroki](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Co zostało dodane](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Rozliczenia](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Rozwiązywanie problemów](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Kolejne kroki

### Przygotowanie infrastruktury i wdrożenie kodu aplikacji

Uruchom `azd up`, aby w jednym kroku przygotować infrastrukturę i wdrożyć aplikację do Azure (lub najpierw `azd provision`, a potem `azd deploy`, aby wykonać te zadania osobno). Odwiedź podane endpointy usługi, aby zobaczyć działającą aplikację!

Aby rozwiązać ewentualne problemy, zobacz [rozwiązywanie problemów](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Konfiguracja pipeline CI/CD

Uruchom `azd pipeline config -e <environment name>`, aby skonfigurować pipeline wdrożeniowy z bezpiecznym połączeniem do Azure. Tutaj podaj nazwę środowiska, aby skonfigurować pipeline dla innego środowiska w celach izolacji. Po tym kroku uruchom `azd env list` i `azd env set`, aby ponownie wybrać domyślne środowisko.

- Wdrażanie za pomocą `GitHub Actions`: Wybierz `GitHub`, gdy pojawi się prośba o dostawcę. Jeśli w Twoim projekcie brakuje pliku `azure-dev.yml`, zaakceptuj propozycję jego dodania i kontynuuj konfigurację pipeline.

- Wdrażanie za pomocą `Azure DevOps Pipeline`: Wybierz `Azure DevOps`, gdy pojawi się prośba o dostawcę. Jeśli w Twoim projekcie brakuje pliku `azure-dev.yml`, zaakceptuj propozycję jego dodania i kontynuuj konfigurację pipeline.

## Co zostało dodane

### Konfiguracja infrastruktury

Aby opisać infrastrukturę i aplikację, dodano `azure.yaml` z następującą strukturą katalogów:

```yaml
- azure.yaml     # azd project configuration
```

Ten plik zawiera pojedynczą usługę, która odnosi się do App Host Twojego projektu. W razie potrzeby uruchom `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth`, aby zapisać ją na dysku.

Jeśli to zrobisz, zostaną utworzone dodatkowe katalogi:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Dodatkowo, dla każdego zasobu projektu odwołującego się do App Host, plik `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` projektu, odwiedź nasze oficjalne [dokumenty](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dążymy do jak największej dokładności, prosimy mieć na uwadze, że tłumaczenia automatyczne mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym należy uważać za źródło autorytatywne. W przypadku informacji krytycznych zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.