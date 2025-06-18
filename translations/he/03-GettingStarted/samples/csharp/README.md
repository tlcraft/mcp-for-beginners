<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T06:03:00+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "he"
}
-->
# שירות מחשבון בסיסי MCP

שירות זה מספק פעולות חישוב בסיסיות דרך פרוטוקול Model Context (MCP). הוא מיועד כדוגמה פשוטה למתחילים הלומדים על יישומי MCP.

למידע נוסף, ראו [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## תכונות

שירות המחשבון הזה מציע את היכולות הבאות:

1. **פעולות חשבון בסיסיות**:
   - חיבור של שני מספרים
   - חיסור של מספר אחד מאחר
   - כפל של שני מספרים
   - חילוק של מספר אחד באחר (עם בדיקת חילוק באפס)

## שימוש ב-`stdio` Type

## תצורה

1. **הגדרת שרתי MCP**:
   - פתחו את סביבת העבודה שלכם ב-VS Code.
   - צרו קובץ `.vscode/mcp.json` בתיקיית סביבת העבודה להגדרת שרתי MCP. דוגמת תצורה:

     ```jsonc
     {
       "inputs": [
         {
           "type": "promptString",
           "id": "repository-root",
           "description": "The absolute path to the repository root"
         }
       ],
       "servers": {
         "calculator-mcp-dotnet": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
             "run",
             "--project",
             "${input:repository-root}/03-GettingStarted/samples/csharp/src/calculator.csproj"
           ]
         }
       }
     }
     ```

   - תתבקשו להזין את שורש מאגר ה-GitHub, שניתן לקבל באמצעות הפקודה `git rev-parse --show-toplevel`.

## Using the Service

The service exposes the following API endpoints through the MCP protocol:

- `add(a, b)`: Add two numbers together
- `subtract(a, b)`: Subtract the second number from the first
- `multiply(a, b)`: Multiply two numbers
- `divide(a, b)`: Divide the first number by the second (with zero check)
- isPrime(n): Check if a number is prime

## Test with Github Copilot Chat in VS Code

1. Try making a request to the service using the MCP protocol. For example, you can ask:
   - "Add 5 and 3"
   - "Subtract 10 from 4"
   - "Multiply 6 and 7"
   - "Divide 8 by 2"
   - "Does 37854 prime?"
   - "What are the 3 prime numbers before after 4242?"
2. To make sure it's using the tools add #MyCalculator to the prompt. For example:
   - "Add 5 and 3 #MyCalculator"
   - "Subtract 10 from 4 #MyCalculator


## Containerized Version

The previous soultion is great when you have the .NET SDK installed, and all the dependencies are in place. However, if you would like to share the solution or run it in a different environment, you can use the containerized version.

1. Start Docker and make sure it's running.
1. From a terminal, navigate in the folder `03-GettingStarted\samples\csharp\src` 
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` עם שם המשתמש שלכם ב-Docker Hub):
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. לאחר שהדימוי נבנה, נעלה אותו ל-Docker Hub. הריצו את הפקודה הבאה:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## שימוש בגרסה מבוססת Docker

1. בקובץ `.vscode/mcp.json` החליפו את תצורת השרת בפקודה הבאה:
   ```json
    "mcp-calc": {
      "command": "docker",
      "args": [
        "run",
        "--rm",
        "-i",
        "<YOUR-DOCKER-USERNAME>/mcp-calc"
      ],
      "envFile": "",
      "env": {}
    }
   ```
   במבט על התצורה, ניתן לראות שהפקודה היא `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, וכמו קודם תוכלו לבקש משירות המחשבון לבצע חישובים עבורכם.

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו הוא המקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי אדם. איננו אחראים לכל אי-הבנה או פרשנות שגויה הנובעים משימוש בתרגום זה.