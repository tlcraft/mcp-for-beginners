<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:08:02+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "tr"
}
-->
## Test Etme ve Hata Ayıklama

MCP sunucunuzu test etmeye başlamadan önce, kullanılabilir araçları ve hata ayıklama için en iyi uygulamaları anlamak önemlidir. Etkili test, sunucunuzun beklendiği gibi çalışmasını sağlar ve sorunları hızlıca tespit edip çözmenize yardımcı olur. Aşağıdaki bölüm, MCP uygulamanızı doğrulamak için önerilen yaklaşımları özetlemektedir.

## Genel Bakış

Bu ders, doğru test yaklaşımının nasıl seçileceğini ve en etkili test aracını ele alır.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- Test için çeşitli yaklaşımları tanımlamak.
- Kodunuzu etkili bir şekilde test etmek için farklı araçları kullanmak.

## MCP Sunucularını Test Etme

MCP, sunucularınızı test etmenize ve hata ayıklamanıza yardımcı olacak araçlar sunar:

- **MCP Inspector**: Hem CLI aracı hem de görsel araç olarak çalıştırılabilen komut satırı aracı.
- **Manuel test**: curl gibi bir araç kullanarak web istekleri gönderebilirsiniz, ancak HTTP çalıştırabilen herhangi bir araç da işe yarar.
- **Birim testi**: Tercih ettiğiniz test çerçevesini kullanarak hem sunucu hem de istemci özelliklerini test etmek mümkündür.

### MCP Inspector Kullanımı

Bu aracın kullanımını önceki derslerde anlattık ancak burada üst düzey olarak biraz bahsedelim. Node.js ile geliştirilmiş bir araçtır ve `npx` yürütülebilir dosyasını çağırarak kullanabilirsiniz. Bu dosya aracı geçici olarak indirir ve yükler, isteğiniz tamamlandığında kendini temizler.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) size şunları sağlar:

- **Sunucu Yetkinliklerini Keşfetme**: Mevcut kaynakları, araçları ve istemleri otomatik olarak tespit eder
- **Araç Çalıştırmayı Test Etme**: Farklı parametreleri deneyip yanıtları gerçek zamanlı görme
- **Sunucu Meta Verilerini Görüntüleme**: Sunucu bilgileri, şemalar ve yapılandırmaları inceleme

Aracın tipik bir çalıştırması şu şekildedir:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Yukarıdaki komut, bir MCP ve görsel arayüzünü başlatır ve tarayıcınızda yerel bir web arayüzü açar. Kayıtlı MCP sunucularınızı, mevcut araçlarını, kaynaklarını ve istemlerini gösteren bir kontrol paneli görmeyi bekleyebilirsiniz. Arayüz, araç çalıştırmayı etkileşimli olarak test etmenize, sunucu meta verilerini incelemenize ve gerçek zamanlı yanıtları görmenize olanak tanır; bu da MCP sunucu uygulamalarınızı doğrulamayı ve hata ayıklamayı kolaylaştırır.

Şöyle görünebilir: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.tr.png)

Bu aracı CLI modunda da çalıştırabilirsiniz; bu durumda `--cli` parametresini eklersiniz. İşte sunucudaki tüm araçları listeleyen "CLI" modunda aracın çalıştırılmasına örnek:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manuel Test

Sunucu yetkinliklerini test etmek için inspector aracını çalıştırmanın yanı sıra, HTTP kullanabilen bir istemciyi, örneğin curl'u çalıştırmak gibi benzer bir yaklaşım da vardır.

Curl ile MCP sunucularını doğrudan HTTP istekleri kullanarak test edebilirsiniz:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Yukarıdaki curl kullanımından görebileceğiniz gibi, araç adını ve parametrelerini içeren bir yükle aracı çağırmak için POST isteği kullanıyorsunuz. Size en uygun yaklaşımı seçin. CLI araçları genellikle daha hızlı kullanılır ve betiklenebilir olmaları CI/CD ortamlarında faydalı olabilir.

### Birim Testi

Araçlarınız ve kaynaklarınız için birim testleri oluşturarak beklendiği gibi çalıştıklarından emin olun. İşte bazı örnek test kodları.

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

Yukarıdaki kod şunları yapar:

- Fonksiyon olarak test oluşturmanıza ve assert ifadeleri kullanmanıza olanak sağlayan pytest çerçevesini kullanır.
- İki farklı araçla bir MCP Sunucusu oluşturur.
- Belirli koşulların sağlanıp sağlanmadığını kontrol etmek için `assert` ifadesini kullanır.

[Tam dosyaya buradan bakabilirsiniz](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Yukarıdaki dosyaya dayanarak, kendi sunucunuzu test ederek yeteneklerin gerektiği gibi oluşturulduğundan emin olabilirsiniz.

Tüm büyük SDK'larda benzer test bölümleri bulunur, böylece seçtiğiniz çalışma ortamına uyarlayabilirsiniz.

## Örnekler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ek Kaynaklar

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Sonraki Adım

- Sonraki: [Deployment](/03-GettingStarted/09-deployment/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.