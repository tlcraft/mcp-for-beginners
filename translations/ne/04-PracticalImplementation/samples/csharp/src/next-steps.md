<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:15:47+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "ne"
}
-->
# `azd init` पछि अगाडिका कदमहरू

## सामग्रीको तालिका

1. [अगाडिका कदमहरू](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [के थपिएको थियो](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [बिलिङ](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [समस्या समाधान](../../../../../../04-PracticalImplementation/samples/csharp/src)

## अगाडिका कदमहरू

### पूर्वाधारको व्यवस्था गर्नुहोस् र एप्लिकेसन कोड तैनात गर्नुहोस्

`azd up` चलाएर एकैपटक पूर्वाधारको व्यवस्था गर्नुहोस् र Azure मा तैनात गर्नुहोस् (वा छुट्टै कार्यहरू पूरा गर्न `azd provision` र त्यसपछि `azd deploy` चलाउनुहोस्)। तपाईंको एप्लिकेसन चलिरहेको हेर्न सूचीबद्ध सेवा अन्तिम बिन्दुहरूमा जानुहोस्!

कुनै समस्या समाधान गर्न, [समस्या समाधान](../../../../../../04-PracticalImplementation/samples/csharp/src) हेर्नुहोस्।

### CI/CD पाइपलाइन कन्फिगर गर्नुहोस्

Azure सँग सुरक्षित रूपमा जडान गर्न तैनाती पाइपलाइन कन्फिगर गर्न `azd pipeline config -e <environment name>` चलाउनुहोस्। यहाँ एक वातावरण नाम निर्दिष्ट गरिएको छ, अलगावको उद्देश्यका लागि पाइपलाइनलाई फरक वातावरणसँग कन्फिगर गर्न। यस कदमपछि डिफल्ट वातावरण पुनः चयन गर्न `azd env list` र `azd env set` चलाउनुहोस्।

- `GitHub Actions` प्रयोग गरेर तैनात गर्दै: प्रदायकको लागि सोध्दा `GitHub` चयन गर्नुहोस्। यदि तपाईंको परियोजनामा `azure-dev.yml` फाइल छैन भने, यसलाई थप्नको लागि सोधिने स्वीकृति दिनुहोस् र पाइपलाइन कन्फिगरेसन अगाडि बढाउनुहोस्।

- `Azure DevOps Pipeline` प्रयोग गरेर तैनात गर्दै: प्रदायकको लागि सोध्दा `Azure DevOps` चयन गर्नुहोस्। यदि तपाईंको परियोजनामा `azure-dev.yml` फाइल छैन भने, यसलाई थप्नको लागि सोधिने स्वीकृति दिनुहोस् र पाइपलाइन कन्फिगरेसन अगाडि बढाउनुहोस्।

## के थपिएको थियो

### पूर्वाधार कन्फिगरेसन

पूर्वाधार र एप्लिकेसन वर्णन गर्न, निम्न डाइरेक्टरी संरचनासँग एक `azure.yaml` थपिएको थियो:

```yaml
- azure.yaml     # azd project configuration
```

यस फाइलमा एकल सेवा समावेश छ, जसले तपाईंको परियोजनाको App Host लाई सन्दर्भ गर्दछ। आवश्यक परेमा, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` चलाएर यसलाई डिस्कमा स्थायी बनाउन सकिन्छ।

यदि तपाईंले यो गर्नुहुन्छ भने, केही अतिरिक्त डाइरेक्टरीहरू सिर्जना गरिनेछ:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

यसका साथै, तपाईंको एप होस्टले सन्दर्भ गर्ने प्रत्येक परियोजना स्रोतको लागि, एक `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` परियोजना, हाम्रो आधिकारिक [डक्स](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert) मा जानुहोस्।

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) को प्रयोग गरेर अनुवाद गरिएको हो। हामी यथार्थताको लागि प्रयास गर्छौं, तर कृपया सचेत रहनुहोस् कि स्वचालित अनुवादहरूमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छन्। यसको मौलिक भाषामा रहेको मूल दस्तावेजलाई प्राधिकृत स्रोतको रूपमा मान्नुपर्छ। महत्वपूर्ण जानकारीको लागि, व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार हुने छैनौं।