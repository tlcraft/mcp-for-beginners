<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:43:10+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "tr"
}
-->
## Test Etme ve Hata Ayıklama

MCP sunucunuzu test etmeye başlamadan önce, hata ayıklama için mevcut araçları ve en iyi uygulamaları anlamak önemlidir. Etkili testler, sunucunuzun beklendiği gibi davranmasını sağlar ve sorunları hızlı bir şekilde tanımlayıp çözmenize yardımcı olur. Aşağıdaki bölüm, MCP uygulamanızı doğrulamak için önerilen yaklaşımları özetlemektedir.

## Genel Bakış

Bu ders, doğru test etme yaklaşımını seçme ve en etkili test aracını nasıl kullanacağınızı kapsar.

## Öğrenme Hedefleri

Bu dersin sonunda, şunları yapabileceksiniz:

- Test için çeşitli yaklaşımları tanımlayın.
- Kodunuzu etkili bir şekilde test etmek için farklı araçları kullanın.

## MCP Sunucularını Test Etme

MCP, sunucularınızı test etmenize ve hata ayıklamanıza yardımcı olacak araçlar sağlar:

- **MCP Inspector**: Hem CLI aracı hem de görsel araç olarak çalıştırılabilen bir komut satırı aracı.
- **Manuel test**: curl gibi bir araç kullanarak web istekleri yapabilirsiniz, ancak HTTP çalıştırabilen herhangi bir araç işe yarar.
- **Birim testleri**: Sunucu ve istemci özelliklerini test etmek için tercih ettiğiniz test çerçevesini kullanabilirsiniz.

### MCP Inspector Kullanımı

Bu aracın kullanımını önceki derslerde açıklamıştık, ancak şimdi biraz daha yüksek seviyede konuşalım. Node.js ile oluşturulmuş bir araçtır ve `npx` çalıştırılabilir dosyasını çağırarak kullanabilirsiniz; bu, aracı geçici olarak indirip yükleyecek ve isteğinizi çalıştırdıktan sonra kendini temizleyecektir.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) size yardımcı olur:

- **Sunucu Yeteneklerini Keşfetme**: Mevcut kaynakları, araçları ve istemleri otomatik olarak algılayın
- **Araç Çalıştırma Testi**: Farklı parametreleri deneyin ve yanıtları gerçek zamanlı olarak görün
- **Sunucu Metadata Görüntüleme**: Sunucu bilgilerini, şemalarını ve yapılandırmalarını inceleyin

Aracın tipik bir çalıştırılması şu şekilde görünür:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Yukarıdaki komut, bir MCP ve onun görsel arayüzünü başlatır ve tarayıcınızda yerel bir web arayüzü açar. Kayıtlı MCP sunucularınızı, mevcut araçlarını, kaynaklarını ve istemlerini gösteren bir kontrol paneli görmeyi bekleyebilirsiniz. Arayüz, araç çalıştırmayı etkileşimli olarak test etmenizi, sunucu metadatasını incelemenizi ve gerçek zamanlı yanıtları görmenizi sağlar, MCP sunucu uygulamalarınızı doğrulamanızı ve hata ayıklamanızı kolaylaştırır.

Böyle görünebilir: ![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.tr.png)

Bu aracı CLI modunda da çalıştırabilirsiniz, bu durumda `--cli` özniteliğini ekleyin. İşte "CLI" modunda aracı çalıştırmanın ve sunucudaki tüm araçları listelemenin bir örneği:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manuel Test

Sunucu yeteneklerini test etmek için inspector aracını çalıştırmanın yanı sıra, HTTP kullanabilen bir istemci çalıştırmak da benzer bir yaklaşımdır, örneğin curl.

Curl ile MCP sunucularını doğrudan HTTP istekleri kullanarak test edebilirsiniz:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Yukarıdaki curl kullanımından gördüğünüz gibi, bir aracın adını ve parametrelerini içeren bir yük kullanarak bir POST isteği yaparsınız. Size en uygun yaklaşımı kullanın. Genel olarak CLI araçları daha hızlı kullanılır ve CI/CD ortamında faydalı olabilecek şekilde betiklenebilir.

### Birim Testleri

Araçlarınız ve kaynaklarınız için beklenen şekilde çalıştıklarından emin olmak için birim testleri oluşturun. İşte bazı örnek test kodları.

```python
import pytest

from mcp.server.fastmcp import FastMCP
from mcp.shared.memory import (
    create_connected_server_and_client_session as create_session,
)

# Mark the whole module for async tests
pytestmark = pytest.mark.anyio


async def test_list_tools_cursor_parameter():
    """Test that the cursor parameter is accepted for list_tools.

    Note: FastMCP doesn't currently implement pagination, so this test
    only verifies that the cursor parameter is accepted by the client.
    """

 server = FastMCP("test")

    # Create a couple of test tools
    @server.tool(name="test_tool_1")
    async def test_tool_1() -> str:
        """First test tool"""
        return "Result 1"

    @server.tool(name="test_tool_2")
    async def test_tool_2() -> str:
        """Second test tool"""
        return "Result 2"

    async with create_session(server._mcp_server) as client_session:
        # Test without cursor parameter (omitted)
        result1 = await client_session.list_tools()
        assert len(result1.tools) == 2

        # Test with cursor=None
        result2 = await client_session.list_tools(cursor=None)
        assert len(result2.tools) == 2

        # Test with cursor as string
        result3 = await client_session.list_tools(cursor="some_cursor_value")
        assert len(result3.tools) == 2

        # Test with empty string cursor
        result4 = await client_session.list_tools(cursor="")
        assert len(result4.tools) == 2
    
```

Önceki kod şunları yapar:

- pytest çerçevesini kullanır, bu da testleri fonksiyonlar olarak oluşturmanıza ve assert ifadelerini kullanmanıza olanak tanır.
- İki farklı araçla bir MCP Sunucusu oluşturur.
- Belirli koşulların yerine getirildiğini kontrol etmek için `assert` ifadesini kullanır.

[Tam dosyaya buradan bakabilirsiniz](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Yukarıdaki dosya sayesinde, kendi sunucunuzu test ederek yeteneklerin doğru şekilde oluşturulmasını sağlayabilirsiniz.

Tüm büyük SDK'lar benzer test bölümlerine sahiptir, böylece seçtiğiniz çalışma zamanına uyarlayabilirsiniz.

## Örnekler

- [Java Hesap Makinesi](../samples/java/calculator/README.md)
- [.Net Hesap Makinesi](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Hesap Makinesi](../samples/javascript/README.md)
- [TypeScript Hesap Makinesi](../samples/typescript/README.md)
- [Python Hesap Makinesi](../../../../03-GettingStarted/samples/python)

## Ek Kaynaklar

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Sırada Ne Var

- Sonraki: [Dağıtım](/03-GettingStarted/08-deployment/README.md)

**Feragatname**: 
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluğu sağlamak için çaba sarf etsek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayın. Belgenin orijinal dili, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlaşılmalardan veya yanlış yorumlamalardan sorumlu değiliz.