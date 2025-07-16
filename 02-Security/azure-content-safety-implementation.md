# Implementing Azure Content Safety with MCP

To strengthen MCP security against prompt injection, tool poisoning, and other AI-specific vulnerabilities, integrating Azure Content Safety is highly recommended. This guide provides implementation examples in multiple languages.

## C# Implementation

```csharp
using Azure.AI.ContentSafety;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Threading.Tasks;

public class MpcContentSafetyFilter
{
    private readonly ContentSafetyClient _contentSafetyClient;
    
    public MpcContentSafetyFilter(IConfiguration configuration)
    {
        // Initialize Azure Content Safety client
        _contentSafetyClient = new ContentSafetyClient(
            new Uri(configuration["ContentSafety:Endpoint"]),
            new AzureKeyCredential(configuration["ContentSafety:ApiKey"]));
    }
    
    public async Task<(bool isSafe, string reason)> ValidateToolRequest(string toolName, object parameters)
    {
        // Convert parameters to JSON string for analysis
        string parameterText = JsonSerializer.Serialize(parameters);
        
        // Create analysis request
        var textAnalysisRequest = new AnalyzeTextRequest
        {
            Text = parameterText,
            Categories = new TextCategories
            {
                Hate = new TextCategory { Severity = TextCategorySeverity.Medium },
                SelfHarm = new TextCategory { Severity = TextCategorySeverity.Medium },
                Sexual = new TextCategory { Severity = TextCategorySeverity.Medium },
                Violence = new TextCategory { Severity = TextCategorySeverity.Medium }
            },
            // Add blocklist to detect specific injection patterns
            BlocklistNames = new List<string> { "MCP-Injection-Patterns" }
        };
        
        // Analyze the tool parameters
        AnalyzeTextResponse response = await _contentSafetyClient.AnalyzeTextAsync(textAnalysisRequest);
        
        // Check if any category is flagged
        bool isSafe = true;
        string reason = string.Empty;
        
        if (response.CategoriesAnalysis != null)
        {
            if (response.CategoriesAnalysis.Hate?.Severity >= TextCategorySeverity.Medium)
            {
                isSafe = false;
                reason = "Content contains potential hate speech";
            }
            else if (response.CategoriesAnalysis.SelfHarm?.Severity >= TextCategorySeverity.Medium)
            {
                isSafe = false;
                reason = "Content contains potential self-harm content";
            }
            // Check other categories similarly
        }
        
        // Check blocklist matches
        if (response.BlocklistsMatch != null && response.BlocklistsMatch.Any())
        {
            isSafe = false;
            reason = "Content matched known injection patterns";
        }
        
        return (isSafe, reason);
    }
    
    // Method to scan tool responses before returning them
    public async Task<(bool isSafe, string reason)> ValidateToolResponse(object response)
    {
        // Similar implementation to ValidateToolRequest
        // ...
        
        return (true, string.Empty); // Placeholder
    }
}
```

## JavaScript/TypeScript Implementation

```typescript
import { ContentSafetyClient, AzureKeyCredential } from "@azure/ai-content-safety";

export class McpContentSafetyFilter {
  private contentSafetyClient: ContentSafetyClient;

  constructor(endpoint: string, apiKey: string) {
    this.contentSafetyClient = new ContentSafetyClient(
      endpoint,
      new AzureKeyCredential(apiKey)
    );
  }

  async validateToolRequest(toolName: string, parameters: any): Promise<{isSafe: boolean, reason: string}> {
    // Convert parameters to string for analysis
    const parameterText = JSON.stringify(parameters);
    
    // Create analysis request
    const analysisRequest = {
      text: parameterText,
      categories: {
        hate: { severity: "medium" },
        selfHarm: { severity: "medium" },
        sexual: { severity: "medium" },
        violence: { severity: "medium" }
      },
      blocklistNames: ["MCP-Injection-Patterns"]
    };
    
    try {
      // Analyze the tool parameters
      const response = await this.contentSafetyClient.analyzeText(analysisRequest);
      
      // Check if any category is flagged
      let isSafe = true;
      let reason = "";
      
      if (response.categoriesAnalysis) {
        if (response.categoriesAnalysis.hate?.severity >= 4) {
          isSafe = false;
          reason = "Content contains potential hate speech";
        } else if (response.categoriesAnalysis.selfHarm?.severity >= 4) {
          isSafe = false;
          reason = "Content contains potential self-harm content";
        }
        // Check other categories similarly
      }
      
      // Check blocklist matches
      if (response.blocklistsMatch && response.blocklistsMatch.length > 0) {
        isSafe = false;
        reason = "Content matched known injection patterns";
      }
      
      return { isSafe, reason };
    } catch (error) {
      console.error("Error analyzing content:", error);
      return { isSafe: false, reason: "Content analysis failed" };
    }
  }
  
  async validateToolResponse(response: any): Promise<{isSafe: boolean, reason: string}> {
    // Similar implementation to validateToolRequest
    // ...
    
    return { isSafe: true, reason: "" }; // Placeholder
  }
}
```

## Python Implementation

```python
from azure.ai.contentsafety import ContentSafetyClient
from azure.ai.contentsafety.models import AnalyzeTextOptions, TextCategory, TextCategorySeverity
from azure.core.credentials import AzureKeyCredential
import json

class McpContentSafetyFilter:
    def __init__(self, endpoint, api_key):
        # Initialize Azure Content Safety client
        self.content_safety_client = ContentSafetyClient(
            endpoint=endpoint,
            credential=AzureKeyCredential(api_key)
        )
    
    async def validate_tool_request(self, tool_name, parameters):
        # Convert parameters to JSON string for analysis
        parameter_text = json.dumps(parameters)
        
        # Create analysis request
        analysis_options = AnalyzeTextOptions(
            text=parameter_text,
            categories=[
                TextCategory(category="Hate", severity=TextCategorySeverity.MEDIUM),
                TextCategory(category="SelfHarm", severity=TextCategorySeverity.MEDIUM),
                TextCategory(category="Sexual", severity=TextCategorySeverity.MEDIUM),
                TextCategory(category="Violence", severity=TextCategorySeverity.MEDIUM)
            ],
            blocklist_names=["MCP-Injection-Patterns"]
        )
        
        try:
            # Analyze the tool parameters
            response = self.content_safety_client.analyze_text(analysis_options)
            
            # Check if any category is flagged
            is_safe = True
            reason = ""
            
            if response.categories_analysis:
                for category in response.categories_analysis:
                    if category.severity >= TextCategorySeverity.MEDIUM:
                        is_safe = False
                        reason = f"Content contains potential {category.category.lower()} content"
                        break
            
            # Check blocklist matches
            if response.blocklists_match and len(response.blocklists_match) > 0:
                is_safe = False
                reason = "Content matched known injection patterns"
            
            return is_safe, reason
        except Exception as e:
            print(f"Error analyzing content: {str(e)}")
            return False, "Content analysis failed"
    
    async def validate_tool_response(self, response):
        # Similar implementation to validate_tool_request
        # ...
        
        return True, "" # Placeholder
```

## Java Implementation

```java
import com.azure.ai.contentsafety.ContentSafetyClient;
import com.azure.ai.contentsafety.ContentSafetyClientBuilder;
import com.azure.ai.contentsafety.models.*;
import com.azure.core.credential.AzureKeyCredential;
import com.fasterxml.jackson.databind.ObjectMapper;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.CompletableFuture;

public class McpContentSafetyFilter {
    private final ContentSafetyClient contentSafetyClient;
    private final ObjectMapper objectMapper;

    public McpContentSafetyFilter(String endpoint, String apiKey) {
        // Initialize Azure Content Safety client
        this.contentSafetyClient = new ContentSafetyClientBuilder()
                .endpoint(endpoint)
                .credential(new AzureKeyCredential(apiKey))
                .buildClient();
        
        this.objectMapper = new ObjectMapper();
    }

    public CompletableFuture<SafetyResult> validateToolRequest(String toolName, Object parameters) {
        return CompletableFuture.supplyAsync(() -> {
            try {
                // Convert parameters to JSON string for analysis
                String parameterText = objectMapper.writeValueAsString(parameters);
                
                // Create analysis request
                AnalyzeTextOptions options = new AnalyzeTextOptions(parameterText);
                
                // Set categories to analyze
                List<TextCategory> categories = new ArrayList<>();
                categories.add(new TextCategory().setCategory(TextCategoryType.HATE).setSeverity(TextCategorySeverity.MEDIUM));
                categories.add(new TextCategory().setCategory(TextCategoryType.SELF_HARM).setSeverity(TextCategorySeverity.MEDIUM));
                categories.add(new TextCategory().setCategory(TextCategoryType.SEXUAL).setSeverity(TextCategorySeverity.MEDIUM));
                categories.add(new TextCategory().setCategory(TextCategoryType.VIOLENCE).setSeverity(TextCategorySeverity.MEDIUM));
                options.setCategories(categories);
                
                // Set blocklists to check
                List<String> blocklistNames = new ArrayList<>();
                blocklistNames.add("MCP-Injection-Patterns");
                options.setBlocklistNames(blocklistNames);
                
                // Analyze the tool parameters
                AnalyzeTextResult response = contentSafetyClient.analyzeText(options);
                
                // Check if any category is flagged
                boolean isSafe = true;
                String reason = "";
                
                if (response.getCategoriesAnalysis() != null) {
                    for (TextCategoryResult categoryResult : response.getCategoriesAnalysis()) {
                        if (categoryResult.getSeverity() >= TextCategorySeverity.MEDIUM.ordinal()) {
                            isSafe = false;
                            reason = "Content contains potential " + categoryResult.getCategory().toString().toLowerCase() + " content";
                            break;
                        }
                    }
                }
                
                // Check blocklist matches
                if (response.getBlocklistsMatch() != null && !response.getBlocklistsMatch().isEmpty()) {
                    isSafe = false;
                    reason = "Content matched known injection patterns";
                }
                
                return new SafetyResult(isSafe, reason);
            } catch (Exception e) {
                e.printStackTrace();
                return new SafetyResult(false, "Content analysis failed: " + e.getMessage());
            }
        });
    }

    public CompletableFuture<SafetyResult> validateToolResponse(Object response) {
        // Similar implementation to validateToolRequest
        // ...
        
        return CompletableFuture.completedFuture(new SafetyResult(true, "")); // Placeholder
    }

    // Helper class to return results
    public static class SafetyResult {
        private final boolean isSafe;
        private final String reason;

        public SafetyResult(boolean isSafe, String reason) {
            this.isSafe = isSafe;
            this.reason = reason;
        }

        public boolean isSafe() {
            return isSafe;
        }

        public String getReason() {
            return reason;
        }
    }
}
```

## Integration with MCP Server

To integrate Azure Content Safety with your MCP server, add the content safety filter as middleware in your request processing pipeline:

1. Initialize the filter during server startup
2. Validate all incoming tool requests before processing
3. Check all outgoing responses before returning them to clients
4. Log and alert on safety violations
5. Implement appropriate error handling for failed content safety checks

This provides a robust defense against:
- Prompt injection attacks
- Tool poisoning attempts
- Data exfiltration via malicious inputs
- Generation of harmful content

## Best Practices for Azure Content Safety Integration

1. **Custom Blocklists**: Create custom blocklists specifically for MCP injection patterns
2. **Severity Tuning**: Adjust severity thresholds based on your specific use case and risk tolerance
3. **Comprehensive Coverage**: Apply content safety checks to all inputs and outputs
4. **Performance Optimization**: Consider implementing caching for repeated content safety checks
5. **Fallback Mechanisms**: Define clear fallback behaviors when content safety services are unavailable
6. **User Feedback**: Provide clear feedback to users when content is blocked due to safety concerns
7. **Continuous Improvement**: Regularly update blocklists and patterns based on emerging threats
