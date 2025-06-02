<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a621fc52c7daec552eb8b3b48c0361dd",
  "translation_date": "2025-06-02T19:45:59+00:00",
  "source_file": "05-AdvancedTopics/mcp-routing/README.md",
  "language_code": "el"
}
-->
## Αρχιτεκτονική Δειγματοληψίας και Δρομολόγησης στο MCP

Η δειγματοληψία αποτελεί κρίσιμο στοιχείο του Πρωτοκόλλου Πλαισίου Μοντέλου (MCP), που επιτρέπει την αποδοτική επεξεργασία και δρομολόγηση αιτημάτων. Περιλαμβάνει την ανάλυση των εισερχόμενων αιτημάτων για να προσδιοριστεί το πιο κατάλληλο μοντέλο ή υπηρεσία που θα τα διαχειριστεί, με βάση διάφορα κριτήρια όπως ο τύπος περιεχομένου, το πλαίσιο χρήστη και το φόρτο του συστήματος.

Η δειγματοληψία και η δρομολόγηση μπορούν να συνδυαστούν για να δημιουργήσουν μια ισχυρή αρχιτεκτονική που βελτιστοποιεί τη χρήση πόρων και εξασφαλίζει υψηλή διαθεσιμότητα. Η διαδικασία της δειγματοληψίας μπορεί να χρησιμοποιηθεί για την ταξινόμηση των αιτημάτων, ενώ η δρομολόγηση τα κατευθύνει προς τα κατάλληλα μοντέλα ή υπηρεσίες.

Το παρακάτω διάγραμμα απεικονίζει πώς η δειγματοληψία και η δρομολόγηση συνεργάζονται σε μια ολοκληρωμένη αρχιτεκτονική MCP:

```mermaid
flowchart TB
    Client([MCP Client])
    
    subgraph "Request Processing"
        Router{Request Router}
        Analyzer[Content Analyzer]
        Sampler[Sampling Configurator]
    end
    
    subgraph "Server Selection"
        LoadBalancer{Load Balancer}
        ModelSelector[Model Selector]
        ServerPool[(Server Pool)]
    end
    
    subgraph "Model Processing"
        ModelA[Specialized Model A]
        ModelB[Specialized Model B]
        ModelC[General Model]
    end
    
    subgraph "Tool Execution"
        ToolRouter{Tool Router}
        ToolRegistryA[(Primary Tools)]
        ToolRegistryB[(Regional Tools)]
    end
    
    Client -->|Request| Router
    Router -->|Analyze| Analyzer
    Analyzer -->|Configure| Sampler
    Router -->|Route Request| LoadBalancer
    LoadBalancer --> ServerPool
    ServerPool --> ModelSelector
    ModelSelector --> ModelA
    ModelSelector --> ModelB
    ModelSelector --> ModelC
    
    ModelA -->|Tool Calls| ToolRouter
    ModelB -->|Tool Calls| ToolRouter
    ModelC -->|Tool Calls| ToolRouter
    
    ToolRouter --> ToolRegistryA
    ToolRouter --> ToolRegistryB
    
    ToolRegistryA -->|Results| ModelA
    ToolRegistryA -->|Results| ModelB
    ToolRegistryA -->|Results| ModelC
    ToolRegistryB -->|Results| ModelA
    ToolRegistryB -->|Results| ModelB
    ToolRegistryB -->|Results| ModelC
    
    ModelA -->|Response| Client
    ModelB -->|Response| Client
    ModelC -->|Response| Client
    
    style Client fill:#d5e8f9,stroke:#333
    style Router fill:#f9d5e5,stroke:#333
    style LoadBalancer fill:#f9d5e5,stroke:#333
    style ToolRouter fill:#f9d5e5,stroke:#333
    style ModelA fill:#c2f0c2,stroke:#333
    style ModelB fill:#c2f0c2,stroke:#333
    style ModelC fill:#c2f0c2,stroke:#333
```

## Τι ακολουθεί

- [Sampling](../mcp-sampling/README.md)

**Αποποίηση Ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που προσπαθούμε για ακρίβεια, παρακαλούμε να έχετε υπόψη ότι οι αυτοματοποιημένες μεταφράσεις ενδέχεται να περιέχουν σφάλματα ή ανακρίβειες. Το πρωτότυπο έγγραφο στη μητρική του γλώσσα πρέπει να θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.