<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:44:09+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "he"
}
-->
# צריכת שרת מההרחבה AI Toolkit עבור Visual Studio Code

כשאתה בונה סוכן AI, זה לא רק על יצירת תגובות חכמות; זה גם על מתן היכולת לסוכן שלך לפעול. כאן נכנס Model Context Protocol (MCP). MCP מקל על סוכנים לגשת לכלים ושירותים חיצוניים בצורה עקבית. תחשוב על זה כמו לחבר את הסוכן שלך לתיבת כלים שהוא *באמת* יכול להשתמש בה.

נניח שאתה מחבר סוכן לשרת MCP של מחשבון. פתאום, הסוכן שלך יכול לבצע פעולות מתמטיות רק על ידי קבלת בקשה כמו "כמה זה 47 כפול 89?" — בלי צורך לקודד לוגיקה או לבנות APIs מותאמים.

## סקירה כללית

השיעור הזה מסביר כיצד לחבר שרת MCP של מחשבון לסוכן באמצעות ההרחבה [AI Toolkit](https://aka.ms/AIToolkit) ב-Visual Studio Code, ומאפשר לסוכן שלך לבצע פעולות מתמטיות כמו חיבור, חיסור, כפל וחילוק באמצעות שפה טבעית.

AI Toolkit היא הרחבה חזקה ל-Visual Studio Code שמפשטת פיתוח סוכני AI. מהנדסי AI יכולים בקלות לבנות אפליקציות AI על ידי פיתוח ובדיקת מודלים גנרטיביים — באופן מקומי או בענן. ההרחבה תומכת ברוב המודלים הגנרטיביים המרכזיים הקיימים כיום.

*הערה*: AI Toolkit תומכת כרגע ב-Python וב-TypeScript.

## מטרות הלמידה

בסוף השיעור תוכל:

- לצרוך שרת MCP דרך AI Toolkit.
- להגדיר תצורת סוכן שתאפשר לו לגלות ולהשתמש בכלים שמספק שרת ה-MCP.
- להשתמש בכלי MCP באמצעות שפה טבעית.

## גישה

כך ניגשים לזה ברמה גבוהה:

- צור סוכן והגדר את הפקודה המערכתית שלו.
- צור שרת MCP עם כלי מחשבון.
- חבר את Agent Builder לשרת MCP.
- בדוק את קריאת הכלים של הסוכן באמצעות שפה טבעית.

מצוין, עכשיו כשאנחנו מבינים את הזרימה, נגדיר סוכן AI שינצל כלים חיצוניים דרך MCP, וישפר את היכולות שלו!

## דרישות מוקדמות

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit עבור Visual Studio Code](https://aka.ms/AIToolkit)

## תרגיל: צריכת שרת

בתרגיל הזה תבנה, תריץ ותשפר סוכן AI עם כלים משרת MCP בתוך Visual Studio Code באמצעות AI Toolkit.

### -0- שלב מקדים, הוסף את מודל OpenAI GPT-4o ל-My Models

התרגיל משתמש במודל **GPT-4o**. יש להוסיף את המודל ל-**My Models** לפני יצירת הסוכן.

![צילום מסך של ממשק בחירת מודל בהרחבת AI Toolkit ב-Visual Studio Code. הכותרת קוראת "Find the right model for your AI Solution" עם כותרת משנה המעודדת לגלות, לבדוק ולפרוס מודלים. מתחת, תחת "Popular Models," מוצגים שישה כרטיסי מודלים: DeepSeek-R1 (מארח GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - קטן, מהיר), ו-DeepSeek-R1 (מארח Ollama). בכל כרטיס יש אפשרויות "Add" ו-"Try in Playground".](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.he.png)

1. פתח את ההרחבה **AI Toolkit** מ-**Activity Bar**.
1. בקטגוריית **Catalog**, בחר **Models** כדי לפתוח את **Model Catalog**. בחירת **Models** פותחת את **Model Catalog** בלשונית עורך חדשה.
1. בשורת החיפוש של **Model Catalog**, הזן **OpenAI GPT-4o**.
1. לחץ על **+ Add** כדי להוסיף את המודל לרשימת **My Models** שלך. ודא שבחרת במודל שמאוחסן ב-GitHub.
1. ב-**Activity Bar**, ודא שמודל **OpenAI GPT-4o** מופיע ברשימה.

### -1- צור סוכן

ה-**Agent (Prompt) Builder** מאפשר לך ליצור ולהתאים אישית סוכני AI משלך. בסעיף זה תיצור סוכן חדש ותשייך לו מודל שיניע את השיחה.

![צילום מסך של ממשק "Calculator Agent" ב-AI Toolkit עבור Visual Studio Code. בפאנל השמאלי, המודל שנבחר הוא "OpenAI GPT-4o (via GitHub)". פקודת מערכת קוראת "You are a professor in university teaching math," ופקודת משתמש אומרת "Explain to me the Fourier equation in simple terms." אפשרויות נוספות כוללות כפתורים להוספת כלים, הפעלת MCP Server ובחירת פלט מובנה. כפתור "Run" כחול בתחתית. בפאנל הימני, תחת "Get Started with Examples," מופיעים שלושה סוכנים לדוגמה: Web Developer (עם MCP Server, Second-Grade Simplifier, ו-Dream Interpreter, כל אחד עם תיאור קצר של תפקידו).](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.he.png)

1. פתח את ההרחבה **AI Toolkit** מ-**Activity Bar**.
1. בקטגוריית **Tools**, בחר **Agent (Prompt) Builder**. בחירת **Agent (Prompt) Builder** פותחת את הכלי בלשונית עורך חדשה.
1. לחץ על כפתור **+ New Agent**. ההרחבה תפעיל אשף הגדרה דרך **Command Palette**.
1. הזן את השם **Calculator Agent** ולחץ **Enter**.
1. ב-**Agent (Prompt) Builder**, בשדה **Model**, בחר את המודל **OpenAI GPT-4o (via GitHub)**.

### -2- צור פקודת מערכת לסוכן

לאחר שסוכן הוגדר, הגיע הזמן להגדיר את האישיות והמטרה שלו. בסעיף זה תשתמש בתכונת **Generate system prompt** כדי לתאר את ההתנהגות הרצויה של הסוכן — במקרה זה, סוכן מחשבון — ותאפשר למודל לכתוב את פקודת המערכת עבורך.

![צילום מסך של ממשק "Calculator Agent" ב-AI Toolkit ל-Visual Studio Code עם חלון מודאלי פתוח שכותרתו "Generate a prompt." החלון מסביר שניתן ליצור תבנית פקודה על ידי שיתוף פרטים בסיסיים וכולל תיבת טקסט עם דוגמת פקודת מערכת: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." מתחת לתיבת הטקסט יש כפתורים "Close" ו-"Generate". ברקע, חלק מהגדרות הסוכן נראות, כולל המודל שנבחר "OpenAI GPT-4o (via GitHub)" ושדות לפקודות מערכת ומשתמש.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.he.png)

1. בקטגוריית **Prompts**, לחץ על כפתור **Generate system prompt**. כפתור זה פותח את בונה הפקודות שמנצל AI ליצירת פקודת מערכת לסוכן.
1. בחלון **Generate a prompt**, הזן את הבא: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. לחץ על כפתור **Generate**. תופיע הודעה בפינה הימנית התחתונה המאשרת שהפקודה נוצרת. לאחר סיום, הפקודה תופיע בשדה **System prompt** ב-**Agent (Prompt) Builder**.
1. סקור את **System prompt** וערוך במידת הצורך.

### -3- צור שרת MCP

כעת כשהגדרת את פקודת המערכת של הסוכן — שמכוונת את התנהגותו ותגובותיו — הגיע הזמן לצייד את הסוכן ביכולות מעשיות. בסעיף זה תיצור שרת MCP של מחשבון עם כלים לביצוע פעולות חיבור, חיסור, כפל וחילוק. שרת זה יאפשר לסוכן לבצע פעולות מתמטיות בזמן אמת בתגובה לבקשות בשפה טבעית.

![צילום מסך של החלק התחתון בממשק Calculator Agent ב-AI Toolkit עבור Visual Studio Code. מוצגים תפריטים נפתחים ל-"Tools" ו-"Structure output," לצד תפריט נפתח לבחירת פורמט פלט המוגדר ל-"text." מימין, יש כפתור "+ MCP Server" להוספת שרת Model Context Protocol. מעל אזור הכלים יש מקום למיקום תמונה.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.he.png)

AI Toolkit מצויד בתבניות להקלה על יצירת שרת MCP משלך. נשתמש בתבנית Python ליצירת שרת MCP של מחשבון.

*הערה*: AI Toolkit תומכת כרגע ב-Python וב-TypeScript.

1. בקטגוריית **Tools** ב-**Agent (Prompt) Builder**, לחץ על כפתור **+ MCP Server**. ההרחבה תפעיל אשף הגדרה דרך **Command Palette**.
1. בחר **+ Add Server**.
1. בחר **Create a New MCP Server**.
1. בחר בתבנית **python-weather**.
1. בחר **Default folder** לשמירת תבנית שרת ה-MCP.
1. הזן את השם הבא לשרת: **Calculator**
1. תיפתח חלון Visual Studio Code חדש. בחר **Yes, I trust the authors**.
1. באמצעות הטרמינל (**Terminal** > **New Terminal**), צור סביבה וירטואלית: `python -m venv .venv`
1. הפעל את הסביבה הווירטואלית בטרמינל:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. התקן את התלויות בטרמינל: `pip install -e .[dev]`
1. בתצוגת **Explorer** ב-**Activity Bar**, הרחב את תיקיית **src** ובחר ב-**server.py** כדי לפתוח את הקובץ בעורך.
1. החלף את הקוד בקובץ **server.py** בקוד הבא ושמור:

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

כעת לסוכן שלך יש כלים, הגיע הזמן להשתמש בהם! בסעיף זה תשלח פקודות לסוכן כדי לבדוק ולאמת האם הסוכן משתמש בכלי המתאים משרת MCP של מחשבון.

![צילום מסך של ממשק Calculator Agent ב-AI Toolkit עבור Visual Studio Code. בפאנל השמאלי, תחת "Tools," נוסף שרת MCP בשם local-server-calculator_server, המציג ארבעה כלים זמינים: add, subtract, multiply, ו-divide. תג מציג שארבעה כלים פעילים. מתחת יש אזור "Structure output" מקופל וכפתור כחול "Run". בפאנל הימני, תחת "Model Response," הסוכן מפעיל את הכלים multiply ו-subtract עם קלטים {"a": 3, "b": 25} ו-{"a": 75, "b": 20} בהתאמה. התגובה הסופית של הכלי מוצגת כ-75.0. יש כפתור "View Code" בתחתית.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.he.png)

תריץ את שרת MCP של המחשבון במכונת הפיתוח המקומית שלך דרך **Agent Builder** כלקוח MCP.

1. לחץ על `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` ערכי **subtract** הוקצו לכלי.
    - התגובה מכל כלי תוצג ב-**Tool Response** המתאים.
    - הפלט הסופי מהמודל יופיע ב-**Model Response** הסופי.
1. שלח פקודות נוספות כדי לבדוק את הסוכן. תוכל לשנות את הפקודה הקיימת בשדה **User prompt** על ידי לחיצה ושינוי הטקסט.
1. כשתסיים לבדוק את הסוכן, תוכל לעצור את השרת דרך **טרמינל** על ידי לחיצה על **CTRL/CMD+C** ליציאה.

## מטלה

נסה להוסיף כלי נוסף לקובץ **server.py** שלך (לדוגמה: להחזיר את שורש הריבוע של מספר). שלח פקודות נוספות שידרשו מהסוכן להשתמש בכלי החדש שלך (או בכלים קיימים). וודא להפעיל מחדש את השרת כדי לטעון את הכלים שהוספת.

## פתרון

[Solution](./solution/README.md)

## נקודות מרכזיות

הנקודות החשובות מהפרק הן:

- ההרחבה AI Toolkit היא לקוח מצוין שמאפשר לך לצרוך שרתי MCP וכלים שלהם.
- ניתן להוסיף כלים חדשים לשרתי MCP, להרחיב את יכולות הסוכן כדי לעמוד בדרישות משתנות.
- AI Toolkit כוללת תבניות (כגון תבניות שרת MCP ב-Python) שמפשטות את יצירת הכלים המותאמים אישית.

## משאבים נוספים

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## מה הלאה

הבא: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון שתרגומים אוטומטיים עלולים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפת המקור שלו צריך להיחשב כמקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי אנושי. אנו לא נישא באחריות לכל אי הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.