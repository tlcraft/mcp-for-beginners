<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:31:32+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "tr"
}
-->
# Vaka Çalışması: REST API'yi API Yönetiminde MCP sunucusu olarak açığa çıkarma

Azure API Management, API Uç Noktalarınızın üzerinde bir Ağ Geçidi sağlayan bir hizmettir. Çalışma şekli, Azure API Management'ın API'lerinizin önünde bir vekil (proxy) gibi davranması ve gelen isteklerle ne yapılacağına karar vermesidir.

Bunu kullanarak şu özellikleri eklemiş olursunuz:

- **Güvenlik**, API anahtarlarından JWT'ye ve yönetilen kimliklere kadar her şeyi kullanabilirsiniz.
- **Oran sınırlaması**, belirli bir zaman biriminde kaç çağrının geçmesine izin verileceğine karar verebilmek harika bir özelliktir. Bu, tüm kullanıcıların iyi bir deneyim yaşamasını sağlar ve hizmetinizin isteklerle aşırı yüklenmesini önler.
- **Ölçeklendirme ve Yük Dengeleme**. Yükü dengelemek için birden fazla uç nokta ayarlayabilir ve "yük dengeleme" yöntemini seçebilirsiniz.
- **Anlamsal önbellekleme gibi AI özellikleri**, token limiti ve token izleme gibi daha fazlası. Bunlar, yanıt verme hızını artıran ve token harcamalarınızı kontrol altında tutmanıza yardımcı olan harika özelliklerdir. [Buradan daha fazlasını okuyun](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Neden MCP + Azure API Management?

Model Context Protocol, ajan tabanlı AI uygulamaları için ve araçları ile verileri tutarlı bir şekilde açığa çıkarmak için hızla standart haline geliyor. Azure API Management, API'leri "yönetmeniz" gerektiğinde doğal bir tercihtir. MCP Sunucuları genellikle istekleri bir araca çözümlemek için diğer API'lerle entegre olur. Bu nedenle Azure API Management ile MCP'yi birleştirmek oldukça mantıklıdır.

## Genel Bakış

Bu özel kullanım senaryosunda, API uç noktalarını MCP Sunucusu olarak açığa çıkarmayı öğreneceğiz. Bunu yaparak, bu uç noktaları ajan tabanlı bir uygulamanın parçası haline getirebilir ve aynı zamanda Azure API Management'ın özelliklerinden faydalanabiliriz.

## Temel Özellikler

- Araç olarak açığa çıkarmak istediğiniz uç nokta yöntemlerini seçersiniz.
- Ek özellikler, API'niz için politika bölümünde yapılandırdıklarınıza bağlıdır. Ancak burada size oran sınırlamasını nasıl ekleyebileceğinizi göstereceğiz.

## Ön adım: Bir API içe aktarın

Zaten Azure API Management'ta bir API'niz varsa harika, bu adımı atlayabilirsiniz. Yoksa, şu bağlantıya göz atın, [Azure API Management'a API içe aktarma](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## API'yi MCP Sunucusu olarak açığa çıkarma

API uç noktalarını açığa çıkarmak için şu adımları izleyelim:

1. Azure Portal'a gidin ve şu adrese erişin <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
API Yönetim örneğinize gidin.

1. Sol menüde, APIs > MCP Servers > + Create new MCP Server seçeneğini tıklayın.

1. API bölümünde, MCP sunucusu olarak açığa çıkarılacak bir REST API seçin.

1. Araç olarak açığa çıkarılacak bir veya daha fazla API İşlemi seçin. Tüm işlemleri veya sadece belirli işlemleri seçebilirsiniz.

    ![Açığa çıkarılacak yöntemleri seçin](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. **Create** seçeneğini tıklayın.

1. Menüden **APIs** ve **MCP Servers** seçeneklerine gidin, aşağıdakini görmelisiniz:

    ![Ana panelde MCP Sunucusunu görün](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP sunucusu oluşturuldu ve API işlemleri araçlar olarak açığa çıkarıldı. MCP sunucusu MCP Servers panelinde listelenir. URL sütunu, test etmek veya bir istemci uygulaması içinde çağırmak için kullanabileceğiniz MCP sunucusunun uç noktasını gösterir.

## İsteğe bağlı: Politikaları yapılandırma

Azure API Management, uç noktalarınız için oran sınırlaması veya anlamsal önbellekleme gibi farklı kurallar belirleyebileceğiniz politika kavramına sahiptir. Bu politikalar XML formatında yazılır.

MCP Sunucunuz için oran sınırlaması politikası nasıl ayarlanır:

1. Portalda, APIs altında **MCP Servers** seçin.

1. Oluşturduğunuz MCP sunucusunu seçin.

1. Sol menüde, MCP altında **Policies** seçeneğine tıklayın.

1. Politika düzenleyicide, MCP sunucusunun araçlarına uygulamak istediğiniz politikaları ekleyin veya düzenleyin. Politikalar XML formatında tanımlanır. Örneğin, MCP sunucusunun araçlarına yapılan çağrıları sınırlamak için (bu örnekte, her istemci IP adresi için 30 saniyede 5 çağrı) bir politika ekleyebilirsiniz. İşte oran sınırlaması yapacak XML:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Politika düzenleyicinin resmi:

    ![Politika düzenleyici](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Deneyin

MCP Sunucumuzun beklendiği gibi çalıştığından emin olalım.

Bunun için Visual Studio Code ve GitHub Copilot'un Agent modunu kullanacağız. MCP sunucusunu *mcp.json* dosyasına ekleyeceğiz. Böylece Visual Studio Code, ajan özelliklerine sahip bir istemci olarak hareket edecek ve son kullanıcılar bir istem yazıp bu sunucu ile etkileşimde bulunabilecek.

Visual Studio Code'da MCP sunucusunu ekleme adımları:

1. Komut Paletinden MCP: **Add Server komutunu kullanın**.

1. İstendiğinde, sunucu türünü seçin: **HTTP (HTTP veya Server Sent Events)**.

1. API Management'taki MCP sunucusunun URL'sini girin. Örnek: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (SSE uç noktası için) veya **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (MCP uç noktası için), taşıma protokolleri arasındaki farkın `/sse` veya `/mcp` olduğunu unutmayın.

1. İstediğiniz bir sunucu kimliği girin. Bu önemli bir değer değil ama bu sunucu örneğinin ne olduğunu hatırlamanıza yardımcı olur.

1. Yapılandırmayı çalışma alanı ayarlarına mı yoksa kullanıcı ayarlarına mı kaydedeceğinizi seçin.

  - **Çalışma alanı ayarları** - Sunucu yapılandırması yalnızca mevcut çalışma alanında bulunan .vscode/mcp.json dosyasına kaydedilir.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    veya taşıma protokolü olarak streaming HTTP seçerseniz biraz farklı olur:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **Kullanıcı ayarları** - Sunucu yapılandırması global *settings.json* dosyanıza eklenir ve tüm çalışma alanlarında kullanılabilir. Yapılandırma aşağıdaki gibidir:

    ![Kullanıcı ayarı](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Ayrıca Azure API Management'a doğru şekilde kimlik doğrulaması yapması için bir başlık eklemeniz gerekir. Bu, **Ocp-Apim-Subscription-Key** adlı bir başlık kullanır.

    - Ayarlara nasıl ekleyeceğiniz:

    ![Kimlik doğrulama için başlık ekleme](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), bu, Azure Portal'da Azure API Management örneğiniz için bulabileceğiniz API anahtarı değerini girmeniz için bir istem görüntüler.

   - Bunun yerine *mcp.json* dosyasına eklemek isterseniz, şöyle ekleyebilirsiniz:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Agent modunu kullanma

Artık ayarlarda veya *.vscode/mcp.json* dosyasında her şey hazır. Hadi deneyelim.

Sunucunuzdan açığa çıkarılan araçların listelendiği şu şekilde bir Araçlar simgesi olmalıdır:

![Sunucudan araçlar](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Araçlar simgesine tıklayın, aşağıdaki gibi bir araç listesi görmelisiniz:

    ![Araçlar](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Aracı çağırmak için sohbete bir istem yazın. Örneğin, bir sipariş hakkında bilgi almak için bir araç seçtiyseniz, ajanı sipariş hakkında sorgulayabilirsiniz. İşte örnek bir istem:

    ```text
    get information from order 2
    ```

    Artık bir araç çağırmaya devam etmek isteyip istemediğinizi soran bir araçlar simgesi gösterilecektir. Aracı çalıştırmaya devam etmeyi seçin, aşağıdaki gibi bir çıktı görmelisiniz:

    ![İstem sonucundan çıktı](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **Yukarıda gördüğünüz, kurduğunuz araçlara bağlıdır, ancak amaç yukarıdaki gibi metinsel bir yanıt almaktır.**


## Kaynaklar

Daha fazla bilgi edinmek için:

- [Azure API Management ve MCP üzerine eğitim](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python örneği: Azure API Management kullanarak güvenli uzak MCP sunucuları (deneysel)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP istemci yetkilendirme laboratuvarı](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [VS Code için Azure API Management uzantısını kullanarak API'leri içe aktarma ve yönetme](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Azure API Center'da uzak MCP sunucularını kaydetme ve keşfetme](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Azure API Management ile birçok AI özelliğini gösteren harika bir depo
- [AI Gateway atölyeleri](https://azure-samples.github.io/AI-Gateway/) Azure Portal kullanarak AI özelliklerini değerlendirmeye başlamak için harika atölyeler içerir

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.