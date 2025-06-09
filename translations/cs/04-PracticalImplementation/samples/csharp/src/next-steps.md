<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-27T16:26:01+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "cs"
}
-->
// Next Steps after `azd init`

// Table of Contents

// 1. Next Steps
// 2. What was added
// 3. Billing
// 4. Troubleshooting

// Next Steps

// Provision infrastructure and deploy application code

// Run `azd up` to provision your infrastructure and deploy to Azure in one step (or run `azd provision` then `azd deploy` to accomplish the tasks separately). Visit the service endpoints listed to see your application up-and-running!

// To troubleshoot any issues, see troubleshooting.

// Configure CI/CD pipeline

// Run `azd pipeline config -e <environment name>` to configure the deployment pipeline to connect securely to Azure. An environment name is specified here to configure the pipeline with a different environment for isolation purposes. Run `azd env list` and `azd env set` to reselect the default environment after this step.

// - Deploying with `GitHub Actions`: Select `GitHub` when prompted for a provider. If your project lacks the `azure-dev.yml` file, accept the prompt to add it and proceed with pipeline configuration.

// - Deploying with `Azure DevOps Pipeline`: Select `Azure DevOps` when prompted for a provider. If your project lacks the `azure-dev.yml` file, accept the prompt to add it and proceed with pipeline configuration.

// What was added

// Infrastructure configuration

// To describe the infrastructure and application, an `azure.yaml` was added with the following directory structure:

// ```yaml
- azure.yaml     # azd project configuration
```

// This file contains a single service, which references your project's App Host. When needed, run azd infra synth to persist it to disk.

// If you do this, some additional directories will be created:

// ```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

// In addition, for each project resource referenced by your app host, a containerApp.tmpl.yaml file will be generated.

// For more details on how to convert your project, visit our official docs at https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert.

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo chybné výklady vzniklé použitím tohoto překladu.