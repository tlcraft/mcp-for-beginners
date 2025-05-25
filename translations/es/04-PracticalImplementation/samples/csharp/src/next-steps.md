<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-16T15:41:44+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "es"
}
-->
# Próximos pasos después de `azd init`

## Tabla de contenidos

1. [Próximos pasos](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Qué se agregó](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Facturación](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Solución de problemas](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Próximos pasos

### Provisione la infraestructura y despliegue el código de la aplicación

Ejecute `azd up` para provisionar su infraestructura y desplegar en Azure en un solo paso (o ejecute `azd provision` y luego `azd deploy` para realizar las tareas por separado). ¡Visite los endpoints del servicio listados para ver su aplicación en funcionamiento!

Para solucionar cualquier problema, consulte [solución de problemas](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Configure la canalización CI/CD

Ejecute `azd pipeline config -e <environment name>` para configurar la canalización de despliegue y conectarse de forma segura a Azure. Aquí se especifica un nombre de entorno para configurar la canalización con un entorno diferente con fines de aislamiento. Ejecute `azd env list` y `azd env set` para volver a seleccionar el entorno predeterminado después de este paso.

- Desplegando con `GitHub Actions`: Seleccione `GitHub` cuando se le solicite un proveedor. Si su proyecto no tiene el archivo `azure-dev.yml`, acepte la solicitud para agregarlo y continúe con la configuración de la canalización.

- Desplegando con `Azure DevOps Pipeline`: Seleccione `Azure DevOps` cuando se le solicite un proveedor. Si su proyecto no tiene el archivo `azure-dev.yml`, acepte la solicitud para agregarlo y continúe con la configuración de la canalización.

## Qué se agregó

### Configuración de infraestructura

Para describir la infraestructura y la aplicación, se agregó un `azure.yaml` con la siguiente estructura de directorios:

```yaml
- azure.yaml     # azd project configuration
```

Este archivo contiene un único servicio, que referencia el App Host de su proyecto. Cuando sea necesario, use `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` para guardarlo en disco.

Si hace esto, se crearán algunos directorios adicionales:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Además, para cada recurso del proyecto referenciado por su app host, un archivo `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` proyecto, visite nuestra [documentación oficial](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Descargo de responsabilidad**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda una traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas que puedan surgir del uso de esta traducción.