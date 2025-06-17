<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-17T16:50:39+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "uk"
}
-->
# Calculator LLM Client

Java-додаток, який демонструє, як використовувати LangChain4j для підключення до сервісу калькулятора MCP (Model Context Protocol) з інтеграцією GitHub Models.

## Вимоги

- Java 21 або новіша версія
- Maven 3.6+ (або використовуйте вбудований Maven wrapper)
- Обліковий запис GitHub з доступом до GitHub Models
- Запущений сервіс калькулятора MCP на `http://localhost:8080`

## Отримання GitHub Token

Цей додаток використовує GitHub Models, що вимагає персональний токен доступу GitHub. Виконайте наступні кроки, щоб отримати токен:

### 1. Доступ до GitHub Models
1. Перейдіть на [GitHub Models](https://github.com/marketplace/models)
2. Увійдіть у свій обліковий запис GitHub
3. Запросіть доступ до GitHub Models, якщо ще не зробили цього

### 2. Створення персонального токена доступу
1. Перейдіть у [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. Натисніть "Generate new token" → "Generate new token (classic)"
3. Дайте токену описову назву (наприклад, "MCP Calculator Client")
4. Встановіть термін дії за потребою
5. Виберіть наступні області доступу:
   - `repo` (якщо потрібен доступ до приватних репозиторіїв)
   - `user:email`
6. Натисніть "Generate token"
7. **Важливо**: Скопіюйте токен одразу – після цього ви не зможете його побачити знову!

### 3. Встановлення змінної середовища

#### У Windows (Command Prompt):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### У Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### У macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Налаштування та встановлення

1. **Клонуйте або перейдіть до каталогу проекту**

2. **Встановіть залежності**:
   ```cmd
   mvnw clean install
   ```
   Або, якщо Maven встановлено глобально:
   ```cmd
   mvn clean install
   ```

3. **Встановіть змінну середовища** (див. розділ "Отримання GitHub Token" вище)

4. **Запустіть сервіс MCP Calculator**:
   Переконайтеся, що сервіс MCP калькулятора з першої глави працює за адресою `http://localhost:8080/sse`. Він має бути запущений до старту клієнта.

## Запуск додатку

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Що робить додаток

Додаток демонструє три основні взаємодії з сервісом калькулятора:

1. **Додавання**: Обчислює суму 24.5 та 17.3
2. **Квадратний корінь**: Обчислює квадратний корінь з 144
3. **Допомога**: Показує доступні функції калькулятора

## Очікуваний результат

При успішному запуску ви побачите приблизно такий вивід:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Усунення неполадок

### Поширені проблеми

1. **"GITHUB_TOKEN environment variable not set"**
   - Переконайтеся, що ви встановили змінну `GITHUB_TOKEN` environment variable
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

### Налагодження

Щоб увімкнути детальне логування, додайте наступний аргумент JVM при запуску:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Конфігурація

Додаток налаштований на:
- Використання GitHub Models з `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Таймаут запитів 60 секунд
- Увімкнення логування запитів/відповідей для налагодження

## Залежності

Основні залежності цього проєкту:
- **LangChain4j**: для інтеграції ШІ та керування інструментами
- **LangChain4j MCP**: для підтримки Model Context Protocol
- **LangChain4j GitHub Models**: для інтеграції GitHub Models
- **Spring Boot**: для фреймворку додатку та впровадження залежностей

## Ліцензія

Цей проєкт ліцензовано за Apache License 2.0 – дивіться файл [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) для деталей.

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоч ми й прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння чи неправильні тлумачення, що виникли внаслідок використання цього перекладу.