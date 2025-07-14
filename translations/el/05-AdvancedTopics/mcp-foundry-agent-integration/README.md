<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-13T23:56:00+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "el"
}
-->
# Ενσωμάτωση Model Context Protocol (MCP) με Azure AI Foundry

Αυτός ο οδηγός δείχνει πώς να ενσωματώσετε τους διακομιστές Model Context Protocol (MCP) με τους agents του Azure AI Foundry, επιτρέποντας ισχυρή ορχήστρωση εργαλείων και δυνατότητες AI για επιχειρήσεις.

## Εισαγωγή

Το Model Context Protocol (MCP) είναι ένα ανοιχτό πρότυπο που επιτρέπει στις εφαρμογές AI να συνδέονται με ασφάλεια σε εξωτερικές πηγές δεδομένων και εργαλεία. Όταν ενσωματώνεται με το Azure AI Foundry, το MCP επιτρέπει στους agents να έχουν πρόσβαση και να αλληλεπιδρούν με διάφορες εξωτερικές υπηρεσίες, APIs και πηγές δεδομένων με έναν τυποποιημένο τρόπο.

Αυτή η ενσωμάτωση συνδυάζει την ευελιξία του οικοσυστήματος εργαλείων του MCP με το στιβαρό πλαίσιο agents του Azure AI Foundry, προσφέροντας λύσεις AI επιπέδου επιχείρησης με εκτεταμένες δυνατότητες προσαρμογής.

**Note:** Εάν θέλετε να χρησιμοποιήσετε MCP στην Υπηρεσία Agents του Azure AI Foundry, προς το παρόν υποστηρίζονται μόνο οι εξής περιοχές: westus, westus2, uaenorth, southindia και switzerlandnorth

## Στόχοι Μάθησης

Στο τέλος αυτού του οδηγού, θα μπορείτε να:

- Κατανοήσετε το Model Context Protocol και τα οφέλη του
- Ρυθμίσετε διακομιστές MCP για χρήση με agents του Azure AI Foundry
- Δημιουργήσετε και να διαμορφώσετε agents με ενσωμάτωση εργαλείων MCP
- Υλοποιήσετε πρακτικά παραδείγματα χρησιμοποιώντας πραγματικούς διακομιστές MCP
- Διαχειριστείτε τις απαντήσεις εργαλείων και τις παραπομπές σε συνομιλίες agents

## Προαπαιτούμενα

Πριν ξεκινήσετε, βεβαιωθείτε ότι έχετε:

- Συνδρομή Azure με πρόσβαση στο AI Foundry
- Python 3.10+ 
- Εγκατεστημένο και ρυθμισμένο το Azure CLI
- Κατάλληλα δικαιώματα για δημιουργία πόρων AI

## Τι είναι το Model Context Protocol (MCP);

Το Model Context Protocol είναι ένας τυποποιημένος τρόπος για εφαρμογές AI να συνδέονται με εξωτερικές πηγές δεδομένων και εργαλεία. Τα βασικά οφέλη περιλαμβάνουν:

- **Τυποποιημένη Ενσωμάτωση**: Ομοιόμορφη διεπαφή σε διάφορα εργαλεία και υπηρεσίες
- **Ασφάλεια**: Ασφαλείς μηχανισμοί πιστοποίησης και εξουσιοδότησης
- **Ευελιξία**: Υποστήριξη για διάφορες πηγές δεδομένων, APIs και προσαρμοσμένα εργαλεία
- **Επεκτασιμότητα**: Εύκολη προσθήκη νέων δυνατοτήτων και ενσωματώσεων

## Ρύθμιση MCP με Azure AI Foundry

### 1. Διαμόρφωση Περιβάλλοντος

Αρχικά, ρυθμίστε τις μεταβλητές περιβάλλοντος και τις εξαρτήσεις σας:

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
        instructions="Είσαι ένας βοηθητικός βοηθός. Χρησιμοποίησε τα διαθέσιμα εργαλεία για να απαντήσεις σε ερωτήσεις. Φρόντισε να αναφέρεις τις πηγές σου.",
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
    print(f"Δημιουργήθηκε agent, agent ID: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Αναγνωριστικό για τον MCP διακομιστή
    "server_url": "https://api.example.com/mcp", # Τελικό σημείο MCP διακομιστή
    "require_approval": "never"                 # Πολιτική έγκρισης: προς το παρόν υποστηρίζεται μόνο το "never"
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
        # Δημιουργία agent με εργαλεία MCP
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Είσαι ένας βοηθητικός βοηθός που ειδικεύεται στην τεκμηρίωση της Microsoft. Χρησιμοποίησε τον MCP διακομιστή του Microsoft Learn για να αναζητήσεις ακριβείς και ενημερωμένες πληροφορίες. Πάντα να αναφέρεις τις πηγές σου.",
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
        print(f"Δημιουργήθηκε agent, agent ID: {agent.id}")    
        
        # Δημιουργία νήματος συνομιλίας
        thread = project_client.agents.threads.create()
        print(f"Δημιουργήθηκε νήμα, thread ID: {thread.id}")

        # Αποστολή μηνύματος
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Τι είναι το .NET MAUI; Πώς συγκρίνεται με το Xamarin.Forms;",
        )
        print(f"Δημιουργήθηκε μήνυμα, message ID: {message.id}")

        # Εκτέλεση του agent
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Αναμονή για ολοκλήρωση
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Κατάσταση εκτέλεσης: {run.status}")

        # Εξέταση βημάτων εκτέλεσης και κλήσεων εργαλείων
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Βήμα εκτέλεσης: {step.id}, κατάσταση: {step.status}, τύπος: {step.type}")
            if step.type == "tool_calls":
                print("Λεπτομέρειες κλήσης εργαλείου:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Εμφάνιση συνομιλίας
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()


## Αντιμετώπιση Συνηθισμένων Προβλημάτων

### 1. Προβλήματα Σύνδεσης
- Ελέγξτε αν η διεύθυνση URL του MCP διακομιστή είναι προσβάσιμη
- Επαληθεύστε τα διαπιστευτήρια πιστοποίησης
- Βεβαιωθείτε για τη δικτυακή συνδεσιμότητα

### 2. Αποτυχίες Κλήσεων Εργαλείων
- Ελέγξτε τα επιχειρήματα και τη μορφοποίηση των κλήσεων εργαλείων
- Εξετάστε τις απαιτήσεις του συγκεκριμένου διακομιστή
- Υλοποιήστε σωστή διαχείριση σφαλμάτων

### 3. Προβλήματα Απόδοσης
- Βελτιστοποιήστε τη συχνότητα κλήσεων εργαλείων
- Εφαρμόστε caching όπου είναι κατάλληλο
- Παρακολουθήστε τους χρόνους απόκρισης του διακομιστή

## Επόμενα Βήματα

Για να βελτιώσετε περαιτέρω την ενσωμάτωση MCP:

1. **Εξερευνήστε Προσαρμοσμένους MCP Διακομιστές**: Δημιουργήστε δικούς σας MCP διακομιστές για ιδιόκτητες πηγές δεδομένων
2. **Υλοποιήστε Προηγμένη Ασφάλεια**: Προσθέστε OAuth2 ή προσαρμοσμένους μηχανισμούς πιστοποίησης
3. **Παρακολούθηση και Αναλύσεις**: Υλοποιήστε καταγραφή και παρακολούθηση χρήσης εργαλείων
4. **Κλιμάκωση της Λύσης σας**: Σκεφτείτε ισορροπία φορτίου και κατανεμημένες αρχιτεκτονικές MCP διακομιστών

## Πρόσθετοι Πόροι

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## Υποστήριξη

Για επιπλέον υποστήριξη και ερωτήσεις:
- Ανατρέξτε στην [τεκμηρίωση του Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- Εξετάστε τους [πόρους της κοινότητας MCP](https://modelcontextprotocol.io/)


## Τι ακολουθεί

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.