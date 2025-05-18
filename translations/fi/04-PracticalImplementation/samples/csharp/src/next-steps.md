<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:18:00+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "fi"
}
-->
# Seuraavat askeleet `azd init` jälkeen

## Sisällysluettelo

1. [Seuraavat askeleet](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Mitä lisättiin](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Laskutus](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Vianmääritys](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Seuraavat askeleet

### Infrastruktuurin provisiointi ja sovelluskoodin käyttöönotto

Aja `azd up` provisioidaksesi infrastruktuurisi ja ottaaksesi käyttöön Azuren yhdellä askeleella (tai aja `azd provision` sitten `azd deploy` suorittaaksesi tehtävät erikseen). Vieraile listatuissa palvelun päätepisteissä nähdäksesi sovelluksesi toiminnassa!

Jos kohtaat ongelmia, katso [vianmääritys](../../../../../../04-PracticalImplementation/samples/csharp/src).

### CI/CD-putken konfigurointi

Aja `azd pipeline config -e <environment name>` konfiguroidaksesi käyttöönottoputken turvalliseen yhteyteen Azureen. Tässä määritellään ympäristön nimi, jotta putki voidaan konfiguroida eri ympäristöllä eristystarkoituksia varten. Aja `azd env list` ja `azd env set` valitaksesi oletusympäristö uudelleen tämän vaiheen jälkeen.

- Käyttöönotto `GitHub Actions` kanssa: Valitse `GitHub`, kun sinulta kysytään palveluntarjoajaa. Jos projektistasi puuttuu `azure-dev.yml` tiedosto, hyväksy kehotus lisätä se ja jatka putken konfigurointia.

- Käyttöönotto `Azure DevOps Pipeline` kanssa: Valitse `Azure DevOps`, kun sinulta kysytään palveluntarjoajaa. Jos projektistasi puuttuu `azure-dev.yml` tiedosto, hyväksy kehotus lisätä se ja jatka putken konfigurointia.

## Mitä lisättiin

### Infrastruktuurin konfigurointi

Infrastruktuurin ja sovelluksen kuvaamiseksi lisättiin `azure.yaml` seuraavalla hakemistorakenteella:

```yaml
- azure.yaml     # azd project configuration
```

Tämä tiedosto sisältää yhden palvelun, joka viittaa projektisi App Hostiin. Kun tarvitaan, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` tallentaaksesi sen levylle.

Jos teet tämän, joitakin lisähakemistoja luodaan:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Lisäksi, jokaiselle projektin resurssille, johon sovelluksen isäntä viittaa, luodaan `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` projekti, vieraile virallisissa [dokumenteissamme](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää auktoritatiivisena lähteenä. Kriittisten tietojen osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.