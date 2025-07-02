<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:17:42+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "he"
}
-->
# אינטגרציה של Model Context Protocol (MCP) עם Azure AI Foundry

מדריך זה מציג כיצד לשלב שרתי Model Context Protocol (MCP) עם סוכני Azure AI Foundry, מה שמאפשר תזמור כלים חזק ויכולות AI ארגוניות.

## מבוא

Model Context Protocol (MCP) הוא תקן פתוח שמאפשר ליישומי AI להתחבר בצורה מאובטחת למקורות נתונים וכלים חיצוניים. בשילוב עם Azure AI Foundry, MCP מאפשר לסוכנים לגשת ולפעול מול שירותים, APIs ומקורות נתונים חיצוניים שונים בצורה סטנדרטית.

שילוב זה מאחד את הגמישות של מערכת הכלים של MCP עם מסגרת הסוכנים החזקה של Azure AI Foundry, ומספק פתרונות AI ברמת ארגונים עם אפשרויות התאמה אישית נרחבות.

**Note:** אם ברצונך להשתמש ב-MCP בשירות Azure AI Foundry Agent, כרגע נתמכות רק האזורים הבאים: westus, westus2, uaenorth, southindia ו-switzerlandnorth

## מטרות הלמידה

בסיום מדריך זה תוכל:

- להבין את Model Context Protocol ואת היתרונות שלו
- להגדיר שרתי MCP לשימוש עם סוכני Azure AI Foundry
- ליצור ולהגדיר סוכנים עם אינטגרציית כלים של MCP
- ליישם דוגמאות מעשיות עם שרתי MCP אמיתיים
- לטפל בתגובות כלים ובציטוטים בשיחות הסוכן

## דרישות מוקדמות

לפני ההתחלה, וודא שיש לך:

- מנוי Azure עם גישה ל-AI Foundry
- Python 3.10 ומעלה
- Azure CLI מותקן ומוגדר
- הרשאות מתאימות ליצירת משאבי AI

## מהו Model Context Protocol (MCP)?

Model Context Protocol הוא דרך סטנדרטית ליישומי AI להתחבר למקורות נתונים וכלים חיצוניים. היתרונות המרכזיים כוללים:

- **אינטגרציה סטנדרטית**: ממשק אחיד בין כלים ושירותים שונים
- **אבטחה**: מנגנוני אימות והרשאה מאובטחים
- **גמישות**: תמיכה במקורות נתונים, APIs וכלים מותאמים שונים
- **הרחבה**: קלות הוספת יכולות ואינטגרציות חדשות

## הגדרת MCP עם Azure AI Foundry

### 1. הגדרת הסביבה

ראשית, הגדר את משתני הסביבה והתלויות:

```python
import os
import time
import json
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential


### 1. Initialize the AI Project Client

```python
project_client = AIProjectClient(
    endpoint="https://your-project-endpoint.services.ai.azure.com/api/projects/your-project",
    credential=DefaultAzureCredential(),
)
```

### 2. Create an Agent with MCP Tools

Configure an agent with MCP server integration:

```python
with project_client:
    agent = project_client.agents.create_agent(
        model="gpt-4.1-nano", 
        name="mcp_agent", 
        instructions="אתה עוזר מועיל. השתמש בכלים שסופקו כדי לענות על שאלות. הקפד לציין את המקורות שלך.",
        tools=[
            {
                "type": "mcp",
                "server_label": "microsoft_docs",
                "server_url": "https://learn.microsoft.com/api/mcp",
                "require_approval": "never"
            }
        ],
        tool_resources=None
    )
    print(f"סוכן נוצר, מזהה סוכן: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # מזהה לשרת MCP
    "server_url": "https://api.example.com/mcp", # נקודת הקצה של שרת MCP
    "require_approval": "never"                 # מדיניות אישור: כרגע נתמך רק "never"
}
```

## Complete Example: Using Microsoft Learn MCP Server

Here's a complete example that demonstrates creating an agent with MCP integration and processing a conversation:

```python
import time
import json
import os
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential

def create_mcp_agent_example():

    project_client = AIProjectClient(
        endpoint="https://your-endpoint.services.ai.azure.com/api/projects/your-project",
        credential=DefaultAzureCredential(),
    )

    with project_client:
        # יצירת סוכן עם כלים של MCP
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="אתה עוזר מומחה לתיעוד Microsoft. השתמש בשרת MCP של Microsoft Learn כדי לחפש מידע מדויק ועדכני. תמיד ציין את המקורות שלך.",
            tools=[
                {
                    "type": "mcp",
                    "server_label": "mslearn",
                    "server_url": "https://learn.microsoft.com/api/mcp",
                    "require_approval": "never"
                }
            ],
            tool_resources=None
        )
        print(f"סוכן נוצר, מזהה סוכן: {agent.id}")    
        
        # יצירת שרשור שיחה
        thread = project_client.agents.threads.create()
        print(f"שרשור שיחה נוצר, מזהה שרשור: {thread.id}")

        # שליחת הודעה
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="מה זה .NET MAUI? איך הוא משתווה ל-Xamarin.Forms?",
        )
        print(f"הודעה נוצרה, מזהה הודעה: {message.id}")

        # הרצת הסוכן
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # בדיקת סטטוס עד לסיום
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"סטטוס הרצה: {run.status}")

        # בדיקת שלבי ההרצה וקריאות הכלים
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"שלב הרצה: {step.id}, סטטוס: {step.status}, סוג: {step.type}")
            if step.type == "tool_calls":
                print("פרטי קריאת כלי:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # הצגת השיחה
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## פתרון בעיות נפוצות

### 1. בעיות חיבור
- ודא שניתן לגשת לכתובת ה-URL של שרת MCP
- בדוק את אישורי האימות
- ודא שיש חיבור רשת תקין

### 2. כשל בקריאות כלים
- בדוק את הפרמטרים והפורמט של קריאות הכלים
- בדוק דרישות ספציפיות לשרת
- יישם טיפול שגיאות מתאים

### 3. בעיות ביצועים
- אופטימיזציה של תדירות קריאות הכלים
- יישום מטמון במידת הצורך
- ניטור זמני תגובה של השרת

## שלבים הבאים

להעמקת האינטגרציה עם MCP:

1. **חקור שרתי MCP מותאמים אישית**: בנה שרתי MCP משלך למקורות נתונים פרטיים
2. **יישום אבטחה מתקדמת**: הוסף OAuth2 או מנגנוני אימות מותאמים
3. **ניטור וניתוח**: יישם רישום וניטור לשימוש בכלים
4. **הרחבת הפתרון**: שקול איזון עומסים וארכיטקטורות שרתי MCP מבוזרים

## משאבים נוספים

- [תיעוד Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- [דוגמאות Model Context Protocol](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [סקירת סוכני Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [מפרט MCP](https://spec.modelcontextprotocol.io/)

## תמיכה

לסיוע ושאלות נוספות:
- עיין ב-[תיעוד Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- בדוק את [משאבי קהילת MCP](https://modelcontextprotocol.io/)

## מה הלאה

- [6. תרומות מהקהילה](../../06-CommunityContributions/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו הוא המקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי אדם. אנו לא אחראים לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.