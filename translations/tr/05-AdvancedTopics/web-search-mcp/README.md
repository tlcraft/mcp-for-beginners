<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T15:36:21+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "tr"
}
-->
# Ders: Bir Web Arama MCP Sunucusu Oluşturma

Bu bölüm, harici API'lerle entegre olan, çeşitli veri türlerini işleyen, hataları yöneten ve birden çok aracı koordine eden gerçek dünya yapay zeka ajanı oluşturmayı gösterir—üretime hazır bir formatta. Şunları göreceksiniz:

- **Kimlik doğrulama gerektiren harici API entegrasyonu**
- **Birden çok uç noktadan gelen çeşitli veri türlerinin işlenmesi**
- **Güçlü hata yönetimi ve kayıt stratejileri**
- **Tek bir sunucuda çoklu araç koordinasyonu**

Bölüm sonunda, gelişmiş yapay zeka ve LLM destekli uygulamalar için gerekli olan kalıplar ve en iyi uygulamalar hakkında pratik deneyim kazanacaksınız.

## Giriş

Bu derste, SerpAPI kullanarak gerçek zamanlı web verisiyle LLM yeteneklerini genişleten gelişmiş bir MCP sunucusu ve istemcisi nasıl oluşturulur öğreneceksiniz. Bu, webden güncel bilgilere erişebilen dinamik yapay zeka ajanları geliştirmek için kritik bir beceridir.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- Harici API'leri (örneğin SerpAPI) güvenli şekilde bir MCP sunucusuna entegre etmek
- Web, haber, ürün arama ve Soru-Cevap için birden çok aracı uygulamak
- Yapılandırılmış verileri LLM kullanımı için ayrıştırmak ve biçimlendirmek
- Hataları yönetmek ve API hız sınırlarını etkili şekilde kontrol etmek
- Hem otomatik hem de etkileşimli MCP istemcileri oluşturup test etmek

## Web Arama MCP Sunucusu

Bu bölüm, Web Arama MCP Sunucusu'nun mimarisini ve özelliklerini tanıtır. FastMCP ve SerpAPI'nin birlikte nasıl kullanıldığını görerek LLM yeteneklerinin gerçek zamanlı web verisiyle nasıl genişletildiğini inceleyeceksiniz.

### Genel Bakış

Bu uygulama, MCP'nin çeşitli, harici API tabanlı görevleri güvenli ve verimli şekilde yönetme yeteneğini gösteren dört aracı içerir:

- **general_search**: Geniş web sonuçları için
- **news_search**: Güncel haber başlıkları için
- **product_search**: E-ticaret verileri için
- **qna**: Soru-cevap parçacıkları için

### Özellikler
- **Kod Örnekleri**: Python için (ve kolayca diğer dillere genişletilebilir) dil-spesifik kod blokları içerir; açıklık için katlanabilir bölümler kullanılmıştır

<details>  
<summary>Python</summary>  

```python
# Example usage of the general_search tool
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "open source LLMs"})
            print(result)
```
</details>

İstemciyi çalıştırmadan önce, sunucunun ne yaptığını anlamak faydalıdır. [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

İşte sunucunun bir aracı nasıl tanımlayıp kaydettiğine dair kısa bir örnek:

<details>  
<summary>Python Sunucu</summary> 

```python
# server.py (excerpt)
from mcp.server import MCPServer, Tool

async def general_search(query: str):
    # ...implementation...

server = MCPServer()
server.add_tool(Tool("general_search", general_search))

if __name__ == "__main__":
    server.run()
```
</details>

- **Harici API Entegrasyonu**: API anahtarlarının ve dış isteklerin güvenli yönetimini gösterir
- **Yapılandırılmış Veri Ayrıştırma**: API yanıtlarının LLM dostu biçimlere dönüştürülmesini sağlar
- **Hata Yönetimi**: Uygun kayıt ile sağlam hata yönetimi
- **Etkileşimli İstemci**: Hem otomatik testler hem de etkileşimli mod içerir
- **Bağlam Yönetimi**: MCP Bağlamını kullanarak kayıt ve istek takibi yapar

## Ön Koşullar

Başlamadan önce ortamınızın doğru şekilde ayarlandığından emin olun. Bu, tüm bağımlılıkların yüklendiği ve API anahtarlarınızın sorunsuz geliştirme ve test için doğru yapılandırıldığı anlamına gelir.

- Python 3.8 veya üzeri
- SerpAPI API Anahtarı ([SerpAPI](https://serpapi.com/) sitesinden kaydolabilirsiniz - ücretsiz katman mevcut)

## Kurulum

Ortamınızı kurmak için aşağıdaki adımları izleyin:

1. Bağımlılıkları uv (önerilen) veya pip ile yükleyin:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Proje kökünde SerpAPI anahtarınızı içeren bir `.env` dosyası oluşturun:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Kullanım

Web Arama MCP Sunucusu, SerpAPI ile entegre olarak web, haber, ürün arama ve Soru-Cevap için araçlar sunan temel bileşendir. Gelen istekleri yönetir, API çağrılarını yapar, yanıtları ayrıştırır ve yapılandırılmış sonuçları istemciye döner.

Tam uygulamayı [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) dosyasında inceleyebilirsiniz.

### Sunucuyu Çalıştırma

MCP sunucusunu başlatmak için şu komutu kullanın:

```bash
python server.py
```

Sunucu, istemcinin doğrudan bağlanabileceği stdio tabanlı bir MCP sunucusu olarak çalışacaktır.

### İstemci Modları

İstemci (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### İstemciyi Çalıştırma

Otomatik testleri çalıştırmak için (bu işlem sunucuyu otomatik başlatır):

```bash
python client.py
```

Ya da etkileşimli modda çalıştırın:

```bash
python client.py --interactive
```

### Farklı Yöntemlerle Test Etme

İhtiyaçlarınıza ve iş akışınıza bağlı olarak sunucunun sunduğu araçları test etmek ve etkileşimde bulunmak için çeşitli yollar vardır.

#### MCP Python SDK ile Özel Test Betikleri Yazmak
Kendi test betiklerinizi MCP Python SDK kullanarak oluşturabilirsiniz:

<details>
<summary>Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def test_custom_query():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            # Call tools with your custom parameters
            result = await session.call_tool("general_search", 
                                           arguments={"query": "your custom query"})
            # Process the result
```
</details>

Burada "test betiği", MCP sunucusu için istemci olarak işlev gören özel bir Python programı anlamına gelir. Resmi bir birim testi olmaktan ziyade, bu betik sunucuya programatik olarak bağlanmanızı, istediğiniz parametrelerle araçları çağırmanızı ve sonuçları incelemenizi sağlar. Bu yaklaşım şunlar için faydalıdır:
- Araç çağrılarını prototiplemek ve denemek
- Sunucunun farklı girdilere nasıl yanıt verdiğini doğrulamak
- Tekrarlanan araç çağrılarını otomatikleştirmek
- MCP sunucusu üzerine kendi iş akışlarınızı veya entegrasyonlarınızı kurmak

Test betiklerini yeni sorguları hızlıca denemek, araç davranışlarını hata ayıklamak veya daha gelişmiş otomasyonlar için başlangıç noktası olarak kullanabilirsiniz. Aşağıda MCP Python SDK ile böyle bir betiğin nasıl oluşturulacağına dair bir örnek var:

## Araç Açıklamaları

Sunucu tarafından sağlanan aşağıdaki araçları farklı arama ve sorgu türleri için kullanabilirsiniz. Her aracın parametreleri ve örnek kullanımı aşağıda açıklanmıştır.

Bu bölüm, mevcut her aracın ve parametrelerinin detaylarını sağlar.

### general_search

Genel bir web araması yapar ve biçimlendirilmiş sonuçları döner.

**Bu aracı nasıl çağırırsınız:**

`general_search` aracını kendi betiğinizden MCP Python SDK kullanarak veya Inspector ya da etkileşimli istemci modunda çağırabilirsiniz. İşte SDK ile bir kod örneği:

<details>
<summary>Python Örneği</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_general_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "latest AI trends"})
            print(result)
```
</details>

Alternatif olarak, etkileşimli modda `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Arama sorgusunu seçin

**Örnek İstek:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Bir sorguyla ilgili güncel haber makalelerini arar.

**Bu aracı nasıl çağırırsınız:**

`news_search` aracını kendi betiğinizden MCP Python SDK kullanarak veya Inspector ya da etkileşimli istemci modunda çağırabilirsiniz. İşte SDK ile bir kod örneği:

<details>
<summary>Python Örneği</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_news_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("news_search", arguments={"query": "AI policy updates"})
            print(result)
```
</details>

Alternatif olarak, etkileşimli modda `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Arama sorgusunu seçin

**Örnek İstek:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Bir sorguya uyan ürünleri arar.

**Bu aracı nasıl çağırırsınız:**

`product_search` aracını kendi betiğinizden MCP Python SDK kullanarak veya Inspector ya da etkileşimli istemci modunda çağırabilirsiniz. İşte SDK ile bir kod örneği:

<details>
<summary>Python Örneği</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_product_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("product_search", arguments={"query": "best AI gadgets 2025"})
            print(result)
```
</details>

Alternatif olarak, etkileşimli modda `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Ürün arama sorgusunu seçin

**Örnek İstek:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Arama motorlarından doğrudan sorulara yanıtlar alır.

**Bu aracı nasıl çağırırsınız:**

`qna` aracını kendi betiğinizden MCP Python SDK kullanarak veya Inspector ya da etkileşimli istemci modunda çağırabilirsiniz. İşte SDK ile bir kod örneği:

<details>
<summary>Python Örneği</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_qna():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("qna", arguments={"question": "what is artificial intelligence"})
            print(result)
```
</details>

Alternatif olarak, etkileşimli modda `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): Yanıt aranacak soruyu seçin

**Örnek İstek:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Kod Detayları

Bu bölüm, sunucu ve istemci uygulamalarına ait kod parçacıkları ve referanslar sağlar.

<details>
<summary>Python</summary>

Tam uygulama detayları için [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) dosyasına bakabilirsiniz.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Bu Dersteki İleri Konseptler

Başlamadan önce, bu bölüm boyunca karşınıza çıkacak bazı önemli ileri kavramlar var. Bunları anlamak, ilerlerken size yardımcı olacaktır, hatta yeniler için bile:

- **Çoklu Araç Koordinasyonu**: Bu, bir MCP sunucusunda web arama, haber arama, ürün arama ve Soru-Cevap gibi farklı araçların birlikte çalışması anlamına gelir. Sunucunuzun sadece tek bir görev değil, çeşitli görevleri yönetmesini sağlar.
- **API Hız Sınırı Yönetimi**: Birçok harici API (örneğin SerpAPI), belirli bir süre içinde yapabileceğiniz istek sayısını sınırlar. İyi kod, bu sınırları kontrol eder ve sınır aşımında uygulamanızın çökmesini engelleyecek şekilde davranır.
- **Yapılandırılmış Veri Ayrıştırma**: API yanıtları genellikle karmaşık ve iç içe geçmiş olur. Bu kavram, bu yanıtları LLM'ler veya diğer programlar için temiz, kolay kullanılabilir biçimlere dönüştürmeyi ifade eder.
- **Hata Kurtarma**: Bazen işler ters gider—örneğin ağ bağlantısı kopar veya API beklenmeyen yanıt verir. Hata kurtarma, kodunuzun bu sorunları yönetip kullanışlı geri bildirim vermesini sağlar, çökme yerine.
- **Parametre Doğrulama**: Bu, araçlarınıza gelen tüm girdilerin doğru ve güvenli olduğunu kontrol etmekle ilgilidir. Varsayılan değerler belirlemek ve tiplerin doğru olmasını sağlamak, hataları ve karışıklıkları önlemeye yardımcı olur.

Bu bölüm, Web Arama MCP Sunucusu ile çalışırken karşılaşabileceğiniz yaygın sorunları teşhis edip çözmenize yardımcı olacaktır. Hata veya beklenmedik davranışla karşılaşırsanız, bu sorun giderme bölümü en yaygın problemlere çözümler sunar. Yardım aramadan önce bu ipuçlarını inceleyin—çoğu sorunu hızlıca çözer.

## Sorun Giderme

Web Arama MCP Sunucusu ile çalışırken zaman zaman sorunlar yaşayabilirsiniz—bu, harici API'lerle ve yeni araçlarla geliştirme yaparken normaldir. Bu bölüm, en yaygın sorunlara pratik çözümler sunar, böylece hızlıca yolunuza devam edebilirsiniz. Bir hata ile karşılaşırsanız, buradan başlayın: aşağıdaki ipuçları çoğu kullanıcının karşılaştığı sorunları ele alır ve genellikle ekstra yardıma gerek kalmadan problemi çözer.

### Yaygın Sorunlar

Aşağıda kullanıcıların en sık karşılaştığı sorunlar, açıklamaları ve çözüm adımları yer almaktadır:

1. **.env dosyasında SERPAPI_KEY eksikliği**
   - Eğer `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env` hatası görüyorsanız, `.env` dosyasını oluşturun ve SerpAPI anahtarınızı ekleyin. Anahtarınız doğruysa ama hata devam ediyorsa, ücretsiz katman kotanızın dolup dolmadığını kontrol edin.

### Hata Ayıklama Modu

Varsayılan olarak, uygulama yalnızca önemli bilgileri kaydeder. Daha fazla detay görmek isterseniz (örneğin karmaşık sorunları teşhis etmek için), DEBUG modunu etkinleştirebilirsiniz. Bu mod, uygulamanın attığı her adım hakkında çok daha fazla bilgi gösterir.

**Örnek: Normal Çıktı**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Örnek: DEBUG Çıktısı**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

DEBUG modunun HTTP istekleri, yanıtları ve diğer iç detaylar hakkında ekstra satırlar içerdiğine dikkat edin. Bu, sorun giderme için çok faydalı olabilir.

DEBUG modunu etkinleştirmek için `client.py` or `server.py` dosyasının en üstünde kayıt seviyesini DEBUG olarak ayarlayın:

<details>
<summary>Python</summary>

```python
# At the top of your client.py or server.py
import logging
logging.basicConfig(
    level=logging.DEBUG,  # Change from INFO to DEBUG
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s"
)
```
</details>

---

## Sırada Ne Var

- [5.10 Gerçek Zamanlı Akış](../mcp-realtimestreaming/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilindeki haliyle yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.