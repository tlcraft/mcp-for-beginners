<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:34:48+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "tr"
}
-->
# Tam MCP İstemci Örnekleri

Bu dizin, farklı programlama dillerinde tam ve çalışan MCP istemci örneklerini içerir. Her istemci, ana README.md öğreticisinde açıklanan tüm işlevselliği gösterir.

## Mevcut İstemciler

### 1. Java İstemcisi (`client_example_java.java`)
- **Taşıma**: HTTP üzerinden SSE (Server-Sent Events)
- **Hedef Sunucu**: `http://localhost:8080`
- **Özellikler**: 
  - Bağlantı kurulumu ve ping
  - Araç listesi
  - Hesap makinesi işlemleri (toplama, çıkarma, çarpma, bölme, yardım)
  - Hata yönetimi ve sonuç çıkarımı

**Çalıştırmak için:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# İstemcisi (`client_example_csharp.cs`)
- **Taşıma**: Stdio (Standart Giriş/Çıkış)
- **Hedef Sunucu**: dotnet run ile yerel .NET MCP sunucusu
- **Özellikler**:
  - Stdio taşıma ile otomatik sunucu başlatma
  - Araç ve kaynak listesi
  - Hesap makinesi işlemleri
  - JSON sonuç ayrıştırma
  - Kapsamlı hata yönetimi

**Çalıştırmak için:**
```bash
dotnet run
```

### 3. TypeScript İstemcisi (`client_example_typescript.ts`)
- **Taşıma**: Stdio (Standart Giriş/Çıkış)
- **Hedef Sunucu**: Yerel Node.js MCP sunucusu
- **Özellikler**:
  - Tam MCP protokol desteği
  - Araç, kaynak ve prompt işlemleri
  - Hesap makinesi işlemleri
  - Kaynak okuma ve prompt yürütme
  - Sağlam hata yönetimi

**Çalıştırmak için:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python İstemcisi (`client_example_python.py`)
- **Taşıma**: Stdio (Standart Giriş/Çıkış)  
- **Hedef Sunucu**: Yerel Python MCP sunucusu
- **Özellikler**:
  - Async/await deseni ile işlemler
  - Araç ve kaynak keşfi
  - Hesap makinesi işlemleri testi
  - Kaynak içerik okuma
  - Sınıf tabanlı organizasyon

**Çalıştırmak için:**
```bash
python client_example_python.py
```

## Tüm İstemcilerde Ortak Özellikler

Her istemci uygulaması şunları gösterir:

1. **Bağlantı Yönetimi**
   - MCP sunucusuna bağlantı kurulması
   - Bağlantı hatalarının yönetimi
   - Doğru temizlik ve kaynak yönetimi

2. **Sunucu Keşfi**
   - Mevcut araçların listelenmesi
   - Mevcut kaynakların listelenmesi (desteklenenlerde)
   - Mevcut promptların listelenmesi (desteklenenlerde)

3. **Araç Çağrısı**
   - Temel hesap makinesi işlemleri (toplama, çıkarma, çarpma, bölme)
   - Sunucu bilgisi için yardım komutu
   - Doğru argüman iletimi ve sonuç yönetimi

4. **Hata Yönetimi**
   - Bağlantı hataları
   - Araç yürütme hataları
   - Zarif hata yönetimi ve kullanıcı geri bildirimi

5. **Sonuç İşleme**
   - Yanıtlardan metin içeriği çıkarma
   - Okunabilirlik için çıktı biçimlendirme
   - Farklı yanıt formatlarının yönetimi

## Ön Koşullar

Bu istemcileri çalıştırmadan önce:

1. **İlgili MCP sunucusunun çalışıyor olması** (`../01-first-server/` dizininden)
2. **Seçilen dil için gerekli bağımlılıkların kurulmuş olması**
3. **Doğru ağ bağlantısının sağlanması** (HTTP tabanlı taşıma için)

## Uygulamalar Arasındaki Temel Farklar

| Dil        | Taşıma   | Sunucu Başlatma | Async Model | Önemli Kütüphaneler |
|------------|----------|-----------------|-------------|---------------------|
| Java       | SSE/HTTP | Harici          | Senkron     | WebFlux, MCP SDK    |
| C#         | Stdio    | Otomatik        | Async/Await | .NET MCP SDK        |
| TypeScript | Stdio    | Otomatik        | Async/Await | Node MCP SDK        |
| Python     | Stdio    | Otomatik        | AsyncIO     | Python MCP SDK      |

## Sonraki Adımlar

Bu istemci örneklerini inceledikten sonra:

1. **İstemcileri değiştirerek yeni özellikler veya işlemler ekleyin**
2. **Kendi sunucunuzu oluşturup bu istemcilerle test edin**
3. **Farklı taşıma yöntemleriyle deneyler yapın** (SSE vs. Stdio)
4. **MCP işlevselliğini entegre eden daha karmaşık bir uygulama geliştirin**

## Sorun Giderme

### Yaygın Sorunlar

1. **Bağlantı reddedildi**: MCP sunucusunun beklenen port/yolda çalıştığından emin olun
2. **Modül bulunamadı**: Diliniz için gerekli MCP SDK'yı yükleyin
3. **İzin reddedildi**: Stdio taşıma için dosya izinlerini kontrol edin
4. **Araç bulunamadı**: Sunucunun beklenen araçları uyguladığını doğrulayın

### Hata Ayıklama İpuçları

1. **MCP SDK'da ayrıntılı loglamayı etkinleştirin**
2. **Sunucu loglarını hata mesajları için kontrol edin**
3. **İstemci ve sunucu arasında araç isimleri ve imzalarının uyumlu olduğundan emin olun**
4. **Öncelikle MCP Inspector ile sunucu işlevselliğini doğrulayın**

## İlgili Dokümantasyon

- [Ana İstemci Öğreticisi](./README.md)
- [MCP Sunucu Örnekleri](../../../../03-GettingStarted/01-first-server)
- [LLM Entegrasyonlu MCP](../../../../03-GettingStarted/03-llm-client)
- [Resmi MCP Dokümantasyonu](https://modelcontextprotocol.io/)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.