<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-04T18:01:55+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "he"
}
-->
# צריכת שרת מההרחבה AI Toolkit עבור Visual Studio Code

כשאתה בונה סוכן AI, זה לא רק על יצירת תגובות חכמות; זה גם על מתן היכולת לסוכן שלך לפעול. כאן נכנס לתמונה Model Context Protocol (MCP). MCP מקל על סוכנים לגשת לכלים ושירותים חיצוניים בצורה עקבית. תחשוב על זה כמו לחבר את הסוכן שלך לתיבת כלים שהוא *באמת* יכול להשתמש בה.

נניח שאתה מחבר סוכן לשרת MCP של מחשבון. פתאום, הסוכן שלך יכול לבצע פעולות מתמטיות רק על ידי קבלת פקודה כמו "כמה זה 47 כפול 89?"—בלי צורך לקודד לוגיקה או לבנות APIs מותאמים.

## סקירה כללית

השיעור הזה מסביר כיצד לחבר שרת MCP של מחשבון לסוכן באמצעות ההרחבה [AI Toolkit](https://aka.ms/AIToolkit) ב-Visual Studio Code, ומאפשר לסוכן שלך לבצע פעולות מתמטיות כמו חיבור, חיסור, כפל וחילוק בשפה טבעית.

AI Toolkit היא הרחבה עוצמתית ל-Visual Studio Code שמפשטת את פיתוח הסוכנים. מהנדסי AI יכולים בקלות לבנות יישומי AI על ידי פיתוח ובדיקת מודלים גנרטיביים—מקומית או בענן. ההרחבה תומכת ברוב המודלים הגנרטיביים המרכזיים הקיימים כיום.

*הערה*: AI Toolkit תומכת כרגע ב-Python ו-TypeScript.

## מטרות הלמידה

בסיום השיעור תוכל:

- לצרוך שרת MCP דרך AI Toolkit.
- להגדיר תצורת סוכן שתאפשר לו לגלות ולהשתמש בכלים שמספק שרת MCP.
- להשתמש בכלי MCP דרך שפה טבעית.

## גישה

כך ניגשים לזה ברמה גבוהה:

- צור סוכן והגדר את ה-system prompt שלו.
- צור שרת MCP עם כלי מחשבון.
- חבר את Agent Builder לשרת MCP.
- בדוק את קריאת הכלים של הסוכן דרך שפה טבעית.

מעולה, עכשיו כשאנחנו מבינים את הזרימה, בוא נגדיר סוכן AI שישתמש בכלים חיצוניים דרך MCP, כדי לשפר את היכולות שלו!

## דרישות מוקדמות

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit עבור Visual Studio Code](https://aka.ms/AIToolkit)

## תרגיל: צריכת שרת

בתרגיל זה תבנה, תריץ ותשפר סוכן AI עם כלים משרת MCP בתוך Visual Studio Code באמצעות AI Toolkit.

### -0- שלב מקדים, הוסף את מודל OpenAI GPT-4o ל-My Models

התרגיל משתמש במודל **GPT-4o**. יש להוסיף את המודל ל-**My Models** לפני יצירת הסוכן.

![צילום מסך של ממשק בחירת מודל בהרחבת AI Toolkit ב-Visual Studio Code. הכותרת קוראת "מצא את המודל המתאים לפתרון ה-AI שלך" עם כותרת משנה המעודדת לגלות, לבדוק ולפרוס מודלים. מתחת, תחת “Popular Models,” מוצגות שש כרטיסיות מודל: DeepSeek-R1 (מתארח ב-GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - קטן, מהיר), ו-DeepSeek-R1 (מתארח ב-Ollama). בכל כרטיס יש אפשרויות “Add” או “Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.he.png)

1. פתח את ההרחבה **AI Toolkit** מ-**Activity Bar**.
1. בקטגוריית **Catalog**, בחר **Models** כדי לפתוח את **Model Catalog**. בחירת **Models** פותחת את **Model Catalog** בכרטיסיית עורך חדשה.
1. בשורת החיפוש של **Model Catalog**, הקלד **OpenAI GPT-4o**.
1. לחץ על **+ Add** כדי להוסיף את המודל לרשימת **My Models** שלך. ודא שבחרת במודל שמאוחסן ב-**GitHub**.
1. ב-**Activity Bar**, ודא שמודל **OpenAI GPT-4o** מופיע ברשימה.

### -1- צור סוכן

ה-**Agent (Prompt) Builder** מאפשר לך ליצור ולהתאים אישית סוכני AI משלך. בחלק זה, תיצור סוכן חדש ותשייך לו מודל שיניע את השיחה.

![צילום מסך של ממשק "Calculator Agent" ב-AI Toolkit עבור Visual Studio Code. בפאנל השמאלי, המודל שנבחר הוא "OpenAI GPT-4o (via GitHub)." ה-system prompt אומר "אתה פרופסור באוניברסיטה שמלמד מתמטיקה," וה-prompt של המשתמש אומר "הסבר לי את משוואת פורייה במונחים פשוטים." אפשרויות נוספות כוללות כפתורים להוספת כלים, הפעלת MCP Server, ובחירת פלט מובנה. כפתור כחול "Run" בתחתית. בפאנל הימני, תחת "Get Started with Examples," מופיעים שלושה סוכנים לדוגמה: Web Developer (עם MCP Server, Second-Grade Simplifier, ו-Dream Interpreter, כל אחד עם תיאור קצר של תפקידו).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.he.png)

1. פתח את ההרחבה **AI Toolkit** מ-**Activity Bar**.
1. בקטגוריית **Tools**, בחר **Agent (Prompt) Builder**. בחירה זו פותחת את **Agent (Prompt) Builder** בכרטיסיית עורך חדשה.
1. לחץ על כפתור **+ New Agent**. ההרחבה תפעיל אשף הגדרה דרך **Command Palette**.
1. הזן את השם **Calculator Agent** ולחץ **Enter**.
1. ב-**Agent (Prompt) Builder**, בשדה **Model**, בחר את המודל **OpenAI GPT-4o (via GitHub)**.

### -2- צור system prompt לסוכן

כעת כשיש לך את מסגרת הסוכן, הגיע הזמן להגדיר את האישיות והמטרה שלו. בחלק זה, תשתמש ביכולת **Generate system prompt** כדי לתאר את ההתנהגות הרצויה של הסוכן—במקרה זה, סוכן מחשבון—ותאפשר למודל לכתוב עבורך את ה-system prompt.

![צילום מסך של ממשק "Calculator Agent" ב-AI Toolkit עם חלון מודאלי פתוח שכותרתו "Generate a prompt." החלון מסביר שניתן ליצור תבנית prompt על ידי שיתוף פרטים בסיסיים וכולל תיבת טקסט עם דוגמת system prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." מתחת לתיבת הטקסט יש כפתורים "Close" ו-"Generate". ברקע, חלק מהגדרות הסוכן נראות, כולל המודל שנבחר "OpenAI GPT-4o (via GitHub)" ושדות ל-system ו-user prompts.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.he.png)

1. בקטגוריית **Prompts**, לחץ על כפתור **Generate system prompt**. כפתור זה פותח את בונה ה-prompt שמשתמש ב-AI ליצירת system prompt לסוכן.
1. בחלון **Generate a prompt**, הזן את הטקסט הבא: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. לחץ על כפתור **Generate**. תופיע הודעה בפינה הימנית התחתונה המאשרת שה-system prompt נוצר. לאחר סיום התהליך, ה-prompt יופיע בשדה **System prompt** ב-**Agent (Prompt) Builder**.
1. סקור את ה-**System prompt** וערוך במידת הצורך.

### -3- צור שרת MCP

כעת כשהגדרת את ה-system prompt של הסוכן—המנחה את התנהגותו ותגובותיו—הגיע הזמן לצייד את הסוכן ביכולות מעשיות. בחלק זה, תיצור שרת MCP של מחשבון עם כלים לביצוע חיבור, חיסור, כפל וחילוק. שרת זה יאפשר לסוכן לבצע פעולות מתמטיות בזמן אמת בתגובה לפקודות בשפה טבעית.

!["צילום מסך של החלק התחתון בממשק Calculator Agent ב-AI Toolkit עבור Visual Studio Code. מוצגים תפריטים נפתחים ל-“Tools” ו-“Structure output,” יחד עם תפריט נפתח לבחירת פורמט פלט שנבחר כ-“text.” מימין יש כפתור "+ MCP Server" להוספת שרת Model Context Protocol. מעל אזור הכלים יש אייקון תמונה כמקום שמור.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.he.png)

AI Toolkit מצויד בתבניות להקלה על יצירת שרת MCP משלך. נשתמש בתבנית Python ליצירת שרת MCP של מחשבון.

*הערה*: AI Toolkit תומכת כרגע ב-Python ו-TypeScript.

1. בקטגוריית **Tools** ב-**Agent (Prompt) Builder**, לחץ על כפתור **+ MCP Server**. ההרחבה תפעיל אשף הגדרה דרך **Command Palette**.
1. בחר **+ Add Server**.
1. בחר **Create a New MCP Server**.
1. בחר בתבנית **python-weather**.
1. בחר **Default folder** לשמירת תבנית שרת MCP.
1. הזן את השם הבא לשרת: **Calculator**
1. תפתח חלון חדש של Visual Studio Code. בחר **Yes, I trust the authors**.
1. באמצעות הטרמינל (**Terminal** > **New Terminal**), צור סביבה וירטואלית: `python -m venv .venv`
1. הפעל את הסביבה הווירטואלית בטרמינל:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. התקן את התלויות בטרמינל: `pip install -e .[dev]`
1. ב-**Explorer** ב-**Activity Bar**, הרחב את תיקיית **src** ובחר ב-**server.py** לפתיחתו בעורך.
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

### -4- הרץ את הסוכן עם שרת MCP של המחשבון

כעת שלסוכן שלך יש כלים, הגיע הזמן להשתמש בהם! בחלק זה, תשלח פקודות לסוכן כדי לבדוק ולאמת האם הסוכן משתמש בכלי המתאים משרת MCP של המחשבון.

![צילום מסך של ממשק Calculator Agent ב-AI Toolkit עבור Visual Studio Code. בפאנל השמאלי, תחת “Tools,” נוסף שרת MCP בשם local-server-calculator_server, המציג ארבעה כלים זמינים: add, subtract, multiply, ו-divide. תג מציין שארבעה כלים פעילים. מתחת יש קטע "Structure output" מקופל וכפתור כחול "Run". בפאנל הימני, תחת “Model Response,” הסוכן מפעיל את הכלים multiply ו-subtract עם קלטים {"a": 3, "b": 25} ו-{"a": 75, "b": 20} בהתאמה. התגובה הסופית של הכלי מוצגת כ-75.0. כפתור "View Code" מופיע בתחתית.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.he.png)

תריץ את שרת MCP של המחשבון במכונת הפיתוח המקומית שלך דרך **Agent Builder** כלקוח MCP.

1. לחץ `F5` כדי להתחיל דיבוג של שרת MCP. **Agent (Prompt) Builder** ייפתח בכרטיסיית עורך חדשה. מצב השרת נראה בטרמינל.
1. בשדה **User prompt** של **Agent (Prompt) Builder**, הזן את הפקודה הבאה: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. לחץ על כפתור **Run** כדי ליצור את תגובת הסוכן.
1. סקור את פלט הסוכן. המודל אמור להסיק ששילמת **$55**.
1. הנה פירוט מה אמור לקרות:
    - הסוכן בוחר בכלי ה-**multiply** וה-**subtract** כדי לסייע בחישוב.
    - ערכי `a` ו-`b` מתאימים מוקצים לכלי ה-**multiply**.
    - ערכי `a` ו-`b` מתאימים מוקצים לכלי ה-**subtract**.
    - התגובה מכל כלי מוצגת ב-**Tool Response** המתאים.
    - הפלט הסופי מהמודל מוצג ב-**Model Response** הסופי.
1. שלח פקודות נוספות כדי לבדוק את הסוכן. ניתן לשנות את הפקודה הקיימת בשדה **User prompt** על ידי לחיצה ושינוי הטקסט.
1. כשתסיים לבדוק את הסוכן, תוכל לעצור את השרת דרך הטרמינל על ידי הקשת **CTRL/CMD+C** ליציאה.

## משימה

נסה להוסיף כלי נוסף לקובץ **server.py** שלך (למשל: החזרת שורש ריבועי של מספר). שלח פקודות נוספות שידרשו מהסוכן להשתמש בכלי החדש (או בכלים קיימים). ודא שאתה מאתחל את השרת כדי לטעון את הכלים החדשים.

## פתרון

[פתרון](./solution/README.md)

## נקודות מפתח

הנקודות החשובות מפרק זה הן:

- ההרחבה AI Toolkit היא לקוח מצוין שמאפשר לך לצרוך שרתי MCP וכלים שלהם.
- ניתן להוסיף כלים חדשים לשרתי MCP, להרחיב את יכולות הסוכן כדי לעמוד בדרישות משתנות.
- AI Toolkit כוללת תבניות (כגון תבניות שרת MCP ב-Python) להקל על יצירת כלים מותאמים.

## משאבים נוספים

- [תיעוד AI Toolkit](https://aka.ms/AIToolkit/doc)

## מה הלאה
- הבא: [בדיקות וניפוי שגיאות](../08-testing/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.