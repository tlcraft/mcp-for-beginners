<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:33:46+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "bg"
}
-->
# Calculator LLM Client

Java приложение, което показва как да използвате LangChain4j за връзка с MCP (Model Context Protocol) калкулатор услуга с интеграция на GitHub Models.

## Изисквания

- Java 21 или по-нова версия
- Maven 3.6+ (или използвайте включения Maven wrapper)
- GitHub акаунт с достъп до GitHub Models
- Работеща MCP калкулатор услуга на `http://localhost:8080`

## Как да получите GitHub токен

Това приложение използва GitHub Models, което изисква личен достъп токен от GitHub. Следвайте тези стъпки, за да получите своя токен:

### 1. Достъп до GitHub Models
1. Отидете на [GitHub Models](https://github.com/marketplace/models)
2. Влезте с вашия GitHub акаунт
3. Заявете достъп до GitHub Models, ако още нямате

### 2. Създаване на личен достъп токен
1. Отидете на [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. Кликнете "Generate new token" → "Generate new token (classic)"
3. Дайте описателно име на токена (например "MCP Calculator Client")
4. Задайте срока на валидност според нуждите
5. Изберете следните права:
   - `repo` (ако имате нужда от достъп до частни хранилища)
   - `user:email`
6. Кликнете "Generate token"
7. **Важно**: Копирайте токена веднага - след това няма да може да го видите отново!

### 3. Настройване на променлива на средата

#### В Windows (Command Prompt):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### В Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### В macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Настройка и инсталация

1. **Клонирайте или отидете в директорията на проекта**

2. **Инсталирайте зависимостите**:
   ```cmd
   mvnw clean install
   ```
   Или ако имате глобално инсталиран Maven:
   ```cmd
   mvn clean install
   ```

3. **Настройте променливата на средата** (вижте секцията "Как да получите GitHub токен" по-горе)

4. **Стартирайте MCP калкулатор услугата**:
   Уверете се, че MCP калкулатор услугата от глава 1 работи на `http://localhost:8080/sse`. Тя трябва да е пусната преди да стартирате клиента.

## Стартиране на приложението

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Какво прави приложението

Приложението демонстрира три основни взаимодействия с калкулатор услугата:

1. **Събиране**: Изчислява сумата на 24.5 и 17.3
2. **Квадратен корен**: Изчислява квадратния корен на 144
3. **Помощ**: Показва наличните калкулатор функции

## Очакван резултат

При успешно изпълнение ще видите изход, подобен на:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Отстраняване на проблеми

### Чести проблеми

1. **"GITHUB_TOKEN променливата на средата не е зададена"**
   - Уверете се, че сте задали `GITHUB_TOKEN` environment variable
   - Restart your terminal/command prompt after setting the variable

2. **"Connection refused to localhost:8080"**
   - Ensure the MCP calculator service is running on port 8080
   - Check if another service is using port 8080

3. **"Authentication failed"**
   - Verify your GitHub token is valid and has the correct permissions
   - Check if you have access to GitHub Models

4. **Maven build errors**
   - Ensure you're using Java 21 or higher: `java -version`
   - Try cleaning the build: `mvnw clean`

### Отстраняване на грешки

За да активирате debug логване, добавете следния JVM аргумент при стартиране:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Конфигурация

Приложението е конфигурирано да:
- Използва GitHub Models с `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Използва 60-секунден таймаут за заявки
- Активира логване на заявки и отговори за отстраняване на грешки

## Зависимости

Основни зависимости в този проект:
- **LangChain4j**: За AI интеграция и управление на инструменти
- **LangChain4j MCP**: За поддръжка на Model Context Protocol
- **LangChain4j GitHub Models**: За интеграция с GitHub Models
- **Spring Boot**: За framework на приложението и dependency injection

## Лиценз

Този проект е лицензиран под Apache License 2.0 - вижте файла [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) за подробности.

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия първоначален език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.