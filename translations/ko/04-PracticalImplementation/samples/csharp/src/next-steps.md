<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-16T15:42:21+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "ko"
}
-->
# `azd init` 이후 다음 단계

## 목차

1. [다음 단계](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [추가된 내용](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [청구](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [문제 해결](../../../../../../04-PracticalImplementation/samples/csharp/src)

## 다음 단계

### 인프라 프로비저닝 및 애플리케이션 코드 배포

`azd up`을 실행하여 인프라를 프로비저닝하고 Azure에 한 번에 배포하세요 (또는 `azd provision`를 실행한 후 `azd deploy`을 실행하여 작업을 별도로 수행할 수 있습니다). 나열된 서비스 엔드포인트를 방문하여 애플리케이션이 정상적으로 작동하는지 확인하세요!

문제가 발생하면 [문제 해결](../../../../../../04-PracticalImplementation/samples/csharp/src)을 참고하세요.

### CI/CD 파이프라인 구성

`azd pipeline config -e <environment name>`를 실행하여 Azure와 안전하게 연결되는 배포 파이프라인을 구성하세요. 여기서 환경 이름을 지정하여 격리 목적으로 다른 환경으로 파이프라인을 구성할 수 있습니다. 이 단계 후 기본 환경을 다시 선택하려면 `azd env list`와 `azd env set`를 실행하세요.

- `GitHub Actions`로 배포하는 경우: 제공자 선택 시 `GitHub`를 선택하세요. 프로젝트에 `azure-dev.yml` 파일이 없으면 추가하라는 메시지가 나타나며, 이를 수락하고 파이프라인 구성을 진행하세요.

- `Azure DevOps Pipeline`로 배포하는 경우: 제공자 선택 시 `Azure DevOps`를 선택하세요. 프로젝트에 `azure-dev.yml` 파일이 없으면 추가하라는 메시지가 나타나며, 이를 수락하고 파이프라인 구성을 진행하세요.

## 추가된 내용

### 인프라 구성

인프라와 애플리케이션을 설명하기 위해 다음과 같은 디렉터리 구조를 가진 `azure.yaml`가 추가되었습니다:

```yaml
- azure.yaml     # azd project configuration
```

이 파일은 프로젝트의 App Host를 참조하는 단일 서비스를 포함합니다. 필요할 때 `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth`를 실행하여 디스크에 저장할 수 있습니다.

이 작업을 수행하면 다음과 같은 추가 디렉터리가 생성됩니다:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

또한, 앱 호스트가 참조하는 각 프로젝트 리소스에 대해 `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` 프로젝트가 생성됩니다. 자세한 내용은 공식 [docs](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert)를 참고하세요.

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의해 주시기 바랍니다. 원본 문서는 해당 언어의 원문이 권위 있는 자료로 간주되어야 합니다. 중요한 정보의 경우에는 전문적인 사람 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해서는 책임을 지지 않습니다.