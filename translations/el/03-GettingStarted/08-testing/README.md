<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:08:15+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "el"
}
-->
## Δοκιμές και Αποσφαλμάτωση

Πριν ξεκινήσετε τις δοκιμές του MCP server σας, είναι σημαντικό να κατανοήσετε τα διαθέσιμα εργαλεία και τις βέλτιστες πρακτικές για την αποσφαλμάτωση. Η αποτελεσματική δοκιμή διασφαλίζει ότι ο server σας λειτουργεί όπως αναμένεται και σας βοηθά να εντοπίσετε και να επιλύσετε γρήγορα τυχόν προβλήματα. Η παρακάτω ενότητα περιγράφει τις προτεινόμενες προσεγγίσεις για την επικύρωση της υλοποίησης MCP σας.

## Επισκόπηση

Αυτό το μάθημα καλύπτει πώς να επιλέξετε τη σωστή προσέγγιση δοκιμών και το πιο αποτελεσματικό εργαλείο δοκιμών.

## Στόχοι Μάθησης

Στο τέλος αυτού του μαθήματος, θα μπορείτε να:

- Περιγράψετε διάφορες προσεγγίσεις για δοκιμές.
- Χρησιμοποιήσετε διαφορετικά εργαλεία για να δοκιμάσετε αποτελεσματικά τον κώδικά σας.

## Δοκιμή MCP Servers

Το MCP παρέχει εργαλεία για να σας βοηθήσει να δοκιμάσετε και να αποσφαλματώσετε τους servers σας:

- **MCP Inspector**: Ένα εργαλείο γραμμής εντολών που μπορεί να εκτελεστεί τόσο ως CLI εργαλείο όσο και ως οπτικό εργαλείο.
- **Χειροκίνητη δοκιμή**: Μπορείτε να χρησιμοποιήσετε ένα εργαλείο όπως το curl για να εκτελέσετε αιτήματα web, αλλά οποιοδήποτε εργαλείο μπορεί να εκτελέσει HTTP είναι κατάλληλο.
- **Μονάδα δοκιμών (Unit testing)**: Είναι δυνατό να χρησιμοποιήσετε το αγαπημένο σας πλαίσιο δοκιμών για να ελέγξετε τις λειτουργίες τόσο του server όσο και του client.

### Χρήση του MCP Inspector

Έχουμε περιγράψει τη χρήση αυτού του εργαλείου σε προηγούμενα μαθήματα, αλλά ας το συζητήσουμε συνοπτικά. Πρόκειται για ένα εργαλείο κατασκευασμένο σε Node.js και μπορείτε να το χρησιμοποιήσετε καλώντας το εκτελέσιμο `npx`, το οποίο θα κατεβάσει και θα εγκαταστήσει προσωρινά το εργαλείο και θα καθαρίσει μετά την ολοκλήρωση της εκτέλεσης του αιτήματός σας.

Το [MCP Inspector](https://github.com/modelcontextprotocol/inspector) σας βοηθά να:

- **Ανακαλύψετε τις Δυνατότητες του Server**: Αυτόματος εντοπισμός διαθέσιμων πόρων, εργαλείων και prompts
- **Δοκιμάσετε την Εκτέλεση Εργαλείων**: Δοκιμάστε διαφορετικές παραμέτρους και δείτε τις απαντήσεις σε πραγματικό χρόνο
- **Προβολή Μεταδεδομένων Server**: Εξετάστε πληροφορίες server, σχήματα και ρυθμίσεις

Μια τυπική εκτέλεση του εργαλείου έχει ως εξής:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

Η παραπάνω εντολή ξεκινά ένα MCP και το οπτικό του περιβάλλον, ανοίγοντας μια τοπική web διεπαφή στον browser σας. Αναμένεται να δείτε έναν πίνακα ελέγχου που εμφανίζει τους εγγεγραμμένους MCP servers σας, τα διαθέσιμα εργαλεία, πόρους και prompts. Η διεπαφή σας επιτρέπει να δοκιμάσετε διαδραστικά την εκτέλεση εργαλείων, να εξετάσετε μεταδεδομένα server και να δείτε απαντήσεις σε πραγματικό χρόνο, καθιστώντας πιο εύκολη την επικύρωση και την αποσφαλμάτωση των υλοποιήσεων MCP server σας.

Έτσι μπορεί να φαίνεται: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.el.png)

Μπορείτε επίσης να τρέξετε αυτό το εργαλείο σε λειτουργία CLI, προσθέτοντας την παράμετρο `--cli`. Ακολουθεί ένα παράδειγμα εκτέλεσης του εργαλείου σε "CLI" λειτουργία που εμφανίζει όλα τα εργαλεία στον server:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Χειροκίνητη Δοκιμή

Εκτός από την εκτέλεση του εργαλείου inspector για τη δοκιμή των δυνατοτήτων του server, μια άλλη παρόμοια προσέγγιση είναι η χρήση ενός client που υποστηρίζει HTTP, όπως για παράδειγμα το curl.

Με το curl, μπορείτε να δοκιμάσετε απευθείας MCP servers χρησιμοποιώντας αιτήματα HTTP:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

Όπως φαίνεται από το παραπάνω παράδειγμα χρήσης του curl, χρησιμοποιείτε ένα POST αίτημα για να καλέσετε ένα εργαλείο με φορτίο που περιλαμβάνει το όνομα του εργαλείου και τις παραμέτρους του. Χρησιμοποιήστε την προσέγγιση που σας ταιριάζει καλύτερα. Τα CLI εργαλεία γενικά είναι πιο γρήγορα στη χρήση και μπορούν να αυτοματοποιηθούν, κάτι που είναι χρήσιμο σε περιβάλλον CI/CD.

### Μονάδα Δοκιμών (Unit Testing)

Δημιουργήστε μονάδες δοκιμών για τα εργαλεία και τους πόρους σας ώστε να διασφαλίσετε ότι λειτουργούν όπως αναμένεται. Ακολουθεί ένα παράδειγμα κώδικα δοκιμής.

```python
import pytest

from mcp.server.fastmcp import FastMCP
from mcp.shared.memory import (
    create_connected_server_and_client_session as create_session,
)

# Mark the whole module for async tests
pytestmark = pytest.mark.anyio


async def test_list_tools_cursor_parameter():
    """Test that the cursor parameter is accepted for list_tools.

    Note: FastMCP doesn't currently implement pagination, so this test
    only verifies that the cursor parameter is accepted by the client.
    """

 server = FastMCP("test")

    # Create a couple of test tools
    @server.tool(name="test_tool_1")
    async def test_tool_1() -> str:
        """First test tool"""
        return "Result 1"

    @server.tool(name="test_tool_2")
    async def test_tool_2() -> str:
        """Second test tool"""
        return "Result 2"

    async with create_session(server._mcp_server) as client_session:
        # Test without cursor parameter (omitted)
        result1 = await client_session.list_tools()
        assert len(result1.tools) == 2

        # Test with cursor=None
        result2 = await client_session.list_tools(cursor=None)
        assert len(result2.tools) == 2

        # Test with cursor as string
        result3 = await client_session.list_tools(cursor="some_cursor_value")
        assert len(result3.tools) == 2

        # Test with empty string cursor
        result4 = await client_session.list_tools(cursor="")
        assert len(result4.tools) == 2
    
```

Ο παραπάνω κώδικας κάνει τα εξής:

- Χρησιμοποιεί το πλαίσιο pytest που σας επιτρέπει να δημιουργείτε δοκιμές ως συναρτήσεις και να χρησιμοποιείτε δηλώσεις assert.
- Δημιουργεί έναν MCP Server με δύο διαφορετικά εργαλεία.
- Χρησιμοποιεί τη δήλωση `assert` για να ελέγξει ότι πληρούνται συγκεκριμένες συνθήκες.

Ρίξτε μια ματιά στο [πλήρες αρχείο εδώ](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

Με βάση το παραπάνω αρχείο, μπορείτε να δοκιμάσετε τον δικό σας server για να βεβαιωθείτε ότι οι δυνατότητες δημιουργούνται όπως πρέπει.

Όλα τα κύρια SDK έχουν παρόμοιες ενότητες δοκιμών, οπότε μπορείτε να προσαρμόσετε ανάλογα με το runtime που επιλέγετε.

## Παραδείγματα

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Πρόσθετοι Πόροι

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## Τι Ακολουθεί

- Επόμενο: [Deployment](/03-GettingStarted/09-deployment/README.md)

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να λάβετε υπόψη ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται η επαγγελματική μετάφραση από ανθρώπους. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.