<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:25:26+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "he"
}
-->
# צריכת שרת מהרחבת AI Toolkit ל-Visual Studio Code

כשאתה בונה סוכן AI, זה לא רק על יצירת תגובות חכמות; זה גם על לתת לסוכן שלך את היכולת לפעול. כאן נכנס לתמונה פרוטוקול הקשר של המודל (MCP). MCP מקל על סוכנים לגשת לכלים ושירותים חיצוניים בצורה עקבית. תחשוב על זה כמו לחבר את הסוכן שלך לארגז כלים שהוא יכול *באמת* להשתמש בו.

נניח שאתה מחבר סוכן לשרת MCP של מחשבון. פתאום, הסוכן שלך יכול לבצע פעולות מתמטיות פשוט על ידי קבלת פקודה כמו "מה זה 47 כפול 89?"—ללא צורך בקידוד לוגיקה או בניית APIs מותאמים אישית.

## סקירה כללית

שיעור זה מכסה כיצד לחבר שרת MCP של מחשבון לסוכן עם הרחבת [AI Toolkit](https://aka.ms/AIToolkit) ב-Visual Studio Code, מה שמאפשר לסוכן שלך לבצע פעולות מתמטיות כמו חיבור, חיסור, כפל וחילוק באמצעות שפה טבעית.

AI Toolkit היא הרחבה עוצמתית ל-Visual Studio Code שמייעלת את פיתוח הסוכנים. מהנדסי AI יכולים בקלות לבנות יישומי AI על ידי פיתוח ובדיקת מודלים של AI גנרטיביים—מקומיים או בענן. ההרחבה תומכת ברוב המודלים הגנרטיביים המרכזיים הקיימים כיום.

*הערה*: AI Toolkit תומך כרגע ב-Python ו-TypeScript.

## מטרות הלמידה

בסוף שיעור זה, תוכל:

- לצרוך שרת MCP דרך AI Toolkit.
- להגדיר תצורת סוכן כדי לאפשר לו לגלות ולהשתמש בכלים המסופקים על ידי שרת MCP.
- להשתמש בכלי MCP דרך שפה טבעית.

## גישה

כך אנו צריכים לגשת לזה ברמה גבוהה:

- צור סוכן והגדר את ההנחיה המערכתית שלו.
- צור שרת MCP עם כלים של מחשבון.
- חבר את ה-Agent Builder לשרת MCP.
- בדוק את זימון הכלים של הסוכן דרך שפה טבעית.

מצוין, עכשיו כשאנחנו מבינים את הזרימה, בואו נגדיר סוכן AI כדי לנצל כלים חיצוניים דרך MCP, ובכך לשפר את היכולות שלו!

## דרישות מוקדמות

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit ל-Visual Studio Code](https://aka.ms/AIToolkit)

## תרגיל: צריכת שרת

בתרגיל זה, תבנה, תריץ ותשפר סוכן AI עם כלים משרת MCP בתוך Visual Studio Code באמצעות AI Toolkit.

### -0- שלב מקדים, הוסף את מודל OpenAI GPT-4o למודלים שלי

התרגיל מנצל את מודל **GPT-4o**. יש להוסיף את המודל ל-**My Models** לפני יצירת הסוכן.

1. פתח את הרחבת **AI Toolkit** מ-**Activity Bar**.
1. בקטע **Catalog**, בחר **Models** כדי לפתוח את **Model Catalog**. בחירה ב-**Models** פותחת את **Model Catalog** בלשונית עורך חדשה.
1. בשורת החיפוש של **Model Catalog**, הכנס **OpenAI GPT-4o**.
1. לחץ על **+ Add** כדי להוסיף את המודל לרשימת **My Models** שלך. ודא שבחרת במודל שמאוחסן על ידי **GitHub**.
1. ב-**Activity Bar**, אשר שהמודל **OpenAI GPT-4o** מופיע ברשימה.

### -1- צור סוכן

**Agent (Prompt) Builder** מאפשר לך ליצור ולהתאים אישית סוכנים מופעלי AI משלך. בחלק זה, תיצור סוכן חדש ותשייך מודל כדי להפעיל את השיחה.

1. פתח את הרחבת **AI Toolkit** מ-**Activity Bar**.
1. בקטע **Tools**, בחר **Agent (Prompt) Builder**. בחירה ב-**Agent (Prompt) Builder** פותחת את **Agent (Prompt) Builder** בלשונית עורך חדשה.
1. לחץ על כפתור **+ New Builder**. ההרחבה תשיק אשף הגדרה דרך **Command Palette**.
1. הכנס את השם **Calculator Agent** ולחץ **Enter**.
1. ב-**Agent (Prompt) Builder**, עבור שדה **Model**, בחר במודל **OpenAI GPT-4o (via GitHub)**.

### -2- צור הנחיה מערכתית לסוכן

עם הסוכן שהוקם, הגיע הזמן להגדיר את האישיות והמטרה שלו. בחלק זה, תשתמש בתכונת **Generate system prompt** כדי לתאר את ההתנהגות המיועדת של הסוכן—במקרה זה, סוכן מחשבון—ותתן למודל לכתוב את ההנחיה המערכתית עבורך.

1. עבור חלק **Prompts**, לחץ על כפתור **Generate system prompt**. כפתור זה נפתח בבונה ההנחיות המשתמש ב-AI כדי ליצור הנחיה מערכתית עבור הסוכן.
1. בחלון **Generate a prompt**, הכנס את הבא: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. לחץ על כפתור **Generate**. תופיע הודעה בפינה הימנית-תחתונה המאשרת שההנחיה המערכתית נוצרה. לאחר שההנחיה נוצרה, היא תופיע בשדה **System prompt** של **Agent (Prompt) Builder**.
1. בדוק את **System prompt** וערוך במידת הצורך.

### -3- צור שרת MCP

עכשיו כשהגדרת את ההנחיה המערכתית של הסוכן שלך—המנחה את ההתנהגות והתגובות שלו—הגיע הזמן לצייד את הסוכן ביכולות מעשיות. בחלק זה, תיצור שרת MCP של מחשבון עם כלים לביצוע חישובים של חיבור, חיסור, כפל וחילוק. שרת זה יאפשר לסוכן שלך לבצע פעולות מתמטיות בזמן אמת בתגובה לפקודות בשפה טבעית.

AI Toolkit מצויד בתבניות להקלת יצירת שרת MCP משלך. נשתמש בתבנית Python ליצירת שרת MCP של מחשבון.

*הערה*: AI Toolkit תומך כרגע ב-Python ו-TypeScript.

1. בקטע **Tools** של **Agent (Prompt) Builder**, לחץ על כפתור **+ MCP Server**. ההרחבה תשיק אשף הגדרה דרך **Command Palette**.
1. בחר **+ Add Server**.
1. בחר **Create a New MCP Server**.
1. בחר **python-weather** כתבנית.
1. בחר **Default folder** לשמירת תבנית שרת MCP.
1. הכנס את השם הבא לשרת: **Calculator**
1. חלון חדש של Visual Studio Code ייפתח. בחר **Yes, I trust the authors**.
1. באמצעות הטרמינל (**Terminal** > **New Terminal**), צור סביבת עבודה וירטואלית: `python -m venv .venv`
1. באמצעות הטרמינל, הפעל את סביבת העבודה הווירטואלית:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. באמצעות הטרמינל, התקן את התלויות: `pip install -e .[dev]`
1. בתצוגת **Explorer** של **Activity Bar**, הרחב את ספריית **src** ובחר **server.py** כדי לפתוח את הקובץ בעורך.
1. החלף את הקוד בקובץ **server.py** עם הבא ושמור:

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- הרץ את הסוכן עם שרת MCP של מחשבון

עכשיו שלסוכן שלך יש כלים, הגיע הזמן להשתמש בהם! בחלק זה, תגיש פקודות לסוכן כדי לבדוק ולאמת אם הסוכן מנצל את הכלי המתאים משרת MCP של המחשבון.

תפעיל את שרת MCP של המחשבון על מכונת הפיתוח המקומית שלך דרך **Agent Builder** כלקוח MCP.

1. לחץ על `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `קניתי 3 פריטים במחיר 25$ כל אחד, ואז השתמשתי בהנחה של 20$. כמה שילמתי?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` ערכים מוקצים לכלי **subtract**.
    - התגובה מכל כלי ניתנת בתגובה לכלי המתאימה.
    - הפלט הסופי מהמודל ניתן בתגובה הסופית של **Model Response**.
1. הגש פקודות נוספות כדי לבדוק עוד את הסוכן. תוכל לשנות את הפקודה הקיימת בשדה **User prompt** על ידי לחיצה לתוך השדה והחלפת הפקודה הקיימת.
1. לאחר שסיימת לבדוק את הסוכן, תוכל להפסיק את השרת דרך **terminal** על ידי הכנסת **CTRL/CMD+C** כדי לצאת.

## משימה

נסה להוסיף רשומת כלי נוספת לקובץ **server.py** שלך (לדוגמה: החזר את השורש הריבועי של מספר). הגש פקודות נוספות שידרשו מהסוכן לנצל את הכלי החדש שלך (או כלים קיימים). ודא להפעיל מחדש את השרת כדי לטעון כלים שנוספו לאחרונה.

## פתרון

[פתרון](./solution/README.md)

## מסקנות עיקריות

המסקנות מהפרק הזה הן הבאות:

- ההרחבה AI Toolkit היא לקוח מצוין שמאפשר לך לצרוך שרתי MCP וכליהם.
- תוכל להוסיף כלים חדשים לשרתי MCP, להרחיב את יכולות הסוכן כדי לעמוד בדרישות מתפתחות.
- AI Toolkit כולל תבניות (לדוגמה, תבניות שרת MCP של Python) כדי לפשט את יצירת הכלים המותאמים אישית.

## משאבים נוספים

- [מסמכי AI Toolkit](https://aka.ms/AIToolkit/doc)

## מה הלאה

הבא: [שיעור 4 יישום מעשי](/04-PracticalImplementation/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). בעוד אנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עשויים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור הסמכותי. עבור מידע קריטי, מומלץ להשתמש בתרגום אנושי מקצועי. אנו לא נושאים באחריות לכל אי הבנות או פרשנויות שגויות הנובעות משימוש בתרגום זה.