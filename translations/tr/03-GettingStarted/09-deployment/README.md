<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:29:24+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "tr"
}
-->
# MCP Sunucularının Dağıtımı

MCP sunucunuzu dağıtmak, başkalarının araçlarına ve kaynaklarına yerel ortamınızın dışında erişmesini sağlar. Ölçeklenebilirlik, güvenilirlik ve yönetim kolaylığı gibi ihtiyaçlarınıza bağlı olarak dikkate almanız gereken çeşitli dağıtım stratejileri vardır. Aşağıda MCP sunucularını yerel olarak, konteynerlerde ve buluta dağıtma konusunda rehberlik bulabilirsiniz.

## Genel Bakış

Bu ders, MCP Server uygulamanızın nasıl dağıtılacağını kapsar.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- Farklı dağıtım yaklaşımlarını değerlendirmek.
- Uygulamanızı dağıtmak.

## Yerel geliştirme ve dağıtım

Sunucunuzun kullanıcıların makinelerinde çalıştırılması amaçlanıyorsa, aşağıdaki adımları izleyebilirsiniz:

1. **Sunucuyu indirin**. Sunucuyu siz yazmadıysanız, önce makinenize indirin.  
1. **Sunucu sürecini başlatın**: MCP server uygulamanızı çalıştırın.

SSE için (stdio tipi sunucu için gerekmez)

1. **Ağ yapılandırmasını yapın**: Sunucunun beklenen porttan erişilebilir olduğundan emin olun.  
1. **İstemcileri bağlayın**: `http://localhost:3000` gibi yerel bağlantı URL'lerini kullanın.

## Bulut Dağıtımı

MCP sunucuları çeşitli bulut platformlarına dağıtılabilir:

- **Serverless Functions**: Hafif MCP sunucularını serverless fonksiyonlar olarak dağıtın.  
- **Konteyner Hizmetleri**: Azure Container Apps, AWS ECS veya Google Cloud Run gibi hizmetleri kullanın.  
- **Kubernetes**: Yüksek kullanılabilirlik için MCP sunucularını Kubernetes kümelerinde dağıtın ve yönetin.

### Örnek: Azure Container Apps

Azure Container Apps, MCP Sunucularının dağıtımını destekler. Hâlâ geliştirme aşamasındadır ve şu anda SSE sunucularını desteklemektedir.

Bunu nasıl yapacağınıza dair adımlar:

1. Bir repoyu klonlayın:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Test etmek için yerelde çalıştırın:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Yerelde denemek için *.vscode* dizininde *mcp.json* dosyası oluşturun ve aşağıdaki içeriği ekleyin:

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

  SSE sunucusu başlatıldıktan sonra, JSON dosyasındaki oynat butonuna tıklayabilirsiniz; artık sunucudaki araçların GitHub Copilot tarafından algılandığını, Araç simgesini görebilirsiniz.

1. Dağıtmak için aşağıdaki komutu çalıştırın:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

İşte bu kadar, yerelde dağıtın veya bu adımlarla Azure'a dağıtın.

## Ek Kaynaklar

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps makalesi](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP reposu](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Sonraki Adım

- Sonraki: [Pratik Uygulama](/04-PracticalImplementation/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba sarf etsek de, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek herhangi bir yanlış anlama veya yorum hatasından sorumlu değiliz.