<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:30:31+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "tr"
}
-->
# Model Context Protocol (MCP) Python Uygulaması

Bu depo, MCP standardını kullanarak iletişim kuran hem sunucu hem de istemci uygulaması oluşturmayı gösteren Model Context Protocol (MCP) için Python uygulaması içerir.

## Genel Bakış

MCP uygulaması iki ana bileşenden oluşur:

1. **MCP Server (`server.py`)** - Şunları sunan bir sunucu:
   - **Tools**: Uzaktan çağrılabilen fonksiyonlar
   - **Resources**: Erişilebilen veriler
   - **Prompts**: Dil modelleri için prompt oluşturma şablonları

2. **MCP Client (`client.py`)** - Sunucuya bağlanan ve özelliklerini kullanan bir istemci uygulaması

## Özellikler

Bu uygulama, MCP’nin birkaç temel özelliğini gösterir:

### Tools
- `completion` - Yapay zeka modellerinden metin tamamlama üretir (simüle edilmiş)
- `add` - İki sayıyı toplayan basit hesap makinesi

### Resources
- `models://` - Mevcut yapay zeka modelleri hakkında bilgi döner
- `greeting://{name}` - Verilen isim için kişiselleştirilmiş selamlama döner

### Prompts
- `review_code` - Kod incelemesi için prompt oluşturur

## Kurulum

Bu MCP uygulamasını kullanmak için gerekli paketleri yükleyin:

```powershell
pip install mcp-server mcp-client
```

## Sunucu ve İstemciyi Çalıştırma

### Sunucuyu Başlatma

Sunucuyu bir terminal penceresinde çalıştırın:

```powershell
python server.py
```

Sunucu ayrıca MCP CLI kullanılarak geliştirme modunda çalıştırılabilir:

```powershell
mcp dev server.py
```

Ya da Claude Desktop’a kurulabilir (mevcutsa):

```powershell
mcp install server.py
```

### İstemciyi Çalıştırma

İstemciyi başka bir terminal penceresinde çalıştırın:

```powershell
python client.py
```

Bu, sunucuya bağlanacak ve mevcut tüm özellikleri gösterecektir.

### İstemci Kullanımı

İstemci (`client.py`) MCP’nin tüm yeteneklerini gösterir:

```powershell
python client.py
```

Bu, sunucuya bağlanır ve araçlar, kaynaklar ve promptlar dahil tüm özellikleri kullanır. Çıktı şunları gösterir:

1. Hesap makinesi aracı sonucu (5 + 7 = 12)
2. "Hayatın anlamı nedir?" sorusuna tamamlama aracı yanıtı
3. Mevcut yapay zeka modellerinin listesi
4. "MCP Explorer" için kişiselleştirilmiş selamlama
5. Kod inceleme prompt şablonu

## Uygulama Detayları

Sunucu, MCP servislerini tanımlamak için yüksek seviyeli soyutlamalar sağlayan `FastMCP` API kullanılarak uygulanmıştır. İşte araçların nasıl tanımlandığına dair basitleştirilmiş bir örnek:

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers together
    
    Args:
        a: First number
        b: Second number
    
    Returns:
        The sum of the two numbers
    """
    logger.info(f"Adding {a} and {b}")
    return a + b
```

İstemci, sunucuya bağlanmak ve çağrı yapmak için MCP istemci kütüphanesini kullanır:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## Daha Fazla Bilgi

MCP hakkında daha fazla bilgi için ziyaret edin: https://modelcontextprotocol.io/

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayın. Orijinal belge, kendi ana dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucunda oluşabilecek yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.