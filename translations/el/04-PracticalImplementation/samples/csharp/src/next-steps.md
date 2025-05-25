<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:16:59+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "el"
}
-->
# Επόμενα Βήματα μετά το `azd init`

## Πίνακας Περιεχομένων

1. [Επόμενα Βήματα](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Τι προστέθηκε](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Χρέωση](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Αντιμετώπιση προβλημάτων](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Επόμενα Βήματα

### Παροχή υποδομής και ανάπτυξη κώδικα εφαρμογής

Τρέξτε `azd up` για να παρέχετε την υποδομή σας και να αναπτύξετε στο Azure σε ένα βήμα (ή τρέξτε `azd provision` και μετά `azd deploy` για να ολοκληρώσετε τις εργασίες ξεχωριστά). Επισκεφθείτε τα σημεία εξυπηρέτησης που αναφέρονται για να δείτε την εφαρμογή σας σε λειτουργία!

Για να αντιμετωπίσετε τυχόν προβλήματα, δείτε [αντιμετώπιση προβλημάτων](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Διαμόρφωση σωλήνα CI/CD

Τρέξτε `azd pipeline config -e <environment name>` για να διαμορφώσετε τον σωλήνα ανάπτυξης ώστε να συνδεθεί με ασφάλεια στο Azure. Εδώ καθορίζεται ένα όνομα περιβάλλοντος για να διαμορφώσετε τον σωλήνα με διαφορετικό περιβάλλον για σκοπούς απομόνωσης. Τρέξτε `azd env list` και `azd env set` για να επαναφέρετε το προεπιλεγμένο περιβάλλον μετά από αυτό το βήμα.

- Ανάπτυξη με `GitHub Actions`: Επιλέξτε `GitHub` όταν σας ζητηθεί να επιλέξετε πάροχο. Αν το έργο σας δεν έχει το αρχείο `azure-dev.yml`, αποδεχτείτε την προτροπή για προσθήκη και προχωρήστε στη διαμόρφωση του σωλήνα.

- Ανάπτυξη με `Azure DevOps Pipeline`: Επιλέξτε `Azure DevOps` όταν σας ζητηθεί να επιλέξετε πάροχο. Αν το έργο σας δεν έχει το αρχείο `azure-dev.yml`, αποδεχτείτε την προτροπή για προσθήκη και προχωρήστε στη διαμόρφωση του σωλήνα.

## Τι προστέθηκε

### Διαμόρφωση υποδομής

Για να περιγράψετε την υποδομή και την εφαρμογή, προστέθηκε ένα `azure.yaml` με την ακόλουθη δομή καταλόγου:

```yaml
- azure.yaml     # azd project configuration
```

Αυτό το αρχείο περιέχει μία υπηρεσία, η οποία αναφέρεται στον App Host του έργου σας. Όταν χρειαστεί, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` για να το διατηρήσετε στον δίσκο.

Αν το κάνετε αυτό, θα δημιουργηθούν μερικοί επιπλέον κατάλογοι:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Επιπλέον, για κάθε πόρο έργου που αναφέρεται από τον host της εφαρμογής σας, ένα `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` έργο, επισκεφθείτε τα επίσημα [έγγραφά μας](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Αποποίηση Ευθύνης**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης [Co-op Translator](https://github.com/Azure/co-op-translator). Ενώ προσπαθούμε για την ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτόματες μεταφράσεις μπορεί να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται η επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή παρανοήσεις που προκύπτουν από τη χρήση αυτής της μετάφρασης.