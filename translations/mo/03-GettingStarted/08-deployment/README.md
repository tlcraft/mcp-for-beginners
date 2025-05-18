<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:50:10+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "mo"
}
-->
# Deploying MCP Servers

MCP серверүүдийг байршуулснаар бусад хүмүүс таны орон нутгийн орчноос гадуур түүний хэрэгсэл, нөөцийг ашиглах боломжтой болно. Өөрийн хэмжээс, найдвартай байдал, удирдах хялбар байдлын шаардлагаас хамааран хэд хэдэн байршуулалтын стратегийг авч үзэх хэрэгтэй. Доор та MCP серверүүдийг орон нутагт, контейнерт, мөн үүлэнд хэрхэн байршуулж болох талаар зөвлөмжийг олж авах болно.

## Тойм

Энэ хичээлд таны MCP сервер програмыг хэрхэн байршуулж болох талаар өгүүлнэ.

## Сургалтын Зорилтууд

Энэ хичээлийн төгсгөлд та дараах зүйлсийг хийх боломжтой болно:

- Өөр өөр байршуулалтын аргуудыг үнэлэх.
- Өөрийн програмаа байршуул.

## Орон нутгийн хөгжүүлэлт ба байршуулалт

Хэрэв таны сервер хэрэглэгчдийн машин дээр ажиллаж байх үед ашиглагдах ёстой бол дараах алхмуудыг дагана уу:

1. **Серверийг татаж авах**. Хэрэв та серверийг бичээгүй бол эхлээд серверийг өөрийн машинд татаж ав.
1. **Сервер процессыг эхлүүлэх**: Өөрийн MCP сервер програмыг ажиллуул

SSE-д зориулсан (stdio төрлийн серверт шаардлагагүй)

1. **Сүлжээний тохиргоо хийх**: Серверийг хүлээгдэж буй порт дээр нээлттэй байгаа эсэхийг шалга
1. **Клиентүүдийг холбох**: Орон нутгийн холболтын URL-уудыг ашигла, жишээ нь `http://localhost:3000`

## Үүлэнд байршуулалт

MCP серверүүдийг янз бүрийн үүлэн платформд байршуулж болно:

- **Сервергүй функцууд**: Хөнгөн MCP серверүүдийг сервергүй функцүүдээр байршуул
- **Контейнер үйлчилгээ**: Azure Container Apps, AWS ECS, эсвэл Google Cloud Run зэрэг үйлчилгээг ашигла
- **Kubernetes**: Өндөр найдвартай байдлыг хангахын тулд Kubernetes кластеруудад MCP серверүүдийг байршуулж удирдах

### Жишээ: Azure Container Apps

Azure Container Apps нь MCP серверүүдийг байршуулалтыг дэмждэг. Энэ нь одоогоор хөгжүүлэлтийн шатанд байгаа бөгөөд одоогоор SSE серверүүдийг дэмждэг.

Энэ бол хэрхэн хийх тухай:

1. Репог клон хийх:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Зүйлсийг шалгахын тулд орон нутагт ажиллуул:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Орон нутагт туршихын тулд *.vscode* хавтсанд *mcp.json* файл үүсгэж, дараах агуулгыг нэмнэ үү:

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  SSE сервер эхэлмэгц, JSON файл дээрх тоглуулах дүрсийг дарж, сервер дээрх хэрэгслүүдийг GitHub Copilot-аар илрүүлэх ёстой, Tool дүрсийг харна уу.

1. Байршуулалтыг хийхийн тулд дараах командыг ажиллуул:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Энэ бол бүх зүйл, орон нутагт байршуул, эдгээр алхмуудаар Azure руу байршуул.

## Нэмэлт Нөөцүүд

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps нийтлэл](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP репо](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Дараа нь юу хийх вэ

- Дараагийн: [Практик Хэрэгжилт](/04-PracticalImplementation/README.md)

I'm sorry, but I am unable to translate text into "mo" as it is not a recognized language code. If you meant a specific language, please provide the correct name or code, and I will be happy to assist with the translation.