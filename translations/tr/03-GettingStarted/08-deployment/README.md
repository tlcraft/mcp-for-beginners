<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:52:24+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "tr"
}
-->
# MCP Sunucularını Dağıtma

MCP sunucunuzu dağıtmak, yerel ortamınızın ötesinde araçlarına ve kaynaklarına erişim sağlar. Ölçeklenebilirlik, güvenilirlik ve yönetim kolaylığı konusundaki gereksinimlerinize bağlı olarak dikkate almanız gereken çeşitli dağıtım stratejileri vardır. Aşağıda, MCP sunucularını yerel olarak, konteynerlerde ve bulutta dağıtmak için rehber bulacaksınız.

## Genel Bakış

Bu ders, MCP Sunucu uygulamanızı nasıl dağıtacağınızı kapsar.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- Farklı dağıtım yaklaşımlarını değerlendirin.
- Uygulamanızı dağıtın.

## Yerel geliştirme ve dağıtım

Sunucunuz kullanıcıların makinesinde çalıştırılarak tüketilmek üzere tasarlandıysa, aşağıdaki adımları takip edebilirsiniz:

1. **Sunucuyu indirin**. Sunucuyu siz yazmadıysanız, önce makinenize indirin.
1. **Sunucu sürecini başlatın**: MCP sunucu uygulamanızı çalıştırın

SSE için (stdio türü sunucu için gerekli değil)

1. **Ağ yapılandırması**: Sunucunun beklenen portta erişilebilir olduğundan emin olun
1. **İstemcileri bağlayın**: `http://localhost:3000` gibi yerel bağlantı URL'lerini kullanın

## Bulut Dağıtımı

MCP sunucuları çeşitli bulut platformlarına dağıtılabilir:

- **Sunucusuz Fonksiyonlar**: Hafif MCP sunucularını sunucusuz fonksiyonlar olarak dağıtın
- **Konteyner Hizmetleri**: Azure Container Apps, AWS ECS veya Google Cloud Run gibi hizmetleri kullanın
- **Kubernetes**: MCP sunucularını yüksek erişilebilirlik için Kubernetes kümelerinde dağıtın ve yönetin

### Örnek: Azure Container Apps

Azure Container Apps, MCP Sunucularının dağıtımını destekler. Hâlâ geliştirme aşamasındadır ve şu anda SSE sunucularını desteklemektedir.

İşte nasıl yapabileceğiniz:

1. Bir repo klonlayın:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Yerel olarak çalıştırarak test edin:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Yerel olarak denemek için, *.vscode* dizininde bir *mcp.json* dosyası oluşturun ve aşağıdaki içeriği ekleyin:

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

  SSE sunucusu başlatıldığında, JSON dosyasındaki oynatma simgesine tıklayabilirsiniz, artık sunucudaki araçların GitHub Copilot tarafından alındığını görmelisiniz, Araç simgesine bakın.

1. Dağıtmak için, aşağıdaki komutu çalıştırın:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

İşte bu kadar, yerel olarak dağıtın, bu adımlar aracılığıyla Azure'a dağıtın.

## Ek Kaynaklar

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps makalesi](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Sıradaki

- Sonraki: [Pratik Uygulama](/04-PracticalImplementation/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayın. Belgenin orijinal dili, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlamalar veya yanlış yorumlamalar için sorumluluk kabul etmiyoruz.