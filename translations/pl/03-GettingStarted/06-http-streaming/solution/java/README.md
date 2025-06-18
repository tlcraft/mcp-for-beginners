<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:46:36+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "pl"
}
-->
# Calculator HTTP Streaming Demo

Ten projekt demonstruje streaming HTTP za pomocą Server-Sent Events (SSE) w Spring Boot WebFlux. Składa się z dwóch aplikacji:

- **Calculator Server**: reaktywny serwis webowy wykonujący obliczenia i przesyłający wyniki strumieniowo za pomocą SSE  
- **Calculator Client**: aplikacja kliencka konsumująca endpoint streamingowy

## Wymagania wstępne

- Java 17 lub nowsza  
- Maven 3.6 lub nowszy

## Struktura projektu

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

## Jak to działa

1. **Calculator Server** udostępnia endpoint `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`  
   - Konsumuje odpowiedź strumieniową  
   - Wypisuje każde zdarzenie na konsolę

## Uruchamianie aplikacji

### Opcja 1: Użycie Mavena (zalecane)

#### 1. Uruchom Calculator Server

Otwórz terminal i przejdź do katalogu serwera:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Serwer uruchomi się pod adresem `http://localhost:8080`

Powinieneś zobaczyć wyjście podobne do:  
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Uruchom Calculator Client

Otwórz **nowy terminal** i przejdź do katalogu klienta:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Klient połączy się z serwerem, wykona obliczenie i wyświetli wyniki strumieniowe.

### Opcja 2: Uruchomienie bezpośrednio z Javy

#### 1. Skompiluj i uruchom serwer:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Skompiluj i uruchom klienta:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Testowanie serwera ręcznie

Możesz także przetestować serwer za pomocą przeglądarki lub curl:

### Za pomocą przeglądarki:  
Odwiedź: `http://localhost:8080/calculate?a=10&b=5&op=add`

### Za pomocą curl:  
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Oczekiwane wyjście

Podczas uruchamiania klienta powinieneś zobaczyć strumieniowe wyjście podobne do:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Obsługiwane operacje

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
- Zwraca Server-Sent Events z postępem obliczeń i wynikiem

**Przykładowe zapytanie:**  
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Przykładowa odpowiedź:**  
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Rozwiązywanie problemów

### Najczęstsze problemy

1. **Port 8080 jest już zajęty**  
   - Zamknij inne aplikacje korzystające z portu 8080  
   - Lub zmień port serwera w `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop`, jeśli działa w tle

## Stos technologiczny

- **Spring Boot 3.3.1** - framework aplikacji  
- **Spring WebFlux** - reaktywny framework webowy  
- **Project Reactor** - biblioteka do reaktywnych strumieni  
- **Netty** - serwer non-blocking I/O  
- **Maven** - narzędzie do budowania  
- **Java 17+** - język programowania

## Kolejne kroki

Spróbuj zmodyfikować kod, aby:  
- Dodać więcej operacji matematycznych  
- Zaimplementować obsługę błędów dla nieprawidłowych operacji  
- Dodać logowanie zapytań i odpowiedzi  
- Wprowadzić uwierzytelnianie  
- Dodać testy jednostkowe

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony przy użyciu usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było jak najdokładniejsze, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub niedokładności. Oryginalny dokument w języku źródłowym powinien być uznawany za wiarygodne źródło. W przypadku informacji o krytycznym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z użycia tego tłumaczenia.