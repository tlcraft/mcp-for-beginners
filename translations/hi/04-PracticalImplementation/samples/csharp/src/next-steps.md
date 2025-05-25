<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:15:05+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "hi"
}
-->
# `azd init` के बाद अगले कदम

## विषय सूची

1. [अगले कदम](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [क्या जोड़ा गया](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [बिलिंग](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [समस्या समाधान](../../../../../../04-PracticalImplementation/samples/csharp/src)

## अगले कदम

### बुनियादी ढांचा तैयार करें और एप्लिकेशन कोड तैनात करें

अपने बुनियादी ढांचे को तैयार करने और Azure में एक कदम में तैनात करने के लिए `azd up` चलाएँ (या `azd provision` फिर `azd deploy` चलाएँ ताकि कार्यों को अलग-अलग पूरा किया जा सके)। अपनी एप्लिकेशन को चलती स्थिति में देखने के लिए सूचीबद्ध सेवा एंडपॉइंट्स पर जाएँ!

किसी भी समस्या को हल करने के लिए, [समस्या समाधान](../../../../../../04-PracticalImplementation/samples/csharp/src) देखें।

### CI/CD पाइपलाइन कॉन्फ़िगर करें

Azure से सुरक्षित रूप से जुड़ने के लिए तैनाती पाइपलाइन को कॉन्फ़िगर करने के लिए `azd pipeline config -e <environment name>` चलाएँ। यहां एक वातावरण नाम निर्दिष्ट किया जाता है ताकि अलगाव उद्देश्यों के लिए पाइपलाइन को एक अलग वातावरण के साथ कॉन्फ़िगर किया जा सके। इस कदम के बाद डिफ़ॉल्ट वातावरण को पुनः चुनने के लिए `azd env list` और `azd env set` चलाएँ।

- `GitHub Actions` के साथ तैनात करना: प्रदाता के लिए पूछे जाने पर `GitHub` चुनें। यदि आपके प्रोजेक्ट में `azure-dev.yml` फ़ाइल नहीं है, तो इसे जोड़ने के लिए प्रॉम्प्ट स्वीकार करें और पाइपलाइन कॉन्फ़िगरेशन के साथ आगे बढ़ें।

- `Azure DevOps Pipeline` के साथ तैनात करना: प्रदाता के लिए पूछे जाने पर `Azure DevOps` चुनें। यदि आपके प्रोजेक्ट में `azure-dev.yml` फ़ाइल नहीं है, तो इसे जोड़ने के लिए प्रॉम्प्ट स्वीकार करें और पाइपलाइन कॉन्फ़िगरेशन के साथ आगे बढ़ें।

## क्या जोड़ा गया

### बुनियादी ढांचा कॉन्फ़िगरेशन

बुनियादी ढांचे और एप्लिकेशन का वर्णन करने के लिए, निम्नलिखित निर्देशिका संरचना के साथ एक `azure.yaml` जोड़ा गया:

```yaml
- azure.yaml     # azd project configuration
```

इस फ़ाइल में एकल सेवा होती है, जो आपके प्रोजेक्ट के ऐप होस्ट को संदर्भित करती है। जब आवश्यक हो, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` इसे डिस्क पर बनाए रखने के लिए।

यदि आप ऐसा करते हैं, तो कुछ अतिरिक्त निर्देशिकाएं बनाई जाएंगी:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

इसके अलावा, आपके ऐप होस्ट द्वारा संदर्भित प्रत्येक प्रोजेक्ट संसाधन के लिए, एक `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` प्रोजेक्ट, हमारे आधिकारिक [दस्तावेज़](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert) पर जाएँ।

**अस्वीकरण**:
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवाद में त्रुटियां या गलतियाँ हो सकती हैं। मूल दस्तावेज़ को उसकी मूल भाषा में आधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।