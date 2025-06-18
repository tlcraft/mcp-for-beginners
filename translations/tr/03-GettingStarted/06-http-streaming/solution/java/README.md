<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:46:49+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "tr"
}
-->
# Calculator HTTP Streaming Demo

Bu proje, Spring Boot WebFlux ile Server-Sent Events (SSE) kullanarak HTTP streaming’i gösterir. İki uygulamadan oluşur:

- **Calculator Server**: Hesaplamalar yapan ve sonuçları SSE ile yayınlayan reaktif bir web servisi
- **Calculator Client**: Streaming uç noktasını tüketen bir istemci uygulaması

## Gereksinimler

- Java 17 veya üzeri
- Maven 3.6 veya üzeri

## Proje Yapısı

```
java/
├── calculator-server/     # Spring Boot server with SSE endpoint
│   ├── src/main/java/com/example/calculatorserver/
│   │   ├── CalculatorServerApplication.java
│   │   └── CalculatorController.java
│   └── pom.xml
├── calculator-client/     # Spring Boot client application
│   ├── src/main/java/com/example/calculatorclient/
│   │   └── CalculatorClientApplication.java
│   └── pom.xml
└── README.md
```

## Nasıl Çalışır

1. **Calculator Server**, `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5` yolunu açar
   - Streaming yanıtını tüketir
   - Her etkinliği konsola yazdırır

## Uygulamaların Çalıştırılması

### Seçenek 1: Maven ile (Önerilen)

#### 1. Calculator Server’ı Başlatın

Bir terminal açın ve server dizinine gidin:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Sunucu `http://localhost:8080` adresinde çalışmaya başlayacak

Aşağıdaki gibi bir çıktı görmelisiniz:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Calculator Client’ı Çalıştırın

**Yeni bir terminal** açın ve client dizinine gidin:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

İstemci sunucuya bağlanacak, hesaplamayı yapacak ve streaming sonuçlarını gösterecek.

### Seçenek 2: Java’yı doğrudan kullanmak

#### 1. Server’ı derleyip çalıştırın:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Client’ı derleyip çalıştırın:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Sunucuyu Manuel Test Etme

Sunucuyu web tarayıcısı veya curl ile de test edebilirsiniz:

### Web tarayıcısı kullanarak:
Şurayı ziyaret edin: `http://localhost:8080/calculate?a=10&b=5&op=add`

### curl kullanarak:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Beklenen Çıktı

İstemci çalışırken aşağıdakine benzer streaming çıktısı görmelisiniz:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Desteklenen İşlemler

- `add` - Addition (a + b)
- `sub` - Subtraction (a - b)
- `mul` - Multiplication (a * b)
- `div` - Division (a / b, returns NaN if b = 0)

## API Reference

### GET /calculate

**Parameters:**
- `a` (required): First number (double)
- `b` (required): Second number (double)
- `op` (required): Operation (`add`, `sub`, `mul`, `div`)

**Response:**
- Content-Type: `text/event-stream`
- Hesaplama ilerlemesi ve sonucu içeren Server-Sent Events döner

**Örnek İstek:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Örnek Yanıt:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Sorun Giderme

### Yaygın Sorunlar

1. **Port 8080 zaten kullanımda**
   - Port 8080’i kullanan diğer uygulamaları durdurun
   - Ya da `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` içinde sunucu portunu değiştirin (arka planda çalıştırıyorsanız)

## Teknoloji Yığını

- **Spring Boot 3.3.1** - Uygulama çatısı
- **Spring WebFlux** - Reaktif web çatısı
- **Project Reactor** - Reaktif stream kütüphanesi
- **Netty** - Engellemesiz I/O sunucusu
- **Maven** - Derleme aracı
- **Java 17+** - Programlama dili

## Sonraki Adımlar

Kodu değiştirip deneyin:
- Daha fazla matematiksel işlem ekleyin
- Geçersiz işlemler için hata yönetimi ekleyin
- İstek/yanıt loglaması ekleyin
- Kimlik doğrulama uygulayın
- Birim testler ekleyin

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucunda ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.