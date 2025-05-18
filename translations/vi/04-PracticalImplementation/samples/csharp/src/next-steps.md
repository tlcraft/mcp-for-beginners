<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "be745fda2aef9ee7ea772119fc6cdcf7",
  "translation_date": "2025-05-17T14:18:33+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/src/next-steps.md",
  "language_code": "vi"
}
-->
# Các bước tiếp theo sau `azd init`

## Mục lục

1. [Các bước tiếp theo](../../../../../../04-PracticalImplementation/samples/csharp/src)
2. [Những gì đã được thêm vào](../../../../../../04-PracticalImplementation/samples/csharp/src)
3. [Thanh toán](../../../../../../04-PracticalImplementation/samples/csharp/src)
4. [Xử lý sự cố](../../../../../../04-PracticalImplementation/samples/csharp/src)

## Các bước tiếp theo

### Cung cấp hạ tầng và triển khai mã ứng dụng

Chạy `azd up` để cung cấp hạ tầng và triển khai lên Azure trong một bước (hoặc chạy `azd provision` rồi `azd deploy` để thực hiện các nhiệm vụ riêng biệt). Truy cập các điểm cuối dịch vụ được liệt kê để thấy ứng dụng của bạn hoạt động!

Để xử lý sự cố, xem [xử lý sự cố](../../../../../../04-PracticalImplementation/samples/csharp/src).

### Cấu hình pipeline CI/CD

Chạy `azd pipeline config -e <environment name>` để cấu hình pipeline triển khai kết nối an toàn với Azure. Tên môi trường được chỉ định ở đây để cấu hình pipeline với môi trường khác nhằm mục đích cô lập. Chạy `azd env list` và `azd env set` để chọn lại môi trường mặc định sau bước này.

- Triển khai với `GitHub Actions`: Chọn `GitHub` khi được hỏi về nhà cung cấp. Nếu dự án của bạn thiếu file `azure-dev.yml`, chấp nhận lời nhắc để thêm nó và tiến hành cấu hình pipeline.

- Triển khai với `Azure DevOps Pipeline`: Chọn `Azure DevOps` khi được hỏi về nhà cung cấp. Nếu dự án của bạn thiếu file `azure-dev.yml`, chấp nhận lời nhắc để thêm nó và tiến hành cấu hình pipeline.

## Những gì đã được thêm vào

### Cấu hình hạ tầng

Để mô tả hạ tầng và ứng dụng, một `azure.yaml` đã được thêm vào với cấu trúc thư mục sau:

```yaml
- azure.yaml     # azd project configuration
```

File này chứa một dịch vụ duy nhất, tham chiếu đến App Host của dự án của bạn. Khi cần thiết, `azd` generates the required infrastructure as code in memory and uses it.

If you would like to see or modify the infrastructure that `azd` uses, run `azd infra synth` để lưu nó vào ổ đĩa.

Nếu bạn làm điều này, một số thư mục bổ sung sẽ được tạo:

```yaml
- infra/            # Infrastructure as Code (bicep) files
  - main.bicep      # main deployment module
  - resources.bicep # resources shared across your application's services
```

Ngoài ra, cho mỗi tài nguyên dự án được tham chiếu bởi app host của bạn, một `containerApp.tmpl.yaml` file will be created in a directory named `manifests` next the project file. This file contains the infrastructure as code for running the project on Azure Container Apps.

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

For additional information about setting up your `azd` dự án, hãy truy cập [tài liệu chính thức](https://learn.microsoft.com/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-convert).

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn thông tin chính thức. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.