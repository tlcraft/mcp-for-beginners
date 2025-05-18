<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:15:32+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "mr"
}
-->
# `azd init` नंतर पुढील पावले

## अनुक्रमणिका

1. [पुढील पावले](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [काय जोडले गेले](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [बिलिंग](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [समस्या निराकरण](../../../../../../04-PracticalImplementation/samples/csharp/src)

## पुढील पावले

### इन्फ्रास्ट्रक्चर पुरवठा करा आणि अनुप्रयोग कोड तैनात करा

आपल्या इन्फ्रास्ट्रक्चरची व्यवस्था करण्यासाठी आणि एकाच पावलात Azure वर तैनात करण्यासाठी `azd up` चालवा (किंवा `azd provision` नंतर `azd deploy` स्वतंत्रपणे कार्ये पूर्ण करण्यासाठी चालवा). आपल्या अनुप्रयोगाला कार्यरत पाहण्यासाठी सूचीबद्ध सेवा endpoints वर जा!

कोणत्याही समस्यांचे निराकरण करण्यासाठी, [समस्या निराकरण](../../../../../../04-PracticalImplementation/samples/csharp/src) पहा.

### CI/CD पाइपलाइन कॉन्फिगर करा

Azure वर सुरक्षितपणे कनेक्ट करण्यासाठी तैनाती पाइपलाइन कॉन्फिगर करण्यासाठी `azd pipeline config -e <environment name>` चालवा. अलग ठेवण्याच्या उद्देशाने वेगळ्या वातावरणासह पाइपलाइन कॉन्फिगर करण्यासाठी येथे एक वातावरणाचे नाव निर्दिष्ट केले जाते. या चरणानंतर डीफॉल्ट वातावरण पुन्हा निवडण्यासाठी `azd env list` आणि `azd env set` चालवा.

- `GitHub Actions` सह तैनात करताना: प्रदाता विचारल्यावर `GitHub` निवडा. जर आपल्या प्रकल्पात `azure-dev.yml` फाइल नसल्यास, ती जोडण्यासाठी सूचना स्वीकारा आणि पाइपलाइन कॉन्फिगरेशनसह पुढे जा.

- `Azure DevOps Pipeline` सह तैनात करताना: प्रदाता विचारल्यावर `Azure DevOps` निवडा. जर आपल्या प्रकल्पात `azure-dev.yml` फाइल नसल्यास, ती जोडण्यासाठी सूचना स्वीकारा आणि पाइपलाइन कॉन्फिगरेशनसह पुढे जा.

## काय जोडले गेले

### इन्फ्रास्ट्रक्चर कॉन्फिगरेशन

इन्फ्रास्ट्रक्चर आणि अनुप्रयोगाचे वर्णन करण्यासाठी, खालील निर्देशिका संरचनेसह एक `azure.yaml` जोडले गेले:

```yaml
- azure.yaml     # azd project configuration
```

या फाइलमध्ये एकच सेवा आहे, जी आपल्या प्रकल्पाच्या App Host ला संदर्भित करते. आवश्यक असल्यास, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` ते डिस्कवर टिकवण्यासाठी चालवा.

जर आपण हे केले तर, काही अतिरिक्त निर्देशिका तयार केल्या जातील:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

याव्यतिरिक्त, आपल्या अनुप्रयोग होस्टद्वारे संदर्भित प्रत्येक प्रकल्प संसाधनासाठी, `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` प्रकल्प, आमच्या अधिकृत [दस्तऐवज](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert) ला भेट द्या.

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला गेला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात ठेवा की स्वयंचलित भाषांतरे चुका किंवा अचूकतेची कमतरता असू शकतात. मूळ भाषेतील मूळ दस्तऐवज अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी, व्यावसायिक मानवी भाषांतराची शिफारस केली जाते. या भाषांतराच्या वापरातून उद्भवणार्‍या कोणत्याही गैरसमज किंवा चुकीच्या अर्थासाठी आम्ही जबाबदार नाही.