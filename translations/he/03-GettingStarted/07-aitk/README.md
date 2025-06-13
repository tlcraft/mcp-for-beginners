<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:23:46+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "he"
}
-->
# צריכת שרת מהתוסף AI Toolkit עבור Visual Studio Code

כשאתה בונה סוכן בינה מלאכותית, זה לא רק לייצר תגובות חכמות; זה גם לתת לסוכן שלך את היכולת לפעול. כאן נכנס ה-Model Context Protocol (MCP). MCP מקל על סוכנים לגשת לכלים ושירותים חיצוניים בצורה עקבית. תחשוב על זה כמו לחבר את הסוכן שלך לתיבת כלים שהוא *באמת* יכול להשתמש בה.

נניח שאתה מחבר סוכן לשרת MCP של מחשבון. פתאום, הסוכן שלך יכול לבצע פעולות מתמטיות רק על ידי קבלת פקודה כמו "כמה זה 47 כפול 89?"—בלי צורך לקודד לוגיקה או לבנות APIs מותאמים.

## סקירה כללית

השיעור הזה מסביר איך לחבר שרת MCP של מחשבון לסוכן עם התוסף [AI Toolkit](https://aka.ms/AIToolkit) ב-Visual Studio Code, ומאפשר לסוכן שלך לבצע פעולות מתמטיות כמו חיבור, חיסור, כפל וחילוק דרך שפה טבעית.

AI Toolkit הוא תוסף חזק ל-Visual Studio Code שמפשט פיתוח סוכני בינה מלאכותית. מהנדסי AI יכולים בקלות לבנות אפליקציות AI על ידי פיתוח ובדיקה של מודלים גנרטיביים—במחשב המקומי או בענן. התוסף תומך ברוב המודלים הגנרטיביים המרכזיים שקיימים היום.

*הערה*: נכון לעכשיו, AI Toolkit תומך ב-Python ו-TypeScript.

## מטרות הלמידה

בסוף השיעור תוכל:

- לצרוך שרת MCP דרך AI Toolkit.
- להגדיר תצורת סוכן שתאפשר לו לגלות ולהשתמש בכלים שמספק שרת MCP.
- להשתמש בכלי MCP דרך שפה טבעית.

## גישה

כך אנחנו צריכים לגשת לנושא ברמה גבוהה:

- ליצור סוכן ולהגדיר את ה-system prompt שלו.
- ליצור שרת MCP עם כלי מחשבון.
- לחבר את Agent Builder לשרת MCP.
- לבדוק את קריאת הכלים של הסוכן דרך שפה טבעית.

מעולה, עכשיו כשאנחנו מבינים את הזרימה, בואו נגדיר סוכן AI שינצל כלים חיצוניים דרך MCP, כדי להרחיב את היכולות שלו!

## דרישות מוקדמות

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## תרגיל: צריכת שרת

בתרגיל הזה תבנה, תפעיל ותשפר סוכן AI עם כלים משרת MCP בתוך Visual Studio Code באמצעות AI Toolkit.

### -0- שלב מקדים, הוסף את מודל OpenAI GPT-4o ל-My Models

התרגיל משתמש במודל **GPT-4o**. יש להוסיף את המודל ל**My Models** לפני יצירת הסוכן.

![צילום מסך של ממשק בחירת מודל בתוסף AI Toolkit ב-Visual Studio Code. הכותרת אומרת "מצא את המודל המתאים לפתרון ה-AI שלך" עם תת-כותרת המעודדת גילוי, בדיקה ופריסה של מודלים. מתחת, תחת "מודלים פופולריים," מוצגים שישה כרטיסי מודל: DeepSeek-R1 (מתארח ב-GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - קטן, מהיר), ו-DeepSeek-R1 (מתארח ב-Ollama). כל כרטיס כולל אפשרויות "הוסף" או "נסה ב-Playground"](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.he.png)

1. פתח את התוסף **AI Toolkit** מ**Activity Bar**.
1. בקטגוריית **Catalog**, בחר **Models** כדי לפתוח את **Model Catalog**. בחירת **Models** תפתח את **Model Catalog** בלשונית עורך חדשה.
1. בשורת החיפוש של **Model Catalog**, הזן **OpenAI GPT-4o**.
1. לחץ על **+ Add** כדי להוסיף את המודל לרשימת **My Models** שלך. ודא שבחרת במודל שמתארח ב-GitHub.
1. ב**Activity Bar**, וודא שמודל **OpenAI GPT-4o** מופיע ברשימה.

### -1- צור סוכן

ה**Agent (Prompt) Builder** מאפשר לך ליצור ולהתאים אישית סוכני AI משלך. בחלק זה, תיצור סוכן חדש ותשייך לו מודל שיניע את השיחה.

![צילום מסך של ממשק "Calculator Agent" בתוסף AI Toolkit ל-Visual Studio Code. בפאנל השמאלי, המודל שנבחר הוא "OpenAI GPT-4o (via GitHub)." ה-system prompt אומר "אתה פרופסור באוניברסיטה שמלמד מתמטיקה," ו-user prompt אומר "הסבר לי את משוואת פורייה במונחים פשוטים." אפשרויות נוספות כוללות כפתורים להוספת כלים, הפעלת MCP Server ובחירת פלט מובנה. כפתור "Run" כחול נמצא בתחתית. בפאנל הימני, תחת "Get Started with Examples," מופיעים שלושה סוכנים לדוגמה: Web Developer (עם MCP Server, Second-Grade Simplifier ו-Dream Interpreter, כל אחד עם תיאור קצר של תפקידו).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.he.png)

1. פתח את התוסף **AI Toolkit** מ**Activity Bar**.
1. בקטגוריית **Tools**, בחר **Agent (Prompt) Builder**. בחירת **Agent (Prompt) Builder** תפתח את הכלי בלשונית עורך חדשה.
1. לחץ על כפתור **+ New Agent**. התוסף יפעיל אשף הגדרות דרך **Command Palette**.
1. הזן את השם **Calculator Agent** ולחץ **Enter**.
1. ב**Agent (Prompt) Builder**, בשדה **Model**, בחר את מודל **OpenAI GPT-4o (via GitHub)**.

### -2- צור system prompt לסוכן

כעת כשיש לך שלד לסוכן, הגיע הזמן להגדיר את האישיות והמטרה שלו. בחלק זה, תשתמש ב**Generate system prompt** כדי לתאר את התנהגות הסוכן—במקרה הזה, סוכן מחשבון—ולהנחות את המודל לכתוב את ה-system prompt עבורך.

![צילום מסך של ממשק "Calculator Agent" בתוסף AI Toolkit ל-Visual Studio Code עם חלון קופץ שכותרתו "Generate a prompt." החלון מסביר שניתן ליצור תבנית prompt על ידי שיתוף פרטים בסיסיים וכולל תיבת טקסט עם דוגמת system prompt: "אתה עוזר יעיל במתמטיקה. כשניתנת בעיה הכוללת אריתמטיקה בסיסית, אתה מגיב בתוצאה הנכונה." מתחת לתיבת הטקסט יש כפתורי "Close" ו-"Generate". ברקע, חלק מתצורת הסוכן גלוי, כולל המודל שנבחר "OpenAI GPT-4o (via GitHub)" ושדות ל-system ו-user prompts.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.he.png)

1. בקטגוריית **Prompts**, לחץ על כפתור **Generate system prompt**. כפתור זה פותח את בונה ה-prompt שמשתמש ב-AI כדי ליצור system prompt לסוכן.
1. בחלון **Generate a prompt**, הזן את הטקסט הבא: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. לחץ על כפתור **Generate**. תופיע התראה בפינה הימנית התחתונה שמאשרת שה-system prompt נוצר. לאחר סיום, ה-prompt יופיע בשדה **System prompt** ב**Agent (Prompt) Builder**.
1. סקור את ה-system prompt ושנה במידת הצורך.

### -3- צור שרת MCP

כעת כשאתה מגדיר את ה-system prompt של הסוכן—המנחה את ההתנהגות והתשובות שלו—הגיע הזמן לצייד את הסוכן ביכולות מעשיות. בחלק זה, תיצור שרת MCP של מחשבון עם כלים לביצוע חיבור, חיסור, כפל וחילוק. שרת זה יאפשר לסוכן שלך לבצע פעולות מתמטיות בזמן אמת בתגובה לפקודות בשפה טבעית.

!["צילום מסך של החלק התחתון בממשק Calculator Agent בתוסף AI Toolkit ל-Visual Studio Code. מוצגים תפריטים נפתחים ל"Tools" ו-"Structure output," יחד עם תפריט בחירה שכותרתו "Choose output format" שנבחר בו "text." מימין, יש כפתור "+ MCP Server" להוספת שרת Model Context Protocol. מעל אזור הכלים יש מקום לאייקון תמונה.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.he.png)

AI Toolkit מצויד בתבניות להקלה על יצירת שרת MCP משלך. נשתמש בתבנית Python ליצירת שרת MCP למחשבון.

*הערה*: נכון לעכשיו, AI Toolkit תומך ב-Python ו-TypeScript.

1. בקטגוריית **Tools** ב**Agent (Prompt) Builder**, לחץ על כפתור **+ MCP Server**. התוסף יפעיל אשף הגדרות דרך **Command Palette**.
1. בחר **+ Add Server**.
1. בחר **Create a New MCP Server**.
1. בחר בתבנית **python-weather**.
1. בחר **Default folder** לשמירת תבנית שרת MCP.
1. הזן את השם הבא לשרת: **Calculator**
1. תפתח חלונית חדשה של Visual Studio Code. בחר **Yes, I trust the authors**.
1. דרך הטרמינל (**Terminal** > **New Terminal**), צור סביבה וירטואלית: `python -m venv .venv`
1. דרך הטרמינל, הפעל את הסביבה הווירטואלית:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. דרך הטרמינל, התקן את התלויות: `pip install -e .[dev]`
1. בתצוגת **Explorer** ב**Activity Bar**, הרחב את תיקיית **src** ובחר ב**server.py** כדי לפתוח את הקובץ בעורך.
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

### -4- הפעל את הסוכן עם שרת MCP של מחשבון

כעת שלסוכן שלך יש כלים, הגיע הזמן להשתמש בהם! בחלק זה, תשלח פקודות לסוכן כדי לבדוק ולאמת האם הסוכן משתמש בכלי המתאים משרת MCP של מחשבון.

![צילום מסך של ממשק Calculator Agent בתוסף AI Toolkit ל-Visual Studio Code. בפאנל השמאלי, תחת "Tools," נוסף שרת MCP בשם local-server-calculator_server, המציג ארבעה כלים זמינים: add, subtract, multiply, ו-divide. תווית מראה שארבעה כלים פעילים. מתחת יש סעיף "Structure output" מקופל וכפתור "Run" כחול. בפאנל הימני, תחת "Model Response," הסוכן מפעיל את הכלים multiply ו-subtract עם קלטים {"a": 3, "b": 25} ו-{"a": 75, "b": 20} בהתאמה. תגובת הכלי הסופית מוצגת כ-75.0. כפתור "View Code" מופיע בתחתית.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.he.png)

תפעיל את שרת MCP של המחשבון במכונת הפיתוח המקומית שלך דרך **Agent Builder** כלקוח MCP.

1. לחץ `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `קניתי 3 פריטים במחיר של 25$ כל אחד, ואז השתמשתי בהנחה של 20$. כמה שילמתי?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` הערכים מוקצים לכלי **subtract**.
    - התגובה מכל כלי מוצגת ב**Tool Response** המתאים.
    - הפלט הסופי מהמודל מוצג ב**Model Response** הסופי.
1. שלח פקודות נוספות כדי לבדוק את הסוכן לעומק. ניתן לשנות את הפקודה הקיימת בשדה **User prompt** על ידי לחיצה ושינוי הטקסט.
1. כשתסיים לבדוק את הסוכן, תוכל לעצור את השרת דרך הטרמינל על ידי הקשת **CTRL/CMD+C** ליציאה.

## משימה

נסה להוסיף כלי נוסף לקובץ **server.py** שלך (לדוגמה: החזרת שורש ריבועי של מספר). שלח פקודות נוספות שידרשו מהסוכן להשתמש בכלי החדש (או בכלים קיימים). ודא שאתה מפעיל מחדש את השרת כדי לטעון את הכלים החדשים.

## פתרון

[Solution](./solution/README.md)

## נקודות מפתח

הנקודות המרכזיות מפרק זה הן:

- תוסף AI Toolkit הוא לקוח מעולה שמאפשר לך לצרוך שרתי MCP והכלים שלהם.
- ניתן להוסיף כלים חדשים לשרתי MCP, להרחיב את יכולות הסוכן בהתאם לצרכים משתנים.
- AI Toolkit כולל תבניות (כגון תבניות שרת MCP ב-Python) להקל על יצירת כלים מותאמים אישית.

## משאבים נוספים

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## מה הלאה
- הבא: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו הוא המקור המוסמך. למידע קריטי מומלץ להשתמש בתרגום מקצועי של אדם. אנו לא אחראים לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.