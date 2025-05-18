<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:15:18+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "bn"
}
-->
# `azd init` পরবর্তী পদক্ষেপ

## বিষয়সূচি

1. [পরবর্তী পদক্ষেপ](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [কি যোগ করা হয়েছে](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [বিলিং](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [সমস্যা সমাধান](../../../../../../04-PracticalImplementation/samples/csharp/src)

## পরবর্তী পদক্ষেপ

### পরিকাঠামো প্রস্তুত করা এবং অ্যাপ্লিকেশন কোড স্থাপন করা

আপনার পরিকাঠামো প্রস্তুত করতে এবং এক ধাপে Azure-এ স্থাপন করতে `azd up` চালান (অথবা `azd provision` তারপর `azd deploy` আলাদাভাবে কাজগুলি সম্পন্ন করতে চালান)। আপনার অ্যাপ্লিকেশন চলমান দেখতে তালিকাভুক্ত সার্ভিস এন্ডপয়েন্টগুলি দেখুন!

কোনো সমস্যা সমাধানের জন্য, [সমস্যা সমাধান](../../../../../../04-PracticalImplementation/samples/csharp/src) দেখুন।

### CI/CD পাইপলাইন কনফিগার করা

Azure-এর সাথে নিরাপদে সংযোগ করতে স্থাপন পাইপলাইন কনফিগার করতে `azd pipeline config -e <environment name>` চালান। একটি পরিবেশের নাম এখানে নির্দিষ্ট করা হয়েছে যাতে ভিন্ন পরিবেশের সাথে পাইপলাইন আলাদা করার জন্য কনফিগার করা যায়। এই ধাপের পরে ডিফল্ট পরিবেশ পুনরায় নির্বাচন করতে `azd env list` এবং `azd env set` চালান।

- `GitHub Actions` এর সাথে স্থাপন: একটি প্রদানকারীর জন্য জিজ্ঞাসিত হলে `GitHub` নির্বাচন করুন। যদি আপনার প্রকল্পে `azure-dev.yml` ফাইল না থাকে, তাহলে এটি যোগ করার জন্য প্রম্পট গ্রহণ করুন এবং পাইপলাইন কনফিগারেশন চালিয়ে যান।

- `Azure DevOps Pipeline` এর সাথে স্থাপন: একটি প্রদানকারীর জন্য জিজ্ঞাসিত হলে `Azure DevOps` নির্বাচন করুন। যদি আপনার প্রকল্পে `azure-dev.yml` ফাইল না থাকে, তাহলে এটি যোগ করার জন্য প্রম্পট গ্রহণ করুন এবং পাইপলাইন কনফিগারেশন চালিয়ে যান।

## কি যোগ করা হয়েছে

### পরিকাঠামো কনফিগারেশন

পরিকাঠামো এবং অ্যাপ্লিকেশন বর্ণনা করার জন্য একটি `azure.yaml` যোগ করা হয়েছে নিম্নলিখিত ডিরেক্টরি কাঠামো সহ:

```yaml
- azure.yaml     # azd project configuration
```

এই ফাইলটিতে একটি একক সার্ভিস রয়েছে, যা আপনার প্রকল্পের অ্যাপ হোস্টকে উল্লেখ করে। যখন প্রয়োজন, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` এটি ডিস্কে সংরক্ষণ করতে।

যদি আপনি এটি করেন, কিছু অতিরিক্ত ডিরেক্টরি তৈরি হবে:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

এছাড়াও, আপনার অ্যাপ হোস্ট দ্বারা উল্লেখিত প্রতিটি প্রকল্প সংস্থার জন্য, একটি `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` প্রকল্প, আমাদের অফিসিয়াল [ডকস](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert) দেখুন।

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ পরিষেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনুবাদ করা হয়েছে। আমরা যথাসম্ভব সঠিকতার জন্য চেষ্টা করি, তবে অনুগ্রহ করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। এর মূল ভাষায় থাকা নথিটি প্রামাণিক উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদ ব্যবহারের ফলে কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যা উদ্ভূত হলে আমরা দায়ী থাকব না।