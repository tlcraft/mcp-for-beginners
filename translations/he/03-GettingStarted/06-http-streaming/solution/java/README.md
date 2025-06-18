<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:48:20+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "he"
}
-->
# דמו של זרימת HTTP במחשבון

הפרויקט הזה מדגים זרימת HTTP באמצעות Server-Sent Events (SSE) עם Spring Boot WebFlux. הוא מורכב משתי אפליקציות:

- **Calculator Server**: שירות ריאקטיבי שמבצע חישובים ומשדר תוצאות באמצעות SSE  
- **Calculator Client**: אפליקציית לקוח שצורכת את נקודת הקצה של הזרימה

## דרישות מוקדמות

- Java 17 ומעלה  
- Maven 3.6 ומעלה  

## מבנה הפרויקט

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

## איך זה עובד

1. ה-**Calculator Server** פותח את הנתיב `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`  
   - צורך את תגובת הזרימה  
   - מדפיס כל אירוע לקונסולה  

## הפעלת האפליקציות

### אפשרות 1: שימוש ב-Maven (מומלץ)

#### 1. הפעלת ה-Calculator Server

פתח טרמינל ונווט לתיקיית השרת:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

השרת יפעל בכתובת `http://localhost:8080`

אתה אמור לראות פלט כמו:  
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. הפעלת ה-Calculator Client

פתח **טרמינל חדש** ונווט לתיקיית הלקוח:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

הלקוח יתחבר לשרת, יבצע את החישוב, ויציג את תוצאות הזרימה.

### אפשרות 2: הפעלה ישירה של Java

#### 1. קומפילציה והפעלה של השרת:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. קומפילציה והפעלה של הלקוח:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## בדיקת השרת ידנית

ניתן גם לבדוק את השרת דרך דפדפן או curl:

### שימוש בדפדפן:  
בקר בכתובת: `http://localhost:8080/calculate?a=10&b=5&op=add`

### שימוש ב-curl:  
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## פלט צפוי

בעת הרצת הלקוח, תראה פלט זרימה דומה ל:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## פעולות נתמכות

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
- מחזיר Server-Sent Events עם התקדמות החישוב והתוצאה

**בקשת דוגמה:**  
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**תגובה לדוגמה:**  
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## פתרון תקלות

### בעיות נפוצות

1. **הפורט 8080 כבר בשימוש**  
   - עצור כל אפליקציה אחרת שמשתמשת בפורט 8080  
   - או שנה את פורט השרת בקובץ `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` אם מריצים כתהליך ברקע  

## טכנולוגיות בשימוש

- **Spring Boot 3.3.1** - מסגרת יישומים  
- **Spring WebFlux** - מסגרת ריאקטיבית לרשת  
- **Project Reactor** - ספריית זרמים ריאקטיביים  
- **Netty** - שרת I/O לא חסום  
- **Maven** - כלי בנייה  
- **Java 17+** - שפת תכנות  

## צעדים הבאים

נסה לשנות את הקוד כדי:  
- להוסיף פעולות מתמטיות נוספות  
- לכלול טיפול בשגיאות לפעולות לא חוקיות  
- להוסיף רישום בקשות/תגובות  
- לממש אימות  
- להוסיף בדיקות יחידה

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). בעוד שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. יש להתייחס למסמך המקורי בשפתו המקורית כמקור הסמכותי. עבור מידע קריטי, מומלץ להיעזר בתרגום מקצועי על ידי אדם. איננו אחראים לכל אי-הבנות או פרשנויות שגויות הנובעות משימוש בתרגום זה.